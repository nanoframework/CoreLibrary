//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Globalization;

    /// <summary>
    /// Represents a 64-bit ununsigned integer.
    /// </summary>
    [Serializable, CLSCompliant(false)]
    public struct UInt64
    {
        // this field is required in the native end
#pragma warning disable 0649        
        // Do not rename (binary serialization)
        private ulong m_value;
#pragma warning restore 0649

        /// <summary>
        /// Represents the largest possible value of UInt64. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is 18,446,744,073,709,551,615; that is, hexadecimal 0xFFFFFFFFFFFFFFFF.</remarks>
        public const ulong MaxValue = 0xffffffffffffffffL;
        /// <summary>
        /// Represents the smallest possible value of UInt64. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is 0.</remarks>
        public const ulong MinValue = 0x0;

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance, consisting of a sequence of digits ranging from 0 to 9, without a sign or leading zeroes.</returns>
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
        /// Converts the string representation of a number to its 64-bit unsigned integer equivalent.
        /// </summary>
        /// <param name="s">A string that represents the number to convert.</param>
        /// <returns>A 64-bit unsigned integer equivalent to the number contained in s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static ulong Parse(string s)
        {
            // check for null string is carried out in native code
            return Convert.ToUInt64(s);
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit unsigned integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="s">Converts the string representation of a number to its 64-bit unsigned integer equivalent. A return value indicates whether the conversion succeeded.</param>
        /// <param name="result">When this method returns, contains the 64-bit unsigned integer value equivalent of the number contained in <paramref name="s"/>, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or <see cref="string.Empty"/>, is not of the correct format, or represents a number less than <see cref="MinValue"/> or greater than <see cref="MaxValue"/>. This parameter is passed uninitialized; any value originally supplied in result will be overwritten.</param>
        /// <returns><see langword="true"/> if s was converted successfully; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// The <see cref="TryParse"/> method is like the <see cref="Parse"/> method, except the <see cref="TryParse"/> method does not throw an exception if the conversion fails. It eliminates the need to use exception handling to test for a <see cref="FormatException"/> in the event that <paramref name="s"/> is invalid and cannot be successfully parsed.
        /// </remarks>
        public static bool TryParse(
            string s,
            out ulong result)
        {
            // the interface use long for min/max, and uint64 is bigger. Setting min/max to 0/0 will cause the native code to calculate the largest value and return it as Int64 which when cast to UInt64 returns the larger numbers that a UInt64 can reach
            result = (ulong)Convert.NativeToInt64(
                s,
                true,
                0,
                0,
                10,
                false,
                out bool success);

            return success;
        }
    }
}
