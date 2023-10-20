//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//


using nanoFramework.TestFramework;
using System;

namespace NFUnitTestGC
{
    [TestClass]
    public class TestGC
    {
        [TestMethod]
        public void TestGCStress()
        {
            int maxArraySize = 1024 * 32;
            object[] arrays = new object[600];

            OutputHelper.WriteLine("Starting TestGCStress");

            for (int loop = 0; loop < 100; loop++)
            {
                OutputHelper.WriteLine($"Running iteration {loop}");

                for (int i = 0; i < arrays.Length - 1;)
                {
                    OutputHelper.WriteLine($"Alloc array of {maxArraySize} bytes @ pos {i}");
                    arrays[i++] = new byte[maxArraySize]; ;

                    OutputHelper.WriteLine($"Alloc array of 64 bytes @ pos {i}");
                    arrays[i++] = new byte[64];
                }

                arrays[0] = new byte[maxArraySize];

                for (int i = 0; i < arrays.Length; i++)
                {
                    arrays[i] = null;
                }
            }

            OutputHelper.WriteLine("Completed TestGCStress");
        }
    }
}
