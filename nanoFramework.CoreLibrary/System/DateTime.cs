//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
namespace System
{
    using Runtime.CompilerServices;
    using Globalization;
    using System.Diagnostics;

    // Summary:
    //     Specifies whether a System.DateTime object represents a local time, a Coordinated
    //     Universal Time (UTC), or is not specified as either local time or UTC.
    /// <summary>
    /// Specifies whether a <see cref="DateTime"/> object represents a local time, a Coordinated Universal Time (UTC), or is not specified as either local time or UTC.
    /// </summary>
    /// <remarks>
    /// nanoFramework doesn't support local time, only  UTC, so it's not possible to specify <see cref="DateTimeKind.Local"/>.
    /// </remarks>
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
        /// <remarks>
        /// nanoFramework doesn't support local time, so <see cref="DateTimeKind.Local"/> is provided to allow code reuse and keep consistency with full .NET framework.
        /// </remarks>
        [Obsolete("nanoFramework doesn't support local time, so DateTimeKind.Local is provided to allow code reuse and keep consistency with full .NET framework", true)]
        Local = 2,
    }

    // Preamble from .NET code base:
    // This value type represents a date and time.  Every DateTime 
    // object has a private field (Ticks) of type Int64 that stores the 
    // date and time as the number of 100 nanosecond intervals since 
    // 12:00 AM January 1, year 1 A.D. in the proleptic Gregorian Calendar.
    //
    // Starting from .NET V2.0, DateTime also stored some context about its time
    // zone in the form of a 3-state value representing Unspecified, Utc or
    // Local. This is stored in the two top bits of the 64-bit numeric value
    // with the remainder of the bits storing the tick count. This information 
    // is only used during time zone conversions and is not part of the 
    // identity of the DateTime. Thus, operations like Compare and Equals
    // ignore this state. This is to stay compatible with earlier behavior
    // and performance characteristics and to avoid forcing  people into dealing 
    // with the effects of daylight savings. Note, that this has little effect
    // on how the DateTime works except in a context where its specific time
    // zone is needed, such as during conversions and some parsing and formatting
    // cases.
    //
    // There is also 4th state stored that is a special type of Local value that
    // is used to avoid data loss when round-tripping between local and UTC time.
    // See below for more information on this 4th state, although it is 
    // effectively hidden from most users, who just see the 3-state DateTimeKind
    // enumeration.
    //
    // For compatibility, DateTime does not serialize the Kind data when used in
    // binary serialization.
    // 
    // For a description of various calendar issues, look at
    // 
    // Calendar Studies web site, at 
    // http://serendipity.nofadz.com/hermetic/cal_stud.htm.
    //
    // nanoFramework DateTime implementation introduces several simplifications:
    // - origin is 1601/01/01:00:00:00.000
    // - maximum value is 3000/12/31:23:59:59.999
    // - does not support time zone (always UTC) or daylight savings, so these bits are always ignored

    /// <summary>
    /// Represents an instant in time, typically expressed as a date and time of day.
    /// </summary>
    [Serializable]
#if NANOCLR_REFLECTION
    [DebuggerDisplay("{DateTimeDisplay,nq}")]
