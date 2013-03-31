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
        public static string AsLaTeX(Superscript elem)
        {
            Base theBase = elem.GetFirstChild<Base>();
            string sup = elem.GetScript<SuperArgument>();
            return String.Format("{0}^{{{1}}}", OL.Translate(theBase), sup);
        }
    }
}
