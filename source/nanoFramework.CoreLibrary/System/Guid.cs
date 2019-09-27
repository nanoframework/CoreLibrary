
using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Represents a globally unique identifier (GUID).
    /// </summary>
    [Serializable]
    public struct Guid
    {
        ////////////////////////////////////////////////////////////////////////////////
        //  Member variables
        ////////////////////////////////////////////////////////////////////////////////
        private int _a;
        private short _b;
        private short _c;
        private byte _d;
        private byte _e;
        private byte _f;
        private byte _g;
        private byte _h;
        private byte _i;
        private byte _j;
        private byte _k;

        /// <summary>
        /// A read-only instance of the Guid class which consists of all zeros.
        /// </summary>
        public static readonly Guid Empty = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

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
        public Guid(int a, short b, short c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _e = e;
            _f = f;
            _g = g;
            _h = h;
            _i = i;
            _j = j;
            _k = k;
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
        public Guid(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)
        {
            _a = (int)a;
            _b = (short)b;
            _c = (short)c;
            _d = d;
            _e = e;
            _f = f;
            _g = g;
            _h = h;
            _i = i;
            _j = j;
            _k = k;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guid"/> structure by using the specified array of bytes.
        /// </summary>
        /// <param name="b">A 16-element byte array containing values with which to initialize the GUID.</param>
        public Guid(byte[] b)
        {
            if (b == null)
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentNullException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (b.Length != 16)
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            _a = b[3] << 24 | b[2] << 16 | b[1] << 8 | b[0];
            _b = (short)(b[5] << 8 | b[4]);
            _c = (short)(b[7] << 8 | b[6]);
            _d = b[8];
            _e = b[9];
            _f = b[10];
            _g = b[11];
            _h = b[12];
            _i = b[13];
            _j = b[14];
            _k = b[15];
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
        /// <param name="g">String representation of new <see cref="Guid"/>.</param>
        /// <exception cref="ArgumentException"></exception>
        public Guid(string g)
        {
            if (!TryParseGuidWithDashes(g, out this))
            {
                throw new ArgumentException("Guid string not in expected format: [{]dddddddd-dddd-dddd-dddd-dddddddddddd[}]");
            }
        }

        /// <summary>
        /// Compares this instance to a specified object and returns an indication of their relative values.
        /// </summary>
        /// <param name="value">Guid instance to compare, or null.</param>
        /// <returns>Indication of the relative values (0 = equal, -1 = this instance less, +1 = this instance greater)</returns>
        public int CompareTo(Object value)
        {
            if (value == null)
            {
                return 1;
            }
            if (!(value is Guid))
            {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            }

            Guid g = (Guid)value;

            if (g._a != _a)
            {
                return GetResult((uint)_a, (uint)g._a);
            }

            if (g._b != _b)
            {
                return GetResult((uint)_b, (uint)g._b);
            }

            if (g._c != _c)
            {
                return GetResult((uint)_c, (uint)g._c);
            }

            if (g._d != _d)
            {
                return GetResult((uint)_d, (uint)g._d);
            }

            if (g._e != _e)
            {
                return GetResult((uint)_e, (uint)g._e);
            }

            if (g._f != _f)
            {
                return GetResult((uint)_f, (uint)g._f);
            }

            if (g._g != _g)
            {
                return GetResult((uint)_g, (uint)g._g);
            }

            if (g._h != _h)
            {
                return GetResult((uint)_h, (uint)g._h);
            }

            if (g._i != _i)
            {
                return GetResult((uint)_i, (uint)g._i);
            }

            if (g._j != _j)
            {
                return GetResult((uint)_j, (uint)g._j);
            }

            if (g._k != _k)
            {
                return GetResult((uint)_k, (uint)g._k);
            }

            return 0;
        }

        /// <summary>
        /// Returns a 16-element byte array that contains the value of this instance.
        /// </summary>
        /// <returns>A 16-element byte array.</returns>
        public byte[] ToByteArray()
        {
            byte[] g = new byte[16];

            g[0] = (byte)(_a);
            g[1] = (byte)(_a >> 8);
            g[2] = (byte)(_a >> 16);
            g[3] = (byte)(_a >> 24);
            g[4] = (byte)(_b);
            g[5] = (byte)(_b >> 8);
            g[6] = (byte)(_c);
            g[7] = (byte)(_c >> 8);
            g[8] = _d;
            g[9] = _e;
            g[10] = _f;
            g[11] = _g;
            g[12] = _h;
            g[13] = _i;
            g[14] = _j;
            g[15] = _k;

            return g;
        }

        /// <summary>
        /// Returns a string representation of the value of this instance of the <see cref="Guid"/> structure.
        /// </summary>
        /// <returns>The value of this Guid, formatted by using the "D" format specifier as follows: 
        ///
        /// xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx 
        ///
        /// where the value of the GUID is represented as a series of lowercase hexadecimal digits in groups of 8, 4, 4, 4, and 12 digits and separated by hyphens. An example of a return value is "382c74c3-721d-4f34-80e5-57657b6cbc27". To convert the hexadecimal digits from a through f to uppercase, call the <see cref="String.ToUpper"/> method on the returned string.
        /// </returns>
        public override string ToString()
        {
            // default format is dddddddd-dddd-dddd-dddd-dddddddddddd

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
        /// <param name="obj">The object to compare with this instance. </param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            Guid g;
            // Check that o is a Guid first
            if (obj == null || !(obj is Guid))
                return false;
            else g = (Guid)obj;

            // Now compare each of the elements
            if (g._a != _a)
                return false;
            if (g._b != _b)
                return false;
            if (g._c != _c)
                return false;
            if (g._d != _d)
                return false;
            if (g._e != _e)
                return false;
            if (g._f != _f)
                return false;
            if (g._g != _g)
                return false;
            if (g._h != _h)
                return false;
            if (g._i != _i)
                return false;
            if (g._j != _j)
                return false;
            if (g._k != _k)
                return false;

            return true;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return _a ^ (((int)_b << 16) | (int)(ushort)_c) ^ (((int)_f << 24) | _k);
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

        private int GetResult(uint me, uint them)
        {
            if (me < them)
            {
                return -1;
            }
            return 1;
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
        /// <param name="guidString">Guid string to parse.</param>
        /// <param name="result">Resulting Guid.</param>
        /// <returns></returns>
        public static bool TryParseGuidWithDashes(String guidString, out Guid result)
        {
            int startPos = 0;
            int temp;
            long templ;
            int currentPos = 0;
            result = Guid.Empty;

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

            currentPos = startPos;
            try
            {
                result._a = (int)HexStringToLong(guidString, ref currentPos, 8);
                ++currentPos; // Increment past the '-'
                result._b = (short)HexStringToLong(guidString, ref currentPos, 4);
                ++currentPos; // Increment past the '-'
                result._c = (short)HexStringToLong(guidString, ref currentPos, 4);
                ++currentPos; // Increment past the '-'
                temp = (int)HexStringToLong(guidString, ref currentPos, 4);
                ++currentPos; // Increment past the '-'
                templ = HexStringToLong(guidString, ref currentPos, 12);
            }
            catch
            {
                result = Guid.Empty;
                return false;
            }

            result._d = (byte)(temp >> 8);
            result._e = (byte)(temp);
            temp = (int)(templ >> 32);
            result._f = (byte)(temp >> 8);
            result._g = (byte)(temp);
            temp = (int)(templ);
            result._h = (byte)(temp >> 24);
            result._i = (byte)(temp >> 16);
            result._j = (byte)(temp >> 8);
            result._k = (byte)(temp);

            return true;
        }

        /// <summary>
        /// Converts a hex sub-string to a long, while incrementing the parsePos.
        /// </summary>
        /// <param name="str">The string containing the hex sub-string.</param>
        /// <param name="parsePos">The position of the hex sub-string within str.</param>
        /// <param name="requiredLength">The length of the hex sub-string.</param>
        /// <returns>False if any character is not a hex digit or string is shorter than needed for the requiredLength. Otherwise true.</returns>
        private static long HexStringToLong(String str, ref int parsePos, int requiredLength)
        {
            long result = Convert.ToInt64(str.Substring(parsePos, requiredLength), 16);
            parsePos += requiredLength;
            return result;
        }
    }
}
