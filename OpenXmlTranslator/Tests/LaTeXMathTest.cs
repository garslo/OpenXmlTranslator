using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DocumentFormat.OpenXml;
using OM = DocumentFormat.OpenXml.Math;

using NUnit.Framework;

namespace OpenXmlTranslate.Tests
{
    [TestFixture]
    class LaTeXMathTest
    {
        // Bar (m:bar)
        private static OM.Bar NewBar(OpenXmlElement theBase)
        {
            var bar = new OM.Bar(
                        new OM.Base(
                            theBase
                            )
                        );
            return bar;
        }

        [Test]
        public static void TranslateBar()
        {
            OM.Bar simpleBar = NewBar(NewRun("x"));
            string simpleBarExpected = @"\bar{x}";

            Assert.AreEqual(simpleBarExpected, LaTeX.Math.Translate(simpleBar));
        }

        [Test]
        public static void TranslateUnicodeBar()
        {
            OM.Bar unicodeBar = new OM.Bar(
                                    new OM.Base(
                                        NewRun("\u03BB - \u03c1")
                                    )
                                );
            string unicodeBarExpected = @"\bar{\lambda - \rho}";

            Assert.AreEqual(unicodeBarExpected, LaTeX.Math.Translate(unicodeBar));
        }

        // Border Boxes (m:borderBox)
        [Test]
        [Ignore("BorderBoxHandler is not yet implemented.")]
        public static void TranslateBorderBox()
        { }

        // Boxes (m:box)
        private static OM.Box NewBox(OpenXmlElement theBase)
        {
            var box = new OM.Box(
                            new OM.Base(
                                theBase
                                )
                            );
            return box;
        }

        [Test]
        public static void TranslateBox()
        {
            OM.Fraction innerFrac = NewFraction(@"x^2-4", "x+2");
            OM.Box box = NewBox(innerFrac);
            // Boxes are just grouping mechanisms. At this point, the LaTeX output
            // should not be affected by them.
            Assert.AreEqual(LaTeX.Math.Translate(innerFrac),
                            LaTeX.Math.Translate(box));
        }

        // Delimiters (m:d)
        private static OM.Delimiter NewDelimiter(OpenXmlElement theBase)
        {
            var delimiter = new OM.Delimiter(
                                new OM.Base(
                                    theBase
                                    )
                                );
            return delimiter;
        }

        [Test]
        public static void TranslateDelimiter()
        {
            OM.Delimiter simpleDelimiter = NewDelimiter(NewRun("x"));
            string simpleDelimiterExpected = @"\left(x\right)";

            Assert.AreEqual(simpleDelimiterExpected, LaTeX.Math.Translate(simpleDelimiter));
        }

        [Test]
        public static void TranslateNonDefaultDelimiter()
        {
            // TODO: Clean this up
            OM.BeginChar dummy = new OM.BeginChar();
            OpenXmlAttribute begChrVal = new OpenXmlAttribute("m", "val", dummy.NamespaceUri, "[");
            OpenXmlAttribute endChrVal = new OpenXmlAttribute("m", "val", dummy.NamespaceUri, "]");
            OM.BeginChar begChr = new OM.BeginChar();
            begChr.SetAttribute(begChrVal);
            OM.EndChar endChr = new OM.EndChar();
            endChr.SetAttribute(endChrVal);

            OM.Delimiter nonDefault = new OM.Delimiter(
                                            new OM.DelimiterProperties(
                                                begChr,
                                                endChr
                                                    ),
                                            new OM.Base(
                                                NewRun("10")
                                                )
                                            );
            string nonDefaultExpected = @"\left[10\right]";

            Assert.AreEqual(nonDefaultExpected, LaTeX.Math.Translate(nonDefault));

            // Squiggly Brackets
            begChrVal.Value = "{";
            endChrVal.Value = "}";
            begChr.SetAttribute(begChrVal);
            endChr.SetAttribute(endChrVal);
            string squigglyBracketExpected = @"\left\{10\right\}";

            Assert.AreEqual(squigglyBracketExpected, LaTeX.Math.Translate(nonDefault));
        }

        // Bases (m:e)
        [Test]
        public static void TranslateBase()
        {
            OM.Base aBase = new OM.Base(
                              NewRun("x + 2")
                                );
            string aBaseExpected = @"x + 2";

            Assert.AreEqual(aBaseExpected, LaTeX.Math.Translate(aBase));
        }

        // Equation Arrays (m:eqArr)
        private static OM.EquationArray NewEquationArray(params OpenXmlElement[] rows)
        {
            var eqArr = new OM.EquationArray(
                            rows.Select(row => new OM.Base(row))
                            );
            return eqArr;   
        }

        [Test]
        public static void TranslateEquationArray()
        {
            OM.EquationArray eqArr = NewEquationArray(
                                        NewRun("y & + & x & = 7"),
                                        NewRun("2y & - & 5x & = 10")
                                        );
            string eqArrExpected =
@"\begin{align*}
    y & + & x & = 7 \\
    2y & - & 5x & = 10
\end{align*}";

            Assert.AreEqual(eqArrExpected, LaTeX.Math.Translate(eqArr));
        }

