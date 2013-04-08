using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenXmlTranslate
{
    static class StringExtensions
    {
        public static string EliminateExtraSpaces(this string str)
        {
            Regex reg = new Regex(@"\s+");
            return reg.Replace(str, " ").Trim();
        }
    }
}
