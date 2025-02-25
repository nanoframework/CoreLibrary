// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Represents a globally unique identifier (GUID).
    /// </summary>
    [Serializable]
    public struct Guid
    {
        private int[] _data;

        /// <summary>
        /// A read-only instance of the Guid class which consists of all zeros.
        /// </summary>
        public static readonly Guid Empty = new Guid(
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0);

        /// <summary>
        /// Initializes a new instance of the <see cref="Guid"/> structure by using the specified integers and bytes.
        /// </summary>
        /// <param name="a">The first 4 bytes of the GUID.</param>
        /// <param name="b">The next 2 bytes of the GUID.</param>
        /// <param name="c">The next 2 bytes of the GUID.</param>
        /// <param name="d">The next byte of the GUID.</param>
        /// <param name="e">The next byte of the GUID.</param>
        /// <param name="f">The next byte of the GUID.</param>
        /// <param name="g">The next byte of the GUID.</param>
        /// <param name="h">The next byte of the GUID.</param>
        /// <param name="i">The next byte of the GUID.</param>
        /// <param name="j">The next byte of the GUID.</param>
        /// <param name="k">The next byte of the GUID.</param>
        /// <remarks>Specifying individual bytes in this manner can be used to circumvent byte order restrictions (big-endian or little-endian byte order) on particular types of computers.</remarks>
        public Guid(int a,
                    short b,
                    short c,
                    byte d,
                    byte e,
                    byte f,
                    byte g,
                    byte h,
                    byte i,
                    byte j,
                    byte k)
        {
            _data = new int[4];

            _data[0] = a;
            _data[1] = (ushort)b | (ushort)c << 16;
            _data[2] = d | (e | (f | g << 8) << 8) << 8;
            _data[3] = h | (i | (j | k << 8) << 8) << 8;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guid"/> structure by using the specified integers and bytes.
        /// </summary>
        /// <param name="a">The first 4 bytes of the GUID.</param>
        /// <param name="b">The next 2 bytes of the GUID.</param>
        /// <param name="c">The next 2 bytes of the GUID.</param>
        /// <param name="d">The next byte of the GUID.</param>
        /// <param name="e">The next byte of the GUID.</param>
        /// <param name="f">The next byte of the GUID.</param>
        /// <param name="g">The next byte of the GUID.</param>
        /// <param name="h">The next byte of the GUID.</param>
        /// <param name="i">The next byte of the GUID.</param>
        /// <param name="j">The next byte of the GUID.</param>
        /// <param name="k">The next byte of the GUID.</param>
        /// <remarks>Specifying the bytes in this manner avoids endianness issues.</remarks>
        [CLSCompliant(false)]
        public Guid(
            uint a,
            ushort b,
            ushort c,
            byte d,
            byte e,
            byte f,
            byte g,
            byte h,
            byte i,
            byte j,
            byte k)
        {
            _data = new int[4];

            _data[0] = (int)a;
            _data[1] = b | c << 16;
            _data[2] = d | (e | (f | g << 8) << 8) << 8;
            _data[3] = h | (i | (j | k << 8) << 8) << 8;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guid"/> structure by using the specified array of bytes.
        /// </summary>
        /// <param name="b">A 16-element byte array containing values with which to initialize the GUID.</param>
        /// <exception cref="ArgumentNullException"><paramref name="b"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="b"/> is not 16 bytes long.</exception>"
        public Guid(byte[] b)
        {
            ArgumentNullException.ThrowIfNull(b);

#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (b.Length != 16)
            {
                throw new ArgumentException();
            }
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            _data = new int[4];

            int i = 0;

            for (int j = 0; j < 4; j++)
            {
                _data[j] = b[i] | (b[i + 1] | (b[i + 2] | b[i + 3] << 8) << 8) << 8;
                i += 4;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guid"/> structure by using the value represented by the specified string.
        /// </summary>
        /// <param name="g">
        /// A string that contains a GUID in one of the following formats ("d" represents a hexadecimal digit whose case is ignored):
        ///
        /// 32 contiguous hexadecimal digits:
        ///
        /// dddddddddddddddddddddddddddddddd
        ///
        /// -or-
        ///
        /// Groups of 8, 4, 4, 4, and 12 hexadecimal digits with hyphens between the groups. The entire GUID can optionally be enclosed in matching braces or parentheses:
        ///
        /// dddddddd-dddd-dddd-dddd-dddddddddddd
        ///
        /// -or-
        ///
        /// {dddddddd-dddd-dddd-dddd-dddddddddddd}
        ///
        /// -or-
        ///
        /// (dddddddd-dddd-dddd-dddd-dddddddddddd)
        ///
        /// -or-
        ///
        /// Groups of 8, 4, and 4 hexadecimal digits, and a subset of eight groups of 2 hexadecimal digits, with each group prefixed by "0x" or "0X", and separated by commas. The entire GUID, as well as the subset, is enclosed in matching braces:
        ///
        /// {0xdddddddd, 0xdddd, 0xdddd,{0xdd,0xdd,0xdd,0xdd,0xdd,0xdd,0xdd,0xdd}}
        ///
        /// All braces, commas, and "0x" prefixes are required. All embedded spaces are ignored. All leading zeros in a group are ignored.
        ///
        /// The hexadecimal digits shown in a group are the maximum number of meaningful hexadecimal digits that can appear in that group. You can specify from 1 to the number of hexadecimal digits shown for a group. The specified digits are assumed to be the low-order digits of the group.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="g"/> is <see langword="null"/>.</exception>"
        /// <exception cref="ArgumentException"><paramref name="g"/> is not in a recognized format.</exception>
        public Guid(string g)
        {
            ArgumentNullException.ThrowIfNull(g);

#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (!TryParseGuidWithDashes(
                g,
                out this))
            {
                throw new ArgumentException();
            }
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one
        }

        /// <summary>
        /// Compares this instance to a specified object and returns an indication of their relative values.
        /// </summary>
        /// <param name="value">An object to compare, or <see langword="null"/>.</param>
        /// <returns>A signed number indicating the relative values of this instance and value.
        /// (0 = This instance is equal to <paramref name="value"/>., -1 = This instance is less than <paramref name="value"/>., +1 = This instance is greater than <paramref name="value"/>, or <paramref name="value"/> is <see langword="null"/>.)</returns>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a <see cref="Guid"/>.</exception>
        public int CompareTo(object value)
        {
            if (value == null)
            {
                return 1;
            }

#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (value is not Guid)
            {
                throw new ArgumentException();
            }
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one

            int[] other = ((Guid)value)._data;
            other ??= new int[4];

            for (int i = 0; i < 4; i++)
            {
                if (_data[i] != other[i])
                {
                    return _data[i] - other[i];
                }
            }

            return 0;
        }

        /// <summary>
        /// Returns a 16-element byte array that contains the value of this instance.
        /// </summary>
        /// <returns>A 16-element byte array.</returns>
        public byte[] ToByteArray()
        {
            byte[] buffer = new byte[16];

            int index = 0;

            for (int i = 0; i < 4; i++)
            {
                int value = _data[i];

                for (int j = 0; j < 4; j++)
                {
                    buffer[index++] = (byte)(value & 0xFF);
                    value = value >> 8;
                }
            }

            return buffer;
        }

        /// <summary>
        /// Returns a string representation of the value of this instance in registry format.
        /// </summary>
        /// <returns>The value of this Guid, formatted by using the "D" format specifier as follows: 
        ///
        /// xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx 
        ///
        /// where the value of the GUID is represented as a series of lowercase hexadecimal digits in groups of 8, 4, 4, 4, and 12 digits and separated by hyphens. An example of a return value is "382c74c3-721d-4f34-80e5-57657b6cbc27". To convert the hexadecimal digits from a through f to uppercase, call the <see cref="String.ToUpper"/> method on the returned string.
        /// </returns>
        public override string ToString()
        {
            _data ??= new int[4];

            byte[] bytes = ToByteArray();

            char[] chars = new char[36];

            int i = -1, j;

            for (j = 3; j >= 0; --j)
            {
                chars[++i] = HexToChar((bytes[j] & 0xF0) >> 4);
                chars[++i] = HexToChar((bytes[j] & 0x0F));
            }

            chars[++i] = '-';
            for (j = 5; j >= 4; --j)
            {
                chars[++i] = HexToChar((bytes[j] & 0xF0) >> 4);
                chars[++i] = HexToChar((bytes[j] & 0x0F));
            }

            chars[++i] = '-';
            for (j = 7; j >= 6; --j)
            {
                chars[++i] = HexToChar((bytes[j] & 0xF0) >> 4);
                chars[++i] = HexToChar((bytes[j] & 0x0F));
            }

            chars[++i] = '-';

            for (j = 8; j <= 9; ++j)
            {
                chars[++i] = HexToChar((bytes[j] & 0xF0) >> 4);
                chars[++i] = HexToChar((bytes[j] & 0x0F));
            }

            chars[++i] = '-';
            for (j = 10; j <= 15; ++j)
            {
                chars[++i] = HexToChar((bytes[j] & 0xF0) >> 4);
                chars[++i] = HexToChar((bytes[j] & 0x0F));
            }

            return new string(chars);
        }

        /// <summary>
        /// Returns a value that indicates whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="o">The object to compare with this instance. </param>
        /// <returns><see langword="true"/> if <paramref name="o"/> is a <see cref="Guid"/> that has the same value as this instance; otherwise, <see langword="false"/>.</returns>
        /// <remarks>Two <see cref="Guid"/> objects are equal if they have identical byte values.</remarks>
        public override bool Equals(object o)
        {
            if (o is not Guid)
            {
                return false;
            }

            int[] other = ((Guid)o)._data;
            other ??= new int[4];

            return (_data[0] == other[0]) && (_data[1] == other[1]) && (_data[2] == other[2]) && (_data[3] == other[3]);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return _data[0] ^ _data[1] ^ _data[2] ^ _data[3];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guid"/> structure.
        /// </summary>
        /// <returns>A new GUID object.</returns>
        public static Guid NewGuid()
        {
            return new Guid(GenerateNewGuid());
        }

        // The native methods implementation is to return a 16 byte array properly generated to provide a valid GUID.
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern byte[] GenerateNewGuid();

        private static char HexToChar(int a)
        {
            return (char)((a > 9) ? a - 10 + 0x61 : a + 0x30);
        }

        /// <summary>
        ///   Creates a new <see cref="Guid"/> based on the value in the string.  The value is made up
        ///   of hex digits speared by the dash ("-"). The string may begin and end with
        ///   brackets ("{", "}").
        ///   
        ///   The string must be of the form dddddddd-dddd-dddd-dddd-dddddddddddd. where
        ///   d is a hex digit. (That is 8 hex digits, followed by 4, then 4, then 4,
        ///   then 12) such as: "CA761232-ED42-11CE-BACD-00AA0057B223"
        /// </summary>
        /// <param name="guidString">A string containing the GUID to convert.</param>
        /// <param name="result">When this method returns, contains the parsed value. If the method returns <see langword="true"/>, result contains a valid <see cref="Guid"/>. If the method returns <see langword="false"/>, result equals <see cref="Empty"/>.</param>
        /// <returns><see langword="true"/> if the parse operation was successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryParseGuidWithDashes(
            string guidString,
            out Guid result)
        {
            int startPos = 0;
            int temp;
            long templ;
            result = Empty;

            // check to see that it's the proper length
            if (guidString[0] == '{')
            {
                if (guidString.Length != 38 || guidString[37] != '}')
                {
                    return false;
                }
                startPos = 1;
            }
            else if (guidString.Length != 36)
            {
                return false;
            }

            if (guidString[8 + startPos] != '-' ||
                guidString[13 + startPos] != '-' ||
                guidString[18 + startPos] != '-' ||
                guidString[23 + startPos] != '-')
            {
                return false;
            }

            int currentPos = startPos;
            try
            {
                result._data[0] = (int)HexStringToLong(guidString, ref currentPos, 8);

                // Increment past the '-'
                ++currentPos;

                result._data[1] = (ushort)HexStringToLong(guidString, ref currentPos, 4)
                                  | ((ushort)HexStringToLong(guidString, ref currentPos, 4) << 16);

                // Increment past the '-'
                ++currentPos;

                temp = (int)HexStringToLong(guidString, ref currentPos, 4);

                // Increment past the '-'
                ++currentPos;

                templ = HexStringToLong(guidString, ref currentPos, 12);
            }
            catch
            {
                result = Empty;
                return false;
            }

            result._data[2] = temp | (int)(templ >> 32) << 16;
            result._data[3] = (int)templ;

            return true;
        }

        /// <summary>
        /// Converts a hex sub-string to a long, while incrementing the parsePos.
        /// </summary>
        /// <param name="str">The string containing the hex sub-string.</param>
        /// <param name="parsePos">The position of the hex sub-string within str.</param>
        /// <param name="requiredLength">The length of the hex sub-string.</param>
        /// <returns>False if any character is not a hex digit or string is shorter than needed for the requiredLength. Otherwise true.</returns>
        private static long HexStringToLong(string str, ref int parsePos, int requiredLength)
        {
            long result = Convert.ToInt64(str.Substring(parsePos, requiredLength), 16);
            parsePos += requiredLength;
            return result;
        }
    }
}
