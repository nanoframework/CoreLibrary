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
    class UnitTestWaitHandleTests
    {
        static WaitHandle[] waitHandles = new WaitHandle[]
        {
            new AutoResetEvent(false),
            new AutoResetEvent(false)
        };


        static void DoTask1()
        {
            AutoResetEvent are = (AutoResetEvent)waitHandles[0];
            int time = 10000;
            Thread.Sleep(time);
            are.Set();
        }

        static void DoTask2()
        {
            AutoResetEvent are = (AutoResetEvent)waitHandles[1];
            int time = 500;
            Thread.Sleep(time);
            are.Set();
        }

        [TestMethod]
        public void WaitHandle1_WaitAll_WaitAny_Test()
        {
            /// <summary>
            /// 1. Starts two threads
            /// 2. Calls WaitAll with respect to those threads
            /// 3. Verifies that both threads have executed
            /// 4. Restarts the threads
            /// 5. Calls WaitAny with respect to those threads
            /// 6. Verifies that only one threads has executed
            /// </summary>
            ///
            OutputHelper.WriteLine("This test may erroneously pass or fail due to machine speed");
            OutputHelper.WriteLine("Tests the WaitAll method");

            OutputHelper.WriteLine("Create threads");
            Thread t1 = new Thread(DoTask1);
            Thread t2 = new Thread(DoTask2);
            t1.Start();
            t2.Start();
            Thread.Sleep(1);

            OutputHelper.WriteLine("Waiting for all tasks to complete and verifying");
            if (!WaitHandle.WaitAll(waitHandles))
            {
                OutputHelper.WriteLine("Not all waithandles has received the signal");
                throw new Exception("Not all waithandles has received the signal");
            }
            bool r = t1.IsAlive, s = t2.IsAlive;
            if (r || s)
            {
                OutputHelper.WriteLine("Not all threads are dead");
                if (r)
                {
                    OutputHelper.WriteLine("t1 is Alive");
                }
                if (s)
                {
                    OutputHelper.WriteLine("t2 is Alive");
                }
                throw new Exception("Not all threads are dead");
            }

            OutputHelper.WriteLine("Re-create threads");
            t1 = new Thread(DoTask1);
            t2 = new Thread(DoTask2);
            t1.Start();
            t2.Start();
            Thread.Sleep(1);

            OutputHelper.WriteLine("Waiting for either task to complete and verifying");
            OutputHelper.WriteLine("The WaitHandle with index " + WaitHandle.WaitAny(waitHandles).ToString() + " satisfied the wait");
            OutputHelper.WriteLine("Doing t1 XOR t2 to verify only one but not both are alive or dead");
            OutputHelper.WriteLine("t1 XOR t2 = ~((p&q)||(~p & ~q))");
            bool p = t1.IsAlive, q = t2.IsAlive;
            if ((p && q) || ((!p) && (!q)))
            {
                OutputHelper.WriteLine("Not both but either one should have finished");
                throw new Exception("Not both but either one should have finished");
            }
            OutputHelper.WriteLine(p == true ? "t1 is Alive " : "t1 is Dead ");
            OutputHelper.WriteLine(q == true ? "t2 is Alive " : "t2 is Dead ");

        }

        static AutoResetEvent ready = new AutoResetEvent(false);
        static AutoResetEvent go = new AutoResetEvent(false);
        static int counter = 0;

        static void Work()
        {
            while (true)
            {
                ready.Set();                          // Indicate that we're ready
                go.WaitOne();                         // Wait to be kicked off...
                if (counter == 0) return;             // Gracefully exit
                OutputHelper.WriteLine("Counter = " + counter);
            }
        }

        [TestMethod]
        public void WaitHandle2_WatiOne_Test()
        {
            /// <summary>
            /// 1. Starts a thread
            /// 2. waits until the thread is ready, calling WaitOne
            /// 3. when the thread signals it's ready, it continues executing
            /// 4. worker thread waits on the other hand till it's signaled
            /// 5. worker thread continues execution when signaled
            /// 6. Verifies thread waits, and executes when signaled.
            /// </summary>
            ///

            OutputHelper.WriteLine("This test verifies thread waits, and executes when signaled");
            OutputHelper.WriteLine("Tests WaitOne method");
            Thread newThread1 = new Thread(Work);
            newThread1.Start();

            OutputHelper.WriteLine("Signal the worker 5 times");
            for (int i = 1; i <= 5; i++)
            {
                OutputHelper.WriteLine("First wait until worker is ready");
                ready.WaitOne();
                OutputHelper.WriteLine("Doing task");
                counter++;
                OutputHelper.WriteLine("Tell worker to go!");
                go.Set();
            }
            if (counter != 5)
            {
                OutputHelper.WriteLine("expected signaling '5' but got '" + counter + "'");
                throw new Exception("expected signaling '5' but got '" + counter + "'");
            }
            OutputHelper.WriteLine("Tell the worker to end by reseting counter to 0(zero)");
            ready.WaitOne();
            counter = 0;
            go.Set();
        }

    }
}
