//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
namespace System
{
    using Runtime.CompilerServices;
    using Globalization;

    /// <summary>
    /// Represents a time zone.
    /// </summary>
    [Serializable]
    public abstract class TimeZone
    {
        internal int Id;

        /// <summary>
        /// Initializes a new instance of the TimeZone class.
        /// </summary>
        protected TimeZone() { }

        /// <summary>
        /// Gets the time zone of the current computer.
        /// </summary>
        /// <value>
        /// A TimeZone object that represents the current local time zone.
        /// </value>
        public static TimeZone CurrentTimeZone
        {
            get
            {
                return new CurrentSystemTimeZone(GetTimeZoneOffset());
            }
        }

        /// <summary>
        /// Gets the standard time zone name.
        /// </summary>
        /// <value>
        /// The standard time zone name.
        /// </value>
        public abstract String StandardName
        {
            get;
        }

        /// <summary>
        /// Gets the daylight saving time zone name.
        /// </summary>
        /// <value>
        /// The daylight saving time zone name.
        /// </value>
        public abstract String DaylightName
        {
            get;
        }

        /// <summary>
        /// Returns the Coordinated Universal Time (UTC) offset for the specified local time.
        /// </summary>
        /// <param name="time">A date and time value.</param>
        /// <returns>The Coordinated Universal Time (UTC) offset from time.</returns>
        public abstract TimeSpan GetUtcOffset(DateTime time);

        /// <summary>
        /// Returns the Coordinated Universal Time (UTC) that corresponds to a specified time.
        /// </summary>
        /// <param name="time">A date and time.</param>
        /// <returns>A DateTime object whose value is the Coordinated Universal Time (UTC) that corresponds to time.</returns>
        public virtual DateTime ToUniversalTime(DateTime time)
        {
            return time.Kind == DateTimeKind.Utc ? time : new DateTime(time.Ticks - GetTimeZoneOffset(), DateTimeKind.Utc);
        }

        /// <summary>
        /// Returns the local time that corresponds to a specified date and time value.
        /// </summary>
        /// <param name="time">A Coordinated Universal Time (UTC) time.</param>
        /// <returns>A DateTime object whose value is the local time that corresponds to time.</returns>
        public virtual DateTime ToLocalTime(DateTime time)
        {
            return time.Kind == DateTimeKind.Local ? time : new DateTime(time.Ticks + GetTimeZoneOffset(), DateTimeKind.Local);
        }

        /// <summary>
        /// Returns the daylight saving time period for a particular year.
        /// </summary>
        /// <param name="year">The year that the daylight saving time period applies to.</param>
        /// <returns>A System.Globalization.DaylightTime object that contains the start and end date for daylight saving time in year.</returns>
        public abstract DaylightTime GetDaylightChanges(int year);

        /// <summary>
        /// Returns a value indicating whether the specified date and time is within a daylight saving time period.
        /// </summary>
        /// <param name="time">A date and time.</param>
        /// <returns>true if time is in a daylight saving time period; otherwise, false.</returns>
        public virtual bool IsDaylightSavingTime(DateTime time)
        {
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        internal static extern long GetTimeZoneOffset();
    }

    [Serializable]
    internal class CurrentSystemTimeZone : TimeZone
    {
        protected long TicksOffset;

        internal CurrentSystemTimeZone()
        {
        }

        internal CurrentSystemTimeZone(long ticksOffset)
        {
            TicksOffset = ticksOffset;
        }

        public override String StandardName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override String DaylightName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override DaylightTime GetDaylightChanges(int year)
        {
            throw new NotImplementedException();
        }

        public override TimeSpan GetUtcOffset(DateTime time)
        {
            return time.Kind == DateTimeKind.Utc ? TimeSpan.Zero : new TimeSpan(TicksOffset);
        }
    }
}
