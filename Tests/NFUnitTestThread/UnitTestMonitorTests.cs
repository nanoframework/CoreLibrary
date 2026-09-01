// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using nanoFramework.TestFramework;

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
                OutputHelper.WriteLine("Attempting to start inc thread " + i);
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
                OutputHelper.WriteLine("Attempting to start dec thread " + i);
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
                OutputHelper.WriteLine("Attempting to start inc2 thread " + i);
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

            // Starts several async threads that Enter and Exit critical sections.
            // This may erroneously pass.
            // This may erroneously fail for extremely slow devices.
            // Starting the 4 threads
            Thread incThread = new Thread(MonitoredThreadIncrementorStarter);
            incThread.Start();
            Thread decThread = new Thread(MonitoredThreadDecrementorStarter);
            decThread.Start();
            Thread inc2Thread = new Thread(MonitoredThreadIncrementor2Starter);
            inc2Thread.Start();
            Thread lastThread = new Thread(MonitoredThreadDecrementor);
            lastThread.Start();
            Thread.Sleep(1);
            // Joining All threads to main thread
            incThread.Join();
            decThread.Join();
            inc2Thread.Join();
            lastThread.Join();
            // Verifying all operations completed successfully
            if (monCount != 4)
            {
                // expected final result = '4' but got '" + monCount + "'
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
            // Verify SynchronizationLockException exception is thrown
            // Calling Monitor.Exit without first calling Monitor.Enter should throw an exception
            Assert.ThrowsException(typeof(Exception), () => { Monitor.Exit(locker1); });
        }

        [TestMethod]
        public void Monitor3_Enter_ArgumentNullException_Test()
        {
            /// <summary>
            /// 1. Call Monitor.Enter passing null reference obj parameter
            /// 2. verify ArgumentNullException exception is thrown
            /// </summary>
            ///

            // verify ArgumentNullException exception is thrown 
            // Calling Monitor.Enter passing null reference parameter should throw exception
            Assert.ThrowsException(typeof(ArgumentNullException), () => { Monitor.Enter(null); });

        }

        [TestMethod]
        public void Monitor4_Exit_ArgumentNullException_Test()
        {
            /// <summary>
            /// 1. Call Monitor.Exit passing null reference obj parameter
            /// 2. verify ArgumentNullException exception is thrown
            /// </summary>
            ///
            // verify ArgumentNullException exception is thrown 
            // Calling Monitor.Exit passing 'null' reference parameter should throw exception
            Assert.ThrowsException(typeof(ArgumentNullException), () => { Monitor.Exit(null); });
        }

        static ManualResetEvent flag = new ManualResetEvent(false);
        static bool lockResult = false;
        static object locker2 = new object();
        static void RepeatedLock()
        {
            OutputHelper.WriteLine("T1 = " + DateTime.UtcNow);
            Monitor.Enter(locker2);
            try
            {
                lockResult = !lockResult;
                // I have the lock
                Nest();
                // I still have the lock
            }
            finally
            {
                if (flag.WaitOne(500, false))
                {
                    Monitor.Exit(locker2);
                    // Here the lock is released
                }
            }
            OutputHelper.WriteLine("T4 = " + DateTime.UtcNow);
        }

        static void Nest()
        {
            OutputHelper.WriteLine("T2 = " + DateTime.UtcNow);
            Monitor.Enter(locker2);
            try
            {
                // Inside Lock
            }
            finally
            {
                Monitor.Exit(locker2);
                // Released the lock? Not quite!
            }
            OutputHelper.WriteLine("T3 = " + DateTime.UtcNow);
        }

        [TestMethod]
        public void Monitor5_Repeatedly_Lock_Unlock_Test()
        {
            // Starts two Threads 
            // Repeatedly locks an object by multiple calls to Monitor.Enter
            // Verifies the object is unlocked only by a corresponding number of Monitor.Exit
            Thread newThread1 = new Thread(RepeatedLock);
            Thread newThread2 = new Thread(RepeatedLock);
            // Starting two threads, repeatedly locking, waiting and verifying
            newThread1.Start();
            newThread2.Start();
            Thread.Sleep(100);
            if (!lockResult)
            {
                // Failure : both threads passed lock
                throw new Exception("Failure : both threads passed lock");
            }
            // unlocking the final lock and verifying the waiting thread continues
            flag.Set();
            Thread.Sleep(500);
            if (lockResult)
            {
                // Failure : lock not released by equal number of unlocks
                throw new Exception("Failure : lock not released by equal number of unlocks");
            }
            if (newThread1.IsAlive)
                newThread2.Abort();
            if (newThread2.IsAlive)
                newThread2.Abort();
        }

        //
        // Locking on generic types. Regression coverage for nanoFramework/Home#1830.
        //
        // In the CLR the monitor lock pointer and the closed TypeSpec of a generic instance are stored in
        // the same word of the object header. Taking a lock on an instance of a generic class used to hand
        // Monitor.Enter that TypeSpec where a lock pointer was expected, and conversely storing a lock
        // would have destroyed the TypeSpec the CLR needs to resolve T. These tests cover both directions,
        // and pair every generic case with the equivalent non-generic one.
        //

        [TestMethod]
        public void Monitor6_Enter_Exit_NonGeneric_Instance_Test()
        {
            // Control for Monitor7: the same sequence on a non-generic instance, which has always worked.
            PlainHolder holder = new PlainHolder(1);

            Monitor.Enter(holder);
            holder.Value = 2;
            Monitor.Exit(holder);

            Assert.AreEqual(2, holder.Get());
        }

        [TestMethod]
        public void Monitor7_Enter_Exit_Generic_Instance_Test()
        {
            // The reported failure. Before the fix this faulted inside the CLR.
            GenericHolder<int> holder = new GenericHolder<int>(1);

            Monitor.Enter(holder);
            holder.Set(2);
            Monitor.Exit(holder);

            Assert.AreEqual(2, holder.Get());
        }

        [TestMethod]
        public void Monitor8_LockStatement_Generic_Instance_Test()
        {
            // The lock keyword lowers to Monitor.Enter/Exit wrapped in a try/finally, so it reaches the
            // same CLR path from a different IL shape. Covers a value type and a reference type argument.
            GenericHolder<int> intHolder = new GenericHolder<int>(1);
            GenericHolder<string> stringHolder = new GenericHolder<string>("a");

            lock (intHolder)
            {
                intHolder.Set(2);
            }

            lock (stringHolder)
            {
                stringHolder.Set("b");
            }

            Assert.AreEqual(2, intHolder.Get());
            Assert.AreEqual("b", stringHolder.Get());
        }

        [TestMethod]
        public void Monitor9_Generic_TypeSpec_Survives_Lock_Test()
        {
            // Taking and releasing the lock must not overwrite the instance's closed TypeSpec. Interface
            // dispatch and a generic method call are the operations that read it back, so they are the
            // probes that detect a clobbered TypeSpec.
            GenericHolder<int> holder = new GenericHolder<int>(7);
            IValueHolder<int> asInterface = holder;

            lock (holder)
            {
                holder.Set(8);
            }

            Assert.AreEqual(8, asInterface.Get());

            asInterface.Set(9);

            Assert.AreEqual(9, holder.Get());
            Assert.AreEqual(18, holder.Convert((int v) => v * 2));
        }

        [TestMethod]
        public void Monitor10_Generic_TypeSpec_Survives_GC_While_Locked_Test()
        {
            // The GC relocation handler for class blocks used to relocate that header word unconditionally,
            // treating a generic instance's TypeSpec as if it were a pointer. Force a full collection and
            // heap compaction while the lock is held, then read the TypeSpec back.
            GenericHolder<string> holder = new GenericHolder<string>("before");
            IValueHolder<string> asInterface = holder;

            lock (holder)
            {
                AllocateGarbage();

                // forces a collection and heap compaction
                GC.GetTotalMemory(true);

                holder.Set("after");
            }

            Assert.AreEqual("after", asInterface.Get());

            // and the instance is still usable as a lock target afterwards
            lock (holder)
            {
                holder.Set("last");
            }

            Assert.AreEqual("last", asInterface.Get());
        }

        [TestMethod]
        public void Monitor11_Recursive_Lock_Generic_Instance_Test()
        {
            // Nested acquisition has to find the same lock and count the recursion. If a fresh lock were
            // created on each Enter, the matching Exits would not balance.
            GenericHolder<int> holder = new GenericHolder<int>(0);

            Monitor.Enter(holder);
            Monitor.Enter(holder);
            Monitor.Enter(holder);

            holder.Set(3);

            Monitor.Exit(holder);
            Monitor.Exit(holder);
            Monitor.Exit(holder);

            Assert.AreEqual(3, holder.Get());

            // fully released, so one more Exit has to throw
            Assert.ThrowsException(typeof(Exception), () => { Monitor.Exit(holder); });
        }

        [TestMethod]
        public void Monitor12_Exit_Without_Enter_Generic_Instance_Test()
        {
            // A generic instance that was never locked must report no lock at all. Reading the TypeSpec as
            // a lock pointer would make this look locked instead of throwing.
            GenericHolder<int> holder = new GenericHolder<int>(0);

            Assert.ThrowsException(typeof(Exception), () => { Monitor.Exit(holder); });
        }

        [TestMethod]
        public void Monitor13_Contention_Generic_Instance_Test()
        {
            // Two threads contending on a generic instance drive the ownership handover path, which is
            // where the header lock slot is cleared as the last owner releases.
            s_contendedHolder = new GenericHolder<int>(0);
            s_contendedCount = 0;

            Thread first = new Thread(ContendOnGenericInstance);
            Thread second = new Thread(ContendOnGenericInstance);

            first.Start();
            second.Start();

            first.Join();
            second.Join();

            Assert.AreEqual(2 * ContendIterations, s_contendedHolder.Get());
            Assert.AreEqual(2 * ContendIterations, s_contendedCount);
        }

        [TestMethod]
        public void Monitor14_Locks_On_Distinct_Generic_Instances_Are_Independent_Test()
        {
            // Locking one instance must not lock another instance of the same closed type, nor a different
            // instantiation of the same open type.
            GenericHolder<int> first = new GenericHolder<int>(1);
            GenericHolder<int> second = new GenericHolder<int>(2);
            GenericHolder<string> other = new GenericHolder<string>("x");

            Monitor.Enter(first);

            // neither of the other two is owned, so releasing them has to throw
            Assert.ThrowsException(typeof(Exception), () => { Monitor.Exit(second); });
            Assert.ThrowsException(typeof(Exception), () => { Monitor.Exit(other); });

            Monitor.Exit(first);

            Assert.AreEqual(1, first.Get());
            Assert.AreEqual(2, second.Get());
            Assert.AreEqual("x", other.Get());
        }

        [TestMethod]
        public void Monitor15_Lock_Boxed_Generic_ValueType_Test()
        {
            // A boxed generic value type is a class block too, so it goes through the same header.
            GenericValue<int> value = new GenericValue<int>();
            value.Value = 5;

            object boxed = value;

            Monitor.Enter(boxed);
            Monitor.Exit(boxed);

            // locking again proves the first release left the header consistent
            lock (boxed)
            {
            }

            Assert.IsNotNull(boxed);
        }

        [TestMethod]
        public void Monitor16_Lock_String_And_Array_Test()
        {
            // Strings and arrays carry no lock slot in their header either, and are found by the same
            // lookup that generic instances now use. Guard against regressing that lookup.
            string text = "monitor lock target";
            int[] numbers = new int[4];

            Monitor.Enter(text);
            Monitor.Exit(text);

            lock (numbers)
            {
                numbers[0] = 1;
            }

            Assert.AreEqual(1, numbers[0]);
            Assert.ThrowsException(typeof(Exception), () => { Monitor.Exit(numbers); });
        }

        [TestMethod]
        public void Monitor17_Synchronized_Methods_Test()
        {
            // A synchronized instance method locks the instance itself, so on a generic type it takes the
            // same path as Monitor7. The static case locks a reflection block for the type instead.
            PlainSyncCounter plain = new PlainSyncCounter();
            plain.Increment();
            plain.Increment();

            Assert.AreEqual(2, plain.Count);

            int firstCall = PlainSyncCounter.StaticIncrement();
            int secondCall = PlainSyncCounter.StaticIncrement();

            Assert.AreEqual(firstCall + 1, secondCall);

            GenericSyncCounter<string> generic = new GenericSyncCounter<string>();
            generic.Increment("a");
            generic.Increment("b");

            Assert.AreEqual(2, generic.Count);
            Assert.AreEqual("b", generic.Value);
        }

        private const int ContendIterations = 20;

        private static GenericHolder<int> s_contendedHolder = new GenericHolder<int>(0);
        private static int s_contendedCount = 0;

        private static void ContendOnGenericInstance()
        {
            for (int i = 0; i < ContendIterations; i++)
            {
                Monitor.Enter(s_contendedHolder);

                s_contendedHolder.Set(s_contendedHolder.Get() + 1);
                s_contendedCount++;

                Monitor.Exit(s_contendedHolder);

                Thread.Sleep(1);
            }
        }

        private static void AllocateGarbage()
        {
            object[] garbage = new object[64];

            for (int i = 0; i < garbage.Length; i++)
            {
                garbage[i] = new object();
            }
        }

        internal interface IValueHolder<T>
        {
            T Get();

            void Set(T value);
        }

        internal class GenericHolder<T> : IValueHolder<T>
        {
            private T _value;

            internal GenericHolder(T value)
            {
                _value = value;
            }

            public T Get() => _value;

            public void Set(T value) => _value = value;

            internal TResult Convert<TResult>(Func<T, TResult> converter) => converter(_value);
        }

        internal class PlainHolder
        {
            internal int Value;

            internal PlainHolder(int value)
            {
                Value = value;
            }

            internal int Get() => Value;
        }

        internal struct GenericValue<T>
        {
            internal T Value;
        }

        internal class PlainSyncCounter
        {
            private static int s_staticCount = 0;

            internal int Count;

            [MethodImpl(MethodImplOptions.Synchronized)]
            internal void Increment()
            {
                Count++;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            internal static int StaticIncrement()
            {
                s_staticCount++;

                return s_staticCount;
            }
        }

        internal class GenericSyncCounter<T>
        {
            internal int Count;
            internal T Value;

            [MethodImpl(MethodImplOptions.Synchronized)]
            internal void Increment(T value)
            {
                Count++;
                Value = value;
            }
        }

    }
}
