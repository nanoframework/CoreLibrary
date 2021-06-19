﻿//
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
    class UnitTestGCTest
    {
        class FinalizeObject
        {
            public static FinalizeObject m_currentInstance = null;

            ~FinalizeObject()
            {
                if (m_hasFinalized1 == false)
                {
                    OutputHelper.WriteLine("First finalization");

                    // Put this object back into a root by creating
                    // a reference to it.
                    FinalizeObject.m_currentInstance = this;

                    // Indicate that this instance has finalized once.
                    m_hasFinalized1 = true;

                    // Place a reference to this object back in the
                    // finalization queue.
                    GC.ReRegisterForFinalize(this);
                }
                else
                {
                    OutputHelper.WriteLine("Second finalization");
                    m_hasFinalized2 = true;
                }
            }
        }

        static bool m_hasFinalized1 = false;
        static bool m_hasFinalized2 = false;
        static bool m_Test1Result = false;

        //[TestMethod]
        //public void SystemGC1_Test()
        //{
        //    /// <summary>
        //    /// 1. Create a FinalizeObject.
        //    /// 2. Release the reference
        //    /// 3. Allow for GC
        //    /// 4. Run ReRegisterForFinalize
        //    /// 5. Allow for GC
        //    /// 6. Verify that object has been collected
        //    /// </summary>
        //    ///
        //    OutputHelper.WriteLine("Tests ReRegisterForFinalize");
        //    OutputHelper.WriteLine("Create a FinalizeObject.");
        //    FinalizeObject mfo = new FinalizeObject();
        //    m_hasFinalized1 = false;
        //    m_hasFinalized2 = false;

        //    OutputHelper.WriteLine("Release reference");
        //    mfo = null;

        //    OutputHelper.WriteLine("Allow GC");
        //    GC.WaitForPendingFinalizers();
        //    int sleepTime = 1000;
        //    int slept = 0;
        //    while (m_hasFinalized1 == false && slept < sleepTime)
        //    {
        //        System.Threading.Thread.Sleep(10);
        //        slept += 10;
        //    }
        //    OutputHelper.WriteLine("GC took " + slept);

        //    // At this point mfo will have gone through the first Finalize.
        //    // There should now be a reference to mfo in the static
        //    // FinalizeObject.m_currentInstance field.  Setting this value
        //    // to null and forcing another garbage collection will now
        //    // cause the object to Finalize permanently.
        //    OutputHelper.WriteLine("Reregister and allow for GC");
        //    FinalizeObject.m_currentInstance = null;
        //    GC.WaitForPendingFinalizers();
        //    sleepTime = 1000;
        //    slept = 0;
        //    while (m_hasFinalized2 == false && slept < sleepTime)
        //    {
        //        System.Threading.Thread.Sleep(10);
        //        slept += 10;
        //    }
        //    OutputHelper.WriteLine("GC took " + slept);

        //    m_Test1Result = m_hasFinalized2;
        //    Assert.True(m_hasFinalized2);
        //}

        //[TestMethod]
        //public void SystemGC2_Test()
        //{
        //    /// <summary>
        //    /// 1. Create a FinalizeObject.
        //    /// 2. Release the reference
        //    /// 3. SupressFinalize
        //    /// 3. Allow for GC
        //    /// 6. Verify that object has not been collected
        //    /// </summary>
        //    ///
        //    OutputHelper.WriteLine("Tests SuppressFinalize");
        //    OutputHelper.WriteLine("Create a FinalizeObject.");
        //    FinalizeObject mfo = new FinalizeObject();
        //    m_hasFinalized1 = false;
        //    m_hasFinalized2 = false;

        //    OutputHelper.WriteLine("Releasing");
        //    System.GC.SuppressFinalize(mfo);
        //    mfo = null;

        //    OutputHelper.WriteLine("Allow GC");
        //    GC.WaitForPendingFinalizers();
        //    int sleepTime = 1000;
        //    int slept = 0;
        //    while (m_hasFinalized1 == false && slept < sleepTime)
        //    {
        //        System.Threading.Thread.Sleep(10);
        //        slept += 10;
        //    }
        //    OutputHelper.WriteLine("GC took " + slept);

        //    Assert.False(m_hasFinalized1);
        //}

        //[TestMethod]
        //public void SystemGC3_Test()
        //{
        //    /// <summary>
        //    /// 1. Create a FinalizeObject.
        //    /// 2. Release the reference
        //    /// 3. SupressFinalize
        //    /// 3. Allow for GC
        //    /// 6. Verify that object has not been collected
        //    /// </summary>
        //    ///
        //    OutputHelper.WriteLine("Tests WaitForPendingFinalizers, dependant on test 1");
        //    OutputHelper.WriteLine("will auto-fail if test 1 fails.");
        //    Assert.True(m_Test1Result);

        //    OutputHelper.WriteLine("Create a FinalizeObject.");
        //    FinalizeObject mfo = new FinalizeObject();
        //    m_hasFinalized1 = false;
        //    m_hasFinalized2 = false;

        //    OutputHelper.WriteLine("Releasing");
        //    mfo = null;

        //    OutputHelper.WriteLine("Wait for GC");
        //    GC.WaitForPendingFinalizers();
        //    System.GC.WaitForPendingFinalizers();

        //    OutputHelper.WriteLine("Releasing again");
        //    FinalizeObject.m_currentInstance = null;

        //    OutputHelper.WriteLine("Wait for GC");
        //    GC.WaitForPendingFinalizers();
        //    System.GC.WaitForPendingFinalizers();

        //    Assert.True(m_hasFinalized2);
        //}

    }
}
