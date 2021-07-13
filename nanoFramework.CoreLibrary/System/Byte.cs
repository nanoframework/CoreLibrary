//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

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
        private byte _value;
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
            return Number.Format(_value, true, "G", NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current Byte object to its equivalent string representation using the specified format.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <returns>The string representation of the current Byte object, formatted as specified by the format parameter.</returns>
        public String ToString(String format)
        {
            return Number.Format(_value, true, format, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the string representation of a number to its Byte equivalent.
        /// </summary>
        /// <param name="s">A string that contains a number to convert. The string is interpreted using the Integer style. </param>
        /// <returns>A byte value that is equivalent to the number contained in s.</returns>
        /// <exception cref="System.ArgumentNullException">s is  null reference (Nothing in Visual Basic).</exception>
        [CLSCompliant(false)]
        public static byte Parse(String s)
        {
            if (s == null)
            {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentNullException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            }

            return Convert.ToByte(s);
        }

    }
}
