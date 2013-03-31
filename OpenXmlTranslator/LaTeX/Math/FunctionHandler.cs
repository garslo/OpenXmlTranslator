using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Math;

using OL = OpenXmlTranslate.LaTeX.Math;

namespace OpenXmlTranslate.LaTeX
{
    static partial class OpenXmlHandlers
    {
        static private List<string> standardFunctions = new List<string>
        {
            "sin",
            "cos",
            "tan",
            "csc",
            "sec",
            "cot",
            "log",
            "ln",
            "lim",
            "max",
            "min",
            "exp",
        };

        public static string AsLaTeX(MathFunction func)
        {
            string args = OL.Translate(func.Base);
            return String.Format("{0}{1}", func.Name(), args);
        }

        private static string Name(this MathFunction func)
        {
            string fName = OL.Translate(func.FunctionName.Elements());
            return AddLaTeXDecorations(fName);
        }

        private static string AddLaTeXDecorations(string fName)
        {
            if (standardFunctions.Contains(fName))
                return String.Format(@"\{0} ", fName);
            return fName;
        }
    }
}
