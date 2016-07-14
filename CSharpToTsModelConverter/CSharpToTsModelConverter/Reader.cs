using System;
using System.Collections.Generic;
using CSharpToTsModelConverter;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CSharpToTsModelConverter
{
    public class Reader
    {
        private string className;
        private List<string> vars = new List<string>();
        private List<string> annotations = new List<string>();

        public void ConvertText(string filePath)
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(filePath);
            string fileText = "";
            
            foreach (string line in lines)
            {
               ParseText(line.Trim());
            }

            fileText += ("class " + className + " {") + Environment.NewLine;
            fileText += Environment.NewLine;

            foreach (string @var in vars)
            {
                fileText += @var + Environment.NewLine;
                fileText += Environment.NewLine;
            }

            fileText += "}" + Environment.NewLine;
            System.IO.Directory.CreateDirectory(@"C:\Users\Public\CS2TS\");
            System.IO.File.WriteAllText(@"C:\Users\Public\CS2TS\"+className+".model.ts", fileText);
            Process.Start(@"C:\Users\Public\CS2TS\");
        }

        public void ParseText(string line)
        {
            if(Regex.IsMatch(line, Patterns.CLASS_PATTERN))
            {
                string @class = new Regex(Patterns.CLASS_PATTERN).Replace(line, "");
                if(@class.Contains(' '))
                @class = @class.Substring(0, @class.Length - @class.IndexOf(' '));
                className = @class;

            }else if(Regex.IsMatch(line, Patterns.ANNOTATION_PATTERN))
            {
                annotations.Add(@"// " + line);
            }else if(Regex.IsMatch(line, Patterns.VAR_PATTERN))
            {
                string varName = new Regex(Patterns.VAR_PATTERN).Match(line).ToString();
                varName = varName.Substring(0, varName.IndexOf(' '));
                varName = Char.ToLowerInvariant(varName[0]) + varName.Substring(1);

                string varType = "any";

                if(Regex.IsMatch(line, Patterns.NUMBER_PATTERN))
                {
                    varType = "number";
                }else if(Regex.IsMatch(line, Patterns.STRING_PATTERN))
                {
                    varType = "string";
                }else if(Regex.IsMatch(line, Patterns.BOOL_PATTERN))
                {
                    varType = "boolean";
                }

                if (varName.Contains("[]"))
                {
                    varName.Substring(0, varName.Length - 2);
                    varType += "[]";
                }

                string parsedVar = "";

                foreach (string annotation in annotations)
                {
                    parsedVar += annotation + Environment.NewLine;
                }
                parsedVar += varName + ": " + varType + ";";
                vars.Add(parsedVar);
                //clear annotations
                annotations = new List<string>();
            }
        }
    }
}
