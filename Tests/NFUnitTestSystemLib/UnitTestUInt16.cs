//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

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
            Assert.Equal((ushort)0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            ushort i = 41;
            Assert.Equal((ushort)41, i);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.Equal((ushort)0xFFFF, ushort.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.Equal((ushort)0, ushort.MinValue);
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
                    Assert.Equal(test.Expected, test.I1.Equals((ushort)test.Obj));
                    Assert.Equal(test.Expected, test.I1.GetHashCode().Equals(((ushort)test.Obj).GetHashCode()));
                    Assert.Equal((ushort)test.I1, test.I1.GetHashCode());
                }

                Assert.Equal(test.Expected, test.I1.Equals(test.Obj));
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