        // Fractions (m:f)
        private static OM.Fraction NewFraction(string num, string den)
        {
            return NewFraction(NewRun(num), NewRun(den));
        }

        private static OM.Fraction NewFraction(OpenXmlElement num, OpenXmlElement den)
        {
            var frac = new OM.Fraction(
                            new OM.Numerator(
                                num
                                ),
                            new OM.Denominator(
                                den
                                )
                            );
            return frac;
        }

        [Test]
        public static void TranslateSimpleFraction()
        {
            OM.Fraction asciiFrac = NewFraction("x", "1+y");
            string asciiFracExpected = @"\frac{x}{1+y}";

            Assert.AreEqual(asciiFracExpected, LaTeX.Math.Translate(asciiFrac));
        }

        [Test]
        public static void TranslateUnicodeFraction()
        {
            OM.Fraction unicodeFrac = NewFraction("\u03A8(x)", "\u03BE");
            string unicodeFracExpected = @"\frac{\Psi (x)}{\xi}";

            Assert.AreEqual(unicodeFracExpected, LaTeX.Math.Translate(unicodeFrac));
        }

        // Functions (m:func)
        [Test]
        public static void TranslateFunction()
        {
            OM.MathFunction func = NewFunction("f", NewRun("x"));
            string funcExpected = @"f\left(x\right)";

            Assert.AreEqual(funcExpected, LaTeX.Math.Translate(func));
        }

        [Test]
        public static void TranslateStandardFunction()
        {
            OM.MathFunction func = NewFunction("sin", NewRun("x"));
            string funcExpected = @"\sin \left(x\right)";

            Assert.AreEqual(funcExpected, LaTeX.Math.Translate(func));
        }

        [Test]
        public static void TranslateComplexFunction()
        {
            OM.MathFunction func = NewFunction("exp",
                                    NewFunction("sin",
                                        NewFunction("f",
                                            NewFraction(@"\pi", "4"),
                                            NewRun(",x-y")
                                            )
                                        )
                                    );
            string funcExpected = @"\exp \left(\sin \left(f\left(\frac{\pi}{4},x-y\right)\right)\right)";

            Assert.AreEqual(funcExpected, LaTeX.Math.Translate(func));
        }

        public static OM.MathFunction NewFunction(string name, params OpenXmlElement[] args)
        {
            var fName = new OM.FunctionName(
                             NewRun(name)
                            );
            var fBase = new OM.Base(
                            new OM.Delimiter(
                                 new OM.Base(args)
                                 )
                            );

            return new OM.MathFunction(fName, fBase);
        }

        // Lower Limits (m:limLow)
        [Test]
        [Ignore("LimitLowerHandler is not yet implemented")]
        public static void TranslateLimitLower()
        {

        }

        // Upper Limits (m:limUpp)
        [Test]
        [Ignore("LimitUpperHandler is not yet implemented")]
        public static void TranslateLimitUpper()
        {

        }

        // N-Ary Operators (m:nary)
        [Test]
        [Ignore("NaryHandler is not yet implemented")]
        public static void TranslateNary()
        {
            
        }

        // Runs (m:r)
        private static OM.Run NewRun(string text)
        {
            return new OM.Run(
                        new OM.Text(text)
                             );
        }

        [Test]
        public static void TranslateRun()
        {
            OM.Run run = NewRun("x+1");
            string runExpected = "x+1";

            Assert.AreEqual(runExpected, LaTeX.Math.Translate(run));
        }

        [Test]
        public static void TranslateGreekUnicodeRun()
        {
            OM.Run run1 = NewRun("\u03b1 + \u03c0");
            string runExpected1 = @"\alpha + \pi";

            OM.Run run2 = NewRun("\u03B5 < 0");
            string runExpected2 = @"\epsilon < 0";

            Assert.AreEqual(runExpected1, LaTeX.Math.Translate(run1));
            Assert.AreEqual(runExpected2, LaTeX.Math.Translate(run2));
        }

        // Radicals (m:rad)
        private static OM.Radical NewRadical(OpenXmlElement theBase)
        {
            var rad = new OM.Radical(
                            new OM.Base(
                                theBase
                                )
                            );
            return rad;
        }

        private static OM.Radical NewRadical(OpenXmlElement theBase, OpenXmlElement degree)
        {
            var rad = new OM.Radical(
                            new OM.Degree(
                                degree
                                ),
                            new OM.Base(
                                theBase
                                )
                            );
            return rad;
        }

        [Test]
        public static void TranslateSquareRoot()
        {
            OM.Radical rad = NewRadical(NewRun("x"));
            string radExpected = @"\sqrt{x}";

            Assert.AreEqual(radExpected, LaTeX.Math.Translate(rad));
        }

