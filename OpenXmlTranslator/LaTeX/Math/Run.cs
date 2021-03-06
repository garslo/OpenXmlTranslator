﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenXmlTranslate.LaTeX.Math
{
    using DictT = Dictionary<char, string>;

    class Run : LaTeXElement
    {
        static private DictT unicodeMap = new DictT
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
                {'\u00B0', @"{}^{\circ}"}, // degree sign
                {'\u2248', @"\approx"},
        };

        private string innerText;
        public string InnerText
        {
            get { return innerText; }
        }


        public Run(string theInnerText)
        {
            innerText = ReplaceUnicode(theInnerText).EliminateExtraSpaces();
        }

        private string ReplaceUnicode(string text)
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

        public override string ToString()
        {
            return innerText;
        }
    }
}
