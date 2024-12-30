using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TemplateContainers;

namespace DataContainer.Generated
{
    public partial class TemplateLoader
    {
        public static void Load(string path)
        {
            TemplateContainer<ConstantStringTemplate>.Load(path, "ConstantString.json");
        }
        public static void Load(Func<string, string> funcLoadJson)
        {
            TemplateContainer<ConstantStringTemplate>.Load("ConstantString.json", funcLoadJson);
        }
        public static void MakeRefTemplate()
        {
            TemplateContainer<ConstantStringTemplate>.MakeRefTemplate();
            
            TemplateContainer<ConstantStringTemplate>.Combine();
        }
    }
}
