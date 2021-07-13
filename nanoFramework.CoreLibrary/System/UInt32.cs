//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Globalization;

    /// <summary>
    /// Represents a 32-bit unsigned integer.
    /// </summary>
    [Serializable, CLSCompliant(false)]
    public struct UInt32
    {
        // this field is required in the native end
#pragma warning disable 0649
        private uint _value;
#pragma warning restore 0649

        /// <summary>
        /// Represents the largest possible value of UInt32. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is 4,294,967,295; that is, hexadecimal 0xFFFFFFFF.</remarks>
        public const uint MaxValue = 0xffffffff;
        /// <summary>
        /// Represents the smallest possible value of UInt32. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is 0.</remarks>
        public const uint MinValue = 0U;

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance, consisting of a sequence of digits ranging from 0 to 9, without a sign or leading zeroes.</returns>
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
        /// Converts the string representation of a number to its 32-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="s">A string representing the number to convert.</param>
        /// <returns>A 32-bit unsigned integer equivalent to the number contained in s.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [CLSCompliant(false)]
        public static uint Parse(String s)
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (s == null) throw new ArgumentNullException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            return Convert.ToUInt32(s);
        }

    }
}
