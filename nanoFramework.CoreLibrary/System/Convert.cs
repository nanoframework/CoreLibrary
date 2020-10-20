//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Specifies whether relevant Convert.ToBase64CharArray and Convert.ToBase64String methods insert line breaks in their output.
    /// </summary>
    [Flags]
    public enum Base64FormattingOptions
    {
        /// <summary>
        /// Does not insert line breaks after every 76 characters in the string representation.
        /// </summary>
        None = 0,
        /// <summary>
        /// Inserts line breaks after every 76 characters in the string representation.
        /// </summary>
        InsertLineBreaks = 1
    }

    //We don't want to implement this whole class, but VB needs an external function to convert any integer type to a Char.
    /// <summary>
    /// Converts a base data type to another base data type.
    /// </summary>
    [ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)]
    public static class Convert
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern long NativeToInt64(string value, bool signed, long min, long max, int fromBase);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern double NativeToDouble(string value);
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to an equivalent Boolean value.
        /// </summary>
        /// <param name="value">The 8-bit unsigned integer to convert.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is not zero; otherwise, <see langword="false"/>.</returns>
        public static bool ToBoolean(byte value)
        {
            return value != 0;
        }

        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">The 16-bit unsigned integer to convert.</param>
        /// <returns>A Unicode character that is equivalent to value.</returns>
        [CLSCompliant(false)]
        public static char ToChar(ushort value)
        {
            return (char)value;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <param name="fromBase">The base of the number in <paramref name="value"/>, which must be 2, 8, 10, or 16. See remark bellow about platform support.</param>
        /// <returns>An 8-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is <see langword="null"/>.</returns>
        /// <remarks>
        /// The nanoFramework implementation of this method may provide only a subset of the equivalent .NET method, 
        /// which is supporting only conversions for base 10 values. In that case, any call using a <paramref name="fromBase"/> with a value other than 10 will throw a <see cref="NotImplementedException"/>.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="fromBase"/> is not 2, 8, 10, or 16.</exception>
        /// <exception cref="NotImplementedException">If the platform doesn't have support to convert from non-base 10 values.</exception>
        [CLSCompliant(false)]
        public static sbyte ToSByte(string value, int fromBase = 10)
        {
            return (sbyte)NativeToInt64(value, true, SByte.MinValue, SByte.MaxValue, fromBase);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <param name="fromBase">The base of the number in <paramref name="value"/>, which must be 2, 8, 10, or 16. See remark bellow about platform support.</param>
        /// <returns>An 8-bit unsigned integer that is equivalent to value, or zero if value is <see langword="null"/>.</returns>
        /// <remarks>
        /// The nanoFramework implementation of this method may provide only a subset of the equivalent .NET method, 
        /// which is supporting only conversions for base 10 values. In that case, any call using a <paramref name="fromBase"/> with a value other than 10 will throw a <see cref="NotImplementedException"/>.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="fromBase"/> is not 2, 8, 10, or 16.</exception>
        /// <exception cref="NotImplementedException">If the platform doesn't have support to convert from non-base 10 values.</exception>
        public static byte ToByte(string value, int fromBase = 10)
        {
            return (byte)NativeToInt64(value, false, Byte.MinValue, Byte.MaxValue, fromBase);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <param name="fromBase">The base of the number in <paramref name="value"/>, which must be 2, 8, 10, or 16. See remark bellow about platform support.</param>
        /// <returns>A 16-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is <see langword="null"/>.</returns>
        /// <remarks>
        /// The nanoFramework implementation of this method may provide only a subset of the equivalent .NET method, 
        /// which is supporting only conversions for base 10 values. In that case, any call using a <paramref name="fromBase"/> with a value other than 10 will throw a <see cref="NotImplementedException"/>.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="fromBase"/> is not 2, 8, 10, or 16.</exception>
        /// <exception cref="NotImplementedException">If the platform doesn't have support to convert from non-base 10 values.</exception>
        public static short ToInt16(string value, int fromBase = 10)
        {
            return (short)NativeToInt64(value, true, Int16.MinValue, Int16.MaxValue, fromBase);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <param name="fromBase">The base of the number in <paramref name="value"/>, which must be 2, 8, 10, or 16. See remark bellow about platform support.</param>
        /// <returns>A 16-bit unsigned integer that is equivalent to the number in value, or 0 (zero) if value is <see langword="null"/>.</returns>
        /// <remarks>
        /// The nanoFramework implementation of this method may provide only a subset of the equivalent .NET method, 
        /// which is supporting only conversions for base 10 values. In that case, any call using a <paramref name="fromBase"/> with a value other than 10 will throw a <see cref="NotImplementedException"/>.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="fromBase"/> is not 2, 8, 10, or 16.</exception>
        /// <exception cref="NotImplementedException">If the platform doesn't have support to convert from non-base 10 values.</exception>
        [CLSCompliant(false)]
        public static ushort ToUInt16(string value, int fromBase = 10)
        {
            return (ushort)NativeToInt64(value, false, UInt16.MinValue, UInt16.MaxValue, fromBase);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <param name="fromBase">The base of the number in <paramref name="value"/>, which must be 2, 8, 10, or 16. See remark bellow about platform support.</param>
        /// <returns>A 32-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is <see langword="null"/>.</returns>
        /// <remarks>
        /// The nanoFramework implementation of this method may provide only a subset of the equivalent .NET method, 
        /// which is supporting only conversions for base 10 values. In that case, any call using a <paramref name="fromBase"/> with a value other than 10 will throw a <see cref="NotImplementedException"/>.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="fromBase"/> is not 2, 8, 10, or 16.</exception>
        /// <exception cref="NotImplementedException">If the platform doesn't have support to convert from non-base 10 values.</exception>
        public static int ToInt32(string value, int fromBase = 10)
        {
            return (int)NativeToInt64(value, true, Int32.MinValue, Int32.MaxValue, fromBase);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <param name="fromBase">The base of the number in <paramref name="value"/>, which must be 2, 8, 10, or 16. See remark bellow about platform support.</param>
        /// <returns>A 32-bit unsigned integer that is equivalent to the number in value, or 0 (zero) if value is <see langword="null"/>.</returns>
        /// <remarks>
        /// The nanoFramework implementation of this method may provide only a subset of the equivalent .NET method, 
        /// which is supporting only conversions for base 10 values. In that case, any call using a <paramref name="fromBase"/> with a value other than 10 will throw a <see cref="NotImplementedException"/>.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="fromBase"/> is not 2, 8, 10, or 16.</exception>
        /// <exception cref="NotImplementedException">If the platform doesn't have support to convert from non-base 10 values.</exception>
        [CLSCompliant(false)]
        public static uint ToUInt32(string value, int fromBase = 10)
        {
            return (uint)NativeToInt64(value, false, UInt32.MinValue, UInt32.MaxValue, fromBase);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <param name="fromBase">The base of the number in <paramref name="value"/>, which must be 2, 8, 10, or 16. See remark bellow about platform support.</param>
        /// <returns>A 64-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is <see langword="null"/>.</returns>
        /// <remarks>
        /// The nanoFramework implementation of this method may provide only a subset of the equivalent .NET method, 
        /// which is supporting only conversions for base 10 values. In that case, any call using a <paramref name="fromBase"/> with a value other than 10 will throw a <see cref="NotImplementedException"/>.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="fromBase"/> is not 2, 8, 10, or 16.</exception>
        /// <exception cref="NotImplementedException">If the platform doesn't have support to convert from non-base 10 values.</exception>
        public static long ToInt64(string value, int fromBase = 10)
        {
            return NativeToInt64(value, true, Int64.MinValue, Int64.MaxValue, fromBase);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <param name="fromBase">The base of the number in <paramref name="value"/>, which must be 2, 8, 10, or 16. See remark bellow about platform support.</param>
        /// <returns>A 64-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is <see langword="null"/>.</returns>
        /// <remarks>
        /// The nanoFramework implementation of this method may provide only a subset of the equivalent .NET method, 
        /// which is supporting only conversions for base 10 values. In that case, any call using a <paramref name="fromBase"/> with a value other than 10 will throw a <see cref="NotImplementedException"/>.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="fromBase"/> is not 2, 8, 10, or 16.</exception>
        /// <exception cref="NotImplementedException">If the platform doesn't have support to convert from non-base 10 values.</exception>
        [CLSCompliant(false)]
        public static ulong ToUInt64(string value, int fromBase = 10)
        {
            return (ulong)NativeToInt64(value, true, 0, 0, fromBase);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent double-precision floating-point number.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>A double-precision floating-point number that is equivalent to the number in value, or 0 (zero) if value is <see langword="null"/>.</returns>
        public static double ToDouble(string value)
        {
            return NativeToDouble(value);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent single-precision floating-point number.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>A single-precision floating-point number that is equivalent to the number in value, or 0 (zero) if value is <see langword="null"/>.</returns>
        public static float ToSingle(string value)
        {
            return (float)NativeToDouble(value);
        }

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent String representation encoded with base 64 digits.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers. </param>
        /// <returns>The String representation, in base 64, of the contents of <paramref name="inArray"/>.</returns>
        public static string ToBase64String(byte[] inArray)
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (inArray == null) throw new ArgumentNullException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            return ToBase64String(inArray, 0, inArray.Length, Base64FormattingOptions.None);
        }

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64 digits. A parameter specifies whether to insert line breaks in the return value.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers.</param>
        /// <param name="options"><see cref="Base64FormattingOptions.InsertLineBreaks"/> to insert a line break every 76 characters, or None to not insert line breaks.</param>
        /// <returns>The string representation in base 64 of the elements in <paramref name="inArray"/>.</returns>
        public static String ToBase64String(byte[] inArray, Base64FormattingOptions options)
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (inArray == null) throw new ArgumentNullException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            return ToBase64String(inArray, 0, inArray.Length, options);
        }

        /// <summary>
        /// Converts a subset of an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64 digits. Parameters specify the subset as an offset in the input array, and the number of elements in the array to convert.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers. </param>
        /// <param name="offset">An offset in <paramref name="inArray"/>.</param>
        /// <param name="length">The number of elements of <paramref name="inArray"/> to convert.</param>
        /// <returns>The string representation in base 64 of <paramref name="length"/> elements of <paramref name="inArray"/>, starting at position <paramref name="offset"/>.</returns>
        public static String ToBase64String(byte[] inArray, int offset, int length)
        {
            return ToBase64String(inArray, offset, length, Base64FormattingOptions.None);
        }

        /// <summary>
        /// Converts a subset of an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64 digits. Parameters specify the subset as an offset in the input array, the number of elements in the array to convert, and whether to insert line breaks in the return value.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers. </param>
        /// <param name="offset">An offset in <paramref name="inArray"/>.</param>
        /// <param name="length">The number of elements of <paramref name="inArray"/> to convert.</param>
        /// <param name="options">cref="System.InsertLineBreaks" to insert a line break every 76 characters, or None to not insert line breaks.</param>
        /// <returns>The string representation in base 64 of <paramref name="length"/> elements of <paramref name="inArray"/>, starting at position <paramref name="offset"/>.</returns>
        public static string ToBase64String(byte[] inArray, int offset, int length, Base64FormattingOptions options)
        {
            //Do data verfication
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (inArray == null) throw new ArgumentNullException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (length < 0) throw new ArgumentOutOfRangeException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (offset < 0) throw new ArgumentOutOfRangeException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (options < Base64FormattingOptions.None || options > Base64FormattingOptions.InsertLineBreaks) throw new ArgumentException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            return ToBase64String(inArray, offset, length, options == Base64FormattingOptions.InsertLineBreaks);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern string ToBase64String(byte[] inArray, int offset, int length, bool insertLineBreaks);

        /// <summary>
        /// Converts the specified string, which encodes binary data as base-64 digits, to an equivalent 8-bit unsigned integer array.
        /// </summary>
        /// <param name="inString">The string to convert.</param>
        /// <returns>An array of 8-bit unsigned integers that is equivalent to <paramref name="inString"/></returns>
        /// <remarks>s is composed of base-64 digits, white-space characters, and trailing padding characters. The base-64 digits in ascending order from zero are the uppercase characters "A" to "Z", lowercase characters "a" to "z", numerals "0" to "9", and the symbols "+" and "/".
        /// The white-space characters, and their Unicode names and hexadecimal code points, are tab(CHARACTER TABULATION, U+0009), newline(LINE FEED, U+000A), carriage return (CARRIAGE RETURN, U+000D), and blank(SPACE, U+0020). An arbitrary number of white-space characters can appear in s because all white-space characters are ignored.
        /// The valueless character, "=", is used for trailing padding. The end of s can consist of zero, one, or two padding characters.
        /// </remarks>
        public static byte[] FromBase64String(string inString)
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (inString == null) throw new ArgumentNullException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            var chArray = inString.ToCharArray();

            return FromBase64CharArray(chArray, 0, chArray.Length);
        }

        /// <summary>
        /// Converts a subset of a Unicode character array, which encodes binary data as base-64 digits, to an equivalent 8-bit unsigned integer array. Parameters specify the subset in the input array and the number of elements to convert.
        /// </summary>
        /// <param name="inArray">A Unicode character array.</param>
        /// <param name="offset">A position within <paramref name="inArray"/>.</param>
        /// <param name="length">The number of elements in <paramref name="inArray"/> to convert. </param>
        /// <returns>An array of 8-bit unsigned integers equivalent to <paramref name="length"/> elements at position <paramref name="offset"/> in <paramref name="inArray"/>.</returns>
        public static byte[] FromBase64CharArray(char[] inArray, int offset, int length)
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (inArray == null) throw new ArgumentNullException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (length < 0) throw new ArgumentOutOfRangeException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (offset < 0) throw new ArgumentOutOfRangeException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (offset > inArray.Length - length) throw new ArgumentOutOfRangeException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            // copy to new array
            var destinationArray = new char[length];
            Array.Copy(inArray, offset, destinationArray, 0, length);

            return FromBase64CharArray(destinationArray, length);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern byte[] FromBase64CharArray(char[] inArray, int length);
    }
}
