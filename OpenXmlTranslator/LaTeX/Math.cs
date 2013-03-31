using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Math;

namespace OpenXmlTranslate.LaTeX
{
    static public class Math
    {
        public static string Translate(IEnumerable<OpenXmlElement> oMaths)
        {
            return String.Join("", oMaths.Select(Translate));
        }

        public static string Translate(OpenXmlElement oMath)
        {
            return oMath.AsLaTeX();
        }

        private static string AsLaTeX(this OpenXmlElement oMath)
        {
            // This is (maybe) better than doing `if (oMath is Bar) ... else if (oMath is BorderBox) ...`
            switch (oMath.LocalName)
            {
                case "bar":
                    return OpenXmlHandlers.AsLaTeX(oMath as Bar);
                case "borderBox":
                    return OpenXmlHandlers.AsLaTeX(oMath as BorderBox);
                case "box":
                    return OpenXmlHandlers.AsLaTeX(oMath as Box);
                case "d":
                    return OpenXmlHandlers.AsLaTeX(oMath as Delimiter);
                case "e":
                    return OpenXmlHandlers.AsLaTeX(oMath as Base);
                case "eqArr":
                    return OpenXmlHandlers.AsLaTeX(oMath as EquationArray);
                case "f":
                    return OpenXmlHandlers.AsLaTeX(oMath as Fraction);
                case "func":
                    return OpenXmlHandlers.AsLaTeX(oMath as MathFunction);
                case "limLow":
                    return OpenXmlHandlers.AsLaTeX(oMath as LimitLower);
                case "limUpp":
                    return OpenXmlHandlers.AsLaTeX(oMath as LimitUpper);
                case "nary":
                    return OpenXmlHandlers.AsLaTeX(oMath as Nary);
                case "oMath":
                    return Translate(oMath.Elements());
                case "r":
                    return OpenXmlHandlers.AsLaTeX(oMath as Run);
                case "rad":
                    return OpenXmlHandlers.AsLaTeX(oMath as Radical);
                case "sPre":
                    return OpenXmlHandlers.AsLaTeX(oMath as PreSubSuper);
                case "sSub":
                    return OpenXmlHandlers.AsLaTeX(oMath as Subscript);
                case "sSup":
                    return OpenXmlHandlers.AsLaTeX(oMath as Superscript);
                case "sSubSup":
                    return OpenXmlHandlers.AsLaTeX(oMath as SubSuperscript);
                default:
                    return oMath.InnerText;
            }
        }
    }
}