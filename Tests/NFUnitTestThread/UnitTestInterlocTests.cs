// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading;
using nanoFramework.TestFramework;

namespace NFUnitTestThread
{
    [TestClass]
    class UnitTestInterlocTests
    {
        public static int interCount = 0;
        static public void ThreadIncrementor()
        {
            Thread.Sleep(new Random().Next(10));
            Interlocked.Increment(ref interCount);
        }

        static public void ThreadDecrementor()
        {
            Thread.Sleep(new Random().Next(10));
            Interlocked.Decrement(ref interCount);
        }

        static public void ThreadIncrementorStarter()
        {
            Thread[] threadArrayInc = new Thread[4];
            for (int i = 0; i < 4; i++)
            {
                OutputHelper.WriteLine("Attempting to start inc thread " + i);
                threadArrayInc[i] = new Thread(ThreadIncrementor);
                threadArrayInc[i].Start();
                Thread.Sleep(1);
            }
            Thread.Sleep(100);
            for (int i = 0; i < 4; i++)
            {
                threadArrayInc[i].Join();
            }
        }

        static public void ThreadDecrementorStarter()
        {
            Thread[] threadArrayDec = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                OutputHelper.WriteLine("Attempting to start dec thread " + i);
                threadArrayDec[i] = new Thread(ThreadDecrementor);
                threadArrayDec[i].Start();
                Thread.Sleep(1);
            }
            Thread.Sleep(100);
            for (int i = 0; i < 5; i++)
            {
                threadArrayDec[i].Join();
            }
        }

        static public void ThreadIncrementor2Starter()
        {

            Thread[] threadArrayInc2 = new Thread[6];
            for (int i = 0; i < 6; i++)
            {
                OutputHelper.WriteLine("Attempting to start inc2 thread " + i);
                threadArrayInc2[i] = new Thread(ThreadIncrementor);
                threadArrayInc2[i].Start();
                Thread.Sleep(1);
            }
            Thread.Sleep(100);
            for (int i = 0; i < 6; i++)
            {
                threadArrayInc2[i].Join();
            }
        }

        [TestMethod]
        public void Interlocked1_Inc_Dec_Test()
        {
            /// <summary>
            /// 1. Starts 4 threads that run asynchronously
            /// 2. Each thread calls Interlocked.Increment or Decrement.
            /// 3. Waits for execution and then verifies that all expected operations completed
            /// </summary>
            ///
            // Starts several async threads that call interlocked 
            // Increment and Decrement, this may erroneously pass.
            // This may erroneously fail for extremely slow devices.

            // Starting several threads, incrementing, decrementing,
            // waiting till all threads finish and verifying
            Thread incThread = new Thread(ThreadIncrementorStarter);
            incThread.Start();
            Thread.Sleep(1);

            Thread decThread = new Thread(ThreadDecrementorStarter);
            decThread.Start();
            Thread.Sleep(1);

            Thread inc2Thread = new Thread(ThreadIncrementor2Starter);
            inc2Thread.Start();
            Thread.Sleep(1);

            Thread lastThread = new Thread(ThreadDecrementor);
            lastThread.Start();
            Thread.Sleep(1);

            // Waiting for execution
            int slept = 0;
            while ((incThread.IsAlive || decThread.IsAlive ||
                inc2Thread.IsAlive || lastThread.IsAlive) && slept < 5000)
            {
                Thread.Sleep(100);
                slept += 100;
            }

            // Verifying all increment/decrement operations done correctly
            if (interCount != 4)
            {
                // expected final increment/decrement result = '4' but got '" + interCount + "'
                throw new Exception("expected final increment/decrement result = '4' but got '" + interCount + "'");
            }
            // Verifying all threads are finished
            if (slept >= 5000)
            {
                // Expcted all threads be done in '5000' msec but took '" + slept + "'
                throw new Exception("Expcted all threads be done in '5000' msec but took '" + slept + "'");
            }
        }

