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
    /// <remarks>
    /// Specific for nanoFramework: this class library is split between mscorlib and it's own assembly.
    /// If you require any of the other methods that are not available here add the NuGet package nanoFramework.System.Math.
    /// </remarks>
    public static partial class Math
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
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int Abs(int val);

        /// <summary>
        /// Returns the absolute value of a double-precision floating-point number.
        /// </summary>
        /// <param name="val">A number that is greater than or equal to Double..::..MinValue, but less than or equal to Double..::..MaxValue.</param>
        /// <returns>A double-precision floating-point number, x, such that 0 ≤ x ≤ Double..::..MaxValue.</returns>
        /// <remarks>
        /// This method with double-precision floating-point parameter might not be available in all platforms or with firmware images that where build with single point FPU option.
        /// </remarks>
        /// <exception cref="NotImplementedException"/>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double Abs(double val);

        /// <summary>
        /// Returns the absolute value of a single-precision floating-point number.
        /// </summary>
        /// <param name="val">A number that is greater than or equal to Double..::..MinValue, but less than or equal to Double..::..MaxValue.</param>
        /// <returns>A single-precision floating-point number, x, such that 0 ≤ x ≤ Double..::..MaxValue.</returns>
        /// <remarks>
        /// This method with single-precision floating-point parameter is exclusive of nanoFramework. It doesn't exist in the .NET API, only the double-precision floating-point version.
        /// It might not be available in all platforms or with firmware images that where build with double point FPU option. 
        /// </remarks>
        /// <exception cref="NotImplementedException"/>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float Abs(float val);

        /// <summary>
        /// Returns the larger of two 32-bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 32-bit signed integers to compare. </param>
        /// <param name="val2">The second of two 32-bit signed integers to compare. </param>
        /// <returns>Parameter val1 or val2, whichever is larger.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int Max(int val1, int val2);

        /// <summary>
        /// Returns the larger of two double-precision floating-point numbers.
        /// </summary>
        /// <param name="x">The first of two double-precision floating-point numbers to compare. </param>
        /// <param name="y">The second of two double-precision floating-point numbers to compare. </param>
        /// <returns>Parameter x or y, whichever is larger. If x, y, or both x and y are equal to NaN, NaN is returned.</returns>
        /// <remarks>
        /// This method with double-precision floating-point parameter might not be available in all platforms or with firmware images that where build with single point FPU option.
        /// </remarks>
        /// <exception cref="NotImplementedException"/>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double Max(double x, double y);
        
        /// <summary>
        /// Returns the larger of two single-precision floating-point numbers.
        /// </summary>
        /// <param name="x">The first of two single-precision floating-point numbers to compare. </param>
        /// <param name="y">The second of two single-precision floating-point numbers to compare. </param>
        /// <returns>Parameter x or y, whichever is larger. If x, y, or both x and y are equal to NaN, NaN is returned.</returns>
        /// <remarks>
        /// This method with single-precision floating-point parameter is exclusive of nanoFramework. It doesn't exist in the .NET API, only the double-precision floating-point version.
        /// It might not be available in all platforms or with firmware images that where build with double point FPU option. 
        /// </remarks>
        /// <exception cref="NotImplementedException"/>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float Max(float x, float y);

        /// <summary>
        /// Returns the smaller of two 32-bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 32-bit signed integers to compare. </param>
        /// <param name="val2">The second of two 32-bit signed integers to compare. </param>
        /// <returns>Parameter val1 or val2, whichever is smaller.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int Min(int val1, int val2);

        /// <summary>
        /// Returns the smaller of two double-precision floating-point numbers.
        /// </summary>
        /// <param name="x">The first of two double-precision floating-point numbers to compare. </param>
        /// <param name="y">The second of two double-precision floating-point numbers to compare. </param>
        /// <returns>Parameter x or y, whichever is smaller. If x, y, or both x and y are equal to NaN, NaN is returned.</returns>
        /// <remarks>
        /// This method with double-precision floating-point parameter might not be available in all platforms or with firmware images that where build with single point FPU option.
        /// </remarks>
        /// <exception cref="NotImplementedException"/>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double Min(double x, double y);
        /// <summary>
        /// Returns the smaller of two single-precision floating-point numbers.
        /// </summary>
        /// <param name="x">The first of two single-precision floating-point numbers to compare. </param>
        /// <param name="y">The second of two single-precision floating-point numbers to compare. </param>
        /// <returns>Parameter x or y, whichever is smaller. If x, y, or both x and y are equal to NaN, NaN is returned.</returns>
        /// <remarks>
        /// This method with single-precision floating-point parameter is exclusive of nanoFramework. It doesn't exist in the .NET API, only the double-precision floating-point version.
        /// It might not be available in all platforms or with firmware images that where build with double point FPU option. 
        /// </remarks>
        /// <exception cref="NotImplementedException"/>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float Min(float x, float y);

    }
}
