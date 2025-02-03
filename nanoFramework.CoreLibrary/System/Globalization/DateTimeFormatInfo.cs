// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// ReSharper disable InconsistentNaming
#define ENABLE_CROSS_APPDOMAIN
namespace System.Globalization
{
    /// <summary>
    /// Provides culture-specific information about the format of date and time values.
    /// </summary>
    public sealed class DateTimeFormatInfo /*: ICloneable, IFormatProvider*/
    {
        internal const string _sortableDatePattern = "yyyy'-'MM'-'dd";
        internal const string _sortableTimePattern = "HH':'mm':'ss";

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
        public string AMDesignator
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
        public string DateSeparator
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
        public string FullDateTimePattern
        {
            get
            {
                return LongDatePattern + " " + LongTimePattern;
            }
        }

        /// <summary>
        /// Gets the custom format string for a long date value.
        /// </summary>
        /// <value>The custom format string for a long date value.</value>
        public string LongDatePattern
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
        public string LongTimePattern
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
        public string MonthDayPattern
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
        public string PMDesignator
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
        public string RFC1123Pattern
        {
            get
            {
                return "ddd, dd MMM yyyy " + _sortableTimePattern + " 'GMT'";
            }
        }

        /// <summary>
        /// Gets the custom format string for a short date value.
        /// </summary>
        /// <value>The custom format string for a short date value.</value>
        public string ShortDatePattern
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
        public string ShortTimePattern
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
        public string SortableDateTimePattern
        {
            get
            {
                return _sortableDatePattern + "'T'" + _sortableTimePattern;
            }
        }

        internal string GeneralShortTimePattern
        {
            get
            {
                return ShortDatePattern + " " + ShortTimePattern;
            }
        }

        internal string GeneralLongTimePattern
        {
            get
            {
                return ShortDatePattern + " " + LongTimePattern;
            }
        }

        /// <summary>
        /// Gets the string that separates the components of time, that is, the hour, minutes, and seconds.
        /// </summary>
        /// <value>The string that separates the components of time. The default for InvariantInfo is ":".</value>
        public string TimeSeparator
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
        public string UniversalSortableDateTimePattern
        {
            get
            {
                return _sortableDatePattern + " " + _sortableTimePattern + "'Z'";
            }
        }

        /// <summary>
        /// Gets the custom format string for a year and month value.
        /// </summary>
        /// <value>The custom format string for a year and month value.</value>
        public string YearMonthPattern
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
        public string[] AbbreviatedDayNames
        {
            get
            {
                return new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            }
        }

        /// <summary>
        /// Gets a one-dimensional string array that contains the culture-specific full names of the days of the week.
        /// </summary>
        /// <value>A one-dimensional string array that contains the culture-specific full names of the days of the week. The array for InvariantInfo contains "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", and "Saturday".</value>
        public string[] DayNames
        {
            get
            {
                return new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            }
        }

        /// <summary>
        /// Gets or sets a one-dimensional string array that contains the culture-specific abbreviated names of the months.
        /// </summary>
        /// <value>A one-dimensional string array with 13 elements that contains the culture-specific abbreviated names of the months. For 12-month calendars, the 13th element of the array is an empty string. 
        /// The array for InvariantInfo contains "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", and "".</value>
        public string[] AbbreviatedMonthNames
        {
            get
            {
                return new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "" };
            }
        }

        /// <summary>
        /// Gets or sets a one-dimensional array of type String containing the culture-specific full names of the months.
        /// </summary>
        /// <value>A one-dimensional array of type String containing the culture-specific full names of the months. In a 12-month calendar, the 13th element of the array is an empty string. 
        /// The array for InvariantInfo contains "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", and "".</value>
        public string[] MonthNames
        {
            get
            {
                return new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", "" };
            }
        }
    }
}
