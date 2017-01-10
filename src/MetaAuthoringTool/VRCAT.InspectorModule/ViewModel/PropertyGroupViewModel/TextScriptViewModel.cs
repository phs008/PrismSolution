using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.InspectorModule
{
    public class TextScriptViewModel
    {
        public readonly string ScriptFilePath;
        public TextScriptViewModel(string ScriptFilePath)
        {
            if(File.Exists(ScriptFilePath))
            {
                string line;
                StringBuilder sBuilder = new StringBuilder();
                FileStream fs = File.OpenRead(ScriptFilePath);
                using (StreamReader sr = new StreamReader(ScriptFilePath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        sBuilder.Append(line);
                        sBuilder.AppendLine();
                    }
                }
                ScriptData = sBuilder.ToString();
                this.ScriptFilePath = ScriptFilePath;
                fs.Close();
            }
        }
        public string ScriptData { get; set; }
    }
}
