// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class DoubleTests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var i = new double();
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            double d = 41;
            Assert.AreEqual(41, d);

            d = 41.3;
            Assert.AreEqual(41.3, d);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual(1.7976931348623157E+308, double.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual(-1.7976931348623157E+308, double.MinValue);
        }

        [TestMethod]
        public void Epsilon()
        {
            Assert.AreEqual(4.9406564584124654E-324, double.Epsilon);
        }

        [TestMethod]
        public void NaN()
        {
            // Identical expressions should not be used on both sides of operators
            // on purpose to test the NaN value
#pragma warning disable S1764 
            Assert.IsTrue(double.NaN.Equals(0.0d / 0.0d));
            Assert.IsTrue(double.IsNaN(0.0d / 0.0d));
#pragma warning restore S1764 // Identical expressions should not be used on both sides of operators
        }

        [TestMethod]
        public void NegativeInfinity()
        {
            Assert.AreEqual(-1.0 / 0.0, double.NegativeInfinity);
            Assert.IsTrue(double.IsNegativeInfinity(-1.0 / 0.0));
        }

        [TestMethod]
        public void PositiveInfinity()
        {
            Assert.AreEqual(1.0 / 0.0, double.PositiveInfinity);
            Assert.IsTrue(double.IsPositiveInfinity(1.0 / 0.0));
        }

        [TestMethod]
        public void Equals()
        {
            DoubleTestData[] testData = new DoubleTestData[]
            {
                new DoubleTestData(
                    (double)789,
                    (double)789,
                    true,
                    "789 should be equal to 789"),
                new DoubleTestData(
                    (double)789,
                    (double)-789,
                    false,
                    "789 should not be equal to -789"),
                new DoubleTestData(
                    (double)789,
                    (double)0,
                    false,
                    "789 should not be equal to 0"),
                new DoubleTestData(
                    double.NaN,
                    double.NaN,
                    true,
                    "NaN should be equal to NaN"),
                new DoubleTestData(
                    double.NaN,
                    -double.NaN,
                    true,
                    "NaN should be equal to -NaN"),
                new DoubleTestData(
                    (double)789,
                    (float)789,
                    false,
                    "789 should not be equal to 789f"),
                new DoubleTestData(
                    (double)789,
                    "789",
                    false,
                    "789(double) should not be equal to '789' (string)"),
                new DoubleTestData(
                    (0.0d),
                    (-0.0d),
                    true,
                    "0.0d should be equal to -0.0d")

            };

            // Floating point numbers should not be tested for equality
            // intended as this is a unit test
#pragma warning disable S1244

            foreach (var test in testData)
            {
                if (test.Value is double d2)
                {
                    Assert.AreEqual(
                        test.Expected,
                        test.D1.Equals(d2),
                        test.AssertMessage);

                    if (double.IsNaN((double)test.D1) && double.IsNaN(d2))
                    {
                        Assert.AreEqual(
                            !test.Expected,
                            (double)test.D1 == d2);
                        Assert.AreEqual(
                            test.Expected,
                            (double)test.D1 != d2);
                    }
                    else
                    {
                        Assert.AreEqual(
                            test.Expected,
                            (double)test.D1 == d2);
                        Assert.AreEqual(
                            !test.Expected,
                            (double)test.D1 != d2);
                    }

                    Assert.AreEqual(
                        test.Expected,
                        test.D1.GetHashCode().Equals(d2.GetHashCode()));
                }

                if (test.Expected)
                {
                    Assert.IsTrue(test.D1.Equals(test.Value));
                }
                else
                {
                    Assert.IsFalse(test.D1.Equals(test.Value));
                }
            }

#pragma warning restore S1244

        }

        private sealed class DoubleTestData
        {
            public object D1 { get; }
            public object Value { get; }
            public bool Expected { get; }
            public string AssertMessage { get; }

            public DoubleTestData(
                object d1,
                object value,
                bool expected,
                string assertMessage = "")
            {
                D1 = d1;
                Value = value;
                Expected = expected;
                AssertMessage = assertMessage;
            }
        }
    }
}
