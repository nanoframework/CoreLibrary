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
        /// <exception cref="ArgumentNullException"></exception>
        public static long Parse(String s)
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (s == null) throw new ArgumentNullException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            return Convert.ToInt64(s);
        }

    }
}