#endif // NANOCLR_REFLECTION
    public struct DateTime
    {
        /// Our origin is at 1601/01/01:00:00:00.000
        /// While desktop CLR's origin is at 0001/01/01:00:00:00.000.
        /// There are 504911232000000000 ticks between them which we are subtracting.
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const long _ticksAtOrigin = 504911232000000000;

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

        // Unix Epoch constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const long UnixEpochTicks = (TicksPerDay * 719162); // 621355968000000000
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const long UnixEpochSeconds = UnixEpochTicks / TicksPerSecond; // 62135596800

        // ticks value corresponding to 1601/01/01:00:00:00.000 (nanoFramework origin date time)
        private const long MinTicks = _ticksAtOrigin;
        // ticks value corresponding to 3000/12/31:23:59:59.999 (nanoFramework maximum date time)
        private const long MaxTicks = 946708127999999999;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const ulong _tickMask = 0x7FFFFFFFFFFFFFFFL;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const ulong _UTCMask = 0x8000000000000000L;

        /// <summary>
        /// Represents the smallest possible value of <see cref="DateTime"/>. This field is read-only.
        /// </summary>
        /// <remarks>The value of this constant is equivalent to 00:00:00.0000000, January 1, 1601.
        /// This value is specific to nanoFramework. .NET equivalent is 00:00:00.0000000 UTC, January 1, 0001, in the Gregorian calendar.
        /// </remarks>
        public static readonly DateTime MinValue = new DateTime(MinTicks);

        /// <summary>
        /// Represents the largest possible value of <see cref="DateTime"/>. This field is read-only.
        /// </summary>
        /// <remarks>The value of this constant is equivalent to 23:59:59.9999999, December 31, 3000.
        /// This value is specific to nanoFramework. .NET equivalent is 23:59:59.9999999 UTC, December 31, 9999 in the Gregorian calendar.
        /// </remarks>
        public static readonly DateTime MaxValue = new DateTime(MaxTicks);

        /// <summary>
        /// Represents the Unix Epoch value. This field is read-only.
        /// </summary>
        /// <remarks>The value of this constant is equivalent to the <see cref="DateTime"/> corresponding to 1970-01-01T00:00:00Z (January 1, 1970, at 12:00 AM UTC).
        /// This value is specific to nanoFramework.
        /// </remarks>
        public static readonly DateTime UnixEpoch = new DateTime(UnixEpochTicks, DateTimeKind.Utc);

        // The data is stored as an unsigned 64-bit integer
        //   Bits 01-62: The value of 100-nanosecond ticks where 0 represents 1601/01/01:00:00:00.000, up until the value
        //               3000/12/31:23:59:59.999
        //   Bits 63-64: Ignored in .NET nanoFramework implementation.
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ulong _ticks;

        // this enum is used to make the call to get date part
        // keep in sync with native 
        private enum DateTimePart
        {
            Year,
            Month,
            Day,
            DayOfWeek,
            DayOfYear,
            Hour,
            Minute,
            Second,
            Millisecond
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTime"/> structure to a specified number of ticks.
        /// </summary>
        /// <param name="ticks">A date and time expressed in the number of 100-nanosecond intervals. </param>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="ticks"/> - Ticks must be between <see cref="DateTime.MinValue"/> and <see cref="DateTime.MaxValue"/>.</exception>
        public DateTime(long ticks)
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (ticks < MinTicks || ticks > MaxTicks)
            {
                throw new ArgumentOutOfRangeException();
            }
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            // need to subtract our ticks at origin
            ticks -= _ticksAtOrigin;

            _ticks = (ulong)ticks;

            // allways UTC
            _ticks |= _UTCMask;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTime"/> structure to a specified number of ticks and to Coordinated Universal Time (UTC).
        /// </summary>
        /// <param name="ticks">A date and time expressed in the number of 100-nanosecond intervals. </param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time, Coordinated Universal Time (UTC), or neither.</param>
        /// <remarks>
        /// nanoFramework doesn't support local time, only  UTC, so it's not possible to specify <see cref="DateTimeKind.Local"/>.
        /// </remarks>
        public DateTime(long ticks, DateTimeKind kind)
            :this(ticks)
        {
            // it's OK to check kind parameter only here 
            // if it's invalid the exception will be thrown anyway and allows the constructor to be reused

            if (kind != DateTimeKind.Utc)
            {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTime"/> structure to the specified year, month, and day.
        /// </summary>
        /// <param name="year">The year (1601 through 3000). </param>
        /// <param name="month">The month (1 through 12). </param>
        /// <param name="day">The day (1 through the number of days in month). </param>
        public DateTime(int year, int month, int day)
            : this(year, month, day, 0, 0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTime"/> structure to the specified year, month, day, hour, minute, and second.
        /// </summary>
        /// <param name="year">The year (1601 through 3000). </param>
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
        /// Initializes a new instance of the <see cref="DateTime"/> structure to the specified year, month, day, hour, minute, second, and millisecond.
        /// </summary>
        /// <param name="year">The year (1601 through 3000). </param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        /// <param name="hour">The hours (0 through 23). </param>
        /// <param name="minute">The minutes (0 through 59). </param>
        /// <param name="second">The seconds (0 through 59). </param>
        /// <param name="millisecond">The milliseconds (0 through 999). </param>
        /// <exception cref="ArgumentOutOfRangeException">Any parameter out of the accepted ranges</exception>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond);

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the value of the specified <see cref="TimeSpan"/> to the value of this instance.
        /// </summary>
        /// <param name="val">A positive or negative time interval. </param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time interval represented by <paramref name="val"/>.</returns>
        public DateTime Add(TimeSpan val)
        {
            return new DateTime(Ticks + val.Ticks);
        }

        private DateTime Add(double val, int scale)
        {
            return new DateTime(Ticks + (long)(val * scale * TicksPerMillisecond + (val >= 0 ? 0.5 : -0.5)));
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of days to the value of this instance.
        /// </summary>
        /// <param name="val">A number of whole and fractional days. The <paramref name="val"/> parameter can be negative or positive. </param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of days represented by <paramref name="val"/>.</returns>
        public DateTime AddDays(double val)
        {
            return Add(val, MillisPerDay);
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of hours to the value of this instance.
        /// </summary>
        /// <param name="val">A number of whole and fractional hours. The <paramref name="val"/> parameter can be negative or positive. </param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of hours represented by <paramref name="val"/>.</returns>
        public DateTime AddHours(double val)
        {
            return Add(val, MillisPerHour);
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of milliseconds to the value of this instance.
        /// </summary>
        /// <param name="val">A number of whole and fractional milliseconds. The <paramref name="val"/> parameter can be negative or positive. Note that this value is rounded to the nearest integer.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of milliseconds represented by <paramref name="val"/>.</returns>
        public DateTime AddMilliseconds(double val)
        {
            return Add(val, 1);
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of minutes to the value of this instance.
        /// </summary>
        /// <param name="val">A number of whole and fractional minutes. The <paramref name="val"/> parameter can be negative or positive. </param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of minutes represented by <paramref name="val"/>.</returns>
        public DateTime AddMinutes(double val)
        {
            return Add(val, MillisPerMinute);
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of seconds to the value of this instance.
        /// </summary>
        /// <param name="val">A number of whole and fractional seconds. The <paramref name="val"/> parameter can be negative or positive. </param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of seconds represented by <paramref name="val"/>.</returns>
        public DateTime AddSeconds(double val)
        {
            return Add(val, MillisPerSecond);
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of ticks to the value of this instance.
        /// </summary>
        /// <param name="val">A number of 100-nanosecond ticks. The <paramref name="val"/> parameter can be positive or negative. </param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time represented by <paramref name="val"/>.</returns>
        public DateTime AddTicks(long val)
        {
            return new DateTime(Ticks + val);
        }

        /// <summary>
        /// Compares two instances of <see cref="DateTime"/> and returns an integer that indicates whether the first instance is earlier than, the same as, or later than the second instance.
        /// </summary>
        /// <param name="t1">The first object to compare. </param>
        /// <param name="t2">The second object to compare. </param>
        /// <returns>A signed number indicating the relative values of <paramref name="t1"/> and <paramref name="t2"/>.</returns>
        public static int Compare(DateTime t1, DateTime t2)
        {
            // Get ticks
            var t1Ticks = t1.Ticks;
            var t2Ticks = t2.Ticks;

            // Compare ticks.
            if (t1Ticks > t2Ticks) return 1;
            if (t1Ticks < t2Ticks) return -1;

            // Values are equal
            return 0;
        }

        /// <summary>
        /// Compares the value of this instance to a specified object that contains a specified <see cref="DateTime"/> value, and returns an integer that indicates whether this instance is earlier than, the same as, or later than the specified <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="val">A boxed object to compare, or null reference (Nothing in Visual Basic).</param>
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
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int DaysInMonth(int year, int month);

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare to this instance. </param>
        /// <returns>true if <paramref name="obj"/> is an instance of <see cref="DateTime"/> and equals the value of this instance; otherwise, false.</returns>
        public override bool Equals(Object obj)
        {
            if (obj is DateTime)
            {
                // Call compare for proper comparison of 2 DateTime objects
                // Since DateTime is optimized value and internally represented by int64
                // "this" may still have type int64.
                // Conversion to object and back is a workaround.
                object o = this;
                var thisTime = (DateTime)o;

                return Compare(thisTime, (DateTime)obj) == 0;
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether two <see cref="DateTime"/> instances have the same date and time value.
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
                return new DateTime(Ticks - (Ticks % TicksPerDay));
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
            get => GetDateTimePart(DateTimePart.Day);
        }

        /// <summary>
        /// Gets the day of the week represented by this instance.
        /// </summary>
        /// <value>
        /// An enumerated constant that indicates the day of the week of this <see cref="DateTime"/> value.
        /// </value>
        public DayOfWeek DayOfWeek
        {
            get => (DayOfWeek)GetDateTimePart(DateTimePart.DayOfWeek);
        }

        /// <summary>
        /// Gets the day of the year represented by this instance.
        /// </summary>
        /// <value>
        /// The day of the year, expressed as a value between 1 and 366.
        /// </value>
        public int DayOfYear
        {
            get => GetDateTimePart(DateTimePart.DayOfYear);
        }

        /// <summary>
        /// Gets the hour component of the date represented by this instance.
        /// </summary>
        /// <value>
        /// The hour component, expressed as a value between 0 and 23.
        /// </value>
        public int Hour
        {
            get => GetDateTimePart(DateTimePart.Hour);
        }

        /// <summary>
        /// Gets a value that indicates whether the time represented by this instance is based on local time, Coordinated Universal Time (UTC), or neither.
        /// </summary>
        /// <value>
        /// One of the enumeration values that indicates what the current time represents.
        /// </value>
        /// <remarks>
        /// Despite the default in the full .NET Framework is <see cref="DateTimeKind.Local"/> this won't never happen because nanoFramework only supports UTC time.
        /// </remarks>
        public DateTimeKind Kind => DateTimeKind.Utc; // always UTC in nanoFramework

        /// <summary>
        /// Gets the milliseconds component of the date represented by this instance.
        /// </summary>
        /// <value>
        /// The milliseconds component, expressed as a value between 0 and 999.
        /// </value>
        public int Millisecond
        {
            get => GetDateTimePart(DateTimePart.Millisecond);
        }

        /// <summary>
        /// Gets the minute component of the date represented by this instance.
        /// </summary>
        /// <value>
        /// The minute component, expressed as a value between 0 and 59.
        /// </value>
        public int Minute
        {
            get => GetDateTimePart(DateTimePart.Minute);
        }

        /// <summary>
        /// Gets the month component of the date represented by this instance.
        /// </summary>
        /// <value>
        /// The month component, expressed as a value between 1 and 12.
        /// </value>
        public int Month
        {
            get => GetDateTimePart(DateTimePart.Month);
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> object that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        /// <value>
        /// An object whose value is the current UTC date and time.
        /// </value>
        public static DateTime UtcNow
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get => new DateTime();
        }

        /// <summary>
        /// Gets the seconds component of the date represented by this instance.
        /// </summary>
        /// <value>
        /// The seconds component, expressed as a value between 0 and 59.
        /// </value>
        public int Second
        {
            get => GetDateTimePart(DateTimePart.Second);
        }

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
                return (long)(_ticks & _tickMask) + _ticksAtOrigin;
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
                return new TimeSpan(Ticks % TicksPerDay);
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
            [MethodImpl(MethodImplOptions.InternalCall)]
            get => new DateTime();
        }

        /// <summary>
        /// Gets the year component of the date represented by this instance.
        /// </summary>
        /// <value>
        /// The year, between 1 and 9999.
        /// </value>
        public int Year
        {
            get => GetDateTimePart(DateTimePart.Year);
        }

        /// <summary>
        /// Subtracts the specified date and time from this instance.
        /// </summary>
        /// <param name="val">The date and time value to subtract. </param>
        /// <returns>A time interval that is equal to the date and time represented by this instance minus the date and time represented by <paramref name="val"/>.</returns>
        public TimeSpan Subtract(DateTime val)
        {
            return new TimeSpan(Ticks - val.Ticks);
        }

        /// <summary>
        /// Subtracts the specified duration from this instance.
        /// </summary>
        /// <param name="val">The time interval to subtract. </param>
        /// <returns>An object that is equal to the date and time represented by this instance minus the time interval represented by <paramref name="val"/>.</returns>
        public DateTime Subtract(TimeSpan val)
        {
            return new DateTime(Ticks - val._ticks);
        }

        /// <summary>
        /// Converts the value of the current <see cref="DateTime"/> object to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the value of the current <see cref="DateTime"/> object.</returns>
        public override string ToString() => DateTimeFormat.Format(this, null, DateTimeFormatInfo.CurrentInfo);

        /// <summary>
        /// Converts the value of the current <see cref="DateTime"/> object to its equivalent string representation using the specified format.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string (see Remarks). </param>
        /// <returns>A string representation of value of the current DateTime object as specified by format.</returns>
        public string ToString(string format) => DateTimeFormat.Format(this, format, DateTimeFormatInfo.CurrentInfo);

        /// <summary>
        /// Adds a specified time interval to a specified date and time, yielding a new date and time.
        /// </summary>
        /// <param name="d">The date and time value to add. </param>
        /// <param name="t">The time interval to add. </param>
        /// <returns>
        /// An object that is the sum of the values of <paramref name="d"/> and <paramref name="t"/>.
        /// </returns>
        public static DateTime operator +(DateTime d, TimeSpan t)
        {
            return new DateTime(d.Ticks + t.Ticks);
        }


        /// <summary>
        /// Subtracts a specified time interval from a specified date and time and returns a new date and time.
        /// </summary>
        /// <param name="d">The date and time value to subtract from. </param>
        /// <param name="t">The time interval to subtract. </param>
        /// <returns>
        /// An object whose value is the value of <paramref name="d"/> minus the value of <paramref name="t"/>.
        /// </returns>
        public static DateTime operator -(DateTime d, TimeSpan t)
        {
            return new DateTime(d.Ticks - t.Ticks);
        }

        /// <summary>
        /// Subtracts a specified date and time from another specified date and time and returns a time interval.
        /// </summary>
        /// <param name="d1">The date and time value to subtract from (the minuend). </param>
        /// <param name="d2">The date and time value to subtract (the subtrahend). </param>
        /// <returns>
        /// The time interval between <paramref name="d1"/> and <paramref name="d2"/>; that is, <paramref name="d1"/> minus <paramref name="d2"/>.
        /// </returns>
        public static TimeSpan operator -(DateTime d1, DateTime d2)
        {
            return d1.Subtract(d2);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="DateTime"/> are equal.
        /// </summary>
        /// <param name="d1">The first object to compare. </param>
        /// <param name="d2">The second object to compare. </param>
        /// <returns>
        /// true if <paramref name="d1"/> and <paramref name="d2"/> represent the same date and time; otherwise, false.
        /// </returns>
        public static bool operator ==(DateTime d1, DateTime d2)
        {
            return Compare(d1, d2) == 0;
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="DateTime"/> are not equal.
        /// </summary>
        /// <param name="t1">The first object to compare. </param>
        /// <param name="t2">The second object to compare. </param>
        /// <returns>
        /// true if <paramref name="t1"/> and <paramref name="t2"/> do not represent the same date and time; otherwise, false.
        /// </returns>
        public static bool operator !=(DateTime t1, DateTime t2)
        {
            return Compare(t1, t2) != 0;
        }

        /// <summary>
        /// Determines whether one specified <see cref="DateTime"/> is less than another specified <see cref="DateTime"/>.
        /// </summary>
        /// <param name="t1">The first object to compare. </param>
        /// <param name="t2">The second object to compare. </param>
        /// <returns>
        /// true if <paramref name="t1"/> is less than <paramref name="t2"/>; otherwise, false.
        /// </returns>
        public static bool operator <(DateTime t1, DateTime t2)
        {
            return Compare(t1, t2) < 0;
        }

        /// <summary>
        /// Determines whether one specified <see cref="DateTime"/> is less than or equal to another specified DateTime.
        /// </summary>
        /// <param name="t1">The first object to compare. </param>
        /// <param name="t2">The second object to compare. </param>
        /// <returns>
        /// true if <paramref name="t1"/> is less than or equal to <paramref name="t2"/>; otherwise, false.
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
        /// true if <paramref name="t1"/> is greater than <paramref name="t2"/>; otherwise, false.
        /// </returns>
        public static bool operator >(DateTime t1, DateTime t2)
        {
            return Compare(t1, t2) > 0;
        }

        /// <summary>
        /// Determines whether one specified <see cref="DateTime"/> is greater than or equal to another specified DateTime.
        /// </summary>
        /// <param name="t1">The first object to compare. </param>
        /// <param name="t2">The second object to compare. </param>
        /// <returns>
        /// true if <paramref name="t1"/> is greater than or equal to <paramref name="t2"/>; otherwise, false.
        /// </returns>
        public static bool operator >=(DateTime t1, DateTime t2)
        {
            return Compare(t1, t2) >= 0;
        }

        /// <summary>
        /// Converts a Unix time expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z to a <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="seconds">A Unix time, expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z (January 1, 1970, at 12:00 AM UTC). For Unix times before this date, its value is negative.</param>
        /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
        /// <remarks>
        /// This method is exclusive of nanoFramework.
        /// </remarks>
        public static DateTime FromUnixTimeSeconds(long seconds)
        {
            const long MaxSeconds = (MaxTicks / TicksPerSecond) - UnixEpochSeconds;

            if (seconds < 0 || seconds > MaxSeconds)
            {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentOutOfRangeException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            }

            long ticks = (seconds * TicksPerSecond) + UnixEpochTicks;
            return new DateTime(ticks);
        }

        /// <summary>
        /// Returns the number of seconds that have elapsed since 1970-01-01T00:00:00Z.
        /// </summary>
        /// <returns>The number of seconds that have elapsed since 1970-01-01T00:00:00Z.</returns>
        /// <remarks>
        /// Unix time represents the number of seconds that have elapsed since 1970-01-01T00:00:00Z (January 1, 1970, at 12:00 AM UTC). It does not take leap seconds into account.
        /// 
        /// This method is exclusive of nanoFramework.
        /// </remarks>
        public long ToUnixTimeSeconds()
        {
            // Truncate sub-second precision before offsetting by the Unix Epoch to avoid
            // the last digit being off by one for dates that result in negative Unix times.
            //
            // For example, consider the DateTime 12/31/1969 12:59:59.001 +0
            //   ticks            = 621355967990010000
            //   ticksFromEpoch   = ticks - UnixEpochTicks                   = -9990000
            //   secondsFromEpoch = ticksFromEpoch / TicksPerSecond = 0
            //
            // Notice that secondsFromEpoch is rounded *up* by the truncation induced by integer division,
            // whereas we actually always want to round *down* when converting to Unix time. This happens
            // automatically for positive Unix time values. Now the example becomes:
            //   seconds          = ticks / TicksPerSecond = 62135596799
            //   secondsFromEpoch = seconds - UnixEpochSeconds      = -1
            //
            // In other words, we want to consistently round toward the time 1/1/0001 00:00:00,
            // rather than toward the Unix Epoch (1/1/1970 00:00:00).
            long seconds = Ticks / TicksPerSecond;
            return seconds - UnixEpochSeconds;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            ulong internalTicks = _ticks;
            return ((int)internalTicks) ^ ((int)(internalTicks >> 0x20));

        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DateTimeDisplay => $"{{{new DateTime(Ticks).ToString()}}}";

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern int GetDateTimePart(DateTimePart part);
    }
}
