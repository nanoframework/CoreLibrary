//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Globalization;

    /// <summary>
    /// Represents an 8-bit signed integer.
    /// </summary>
    [Serializable, CLSCompliant(false)]
    public struct SByte
    {
        // this field is required in the native end
#pragma warning disable 0649
        private sbyte _value;
#pragma warning restore 0649

        /// <summary>
        /// Represents the largest possible value of SByte. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is 127; that is, hexadecimal 0x7F.</remarks>
        public const sbyte MaxValue = 0x7F;

        /// <summary>
        /// Represents the smallest possible value of SByte. This field is constant.
        /// </summary>
        /// /// <remarks>The value of this constant is -128; that is, hexadecimal 0x80.</remarks>
        public const sbyte MinValue = unchecked((sbyte)0x80);

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
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <returns>The string representation of the value of this instance as specified by format.</returns>
        public String ToString(String format)
        {
            return Number.Format(_value, true, format, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the string representation of a number to its 8-bit signed integer equivalent.
        /// </summary>
        /// <param name="s">A string that represents a number to convert. The string is interpreted using the NumberStyles.Integer style.</param>
        /// <returns>An 8-bit signed integer that is equivalent to the number contained in the s parameter.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        [CLSCompliant(false)]
        public static sbyte Parse(String s)
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (s == null) throw new ArgumentNullException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            return Convert.ToSByte(s);
        }

    }
}
