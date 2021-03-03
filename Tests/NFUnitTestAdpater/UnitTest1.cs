//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestAdpater
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestMethod()
        {
            Debug.WriteLine("This is just to get the TestAdapter. Don not remove this project!");
        }
    }
}
