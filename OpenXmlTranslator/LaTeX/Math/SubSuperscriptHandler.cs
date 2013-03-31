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
        public static string AsLaTeX(SubSuperscript elem)
        {
            string sub = elem.GetScript<SubArgument>();
            string sup = elem.GetScript<SuperArgument>();
            Base theBase = elem.GetFirstChild<Base>();

            return String.Format("{0}^{{{1}}}_{{{2}}}", OL.Translate(theBase), sup, sub);
        }
    }
}
