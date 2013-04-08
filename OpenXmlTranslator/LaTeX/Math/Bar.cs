using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXmlTranslate.LaTeX.Math
{
    public class Bar : LaTeXElement
    {
        private LaTeXElement innerElement;
        public LaTeXElement InnerElement
        {
            get { return innerElement; }
        }

        public Bar(LaTeXElement theInnerElement)
        {
            innerElement = theInnerElement;
        }

        public override string ToString()
        {
            return String.Format(@"\bar{{{0}}}", innerElement);
        }
    }
}
