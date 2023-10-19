//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;

namespace NFUnitTestGC
{
    [TestClass]
    public class TestGCWithDateTimeArrays
    {
        [TestMethod]
        public void TestCompactionForNotFixedDateTimeArray()
        {
            OutputHelper.WriteLine("Starting TestCompactionForNotFixedDateTimeArray");

            for (int loop = 0; loop < 10; loop++)
            {
                OutputHelper.WriteLine($"Starting iteration {loop}");
                // First we create objects and holes that keeps some space that could be used by compaction.
                // Small count so compaction does not happen. 
                HolderForDateTime[] arrayOfArrays = new HolderForDateTime[10];
                RunDateTimeAllocations(arrayOfArrays);

                // This is the array that we expect to move in during compaction.
                HolderForDateTime[] testNativeBuffer = new HolderForDateTime[100];
                // Fill it, so it is not optimized out
                for (int i = 0; i < testNativeBuffer.Length; i++)
                {
                    testNativeBuffer[i] = new HolderForDateTime(GetRandomDateTime());
                }

                OutputHelper.WriteLine("Large HolderForDateTime array created");
                OutputHelper.WriteLine("Forcing compaction to occurr");

                // Causes compaction
                InitiateDateTimeCompaction();

                OutputHelper.WriteLine("Compaction occurred");
                OutputHelper.WriteLine("Checking arrays for corrupted data...");

                int index = 0;

                // Check that array content is not corrupted
                foreach (HolderForDateTime holder in testNativeBuffer)
                {
                    Assert.AreEqual(holder.StoredTicks, holder.DtValue.Ticks, $"Array content comparison failed at position {index}. Expecting {holder.StoredTicks}, found {holder.DtValue.Ticks}");
                    index++;
                }

                OutputHelper.WriteLine("No corruption detected in array");
            }

            OutputHelper.WriteLine("Completed TestCompactionForNotFixedArray");
        }

        // This function cause compaction to occur.
        // It is not so trivial as it need to fragment heap with referenced objects.      
        void InitiateDateTimeCompaction()
        {
            // Large count, so compaction happens during RunAllocations.
            HolderForDateTime[] arrayOfArrays = new HolderForDateTime[500];
            RunDateTimeAllocations(arrayOfArrays);
        }

        private void RunDateTimeAllocations(HolderForDateTime[] arrObj)
        {
            for (int i = 1; i < arrObj.Length; i++)
            {
                // Creates referenced object, which stays in memory until InitiateCompaction exits
                arrObj[i] = new HolderForDateTime(DateTime_btwn_1801_And_2801());

                // Tries to create larger object that would be later hole
                // This object could be garbage collected on each "i" cycle
                HolderForDateTime[] arr = new HolderForDateTime[50 * i];

                // Creates some usage for array elements, so it is not optimized out
                arr[0] = new HolderForDateTime(DateTime.MinValue);
                arr[1] = new HolderForDateTime(DateTime.MaxValue);

                Console.WriteLine($"On Cycle {i:D3} DateTime holder allocated");
            }
        }

        private class HolderForDateTime
        {
            public long StoredTicks { get; }
            public DateTime DtValue { get; }

            public HolderForDateTime(DateTime dt)
            {
                StoredTicks = dt.Ticks;
                DtValue = dt;
            }
        }

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

    }
}
