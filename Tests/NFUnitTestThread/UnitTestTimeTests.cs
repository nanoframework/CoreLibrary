﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading;
using nanoFramework.TestFramework;

namespace NFUnitTestThread
{
    [TestClass]
    class UnitTestTimeTests
    {
        class StatusChecker
        {

            public bool m_result = false;
            public bool z_flag = false;
            public bool c_flag = false;
            public bool m_flag = false;
            public int counter = 0;
            public DateTime t2;
            public DateTime t1;
            public int m_invokeCount, m_maxCount;
            public StatusChecker(int count)
            {
                m_invokeCount = 0;
                m_maxCount = count;
            }

            // This method is called by the timer delegate.
            public void CheckStatus(Object stateInfo)
            {
                if (z_flag)
                {
                    t2 = DateTime.UtcNow;
                    z_flag = false;
                }
                if (m_flag)
                {
                    t1 = DateTime.UtcNow;
                    z_flag = true;
                    m_flag = false;
                }
                if (c_flag)
                {
                    counter++;
                }
                AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
                OutputHelper.WriteLine("Checking status: " +
                    DateTime.UtcNow.ToString() + " " +
                    (++m_invokeCount).ToString());

                if (m_invokeCount == m_maxCount)
                {
                    // Reset the counter and signal Main.
                    m_invokeCount = 0;
                    autoEvent.Set();
                    m_result = true;
                }
            }
        }

