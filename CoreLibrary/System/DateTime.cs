//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
namespace System
{
    using Runtime.CompilerServices;
    using Globalization;

    // Summary:
    //     Specifies whether a System.DateTime object represents a local time, a Coordinated
    //     Universal Time (UTC), or is not specified as either local time or UTC.
    /// <summary>
    /// Specifies whether a DateTime object represents a local time, a Coordinated Universal Time (UTC), or is not specified as either local time or UTC.
    /// </summary>
    [Serializable]
    public enum DateTimeKind
    {
        /// <summary>
        /// The time represented is UTC.
        /// </summary>
        Utc = 1,
        /// <summary>
        /// The time represented is local time.
        /// </summary>
        Local = 2,
    }

    // This value type represents a date and time.  Every DateTime
    // object has a private field (Ticks) of type Int64 that stores the
    // date and time as the number of 100 nanosecond intervals since
    // 12:00 AM January 1, year 1601 A.D. in the proleptic Gregorian Calendar.
    //
    // <p>For a description of various calendar issues, look at
    // <a href="http://serendipity.nofadz.com/hermetic/cal_stud.htm">
    // Calendar Studies web site</a>, at
    // http://serendipity.nofadz.com/hermetic/cal_stud.htm.
    //
    // <p>
    // <h2>Warning about 2 digit years</h2>
    // <p>As a temporary hack until we get new DateTime &lt;-&gt; String code,
    // some systems won't be able to round trip dates less than 1930.  This
    // is because we're using OleAut's string parsing routines, which look
    // at your computer's default short date string format, which uses 2 digit
    // years on most computers.  To fix this, go to Control Panel -&gt; Regional
    // Settings -&gt; Date and change the short date style to something like
    // "M/d/yyyy" (specifying four digits for the year).
    //
    /// <summary>
    /// Represents an instant in time, typically expressed as a date and time of day.
    /// </summary>
    [Serializable]
    public struct DateTime
    {
        // Number of 100ns ticks per time unit
        private const long TicksPerMillisecond = 10000;
        private const long TicksPerSecond = TicksPerMillisecond * 1000;
        private const long TicksPerMinute = TicksPerSecond * 60;
        private const long TicksPerHour = TicksPerMinute * 60;
        private const long TicksPerDay = TicksPerHour * 24;

        // Number of milliseconds per time unit
        private const int MillisPerSecond = 1000;
        private const int MillisPerMinute = MillisPerSecond * 60;
        private const int MillisPerHour = MillisPerMinute * 60;
        private const int MillisPerDay = MillisPerHour * 24;

        private const long MinTicks = 0;
        private const long MaxTicks = 441796895990000000;

        // This is mask to extract ticks from m_ticks
        private const ulong TickMask = 0x7FFFFFFFFFFFFFFFL;
        private const ulong UtcMask = 0x8000000000000000L;

        /// <summary>
        /// Represents the smallest possible value of DateTime. This field is read-only.
        /// </summary>
        /// <remarks>The value of this constant is equivalent to 00:00:00.0000000, January 1, 1601.</remarks>
        public static readonly DateTime MinValue = new DateTime(MinTicks);
        /// <summary>
        /// Represents the largest possible value of DateTime. This field is read-only.
        /// </summary>
        /// <remarks>The value of this constant is equivalent to 23:59:59.9999999, December 31, 9999, exactly one tick (100 nanoseconds) before 00:00:00, January 1, 10000.</remarks>
        public static readonly DateTime MaxValue = new DateTime(MaxTicks);

        private ulong _mTicks;

        /// <summary>
        /// Initializes a new instance of the DateTime structure to a specified number of ticks.
        /// </summary>
        /// <param name="ticks">A date and time expressed in the number of 100-nanosecond intervals. </param>
        /// <exception cref="System.ArgumentOutOfRangeException">ticks - Ticks must be between DateTime.MinValue.Ticks and DateTime.MaxValue.Ticks.</exception>
        public DateTime(long ticks)
        {
            if ((ticks & (long)TickMask) < MinTicks || (ticks & (long)TickMask) > MaxTicks)
            {
                throw new ArgumentOutOfRangeException();
            }

            _mTicks = (ulong)ticks;
        }

