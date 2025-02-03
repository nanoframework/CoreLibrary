// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UInt16Tests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var i = new ushort();
            Assert.AreEqual((ushort)0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            ushort i = 41;
            Assert.AreEqual((ushort)41, i);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual((ushort)0xFFFF, ushort.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual((ushort)0, ushort.MinValue);
        }

        [TestMethod]
        public void Equals()
        {
            UInt16TestData[] testData = new UInt16TestData[]
            {
                new UInt16TestData((ushort)789, (ushort)789, true),
                new UInt16TestData((ushort)788, (ushort)0, false),
                new UInt16TestData((ushort)0, (ushort)0, true),
                new UInt16TestData((ushort)789, null, false),
                new UInt16TestData((ushort)789, "789", false),
                new UInt16TestData((ushort)789, 789, false)
            };

            foreach (var test in testData)
            {
                if (test.Obj is ushort)
                {
                    Assert.AreEqual(test.Expected, test.I1.Equals((ushort)test.Obj));
                    Assert.AreEqual(test.Expected, test.I1.GetHashCode().Equals(((ushort)test.Obj).GetHashCode()));
                    Assert.AreEqual((ushort)test.I1, test.I1.GetHashCode());
                }

                Assert.AreEqual(test.Expected, test.I1.Equals(test.Obj));
            }
        }

        private sealed class UInt16TestData
        {
            public object I1 { get; }
            public object Obj { get; }
            public bool Expected { get; }

            public UInt16TestData(object i1, object obj, bool expected)
            {
                I1 = i1;
                Obj = obj;
                Expected = expected;
            }
        }
    }
}
