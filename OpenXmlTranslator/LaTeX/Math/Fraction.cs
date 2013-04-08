using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXmlTranslate.LaTeX.Math
{
    class Fraction : LaTeXElement
    {
        private LaTeXElement numerator;
        public LaTeXElement Numerator
        {
            get { return numerator; }
        }

        private LaTeXElement denominator;
        public LaTeXElement Denominator
        {
            get { return denominator; }
        }

        public Fraction(LaTeXElement theNumerator, LaTeXElement theDenominator)
        {
            numerator = theNumerator;
            denominator = theDenominator;
        }

        public override string ToString()
        {
            return String.Format(@"\frac{{{0}}}{{{1}}}", numerator, denominator);
        }
    }
}