        [TestMethod]
        public void Interlocked2_Compare_Exchange_Test()
        {
            /// <summary>
            /// 1. Starts 4 threads that run asynchronously
            /// 2. Each thread calls Interlocked.Compare or CompareExchange
            /// 3. Waits for execution and then verifies that all expected operations completed
            /// </summary>
            ///

            // Starts 4 async threads that call interlocked Compare, CompareExchange
            // This may erroneously pass.
            // this may erroneously fail for extremely slow devices.

            // Starting the 4 threads
            Thread incThread = new Thread(ThreadIncrementorStarter);
            incThread.Start();

            Thread decThread = new Thread(ThreadDecrementorStarter);
            decThread.Start();

            Thread inc2Thread = new Thread(ThreadIncrementor2Starter);
            inc2Thread.Start();

            Thread lastThread = new Thread(ThreadDecrementor);
            lastThread.Start();
            Thread.Sleep(1);
            int comp = 10;
            // Waiting for execution
            while ((0 != Interlocked.CompareExchange(ref interCount, 0, comp)) ||
                (incThread.IsAlive || decThread.IsAlive || inc2Thread.IsAlive ||
                lastThread.IsAlive))
            {
                OutputHelper.WriteLine(
                    Interlocked.Exchange(ref interCount, 0).ToString() + " " +
                    incThread.IsAlive.ToString() + " " +
                    decThread.IsAlive.ToString() + " " +
                        inc2Thread.IsAlive.ToString() + " " +
                            lastThread.IsAlive.ToString());
                // Setting Count to 0
                Interlocked.Exchange(ref interCount, 0);
                Thread.Sleep(10);
            }
            int slept = 0;
            while ((incThread.IsAlive || decThread.IsAlive || inc2Thread.IsAlive ||
                lastThread.IsAlive) && slept < 5000)
            {
                Thread.Sleep(100);
                slept += 100;
            }
            // Verifying all Interlocked.Compare/CompareExchange operations done correctly
            if (interCount != 0)
            {
                // expected final Compare/CompareExchange result = '0' but got '" + interCount + "'
                throw new Exception("expected final Compare/CompareExchange result = '0' but got '" + interCount + "'");
            }
            // Verifying all threads are finished
            if (slept >= 5000)
            {
                // Expcted all threads be done in '5000' msec but took '" + slept + "'
                throw new Exception("Expcted all threads be done in '5000' msec but took '" + slept + "'");
            }
        }

        [TestMethod]
        public void Interlocked3_Exchange_Boundary_Test()
        {
            /// <summary>
            /// 1. creates 3 int variables initialized to the boundary values of signed int 32
            /// 2. passes all possible combinations of the values to Interlocked.Exchange
            /// 3. verifies Exchange and also verifies original value is returned
            /// </summary>
            ///

            int[] value = new int[] { -2147483648, 0, 2147483647 };
            int temp1, temp2;
            // Verification of original value returned needs temp1 = temp2
            // Verifies Exchange 

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    temp1 = value[i];
                    temp2 = Interlocked.Exchange(ref value[i], value[j]);
                    if (temp1 != temp2)
                    {
                        OutputHelper.WriteLine("Failure : expected Interlocked.Exchange returns" +
                            " the original value '" + temp1 + "' but got '" + temp2 + "'");
                        break;
                    }
                    if (value[i] != value[j])
                    {
                        // Failure : 
                        OutputHelper.WriteLine(value[j] + " is not stored at location1");
                        break;
                    }
                    value[i] = temp1;
                }
            }
        }

        [TestMethod]
        public void Interlocked4_CompareExchange_Boundary_Test()
        {
            /// <summary>
            /// 1. creates 3 int variables initialized to the boundary values of signed int 32
            /// 2. passes all posible combinations of the values to Interlocked.CompareExchange
            /// 3. verifies Exchange upon equality and also verifies original value is returned
            /// </summary>
            ///

            int[] value = new int[] { -2147483648, 0, 2147483647 };
            int temp1, temp2;

            // Verifies the original value is returned at all time
            // Verifies value is stored in location1 upon equality
            for (int r = 0; r < 3; r++)
            {
                for (int p = 0; p < 3; p++)
                {
                    for (int q = 0; q < 3; q++)
                    {
                        temp1 = value[r];
                        temp2 = Interlocked.CompareExchange(ref value[r], value[p], value[q]);

                        if (temp1 != temp2)
                        {
                            OutputHelper.WriteLine("Failure : expected Interlocked.CompareExchange returns" +
                                " the original vaue '" + temp1 + "' but returned '" + temp2 + "'");
                            break;
                        }
                        if (r == q)
                        {

                            if (value[r] != value[p])
                            {
                                OutputHelper.WriteLine("Failure : expected Interlocked.CompareExchange replaces the original value '" +
                                    temp1 + "' upon equality of the two comparands '" + value[r] + "' and '" + value[q] + "'");
                                OutputHelper.WriteLine(value[p] + " is not stored at location1");
                                break;
                            }
                        }
                        value[r] = temp1;
                    }
                }
            }
        }

    }
}
