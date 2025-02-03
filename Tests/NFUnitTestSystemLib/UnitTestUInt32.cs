// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UInt32Tests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var i = new uint();
            Assert.AreEqual((uint)0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            uint i = 41;
            Assert.AreEqual((uint)41, i);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual(0xFFFFFFFF, uint.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual((uint)0, uint.MinValue);
        }

        [TestMethod]
        public void Equals()
        {
            UInt32TestData[] testData = new UInt32TestData[]
            {
                new UInt32TestData((uint)789, (uint)789, true),
                new UInt32TestData((uint)788, (uint)0, false),
                new UInt32TestData((uint)0, (uint)0, true),
                new UInt32TestData((uint)789, null, false),
                new UInt32TestData((uint)789, "789", false),
                new UInt32TestData((uint)789, 789, false)
            };

            foreach (var test in testData)
            {
                if (test.Obj is uint)
                {
                    uint i2 = (uint)test.Obj;
                    Assert.AreEqual(test.Expected, test.I1.Equals(i2));
                    Assert.AreEqual(test.Expected, test.I1.GetHashCode().Equals(i2.GetHashCode()));
                    Assert.AreEqual((uint)test.I1, test.I1.GetHashCode());
                }

                Assert.AreEqual(test.Expected, test.I1.Equals(test.Obj));
            }
        }

        private sealed class UInt32TestData
        {
            public object I1 { get; }
            public object Obj { get; }
            public bool Expected { get; }

            public UInt32TestData(object i1, object obj, bool expected)
            {
                I1 = i1;
                Obj = obj;
                Expected = expected;
            }
        }
    }
}
