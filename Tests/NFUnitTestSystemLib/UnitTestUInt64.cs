// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UInt64Tests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var i = new ulong();
            Assert.AreEqual((ulong)0, i);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            ulong i = 41;
            Assert.AreEqual((ulong)41, i);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual(0xFFFFFFFFFFFFFFFF, ulong.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual((ulong)0, ulong.MinValue);
        }

        [TestMethod]
        [DataRow((ulong)789, (ulong)789, true)]
        [DataRow((ulong)789, (ulong)0, false)]
        [DataRow((ulong)0, (ulong)0, true)]
        public void Equals_UInt64ToUInt64(ulong i1, ulong obj, bool expected)
        {
            OutputHelper.WriteLine($"Testing combination {i1} and {obj}");
            Assert.AreEqual(expected, i1.Equals(obj), $"Equality test between {i1} and {obj} failed");
            Assert.AreEqual(expected, i1.GetHashCode().Equals(obj.GetHashCode()));
            Assert.AreEqual(i1, i1.GetHashCode());
        }

        [TestMethod]
        public void Equals_UInt64ToNull()
        {
            ulong i1 = 789;
            object obj = null;
            OutputHelper.WriteLine($"Testing combination {i1} and {obj}");
            Assert.AreEqual(false, i1.Equals(obj), $"Equality test between {i1} and {obj} failed");
        }

        [TestMethod]
        public void Equals_UInt64ToString()
        {
            ulong i1 = 789;
            object obj = "789";
            OutputHelper.WriteLine($"Testing combination {i1} and {obj}");
            Assert.AreEqual(false, i1.Equals(obj), $"Equality test between {i1} and {obj} failed");
        }

        [TestMethod]
        public void Equals_UInt64ToInt()
        {
            ulong i1 = 789;
            object obj = 789;
            OutputHelper.WriteLine($"Testing combination {i1} and {obj}");
            Assert.AreEqual(false, i1.Equals(obj), $"Equality test between {i1} and {obj} failed");
        }
    }
}
