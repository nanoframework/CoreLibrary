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
    class UnitTestMonitorTests
    {
        public static int monCount = 0;
        public static object mutex = new object();
        static public void MonitoredThreadIncrementor()
        {
            Thread.Sleep(new Random().Next(10));
            Monitor.Enter(mutex);
            monCount++;
            Monitor.Exit(mutex);
        }
        static public void MonitoredThreadDecrementor()
        {
            Thread.Sleep(new Random().Next(10));
            Monitor.Enter(mutex);
            monCount--;
            Monitor.Exit(mutex);
        }
        static public void MonitoredThreadIncrementorStarter()
        {
            Thread[] threadArrayInc = new Thread[4];
            for (int i = 0; i < 4; i++)
            {
                Debug.WriteLine("Attempting to start inc thread " + i);
                threadArrayInc[i] = new Thread(MonitoredThreadIncrementor);
                threadArrayInc[i].Start();
                Thread.Sleep(1);
            }
            Thread.Sleep(10);
            for (int i = 0; i < 4; i++)
            {
                threadArrayInc[i].Join();
            }
        }
        static public void MonitoredThreadDecrementorStarter()
        {
            Thread[] threadArrayDec = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                Debug.WriteLine("Attempting to start dec thread " + i);
                threadArrayDec[i] = new Thread(MonitoredThreadDecrementor);
                threadArrayDec[i].Start();
                Thread.Sleep(1);
            }
            Thread.Sleep(10);
            for (int i = 0; i < 5; i++)
            {
                threadArrayDec[i].Join();
            }
        }
        static public void MonitoredThreadIncrementor2Starter()
        {
            Thread[] threadArrayInc2 = new Thread[6];
            for (int i = 0; i < 6; i++)
            {
                Debug.WriteLine("Attempting to start inc2 thread " + i);
                threadArrayInc2[i] = new Thread(MonitoredThreadIncrementor);
                threadArrayInc2[i].Start();
                Thread.Sleep(1);
            }
            Thread.Sleep(10);
            for (int i = 0; i < 6; i++)
            {
                threadArrayInc2[i].Join();
            }
        }

        [TestMethod]
        public void Monitor1_Basic_Test()
        {
            /// <summary>
            /// 1. Starts 4 threads that run asynchronously
            /// 2. Each thread increments or decrements while in a critical section
            /// 3. Waits for execution and then verifies that all expected operations completed
            /// </summary>
            ///

            Debug.WriteLine("Starts several async threads that Enter and Exit critical sections.");
            Debug.WriteLine("This may erroneously pass.");
            Debug.WriteLine("This may erroneously fail for extremely slow devices.");
            Debug.WriteLine("Starting the 4 threads");
            Thread incThread = new Thread(MonitoredThreadIncrementorStarter);
            incThread.Start();
            Thread decThread = new Thread(MonitoredThreadDecrementorStarter);
            decThread.Start();
            Thread inc2Thread = new Thread(MonitoredThreadIncrementor2Starter);
            inc2Thread.Start();
            Thread lastThread = new Thread(MonitoredThreadDecrementor);
            lastThread.Start();
            Thread.Sleep(1);
            Debug.WriteLine("Joining All threads to main thread");
            incThread.Join();
            decThread.Join();
            inc2Thread.Join();
            lastThread.Join();
            Debug.WriteLine("Verifying all operations completed successfully");
            if (monCount != 4)
            {
                Debug.WriteLine("expected final result = '4' but got '" + monCount + "'");
                throw new Exception("expected final result = '4' but got '" + monCount + "'");
            }
        }

        static object locker1 = new object();

        [TestMethod]
        public void Monitor2_SynchronizationLockException_Test()
        {
            /// <summary>
            /// 1. Call Monitor.Exit without first calling Monitor.Enter on the same object
            /// 2. Verify SynchronizationLockException exception is thrown
            /// </summary>
            ///
            Debug.WriteLine("Verify SynchronizationLockException exception is thrown");
            Debug.WriteLine("Calling Monitor.Exit without first calling Monitor.Enter should throw an exception");
            Assert.Trows(typeof(Exception), () => { Monitor.Exit(locker1); });
        }

        [TestMethod]
        public void Monitor3_Enter_ArgumentNullException_Test()
        {
            /// <summary>
            /// 1. Call Monitor.Enter passing null reference obj parameter
            /// 2. verify ArgumentNullException exception is thrown
            /// </summary>
            ///

            Debug.WriteLine("verify ArgumentNullException exception is thrown ");
            Debug.WriteLine("Calling Monitor.Enter passing null reference parameter should throw exception");
            Assert.Trows(typeof(ArgumentNullException), () => { Monitor.Enter(null); });

        }

        [TestMethod]
        public void Monitor4_Exit_ArgumentNullException_Test()
        {
            /// <summary>
            /// 1. Call Monitor.Exit passing null reference obj parameter
            /// 2. verify ArgumentNullException exception is thrown
            /// </summary>
            ///
            Debug.WriteLine("verify ArgumentNullException exception is thrown ");
            Debug.WriteLine("Calling Monitor.Exit passing 'null' reference parameter should throw exception");
            Assert.Trows(typeof(ArgumentNullException), () => { Monitor.Exit(null); });
        }

        static ManualResetEvent flag = new ManualResetEvent(false);
        static bool lockResult = false;
        static object locker2 = new object();
        static void RepeatedLock()
        {
            Debug.WriteLine("T1 = " + DateTime.UtcNow);
            Monitor.Enter(locker2);
            try
            {
                lockResult = !lockResult;
                Debug.WriteLine("I have the lock");
                Nest();
                Debug.WriteLine("I still have the lock");
            }
            finally
            {
                if (flag.WaitOne(500, false))
                {
                    Monitor.Exit(locker2);
                    Debug.WriteLine("Here the lock is released");
                }
            }
            Debug.WriteLine("T4 = " + DateTime.UtcNow);
        }

        static void Nest()
        {
            Debug.WriteLine("T2 = " + DateTime.UtcNow);
            Monitor.Enter(locker2);
            try
            {
                Debug.WriteLine("Inside Lock");
            }
            finally
            {
                Monitor.Exit(locker2);
                Debug.WriteLine("Released the lock? Not quite!");
            }
            Debug.WriteLine("T3 = " + DateTime.UtcNow);
        }

        [TestMethod]
        public void Monitor5_Repeatedly_Lock_Unlock_Test()
        {
            Debug.WriteLine("Starts two Threads ");
            Debug.WriteLine("Repeatedly locks an object by multiple calls to Monitor.Enter");
            Debug.WriteLine("Verifies the object is unlocked only by a corresponding number of Monitor.Exit");
            Thread newThread1 = new Thread(RepeatedLock);
            Thread newThread2 = new Thread(RepeatedLock);
            Debug.WriteLine("Starting two threads, repeatedly locking, waiting and verifying");
            newThread1.Start();
            newThread2.Start();
            Thread.Sleep(100);
            if (!lockResult)
            {
                Debug.WriteLine("Failure : both threads passed lock");
                throw new Exception("Failure : both threads passed lock");                
            }
            Debug.WriteLine("unlocking the final lock and verifying the waiting thread continues");
            flag.Set();
            Thread.Sleep(500);
            if (lockResult)
            {
                Debug.WriteLine("Failure : lock not released by equal number of unlocks");
                throw new Exception("Failure : lock not released by equal number of unlocks");
            }
            if (newThread1.IsAlive)
                newThread2.Abort();
            if (newThread2.IsAlive)
                newThread2.Abort();
        }

    }
}
