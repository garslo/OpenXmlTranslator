using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXmlTranslate.LaTeX.Math
{
    class Subscript : LaTeXElement
    {
        private LaTeXElement subscriptArg;
        public LaTeXElement SubscriptArg
        {
            get { return subscriptArg; }
        }

        private LaTeXElement innerElement;
        public LaTeXElement InnerElement
        {
            get { return innerElement; }
        }

        public Subscript(LaTeXElement theInnerElement, LaTeXElement theSubscript)
        {
            innerElement = theInnerElement;
            subscriptArg = theSubscript;
        }

        public override string ToString()
        {
            return String.Format("{0}_{{{1}}}", innerElement, subscriptArg);
        }
    }
}
