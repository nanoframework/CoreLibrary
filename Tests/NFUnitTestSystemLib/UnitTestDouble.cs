//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

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
            Assert.Equal(0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            double d = 41;
            Assert.Equal(41, d);

            d = 41.3;
            Assert.Equal(41.3, d);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.Equal(1.7976931348623157E+308, double.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.Equal(-1.7976931348623157E+308, double.MinValue);
        }

        [TestMethod]
        public void Epsilon()
        {
            Assert.Equal(4.9406564584124654E-324, double.Epsilon);
        }

        [TestMethod]
        public void NaN()
        {
            Assert.True(double.NaN.Equals(0.0d / 0.0d));
        }

        [TestMethod]
        public void NegativeInfinity()
        {
            Assert.Equal(-1.0 / 0.0, double.NegativeInfinity);
        }

        [TestMethod]
        public void PositiveInfinity()
        {
            Assert.Equal(1.0 / 0.0, double.PositiveInfinity);
        }

        [TestMethod]
        public void Equals()
        {
            DoubleTestData[] testData = new DoubleTestData[]
            {
                new DoubleTestData((double)789, (double)789, true),
                new DoubleTestData((double)789, (double)-789, false),
                new DoubleTestData((double)789, (double)0, false),
                new DoubleTestData(double.NaN, double.NaN, true),
                new DoubleTestData(double.NaN, -double.NaN, true),
                new DoubleTestData((double)789, (float)789, false),
                new DoubleTestData((double)789, "789", false)
            };

            foreach (var test in testData)
            {
                if (test.Value is double d2)
                {
                    Assert.Equal(test.Expected, test.D1.Equals(d2));

                    if (double.IsNaN((double)test.D1) && double.IsNaN(d2))
                    {
                        Assert.Equal(!test.Expected, (double)test.D1 == d2);
                        Assert.Equal(test.Expected, (double)test.D1 != d2);
                    }
                    else
                    {
                        Assert.Equal(test.Expected, (double)test.D1 == d2);
                        Assert.Equal(!test.Expected, (double)test.D1 != d2);
                    }
                    
                    Assert.Equal(test.Expected, test.D1.GetHashCode().Equals(d2.GetHashCode()));
                }

                Assert.Equal(test.Expected, test.D1.Equals(test.Value));
            }
        }

        private sealed class DoubleTestData
        {
            public object D1 { get; }
            public object Value { get; }
            public bool Expected { get; }

            public DoubleTestData(object d1, object value, bool expected)
            {
                D1 = d1;
                Value = value;
                Expected = expected;
            }
        }
    }
}
