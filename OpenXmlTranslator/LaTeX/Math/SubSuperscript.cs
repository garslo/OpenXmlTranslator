using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXmlTranslate.LaTeX.Math
{
    class SubSuperscript : LaTeXElement
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

        public SubSuperscript(LaTeXElement theInnerElement, LaTeXElement theSubscript, LaTeXElement theSuperscript)
        {
            innerElement = theInnerElement;
            subscriptArg = theSubscript;
            superscriptArg = theSuperscript;
        }

        public override string ToString()
        {
            return String.Format("{0}^{{{1}}}_{{{2}}}", innerElement, superscriptArg, subscriptArg);
        }
    }
}
