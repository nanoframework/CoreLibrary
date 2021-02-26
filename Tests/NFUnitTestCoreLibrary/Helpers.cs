using System;

namespace NFUnitTestCoreLibrary
{
    class Helper
    {
        static string DigitialToHex(int x)
        {
            switch (x)
            {
                case 0: return "0";
                case 1: return "1";
                case 2: return "2";
                case 3: return "3";
                case 4: return "4";
                case 5: return "5";
                case 6: return "6";
                case 7: return "7";
                case 8: return "8";
                case 9: return "9";
                case 10: return "A";
                case 11: return "B";
                case 12: return "C";
                case 13: return "D";
                case 14: return "E";
                case 15: return "F";
                default: throw new Exception();
            }
        }

        static string ByteToHex(byte b)
        {
            return DigitialToHex(b / 16) + DigitialToHex(b % 16);
        }

        static string LongToHex(long l)
        {
            string sHex = string.Empty;

            for (int i = 0; i < 8; i++)
            {
                sHex = ByteToHex((byte)(l & 0xff)) + sHex;
                l >>= 8;
            }

            return sHex;
        }

        static bool CompareByteArray(byte[] left, byte[] right)
        {
            if (left.Length != right.Length)
            {
                return false;
            }

            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        static string ByteArrayToHex(byte[] bs)
        {
            string sHex = string.Empty;

            foreach (byte b in bs)
            {
                if (sHex.Length > 0)
                {
                    sHex += "-";
                }

                sHex += ByteToHex(b);
            }

            return sHex;
        }

        static public void DoubleToLongBits(double input, long expected)
        {
            long ret = BitConverter.DoubleToInt64Bits(input);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.DoubleToInt64Bit result:{LongToHex(ret)} expected:{LongToHex(expected)} input:{input}");
            }
        }

        static public void GetBytesBool(bool input, byte[] expected)
        {
            byte[] ret = BitConverter.GetBytes(input);

            if (!CompareByteArray(ret, expected))
            {
                throw new Exception(
                    $"BitConverter.GetBytes<bool> result:{ByteArrayToHex(ret)} expected:{ByteArrayToHex(expected)} input:{input}");
            }
        }

        static public void GetBytesChar(char input, byte[] expected)
        {
            byte[] ret = BitConverter.GetBytes(input);

            if (!CompareByteArray(ret, expected))
            {
                throw new Exception(
                    $"BitConverter.GetBytes<char> result:{ByteArrayToHex(ret)} expected:{ByteArrayToHex(expected)} input:{input}");
            }
        }

        static public void GetBytesDouble(double input, byte[] expected)
        {
            byte[] ret = BitConverter.GetBytes(input);

            if (!CompareByteArray(ret, expected))
            {
                throw new Exception(
                    $"BitConverter.GetBytes<double> result:{ByteArrayToHex(ret)} expected:{ByteArrayToHex(expected)} input:{input}");
            }
        }

        static public void GetBytesSingle(float input, byte[] expected)
        {
            byte[] ret = BitConverter.GetBytes(input);

            if (!CompareByteArray(ret, expected))
            {
                throw new Exception(
                    $"BitConverter.GetBytes<float> result:{ByteArrayToHex(ret)} expected:{ByteArrayToHex(expected)} input:{input}");
            }
        }

        static public void GetBytesInt64(long input, byte[] expected)
        {
            byte[] ret = BitConverter.GetBytes(input);

            if (!CompareByteArray(ret, expected))
            {
                throw new Exception(
                    $"BitConverter.GetBytes<long> result:{ByteArrayToHex(ret)} expected:{ByteArrayToHex(expected)} input:{input}");
            }
        }

        static public void GetBytesInt32(int input, byte[] expected)
        {
            byte[] ret = BitConverter.GetBytes(input);

            if (!CompareByteArray(ret, expected))
            {
                throw new Exception(
                    $"BitConverter.GetBytes<int> result:{ByteArrayToHex(ret)} expected:{ByteArrayToHex(expected)} input:{input}");
            }
        }

        static public void GetBytesInt16(short input, byte[] expected)
        {
            byte[] ret = BitConverter.GetBytes(input);

            if (!CompareByteArray(ret, expected))
            {
                throw new Exception(
                    $"BitConverter.GetBytes<short> result:{ByteArrayToHex(ret)} expected:{ByteArrayToHex(expected)} input:{input}");               
            }
        }

        static public void GetBytesUInt64(ulong input, byte[] expected)
        {
            byte[] ret = BitConverter.GetBytes(input);

            if (!CompareByteArray(ret, expected))
            {
                throw new Exception(
                    $"BitConverter.GetBytes<ulong> result:{ByteArrayToHex(ret)} expected:{ByteArrayToHex(expected)} input:{input}");
            }
        }

        static public void GetBytesUInt32(uint input, byte[] expected)
        {
            byte[] ret = BitConverter.GetBytes(input);

            if (!CompareByteArray(ret, expected))
            {
                throw new Exception(
                    $"BitConverter.GetBytes<uint> result:{ByteArrayToHex(ret)} expected:{ByteArrayToHex(expected)} input:{input}");
            }
        }

        static public void GetBytesUInt16(ushort input, byte[] expected)
        {
            byte[] ret = BitConverter.GetBytes(input);

            if (!CompareByteArray(ret, expected))
            {
                throw new Exception(
                    $"BitConverter.GetBytes<ushort> result:{ByteArrayToHex(ret)} expected:{ByteArrayToHex(expected)} input:{input}");
            }
        }

