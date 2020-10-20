//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
namespace System
{
    using Runtime.CompilerServices;

    /// <summary>
    /// Represents a time interval.
    /// </summary>
    /// <remarks>
    /// A <see cref="TimeSpan "/> object represents a time interval (duration of time or elapsed time) that is measured as a positive or negative number of days, hours, minutes, seconds, and fractions of a second. The <see cref="TimeSpan "/> structure can also be used to represent the time of day, but only if the time is unrelated to a particular date. Otherwise, the <see cref="DateTime "/> structure should be used instead.
    /// The value of a <see cref="TimeSpan"/> object is the number of ticks that equal the represented time interval. A tick is equal to 100 nanoseconds, or one ten-millionth of a second. The value of a <see cref="TimeSpan"/> object can range from <see cref="TimeSpan.MinValue"/> to <see cref="TimeSpan.MaxValue"/>. 
    /// </remarks>
    [Serializable]
    public struct TimeSpan
    {
        internal long _ticks;

        internal const long MaxMilliSeconds = Int64.MaxValue / TicksPerMillisecond;
        internal const long MinMilliSeconds = Int64.MinValue / TicksPerMillisecond;

        /// <summary>
        /// Represents the number of ticks in 1 millisecond. This field is constant.
        /// </summary>
        public const long TicksPerMillisecond = 10000;
        private const double MillisecondsPerTick = 1.0 / TicksPerMillisecond;

        /// <summary>
        /// Represents the number of ticks in 1 second.
        /// </summary>
        public const long TicksPerSecond = TicksPerMillisecond * 1000;  // 10.000.000
        private const double SecondsPerTick = 1.0 / TicksPerSecond;     // 0.0001

        /// <summary>
        /// Represents the number of ticks in 1 minute. This field is constant.
        /// </summary>
        public const long TicksPerMinute = TicksPerSecond * 60;     // 600.000.000
        private const double MinutesPerTick = 1.0 / TicksPerMinute; // 1.6666666666667e-9

        /// <summary>
        /// Represents the number of ticks in 1 hour. This field is constant.
        /// </summary>
        public const long TicksPerHour = TicksPerMinute * 60;   // 36.000.000.000
        private const double HoursPerTick = 1.0 / TicksPerHour; // 2.77777777777777778e-11

        /// <summary>
        /// Represents the number of ticks in 1 day. This field is constant.
        /// </summary>
        public const long TicksPerDay = TicksPerHour * 24;      // 864.000.000.000
        private const double DaysPerTick = 1.0 / TicksPerDay;   // 1.1574074074074074074e-12

        /// <summary>
        /// Represents the zero <see cref="TimeSpan"/> value. This field is read-only.
        /// </summary>
        public static readonly TimeSpan Zero = new TimeSpan(0);

