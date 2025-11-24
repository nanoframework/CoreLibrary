// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    class BooleanTests
    {
        [TestMethod]
        public void TrueString_Get_ReturnsTrue()
        {
            Assert.AreEqual("True", bool.TrueString);
        }

        [TestMethod]
        public void FalseString_Get_ReturnsFalse()
        {
            Assert.AreEqual("False", bool.FalseString);
        }

        [TestMethod]
        [DataRow(true, 1)]
        [DataRow(false, 0)]
        public void GetHashCode_Invoke_ReturnsExpected(bool value, int expected)
        {
            Assert.AreEqual(value.GetHashCode(), expected);
        }
    }
}
