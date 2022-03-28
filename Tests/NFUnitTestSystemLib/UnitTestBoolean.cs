//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    class BooleanTests
    {
        [TestMethod]
        public void TrueString_Get_ReturnsTrue()
        {
            Assert.Equal("True", bool.TrueString);
        }

        [TestMethod]
        public void FalseString_Get_ReturnsFalse()
        {
            Assert.Equal("False", bool.FalseString);
        }

        [TestMethod]
        public void GetHashCode_Invoke_ReturnsExpected()
        {
            bool _true = true;
            bool _false = false;

            Assert.Equal(_true.GetHashCode(), 1);
            Assert.Equal(_false.GetHashCode(), 0);
        }
    }
}
