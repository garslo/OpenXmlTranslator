using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXmlTranslate.LaTeX.Math
{
    class MathFunction : LaTeXElement
    {
        private LaTeXElement name;
        public LaTeXElement Name
        {
            get { return name; }
        }

        private IEnumerable<LaTeXElement> args;
        public IEnumerable<LaTeXElement> Args
        {
            get { return args; }
        }

        private List<string> standardFunctions = new List<string>
        {
            "sin",
            "cos",
            "tan",
            "csc",
            "sec",
            "cot",
            "log",
            "ln",
            "lim",
            "max",
            "min",
            "exp",
        };

        public MathFunction(LaTeXElement functionName, params LaTeXElement[] theArgs)
            : this(functionName, theArgs.AsEnumerable())
        { }

        public MathFunction(LaTeXElement functionName, IEnumerable<LaTeXElement> theArgs)
        {
            name = functionName;
            args = theArgs;
        }

        public override string ToString()
        {
            return String.Format("{0}{1}", AddLaTeXDecorations(name.ToString()), ArgString());
        }

        private string AddLaTeXDecorations(string functionName)
        {
            if (standardFunctions.Contains(functionName))
                return String.Format(@"\{0} ", functionName);
            return functionName;
        }

        private string ArgString()
        {
            IEnumerable<string> stringArgs = args.Select(arg => arg.ToString());
            return String.Join(", ", stringArgs);
        }
    }
}
