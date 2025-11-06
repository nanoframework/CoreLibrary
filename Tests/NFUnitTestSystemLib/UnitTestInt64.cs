// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class Int64Tests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var i = new long();
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            long i = 41;
            Assert.AreEqual(41, i);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual(0x7FFFFFFFFFFFFFFF, long.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual(unchecked((long)0x8000000000000000), long.MinValue);
        }

        [TestMethod]
        [DataRow((long)789, (long)789, true)]
        [DataRow((long)789, (long)-789, false)]
        [DataRow((long)789, (long)0, false)]
        [DataRow((long)0, (long)0, true)]
        [DataRow((long)-789, (long)-789, true)]
        [DataRow((long)-789, (long)789, false)]
        public void Equals_LongToLong(long i1, long obj, bool expected)
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
        }

        [TestMethod]
        public void Equals_LongToNull()
        {
            long i1 = 789;
            object obj = null;

            Assert.AreNotEqual(i1, obj);
        }

        [TestMethod]
        public void Equals_LongToString()
        {
            long i1 = 789;
            object obj = "789";

            Assert.AreNotEqual(i1, obj);
        }
    }
}
