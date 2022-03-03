//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class SByteTests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var i = new sbyte();
            Assert.Equal((sbyte)0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            sbyte i = 41;
            Assert.Equal((sbyte)41, i);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.Equal((sbyte)0x7F, sbyte.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.Equal((sbyte)-0x80, sbyte.MinValue);
        }

        [TestMethod]
        public void Equals()
        {
            SByteTestData[] testData = new SByteTestData[]
            {
                new SByteTestData((sbyte)78, (sbyte)78, true),
                new SByteTestData((sbyte)78, (sbyte)-78, false),
                new SByteTestData((sbyte)78, (sbyte)0, false),
                new SByteTestData((sbyte)0, (sbyte)0, true),
                new SByteTestData((sbyte)-78, (sbyte)-78, true),
                new SByteTestData((sbyte)-78, (sbyte)78, false),
                new SByteTestData((sbyte)78, null, false),
                new SByteTestData((sbyte)78, "78", false),
                new SByteTestData((sbyte)78, 78, false)
            };

            foreach (var test in testData)
            {
                if (test.Obj is sbyte)
                {
                    sbyte i2 = (sbyte)test.Obj;
                    Assert.Equal(test.Expected, test.B.Equals(i2));
                    Assert.Equal(test.Expected, test.B.GetHashCode().Equals(i2.GetHashCode()));
                }

                Assert.Equal(test.Expected, test.B.Equals(test.Obj));
            }
        }

        private sealed class SByteTestData
        {
            public object B { get; }
            public object Obj { get; }
            public bool Expected { get; }

            public SByteTestData(object b, object obj, bool expected)
            {
                B = b;
                Obj = obj;
                Expected = expected;
            }
        }
    }
}