        [Test]
        public static void TranslateNthRoot()
        {
            OM.Radical rad = NewRadical(NewRun("x"), NewRun("n"));
            string radExpected = @"\sqrt[n]{x}";

            Assert.AreEqual(radExpected, LaTeX.Math.Translate(rad));
        }

        [Test]
        public static void TranslateComplexRoot()
        {
            OM.Radical rad = NewRadical(
                                NewFunction(
                                    "sin",
                                    NewFraction(@"\pi", "3")
                                    ),
                                NewFraction(@"\pi", "4")
                                );
            string radExpected = @"\sqrt[\frac{\pi}{4}]{\sin \left(\frac{\pi}{3}\right)}";

            Assert.AreEqual(radExpected, LaTeX.Math.Translate(rad));
        }

        // Pre-Script (m:pre)
        private static OM.PreSubSuper NewPreSubSuper(OpenXmlElement sup, OpenXmlElement sub, OpenXmlElement aBase)
        {
            OM.PreSubSuper subSuper = new OM.PreSubSuper(
                                            new OM.SuperArgument(
                                                sup
                                                ),
                                            new OM.SubArgument(
                                                sub
                                                ),
                                            new OM.Base(
                                                aBase
                                                )
                                            );
            return subSuper;
        }

        [Test]
        public static void TranslatePrescript()
        {
            OM.PreSubSuper subSuper = NewPreSubSuper(NewRun("2"), NewRun("1"), NewRun("A"));
            string subSuperExpected = @"{}^{2}_{1}A";

            Assert.AreEqual(subSuperExpected, LaTeX.Math.Translate(subSuper));
        }

        [Test]
        public static void TranslateComplexPrescript()
        {
            OM.PreSubSuper subSuper = NewPreSubSuper(
                                        NewFraction("3", "2"),
                                        NewFraction("1", "2"),
                                        NewFunction("f", NewRun("x"))
                                        );
            string subSuperExpected = @"{}^{\frac{3}{2}}_{\frac{1}{2}}f\left(x\right)";

            Assert.AreEqual(subSuperExpected, LaTeX.Math.Translate(subSuper));
        }

        // Subscript (m:sSub)
        private static OM.Subscript NewSubscript(OpenXmlElement aBase, OpenXmlElement subscript)
        {
            OM.Subscript sub = new OM.Subscript(
                                    new OM.SubArgument(
                                        subscript
                                        ),
                                    new OM.Base(
                                        aBase
                                        )
                                    );
            return sub;
        }

        [Test]
        public static void TranslateSubscript()
        {
            OM.Subscript sub = NewSubscript(NewRun("x"), NewRun("1"));
            string subExpected = "x_{1}";

            Assert.AreEqual(subExpected, LaTeX.Math.Translate(sub));
        }

        [Test]
        public static void TranslateComplexSubscript()
        {
            OM.Subscript sub = NewSubscript(
                                NewPreSubSuper(
                                    NewFraction("1", "2"),
                                    NewRun("0"),
                                    NewRun("Σ")
                                    ),
                                NewRun("1")
                                );
            string subExpected = @"{}^{\frac{1}{2}}_{0}\Sigma_{1}";

            Assert.AreEqual(subExpected, LaTeX.Math.Translate(sub));
        }

        // Superscript (m:sSup)
        private static OM.Superscript NewSuperscript(OpenXmlElement aBase, OpenXmlElement superscript)
        {
            OM.Superscript sup = new OM.Superscript(
                                        new OM.SuperArgument(
                                            superscript
                                            ),
                                        new OM.Base(
                                            aBase
                                            )
                                        );
            return sup;
        }

        // Subscript (m:sSub)
        [Test]
        public static void TranslateSuperscript()
        {
            OM.Superscript sup = NewSuperscript(NewRun("x"), NewRun("2"));
            string supExpected = "x^{2}";

            Assert.AreEqual(supExpected, LaTeX.Math.Translate(sup));
        }

        [Test]
        public static void TranslateComplexSuperscript()
        {
            //OM.Superscript sup = NewSuperscript()

        }

        // SubSuperscript (m:sSubSup)
        private static OM.SubSuperscript NewSubSuperscript(OpenXmlElement theBase,
                                                           OpenXmlElement sub,
                                                           OpenXmlElement sup)
        {
            var script = new OM.SubSuperscript(
                                new OM.SuperArgument(
                                    sup
                                    ),
                                new OM.SubArgument(
                                    sub
                                    ),
                                new OM.Base(
                                    theBase
                                    )
                                );
            return script;
        }

        private static OM.SubSuperscript NewSubSuperscript(string theBase, string sub, string sup)
        {
            return NewSubSuperscript(NewRun(theBase), NewRun(sub), NewRun(sup));
        }

        [Test]
        public static void TranslateSubSuperscript()
        {
            OM.SubSuperscript elem = NewSubSuperscript("x", "1", "2");
            string elemExpected = "x^{2}_{1}";

            Assert.AreEqual(elemExpected, LaTeX.Math.Translate(elem));
        }
    }
}
