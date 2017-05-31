//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
namespace System
{
    using Runtime.CompilerServices;

    /// <summary>
    /// Represents a time interval.
    /// </summary>
    [Serializable]
    public struct TimeSpan
    {
        internal long _numberOfTicks;

        /// <summary>
        /// Represents the number of ticks in 1 millisecond. This field is constant.
        /// </summary>
        public const long TicksPerMillisecond = 10000;
        /// <summary>
        /// Represents the number of ticks in 1 second.
        /// </summary>
        public const long TicksPerSecond = TicksPerMillisecond * 1000;
        /// <summary>
        /// Represents the number of ticks in 1 minute. This field is constant.
        /// </summary>
        public const long TicksPerMinute = TicksPerSecond * 60;
        /// <summary>
        /// Represents the number of ticks in 1 hour. This field is constant.
        /// </summary>
        public const long TicksPerHour = TicksPerMinute * 60;
        /// <summary>
        /// Represents the number of ticks in 1 day. This field is constant.
        /// </summary>
        public const long TicksPerDay = TicksPerHour * 24;

        /// <summary>
        /// Represents the zero TimeSpan value. This field is read-only.
        /// </summary>
        public static readonly TimeSpan Zero = new TimeSpan(0);

        /// <summary>
        /// Represents the maximum TimeSpan value. This field is read-only.
        /// </summary>
        public static readonly TimeSpan MaxValue = new TimeSpan(Int64.MaxValue);
        /// <summary>
        /// Represents the minimum TimeSpan value. This field is read-only.
        /// </summary>
        public static readonly TimeSpan MinValue = new TimeSpan(Int64.MinValue);

        /// <summary>
        /// Initializes a new instance of the TimeSpan structure to the specified number of ticks.
        /// </summary>
        /// <param name="ticks">A time period expressed in 100-nanosecond units.</param>
        public TimeSpan(long ticks)
        {
            _numberOfTicks = ticks;
        }

        /// <summary>
        /// Initializes a new instance of the TimeSpan structure to a specified number of hours, minutes, and seconds.
        /// </summary>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        /// <param name="seconds">Number of seconds.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern TimeSpan(int hours, int minutes, int seconds);

        /// <summary>
        /// Initializes a new instance of the TimeSpan structure to a specified number of days, hours, minutes, and seconds.
        /// </summary>
        /// <param name="days">Number of days.</param>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        /// <param name="seconds">Number of seconds.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern TimeSpan(int days, int hours, int minutes, int seconds);

        /// <summary>
        /// Initializes a new instance of the TimeSpan structure to a specified number of days, hours, minutes, seconds and milliseconds.
        /// </summary>
        /// <param name="days">Number of days.</param>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        /// <param name="seconds">Number of seconds.</param>
        /// <param name="milliseconds">Number of milliseconds.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds);

        /// <summary>
        /// Gets the number of ticks that represent the value of the current TimeSpan structure.
        /// </summary>
        /// <value>The number of ticks contained in this instance. </value>
        public long Ticks
        {
            get
            {
                return _numberOfTicks;
            }
        }

        /// <summary>
        /// Gets the days component of the time interval represented by the current TimeSpan structure.
        /// </summary>
        /// <value>The day component of this instance. The return value can be positive or negative.</value>
        public int Days
        {
            get
            {
                return (int)(_numberOfTicks / TicksPerDay);
            }
        }

        /// <summary>
        /// Gets the hours component of the time interval represented by the current TimeSpan structure.
        /// </summary>
        /// <value>The hour component of this instance. The return value can be positive or negative.</value>
        public int Hours
        {
            get
            {
                return (int)((_numberOfTicks / TicksPerHour) % 24);
            }
        }

        /// <summary>
        /// Gets the milliseconds component of the time interval represented by the current TimeSpan structure.
        /// </summary>
        /// <value>The millisecond component of this instance. The return value can be positive or negative.</value>
        public int Milliseconds
        {
            get
            {
                return (int)((_numberOfTicks / TicksPerMillisecond) % 1000);
            }
        }

        /// <summary>
        /// Gets the minutes component of the time interval represented by the current TimeSpan structure.
        /// </summary>
        /// <value>The minute component of this instance. The return value can be positive or negative.</value>
        public int Minutes
        {
            get
            {
                return (int)((_numberOfTicks / TicksPerMinute) % 60);
            }
        }

        /// <summary>
        /// Gets the seconds component of the time interval represented by the current TimeSpan structure.
        /// </summary>
        /// <value>The second component of this instance. The return value can be positive or negative.</value>
        public int Seconds
        {
            get
            {
                return (int)((_numberOfTicks / TicksPerSecond) % 60);
            }
        }

        /// <summary>
        /// Returns a new TimeSpan object whose value is the sum of the specified TimeSpan object and this instance.
        /// </summary>
        /// <param name="ts">The time interval to add.</param>
        /// <returns>A new object that represents the value of this instance plus the value of ts.</returns>
        public TimeSpan Add(TimeSpan ts)
        {
            return new TimeSpan(_numberOfTicks + ts._numberOfTicks);
        }

