// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using nanoFramework.TestFramework;

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

            for (int loop = 0; loop < 100; loop++)
            {
                OutputHelper.WriteLine($"Running iteration {loop}");

                for (int i = 0; i < arrays.Length - 1;)
                {
                    OutputHelper.WriteLine($"Alloc array of {maxArraySize} bytes @ pos {i}");
                    arrays[i++] = new byte[maxArraySize];

                    OutputHelper.WriteLine($"Alloc array of 64 bytes @ pos {i}");
                    arrays[i++] = new byte[64];
                }

                arrays[0] = new byte[maxArraySize];

                for (int i = 0; i < arrays.Length; i++)
                {
                    arrays[i] = null;
                }
            }
        }

        [TestMethod]
        public void TestGetTotalMemory()
        {
            // create several objects
            object[] objects = new object[100];

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i] = new object();
            }

            // get total memory
            long totalMemory = GC.GetTotalMemory(false);
            OutputHelper.WriteLine($"Total memory: {totalMemory} bytes");

            // release objects
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i] = null;
            }

            // get total memory, forcing full collection
            long totalMemoryAfterCollection = GC.GetTotalMemory(true);
            OutputHelper.WriteLine($"Total memory: {totalMemoryAfterCollection} bytes");

            // check if memory was released
            Assert.IsTrue(totalMemory > totalMemoryAfterCollection, "Memory was not released");
        }
    }
}
