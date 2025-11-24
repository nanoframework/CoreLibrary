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
            var empty = Guid.Empty;
            var notEmpty = Guid.NewGuid();
            Assert.IsFalse(empty == notEmpty);
        }

        [TestMethod]
        public void Guid_Empty_IsAllZeros()
        {
            var empty = Guid.Empty;
            var bytes = empty.ToByteArray();
            foreach (var b in bytes)
            {
                Assert.AreEqual((byte)0, b);
            }
        }

        [TestMethod]
        public void Guid_Constructor_ByteArray_RoundTrip()
        {
            var original = Guid.NewGuid();
            var bytes = original.ToByteArray();
            var roundTrip = new Guid(bytes);
            Assert.AreEqual(original, roundTrip);
        }

        [TestMethod]
        public void Guid_Equals_And_Operator()
        {
            var g1 = Guid.NewGuid();
            var g2 = new Guid(g1.ToByteArray());
            Assert.IsTrue(g1.Equals(g2));
            Assert.IsTrue(g1 == g2);
            Assert.IsFalse(g1 != g2);
        }

        [TestMethod]
        public void Guid_NotEquals_And_Operator()
        {
            var g1 = Guid.NewGuid();
            var g2 = Guid.NewGuid();
            Assert.IsFalse(g1.Equals(g2));
            Assert.IsFalse(g1 == g2);
            Assert.IsTrue(g1 != g2);
        }

        [TestMethod]
        public void Guid_ToString_And_Parse()
        {
            var g1 = Guid.NewGuid();
            var str = g1.ToString();
            var g2 = new Guid(str);
            Assert.AreEqual(g1, g2);
        }

        [TestMethod]
        public void Guid_GetHashCode_Consistent()
        {
            var g1 = Guid.NewGuid();
            var g2 = new Guid(g1.ToByteArray());
            Assert.AreEqual(g1.GetHashCode(), g2.GetHashCode());
        }

        [TestMethod]
        public void Guid_CompareTo_Object_And_Self()
        {
            var g1 = Guid.NewGuid();
            var g2 = new Guid(g1.ToByteArray());
            Assert.AreEqual(0, g1.CompareTo(g2));
            Assert.AreEqual(0, g1.CompareTo((object)g2));
            Assert.AreEqual(1, g1.CompareTo(null));
        }

        [TestMethod]
        public void Guid_CompareTo_InvalidType_Throws()
        {
            var g1 = Guid.NewGuid();
            Assert.ThrowsException(typeof(ArgumentException), () =>
            {
                g1.CompareTo("not a guid");
            });
        }

        [TestMethod]
        public void Guid_TryParseGuidWithDashes_Valid()
        {
            var g1 = Guid.NewGuid();
            var str = g1.ToString();
            bool parsed = Guid.TryParseGuidWithDashes(str, out var g2);
            Assert.IsTrue(parsed);
            Assert.AreEqual(g1, g2);
        }

        [TestMethod]
        public void Guid_TryParseGuidWithDashes_Invalid()
        {
            bool parsed = Guid.TryParseGuidWithDashes("invalid-guid", out var g2);
            Assert.IsFalse(parsed);
            Assert.AreEqual(Guid.Empty, g2);
        }

        [TestMethod]
        public void Guid_Constructor_String_WithBraces()
        {
            var g1 = Guid.NewGuid();
            var str = "{" + g1.ToString() + "}";
            var g2 = new Guid(str);
            Assert.AreEqual(g1, g2);
        }

        [TestMethod]
        public void Guid_Constructor_String_Invalid_Throws()
        {
            Assert.ThrowsException(typeof(ArgumentException), () =>
            {
                var g = new Guid("invalid-guid");
            });
        }

        [TestMethod]
        public void Guid_GetHashCode_Empty()
        {
            var empty = Guid.Empty;
            Assert.AreEqual(0, empty.GetHashCode());
        }
    }
}
