// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestTypes
{
    [TestClass]
    class UnitTestGuid
    {
        [TestMethod]
        public void Guid_Compare_To_Empty()
        {
            Guid empty = Guid.Empty;
            Guid notEmpty = Guid.NewGuid();
            Assert.IsFalse(empty == notEmpty);
        }

        [TestMethod]
        public void Guid_Empty_IsAllZeros()
        {
            Guid empty = Guid.Empty;
            byte[] bytes = empty.ToByteArray();
            foreach (byte b in bytes)
            {
                Assert.AreEqual((byte)0, b);
            }
        }

        [TestMethod]
        public void Guid_Constructor_ByteArray_RoundTrip()
        {
            Guid original = Guid.NewGuid();
            byte[] bytes = original.ToByteArray();
            Guid roundTrip = new Guid(bytes);
            Assert.AreEqual(original, roundTrip);
        }

        [TestMethod]
        public void Guid_Equals_And_Operator()
        {
            Guid g1 = Guid.NewGuid();
            Guid g2 = new Guid(g1.ToByteArray());
            Assert.IsTrue(g1.Equals(g2));
            Assert.IsTrue(g1 == g2);
            Assert.IsFalse(g1 != g2);
        }

        [TestMethod]
        public void Guid_NotEquals_And_Operator()
        {
            Guid g1 = Guid.NewGuid();
            Guid g2 = Guid.NewGuid();
            Assert.IsFalse(g1.Equals(g2));
            Assert.IsFalse(g1 == g2);
            Assert.IsTrue(g1 != g2);
        }

        [TestMethod]
        public void Guid_ToString_And_Parse()
        {
            Guid g1 = Guid.NewGuid();
            string str = g1.ToString();
            Guid g2 = new Guid(str);
            Assert.AreEqual(g1, g2);
        }

        [TestMethod]
        public void Guid_GetHashCode_Consistent()
        {
            Guid g1 = Guid.NewGuid();
            Guid g2 = new Guid(g1.ToByteArray());
            Assert.AreEqual(g1.GetHashCode(), g2.GetHashCode());
        }

        [TestMethod]
        public void Guid_CompareTo_Object_And_Self()
        {
            Guid g1 = Guid.NewGuid();
            Guid g2 = new Guid(g1.ToByteArray());
            Assert.AreEqual(0, g1.CompareTo(g2));
            Assert.AreEqual(0, g1.CompareTo((object)g2));
            Assert.AreEqual(1, g1.CompareTo(null));
        }

        [TestMethod]
        public void Guid_CompareTo_InvalidType_Throws()
        {
            Guid g1 = Guid.NewGuid();
            Assert.ThrowsException(typeof(ArgumentException), () =>
            {
                g1.CompareTo("not a guid");
            });
        }

        [TestMethod]
        public void Guid_TryParseGuidWithDashes_Valid()
        {
            Guid g1 = Guid.NewGuid();
            string str = g1.ToString();
            Guid g2;
            bool parsed = Guid.TryParse(str, out g2);
            Assert.IsTrue(parsed);
            Assert.AreEqual(g1, g2);
        }

        [TestMethod]
        public void Guid_TryParseGuidWithDashes_Invalid()
        {
            Guid g2;
            bool parsed = Guid.TryParse("invalid-guid", out g2);
            Assert.IsFalse(parsed);
            Assert.AreEqual(Guid.Empty, g2);
        }

        [TestMethod]
        public void Guid_Constructor_String_WithBraces()
        {
            Guid g1 = Guid.NewGuid();
            string str = "{" + g1.ToString() + "}";
            Guid g2 = new Guid(str);
            Assert.AreEqual(g1, g2);
        }

        [TestMethod]
        public void Guid_Constructor_String_Invalid_Throws()
        {
            Assert.ThrowsException(typeof(ArgumentException), () =>
            {
                Guid g = new Guid("invalid-guid");
            });
        }

        [TestMethod]
        public void Guid_GetHashCode_Empty()
        {
            Guid empty = Guid.Empty;
            Assert.AreEqual(0, empty.GetHashCode());
        }

        [TestMethod]
        public void Guid_CompareTo_LessThan()
        {
            Guid g1 = new Guid(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Guid g2 = new Guid(2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Assert.IsTrue(g1.CompareTo(g2) < 0, "g1 should be less than g2");
        }

        [TestMethod]
        public void Guid_CompareTo_GreaterThan()
        {
            Guid g1 = new Guid(2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Guid g2 = new Guid(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Assert.IsTrue(g1.CompareTo(g2) > 0, "g1 should be greater than g2");
        }

        [TestMethod]
        public void Guid_CompareTo_OrdersByComponents()
        {
            // b component
            Guid lo = new Guid(0, (short)1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Guid hi = new Guid(0, (short)2, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Assert.IsTrue(lo.CompareTo(hi) < 0);

            // 'a' high-bit: 0x80000001 as uint > 0x00000001; signed subtraction would overflow and give wrong sign
            Guid bigA = new Guid(unchecked((int)0x80000001), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Guid smallA = new Guid(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Assert.IsTrue(bigA.CompareTo(smallA) > 0);

            // last byte (k)
            Guid loK = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            Guid hiK = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2);
            Assert.IsTrue(loK.CompareTo(hiK) < 0);
        }
    }
}
