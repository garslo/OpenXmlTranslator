using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DocumentFormat.OpenXml;
using OM = DocumentFormat.OpenXml.Math;

using OLM = OpenXmlTranslate.LaTeX.Math;

namespace OpenXmlTranslate.LaTeX
{

    using DictT = Dictionary<Type, Func<OpenXmlElement, LaTeXElement>>;
    public class OpenXmlToLaTeXElementConverter : ElementConverter<OpenXmlElement, LaTeXElement>
    {
        private DictT ElementMapping;

        public OpenXmlToLaTeXElementConverter()
        {
            ElementMapping = new DictT
                {
                    {typeof(OM.Bar), ConvertBar},
                    {typeof(OM.Box), ConvertBox},
                    {typeof(OM.Delimiter), ConvertDelimiter},
                    {typeof(OM.EquationArray), ConvertEquationArray},
                    {typeof(OM.Fraction), ConvertFraction},
                    {typeof(OM.MathFunction), ConvertMathFunction},
                    {typeof(OM.PreSubSuper), ConvertPreSubSuper},
                    {typeof(OM.Radical), ConvertRadical},
                    {typeof(OM.Run), ConvertRun},
                    {typeof(OM.Subscript), ConvertSubscript},
                    {typeof(OM.SubSuperscript), ConvertSubSuperscript},
                    {typeof(OM.Superscript), ConvertSuperscript},
                    {typeof(OM.Base), ConvertBase},
                };
        }

        public LaTeXElement Convert(OpenXmlElement element)
        {
            if (element == null)
                throw new ArgumentNullException();

            Func<OpenXmlElement, LaTeXElement> convertFunc;
            if (ElementMapping.TryGetValue(element.GetType(), out convertFunc))
                return convertFunc(element);

            throw new ArgumentException("Element type " + element + " not supported.");
        }

        private OLM.Bar ConvertBar(OpenXmlElement element)
        {
            var oxmlBar = (OM.Bar)element;
            var olmBar = new OLM.Bar(Convert(oxmlBar.Base));
            return olmBar;
        }

        private OLM.Base ConvertBase(OpenXmlElement element)
        {
            var theBase = (OM.Base)element;
            return new OLM.Base(theBase.Elements().Select(Convert));
        }

        private OLM.Box ConvertBox(OpenXmlElement element)
        {
            var box = (OM.Box)element;
            return new OLM.Box(Convert(box.Base));
        }

        private OLM.Delimiter ConvertDelimiter(OpenXmlElement element)
        {
            var delimiter = (OM.Delimiter)element;
            Tuple<string, string> leftRightDelims = delimiter.GetDelimiters();
            OpenXmlElement theBase = element.GetFirstChild<OM.Base>();
            return new OLM.Delimiter(leftRightDelims.Item1, Convert(theBase), leftRightDelims.Item2);
        }

        private OLM.EquationArray ConvertEquationArray(OpenXmlElement eqArr)
        {
            return new OLM.EquationArray();
        }

        private OLM.Fraction ConvertFraction(OpenXmlElement fraction)
        {
            return new OLM.Fraction(new OLM.Run("x"), new OLM.Run("y"));
        }

        private OLM.MathFunction ConvertMathFunction(OpenXmlElement func)
        {
            return new OLM.MathFunction(new OLM.Run("f"), new OLM.Run("x"));
        }

        private OLM.PreSubSuper ConvertPreSubSuper(OpenXmlElement script)
        {
            return new OLM.PreSubSuper(new OLM.Run("x"), new OLM.Run("1"), new OLM.Run("2"));
        }

        private OLM.Radical ConvertRadical(OpenXmlElement radical)
        {
            return new OLM.Radical(new OLM.Run("x"));
        }

        private OLM.Run ConvertRun(OpenXmlElement element)
        {
            var run = (OM.Run)element;
            return new OLM.Run(run.InnerText);
        }

        private OLM.Subscript ConvertSubscript(OpenXmlElement script)
        {
            return new OLM.Subscript(new OLM.Run("x"), new OLM.Run("1"));
        }

        private OLM.SubSuperscript ConvertSubSuperscript(OpenXmlElement script)
        {
            return new OLM.SubSuperscript(new OLM.Run("x"), new OLM.Run("1"), new OLM.Run("2"));
        }

        private OLM.Superscript ConvertSuperscript(OpenXmlElement script)
        {
            return new OLM.Superscript(new OLM.Run("x"), new OLM.Run("1"));
        }
    }
}
