using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Math;

using OL = OpenXmlTranslate.LaTeX.Math;

namespace OpenXmlTranslate.LaTeX
{
    static partial class OpenXmlHandlers
    {
        public static string AsLaTeX(Radical rad)
        {
            return String.Format(rad.BuildFormatString(), OL.Translate(rad.Base));
        }

        private static string BuildFormatString(this Radical rad)
        {
            if (rad.HasExplicitDegree())
            {
                string degree = rad.Degree();
                return @"\sqrt[" + degree.EscapeForFormat() + "]{{{0}}}";
            }
            return @"\sqrt{{{0}}}";
        }

        private static string EscapeForFormat(this string str)
        {
            return str.Replace("{", "{{").Replace("}", "}}");
        }
        
        private static string Degree(this Radical rad)
        {
            return OL.Translate(rad.Degree.Elements());
        }

        private static bool HasExplicitDegree(this Radical rad)
        {
            if (rad.Degree != null && rad.Degree.HasExplicitDegree())
                return true;
            return false;
        }

        private static bool HasExplicitDegree(this Degree deg)
        {
            return deg.Descendants<Text>().Count() != 0;
        }
    }
}
