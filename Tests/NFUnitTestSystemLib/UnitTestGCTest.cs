// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestGCTest
    {
#pragma warning disable S1215 // this is intended to test the GC
#pragma warning disable S1854 // this is intended to test the GC
#pragma warning disable S2696 // this is intended to test the GC
#pragma warning disable S3971 // this is intended to test the GC

        internal class FinalizeObject
        {
            public static FinalizeObject m_currentInstance = null;

            ~FinalizeObject()
            {
                if (!m_hasFinalized1)
                {
                    // First finalization

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
                    // Second finalization
                    m_hasFinalized2 = true;
                }
            }
        }

        static bool m_hasFinalized1 = false;
        static bool m_hasFinalized2 = false;
        static bool m_Test1Result = false;

        [TestMethod]
        public void SystemGC1_Test()
        {
            /// <summary>
            /// 1. Create a FinalizeObject.
            /// 2. Release the reference
            /// 3. Allow for GC
            /// 4. Run ReRegisterForFinalize
            /// 5. Allow for GC
            /// 6. Verify that object has been collected
            /// </summary>
            ///

            OutputHelper.WriteLine("Tests ReRegisterForFinalize");
            OutputHelper.WriteLine("Create a FinalizeObject.");

            FinalizeObject mfo = new FinalizeObject();
            m_hasFinalized1 = false;
            m_hasFinalized2 = false;

            // Release reference
            OutputHelper.WriteLine("Release reference");
            mfo = null;

            OutputHelper.WriteLine("Allow GC");
            GC.Collect();

            int sleepTime = 1000;
            int slept = 0;

            while (!m_hasFinalized1 && slept < sleepTime)
            {
                // force GC run caused by memory allocation
                var dummyArray = new byte[1024 * 1024 * 1];

                System.Threading.Thread.Sleep(10);
                slept += 10;
            }

            OutputHelper.WriteLine($"GC took {slept}");

            // At this point mfo will have gone through the first Finalize.
            // There should now be a reference to mfo in the static
            // FinalizeObject.m_currentInstance field.  Setting this value
            // to null and forcing another garbage collection will now
            // cause the object to Finalize permanently.

            OutputHelper.WriteLine("Reregister and allow for GC");
            FinalizeObject.m_currentInstance = null;
            GC.Collect();

            sleepTime = 1000;
            slept = 0;

            while (!m_hasFinalized2 && slept < sleepTime)
            {
                // force GC run caused by memory allocation
                var dummyArray = new byte[1024 * 1024 * 1];

                System.Threading.Thread.Sleep(10);
                slept += 10;
            }

            OutputHelper.WriteLine($"GC took {slept}");

            m_Test1Result = m_hasFinalized2;
            Assert.IsTrue(m_hasFinalized2);
        }

        [TestMethod]
        public void SystemGC2_Test()
        {
            /// <summary>
            /// 1. Create a FinalizeObject.
            /// 2. Release the reference
            /// 3. SupressFinalize
            /// 3. Allow for GC
            /// 6. Verify that object has not been collected
            /// </summary>
            ///

            OutputHelper.WriteLine("Tests SuppressFinalize");
            OutputHelper.WriteLine("Create a FinalizeObject");
            FinalizeObject mfo = new FinalizeObject();
            m_hasFinalized1 = false;
            m_hasFinalized2 = false;

            OutputHelper.WriteLine("Releasing");
            GC.SuppressFinalize(mfo);
            mfo = null;

            OutputHelper.WriteLine("Allow GC");
            GC.Collect();

            int sleepTime = 1000;
            int slept = 0;

            while (!m_hasFinalized1 && slept < sleepTime)
            {
                // force GC run caused by memory allocation
                _ = new byte[1024 * 1024 * 1];

                System.Threading.Thread.Sleep(10);
                slept += 10;
            }

            OutputHelper.WriteLine($"GC took {slept}");

            Assert.IsFalse(m_hasFinalized1);
        }

        [TestMethod]
        public void SystemGC3_Test()
        {
            /// <summary>
            /// 1. Create a FinalizeObject.
            /// 2. Release the reference
            /// 3. SupressFinalize
            /// 3. Allow for GC
            /// 6. Verify that object has not been collected
            /// </summary>
            ///

            OutputHelper.Write("Tests WaitForPendingFinalizers, dependant on test 1");
            OutputHelper.WriteLine("will fail if test 1 fails.");

            Assert.IsTrue(m_Test1Result, "Can't run this test as SystemGC1_Test has failed.");

            OutputHelper.WriteLine("Create a FinalizeObject");
            FinalizeObject mfo = new FinalizeObject();
            m_hasFinalized1 = false;
            m_hasFinalized2 = false;

            OutputHelper.WriteLine("Releasing");
            mfo = null;

            OutputHelper.WriteLine("Wait for GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            OutputHelper.WriteLine("Releasing again");
            FinalizeObject.m_currentInstance = null;

            OutputHelper.WriteLine("Wait for GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Assert.IsTrue(m_hasFinalized2);
        }
    }
#pragma warning restore S1215 // "GC.Collect" should not be called
#pragma warning restore S1854 // Unused assignments should be removed
#pragma warning restore S2696 // Instance members should not write to "static" fields
#pragma warning restore S3971 // "GC.SuppressFinalize" should not be called
}
