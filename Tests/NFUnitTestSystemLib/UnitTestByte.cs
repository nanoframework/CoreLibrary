// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class ByteTests
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            var b = new byte();
            Assert.AreEqual((byte)0, b);
        }

        [TestMethod]
        public void Ctor_Value()
        {
            byte b = 41;
            Assert.AreEqual((byte)41, b);
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual((byte)0xFF, byte.MaxValue);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual((byte)0, byte.MinValue);
        }

        [TestMethod]
        [DataRow((byte)78, (byte)78, true)]
        [DataRow((byte)78, (byte)0, false)]
        [DataRow((byte)0, (byte)0, true)]
        public void Equals_ByteToByte(byte b, byte obj, bool expected)
        {
            OutputHelper.WriteLine($"Testing combination {b} and {obj}");
            Assert.AreEqual(expected, b.Equals(obj), $"Equality test between {b} and {obj} failed");
            Assert.AreEqual(expected, b.GetHashCode().Equals(obj.GetHashCode()), $"HashCode of {b}({b.GetHashCode()}) differs from the one of {obj}({obj.GetHashCode()})");
            Assert.AreEqual(b, b.GetHashCode(), $"HashCode of {b} different from expected, is {b.GetHashCode()}");
        }

        [TestMethod]
        public void Equals_ByteToNull()
        {
            byte b = 78;
            object obj = null;
            OutputHelper.WriteLine($"Testing combination {b} and {obj}");
            Assert.AreEqual(false, b.Equals(obj), $"Equality test between {b} and {obj} failed");
        }

        [TestMethod]
        public void Equals_ByteToString()
        {
            byte b = 78;
            object obj = "78";
            OutputHelper.WriteLine($"Testing combination {b} and {obj}");
            Assert.AreEqual(false, b.Equals(obj), $"Equality test between {b} and {obj} failed");
        }

        [TestMethod]
        public void Equals_ByteToInt()
        {
            byte b = 78;
            object obj = 78;
            OutputHelper.WriteLine($"Testing combination {b} and {obj}");
            Assert.AreEqual(false, b.Equals(obj), $"Equality test between {b} and {obj} failed");
        }
    }
}
