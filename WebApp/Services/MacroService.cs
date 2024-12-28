using DataContainer;
using Dignus.DependencyInjection.Attributes;
using Dignus.Log;
using Dignus.Utils;
using System.Xml.Serialization;

namespace WebApp.Services
{
    [Injectable(Dignus.DependencyInjection.LifeScope.Transient)]
    public class MacroService(HttpRequester httpRequester)
    {
        private const string GitHubHelpUrl = $"https://github.com/EomTaeWook/DiademMacro/blob/master/README.md";
        public async Task<VersionNote> GetLatestVersionAsync()
        {
            try
            {
                var versionNoteXml = await httpRequester.GetAsync("https://cdn.itdah.com/VersionNote.xml");

                if (string.IsNullOrEmpty(versionNoteXml))
                {
                    return null;
                }

                var serializer = new XmlSerializer(typeof(VersionNote));
                using (var reader = new StringReader(versionNoteXml))
                {
                    return (VersionNote)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return null;
        }
        public string GetGitHubHelpUrl()
        {
            return GitHubHelpUrl;
        }
    }
}
