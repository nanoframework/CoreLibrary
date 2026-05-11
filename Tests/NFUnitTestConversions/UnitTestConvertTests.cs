// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestConversions
{
    [TestClass]
    class UnitTestConvertTests
    {
        [TestMethod]
        public void Cast_FloatingPoint()
        {
            uint u1;
            uint u2;
            double d1;
            float f1;
            long l1;
            long l2;
            double d2;
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                u1 = (uint)rand.Next();

                d1 = u1; // Does not work correctly (d1 is close to 0)
                u2 = (uint)d1;
                Assert.AreEqual(d1, u1);
                Assert.AreEqual(u2, u1);

                f1 = u1; // Same problem
                Assert.AreEqual(f1, u1);

                l1 = u1;
                u2 = (uint)l1;
                Assert.AreEqual(l1, u1);
                Assert.AreEqual(u2, u1);

                d2 = l1; // Same problem
                l2 = (long)d2;
                Assert.AreEqual(d2, l1);
                Assert.AreEqual(l2, l1);
            }
        }

        [TestMethod]
        public void Convert_Positive()
        {
            string number = "12";
            sbyte value_sb = Convert.ToSByte(number);
            Assert.AreEqual(value_sb, (byte)12);
            byte value_b = Convert.ToByte(number);
            Assert.AreEqual(value_b, (byte)12);
            short value_s16 = Convert.ToInt16(number);
            Assert.AreEqual(value_s16, (short)12);
            ushort value_u16 = Convert.ToUInt16(number);
            Assert.AreEqual(value_u16, (ushort)12);
            int value_s32 = Convert.ToInt32(number);
            Assert.AreEqual(value_s32, 12);
            uint value_u32 = Convert.ToUInt32(number);
            Assert.AreEqual(value_u32, 12);
            long value_s64 = Convert.ToInt32(number);
            Assert.AreEqual(value_s64, 12);
            ulong value_u64 = Convert.ToUInt64(number);
            Assert.AreEqual(value_u64, 12);
        }

        [TestMethod]
        public void Convert_PositivePlus()
        {
            string number = "+12";
            sbyte value_sb = Convert.ToSByte(number);
            Assert.AreEqual(value_sb, (byte)12);
            byte value_b = Convert.ToByte(number);
            Assert.AreEqual(value_b, (byte)12);
            short value_s16 = Convert.ToInt16(number);
            Assert.AreEqual(value_s16, (short)12);
            ushort value_u16 = Convert.ToUInt16(number);
            Assert.AreEqual(value_u16, (ushort)12);
            int value_s32 = Convert.ToInt32(number);
            Assert.AreEqual(value_s32, 12);
            uint value_u32 = Convert.ToUInt32(number);
            Assert.AreEqual(value_u32, 12);
            long value_s64 = Convert.ToInt32(number);
            Assert.AreEqual(value_s64, 12);
            ulong value_u64 = Convert.ToUInt64(number);
            Assert.AreEqual(value_u64, 12);
        }


        [TestMethod]
        public void Convert_Negative()
        {
            string number = "-12";
            int actualNumber = -12;
            sbyte value_sb = Convert.ToSByte(number);
            Assert.AreEqual(value_sb, (sbyte)actualNumber);
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { Convert.ToByte(number); });
            short value_s16 = Convert.ToInt16(number);
            Assert.AreEqual(value_s16, (short)actualNumber);
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { Convert.ToUInt16(number); });
            int value_s32 = Convert.ToInt32(number);
            Assert.AreEqual(value_s32, actualNumber);
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { Convert.ToUInt32(number); });
            long value_s64 = Convert.ToInt32(number);
            Assert.AreEqual(value_s64, actualNumber);
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { Convert.ToUInt64(number); });
        }

        [TestMethod]
        public void Convert_Double()
        {
            string number = "36.123456";
            double actualNumber = 36.123456;

            double value_dd = Convert.ToDouble(number);
            Assert.AreEqual(value_dd, actualNumber);

            Assert.AreEqual(-129, Convert.ToDouble("-129"));  // can't handle not having a decimal point!
            Assert.AreEqual(-123.456, Convert.ToDouble("-123.456"));
        }

        [TestMethod]
        public void Convert_Plus()
        {
            string number = "+36.123456";
            double actualNumber = 36.123456;

            double value_dd = Convert.ToDouble(number);
            Assert.AreEqual(value_dd, actualNumber);
            Assert.AreEqual(0, Convert.ToDouble("+0"), "The string +0 did not parse to 0 for Double");
        }

        [TestMethod]
        public void Convert_Neg()
        {
            string number = "-36.123456";
            double actualNumber = -36.123456;

            double value_dd = Convert.ToDouble(number);

            Assert.AreEqual(value_dd, actualNumber);

            // need to use this hack to be able to compare negative zero
            var negativeZero = Convert.ToDouble("-0");
            Assert.AreEqual(negativeZero, Convert.ToDouble("-0"), "The string -0 did not parse to 0 for Double");
        }

        [TestMethod]
        public void Convert_Whitespace()
        {
            string intnum = " -3484  ";
            string number = " +36.123456   ";
            long actualInt = -3484;
            double actualNumber = 36.123456;

            Assert.AreEqual(actualInt, Convert.ToInt16(intnum));
            Assert.AreEqual(actualInt, Convert.ToInt32(intnum));
            Assert.AreEqual(actualInt, Convert.ToInt64(intnum));
            double value_dd = Convert.ToDouble(number);
            Assert.AreEqual(value_dd, actualNumber);
        }

        [TestMethod]
        public void Convert_DoubleNormalizeNeg()
        {
            string number = "-3600030383448481.123456";
            double actualNumber = -3600030383448481.123456;  // note: this is the double as calculated by the Roslyn compiler - not the same as the native code routine

            double value_dd = Convert.ToDouble(number);

            Assert.AreEqual(value_dd, actualNumber, $"Convert.ToDouble should be {number}");  // this works if the numbers are fairly small - i.e. not e^x sized

            // Examples of how we can get differences due to differences between the compiler parser, and the native parser
            // And differences caused by the native parsers "fast speed" causing rounding errors
            string num1 = "+0.000000004848747585e-3";
            string num2 = "4.848747585e-12";  // same number as above, but we've moved the digits over a bit and adjusted the exponent
            double dnum1Roslyn = +0.000000004848747585e-3;  // Roslyn compiler will parse the value and put it into the double at compile time
            double dnum1Native = Convert.ToDouble(num1);    // Native code will parse the value and put it into the double at run time
            double dnum2Roslyn = 4.848747585e-12;           // Compiler 
            double dnum2Native = Convert.ToDouble(num2);    // Native


            // Now we will compare some of the ToString values
            // compare native to native - but parsing e-3 versus e-12 means 9 more loops thru the double multiplication where rounding can occur so this won't work for all numbers
            Assert.AreEqual(dnum1Native.ToString(), dnum2Native.ToString(), $"Comparing native parse tostring");
            // compare roslyn to roslyn - the roslyn parser is more accurate and that means the double is much more likely to be the same
            Assert.AreEqual(dnum1Roslyn.ToString(), dnum2Roslyn.ToString(), $"Comparing Roslyn parse tostring");
            // Now mix things up
            Assert.AreEqual(dnum1Roslyn.ToString(), dnum2Native.ToString(), $"Comparing Roslyn parse and native parse tostring");
            Assert.AreEqual(dnum1Native.ToString(), dnum2Roslyn.ToString(), $"Comparing Roslyn parse and native parse tostring");
            Assert.AreEqual(dnum1Roslyn.ToString(), dnum1Native.ToString(), $"Comparing Roslyn to native using {num1}");
            Assert.AreEqual(dnum2Roslyn.ToString(), dnum2Native.ToString(), $"Comparing Roslyn to natvie using {num2}");
        }

        [TestMethod]
        public void Convert_HexInt()
        {
            string number = "0x01234567";
            int actualNumber = 0x01234567;

            int value = Convert.ToInt32(number, 16);

            Assert.AreEqual(value, actualNumber);
            number = "0x89abcdef";
            unchecked
            {
                actualNumber = (int)0x89abcdef;
            }
            Assert.AreEqual(actualNumber, Convert.ToInt32(number, 16));
            number = "0x0AbF83C";
            actualNumber = 0xAbF83C;

            Assert.AreEqual(actualNumber, Convert.ToInt32(number, 16));
        }

        [TestMethod]

        public void Convert_BoundaryValues()
        {
            const string OUT_OF_RANGE = "1.7976931348623157E+308";
            const string OUT_OF_RANGE_NEG = "-1.7976931348623157E+308";

            const string DOUBLE_MAX_VAL = "1.7976931348623157E+308";
            const string DOUBLE_MAX_HEX = "0x7FEFFFFFFFFFFFFF";       // value from IEEE 574
            const string DOUBLE_MIN_VAL = "-1.7976931348623157E+308";
            const string DOUBLE_MIN_HEX = "0xFFEFFFFFFFFFFFFF";       // value from IEEE 574
            const string DOUBLE_ZERO_HEX = "0x0000000000000000";

            const string FLOAT_MAX_VAL = "3.40282347E+38";
            const string FLOAT_MAX_HEX = "0x7F7FFFFF";
            const string FLOAT_MIN_VAL = "-3.40282347E+38";
            const string FLOAT_MIN_HEX = "0xFF7FFFFF";
            const string FLOAT_ZERO_HEX = "0x00000000";

            // boundary: double max
            double doubleMax = double.MaxValue;
            Assert.AreEqual(OUT_OF_RANGE, doubleMax.ToString(), "double.MaxValue value failed");
            Assert.AreEqual(DOUBLE_MAX_HEX, DoubleToHex(doubleMax), "Hex value to double max value does not match");
            Assert.AreEqual(DOUBLE_MAX_HEX, DoubleToHex(Convert.ToDouble(DOUBLE_MAX_VAL)), "Parsing double max value does not return correct hex value");

            doubleMax = Convert.ToDouble(DOUBLE_MAX_VAL);
            Assert.AreEqual(doubleMax.ToString(), OUT_OF_RANGE, "Double.ToString did not return 'oor' for first out-of-range value");

            // boundary: double min
            double doubleMin = double.MinValue;
            Assert.AreEqual(OUT_OF_RANGE_NEG, doubleMin.ToString());
            Assert.AreEqual(DOUBLE_MIN_HEX, DoubleToHex(doubleMin), "Hex value to double min value does not match");
            Assert.AreEqual(DOUBLE_MIN_HEX, DoubleToHex(Convert.ToDouble(DOUBLE_MIN_VAL)), "Parsing double min value does not return correct hex value");

            doubleMin = Convert.ToDouble(DOUBLE_MIN_VAL);
            Assert.AreEqual(doubleMin.ToString(), doubleMin.ToString(), "Double.ToString did not return the correct value for smallest in range value");

            // boundary: double zero
            double doubleZero = 0;   // test that zero gets a zero exponent and a value like 1023 the exponent bias used in floating point math
            Assert.AreEqual(doubleZero.ToString(), "0", "ToString of a double with zero value formats incorrectly");
            Assert.AreEqual(DOUBLE_ZERO_HEX, DoubleToHex(doubleZero), "Double with zero value returns the wrong hex value");

            // boundary: float max
            float floatMax = float.MaxValue;
            Assert.AreEqual(FLOAT_MAX_VAL, floatMax.ToString(), "floatMax.ToString()");
            Assert.AreEqual(FLOAT_MAX_HEX, FloatToHex(floatMax), "Hex value to float max values does not match");
            Assert.AreEqual(FLOAT_MAX_HEX, FloatToHex((float)Convert.ToDouble(FLOAT_MAX_VAL)), "Parsing float max value does not return correct hex value");

            floatMax = Convert.ToSingle(FLOAT_MAX_VAL);
            Assert.AreEqual(FLOAT_MAX_VAL, floatMax.ToString(), "floatOutRange.ToString() did not return 'oor' for first out-of-range value");

            // boundary: float min
            float floatMin = float.MinValue;
            Assert.AreEqual(FLOAT_MIN_VAL, floatMin.ToString(), "floatMin.ToString()");
            Assert.AreEqual(FLOAT_MIN_HEX, FloatToHex(floatMin), "Hex value to double min value does not match");
            Assert.AreEqual(FLOAT_MIN_HEX, FloatToHex((float)Convert.ToDouble(FLOAT_MIN_VAL)), "Parsing float min value does not return correct hex value");

            floatMin = Convert.ToSingle(FLOAT_MIN_VAL);
            Assert.AreEqual(FLOAT_MIN_VAL, floatMin.ToString(), "Float.ToString did not return 'oor' for smallest out-of-range value");

            //boundary: float zero
            float floatZero = 0;   // test that zero gets a zero exponent and not a value like 1023 the exponent bias used in floating point math
            Assert.AreEqual("0", floatZero.ToString(), "ToString of a string with zero value formats incorrectly");
            Assert.AreEqual(FLOAT_ZERO_HEX, FloatToHex(floatZero), "Float with zero value returns the wrong hex value");

            long lMax = long.MaxValue;
            string numMax = lMax.ToString();
            long lMin = long.MinValue;
            string numMin = lMin.ToString();

            Assert.AreEqual(lMax, Convert.ToInt64(numMax), "Int64 Max");
            Assert.AreEqual(lMin, Convert.ToInt64(numMin), "Int64 Min");

            ulong ulMax = ulong.MaxValue;
            numMax = ulMax.ToString();
            ulong ulMin = ulong.MinValue;
            numMin = ulMin.ToString();

            Assert.AreEqual(ulMax, Convert.ToUInt64(numMax), "UInt64 Max");
            Assert.AreEqual(ulMin, Convert.ToUInt64(numMin), "UInt64 Min");

            long iMax = int.MaxValue;
            numMax = iMax.ToString();
            long iMin = int.MinValue;
            numMin = iMin.ToString();

            Assert.AreEqual(iMax, Convert.ToInt32(numMax), "Int32 Max");
            Assert.AreEqual(iMin, Convert.ToInt32(numMin), "Int32 Min");

            uint uiMax = uint.MaxValue;
            numMax = uiMax.ToString();
            uint uiMin = uint.MinValue;
            numMin = uiMin.ToString();

            Assert.AreEqual(uiMax, Convert.ToUInt32(numMax));
            Assert.AreEqual(uiMin, Convert.ToUInt32(numMin));

            short sMax = short.MaxValue;
            numMax = sMax.ToString();
            short sMin = short.MinValue;
            numMin = sMin.ToString();

            Assert.AreEqual(sMax, Convert.ToInt16(numMax));
            Assert.AreEqual(sMin, Convert.ToInt16(numMin));

            ushort usMax = ushort.MaxValue;
            numMax = usMax.ToString();
            ushort usMin = ushort.MinValue;
            numMin = usMin.ToString();

            Assert.AreEqual(usMax, Convert.ToUInt16(numMax));
            Assert.AreEqual(usMin, Convert.ToUInt16(numMin));

            sbyte sbMax = sbyte.MaxValue;
            numMax = sbMax.ToString();
            sbyte sbMin = sbyte.MinValue;
            numMin = sbMin.ToString();

            sbMax = Convert.ToSByte(numMax);

            sbMin = Convert.ToSByte(numMin);

            Assert.AreEqual(sbMax, Convert.ToSByte(numMax));
            Assert.AreEqual(sbMin, Convert.ToSByte(numMin));

            byte bMax = byte.MaxValue;
            numMax = bMax.ToString();
            byte bMin = byte.MinValue;
            numMin = bMin.ToString();

            Assert.AreEqual(bMax, Convert.ToByte(numMax));
            Assert.AreEqual(bMin, Convert.ToByte(numMin));

        }


        [TestMethod]
        public void Convert_LeadingZeroValues()
        {
            string number = "00000000";

            Assert.AreEqual((short)0, Convert.ToInt16(number));
            Assert.AreEqual(0, Convert.ToInt32(number));
            Assert.AreEqual(0, Convert.ToInt64(number));

            number = "+00000000000";

            Assert.AreEqual((short)0, Convert.ToInt16(number));
            Assert.AreEqual(0, Convert.ToInt32(number));
            Assert.AreEqual(0, Convert.ToInt64(number));

            number = "-00000000000";

            Assert.AreEqual((short)0, Convert.ToInt16(number));
            Assert.AreEqual(0, Convert.ToInt32(number));
            Assert.AreEqual(0, Convert.ToInt64(number));
        }

        [TestMethod]
        public void Convert_LeadingZeros()
        {
            string number = "000003984";
            int actualNumber = 3984;

            Assert.AreEqual((short)actualNumber, Convert.ToInt16(number));
            Assert.AreEqual(actualNumber, Convert.ToInt32(number));
            Assert.AreEqual(actualNumber, Convert.ToInt64(number));
            number = "-00000003489";
            actualNumber = -3489;

            Assert.AreEqual((short)actualNumber, Convert.ToInt16(number));
            Assert.AreEqual(actualNumber, Convert.ToInt32(number));
            Assert.AreEqual(actualNumber, Convert.ToInt64(number));
            number = "+00000003489";
            actualNumber = 3489;

            Assert.AreEqual((short)actualNumber, Convert.ToInt16(number));
            Assert.AreEqual(actualNumber, Convert.ToInt32(number));
            Assert.AreEqual(actualNumber, Convert.ToInt64(number));

            number = "+000000043984.00048850000";
            double numD = 4.39840004885;

            Assert.AreNotEqual(numD, Convert.ToDouble(number));
            number = "-000000043984.00048850000";
            numD = -4.39840004885;

            Assert.AreNotEqual(numD, Convert.ToDouble(number));
            number = "000000043984.000488500e-006";
            numD = 4.39840004885e2;

            Assert.AreNotEqual(numD, Convert.ToDouble(number));
        }

        [TestMethod]
        public void Convert_64ParsePerf()
        {
            string number = "-7446744073709551615";
            long val = 0;

            DateTime start = DateTime.UtcNow;
            for (int i = 0; i < 0x1000; i++)
            {
                val = Convert.ToInt64(number);
            }
            OutputHelper.WriteLine("Time: " + (DateTime.UtcNow - start).ToString());

            Assert.AreEqual(val, -7446744073709551615L);
        }

        [TestMethod]
        public void Convert_FromBoolean()
        {
            bool iamTrue = true;
            bool iamFalse = false;

            byte convTrueIsOne = Convert.ToByte(iamTrue);
            byte convFalseIsZero = Convert.ToByte(iamFalse);

            Assert.AreEqual(convTrueIsOne, (byte)1);
            Assert.AreEqual(convFalseIsZero, (byte)0);
        }

        [TestMethod]
        public void Cast_UnsignedToDouble()
        {
            // Regression test for https://github.com/nanoframework/Home/issues/1730
            // Conversion from an unsigned integer expression to double should produce
            // the correct (unsigned) result even when no intermediate uint local is used.

            ushort[] us = { 0x0000, 0x8000 };

            // DecodeNumber1: converts the expression directly to double (no intermediate uint local)
            double d1 = DecodeNumber1(us);

            // DecodeNumber2: stores in a uint local first, then converts to double
            double d2 = DecodeNumber2(us);

            Assert.AreEqual(2147483648d, d1, "Direct cast of (uint expression) to double should be 2147483648, not -2147483648");
            Assert.AreEqual(2147483648d, d2, "Indirect cast via uint local to double should be 2147483648");
            Assert.AreEqual(d2, d1, "Direct and indirect unsigned-to-double conversions should produce equal results");

            // Additional values with the high bit set in the uint range
            us = new ushort[] { 0xFFFF, 0xFFFF };
            d1 = DecodeNumber1(us);
            d2 = DecodeNumber2(us);
            Assert.AreEqual(d2, d1, "Direct and indirect unsigned-to-double conversions should be equal for 0xFFFFFFFF");

            us = new ushort[] { 0x1234, 0x8765 };
            d1 = DecodeNumber1(us);
            d2 = DecodeNumber2(us);
            Assert.AreEqual(d2, d1, "Direct and indirect unsigned-to-double conversions should be equal for 0x87651234");

            // Values without the high bit set should also be equal
            us = new ushort[] { 0xABCD, 0x1234 };
            d1 = DecodeNumber1(us);
            d2 = DecodeNumber2(us);
            Assert.AreEqual(d2, d1, "Direct and indirect unsigned-to-double conversions should be equal for 0x1234ABCD");
        }

        [TestMethod]
        public void Cast_UIntToFloat()
        {
            // Regression test for https://github.com/nanoframework/Home/issues/1730
            // Conversion from a uint expression (I4 on stack) to float via conv.r.un + conv.r4
            // must produce the unsigned result even when no intermediate uint local is used.

            ushort[] us = { 0x0000, 0x8000 }; // 0x80000000 = 2147483648u

            float f1 = DecodeNumberToFloat1(us); // direct cast of expression
            float f2 = DecodeNumberToFloat2(us); // via uint local

            Assert.AreEqual(2147483648f, f1, "Direct cast of (uint expression) to float should be 2147483648, not -2147483648");
            Assert.AreEqual(2147483648f, f2, "Indirect cast via uint local to float should be 2147483648");
            Assert.AreEqual(f2, f1, "Direct and indirect uint-to-float conversions should produce equal results");

            us = new ushort[] { 0xFFFF, 0xFFFF }; // 0xFFFFFFFF = 4294967295u
            f1 = DecodeNumberToFloat1(us);
            f2 = DecodeNumberToFloat2(us);
            Assert.AreEqual(f2, f1, "Direct and indirect uint-to-float should be equal for 0xFFFFFFFF");

            us = new ushort[] { 0x1234, 0x8765 }; // 0x87651234, high bit set
            f1 = DecodeNumberToFloat1(us);
            f2 = DecodeNumberToFloat2(us);
            Assert.AreEqual(f2, f1, "Direct and indirect uint-to-float should be equal for 0x87651234");

            us = new ushort[] { 0xABCD, 0x1234 }; // 0x1234ABCD, high bit clear
            f1 = DecodeNumberToFloat1(us);
            f2 = DecodeNumberToFloat2(us);
            Assert.AreEqual(f2, f1, "Direct and indirect uint-to-float should be equal for 0x1234ABCD");
        }

        [TestMethod]
        public void Cast_ULongToDouble()
        {
            // Regression test for https://github.com/nanoframework/Home/issues/1730
            // ulong arithmetic results land on the eval stack as I8 (signed).
            // conv.r.un must treat the I8 bits as unsigned; before the fix the
            // interpreter ignored the fUnsigned flag and produced a negative double.

            uint[] ui = { 0x00000000, 0x80000000 }; // 0x8000000000000000 = 9223372036854775808uL

            double d1 = DecodeULong1(ui);  // expression result (I8) → conv.r.un: was broken
            double d2 = DecodeULong2(ui);  // via ulong local (U8) → conv.r.un: was correct

            Assert.AreEqual(9223372036854775808d, d1, "Direct cast of (ulong expression) to double should be 9223372036854775808, not negative");
            Assert.AreEqual(9223372036854775808d, d2, "Indirect cast via ulong local to double should be 9223372036854775808");
            Assert.AreEqual(d2, d1, "Direct and indirect ulong-to-double conversions should produce equal results");

            ui = new uint[] { 0xFFFFFFFF, 0xFFFFFFFF }; // ulong.MaxValue = 18446744073709551615
            d1 = DecodeULong1(ui);
            d2 = DecodeULong2(ui);
            Assert.AreEqual(18446744073709551615d, d1, "Direct cast of ulong.MaxValue expression to double should be 18446744073709551615");
            Assert.AreEqual(d2, d1, "Direct and indirect ulong-to-double should be equal for ulong.MaxValue");

            ui = new uint[] { 0x12345678, 0x87654321 }; // 0x8765432112345678, high bit set
            d1 = DecodeULong1(ui);
            d2 = DecodeULong2(ui);
            Assert.AreEqual(d2, d1, "Direct and indirect ulong-to-double should be equal for 0x8765432112345678");

            ui = new uint[] { 0x12345678, 0x01234567 }; // 0x0123456712345678, high bit clear
            d1 = DecodeULong1(ui);
            d2 = DecodeULong2(ui);
            Assert.AreEqual(d2, d1, "Direct and indirect ulong-to-double should be equal for 0x0123456712345678");
        }

        [TestMethod]
        public void Cast_ULongToFloat()
        {
            // Regression test for https://github.com/nanoframework/Home/issues/1730
            // Same sign-interpretation bug as Cast_ULongToDouble but for float (conv.r.un + conv.r4).

            uint[] ui = { 0x00000000, 0x80000000 }; // 0x8000000000000000 = 9223372036854775808uL

            float f1 = DecodeULong1Float(ui);  // expression result (I8) → conv.r.un: was broken
            float f2 = DecodeULong2Float(ui);  // via ulong local (U8) → conv.r.un: was correct

            Assert.AreEqual(9223372036854775808f, f1, "Direct cast of (ulong expression) to float should be 9223372036854775808, not negative");
            Assert.AreEqual(9223372036854775808f, f2, "Indirect cast via ulong local to float should be 9223372036854775808");
            Assert.AreEqual(f2, f1, "Direct and indirect ulong-to-float conversions should produce equal results");

            ui = new uint[] { 0xFFFFFFFF, 0xFFFFFFFF }; // ulong.MaxValue
            f1 = DecodeULong1Float(ui);
            f2 = DecodeULong2Float(ui);
            Assert.AreEqual(f2, f1, "Direct and indirect ulong-to-float should be equal for ulong.MaxValue");

            ui = new uint[] { 0x12345678, 0x87654321 }; // 0x8765432112345678, high bit set
            f1 = DecodeULong1Float(ui);
            f2 = DecodeULong2Float(ui);
            Assert.AreEqual(f2, f1, "Direct and indirect ulong-to-float should be equal for 0x8765432112345678");

            ui = new uint[] { 0x12345678, 0x01234567 }; // high bit clear
            f1 = DecodeULong1Float(ui);
            f2 = DecodeULong2Float(ui);
            Assert.AreEqual(f2, f1, "Direct and indirect ulong-to-float should be equal for 0x0123456712345678");
        }

        private static double DecodeNumber1(ushort[] us)
        {
            // Returns the expression directly as double without an intermediate uint local variable.
            // This exercises the conv.r.un IL opcode on a stack value, which had a sign-interpretation bug.
            return ((uint)us[1] << 16) + us[0];
        }

        private static double DecodeNumber2(ushort[] us)
        {
            // Stores in a uint local first, so conv.r.un sees a correctly typed local variable.
            uint u = ((uint)us[1] << 16) + us[0];
            return u;
        }

        private static float DecodeNumberToFloat1(ushort[] us)
        {
            // Returns the uint expression directly as float, exercising conv.r.un on an I4 stack value.
            return ((uint)us[1] << 16) + us[0];
        }

        private static float DecodeNumberToFloat2(ushort[] us)
        {
            // Stores in a uint local first, so conv.r.un sees a correctly typed U4 local.
            uint u = ((uint)us[1] << 16) + us[0];
            return u;
        }

        private static double DecodeULong1(uint[] ui)
        {
            // Returns the ulong expression directly as double.
            // conv.r.un is applied to an I8 arithmetic result on the eval stack,
            // which had a sign-interpretation bug before the fix.
            return ((ulong)ui[1] << 32) | ui[0];
        }

        private static double DecodeULong2(uint[] ui)
        {
            // Stores in a ulong local first, so conv.r.un sees a correctly typed U8 local.
            ulong u = ((ulong)ui[1] << 32) | ui[0];
            return u;
        }

        private static float DecodeULong1Float(uint[] ui)
        {
            // Returns the ulong expression directly as float (conv.r.un on I8, then conv.r4).
            return (float)(((ulong)ui[1] << 32) | ui[0]);
        }

        private static float DecodeULong2Float(uint[] ui)
        {
            // Stores in a ulong local first, so conv.r.un sees a correctly typed U8 local.
            ulong u = ((ulong)ui[1] << 32) | ui[0];
            return (float)u;
        }

        #region Double/Floating point number helpers

        /// <summary>
        /// Converts the given double to a hexidecimal display - to be used to test boundary cases.
        /// </summary>
        /// <param name="d">The double to convert.</param>
        /// <returns>"+Infinity", "-Infinity", "NaN" or "0x[16 hex bytes]"</return>
        public static string DoubleToHex(double d)
        {
            if (double.IsPositiveInfinity(d))
                return "+Infinity";
            if (double.IsNegativeInfinity(d))
                return "-Infinity";
            if (double.IsNaN(d))
                return "NaN";

            string returnValue = string.Format("0x{0:X16}", BitConverter.DoubleToInt64Bits(d));
            return returnValue;
        }

        /// <summary>
        /// Converts the given double to a hexidecimal display - to be used to test boundary cases.
        /// </summary>
        /// <param name="f">The single (float) to convert.</param>
        /// <returns>"+Infinity", "-Infinity", "NaN" or "0x[8 hex bytes]"</return>
        public static string FloatToHex(float f)
        {
            if (float.IsPositiveInfinity(f))
                return "+Infinity";
            if (float.IsNegativeInfinity(f))
                return "-Infinity";
            if (float.IsNaN(f))
                return "NaN";
            string returnValue = string.Format("0x{0:X8}", BitConverter.ToInt32(BitConverter.GetBytes(f), 0));  // CoreLibrary/mscorlib does not implement SingleToInt32Bits
            return returnValue;
        }


        #endregion

        #region Base64 conversions

        [TestMethod]
        public void Convert_FromToBase64()
        {
            string sharedAccessKeyPlainText = "IAmALongAndNiceKeyInPlainText";
            string sharedAccessKey = "SUFtQUxvbmdBbmROaWNlS2V5SW5QbGFpblRleHQ=";

            byte[] sharedAccessKeyAsByte = Convert.FromBase64String(sharedAccessKey);

            char[] charArray = new char[sharedAccessKeyAsByte.Length];

            for (int i = 0; i < sharedAccessKeyAsByte.Length; i++)
            {
                charArray[i] = (char)sharedAccessKeyAsByte[i];
            }

            string sharedAccessKeyAsString = new(charArray);

            Assert.AreEqual(sharedAccessKeyAsString, sharedAccessKeyPlainText, "Converted string as byte array is not correct.");

            string convertedFromBase64 = Convert.ToBase64String(sharedAccessKeyAsByte);

            OutputHelper.WriteLine($">>{convertedFromBase64}");
            OutputHelper.WriteLine($">>{sharedAccessKey}");

            Assert.AreEqual(convertedFromBase64, sharedAccessKey, "Converted string from byte array is not correct.");
        }

        [TestMethod]
        public void Convert_ToFromBase64()
        {
            byte[] inArray = new byte[256];
            byte[] outArray;
            int x;

            for (x = 0; x < inArray.Length; x++)
            {
                inArray[x] = (byte)x;
            }

            string base64EncodedString_WithLineBreaks = @"AAECAwQFBgcICQoLDA0ODxAREhMUFRYXGBkaGxwdHh8gISIjJCUmJygpKissLS4vMDEyMzQ1Njc4
OTo7PD0+P0BBQkNERUZHSElKS0xNTk9QUVJTVFVWV1hZWltcXV5fYGFiY2RlZmdoaWprbG1ub3Bx
cnN0dXZ3eHl6e3x9fn+AgYKDhIWGh4iJiouMjY6PkJGSk5SVlpeYmZqbnJ2en6ChoqOkpaanqKmq
q6ytrq+wsbKztLW2t7i5uru8vb6/wMHCw8TFxsfIycrLzM3Oz9DR0tPU1dbX2Nna29zd3t/g4eLj
5OXm5+jp6uvs7e7v8PHy8/T19vf4+fr7/P3+/w==";

            string base64EncodedString_WithoutLineBreaks = "AAECAwQFBgcICQoLDA0ODxAREhMUFRYXGBkaGxwdHh8gISIjJCUmJygpKissLS4vMDEyMzQ1Njc4OTo7PD0+P0BBQkNERUZHSElKS0xNTk9QUVJTVFVWV1hZWltcXV5fYGFiY2RlZmdoaWprbG1ub3BxcnN0dXZ3eHl6e3x9fn+AgYKDhIWGh4iJiouMjY6PkJGSk5SVlpeYmZqbnJ2en6ChoqOkpaanqKmqq6ytrq+wsbKztLW2t7i5uru8vb6/wMHCw8TFxsfIycrLzM3Oz9DR0tPU1dbX2Nna29zd3t/g4eLj5OXm5+jp6uvs7e7v8PHy8/T19vf4+fr7/P3+/w==";

            string base64string1 = Convert.ToBase64String(
                inArray,
                0,
                inArray.Length,
                Base64FormattingOptions.InsertLineBreaks);

            Assert.AreEqual(base64string1, base64EncodedString_WithLineBreaks, "Converted Base64 string with line breaks is not correct.");

            string base64string2 = Convert.ToBase64String(inArray);

            Assert.AreEqual(base64string2, base64EncodedString_WithoutLineBreaks, "Converted Base64 string without line breaks is not correct.");

            outArray = Convert.FromBase64String(base64string1);

            CollectionAssert.AreEqual(inArray, outArray, "Convert back from Base64 encoded array is not equal");
        }

        #endregion
    }
}
