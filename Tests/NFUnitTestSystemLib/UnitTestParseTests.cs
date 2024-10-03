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
        private static int[] _intArr = new int[0];

        public static string[] GetRandomStringArray(int max, bool signed)
        {
            Random random = new Random();

            string[] arr1 = new string[] {
                "0",
                "-0",
                "+0",
                "00000     ",
                "    -00000",
                "   +00000  ",
                "   0   ",
                "  -00000  ",
                "+123",
                "  +123  ",
                "   +123",
                "+123    ",
                "56",
                "62",
                "100",
                "22"
            };

            string[] arr2 = new string[arr1.Length];

            _intArr = new int[] {
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                123,
                123,
                123,
                123,
                56,
                62,
                100,
                22,
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
                0,
                0,
                0,
                0,
                0,
                0
            };

            // sanity check for when the test arrays above change
            Assert.AreEqual(_intArr.Length, 2 * arr1.Length);

            for (int i = 0; i < arr2.Length; i++)
            {
                if (signed && ((i % 2) == 0))
                {
                    _intArr[i + arr1.Length] = -(random.Next(max));
                    arr2[i] = (_intArr[i + arr1.Length].ToString());
                }
                else
                {
                    _intArr[i + arr1.Length] = random.Next(max);
                    arr2[i] = _intArr[i + arr1.Length].ToString();
                }
            }

            string[] arr = new string[_intArr.Length];

            Array.Copy(arr1, arr, arr1.Length);
            Array.Copy(arr2, 0, arr, arr1.Length, arr2.Length);

            return arr;
        }

        [TestMethod]
        public void ParseSByte_Test_1()
        {
            OutputHelper.WriteLine("SByte MinValue = " + sbyte.MinValue.ToString());
            OutputHelper.WriteLine("SByte MaxValue = " + sbyte.MaxValue.ToString());

            string[] strArr = GetRandomStringArray(sbyte.MaxValue, true);
            sbyte[] _sByte = new sbyte[_intArr.Length];
            for (int i = 0; i < _sByte.Length; i++)
            {
                _sByte[i] = (sbyte)_intArr[i];
            }

            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.AreEqual(sbyte.Parse(strArr[i]), _sByte[i]);

                Assert.IsTrue(sbyte.TryParse(strArr[i], out sbyte result), $"TryParse failed for {strArr[i]} expecting: {_sByte[i]}");
                Assert.AreEqual(_sByte[i], result);
            }
        }

        [TestMethod]
        public void ParseByte_Test_2()
        {
            OutputHelper.WriteLine("Byte MinValue = " + byte.MinValue.ToString());
            OutputHelper.WriteLine("Byte MaxValue = " + byte.MaxValue.ToString());

            string[] strArr = GetRandomStringArray(byte.MaxValue, false);
            byte[] _byte = new byte[_intArr.Length];

            for (int i = 0; i < _byte.Length; i++)
            {
                _byte[i] = (byte)_intArr[i];
            }

            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.AreEqual(byte.Parse(strArr[i]), _byte[i], $"Parse failed for {strArr[i]}, expecting: {_byte[i]}");

                Assert.IsTrue(byte.TryParse(strArr[i], out byte result), $"TryParse failed for {strArr[i]} expecting: {_byte[i]}");
                Assert.AreEqual(_byte[i], result);
            }
        }

        [TestMethod]
        public void ParseInt16_Test_3()
        {
            OutputHelper.WriteLine("Int16 MinValue = " + short.MinValue.ToString());
            OutputHelper.WriteLine("Int16 MaxValue = " + short.MaxValue.ToString());

            string[] strArr = GetRandomStringArray(short.MaxValue, true);
            short[] _int16 = new short[_intArr.Length];
            for (int i = 0; i < _int16.Length; i++)
            {
                _int16[i] = (short)_intArr[i];
            }

            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.AreEqual(short.Parse(strArr[i]), _int16[i]);

                Assert.IsTrue(short.TryParse(strArr[i], out short result), $"TryParse failed for {strArr[i]} expecting: {_int16[i]}");
                Assert.AreEqual(_int16[i], result);
            }
        }

        [TestMethod]
        public void ParseUInt16_Test_4()
        {
            OutputHelper.WriteLine("UInt16 MinValue = " + ushort.MinValue.ToString());
            OutputHelper.WriteLine("UInt16 MaxValue = " + ushort.MaxValue.ToString());


            string[] strArr = GetRandomStringArray(ushort.MaxValue, false);
            ushort[] _uInt16 = new ushort[_intArr.Length];
            for (int i = 0; i < _uInt16.Length; i++)
            {
                _uInt16[i] = (ushort)_intArr[i];
            }

            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.IsTrue(ushort.TryParse(strArr[i], out ushort result), $"TryParse failed for {strArr[i]} expecting: {_uInt16[i]}");
                Assert.AreEqual(_uInt16[i], result);

                Assert.AreEqual(ushort.Parse(strArr[i]), _uInt16[i]);
            }
        }

        [TestMethod]
        public void ParseInt32_Test_5()
        {
            OutputHelper.WriteLine("Int32 MinValue = " + int.MinValue.ToString());
            OutputHelper.WriteLine("Int32 MaxValue = " + int.MaxValue.ToString());

            string[] strArr = GetRandomStringArray(int.MaxValue, true);
            int[] _int32 = new int[_intArr.Length];
            for (int i = 0; i < _int32.Length; i++)
            {
                _int32[i] = _intArr[i];
            }

            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.AreEqual(int.Parse(strArr[i]), _int32[i]);

                Assert.IsTrue(int.TryParse(strArr[i], out int result), $"TryParse failed for {strArr[i]} expecting: {_int32[i]}");
                Assert.AreEqual(_int32[i], result);
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
            OutputHelper.WriteLine("UInt32 MinValue = " + uint.MinValue.ToString());
            OutputHelper.WriteLine("UInt32 MaxValue = " + uint.MaxValue.ToString());

            Random random = new Random();
            string[] strArr = new string[] { "0", "-0","+0",
                                        "00000     ", "    -00000","   +00000  ",
                                        "   0   ", "  -00000  ",
                                        "+123", "  +123  ", "   +123", "+123    ",
                                        "","","","","","","","","",""};
            uint[] _uInt32 = new uint[] { 0, 0, 0, 0, 0, 0, 0, 0, 123, 123, 123, 123, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 12; i < _uInt32.Length; i++)
            {
                int power = random.Next(33);
                _uInt32[i] = (uint)(Pow(2, power) - 1);
                strArr[i] = _uInt32[i].ToString();
            }

            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.IsTrue(uint.TryParse(strArr[i], out uint result), $"TryParse failed for {strArr[i]} expecting: {_uInt32[i]}");
                Assert.AreEqual(_uInt32[i], result);

                Assert.AreEqual(uint.Parse(strArr[i]), _uInt32[i]);
            }
        }

        [TestMethod]
        public void ParseInt64_Test_7()
        {
            OutputHelper.WriteLine("Int64 MinValue = " + long.MinValue.ToString());
            OutputHelper.WriteLine("Int64 MaxValue = " + long.MaxValue.ToString());

            Random random = new Random();
            string[] strArr = new string[] { "0", "-0","+0",
                                        "00000     ", "    -00000","   +00000  ",
                                        "   0   ", "  -00000  ",
                                        "+123", "  +123  ", "   +123", "+123    ",
                                        "","","","","","","","","",""};
            long[] _int64 = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 123, 123, 123, 123, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 12; i < _int64.Length; i++)
            {
                int power = random.Next(64);
                if (i % 2 == 0)
                {
                    _int64[i] = (long)(-Pow(2, power) - 1);
                }
                else
                {
                    _int64[i] = (long)(Pow(2, power) - 1);
                }
                strArr[i] = _int64[i].ToString();
            }

            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.AreEqual(long.Parse(strArr[i]), _int64[i]);

                Assert.IsTrue(long.TryParse(strArr[i], out long result), $"TryParse failed for {strArr[i]} expecting: {_int64[i]}");
                Assert.AreEqual(_int64[i], result);
            }

            //Int32:  -2147483648 --> 2147483647
            CheckValues(int.MinValue);
            CheckValues(int.MaxValue);

            //UInt32: 0 ---> 4294967295
            CheckValues(uint.MinValue);
            CheckValues(uint.MaxValue);

            //Int64: -9223372036854775808  --> 9223372036854775807
            CheckValues(long.MinValue);
            CheckValues(long.MaxValue);

            //Uint64: 0 --> 18446744073709551615
            CheckValues((long)ulong.MinValue);
        }


        private void CheckValues(long start)
        {
            long newVal = 0;
            string temp;
            for (long i = start - 10; i < start + 10; i++)
            {
                temp = i.ToString();
                newVal = long.Parse(temp);
                Assert.AreEqual(i, newVal);
            }
        }

        [TestMethod]
        public void ParseUInt64_Test_8()
        {
            OutputHelper.WriteLine("UInt64 MinValue = " + ulong.MinValue.ToString());
            OutputHelper.WriteLine("UInt64 MaxValue = " + ulong.MaxValue.ToString());

            Random random = new Random();
            string[] strArr = new string[] { "0", "-0","+0",
                                        "00000     ", "    -00000","   +00000  ",
                                        "   0   ", "  -00000  ",
                                        "+123", "  +123  ", "   +123", "+123    ",
                                        "","","","","","","","","",""};
            ulong[] _uInt64 = new ulong[] { 0, 0, 0, 0, 0, 0, 0, 0, 123, 123, 123, 123, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 12; i < _uInt64.Length; i++)
            {
                int power = random.Next(65);
                _uInt64[i] = (ulong)(Pow(2, power) - 1);
                strArr[i] = _uInt64[i].ToString();
            }

            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.IsTrue(ulong.TryParse(strArr[i], out ulong result), $"TryParse failed for {strArr[i]} expecting: {_uInt64[i]}");
                Assert.AreEqual(_uInt64[i], result);

                result = ulong.Parse(strArr[i]);
                Assert.AreEqual(_uInt64[i], result);
            }

            //Int32:  -2147483648 --> 2147483647
            CheckUValues(int.MaxValue);

            //UInt32: 0 ---> 4294967295
            CheckUValues(uint.MinValue);
            CheckUValues(uint.MaxValue);

            //Int64: -9223372036854775808  --> 9223372036854775807
            CheckUValues(ulong.MaxValue);

            //Uint64: 0 --> 18446744073709551615
            CheckUValues(ulong.MinValue);
            CheckUValues(ulong.MaxValue);
        }

        [TestMethod]
        public void ParseDouble_Test_Valid_Values()
        {
            string[] strArr = new string[] {
                "0",
                "-0",
                "+0",
                "00000     ",
                "    -00000",
                "   +00000  ",
                "   0   ",
                "  -00000  ",
                "+123",
                "  +123  ",
                "   +123",
                "+123    ",
                "567.89",
                "-567.89",
                "1E23",
                "9007199254740997.0",
                "9007199254740997.00000000000000000000000000000000000000000000000000000",
                "5.005",
                "5.050",
                "50050.0",
                "0.005",
                "6250000000000000000000000000000000e-12",
                "6250000e0",
                "6250100e-5",
                "625010.00e-4",
                "62500e-4",
                "62500",
                "10e-3"
            };

            double[] _double = new double[] {
                0,
                double.Parse("-0"),
                double.Parse("+0"),
                0,
                double.Parse("-0"),
                0,
                0,
                double.Parse("-0"),
                123,
                123,
                123,
                123,
                567.89,
                -567.89,
                1E23,
                9007199254740997.0,
                9007199254740996.0,
                5.005,
                5.050,
                50050.0,
                0.005,
                6250000000000000000000000000000000e-12,
                6.25e6,
                62.501,
                62.501,
                6.25,
                62500,
                0.01
            };

            double result;
            for (int i = 0; i < strArr.Length; i++)
            {
                OutputHelper.WriteLine($"Parsing {strArr[i]} expecting: {_double[i]}");

                Assert.AreEqual(double.Parse(strArr[i]), _double[i], $"Failed while parsing string: {strArr[i]} expecting: {_double[i]}");

                Assert.IsTrue(double.TryParse(strArr[i], out result), $"TryParse failed for {strArr[i]} expecting: {_double[i]}");
                Assert.AreEqual(_double[i], result);
            }

            double d = double.Parse("-0.1");
            Assert.AreEqual(d, -0.1);

            Assert.IsTrue(double.TryParse("-0.1", out result), $"TryParse failed for -0.1 expecting: {d}");
            Assert.AreEqual(-0.1, result);

            d = double.Parse("0.1");
            Assert.AreEqual(d, 0.1);

            Assert.IsTrue(double.TryParse("0.1", out result), $"TryParse failed for 0.1 expecting: {d}");
            Assert.AreEqual(0.1, result);

            d = double.Parse(" -1.1");
            Assert.AreEqual(d, -1.1);

            Assert.IsTrue(double.TryParse(" -1.1", out result), $"TryParse failed for -1.1 expecting: {d}");
            Assert.AreEqual(-1.1, result);

            d = double.Parse(" -0.0001");
            Assert.AreEqual(d, -0.0001);

            Assert.IsTrue(double.TryParse(" -0.0001", out result), $"TryParse failed for -0.0001 expecting: {d}");
            Assert.AreEqual(-0.0001, result);

            d = double.Parse(" -10.0001");
            Assert.AreEqual(d, -10.0001);

            Assert.IsTrue(double.TryParse(" -10.0001", out result), $"TryParse failed for -10.0001 expecting: {d}");
            Assert.AreEqual(-10.0001, result);

            d = double.Parse("-0.01e-10");
            Assert.AreEqual(d, -0.01e-10);

            Assert.IsTrue(double.TryParse("-0.01e-10", out result), $"TryParse failed for -0.01e-10 expecting: {d}");
            Assert.AreEqual(-0.01e-10, result);

            // can't use Min/MaxValue.ToString() because the fast float-to-string routine only works in the range 2^64 to 2^-64 (there-about).
            string t = "-1.7976931348623157E+308";  // double.MinValue
            Assert.AreEqual(double.MinValue, double.Parse(t), "Testing double min value parse");

            t = "1.7976931348623157E+308";
            Assert.AreEqual(double.MaxValue, double.Parse(t), "Testing double max value parse");
        }

        [TestMethod]
        public void ParseDouble_Test_Invalid_Values()
        {
            string[] strArr = new string[] {
                "",
                "   ",
                " ",
                "-0e-a",
                "+123a4",
                "   +123f.1",
                "123ea2",
                "1.111.1",
                "   -123-e3",
                " 123.456 777",
                "1234567ee73",
                "  +1234e-77+",
                "++1",
                "--1",
                "+1+",
                "   .1123abc",
                " .123+456",
                "+123e++10",
                "+123e--10",
                "-123e++10"
            };

            for (int i = 0; i < strArr.Length; i++)
            {
                OutputHelper.WriteLine($"parse {strArr[i]}");

                Assert.ThrowsException(typeof(FormatException),
                              () => { double.Parse(strArr[i]); },
                              $"Should throw exception of type FormatExeception while parsing string: '{strArr[i]}'");

                Assert.IsFalse(double.TryParse(strArr[i], out double _), $"TryParse should return false while parsing string: '{strArr[i]}'");
            }
        }

        [TestMethod]
        public void ParseDouble_OverflowTests()
        {
            // Note we have to check hex values - again, the ToString() works over a subset of the range for double/float, and returns 'oor' or '-oor' for anything outside that range
            string t = "-1.7976931348623180E+320";
            Assert.AreEqual(double.NegativeInfinity, double.Parse(t), "High negative values should return double.NegativeInfinity value when parsed");

            t = "1.7976931348623180E+308";
            Assert.AreEqual(double.PositiveInfinity, double.Parse(t), "High positive values should return double.PositiveInfinity value when parsed");
        }

        [TestMethod]
        public void ParseFloat_Test_Valid_Values()
        {
            string[] strArr = new string[] {
                "0",
                "-0",
                "+0",
                "00000     ",
                "    -00000",
                "   +00000  ",
                "   0   ",
                "  -00000  ",
                "+123",
                "  +123  ",
                "   +123",
                "+123    ",
                "567.89",
                "-567.89",
                "1E23",
                "9007199254740997.0",
                "9007199254740997.00000000000000000000000000000000000000000000000000000",
                "5.005",
                "5.050",
                "50050.0",
                "0.005",
                "6250000000000000000000000000000000e-12",
                "6250000e0",
                "6250100e-5",
                "625010.00e-4",
                "62500e-4",
                "62500",
                "10e-3"
            };

            float[] _float = new float[] {
                0,
                float.Parse("-0"),
                float.Parse("+0"),
                0,
                float.Parse("-0"),
                0,
                0,
                float.Parse("-0"),
                123,
                123,
                123,
                123,
                567.89f,
                -567.89f,
                1E23f,
                9007199254740997.0f,
                9007199254740996.0f,
                5.005f,
                5.050f,
                50050.0f,
                0.005f,
                6250000000000000000000000000000000e-12f,
                6.25e6f,
                62.501f,
                62.501f,
                6.25f,
                62500,
                0.01f
            };

            float result;
            for (int i = 0; i < strArr.Length; i++)
            {
                OutputHelper.WriteLine($"Parsing {strArr[i]} expecting: {_float[i]}");

                Assert.AreEqual(float.Parse(strArr[i]), _float[i], $"Failed while parsing string: {strArr[i]} expecting: {_float[i]}");

                Assert.IsTrue(float.TryParse(strArr[i], out result), $"TryParse failed for {strArr[i]} expecting: {_float[i]}");
                Assert.AreEqual(_float[i], result);
            }

            float f = float.Parse("-0.1");
            Assert.AreEqual(f, -0.1f);

            Assert.IsTrue(float.TryParse("-0.1", out result), $"TryParse failed for -0.1 expecting: {f}");
            Assert.AreEqual(-0.1f, result);

            f = float.Parse("0.1");
            Assert.AreEqual(f, 0.1f);

            Assert.IsTrue(float.TryParse("0.1", out result), $"TryParse failed for 0.1 expecting: {f}");
            Assert.AreEqual(0.1f, result);

            f = float.Parse(" -1.1");
            Assert.AreEqual(f, -1.1f);

            Assert.IsTrue(float.TryParse(" -1.1", out result), $"TryParse failed for -1.1 expecting: {f}");
            Assert.AreEqual(-1.1f, result);

            f = float.Parse(" -0.0001");
            Assert.AreEqual(f, -0.0001f);

            Assert.IsTrue(float.TryParse(" -0.0001", out result), $"TryParse failed for -0.0001 expecting: {f}");
            Assert.AreEqual(-0.0001f, result);

            f = float.Parse(" -10.0001");
            Assert.AreEqual(f, -10.0001f);

            Assert.IsTrue(float.TryParse(" -10.0001", out result), $"TryParse failed for -10.0001 expecting: {f}");
            Assert.AreEqual(-10.0001f, result);

            f = float.Parse("-0.01e-10");
            Assert.AreEqual(f, -0.01e-10f);

            Assert.IsTrue(float.TryParse("-0.01e-10", out result), $"TryParse failed for -0.01e-10 expecting: {f}");
            Assert.AreEqual(-0.01e-10f, result);

            // can't use Min/MaxValue.ToString() because the fast float-to-string routine only works in the range 2^64 to 2^-64 (there-about).
            string t = "-3.40282347E+38";  // float.MinValue
            Assert.AreEqual(float.MinValue, float.Parse(t), "Testing float min value parse");

            t = "3.40282347E+38"; // float.MaxValue
            Assert.AreEqual(float.MaxValue, float.Parse(t), "Testing float max value parse");
        }

        [TestMethod]
        public void ParseFloat_Test_Invalid_Values()
        {
            string[] strArr = new string[] {
                "",
                "   ",
                " ",
                "-0e-a",
                "+123a4",
                "   +123f.1",
                "123ea2",
                "1.111.1",
                "   -123-e3",
                " 123.456 777",
                "1234567ee73",
                "  +1234e-77+",
                "++1",
                "--1",
                "+1+",
                "   .1123abc",
                " .123+456",
                "+123e++10",
                "+123e--10",
                "-123e++10"
            };

            for (int i = 0; i < strArr.Length; i++)
            {
                OutputHelper.WriteLine($"parse {strArr[i]}");

                Assert.ThrowsException(typeof(FormatException),
                              () => { float.Parse(strArr[i]); },
                              $"Should throw exception of type FormatExeception while parsing string: '{strArr[i]}'");

                Assert.IsFalse(float.TryParse(strArr[i], out float _), $"TryParse should return false while parsing string: '{strArr[i]}'");
            }
        }

        [TestMethod]
        public void ParseFloat_OverflowTests()
        {
            // Note we have to check hex values - again, the ToString() works over a subset of the range for double/float, and returns 'oor' or '-oor' for anything outside that range
            string t = "-3.40282380E+38";
            Assert.AreEqual(float.NegativeInfinity, float.Parse(t), "High negative values should return float.NegativeInfinity value when parsed");

            t = "3.40282380E+38";
            Assert.AreEqual(float.PositiveInfinity, float.Parse(t), "High positive values should return float.PositiveInfinity value when parsed");
        }

        private void CheckUValues(ulong start)
        {
            for (ulong i = start - 10; i < start + 10; i++)
            {
                ulong newVal = ulong.Parse(i.ToString());

                Assert.IsTrue(ulong.TryParse(i.ToString(), out ulong result), $"TryParse failed for {i.ToString()} expecting: {newVal}");
                Assert.AreEqual(newVal, result);

                Assert.AreEqual(i, newVal);
            }
        }

        //=========================================================================================
        //        BoundaryTests


        [TestMethod]
        public void SByte_Boundary_Test_9()
        {

            string[] strArr = new string[] { sbyte.MaxValue.ToString(), "127", sbyte.MinValue.ToString(), "-128" };
            sbyte[] _SByte = new sbyte[] { 127, 127, -128, -128 };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.AreEqual(sbyte.Parse(strArr[i]), _SByte[i]);

                Assert.IsTrue(sbyte.TryParse(strArr[i], out sbyte result), $"TryParse failed for {strArr[i]} expecting: {_SByte[i]}");
                Assert.AreEqual(_SByte[i], result);
            }
        }

        [TestMethod]
        public void Byte_Boundary_Test_10()
        {
            string[] strArr = new string[] { byte.MaxValue.ToString(), "255", byte.MinValue.ToString(), "0" };
            byte[] _byte = new byte[] { 255, 255, 0, 0 };

            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.AreEqual(byte.Parse(strArr[i]), _byte[i]);

                Assert.IsTrue(byte.TryParse(strArr[i], out byte result), $"TryParse failed for {strArr[i]} expecting: {_byte[i]}");
                Assert.AreEqual(_byte[i], result);
            }
        }

        [TestMethod]
        public void Int16_Boundary_Test_11()
        {
            string[] strArr = new string[] { short.MaxValue.ToString(), "32767", short.MinValue.ToString(), "-32768" };
            short[] _int16 = new short[] { 32767, 32767, -32768, -32768 };

            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.AreEqual(short.Parse(strArr[i]), _int16[i]);

                Assert.IsTrue(short.TryParse(strArr[i], out short result), $"TryParse failed for {strArr[i]} expecting: {_int16[i]}");
                Assert.AreEqual(_int16[i], result);
            }
        }

        [TestMethod]
        public void UInt16_Boundary_Test_12()
        {
            string[] strArr = new string[] { ushort.MaxValue.ToString(), "65535", ushort.MinValue.ToString(), "0" };
            ushort[] _uInt16 = new ushort[] { 65535, 65535, 0, 0 };

            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.IsTrue(ushort.TryParse(strArr[i], out ushort result), $"TryParse failed for {strArr[i]} expecting: {_uInt16[i]}");
                Assert.AreEqual(_uInt16[i], result);

                Assert.AreEqual(ushort.Parse(strArr[i]), _uInt16[i]);
            }
        }

        [TestMethod]
        public void Int32_Boundary_Test_13()
        {
            string[] strArr = new string[] { int.MaxValue.ToString(), "2147483647", int.MinValue.ToString(), "-2147483648" };
            int[] _int32 = new int[] { 2147483647, 2147483647, -2147483648, -2147483648 };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.AreEqual(int.Parse(strArr[i]), _int32[i]);

                Assert.IsTrue(int.TryParse(strArr[i], out int result), $"TryParse failed for {strArr[i]} expecting: {_int32[i]}");
                Assert.AreEqual(_int32[i], result);
            }
        }

        [TestMethod]
        public void UInt32_Boundary_Test_14()
        {
            string[] strArr = new string[] { uint.MaxValue.ToString(), "4294967295", uint.MinValue.ToString(), "0" };
            uint[] _uInt32 = new uint[] { 4294967295, 4294967295, 0, 0 };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.IsTrue(uint.TryParse(strArr[i], out uint result), $"TryParse failed for {strArr[i]} expecting: {_uInt32[i]}");
                Assert.AreEqual(_uInt32[i], result);

                Assert.AreEqual(uint.Parse(strArr[i]), _uInt32[i]);
            }
        }

        [TestMethod]
        public void Int64_Boundary_Test_15()
        {
            string[] strArr = new string[] { long.MaxValue.ToString(), "9223372036854775807", long.MinValue.ToString(), "-9223372036854775808" };
            long[] _int64 = new long[] { 9223372036854775807, 9223372036854775807, -9223372036854775808, -9223372036854775808 };
            long temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = long.Parse(strArr[i]);
                Assert.AreEqual(temp, _int64[i]);
            }
        }

        [TestMethod]
        public void UInt64_Boundary_Test_16()
        {
            string[] strArr = new string[] { ulong.MaxValue.ToString(), "18446744073709551615", ulong.MinValue.ToString(), "0" };
            ulong[] _uInt64 = new ulong[] { 18446744073709551615, 18446744073709551615, 0, 0 };
            ulong temp = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                temp = ulong.Parse(strArr[i]);
                Assert.AreEqual(temp, _uInt64[i]);
            }
        }

        //============================================================================
        //          ArgumentNullException tests

        public static string str = null;

        [TestMethod]
        public void SByte_ArgumentNullException_Test_17()
        {
            Assert.ThrowsException(typeof(ArgumentNullException), () => { sbyte.Parse(str); });
        }

        [TestMethod]
        public void SByte_TryParse_Test()
        {
            Assert.IsFalse(sbyte.TryParse(str, out sbyte _));
        }

        [TestMethod]
        public void Byte_ArgumentNullException_Test_18()
        {
            Assert.ThrowsException(typeof(ArgumentNullException), () => { byte.Parse(str); });
        }

        [TestMethod]
        public void Byte_TryParse_Test()
        {
            Assert.IsFalse(byte.TryParse(str, out byte _));
        }

        [TestMethod]
        public void Int16_ArgumentNullException_Test_19()
        {
            Assert.ThrowsException(typeof(ArgumentNullException), () => { short.Parse(str); });
        }

        [TestMethod]
        public void Int16_TryParse_Test()
        {
            Assert.IsFalse(short.TryParse(str, out short _));
        }

        [TestMethod]
        public void UInt16_ArgumentNullException_Test_20()
        {
            Assert.ThrowsException(typeof(ArgumentNullException), () => { ushort.Parse(str); });
        }

        [TestMethod]
        public void UInt16_TryParse_Test()
        {
            Assert.IsFalse(ushort.TryParse(str, out ushort _));
        }

        [TestMethod]
        public void Int32_ArgumentNullException_Test_21()
        {
            Assert.ThrowsException(typeof(ArgumentNullException), () => { int.Parse(str); });
        }

        [TestMethod]
        public void Int32_TryParse_Test()
        {
            Assert.IsFalse(int.TryParse(str, out int _));
        }

        [TestMethod]
        public void UInt32_ArgumentNullException_Test_22()
        {
            Assert.ThrowsException(typeof(ArgumentNullException), () => { uint.Parse(str); });
        }

        [TestMethod]
        public void UInt32_TryParse_Test()
        {
            Assert.IsFalse(uint.TryParse(str, out uint _));
        }

        [TestMethod]
        public void Int64_ArgumentNullException_Test_23()
        {
            Assert.ThrowsException(typeof(ArgumentNullException), () => { long.Parse(str); });
        }

        [TestMethod]
        public void Int64_TryParse_Test()
        {
            Assert.IsFalse(long.TryParse(str, out long _));
        }

        [TestMethod]
        public void UInt64_ArgumentNullException_Test_24()
        {
            Assert.ThrowsException(typeof(ArgumentNullException), () => { ulong.Parse(str); });
        }

        [TestMethod]
        public void UInt64_TryParse_Test()
        {
            Assert.IsFalse(ulong.TryParse(str, out ulong _));
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
            string[] strArr = new string[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(FormatException), () => { _ = sbyte.Parse(strArr[i]); });

                Assert.IsFalse(sbyte.TryParse(strArr[i], out _));
            }
            for (int i = 0; i < 5; i++)
            {
                string rdmString = GetRandomString();

                Assert.ThrowsException(typeof(FormatException), () => { _ = sbyte.Parse(rdmString); });

                Assert.IsFalse(sbyte.TryParse(rdmString, out _));
            }
        }

        [TestMethod]
        public void ParseByte_FormatException_Test_26()
        {
            string[] strArr = new string[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(FormatException), () => { _ = byte.Parse(strArr[i]); }, $"Value '{strArr[i]}' did not throw exception of type FormatException");

                Assert.IsFalse(byte.TryParse(strArr[i], out _));
            }

            for (int i = 0; i < 5; i++)
            {
                string rdmString = GetRandomString();

                Assert.ThrowsException(typeof(FormatException), () => { _ = byte.Parse(rdmString); }, $"Random string '{rdmString}' did not throw exception of FormatException");

                Assert.IsFalse(byte.TryParse(rdmString, out _));
            }
        }

        [TestMethod]
        public void ParseInt16_FormatException_Test_27()
        {
            string[] strArr = new string[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(FormatException), () => { _ = short.Parse(strArr[i]); });

                Assert.IsFalse(short.TryParse(strArr[i], out _));
            }
            for (int i = 0; i < 5; i++)
            {
                string rdmString = GetRandomString();

                Assert.ThrowsException(typeof(FormatException), () => { _ = short.Parse(rdmString); });

                Assert.IsFalse(short.TryParse(rdmString, out _));
            }
        }

        [TestMethod]
        public void ParseUInt16_FormatException_Test_28()
        {
            string[] strArr = new string[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(FormatException), () => { _ = ushort.Parse(strArr[i]); });

                Assert.IsFalse(ushort.TryParse(strArr[i], out _));
            }
            for (int i = 0; i < 5; i++)
            {
                string rdmString = GetRandomString();

                Assert.ThrowsException(typeof(FormatException), () => { _ = ushort.Parse(rdmString); });

                Assert.IsFalse(ushort.TryParse(rdmString, out _));
            }
        }

        [TestMethod]
        public void ParseInt32_FormatException_Test_29()
        {
            string[] strArr = new string[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(FormatException), () => { _ = int.Parse(strArr[i]); });

                Assert.IsFalse(int.TryParse(strArr[i], out _));
            }
            for (int i = 0; i < 5; i++)
            {
                string rdmString = GetRandomString();

                Assert.ThrowsException(typeof(FormatException), () => { _ = int.Parse(rdmString); });

                Assert.IsFalse(int.TryParse(rdmString, out _));
            }
        }

        [TestMethod]
        public void ParseUInt32_FormatException_Test_30()
        {
            string[] strArr = new string[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(FormatException), () => { _ = uint.Parse(strArr[i]); });

                Assert.IsFalse(uint.TryParse(strArr[i], out _));
            }
            for (int i = 0; i < 5; i++)
            {
                string rdmString = GetRandomString();

                Assert.ThrowsException(typeof(FormatException), () => { _ = uint.Parse(rdmString); });

                Assert.IsFalse(uint.TryParse(rdmString, out _));
            }
        }

        [TestMethod]
        public void ParseInt64_FormatException_Test_31()
        {
            string[] strArr = new string[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(FormatException), () => { _ = long.Parse(strArr[i]); });

                Assert.IsFalse(long.TryParse(strArr[i], out _));
            }
            for (int i = 0; i < 5; i++)
            {
                string rdmString = GetRandomString();

                Assert.ThrowsException(typeof(FormatException), () => { _ = long.Parse(rdmString); });

                Assert.IsFalse(long.TryParse(rdmString, out _));
            }
        }

        [TestMethod]
        public void ParseUInt64_FormatException_Test_32()
        {
            string[] strArr = new string[] { "", "1,234", "123e5", "a", "3.14159265358979" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(FormatException), () => { _ = ulong.Parse(strArr[i]); });

                Assert.IsFalse(ulong.TryParse(strArr[i], out _));
            }
            for (int i = 0; i < 5; i++)
            {
                string rdmString = GetRandomString();

                Assert.ThrowsException(typeof(FormatException), () => { _ = ulong.Parse(rdmString); });

                Assert.IsFalse(ulong.TryParse(rdmString, out _));
            }
        }


        //============================================================================
        //          OverflowException tests


        [TestMethod]
        public void ParseSByte_OverflowException_Test_33()
        {
            string[] strArr = new string[] { ((long)sbyte.MinValue - 1).ToString(), ((long)sbyte.MinValue - 100).ToString(),
                                             ((long)sbyte.MaxValue + 1).ToString(), ((long)sbyte.MaxValue + 100).ToString() };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { _ = sbyte.Parse(strArr[i]); }, $"The value '{strArr[i]}' did not produce an exception type of ArgumentOutOfRange");

                Assert.IsFalse(sbyte.TryParse(strArr[i], out _));
            }
        }

        [TestMethod]
        public void ParseByte_OverflowException_Test_34()
        {
            string[] strArr = new string[] { ((long)byte.MinValue - 1).ToString(), ((long)byte.MinValue - 100).ToString(),
                                             ((long)byte.MaxValue + 1).ToString(), ((long)byte.MaxValue + 100).ToString() };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { _ = byte.Parse(strArr[i]); });

                Assert.IsFalse(byte.TryParse(strArr[i], out _));
            }
        }

        [TestMethod]
        public void ParseInt16_OverflowException_Test_35()
        {
            string[] strArr = new string[] { ((long)short.MinValue - 1).ToString(), ((long)short.MinValue - 100).ToString(),
                                             ((long)short.MaxValue + 1).ToString(), ((long)short.MaxValue + 100).ToString() };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { _ = short.Parse(strArr[i]); });

                Assert.IsFalse(short.TryParse(strArr[i], out _));
            }
        }

        [TestMethod]
        public void ParseUInt16_OverflowException_Test_36()
        {
            string[] strArr = new string[] { ((long)ushort.MinValue - 1).ToString(), ((long)ushort.MinValue - 100).ToString(),
                                             ((long)ushort.MaxValue + 1).ToString(), ((long)ushort.MaxValue + 100).ToString() };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { _ = ushort.Parse(strArr[i]); });

                Assert.IsFalse(ushort.TryParse(strArr[i], out _));
            }
        }

        [TestMethod]
        public void ParseInt32_OverflowException_Test_37()
        {
            string[] strArr = new string[] { ((long)int.MinValue - 1).ToString(), ((long)int.MinValue - 100).ToString(),
                                             ((long)int.MaxValue + 1).ToString(), ((long)int.MaxValue + 100).ToString() };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { _ = int.Parse(strArr[i]); });

                Assert.IsFalse(int.TryParse(strArr[i], out _));
            }
        }

        [TestMethod]
        public void ParseUInt32_OverflowException_Test_38()
        {
            string[] strArr = new string[] { ((long)uint.MinValue - 1).ToString(), ((long)uint.MinValue - 100).ToString(),
                                             ((long)uint.MaxValue + 1).ToString(), ((long)uint.MaxValue + 100).ToString() };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { _ = uint.Parse(strArr[i]); });

                Assert.IsFalse(uint.TryParse(strArr[i], out _));
            }
        }

        [TestMethod]
        public void ParseInt64_OverflowException_Test_39()
        {

            string[] strArr = new string[] { "-9223372036854775809", "-9223372036854775900",
                                             "9223372036854775808", "9223372036854775900" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { _ = long.Parse(strArr[i]); }, $"An exception of type ArgumentOutOfRangeException was not thrown when values was {strArr[i]}");

                Assert.IsFalse(long.TryParse(strArr[i], out _));
            }
        }

        [TestMethod]
        public void ParseUInt64_OverflowException_Test_40()
        {
            string[] strArr = new string[] { "-1", "-100", "18446744073709551616", "18446744073709551700" };
            for (int i = 0; i < strArr.Length; i++)
            {
                Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { _ = ulong.Parse(strArr[i]); });

                Assert.IsFalse(ulong.TryParse(strArr[i], out _));
            }
        }

        [TestMethod]
        public void Cast_Double_to_int64_Test_40()
        {
            double dbVal = new Random().Next();

            // Convert to int and uint should keep the value
            long l_val = (long)dbVal;
            Assert.AreEqual(l_val, dbVal);

            ulong ul_val = (ulong)dbVal;
            Assert.AreEqual(ul_val, dbVal);

            // Change sign to negative
            dbVal = -dbVal;

            l_val = (long)dbVal;
            Assert.AreEqual(l_val, dbVal);

            ul_val = (ulong)dbVal;
            long ul_val_cast = (long)ul_val;
            Assert.AreEqual(ul_val_cast, dbVal);
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
            Assert.AreEqual(sv, (short)MyEnum.Value);

            // Cast from enum to primitive type that enum is based on
            int iv = (int)o_enum1;
            Assert.AreEqual(iv, (short)MyEnum1.Value);

            int i_long = (int)(long)o_long;
            CastTestClass cls = (CastTestClass)o_class;
            Guid guid = (Guid)o_guid;

            // Now casts that should throw exception. Any cast that does not throw - means error.
            Assert.ThrowsException(typeof(InvalidCastException), () =>
            {
                MyEnum1 e1 = (MyEnum1)o_enum;
            }, "Trying to cast incompatible enums - should throw InvalidCastException");

            // Now casts that should throw exception. Any cast that does not throw - means error.
            Assert.ThrowsException(typeof(InvalidCastException), () =>
            {
                int i = (int)o_long;
            }, "Trying to cast long to int - should throw InvalidCastException");

            // Now casts that should throw exception. Any cast that does not throw - means error.
            Assert.ThrowsException(typeof(InvalidCastException), () =>
            {
                int i = (int)o_class;
            }, "Trying to cast object to int - should throw InvalidCastException");

            // Now casts that should throw exception. Any cast that does not throw - means error.
            Assert.ThrowsException(typeof(InvalidCastException), () =>
            {
                int i = (int)o_enum;
            }, "Trying to cast enum to int - should throw InvalidCastException");

            // Now casts that should throw exception. Any cast that does not throw - means error.
            Assert.ThrowsException(typeof(InvalidCastException), () =>
            {
                int i = (int)o_guid;
            }, "Trying to cast Guid to int - should throw InvalidCastException");
        }
    }
}
