//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Globalization;

    /// <summary>
    /// Represents a 16-bit unsigned integer.
    /// </summary>
    [Serializable, CLSCompliant(false)]
    public struct UInt16
    {
        // this field is required in the native end
#pragma warning disable 0649
        private ushort _value;
#pragma warning restore 0649

        /// <summary>
        /// Represents the largest possible value of UInt16. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is 65535; that is, hexadecimal 0xFFFF.</remarks>
        public const ushort MaxValue = 0xFFFF;
        /// <summary>
        /// Represents the smallest possible value of UInt16. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is 0.</remarks>
        public const ushort MinValue = 0;

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance, which consists of a sequence of digits ranging from 0 to 9, without a sign or leading zeros.</returns>
        public override String ToString()
        {
            return Number.Format(_value, true, "G", NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation using the specified format.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <returns>The string representation of the value of this instance as specified by format.</returns>
        public String ToString(String format)
        {
            return Number.Format(_value, true, format, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="s">A string that represents the number to convert.</param>
        /// <returns>A 16-bit unsigned integer equivalent to the number contained in s.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [CLSCompliant(false)]
        public static ushort Parse(String s)
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (s == null) throw new ArgumentNullException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            return Convert.ToUInt16(s);
        }

    }
}
