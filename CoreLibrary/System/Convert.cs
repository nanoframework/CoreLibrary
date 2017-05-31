//
// Copyright (c) 2017 The nanoFramework project contributors
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
    [ComponentModel.EditorBrowsableAttribute(ComponentModel.EditorBrowsableState.Never)]
    public static class Convert
    {
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
        /// <returns>An 8-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        [CLSCompliant(false)]
        public static sbyte ToSByte(string value)
        {
            return (sbyte)ToInt64(value, true, SByte.MinValue, SByte.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>An 8-bit unsigned integer that is equivalent to value, or zero if value is null.</returns>
        public static byte ToByte(string value)
        {
            return (byte)ToInt64(value, false, Byte.MinValue, Byte.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>A 16-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        public static short ToInt16(string value)
        {
            return (short)ToInt64(value, true, Int16.MinValue, Int16.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>A 16-bit unsigned integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        [CLSCompliant(false)]
        public static ushort ToUInt16(string value)
        {
            return (ushort)ToInt64(value, false, UInt16.MinValue, UInt16.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>A 32-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        public static int ToInt32(string value)
        {
            return (int)ToInt64(value, true, Int32.MinValue, Int32.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>A 32-bit unsigned integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        [CLSCompliant(false)]
        public static uint ToUInt32(string value)
        {
            return (uint)ToInt64(value, false, UInt32.MinValue, UInt32.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <returns>A 64-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        public static long ToInt64(string value)
        {
            return ToInt64(value, true, Int64.MinValue, Int64.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>A 64-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        [CLSCompliant(false)]
        public static ulong ToUInt64(string value)
        {
            return (ulong)ToInt64(value, false, 0, 0);
        }

        /// <summary>
        /// Converts the string representation of a number in a specified base to an equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="hexNumber">A string that contains the number to convert.</param>
        /// <param name="fromBase">The base of the number in value, which must be 2, 8, 10, or 16.</param>
        /// <returns>A 32-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static int ToInt32(string hexNumber, int fromBase)
        {
            if (hexNumber == null) return 0;
            if (fromBase != 16) throw new ArgumentException();

            var result = 0;
            var hexDigit = hexNumber.Trim(' ').ToUpper().ToCharArray();

            // Trim hex sentinal if present 
            var len = hexDigit.Length;
            var i = len >= 2 && hexDigit[0] == '0' && hexDigit[1] == 'X' ? 2 : 0;

            // 8 hex chars == 4 bytes == sizeof(Int32)
            if (len - i > 8) throw new ArgumentException();

            // Convert hex to integer
            for (; i < len; i++)
            {
                var c = hexDigit[i];

                int digit;
                switch (c)
                {
                    case '0':
                    digit = 0;
                    break;
                    case '1':
                    digit = 1;
                    break;
                    case '2':
                    digit = 2;
                    break;
                    case '3':
                    digit = 3;
                    break;
                    case '4':
                    digit = 4;
                    break;
                    case '5':
                    digit = 5;
                    break;
                    case '6':
                    digit = 6;
                    break;
                    case '7':
                    digit = 7;
                    break;
                    case '8':
                    digit = 8;
                    break;
                    case '9':
                    digit = 9;
                    break;
                    case 'A':
                    digit = 10;
                    break;
                    case 'B':
                    digit = 11;
                    break;
                    case 'C':
                    digit = 12;
                    break;
                    case 'D':
                    digit = 13;
                    break;
                    case 'E':
                    digit = 14;
                    break;
                    case 'F':
                    digit = 15;
                    break;
                    default:
                    throw new ArgumentException();
                }

                result <<= 4;
                result += digit;
            }

            return result;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent double-precision floating-point number.
        /// </summary>
        /// <param name="s">A string that contains the number to convert.</param>
        /// <returns>A double-precision floating-point number that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        public static double ToDouble(string s)
        {
            if (s == null) return 0;

            s = s.Trim(' ').ToLower();

            if (s.Length == 0) return 0;

            var decimalpoint = s.IndexOf('.');
            var exp = s.IndexOf('e');

            if (exp != -1 && decimalpoint > exp) throw new Exception();

            var chars = s.ToCharArray();
            var len = chars.Length;
            double power = 0;
            double rightDecimal = 0;
            var decLeadingZeros = 0;
            double leftDecimal = 0;
            var leftDecLen = 0;
            var isNeg = chars[0] == '-';

            // convert the exponential portion to a number            
            if (exp != -1 && exp + 1 < len - 1)
            {
                int tmp;
                power = GetDoubleNumber(chars, exp + 1, len - (exp + 1), out tmp);
            }

            // convert the decimal portion to a number
            if (decimalpoint != -1)
            {
                int decLen;

                if (exp == -1) decLen = len - (decimalpoint + 1);
                else decLen = exp - (decimalpoint + 1);

                var number = GetDoubleNumber(chars, decimalpoint + 1, decLen, out decLeadingZeros);

                rightDecimal = number * Math.Pow(10, -decLen);
            }

            // convert the integer portion to a number
            if (decimalpoint != 0)
            {
                int leadingZeros;

                if (decimalpoint == -1 && exp == -1) leftDecLen = len;
                else if (decimalpoint != -1) leftDecLen = decimalpoint;
                else leftDecLen = exp;

                leftDecimal = GetDoubleNumber(chars, 0, leftDecLen, out leadingZeros);
                // subtract leading zeros from integer length
                leftDecLen -= leadingZeros;

                if (chars[0] == '-' || chars[0] == '+') leftDecLen--;
            }

            double value;
            if (leftDecimal < 0)
            {
                value = -leftDecimal + rightDecimal;
                value = -value;
            }
            else value = leftDecimal + rightDecimal;

            // lets normalize the integer portion first
            while (leftDecLen > 1)
            {
                switch (leftDecLen)
                {
                    case 2:
                    value /= 10.0;
                    power += 1;
                    leftDecLen -= 1;
                    break;
                    case 3:
                    value /= 100.0;
                    power += 2;
                    leftDecLen -= 2;
                    break;
                    case 4:
                    value /= 1000.0;
                    power += 3;
                    leftDecLen -= 3;
                    break;
                    default:
                    value /= 10000.0;
                    power += 4;
                    leftDecLen -= 4;
                    break;
                }
            }

            // now normalize the decimal portion
            if (value != 0.0 && value < 1.0 && value > -1.0)
            {
                // for normalization we want x.xxx instead of 0.xxx
                decLeadingZeros++;

                while (decLeadingZeros > 0)
                {
                    switch (decLeadingZeros)
                    {
                        case 1:
                        value *= 10.0;
                        power -= 1;
                        decLeadingZeros -= 1;
                        break;
                        case 2:
                        value *= 100.0;
                        power -= 2;
                        decLeadingZeros -= 2;
                        break;
                        case 3:
                        value *= 1000.0;
                        power -= 3;
                        decLeadingZeros -= 3;
                        break;
                        default:
                        value *= 10000.0;
                        power -= 4;
                        decLeadingZeros -= 4;
                        break;
                    }
                }
            }

            // special case for epsilon (the System.Math.Pow native method will return zero for -324)
            if (power == -324)
            {
                value = value * Math.Pow(10, power + 1);
                value /= 10.0;
            }
            else value = value * Math.Pow(10, power);

            if (double.IsPositiveInfinity(value) || double.IsNegativeInfinity(value)) throw new Exception();

            if (isNeg && value > 0) value = -value;

            return value;
        }

        private static long ToInt64(string value, bool signed, long min, long max)
        {
            if (value == null) return 0;

            value = value.Trim(' ');

            var num = value.ToCharArray();
            var len = num.Length;
            ulong result = 0;
            var index = 0;
            var isNeg = false;

            // check the sign
            if (num[0] == '-')
            {
                isNeg = true;
                index = 1;
            }
            else if (num[0] == '+')
            {
                index = 1;
            }

            for (var i = index; i < len; i++)
            {
                ulong digit;
                var c = num[i];

                // switch statement is faster than subtracting '0'
                switch (c)
                {
                    case '0':
                    digit = 0;
                    break;
                    case '1':
                    digit = 1;
                    break;
                    case '2':
                    digit = 2;
                    break;
                    case '3':
                    digit = 3;
                    break;
                    case '4':
                    digit = 4;
                    break;
                    case '5':
                    digit = 5;
                    break;
                    case '6':
                    digit = 6;
                    break;
                    case '7':
                    digit = 7;
                    break;
                    case '8':
                    digit = 8;
                    break;
                    case '9':
                    digit = 9;
                    break;
                    default:
                    throw new Exception();
                }

                // check for overflow - any number greater than this number will cause an overflow
                // when multiplied by 10
                if (signed && result > 0x0CCCCCCCCCCCCCCC || !signed && result > 0x1999999999999999) throw new Exception();

                result *= 10;
                result += digit;
            }

            if (isNeg && !signed && result != 0) throw new Exception();

            long res;

            if (isNeg)
            {
                res = -(long)result;

                // if the result is not negative, we had an overflow
                if (res > 0) throw new Exception();
            }
            else
            {
                res = (long)result;

                // if the result is negative and we are not converting a
                // UInt64, we had an overflow
                if (max != 0 && res < 0) throw new Exception();
            }

            // final check for max/min
            if (max != 0 && (res < min || res > max)) throw new Exception();

            return res;
        }

        private static double GetDoubleNumber(char[] chars, int start, int length, out int numLeadingZeros)
        {
            double number = 0;
            var isNeg = false;
            var end = start + length;

            numLeadingZeros = 0;

            if (chars[start] == '-')
            {
                isNeg = true;
                start++;
            }
            else if (chars[start] == '+')
            {
                start++;
            }

            for (var i = start; i < end; i++)
            {
                int digit;
                var c = chars[i];

                // switch statement is faster than subtracting '0'                
                switch (c)
                {
                    case '0':
                    // update the number of leading zeros (used for normalizing)
                    if (numLeadingZeros + start == i)
                    {
                        numLeadingZeros++;
                    }
                    digit = 0;
                    break;
                    case '1':
                    digit = 1;
                    break;
                    case '2':
                    digit = 2;
                    break;
                    case '3':
                    digit = 3;
                    break;
                    case '4':
                    digit = 4;
                    break;
                    case '5':
                    digit = 5;
                    break;
                    case '6':
                    digit = 6;
                    break;
                    case '7':
                    digit = 7;
                    break;
                    case '8':
                    digit = 8;
                    break;
                    case '9':
                    digit = 9;
                    break;
                    default:
                    throw new Exception();
                }

                number *= 10;
                number += digit;
            }

            return isNeg ? -number : number;
        }

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent String representation encoded with base 64 digits.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers. </param>
        /// <returns>The String representation, in base 64, of the contents of <paramref name="inArray"/>.</returns>
        public static string ToBase64String(byte[] inArray)
        {
            if (inArray == null) throw new ArgumentNullException();

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
            if (inArray == null) throw new ArgumentNullException();

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
            if (inArray == null) throw new ArgumentNullException();
            if (length < 0) throw new ArgumentOutOfRangeException();
            if (offset < 0) throw new ArgumentOutOfRangeException();
            if (options < Base64FormattingOptions.None || options > Base64FormattingOptions.InsertLineBreaks) throw new ArgumentException();

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
            if (inString == null) throw new ArgumentNullException();

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
            if (inArray == null) throw new ArgumentNullException();
            if (length < 0) throw new ArgumentOutOfRangeException();
            if (offset < 0) throw new ArgumentOutOfRangeException();
            if (offset > inArray.Length - length) throw new ArgumentOutOfRangeException();

            // copy to new array
            var destinationArray = new char[length];
            Array.Copy(inArray, offset, destinationArray, 0, length);

            return FromBase64CharArray(inArray, length);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern byte[] FromBase64CharArray(char[] inArray, int length);
    }
}
