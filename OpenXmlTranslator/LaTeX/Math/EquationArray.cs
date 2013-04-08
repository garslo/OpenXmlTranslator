using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXmlTranslate.LaTeX.Math
{
    class EquationArray : LaTeXElement
    {
        private IEnumerable<LaTeXElement> rows;
        public IEnumerable<LaTeXElement> Rows
        {
            get { return rows; }
        }

        // TODO: Deal with Windows/Unix line endings
        private string equationArrayTemplate = "\\begin{{align*}}\n    {0}\n\\end{{align*}}";

        public EquationArray(params LaTeXElement[] theRows)
        {
            rows = theRows;
        }

        public EquationArray(IEnumerable<LaTeXElement> theRows)
        {
            rows = theRows;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
