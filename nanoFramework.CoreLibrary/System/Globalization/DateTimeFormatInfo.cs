//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

// ReSharper disable InconsistentNaming
#define ENABLE_CROSS_APPDOMAIN
namespace System.Globalization
{
    using System;

    /// <summary>
    /// Provides culture-specific information about the format of date and time values.
    /// </summary>
    public sealed class DateTimeFormatInfo /*: ICloneable, IFormatProvider*/
    {
        internal String _generalShortTimePattern = "MM/dd/yyyy HH:mm";
        internal String _generalLongTimePattern = "MM/dd/yyyy HH:mm:ss";
        internal const String _rfc1123Pattern = "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'";
        internal const String _sortableDateTimePattern = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";
        internal const String _universalSortableDateTimePattern = "yyyy'-'MM'-'dd HH':'mm':'ss'Z'";
        internal String _fullDateTimePattern = "dddd, dd MMMM yyyy HH:mm:ss";

        internal DateTimeFormatInfo(CultureInfo cultureInfo)
        {
        }

        /// <summary>
        /// Gets a read-only DateTimeFormatInfo object that formats values based on the current culture.
        /// </summary>
        /// <value>A read-only DateTimeFormatInfo object based on the CultureInfo object for the current thread.</value>
        public static DateTimeFormatInfo CurrentInfo
        {
            get
            {
                return CultureInfo.CurrentUICulture.DateTimeFormat;
            }
        }

        /// <summary>
        /// Gets the string designator for hours that are "ante meridiem" (before noon).
        /// </summary>
        /// <value>The string designator for hours that are ante meridiem. The default for InvariantInfo is "AM".</value>
        public String AMDesignator
        {
            get
            {
                return "AM";
            }
        }

        /// <summary>
        /// Gets the string that separates the components of a date, that is, the year, month, and day.
        /// </summary>
        /// <value>The string that separates the components of a date, that is, the year, month, and day. The default for InvariantInfo is "/".</value>
        public String DateSeparator
        {
            get
            {
                return "/";
            }
        }

        /// <summary>
        /// Gets the custom format string for a long date and long time value.
        /// </summary>
        /// <value>The custom format string for a long date and long time value.</value>
        public String FullDateTimePattern
        {
            get
            {
                return _fullDateTimePattern;
            }
        }

        /// <summary>
        /// Gets the custom format string for a long date value.
        /// </summary>
        /// <value>The custom format string for a long date value.</value>
        public String LongDatePattern
        {
            get
            {
                return "dddd, dd MMMM yyyy";
            }
        }

        /// <summary>
        /// Gets the custom format string for a long time value.
        /// </summary>
        /// <value>The format pattern for a long time value.</value>
        public String LongTimePattern
        {
            get
            {
                return "HH:mm:ss";
            }
        }

        /// <summary>
        /// Gets the custom format string for a month and day value.
        /// </summary>
        /// <value>The custom format string for a month and day value.</value>
        public String MonthDayPattern
        {
            get
            {
                return "MMMM dd";
            }
        }

        /// <summary>
        /// Gets the string designator for hours that are "post meridiem" (after noon).
        /// </summary>
        /// <value>The string designator for hours that are "post meridiem" (after noon). The default for InvariantInfo is "PM".</value>
        public String PMDesignator
        {
            get
            {
                return "PM";
            }
        }

        /// <summary>
        /// Gets the custom format string for a time value that is based on the Internet Engineering Task Force (IETF) Request for Comments (RFC) 1123 specification.
        /// </summary>
        /// <value>The custom format string for a time value that is based on the IETF RFC 1123 specification.</value>
        public String RFC1123Pattern
        {
            get
            {
                return _rfc1123Pattern;
            }
        }

        /// <summary>
        /// Gets the custom format string for a short date value.
        /// </summary>
        /// <value>The custom format string for a short date value.</value>
        public String ShortDatePattern
        {
            get
            {
                return "MM/dd/yyyy";
            }
        }

        /// <summary>
        /// Gets the custom format string for a short time value.
        /// </summary>
        /// <value>The custom format string for a short time value.</value>
        public String ShortTimePattern
        {
            get
            {
                return "HH:mm";
            }
        }

        /// <summary>
        /// Gets the custom format string for a sortable date and time value.
        /// </summary>
        /// <value>The custom format string for a sortable date and time value.</value>
        public String SortableDateTimePattern
        {
            get
            {
                return _sortableDateTimePattern;
            }
        }

        internal String GeneralShortTimePattern
        {
            get
            {
                return _generalShortTimePattern;
            }
        }

        internal String GeneralLongTimePattern
        {
            get
            {
                return _generalLongTimePattern;
            }
        }

        /// <summary>
        /// Gets the string that separates the components of time, that is, the hour, minutes, and seconds.
        /// </summary>
        /// <value>The string that separates the components of time. The default for InvariantInfo is ":".</value>
        public String TimeSeparator
        {
            get
            {
                return ":";
            }
        }

        /// <summary>
        /// Gets the custom format string for a universal, sortable date and time string.
        /// </summary>
        /// <value>The custom format string for a universal, sortable date and time string.</value>
        public String UniversalSortableDateTimePattern
        {
            get
            {
                return _universalSortableDateTimePattern;
            }
        }

        /// <summary>
        /// Gets the custom format string for a year and month value.
        /// </summary>
        /// <value>The custom format string for a year and month value.</value>
        public String YearMonthPattern
        {
            get
            {
                return "yyyy MMMM";
            }
        }

        /// <summary>
        /// Gets a one-dimensional array of type String containing the culture-specific abbreviated names of the days of the week.
        /// </summary>
        /// <value>A one-dimensional array of type String containing the culture-specific abbreviated names of the days of the week. The array for InvariantInfo contains "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", and "Sat".</value>
        public String[] AbbreviatedDayNames
        {
            get
            {
                return new String[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            }
        }

        /// <summary>
        /// Gets a one-dimensional string array that contains the culture-specific full names of the days of the week.
        /// </summary>
        /// <value>A one-dimensional string array that contains the culture-specific full names of the days of the week. The array for InvariantInfo contains "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", and "Saturday".</value>
        public String[] DayNames
        {
            get
            {
                return new String[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            }
        }

        /// <summary>
        /// Gets or sets a one-dimensional string array that contains the culture-specific abbreviated names of the months.
        /// </summary>
        /// <value>A one-dimensional string array with 13 elements that contains the culture-specific abbreviated names of the months. For 12-month calendars, the 13th element of the array is an empty string. 
        /// The array for InvariantInfo contains "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", and "".</value>
        public String[] AbbreviatedMonthNames
        {
            get
            {
                return new String[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "" };
            }
        }

        /// <summary>
        /// Gets or sets a one-dimensional array of type String containing the culture-specific full names of the months.
        /// </summary>
        /// <value>A one-dimensional array of type String containing the culture-specific full names of the months. In a 12-month calendar, the 13th element of the array is an empty string. 
        /// The array for InvariantInfo contains "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", and "".</value>
        public String[] MonthNames
        {
            get
            {
                return new String[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", "" };
            }
        }
    }
}
