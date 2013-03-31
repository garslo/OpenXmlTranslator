using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Math;

using OL = OpenXmlTranslate.LaTeX.Math;

namespace OpenXmlTranslate.LaTeX
{
    static partial class OpenXmlHandlers
    {
        public static string AsLaTeX(Box box)
        {
            // Boxes are mechanisms for grouping or spacing. We're ignoring
            // them for now.
            return OL.Translate(box.Base.Elements());
        }
    }
}
