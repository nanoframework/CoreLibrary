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
        public static readonly Guid Empty = new Guid(new byte[16]);

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
        /// Groups of 8, 4, 4, 4, and 12 hexadecimal digits with hyphens between the groups. The entire GUID can optionally be enclosed in matching braces or parentheses:
        ///
        /// dddddddd-dddd-dddd-dddd-dddddddddddd
        ///
        /// -or-
        ///
        /// {dddddddd-dddd-dddd-dddd-dddddddddddd}
        ///
        /// The hexadecimal digits shown in a group are the maximum number of meaningful hexadecimal digits that can appear in that group. You can specify from 1 to the number of hexadecimal digits shown for a group. The specified digits are assumed to be the low-order digits of the group.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="g"/> is <see langword="null"/>.</exception>"
        /// <exception cref="ArgumentException"><paramref name="g"/> is not in a recognized format.</exception>
        public Guid(string g)
        {
            ArgumentNullException.ThrowIfNull(g);

#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (!TryParse(
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
        /// Converts the string representation of a GUID to the equivalent <see cref="Guid"/> structure.
        /// </summary>
        /// <param name="input">A string containing the GUID to convert.</param>
        /// <param name="result">When this method returns, contains the parsed value. If the method returns <see langword="true"/>, result contains a valid <see cref="Guid"/>. If the method returns <see langword="false"/>, result equals <see cref="Empty"/>.</param>
        /// <returns><see langword="true"/> if the parse operation was successful; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// The .NET nanoFramework implementation of this method only supports 'D' and 'N' format specifiers.
        /// </remarks>
        public static bool TryParse(
            string input,
            out Guid result)
        {
            int startPos = 0;

            // because this is a struct we can't assign the Empty directly to result,
            // otherwise it will overwrite the _data field of the struct, as this is a shallow copy
            result = new Guid(new byte[16]);

            // Check for optional surrounding braces
            if (input[0] == '{')
            {
                if (input.Length != 38 || input[37] != '}')
                {
                    return false;
                }

                startPos = 1;
            }
            else if (input.Length != 36)
            {
                return false;
            }

            // Verify hyphen positions
            if (input[8 + startPos] != '-' ||
                input[13 + startPos] != '-' ||
                input[18 + startPos] != '-' ||
                input[23 + startPos] != '-')
            {
                return false;
            }

            int currentPos = startPos;

            try
            {
                // Data1: 8 hex digits
                result._data[0] = (int)HexStringToLong(input, ref currentPos, 8);

                // Skip dash
                ++currentPos;

                // Data2: 4 hex digits
                ushort data2 = (ushort)HexStringToLong(input, ref currentPos, 4);

                // Skip dash
                ++currentPos;

                // Data3: 4 hex digits
                ushort data3 = (ushort)HexStringToLong(input, ref currentPos, 4);

                // These values are already in big‑endian order as in the string
                // They must be stored directly (without swapping) in the internal little‑endian representation
                result._data[1] = data2 | (data3 << 16);

                // Skip dash
                ++currentPos;

                // Data4 – first part: 4 hex digits (2 bytes)
                ushort group4 = (ushort)HexStringToLong(input, ref currentPos, 4);

                // Skip dash
                ++currentPos;

                // Data4 – second part: 12 hex digits (6 bytes)
                long group5 = HexStringToLong(input, ref currentPos, 12);

                // For Data4, we need to convert from big‑endian to little‑endian
                // Swap the 2-byte group
                ushort group4_le = (ushort)(((group4 & 0xFF) << 8) | (group4 >> 8));

                // Split the 6-byte group into its high 2 bytes and low 4 bytes
                // high 16 bits (big‑endian)
                ushort group5High = (ushort)(group5 >> 32);

                // low 32 bits (big‑endian)
                uint group5Low = (uint)(group5 & 0xFFFFFFFF);

                // Swap bytes for each
                ushort group5High_le = (ushort)(((group5High & 0xFF) << 8) | (group5High >> 8));
                uint group5Low_le = ((group5Low & 0xFF) << 24) |
                                    (((group5Low >> 8) & 0xFF) << 16) |
                                    (((group5Low >> 16) & 0xFF) << 8) |
                                    ((group5Low >> 24) & 0xFF);

                // Combine the converted Data4 parts into _data[2] and _data[3]
                // _data[2]: lower 16 bits from swapped group4, upper 16 bits from swapped group5High
                result._data[2] = group4_le | (group5High_le << 16);

                // _data[3]: swapped group5Low
                result._data[3] = (int)group5Low_le;
            }
            catch
            {
                return false;
            }

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
