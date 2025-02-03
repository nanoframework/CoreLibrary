// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestGC
{
    [TestClass]
    public class TestGCWithByteArrays
    {
        [TestMethod]
        public void TestCompactionForNotFixedArray()
        {
            // Starting TestCompactionForNotFixedArray

            for (int loop = 0; loop < 10; loop++)
            {
                OutputHelper.WriteLine($"Starting iteration {loop}");

                // First we create byte and holes that keeps some space that could be used by compaction

                // Small count so compaction does not happen
                byte[] arrayOfArrays = new byte[10];

                RunAllocations(arrayOfArrays);

                // This is the array that we expect to move in during compaction.
                byte[] testNativeBuffer = new byte[100];

                // Fill it, so it is not optimized out
                Random random = new();
                var baseValue = random.Next(2);

                for (int i = 0; i < testNativeBuffer.Length; i++)
                {
                    testNativeBuffer[i] = (byte)(i * baseValue);
                }

                // trigger compaction
                InitiateCompaction();

                int index = 0;

                // Check that array content is not corrupted
                foreach (var item in testNativeBuffer)
                {
                    Assert.AreEqual(index * baseValue, item, $"Array content comparison failed at position {index}. Expecting {(index * baseValue)}, found {item}");
                    index++;
                }

                // No corruption detected in array
            }

            // Completed TestCompactionForNotFixedArray
        }

        void RunAllocations(byte[] arrObj)
        {
            for (int i = 1; i < arrObj.Length; i++)
            {
                // Creates referenced byte, which stays in memory until InitiateCompaction exits
                arrObj[i] = new byte();

                // Tries to create larger object that would be later hole . 
                // This object could be garbage collected on each "i" cycle.
                byte[] arr = new byte[50 * i];

                // Creates some usage for arr, so it is not optimized out. 
                arr[0] = 1;
                arr[1] = 2;

                OutputHelper.WriteLine($"On Cycle {i:D3} Array of {arr[1]} was allocated");
            }
        }

        // This method causes compaction to occur.
        // It is not so trivial as it need to fragment heap with referenced byte array.      
        void InitiateCompaction()
        {
            // large count, so compaction happens during call to RunAllocations
            byte[] arrayOfArrays = new byte[1500];
            RunAllocations(arrayOfArrays);
        }
    }
}
