//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class Int32Tests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var i = new int();
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            int i = 41;
            Assert.AreEqual(41, i);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual(0x7FFFFFFF, int.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual(unchecked((int)0x80000000), int.MinValue);
        }

        [TestMethod]
        public void Equals()
        {
            Int32TestData[] testData = new Int32TestData[]
            {
                new Int32TestData((int)789, (int)789, true),
                new Int32TestData((int)789, (int)-789, false),
                new Int32TestData((int)789, (int)0, false),
                new Int32TestData((int)0, (int)0, true),
                new Int32TestData((int)-789, (int)-789, true),
                new Int32TestData((int)-789, (int)789, false),
                new Int32TestData((int)789, null, false),
                new Int32TestData((int)89, "789", false),
            };

            foreach (var test in testData)
            {
                if (test.Obj is int)
                {
                    int i2 = (int)test.Obj;
                    Assert.AreEqual(test.Expected, test.I1.Equals(i2));
                    Assert.AreEqual(test.Expected, test.I1.GetHashCode().Equals(i2.GetHashCode()));
                }

                Assert.AreEqual(test.Expected, test.I1.Equals(test.Obj));
            }
        }

        private sealed class Int32TestData
        {
            public object I1 { get; }
            public object Obj { get; }
            public bool Expected { get; }

            public Int32TestData(object i1, object obj, bool expected)
            {
                I1 = i1;
                Obj = obj;
                Expected = expected;
            }
        }
    }
}