        static public void LongBitsToDouble(long input, double expected)
        {
            double ret = BitConverter.Int64BitsToDouble(input);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.Int64BitsToDouble result:{ret} expected:{expected} input:{input}");
            }
        }

        static public void BAToBool(byte[] bytes, int index, bool expected)
        {
            bool ret = BitConverter.ToBoolean(bytes, index);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.ToBoolean result:{ret} expected:{expected} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToBoolThrow(byte[] bytes, int index, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToBoolean(bytes, index);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                    $"BitConverter.ToBoolean expected exception:{expectedExceptionType} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToChar(byte[] bytes, int index, char expected)
        {
            char ret = BitConverter.ToChar(bytes, index);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.ToChar result:{ret} expected:{expected} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToCharThrow(byte[] bytes, int index, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToChar(bytes, index);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                    $"BitConverter.ToChar exception:{exception} expected:{expectedExceptionType} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToDouble(byte[] bytes, int index, double expected)
        {
            double ret = BitConverter.ToDouble(bytes, index);

            if (ret != expected)
            {
                throw new Exception(
                   $"BitConverter.ToDouble result:{ret} expected:{expected} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToDoubleThrow(byte[] bytes, int index, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToDouble(bytes, index);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                    $"BitConverter.ToDouble exception:{exception} expected:{expectedExceptionType} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToInt16(byte[] bytes, int index, short expected)
        {
            short ret = BitConverter.ToInt16(bytes, index);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.ToInt16 result:{ret} expected:{expected} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToInt16Throw(byte[] bytes, int index, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToInt16(bytes, index);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                   $"BitConverter.ToInt16 exception:{exception} expected:{expectedExceptionType} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToInt32(byte[] bytes, int index, int expected)
        {
            int ret = BitConverter.ToInt32(bytes, index);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.ToInt32 result:{ret} expected:{expected} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToInt32Throw(byte[] bytes, int index, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToInt32(bytes, index);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                    $"BitConverter.ToInt32 exception:{exception} expected:{expectedExceptionType} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToInt64(byte[] bytes, int index, long expected)
        {
            long ret = BitConverter.ToInt64(bytes, index);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.ToInt64 result:{ret} expected:{expected} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToInt64Throw(byte[] bytes, int index, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToInt64(bytes, index);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                    $"BitConverter.ToInt64 exception:{exception} expected:{expectedExceptionType} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToSingle(byte[] bytes, int index, float expected)
        {
            float ret = BitConverter.ToSingle(bytes, index);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.ToSingle result:{ret} expected:{expected} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToSingleThrow(byte[] bytes, int index, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToSingle(bytes, index);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                    $"BitConverter.ToSingle exception:{exception} expected:{expectedExceptionType} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToUInt16(byte[] bytes, int index, ushort expected)
        {
            ushort ret = BitConverter.ToUInt16(bytes, index);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.ToUInt16 result:{ret} expected:{expected} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToUInt16Throw(byte[] bytes, int index, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToUInt16(bytes, index);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                    $"BitConverter.ToUInt16 exception:{exception} expected:{expectedExceptionType} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToUInt32(byte[] bytes, int index, uint expected)
        {
            uint ret = BitConverter.ToUInt32(bytes, index);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.ToUInt32 result:{ret} expected:{expected} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToUInt32Throw(byte[] bytes, int index, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToUInt32(bytes, index);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                    $"BitConverter.ToUInt32 exception:{exception} expected:{expectedExceptionType} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToUInt64(byte[] bytes, int index, ulong expected)
        {
            ulong ret = BitConverter.ToUInt64(bytes, index);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.ToUInt64 result:{ret} expected:{expected} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void BAToUInt64Throw(byte[] bytes, int index, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToUInt64(bytes, index);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                    $"BitConverter.ToUInt64 exception:{exception} expected:{expectedExceptionType} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void WriteByteArray(byte[] bytes, string expected)
        {
            string ret = BitConverter.ToString(bytes);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.ToString result:{ret} expected:{expected} input:{ByteArrayToHex(bytes)}");
            }
        }

        static public void WriteMultiLineByteArray(byte[] bytes, string expected)
        {
            string ret = string.Empty;

            const int rowSize = 20;
            int i;
            for (i = 0; i < bytes.Length - rowSize; i += rowSize)
            {
                if (ret.Length > 0)
                {
                    ret += "\r\n";
                }
                ret += BitConverter.ToString(bytes, i, rowSize);
            }

            if (ret.Length > 0)
            {
                ret += "\r\n";
            }
            ret += BitConverter.ToString(bytes, i);

            if (ret != expected)
            {
                throw new Exception(
                    $"BitConverter.ToString(2) result:{ret} expected:{expected} input:{ByteArrayToHex(bytes)}");
            }
        }

        static public void ToStringThrow(byte[] bytes, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToString(bytes);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                    $"BitConverter.ToString exception:{exception} expected:{expectedExceptionType} input:{ByteArrayToHex(bytes)}");
            }
        }

        static public void ToStringThrow(byte[] bytes, int index, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToString(bytes, index);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                    $"BitConverter.ToString exception:{exception} expected:{expectedExceptionType} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }

        static public void ToStringThrow(byte[] bytes, int index, int length, Type expectedExceptionType)
        {
            Exception exception = null;

            try
            {
                BitConverter.ToString(bytes, index, length);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception == null || exception.GetType() != expectedExceptionType)
            {
                throw new Exception(
                    $"BitConverter.ToString exception:{exception} expected:{expectedExceptionType} input:{ByteArrayToHex(bytes)} index:{index}");
            }
        }
    }
}
