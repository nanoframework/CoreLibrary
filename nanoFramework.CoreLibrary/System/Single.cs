//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Globalization;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents a single-precision floating-point number.
    /// </summary>
    [Serializable]
    public struct Single
    {
        // this field is required in the native end
#pragma warning disable 0649
        // Do not rename (binary serialization)
        internal float m_value;
#pragma warning restore 0649

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
        /// Represents negative infinity. This field is constant.
        /// </summary>
        public const float NegativeInfinity = -1.0f / 0.0f;

        /// <summary>
        /// Represents positive infinity. This field is constant.
        /// </summary>
        public const float PositiveInfinity = 1.0f / 0.0f;

#pragma warning disable S1764 // Identical expressions should not be used on both sides of a binary operator
        // intended as the purpose is to a NaN value

        /// <summary>
        /// Represents a value that is not a number (NaN). This field is constant.
        /// </summary>
        public const float NaN = 0.0f / 0.0f;
#pragma warning restore S1764 // Identical expressions should not be used on both sides of a binary operator

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative or positive infinity.
        /// </summary>
        /// <param name="f">A single-precision floating-point number. </param>
        /// <returns>
        /// <see langword="true"/> if f evaluates to <see cref="PositiveInfinity"/> or <see cref="NegativeInfinity"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsInfinity(float f)
        {
            return double.IsInfinity(f);
        }

        /// <summary>
        /// Returns a value that indicates whether the specified value is not a number (<see cref="NaN"/>).
        /// </summary>
        /// <param name="f">A single-precision floating-point number. </param>
        /// <returns>
        /// <see langword="true"/> if f evaluates to <see cref="NaN"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsNaN(float f)
        {
            return double.IsNaN(f);
        }

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative infinity.
        /// </summary>
        /// <param name="f">A single-precision floating-point number.</param>
        /// <returns>
        /// <see langword="true"/> if f evaluates to <see cref="NegativeInfinity"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsNegativeInfinity(float f)
        {
            return double.IsNegativeInfinity(f);
        }

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to positive infinity.
        /// </summary>
        /// <param name="f">A single-precision floating-point number. </param>
        /// <returns>
        /// <see langword="true"/> if d evaluates to <see cref="PositiveInfinity"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsPositiveInfinity(float f)
        {
            return double.IsPositiveInfinity(f);
        }

        /// <summary>
        /// Compares this instance to a specified single-precision floating-point number and returns an integer that indicates whether the value of this instance is less than, equal to, or greater than the value of the specified single-precision floating-point number.
        /// </summary>
        /// <param name="value">A single-precision floating-point number to compare.</param>
        /// <returns>A signed number indicating the relative values of this instance and value.
        /// Less than zero: This instance is less than value. -or- This instance is not a number (<see cref="NaN"/>) and value is a number.
        /// Zero: This instance is equal to value. -or- Both this instance and value are not a number (<see cref="NaN"/>), <see cref="PositiveInfinity"/>, or <see cref="NegativeInfinity"/>. 
        /// Greater than zero: This instance is greater than value. -or- This instance is a number and value is not a number (<see cref="NaN"/>). 
        /// </returns>
        public int CompareTo(float value)
        {
            return double.CompareTo(this, value);
        }

        /// <summary>
        /// Converts the string representation of a number to its single-precision floating-point number equivalent.
        /// </summary>
        /// <param name="s">A string that contains a number to convert. </param>
        /// <returns>A single-precision floating-point number equivalent to the numeric value or symbol specified in <code>s</code>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
        public static float Parse(string s)
        {
            // check for null string is carried out in native code
            return Convert.ToSingle(s);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public override string ToString()
        {
            return ToString("G");
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation, using the specified format.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <returns>The string representation of the value of this instance as specified by format.</returns>
        public string ToString(string format)
        {
            if (IsPositiveInfinity(this))
            {
                return double._positiveInfinitySymbol;
            }
            else if (IsNegativeInfinity(this))
            {
                return double._negativeInfinitySymbol;
            }
            else if(IsNaN(this))
            {
                return double._naNSymbol;
            }

            return Number.Format(m_value, false, format, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the string representation of a number to its single-precision floating-point number equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A string containing a number to convert. </param>
        /// <param name="result">When this method returns, contains single-precision floating-point number equivalent to the numeric value or symbol contained in <paramref name="s"/>, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or <see cref="string.Empty"/>, is not a number in a valid format, or represents a number less than <see cref="MinValue"/> or greater than <see cref="MaxValue"/>. This parameter is passed uninitialized; any value originally supplied in result will be overwritten.</param>
        /// <returns><see langword="true"/> if s was converted successfully; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// <para>
        /// Values that are too large to represent are rounded to <see cref="PositiveInfinity"/> or <see cref="NegativeInfinity"/> as required by the IEEE 754 specification.
        /// </para>
        /// <para>
        /// This overload differs from the <see cref="Parse"/> method by returning a <see cref="bool"/> value that indicates whether the parse operation succeeded instead of returning the parsed numeric value. It eliminates the need to use exception handling to test for a <see cref="FormatException"/> in the event that s is invalid and cannot be successfully parsed.
        /// </para>
        /// </remarks>
        public static bool TryParse(
            string s,
            out float result)
        {
            result = (float)Convert.NativeToDouble(
                s,
                false,
                out bool success);

            return success;
        }
    }
}
