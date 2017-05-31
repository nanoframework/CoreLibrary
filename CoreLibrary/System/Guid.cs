
using System.Runtime.CompilerServices;

namespace System
{
    [Serializable]
    public struct Guid
    {
        ////////////////////////////////////////////////////////////////////////////////
        //  Member variables
        ////////////////////////////////////////////////////////////////////////////////
        private int   _a;
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
                throw new ArgumentNullException();
            if (b.Length != 16)
                throw new ArgumentException();

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
                throw new ArgumentException();
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
        /// <param name="o">The object to compare with this instance. </param>
        /// <returns></returns>
        public override bool Equals(Object o)
        {
            Guid g;
            // Check that o is a Guid first
            if (o == null || !(o is Guid))
                return false;
            else g = (Guid)o;

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
    }
}
