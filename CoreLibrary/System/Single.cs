//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Globalization;

    /// <summary>
    /// Represents a single-precision floating-point number.
    /// </summary>
    [Serializable]
    public struct Single
    {
        internal float _value;

        /// <summary>
        /// Represents the smallest possible value of Single. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is negative 3.402823e38.</remarks>
        public const float MinValue = (float)-3.40282346638528859e+38;
        /// <summary>
        /// Represents the smallest positive Single value that is greater than zero. This field is constant.
        /// </summary>
        public const float Epsilon = (float)1.4e-45;
        /// <summary>
        /// Represents the largest possible value of Single. This field is constant.
        /// </summary>
        /// <remarks>The value of this constant is positive 3.40282347E+38.</remarks>
        public const float MaxValue = (float)3.40282346638528859e+38;

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public override String ToString()
        {
            var str = ((Double)_value).ToString();
            switch (str)
            {
                case "Infinity":
                case "-Infinity":
                case "NaN":
                return str;
                default:
                return Number.Format(_value, false, "G", NumberFormatInfo.CurrentInfo);
            }
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation, using the specified format.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <returns>The string representation of the value of this instance as specified by format.</returns>
        public String ToString(String format)
        {
            var str = ((Double)_value).ToString();
            switch (str)
            {
                case "Infinity":
                case "-Infinity":
                case "NaN":
                return str;
                default:
                return Number.Format(_value, false, format, NumberFormatInfo.CurrentInfo);
            }
        }
    }
}
