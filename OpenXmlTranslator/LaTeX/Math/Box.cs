using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXmlTranslate.LaTeX.Math
{
    class Box : LaTeXElement
    {
        private LaTeXElement innerElement;
        public LaTeXElement InnerElement
        {
            get { return innerElement; }
        }

        public Box(LaTeXElement theInnerElement)
        {
            innerElement = theInnerElement;
        }

        public override string ToString()
        {
            return innerElement.ToString();
        }
    }
}
