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
        public void GetHashCode_Invoke_ReturnsExpected()
        {
            bool _true = true;
            bool _false = false;

            Assert.AreEqual(_true.GetHashCode(), 1);
            Assert.AreEqual(_false.GetHashCode(), 0);
        }
    }
}
