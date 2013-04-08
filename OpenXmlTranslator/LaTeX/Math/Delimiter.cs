using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXmlTranslate.LaTeX.Math
{
    class Delimiter : LaTeXElement
    {
        private string leftDelim;
        public string LeftDelim
        {
            get { return leftDelim; }
        }

        private string rightDelim;
        public string RightDelim
        {
            get { return rightDelim; }
        }

        private LaTeXElement innerElement;
        public LaTeXElement InnerElement
        {
            get { return InnerElement; }
        }

        public Delimiter(string leftDelimiter, LaTeXElement theInnerElement, string rightDelimiter)
        {
            leftDelim = leftDelimiter;
            rightDelim = rightDelimiter;
            innerElement = theInnerElement;
        }

        public override string ToString()
        {
            return String.Format(@"\left{0}{1}\right{2}", leftDelim, innerElement, rightDelim);
        }
    }
}
