using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using OLM = OpenXmlTranslate.LaTeX.Math;

namespace OpenXmlTranslate.Tests
{
    [TestFixture]
    class LaTeX_Math__Tests
    {
        // Bars (m:bar)
        [Test]
        public void TestBarCreation()
        {
            OLM.Bar bar = new OLM.Bar(new OLM.Run("x"));
            string expected = @"\bar{x}";

            Assert.AreEqual(expected, bar.ToString());
        }

        // Box (m:box)
        [Test]
        public void TestBoxCreation()
        {
            OLM.Box box = new OLM.Box(
                                new OLM.Run("this is inside a box")
                                );
            string expected = "this is inside a box";

            Assert.AreEqual(expected, box.ToString());
        }

        // Delimiter (m:d)
        [Test]
        public void TestDelimiterCreation()
        {
            OLM.Delimiter delimiter = new OLM.Delimiter(
                                        "(",
                                        new OLM.Run("x+1"),
                                        ")"
                                        );
            string expected = @"\left(x+1\right)";

            Assert.AreEqual(expected, delimiter.ToString());
        }

        // EquationArray (m:eqArr)
        [Test]
        [Ignore]
        public void TestEquationArrayCreation()
        {
            OLM.EquationArray eqArr = new OLM.EquationArray(
                                        new OLM.Run("x & + & 1 & = 4"),
                                        new OLM.Run("y & - & 3 & = 7")
                                        );
            string expected =
@"\begin{align*}
    x & + & 1 & = 4 \\
    y & - & 3 & = 7
\end{align*}";

            Assert.AreEqual(expected, eqArr.ToString());
        }

        // Fraction (m:f)
        [Test]
        public void TestFractionCreation()
        {
            OLM.Fraction frac = new OLM.Fraction(
                                    new OLM.Run("x"),
                                    new OLM.Run("y")
                                    );
            string expected = @"\frac{x}{y}";

            Assert.AreEqual(expected, frac.ToString());
        }

        // MathFunction (m:func)
        [Test]
        public void TestMathFunctionCreation()
        {
            OLM.MathFunction func = new OLM.MathFunction(
                                        new OLM.Run("f"),
                                        new OLM.Delimiter(
                                            "(",
                                            new OLM.Run("x"),
                                            ")"
                                            )
                                        );
            string expected = @"f\left(x\right)";

            Assert.AreEqual(expected, func.ToString());
        }

        [Test]
        public void TestMathFunctionStandardFunctionCreation()
        {
            OLM.MathFunction func = new OLM.MathFunction(
                                        new OLM.Run("sin"),
                                        new OLM.Delimiter(
                                            "(",
                                            new OLM.Run("x"),
                                            ")"
                                            )
                                        );
            string expected = @"\sin \left(x\right)";

            Assert.AreEqual(expected, func.ToString());
        }

        // TODO: Add Base support (to enable multipe arguments -- inside delimiter)
        [Test]
        [Ignore]
        public void TestMathFunctionMultipleArgsCreation()
        {
        }

        // PreSubSuper (m:sPre)
        [Test]
        public void TestPreSubSuperCreation()
        {
            OLM.PreSubSuper script = new OLM.PreSubSuper(
                                        new OLM.Run("x"),
                                        new OLM.Run("1"),
                                        new OLM.Run(@"2")
                                        );
            string expected = "{}^{2}_{1}x";

            Assert.AreEqual(expected, script.ToString());
        }

        // Radical (m:rad)
        [Test]
        public void TestRadicalCreation()
        {
            OLM.Radical rad = new OLM.Radical(
                                new OLM.Run("x")
                                );
            string expected = @"\sqrt{x}";

            Assert.AreEqual(expected, rad.ToString());
        }

        [Test]
        public void TestRadicalWithDegreeCreation()
        {
            OLM.Radical rad = new OLM.Radical(
                                new OLM.Run("x"),
                                new OLM.Run("3")
                                );
            string expected = @"\sqrt[3]{x}";

            Assert.AreEqual(expected, rad.ToString());
        }

        // Runs (m:run)
        [Test]
        public void TestRunCreation()
        {
            OLM.Run run = new OLM.Run("foo");
            string expected = "foo";

            Assert.AreEqual(expected, run.InnerText);
            Assert.AreEqual(expected, run.ToString());
        }

        [Test]
        public void TestUnicodeRunCreation()
        {
            OLM.Run run = new OLM.Run("\u03Ba = \u03C0");
            string expected = @"\kappa = \pi";

            Assert.AreEqual(expected, run.InnerText);
            Assert.AreEqual(expected, run.ToString());
        }

        // SubSuperscript (m:sSubSup)
        [Test]
        public void TestSubSuperscriptCreation()
        {
            OLM.SubSuperscript script = new OLM.SubSuperscript(
                                            new OLM.Run("x"),
                                            new OLM.Run("1"),
                                            new OLM.Run("2")
                                            );
            string expected = "x^{2}_{1}";

            Assert.AreEqual(expected, script.ToString());
        }

        // Subscript (m:sSub)
        [Test]
        public void TestSubscriptCreation()
        {
            OLM.Subscript script = new OLM.Subscript(
                                        new OLM.Run("x"),
                                        new OLM.Run("1")
                                        );
            string expected = "x_{1}";

            Assert.AreEqual(expected, script.ToString());
        }

        // Superscript (m:sSup)
        [Test]
        public void TestSuperscriptCreation()
        {
            OLM.Superscript script = new OLM.Superscript(
                                        new OLM.Run("x"),
                                        new OLM.Run("2")
                                        );
            string expected = "x^{2}";

            Assert.AreEqual(expected, script.ToString());
        }
    }
}
