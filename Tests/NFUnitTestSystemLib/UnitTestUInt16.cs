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
        [DataRow((ushort)789, (ushort)789, true)]
        [DataRow((ushort)788, (ushort)0, false)]
        [DataRow((ushort)0, (ushort)0, true)]
        public void Equals_UInt16ToUInt16(ushort i1, ushort obj, bool expected)
        {
            Assert.AreEqual(expected, i1.Equals(obj));
            Assert.AreEqual(expected, i1.GetHashCode().Equals(obj.GetHashCode()));
            Assert.AreEqual(i1, i1.GetHashCode());
        }

        [TestMethod]
        public void Equals_UInt16ToNull()
        {
            ushort i1 = 789;
            object obj = null;
            Assert.AreEqual(false, i1.Equals(obj));
        }

        [TestMethod]
        public void Equals_UInt16ToString()
        {
            ushort i1 = 789;
            object obj = "789";
            Assert.AreEqual(false, i1.Equals(obj));
        }

        [TestMethod]
        public void Equals_UInt16ToInt()
        {
            ushort i1 = 789;
            object obj = 789;
            Assert.AreEqual(false, i1.Equals(obj));
        }
    }
}
