using Dignus.Extensions.AspNetCore;
using Dignus.Extensions.Log;
using Dignus.Log;
using Dignus.Utils;
using System.Reflection;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            LogBuilder.Configuration(LogConfigXmlReader.Load("DignusLog.config")).Build();

            Environment.CurrentDirectory = AppContext.BaseDirectory;

            var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
            {
                Args = args,
                ContentRootPath = AppContext.BaseDirectory
            });
            InitDependency(builder);

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.MapControllerRoute(
                name: "area",
                pattern: "{area:exists}/{controller=Ticks2DateTime}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Ticks2DateTime}/{action=Index}/{id?}"
            );

            app.Use(async (httpContext, next) =>
            {
                try
                {
                    if (httpContext.Request.Method == HttpMethods.Get)
                    {
                        LogHelper.Info($"[{httpContext.Connection.RemoteIpAddress}] [{httpContext.Request.Path}]");
                    }

                    await next();
                }
                catch (Exception ex)
                {
                    LogHelper.Fatal(ex);
                }
            });

            app.Run();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper.Fatal(e.ExceptionObject as Exception);
            Environment.Exit(1);
        }

        private static void InitDependency(WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.RegisterDependencies(Assembly.GetExecutingAssembly());

            builder.Services.AddSingleton<HttpRequester, HttpRequester>();
        }
    }
}
