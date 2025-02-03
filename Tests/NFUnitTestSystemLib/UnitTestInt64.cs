// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class Int64Tests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var i = new long();
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            long i = 41;
            Assert.AreEqual(41, i);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual(0x7FFFFFFFFFFFFFFF, long.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual(unchecked((long)0x8000000000000000), long.MinValue);
        }

        [TestMethod]
        public void Equals()
        {
            Int64TestData[] testData = new Int64TestData[]
            {
                new Int64TestData((long)789, (long)789, true),
                new Int64TestData((long)789, (long)-789, false),
                new Int64TestData((long)789, (long)0, false),
                new Int64TestData((long)0, (long)0, true),
                new Int64TestData((long)-789, (long)-789, true),
                new Int64TestData((long)-789, (long)789, false),
                new Int64TestData((long)789, null, false),
                new Int64TestData((long)789, "789", false),
            };

            foreach (var test in testData)
            {
                if (test.Obj is long)
                {
                    long i2 = (long)test.Obj;
                    Assert.AreEqual(test.Expected, test.I1.Equals(i2));
                    Assert.AreEqual(test.Expected, test.I1.GetHashCode().Equals(i2.GetHashCode()));
                }

                Assert.AreEqual(test.Expected, test.I1.Equals(test.Obj));
            }
        }

        private sealed class Int64TestData
        {
            public object I1 { get; }
            public object Obj { get; }
            public bool Expected { get; }

            public Int64TestData(object i1, object obj, bool expected)
            {
                I1 = i1;
                Obj = obj;
                Expected = expected;
            }
        }
    }
}
