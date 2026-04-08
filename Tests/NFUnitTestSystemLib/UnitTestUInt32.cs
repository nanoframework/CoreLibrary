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
        [DataRow((uint)789, (uint)789, true)]
        [DataRow((uint)788, (uint)0, false)]
        [DataRow((uint)0, (uint)0, true)]
        public void Equals_UInt32ToUInt32(uint i1, uint obj, bool expected)
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
        public void Equals_UInt32ToNull()
        {
            uint i1 = 789;
            object obj = null;

            Assert.AreNotEqual(i1, obj);
        }

        [TestMethod]
        public void Equals_UInt32ToString()
        {
            uint i1 = 789;
            object obj = "789";

            Assert.AreNotEqual(i1, obj);
        }

        [TestMethod]
        public void Equals_UInt32ToInt()
        {
            uint i1 = 789;
            object obj = 789;

            Assert.AreNotEqual(i1, obj);
        }
    }
}