        /// <summary>
        /// Compares two TimeSpan values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
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
        /// Returns a new TimeSpan object whose value is the absolute value of the current TimeSpan object.
        /// </summary>
        /// <returns>A new object whose value is the absolute value of the current TimeSpan object.</returns>
        public TimeSpan Duration()
        {
            return new TimeSpan(_numberOfTicks >= 0 ? _numberOfTicks : -_numberOfTicks);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="value">An object to compare with this instance.</param>
        /// <returns>true if value is a TimeSpan object that represents the same time interval as the current TimeSpan structure; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern bool Equals(Object value);

        /// <summary>
        /// Returns a value that indicates whether two specified instances of TimeSpan are equal.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the values of t1 and t2 are equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool Equals(TimeSpan t1, TimeSpan t2);

        /// <summary>
        /// Returns a new TimeSpan object whose value is the negated value of this instance.
        /// </summary>
        /// <returns>A new object with the same numeric value as this instance, but with the opposite sign.</returns>
        public TimeSpan Negate()
        {
            return new TimeSpan(-_numberOfTicks);
        }

        /// <summary>
        /// Returns a new TimeSpan object whose value is the difference between the specified TimeSpan object and this instance.
        /// </summary>
        /// <param name="ts">The time interval to be subtracted.</param>
        /// <returns>A new time interval whose value is the result of the value of this instance minus the value of ts.</returns>
        public TimeSpan Subtract(TimeSpan ts)
        {
            return new TimeSpan(_numberOfTicks - ts._numberOfTicks);
        }

        /// <summary>
        /// Returns a TimeSpan that represents a specified time, where the specification is in units of ticks.
        /// </summary>
        /// <param name="value">A number of ticks that represent a time.</param>
        /// <returns>An object that represents value.</returns>
        public static TimeSpan FromTicks(long value)
        {
            return new TimeSpan(value);
        }

        /// <summary>
        /// Converts the value of the current TimeSpan object to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the current TimeSpan value.</returns>
        /// <remarks>The returned string is formatted with the "c" format specifier and has the following format: [-][d.]hh:mm:ss[.fffffff]</remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern String ToString();

        /// <summary>
        /// Returns a TimeSpan whose value is the negated value of the specified instance.
        /// </summary>
        /// <param name="t">The time interval to be negated.</param>
        /// <returns>An object that has the same numeric value as this instance, but the opposite sign.</returns>
        public static TimeSpan operator -(TimeSpan t)
        {
            return new TimeSpan(-t._numberOfTicks);
        }

        /// <summary>
        /// Subtracts a specified TimeSpan from another specified TimeSpan.
        /// </summary>
        /// <param name="t1">The minuend.</param>
        /// <param name="t2">The subtrahend.</param>
        /// <returns>An object whose value is the result of the value of t1 minus the value of t2.</returns>
        public static TimeSpan operator -(TimeSpan t1, TimeSpan t2)
        {
            return new TimeSpan(t1._numberOfTicks - t2._numberOfTicks);
        }

        /// <summary>
        /// Returns the specified instance of TimeSpan.
        /// </summary>
        /// <param name="t">The time interval to return.</param>
        /// <returns>The time interval specified by t.</returns>
        public static TimeSpan operator +(TimeSpan t)
        {
            return t;
        }

        /// <summary>
        /// Adds two specified TimeSpan instances.
        /// </summary>
        /// <param name="t1">The first time interval to add.</param>
        /// <param name="t2">The second time interval to add.</param>
        /// <returns>An object whose value is the sum of the values of t1 and t2.</returns>
        public static TimeSpan operator +(TimeSpan t1, TimeSpan t2)
        {
            return new TimeSpan(t1._numberOfTicks + t2._numberOfTicks);
        }

        /// <summary>
        /// Indicates whether two TimeSpan instances are equal
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the values of t1 and t2 are equal; otherwise, false.</returns>
        public static bool operator ==(TimeSpan t1, TimeSpan t2)
        {
            return t1._numberOfTicks == t2._numberOfTicks;
        }

        /// <summary>
        /// Indicates whether two TimeSpan instances are not equal.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the values of t1 and t2 are not equal; otherwise, false.</returns>
        public static bool operator !=(TimeSpan t1, TimeSpan t2)
        {
            return t1._numberOfTicks != t2._numberOfTicks;
        }

        /// <summary>
        /// Indicates whether a specified TimeSpan is less than another specified TimeSpan.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the value of t1 is less than the value of t2; otherwise, false.</returns>
        public static bool operator <(TimeSpan t1, TimeSpan t2)
        {
            return t1._numberOfTicks < t2._numberOfTicks;
        }

        /// <summary>
        /// Indicates whether a specified TimeSpan is less than or equal to another specified TimeSpan.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the value of t1 is less than or equal to the value of t2; otherwise, false.</returns>
        public static bool operator <=(TimeSpan t1, TimeSpan t2)
        {
            return t1._numberOfTicks <= t2._numberOfTicks;
        }

        /// <summary>
        /// Indicates whether a specified TimeSpan is greater than another specified TimeSpan.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the value of t1 is greater than the value of t2; otherwise, false.</returns>
        public static bool operator >(TimeSpan t1, TimeSpan t2)
        {
            return t1._numberOfTicks > t2._numberOfTicks;
        }

        /// <summary>
        /// Indicates whether a specified TimeSpan is greater than or equal to another specified TimeSpan.
        /// </summary>
        /// <param name="t1">The first time interval to compare.</param>
        /// <param name="t2">The second time interval to compare.</param>
        /// <returns>true if the value of t1 is greater than or equal to the value of t2; otherwise, false.</returns>
        public static bool operator >=(TimeSpan t1, TimeSpan t2)
        {
            return t1._numberOfTicks >= t2._numberOfTicks;
        }

    }
}
