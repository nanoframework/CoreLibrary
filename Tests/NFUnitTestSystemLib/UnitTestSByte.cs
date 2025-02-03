// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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
            Assert.AreEqual((sbyte)0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            sbyte i = 41;
            Assert.AreEqual((sbyte)41, i);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual((sbyte)0x7F, sbyte.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual((sbyte)-0x80, sbyte.MinValue);
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
                    Assert.AreEqual(test.Expected, test.B.Equals(i2));
                    Assert.AreEqual(test.Expected, test.B.GetHashCode().Equals(i2.GetHashCode()));
                }

                Assert.AreEqual(test.Expected, test.B.Equals(test.Obj));
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
