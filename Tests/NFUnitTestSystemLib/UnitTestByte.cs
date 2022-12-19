//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class ByteTests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var b = new byte();
            Assert.AreEqual((byte)0, b);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            byte b = 41;
            Assert.AreEqual((byte)41, b);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual((byte)0xFF, byte.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual((byte)0, byte.MinValue);
        }

        [TestMethod]
        public void Equals()
        {
            ByteTestData[] testData = new ByteTestData[]
            {
                new ByteTestData((byte)78, (byte)78, true),
                new ByteTestData((byte)78, (byte)0, false),
                new ByteTestData((byte)0, (byte)0, true),
                new ByteTestData((byte)78, null, false),
                new ByteTestData((byte)78, "78", false),
                new ByteTestData((byte)78, 78, false)
            };

            foreach (var test in testData)
            {
                OutputHelper.WriteLine($"Testing combination {test.B} and {test.Obj}");

                if (test.Obj is byte b2)
                {
                    Assert.AreEqual(test.Expected, test.B.Equals(b2), $"Casting Obj wasn't successful for {test.Obj}");
                    Assert.AreEqual(test.Expected, test.B.GetHashCode().Equals(b2.GetHashCode()), $"HashCode of {test.B}({test.B.GetHashCode()}) differs from the one of {b2}(b2.GetHashCode())");
                    Assert.AreEqual((byte)test.B, test.B.GetHashCode(), $"HashCode of {(byte)test.B} different from expected, is {test.B.GetHashCode()}");
                }

                Assert.AreEqual(test.Expected, test.B.Equals(test.Obj), $"Equality test between {test.B} and {test.Obj} failed");
            }
        }

        private sealed class ByteTestData
        {
            public object B { get; }
            public object Obj { get; }
            public bool Expected { get; }

            public ByteTestData(object b, object obj, bool expected)
            {
                B = b;
                Obj = obj;
                Expected = expected;
            }
        }
    }
}
