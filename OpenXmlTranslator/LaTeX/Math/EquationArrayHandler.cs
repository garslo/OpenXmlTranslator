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
        private static string EquationRowSeparator
        {
            get { return String.Format(@" \\{0}    ", NewLine); }
        }

        private static string NewLine = "\n";

        private static string EquationArrayTemplate =
@"\begin{{align*}}
    {0}
\end{{align*}}";

        public static string AsLaTeX(EquationArray eqArr)
        {
            return String.Format(EquationArrayTemplate, eqArr.Rows());
        }

        private static string Rows(this EquationArray eqArr)
        {
            IEnumerable<Base> rows = eqArr.Elements<Base>();
            return String.Join(EquationRowSeparator, rows.Select(OL.Translate));
        }

    }
}
