//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Globalization;

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

            // Creating new DateTime Object
            DateTime dt = new DateTime();
            OutputHelper.WriteLine(dt.ToString());
            Type type = dt.GetType();
            // Verifying its type
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

            // Generating 10 random DateTime and Verifying
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
            // Creating Minimum DateTime and verifying
            DateTime minDT1 = DateTime.MinValue;
            DateTime minDT2 = new DateTime();
            DateTime minDT3 = new DateTime(504911232000000000);
            DateTime minDT4 = new DateTime(1601, 1, 1, 0, 0, 0, 0);

            if ((DateTime.Compare(minDT1, minDT2) != 0) ||
                (DateTime.Compare(minDT2, minDT3) != 0) ||
                (DateTime.Compare(minDT3, minDT4) != 0))
            {
                // DateTime.MinValue = '" + minDT1.Ticks + "'ticks,
                //  new DateTime() = '" + minDT2.Ticks + "'ticks,
                // new DateTime(0) = '" + minDT3.Ticks + "'ticks.
                throw new Exception("Expected 'DateTime.MinValue' is equal to 'new DateTime()', " +
                    "equal to 'new DateTime(0)', equal to 'new DateTime(1, 1, 1, 0, 0, 0, 0)' but got ");
            }

            // Creating Maximum DateTime and verifying
            DateTime maxDateTime = new DateTime(946708127999999999);
            Assert.IsTrue(DateTime.MaxValue.Equals(maxDateTime));
        }

        [TestMethod]
        public void DateTime_CompareToTest4()
        {
            /// <summary>
            ///  1. Creates random DateTimes
            ///  2. Verifies that they CompareTo each other
            /// </summary>
            /// 
            // Generating random DateTimes b/n 1000 - 9000
            // comparing eachother with DateTime.CompareTo and verifying
            DateTime dt1 = DateTime_btwn_1801_And_2801();
            DateTime dt2 = new DateTime(year, month, day, hour, minute, second, millisec);
            // Comparing two equal DateTimes
            Assert.AreEqual(dt1.CompareTo(dt2), 0);
            // Comparing Unequal DateTimes and Verifying
            dt2 = dt1.Add(new TimeSpan(1));
            Assert.IsFalse(dt1.CompareTo(dt2) >= 0);
            Assert.IsFalse(dt2.CompareTo(dt1) <= 0);
        }

        [TestMethod]
        public void DateTime_EqualsTest5()
        {
            /// <summary>
            ///  1. Creates two DateTimes
            ///  2. Verifies that they Equals each other
            /// </summary>
            /// 
            // Generating random DateTime
            DateTime dt1 = GetRandomDateTime();
            DateTime dt2 = new DateTime(ticks);
            Assert.IsTrue(dt1.Equals(dt2));
        }

        [TestMethod]
        public void DateTime_ToStringTest06()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies that it correctly returns a string from ToString
            /// </summary>
            /// 
            // Generating random DateTime
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
            Assert.AreEqual(dt.ToString(), str);
        }

        [TestMethod]
        public void DateTime_ToStringTest08()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // DateTime.ToString(String) using specified formats and Verifying

            // ShortDatePattern
            string specifier1 = "d";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                // expected format is MM/dd/yyyy

                int length = 10;

                // check length
                Assert.IsTrue(length == dtOutput1.Length, $"Wrong output1 length: {dtOutput1.Length}, should have been {length}");

                // check 'MM'
                Assert.AreEqual(dt.Month, int.Parse(dtOutput1.Substring(0, 2)), "Wrong output1 in for 'MM'");
                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(3, 2)), "Wrong output1 in for 'dd'");
                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(6, 4)), "Wrong output1 for 'yyyy'");
                
                // check '/'
                Assert.AreEqual("/", dtOutput1.Substring(2, 1), "Wrong output1 in for '-'");
                Assert.AreEqual("/", dtOutput1.Substring(5, 1), "Wrong output1 in for '-'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest09()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // LongDatePattern
            var specifier1 = "D";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                // expected format is dddd, dd MMMM yyyy

                int minLength = 19;

                // check length
                Assert.IsTrue(dtOutput1.Length >= minLength, $"Wrong output1 length: {dtOutput1.Length}, should have been at least {minLength}");

                // check 'dddd'
                int endIndex = dtOutput1.IndexOf(',');
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.DayNames[(int)dt.DayOfWeek],
                    dtOutput1.Substring(0, endIndex),
                    "Wrong output1 for 'dddd'");

                // check ','
                Assert.AreEqual(",", dtOutput1.Substring(endIndex, 1), "Wrong output1 in for ','");
                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex + 1, 1), "Wrong output1 in for ' '");
                
                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(endIndex + 2, 2)), "Wrong output1 in for 'dd'");
                
                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex + 4, 1), "Wrong output1 in for ' '");

                // check 'MMMM'
                var startIndex = dtOutput1.IndexOf(' ', endIndex + 2);
                endIndex = dtOutput1.IndexOf(' ', startIndex + 1);
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.MonthNames[dt.Month - 1],
                    dtOutput1.Substring(startIndex + 1, endIndex - 1 - startIndex),
                    "Wrong output1 in for 'MMMM'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex, 1), "Wrong output1 in for ' '");

                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(endIndex + 1, 4)), "Wrong output1 for 'yyyy'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }

        }

        [TestMethod]
        public void DateTime_ToStringTest10()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // full date / short time
            var specifier1 = "f";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                // expected format is dddd, dd MMMM yyyy HH:mm

                int minLength = 25;
                int actualLength = dtOutput1.Length;

                // check length
                Assert.IsTrue(dtOutput1.Length >= minLength, $"Wrong output1 length: {dtOutput1.Length}, should have been at least {minLength}");


                // check 'dddd'
                int endIndex = dtOutput1.IndexOf(',');
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.DayNames[(int)dt.DayOfWeek],
                    dtOutput1.Substring(0, endIndex),
                    "Wrong output1 for 'dddd'");

                // check ','
                Assert.AreEqual(",", dtOutput1.Substring(endIndex, 1), "Wrong output1 in for ','");
                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex + 1, 1), "Wrong output1 in for ' '");

                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(endIndex + 2, 2)), "Wrong output1 in for 'dd'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex + 4, 1), "Wrong output1 in for ' '");

                // check 'MMMM'
                var startIndex = dtOutput1.IndexOf(' ', endIndex + 2);
                endIndex = dtOutput1.IndexOf(' ', startIndex + 1);
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.MonthNames[dt.Month - 1],
                    dtOutput1.Substring(startIndex + 1, endIndex - 1 - startIndex),
                    "Wrong output1 in for 'MMMM'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex, 1), "Wrong output1 in for ' '");

                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(endIndex + 1, 4)), "Wrong output1 for 'yyyy'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex + 5, 1), "Wrong output1 in for ' '");

                startIndex = endIndex + 6;

                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(startIndex, 2)), "Wrong output1 in for 'HH'");

                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(startIndex + 3, 2)), "Wrong output1 in for 'mm'");

                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(startIndex + 2, 1), "Wrong output1 in for ':'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest11()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // full date / long time
            var specifier1 = "F";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                // expected format is dddd, dd MMMM yyyy HH:mm:ss

                int minLength = 26;
                int actualLength = dtOutput1.Length;

                // check length
                Assert.IsTrue(dtOutput1.Length >= minLength, $"Wrong output1 length: {dtOutput1.Length}, should have been at least {minLength}");

                // check 'dddd'
                int endIndex = dtOutput1.IndexOf(',');
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.DayNames[(int)dt.DayOfWeek],
                    dtOutput1.Substring(0, endIndex),
                    "Wrong output1 for 'dddd'");

                // check ','
                Assert.AreEqual(",", dtOutput1.Substring(endIndex, 1), "Wrong output1 in for ','");
                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex + 1, 1), "Wrong output1 in for ' '");

                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(endIndex + 2, 2)), "Wrong output1 in for 'dd'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex + 4, 1), "Wrong output1 in for ' '");

                // check 'MMMM'
                var startIndex = dtOutput1.IndexOf(' ', endIndex + 2);
                endIndex = dtOutput1.IndexOf(' ', startIndex + 1);
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.MonthNames[dt.Month - 1],
                    dtOutput1.Substring(startIndex + 1, endIndex - 1 - startIndex),
                    "Wrong output1 in for 'MMMM'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex, 1), "Wrong output1 in for ' '");

                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(endIndex + 1, 4)), "Wrong output1 for 'yyyy'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex + 5, 1), "Wrong output1 in for ' '");

                startIndex = endIndex + 6;

                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(startIndex, 2)), "Wrong output1 in for 'HH'");

                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(startIndex + 3, 2)), "Wrong output1 in for 'mm'");

                // check 'ss'
                Assert.AreEqual(dt.Second, int.Parse(dtOutput1.Substring(startIndex + 6, 2)), "Wrong output1 in for 'ss'");

                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(startIndex + 2, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput1.Substring(startIndex + 5, 1), "Wrong output1 in for ':'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }
        
        [TestMethod]
        public void DateTime_ToStringTest12()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // short date / short time
            var specifier1 = "g";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                // expected format is MM/dd/yyyy HH:mm

                int length = 16;

                // check length
                Assert.IsTrue(length == dtOutput1.Length, $"Wrong output1 length: {dtOutput1.Length}, should have been {length}");

                // check 'MM'
                Assert.AreEqual(dt.Month, int.Parse(dtOutput1.Substring(0, 2)), "Wrong output1 in for 'MM'");
                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(3, 2)), "Wrong output1 in for 'dd'");
                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(6, 4)), "Wrong output1 for 'yyyy'");
                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(11, 2)), "Wrong output1 in for 'HH'");
                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(14, 2)), "Wrong output1 in for 'mm'");

                // check '/'
                Assert.AreEqual("/", dtOutput1.Substring(2, 1), "Wrong output1 in for '/'");
                Assert.AreEqual("/", dtOutput1.Substring(5, 1), "Wrong output1 in for '/'");
                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(10, 1), "Wrong output1 in for ' '");
                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(13, 1), "Wrong output1 in for ':'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }

        }

        [TestMethod]
        public void DateTime_ToStringTest13()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // short date / long time
            var specifier1 = "G";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                // expected format is MM/dd/yyyy HH:mm:ss

                int length = 19;

                // check length
                Assert.IsTrue(length == dtOutput1.Length, $"Wrong output1 length: {dtOutput1.Length}, should have been {length}");

                // check 'MM'
                Assert.AreEqual(dt.Month, int.Parse(dtOutput1.Substring(0, 2)), "Wrong output1 in for 'MM'");
                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(3, 2)), "Wrong output1 in for 'dd'");
                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(6, 4)), "Wrong output1 for 'yyyy'");
                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(11, 2)), "Wrong output1 in for 'HH'");
                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(14, 2)), "Wrong output1 in for 'mm'");
                // check 'ss'
                Assert.AreEqual(dt.Second, int.Parse(dtOutput1.Substring(17, 2)), "Wrong output1 in for 'ss'");

                // check '/'
                Assert.AreEqual("/", dtOutput1.Substring(2, 1), "Wrong output1 in for '/'");
                Assert.AreEqual("/", dtOutput1.Substring(5, 1), "Wrong output1 in for '/'");
                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(10, 1), "Wrong output1 in for ' '");
                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(13, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput1.Substring(16, 1), "Wrong output1 in for ':'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest14()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // MonthDayPattern
            var specifier1 = "M";
            var specifier2 = "m";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}' and '{specifier2}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);
                string dtOutput2 = dt.ToString(specifier2);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                // expected format is MMMM dd

                int minLength = 6;

                // check length
                Assert.IsTrue(dtOutput1.Length >= minLength, $"Wrong output1 length: {dtOutput1.Length}, should have been at least {minLength}");
                Assert.IsTrue(dtOutput2.Length >= minLength, $"Wrong output1 length: {dtOutput2.Length}, should have been at least {minLength}");

                // check 'MMMM'
                var endIndex = dtOutput1.IndexOf(' ');
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.MonthNames[dt.Month - 1],
                    dtOutput1.Substring(0, endIndex),
                    "Wrong output1 in for 'MMMM'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex, 1), "Wrong output1 in for ' '");

                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(endIndex + 1, 2)), "Wrong output1 in for 'dd'");

                // check 'MMMM'
                endIndex = dtOutput2.IndexOf(' ');
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.MonthNames[dt.Month - 1],
                    dtOutput2.Substring(0, endIndex),
                    "Wrong output1 in for 'MMMM'");

                // check ' '
                Assert.AreEqual(" ", dtOutput2.Substring(endIndex, 1), "Wrong output1 in for ' '");

                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput2.Substring(endIndex + 1, 2)), "Wrong output1 in for 'dd'");

            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest15()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // Round-trip ISO8601 compatible
            var specifier1 = "o";
            var specifier2 = "O";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}' and '{specifier2}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);
                string dtOutput2 = dt.ToString(specifier2);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");
                OutputHelper.WriteLine($"Output from ToString(\"{specifier2}\") was '{dtOutput2}'");

                // expected format is yyyy-MM-ddTHH:mm:ss.fffffffZ

                int length = 28;

                // check length
                Assert.IsTrue(length == dtOutput1.Length, $"Wrong output1 length: {dtOutput1.Length}, should have been {length}");
                Assert.IsTrue(length == dtOutput2.Length, $"Wrong output1 length: {dtOutput2.Length}, should have been {length}");

                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(0, 4)), "Wrong output1 for 'yyyy'");
                Assert.AreEqual(dt.Year, int.Parse(dtOutput2.Substring(0, 4)), "Wrong output2 for 'yyyy'");
                // check 'MM'
                Assert.AreEqual(dt.Month, int.Parse(dtOutput1.Substring(5, 2)), "Wrong output1 in for 'MM'");
                Assert.AreEqual(dt.Month, int.Parse(dtOutput2.Substring(5, 2)), "Wrong output2 in for 'MM'");
                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(8, 2)), "Wrong output1 in for 'dd'");
                Assert.AreEqual(dt.Day, int.Parse(dtOutput2.Substring(8, 2)), "Wrong output2 in for 'dd'");
                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(11, 2)), "Wrong output1 in for 'HH'");
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput2.Substring(11, 2)), "Wrong output2 in for 'HH'");
                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(14, 2)), "Wrong output1 in for 'mm'");
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput2.Substring(14, 2)), "Wrong output2 in for 'mm'");
                // check 'ss'
                Assert.AreEqual(dt.Second, int.Parse(dtOutput1.Substring(17, 2)), "Wrong output1 in for 'ss'");
                Assert.AreEqual(dt.Second, int.Parse(dtOutput2.Substring(17, 2)), "Wrong output2 in for 'ss'");

                // check 'fffffff'
                // need to do the math to get the fraction part from ticks
                var fraction = dt.Ticks % _TicksPerSecond;
                Assert.AreEqual(fraction, int.Parse(dtOutput1.Substring(20, 7)), "Wrong output1 in for 'fffffff'");
                Assert.AreEqual(fraction, int.Parse(dtOutput2.Substring(20, 7)), "Wrong output2 in for 'fffffff'");

                // check '-'
                Assert.AreEqual("-", dtOutput1.Substring(4, 1), "Wrong output1 in for '-'");
                Assert.AreEqual("-", dtOutput2.Substring(4, 1), "Wrong output2 in for '-'");
                Assert.AreEqual("-", dtOutput1.Substring(7, 1), "Wrong output1 in for '-'");
                Assert.AreEqual("-", dtOutput2.Substring(7, 1), "Wrong output2 in for '-'");
                // check 'T'
                Assert.AreEqual("T", dtOutput1.Substring(10, 1), "Wrong output1 in for 'T'");
                Assert.AreEqual("T", dtOutput2.Substring(10, 1), "Wrong output2 in for 'T'");
                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(13, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput2.Substring(13, 1), "Wrong output2 in for ':'");
                Assert.AreEqual(":", dtOutput1.Substring(16, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput2.Substring(16, 1), "Wrong output2 in for ':'");
                // check '.'
                Assert.AreEqual(".", dtOutput1.Substring(19, 1), "Wrong output1 in for '.'");
                Assert.AreEqual(".", dtOutput2.Substring(19, 1), "Wrong output2 in for '.'");
                // check 'Z'
                Assert.AreEqual("Z", dtOutput1.Substring(27, 1), "Wrong output1 in for 'Z'");
                Assert.AreEqual("Z", dtOutput2.Substring(27, 1), "Wrong output2 in for 'Z'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest16()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // RFC1123Pattern
            var specifier1 = "r";
            var specifier2 = "R";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}' and '{specifier2}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);
                string dtOutput2 = dt.ToString(specifier2);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");
                OutputHelper.WriteLine($"Output from ToString(\"{specifier2}\") was '{dtOutput2}'");

                // expected format is ddd, dd MMM yyyy HH:mm:ss GMT

                int length = 29;

                // check length
                Assert.IsTrue(length == dtOutput1.Length, $"Wrong output1 length: {dtOutput1.Length}, should have been {length}");
                Assert.IsTrue(length == dtOutput2.Length, $"Wrong output1 length: {dtOutput2.Length}, should have been {length}");

                // check 'ddd'
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.AbbreviatedDayNames[(int)dt.DayOfWeek],
                    dtOutput1.Substring(0, 3), "Wrong output1 in for 'ddd'");
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.AbbreviatedDayNames[(int)dt.DayOfWeek],
                    dtOutput2.Substring(0, 3), "Wrong output1 in for 'ddd'");

                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(5, 2)), "Wrong output1 in for 'dd'");
                Assert.AreEqual(dt.Day, int.Parse(dtOutput2.Substring(5, 2)), "Wrong output2 in for 'dd'");

                // check 'MMM'
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames[dt.Month -1],
                    dtOutput1.Substring(8, 3), "Wrong output1 in for 'MMM'");
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames[dt.Month - 1],
                    dtOutput2.Substring(8, 3), "Wrong output1 in for 'MMM'");

                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(12, 4)), "Wrong output1 for 'yyyy'");
                Assert.AreEqual(dt.Year, int.Parse(dtOutput2.Substring(12, 4)), "Wrong output2 for 'yyyy'");

                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(17, 2)), "Wrong output1 in for 'HH'");
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput2.Substring(17, 2)), "Wrong output2 in for 'HH'");

                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(20, 2)), "Wrong output1 in for 'mm'");
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput2.Substring(20, 2)), "Wrong output2 in for 'mm'");

                // check 'ss'
                Assert.AreEqual(dt.Second, int.Parse(dtOutput1.Substring(23, 2)), "Wrong output1 in for 'ss'");
                Assert.AreEqual(dt.Second, int.Parse(dtOutput2.Substring(23, 2)), "Wrong output2 in for 'ss'");

                // check ','
                Assert.AreEqual(",", dtOutput1.Substring(3, 1), "Wrong output1 in for ','");
                Assert.AreEqual(",", dtOutput2.Substring(3, 1), "Wrong output1 in for ','");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(4, 1), "Wrong output1 in for ' '");
                Assert.AreEqual(" ", dtOutput2.Substring(4, 1), "Wrong output2 in for ' '");
                Assert.AreEqual(" ", dtOutput1.Substring(7, 1), "Wrong output1 in for ' '");
                Assert.AreEqual(" ", dtOutput2.Substring(7, 1), "Wrong output2 in for ' '");
                Assert.AreEqual(" ", dtOutput1.Substring(11, 1), "Wrong output1 in for ' '");
                Assert.AreEqual(" ", dtOutput2.Substring(11, 1), "Wrong output2 in for ' '");
                Assert.AreEqual(" ", dtOutput1.Substring(16, 1), "Wrong output1 in for ' '");
                Assert.AreEqual(" ", dtOutput2.Substring(16, 1), "Wrong output2 in for ' '");
                Assert.AreEqual(" ", dtOutput1.Substring(25, 1), "Wrong output1 in for ' '");
                Assert.AreEqual(" ", dtOutput2.Substring(25, 1), "Wrong output2 in for ' '");

                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(19, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput2.Substring(19, 1), "Wrong output2 in for ':'");
                Assert.AreEqual(":", dtOutput1.Substring(22, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput2.Substring(22, 1), "Wrong output2 in for ':'");

                // check 'GMT'
                Assert.AreEqual("GMT", dtOutput1.Substring(26, 3), "Wrong output1 in for 'GMT'");
                Assert.AreEqual("GMT", dtOutput2.Substring(26, 3), "Wrong output2 in for 'GMT'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest17()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // SortableDateTimePattern
            var specifier1 = "s";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                // expected format is yyyy-MM-ddTHH:mm:ss

                int length = 19;

                // check length
                Assert.IsTrue(length == dtOutput1.Length, $"Wrong output1 length: {dtOutput1.Length}, should have been {length}");

                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(0, 4)), "Wrong output1 for 'yyyy'");
                // check 'MM'
                Assert.AreEqual(dt.Month, int.Parse(dtOutput1.Substring(5, 2)), "Wrong output1 in for 'MM'");
                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(8, 2)), "Wrong output1 in for 'dd'");
                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(11, 2)), "Wrong output1 in for 'HH'");
                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(14, 2)), "Wrong output1 in for 'mm'");
                // check 'ss'
                Assert.AreEqual(dt.Second, int.Parse(dtOutput1.Substring(17, 2)), "Wrong output1 in for 'ss'");

                // check '-'
                Assert.AreEqual("-", dtOutput1.Substring(4, 1), "Wrong output1 in for '-'");
                Assert.AreEqual("-", dtOutput1.Substring(7, 1), "Wrong output1 in for '-'");

                // check 'T'
                Assert.AreEqual("T", dtOutput1.Substring(10, 1), "Wrong output1 in for 'T'");

                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(13, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput1.Substring(16, 1), "Wrong output1 in for ':'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest18()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // long time
            var specifier1 = "T";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                // expected format is HH:mm:ss

                int length = 8;
        
                // check length
                Assert.IsTrue(dtOutput1.Length >= length, $"Wrong output1 length: {dtOutput1.Length}, should have been at least {length}");

                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(0, 2)), "Wrong output1 in for 'HH'");
                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(3, 2)), "Wrong output1 in for 'mm'");
                // check 'ss'
                Assert.AreEqual(dt.Second, int.Parse(dtOutput1.Substring(6, 2)), "Wrong output1 in for 'ss'");

                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(2, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput1.Substring(5, 1), "Wrong output1 in for ':'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest19()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // short time
            var specifier1 = "t";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                // expected format is HH:mm

                int length = 5;

                // check length
                Assert.IsTrue(dtOutput1.Length >= length, $"Wrong output1 length: {dtOutput1.Length}, should have been at least {length}");

                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(0, 2)), "Wrong output1 in for 'HH'");
                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(3, 2)), "Wrong output1 in for 'mm'");

                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(2, 1), "Wrong output1 in for ':'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest20()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // UniversalSortableDateTimePattern
            var specifier1 = "u";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                // expected format is yyyy-MM-dd HH:mm:ssZ

                int length = 20;

                // check length
                Assert.IsTrue(length == dtOutput1.Length, $"Wrong output1 length: {dtOutput1.Length}, should have been {length}");

                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(0, 4)), "Wrong output1 for 'yyyy'");
                // check 'MM'
                Assert.AreEqual(dt.Month, int.Parse(dtOutput1.Substring(5, 2)), "Wrong output1 in for 'MM'");
                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(8, 2)), "Wrong output1 in for 'dd'");
                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(11, 2)), "Wrong output1 in for 'HH'");
                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(14, 2)), "Wrong output1 in for 'mm'");
                // check 'ss'
                Assert.AreEqual(dt.Second, int.Parse(dtOutput1.Substring(17, 2)), "Wrong output1 in for 'ss'");

                // check '-'
                Assert.AreEqual("-", dtOutput1.Substring(4, 1), "Wrong output1 in for '-'");
                Assert.AreEqual("-", dtOutput1.Substring(7, 1), "Wrong output1 in for '-'");
                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(10, 1), "Wrong output1 in for ' '");
                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(13, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput1.Substring(16, 1), "Wrong output1 in for ':'");
                // check 'Z'
                Assert.AreEqual("Z", dtOutput1.Substring(19, 1), "Wrong output1 in for 'Z'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest21()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // FullDateTimePattern
            var specifier1 = "U";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                // expected format is dddd, dd MMMM yyyy HH:mm:ss

                int minLength = 19;

                // check length
                Assert.IsTrue(dtOutput1.Length > minLength, $"Wrong output1 length: {dtOutput1.Length}, should have been at least {minLength}");

                // check 'dddd'
                int endIndex = dtOutput1.IndexOf(',');
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.DayNames[(int)dt.DayOfWeek],
                    dtOutput1.Substring(0, endIndex),
                    "Wrong output1 for 'dddd'");

                // check ','
                Assert.AreEqual(",", dtOutput1.Substring(endIndex, 1), "Wrong output1 in for ','");
                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex + 1, 1), "Wrong output1 in for ' '");

                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(endIndex + 2, 2)), "Wrong output1 in for 'dd'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex + 4, 1), "Wrong output1 in for ' '");

                // check 'MMMM'
                var startIndex = dtOutput1.IndexOf(' ', endIndex + 2);
                endIndex = dtOutput1.IndexOf(' ', startIndex + 1);
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.MonthNames[dt.Month - 1],
                    dtOutput1.Substring(startIndex + 1, endIndex - 1 - startIndex),
                    "Wrong output1 in for 'MMMM'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex, 1), "Wrong output1 in for ' '");

                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(endIndex + 1, 4)), "Wrong output1 for 'yyyy'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(endIndex + 5, 1), "Wrong output1 in for ' '");

                startIndex = endIndex + 6;

                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(startIndex, 2)), "Wrong output1 in for 'HH'");
                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(startIndex + 3, 2)), "Wrong output1 in for 'mm'");
                // check 'ss'
                Assert.AreEqual(dt.Second, int.Parse(dtOutput1.Substring(startIndex + 6, 2)), "Wrong output1 in for 'ss'");

                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(startIndex + 2, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput1.Substring(startIndex + 5, 1), "Wrong output1 in for ':'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest22()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            // YearMonthPattern
            var specifier1 = "y";
            var specifier2 = "Y";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}' and '{specifier2}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);
                string dtOutput2 = dt.ToString(specifier2);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");
                OutputHelper.WriteLine($"Output from ToString(\"{specifier2}\") was '{dtOutput2}'");

                // expected format is yyyy MMMM

                int minLength = 6;

                // check length
                Assert.IsTrue(dtOutput1.Length > minLength, $"Wrong output1 length: {dtOutput1.Length}, should have been at least {minLength}");
                Assert.IsTrue(dtOutput2.Length > minLength, $"Wrong output1 length: {dtOutput2.Length}, should have been at least {minLength}");

                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(0, 4)), "Wrong output1 for 'yyyy'");
                Assert.AreEqual(dt.Year, int.Parse(dtOutput2.Substring(0, 4)), "Wrong output2 for 'yyyy'");

                // check 'MMMM'
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.MonthNames[dt.Month - 1],
                    dtOutput1.Substring(5, dtOutput1.Length - 5),
                    "Wrong output1 in for 'MMMM'");
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.MonthNames[dt.Month - 1],
                    dtOutput1.Substring(5, dtOutput2.Length - 5),
                    "Wrong output1 in for 'MMMM'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(4, 1), "Wrong output1 in for ' '");
                Assert.AreEqual(" ", dtOutput2.Substring(4, 1), "Wrong output2 in for ' '");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest23()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            var specifier1 = "h:mm:ss.ff t";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                int minLength = 12;

                // check length
                Assert.IsTrue(dtOutput1.Length >= minLength, $"Wrong output1 length: {dtOutput1.Length}, should have been at least {minLength}");

                // check 'h'
                var endIndex = dtOutput1.IndexOf(':');

                var hour12 = dt.Hour % 12;
                if (hour12 == 0)
                {
                    hour12 = 12;
                }
                Assert.AreEqual(hour12, int.Parse(dtOutput1.Substring(0, endIndex)), "Wrong output1 for 'h'");

                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(endIndex + 1, 2)), "Wrong output1 in for 'mm'");

                // check 'ss'
                Assert.AreEqual(dt.Second, int.Parse(dtOutput1.Substring(endIndex + 4, 2)), "Wrong output1 in for 'ss'");

                // check 'ff'
                // need to do the math to get the fraction part from ticks
                var fraction = dt.Ticks % _TicksPerSecond;
                Assert.AreEqual(fraction.ToString("D7").Substring(0, 2), dtOutput1.Substring(endIndex + 7, 2), "Wrong output1 in for 'ff'");

                // check 't'
                if (dt.Hour < 12)
                {
                    if (CultureInfo.CurrentUICulture.DateTimeFormat.AMDesignator.Length >= 1)
                    {
                        Assert.AreEqual(CultureInfo.CurrentUICulture.DateTimeFormat.AMDesignator[0].ToString(), dtOutput1.Substring(dtOutput1.Length - 1, 1), "Wrong output1 in for 't'");
                    }
                }
                else
                {
                    Assert.AreEqual(CultureInfo.CurrentUICulture.DateTimeFormat.PMDesignator[0].ToString(), dtOutput1.Substring(dtOutput1.Length - 1, 1), "Wrong output1 in for 't'");
                }

                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(endIndex, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput1.Substring(endIndex + 3, 1), "Wrong output1 in for ':'");

                // check '.'
                Assert.AreEqual(".", dtOutput1.Substring(endIndex + 6, 1), "Wrong output1 in for '.'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest24()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            var specifier1 = "d MMM yyyy";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                int minLength = 10;

                // check length
                Assert.IsTrue(dtOutput1.Length >= minLength, $"Wrong output1 length: {dtOutput1.Length}, should have been at least {minLength}");

                // check 'd'
                var endIndex = dtOutput1.IndexOf(' ');
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(0, endIndex)), "Wrong output1 in for 'd'");

                // check 'MMM'
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames[dt.Month - 1],
                    dtOutput1.Substring(endIndex + 1, 3), "Wrong output1 in for 'MMM'");

                // check 'yyyy'
                Assert.AreEqual(dt.Year, int.Parse(dtOutput1.Substring(endIndex + 5, 4)), "Wrong output1 for 'yyyy'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest25()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            var specifier1 = "HH:mm:ss.f";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                int length = 10;

                // check length
                Assert.IsTrue(dtOutput1.Length == length, $"Wrong output1 length: {dtOutput1.Length}, should have been {length}");

                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(0, 2)), "Wrong output1 in for 'HH'");

                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(3, 2)), "Wrong output1 in for 'mm'");

                // check 'ss'
                Assert.AreEqual(dt.Second, int.Parse(dtOutput1.Substring(6, 2)), "Wrong output1 in for 'ss'");

                // check 'f'
                // need to do the math to get the fraction part from ticks
                var fraction = dt.Ticks % _TicksPerSecond;
                Assert.AreEqual(fraction.ToString("D7").Substring(0, 1), dtOutput1.Substring(9, 1), "Wrong output1 in for 'f'");

                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(2, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput1.Substring(5, 1), "Wrong output1 in for ':'");

                // check '.'
                Assert.AreEqual(".", dtOutput1.Substring(8, 1), "Wrong output1 in for '.'");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest26()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            var specifier1 = "dd MMM HH:mm:ss";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                int length = 15;

                // check length
                Assert.IsTrue(dtOutput1.Length == length, $"Wrong output1 length: {dtOutput1.Length}, should have been {length}");

                // check 'dd'
                Assert.AreEqual(dt.Day, int.Parse(dtOutput1.Substring(0, 2)), "Wrong output1 in for 'dd'");

                // check 'MMM'
                Assert.AreEqual(
                    DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames[dt.Month - 1],
                    dtOutput1.Substring(3, 3),
                    "Wrong output1 in for 'MMM'");

                // check 'HH'
                Assert.AreEqual(dt.Hour, int.Parse(dtOutput1.Substring(7, 2)), "Wrong output1 in for 'HH'");

                // check 'mm'
                Assert.AreEqual(dt.Minute, int.Parse(dtOutput1.Substring(7+3, 2)), "Wrong output1 in for 'mm'");

                // check 'ss'
                Assert.AreEqual(dt.Second, int.Parse(dtOutput1.Substring(7+6, 2)), "Wrong output1 in for 'ss'");

                // check ':'
                Assert.AreEqual(":", dtOutput1.Substring(7+2, 1), "Wrong output1 in for ':'");
                Assert.AreEqual(":", dtOutput1.Substring(7+5, 1), "Wrong output1 in for ':'");

                // check ' '
                Assert.AreEqual(" ", dtOutput1.Substring(2, 1), "Wrong output1 in for ' '");
                Assert.AreEqual(" ", dtOutput1.Substring(6, 1), "Wrong output1 in for ' '");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
            }
        }

        [TestMethod]
        public void DateTime_ToStringTest27()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Verifies DateTime.ToString (String) returns correct String using a specified format
            /// </summary>
            // Generating random DateTime

            DateTime dt = GetRandomDateTime();

            OutputHelper.WriteLine($"Test DateTime is: {dt}");

            var specifier1 = @"\Mon\t\h\: M";

            OutputHelper.WriteLine($"Testing specified format(s): '{specifier1}'");

            try
            {
                string dtOutput1 = dt.ToString(specifier1);

                OutputHelper.WriteLine($"Output from ToString(\"{specifier1}\") was '{dtOutput1}'");

                int minLength = 8;

                // check length
                Assert.IsTrue(dtOutput1.Length >= minLength, $"Wrong output1 length: {dtOutput1.Length}, should have been at least {minLength}");

                // check 'M'
                Assert.AreEqual(dt.Month, int.Parse(dtOutput1.Substring(7)), "Wrong output1 in for 'M'");

                // check 'Month: '
                Assert.AreEqual("Month: ", dtOutput1.Substring(0, 7), "Wrong output1 in for 'Month: '");
            }
            catch (Exception ex)
            {
                throw new Exception($"Caught {ex.Message} when Trying DateTime.ToString(\"{specifier1}\")");
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
            // Generating random DateTimes 
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
                // Adding '" + ts.ToString() + "' Timespan to '" + dt1.ToString() + "'
                DateTime dt2 = dt1.Add(ts);
                Assert.AreEqual(dt2.Ticks, (dt1.Ticks + ts.Ticks));
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
            // Generating random DateTime
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            // Adding Random +ve Days and verifying
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double dy = random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                // Adding '" + dy + "' days to '" + dt1.ToString() + "'
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

            // This is fixed, DateTime.AddXXXX methods do not handle negative
            // values correctly on Device, see 22728 for details
            // Generating random DateTime
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            // Adding Random -ve Days and verifying
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double dy = -random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                // Adding '" + dy + "' days to '" + dt1.ToString() + "'
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

            // Generating random DateTime
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            // Adding Random +ve Hours and verifying
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double hr = random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                // Adding '" + hr + "' hours to '" + dt1.ToString() + "'
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

            // This is fixed, DateTime.AddXXXX methods do not handle negative
            // values correctly on Device, see 22728 for details
            // Generating random DateTime
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            // Adding Random -ve Hours and verifying
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double hr = -random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                // Adding '" + hr + "' hours to '" + dt1.ToString() + "'
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
            // Generating random DateTime
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            // Adding Random +ve Milliseconds and verifying
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double msec = random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                // Adding '" + msec + "' milliseconds to '" + dt1.ToString() + "'
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
            // This is fixed, DateTime.AddXXXX methods do not handle negative
            // values correctly on Device, see 22728 for details
            // Generating random DateTime
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            // Adding Random -ve Milliseconds and verifying
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double msec = -random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                // Adding '" + msec + "' milliseconds to '" + dt1.ToString() + "'
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
            // Generating random DateTime
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            // Adding Random +ve Minutes and verifying
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double mnts = random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                // Adding '" + mnts + "' minutes to '" + dt1.ToString() + "'
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
            // This is fixed, DateTime.AddXXXX methods do not handle negative
            // values correctly on Device, see 22728 for details
            // Generating random DateTime
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            // Adding Random -ve Minutes and verifying
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double mnts = -random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                // Adding '" + mnts + "' minutes to '" + dt1.ToString() + "'
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
            // Generating random DateTime
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            // Adding Random +ve Seconds and verifying
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double sec = random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                // Adding '" + sec + "' seconds to '" + dt1.ToString() + "'
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
            // This is fixed, DateTime.AddXXXX methods do not handle negative
            // values correctly on Device, see 22728 for details
            // Generating random DateTime
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            // Adding Random -ve Seconds and verifying
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                double sec = -random.Next(1000) * rdmFraction[random.Next(rdmFraction.Length)];
                // Adding '" + sec + "' seconds to '" + dt1.ToString() + "'
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
            // Generating random DateTime
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            // Adding Random +ve Ticks and verifying
            for (int i = 0; i < dt1Arr.Length; i++)
            {
                DateTime dt1 = dt1Arr[i];
                long ticks = (long)random.Next(1000);
                // Adding '" + ticks + "' ticks to '" + dt1.ToString() + "'
                DateTime dt2 = dt1.AddTicks(ticks);
                Assert.AreEqual(dt2.Ticks, (dt1.Ticks + ticks));
            }
        }

        [TestMethod]
        public void DateTime_AddTicks_NegativeTest21()
        {
            /// <summary>
            ///  1. Creates a DateTime
            ///  2. Runs the AddTicks function and verifies output
            /// </summary>
            // Generating random DateTime
            DateTime[] dt1Arr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            // Adding Random -ve Ticks and verifying
            for (int i = 0; i < 10; i++)
            {
                DateTime dt1 = dt1Arr[i];
                long ticks = -(long)random.Next(1000);
                // Adding '" + ticks + "' ticks to '" + dt1.ToString() + "'
                DateTime dt2 = dt1.AddTicks(ticks);
                Assert.AreEqual(dt2.Ticks, (dt1.Ticks + ticks));
            }
        }

        [TestMethod]
        public void DateTime_Compare_Test23()
        {
            /// <summary>
            ///  1. Creates two DateTimes
            ///  2. Verifies that they Compare with each other
            /// </summary>
            // Creating two Random but equal DateTime b/n 1000 - 9000
            // Comparing eachother with DateTime.Compare and Verifying
            DateTime dt1 = DateTime_btwn_1801_And_2801();
            DateTime dt2 = new DateTime(year, month, day, hour, minute, second, millisec);
            // Comparing equal DateTimes and Verifying
            if (DateTime.Compare(dt1, dt2) != 0)
            {
                throw new Exception("Expected DateTime.Compare(" + dt1.ToString() + ", " + dt2.ToString() +
                    ") returns '0' but got '" + DateTime.Compare(dt1, dt2) + "'");
            }
            // Comparing Unequal DateTimes and Verifying
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
            // Generates a random year and month, and
            Random random = new Random();
            // Verifies the number of days in the specific month/year
            for (int i = 0; i < 100; i++)
            {
                int yr = random.Next(9999) + 1;
                int mnth = random.Next(12) + 1;
                DaysInMonthTest(yr, mnth);
            }
            // Verifying no. of days in Feb, for 20th and 21st centuries
            for (int yr = 1900; yr < 2100; yr += 4)
            {
                DaysInMonthTest(yr, 2);
            }
        }

        [TestMethod]
        public void DateTime_EqualsTest25()
        {
            // Creating random-equal DateTimes
            // And Verifying they are equal
            DateTime dt1 = DateTime_btwn_1801_And_2801();
            DateTime dt2 = new DateTime(year, month, day, hour, minute, second, millisec);
            Assert.IsTrue(DateTime.Equals(dt1, dt2));
            object obj1 = (object)dt1, obj2 = (object)dt2;
            Assert.IsTrue(object.Equals(obj1, obj2));
            Assert.IsTrue(dt1.Equals(obj2));
        }

        [TestMethod]
        public void DateTime_Subtract_DateTimeTest26()
        {
            // Creating two Random DateTimes,
            // dt1.Subtract(dt2) and verifying
            DateTime dt1 = GetRandomDateTime();
            DateTime dt2 = GetRandomDateTime();
            TimeSpan ts1 = dt1.Subtract(dt2);
            TimeSpan ts2 = new TimeSpan(dt1.Ticks - dt2.Ticks);

            Assert.IsTrue(ts1 == ts2);
        }

        [TestMethod]
        public void DateTime_Subtract_TimeSpanTest27()
        {
            // Creating now DateTime
            // Subtracting random timespans and 
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
                Assert.AreEqual(DateTime.Compare(dt2, dt3), 0);
            }
        }

        [TestMethod]
        public void DateTime_op_AdditionTest30()
        {
            // Creating Random DateTimes,
            // Adds a specified period of time and verifying

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
                Assert.AreEqual(DateTime.Compare(dt2, dt3), 0);
            }
        }

        [TestMethod]
        public void DateTime_op_Subtraction_DateTimeTest31()
        {
            // Creating Random DateTimes,
            // Subtracting one from the other and verifying
            DateTime[] dtArr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            for (int i = 0; i < dtArr.Length; i++)
            {
                DateTime dt1 = dtArr[i];
                DateTime dt2 = new DateTime(504911232000000000 + random.Next(1000) + 1);
                TimeSpan ts = dt1 - dt2;
                Assert.AreEqual(ts.Ticks, (dt1.Ticks - dt2.Ticks));
            }
        }

        [TestMethod]
        public void DateTime_op_Subtraction_TimeSpanTest32()
        {
            // Creating Random DateTime,
            // Subtracting random TimeSpan and verifying
            DateTime[] dtArr = Get_ArrayOfRandomDateTimes();
            Random random = new Random();
            for (int i = 0; i < dtArr.Length; i++)
            {
                DateTime dt1 = dtArr[i];
                TimeSpan ts = new TimeSpan(random.Next(10000));
                DateTime dt2 = dt1 - ts;

                Assert.AreEqual(dt2.Ticks, (dt1.Ticks - ts.Ticks));
            }
        }

        [TestMethod]
        public void DateTime_op_EqualityTest33()
        {
            // Creating Random DateTime,
            // Creating another DateTime equal to previous one
            // Verifying the two DateTimes are equal using '=='
            DateTime dt1 = GetRandomDateTime();
            DateTime dt2 = new DateTime(dt1.Ticks);

            if (!(dt1 == dt2))
            {
                throw new Exception("Failure : expected the two DateTimes '" + dt1.ToString() +
                    "'  and '" + dt2.ToString() + "' to be equal but are not");
            }
        }

        [TestMethod]
        public void DateTime_op_InequalityTest34()
        {
            // Creating Random DateTime,
            // Creating another Different DateTime
            // Verifying the two DateTimes are not equal using '!='
            DateTime dt1 = GetRandomDateTime();
            DateTime dt2 = new DateTime(dt1.Ticks + 100);

            if (!(dt1 != dt2))
            {
                throw new Exception("Failure : expected the two DateTimes '" + dt1.ToString() +
                    "'  and '" + dt2.ToString() + "' not to be equal but are equal");
            }
        }

        [TestMethod]
        public void DateTime_op_LessThanTest35()
        {
            // Creating Random DateTime,
            // Creating another Different DateTime greater than previous one
            // Verifying 1st DateTime is less than 2nd using '<'
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
            // Creating Random DateTime, Creaing 2nd equal DateTime
            // Creating 3rd Different DateTime greater than previous two
            // Verifying 1st DateTime is less than or equal to 2nd DateTime using '<='
            // Verifying 1st DateTime is less than or equal to 3rd DateTime using '<='
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
            // Creating Random DateTime,
            // Creating another Different DateTime greater than previous one
            // Verifying 2nd DateTime is greater than 1st using '>'
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
            // Creating Random DateTime, Creaing 2nd equal DateTime
            // Creating 3rd Different DateTime greater than previous two
            // Verifying 1st DateTime is greater than or equal to 2nd DateTime using '>='
            // Verifying 3rd DateTime is greater than or equal to 1st DateTime using '>='
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
            // Getting the Min. DateTime and Verifying
            DateTime field = DateTime.MinValue;
            OutputHelper.WriteLine(field.Ticks.ToString());
            Assert.AreEqual(field.Ticks, 504911232000000000);
        }

        [TestMethod]
        public void DateTime_MaxValueTest40()
        {
            /// <summary>
            ///  1. Verifies the MinValue property
            /// </summary>
            // Getting the Max. DateTime and Verifying
            DateTime field = DateTime.MaxValue;
            OutputHelper.WriteLine(field.Ticks.ToString());
            Assert.AreEqual(field.Ticks, 946708127999999999);
        }

        [TestMethod]
        public void DateTime_DateTest41()
        {
            /// <summary>
            ///  1. Verifies the Date property
            /// </summary>
            // Creating a DateTime, getting the Date and Verifying
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
            // Creating a DateTime, getting the Day and Verifying
            DateTime testDateTime = GetRandomDateTime();
            Int32 _day = testDateTime.Day;
            Assert.AreEqual(_day, day);
        }

        [TestMethod]
        public void DateTime_DayOfWeekTest43()
        {
            /// <summary>
            ///  1. Verifies the DayOfWeek property
            /// </summary>
            // Creating a DateTime, getting the DayOfWeek and Verifying
            DateTime testDateTime = new DateTime(2005, 1, 28);
            DayOfWeek prop = testDateTime.DayOfWeek;
            Assert.AreEqual((int)prop, (int)DayOfWeek.Friday);
        }

        [TestMethod]
        public void DateTime_DayOfYearTest44()
        {
            /// <summary>
            ///  1. Verifies the DayOfYear property
            /// </summary>
            // Creating a DateTime, getting the DayOfYear and Verifying
            // DateTime::DayOfYear - Normal 
            DateTime testDateTime = new DateTime(2005, 1, 1);
            int _dayOfYear = testDateTime.DayOfYear;
            Assert.AreEqual(_dayOfYear, 1);
        }

        [TestMethod]
        public void DateTime_HourTest45()
        {
            /// <summary>
            ///  1. Verifies the Hour property
            /// </summary>
            // Creating a DateTime, getting the Hour and Verifying
            DateTime testDateTime = GetRandomDateTime();
            Int32 _hour = testDateTime.Hour;
            Assert.AreEqual(_hour, hour);
        }

        [TestMethod]
        public void DateTime_MillisecondTest46()
        {
            /// <summary>
            ///  1. Verifies the Millisecond property
            /// </summary>
            // Creating a DateTime, getting the Milliseconds and Verifying
            DateTime testDateTime = GetRandomDateTime();
            Int32 _mSec = testDateTime.Millisecond;
            Assert.AreEqual(_mSec, millisec);
        }

        [TestMethod]
        public void DateTime_MinuteTest47()
        {
            /// <summary>
            ///  1. Verifies the Minute property
            /// </summary>
            // Creating a DateTime, getting the Minute and Verifying
            DateTime testDateTime = GetRandomDateTime();
            Int32 _minute = testDateTime.Minute;
            Assert.AreEqual(_minute, minute);
        }

        [TestMethod]
        public void DateTime_MonthTest48()
        {
            /// <summary>
            ///  1. Verifies the Month property
            /// </summary>
            // Creating a DateTime, getting the Month and Verifying
            DateTime testDateTime = GetRandomDateTime();
            Int32 _month = testDateTime.Month;
            Assert.AreEqual(_month, month);
        }

        [TestMethod]
        public void DateTime_NowTest49()
        {
            /// <summary>
            /// 1. Creates 2 DateTimes
            /// 2. Verifies they are equal in all but Seconds and Millisecond
            /// </summary>
            // Creating 2 DateTimes and verifying they are equal in yy/mm/dd/hr/mn
            DateTime test0 = DateTime.UtcNow;
            DateTime test1 = DateTime.UtcNow;
            // Verifying
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
            // Creating a DateTime, getting the Second and Verifying
            DateTime testDateTime = GetRandomDateTime();
            Int32 _sec = testDateTime.Second;
            Assert.AreEqual(_sec, second);
        }

        [TestMethod]
        public void DateTime_TicksTest52()
        {
            /// <summary>
            ///  1. Verifies the Ticks property
            /// </summary>
            // Creating a DateTime, getting the Ticks and Verifying
            DateTime testDateTime = new System.DateTime(504911232000000000);
            long _ticks = testDateTime.Ticks;
            Assert.AreEqual(_ticks, 504911232000000000);
        }

        [TestMethod]
        public void DateTime_YearTest54()
        {
            /// <summary>
            ///  1. Verifies the Year property
            /// </summary>
            // Creating a DateTime.Today, getting the year and Verifying
            DateTime testDateTime = GetRandomDateTime();
            Int32 _year = testDateTime.Year;
            Assert.AreEqual(_year, year);
        }

        //===================================================================================
        //The Following test are commented out because they throw Debug Assert in build Envt.
        //Please see 23143 for details
        //===================================================================================    

        [TestMethod]
        public void DateTime_BelowMinDateTime_ArgumentOutOfRangeExceptionTest58()
        {
            // Creating a DateTime with -ve Ticks and,
            // verifying ArgumentOutOfRangeException is thrown
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { DateTime dt = new DateTime(-(new Random().Next(10) + 1)); });
        }

        [TestMethod]
        public void DateTime_AboveMaxDatTime_ArgumentOutOfRangeExceptionTest59()
        {
            // Creating a DateTime later than DateTime.MaxValue and,
            // verifying ArgumentOutOfRangeException is thrown
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { DateTime dt1 = new DateTime(DateTime.MaxValue.Ticks + 1); });
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { DateTime dt2 = new DateTime(10000, 1, 1, 0, 0, 0, 0); });
        }

        [TestMethod]
        public void DateTime_ParseTest00()
        {
            // perform 10 random conversions
            for (int i = 0; i < 10; i++)
            {
                DateTime dt = GetRandomDateTime();

                // UniversalSortableDateTimePattern
                var specifier1 = "u";

                string dtOutput1 = dt.ToString(specifier1);

                Assert.AreEqual(DateTime.Parse(dtOutput1).ToString(specifier1), dt.ToString(specifier1), $"DateTime.Parse '{dt}' failed");

                Assert.IsTrue(DateTime.TryParse(dtOutput1, out DateTime result), $"DateTime.TryParse '{dt}' failed");
                Assert.AreEqual(result.ToString(specifier1), dt.ToString(specifier1), $"DateTime.TryParse '{dt}' returning wrong value: '{result}'");
            }
        }

        [TestMethod]
        public void DateTime_ParseTest01()
        {
            // perform 10 random conversions
            for (int i = 0; i < 10; i++)
            {
                DateTime dt = GetRandomDateTime();

                // Round Trip ISO 8601 compatible
                var specifier1 = "o";

                string dtOutput1 = dt.ToString(specifier1);

                // expected format is yyyy-MM-ddTHH:mm:ss.fffffffK
                Assert.AreEqual(DateTime.Parse(dtOutput1).ToString(specifier1), dt.ToString(specifier1), $"Parsing DateTime '{dt}' failed");

                Assert.IsTrue(DateTime.TryParse(dtOutput1, out DateTime result), $"DateTime.TryParse '{dt}' failed");
                Assert.AreEqual(result.ToString(specifier1), dt.ToString(specifier1), $"DateTime.TryParse '{dt}' returning wrong value: '{result}'");
            }
        }

        [TestMethod]
        public void DateTime_ParseTest02()
        {
            // perform 10 random conversions
            for (int i = 0; i < 10; i++)
            {
                DateTime dt = GetRandomDateTime();

                // RFC 1123 date
                var specifier1 = "r";

                string dtOutput1 = dt.ToString(specifier1);

                // expected format is ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
                Assert.AreEqual(DateTime.Parse(dtOutput1).ToString(specifier1), dt.ToString(specifier1), $"Parsing DateTime '{dt}' failed");

                Assert.IsTrue(DateTime.TryParse(dtOutput1, out DateTime result), $"DateTime.TryParse '{dt}' failed");
                Assert.AreEqual(result.ToString(specifier1), dt.ToString(specifier1), $"DateTime.TryParse '{dt}' returning wrong value: '{result}'");
            }
        }

        static double[] rdmFraction = new double[] { 0.0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 };

        static int year, month, day, hour, minute, second, millisec;
        static long ticks;

        static int[] leapYear = new int[] {2000, 2004, 2008, 2012, 2016, 2020, 2024, 2028, 2032, 2036, 2040, 2044, 2048,
                2052, 2056, 2060, 2064, 2068, 2072, 2076, 2080, 2084, 2088, 2092, 2096};

        // computing our constants here, as these are not accessible
        // equivalent to  DateTime.TicksPerSecond
        const int _TicksPerSecond = 10000 * 1000;

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
            {
                day = random.Next(29) + 1;
            }
            else if (month == 2 && (!IsLeapYear(year)))
            {
                day = random.Next(28) + 1;
            }
            else if (((month <= 7) && ((month + 1) % 2 == 0))
                     || ((month > 7) && ((month % 2) == 0)))
            {
                day = random.Next(31) + 1;
            }
            else
            {
                day = random.Next(30) + 1;
            }

            hour = random.Next(24);
            minute = random.Next(60);
            second = random.Next(60);
            millisec = random.Next(1000);

            DateTime dt = new(year, month, day, hour, minute, second, millisec);

            // fill in random ticks value so we can have a fully filled ticks value
            ticks = dt.Ticks + random.Next(1000_000);

            dt = new(ticks);

            // need to update minutesm, millisec and second because it could have changed with new ticks value
            millisec = dt.Millisecond;
            second = dt.Second;
            minute = dt.Minute;

            return dt;
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
                // Difference ticks = '" + diff.ToString() + "'
                return false;
            }
            return true;
        }

        public void DaysInMonthTest(int yr, int mnth)
        {
            int daysInMonth = DateTime.DaysInMonth(yr, mnth);
            // Got " + daysInMonth + " number of days in " + mnth + "/" + yr + " mm/yr
            if (mnth == 2)
            {
                if (IsLeapYear(yr))
                {
                    OutputHelper.WriteLine("Year '" + yr + "' is a LeapYear, expected '29' days but got '" +
                        daysInMonth + "' in Month '" + mnth + "'");
                    Assert.AreEqual(daysInMonth, 29);
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
                Assert.AreEqual(daysInMonth, 31);
            }
            else
            {
                OutputHelper.WriteLine("Year '" + yr + "' Month '" + mnth +
                    "', expected '30' days but got '" + daysInMonth + "'");
                Assert.AreEqual(daysInMonth, 30);
            }
        }
    }
}
