using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXmlTranslate.LaTeX.Math
{
    class Radical : LaTeXElement
    {
        private LaTeXElement degree;
        public LaTeXElement Degree
        {
            get { return degree; }
        }

        private LaTeXElement innerElement;
        public LaTeXElement InnerElement
        {
            get { return innerElement; }
        }

        public Radical(LaTeXElement theInnerElement)
            : this(theInnerElement, null)
        { }

        public Radical(LaTeXElement theInnerElement, LaTeXElement theDegree)
        {
            innerElement = theInnerElement;
            degree = theDegree;
        }

        public override string ToString()
        {
            if (degree == null)
                return HasNoDegreeToString();
            return HasDegreeToString();
        }

        private string HasNoDegreeToString()
        {
            return String.Format(@"\sqrt{{{0}}}", innerElement);
        }

        private string HasDegreeToString()
        {
            return String.Format(@"\sqrt[{0}]{{{1}}}", degree, innerElement);
        }
    }
}
