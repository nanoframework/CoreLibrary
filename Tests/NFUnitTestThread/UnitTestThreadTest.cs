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
    public class ThreadTest
    {
        class Work
        {
            public static void DoWork()
            {
                Thread.Sleep(300);
                Debug.WriteLine("Static thread procedure DoWork.");
                Thread.Sleep(300);
            }
            public int m_data = 0;
            public Thread currThread;
            public void DoMoreWork()
            {
                Debug.WriteLine("Instance thread procedure DoMoreWork. Data= " + m_data);
                currThread = Thread.CurrentThread;
            }
            public static void DoWorkAbort()
            {
                Thread.Sleep(300);
                Debug.WriteLine("Static thread procedure DoWorkAbort.");
                Thread.Sleep(10000);
            }
            public Thread m_toJoin = null;
            public void DoWorkJoin()
            {
                m_toJoin.Join();
                Debug.WriteLine("Instance thread procedure DoWorkJoin.");
            }

            public static bool hasAborted = false;
            public static void DoWorkThreadAbortException()
            {
                while (!hasAborted)
                {
                    try
                    {
                        while (true) ;
                    }
                    catch (ThreadAbortException e)
                    {
                        hasAborted = true;
                        Debug.WriteLine("Thread State = " + Thread.CurrentThread.ThreadState);
                        Debug.WriteLine("verifying ThreadAbortException named " + e.ToString() + " is thrown");
                    }
                }
            }

            public static bool run = false;
            public void DoWorkThreadState()
            {
                while (run)
                    ;
            }
        }

        [TestMethod]
        public void Threading_Basic_Test1()
        {
            /// <summary>
            /// 1. Starts two threads
            /// 2. Verifies that they execute in a reasonable time
            /// </summary>
            ///
            Debug.WriteLine("Starting a thread without explicit declaration of ThreadStart Delegate");
            Debug.WriteLine("Starts two threads, waits for them to complete and passes, ");
            Debug.WriteLine("this may erroneously fail for extremely slow devices.");
            Debug.WriteLine("All other threading tests are dependent on this, if this fails, ");
            Debug.WriteLine("all other results are invalid.");

            Debug.WriteLine("Starting thread 1");
            Thread newThread1 = new Thread(Work.DoWork);
            newThread1.Start();

            Debug.WriteLine("Starting thread 2");
            Work w = new Work();
            w.m_data = 42;
            Thread newThread2 = new Thread(w.DoMoreWork);
            newThread2.Start();
            Thread.Sleep(1);

            Debug.WriteLine("Waiting for them to finish");
            int slept = 0;
            while ((newThread1.ThreadState != ThreadState.Stopped
                || newThread2.ThreadState != ThreadState.Stopped) && slept < 1000)
            {
                Thread.Sleep(100);
                slept += 100;
            }
            if (!(newThread1.ThreadState == ThreadState.Stopped &&
                newThread2.ThreadState == ThreadState.Stopped))
            {
                Debug.WriteLine("The threads took more than 1000msec to come to Stopped state");
                throw new Exception("The threads took more than 1000msec to come to Stopped state");
            }
        }

        [TestMethod]
        public void Threading_ThreadStart_Test2()
        {
            /// <summary>
            /// 1. Starts two threads  with ThreadStart Delegate,
            /// 2. Verifies that they execute in a reasonable time
            /// </summary>
            ///
            Debug.WriteLine("Starts two threads with ThreadStart Delegate,");
            Debug.WriteLine("waits for them to complete and passes, ");
            Debug.WriteLine("this may erroneously fail for extremely slow devices.");

            ThreadStart threadDelegate = new ThreadStart(Work.DoWork);
            Thread newThread1 = new Thread(threadDelegate);
            Debug.WriteLine("Starting thread 1");
            newThread1.Start();
            Work w = new Work();
            w.m_data = 42;
            threadDelegate = new ThreadStart(w.DoMoreWork);
            Thread newThread2 = new Thread(threadDelegate);
            Debug.WriteLine("Starting thread 2");
            newThread2.Start();
            Thread.Sleep(1);

            Debug.WriteLine("Waiting for them to complete");
            int slept = 0;
            while ((newThread1.ThreadState != ThreadState.Stopped
                || newThread2.ThreadState != ThreadState.Stopped) && slept < 1000)
            {
                Thread.Sleep(100);
                slept += 100;
            }
            if (!(newThread1.ThreadState == ThreadState.Stopped
                && newThread2.ThreadState == ThreadState.Stopped))
            {
                Debug.WriteLine("The threads took more than 1000msec to come to Stopped state");
                throw new Exception("The threads took more than 1000msec to come to Stopped state");
            }
        }

        [TestMethod]
        public void Threading_Abort_Test3()
        {
            /// <summary>
            /// 1. Starts two threads one of which has a very long execution time
            /// 2. Calls Abort on the long thread
            /// 3. Verifies that the aborted thread stops immediately
            /// 4. Verifies that the short thread finishes normally
            /// </summary>
            ///
            Debug.WriteLine("Starting long thread");
            Thread newThread1 = new Thread(Work.DoWorkAbort);
            newThread1.Start();

            Debug.WriteLine("Starting short thread");
            Work w = new Work();
            w.m_data = 42;
            Thread newThread2 = new Thread(w.DoMoreWork);
            newThread2.Start();
            Thread.Sleep(1);

            Debug.WriteLine("Aborting long thread and verifying it's Aborted");
            newThread1.Abort();
            ThreadState tState = newThread1.ThreadState;
            if (tState != ThreadState.Aborted
                        && newThread1.ThreadState != ThreadState.Stopped)
            {
                Debug.WriteLine("Expected long thread state Aborted/Stopped '" + ThreadState.Aborted +
                    "/" + ThreadState.Stopped + "' but got '" + tState + "'");
                throw new Exception("Expected long thread state Aborted/Stopped '" + ThreadState.Aborted +
                    "/" + ThreadState.Stopped + "' but got '" + tState + "'");
            }
            int slept = 0;

            Debug.WriteLine("Waiting for 1 or both threads to finish");
            while ((newThread1.ThreadState != ThreadState.Stopped ||
                newThread2.ThreadState != ThreadState.Stopped) && slept < 1000)
            {
                Thread.Sleep(100);
                slept += 100;
            }
            ThreadState tState1 = newThread1.ThreadState, tState2 = newThread2.ThreadState;
            if (tState1 != ThreadState.Stopped || tState2 != ThreadState.Stopped)
            {
                Debug.WriteLine("Expected both threads in Stopped state '" + ThreadState.Stopped +
                    "' but got Thread1 in '" + tState1 + "' and Thread2 in '" + tState2 + "'");
                throw new Exception("Expected both threads in Stopped state '" + ThreadState.Stopped +
                    "' but got Thread1 in '" + tState1 + "' and Thread2 in '" + tState2 + "'");
            }
        }

        [TestMethod]
        public void Threading_IsAlive_Test4()
        {
            /// <summary>
            /// 1. Starts two threads one of which has a very long execution time
            /// 2. Calls Abort() on the long thread
            /// 3. Verifies that the aborted thread stops immediately using the IsAlive Property
            /// 4. Verifies that the short thread finishes normally using the IsAlive Property
            /// </summary>
            ///

            Debug.WriteLine("Starts two threads, aborts one and verifies the IsAlive property, ");
            Debug.WriteLine("this may erroneously fail for extremely slow devices.");
            Debug.WriteLine("Starting long thread and verifying it's alive");
            Thread newThread1 = new Thread(Work.DoWorkAbort);
            newThread1.Start();

            Debug.WriteLine("Starting short thread");
            Work w = new Work();
            w.m_data = 42;
            Thread newThread2 = new Thread(w.DoMoreWork);
            newThread2.Start();
            if (!newThread1.IsAlive)
            {
                Debug.WriteLine("Long thread not alive");
                throw new Exception("Long thread not alive");
            }
            Debug.WriteLine("Aborting long thread, waiting and verifying both threads are dead");
            newThread1.Abort();
            int slept = 0;
            while ((newThread1.IsAlive || newThread2.IsAlive) && slept < 1000)
            {
                Thread.Sleep(100);
                slept += 100;
            }

            if (newThread1.IsAlive || newThread2.IsAlive)
            {
                Debug.WriteLine("Expected both threads dead but got long thread '" +
                    newThread1.ThreadState + "' and short thread '" + newThread2.ThreadState + "'");
                throw new Exception("Expected both threads dead but got long thread '" +
                    newThread1.ThreadState + "' and short thread '" + newThread2.ThreadState + "'");
            }
        }

        [TestMethod]
        public void Threading_Join_Test5()
        {
            /// <summary>
            /// 1. Starts a thread
            /// 2. Starts a second thread that Join()s the first
            /// 3. Verifies that they finish in a reasonable amount of time
            /// </summary>
            ///

            Debug.WriteLine("Starts two threads, the second thread Join()s the first");
            Debug.WriteLine("Verifies they finish in a reasonable amount of time");
            Debug.WriteLine("this may erroneously fail for extremely slow or fast devices.");

            Thread newThread1 = new Thread(Work.DoWork);
            newThread1.Start();

            Work w = new Work();
            w.m_data = 42;
            w.m_toJoin = newThread1;
            Thread newThread2 = new Thread(w.DoWorkJoin);
            newThread2.Start();
            Thread.Sleep(1);
            int slept = 0;
            while (newThread2.IsAlive && slept < 1000)
            {
                Thread.Sleep(100);
                slept += 100;
            }
            if (newThread1.IsAlive || newThread2.IsAlive)
            {
                Debug.WriteLine("Expected both threads dead but got thread1 '" + newThread1.ThreadState +
                    "' and thread2 '" + newThread2.ThreadState + "'");
                throw new Exception("Expected both threads dead but got thread1 '" + newThread1.ThreadState +
                    "' and thread2 '" + newThread2.ThreadState + "'");
            }
        }

        static class PriorityTest
        {
            static public ManualResetEvent loopSwitch = new ManualResetEvent(false);
            static public ManualResetEvent startSecond = new ManualResetEvent(false);
            static public ManualResetEvent keepAlive = new ManualResetEvent(false);
            static public long resultLowest = 0;
            static public long resultBelow = 0;
            static public long resultNorm = 0;
            static public long resultAbove = 0;
            static public long resultHighest = 0;
            static public long resultControl = 0;

            static public long resultNewLowest = 0;
            static public long resultNewBelow = 0;
            static public long resultNewNorm = 0;
            static public long resultNewAbove = 0;
            static public long resultNewHighest = 0;
            static public long resultNewControl = 0;

            static public void ThreadMethodLowest()
            {
                long threadCount = 0;
                long fakeCount = 0;

                while (!loopSwitch.WaitOne(0, false))
                {
                    threadCount++;
                }
                resultLowest = threadCount;
                startSecond.WaitOne();
                while (!keepAlive.WaitOne(0, false))
                {
                    fakeCount++;
                }
                resultNewLowest = fakeCount;
            }
            static public void ThreadMethodBelow()
            {
                long threadCount = 0;
                long fakeCount = 0;

                while (!loopSwitch.WaitOne(0, false))
                {
                    threadCount++;
                }
                resultBelow = threadCount;
                startSecond.WaitOne();
                while (!keepAlive.WaitOne(0, false))
                {
                    fakeCount++;
                }
                resultNewBelow = fakeCount;
            }
            static public void ThreadMethodNorm()
            {
                long threadCount = 0;
                long fakeCount = 0;

                while (!loopSwitch.WaitOne(0, false))
                {
                    threadCount++;
                }
                resultNorm = threadCount;
                startSecond.WaitOne();
                while (!keepAlive.WaitOne(0, false))
                {
                    fakeCount++;
                }
                resultNewNorm = fakeCount;
            }
            static public void ThreadMethodAbove()
            {
                long threadCount = 0;
                long fakeCount = 0;

                while (!loopSwitch.WaitOne(0, false))
                {
                    threadCount++;
                }
                resultAbove = threadCount;
                startSecond.WaitOne();
                while (!keepAlive.WaitOne(0, false))
                {
                    fakeCount++;
                }
                resultNewAbove = fakeCount;
            }
            static public void ThreadMethodHighest()
            {
                long threadCount = 0;
                long fakeCount = 0;

                while (!loopSwitch.WaitOne(0, false))
                {
                    threadCount++;
                }
                resultHighest = threadCount;
                startSecond.WaitOne();
                while (!keepAlive.WaitOne(0, false))
                {
                    fakeCount++;
                }
                resultNewHighest = fakeCount;
            }
            static public void ThreadMethodControl()
            {
                long threadCount = 0;
                long fakeCount = 0;

                while (!loopSwitch.WaitOne(0, false))
                {
                    threadCount++;
                }
                resultControl = threadCount;
                startSecond.WaitOne();
                while (!keepAlive.WaitOne(0, false))
                {
                    fakeCount++;
                }
                resultNewControl = fakeCount;
            }
        }

        static Thread threadLowest = new Thread(PriorityTest.ThreadMethodLowest);
        static Thread threadBelow = new Thread(PriorityTest.ThreadMethodBelow);
        static Thread threadNorm = new Thread(PriorityTest.ThreadMethodNorm);
        static Thread threadAbove = new Thread(PriorityTest.ThreadMethodAbove);
        static Thread threadHighest = new Thread(PriorityTest.ThreadMethodHighest);
        static Thread threadControl = new Thread(PriorityTest.ThreadMethodControl);

        public double Tolerance(long level1, long level2)
        {
            long temp = (level1 - level2);
            temp = temp < 0 ? -temp : temp;

            return (level2 == 0) ? 100.0 : (temp * 100) / level2;
        }

        [TestMethod]
        public void Threading_Priority_Test6()
        {
            /// <summary>
            /// 1. Starts five threads of increasing priority
            /// 2. Waits for them to complete work
            /// 3. Verifies that they get increasing amounts of attention
            /// </summary>
            ///

            const double acceptedTolerance = 5.0; // 5% tolerance

            Debug.WriteLine("Starts five threads of increasing priority and a control thread, priority not set ");
            Debug.WriteLine("verifies that they get increasing amounts of attention");

            threadLowest.Priority = ThreadPriority.Lowest;
            threadBelow.Priority = ThreadPriority.BelowNormal;
            threadNorm.Priority = ThreadPriority.Normal;
            threadAbove.Priority = ThreadPriority.AboveNormal;
            threadHighest.Priority = ThreadPriority.Highest;

            Debug.WriteLine("Starting Threads");
            threadHighest.Start();
            threadAbove.Start();
            threadNorm.Start();
            threadBelow.Start();
            threadLowest.Start();
            threadControl.Start();

            Debug.WriteLine("Allow counting for 1 seconds.");
            Thread.Sleep(1000);
            PriorityTest.loopSwitch.Set();
            Thread.Sleep(1000);

            Debug.WriteLine("Lowest         " + PriorityTest.resultLowest);
            Debug.WriteLine("Below          " + PriorityTest.resultBelow);
            Debug.WriteLine("Normal         " + PriorityTest.resultNorm);
            Debug.WriteLine("Above          " + PriorityTest.resultAbove);
            Debug.WriteLine("Highest        " + PriorityTest.resultHighest);
            Debug.WriteLine("Control Thread " + PriorityTest.resultControl);

            Debug.WriteLine("Verifies that each thread recieves attention less than or equal");
            Debug.WriteLine("to higher priority threads.");
            Debug.WriteLine("Accepted tolerance : " + acceptedTolerance + "%");

            PriorityTest.startSecond.Set();
            PriorityTest.keepAlive.Set();

            if ((PriorityTest.resultLowest <= 0) ||
                (Tolerance(2 * PriorityTest.resultLowest, PriorityTest.resultBelow) > acceptedTolerance) ||
                (Tolerance(2 * PriorityTest.resultBelow, PriorityTest.resultNorm) > acceptedTolerance) ||
                (Tolerance(2 * PriorityTest.resultNorm, PriorityTest.resultAbove) > acceptedTolerance) ||
                (Tolerance(2 * PriorityTest.resultAbove, PriorityTest.resultHighest) > acceptedTolerance) ||
                (Tolerance(PriorityTest.resultNorm, PriorityTest.resultControl) > acceptedTolerance))
            {
                Debug.WriteLine("Lowest thread should execute at least once, got " + PriorityTest.resultLowest);
                Debug.WriteLine("Deviation b/n 2*Lowest and Below " + Tolerance(2 * PriorityTest.resultLowest, PriorityTest.resultBelow));
                Debug.WriteLine("Deviation b/n 2*Below and Normal " + Tolerance(2 * PriorityTest.resultBelow, PriorityTest.resultNorm));
                Debug.WriteLine("Deviation b/n 2*Normal and Above " + Tolerance(2 * PriorityTest.resultNorm, PriorityTest.resultAbove));
                Debug.WriteLine("Deviation b/n 2*Above and Highest " + Tolerance(2 * PriorityTest.resultAbove, PriorityTest.resultHighest));
                Debug.WriteLine("Deviation b/n Normal and Control " + Tolerance(PriorityTest.resultNorm, PriorityTest.resultControl));
                throw new Exception("Tolerance not met");
            }
        }

        [TestMethod]
        public void Threading_Suspend_Resume_Test7()
        {
            /// <summary>
            /// 1. Starts two threads
            /// 2. Suspends them
            /// 3. Verifies that they do not terminate while suspended
            /// 4. Resumes them
            /// 5. Verifies that they finish in a reasonable amount of time
            /// </summary>
            ///
            Debug.WriteLine("Starts two threads, suspends and resumes them, ");
            Debug.WriteLine("this may erroneously fail for extremely slow devices.");

            Thread newThread1 = new Thread(Work.DoWork);
            newThread1.Start();

            Work w = new Work();
            w.m_data = 42;
            w.m_toJoin = newThread1;
            Thread newThread2 = new Thread(w.DoWorkJoin);
            newThread2.Start();
            Thread.Sleep(1);

            newThread2.Suspend();
            newThread1.Suspend();
            ThreadState tState = newThread2.ThreadState;
            if ((int)tState != 96)
            {
                Debug.WriteLine("expected Thread2 in WaitSleepJoin + Suspended ('96') but got '" +
                    tState + "'");
                throw new Exception("expected Thread2 in WaitSleepJoin + Suspended ('96') but got '" +
                    tState + "'");

            }
            newThread2.Resume();
            tState = newThread1.ThreadState;
            if ((int)tState != 96)
            {
                Debug.WriteLine("expected Thread1 in WaitSleepJoin + Suspended ('96') but got '" +
                   tState + "'");
                throw new Exception("expected Thread1 in WaitSleepJoin + Suspended ('96') but got '" +
                   tState + "'");
            }
            newThread1.Resume();

            int slept = 0;
            while ((newThread1.IsAlive || newThread2.IsAlive) && slept < 1000)
            {
                Thread.Sleep(100);
                slept += 100;
            }
            if (newThread1.IsAlive || newThread2.IsAlive)
            {
                Debug.WriteLine("expected both threads dead after 1000msec but got thread1 '" +
                    newThread1.ThreadState + "' and thread2 '" + newThread2.ThreadState + "'");
                throw new Exception("expected both threads dead after 1000msec but got thread1 '" +
                    newThread1.ThreadState + "' and thread2 '" + newThread2.ThreadState + "'");
            }
        }

        public static bool sleptCorrect(int Msec)
        {
            TimeSpan zeroDuration = new TimeSpan(0);            
            const long TicksPerMillisecond = TimeSpan.TicksPerMillisecond;
            long startTime = DateTime.UtcNow.Ticks;

            Thread.Sleep(Msec);
            long sleptSpan = DateTime.UtcNow.Ticks - startTime;
            if ((sleptSpan / TicksPerMillisecond) < Msec)
            {
                Debug.WriteLine("Expected the thread slept for at least " + Msec + " Msec. but slept only for "
                    + (sleptSpan / TicksPerMillisecond) + " Msec");
                return false;
            }

            Debug.WriteLine(Msec + " Msec sleep success, slept for "
                + (sleptSpan / TicksPerMillisecond) + " Msec");
            return true;
        }

        [TestMethod]
        public void Threading_SleepApprox_Test8()
        {
            /// <summary>
            /// 1. Sleeps the main thread for increasing amounts of time
            /// 2. Verifies the thread sleeps at least for the time requested         
            /// </summary>
            ///          
            Debug.WriteLine("This test verifies the thread slept at least for the amount of time required");
            int[] sleepTime = new int[] { 10, 100, 1000, 10000, 60000 };
            for (int i = 0; i < sleepTime.Length; i++)
            {
                if (!sleptCorrect(sleepTime[i]))
                {
                    throw new Exception("Thread didn't sleep enough");
                }
            }
        }

        [TestMethod]
        public void Threading_Suspend_Suspend_Test9()
        {
            /// <summary>
            /// 1. Starts two threads and suspends the first thread twice
            /// 2. Gets the state of the 1st thread
            /// 3. Resumes the 1st thread 
            /// 4. Verifies that calling Suspend for the 2nd time has no effect
            /// </summary>
            ///

            Debug.WriteLine("Starts two threads and suspends the first thread twice");
            Debug.WriteLine("Gets the state of the 1st thread");
            Debug.WriteLine("Resumes the 1st thread ");
            Debug.WriteLine("Verifies that calling Suspend for the 2nd time has no effect");
            Work.run = true;
            Work w1 = new Work();
            Thread newThread1 = new Thread(w1.DoWorkThreadState);
            newThread1.Start();
            newThread1.Suspend();
            newThread1.Suspend();

            Work w2 = new Work();
            w2.m_data = 42;
            Thread newThread2 = new Thread(w2.DoMoreWork);
            newThread2.Start();

            ThreadState tState = newThread1.ThreadState;
            newThread1.Resume();
            newThread1.Abort();
            if (tState != ThreadState.Suspended)
            {
                Debug.WriteLine("Suspending twice, expected thread state Suspended(" +
                    ThreadState.Suspended + ") but got '" + tState + "'");
                throw new Exception("Suspending twice, expected thread state Suspended(" +
                    ThreadState.Suspended + ") but got '" + tState + "'");

            }
        }

        [TestMethod]
        public void Threading_ThreadState_Unstarted_Running_WaitSleepJoin_Test10()
        {
            /// <summary>
            /// 1. Creates a thread and verifies its state is Unstarted
            /// 2. Starts a thread and verifies its state is Running
            /// 3. Sleeps a thread and verifies its state is WaitSleepJoin
            /// 4. Joins a thread and verifies its state is WaitSleepJoin
            /// </summary>
            ///

            Debug.WriteLine("Creating a thread and verifing its state is Unstarted");
            Thread newThread1 = new Thread(Work.DoWork);
            ThreadState tState = newThread1.ThreadState;
            if (tState != ThreadState.Unstarted)
            {
                Debug.WriteLine("Expected thread state Unstarted(" + ThreadState.Unstarted +
                    ") but got '" + tState + "'");
                throw new Exception("Expected thread state Unstarted(" + ThreadState.Unstarted +
                    ") but got '" + tState + "'");
            }

            Debug.WriteLine("Verifying the state of the current thread is Running");
            newThread1.Start();
            tState = Thread.CurrentThread.ThreadState;
            if (tState != ThreadState.Running)
            {
                Debug.WriteLine("expected the state of current thread Running(" + ThreadState.Running +
                    ") but got '" + tState + "'");
                throw new Exception("expected the state of current thread Running(" + ThreadState.Running +
                    ") but got '" + tState + "'");
            }

            Debug.WriteLine("Sleeping a thread and verifing its state is WaitSleepJoin");
            Thread.Sleep(100);
            tState = newThread1.ThreadState;
            if (tState != ThreadState.WaitSleepJoin)
            {
                Debug.WriteLine("expected thread1 in WaitSleepJoin(" + ThreadState.WaitSleepJoin +
                    ") but got '" + newThread1.ThreadState + "'");
                throw new Exception("expected thread1 in WaitSleepJoin(" + ThreadState.WaitSleepJoin +
                    ") but got '" + newThread1.ThreadState + "'");
            }
            Debug.WriteLine(" Joining a thread and verifing its state is WaitSleepJoin");
            Work w = new Work();
            Thread newThread3 = new Thread(Work.DoWork);
            w.m_toJoin = newThread3;
            Thread newThread2 = new Thread(w.DoWorkJoin);
            newThread3.Start();
            newThread2.Start();
            Thread.Sleep(0);
            tState = newThread2.ThreadState;
            if (tState != ThreadState.WaitSleepJoin)
            {
                Debug.WriteLine("expected a joined sleeping thread in WaitSleepJoin state(" +
                    ThreadState.WaitSleepJoin + ") but got '" + tState + "'");
                throw new Exception("expected a joined sleeping thread in WaitSleepJoin state(" +
                    ThreadState.WaitSleepJoin + ") but got '" + tState + "'");
            }
        }

        [TestMethod]
        public void Threading_ThreadState_Suspend_Test11()
        {
            /// <summary>
            /// 1. Starts a thread and Suspends it immediately
            /// 2. Starts a second thread
            /// 3. Gets the state of the 1st thread and Resumes it
            /// 4. Verifies that the state of the 1st thread was Suspended
            /// </summary>
            ///

            Debug.WriteLine("Starts a thread and Suspends it immediately");
            Debug.WriteLine("Starts a second thread");
            Debug.WriteLine("Gets the state of the 1st thread and Resumes it");
            Debug.WriteLine("Verifies that the state of the 1st thread was Suspended");
            Work.run = true;
            Work w1 = new Work();
            Thread newThread1 = new Thread(w1.DoWorkThreadState);
            newThread1.Start();
            newThread1.Suspend();

            Work w2 = new Work();
            w2.m_data = 42;
            Thread newThread2 = new Thread(w2.DoMoreWork);
            newThread2.Start();

            ThreadState tState = newThread1.ThreadState;
            newThread1.Resume();
            newThread1.Abort();
            if (tState != ThreadState.Suspended)
            {
                Debug.WriteLine("expected state Suspended(" + ThreadState.Suspended + ") but got '" + tState + "'");
                throw new Exception("expected state Suspended(" + ThreadState.Suspended + ") but got '" + tState + "'");
            }
        }

        [TestMethod]
        public void Threading_ThreadState_SuspendRequested_Test12()
        {
            /// <summary>
            /// 1. Starts 10 threads and Suspends all of them 
            /// 2. Immediately verifies the state is SuspendRequested
            /// 3. It's an approximate test
            /// </summary>
            ///

            Debug.WriteLine("Starting 10 Threads");
            Thread[] newThread = new Thread[10];
            Work[] w = new Work[10];
            int i = 0, k = 0;
            Work.run = true;
            while (i < 10)
            {
                w[i] = new Work();
                newThread[i] = new Thread(w[i].DoWorkThreadState);
                newThread[i].Start();
                i++;
            }
            Debug.WriteLine("Suspending the Threads and checking for SuspendRequested");
            Debug.WriteLine("At least one of the threads should be in SuspendRequested");
            while (k < 10)
            {
                while (newThread[k].ThreadState != ThreadState.Suspended)
                {
                    newThread[k].Suspend();
                    if (newThread[k].ThreadState == ThreadState.SuspendRequested)
                    {
                        throw new Exception("Thread not properly susended");
                        break;
                    }
                }
                newThread[k].Resume();
                k++;
            }
            k--;
            while (k >= 0)
            {
                newThread[k].Abort();
                k--;
            }
            Work.run = false;
        }

        [TestMethod]
        public void Threading_ThreadState_Abort_Stopped_Test13()
        {
            /// <summary>
            /// 1. Starts a thread and Aborts it immediately
            /// 2. Starts a second thread
            /// 3. Gets the state of the 1st thread thread
            /// 4. Verifies the state of the 1st thread is Aborted
            /// </summary>
            ///

            Debug.WriteLine("Starts a thread and Aborts it immediately");
            Debug.WriteLine("Starts a second thread");
            Debug.WriteLine("Gets the state of the 1st thread");
            Debug.WriteLine("Verifies the state of the 1st thread is Aborted");

            DateTime t1, t2;
            TimeSpan period;
            Thread newThread1 = new Thread(Work.DoWork);
            newThread1.Start();
            newThread1.Abort();
            t1 = DateTime.UtcNow;

            Work w = new Work();
            w.m_data = 42;
            Thread newThread2 = new Thread(w.DoMoreWork);
            newThread2.Start();
            Debug.WriteLine("Pass Requires either of the next two compared values to be equal");
            Debug.WriteLine(newThread1.ThreadState + " Compare to " + ThreadState.Aborted);
            Debug.WriteLine(newThread1.ThreadState + " Compare to " + ThreadState.Stopped);
            t2 = DateTime.UtcNow;
            ThreadState tState = newThread1.ThreadState;
            period = t2 - t1;
            Debug.WriteLine("Waited for at least " + period.Milliseconds.ToString() + " before checking the state");
            if (tState != ThreadState.Aborted && tState != ThreadState.Stopped)
            {
                Debug.WriteLine("expected the thread to be in Aborted/Stopped(" + ThreadState.Aborted +
                    "/" + ThreadState.Stopped + ") state but got '" + tState + "'");
                throw new Exception("expected the thread to be in Aborted/Stopped(" + ThreadState.Aborted +
                    "/" + ThreadState.Stopped + ") state but got '" + tState + "'");
            }
        }

        [TestMethod]
        public void Threading_Abort_ThreadStateException_Test14()
        {
            /// <summary>
            /// 1. Creates a thread, Aborts it without starting it
            /// 2. Verifies Exception is thrown.
            /// </summary>
            ///

            Debug.WriteLine("The type of exception thrown should be ThreadStateException");
            Thread newThread1 = new Thread(Work.DoWork);
            try
            {
                Debug.WriteLine("Aborting a thread not started should throw exception");
                newThread1.Abort();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Correctly threw " + e.ToString() + " in an attempt to Abort Unstarted thread");
                return;
            }

            throw new Exception("Not Correctly threw Exception in an attempt to Abort Unstarted thread");
        }

        [TestMethod]
        public void Threading_Abort_ThreadAbortException_Test15()
        {
            /// <summary>
            /// 1. starts a thread and Aborts it immediately
            /// 2. verifies ThreadAbortException is thrown
            /// </summary>
            ///

            Work.hasAborted = false;
            Thread newThread1 = new Thread(Work.DoWorkThreadAbortException);
            Debug.WriteLine("starting a thread and Aborting it immediately");
            newThread1.Start();
            Thread.Sleep(50);
            newThread1.Abort();
            Thread.Sleep(500);
            Debug.WriteLine("Verifying");
            if (!Work.hasAborted)
            {
                Debug.WriteLine("Aborting a Thread didn't throw ThreadAbortException");
                throw new Exception("Aborting a Thread didn't throw ThreadAbortException");
            }
        }

        [TestMethod]
        public void Threading_Join_Timeout_Test16()
        {
            /// <summary>
            /// 1. Starts two threads
            /// 2. both threads joins the main thread using Join(int millisecondsTimeout) Join(TimeSpan timeout)
            /// 3. Verifies the calling thread is blocked until the specified amount of time elapses
            /// </summary>
            ///

            Debug.WriteLine("Starts two threads");
            Debug.WriteLine("Both threads Joins the main thread");
            Debug.WriteLine("verify calling thread (main thread) is blocked for millisecondsTimeout");
            Work.run = true;
            Work w = new Work();

            Thread newThread1 = new Thread(w.DoWorkThreadState);
            newThread1.Start();
            Thread.Sleep(50);
            DateTime d1 = DateTime.UtcNow;
            newThread1.Join(250);
            DateTime d2 = DateTime.UtcNow;
            TimeSpan duration1 = d2 - d1;
            newThread1.Abort();
            Thread newThread2 = new Thread(w.DoWorkThreadState);
            newThread2.Start();
            Thread.Sleep(50);
            DateTime d3 = DateTime.UtcNow;
            newThread1.Join(new TimeSpan(0, 0, 0, 0, 250));
            DateTime d4 = DateTime.UtcNow;
            TimeSpan duration2 = d4 - d3;
            newThread2.Abort();
            int result1 = duration1.CompareTo(new TimeSpan(0, 0, 0, 0, 250));
            int result2 = duration1.CompareTo(new TimeSpan(0, 0, 0, 0, 250));
            if (result1 < 0 || result2 < 0)
            {
                Debug.WriteLine("expected the main thread to be blocked at least for '250' msec. but was blocked for '" +
                    duration1.ToString() + "' by Thread1 and '" + duration2.ToString() + "' by Thread2");
                throw new Exception("expected the main thread to be blocked at least for '250' msec. but was blocked for '" +
                    duration1.ToString() + "' by Thread1 and '" + duration2.ToString() + "' by Thread2");
            }
        }

        [TestMethod]
        public void Threading_Join_ArgumentOutOfRangeException_Test17()
        {
            /// <summary>
            /// 1. Start a thread that Join(TimeSpan timeout)s passing negative value 
            /// 2. Verify ArgumentOutOfRangeException is thrown
            /// </summary>

            Thread newThread1 = new Thread(Work.DoWork);
            newThread1.Start();
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { newThread1.Join(-77); });
        }

        [TestMethod]
        public void Threading_Sleep_ArgumentOutOfRangeException_Test18()
        {
            /// <summary>
            /// 1. Sleep a thread passing a negative argument
            /// 2. Verify ArgumentOutOfRangeException exception is thrown
            /// </summary>
            /// 

            Debug.WriteLine("Verify ArgumentOutOfRangeException exception is thrown");
            Debug.WriteLine("Why not for -1 ?");
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { Thread.Sleep(-2); });
        }

        [TestMethod]
        public void Threading_Join_ThreadStateException_Test19()
        {
            /// <summary>
            /// 1. Join a thread that is not Started 
            /// 2. verify ThreadStateException is thrown
            /// </summary>
            /// 

            Debug.WriteLine("The type of exception thrown should be ThreadStateException");
            Thread newThread1 = new Thread(Work.DoWork);
            Assert.Throws(typeof(Exception), () => { newThread1.Join(); });
        }

        [TestMethod]
        public void Threading_Suspend_ThreadStateException_Test20()
        {
            /// <summary>
            /// 1. Suspend a thread that is not Started
            /// 2. verify ThreadStateException is thrown
            /// </summary>
            /// 

            Debug.WriteLine("The type of exception thrown should be ThreadStateException");
            Thread newThread1 = new Thread(Work.DoWork);
            Assert.Throws(typeof(Exception), () => { newThread1.Suspend(); });
        }

        [TestMethod]
        public void Threading_Resume_ThreadStateException_Test21()
        {

            /// <summary>
            /// 1. Resume a thread that is not Started
            /// 2. verify ThreadStateException is thrown
            /// </summary>
            ///

            Debug.WriteLine("The type of exception thrown should be ThreadStateException");
            Thread newThread1 = new Thread(Work.DoWork);
            Assert.Throws(typeof(Exception), () => { newThread1.Resume(); });
        }

        static bool sleepZero = false;
        static bool sleepResult = false;
        public static void SleepTest()
        {
            while (sleepZero)
                sleepResult = true;
        }

        [TestMethod]
        public void Threading_Sleep_Zero_Test22()
        {
            /// <summary>
            /// 1. Start a thread, 
            /// 2. Sleep the main thread for 0 (zero) milliseconds and 
            /// 3. verify that thread rescheduling is taken place right away
            /// </summary>
            /// 

            Debug.WriteLine("Starting a thread , Thread.Sleep(0) on the main thread");
            Debug.WriteLine("Verify the thread is immediately scheduled to execute");
            sleepZero = true;
            Thread t1 = new Thread(new ThreadStart(SleepTest));
            t1.Start();
            Thread.Sleep(50);
            sleepResult = false;
            Thread.Sleep(0);
            if (!sleepResult)
            {
                Debug.WriteLine("Test Thread.Sleep(0) Failed");
                throw new Exception("Test Thread.Sleep(0) Failed");
            }
            else
            {
                Debug.WriteLine("Test Thread.Sleep(0) Successful");
            }
            sleepZero = false;
        }

        [TestMethod]
        public void Threading_Priority_Change_Test23()
        {
            /// <summary>
            /// 1. Starts five threads of increasing priority
            /// 2. Change their priorities to different levels
            /// 3. Verifies that they get increasing amounts of attention
            /// 4. based on their new priority level.
            /// </summary>
            ///

            const double acceptedTolerance = 5.0; // 5% tolerance
            Debug.WriteLine("Starts five threads of increasing priority and ");
            Debug.WriteLine("a control thread priority not set ");
            Debug.WriteLine("verifies that they get increasing amounts of attention");

            PriorityTest.loopSwitch.Reset();
            PriorityTest.startSecond.Reset();
            PriorityTest.keepAlive.Reset();

            Thread threadLowest = new Thread(PriorityTest.ThreadMethodLowest);
            Thread threadBelow = new Thread(PriorityTest.ThreadMethodBelow);
            Thread threadNorm = new Thread(PriorityTest.ThreadMethodNorm);
            Thread threadAbove = new Thread(PriorityTest.ThreadMethodAbove);
            Thread threadHighest = new Thread(PriorityTest.ThreadMethodHighest);
            Thread threadControl = new Thread(PriorityTest.ThreadMethodControl);

            threadLowest.Priority = ThreadPriority.Lowest;
            threadBelow.Priority = ThreadPriority.BelowNormal;
            threadNorm.Priority = ThreadPriority.Normal;
            threadAbove.Priority = ThreadPriority.AboveNormal;
            threadHighest.Priority = ThreadPriority.Highest;

            Debug.WriteLine("Starting Threads");
            threadHighest.Start();
            threadAbove.Start();
            threadNorm.Start();
            threadBelow.Start();
            threadLowest.Start();
            threadControl.Start();

            Debug.WriteLine("Allow counting for 1 seconds.");
            Thread.Sleep(1000);
            PriorityTest.loopSwitch.Set();
            Thread.Sleep(1000);

            Debug.WriteLine("Lowest         " + PriorityTest.resultLowest);
            Debug.WriteLine("Below          " + PriorityTest.resultBelow);
            Debug.WriteLine("Normal         " + PriorityTest.resultNorm);
            Debug.WriteLine("Above          " + PriorityTest.resultAbove);
            Debug.WriteLine("Highest        " + PriorityTest.resultHighest);
            Debug.WriteLine("Control Thread " + PriorityTest.resultControl);

            threadLowest.Priority = ThreadPriority.BelowNormal;
            threadBelow.Priority = ThreadPriority.Normal;
            threadNorm.Priority = ThreadPriority.AboveNormal;
            threadAbove.Priority = ThreadPriority.Highest;
            threadHighest.Priority = ThreadPriority.Lowest;
            Debug.WriteLine("Thread Priorities of each thread changed");
            Debug.WriteLine("Allow counting for 1 seconds.");

            PriorityTest.startSecond.Set();
            Thread.Sleep(1000);
            PriorityTest.keepAlive.Set();
            Thread.Sleep(1000);

            Debug.WriteLine("Lowest - > Below   " + PriorityTest.resultNewLowest);
            Debug.WriteLine("Below - > Normal   " + PriorityTest.resultNewBelow);
            Debug.WriteLine("Normal - > Above   " + PriorityTest.resultNewNorm);
            Debug.WriteLine("Above - > Highest  " + PriorityTest.resultNewAbove);
            Debug.WriteLine("Highest - > Lowest " + PriorityTest.resultNewHighest);
            Debug.WriteLine("Control Thread     " + PriorityTest.resultNewControl);

            Debug.WriteLine("Verifies that each thread recieves attention less than or equal");
            Debug.WriteLine("to higher priority threads based on the newly assigned priorities.");
            Debug.WriteLine("Accepted Tolerance : " + acceptedTolerance + "%");

            if ((PriorityTest.resultNewHighest <= 0) ||
                (Tolerance(2 * PriorityTest.resultNewHighest, PriorityTest.resultNewLowest) > acceptedTolerance) ||
                (Tolerance(2 * PriorityTest.resultNewLowest, PriorityTest.resultNewBelow) > acceptedTolerance) ||
                (Tolerance(2 * PriorityTest.resultNewBelow, PriorityTest.resultNewNorm) > acceptedTolerance) ||
                (Tolerance(2 * PriorityTest.resultNewNorm, PriorityTest.resultNewAbove) > acceptedTolerance) ||
                (Tolerance(PriorityTest.resultNewBelow, PriorityTest.resultNewControl) > acceptedTolerance))
            {
                Debug.WriteLine("NewHighest thread should execute at least once, got " + PriorityTest.resultNewHighest);
                Debug.WriteLine("Deviation b/n 2*NewHighest and NewLowest " + Tolerance(2 * PriorityTest.resultNewHighest, PriorityTest.resultNewLowest));
                Debug.WriteLine("Deviation b/n 2*NewLowest and NewBelow " + Tolerance(2 * PriorityTest.resultNewLowest, PriorityTest.resultNewBelow));
                Debug.WriteLine("Deviation b/n 2*NewBelow and NewNorm " + Tolerance(2 * PriorityTest.resultNewBelow, PriorityTest.resultNewNorm));
                Debug.WriteLine("Deviation b/n 2*NewNorm and NewAbove " + Tolerance(2 * PriorityTest.resultNewNorm, PriorityTest.resultNewAbove));
                Debug.WriteLine("Deviation b/n NewBelow and Control " + Tolerance(PriorityTest.resultNewBelow, PriorityTest.resultNewControl));
                throw new Exception("Failed to change priority");
            }
        }

        [TestMethod]
        public void Threading_CurrentThread_Test24()
        {
            /// <summary>
            /// 1. Start a thread
            /// 2. Verify Thread.CurrentThread gives the thread itself
            /// </summary>
            /// 

            Debug.WriteLine("Starting the Thread");
            Work w = new Work();
            w.m_data = 7;
            Thread newThread1 = new Thread(w.DoMoreWork);
            newThread1.Start();
            Thread.Sleep(1);
            Debug.WriteLine("verifying Thread.CurrentThread gives the Thread itself");
            if (!newThread1.Equals(w.currThread))
            {
                Debug.WriteLine("Comparing the Thread with its own (Thread.Equals(Thread.CurrentThread)) failed");
                throw new Exception("Comparing the Thread with its own (Thread.Equals(Thread.CurrentThread)) failed");
            }
        }

        //[TestMethod]
        //public void Threading_GetDomain_Test25()
        //{
        //    /// <summary>
        //    /// 1. Get the application domain in which the current thread is running
        //    /// 2. Verify it's the current domain
        //    /// </summary>
        //    /// 

        //    Debug.WriteLine("Getting the AppDomain");
        //    AppDomain domain = Thread.GetDomain();
        //    Debug.WriteLine("Verifying the domain");

        //    if (!domain.Equals(AppDomain.CurrentDomain))
        //    {
        //        Debug.WriteLine("Thread.GetDomain().Equals(AppDomain.CurrentDomain) Failed");
        //        throw new Exception("Thread.GetDomain().Equals(AppDomain.CurrentDomain) Failed");
        //    }
        //}

        [TestMethod]
        public void Threading_Thread_CurrentThread_Suspend_Test26()
        {
            int count = 0;

            Thread newThread = new Thread(new ThreadStart(
                delegate
                {
                    count += 2;
                    Debug.WriteLine("2) Worker thread started...");
                    Debug.WriteLine("Suspending Worker thread...");
                    Thread.CurrentThread.Suspend();
                    Debug.WriteLine("4) Worker thread resumed...");
                    count += 5;
                }
                ));

            if (count != 0)
            {
                Debug.WriteLine("Failure verifying counter reset to zero before starting the thread");
                throw new Exception("Failure verifying counter reset to zero before starting the thread");
            }
            Debug.WriteLine("1) Starting worker...");
            newThread.Start();
            Thread.Sleep(3000);
            if (count != 2)
            {
                Debug.WriteLine("Failure : Worker Thread is not Suspended !");
                throw new Exception("Failure : Worker Thread is not Suspended !");
            }
            Debug.WriteLine("3) Wake up suspended thread...");
            newThread.Resume();
            Thread.Sleep(3000);
            Debug.WriteLine("5) Main thread finished");
            if (count != 7)
            {
                Debug.WriteLine("Worker thread not finished for 3000msec after resumed");
                throw new Exception("Worker thread not finished for 3000msec after resumed");
            }
        }

    }
}
