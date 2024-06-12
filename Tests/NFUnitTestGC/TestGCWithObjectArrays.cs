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
    public class TestGCWithObjectArrays
    {
        [TestMethod]
        public void TestCompactionForNotFixedArray()
        {
            // Starting TestCompactionForNotFixedArray

            for (int loop = 0; loop < 10; loop++)
            {
                OutputHelper.WriteLine($"Starting iteration {loop}");

                // First we create objects and holes that keeps some space that could be used by compaction

                // Small count so compaction does not happen
                object[] arrayOfArrays = new object[10];

                RunAllocations(arrayOfArrays);

                // This is the array that we expect to move in during compaction.
                int[] testNativeBuffer = new int[100];

                // Fill it, so it is not optimized out
                Random random = new Random();
                var baseValue = random.Next();

                for (int i = 0; i < testNativeBuffer.Length; i++)
                {
                    testNativeBuffer[i] = i * baseValue;
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

        void RunAllocations(object[] arrObj)
        {
            for (int i = 1; i < arrObj.Length; i++)
            {
                // Creates referenced interger object, which stays in memory until InitiateCompaction exits
                arrObj[i] = new int();

                // Tries to create larger object that would be later hole . 
                // This object could be garbage collected on each "i" cycle.
                int[] arr = new int[50 * i];

                // Creates some usage for arr, so it is not optimized out. 
                arr[0] = i;
                arr[1] = 50 * i;

                OutputHelper.WriteLine($"On Cycle {i:D3} Array of {arr[1]} was allocated");
            }
        }

        // This method causes compaction to occur.
        // It is not so trivial as it need to fragment heap with referenced objects.      
        void InitiateCompaction()
        {
            // large count, so compaction happens during call to RunAllocations
            object[] arrayOfArrays = new object[1500];
            RunAllocations(arrayOfArrays);
        }
    }
}
