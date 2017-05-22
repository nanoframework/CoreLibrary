//
// Copyright (c) 2017 The nanoFramework project contributors
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
        internal String amDesignator;
        internal String pmDesignator;
        internal String dateSeparator;
        internal String longTimePattern;
        internal String shortTimePattern;
        internal String generalShortTimePattern;
        internal String generalLongTimePattern;
        internal String timeSeparator;
        internal String monthDayPattern;
        internal const String rfc1123Pattern = "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'";
        internal const String sortableDateTimePattern = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";
        internal const String universalSortableDateTimePattern = "yyyy'-'MM'-'dd HH':'mm':'ss'Z'";
        internal String fullDateTimePattern;
        internal String longDatePattern;
        internal String shortDatePattern;
        internal String yearMonthPattern;
        internal String[] abbreviatedDayNames;
        internal String[] dayNames;
        internal String[] abbreviatedMonthNames;
        internal String[] monthNames;
        private readonly CultureInfo _cultureInfo;

        internal DateTimeFormatInfo(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
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
                return _cultureInfo.EnsureStringResource(ref amDesignator, Resources.CultureInfo.StringResources.AMDesignator);
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
                return _cultureInfo.EnsureStringResource(ref dateSeparator, Resources.CultureInfo.StringResources.DateSeparator);
            }
        }

        /// <summary>
        /// Gets or sets the custom format string for a long date and long time value.
        /// </summary>
        /// <value>The custom format string for a long date and long time value.</value>
        public String FullDateTimePattern
        {
            get
            {
                if (fullDateTimePattern == null) fullDateTimePattern = LongDatePattern + " " + LongTimePattern;

                return fullDateTimePattern;
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
                return _cultureInfo.EnsureStringResource(ref longDatePattern, Resources.CultureInfo.StringResources.LongDatePattern);
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
                return _cultureInfo.EnsureStringResource(ref longTimePattern, Resources.CultureInfo.StringResources.LongTimePattern);
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
                return _cultureInfo.EnsureStringResource(ref monthDayPattern, Resources.CultureInfo.StringResources.MonthDayPattern);
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
                return _cultureInfo.EnsureStringResource(ref pmDesignator, Resources.CultureInfo.StringResources.PMDesignator);
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
                return rfc1123Pattern;
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
                return _cultureInfo.EnsureStringResource(ref shortDatePattern, Resources.CultureInfo.StringResources.ShortDatePattern);
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
                return _cultureInfo.EnsureStringResource(ref shortTimePattern, Resources.CultureInfo.StringResources.ShortTimePattern);
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
                return sortableDateTimePattern;
            }
        }

        internal String GeneralShortTimePattern
        {
            get
            {
                if (generalShortTimePattern == null) generalShortTimePattern = ShortDatePattern + " " + ShortTimePattern;

                return generalShortTimePattern;
            }
        }

        /*=================================GeneralLongTimePattern=====================
      //*Property: Return the pattern for 'g' general format: shortDate + Long time
      //*Note: This is used by DateTimeFormat.cs to get the pattern for 'g'
      //*      We put this internal property here so that we can avoid doing the
      //*      concatation every time somebody asks for the general format.
        ==============================================================================*/
        internal String GeneralLongTimePattern
        {
            get
            {
                if (generalLongTimePattern == null) generalLongTimePattern = ShortDatePattern + " " + LongTimePattern;

                return generalLongTimePattern;
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
                return _cultureInfo.EnsureStringResource(ref timeSeparator, Resources.CultureInfo.StringResources.TimeSeparator);
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
                return universalSortableDateTimePattern;
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
                return _cultureInfo.EnsureStringResource(ref yearMonthPattern, Resources.CultureInfo.StringResources.YearMonthPattern);
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
                return _cultureInfo.EnsureStringArrayResource(ref abbreviatedDayNames, Resources.CultureInfo.StringResources.AbbreviatedDayNames);
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
                return _cultureInfo.EnsureStringArrayResource(ref dayNames, Resources.CultureInfo.StringResources.DayNames);
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
                return _cultureInfo.EnsureStringArrayResource(ref abbreviatedMonthNames, Resources.CultureInfo.StringResources.AbbreviatedMonthNames);
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
                return _cultureInfo.EnsureStringArrayResource(ref monthNames, Resources.CultureInfo.StringResources.MonthNames);
            }
        }
    }
}


