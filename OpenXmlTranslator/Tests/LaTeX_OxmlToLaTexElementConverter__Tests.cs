using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using OM = DocumentFormat.OpenXml.Math;

using OpenXmlTranslate.LaTeX;
using OLM = OpenXmlTranslate.LaTeX.Math;

namespace OpenXmlTranslate.Tests
{
    [TestFixture]
    class LaTeX_OxmlToLaTexElementConverter__Tests
    {
        private LaTeXFactory factory;

        [SetUp]
        public void Init()
        {
            var converter = new OpenXmlToLaTeXElementConverter();
            factory = new LaTeXFactory(converter);
        }

        [Test]
        public void TestBarConversion()
        {
            OM.Bar bar = new OM.Bar(
                            new OM.Base()
                            );
            var result = factory.MakeFrom(bar);

            Assert.AreEqual(typeof(OLM.Bar), result.GetType());
        }

        [Test]
        public void TestBarWithContentConversion()
        {
            var bar = new OM.Bar(
                            new OM.Base(
                                new OM.Run(
                                    new OM.Text("y")
                                   )
                                )
                            );
            var result = factory.MakeFrom(bar);

            Assert.AreEqual(@"\bar{y}", result.ToString());
        }

        [Test]
        public void TestBoxConversion()
        {
            OM.Box box = new OM.Box(
                            new OM.Base()
                            );
            var result = factory.MakeFrom(box);

            Assert.AreEqual(typeof(OLM.Box), result.GetType());
        }

        [Test]
        public void TestBoxWithContentConversion()
        {
            var box = new OM.Box(
                        new OM.Base(
                            new OM.Run(
                                new OM.Text("y")
                                )
                            )
                        );
            var result = factory.MakeFrom(box);

            Assert.AreEqual("y", result.ToString());
        }

        [Test]
        public void TestDelimiterConversion()
        {
            OM.Delimiter delimiter = new OM.Delimiter(
                                        new OM.Base()
                                        );
            var result = factory.MakeFrom(delimiter);

            Assert.AreEqual(typeof(OLM.Delimiter), result.GetType());
        }

        [Test]
        public void TestDelimiterWithContentConversion()
        {
            var delimiter = new OM.Delimiter(
                                new OM.Base(
                                    new OM.Run(
                                        new OM.Text("y")
                                        )
                                    )
                                );
            var result = factory.MakeFrom(delimiter);

            Assert.AreEqual(@"\left(y\right)", result.ToString());
        }

        [Test]
        public void TestEquationArrayConversion()
        {
            OM.EquationArray eqArr = new OM.EquationArray();
            var result = factory.MakeFrom(eqArr);

            Assert.AreEqual(typeof(OLM.EquationArray), result.GetType());
        }

        [Test]
        [Ignore]
        public void TestEquationArrayWithContentConversion()
        {
        }

        [Test]
        public void TestFractionConversion()
        {
            OM.Fraction frac = new OM.Fraction();
            var result = factory.MakeFrom(frac);

            Assert.AreEqual(typeof(OLM.Fraction), result.GetType());
        }

        [Test]
        public void TestMathFunctionConversion()
        {
            OM.MathFunction func = new OM.MathFunction();
            var result = factory.MakeFrom(func);

            Assert.AreEqual(typeof(OLM.MathFunction), result.GetType());
        }

        [Test]
        public void TestPreSubSuperConversion()
        {
            OM.PreSubSuper script = new OM.PreSubSuper();
            var result = factory.MakeFrom(script);

            Assert.AreEqual(typeof(OLM.PreSubSuper), result.GetType());
        }

        [Test]
        public void TestRadicalConversion()
        {
            OM.Radical rad = new OM.Radical();
            var result = factory.MakeFrom(rad);

            Assert.AreEqual(typeof(OLM.Radical), result.GetType());
        }

        [Test]
        public void TestRunConversion()
        {
            OM.Run run = new OM.Run();
            var result = factory.MakeFrom(run);

            Assert.AreEqual(typeof(OLM.Run), result.GetType());
        }

        [Test]
        public void TestSubscriptConversion()
        {
            OM.Subscript script = new OM.Subscript();
            var result = factory.MakeFrom(script);

            Assert.AreEqual(typeof(OLM.Subscript), result.GetType());
        }

        [Test]
        public void TestSubSuperscriptConversion()
        {
            OM.SubSuperscript script = new OM.SubSuperscript();
            var result = factory.MakeFrom(script);

            Assert.AreEqual(typeof(OLM.SubSuperscript), result.GetType());
        }

        [Test]
        public void TestSuperscriptConversion()
        {
            OM.Superscript script = new OM.Superscript();
            var result = factory.MakeFrom(script);

            Assert.AreEqual(typeof(OLM.Superscript), result.GetType());
        }
    }
}
