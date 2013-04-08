using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Math;

namespace OpenXmlTranslate.LaTeX
{
    public class LaTeXFactory : GenericFactory<OpenXmlElement, LaTeXElement>
    {
        private ElementConverter<OpenXmlElement, LaTeXElement> converter;

        public LaTeXFactory(ElementConverter<OpenXmlElement, LaTeXElement> theConverter)
        {
            converter = theConverter;
        }

        public LaTeXElement MakeFrom(OpenXmlElement element)
        {
            return converter.Convert(element);
        }
    }
}
