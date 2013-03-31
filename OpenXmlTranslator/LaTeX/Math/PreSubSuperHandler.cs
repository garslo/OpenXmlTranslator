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
        public static string AsLaTeX(PreSubSuper elem)
        {
            string sup = elem.GetScript<SuperArgument>();
            string sub = elem.GetScript<SubArgument>();
            OpenXmlElement theBase = elem.GetFirstChild<Base>();
            return String.Format(@"{{}}^{{{0}}}_{{{1}}}{2}", sup, sub, OL.Translate(theBase));            
        }

        private static string GetScript<T>(this OpenXmlElement elem)
            where T : OpenXmlElement
        {
            IEnumerable<T> scripts = elem.Elements<T>();
            if (scripts.Count() != 0)
                return String.Join("", scripts.Select(script => OL.Translate(script.Elements())));
            return "";
        }
    }
}
