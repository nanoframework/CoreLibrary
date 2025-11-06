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
        [DataRow((sbyte)78, (sbyte)78, true)]
        [DataRow((sbyte)78, (sbyte)-78, false)]
        [DataRow((sbyte)78, (sbyte)0, false)]
        [DataRow((sbyte)0, (sbyte)0, true)]
        [DataRow((sbyte)-78, (sbyte)-78, true)]
        [DataRow((sbyte)-78, (sbyte)78, false)]
        public void Equals_SByteToSByte(sbyte b, sbyte obj, bool expected)
        {
            if (expected)
            {
                Assert.AreEqual(b, obj);
                Assert.IsTrue(b.GetHashCode().Equals(obj.GetHashCode()));
            }
            else
            {
                Assert.AreNotEqual(b, obj);
                Assert.IsFalse(b.GetHashCode().Equals(obj.GetHashCode()));
            }
            Assert.AreEqual(b, b.GetHashCode());
        }

        [TestMethod]
        public void Equals_SByteToNull()
        {
            sbyte b = 78;
            object obj = null;

            Assert.AreNotEqual(b, obj);
        }

        [TestMethod]
        public void Equals_SByteToString()
        {
            sbyte b = 78;
            object obj = "78";

            Assert.AreNotEqual(b, obj);
        }

        [TestMethod]
        public void Equals_SByteToInt()
        {
            sbyte b = 78;
            object obj = 78;

            Assert.AreNotEqual(b, obj);
        }
    }
}
