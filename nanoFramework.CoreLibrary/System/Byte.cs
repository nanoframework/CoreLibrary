// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    using Globalization;

    /// <summary>
    /// Represents an 8-bit unsigned integer.
    /// </summary>
    [Serializable]
    public struct Byte
    {
        // this field is required in the native end
#pragma warning disable 0649
        // Do not rename (binary serialization)
        private byte m_value;
#pragma warning restore 0649

        /// <summary>
        /// Represents the largest possible value of a Byte. This field is constant.
        /// </summary>
        public const byte MaxValue = 0xFF;
        /// <summary>
        /// Represents the smallest possible value of a Byte. This field is constant.
        /// </summary>
        public const byte MinValue = 0;

        /// <summary>
        /// Converts the value of the current Byte object to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this object, which consists of a sequence of digits that range from 0 to 9 with no leading zeroes.</returns>
        /// <remarks>The return value is formatted with the general numeric format specifier ("G") and the NumberFormatInfo object for the thread current culture.</remarks>
        public override String ToString()
        {
            return Number.Format(m_value, true, "G", NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current Byte object to its equivalent string representation using the specified format.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <returns>The string representation of the current Byte object, formatted as specified by the format parameter.</returns>
        public String ToString(String format)
        {
            return Number.Format(m_value, true, format, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the string representation of a number to its <see cref="Byte"/> equivalent.
        /// </summary>
        /// <param name="s">A string that contains a number to convert. The string is interpreted using the Integer style. </param>
        /// <returns>A <see cref="byte"/> value that is equivalent to the number contained in <paramref name="s"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException"><paramref name="s"/> is not of the correct format.</exception>
        [CLSCompliant(false)]
        public static byte Parse(string s)
        {
            // check for null string is carried out in native code
            return Convert.ToByte(s);
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its <see cref="Byte"/> equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="s">A <see cref="string"/> that contains a number to convert.</param>
        /// <param name="result">When this method returns, contains the <see cref="byte"/> value equivalent to the number contained in <paramref name="s"/> if the conversion succeeded, or zero if the conversion failed. This parameter is passed uninitialized; any value originally supplied in <paramref name="result"/> will be overwritten.</param>
        /// <returns>true if <paramref name="s"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// The conversion fails and the method returns <see langword="false"/> if the s parameter is not in the correct format, if it is <see langword="null"/> or <see cref="string.Empty"/>, or if it represents a number less than <see cref="MinValue"/> or greater than <see cref="MaxValue"/>.
        /// The <see cref="TryParse"/>(String, Byte) method is similar to the Byte.Parse(String) method, except that <see cref="TryParse"/>(String, Byte) does not throw an exception if the conversion fails.
        /// </remarks>
        public static bool TryParse(string s, out byte result)
        {
            result = (byte)Convert.NativeToInt64(
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
