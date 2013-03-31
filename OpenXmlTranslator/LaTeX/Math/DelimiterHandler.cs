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
        public static string AsLaTeX(Delimiter delimiter)
        {
            Tuple<string, string> delims = delimiter.Delimiters();
            return String.Format(@"\left{0}{1}\right{2}", delims.Item1,
                                                          OL.Translate(delimiter.Elements()),
                                                          delims.Item2);
        }

        private static Tuple<string, string> Delimiters(this Delimiter delimiter)
        {
            // Delimiters default to parens
            var delims = Tuple.Create("(", ")");
            DelimiterProperties dPr = delimiter.Properties();
            if (dPr != null)
                delims = Tuple.Create(dPr.BegChr(delims.Item1),
                                      dPr.EndChr(delims.Item2));
            return delims;
        }

        private static DelimiterProperties Properties(this Delimiter delimiter)
        {
            IEnumerable<DelimiterProperties> dPrs = delimiter.Elements<DelimiterProperties>();
            if (dPrs.Count() == 0)
                return null;
            // There's only on dPr
            return dPrs.First();
        }

        private static string BegChr(this DelimiterProperties dPr, string fallback)
        {
            if (dPr.BeginChar == null)
                return fallback;
            // LaTeX doesn't like unescaped squiggly brackets.
            string value = dPr.BeginChar.Val.Value;
            return value == "{" ? @"\{" : value;
        }

        private static string EndChr(this DelimiterProperties dPr, string fallback)
        {
            if (dPr.EndChar == null)
                return fallback;
            // LaTeX doesn't like unescaped squiggly brackets.
            string value = dPr.EndChar.Val.Value;
            return value == "}" ? @"\}" : value;
        }
    }
}
