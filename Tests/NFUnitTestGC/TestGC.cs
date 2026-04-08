// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


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

            // Starting TestGCStress

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

            // Completed TestGCStress
        }
    }
}
