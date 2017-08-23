//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#define ENABLE_CROSS_APPDOMAIN
namespace System.Globalization
{
    using Runtime.CompilerServices;
    using System;

    /// <summary>
    /// Provides information about a specific culture (called a locale for unmanaged code development). 
    /// The information includes the names for the culture, the writing system, the calendar used, the sort order of strings, and formatting for dates and numbers.
    /// </summary>
    public class CultureInfo /*: ICloneable , IFormatProvider*/
    {
        internal NumberFormatInfo _numInfo;
        internal DateTimeFormatInfo _dateTimeInfo;
        internal string _cultureInfoName;
        [NonSerialized]
        private CultureInfo _parent;

        public CultureInfo(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            _cultureInfoName = "";
        }

        /// <summary>
        /// Gets or sets the CultureInfo object that represents the current user interface culture used by the Resource Manager to look up culture-specific resources at run time.
        /// </summary>
        /// <value>The culture used by the Resource Manager to look up culture-specific resources at run time.</value>
        public static CultureInfo CurrentUICulture
        {
            get
            {
                return CurrentUICultureInternal;
            }
        }

        private static extern CultureInfo CurrentUICultureInternal
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the CultureInfo that represents the parent culture of the current CultureInfo.
        /// </summary>
        /// <value>The CultureInfo that represents the parent culture of the current CultureInfo.</value>
        public virtual CultureInfo Parent
        {
            get
            {
                return this;
            }
        }


        /// <summary>
        /// Gets the culture name in the format languagecode2-country/regioncode2.
        /// </summary>
        /// <value>The culture name in the format languagecode2-country/regioncode2. languagecode2 is a lowercase two-letter code derived from ISO 639-1. 
        /// country/regioncode2 is derived from ISO 3166 and usually consists of two uppercase letters, or a BCP-47 language tag.</value>
        public virtual String Name
        {
            get
            {
                return _cultureInfoName;
            }
        }

        /// <summary>
        /// Returns a string containing the name of the current CultureInfo in the format languagecode2-country/regioncode2.
        /// </summary>
        /// <returns>A string containing the name of the current CultureInfo.</returns>
        public override String ToString()
        {
            return _cultureInfoName;
        }

        /// <summary>
        /// Gets a NumberFormatInfo that defines the culturally appropriate format of displaying numbers, currency, and percentage.
        /// </summary>
        /// <value>A NumberFormatInfo that defines the culturally appropriate format of displaying numbers, currency, and percentage.</value>
        public virtual NumberFormatInfo NumberFormat
        {
            get
            {

                if (_numInfo == null) _numInfo = new NumberFormatInfo(this);

                return _numInfo;
            }
        }

        /// <summary>
        /// Gets a DateTimeFormatInfo that defines the culturally appropriate format of displaying dates and times.
        /// </summary>
        /// <value>A DateTimeFormatInfo that defines the culturally appropriate format of displaying dates and times.</value>
        public virtual DateTimeFormatInfo DateTimeFormat
        {
            get
            {
                if (_dateTimeInfo == null) _dateTimeInfo = new DateTimeFormatInfo(this);

                return _dateTimeInfo;
            }
        }
    }
}
