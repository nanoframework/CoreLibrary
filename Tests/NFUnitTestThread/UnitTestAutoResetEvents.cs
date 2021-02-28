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
    class UnitTestAutoResetEvents
    {
        class Waiter
        {
            public static AutoResetEvent are1 = new AutoResetEvent(false);
            public static AutoResetEvent are2 = new AutoResetEvent(true);
            public bool flag;
            public int wait;
            public DateTime t1;
            public DateTime t2;

            public void DoWait()
            {
                Debug.WriteLine("Waiting...");
                t1 = DateTime.UtcNow;
                are1.WaitOne();
                t2 = DateTime.UtcNow;
                flag = true;
                Debug.WriteLine("Notified");
            }

            public void DoWaitTimeOut()
            {
                Debug.WriteLine("Waiting...");
                are1.WaitOne(wait, false);
                flag = true;
            }

            public void DoWaitReset()
            {
                Debug.WriteLine("Waiting...");
                are2.WaitOne();
                flag = true;
            }
        }

        [TestMethod]
        public void AutoReset1_WaitOne_Set_Test()
        {
            ///<summary>
            ///Start a thread and make it wait by calling WaitOne until signaled by another thread.
            ///Verify that it continues executing when Set by the other thread.
            ///</summary>
            /// 

            Debug.WriteLine("Starts a thread and calls WaitOne inside the thread ");
            Debug.WriteLine("Signals The thread to continue execution");
            Debug.WriteLine("Verifies the thread has waited and continued execution upon calling Set");

            Debug.WriteLine("Starting Thread");
            Waiter newWaiter1 = new Waiter();
            Thread newThread1 = new Thread(newWaiter1.DoWait);
            newThread1.Start();

            Debug.WriteLine("Waiting and Signaling after 1000msec.");
            Thread.Sleep(1000);

            Debug.WriteLine("wake it up");
            DateTime t3 = DateTime.UtcNow;
            Waiter.are1.Set();

            Debug.WriteLine("Waiting the thread to finish and also to get t2");
            Thread.Sleep(10);
            TimeSpan duration1 = newWaiter1.t2 - newWaiter1.t1;
            TimeSpan duration2 = newWaiter1.t2 - t3;

            // Assuming atleast the thread should wait for 750ms           
            if (duration1.CompareTo(new TimeSpan(0, 0, 0, 0, 750)) <= 0)
            {
                Debug.WriteLine("The thread should have waited atleast 750 msec.");
                throw new Exception("The thread should have waited atleast 750 msec.");
            }
            if (duration2.CompareTo(new TimeSpan(0, 0, 0, 0, 0)) < 0)
            {
                Debug.WriteLine("The thread continued executing before it's signaled");
                throw new Exception("The thread continued executing before it's signaled");
            }
        }

        [TestMethod]
        public void AutoReset2_Set_WaitOne_Set_Test()
        {
            ///<summary>
            ///Calls Set repeatedly while no thread was blocked
            ///Starts two threads and call WaitOne on both. 
            ///Call Set by a third unblocked thread with access to the AutoResetEvent and
            ///verify that only one blocked thread is released.
            ///</summary>
            ///

            Debug.WriteLine("Calls Set repeatedly while no thread was blocked");
            Debug.WriteLine("Starts two threads and calls WaitOne on both threads ");
            Debug.WriteLine("Signals The thread to continue execution calling Set once");
            Debug.WriteLine("Verifies only one blocked thread is released");

            Waiter.are1.Set();
            Waiter.are1.Set();

            Waiter newWaiter1 = new Waiter();
            newWaiter1.flag = false;
            Thread newThread1 = new Thread(newWaiter1.DoWait);
            Waiter newWaiter2 = new Waiter();
            newWaiter2.flag = false;
            Thread newThread2 = new Thread(newWaiter2.DoWait);
            Debug.WriteLine("Starting The threads");
            newThread1.Start();
            newThread2.Start();

            Debug.WriteLine("Waiting and verifying only one of the threads is signaled");
            Thread.Sleep(1000);
            Debug.WriteLine("flag1 XOR flag2 =  ~((flag1 & flag2)||(~flag1 & ~flag2))");
            if ((newWaiter1.flag && newWaiter2.flag) || ((!newWaiter1.flag) && (!newWaiter2.flag)))
            {
                Debug.WriteLine("Only One of the threads should have been signaled");
                throw new Exception("Only One of the threads should have been signaled");
            }
            Waiter.are1.Set();
        }

        [TestMethod]
        public void AutoReset3_TwoWaitOne_TwoSet_Test()
        {
            ///<summary>
            ///Start two threads and call WaitOne on both. 
            ///Call Set twice by a third unblocked thread with access to the AutoResetEvent and
            ///verify that both blocked threads are released.
            ///</summary>
            ///

            Debug.WriteLine("Starts two threads and calls WaitOne on both threads ");
            Debug.WriteLine("Signals The threads to continue execution calling Set twice");
            Debug.WriteLine("Verifies both blocked threads are released");

            Waiter newWaiter1 = new Waiter();
            Thread newThread1 = new Thread(newWaiter1.DoWait);
            newWaiter1.flag = false;
            Waiter newWaiter2 = new Waiter();
            Thread newThread2 = new Thread(newWaiter2.DoWait);
            newWaiter2.flag = false;
            Debug.WriteLine("Starting threads, waiting and verifying both are waiting");
            newThread1.Start();
            newThread2.Start();
            Thread.Sleep(1000);
            if (newWaiter1.flag || newWaiter2.flag)
            {
                Debug.WriteLine("Failure: One or both threads are not waiting, Thread1 = '" +
                    newWaiter1.flag + "' Thread2 = '" + newWaiter2.flag + "'");
                throw new Exception("Failure: One or both threads are not waiting, Thread1 = '" +
                    newWaiter1.flag + "' Thread2 = '" + newWaiter2.flag + "'");
            }
            Debug.WriteLine("Signaling twice, waiting and verifying both threads are signaled");
            Waiter.are1.Set();
            Waiter.are1.Set();
            Thread.Sleep(1000);
            if (!newWaiter1.flag || !newWaiter2.flag)
            {
                Debug.WriteLine("Not both threads are signaled, Thread1 = '" + newWaiter1.flag +
                    "' and Thread2 = '" + newWaiter2.flag + "'");
                throw new Exception("Not both threads are signaled, Thread1 = '" + newWaiter1.flag +
                    "' and Thread2 = '" + newWaiter2.flag + "'");
            }
        }

        [TestMethod]
        public void AutoReset4_WaitOne_TimeOut_Test()
        {
            ///<summary>
            ///Starts a thread and call WaitOne passing timeout parameter
            ///Verify that the wait will end because of a timeout rather than obtaining a signal.
            ///</summary>
            ///

            Debug.WriteLine("Starts a thread and call WatiOne passing timeout parameter");
            Debug.WriteLine("verifies the wait will end because of timeout");
            Debug.WriteLine("Starts a 2nd thread and call WatiOne passing Timeout.Infinite");
            Debug.WriteLine("verifies the wait will not end for 3 sec (assumed Infinite)");

            Waiter newWaiter1 = new Waiter();
            newWaiter1.wait = 100;
            newWaiter1.flag = false;
            Thread newThread1 = new Thread(newWaiter1.DoWaitTimeOut);
            Debug.WriteLine("Starting thread, waiting and verifying wait timeouts");
            newThread1.Start();
            Thread.Sleep(500);
            if (!newWaiter1.flag)
            {
                Debug.WriteLine("Waited for 500msec. but Thread should have timeouted in " + newWaiter1.wait + "");
                throw new Exception("Waited for 500msec. but Thread should have timeouted in " + newWaiter1.wait + "");
            }
            Waiter newWaiter2 = new Waiter();
            newWaiter2.wait = -1;
            newWaiter2.flag = false;
            Thread newThread2 = new Thread(newWaiter2.DoWaitTimeOut);
            Debug.WriteLine("Starting thread, waiting for Timeout.Infinite and verifying");
            newThread2.Start();
            Thread.Sleep(3000);
            if (newWaiter2.flag)
            {
                Debug.WriteLine("Failure: thread didn't wait for Infinite.Timeout");
                throw new Exception("Failure: thread didn't wait for Infinite.Timeout");
            }
            Debug.WriteLine("finally signaling the Infinite.Timeout thread");
            Waiter.are1.Set();
        }

        [TestMethod]
        public void AutoReset5_Reset_Test()
        {
            ///<summary>
            ///Creates an AutoResetEvent having an initial state signaled
            ///Starts a thread, calls WaitOne and verifies the thread is not blocked
            ///Starts another thread, calls WaitOne and verifies it's auto reset (nonsignaled)
            ///calls Set and verify it's set (Signaled)
            ///calls Set, calls Reset, starts a thread and calls WaitOne on the thread
            ///Verifies that the thread remains blocked
            ///</summary>
            ///

            Debug.WriteLine("Creates an AutoResetEvent having an initial state signaled");
            Debug.WriteLine("Start a thread, call WaitOne and verify the thread is not blocked");
            Debug.WriteLine("Starts a 2nd thread, call WaitOne and verify it's auto reset (thread is blocked)");
            Debug.WriteLine("call Set and verify it's set (signaled)");
            Debug.WriteLine("call Set, call Reset, starts a thread and call WaitOne on the thread");
            Debug.WriteLine("Verify the thread remains blocked");

            Waiter newWaiter1 = new Waiter();
            newWaiter1.flag = false;
            Thread newThread1 = new Thread(newWaiter1.DoWaitReset);
            Debug.WriteLine("Starting thread, waiting and verifying thread not blocked if initial state is signaled");
            newThread1.Start();
            Thread.Sleep(100);
            if (!newWaiter1.flag)
            {
                Debug.WriteLine("Faiure : AutoResetEvent initial state signaled but blocked thread");
                throw new Exception("Faiure : AutoResetEvent initial state signaled but blocked thread");
            }

            Waiter newWaiter2 = new Waiter();
            newWaiter2.flag = false;
            Thread newThread2 = new Thread(newWaiter2.DoWaitReset);
            Debug.WriteLine("Starting thread, waiting and verifying autoreset blocks the thread");
            newThread2.Start();
            Thread.Sleep(100);
            if (newWaiter2.flag)
            {
                Debug.WriteLine("Failure : AutoResetEvent not autoreseted");
                throw new Exception("Failure : AutoResetEvent not autoreseted");
            }
            Debug.WriteLine("Signaling, waiting and verifying");
            Waiter.are2.Set();
            Thread.Sleep(100);
            if (!newWaiter2.flag)
            {
                Debug.WriteLine("Failure : AutoResetEvent signaled but thread blocked");
                throw new Exception("Failure : AutoResetEvent signaled but thread blocked");
            }
            Debug.WriteLine("Set, Reset, Start a thread, waiting and verifying thread remain blocked");
            Waiter newWaiter3 = new Waiter();
            newWaiter3.flag = false;
            Thread newThread3 = new Thread(newWaiter3.DoWaitReset);
            Waiter.are2.Set();
            Waiter.are2.Reset();
            newThread3.Start();
            Thread.Sleep(100);
            if (newWaiter3.flag)
            {
                Debug.WriteLine("Failure: a Reseted AutoResetEvent didn't block thread");
                throw new Exception("Failure: a Reseted AutoResetEvent didn't block thread");
            }

            Debug.WriteLine("Finally Setting the reseted AutoResetEvent");
            Waiter.are2.Set();
        }

    }
}
