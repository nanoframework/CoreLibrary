//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Globalization
{
    using System;

    /// <summary>
    /// Defines the period of daylight saving time.
    /// </summary>
    [Serializable]
    public class DaylightTime
    {
        internal DateTime _daylightTimeStart;
        internal DateTime _daylightTimeEnd;
        internal TimeSpan _daylightTimeDelta;

        private DaylightTime()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DaylightTime class with the specified start, end, and time difference information.
        /// </summary>
        /// <param name="start">The object that represents the date and time when daylight saving time begins. The value must be in local time.</param>
        /// <param name="end">The object that represents the date and time when daylight saving time ends. The value must be in local time.</param>
        /// <param name="delta">The object that represents the difference between standard time and daylight saving time, in ticks.</param>
        public DaylightTime(DateTime start, DateTime end, TimeSpan delta)
        {
            _daylightTimeStart = start;
            _daylightTimeEnd = end;
            _daylightTimeDelta = delta;
        }

        /// <summary>
        /// Gets the object that represents the date and time when the daylight saving period begins.
        /// </summary>
        /// <value>The object that represents the date and time when the daylight saving period begins. The value is in local time.</value>
        public DateTime Start
        {
            get
            {
                return _daylightTimeStart;
            }
        }

        /// <summary>
        /// Gets the object that represents the date and time when the daylight saving period ends.
        /// </summary>
        /// <value>The object that represents the date and time when the daylight saving period ends. The value is in local time.</value>
        public DateTime End
        {
            get
            {
                return _daylightTimeEnd;
            }
        }

        /// <summary>
        /// Gets the time interval that represents the difference between standard time and daylight saving time.
        /// </summary>
        /// <value>The time interval that represents the difference between standard time and daylight saving time.</value>
        public TimeSpan Delta
        {
            get
            {
                return _daylightTimeDelta;
            }
        }
    }
}
