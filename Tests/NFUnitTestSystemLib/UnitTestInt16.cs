// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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
        [DataRow((short)789, (short)789, true)]
        [DataRow((short)789, (short)-789, false)]
        [DataRow((short)789, (short)0, false)]
        [DataRow((short)0, (short)0, true)]
        [DataRow((short)-789, (short)-789, true)]
        [DataRow((short)-789, (short)789, false)]
        public void Equals_Int16ToInt16(short i1, short obj, bool expected)
        {
            if (expected)
            {
                Assert.AreEqual(i1, obj);
                Assert.IsTrue(i1.GetHashCode().Equals(obj.GetHashCode()));
            }
            else
            {
                Assert.AreNotEqual(i1, obj);
                Assert.IsFalse(i1.GetHashCode().Equals(obj.GetHashCode()));
            }
            Assert.AreEqual(i1, i1.GetHashCode());
        }

        [TestMethod]
        public void Equals_Int16ToNull()
        {
            short i1 = 789;
            object obj = null;

            Assert.AreNotEqual(i1, obj);
        }

        [TestMethod]
        public void Equals_Int16ToString()
        {
            short i1 = 789;
            object obj = "789";

            Assert.AreNotEqual(i1, obj);
        }

        [TestMethod]
        public void Equals_Int16ToInt()
        {
            short i1 = 789;
            object obj = 789;

            Assert.AreNotEqual(i1, obj);
        }
    }
}
