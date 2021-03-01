//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestSystemLib
{
    [TestClass]
    class UnitTestWeakReferenceTests
    {
        //WeakRef Test methods
        static bool hasFinalized1 = false;
        public class WeakRefClass
        {
            public int data = 5;
            public WeakRefClass() { }
            ~WeakRefClass()
            {
                Debug.WriteLine("Finalized.");
                hasFinalized1 = true;
            }
            void MakeSomeGarbage()
            {
                // Create objects and release them
                // to fill up memory with unused objects.
                object junk;
                for (int i = 0; i < 10000; i++)
                {
                    junk = new object();
                }
            }
        }

        [TestMethod]
        public void WeakRef1_Test()
        {
            //  1. Create an object with strong ref
            //  2. Create a short weak ref to the onject
            //  3. Allow for GC
            //  4. Verify & Remove Strong reference
            //  5. Allow for GC
            //  6. If weak ref surivived verify its data
            Debug.WriteLine("Create an object with strong ref");
            WeakRefClass WRC1 = new WeakRefClass();

            Debug.WriteLine("Create a short weak ref to the onject");
            WeakReference wr = new WeakReference(WRC1);
            wr.Target = WRC1;

            Debug.WriteLine("Allow for GC");
            GC.WaitForPendingFinalizers();
            int sleepTime = 1000;
            int slept = 0;
            while (!hasFinalized1 && slept < sleepTime)
            {
                System.Threading.Thread.Sleep(10);
                slept += 10;
            }
            Debug.WriteLine("GC took " + slept);

            Assert.False(hasFinalized1);

            Debug.WriteLine("Verify & Remove Strong reference");
            Assert.Equal(((WeakRefClass)wr.Target).data, 5);
            WRC1 = null;
            Assert.Null(WRC1);

            Debug.WriteLine("Allow for GC");
            // We should force the finalizer somehow
            GC.WaitForPendingFinalizers();
            sleepTime = 1000;
            slept = 0;
            while (!hasFinalized1 && slept < sleepTime)
            {
                System.Threading.Thread.Sleep(10);
                slept += 10;
            }
            Debug.WriteLine("GC took " + slept);
            Assert.True(hasFinalized1);
            Assert.Null(WRC1 );

            if (wr.IsAlive)
            {
                Assert.Equal(((WeakRefClass)wr.Target).data, 5);
                Debug.WriteLine("Weak Reference survived.");
            }
            else
            {
                Debug.WriteLine("Weak Reference has been collected");
            }
        }

    }
}
