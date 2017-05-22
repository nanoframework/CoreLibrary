//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Runtime.CompilerServices;
    /// <summary>
    /// Provides constants and static methods for trigonometric, logarithmic, and other common mathematical functions.
    /// </summary>
    public static class Math
    {
        /// <summary>
        /// Represents the ratio of the circumference of a circle to its diameter, specified by the constant, π.
        /// </summary>
        /// <remarks>The value of this field is 3.14159265358979323846.</remarks>
        public const double PI = 3.14159265358979323846;
        /// <summary>
        /// Represents the natural logarithmic base, specified by the constant, e.
        /// </summary>
        /// <remarks>The value of this field is 2.7182818284590452354.</remarks>
        public const double E = 2.7182818284590452354;

        /// <summary>
        /// Returns the absolute value of a 32-bit signed integer.
        /// </summary>
        /// <param name="val">A number that is greater than Int32..::..MinValue, but less than or equal to Int32..::..MaxValue.</param>
        /// <returns>A 32-bit signed integer, x, such that 0 ≤ x ≤ Int32..::..MaxValue.</returns>
        public static int Abs(int val)
        {
            return val >= 0 ? val : -val;
        }
        /// <summary>
        /// Returns the larger of two 32-bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 32-bit signed integers to compare. </param>
        /// <param name="val2">The second of two 32-bit signed integers to compare. </param>
        /// <returns>Parameter val1 or val2, whichever is larger.</returns>
        public static int Max(int val1, int val2)
        {
            return val1 >= val2 ? val1 : val2;
        }
        /// <summary>
        /// Returns the smaller of two 32-bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 32-bit signed integers to compare. </param>
        /// <param name="val2">The second of two 32-bit signed integers to compare. </param>
        /// <returns>Parameter val1 or val2, whichever is smaller.</returns>
        public static int Min(int val1, int val2)
        {
            return val1 <= val2 ? val1 : val2;
        }
        /// <summary>
        /// Returns the absolute value of a double-precision floating-point number.
        /// </summary>
        /// <param name="val">A number that is greater than or equal to Double..::..MinValue, but less than or equal to Double..::..MaxValue.</param>
        /// <returns>A double-precision floating-point number, x, such that 0 ≤ x ≤ Double..::..MaxValue.</returns>
        public static double Abs(double val)
        {
            return val >= 0 ? val : -val;
        }
        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="d">A number representing a cosine, where d must be greater than or equal to -1, but less than or equal to 1. </param>
        /// <returns>An angle, θ, measured in radians, such that 0 ≤ θ ≤ π -or- NaN if d &lt; -1 or d > 1 or d equals NaN.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Acos(double d);
        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="d">A number representing a sine, where d must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>An angle, θ, measured in radians, such that -π/2 ≤ θ ≤ π/2 -or- NaN if d &lt; -1 or d> 1 or d equals NaN.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Asin(double d);
        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <param name="d">A number representing a tangent. </param>
        /// <returns>An angle, θ, measured in radians, such that -π/2 ≤ θ ≤ π/2. -or- NaN if d equals NaN, -π/2 rounded to double precision(-1.5707963267949) if d equals NegativeInfinity, or π/2 rounded to double precision(1.5707963267949) if d equals PositiveInfinity.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Atan(double d);
        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// <param name="y">The y coordinate of a point. </param>
        /// <param name="x">The x coordinate of a point. </param>
        /// <returns>An angle, θ, measured in radians, such that -π ≤ θ ≤ π, and tan(θ) = y / x, where (x, y) is a point in the Cartesian plane.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Atan2(double y, double x);
        /// <summary>
        /// eturns the smallest integral value that is greater than or equal to the specified double-precision floating-point number.
        /// </summary>
        /// <param name="d">A double-precision floating-point number. </param>
        /// <returns>The smallest integral value that is greater than or equal to d. If d is equal to NaN, NegativeInfinity, or PositiveInfinity, that value is returned. Note that this method returns a Double instead of an integral type.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Ceiling(double d);
        /// <summary>
        /// Returns the cosine of the specified angle.
        /// </summary>
        /// <param name="a">An angle, measured in radians. </param>
        /// <returns>The cosine of a. If a is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Cos(double a);
        /// <summary>
        /// Returns the hyperbolic cosine of the specified angle.
        /// </summary>
        /// <param name="a">An angle, measured in radians. </param>
        /// <returns>The hyperbolic cosine of val. If val is equal to NegativeInfinity or PositiveInfinity, PositiveInfinity is returned. If value is equal to NaN, NaN is returned.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Cosh(double a);
        /// <summary>
        /// Returns the remainder resulting from the division of a specified number by another specified number.
        /// </summary>
        /// <param name="x">A dividend. </param>
        /// <param name="y">A divisor. </param>
        /// <returns>A number equal to x - (y Q), where Q is the quotient of x / y rounded to the nearest integer (if x / y falls halfway between two integers, the even integer is returned).
        /// If x - (y Q) is zero, the value +0 is returned if x is positive, or -0 if x is negative.
        /// If y = 0, NaN is returned.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double IEEERemainder(double x, double y);
        /// <summary>
        /// Returns e raised to the specified power.
        /// </summary>
        /// <param name="d">A number specifying a power. </param>
        /// <returns>The number e raised to the power d. If d equals NaN or PositiveInfinity, that value is returned. If d equals NegativeInfinity, 0 is returned.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Exp(double d);
        /// <summary>
        /// Returns the largest integer less than or equal to the specified double-precision floating-point number.
        /// </summary>
        /// <param name="d">A double-precision floating-point number. </param>
        /// <returns>The largest integer less than or equal to d. If d is equal to NaN, NegativeInfinity, or PositiveInfinity, that value is returned.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Floor(double d);
        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number.
        /// </summary>
        /// <param name="d">The number whose logarithm is to be found. </param>
        /// <returns>The natural logarithm of d; that is, ln d, or log e d</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Log(double d);
        /// <summary>
        /// Returns the base 10 logarithm of a specified number.
        /// </summary>
        /// <param name="d">A number whose logarithm is to be found. </param>
        /// <returns>The base 10 log of d; that is, log 10 d.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Log10(double d);
        /// <summary>
        /// Returns the larger of two double-precision floating-point numbers.
        /// </summary>
        /// <param name="x">The first of two double-precision floating-point numbers to compare. </param>
        /// <param name="y">The second of two double-precision floating-point numbers to compare. </param>
        /// <returns>Parameter x or y, whichever is larger. If x, y, or both x and y are equal to NaN, NaN is returned.</returns>
        public static double Max(double x, double y)
        {
            return x >= y ? x : y;
        }
        /// <summary>
        /// Returns the smaller of two double-precision floating-point numbers.
        /// </summary>
        /// <param name="x">The first of two double-precision floating-point numbers to compare. </param>
        /// <param name="y">The second of two double-precision floating-point numbers to compare. </param>
        /// <returns>Parameter x or y, whichever is smaller. If x, y, or both x and y are equal to NaN, NaN is returned.</returns>
        public static double Min(double x, double y)
        {
            return x <= y ? x : y;
        }
        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// </summary>
        /// <param name="x">A double-precision floating-point number to be raised to a power. </param>
        /// <param name="y">A double-precision floating-point number that specifies a power. </param>
        /// <returns>The number x raised to the power y.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Pow(double x, double y);
        /// <summary>
        /// Rounds a double-precision floating-point value to the nearest integral value.
        /// </summary>
        /// <param name="d">A double-precision floating-point number to be rounded.</param>
        /// <returns>The integer nearest d. If the fractional component of d is halfway between two integers, one of which is even and the other odd, then the even number is returned. Note that this method returns a Double instead of an integral type.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Round(double d);
        /// <summary>
        /// Returns a value indicating the sign of a double-precision floating-point number.
        /// </summary>
        /// <param name="value">A signed number. </param>
        /// <returns>A number that indicates the sign of value.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern int Sign(double value);
        /// <summary>
        /// Returns the sine of the specified angle.
        /// </summary>
        /// <param name="a">An angle, measured in radians. </param>
        /// <returns>The sine of a. If a is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Sin(double a);
        /// <summary>
        /// Returns the hyperbolic sine of the specified angle.
        /// </summary>
        /// <param name="value">An angle, measured in radians. </param>
        /// <returns>The hyperbolic sine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns a Double equal to value.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Sinh(double value);
        /// <summary>
        /// Returns the square root of a specified number.
        /// </summary>
        /// <param name="d">The number whose square root is to be found. </param>
        /// <returns>The positive square root of d.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Sqrt(double d);
        /// <summary>
        /// Returns the tangent of the specified angle.
        /// </summary>
        /// <param name="a">An angle, measured in radians. </param>
        /// <returns>The tangent of a. If a is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Tan(double a);
        /// <summary>
        /// Returns the hyperbolic tangent of the specified angle.
        /// </summary>
        /// <param name="value">An angle, measured in radians. </param>
        /// <returns>The hyperbolic tangent of value. If value is equal to NegativeInfinity, this method returns -1. If value is equal to PositiveInfinity, this method returns 1. If value is equal to NaN, this method returns NaN.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Tanh(double value);
        /// <summary>
        /// Calculates the integral part of a specified double-precision floating-point number.
        /// </summary>
        /// <param name="d">A number to truncate.</param>
        /// <returns>The integral part of d; that is, the number that remains after any fractional digits have been discarded</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern double Truncate(double d);
    }
}