        /// <summary>
        /// Initializes a new instance of the DateTime structure to a specified number of ticks and to Coordinated Universal Time (UTC) or local time.
        /// </summary>
        /// <param name="ticks">A date and time expressed in the number of 100-nanosecond intervals. </param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time, Coordinated Universal Time (UTC), or neither.</param>
        public DateTime(long ticks, DateTimeKind kind)
            : this(ticks)
        {
            if (kind == DateTimeKind.Local)
            {
                _mTicks &= ~UtcMask;
            }
            else
            {
                _mTicks |= UtcMask;
            }
        }

        /// <summary>
        /// Initializes a new instance of the DateTime structure to the specified year, month, and day.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param>
        /// <param name="month">The month (1 through 12). </param>
        /// <param name="day">The day (1 through the number of days in month). </param>
        public DateTime(int year, int month, int day)
            : this(year, month, day, 0, 0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, and second.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        /// <param name="hour">The hours (0 through 23). </param>
        /// <param name="minute">The minutes (0 through 59). </param>
        /// <param name="second">The seconds (0 through 59). </param>
        public DateTime(int year, int month, int day, int hour, int minute, int second)
            : this(year, month, day, hour, minute, second, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, second, and millisecond.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        /// <param name="hour">The hours (0 through 23). </param>
        /// <param name="minute">The minutes (0 through 59). </param>
        /// <param name="second">The seconds (0 through 59). </param>
        /// <param name="millisecond">The milliseconds (0 through 999). </param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond);

        /// <summary>
        /// Returns a new DateTime that adds the value of the specified TimeSpan to the value of this instance.
        /// </summary>
        /// <param name="val">A positive or negative time interval. </param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time interval represented by val.</returns>
        public DateTime Add(TimeSpan val)
        {
            return new DateTime((long)_mTicks + val.Ticks);
        }

        private DateTime Add(double val, int scale)
        {
            return new DateTime((long)_mTicks + (long)(val * scale * TicksPerMillisecond + (val >= 0 ? 0.5 : -0.5)));
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of days to the value of this instance.
        /// </summary>
        /// <param name="val">A number of whole and fractional days. The val parameter can be negative or positive. </param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of days represented by val.</returns>
        public DateTime AddDays(double val)
        {
            return Add(val, MillisPerDay);
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of hours to the value of this instance.
        /// </summary>
        /// <param name="val">A number of whole and fractional hours. The val parameter can be negative or positive. </param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of hours represented by val.</returns>
        public DateTime AddHours(double val)
        {
            return Add(val, MillisPerHour);
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of milliseconds to the value of this instance.
        /// </summary>
        /// <param name="val">A number of whole and fractional milliseconds. The val parameter can be negative or positive. Note that this value is rounded to the nearest integer.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of milliseconds represented by val.</returns>
        public DateTime AddMilliseconds(double val)
        {
            return Add(val, 1);
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of minutes to the value of this instance.
        /// </summary>
        /// <param name="val">A number of whole and fractional minutes. The val parameter can be negative or positive. </param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of minutes represented by val.</returns>
        public DateTime AddMinutes(double val)
        {
            return Add(val, MillisPerMinute);
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of seconds to the value of this instance.
        /// </summary>
        /// <param name="val">A number of whole and fractional seconds. The val parameter can be negative or positive. </param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of seconds represented by val.</returns>
        public DateTime AddSeconds(double val)
        {
            return Add(val, MillisPerSecond);
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of ticks to the value of this instance.
        /// </summary>
        /// <param name="val">A number of 100-nanosecond ticks. The val parameter can be positive or negative. </param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time represented by val.</returns>
        public DateTime AddTicks(long val)
        {
            return new DateTime((long)_mTicks + val);
        }

        /// <summary>
        /// Compares two instances of DateTime and returns an integer that indicates whether the first instance is earlier than, the same as, or later than the second instance.
        /// </summary>
        /// <param name="t1">The first object to compare. </param>
        /// <param name="t2">The second object to compare. </param>
        /// <returns>A signed number indicating the relative values of t1 and t2.</returns>
        public static int Compare(DateTime t1, DateTime t2)
        {
            // Get ticks, clear UTC mask
            var t1Ticks = t1._mTicks & TickMask;
            var t2Ticks = t2._mTicks & TickMask;

            // Compare ticks, ignore the Kind property.
            if (t1Ticks > t2Ticks)
            {
                return 1;
            }

            if (t1Ticks < t2Ticks)
            {
                return -1;
            }

            // Values are equal
            return 0;
        }

        /// <summary>
        /// Compares the value of this instance to a specified object that contains a specified DateTime value, and returns an integer that indicates whether this instance is earlier than, the same as, or later than the specified DateTime value.
        /// </summary>
        /// <param name="val">A boxed object to compare, or nullNothingnullptrunita null reference (Nothing in Visual Basic).</param>
        /// <returns>A signed number indicating the relative values of this instance and value.</returns>
        public int CompareTo(Object val)
        {
            return val == null ? 1 : Compare(this, (DateTime)val);
        }

        /// <summary>
        /// Returns the number of days in the specified month and year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month (a number ranging from 1 to 12). </param>
        /// <returns>The number of days in month for the specified year.
        /// For example, if month equals 2 for February, the return value is 28 or 29 depending upon whether year is a leap year.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern int DaysInMonth(int year, int month);

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="val">The object to compare to this instance. </param>
        /// <returns>true if val is an instance of DateTime and equals the value of this instance; otherwise, false.</returns>
        public override bool Equals(Object val)
        {
            if (val is DateTime)
            {
                // Call compare for proper comparison of 2 DateTime objects
                // Since DateTime is optimized value and internally represented by int64
                // "this" may still have type int64.
                // Convertion to object and back is a workaround.
                object o = this;
                var thisTime = (DateTime)o;
                return Compare(thisTime, (DateTime)val) == 0;
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether two DateTime instances have the same date and time value.
        /// </summary>
        /// <param name="t1">The first object to compare. </param>
        /// <param name="t2">The second object to compare. </param>
        /// <returns>true if the two values are equal; otherwise, false.</returns>
        public static bool Equals(DateTime t1, DateTime t2)
        {
            return Compare(t1, t2) == 0;
        }

        /// <summary>
        /// Gets the date component of this instance.
        /// </summary>
        /// <value>
        /// A new object with the same date as this instance, and the time value set to 12:00:00 midnight (00:00:00).
        /// </value>
        public DateTime Date
        {
            get
            {
                // Need to remove UTC mask before arithmetic operations. Then set it back.
                return (_mTicks & UtcMask) != 0 ? new DateTime((long)(((_mTicks & TickMask) - (_mTicks & TickMask) % TicksPerDay) | UtcMask)) : new DateTime((long)(_mTicks - _mTicks % TicksPerDay));
            }
        }

        /// <summary>
        /// Gets the day of the month represented by this instance.
        /// </summary>
        /// <value>
        /// The day component, expressed as a value between 1 and 31.
        /// </value>
        public int Day
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the day of the week represented by this instance.
        /// </summary>
        /// <value>
        /// An enumerated constant that indicates the day of the week of this DateTime value.
        /// </value>
        public DayOfWeek DayOfWeek
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get
            {
                return DayOfWeek.Monday;
            }
        }

        /// <summary>
        /// Gets the day of the year represented by this instance.
        /// </summary>
        /// <value>
        /// The day of the year, expressed as a value between 1 and 366.
        /// </value>
        public int DayOfYear
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the hour component of the date represented by this instance.
        /// </summary>
        /// <value>
        /// The hour component, expressed as a value between 0 and 23.
        /// </value>
        public int Hour
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the time represented by this instance is based on local time, Coordinated Universal Time (UTC), or neither.
        /// </summary>
        /// <value>
        /// One of the enumeration values that indicates what the current time represents. The default is Local.
        /// </value>
        public DateTimeKind Kind
        {
            get
            {
                // If mask for UTC time is set - return UTC. If no maskk - return local.
                return (_mTicks & UtcMask) != 0 ? DateTimeKind.Utc : DateTimeKind.Local;
            }

        }

        /// <summary>
        /// Creates a new DateTime object that has the same number of ticks as the specified DateTime, but is designated as either local time, Coordinated Universal Time (UTC), or neither, as indicated by the specified DateTimeKind value.
        /// </summary>
        /// <param name="value">A date and time. </param>
        /// <param name="kind">One of the enumeration values that indicates whether the new object represents local time, UTC, or neither.</param>
        /// <returns>A new object that has the same number of ticks as the object represented by the value parameter and the DateTimeKind value specified by the kind parameter.</returns>
        public static DateTime SpecifyKind(DateTime value, DateTimeKind kind)
        {
            var retVal = new DateTime((long) value._mTicks)
            {
                _mTicks = kind == DateTimeKind.Utc ? value._mTicks | UtcMask : value._mTicks & ~UtcMask
            };


            return retVal;
        }

        /// <summary>
        /// Gets the milliseconds component of the date represented by this instance.
        /// </summary>
        /// <value>
        /// The milliseconds component, expressed as a value between 0 and 999.
        /// </value>
        public int Millisecond
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the minute component of the date represented by this instance.
        /// </summary>
        /// <value>
        /// The minute component, expressed as a value between 0 and 59.
        /// </value>
        public int Minute
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the month component of the date represented by this instance.
        /// </summary>
        /// <value>
        /// The month component, expressed as a value between 1 and 12.
        /// </value>
        public int Month
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets a DateTime object that is set to the current date and time on this computer, expressed as the local time.
        /// </summary>
        /// <value>
        /// An object whose value is the current local date and time.
        /// </value>
        public static DateTime Now
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get
            {
                return new DateTime();
            }
        }

        /// <summary>
        /// Gets a DateTime object that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        /// <value>
        /// An object whose value is the current UTC date and time.
        /// </value>
        public static DateTime UtcNow
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get
            {
                return new DateTime();
            }
        }

        /// <summary>
        /// Gets the seconds component of the date represented by this instance.
        /// </summary>
        /// <value>
        /// The seconds component, expressed as a value between 0 and 59.
        /// </value>
        public int Second
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get
            {
                return 0;
            }
        }

        /// Our origin is at 1601/01/01:00:00:00.000
        /// While desktop CLR's origin is at 0001/01/01:00:00:00.000.
        /// There are 504911232000000000 ticks between them which we are subtracting.
        /// See DeviceCode\PAL\time_decl.h for explanation of why we are taking
        /// year 1601 as origin for our HAL, PAL, and CLR.
// static Int64 ticksAtOrigin = 504911232000000000;
        private const Int64 TicksAtOrigin = 0;

        /// <summary>
        /// Gets the number of ticks that represent the date and time of this instance.
        /// </summary>
        /// <value>
        /// The number of ticks that represent the date and time of this instance. The value is between DateTime.MinValue.Ticks and DateTime.MaxValue.Ticks
        /// </value>
        public long Ticks
        {
            get
            {
                return (long)(_mTicks & TickMask) + TicksAtOrigin;
            }
        }

        /// <summary>
        /// Gets the time of day for this instance.
        /// </summary>
        /// <value>
        /// A time interval that represents the fraction of the day that has elapsed since midnight.
        /// </value>
        public TimeSpan TimeOfDay
        {
            get
            {
                return new TimeSpan((long)((_mTicks & TickMask) % TicksPerDay));
            }
        }

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <value>
        /// An object that is set to today's date, with the time component set to 00:00:00.
        /// </value>
        public static DateTime Today
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get
            {
                return new DateTime();
            }
        }

        /// <summary>
        /// Gets the year component of the date represented by this instance.
        /// </summary>
        /// <value>
        /// The year, between 1 and 9999.
        /// </value>
        public int Year
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Subtracts the specified date and time from this instance.
        /// </summary>
        /// <param name="val">The date and time value to subtract. </param>
        /// <returns>A time interval that is equal to the date and time represented by this instance minus the date and time represented by val.</returns>
        public TimeSpan Subtract(DateTime val)
        {
            return new TimeSpan((long)(_mTicks & TickMask) - (long)(val._mTicks & TickMask));
        }

        /// <summary>
        /// Subtracts the specified duration from this instance.
        /// </summary>
        /// <param name="val">The time interval to subtract. </param>
        /// <returns>An object that is equal to the date and time represented by this instance minus the time interval represented by val.</returns>
        public DateTime Subtract(TimeSpan val)
        {
            return new DateTime((long)(_mTicks - (ulong)val.m_ticks));
        }

        /// <summary>
        /// Converts the value of the current DateTime object to local time.
        /// </summary>
        /// <returns>An object whose Kind property is Local, and whose value is the local time equivalent to the value of the current DateTime object, or MaxValue if the converted value is too large to be represented by a DateTime object, or MinValue if the converted value is too small to be represented as a DateTime object.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern DateTime ToLocalTime();

        /// <summary>
        /// Converts the value of the current DateTime object to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the value of the current DateTime object.</returns>
        public override String ToString()
        {
            return DateTimeFormat.Format(this, null, DateTimeFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current DateTime object to its equivalent string representation using the specified format.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string (see Remarks). </param>
        /// <returns>A string representation of value of the current DateTime object as specified by format.</returns>
        public String ToString(String format)
        {
            return DateTimeFormat.Format(this, format, DateTimeFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current DateTime object to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An object whose Kind property is Utc, and whose value is the UTC equivalent to the value of the current DateTime object, or MaxValue if the converted value is too large to be represented by a DateTime object, or MinValue if the converted value is too small to be represented by a DateTime object.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern DateTime ToUniversalTime();

        /// <summary>
        /// Adds a specified time interval to a specified date and time, yielding a new date and time.
        /// </summary>
        /// <param name="d">The date and time value to add. </param>
        /// <param name="t">The time interval to add. </param>
        /// <returns>
        /// An object that is the sum of the values of d and t.
        /// </returns>
        public static DateTime operator +(DateTime d, TimeSpan t)
        {
            return new DateTime((long)(d._mTicks + (ulong)t.m_ticks));
        }


        /// <summary>
        /// Subtracts a specified time interval from a specified date and time and returns a new date and time.
        /// </summary>
        /// <param name="d">The date and time value to subtract from. </param>
        /// <param name="t">The time interval to subtract. </param>
        /// <returns>
        /// An object whose value is the value of d minus the value of t.
        /// </returns>
        public static DateTime operator -(DateTime d, TimeSpan t)
        {
            return new DateTime((long)(d._mTicks - (ulong)t.m_ticks));
        }

        /// <summary>
        /// Subtracts a specified date and time from another specified date and time and returns a time interval.
        /// </summary>
        /// <param name="d1">The date and time value to subtract from (the minuend). </param>
        /// <param name="d2">The date and time value to subtract (the subtrahend). </param>
        /// <returns>
        /// The time interval between d1 and d2; that is, d1 minus d2.
        /// </returns>
        public static TimeSpan operator -(DateTime d1, DateTime d2)
        {
            return d1.Subtract(d2);
        }

        /// <summary>
        /// Determines whether two specified instances of DateTime are equal.
        /// </summary>
        /// <param name="d1">The first object to compare. </param>
        /// <param name="d2">The second object to compare. </param>
        /// <returns>
        /// true if d1 and d2 represent the same date and time; otherwise, false.
        /// </returns>
        public static bool operator ==(DateTime d1, DateTime d2)
        {
            return Compare(d1, d2) == 0;
        }

        /// <summary>
        /// Determines whether two specified instances of DateTime are not equal.
        /// </summary>
        /// <param name="t1">The first object to compare. </param>
        /// <param name="t2">The second object to compare. </param>
        /// <returns>
        /// true if t1 and t2 do not represent the same date and time; otherwise, false.
        /// </returns>
        public static bool operator !=(DateTime t1, DateTime t2)
        {
            return Compare(t1, t2) != 0;
        }

        /// <summary>
        /// Determines whether one specified DateTime is less than another specified DateTime.
        /// </summary>
        /// <param name="t1">The first object to compare. </param>
        /// <param name="t2">The second object to compare. </param>
        /// <returns>
        /// true if t1 is less than t2; otherwise, false.
        /// </returns>
        public static bool operator <(DateTime t1, DateTime t2)
        {
            return Compare(t1, t2) < 0;
        }

        /// <summary>
        /// Determines whether one specified DateTime is less than or equal to another specified DateTime.
        /// </summary>
        /// <param name="t1">The first object to compare. </param>
        /// <param name="t2">The second object to compare. </param>
        /// <returns>
        /// true if t1 is less than or equal to t2; otherwise, false.
        /// </returns>
        public static bool operator <=(DateTime t1, DateTime t2)
        {
            return Compare(t1, t2) <= 0;
        }

        /// <summary>
        /// Determines whether one specified DateTime is greater than another specified DateTime.
        /// </summary>
        /// <param name="t1">The first object to compare. </param>
        /// <param name="t2">The second object to compare. </param>
        /// <returns>
        /// true if t1 is greater than t2; otherwise, false.
        /// </returns>
        public static bool operator >(DateTime t1, DateTime t2)
        {
            return Compare(t1, t2) > 0;
        }

        /// <summary>
        /// Determines whether one specified DateTime is greater than or equal to another specified DateTime.
        /// </summary>
        /// <param name="t1">The first object to compare. </param>
        /// <param name="t2">The second object to compare. </param>
        /// <returns>
        /// true if t1 is greater than or equal to t2; otherwise, false.
        /// </returns>
        public static bool operator >=(DateTime t1, DateTime t2)
        {
            return Compare(t1, t2) >= 0;
        }
    }
}
