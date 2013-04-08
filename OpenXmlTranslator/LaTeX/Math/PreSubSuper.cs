using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXmlTranslate.LaTeX.Math
{
    class PreSubSuper : LaTeXElement
    {
        private LaTeXElement subscriptArg;
        public LaTeXElement SubscriptArg
        {
            get { return subscriptArg; }
        }

        private LaTeXElement superscriptArg;
        public LaTeXElement SuperscriptArg
        {
            get { return superscriptArg; }
        }

        private LaTeXElement innerElement;
        public LaTeXElement InnerElement
        {
            get { return innerElement; }
        }

        public PreSubSuper(LaTeXElement theInnerElement, LaTeXElement theSubscript, LaTeXElement theSuperscript)
        {
            subscriptArg = theSubscript;
            superscriptArg = theSuperscript;
            innerElement = theInnerElement;
        }

        public override string ToString()
        {
            return String.Format("{{}}^{{{0}}}_{{{1}}}{2}", superscriptArg, subscriptArg, innerElement);
        }
    }
}
