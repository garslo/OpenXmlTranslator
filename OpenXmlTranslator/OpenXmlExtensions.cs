using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Math;

namespace OpenXmlTranslate
{
    public static class OpenXmlExtensions
    {
        public static Tuple<string, string> GetDelimiters(this Delimiter delimiter)
        {
            string defaultLeft = "(";
            string defaultRight = ")";

            DelimiterProperties dPr = delimiter.DelimiterProperties;
            if (dPr != null)
                return Tuple.Create(dPr.BegChr(defaultLeft), dPr.EndChr(defaultRight));

            return Tuple.Create(defaultLeft, defaultRight);
        }

        private static string BegChr(this DelimiterProperties dPr, string theDefault)
        {
            if (dPr.BeginChar == null)
                return theDefault;
            string value = dPr.BeginChar.Val;
            // LaTeX doesn't like unescaped squiggly brackets
            return value == "{" ? @"\{" : value;
        }

        private static string EndChr(this DelimiterProperties dPr, string theDefault)
        {
            if (dPr.EndChar == null)
                return theDefault;
            string value = dPr.EndChar.Val;
            // LaTeX doesn't like unescaped squiggly brackets
            return value == "}" ? @"\}" : value;
        }
    }
}
