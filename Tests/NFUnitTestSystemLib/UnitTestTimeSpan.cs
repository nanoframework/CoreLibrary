//
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
    class UnitTestTimeSpan
    {
        //TimeSpan Test methods
        const long m_TicksPerDay = 864000000000;
        const long m_TicksPerHour = 36000000000;
        const long m_TicksPerMinute = 600000000;
        const long m_TicksPerSecond = 10000000;
        const long m_TicksPerMillisecond = 10000;

        public bool CCtorHelper(ref TimeSpan ts)
        {
            bool testResult = true;
            try
            {
                ts = new TimeSpan();
                testResult &= ts.Ticks == 0;
                testResult &= ts.Days == 0;
                testResult &= ts.Hours == 0;
                testResult &= ts.Minutes == 0;
                testResult &= ts.Seconds == 0;
                testResult &= ts.Milliseconds == 0;
                if (!testResult)
                    Debug.WriteLine(ts.ToString());
            }
            catch
            {
                Debug.WriteLine("Exception Caught");
                testResult = false;
            }
            Debug.WriteLine((testResult ? "PASS" : "FAIL"));
            return testResult;
        }

        [TestMethod]
        public void CCtor_Test()
        {
            /// <summary>
            /// 1. Test copy constructor
            /// </summary>
            ///
            Debug.WriteLine("Copy Constructor test");
            TimeSpan ts = new TimeSpan();
            Debug.WriteLine(ts.ToString());
            Assert.True(CCtorHelper(ref ts));
            ts = TimeSpan.MaxValue;
            ts = new TimeSpan();
            Debug.WriteLine(ts.ToString());
            Assert.True(CCtorHelper(ref ts));
            ts = TimeSpan.MinValue;
            Assert.True(CCtorHelper(ref ts));
            int mxd = 24000;
            int mx = 1000;

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int id = (random.Next(1) == 0 ? -1 : 1) *
                    random.Next(mxd);
                int ih = (random.Next(1) == 0 ? -1 : 1) *
                    random.Next(mx);
                int im = (random.Next(1) == 0 ? -1 : 1) *
                    random.Next(mx);
                int ise = (random.Next(1) == 0 ? -1 : 1) *
                    random.Next(mx);
                int ims = (random.Next(1) == 0 ? -1 : 1) *
                    random.Next(mx);
                ts = new TimeSpan(id, ih, im, ise, ims);
                Assert.True(CCtorHelper(ref ts));
            }
        }

        public void Ctor64Helper(Int64 i64)
        {
            /// <summary>
            /// 1. Test constructor
            /// </summary>
            ///
            Debug.WriteLine("Constructor test");

            TimeSpan ts = new TimeSpan(i64);
            long days = i64 / m_TicksPerDay;
            long hours = (i64 - ts.Days * m_TicksPerDay) / m_TicksPerHour;
            long minutes = (i64 - ts.Days * m_TicksPerDay - ts.Hours *
                m_TicksPerHour) / m_TicksPerMinute;
            long seconds = (i64 - ts.Days * m_TicksPerDay - ts.Hours *
                m_TicksPerHour - ts.Minutes * m_TicksPerMinute) / m_TicksPerSecond;
            long milliseconds = (i64 - ts.Days * m_TicksPerDay - ts.Hours *
                m_TicksPerHour - ts.Minutes * m_TicksPerMinute - ts.Seconds * m_TicksPerSecond) /
                m_TicksPerMillisecond;
            Assert.Equal(ts.Days, days);
            Assert.Equal(ts.Hours, hours);
            Assert.Equal(ts.Minutes, minutes);
            Assert.Equal(ts.Seconds, seconds);
            Assert.Equal(ts.Milliseconds, milliseconds);
            Debug.WriteLine(ts.ToString());

        }

        [TestMethod]
        public void Ctor_Test()
        {
            /// <summary>
            /// 1. Test constructor with Int64
            /// </summary>
            ///
            Debug.WriteLine("Constructor test for 64 bit int");

            Int64 i64 = 0;
            Debug.WriteLine("Normal");
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                i64 = random.Next(int.MaxValue);
                i64 *= random.Next(10000);
                Ctor64Helper(i64);
            }

            Debug.WriteLine("Max and Min values");
            i64 = 0x7fffffffffffffff;
            Ctor64Helper(i64);
            Ctor64Helper(TimeSpan.MaxValue.Ticks);
            i64 = 0;
            Ctor64Helper(i64);
            i64 = -9223372036854775808;
            Ctor64Helper(i64);
            Debug.WriteLine("MAX VALUES: " + TimeSpan.MaxValue.Ticks.ToString() + " AND " +
                Int64.MaxValue);
            Ctor64Helper(Int64.MaxValue);
            Ctor64Helper(TimeSpan.MinValue.Ticks);
        }

        public void CtorHelper(int[] vals)
        {
            TimeSpan ts = new TimeSpan(0);
            Int64 i64 = 0;

            string str = "";
            if (vals.Length == 3)
                str = "0 : ";
            for (int i = 0; i < vals.Length; i++)
                str += vals[i].ToString() + " : ";
            for (int i = vals.Length; i < 5; i++)
                str += "0 : ";
            Debug.WriteLine(str);

            switch (vals.Length)
            {
                case 3:
                    ts = new TimeSpan(vals[0], vals[1], vals[2]);
                    i64 = vals[0] * m_TicksPerHour + vals[1] * m_TicksPerMinute + vals[2] *
                        m_TicksPerSecond;
                    break;
                case 4:
                    ts = new TimeSpan(vals[0], vals[1], vals[2], vals[3]);
                    i64 = vals[0] * m_TicksPerDay + vals[1] * m_TicksPerHour + vals[2] *
                        m_TicksPerMinute + vals[3] * m_TicksPerSecond;
                    break;
                case 5:
                    ts = new TimeSpan(vals[0], vals[1], vals[2], vals[3], vals[4]);
                    i64 = vals[0] * m_TicksPerDay + vals[1] * m_TicksPerHour + vals[2] *
                        m_TicksPerMinute + vals[3] * m_TicksPerSecond + vals[4] * m_TicksPerMillisecond;
                    break;
                default:
                    Debug.WriteLine("Invalid parameter!");
                    throw new Exception("Invalid parameter!");
                    break;
            }
            Assert.Equal(ts.Days, i64 / m_TicksPerDay);
            Assert.Equal(ts.Hours, (i64 - ts.Days * m_TicksPerDay) / m_TicksPerHour);
            Assert.Equal(ts.Minutes, (i64 - ts.Days * m_TicksPerDay - ts.Hours *
                    m_TicksPerHour) / m_TicksPerMinute);
            Assert.Equal(ts.Seconds, (i64 - ts.Days * m_TicksPerDay - ts.Hours *
                    m_TicksPerHour - ts.Minutes * m_TicksPerMinute) / m_TicksPerSecond);
            Assert.Equal(ts.Milliseconds, (i64 - ts.Days * m_TicksPerDay - ts.Hours *
                    m_TicksPerHour - ts.Minutes * m_TicksPerMinute - ts.Seconds * m_TicksPerSecond) / m_TicksPerMillisecond);

            Debug.WriteLine(ts.Days.ToString() + " : " +
                ts.Hours.ToString() + " : " +
                ts.Minutes.ToString() + " : " +
                ts.Seconds.ToString() + " : " +
                ts.Milliseconds.ToString());
        }

        [TestMethod]
        public void Ctor_Test1()
        {
            /// <summary>
            /// 1. Test constructor with Hour Minute Second
            /// </summary>
            ///
            Debug.WriteLine("Constructor test H:M:S");


            Debug.WriteLine(m_TicksPerDay.ToString() + " == " + TimeSpan.TicksPerDay.ToString());
            Debug.WriteLine(m_TicksPerHour.ToString() + " == " + TimeSpan.TicksPerHour.ToString());
            Debug.WriteLine(m_TicksPerMinute.ToString() + " == " +
                TimeSpan.TicksPerMinute.ToString());
            Debug.WriteLine(m_TicksPerSecond.ToString() + " == " +
                TimeSpan.TicksPerSecond.ToString());
            Debug.WriteLine(m_TicksPerMillisecond.ToString() + " == " +
                TimeSpan.TicksPerMillisecond.ToString());

            int[] vals = new int[3];
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                vals[0] = random.Next(23); //hours
                vals[1] = random.Next(59); //min
                vals[2] = random.Next(59); //sec
                CtorHelper(vals);
            }
        }

        [TestMethod]
        public void Ctor_Test2()
        {
            /// <summary>
            /// 1. Test constructor with Day Hour Minute Second
            /// </summary>
            ///
            Debug.WriteLine("Constructor test D:H:M:S");
            int[] vals = new int[4];
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                vals[0] = random.Next(10 * 365) + 1;  //days
                vals[1] = random.Next(23);  //hours
                vals[2] = random.Next(59);  //minutes
                vals[3] = random.Next(59);  //seconds
                CtorHelper(vals);
            }
        }

        [TestMethod]
        public void Ctor_Test3()
        {
            /// <summary>
            /// 1. Test constructor with Day Hour Minute Second Millisecond
            /// </summary>
            ///
            Debug.WriteLine("Constructor test D:H:M:S:MS");

            Debug.WriteLine("TimeSpan::Ctor - Normal ");

            int[] vals = new int[5];
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                vals[0] = random.Next(10 * 365) + 1;  //days
                vals[1] = random.Next(23);  //hours
                vals[2] = random.Next(59);  //minutes
                vals[3] = random.Next(59);  //seconds
                vals[4] = random.Next(999);  //milliseconds
                CtorHelper(vals);
            }
        }

        [TestMethod]
        public void CompareTo_Test4()
        {
            /// <summary>
            /// 1. Construct 2 Timespans
            /// 2. Test the CompareTo method
            /// </summary>
            ///
            Debug.WriteLine("Testing the CompareTo method");

            Random random = new Random();
            Debug.WriteLine("Creating TimeSpan");
            int day = random.Next(10 * 365) + 1;  //days
            int hour = random.Next(23);  //hours
            int minute = random.Next(59);  //minutes
            int second = random.Next(59);  //seconds
            int msec = random.Next(999);  //milliseconds
            TimeSpan ts1 = new TimeSpan(day, hour, minute, second, msec);

            Debug.WriteLine("Testing CompareTo");
            Assert.Equal(-1, ts1.CompareTo(new TimeSpan(day + 1, hour, minute, second, msec)));
            Debug.WriteLine(ts1.CompareTo(new TimeSpan(day + 1, hour, minute, second, msec)).ToString());
            Assert.Equal(1, ts1.CompareTo(new TimeSpan(day, hour - 1, minute, second, msec)));
            Debug.WriteLine(ts1.CompareTo(new TimeSpan(day, hour - 1, minute, second, msec)).ToString());
            Assert.Equal(0, ts1.CompareTo(new TimeSpan(day, hour, minute, second, msec)));
            Debug.WriteLine(ts1.CompareTo(new TimeSpan(day, hour, minute, second, msec)).ToString());
        }

        [TestMethod]
        public void GetHashCode_Test5()
        {
            /// <summary>
            /// 1. Test that GetHashCode returns the same for the same TimeSpan
            /// 2. Test that GetHashCode returns differently for different TimeSpans
            /// </summary>
            ///
            Debug.WriteLine("Testing the GetHashCode method");

            Random random = new Random();
            Debug.WriteLine("Test that GetHashCode returns the same for the same TimeSpan");
            for (int i = 0; i < 30; i++)
            {
                int hours = random.Next(23);
                int minutes = random.Next(59);
                int seconds = random.Next(59);
                TimeSpan ts01 = new TimeSpan(hours, minutes, seconds);
                TimeSpan ts02 = new TimeSpan(hours, minutes, seconds);
                Debug.WriteLine(ts01.GetHashCode().ToString() + " == " +
                    ts02.GetHashCode().ToString());
                Assert.Equal(ts01.GetHashCode(), ts02.GetHashCode());
            }

            TimeSpan ts1 = new TimeSpan(1, 1, 1);
            Debug.WriteLine("Test that GetHashCode returns differently for different TimeSpans");
            Debug.WriteLine("This may fail erroneously.");
            Debug.WriteLine("From the docs two different TimeSpans may have same hashcode");
            Debug.WriteLine("But, for the most part the values should be different.");
            for (int i = 0; i < 5; i++)
            {
                TimeSpan ts2 = new TimeSpan(random.Next(23),
                    random.Next(59), random.Next(59));
                Debug.WriteLine(ts1.GetHashCode().ToString() + " Does Not Equal " +
                    ts2.GetHashCode().ToString());
                if (ts1 != ts2)
                {
                    Assert.NotEqual(ts1.GetHashCode(), ts2.GetHashCode());
                }
                else
                {
                    Assert.Equal(ts1.GetHashCode(), ts2.GetHashCode());
                }
            }
        }

        [TestMethod]
        public void Equals_Test6()
        {
            /// <summary>
            /// 1. Test the Equals method
            /// </summary>
            ///
            Debug.WriteLine("Testing the Equals method");
            Random random = new Random();
            // verify same timespan computes to same hash
            for (int i = 0; i < 5; i++)
            {
                int hours = random.Next(23);
                int minutes = random.Next(59);
                int seconds = random.Next(59);
                TimeSpan ts01 = new TimeSpan(hours, minutes, seconds);
                TimeSpan ts02 = new TimeSpan(hours, minutes, seconds);
                Debug.WriteLine(ts01.ToString() + " == " + ts02.ToString());
                Debug.WriteLine("Expected true");
                Assert.True(ts01.Equals(ts02));
                TimeSpan ts03 = new TimeSpan(hours, minutes, seconds);
                TimeSpan ts04 = new TimeSpan(hours + 1, minutes - 1, seconds + 1);
                Debug.WriteLine("Expected false");
                Assert.False(ts03.Equals(ts04));
            }
        }

        [TestMethod]
        public void ToString_Test7()
        {
            /// <summary>
            /// 1. Test the ToString method
            /// </summary>
            ///
            Debug.WriteLine("Testing ToString method");
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                bool b = true;
                int hours = random.Next(23);
                int minutes = random.Next(59);
                int seconds = random.Next(59);
                TimeSpan ts01 = new TimeSpan(hours, minutes, seconds);
                string str =
                    (hours < 10 ? "0" : "") + hours.ToString() + ":" +
                    (minutes < 10 ? "0" : "") + minutes.ToString() + ":" +
                    (seconds < 10 ? "0" : "") + seconds.ToString();
                Assert.Equal(str, ts01.ToString());
                Debug.WriteLine(str + " == " + ts01.ToString());
            }
        }

        bool CompareTimeSpan(TimeSpan ts1, TimeSpan ts2)
        {
            bool testResult = true;
            testResult &= ts1.Days == ts2.Days;
            testResult &= ts1.Hours == ts2.Hours;
            testResult &= ts1.Minutes == ts2.Minutes;
            testResult &= ts1.Seconds == ts2.Seconds;
            testResult &= ts1.Milliseconds == ts2.Milliseconds;
            return testResult;
        }

        [TestMethod]
        public void Add_Test8()
        {
            /// <summary>
            /// 1. Test the binary + operator
            /// </summary>
            ///
            Debug.WriteLine("Testing the + operator");

            Debug.WriteLine("TimeSpan::Add - Normal ");
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                bool b = true;
                TimeSpan ts01 = new TimeSpan(random.Next(12),
                    random.Next(29), random.Next(29));
                int hours = random.Next(11);
                int minutes = random.Next(30);
                int seconds = random.Next(30);
                TimeSpan ts02 = new TimeSpan(hours, minutes, seconds);
                TimeSpan ts03 = ts01.Add(ts02);
                Assert.True(ts01 != ts03);
                Assert.False(CompareTimeSpan(ts01, ts03));
                Assert.True(CompareTimeSpan(ts03, ts01 + ts02));
                Assert.True(ts03.Days == (ts01.Days + ts02.Days));
                Assert.True(ts03.Hours == (ts01.Hours + hours));
                Assert.True(ts03.Minutes == (ts01.Minutes + minutes));
                Assert.True(ts03.Seconds == (ts01.Seconds + seconds));
                Assert.True(ts03.Milliseconds == (ts01.Milliseconds + ts02.Milliseconds));
                Debug.WriteLine(b.ToString());
            }
            TimeSpan ts1 = new TimeSpan(2, 2, 2, 2, 2);
            TimeSpan ts2 = new TimeSpan(0, 0, 0, 0, 999);
            TimeSpan ts3 = ts1.Add(ts2);
            Assert.Equal(ts3.Milliseconds, 1);
            Assert.Equal(ts3.Seconds, 3);
            Assert.Equal(ts3.Minutes, 2);
            Assert.Equal(ts3.Hours, 2);
            Assert.Equal(ts3.Days, 2);

            ts2 = new TimeSpan(0, 0, 0, 58, 0);
            ts3 = ts1.Add(ts2);
            Assert.Equal(ts3.Milliseconds, 2);
            Assert.Equal(ts3.Seconds, 0);
            Assert.Equal(ts3.Minutes, 3);
            Assert.Equal(ts3.Hours, 2);
            Assert.Equal(ts3.Days, 2);

            ts2 = new TimeSpan(0, 0, 59, 0, 0);
            ts3 = ts1.Add(ts2);
            Assert.Equal(ts3.Milliseconds, 2);
            Assert.Equal(ts3.Seconds, 2);
            Assert.Equal(ts3.Minutes, 1);
            Assert.Equal(ts3.Hours, 3);
            Assert.Equal(ts3.Days, 2);

            ts2 = new TimeSpan(0, 22, 0, 0, 0);
            ts3 = ts1.Add(ts2);
            Assert.Equal(ts3.Milliseconds, 2);
            Assert.Equal(ts3.Seconds, 2);
            Assert.Equal(ts3.Minutes, 2);
            Assert.Equal(ts3.Hours, 0);
            Assert.Equal(ts3.Days, 3);
        }

        [TestMethod]
        public void Compare_Test9()
        {
            /// <summary>
            /// 1. Test the Compare method
            /// </summary>
            ///

            Debug.WriteLine("Testing the Compare method");

            Random random = new Random();
            int day = random.Next(10 * 365) + 1;  //days
            int hour = random.Next(23);  //hours
            int minute = random.Next(59);  //minutes
            int second = random.Next(59);  //seconds
            int msec = random.Next(999);  //milliseconds
            TimeSpan ts1 = new TimeSpan(day, hour, minute, second, msec);

            Assert.Equal(-1, TimeSpan.Compare(ts1, new TimeSpan
                (day, hour, minute, second + 1, msec)));
            Debug.WriteLine(TimeSpan.Compare(ts1, new TimeSpan
                (day, hour, minute, second + 1, msec)).ToString());

            Assert.Equal(1, TimeSpan.Compare(ts1, new TimeSpan
                (day, hour, minute, second, msec - 1)));
            Debug.WriteLine(TimeSpan.Compare(ts1, new TimeSpan
                (day, hour, minute, second, msec - 1)).ToString());

            Assert.Equal(0, TimeSpan.Compare(ts1, new TimeSpan
                (day, hour, minute, second, msec)));
            Debug.WriteLine(TimeSpan.Compare(ts1, new TimeSpan
                (day, hour, minute, second, msec)).ToString());
        }

        [TestMethod]
        public void Duration_Test10()
        {
            /// <summary>
            /// 1. Test the Duration property with several random TimeSpans
            /// </summary>
            ///
            Debug.WriteLine("Testing Duration property");
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                bool b = true;
                int hours = random.Next(23);
                int minutes = random.Next(59);
                int seconds = random.Next(59);
                TimeSpan ts = new TimeSpan(-hours, -minutes, -seconds);
                Assert.True(ts.Duration() == new TimeSpan(hours, minutes, seconds));
                ts = new TimeSpan(hours, minutes, seconds);
                Assert.True(ts.Duration() == new TimeSpan(hours, minutes, seconds));
            }
        }

        [TestMethod]
        public void Negate_Test12()
        {
            /// <summary>
            /// 1. Test the Negate method
            /// </summary>
            ///
            Debug.WriteLine("Testing the Negate method");
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                bool b = true;
                int hours = random.Next(23);
                int minutes = random.Next(59);
                int seconds = random.Next(59);
                TimeSpan tsN = new TimeSpan(-hours, -minutes, -seconds);
                TimeSpan tsP = new TimeSpan(hours, minutes, seconds);
                Assert.True(tsN.Negate() == tsP);
                Assert.True(tsP.Negate() == tsN);
                Assert.True(tsN.Negate().Negate() == tsN);
                Assert.True(tsP.Negate().Negate() == tsP);
            }
        }

        [TestMethod]
        public void Subtract_Test13()
        {
            /// <summary>
            /// 1. Test subtraction, the binary - operator
            /// </summary>
            ///
            Debug.WriteLine("Testing the binary - operator");

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                bool b = true;
                TimeSpan ts01 = new TimeSpan(23, 59, 59);
                int hours = random.Next(23);
                int minutes = random.Next(59);
                int seconds = random.Next(59);
                TimeSpan ts02 = new TimeSpan(hours, minutes, seconds);
                TimeSpan ts03 = ts01.Subtract(ts02);
                Assert.True((ts01 != ts03) || (ts02.Ticks == 0));
                Assert.False(CompareTimeSpan(ts01, ts03));
                Assert.True(CompareTimeSpan(ts03, ts01 - ts02));
                Assert.True(ts03.Days == (ts01.Days - ts02.Days));
                Assert.True(ts03.Hours == (ts01.Hours - hours));
                Assert.True(ts03.Minutes == (ts01.Minutes - minutes));
                Assert.True(ts03.Seconds == (ts01.Seconds - seconds));
                Assert.True(ts03.Milliseconds == (ts01.Milliseconds - ts02.Milliseconds));
            }
            TimeSpan ts1 = new TimeSpan(2, 2, 2, 2, 2);
            TimeSpan ts2 = new TimeSpan(0, 0, 0, 0, 3);
            TimeSpan ts3 = ts1.Subtract(ts2);
            Assert.Equal(ts3.Milliseconds, 999);
            Assert.Equal(ts3.Seconds, 1);
            Assert.Equal(ts3.Minutes, 2);
            Assert.Equal(ts3.Hours, 2);
            Assert.Equal(ts3.Days, 2);

            ts2 = new TimeSpan(0, 0, 0, 3, 0);
            ts3 = ts1.Subtract(ts2);
            Assert.Equal(ts3.Milliseconds, 2);
            Assert.Equal(ts3.Seconds, 59);
            Assert.Equal(ts3.Minutes, 1);
            Assert.Equal(ts3.Hours, 2);
            Assert.Equal(ts3.Days, 2);

            ts2 = new TimeSpan(0, 0, 3, 0, 0);
            ts3 = ts1.Subtract(ts2);
            Assert.Equal(ts3.Milliseconds, 2);
            Assert.Equal(ts3.Seconds, 2);
            Assert.Equal(ts3.Minutes, 59);
            Assert.Equal(ts3.Hours, 1);
            Assert.Equal(ts3.Days, 2);

            ts2 = new TimeSpan(0, 3, 0, 0, 0);
            ts3 = ts1.Subtract(ts2);
            Assert.Equal(ts3.Milliseconds, 2);
            Assert.Equal(ts3.Seconds, 2);
            Assert.Equal(ts3.Minutes, 2);
            Assert.Equal(ts3.Hours, 23);
            Assert.Equal(ts3.Days, 1);

            ts2 = new TimeSpan(3, 0, 0, 0, 0);
            ts3 = ts1.Subtract(ts2);
            Assert.Equal(ts3.Milliseconds, -998);
            Assert.Equal(ts3.Seconds, -57);
            Assert.Equal(ts3.Minutes, -57);
            Assert.Equal(ts3.Hours, -21);
            Assert.Equal(ts3.Days, 0);
        }

        private void FromTicksHelper(int days, int hours, int mins, int secs, int ms)
        {
            long ticks =
                m_TicksPerDay * days +
                m_TicksPerHour * hours +
                m_TicksPerMinute * mins +
                m_TicksPerSecond * secs +
                m_TicksPerMillisecond * ms;
            TimeSpan ts = TimeSpan.FromTicks(ticks);

            int dys = (int)(ticks / m_TicksPerDay);
            Debug.WriteLine(dys.ToString());
            Assert.Equal(ts.Days, dys);

            int hrs = (int)(ticks / m_TicksPerHour) % 24;
            Debug.WriteLine(hrs.ToString());
            Assert.Equal(ts.Hours, hrs);

            int mns = (int)(ticks / m_TicksPerMinute) % 60;
            Debug.WriteLine(mns.ToString());
            Assert.Equal(ts.Minutes, mns);

            int scs = (int)(ticks / m_TicksPerSecond) % 60;
            Debug.WriteLine(scs.ToString());
            Assert.Equal(ts.Seconds, scs);

            int mss = (int)ms % 1000;
            Debug.WriteLine("MS: " + mss.ToString());
            Assert.Equal(ts.Milliseconds, mss);

            Debug.WriteLine("Days= " + days + " Hours= " + hours +
                " Minutes= " + mins + " Secs= " + secs + " ms= " + ms);
            Debug.WriteLine(ts.ToString());
        }

        [TestMethod]
        public void FromTicks_Test14()
        {
            /// <summary>
            /// 1. Testing the use of ticks in constructors
            /// </summary>
            ///
            Debug.WriteLine("Testing the use of ticks, ticks per increment specified in this file");
            Debug.WriteLine("TimeSpan::FromTicks - Normal ");
            Random random = new Random();
            int max = 5000;
            int maxOthers = 200;
            for (int i = 0; i < 5; i++)
            {
                FromTicksHelper(random.Next(max),
                    random.Next(maxOthers), random.Next(maxOthers),
                    random.Next(maxOthers), random.Next(1000));
            }
        }

        private void UnaryHelper(int days, int hours, int mins, int secs, int ms, bool neg)
        {
            long ticks =
                m_TicksPerDay * days +
                m_TicksPerHour * hours +
                m_TicksPerMinute * mins +
                m_TicksPerSecond * secs +
                m_TicksPerMillisecond * ms;

            TimeSpan ts = new TimeSpan(days, hours, mins, secs, ms);
            TimeSpan nts = (neg ? -ts : +ts);
            int d = (int)(ticks / m_TicksPerDay);
            int h = (int)((ticks % m_TicksPerDay) / m_TicksPerHour);
            int m = (int)((ticks % m_TicksPerDay % m_TicksPerHour) / m_TicksPerMinute);
            int s = (int)((ticks % m_TicksPerDay % m_TicksPerHour % m_TicksPerMinute)
                / m_TicksPerSecond);
            int m_s = (int)((ticks % m_TicksPerDay % m_TicksPerHour % m_TicksPerMinute
                % m_TicksPerSecond) / m_TicksPerMillisecond);

            Assert.Equal(nts.Days, (neg ? -d : +d));
            Debug.WriteLine(nts.Days.ToString() + " == " + (neg ? -d : +d).ToString());

            Assert.Equal(nts.Hours, (neg ? -h : +h));
            Debug.WriteLine(nts.Hours.ToString() + " == " + ((neg ? -h : +h)).ToString());

            Assert.Equal(nts.Minutes, (neg ? -m : +m));
            Debug.WriteLine(nts.Minutes.ToString() + " == " + ((neg ? -m : +m)).ToString());

            Assert.Equal(nts.Seconds, (neg ? -s : +s));
            Debug.WriteLine(nts.Seconds.ToString() + " == " + ((neg ? -s : +s)).ToString());

            Assert.Equal(nts.Milliseconds, (neg ? -m_s : +m_s));
            Debug.WriteLine(nts.Milliseconds.ToString() + " == " + ((neg ? -m_s : +m_s)).ToString());

            Debug.WriteLine(ts.ToString());
            Debug.WriteLine(nts.ToString());
        }

        [TestMethod]
        public void op_UnaryNegation_Test15()
        {
            /// <summary>
            /// 1. Test negation, the unary - operator
            /// </summary>
            ///
            Debug.WriteLine("Testing the unary - operator");

            Random random = new Random();
            int mxd = 24000;
            int mx = 10000;
            for (int i = 0; i < 5; i++)
            {
                int id = (random.Next(1) == 0 ? -1 : 1);
                int ih = (random.Next(1) == 0 ? -1 : 1);
                int im = (random.Next(1) == 0 ? -1 : 1);
                int ise = (random.Next(1) == 0 ? -1 : 1);
                int ims = (random.Next(1) == 0 ? -1 : 1);
                UnaryHelper(id * random.Next(mxd),
                    ih * random.Next(mx), im * random.Next(mx),
                    ise * random.Next(mx), ims * random.Next(mx), true);
            }
        }

        private void OSubAddHelper(int days1, int hours1, int mins1, int secs1,
            int ms1, int days2, int hours2, int mins2, int secs2, int ms2, bool add)
        {
            long ticks1 =
                m_TicksPerDay * days1 +
                m_TicksPerHour * hours1 +
                m_TicksPerMinute * mins1 +
                m_TicksPerSecond * secs1 +
                m_TicksPerMillisecond * ms1;
            long ticks2 =
                m_TicksPerDay * days2 +
                m_TicksPerHour * hours2 +
                m_TicksPerMinute * mins2 +
                m_TicksPerSecond * secs2 +
                m_TicksPerMillisecond * ms2;
            long ticks3 = (add ? (ticks1 + ticks2) : (ticks1 - ticks2));

            int d1 = (int)(ticks3 / m_TicksPerDay);
            int h1 = (int)((ticks3 % m_TicksPerDay) / m_TicksPerHour);
            int m1 = (int)((ticks3 % m_TicksPerDay % m_TicksPerHour) / m_TicksPerMinute);
            int s1 = (int)((ticks3 % m_TicksPerDay % m_TicksPerHour % m_TicksPerMinute)
                / m_TicksPerSecond);
            int m_s1 = (int)((ticks3 % m_TicksPerDay % m_TicksPerHour % m_TicksPerMinute
                % m_TicksPerSecond) / m_TicksPerMillisecond);

            TimeSpan ts1 = new TimeSpan(days1, hours1, mins1, secs1, ms1);
            TimeSpan ts2 = new TimeSpan(days2, hours2, mins2, secs2, ms2);
            TimeSpan ts3 = (add ? (ts1 + ts2) : (ts1 - ts2));

            Assert.Equal(ts3.Days, d1);
            Debug.WriteLine(ts3.Days.ToString() + " == " + d1.ToString());

            Assert.Equal(ts3.Hours, h1);
            Debug.WriteLine(ts3.Hours.ToString() + " == " + h1.ToString());

            Assert.Equal(ts3.Minutes, m1);
            Debug.WriteLine(ts3.Minutes.ToString() + " == " + m1.ToString());

            Assert.Equal(ts3.Seconds, s1);
            Debug.WriteLine(ts3.Seconds.ToString() + " == " + s1.ToString());

            Assert.Equal(ts3.Milliseconds, m_s1);
            Debug.WriteLine(ts3.Milliseconds.ToString() + " == " + m_s1.ToString());

            Debug.WriteLine(ts1.ToString());
            Debug.WriteLine(ts2.ToString());
        }

        [TestMethod]
        public void op_Subtraction_Test16()
        {
            /// <summary>
            /// 1. Test subtraction, the binary - operator with non TimeSpan args
            /// </summary>
            ///
            Debug.WriteLine("Testing the binary - operator with non TimeSpan args");
            Random random = new Random();
            int mxd = 24000;
            int mx = 10000;
            for (int i = 0; i < 5; i++)
            {
                int id = (random.Next(1) == 0 ? -1 : 1);
                int ih = (random.Next(1) == 0 ? -1 : 1);
                int im = (random.Next(1) == 0 ? -1 : 1);
                int ise = (random.Next(1) == 0 ? -1 : 1);
                int ims = (random.Next(1) == 0 ? -1 : 1);
                OSubAddHelper(id * random.Next(mxd),
                    ih * random.Next(mx), im * random.Next(mx),
                    ise * random.Next(mx), ims * random.Next(mx),
                    id * random.Next(mxd), ih * random.Next(mx),
                    im * random.Next(mx), ise * random.Next(mx),
                    ims * random.Next(mx), false);
            }
        }

        [TestMethod]
        public void op_UnaryPlus_Test17()
        {
            /// <summary>
            /// 1. Test the unary + operator
            /// </summary>
            ///
            Debug.WriteLine("Testing the unary + operator");
            Random random = new Random();
            int mxd = 24000;
            int mx = 10000;
            for (int i = 0; i < 5; i++)
            {
                int id = (random.Next(1) == 0 ? -1 : 1);
                int ih = (random.Next(1) == 0 ? -1 : 1);
                int im = (random.Next(1) == 0 ? -1 : 1);
                int ise = (random.Next(1) == 0 ? -1 : 1);
                int ims = (random.Next(1) == 0 ? -1 : 1);
                UnaryHelper(id * random.Next(mxd),
                    ih * random.Next(mx), im * random.Next(mx),
                    ise * random.Next(mx), ims * random.Next(mx),
                    false);
            }
        }

        [TestMethod]
        public void op_Addition_Test18()
        {
            /// <summary>
            /// 1. Test the binary + operator with non-TimeSpan args
            /// </summary>
            ///
            Debug.WriteLine("Testing the binary + operator with non-TimeSpan args");
            Random random = new Random();
            int mxd = 24000;
            int mx = 10000;
            for (int i = 0; i < 5; i++)
            {
                int id = (random.Next(1) == 0 ? -1 : 1);
                int ih = (random.Next(1) == 0 ? -1 : 1);
                int im = (random.Next(1) == 0 ? -1 : 1);
                int ise = (random.Next(1) == 0 ? -1 : 1);
                int ims = (random.Next(1) == 0 ? -1 : 1);
                OSubAddHelper(id * random.Next(mxd),
                    ih * random.Next(mx), im * random.Next(mx),
                    ise * random.Next(mx), ims * random.Next(mx),
                    id * random.Next(mxd), ih * random.Next(mx),
                    im * random.Next(mx), ise * random.Next(mx),
                    ims * random.Next(mx), true);
            }
        }

        private void EqualityHelper(int days1, int hours1, int mins1, int secs1, int ms1,
            int days2, int hours2, int mins2, int secs2, int ms2, bool expected, bool ineq)
        {

            TimeSpan ts1 = new TimeSpan(days1, hours1, mins1, secs1, ms1);
            TimeSpan ts2 = new TimeSpan(days2, hours2, mins2, secs2, ms2);
            Assert.True((ts1 == ts2) == expected);
        }

        [TestMethod]
        public void op_Equality_Test19()
        {
            /// <summary>
            /// 1. Test  equality, the binary == operator 
            /// </summary>
            ///
            Debug.WriteLine("Testing the == operator");
            Random random = new Random();
            int mxd = 24000;
            int mx = 10000;
            for (int i = 0; i < 5; i++)
            {
                int id = (random.Next(1) == 0 ? -1 : 1) * random.Next(mxd);
                int ih = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int im = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int ise = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int ims = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                EqualityHelper(id, ih, im, ise, ims, id, ih, im, ise, ims,
                                            true, false);
                EqualityHelper(id, ih, im, ise, ims, id + 1, ih, im, ise, ims,
                                            false, false);
                EqualityHelper(id, ih, im, ise, ims, id, ih + 1, im, ise, ims,
                                            false, false);
                EqualityHelper(id, ih, im, ise, ims, id, ih, im + 1, ise, ims,
                                            false, false);
                EqualityHelper(id, ih, im, ise, ims, id, ih, im, ise + 1, ims,
                                            false, false);
                EqualityHelper(id, ih, im, ise, ims, id, ih, im, ise, ims + 1,
                                            false, false);
            }
        }

        private void InequalityHelper(int days1, int hours1, int mins1, int secs1, int ms1, int days2, int hours2, int mins2, int secs2, int ms2, bool expected, bool ineq)
        {
            TimeSpan ts1 = new TimeSpan(days1, hours1, mins1, secs1, ms1);
            TimeSpan ts2 = new TimeSpan(days2, hours2, mins2, secs2, ms2);
            Assert.True((ts1 != ts2) == expected);

        }

        [TestMethod]
        public void op_Inequality_Test20()
        {
            /// <summary>
            /// 1. Test  inequality, the binary != operator 
            /// </summary>
            ///
            Debug.WriteLine("Testing the != operator");
            Random random = new Random();
            int mxd = 24000;
            int mx = 10000;
            for (int i = 0; i < 5; i++)
            {
                int id = (random.Next(1) == 0 ? -1 : 1) * random.Next(mxd);
                int ih = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int im = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int ise = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int ims = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                InequalityHelper(id, ih, im, ise, ims, id, ih, im, ise, ims,
                                                false, false);
                InequalityHelper(id, ih, im, ise, ims, id + 1, ih, im, ise, ims,
                                                true, false);
                InequalityHelper(id, ih, im, ise, ims, id, ih + 1, im, ise, ims,
                                                true, false);
                InequalityHelper(id, ih, im, ise, ims, id, ih, im + 1, ise, ims,
                                                true, false);
                InequalityHelper(id, ih, im, ise, ims, id, ih, im, ise + 1, ims,
                                                true, false);
                InequalityHelper(id, ih, im, ise, ims, id, ih, im, ise, ims + 1,
                                                true, false);
            }
        }

        private bool LTGTHelper(int days1, int hours1, int mins1, int secs1, int ms1, int days2, int hours2, int mins2, int secs2, int ms2, bool expected, int opcode)
        {
            bool testResult = true;
            try
            {
                TimeSpan ts1 = new TimeSpan(days1, hours1, mins1, secs1, ms1);
                TimeSpan ts2 = new TimeSpan(days2, hours2, mins2, secs2, ms2);
                if (opcode == 0)
                    testResult &= ((ts1 < ts2) == expected);
                else if (opcode == 1)
                    testResult &= ((ts1 <= ts2) == expected);
                else if (opcode == 2)
                    testResult &= ((ts1 > ts2) == expected);
                else if (opcode == 3)
                    testResult &= ((ts1 >= ts2) == expected);
                else
                {
                    Debug.WriteLine("Test Error: Invalid opcode");
                    testResult = false;
                }
            }
            catch
            {
                Debug.WriteLine("Exception Caught");
                testResult = false;
            }
            return testResult;
        }

        [TestMethod]
        public void op_LessThan_Test21()
        {
            /// <summary>
            /// 1. Testing the binary Less Than operator
            /// </summary>
            ///
            Debug.WriteLine("Testing the Less Than operator");
            Random random = new Random();
            int mxd = 24000;
            int mx = 10000;
            for (int i = 0; i < 5; i++)
            {
                int id = (random.Next(1) == 0 ? -1 : 1) * random.Next(mxd);
                int ih = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int im = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int ise = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int ims = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im, ise, ims, false, 0));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id + 1, ih, im, ise, ims, true, 0));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih + 1, im, ise, ims, true, 0));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im + 1, ise, ims, true, 0));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im, ise + 1, ims, true, 0));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im, ise, ims + 1, true, 0));
                Assert.True(LTGTHelper(id + 1, ih, im, ise, ims, id, ih, im, ise, ims, false, 0));
                Assert.True(LTGTHelper(id, ih + 1, im, ise, ims, id, ih, im, ise, ims, false, 0));
                Assert.True(LTGTHelper(id, ih, im + 1, ise, ims, id, ih, im, ise, ims, false, 0));
                Assert.True(LTGTHelper(id, ih, im, ise + 1, ims, id, ih, im, ise, ims, false, 0));
                Assert.True(LTGTHelper(id, ih, im, ise, ims + 1, id, ih, im, ise, ims, false, 0));
            }
        }

        [TestMethod]
        public void op_LessThanOrEqual_Test22()
        {
            /// <summary>
            /// 1. Test the binary Less Than Equals operator 
            /// </summary>
            ///
            Debug.WriteLine("Testing the Less Than Equals operator");
            Random random = new Random();
            int mxd = 24000;
            int mx = 10000;
            for (int i = 0; i < 5; i++)
            {
                int id = (random.Next(1) == 0 ? -1 : 1) * random.Next(mxd);
                int ih = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int im = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int ise = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int ims = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im, ise, ims, true, 1));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id + 1, ih, im, ise, ims, true, 1));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih + 1, im, ise, ims, true, 1));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im + 1, ise, ims, true, 1));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im, ise + 1, ims, true, 1));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im, ise, ims + 1, true, 1));
                Assert.True(LTGTHelper(id + 1, ih, im, ise, ims, id, ih, im, ise, ims, false, 1));
                Assert.True(LTGTHelper(id, ih + 1, im, ise, ims, id, ih, im, ise, ims, false, 1));
                Assert.True(LTGTHelper(id, ih, im + 1, ise, ims, id, ih, im, ise, ims, false, 1));
                Assert.True(LTGTHelper(id, ih, im, ise + 1, ims, id, ih, im, ise, ims, false, 1));
                Assert.True(LTGTHelper(id, ih, im, ise, ims + 1, id, ih, im, ise, ims, false, 1));
            }
        }

        [TestMethod]
        public void op_GreaterThan_Test23()
        {
            /// <summary>
            /// 1. Test the binary Greater Than operator 
            /// </summary>
            ///
            Debug.WriteLine("Testing the Greater Than operator");
            Random random = new Random();
            int mxd = 24000;
            int mx = 10000;
            for (int i = 0; i < 5; i++)
            {
                int id = (random.Next(1) == 0 ? -1 : 1) * random.Next(mxd);
                int ih = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int im = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int ise = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int ims = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im, ise, ims, false, 2));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id + 1, ih, im, ise, ims, false, 2));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih + 1, im, ise, ims, false, 2));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im + 1, ise, ims, false, 2));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im, ise + 1, ims, false, 2));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im, ise, ims + 1, false, 2));
                Assert.True(LTGTHelper(id + 1, ih, im, ise, ims, id, ih, im, ise, ims, true, 2));
                Assert.True(LTGTHelper(id, ih + 1, im, ise, ims, id, ih, im, ise, ims, true, 2));
                Assert.True(LTGTHelper(id, ih, im + 1, ise, ims, id, ih, im, ise, ims, true, 2));
                Assert.True(LTGTHelper(id, ih, im, ise + 1, ims, id, ih, im, ise, ims, true, 2));
                Assert.True(LTGTHelper(id, ih, im, ise, ims + 1, id, ih, im, ise, ims, true, 2));
            }
        }

        [TestMethod]
        public void op_GreaterThanOrEqual_Test24()
        {
            /// <summary>
            /// 1. Test the binary Greater Than Equals operator 
            /// </summary>
            ///
            Debug.WriteLine("Testing the Greater Than Equals operator");
            Random random = new Random();
            int mxd = 24000;
            int mx = 10000;
            for (int i = 0; i < 5; i++)
            {
                int id = (random.Next(1) == 0 ? -1 : 1) * random.Next(mxd);
                int ih = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int im = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int ise = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                int ims = (random.Next(1) == 0 ? -1 : 1) * random.Next(mx);
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im, ise, ims, true, 3));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id + 1, ih, im, ise, ims, false, 3));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih + 1, im, ise, ims, false, 3));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im + 1, ise, ims, false, 3));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im, ise + 1, ims, false, 3));
                Assert.True(LTGTHelper(id, ih, im, ise, ims, id, ih, im, ise, ims + 1, false, 3));
                Assert.True(LTGTHelper(id + 1, ih, im, ise, ims, id, ih, im, ise, ims, true, 3));
                Assert.True(LTGTHelper(id, ih + 1, im, ise, ims, id, ih, im, ise, ims, true, 3));
                Assert.True(LTGTHelper(id, ih, im + 1, ise, ims, id, ih, im, ise, ims, true, 3));
                Assert.True(LTGTHelper(id, ih, im, ise + 1, ims, id, ih, im, ise, ims, true, 3));
                Assert.True(LTGTHelper(id, ih, im, ise, ims + 1, id, ih, im, ise, ims, true, 3));
            }
        }

        private void TicksHelper(int days, int hours, int mins, int secs, int ms)
        {
            TimeSpan ts = new TimeSpan(days, hours, mins, secs, ms);
            long ticks =
                days * m_TicksPerDay +
                hours * m_TicksPerHour +
                mins * m_TicksPerMinute +
                secs * m_TicksPerSecond +
                ms * m_TicksPerMillisecond;
            Assert.Equal(ts.Ticks, ticks);
            Debug.WriteLine(ts.Ticks.ToString() + " == " + ticks.ToString());
        }
        [TestMethod]
        public void Ticks_Test28()
        {
            /// <summary>
            /// 1. Test the Ticks Property
            /// </summary>
            ///
            Debug.WriteLine("Testing the Ticks Property");

            Debug.WriteLine("TimeSpan::Ticks - Normal ");
            Random random = new Random();
            int max = 24000;
            int maxOthers = 10000;
            for (int i = 0; i < 5; i++)
            {
                TicksHelper(random.Next(max),
                    random.Next(maxOthers), random.Next(maxOthers),
                    random.Next(maxOthers), random.Next(maxOthers));
            }
        }

    }
}
