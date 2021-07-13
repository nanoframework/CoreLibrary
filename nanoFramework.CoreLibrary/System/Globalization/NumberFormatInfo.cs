//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Globalization
{
    using System;
    //
    // Property             Default Description
    // PositiveSign           '+'   Character used to indicate positive values.
    // NegativeSign           '-'   Character used to indicate negative values.
    // NumberDecimalSeparator '.'   The character used as the decimal separator.
    // NumberGroupSeparator   ','   The character used to separate groups of
    //                              digits to the left of the decimal point.
    // NumberDecimalDigits    2     The default number of decimal places.
    // NumberGroupSizes       3     The number of digits in each group to the
    //                              left of the decimal point.
    // NaNSymbol             "NaN"  The string used to represent NaN values.
    // PositiveInfinitySymbol"Infinity" The string used to represent positive
    //                              infinities.
    // NegativeInfinitySymbol"-Infinity" The string used to represent negative
    //                              infinities.
    //
    //
    //
    // Property                  Default  Description
    // CurrencyDecimalSeparator  '.'      The character used as the decimal
    //                                    separator.
    // CurrencyGroupSeparator    ','      The character used to separate groups
    //                                    of digits to the left of the decimal
    //                                    point.
    // CurrencyDecimalDigits     2        The default number of decimal places.
    // CurrencyGroupSizes        3        The number of digits in each group to
    //                                    the left of the decimal point.
    // CurrencyPositivePattern   0        The format of positive values.
    // CurrencyNegativePattern   0        The format of negative values.
    // CurrencySymbol            "$"      String used as local monetary symbol.
    //

    /// <summary>
    /// Provides culture-specific information for formatting and parsing numeric values.
    /// </summary>
    [Serializable]
    public sealed class NumberFormatInfo /*: ICloneable, IFormatProvider*/
    {
        internal int[] _numberGroupSizes = new int[] { 3 };
        internal String _positiveSign = "+";
        internal String _negativeSign = "-";
        internal String _numberDecimalSeparator = ".";
        internal String _numberGroupSeparator = ",";
        private readonly CultureInfo _cultureInfo;

        internal NumberFormatInfo(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
        }

        /// <summary>
        /// Gets the number of digits in each group to the left of the decimal in numeric values.
        /// </summary>
        /// <value>The number of digits in each group to the left of the decimal in numeric values. The default for InvariantInfo is a one-dimensional array with only one element, which is set to 3.</value>
        /// <exception cref="System.InvalidOperationException"></exception>
        public int[] NumberGroupSizes
        {
            get
            {
                return _numberGroupSizes;
            }
        }

        /// <summary>
        /// Gets a read-only NumberFormatInfo that formats values based on the current culture.
        /// </summary>
        /// <value>A read-only NumberFormatInfo based on the culture of the current thread.</value>
        public static NumberFormatInfo CurrentInfo
        {
            get
            {
                return CultureInfo.CurrentUICulture.NumberFormat;
            }
        }

        /// <summary>
        /// Gets the string that denotes that the associated number is negative.
        /// </summary>
        /// <value>The string that denotes that the associated number is negative. The default for InvariantInfo is "-".</value>
        public String NegativeSign
        {
            get
            {
                return _negativeSign;
            }
        }

        /// <summary>
        /// Gets the string to use as the decimal separator in numeric values.
        /// </summary>
        /// <value>The string to use as the decimal separator in numeric values. The default for InvariantInfo is ".".</value>
        public String NumberDecimalSeparator
        {
            get
            {
                return _numberDecimalSeparator;
            }
        }

        /// <summary>
        /// Gets the string that separates groups of digits to the left of the decimal in numeric values.
        /// </summary>
        /// <value>The string that separates groups of digits to the left of the decimal in numeric values. The default for InvariantInfo is ",".</value>
        public String NumberGroupSeparator
        {
            get
            {
                return _numberGroupSeparator;
            }
        }

        /// <summary>
        /// Gets the string that denotes that the associated number is positive.
        /// </summary>
        /// <value>The string that denotes that the associated number is positive. The default for InvariantInfo is "+".</value>
        public String PositiveSign
        {
            get
            {
                return _positiveSign;
            }
        }
    }
}
