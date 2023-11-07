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
    public class TestGCWithStringArrays
    {
        [TestMethod]
        public void TestCompactionForNotFixedStringArray()
        {
            OutputHelper.WriteLine("Starting TestCompactionForNotFixedStringArray");

            for (int loop = 0; loop < 10; loop++)
            {
                OutputHelper.WriteLine($"Starting iteration {loop}");

                // First we create objects and holes that keeps some space that could be used by compaction.
                   
                // Small count so compaction does not happen. 
                HolderForString[] arrayOfStrings = new HolderForString[10];
                RunStringAllocations(arrayOfStrings);

                // This is the array that we expect to move in during compaction.
                HolderForString[] testNativeBuffer = new HolderForString[100];
                // Fill it, so it is not optimized out
                for (int i = 0; i < testNativeBuffer.Length; i++)
                {
                    testNativeBuffer[i] = new HolderForString(Guid.NewGuid().ToString());
                }

                OutputHelper.WriteLine("Large HolderForString array created");
                OutputHelper.WriteLine("Forcing compaction to occurr");

                // Causes compaction
                InitiateStringCompaction();

                OutputHelper.WriteLine("Compaction occurred");
                OutputHelper.WriteLine("Checking arrays for corrupted data...");

                int index = 0;

                // Check that array content is not corrupted
                foreach (HolderForString holder in testNativeBuffer)
                {
                    Assert.AreEqual(
                        holder.StringHash,
                        holder.StringContent.GetHashCode(),
                        $"Array content comparison failed at position {index}. Expecting {holder.StringHash}, found {holder.StringContent.GetHashCode()}");

                    index++;
                }

                OutputHelper.WriteLine("No corruption detected in array");
            }

            OutputHelper.WriteLine("Completed TestCompactionForNotFixedArray");
        }

        // This function cause compaction to occur.
        // It is not so trivial as it need to fragment heap with referenced objects.      
        void InitiateStringCompaction()
        {
            // Large count, so compaction happens during RunAllocations.
            HolderForString[] arrayOfArrays = new HolderForString[400];
            RunStringAllocations(arrayOfArrays);
        }

        private void RunStringAllocations(HolderForString[] arrObj)
        {
            for (int i = 1; i < arrObj.Length; i++)
            {
                // Creates referenced object, which stays in memory until InitiateCompaction exits
                arrObj[i] = new HolderForString(Guid.NewGuid().ToString());

                // Tries to create larger object that would be later hole
                // This object could be garbage collected on each "i" cycle
                HolderForString[] arr = new HolderForString[50 * i];

                // Creates some usage for array elements, so it is not optimized out
                arr[0] = new HolderForString(Guid.NewGuid().ToString());
            }
        }

        private class HolderForString
        {
            public int StringHash { get; }
            public string StringContent { get; }

            public HolderForString(string value)
            {
                StringContent = value;
                StringHash = value.GetHashCode();
            }
        }
    }
}
