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
            Assert.IsTrue(float.NaN.Equals(0.0f / 0.0f));
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
                new SingleTestData(
                    (float)789,
                    (float)789,
                    true,
                    "789 should be equal to 789"),
                new SingleTestData(
                    (float)789,
                    (float)-789,
                    false,
                    "789 should not be equal to -789"),
                new SingleTestData(
                    (float)789,
                    (float)0,
                    false,
                    "789 should not be equal to 0"),
                new SingleTestData(
                    float.NaN,
                    float.NaN,
                    true,
                    "NaN should be equal to NaN"),
                new SingleTestData(
                    float.NaN,
                    -float.NaN,
                    true,
                    "NaN should be equal to -NaN"),
                new SingleTestData(
                    (float)789,
                    (double)789,
                    false,
                    "789(float) should not be equal to 789(double)"),
                new SingleTestData(
                    (float)789,
                    "789",
                    false,
                    "789(float) should not be equal to '789' (string)"),
                new SingleTestData(
                    (0.0F),
                    (-0.0F),
                    true,
                    "0.0F should be equal to -0.0F")
            };

            // Floating point numbers should not be tested for equality
            // intended as this is a unit test
#pragma warning disable S1244


            foreach (var test in testData)
            {
                if (test.Value is float f2)
                {
                    Assert.AreEqual(
                        test.Expected,
                        test.F1.Equals(f2),
                        test.AssertMessage);

                    if (float.IsNaN((float)test.F1) && float.IsNaN(f2))
                    {
                        Assert.AreEqual(
                            !test.Expected,
                            (float)test.F1 == f2);

                        Assert.AreEqual(
                            test.Expected,
                            (float)test.F1 != f2);
                    }
                    else
                    {
                        Assert.AreEqual(
                            test.Expected,
                            (float)test.F1 == f2);

                        Assert.AreEqual(
                            !test.Expected,
                            (float)test.F1 != f2);
                    }

                    Assert.AreEqual(test.Expected, test.F1.GetHashCode().Equals(f2.GetHashCode()));
                }

                Assert.AreEqual(test.Expected, test.F1.Equals(test.Value));
            }

#pragma warning restore S1244

        }

        [TestMethod]
        public void ToString_NoFormatString()
        {
            // Test basic ToString() without format string (uses "G" format by default)
            float value = 0;
            Assert.AreEqual("0", value.ToString(), "0.ToString() failed");

            value = 123;
            Assert.AreEqual("123", value.ToString(), "123.ToString() failed");

            value = -123;
            Assert.AreEqual("-123", value.ToString(), "-123.ToString() failed");

            value = 123.456f;
            Assert.AreEqual("123.456", value.ToString(), "123.456f.ToString() failed");

            value = -123.456f;
            Assert.AreEqual("-123.456", value.ToString(), "-123.456f.ToString() failed");

            value = 0.1f;
            Assert.AreEqual("0.1", value.ToString(), "0.1f.ToString() failed");

            value = -0.1f;
            Assert.AreEqual("-0.1", value.ToString(), "-0.1f.ToString() failed");

            value = 1234567.89f;
            Assert.AreEqual("1234567.89", value.ToString(), "1234567.89f.ToString() failed");

            value = -1234567.89f;
            Assert.AreEqual("-1234567.89", value.ToString(), "-1234567.89f.ToString() failed");
        }

        [TestMethod]
        public void ToString_SpecialValues()
        {
            // Test special values
            Assert.AreEqual("NaN", float.NaN.ToString(), "NaN.ToString() failed");
            Assert.AreEqual("Infinity", float.PositiveInfinity.ToString(), "PositiveInfinity.ToString() failed");
            Assert.AreEqual("-Infinity", float.NegativeInfinity.ToString(), "NegativeInfinity.ToString() failed");
        }

        [TestMethod]
        public void ToString_ZeroValues()
        {
            // Test zero and negative zero
            float zero = 0.0f;
            Assert.AreEqual("0", zero.ToString(), "0.0f.ToString() failed");

            float negativeZero = -0.0f;
            Assert.AreEqual("0", negativeZero.ToString(), "-0.0f.ToString() failed");
        }

        [TestMethod]
        public void ToString_SmallValues()
        {
            // Test very small values
            float value = 0.0001f;
            Assert.AreEqual("0.0001", value.ToString(), "0.0001f.ToString() failed");

            value = -0.0001f;
            Assert.AreEqual("-0.0001", value.ToString(), "-0.0001f.ToString() failed");

            value = 1e-10f;
            Assert.AreEqual("1E-10", value.ToString(), "1e-10f.ToString() failed");

            value = -1e-10f;
            Assert.AreEqual("-1E-10", value.ToString(), "-1e-10f.ToString() failed");
        }

        [TestMethod]
        public void ToString_LargeValues()
        {
            // Test large values
            float value = 1e10f;
            Assert.AreEqual("10000000000", value.ToString(), "1e10f.ToString() failed");

            value = -1e10f;
            Assert.AreEqual("-10000000000", value.ToString(), "-1e10f.ToString() failed");

            value = 1.23456789e15f;
            string result = value.ToString();
            Assert.IsTrue(result.Length > 0, "ToString() should return a non-empty string");
        }

        [TestMethod]
        public void ToString_ScientificNotation()
        {
            // Test values that should use scientific notation in default format
            float value = 1.23e20f;
            string result = value.ToString();
            Assert.IsTrue(result.Contains("E") || result.Contains("e"), "1.23e20f.ToString() should use scientific notation");

            value = -1.23e20f;
            result = value.ToString();
            Assert.IsTrue(result.Contains("E") || result.Contains("e"), "-1.23e20f.ToString() should use scientific notation");

            value = 1.23e-20f;
            result = value.ToString();
            Assert.IsTrue(result.Contains("E") || result.Contains("e"), "1.23e-20f.ToString() should use scientific notation");
        }

        [TestMethod]
        public void ToString_RoundingBehavior()
        {
            // Test rounding behavior
            float value = 1.23456789f;
            string result = value.ToString();
            Assert.IsTrue(result.Length > 0, "ToString() should return a non-empty string");
            Assert.IsTrue(result.Contains("."), "Decimal value ToString() should contain a decimal point");

            value = 0.123456789f;
            result = value.ToString();
            Assert.IsTrue(result.StartsWith("0."), "Fractional value should start with '0.'");
        }

        [TestMethod]
        public void ToString_WithFormatString()
        {
            // Test ToString() with format string
            float value = 123.456f;
            Assert.AreEqual("123.46", value.ToString("F2"), "ToString('F2') failed");

            value = 1234.5f;
            Assert.AreEqual("1,234.50", value.ToString("N2"), "ToString('N2') failed");

            value = 1.23456e10f;
            Assert.AreEqual("1.234560E+010", value.ToString("E6"), "ToString('E6') failed");
        }

        private sealed class SingleTestData
        {
            public object F1 { get; }
            public object Value { get; }
            public bool Expected { get; }
            public string AssertMessage { get; }

            public SingleTestData(
                object f1,
                object value,
                bool expected,
                string assertMessage = "")
            {
                F1 = f1;
                Value = value;
                Expected = expected;
                AssertMessage = assertMessage;
            }
        }
    }
}
