using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logic.Tests
{
    [TestFixture]
    class PolynomialTests
    {
        #region Test cases
        static object[] AddCases =
        {
            new object[] { new double[] { 3, 4, 6 }, new double[] { 2, 1, 3 }, new double[] { 5, 5, 9 } },
            new object[] { new double[] { 1, 2 }, new double[] { 1, 2, 3 }, new double[] { 2, 4, 3 } },
            new object[] { new double[] { 1, 2, 3, 4 }, new double[] { 1, 2 }, new double[] { 2, 4, 3, 4 } },
            new object[] { new double[] { 1, 4, 4 }, new double[] { 1, 2, -4.0 }, new double[] { 2, 6 } },
            new object[] { new double[] { }, new double[] {1, 2}, new double[] {1, 2} }
        };

        static object[] SubCases =
        {
            new object[] { new double[] { 3, 4, 6 }, new double[] { 2, 1, 3 }, new double[] { 1, 3, 3 } },
            new object[] { new double[] { 1, 2 }, new double[] { 1, 2, 3 }, new double[] { 0, 0, -3 } },
            new object[] { new double[] { 1, -2, 3, 4 }, new double[] { 1, 2, 0, 4 }, new double[] { 0, -4, 3 } }
        };

        static object[] MultCases =
        {
            new object[] { new double[] { 3 }, new double[] { 2 }, new double[] { 6 } },
            new object[] { new double[] { 1, 6 }, new double[] { 3, -5, 2}, new double[] { 3, 13, -28, 12}}
        };
        #endregion

        #region Some tests for beginning
        [TestCase(1, 1, 1)]
        public void Polynomial_Coefficients_CreatingPolynomial(double a, double b, double c)
        {
            Polynomial polynomial = new Polynomial(a, b, c);
        }

        [TestCase(1, -1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 1, 0, 0, 0)]
        [TestCase(0, 0, 0, 0, 1, 1, 1, 0, 0, 0)]
        public void ToString_Coefficients_ShowTheOutput(params double[] c)
        {
            Polynomial p = new Polynomial(c);
            Console.WriteLine(p);
        }
        #endregion

        #region Tests for Add method and operator
        [TestCaseSource("AddCases")]
        public void Add_Coefficients_EqualToExpectedResult(double[] c1, double[] c2, double[] res_c)
        {
            Polynomial p1 = new Polynomial(c1);
            Polynomial p2 = new Polynomial(c2);

            Polynomial res = p1 + p2;
            CollectionAssert.AreEqual(res_c, res.Coefficients);
        }

        [TestCase(null, new double[]{ 1 })]
        [TestCase(new double[] { 1 }, null)]
        [TestCase(null, null)]
        public void Add_NullReference_ArgumentNullException(double[] c1, double[] c2)
        {
            Polynomial p1 = null, p2 = null;
            if (c1 != null)
                p1 = new Polynomial(c1);
            if (c2 != null)
                p2 = new Polynomial(c2);
            Assert.Throws<ArgumentNullException>(() => Polynomial.Add(p1, p2));
        }
        #endregion

        #region Tests for Subtract method and operator
        [TestCaseSource("SubCases")]
        public void Subtract_Coefficients_EqualToExpectedResult(double[] c1, double[] c2, double[] res_c)
        {
            Polynomial p1 = new Polynomial(c1);
            Polynomial p2 = new Polynomial(c2);

            Polynomial res = p1 - p2;
            CollectionAssert.AreEqual(res_c, res.Coefficients);
        }

        [TestCase(null, new double[] { 1 })]
        [TestCase(new double[] { 1 }, null)]
        [TestCase(null, null)]
        public void Subtract_NullReference_ArgumentNullException(double[] c1, double[] c2)
        {
            Polynomial p1 = null, p2 = null;
            if (c1 != null)
                p1 = new Polynomial(c1);
            if (c2 != null)
                p2 = new Polynomial(c2);
            Assert.Throws<ArgumentNullException>(() => Polynomial.Subtract(p1, p2));
        }
        #endregion

        #region Test for indexer
        [TestCase(-2)]
        [TestCase(10)]
        public void Indexer_OutOfRangeIndex_ArgumentOutOfRangeException(int idx)
        {
            Polynomial p = new Polynomial(1, 2, 3);
            double n;
            Assert.Throws<ArgumentOutOfRangeException>(() => n = p[idx]);
        }
        #endregion

        #region Test for Multiply method and operator
        [TestCaseSource("MultCases")]
        public void Multiply_Coefficients_EqualToExpectedResult(double[] c1, double[] c2, double[] res_c)
        {
            Polynomial p1 = new Polynomial(c1);
            Polynomial p2 = new Polynomial(c2);

            Polynomial res = p1 * p2;
            CollectionAssert.AreEqual(res_c, res.Coefficients);
        }

        [TestCase(null, new double[] { 1 })]
        [TestCase(new double[] { 1 }, null)]
        [TestCase(null, null)]
        public void Multiply_NullReference_ArgumentNullException(double[] c1, double[] c2)
        {
            Polynomial p1 = null, p2 = null;
            if (c1 != null)
                p1 = new Polynomial(c1);
            if (c2 != null)
                p2 = new Polynomial(c2);
            Assert.Throws<ArgumentNullException>(() => Polynomial.Multiply(p1, p2));
        }
        #endregion

        #region Tests for Equals method 
        [Test]
        public void Equals_TwoEqualPolynimals_Equal()
        {
            Polynomial p1 = new Polynomial(10, 2);
            Polynomial p2 = new Polynomial(10, 2);

            Assert.True(p1.Equals(p2));
        }

        [Test]
        public void Equals_TwoReferences_Equal()
        {
            Polynomial p1 = new Polynomial(1);
            Polynomial p2 = p1;

            Assert.True(p1.Equals(p2));
        }

        [Test]
        public void Equals_NullRef_NotEqual()
        {
            Polynomial p1 = new Polynomial(10);
            Polynomial p2 = null;

            Assert.False(p1.Equals(p2));
        }

        [Test]
        public void Equals_EqualObjectAndPolynomialValues_Equal()
        {
            Polynomial p1 = new Polynomial(1, 2, 3);
            object p2 = new Polynomial(1, 2, 3);

            Assert.True(p1.Equals(p2));
        }
        #endregion
    }
}
