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
    class UnitTestDateTime
    {
        [TestMethod]
        public void DateTime_ConstructorTest1()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies that the created object is a DateTime
            /// </summary>

            OutputHelper.WriteLine("Creating new DateTime Object");
            DateTime dt = new DateTime();
            OutputHelper.WriteLine(dt.ToString());
            Type type = dt.GetType();
            OutputHelper.WriteLine("Verifying its type");
            Assert.IsType(type, Type.GetType("System.DateTime"));
        }

        [TestMethod]
        public void DateTime_ConstructorTest2()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies that the created object is a DateTime
            /// </summary>
            /// 

            OutputHelper.WriteLine("Generating 10 random DateTime and Verifying");
            for (int i = 0; i < 10; i++)
            {
                DateTime dt = GetRandomDateTime();
                if (dt.Year != year || dt.Month != month || dt.Day != day ||
               dt.Hour != hour || dt.Minute != minute ||
               dt.Second != second || dt.Millisecond != millisec)
                {
                    throw new Exception("Expected DateTime '" + month + "/" + day + "/" + year +
                        " " + hour + ":" + minute + ":" + second + ":" + millisec +
                        "' but got '" + dt.Month + "/" + dt.Day + "/" + dt.Year + " " +
                        dt.Hour + ":" + dt.Minute + ":" + dt.Second + ":" + dt.Millisecond + "'");
                }
                Type t = dt.GetType();
                Assert.IsType(t, Type.GetType("System.DateTime"));
            }
        }

        [TestMethod]
        public void DateTime_ConstructorTest3()
        {
            /// <summary>
            ///  1. Creates Minimum and Maximum DateTimes
            ///  2. Verifies the DateTimes are equal to DateTime.MinValue, DateTime.MaxValue
            /// </summary>
            /// 
            OutputHelper.WriteLine("Creating Minimum DateTime and verifying");
            DateTime minDT1 = DateTime.MinValue;
            DateTime minDT2 = new DateTime();
            DateTime minDT3 = new DateTime(504911232000000000);
            DateTime minDT4 = new DateTime(1601, 1, 1, 0, 0, 0, 0);

            if ((DateTime.Compare(minDT1, minDT2) != 0) ||
                (DateTime.Compare(minDT2, minDT3) != 0) ||
                (DateTime.Compare(minDT3, minDT4) != 0))
            {
                OutputHelper.WriteLine("DateTime.MinValue = '" + minDT1.Ticks + "'ticks,");
                OutputHelper.WriteLine(" new DateTime() = '" + minDT2.Ticks + "'ticks,");
                OutputHelper.WriteLine("new DateTime(0) = '" + minDT3.Ticks + "'ticks.");
                throw new Exception("Expected 'DateTime.MinValue' is equal to 'new DateTime()', " +
                    "equal to 'new DateTime(0)', equal to 'new DateTime(1, 1, 1, 0, 0, 0, 0)' but got ");
            }

            OutputHelper.WriteLine("Creating Maximum DateTime and verifying");
            DateTime maxDateTime = new DateTime(946708127999999999);
            Assert.True(DateTime.MaxValue.Equals(maxDateTime));
        }

        [TestMethod]
        public void DateTime_CompareToTest4()
        {
            /// <summary>
            ///  1. Creates random DateTimes
            ///  2. Verifies that they CompareTo each other
            /// </summary>
            /// 
            OutputHelper.WriteLine("Generating random DateTimes b/n 1000 - 9000");
            OutputHelper.WriteLine("comparing eachother with DateTime.CompareTo and verifying");
            DateTime dt1 = DateTime_btwn_1801_And_2801();
            DateTime dt2 = new DateTime(year, month, day, hour, minute, second, millisec);
            OutputHelper.WriteLine("Comparing two equal DateTimes");
            Assert.Equal(dt1.CompareTo(dt2), 0);
            OutputHelper.WriteLine("Comparing Unequal DateTimes and Verifying");
            dt2 = dt1.Add(new TimeSpan(1));
            Assert.False(dt1.CompareTo(dt2) >= 0);
            Assert.False(dt2.CompareTo(dt1) <= 0);
        }

        [TestMethod]
        public void DateTime_EqualsTest5()
        {
            /// <summary>
            ///  1. Creates two DateTimes
            ///  2. Verifies that they Equals each other
            /// </summary>
            /// 
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime dt1 = GetRandomDateTime();
            DateTime dt2 = new DateTime(year, month, day, hour, minute, second, millisec);
            Assert.True(dt1.Equals(dt2));
        }

        [TestMethod]
        public void DateTime_ToStringTest6()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies that it correctly returns a string from ToString
            /// </summary>
            /// 
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime dt = GetRandomDateTime();
            int[] intArr = new int[] { dt.Month, dt.Day, dt.Year, dt.Hour, dt.Minute, dt.Second };
            string[] strArr = new string[] { "", "", "", "", "", "" };
            for (int i = 0; i < intArr.Length; i++)
            {
                if (i == 2)
                {
                    if (intArr[2] < 100)
                        strArr[2] += "00" + intArr[2];
                    else if (intArr[2] < 1000)
                        strArr[2] += "0" + intArr[2];
                    else
                        strArr[2] += intArr[2];
                }
                else
                {
                    if (intArr[i] < 10)
                    {
                        strArr[i] += "0" + intArr[i];
                    }
                    else
                        strArr[i] += intArr[i];
                }
            }
            string str = strArr[0] + "/" + strArr[1] + "/" + strArr[2] + " " + strArr[3] + ":" + strArr[4] + ":" + strArr[5];
            Assert.Equal(dt.ToString(), str);
        }

        [TestMethod]
        public void DateTime_ToStringTest7()
        {
           /// <summary>
           ///  1. Creates a DateTime
           ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
           /// </summary>
           OutputHelper.WriteLine("Generating random DateTime");
           DateTime dt = GetRandomDateTime();
           OutputHelper.WriteLine("DateTime.ToString(String) using Standard Formats and Verifying");
           string[] standardFmts = { "d", "D", "f", "F", "g", "G", "m", "M", "o", "O", "R", "r", "s", "t", "T", "u", "U", "Y", "y" };
           foreach (string standardFmt in standardFmts)
           {
               try
               {
                   if (dt.ToString(standardFmt).Length < 1)
                   {
                       throw new Exception("Expected a String length greater than '0' but got '" +
                           dt.ToString(standardFmt).Length + "'");
                   }
               }
               catch (Exception ex)
               {
                   throw new Exception("Caught " + ex.Message + " when Trying DateTime.ToString(" + standardFmt + ")");
               }
               OutputHelper.WriteLine("Successfully verified 'DateTime.ToString(" + standardFmt + ")' format as: " + dt.ToString(standardFmt));
           }
           OutputHelper.WriteLine("DateTime.ToString(String) using Custom Formats and Verifying");
           string[] customFmts = {"h:mm:ss.ff t", "d MMM yyyy", "HH:mm:ss.f","dd MMM HH:mm:ss",
                 @"\Mon\t\h\: M", "MM/dd/yyyy", "dddd, dd MMMM yyyy", "MMMM dd", "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'",
                            "yyyy'-'MM'-'dd'T'HH':'mm':'ss", "HH:mm", "yyyy'-'MM'-'dd HH':'mm':'ss'Z'", "yyyy MMMM"};
           foreach (string customFmt in customFmts)
           {
               try
               {
                   if (dt.ToString(customFmt).Length < 1)
                   {
                       throw new Exception("Expected a String length greater than '0' but got '" +
                           dt.ToString(customFmt).Length + "'");
                   }
               }
               catch (Exception ex)
               {
                   throw new Exception("Caught " + ex.Message + " when Trying DateTime.ToString(" + customFmt + ")");
               }
               OutputHelper.WriteLine("Successfully verified 'DateTime.ToString(" + customFmt + ")' format as: " + dt.ToString(customFmt));
           }
        }

        [TestMethod]
        public void DateTime_AddTest8()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the Add function and verifies output
            /// </summary>
            ///                       
            OutputHelper.WriteLine("Generating random DateTimes ");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            TimeSpan ts;
            Random random = new Random();
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                if (i % 2 == 0)
                {
                    ts = new TimeSpan(-random.Next(1000));
                }
                else
                {
                    ts = new TimeSpan(random.Next(1000));
                }
                OutputHelper.WriteLine("Adding '" + ts.ToString() + "' Timespan to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.Add(ts);
                Assert.Equal(dt2.Ticks, (dt1.Ticks + ts.Ticks));
            }
        }

        [TestMethod]
        public void DateTime_AddDays_PositiveTest9()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddDays function and verifies output
            /// </summary>
            /// 
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            OutputHelper.WriteLine("Adding Random +ve Days and verifying");
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double dy = random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                OutputHelper.WriteLine("Adding '" + dy + "' days to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.AddDays(dy);
                if (!CheckDeviation((long)(dt1.Ticks + (dy * TimeSpan.TicksPerDay)), dt2.Ticks))
                {
                    throw new Exception("After Adding +ve day = '" + dy + "' to a DateTime = '" + dt1 +
                        "', expected Ticks = '" + (long)(dt1.Ticks + (dy * TimeSpan.TicksPerDay)) +
                        "' but got Ticks = '" + dt2.Ticks + "'");
                }
            }
        }

        [TestMethod]
        public void DateTime_AddDays_NegativeTest10()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddDays function and verifies output
            /// </summary>
            /// 

            OutputHelper.WriteLine("This is fixed, DateTime.AddXXXX methods do not handle negative");
            OutputHelper.WriteLine("values correctly on Device, see 22728 for details");
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            OutputHelper.WriteLine("Adding Random -ve Days and verifying");
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double dy = -random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                OutputHelper.WriteLine("Adding '" + dy + "' days to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.AddDays(dy);
                if (!CheckDeviation((long)(dt1.Ticks + (dy * TimeSpan.TicksPerDay)), dt2.Ticks))
                {
                    throw new Exception("After Adding -ve day = '" + dy + "' to a DateTime = '" + dt1 +
                        "', expected Ticks = '" + (long)(dt1.Ticks + (dy * TimeSpan.TicksPerDay)) +
                        "' but got Ticks = '" + dt2.Ticks + "'");
                }
            }
        }

        [TestMethod]
        public void DateTime_AddHours_PositiveTest11()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddHours function and verifies output
            /// </summary>
            /// 

            OutputHelper.WriteLine("Generating random DateTime");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            OutputHelper.WriteLine("Adding Random +ve Hours and verifying");
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double hr = random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                OutputHelper.WriteLine("Adding '" + hr + "' hours to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.AddHours(hr);
                if (!CheckDeviation((long)(dt1.Ticks + (hr * TimeSpan.TicksPerHour)), dt2.Ticks))
                {
                    throw new Exception("After Adding +ve hour = '" + hr + "' to a DateTime = '" + dt1 +
                        "', expected Ticks = '" + (long)(dt1.Ticks + (hr * TimeSpan.TicksPerHour)) +
                        "' but got Ticks = '" + dt2.Ticks + "'");
                }
            }
        }

        [TestMethod]
        public void DateTime_AddHours_NegativeTest12()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddHours function and verifies output
            /// </summary>
            /// 

            OutputHelper.WriteLine("This is fixed, DateTime.AddXXXX methods do not handle negative");
            OutputHelper.WriteLine("values correctly on Device, see 22728 for details");
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            OutputHelper.WriteLine("Adding Random -ve Hours and verifying");
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double hr = -random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                OutputHelper.WriteLine("Adding '" + hr + "' hours to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.AddHours(hr);
                if (!CheckDeviation((long)(dt1.Ticks + (hr * TimeSpan.TicksPerHour)), dt2.Ticks))
                {
                    throw new Exception("After Adding -ve hour = '" + hr + "' to a DateTime = '" + dt1 +
                        "', expected Ticks = '" + (long)(dt1.Ticks + (hr * TimeSpan.TicksPerHour)) +
                        "' but got Ticks = '" + dt2.Ticks + "'");
                }
            }
        }

        [TestMethod]
        public void DateTime_AddMilliseconds_PositiveTest13()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddMilliseconds function and verifies output
            /// </summary>
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            OutputHelper.WriteLine("Adding Random +ve Milliseconds and verifying");
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double msec = random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                OutputHelper.WriteLine("Adding '" + msec + "' milliseconds to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.AddMilliseconds(msec);
                if (!CheckDeviation((long)(dt1.Ticks + (msec * TimeSpan.TicksPerMillisecond)), dt2.Ticks))
                {
                    throw new Exception("After Adding +ve milliseconds = '" + msec + "' to a DateTime = '" + dt1 +
                        "', expected Ticks = '" + (long)(dt1.Ticks + (msec * TimeSpan.TicksPerMillisecond)) +
                        "' but got Ticks = '" + dt2.Ticks + "'");
                }
            }
        }

        [TestMethod]
        public void DateTime_AddMilliseconds_NegativeTest14()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddMilliseconds function and verifies output
            /// </summary>
            OutputHelper.WriteLine("This is fixed, DateTime.AddXXXX methods do not handle negative");
            OutputHelper.WriteLine("values correctly on Device, see 22728 for details");
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            OutputHelper.WriteLine("Adding Random -ve Milliseconds and verifying");
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double msec = -random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                OutputHelper.WriteLine("Adding '" + msec + "' milliseconds to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.AddMilliseconds(msec);
                if (!CheckDeviation((long)(dt1.Ticks + (msec * TimeSpan.TicksPerMillisecond)), dt2.Ticks))
                {
                    throw new Exception("After Adding -ve milliseconds = '" + msec + "' to a DateTime = '" + dt1 +
                        "', expected Ticks = '" + (long)(dt1.Ticks + (msec * TimeSpan.TicksPerMillisecond)) +
                        "' but got Ticks = '" + dt2.Ticks + "'");
                }
            }
        }

        [TestMethod]
        public void DateTime_AddMinutes_PositiveTest15()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddMinutes function and verifies output
            /// </summary>
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            OutputHelper.WriteLine("Adding Random +ve Minutes and verifying");
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double mnts = random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                OutputHelper.WriteLine("Adding '" + mnts + "' minutes to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.AddMinutes(mnts);
                if (!CheckDeviation((long)(dt1.Ticks + (mnts * TimeSpan.TicksPerMinute)), dt2.Ticks))
                {
                    throw new Exception("After Adding +ve minute = '" + mnts + "' to a DateTime = '" + dt1 +
                        "', expected Ticks = '" + (long)(dt1.Ticks + (mnts * TimeSpan.TicksPerMinute)) +
                        "' but got Ticks = '" + dt2.Ticks + "'");
                }
            }
        }

        [TestMethod]
        public void DateTime_AddMinutes_NegativeTest16()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddMinutes function and verifies output
            /// </summary>
            OutputHelper.WriteLine("This is fixed, DateTime.AddXXXX methods do not handle negative");
            OutputHelper.WriteLine("values correctly on Device, see 22728 for details");
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            OutputHelper.WriteLine("Adding Random -ve Minutes and verifying");
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double mnts = -random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                OutputHelper.WriteLine("Adding '" + mnts + "' minutes to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.AddMinutes(mnts);
                if (!CheckDeviation((long)(dt1.Ticks + (mnts * TimeSpan.TicksPerMinute)), dt2.Ticks))
                {
                    throw new Exception("After Adding -ve minute = '" + mnts + "' to a DateTime = '" + dt1 +
                        "', expected Ticks = '" + (long)(dt1.Ticks + mnts * TimeSpan.TicksPerMinute) +
                        "' but got Ticks = '" + dt2.Ticks + "'");
                }
            }
        }

        [TestMethod]
        public void DateTime_AddSeconds_PositiveTest18()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddSeconds function and verifies output
            /// </summary>
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            OutputHelper.WriteLine("Adding Random +ve Seconds and verifying");
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double sec = random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                OutputHelper.WriteLine("Adding '" + sec + "' seconds to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.AddSeconds(sec);
                if (!CheckDeviation((long)(dt1.Ticks + (sec * TimeSpan.TicksPerSecond)), dt2.Ticks))
                {
                    throw new Exception("After Adding +ve seconds = '" + sec + "' to a DateTime = '" + dt1 +
                        "', expected Ticks = '" + (long)(dt1.Ticks + (sec * TimeSpan.TicksPerSecond)) +
                        "' but got Ticks = '" + dt2.Ticks + "'");
                }
            }
        }

        [TestMethod]
        public void DateTime_AddSeconds_NegativeTest19()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddSeconds function and verifies output
            /// </summary>
            OutputHelper.WriteLine("This is fixed, DateTime.AddXXXX methods do not handle negative");
            OutputHelper.WriteLine("values correctly on Device, see 22728 for details");
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            OutputHelper.WriteLine("Adding Random -ve Seconds and verifying");
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double sec = -random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                OutputHelper.WriteLine("Adding '" + sec + "' seconds to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.AddSeconds(sec);
                if (!CheckDeviation((long)(dt1.Ticks + (sec * TimeSpan.TicksPerSecond)), dt2.Ticks))
                {
                    throw new Exception("After Adding -ve seconds = '" + sec + "' to a DateTime = '" + dt1 +
                        "', expected Ticks = '" + (long)(dt1.Ticks + sec * TimeSpan.TicksPerSecond) +
                        "' but got Ticks = '" + dt2.Ticks + "'");
                }
            }
        }

        [TestMethod]
        public void DateTime_AddTicks_PositiveTest20()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddTicks function and verifies output
            /// </summary>
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            OutputHelper.WriteLine("Adding Random +ve Ticks and verifying");
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                long ticks = (long)random.Next(1000);
                OutputHelper.WriteLine("Adding '" + ticks + "' ticks to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.AddTicks(ticks);
                Assert.Equal(dt2.Ticks, (dt1.Ticks + ticks));
            }
        }

        [TestMethod]
        public void DateTime_AddTicks_NegativeTest21()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddTicks function and verifies output
            /// </summary>
            OutputHelper.WriteLine("Generating random DateTime");
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            OutputHelper.WriteLine("Adding Random -ve Ticks and verifying");
            for (int i = 0; i < 10; i++)
            {
                DateTime dt1 = dt1Arr[i];
                long ticks = -(long)random.Next(1000);
                OutputHelper.WriteLine("Adding '" + ticks + "' ticks to '" + dt1.ToString() + "'");
                DateTime dt2 = dt1.AddTicks(ticks);
                Assert.Equal(dt2.Ticks, (dt1.Ticks + ticks));
            }
        }

        [TestMethod]
        public void DateTime_Compare_Test23()
        {
            /// <summary>
            ///  1. Creates two DateTimes
            ///  2. Verifies that they Compare with each other
            /// </summary>
            OutputHelper.WriteLine("Creating two Random but equal DateTime b/n 1000 - 9000");
            OutputHelper.WriteLine("Comparing eachother with DateTime.Compare and Verifying");
            DateTime dt1 = DateTime_btwn_1801_And_2801();
            DateTime dt2 = new DateTime(year, month, day, hour, minute, second, millisec);
            OutputHelper.WriteLine("Comparing equal DateTimes and Verifying");
            if (DateTime.Compare(dt1, dt2) != 0)
            {
                throw new Exception("Expected DateTime.Compare(" + dt1.ToString() + ", " + dt2.ToString() +
                    ") returns '0' but got '" + DateTime.Compare(dt1, dt2) + "'");
            }
            OutputHelper.WriteLine("Comparing Unequal DateTimes and Verifying");
            dt2 = dt1.Add(new TimeSpan(1));
            if (DateTime.Compare(dt1, dt2) >= 0)
            {
                throw new Exception("Expected DateTime.Compare(" + dt1.ToString() + ", " + dt2.ToString() +
                    ") returns '-ve' value but got '" + DateTime.Compare(dt1, dt2) + "'");
            }
            if (DateTime.Compare(dt2, dt1) <= 0)
            {
                throw new Exception("Expected DateTime.CompareTo(" + dt1.ToString() + ", " + dt2.ToString() +
                     ") returns '+ve' value but got '" + DateTime.Compare(dt1, dt2) + "'");
            }
        }


        [TestMethod]
        public void DateTime_DaysInMonth_Test24()
        {
            /// <summary>
            ///  1. Verifies the accuracy of the DaysInMonth method
            /// </summary>        
            OutputHelper.WriteLine("Generates a random year and month, and");
            Random random = new Random();
            OutputHelper.WriteLine("Verifies the number of days in the specific month/year");
            for (int i = 0; i < 100; i++)
            {
                int yr = random.Next(9999) + 1;
                int mnth = random.Next(12) + 1;
                DaysInMonthTest(yr, mnth);
            }
            OutputHelper.WriteLine("Verifying no. of days in Feb, for 20th and 21st centuries");
            for (int yr = 1900; yr < 2100; yr += 4)
            {
                DaysInMonthTest(yr, 2);
            }
        }

        [TestMethod]
        public void DateTime_EqualsTest25()
        {
            OutputHelper.WriteLine("Creating random-equal DateTimes");
            OutputHelper.WriteLine("And Verifying they are equal");
            DateTime dt1 = DateTime_btwn_1801_And_2801();
            DateTime dt2 = new DateTime(year, month, day, hour, minute, second, millisec);
            Assert.True(DateTime.Equals(dt1, dt2));
            object obj1 = (object)dt1, obj2 = (object)dt2;
            Assert.True(object.Equals(obj1, obj2));
            Assert.True(dt1.Equals(obj2));
        }

        [TestMethod]
        public void DateTime_Subtract_DateTimeTest26()
        {
            OutputHelper.WriteLine("Creating two Random DateTimes,");
            OutputHelper.WriteLine("dt1.Subtract(dt2) and verifying");
            DateTime dt1 = GetRandomDateTime();
            DateTime dt2 = GetRandomDateTime();
            TimeSpan ts1 = dt1.Subtract(dt2);
            TimeSpan ts2 = new TimeSpan(dt1.Ticks - dt2.Ticks);

            Assert.True(ts1 == ts2);
        }

        [TestMethod]
        public void DateTime_Subtract_TimeSpanTest27()
        {
            OutputHelper.WriteLine("Creating now DateTime");
            OutputHelper.WriteLine("Subtracting random timespans and ");
            DateTime[] dtArr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            TimeSpan ts;
            for (int i = 0; i < dtArr.Length; i++)
            {
                DateTime dt1 = dtArr[i];
                if (i % 2 == 0)
                {
                    ts = new TimeSpan(-random.Next(1000));
                }
                else
                {
                    ts = -new TimeSpan(random.Next(1000));
                }

                OutputHelper.WriteLine(dt1.ToString());
                OutputHelper.WriteLine(ts.ToString());
                DateTime dt2 = dt1.Subtract(ts);
                OutputHelper.WriteLine(dt2.ToString());
                DateTime dt3 = new DateTime(dt1.Ticks - ts.Ticks);
                OutputHelper.WriteLine(dt3.ToString());
                Assert.Equal(DateTime.Compare(dt2, dt3), 0);
            }
        }

        [TestMethod]
        public void DateTime_op_AdditionTest30()
        {
            OutputHelper.WriteLine("Creating Random DateTimes,");
            OutputHelper.WriteLine("Adds a specified period of time and verifying");

            DateTime[] dtArr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            TimeSpan ts;
            for (int i = 0; i < dtArr.Length; i++)
            {
                DateTime dt1 = dtArr[i];
                if (i % 2 == 0)
                {
                    ts = new TimeSpan(-random.Next(1000));
                }
                else
                {
                    ts = new TimeSpan(random.Next(1000));
                }
                DateTime dt2 = dt1 + ts;
                DateTime dt3 = new DateTime(dt1.Ticks + ts.Ticks);
                Assert.Equal(DateTime.Compare(dt2, dt3), 0);
            }
        }

        [TestMethod]
        public void DateTime_op_Subtraction_DateTimeTest31()
        {
            OutputHelper.WriteLine("Creating Random DateTimes,");
            OutputHelper.WriteLine("Subtracting one from the other and verifying");
            DateTime[] dtArr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            for (int i = 0; i < dtArr.Length; i++)
            {
                DateTime dt1 = dtArr[i];
                DateTime dt2 = new DateTime(504911232000000000 + random.Next(1000) + 1);
                TimeSpan ts = dt1 - dt2;
                Assert.Equal(ts.Ticks, (dt1.Ticks - dt2.Ticks));
            }
        }

        [TestMethod]
        public void DateTime_op_Subtraction_TimeSpanTest32()
        {
            OutputHelper.WriteLine("Creating Random DateTime,");
            OutputHelper.WriteLine("Subtracting random TimeSpan and verifying");
            DateTime[] dtArr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            for (int i = 0; i < dtArr.Length; i++)
            {
                DateTime dt1 = dtArr[i];
                TimeSpan ts = new TimeSpan(random.Next(10000));
                DateTime dt2 = dt1 - ts;

                Assert.Equal(dt2.Ticks, (dt1.Ticks - ts.Ticks));
            }
        }

        [TestMethod]
        public void DateTime_op_EqualityTest33()
        {
            OutputHelper.WriteLine("Creating Random DateTime,");
            OutputHelper.WriteLine("Creating another DateTime equal to previous one");
            OutputHelper.WriteLine("Verifying the two DateTimes are equal using '=='");
            DateTime dt1 = GetRandomDateTime();
            DateTime dt2 = new DateTime(year, month, day, hour, minute, second, millisec);

            if (!(dt1 == dt2))
            {
                throw new Exception("Failure : expected the two DateTimes '" + dt1.ToString() +
                    "'  and '" + dt2.ToString() + "' to be equal but are not");
            }
        }

        [TestMethod]
        public void DateTime_op_InequalityTest34()
        {
            OutputHelper.WriteLine("Creating Random DateTime,");
            OutputHelper.WriteLine("Creating another Different DateTime");
            OutputHelper.WriteLine("Verifying the two DateTimes are not equal using '!='");
            DateTime dt1 = GetRandomDateTime();
            DateTime dt2 = new DateTime(year + 1, month, day, hour, minute, second, millisec);

            if (!(dt1 != dt2))
            {
                throw new Exception("Failure : expected the two DateTimes '" + dt1.ToString() +
                    "'  and '" + dt2.ToString() + "' not to be equal but are equal");
            }
        }

        [TestMethod]
        public void DateTime_op_LessThanTest35()
        {
            OutputHelper.WriteLine("Creating Random DateTime,");
            OutputHelper.WriteLine("Creating another Different DateTime greater than previous one");
            OutputHelper.WriteLine("Verifying 1st DateTime is less than 2nd using '<'");
            DateTime dt1 = GetRandomDateTime();
            DateTime dt2 = new DateTime(year + 1, month, day, hour, minute, second, millisec);

            if (!(dt1 < dt2))
            {
                throw new Exception("Failure : expected  DateTime '" + dt1.ToString() +
                    "'  less than '" + dt2.ToString() + "'");
            }
        }

        [TestMethod]
        public void DateTime_op_LessThanOrEqualTest36()
        {
            OutputHelper.WriteLine("Creating Random DateTime, Creaing 2nd equal DateTime");
            OutputHelper.WriteLine("Creating 3rd Different DateTime greater than previous two");
            OutputHelper.WriteLine("Verifying 1st DateTime is less than or equal to 2nd DateTime using '<='");
            OutputHelper.WriteLine("Verifying 1st DateTime is less than or equal to 3rd DateTime using '<='");
            DateTime dt1 = GetRandomDateTime();
            DateTime dt2 = new DateTime(year, month, day, hour, minute, second, millisec);
            DateTime dt3 = new DateTime(year + 1, month, day, hour, minute, second, millisec);
            if (!((dt1 <= dt2) || (dt2 <= dt1)))
            {
                throw new Exception("Failure : expected  DateTime '" + dt1.ToString() + "'  lessthan or equal to '" +
                    dt2.ToString() + "' (dt1 <= dt2) = '" + (dt1 <= dt2) + "' and (dt2<=dt1) = '" + (dt2 <= dt1) + "'");
            }
            if (!(dt1 <= dt3))
            {
                throw new Exception("Failure : expected  DateTime '" + dt1.ToString() +
                    "'  less than or equal to '" + dt2.ToString() + "'");
            }
        }

        [TestMethod]
        public void DateTime_op_GreaterThanTest37()
        {
            OutputHelper.WriteLine("Creating Random DateTime,");
            OutputHelper.WriteLine("Creating another Different DateTime greater than previous one");
            OutputHelper.WriteLine("Verifying 2nd DateTime is greater than 1st using '>'");
            DateTime dt1 = GetRandomDateTime();
            DateTime dt2 = new DateTime(year + 1, month, day, hour, minute, second, millisec);

            if (!(dt2 > dt1))
            {
                throw new Exception("Failure : expected  DateTime '" + dt1.ToString() +
                    "'  greater than '" + dt2.ToString() + "'");
            }
        }

        [TestMethod]
        public void DateTime_op_GreaterThanOrEqualTest38()
        {
            OutputHelper.WriteLine("Creating Random DateTime, Creaing 2nd equal DateTime");
            OutputHelper.WriteLine("Creating 3rd Different DateTime greater than previous two");
            OutputHelper.WriteLine("Verifying 1st DateTime is greater than or equal to 2nd DateTime using '>='");
            OutputHelper.WriteLine("Verifying 3rd DateTime is greater than or equal to 1st DateTime using '>='");
            DateTime dt1 = GetRandomDateTime();
            DateTime dt2 = new DateTime(year, month, day, hour, minute, second, millisec);
            DateTime dt3 = new DateTime(year + 1, month, day, hour, minute, second, millisec);
            if (!((dt1 >= dt2) || (dt2 >= dt1)))
            {
                throw new Exception("Failure : expected  DateTime '" + dt1.ToString() +
                    "'  lessthan or equal to '" + dt2.ToString() + "'");
            }
            if (!(dt1 <= dt3))
            {
                throw new Exception("Failure : expected  DateTime '" + dt1.ToString() +
                    "'  greater than or equal to '" + dt2.ToString() + "'");
            }
        }

        [TestMethod]
        public void DateTime_MinValueTest39()
        {
            /// <summary>
            ///  1. Verifies the MinValue property
            /// </summary>
            OutputHelper.WriteLine("Getting the Min. DateTime and Verifying");
            DateTime field = DateTime.MinValue;
            OutputHelper.WriteLine(field.Ticks.ToString());
            Assert.Equal(field.Ticks, 504911232000000000);
        }

        [TestMethod]
        public void DateTime_MaxValueTest40()
        {
            /// <summary>
            ///  1. Verifies the MinValue property
            /// </summary>
            OutputHelper.WriteLine("Getting the Max. DateTime and Verifying");
            DateTime field = DateTime.MaxValue;
            OutputHelper.WriteLine(field.Ticks.ToString());
            Assert.Equal(field.Ticks, 946708127999999999);
        }

        [TestMethod]
        public void DateTime_DateTest41()
        {
            /// <summary>
            ///  1. Verifies the Date property
            /// </summary>
            OutputHelper.WriteLine("Creating a DateTime, getting the Date and Verifying");
            DateTime dt = GetRandomDateTime();
            DateTime _date = dt.Date;
            if ((_date.Year != dt.Year) || (_date.Month != dt.Month) || (_date.Day != dt.Day) ||
                (_date.Hour != 0) || (_date.Minute != 0) | (_date.Second != 0) || (_date.Millisecond != 0))
            {
                throw new Exception("Failure : expected Date(mm/dd/yr/hr/mn/sec/msec) = '" + dt.Month + "/" + dt.Day +
                    "/" + dt.Year + "/0:0:0:0' but got '" + _date.Month + "/" + _date.Day + "/" +
                    _date.Year + "/" + _date.Hour + ":" + _date.Minute + ":" + _date.Second + ":" + _date.Millisecond + "'");
            }
        }

        [TestMethod]
        public void DateTime_DayTest42()
        {
            /// <summary>
            ///  1. Verifies the Day property
            /// </summary>
            OutputHelper.WriteLine("Creating a DateTime, getting the Day and Verifying");
            DateTime testDateTime = GetRandomDateTime();
            Int32 _day = testDateTime.Day;
            Assert.Equal(_day, day);
        }

        [TestMethod]
        public void DateTime_DayOfWeekTest43()
        {
            /// <summary>
            ///  1. Verifies the DayOfWeek property
            /// </summary>
            OutputHelper.WriteLine("Creating a DateTime, getting the DayOfWeek and Verifying");
            DateTime testDateTime = new DateTime(2005, 1, 28);
            DayOfWeek prop = testDateTime.DayOfWeek;
            Assert.Equal((int)prop, (int)DayOfWeek.Friday);
        }

        [TestMethod]
        public void DateTime_DayOfYearTest44()
        {
            /// <summary>
            ///  1. Verifies the DayOfYear property
            /// </summary>
            OutputHelper.WriteLine("Creating a DateTime, getting the DayOfYear and Verifying");
            OutputHelper.WriteLine("DateTime::DayOfYear - Normal ");
            DateTime testDateTime = new DateTime(2005, 1, 1);
            int _dayOfYear = testDateTime.DayOfYear;
            Assert.Equal(_dayOfYear, 1);
        }

        [TestMethod]
        public void DateTime_HourTest45()
        {
            /// <summary>
            ///  1. Verifies the Hour property
            /// </summary>
            OutputHelper.WriteLine("Creating a DateTime, getting the Hour and Verifying");
            DateTime testDateTime = GetRandomDateTime();
            Int32 _hour = testDateTime.Hour;
            Assert.Equal(_hour, hour);
        }

        [TestMethod]
        public void DateTime_MillisecondTest46()
        {
            /// <summary>
            ///  1. Verifies the Millisecond property
            /// </summary>
            OutputHelper.WriteLine("Creating a DateTime, getting the Milliseconds and Verifying");
            DateTime testDateTime = GetRandomDateTime();
            Int32 _mSec = testDateTime.Millisecond;
            Assert.Equal(_mSec, millisec);
        }

        [TestMethod]
        public void DateTime_MinuteTest47()
        {
            /// <summary>
            ///  1. Verifies the Minute property
            /// </summary>
            OutputHelper.WriteLine("Creating a DateTime, getting the Minute and Verifying");
            DateTime testDateTime = GetRandomDateTime();
            Int32 _minute = testDateTime.Minute;
            Assert.Equal(_minute, minute);
        }

        [TestMethod]
        public void DateTime_MonthTest48()
        {
            /// <summary>
            ///  1. Verifies the Month property
            /// </summary>
            OutputHelper.WriteLine("Creating a DateTime, getting the Month and Verifying");
            DateTime testDateTime = GetRandomDateTime();
            Int32 _month = testDateTime.Month;
            Assert.Equal(_month, month);
        }

        [TestMethod]
        public void DateTime_NowTest49()
        {
            /// <summary>
            /// 1. Creates 2 DateTimes
            /// 2. Verifies they are equal in all but Seconds and Millisecond
            /// </summary>
            OutputHelper.WriteLine("Creating 2 DateTimes and verifying they are equal in yy/mm/dd/hr/mn");
            DateTime test0 = DateTime.UtcNow;
            DateTime test1 = DateTime.UtcNow;
            OutputHelper.WriteLine("Verifying");
            if ((test0.Year != test1.Year) || (test0.Month != test1.Month) ||
                (test0.Day != test1.Day) || (test0.Hour != test1.Hour) ||
                (test0.Minute != test1.Minute))
            {
                throw new Exception("Failure : Expected the two DateTimes ('" + test0.ToString() +
                    "' and '" + test1.ToString() + "') are equal in all but seconds and milliseconds");
            }
        }

        [TestMethod]
        public void DateTime_SecondTest51()
        {
            /// <summary>
            ///  1. Verifies the Second property
            /// </summary>
            OutputHelper.WriteLine("Creating a DateTime, getting the Second and Verifying");
            DateTime testDateTime = GetRandomDateTime();
            Int32 _sec = testDateTime.Second;
            Assert.Equal(_sec, second);
        }

        [TestMethod]
        public void DateTime_TicksTest52()
        {
            /// <summary>
            ///  1. Verifies the Ticks property
            /// </summary>
            OutputHelper.WriteLine("Creating a DateTime, getting the Ticks and Verifying");
            DateTime testDateTime = new System.DateTime(504911232000000000);
            long _ticks = testDateTime.Ticks;
            Assert.Equal(_ticks, 504911232000000000);
        }

        [TestMethod]
        public void DateTime_YearTest54()
        {
            /// <summary>
            ///  1. Verifies the Year property
            /// </summary>
            OutputHelper.WriteLine("Creating a DateTime.Today, getting the year and Verifying");
            DateTime testDateTime = GetRandomDateTime();
            Int32 _year = testDateTime.Year;
            Assert.Equal(_year, year);
        }

        //===================================================================================
        //The Following test are commented out because they throw Debug Assert in build Envt.
        //Please see 23143 for details
        //===================================================================================    

        [TestMethod]
        public void DateTime_BelowMinDateTime_ArgumentOutOfRangeExceptionTest58()
        {
            OutputHelper.WriteLine("Creating a DateTime with -ve Ticks and,");
            OutputHelper.WriteLine("verifying ArgumentOutOfRangeException is thrown");
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { DateTime dt = new DateTime(-(new Random().Next(10) + 1)); });
        }

        [TestMethod]
        public void DateTime_AboveMaxDatTime_ArgumentOutOfRangeExceptionTest59()
        {
            OutputHelper.WriteLine("Creating a DateTime later than DateTime.MaxValue and,");
            OutputHelper.WriteLine("verifying ArgumentOutOfRangeException is thrown");
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { DateTime dt1 = new DateTime(DateTime.MaxValue.Ticks + 1); });
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { DateTime dt2 = new DateTime(10000, 1, 1, 0, 0, 0, 0); });
        }

        static double[] rdmFraction = new double[] { 0.0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 };

        static int year, month, day, hour, minute, second, millisec;

        static int[] leapYear = new int[] {2000, 2004, 2008, 2012, 2016, 2020, 2024, 2028, 2032, 2036, 2040, 2044, 2048,
                2052, 2056, 2060, 2064, 2068, 2072, 2076, 2080, 2084, 2088, 2092, 2096};

        private DateTime[] Get_ArrayOfRandomDateTimes()
        {
            OutputHelper.WriteLine(DateTime_btwn_1801_And_2801().ToString());
            OutputHelper.WriteLine(GetLeapYearDateTime().ToString());
            DateTime[] _dateTimeArr = new DateTime[] {DateTime.UtcNow,
                DateTime_btwn_1801_And_2801(), DateTime_btwn_1801_And_2801(), DateTime_btwn_1801_And_2801(),
                GetLeapYearDateTime(), GetLeapYearDateTime() , GetLeapYearDateTime(),
            DateTime_btwn_1801_And_2801(), DateTime_btwn_1801_And_2801(), DateTime_btwn_1801_And_2801(),
             GetLeapYearDateTime(), GetLeapYearDateTime(), GetLeapYearDateTime()};

            return _dateTimeArr;
        }

        private DateTime DateTime_btwn_1801_And_2801()
        {
            //Generates random DateTime b/n 1000 and 9000
            Random random = new Random();
            year = random.Next(999) + 1801;
            month = random.Next(12) + 1;
            if (month == 2 && IsLeapYear(year))
                day = random.Next(29) + 1;
            else if (month == 2 && (!IsLeapYear(year)))
                day = random.Next(28) + 1;
            else if (((month <= 7) && ((month + 1) % 2 == 0)) ||
                ((month > 7) && ((month % 2) == 0)))
                day = random.Next(31) + 1;
            else
                day = random.Next(30) + 1;
            hour = random.Next(24);
            minute = random.Next(60);
            second = random.Next(60);
            millisec = random.Next(1000);

            return new DateTime(year, month, day, hour, minute, second, millisec);
        }

        private DateTime GetRandomDateTime()
        {
            //Generates random DateTime
            Random random = new Random();
            year = random.Next(1399) + 1601;
            month = random.Next(12) + 1;
            if (month == 2 && IsLeapYear(year))
                day = random.Next(29) + 1;
            else if (month == 2 && (!IsLeapYear(year)))
                day = random.Next(28) + 1;
            else if (((month <= 7) && ((month + 1) % 2 == 0)) ||
                ((month > 7) && ((month % 2) == 0)))
                day = random.Next(31) + 1;
            else
                day = random.Next(30) + 1;
            hour = random.Next(24);
            minute = random.Next(60);
            second = random.Next(60);
            millisec = random.Next(1000);

            return new DateTime(year, month, day, hour, minute, second, millisec);
        }

        private DateTime GetLeapYearDateTime()
        {
            Random random = new Random();
            year = leapYear[random.Next(leapYear.Length)];
            month = random.Next(12) + 1;
            day = random.Next(29) + 1;
            hour = random.Next(24);
            minute = random.Next(60);
            second = random.Next(60);
            millisec = random.Next(1000);
            OutputHelper.WriteLine($"{year} {month} {day} {hour} {minute} {second} {millisec}");
            return new DateTime(year, month, day, hour, minute, second, millisec);
        }

        private bool IsLeapYear(int yr)
        {
            if ((yr % 400 == 0) || ((yr % 100 != 0) && (yr % 4 == 0)))
                return true;
            else
                return false;
        }

        private bool CheckDeviation(long dTicks1, long dTicks2)
        {
            long diff = dTicks2 - dTicks1;
            diff = diff < 0 ? -diff : diff;
            //fail if deviates by more than 0.05ms (500 ticks)
            if (diff > 500)
            {
                OutputHelper.WriteLine("Difference ticks = '" + diff.ToString() + "'");
                return false;
            }
            return true;
        }

        public void DaysInMonthTest(int yr, int mnth)
        {
            int daysInMonth = DateTime.DaysInMonth(yr, mnth);
            OutputHelper.WriteLine("Got " + daysInMonth + " number of days in " + mnth + "/" + yr + " mm/yr");
            if (mnth == 2)
            {
                if (IsLeapYear(yr))
                {
                    OutputHelper.WriteLine("Year '" + yr + "' is a LeapYear, expected '29' days but got '" +
                        daysInMonth + "' in Month '" + mnth + "'");
                    Assert.Equal(daysInMonth, 29);
                }
                else if (daysInMonth != 28)
                {
                    throw new Exception("Year '" + yr + "' Month '" + mnth +
                        "', expected '28' days but got '" + daysInMonth + "'");
                }
            }
            else if (((mnth <= 7) && ((mnth + 1) % 2 == 0)) ||
            ((mnth > 7) && ((mnth % 2) == 0)))
            {
                OutputHelper.WriteLine("Year '" + yr + "' Month '" + mnth +
                    "', expected '31' days but got '" + daysInMonth + "'");
                Assert.Equal(daysInMonth, 31);
            }
            else
            {
                OutputHelper.WriteLine("Year '" + yr + "' Month '" + mnth +
                    "', expected '30' days but got '" + daysInMonth + "'");
                Assert.Equal(daysInMonth, 30);
            }
        }
    }
}
