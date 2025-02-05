// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class SingleTests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var f = new float();
            Assert.AreEqual(0, f);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            float f = 41;
            Assert.AreEqual(41, f);

            f = 41.3f;
            Assert.AreEqual(41.3f, f);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual((float)3.40282346638528859e+38, float.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual((float)-3.40282346638528859e+38, float.MinValue);
        }

        [TestMethod]
        public void Epsilon()
        {
            Assert.AreEqual((float)1.4e-45, float.Epsilon);
        }

        [TestMethod]
        public void NaN()
        {
            // Identical expressions should not be used on both sides of operators
            // on purpose to test the NaN value
#pragma warning disable S1764 
            Assert.IsTrue(float.NaN.Equals(0.0d / 0.0d));
            Assert.IsTrue(float.IsNaN(0.0f / 0.0f));
#pragma warning restore S1764 // Identical expressions should not be used on both sides of operators
        }

        [TestMethod]
        public void NegativeInfinity()
        {
            Assert.AreEqual(-1.0f / 0.0f, float.NegativeInfinity);
            Assert.IsTrue(float.IsNegativeInfinity(-1.0f / 0.0f));
        }

        [TestMethod]
        public void PositiveInfinity()
        {
            Assert.AreEqual(1.0f / 0.0f, float.PositiveInfinity);
            Assert.IsTrue(float.IsPositiveInfinity(1.0f / 0.0f));
        }

        [TestMethod]
        public void Equals()
        {
            SingleTestData[] testData = new SingleTestData[]
            {
                new SingleTestData((float)789, (float)789, true),
                new SingleTestData((float)789, (float)-789, false),
                new SingleTestData((float)789, (float)0, false),
                new SingleTestData((float)float.NaN, float.NaN, true),
                new SingleTestData((float)float.NaN, -float.NaN, true),
                new SingleTestData((float)789, (double)789, false),
                new SingleTestData((float)789, "789", false),
            };

            foreach (var test in testData)
            {
                if (test.Value is float f2)
                {
                    Assert.AreEqual(test.Expected, test.F1.Equals(f2));

                    if (float.IsNaN((float)test.F1) && float.IsNaN(f2))
                    {
                        Assert.AreEqual(!test.Expected, (float)test.F1 == f2);
                        Assert.AreEqual(test.Expected, (float)test.F1 != f2);
                    }
                    else
                    {
                        Assert.AreEqual(test.Expected, (float)test.F1 == f2);
                        Assert.AreEqual(!test.Expected, (float)test.F1 != f2);
                    }

                    Assert.AreEqual(test.Expected, test.F1.GetHashCode().Equals(f2.GetHashCode()));
                }

                Assert.AreEqual(test.Expected, test.F1.Equals(test.Value));
            }
        }

        private sealed class SingleTestData
        {
            public object F1 { get; }
            public object Value { get; }
            public bool Expected { get; }

            public SingleTestData(object f1, object value, bool expected)
            {
                F1 = f1;
                Value = value;
                Expected = expected;
            }
        }
    }
}
