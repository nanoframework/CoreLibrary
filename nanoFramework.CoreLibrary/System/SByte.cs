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
        /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static sbyte Parse(string s)
        {
            // check for null string is carried out in native code
            return Convert.ToSByte(s);
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its <see cref="SByte"/> equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="s">A string that contains a number to convert.</param>
        /// <param name="result">When this method returns, contains the 8-bit signed integer value that is equivalent to the number contained in <paramref name="s"/> if the conversion succeeded, or zero if the conversion failed. The conversion fails if the s parameter is <see langword="null"/> or <see cref="string.Empty"/>, is not in the correct format, or represents a number that is less than <see cref="MinValue"/> or greater than <see cref="MaxValue"/>. This parameter is passed uninitialized; any value originally supplied in result will be overwritten.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// The <see cref="TryParse"/>(String, SByte) method is like the <see cref="Parse"/>(String) method, except that it does not throw an exception if the conversion fails. This method eliminates the need to use exception handling to test for a <see cref="FormatException"/> if value is invalid and cannot be successfully parsed.
        /// </remarks>
        [CLSCompliant(false)]
        public static bool TryParse(
            string s,
            out sbyte result)
        {
            result = (sbyte)Convert.NativeToInt64(
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