        [TestMethod]
        public void Timer_TimerCallback_Test1()
        {
            /// <summary>
            /// 1. Creates a TimerCallback
            /// 2. Creates a Timer that calls it at 1 sec and every quarter sec thereafter
            /// 3. Verifies that the TimerCallback gets called
            /// 4. Change period to half sec
            /// 5. Disposes of the timer after it signals
            /// 6. Verifies that the TimerCallback has been called
            /// </summary>
            ///
            // Tests the Timer and TimerCallback classes, 
            // as well as the Change and Dispose methods
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            StatusChecker statusChecker = new StatusChecker(15);

            // Creating the TimerCallback
            TimerCallback timerDelegate =
                new TimerCallback(statusChecker.CheckStatus);

            OutputHelper.WriteLine("Creating timer: " +
                DateTime.UtcNow.ToString());
            Timer stateTimer =
                    new Timer(timerDelegate, autoEvent, 1000, 250);

            statusChecker.m_result = false;
            // Waiting and verifying
            autoEvent.WaitOne(5000, false);
            if (!statusChecker.m_result)
            {
                OutputHelper.WriteLine("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
                throw new Exception("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
            }
            statusChecker.m_result = false;
            // Changing period to 500msec
            stateTimer.Change(0, 500);
            // Waiting for 7500msec and verifying
            autoEvent.WaitOne(7500, false);
            stateTimer.Dispose();
            // Destroying timer.
            if (!statusChecker.m_result)
            {
                OutputHelper.WriteLine("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
                throw new Exception("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
            }
        }

        [TestMethod]
        public void Timer_TimerCallback_ZeroTest2()
        {
            /// <summary>
            /// 1. Creates a TimerCallback
            /// 2. Creates a Timer that calls it at 1 sec and every quarter sec thereafter
            /// 3. Verifies that the TimerCallback gets called
            /// 4. Change duetime to zero sec
            /// 5. Disposes of the timer after it signals
            /// 6. Verifies that the TimerCallback restarted immediately
            /// </summary>
            ///

            // Tests the Timer and TimerCallback classes, 
            // as well as the Change and Dispose methods
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            StatusChecker statusChecker = new StatusChecker(15);

            // Creating the TimerCallback
            TimerCallback timerDelegate =
                new TimerCallback(statusChecker.CheckStatus);

            OutputHelper.WriteLine("Creating timer: " +
                DateTime.UtcNow.ToString());
            Timer stateTimer =
                    new Timer(timerDelegate, autoEvent, 1000, 250);

            statusChecker.m_result = false;
            // Waiting and verifying
            autoEvent.WaitOne(5000, false);
            if (!statusChecker.m_result)
            {
                OutputHelper.WriteLine("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
                throw new Exception("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
            }
            statusChecker.m_result = false;
            statusChecker.z_flag = true;
            // Changing duetime to zero and Verifying the timer started Immediately.
            DateTime t1 = DateTime.UtcNow;
            stateTimer.Change(0, 500);
            Thread.Sleep(1);
            TimeSpan time = DateTime.UtcNow - statusChecker.t2;
            OutputHelper.WriteLine("callback method called within " + time.ToString());
            if (time.CompareTo(new TimeSpan(0, 0, 0, 0, 100)) > 0)
            {
                // The timer didn't start immediately, started after '" + time.ToString() + "'
                throw new Exception("The timer didn't start immediately, started after '" + time.ToString() + "'");
            }
            // Waiting and verifying
            autoEvent.WaitOne(7500, false);
            // Destroying timer.
            stateTimer.Dispose();
            if (!statusChecker.m_result)
            {
                OutputHelper.WriteLine("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
                throw new Exception("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
            }
        }

        [TestMethod]
        public void Timer_Disable_Periodic_Signaling_Test3()
        {
            /// <summary>
            /// 1. Creates a TimerCallback
            /// 2. Creates a Timer that calls it at 1 sec and every quarter sec thereafter
            /// 3. Verifies that the TimerCallback gets called
            /// 4. Changes period to zero (0) 
            /// 5. Verifies periodic signaling is disabled
            /// 6. Changes period to Infinite
            /// 7. Verifies periodic signaling is disabled
            /// 8. Changes period to quarter sec
            /// 9. Disposes the timer after it signals
            /// 10. Verifies that the TimerCallback has been called
            /// </summary>
            ///

            // Tests the Timer and TimerCallback classes, 
            // as well as the Change and Dispose methods
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            StatusChecker statusChecker = new StatusChecker(15);

            // Creating the TimerCallback
            TimerCallback timerDelegate =
                new TimerCallback(statusChecker.CheckStatus);

            OutputHelper.WriteLine("Creating timer: " +
                DateTime.UtcNow.ToString());
            Timer stateTimer =
                    new Timer(timerDelegate, autoEvent, 1000, 250);

            // Waiting and verifying
            autoEvent.WaitOne(5000, false);
            if (!statusChecker.m_result)
            {
                OutputHelper.WriteLine("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
                throw new Exception("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
            }

            statusChecker.m_result = false;
            statusChecker.c_flag = true;
            // Changing period to zero (0) 
            stateTimer.Change(0, 0);

            // Waiting and verifying the callback method is invoked once
            autoEvent.WaitOne(5000, false);
            if (statusChecker.counter != 1)
            {
                // Failure : expected callback '1' times but got '" + statusChecker.counter + "'
                throw new Exception("Failure : expected callback '1' times but got '" + statusChecker.counter + "'");
            }

            // Reseting counter to zero
            statusChecker.counter = 0;
            // Changing period to Timeout.Infinite
            stateTimer.Change(0, Timeout.Infinite);
            // Waiting and verifying the callback method is invoked once
            autoEvent.WaitOne(5000, false);
            if (statusChecker.counter != 1)
            {
                // Failure : expected callback '1' times but got '" + statusChecker.counter + "'
                throw new Exception("Failure : expected callback '1' times but got '" + statusChecker.counter + "'");
            }

            // Changing period to quarter sec 
            stateTimer.Change(0, 250);
            // Waiting and verifying
            autoEvent.WaitOne(5000, false);
            // Destroying timer.
            stateTimer.Dispose();
            if (!statusChecker.m_result)
            {
                OutputHelper.WriteLine("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
                throw new Exception("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
            }
        }

        [TestMethod]
        public void Timer_TimerCallback_Duetime_Infinite_Test4()
        {
            /// <summary>
            /// 1. Creates a TimerCallback
            /// 2. Creates a Timer that calls it after infinite time
            /// 3. Verifies the callback method is never invoked
            /// </summary>
            ///

            // Tests the TimerCallback is never invoked if it's duetime is infinite 
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            StatusChecker statusChecker = new StatusChecker(15);
            statusChecker.c_flag = true;
            // Creating the TimerCallback
            TimerCallback timerDelegate =
                new TimerCallback(statusChecker.CheckStatus);

            OutputHelper.WriteLine("Creating timer: " +
                DateTime.UtcNow.ToString());
            Timer stateTimer =
                    new Timer(timerDelegate, autoEvent, Timeout.Infinite, 250);

            // Waiting and verifying
            autoEvent.WaitOne(5000, false);
            // Destroying timer.
            stateTimer.Dispose();
            if (statusChecker.counter != 0)
            {
                OutputHelper.WriteLine("Failure : expected callback  method never invoked" +
                    " but is invoked '" + statusChecker.counter + "' times");
                throw new Exception("Failure : expected callback  method never invoked" +
                    " but is invoked '" + statusChecker.counter + "' times");
            }
        }

        [TestMethod]
        public void Timer_Dispose_Test5()
        {
            /// <summary>
            /// 1. Creates a TimerCallback
            /// 2. Creates a Timer that calls it at 1 sec and every quarter sec thereafter
            /// 3. Immediately Disposes the timer
            /// 4. Verifies that the Timer is disposed
            /// </summary>
            ///

            // Tests the Timer and TimerCallback classes, 
            // as well as the Change and Dispose methods
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            StatusChecker statusChecker = new StatusChecker(15);
            statusChecker.c_flag = true;
            // Creating the TimerCallback
            TimerCallback timerDelegate =
                new TimerCallback(statusChecker.CheckStatus);

            OutputHelper.WriteLine("Creating timer: " +
                DateTime.UtcNow.ToString());
            Timer stateTimer =
                    new Timer(timerDelegate, autoEvent, 1000, 250);
            // Immediately Destroying timer
            stateTimer.Dispose();
            // Waiting and verifying for Timer disposed
            autoEvent.WaitOne(5000, false);
            if (statusChecker.counter != 0)
            {
                OutputHelper.WriteLine("Failure : expected timer destroyed immediately hence callback method" +
                    " never invoked but is invoked '" + statusChecker.counter + "' times");
                throw new Exception("Failure : expected timer destroyed immediately hence callback method" +
                    " never invoked but is invoked '" + statusChecker.counter + "' times");
            }
        }

        [TestMethod]
        public void Timer_Negative_Period_Test6()
        {

            /// <summary>
            /// 1. Creates a TimerCallback
            /// 2. Creates a Timer that calls it at 1 sec and every quarter sec thereafter
            /// 3. Verifies that the TimerCallback gets called
            /// 4. Changes period to -2 (negative two) sec
            /// 5. Verifies ArgumentOutOfRangeException exception is thrown
            /// </summary>
            ///

            // Tests the Timer and TimerCallback classes, 
            // as well as the Change and Dispose methods
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            StatusChecker statusChecker = new StatusChecker(15);

            // Creating the TimerCallback
            TimerCallback timerDelegate =
                new TimerCallback(statusChecker.CheckStatus);

            OutputHelper.WriteLine("Creating timer: " +
                DateTime.UtcNow.ToString());
            Timer stateTimer =
                    new Timer(timerDelegate, autoEvent, 1000, 250);

            statusChecker.m_result = false;
            // Waiting and verifying
            autoEvent.WaitOne(5000, false);
            statusChecker.m_result = false;
            // Changing period to -ve
            // period is negative and is not equal to Infinite (or -1) should throw an exception
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                stateTimer.Change(0, -2);
                // Waiting and verifying
                autoEvent.WaitOne(7500, false);
            });
            // Destroying timer.
            stateTimer.Dispose();
        }

        [TestMethod]
        public void Timer_Negative_Duetime_Test7()
        {
            /// <summary>
            /// 1. Creates a TimerCallback
            /// 2. Creates a Timer that calls it at 1 sec and every quarter sec thereafter
            /// 3. Verifies that the TimerCallback gets called
            /// 4. Changes duetime to -2 (negative two) sec
            /// 5. Verifies ArgumentOutOfRangeException exception is thrown
            /// </summary>
            ///

            // Tests the Timer Change method for ArgumentOutOfRangeException
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            StatusChecker statusChecker = new StatusChecker(15);

            // Creating the TimerCallback
            TimerCallback timerDelegate =
                new TimerCallback(statusChecker.CheckStatus);

            OutputHelper.WriteLine("Creating timer: " +
                DateTime.UtcNow.ToString());
            Timer stateTimer =
                    new Timer(timerDelegate, autoEvent, 1000, 250);

            statusChecker.m_result = false;
            // Waiting and verifying
            autoEvent.WaitOne(5000, false);
            statusChecker.m_result = false;
            // Changing period -ve
            // duetime is negative and is not equal to Infinite(or -1) should throw an exception
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                stateTimer.Change(-2, 500);
                // Waiting and verifying
                autoEvent.WaitOne(7500, false);
            });

            // Destroying timer.
            stateTimer.Dispose();
        }

        [TestMethod]
        public void Timer_TimerCallback_Null_Test8()
        {
            /// <summary>
            /// 1. Creates a Timer with callback parameter null
            /// 2. Verifies ArgumentNullException exception is thrown
            /// </summary>
            ///
            // Tests the Timer for ArgumentNullException

            AutoResetEvent autoEvent = new AutoResetEvent(false);
            StatusChecker statusChecker = new StatusChecker(15);

            OutputHelper.WriteLine("Creating timer: " +
                DateTime.UtcNow.ToString());
            Assert.ThrowsException(typeof(ArgumentNullException), () =>
            {
                // Passing a 'null' callback parameter to a timer should throw exception
                Timer stateTimer = new Timer(null, autoEvent, 1000, 250);
                // Waiting and verifying
                autoEvent.WaitOne(7500, false);
                // Destroying timer.
                stateTimer.Dispose();
            });
        }

        [TestMethod]
        public void Timer_MaxInt_DueTime_Test9()
        {
            /// <summary>
            /// 1. Creates a TimerCallback
            /// 2. Creates a Timer that calls it at 1 sec and every quarter sec thereafter
            /// 3. Verifies that the TimerCallback gets called
            /// 4. Changes duetime to MaxInt (in this case MaxInt assumed to be 4 sec)
            /// 5. Disposes of the timer after it signals
            /// 6. Verifies that the TimerCallback starts after 4 sec
            /// </summary>
            ///

            // Tests the Timer and TimerCallback classes, 
            // as well as the Change and Dispose methods
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            StatusChecker statusChecker = new StatusChecker(15);

            // Creating the TimerCallback
            TimerCallback timerDelegate =
                new TimerCallback(statusChecker.CheckStatus);

            OutputHelper.WriteLine("Creating timer: " +
                DateTime.UtcNow.ToString());
            Timer stateTimer =
                    new Timer(timerDelegate, autoEvent, 1000, 250);

            statusChecker.m_result = false;
            // Waiting and verifying
            autoEvent.WaitOne(5000, false);
            if (!statusChecker.m_result)
            {
                OutputHelper.WriteLine("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
                throw new Exception("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
            }
            statusChecker.m_result = false;
            statusChecker.z_flag = true;
            // Changing duetime to 4 sec (Assumed MaxInt)
            DateTime t1 = DateTime.UtcNow;
            stateTimer.Change(4000, 250);
            // Waiting and verifying
            autoEvent.WaitOne(8000, false);
            TimeSpan duration = statusChecker.t2 - t1;
            // Verifying callback method 1st invoked after 4000msec.
            if (duration.CompareTo(new TimeSpan(4000)) <= 0)
            {
                OutputHelper.WriteLine("Failure : expected 1st callback happens more than" +
                    " '4000msec.' but happened after '" + duration.ToString() + "'");
                throw new Exception("Failure : expected 1st callback happens more than" +
                    " '4000msec.' but happened after '" + duration.ToString() + "'");
            }
            if (!statusChecker.m_result)
            {
                OutputHelper.WriteLine("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
                throw new Exception("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
            }
            // Destroying timer.
            stateTimer.Dispose();
        }

        [TestMethod]
        public void Timer_MaxInt_Period_Test10()
        {
            /// <summary>
            /// 1. Creates a TimerCallback
            /// 2. Creates a Timer that calls it at 1 sec and every quarter sec thereafter
            /// 3. Verifies that the TimerCallback gets called
            /// 4. Changes period to MaxInt (in this case MaxInt assumed to be 4 sec)
            /// 5. Disposes of the timer after it signals
            /// 6. Verifies that the TimerCallback starts every 4 sec
            /// </summary>
            ///

            // Tests the Timer and TimerCallback classes, 
            // as well as the Change and Dispose methods
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            StatusChecker statusChecker = new StatusChecker(15);

            // Creating the TimerCallback
            TimerCallback timerDelegate =
                new TimerCallback(statusChecker.CheckStatus);

            OutputHelper.WriteLine("Creating timer: " +
                DateTime.UtcNow.ToString());
            Timer stateTimer =
                    new Timer(timerDelegate, autoEvent, 1000, 250);

            statusChecker.m_result = false;
            // Waiting and verifying
            autoEvent.WaitOne(5000, false);
            if (!statusChecker.m_result)
            {
                OutputHelper.WriteLine("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
                throw new Exception("Failure : expected callback '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
            }
            statusChecker.m_result = false;
            statusChecker.m_flag = true;
            // Changing period to 4 sec (Assumed MaxInt)
            stateTimer.Change(0, 4000);
            // Waiting and verifying callback method is invoked every 4 sec
            autoEvent.WaitOne(60000, false);
            if (!statusChecker.m_result)
            {
                OutputHelper.WriteLine("Failure : after 60sec. expected callback invoked '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
                throw new Exception("Failure : after 60sec. expected callback invoked '" + statusChecker.m_maxCount +
                    "' times but got '" + statusChecker.m_invokeCount + "'");
            }
            // Verifying time interval b/n callback invoke is atleast 4sec.
            TimeSpan duration = statusChecker.t2 - statusChecker.t1;
            if (duration.CompareTo(new TimeSpan(4000)) < 0)
            {
                // Failure : expected interval b/n callbacks at least '4sec' but got '" + duration.Seconds.ToString() + "sec'
                throw new Exception("Failure : expected interval b/n callbacks at least '4sec' but got '" + duration.Seconds.ToString() + "sec'");
            }
            // Destroying timer.
            stateTimer.Dispose();
        }

    }
}
