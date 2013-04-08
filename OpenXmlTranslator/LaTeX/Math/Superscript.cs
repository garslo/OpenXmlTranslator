using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXmlTranslate.LaTeX.Math
{
    class Superscript : LaTeXElement
    {
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

        public Superscript(LaTeXElement theInnerElement, LaTeXElement theSuperscriptArg)
        {
            innerElement = theInnerElement;
            superscriptArg = theSuperscriptArg;
        }

        public override string ToString()
        {
            return String.Format("{0}^{{{1}}}", innerElement, superscriptArg);
        }
    }
}
