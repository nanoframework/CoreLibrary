//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Globalization;

    /// <summary>
    /// Represents a 64-bit signed integer.
    /// </summary>
    [Serializable]
    public struct Int64
    {
        internal long _value;

        /// <summary>
        /// Represents the largest possible value of an Int64. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is 9,223,372,036,854,775,807; that is, hexadecimal 0x7FFFFFFFFFFFFFFF.</remarks>
        public const long MaxValue = 0x7fffffffffffffffL;
        /// <summary>
        /// Represents the smallest possible value of an Int64. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is negative 9,223,372,036,854,775,808; that is, hexadecimal 0x8000000000000000.</remarks>
        public const long MinValue = unchecked((long)0x8000000000000000L);

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance, consisting of a minus sign if the value is negative, and a sequence of digits ranging from 0 to 9 with no leading zeroes.</returns>
        public override String ToString()
        {
            return Number.Format(_value, true, "G", NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation, using the specified format.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <returns>The string representation of the value of this instance as specified by format.</returns>
        public String ToString(String format)
        {
            return Number.Format(_value, true, format, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer equivalent.
        /// </summary>
        /// <param name="s">A string containing a number to convert. </param>
        /// <returns>A 64-bit signed integer equivalent to the number contained in s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
        public static long Parse(string s)
        {
            // check for null string is carried out in native code
            return Convert.ToInt64(s);
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="s">Converts the string representation of a number to its 64-bit signed integer equivalent. A return value indicates whether the conversion succeeded.</param>
        /// <param name="result">When this method returns, contains the 64-bit signed integer value equivalent of the number contained in <paramref name="s"/>, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or <see cref="string.Empty"/>, is not of the correct format, or represents a number less than <see cref="MinValue"/> or greater than <see cref="MaxValue"/>. This parameter is passed uninitialized; any value originally supplied in result will be overwritten.</param>
        /// <returns><see langword="true"/> if s was converted successfully; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// The <see cref="TryParse"/> method is like the <see cref="Parse"/> method, except the <see cref="TryParse"/> method does not throw an exception if the conversion fails. It eliminates the need to use exception handling to test for a <see cref="FormatException"/> in the event that <paramref name="s"/> is invalid and cannot be successfully parsed.
        /// </remarks>
        public static bool TryParse(
            string s,
            out long result)
        {
            result = Convert.NativeToInt64(
                s,
                true,
                MinValue,
                MaxValue,
                10,
                false,
                out bool success);

            return success;
        }
    }
}
