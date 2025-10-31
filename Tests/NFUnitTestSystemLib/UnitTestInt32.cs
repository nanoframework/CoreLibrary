// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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
        [DataRow(789, 789, true)]
        [DataRow(789, -789, false)]
        [DataRow(789, 0, false)]
        [DataRow(0, 0, true)]
        [DataRow(-789, -789, true)]
        [DataRow(-789, 789, false)]
        public void Equals_Int32ToInt32(int i1, int obj, bool expected)
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
        public void Equals_Int32ToNull()
        {
            int i1 = 789;
            object obj = null;

            Assert.AreNotEqual(i1, obj);
        }

        [TestMethod]
        public void Equals_Int32ToString()
        {
            int i1 = 89;
            object obj = "789";

            Assert.AreNotEqual(i1, obj);
        }
    }
}