        /// <summary>
        /// Represents the maximum <see cref="TimeSpan"/> value. This field is read-only.
        /// </summary>
        public static readonly TimeSpan MaxValue = new TimeSpan(Int64.MaxValue);
        /// <summary>
        /// Represents the minimum <see cref="TimeSpan"/> value. This field is read-only.
        /// </summary>
        public static readonly TimeSpan MinValue = new TimeSpan(Int64.MinValue);

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSpan"/> structure to the specified number of ticks.
        /// </summary>
        /// <param name="ticks">A time period expressed in 100-nanosecond units.</param>
        public TimeSpan(long ticks)
        {
            _ticks = ticks;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSpan"/> structure to a specified number of hours, minutes, and seconds.
        /// </summary>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        /// <param name="seconds">Number of seconds.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern TimeSpan(int hours, int minutes, int seconds);

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSpan"/> structure to a specified number of days, hours, minutes, and seconds.
        /// </summary>
        /// <param name="days">Number of days.</param>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        /// <param name="seconds">Number of seconds.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern TimeSpan(int days, int hours, int minutes, int seconds);

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSpan"/> structure to a specified number of days, hours, minutes, seconds and milliseconds.
        /// </summary>
        /// <param name="days">Number of days.</param>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        /// <param name="seconds">Number of seconds.</param>
        /// <param name="milliseconds">Number of milliseconds.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds);

        /// <summary>
        /// Gets the number of ticks that represent the value of the current <see cref="TimeSpan"/> structure.
        /// </summary>
        /// <value>The number of ticks contained in this instance. </value>
        public long Ticks => _ticks;

        /// <summary>
        /// Gets the days component of the time interval represented by the current <see cref="TimeSpan"/> structure.
        /// </summary>
        /// <value>The day component of this instance. The return value can be positive or negative.</value>
        public int Days => (int)(_ticks / TicksPerDay);

        /// <summary>
        /// Gets the hours component of the time interval represented by the current <see cref="TimeSpan"/> structure.
        /// </summary>
        /// <value>The hour component of this instance. The return value ranges from -23 through 23.</value>
        public int Hours => (int)((_ticks / TicksPerHour) % 24);

        /// <summary>
        /// Gets the milliseconds component of the time interval represented by the current <see cref="TimeSpan"/> structure.
        /// </summary>
        /// <value>The millisecond component of this instance.  The return value ranges from -999 through 999.</value>
        public int Milliseconds => (int)((_ticks / TicksPerMillisecond) % 1000);

        /// <summary>
        /// Gets the minutes component of the time interval represented by the current <see cref="TimeSpan"/> structure.
        /// </summary>
        /// <value>The minute component of this instance. The return value ranges from -59 through 59.</value>
        public int Minutes => (int)((_ticks / TicksPerMinute) % 60);

        /// <summary>
        /// Gets the seconds component of the time interval represented by the current <see cref="TimeSpan"/> structure.
        /// </summary>
        /// <value>The second component of this instance. The return value ranges from -59 through 59.</value>
        public int Seconds => (int)((_ticks / TicksPerSecond) % 60);

        /// <summary>
        /// Gets the value of the current <see cref="TimeSpan"/> structure expressed in whole and fractional days.
        /// </summary>
        /// <value>The total number of days represented by this instance.</value>
        public double TotalDays => (_ticks) * DaysPerTick;

        /// <summary>
        /// Gets the value of the current <see cref="TimeSpan"/> structure expressed in whole and fractional hours.
        /// </summary>
        /// <value>The total number of hours represented by this instance.</value>
        public double TotalHours => _ticks * HoursPerTick;

        /// <summary>
        /// Gets the value of the current <see cref="TimeSpan"/> structure expressed in whole and fractional milliseconds.
        /// </summary>
        /// <value>The total number of milliseconds represented by this instance.</value>
        public double TotalMilliseconds
        {
            get
            {
                double temp = _ticks * MillisecondsPerTick;
                if (temp > MaxMilliSeconds)
                    return MaxMilliSeconds;

                if (temp < MinMilliSeconds)
                    return MinMilliSeconds;

                return temp;
            }
        }

        /// <summary>
        /// Gets the value of the current <see cref="TimeSpan"/> structure expressed in whole and fractional minutes.
        /// </summary>
        /// <value>The total number of minutes represented by this instance.</value>
        public double TotalMinutes => _ticks * MinutesPerTick;

        /// <summary>
        /// Gets the value of the current <see cref="TimeSpan"/> structure expressed in whole and fractional seconds.
        /// </summary>
        /// <value>The total number of seconds represented by this instance.</value>
        public double TotalSeconds => _ticks * SecondsPerTick;

        /// <summary>
        /// Returns a new <see cref="TimeSpan"/> object whose value is the sum of the specified <see cref="TimeSpan"/> object and this instance.
        /// </summary>
        /// <param name="ts">The time interval to add.</param>
        /// <returns>A new object that represents the value of this instance plus the value of ts.</returns>
        public TimeSpan Add(TimeSpan ts) => new TimeSpan(_ticks + ts._ticks);

        /// <summary>
        /// Compares two <see cref="TimeSpan"/> values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>One of the following values :
        /// <para>-1 if t1 is shorter than t2.</para>
        /// <para>0 if t1 is equal to t2.</para>
        /// <para>1 if t1 is longer than t2.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int Compare(TimeSpan t1, TimeSpan t2);

        /// <summary>
        /// Compares this instance to a specified object and returns an integer that indicates whether this instance is shorter than, equal to, or longer than the specified object.
        /// </summary>
        /// <param name="value">An object to compare, or null.</param>
        /// <returns>One of the following values :
        /// <para>-1 if This instance is shorter than value.</para>
        /// <para>0 if This instance is equal to value.</para>
        /// <para>1 if This instance is longer than value or value is null.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int CompareTo(Object value);

        /// <summary>
        /// Returns a new <see cref="TimeSpan"/> object whose value is the absolute value of the current <see cref="TimeSpan"/> object.
        /// </summary>
        /// <returns>A new object whose value is the absolute value of the current <see cref="TimeSpan"/> object.</returns>
        public TimeSpan Duration() => new TimeSpan(_ticks >= 0 ? _ticks : -_ticks);

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="value">An object to compare with this instance.</param>
        /// <returns>true if value is a <see cref="TimeSpan"/> object that represents the same time interval as the current <see cref="TimeSpan"/> structure; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern bool Equals(Object value);

        /// <summary>
        /// Returns a value that indicates whether two specified instances of <see cref="TimeSpan"/> are equal.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the values of t1 and t2 are equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool Equals(TimeSpan t1, TimeSpan t2);

        /// <summary>
        /// Returns a new <see cref="TimeSpan"/> object whose value is the negated value of this instance.
        /// </summary>
        /// <returns>A new object with the same numeric value as this instance, but with the opposite sign.</returns>
        public TimeSpan Negate() => new TimeSpan(-_ticks);

        /// <summary>
        /// Returns a new <see cref="TimeSpan"/> object whose value is the difference between the specified <see cref="TimeSpan"/> object and this instance.
        /// </summary>
        /// <param name="ts">The time interval to be subtracted.</param>
        /// <returns>A new time interval whose value is the result of the value of this instance minus the value of ts.</returns>
        public TimeSpan Subtract(TimeSpan ts) => new TimeSpan(_ticks - ts._ticks);

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> that represents a specified time, where the specification is in units of ticks.
        /// </summary>
        /// <param name="value">A number of ticks that represent a time.</param>
        /// <returns>An object that represents value.</returns>
        public static TimeSpan FromTicks(long value) => new TimeSpan(value);
        
        /// <summary>
        /// Returns a <see cref="TimeSpan"/> that represents a specified time, where the specification is in units of milliseconds.
        /// </summary>
        /// <param name="value">A number of milliseconds that represent a time.</param>
        /// <returns>An object that represents value.</returns>
        public static TimeSpan FromMilliseconds(long value) => new TimeSpan(TimeSpan.TicksPerMillisecond  * value);

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> that represents a specified time, where the specification is in units of seconds.
        /// </summary>
        /// <param name="value">A number of seconds that represent a time.</param>
        /// <returns>An object that represents value.</returns>
        public static TimeSpan FromSeconds(long value) => new TimeSpan(TimeSpan.TicksPerSecond * value);

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> that represents a specified time, where the specification is in units of minute.
        /// </summary>
        /// <param name="value">A number of minute that represent a time.</param>
        /// <returns>An object that represents value.</returns>
        public static TimeSpan FromMinutes(long value) => new TimeSpan(TimeSpan.TicksPerMinute * value);

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> that represents a specified time, where the specification is in units of hours.
        /// </summary>
        /// <param name="value">A number of hours that represent a time.</param>
        /// <returns>An object that represents value.</returns>
        public static TimeSpan FromHours(long value) => new TimeSpan(TimeSpan.TicksPerHour * value);

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> that represents a specified time, where the specification is in units of days.
        /// </summary>
        /// <param name="value">A number of days that represent a time.</param>
        /// <returns>An object that represents value.</returns>
        public static TimeSpan FromDays(long value) => new TimeSpan(TimeSpan.TicksPerDay * value);
        
        /// <summary>
        /// Converts the value of the current <see cref="TimeSpan"/> object to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the current <see cref="TimeSpan"/> value.</returns>
        /// <remarks>The returned string is formatted with the "c" format specifier and has the following format: [-][d.]hh:mm:ss[.fffffff]</remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern String ToString();

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> whose value is the negated value of the specified instance.
        /// </summary>
        /// <param name="t">The time interval to be negated.</param>
        /// <returns>An object that has the same numeric value as this instance, but the opposite sign.</returns>
        public static TimeSpan operator -(TimeSpan t) => new TimeSpan(-t._ticks);

        /// <summary>
        /// Subtracts a specified <see cref="TimeSpan"/> from another specified TimeSpan.
        /// </summary>
        /// <param name="t1">The minuend.</param>
        /// <param name="t2">The subtrahend.</param>
        /// <returns>An object whose value is the result of the value of t1 minus the value of t2.</returns>
        public static TimeSpan operator -(TimeSpan t1, TimeSpan t2) => new TimeSpan(t1._ticks - t2._ticks);

        /// <summary>
        /// Returns the specified instance of TimeSpan.
        /// </summary>
        /// <param name="t">The time interval to return.</param>
        /// <returns>The time interval specified by t.</returns>
        public static TimeSpan operator +(TimeSpan t) => t;

        /// <summary>
        /// Adds two specified <see cref="TimeSpan"/> instances.
        /// </summary>
        /// <param name="t1">The first time interval to add.</param>
        /// <param name="t2">The second time interval to add.</param>
        /// <returns>An object whose value is the sum of the values of t1 and t2.</returns>
        public static TimeSpan operator +(TimeSpan t1, TimeSpan t2) => new TimeSpan(t1._ticks + t2._ticks);

        /// <summary>
        /// Indicates whether two <see cref="TimeSpan"/> instances are equal
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the values of t1 and t2 are equal; otherwise, false.</returns>
        public static bool operator ==(TimeSpan t1, TimeSpan t2) => t1._ticks == t2._ticks;

        /// <summary>
        /// Indicates whether two <see cref="TimeSpan"/> instances are not equal.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the values of t1 and t2 are not equal; otherwise, false.</returns>
        public static bool operator !=(TimeSpan t1, TimeSpan t2) => t1._ticks != t2._ticks;

        /// <summary>
        /// Indicates whether a specified <see cref="TimeSpan"/> is less than another specified TimeSpan.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the value of t1 is less than the value of t2; otherwise, false.</returns>
        public static bool operator <(TimeSpan t1, TimeSpan t2) => t1._ticks < t2._ticks;

        /// <summary>
        /// Indicates whether a specified <see cref="TimeSpan"/> is less than or equal to another specified TimeSpan.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the value of t1 is less than or equal to the value of t2; otherwise, false.</returns>
        public static bool operator <=(TimeSpan t1, TimeSpan t2) => t1._ticks <= t2._ticks;

        /// <summary>
        /// Indicates whether a specified <see cref="TimeSpan"/> is greater than another specified TimeSpan.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the value of t1 is greater than the value of t2; otherwise, false.</returns>
        public static bool operator >(TimeSpan t1, TimeSpan t2) => t1._ticks > t2._ticks;

        /// <summary>
        /// Indicates whether a specified <see cref="TimeSpan"/> is greater than or equal to another specified TimeSpan.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the value of t1 is greater than or equal to the value of t2; otherwise, false.</returns>
        public static bool operator >=(TimeSpan t1, TimeSpan t2) => t1._ticks >= t2._ticks;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return (int)_ticks ^ (int)(_ticks >> 32);
        }
    }
}
