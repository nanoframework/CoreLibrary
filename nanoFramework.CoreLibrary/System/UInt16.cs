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
        // Do not rename (binary serialization)
        private ushort m_value;
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
            return Number.Format(m_value, true, "G", NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation using the specified format.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <returns>The string representation of the value of this instance as specified by format.</returns>
        public String ToString(String format)
        {
            return Number.Format(m_value, true, format, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="s">A string that represents the number to convert.</param>
        /// <returns>A 16-bit unsigned integer equivalent to the number contained in s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static ushort Parse(string s)
        {
            // check for null string is carried out in native code
            return Convert.ToUInt16(s);
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit unsigned integer equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A <see cref="string"/> that contains a number to convert.</param>
        /// <param name="result">When this method returns, contains the 16-bit unsigned integer value equivalent to the number contained in <paramref name="s"/>, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or <see cref="string.Empty"/>, is not of the correct format, or represents a number less than <see cref="MinValue"/> or greater than <see cref="MaxValue"/>. This parameter is passed uninitialized; any value originally supplied in <paramref name="result"/> will be overwritten.</param>
        /// <returns>true if <paramref name="s"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// The <see cref="TryParse"/> method differs from the <see cref="Parse"/> method by returning a <see cref="bool"/> value that indicates whether the parse operation succeeded instead of returning the parsed <see cref="short"/> value. It eliminates the need to use exception handling to test for a <see cref="FormatException"/> in the event that <paramref name="s"/> is invalid and cannot be successfully parsed.
        /// </remarks>
        public static bool TryParse(
            string s,
            out ushort result)
        {
            result = (ushort)Convert.NativeToInt64(
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
