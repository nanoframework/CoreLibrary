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
    public class TestGCWithTimeSpanArrays
    {
        [TestMethod]
        public void TestCompactionForNotFixedTimeSpanArray()
        {
            // Starting TestCompactionForNotFixedTimeSpanArray

            for (int loop = 0; loop < 10; loop++)
            {
                OutputHelper.WriteLine($"Starting iteration {loop}");

                // First we create objects and holes that keeps some space that could be used by compaction.
                // Small count so compaction does not happen. 
                HolderForTimeSpan[] arrayOfArrays = new HolderForTimeSpan[10];
                RunTimeSpanAllocations(arrayOfArrays);

                // This is the array that we expect to move in during compaction.
                HolderForTimeSpan[] testNativeBuffer = new HolderForTimeSpan[100];
                // Fill it, so it is not optimized out
                for (int i = 0; i < testNativeBuffer.Length; i++)
                {
                    testNativeBuffer[i] = new HolderForTimeSpan(GetRandomTimeSpan());
                }

                // Large HolderForTimeSpan array created
                // Forcing compaction to occurr

                // Causes compaction
                InitiateTimeSpanCompaction();

                // Compaction occurred
                // Checking arrays for corrupted data...

                int index = 0;

                // Check that array content is not corrupted
                foreach (HolderForTimeSpan holder in testNativeBuffer)
                {
                    Assert.AreEqual(holder.StoredTicks, holder.TsValue.Ticks, $"Array content comparison failed at position {index}. Expecting {holder.StoredTicks}, found {holder.TsValue.Ticks}");
                    index++;
                }

                // No corruption detected in array
            }

            // Completed TestCompactionForNotFixedArray
        }

        private TimeSpan GetRandomTimeSpan()
        {
            Random rand = new();

            return TimeSpan.FromTicks(rand.Next() * 1000_000);
        }

        // This function cause compaction to occur.
        // It is not so trivial as it need to fragment heap with referenced objects.      
        void InitiateTimeSpanCompaction()
        {
            // Large count, so compaction happens during RunAllocations.
            HolderForTimeSpan[] arrayOfArrays = new HolderForTimeSpan[500];
            RunTimeSpanAllocations(arrayOfArrays);
        }

        private void RunTimeSpanAllocations(HolderForTimeSpan[] arrObj)
        {

            for (int i = 1; i < arrObj.Length; i++)
            {
                // Creates referenced object, which stays in memory until InitiateCompaction exits
                arrObj[i] = new HolderForTimeSpan(GetRandomTimeSpan());

                // Tries to create larger object that would be later hole
                // This object could be garbage collected on each "i" cycle
                HolderForTimeSpan[] arr = new HolderForTimeSpan[50 * i];

                // Creates some usage for array elements, so it is not optimized out
                arr[0] = new HolderForTimeSpan(TimeSpan.MinValue);
                arr[1] = new HolderForTimeSpan(TimeSpan.MaxValue);

                Console.WriteLine($"On Cycle {i:D3} DateTime holder allocated");
            }
        }

        private class HolderForTimeSpan
        {
            public long StoredTicks { get; }
            public TimeSpan TsValue { get; }

            public HolderForTimeSpan(TimeSpan ts)
            {
                StoredTicks = ts.Ticks;
                TsValue = ts;
            }
        }
    }
}
