//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;
using System.Threading;

namespace NFUnitTestThread
{
    [TestClass]
    class UnitTestTimeoutTests
    {
        class Work
        {
            public void DoWorkInfinite()
            {
                Thread.Sleep(300);
                OutputHelper.WriteLine("Instance thread procedure DoWorkInfinite.");
                Thread.Sleep(Timeout.Infinite);
            }
            public static void DoWorkInfiniteStatic()
            {
                Thread.Sleep(300);
                OutputHelper.WriteLine("Static thread procedure DoWorkInfiniteStatic.");
                Thread.Sleep(Timeout.Infinite);
            }
        }

        [TestMethod]
        public void Timeout1_Infinite_Test()
        {
            /// <summary>
            /// 1. Starts two threads which have an Infinite execution time one static
            /// 2. Calls Abort on the Infinite threads
            /// 3. Verifies that the aborted threads stop immediately
            /// </summary>
            ///

            OutputHelper.WriteLine("Starts two threads one infinitely long, aborts one and passes.");
            OutputHelper.WriteLine("This may erroneously fail for extremely slow devices.");

            OutputHelper.WriteLine("Starting the two threads");
            Thread newThread1 = new Thread(Work.DoWorkInfiniteStatic);
            newThread1.Start();
            Work w = new Work();
            Thread newThread2 = new Thread(w.DoWorkInfinite);
            newThread2.Start();
            Thread.Sleep(1);

            OutputHelper.WriteLine("Waiting for 1000msec and verifying both threads are alive");
            int slept = 0;
            while ((newThread1.IsAlive || newThread2.IsAlive) && slept < 1000)
            {
                Thread.Sleep(100);
                slept += 100;
            }
            if (!newThread1.IsAlive || !newThread2.IsAlive)
            {
                OutputHelper.WriteLine("Failure : Both threads were suppose to be sleeping for Timeout.Infinite");
                OutputHelper.WriteLine("IsAlive ? Thread1 = '" + newThread1.IsAlive + "' and Thread2 = '" + newThread2.IsAlive + "'");
                throw new Exception("IsAlive ? Thread1 = '" + newThread1.IsAlive + "' and Thread2 = '" + newThread2.IsAlive + "'");
            }

            OutputHelper.WriteLine("Aborting both threds and Verifying abort.");
            newThread2.Abort();
            newThread1.Abort();
            Thread.Sleep(10);
            if (newThread1.IsAlive || newThread2.IsAlive)
            {
                OutputHelper.WriteLine("Upon Abort both thread should be dead but");
                OutputHelper.WriteLine("IsAlive ? Thread1 = '" + newThread1.IsAlive + "' and Thread2 = '" + newThread2.IsAlive + "'");
                throw new Exception("IsAlive ? Thread1 = '" + newThread1.IsAlive + "' and Thread2 = '" + newThread2.IsAlive + "'");
            }
        }

    }
}
