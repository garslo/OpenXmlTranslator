using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocumentFormat.OpenXml;

namespace OpenXmlTranslate.LaTeX
{
    public class OpenXmlToLaTeXTranslator : Translator<OpenXmlElement, LaTeXElement>
    {
        private LaTeXFactory factory;
        public OpenXmlToLaTeXTranslator(LaTeXFactory latexFactory)
        {
            factory = latexFactory;
        }

        public LaTeXElement Translate(OpenXmlElement element)
        {
            return factory.MakeFrom(element);
        }
    }
}
