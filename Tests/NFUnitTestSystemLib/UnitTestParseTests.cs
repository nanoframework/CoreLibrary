//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestSystemLib
{
    [TestClass]
    class UnitTestParseTests
    {
        public static int[] intArr = null;
        public String[] GetRandomStringArray(int max, bool signed)
        {
            Random random = new Random();
            String[] arr1 = new String[] { "0", "-0","+0",
                                        "00000     ", "    -00000","   +00000  ",
                                        "   0   ", "  -00000  ",
                                        "+123", "  +123  ", "   +123", "+123    " };
            String[] arr2 = new String[10];
            intArr = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 123, 123, 123, 123, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < arr2.Length; i++)
            {
                if (signed && ((i % 2) == 0))
                {
                    intArr[i + 12] = -(random.Next(max));
                    arr2[i] = (intArr[i + 12].ToString());
                }
                else
                {
                    intArr[i + 12] = random.Next(max);
                    arr2[i] = intArr[i + 12].ToString();
                }
            }
            String[] arr = new String[22];
            Array.Copy(arr1, arr, arr1.Length);
            Array.Copy(arr2, 0, arr, arr1.Length, arr2.Length);
            return arr;
        }

        [TestMethod]
        public void ParseSByte_Test_1()
        {
            Debug.WriteLine("SByte MinValue = " + SByte.MinValue.ToString());
            Debug.WriteLine("SByte MaxValue = " + SByte.MaxValue.ToString());

            String[] strArr = GetRandomStringArray(SByte.MaxValue, true);
            SByte[] _sByte = new SByte[intArr.Length];
            for (int i = 0; i < _sByte.Length; i++)
            {
                _sByte[i] = (SByte)intArr[i];
            }

            SByte temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = SByte.Parse(strArr[i]);
                Assert.Equal(temp, _sByte[i]);
            }
        }

        [TestMethod]
        public void ParseByte_Test_2()
        {
            Debug.WriteLine("Byte MinValue = " + Byte.MinValue.ToString());
            Debug.WriteLine("Byte MaxValue = " + Byte.MaxValue.ToString());

            String[] strArr = GetRandomStringArray(Byte.MaxValue, false);
            Byte[] _byte = new Byte[intArr.Length];
            for (int i = 0; i < _byte.Length; i++)
            {
                    _byte[i] = (Byte)intArr[i];
             }

            Byte temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = Byte.Parse(strArr[i]);
                Assert.Equal(temp, _byte[i]);
            }
        }

        [TestMethod]
        public void ParseInt16_Test_3()
        {
            Debug.WriteLine("Int16 MinValue = " + Int16.MinValue.ToString());
            Debug.WriteLine("Int16 MaxValue = " + Int16.MaxValue.ToString());

            String[] strArr = GetRandomStringArray(Int16.MaxValue, true);
            Int16[] _int16 = new Int16[intArr.Length];
            for (int i = 0; i < _int16.Length; i++)
            {
                _int16[i] = (Int16)intArr[i];
            }
            Int16 temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = Int16.Parse(strArr[i]);
                Assert.Equal(temp, _int16[i]);
            }
        }

        [TestMethod]
        public void ParseUInt16_Test_4()
        {
            Debug.WriteLine("UInt16 MinValue = " + UInt16.MinValue.ToString());
            Debug.WriteLine("UInt16 MaxValue = " + UInt16.MaxValue.ToString());


            String[] strArr = GetRandomStringArray(UInt16.MaxValue, false);
            UInt16[] _uInt16 = new UInt16[intArr.Length];
            for (int i = 0; i < _uInt16.Length; i++)
            {
                _uInt16[i] = (UInt16)intArr[i];
            }

            UInt16 temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = UInt16.Parse(strArr[i]);
                Assert.Equal(temp, _uInt16[i]);
            }
        }

        [TestMethod]
        public void ParseInt32_Test_5()
        {
            Debug.WriteLine("Int32 MinValue = " + Int32.MinValue.ToString());
            Debug.WriteLine("Int32 MaxValue = " + Int32.MaxValue.ToString());


            String[] strArr = GetRandomStringArray(Int32.MaxValue, true);
            Int32[] _int32 = new Int32[intArr.Length];
            for (int i = 0; i < _int32.Length; i++)
            {
                _int32[i] = (Int32)intArr[i];
            }

            Int32 temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = Int32.Parse(strArr[i]);
                Assert.Equal(temp, _int32[i]);
            }
        }

        // ==========================================================================

        public static double Pow(double num, int power)
        {
            double val = 1;
            for (int pow = 0; pow < power; pow++)
            {
                val = val * num;
            }

            return val;
        }

        [TestMethod]
        public void ParseUInt32_Test_6()
        {
            Debug.WriteLine("UInt32 MinValue = " + UInt32.MinValue.ToString());
            Debug.WriteLine("UInt32 MaxValue = " + UInt32.MaxValue.ToString());

            Random random = new Random();
            String[] strArr = new String[] { "0", "-0","+0",
                                        "00000     ", "    -00000","   +00000  ",
                                        "   0   ", "  -00000  ",
                                        "+123", "  +123  ", "   +123", "+123    ",
                                        "","","","","","","","","",""};
            UInt32[] _uInt32 = new UInt32[] { 0, 0, 0, 0, 0, 0, 0, 0, 123, 123, 123, 123, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 12; i < _uInt32.Length; i++)
            {
                int power = random.Next(33);
                _uInt32[i] = (uint)(Pow(2, power) - 1);
                strArr[i] = _uInt32[i].ToString();
            }

            UInt32 temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = UInt32.Parse(strArr[i]);
                Assert.Equal(temp, _uInt32[i]);
            }
        }

        [TestMethod]
        public void ParseInt64_Test_7()
        {
            Debug.WriteLine("Int64 MinValue = " + Int64.MinValue.ToString());
            Debug.WriteLine("Int64 MaxValue = " + Int64.MaxValue.ToString());

            Random random = new Random();
            String[] strArr = new String[] { "0", "-0","+0",
                                        "00000     ", "    -00000","   +00000  ",
                                        "   0   ", "  -00000  ",
                                        "+123", "  +123  ", "   +123", "+123    ",
                                        "","","","","","","","","",""};
            Int64[] _int64 = new Int64[] { 0, 0, 0, 0, 0, 0, 0, 0, 123, 123, 123, 123, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 12; i < _int64.Length; i++)
            {
                int power = random.Next(64);
                if (i % 2 == 0)
                {
                    _int64[i] = (Int64)(-Pow(2, power) - 1);
                }
                else
                {
                    _int64[i] = (Int64)(Pow(2, power) - 1);
                }
                strArr[i] = _int64[i].ToString();
            }

            Int64 temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {

                temp = Int64.Parse(strArr[i]);
                Assert.Equal(temp, _int64[i]);
            }

            //Int32:  -2147483648 --> 2147483647
            CheckValues(Int32.MinValue);
            CheckValues(Int32.MaxValue);

            //UInt32: 0 ---> 4294967295
            CheckValues(UInt32.MinValue);
            CheckValues(UInt32.MaxValue);

            //Int64: -9223372036854775808  --> 9223372036854775807
            CheckValues(Int64.MinValue);
            CheckValues(Int64.MaxValue);

            //Uint64: 0 --> 18446744073709551615
            CheckValues((Int64)UInt64.MinValue);
        }


        private void CheckValues(Int64 start)
        {
            Int64 newVal = 0;
            string temp;
            for (Int64 i = start - 10; i < start + 10; i++)
            {
                temp = i.ToString();
                newVal = Int64.Parse(temp);
                Assert.Equal(i, newVal);
            }
        }

        [TestMethod]
        public void ParseUInt64_Test_8()
        {
            Debug.WriteLine("UInt64 MinValue = " + UInt64.MinValue.ToString());
            Debug.WriteLine("UInt64 MaxValue = " + UInt64.MaxValue.ToString());

            Random random = new Random();
            String[] strArr = new String[] { "0", "-0","+0",
                                        "00000     ", "    -00000","   +00000  ",
                                        "   0   ", "  -00000  ",
                                        "+123", "  +123  ", "   +123", "+123    ",
                                        "","","","","","","","","",""};
            UInt64[] _uInt64 = new UInt64[] { 0, 0, 0, 0, 0, 0, 0, 0, 123, 123, 123, 123, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 12; i < _uInt64.Length; i++)
            {
                int power = random.Next(65);
                _uInt64[i] = (UInt64)(Pow(2, power) - 1);
                strArr[i] = _uInt64[i].ToString();
            }

            UInt64 temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {

                temp = UInt64.Parse(strArr[i]);
                Assert.Equal(temp, _uInt64[i]);
            }

            //Int32:  -2147483648 --> 2147483647
            CheckUValues(Int32.MaxValue);

            //UInt32: 0 ---> 4294967295
            CheckUValues(UInt32.MinValue);
            CheckUValues(UInt32.MaxValue);

            //Int64: -9223372036854775808  --> 9223372036854775807
            CheckUValues(UInt64.MaxValue);

            //Uint64: 0 --> 18446744073709551615
            CheckUValues(UInt64.MinValue);
            CheckUValues(UInt64.MaxValue);
        }

        [TestMethod]
        public void ParseDouble_Test_Valid_Values()
        {

            Random random = new Random();
            String[] strArr = new String[] { "0", "-0","+0",
                                        "00000     ", "    -00000","   +00000  ",
                                        "   0   ", "  -00000  ",
                                        "+123", "  +123  ", "   +123", "+123    "};
            double[] _double = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 123, 123, 123, 123 };

            double temp;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = double.Parse(strArr[i]);
                Assert.Equal(temp, _double[i], $"Failed while parsing string: {strArr[i]} expecting: {_double[i].ToString()}");
            }

            double d = double.Parse("-0.1");
            Assert.Equal(d, -0.1);

            d = double.Parse("0.1");
            Assert.Equal(d, 0.1);

            d = double.Parse(" -1.1");
            Assert.Equal(d, -1.1);

            d = double.Parse(" -0.0001");
            Assert.Equal(d, -0.0001);

            d = double.Parse(" -10.0001");
            Assert.Equal(d, -10.0001);

            d = double.Parse("-0.01e-10");
            Assert.Equal(d, -0.01e-10);

            // can't use Min/MaxValue.ToString() because the fast float-to-string routine only works in the range 2^64 to 2^-64 (there-about).
            string t = "-1.7976931348623157E+308";  // double.MinValue
            Assert.Equal(double.MinValue, double.Parse(t), "Testing double min value parse");

            t = "1.7976931348623157E+308";
            Assert.Equal(double.MaxValue, double.Parse(t), "Testing double max value parse");

            t = "-3.40282347E+38";
            Assert.Equal(float.MinValue, (float)double.Parse(t), "Testing float min value parse");

            t = "3.40282347E+38";
            Assert.Equal(float.MaxValue, (float)double.Parse(t), "Testing float max value parse");

        }
        [TestMethod]
        public void ParseDouble_Test_Invalid_Values()
        {

            String[] strArr = new String[] { "", "   ", " ", "-0e-a", "+123a4", "   +123f.1", "123ea2", "1.111.1", 
                        "   -123-e3", " 123.456 777", "1234567ee73", "  +1234e-77+", "++1", "--1", "+1+", "   .1123abc", " .123+456",
                        "+123e++10", "+123e--10", "-123e++10"};

            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(FormatException), () => { double.Parse(strArr[i]); }, $"Should throw exception of type FormatExeception while parsing string: '{strArr[i]}'");
            }
        }

        [TestMethod]
        public void ParseDouble_OverflowTests()
        {
            // Note we have to check hex values - again, the ToString() works over a subset of the range for double/float, and returns 'oor' or '-oor' for anything outside that range
            string t = "-1.7976931348623180E+320";
            Assert.Equal(double.NegativeInfinity, double.Parse(t), "High negative values should return double.NegativeInfinity value when parsed");

            t = "1.7976931348623180E+308";
            Assert.Equal(double.PositiveInfinity, double.Parse(t), "High positive values should return double.PositiveInfinity value when parsed");

            t = "-3.40282380E+38";
            Assert.Equal(float.NegativeInfinity, float.Parse(t), "High negative values should return float.NegativeInfinity value when parsed");

            t = "3.40282380E+38";
            Assert.Equal(float.PositiveInfinity, float.Parse(t), "High positive values should return float.PositiveInfinity value when parsed");

        }

        private void CheckUValues(UInt64 start)
        {
            UInt64 newVal = 0;
            string temp;
            for (UInt64 i = start - 10; i < start + 10; i++)
            {
                temp = i.ToString();
                newVal = UInt64.Parse(temp);
                Assert.Equal(i, newVal);
            }
        }

        //=========================================================================================
        //        BoundaryTests


        [TestMethod]
        public void SByte_Boundary_Test_9()
        {

            String[] strArr = new String[] { SByte.MaxValue.ToString(), "127", SByte.MinValue.ToString(), "-128" };
            SByte[] _SByte = new SByte[] { 127, 127, -128, -128 };
            SByte temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = SByte.Parse(strArr[i]);
                Assert.Equal(temp, _SByte[i]);
            }
        }

        [TestMethod]
        public void Byte_Boundary_Test_10()
        {

            String[] strArr = new String[] { Byte.MaxValue.ToString(), "255", Byte.MinValue.ToString(), "0" };
            Byte[] _byte = new Byte[] { 255, 255, 0, 0 };
            Byte temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = Byte.Parse(strArr[i]);
                Assert.Equal(temp, _byte[i]);
            }
        }

        [TestMethod]
        public void Int16_Boundary_Test_11()
        {
            String[] strArr = new String[] { Int16.MaxValue.ToString(), "32767", Int16.MinValue.ToString(), "-32768" };
            Int16[] _int16 = new Int16[] { 32767, 32767, -32768, -32768 };
            Int16 temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = Int16.Parse(strArr[i]);
                Assert.Equal(temp, _int16[i]);
            }
        }

        [TestMethod]
        public void UInt16_Boundary_Test_12()
        {
            String[] strArr = new String[] { UInt16.MaxValue.ToString(), "65535", UInt16.MinValue.ToString(), "0" };
            UInt16[] _uInt16 = new UInt16[] { 65535, 65535, 0, 0 };
            UInt16 temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {

                temp = UInt16.Parse(strArr[i]);
                Assert.Equal(temp, _uInt16[i]);
            }
        }

        [TestMethod]
        public void Int32_Boundary_Test_13()
        {
            String[] strArr = new String[] { Int32.MaxValue.ToString(), "2147483647", Int32.MinValue.ToString(), "-2147483648" };
            Int32[] _int32 = new Int32[] { 2147483647, 2147483647, -2147483648, -2147483648 };
            Int32 temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = Int32.Parse(strArr[i]);
                Assert.Equal(temp, _int32[i]);
            }
        }

        [TestMethod]
        public void UInt32_Boundary_Test_14()
        {
            String[] strArr = new String[] { UInt32.MaxValue.ToString(), "4294967295", UInt32.MinValue.ToString(), "0" };
            UInt32[] _uInt32 = new UInt32[] { 4294967295, 4294967295, 0, 0 };
            UInt32 temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = UInt32.Parse(strArr[i]);
                Assert.Equal(temp, _uInt32[i]);
            }
        }

        [TestMethod]
        public void Int64_Boundary_Test_15()
        {
            String[] strArr = new String[] { Int64.MaxValue.ToString(), "9223372036854775807", Int64.MinValue.ToString(), "-9223372036854775808" };
            Int64[] _int64 = new Int64[] { 9223372036854775807, 9223372036854775807, -9223372036854775808, -9223372036854775808 };
            Int64 temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = Int64.Parse(strArr[i]);
                Assert.Equal(temp, _int64[i]);
            }
        }

        [TestMethod]
        public void UInt64_Boundary_Test_16()
        {
            String[] strArr = new String[] { UInt64.MaxValue.ToString(), "18446744073709551615", UInt64.MinValue.ToString(), "0" };
            UInt64[] _uInt64 = new UInt64[] { 18446744073709551615, 18446744073709551615, 0, 0 };
            UInt64 temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = UInt64.Parse(strArr[i]);
                Assert.Equal(temp, _uInt64[i]);
            }
        }

        //============================================================================
        //          ArgumentNullException tests

        public static string str = null;

        [TestMethod]
        public void SByte_ArgumentNullException_Test_17()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { SByte.Parse(str); });
        }

        [TestMethod]
        public void Byte_ArgumentNullException_Test_18()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { Byte.Parse(str); });
        }

        [TestMethod]
        public void Int16_ArgumentNullException_Test_19()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { Int16.Parse(str); });
        }

        [TestMethod]
        public void UInt16_ArgumentNullException_Test_20()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { UInt16.Parse(str); });
        }

        [TestMethod]
        public void Int32_ArgumentNullException_Test_21()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { Int32.Parse(str); });
        }

        [TestMethod]
        public void UInt32_ArgumentNullException_Test_22()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { UInt32.Parse(str); });
        }

        [TestMethod]
        public void Int64_ArgumentNullException_Test_23()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { Int64.Parse(str); });
        }

        [TestMethod]
        public void UInt64_ArgumentNullException_Test_24()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { UInt64.Parse(str); });
        }

        /// <summary>
        /// Used to generate random string of specified length and type
        /// </summary>
        /// <param name="length">An integer specifying the length on the random string</param>
        /// <param name="safe">A RandomType enum specifying random string type</param>
        /// <returns>random string</returns>
        private static string GetRandomString()
        {
            // Negative numbers indicate a random string length of 10-20 is desired.
            Random s_random = new Random();
            int length = 10 + s_random.Next(11);

            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                switch (s_random.Next(3))
                {
                    case 0:
                        // Get a random char between ascii 65 and 90 (upper case alphabets).
                        chars[i] = (char)(65 + s_random.Next(26));
                        break;
                    case 1:
                        // Get a random char between ascii 97 and 122 (lower case alphabets).
                        chars[i] = (char)(97 + s_random.Next(26));
                        break;
                    case 2:
                        // Get a random number 0 - 9
                        chars[i] = (char)('0' + s_random.Next(10));
                        break;
                }
            }

            return new string(chars);
        }

        //============================================================================
        //          FormatException tests

        [TestMethod]
        public void ParseSByte_FormatException_Test_25()
        {
            String[] strArr = new String[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(FormatException), () => { SByte.Parse(strArr[i]); });
            }
            for (int i = 0; i < 5; i++)
            {
                String rdmString = GetRandomString();
                Assert.Throws(typeof(FormatException), () => { SByte.Parse(rdmString); });
            }
        }

        [TestMethod]
        public void ParseByte_FormatException_Test_26()
        {
            String[] strArr = new String[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(FormatException), () => { Byte.Parse(strArr[i]); }, $"Value '{strArr[i]}' did not throw exception of type FormatException");
            }
            for (int i = 0; i < 5; i++)
            {
                String rdmString = GetRandomString();
                Assert.Throws(typeof(FormatException), () => { Byte.Parse(rdmString); }, $"Random string '{rdmString}' did not throw exception of FormatException");
            }
        }

        [TestMethod]
        public void ParseInt16_FormatException_Test_27()
        {
            String[] strArr = new String[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(FormatException), () => { Int16.Parse(strArr[i]); });
            }
            for (int i = 0; i < 5; i++)
            {
                String rdmString = GetRandomString();
                Assert.Throws(typeof(FormatException), () => { Int16.Parse(rdmString); });
            }
        }

        [TestMethod]
        public void ParseUInt16_FormatException_Test_28()
        {
            String[] strArr = new String[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(FormatException), () => { UInt16.Parse(strArr[i]); });
            }
            for (int i = 0; i < 5; i++)
            {
                String rdmString = GetRandomString();
                Assert.Throws(typeof(FormatException), () => { UInt16.Parse(rdmString); });
            }
        }

        [TestMethod]
        public void ParseInt32_FormatException_Test_29()
        {
            String[] strArr = new String[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(FormatException), () => { Int32.Parse(strArr[i]); });
            }
            for (int i = 0; i < 5; i++)
            {
                String rdmString = GetRandomString();
                Assert.Throws(typeof(FormatException), () => { Int32.Parse(rdmString); });
            }
        }

        [TestMethod]
        public void ParseUInt32_FormatException_Test_30()
        {
            String[] strArr = new String[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(FormatException), () => { UInt32.Parse(strArr[i]); });
            }
            for (int i = 0; i < 5; i++)
            {
                String rdmString = GetRandomString();
                Assert.Throws(typeof(FormatException), () => { UInt32.Parse(rdmString); });
            }
        }

        [TestMethod]
        public void ParseInt64_FormatException_Test_31()
        {
            String[] strArr = new String[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(FormatException), () => { Int64.Parse(strArr[i]); });
            }
            for (int i = 0; i < 5; i++)
            {
                String rdmString = GetRandomString();
                Assert.Throws(typeof(FormatException), () => { Int64.Parse(rdmString); });
            }
        }

        [TestMethod]
        public void ParseUInt64_FormatException_Test_32()
        {
            String[] strArr = new String[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(FormatException), () => { UInt64.Parse(strArr[i]); });
            }
            for (int i = 0; i < 5; i++)
            {
                String rdmString = GetRandomString();
                Assert.Throws(typeof(FormatException), () => { UInt64.Parse(rdmString); });
            }
        }


        //============================================================================
        //          OverflowException tests


        [TestMethod]
        public void ParseSByte_OverflowException_Test_33()
        {
            String[] strArr = new String[] { ((Int64)SByte.MinValue - 1).ToString(), ((Int64)SByte.MinValue - 100).ToString(),
                                             ((Int64)SByte.MaxValue + 1).ToString(), ((Int64)SByte.MaxValue + 100).ToString() };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => { SByte.Parse(strArr[i]); }, $"The value '{strArr[i]}' did not produce an exception type of ArgumentOutOfRange");
            }
        }

        [TestMethod]
        public void ParseByte_OverflowException_Test_34()
        {
            String[] strArr = new String[] { ((Int64)Byte.MinValue - 1).ToString(), ((Int64)Byte.MinValue - 100).ToString(),
                                             ((Int64)Byte.MaxValue + 1).ToString(), ((Int64)Byte.MaxValue + 100).ToString() };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => { Byte.Parse(strArr[i]); });
            }
        }

        [TestMethod]
        public void ParseInt16_OverflowException_Test_35()
        {
            String[] strArr = new String[] { ((Int64)Int16.MinValue - 1).ToString(), ((Int64)Int16.MinValue - 100).ToString(),
                                             ((Int64)Int16.MaxValue + 1).ToString(), ((Int64)Int16.MaxValue + 100).ToString() };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => { Int16.Parse(strArr[i]); });
            }
        }

        [TestMethod]
        public void ParseUInt16_OverflowException_Test_36()
        {
            String[] strArr = new String[] { ((Int64)UInt16.MinValue - 1).ToString(), ((Int64)UInt16.MinValue - 100).ToString(),
                                             ((Int64)UInt16.MaxValue + 1).ToString(), ((Int64)UInt16.MaxValue + 100).ToString() };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => { UInt16.Parse(strArr[i]); });
            }
        }

        [TestMethod]
        public void ParseInt32_OverflowException_Test_37()
        {
            String[] strArr = new String[] { ((Int64)Int32.MinValue - 1).ToString(), ((Int64)Int32.MinValue - 100).ToString(),
                                             ((Int64)Int32.MaxValue + 1).ToString(), ((Int64)Int32.MaxValue + 100).ToString() };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => { Int32.Parse(strArr[i]); });
            }
        }

        [TestMethod]
        public void ParseUInt32_OverflowException_Test_38()
        {
            String[] strArr = new String[] { ((Int64)UInt32.MinValue - 1).ToString(), ((Int64)UInt32.MinValue - 100).ToString(),
                                             ((Int64)UInt32.MaxValue + 1).ToString(), ((Int64)UInt32.MaxValue + 100).ToString() };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => { UInt32.Parse(strArr[i]); });
            }
        }

        [TestMethod]
        public void ParseInt64_OverflowException_Test_39()
        {

            string[] strArr = new string[] { "-9223372036854775809", "-9223372036854775900",
                                             "9223372036854775808", "9223372036854775900" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => { Int64.Parse(strArr[i]); }, $"An exception of type ArgumentOutOfRangeException was not thrown when values was {strArr[i]}");
            }
        }

        [TestMethod]
        public void ParseUInt64_OverflowException_Test_40()
        {
            string[] strArr = new string[] { "-1", "-100", "18446744073709551616", "18446744073709551700" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => { UInt64.Parse(strArr[i]); });
            }
        }


        [TestMethod]
        public void Cast_Double_to_int64_Test_40()
        {
            double dbVal = new Random().Next();

            // Convert to int and uint should keep the value
            long l_val = (long)dbVal;
            Assert.Equal(l_val, dbVal);

            ulong ul_val = (ulong)dbVal;
            Assert.Equal(ul_val, dbVal);

            // Change sign to negative
            dbVal = -dbVal;

            l_val = (long)dbVal;
            Assert.Equal(l_val, dbVal);

            ul_val = (ulong)dbVal;
            long ul_val_cast = (long)ul_val;
            Assert.Equal(ul_val_cast, dbVal);
        }


        public enum MyEnum : short { Value = 25 }
        public enum MyEnum1 { Value = 24 }
        public enum MyEnum2 : short { Value = 23 }

        class CastTestClass
        {

        }


        [TestMethod]
        public void box_unbox_Test_1()
        {
            // Creates objects for testing of different casts.
            object o_enum = MyEnum.Value;
            object o_enum1 = MyEnum1.Value;
            object o_long = 24L;
            object o_class = new CastTestClass();
            object o_guid = Guid.NewGuid();

            // Try casts that shoud succeed. Any exception here means failure.
            // First we try casts that should succeed. 
            // Casts between enums with the same basic type
            MyEnum2 e2 = (MyEnum2)o_enum; // line 2
                                          // Cast from enum to primitive type that enum is based on
            short sv = (short)o_enum;
            Assert.Equal(sv, (short)MyEnum.Value);

            // Cast from enum to primitive type that enum is based on
            int iv = (int)o_enum1;
            Assert.Equal(iv, (short)MyEnum1.Value);

            int i_long = (int)(long)o_long;
            CastTestClass cls = (CastTestClass)o_class;
            Guid guid = (Guid)o_guid;

            // Now casts that should throw exception. Any cast that does not throw - means error.
            Assert.Throws(typeof(InvalidCastException), () => {
                MyEnum1 e1 = (MyEnum1)o_enum;
            }, "Trying to cast incompatible enums - should throw InvalidCastException");

            // Now casts that should throw exception. Any cast that does not throw - means error.
            Assert.Throws(typeof(InvalidCastException), () => {
                int i = (int)o_long;
            }, "Trying to cast long to int - should throw InvalidCastException");

            // Now casts that should throw exception. Any cast that does not throw - means error.
            Assert.Throws(typeof(InvalidCastException), () => {
                int i = (int)o_class;
            }, "Trying to cast object to int - should throw InvalidCastException");

            // Now casts that should throw exception. Any cast that does not throw - means error.
            Assert.Throws(typeof(InvalidCastException), () => {
                int i = (int)o_enum;
            }, "Trying to cast enum to int - should throw InvalidCastException");

            // Now casts that should throw exception. Any cast that does not throw - means error.
            //Assert.Throws(typeof(InvalidCastException), () => {
            //    int i = (int)o_guid;
            //}, "Trying to cast Guid to int - should throw InvalidCastException");
            Assert.SkipTest("test of casting guid disabled");
        }

    }
}
