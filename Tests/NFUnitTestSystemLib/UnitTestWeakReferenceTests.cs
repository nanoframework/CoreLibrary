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
                // Finalized.
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

        // Removing as using an external reference
        //[TestMethod]
        //public void WeakRef1_Test()
        //{
        //    //  1. Create an object with strong ref
        //    //  2. Create a short weak ref to the onject
        //    //  3. Allow for GC
        //    //  4. Verify & Remove Strong reference
        //    //  5. Allow for GC
        //    //  6. If weak ref surivived verify its data
        //    // Create an object with strong ref
        //    WeakRefClass WRC1 = new WeakRefClass();

        //    // Create a short weak ref to the onject
        //    WeakReference wr = new WeakReference(WRC1);
        //    wr.Target = WRC1;

        //    // Allow for GC
        //    nanoFramework.Runtime.Native.GC.Run(true);
        //    int sleepTime = 2000;
        //    int slept = 0;
        //    while (!hasFinalized1 && slept < sleepTime)
        //    {
        //        System.Threading.Thread.Sleep(10);
        //        slept += 10;
        //    }
        //    OutputHelper.WriteLine("GC took " + slept);

        //    Assert.IsFalse(hasFinalized1);

        //    // Verify & Remove Strong reference
        //    Assert.AreEqual(((WeakRefClass)wr.Target).data, 5);
        //    WRC1 = null;
        //    Assert.IsNull(WRC1);

        //    // Allow for GC
        //    // We should force the finalizer somehow
        //    nanoFramework.Runtime.Native.GC.Run(true);
        //    GC.WaitForPendingFinalizers();
        //    sleepTime = 2000;
        //    slept = 0;
        //    while (!hasFinalized1 && slept < sleepTime)
        //    {
        //        System.Threading.Thread.Sleep(10);
        //        slept += 10;
        //    }
        //    OutputHelper.WriteLine("GC took " + slept);
        //    Assert.IsTrue(hasFinalized1);
        //    Assert.IsNull(WRC1 );

        //    if (wr.IsAlive)
        //    {
        //        Assert.AreEqual(((WeakRefClass)wr.Target).data, 5);
        //        // Weak Reference survived.
        //    }
        //    else
        //    {
        //        // Weak Reference has been collected
        //    }
        //}
    }
}
