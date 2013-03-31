using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Math;

using OL = OpenXmlTranslate.LaTeX.Math;

namespace OpenXmlTranslate.LaTeX
{
    using DictT = Dictionary<char, string>;
    static partial class OpenXmlHandlers
    {
        static private DictT unicodeMap;

        public static string AsLaTeX(Run run)
        {
            if (unicodeMap == null)
                PopulateUnicodeMap();
            return run.InnerText.ReplaceUnicode().EliminateExtraSpaces();
        }

        private static void PopulateUnicodeMap()
        {
            unicodeMap = new DictT
            {
                // Uppercase
                {'\u0391', @"\Alpha"},
                {'\u0392', @"\Beta"},
                {'\u0393', @"\Gamma"},
                {'\u0394', @"\Delta"},
                {'\u0395', @"\Epsilon"},
                {'\u0396', @"\Zeta"},
                {'\u0397', @"\Eta"},
                {'\u0398', @"\Theta"},
                {'\u0399', @"\Iota"},
                {'\u039A', @"\Kappa"},
                {'\u039B', @"\Lamda"},
                {'\u039C', @"\Mu"},
                {'\u039D', @"\Nu"},
                {'\u039E', @"\Xi"},
                {'\u039F', @"\Omicron"},
                {'\u03A0', @"\Pi"},
                {'\u03A1', @"\Rho"},
                {'\u03A3', @"\Sigma"},
                {'\u03A4', @"\Tau"},
                {'\u03A5', @"\Upsilon"},
                {'\u03A6', @"\Phi"},
                {'\u03A7', @"\Chi"},
                {'\u03A8', @"\Psi"},
                {'\u03A9', @"\Omega"},
                // Lowercase
                {'\u03B1', @"\alpha"},
                {'\u03B2', @"\beta"},
                {'\u03B3', @"\gamma"},
                {'\u03B4', @"\delta"},
                {'\u03B5', @"\epsilon"},
                {'\u03B6', @"\zeta"},
                {'\u03B7', @"\eta"},
                {'\u03B8', @"\theta"},
                {'\u03B9', @"\iota"},
                {'\u03BA', @"\kappa"},
                {'\u03BB', @"\lambda"},
                {'\u03BC', @"\mu"},
                {'\u03BD', @"\nu"},
                {'\u03BE', @"\xi"},
                {'\u03BF', @"\omicron"},
                {'\u03C0', @"\pi"},
                {'\u03C1', @"\rho"},
                {'\u03C2', @"\sigma"},
                {'\u03C3', @"\sigma"},
                {'\u03C4', @"\tau"},
                {'\u03C5', @"\upsilon"},
                {'\u03C6', @"\phi"},
                {'\u03C7', @"\chi"},
                {'\u03C8', @"\psi"},
                {'\u03C9', @"\omega"},
            };
        }

        private static string ReplaceUnicode(this string text)
        {
            var noUnicode = new StringBuilder();
            foreach (char ch in text)
            {
                if (unicodeMap.ContainsKey(ch))
                {
                    noUnicode.Append(unicodeMap[ch]);
                    // LaTeX might gnarf the command if we don't include a trailing space.
                    // E.g. δb -> \deltab is different from δb -> \delta b
                    noUnicode.Append(" ");
                }
                else
                    noUnicode.Append(ch);
            }
            return noUnicode.ToString();
        }

        private static string EliminateExtraSpaces(this string text)
        {
            Regex reg = new Regex(@"\s+");
            return reg.Replace(text, " ").Trim();
        }
    }
}
