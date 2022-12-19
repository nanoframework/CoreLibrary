//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class Int16Tests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var i = new short();
            Assert.AreEqual((short)0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            short i = 41;
            Assert.AreEqual((short)41, i);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual((short)0x7FFF, short.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual(unchecked((short)0x8000), short.MinValue);
        }

        [TestMethod]
        public void Equals()
        {
            Int16TestData[] testData = new Int16TestData[]
            {
                new Int16TestData((short)789, (short)789, true),
                new Int16TestData((short)789, (short)-789, false),
                new Int16TestData((short)789, (short)0, false),
                new Int16TestData((short)0, (short)0, true),
                new Int16TestData((short)-789, (short)-789, true),
                new Int16TestData((short)-789, (short)789, false),
                new Int16TestData((short)789, null, false),
                new Int16TestData((short)789, "789", false),
                new Int16TestData((short)789, 789, false)
            };

            foreach (var test in testData)
            {
                if (test.Obj is short)
                {
                    short i2 = (short)test.Obj;
                    Assert.AreEqual(test.Expected, test.I1.Equals(i2));
                    Assert.AreEqual(test.Expected, test.I1.GetHashCode().Equals(i2.GetHashCode()));
                }

                Assert.AreEqual(test.Expected, test.I1.Equals(test.Obj));
            }
        }

        private sealed class Int16TestData
        {
            public object I1 { get; }
            public object Obj { get; }
            public bool Expected { get; }

            public Int16TestData(object i1, object obj, bool expected)
            {
                I1 = i1;
                Obj = obj;
                Expected = expected;
            }
        }
    }
}
