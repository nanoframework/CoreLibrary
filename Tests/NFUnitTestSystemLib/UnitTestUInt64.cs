//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UInt64Tests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var i = new ulong();
            Assert.AreEqual((ulong)0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            ulong i = 41;
            Assert.AreEqual((ulong)41, i);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual(0xFFFFFFFFFFFFFFFF, ulong.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual((ulong)0, ulong.MinValue);
        }

        [TestMethod]
        public void Equals()
        {
            UInt64TestData[] testData = new UInt64TestData[]
            {
                new UInt64TestData((ulong)789, (ulong)789, true),
                new UInt64TestData((ulong)789, (ulong)0, false),
                new UInt64TestData((ulong)0, (ulong)0, true),
                new UInt64TestData((ulong)789, null, false),
                new UInt64TestData((ulong)789, "789", false),
                new UInt64TestData((ulong)789, 789, false),
            };

            foreach (var test in testData)
            {
                OutputHelper.WriteLine($"Testing combination {test.I1} and {test.Obj}");

                if (test.Obj is ulong i2)
                {
                    Assert.AreEqual(test.Expected, test.I1.Equals(i2));
                    Assert.AreEqual(test.Expected, test.I1.GetHashCode().Equals(i2.GetHashCode()));
                    Assert.AreEqual((ulong)test.I1, test.I1.GetHashCode());
                }

                Assert.AreEqual(test.Expected, test.I1.Equals(test.Obj), $"Equality test between {test.I1} and {test.Obj} failed");
            }
        }

        private sealed class UInt64TestData
        {
            public object I1 { get; }
            public object Obj { get; }
            public bool Expected { get; }

            public UInt64TestData(object i1, object obj, bool expected)
            {
                I1 = i1;
                Obj = obj;
                Expected = expected;
            }
        }
    }
}
