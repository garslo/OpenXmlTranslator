using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXmlTranslate.LaTeX.Math
{
    class Base : LaTeXElement
    {
        private IEnumerable<LaTeXElement> innerElements;
        public IEnumerable<LaTeXElement> InnerElements
        {
            get { return innerElements; }
        }

        public Base(params LaTeXElement[] theInnerElements)
            : this(theInnerElements.AsEnumerable())
        { }

        public Base(IEnumerable<LaTeXElement> theInnerElements)
        {
            innerElements = theInnerElements;
        }

        public override string ToString()
        {
            return String.Join("", innerElements);
        }
    }
}
