//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Globalization;

    /// <summary>
    /// Represents a 16-bit signed integer.
    /// </summary>
    [Serializable]
    public struct Int16
    {
        // this field is required in the native end
#pragma warning disable 0649
        internal short _value;
#pragma warning restore 0649

        /// <summary>
        /// Represents the largest possible value of an Int16. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is 32767; that is, hexadecimal 0x7FFF.</remarks>
        public const short MaxValue = 0x7FFF;
        /// <summary>
        /// Represents the smallest possible value of Int16. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is -32768; that is, hexadecimal 0x8000.</remarks>
        public const short MinValue = unchecked((short)0x8000);

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance, consisting of a minus sign if the value is negative, and a sequence of digits ranging from 0 to 9 with no leading zeroes.</returns>
        public override String ToString()
        {
            return Number.Format(_value, true, "G", NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation, using the specified format
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <returns>The string representation of the value of this instance as specified by format.</returns>
        public String ToString(String format)
        {
            return Number.Format(_value, true, format, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed integer equivalent.
        /// </summary>
        /// <param name="s">A string containing a number to convert. </param>
        /// <returns>A 16-bit signed integer equivalent to the number contained in s.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static short Parse(String s)
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (s == null) throw new ArgumentNullException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            return Convert.ToInt16(s);
        }

    }
}
