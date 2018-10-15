//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Globalization;

    /// <summary>
    /// Represents a 32-bit signed integer.
    /// </summary>
    [Serializable]
    public struct Int32
    {
        internal int _value;

        /// <summary>
        /// Represents the largest possible value of an Int32. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is 2,147,483,647; that is, hexadecimal 0x7FFFFFFF.</remarks>
        public const int MaxValue = 0x7fffffff;
        /// <summary>
        /// Represents the smallest possible value of Int32. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is -2,147,483,648; that is, hexadecimal 0x80000000.</remarks>
        public const int MinValue = unchecked((int)0x80000000);

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance, consisting of a negative sign if the value is negative, and a sequence of digits ranging from 0 to 9 with no leading zeroes.</returns>
        public override String ToString()
        {
            return Number.Format(_value, true, "G", NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation, using the specified format.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string</param>
        /// <returns>he string representation of the value of this instance as specified by format.</returns>
        public String ToString(String format)
        {
            return Number.Format(_value, true, format, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="s">A string containing a number to convert. </param>
        /// <returns>A 32-bit signed integer equivalent to the number contained in s.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int Parse(String s)
        {
            if (s == null) throw new ArgumentNullException();

            return Convert.ToInt32(s);
        }

    }
}
