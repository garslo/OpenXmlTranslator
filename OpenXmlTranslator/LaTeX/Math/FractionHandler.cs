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
        public static string AsLaTeX(Fraction fraction)
        {
            return String.Format(@"\frac{{{0}}}{{{1}}}", 
                                 OL.Translate(fraction.Numerator.Elements()),
                                 OL.Translate(fraction.Denominator.Elements()));
        }
    }
}
