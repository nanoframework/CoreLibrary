//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

// ReSharper disable InconsistentNaming
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
        internal int[] numberGroupSizes;//new int[] { 3 };
        internal String positiveSign;//"+";
        internal String negativeSign;//"-";
        internal String numberDecimalSeparator;//".";
        internal String numberGroupSeparator;//",";
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
                if (numberGroupSizes == null)
                {
                    String sizesStr = null;

                    _cultureInfo.EnsureStringResource(ref sizesStr, Resources.CultureInfo.StringResources.NumberGroupSizes);

                    var sizesLen = sizesStr.Length;
                    numberGroupSizes = new int[sizesLen];

                    for (var i = 0; i < sizesLen; i++)
                    {
                        var size = sizesStr[i] - '0';
                        if (size > 9 || size < 0)
                        {
                            numberGroupSizes = null;
                            throw new InvalidOperationException();
                        }

                        numberGroupSizes[i] = size;
                    }
                }

                return (int[])numberGroupSizes.Clone();
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
                return _cultureInfo.EnsureStringResource(ref negativeSign, Resources.CultureInfo.StringResources.NegativeSign);
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
                return _cultureInfo.EnsureStringResource(ref numberDecimalSeparator, Resources.CultureInfo.StringResources.NumberDecimalSeparator);
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
                return _cultureInfo.EnsureStringResource(ref numberGroupSeparator, Resources.CultureInfo.StringResources.NumberGroupSeparator);
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
                return _cultureInfo.EnsureStringResource(ref positiveSign, Resources.CultureInfo.StringResources.PositiveSign);
            }
        }
    }
}


