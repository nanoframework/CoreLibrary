﻿//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

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

                d1 = (double)u1; // Does not work correctly (d1 is close to 0)
                u2 = (uint)d1;
                Assert.Equal(d1, u1);
                Assert.Equal(u2, u1);

                f1 = (float)u1; // Same problem
                Assert.Equal(f1, u1);

                l1 = (long)u1;
                u2 = (uint)l1;
                Assert.Equal(l1, u1);
                Assert.Equal(u2, u1);

                d2 = l1; // Same problem
                l2 = (long)d2;
                Assert.Equal(d2, l1);
                Assert.Equal(l2, l1);
            }
        }

        [TestMethod]
        public void Convert_Positive()
        {
            string number = "12";
            int actualNumber = 12;
            SByte value_sb = Convert.ToSByte(number);
            Assert.Equal(value_sb, (byte)12);
            Byte value_b = Convert.ToByte(number);
            Assert.Equal(value_b, (byte)12);
            Int16 value_s16 = Convert.ToInt16(number);
            Assert.Equal(value_s16, (short)12);
            UInt16 value_u16 = Convert.ToUInt16(number);
            Assert.Equal(value_u16, (ushort)12);
            Int32 value_s32 = Convert.ToInt32(number);
            Assert.Equal(value_s32, (int)12);
            UInt32 value_u32 = Convert.ToUInt32(number);
            Assert.Equal(value_u32, (uint)12);
            Int64 value_s64 = Convert.ToInt32(number);
            Assert.Equal(value_s64, (long)12);
            UInt64 value_u64 = Convert.ToUInt64(number);
            Assert.Equal(value_u64, (ulong)12);
        }

        [TestMethod]
        public void Convert_PositivePlus()
        {
            string number = "+12";
            int actualNumber = 12;
            SByte value_sb = Convert.ToSByte(number);
            Assert.Equal(value_sb, (byte)12);
            Byte value_b = Convert.ToByte(number);
            Assert.Equal(value_b, (byte)12);
            Int16 value_s16 = Convert.ToInt16(number);
            Assert.Equal(value_s16, (short)12);
            UInt16 value_u16 = Convert.ToUInt16(number);
            Assert.Equal(value_u16, (ushort)12);
            Int32 value_s32 = Convert.ToInt32(number);
            Assert.Equal(value_s32, (int)12);
            UInt32 value_u32 = Convert.ToUInt32(number);
            Assert.Equal(value_u32, (uint)12);
            Int64 value_s64 = Convert.ToInt32(number);
            Assert.Equal(value_s64, (long)12);
            UInt64 value_u64 = Convert.ToUInt64(number);
            Assert.Equal(value_u64, (ulong)12);
        }


        [TestMethod]
        public void Convert_Negative()
        {
            string number = "-12";
            int actualNumber = -12;
            SByte value_sb = Convert.ToSByte(number);
            Assert.Equal(value_sb, (sbyte)actualNumber, "Test1");
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { Byte value_b = Convert.ToByte(number); }, "Test2");
            Int16 value_s16 = Convert.ToInt16(number);
            Assert.Equal(value_s16, (short)actualNumber, "Test3");
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { UInt16 value_u16 = Convert.ToUInt16(number); }, "Test4");
            Int32 value_s32 = Convert.ToInt32(number);
            Assert.Equal(value_s32, (int)actualNumber, "Test5");
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { UInt32 value_u32 = Convert.ToUInt32(number); }, "Test6");
            Int64 value_s64 = Convert.ToInt32(number);
            Assert.Equal(value_s64, (long)actualNumber, "Test7");
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { UInt64 value_u64 = Convert.ToUInt64(number); }, "Test8");
        }

        [TestMethod]
        public void Convert_Double()
        {
            string number = "36.123456";
            double actualNumber = 36.123456;

            double value_dd = Convert.ToDouble(number);
            Assert.Equal(value_dd, actualNumber);
        }

        [TestMethod]
        public void Convert_Plus()
        {
            string number = "+36.123456";
            double actualNumber = 36.123456;

            double value_dd = Convert.ToDouble(number);
            Assert.Equal(value_dd, actualNumber);
        }

        [TestMethod]
        public void Convert_Neg()
        {
            string number = "-36.123456";
            double actualNumber = -36.123456;

            double value_dd = Convert.ToDouble(number);

            Assert.Equal(value_dd, actualNumber);
        }

        [TestMethod]
        public void Convert_Whitespace()
        {
            string intnum = " -3484  ";
            string number = " +36.123456   ";
            long actualInt = -3484;
            double actualNumber = 36.123456;

            Assert.Equal(actualInt, Convert.ToInt16(intnum));
            Assert.Equal(actualInt, Convert.ToInt32(intnum));
            Assert.Equal(actualInt, Convert.ToInt64(intnum));
            double value_dd = Convert.ToDouble(number);
            Assert.Equal(value_dd, actualNumber);
        }

        [TestMethod]
        public void Convert_DoubleNormalizeNeg()
        {
            string number = "-3600030383448481.123456";
            double actualNumber = -3600030383448481.123456;  // note: this is the double as calculated by the Roslyn compiler - not the same as the native code routine

            double value_dd = Convert.ToDouble(number);

            Assert.Equal(value_dd, actualNumber, $"Convert.ToDouble should be {number}");  // this works if the numbers are fairly small - i.e. not e^x sized

            // Examples of how we can get differences due to differences between the compiler parser, and the native parser
            // And differences caused by the native parsers "fast speed" causing rounding errors
            string num1 = "+0.000000004848747585e-3"; 
            string num2 = "4.848747585e-12";  // same number as above, but we've moved the digits over a bit and adjusted the exponent
            double dnum1Roslyn = +0.000000004848747585e-3;  // Roslyn compiler will parse the value and put it into the double at compile time
            double dnum1Native = Convert.ToDouble(num1);    // Native code will parse the value and put it into the double at run time
            double dnum2Roslyn = 4.848747585e-12;           // Roslyn 
            double dnum2Native = Convert.ToDouble(num2);    // Native

            // Note: in the Asserts below the message should NOT be displayed - which is why "unless..." is added to the message.
            // If the message appears then something has changed.  
            // First we compare the hex values so we don't see any "softness" from the native Double.ToString printf processing

            // comparing the Roslyn results should always match and not display the message
            Assert.Equal(DoubleToHex(dnum1Roslyn), DoubleToHex(dnum2Roslyn), $"Two numbers parsed from Roslyn should always match, unless...");
            // sometimes you can mix and it will work
            Assert.Equal(DoubleToHex(dnum1Roslyn), DoubleToHex(dnum2Native), $"Mixing numbers from Roslyn and Native can sometimes work, unless...");
            // sometimes you can mix and it won't work - depends on how rounding happens in the parser
            Assert.NotEqual(DoubleToHex(dnum1Native), DoubleToHex(dnum2Roslyn), $"Mixing numbers from Roslyn and Native sometimes doesn't work, unless...");

            // Now we will compare some of the ToString values
            // compare native to native - but parsing e-3 versus e-12 means 9 more loops thru the double multiplication where rounding can occur so this won't work for all numbers
            Assert.Equal(dnum1Native.ToString(), dnum2Native.ToString(), $"Comparing native parse then tostring will often work, unless...");
            // compare roslyn to roslyn - the roslyn parser is more accurate and that means the double is much more likely to be the same
            Assert.Equal(dnum1Roslyn.ToString(), dnum2Roslyn.ToString(), $"Comparing Roslyn parse then tostring should always work, unless...");
            // Now mix things up
            Assert.Equal(dnum1Roslyn.ToString(), dnum2Native.ToString(), $"Comparing Roslyn parse and native parse then tostring sometimes works, unless...");
            // Suprising that this next test passes - from above we know that Roslyn and native parsers generated different hex values.  But the native ToString can lose some precision, so that can mask this difference
            Assert.Equal(dnum1Native.ToString(), dnum2Roslyn.ToString(), $"Comparing Roslyn parse and native parse then tostring sometimes works, unless...");
            Assert.Equal(dnum1Roslyn.ToString(), dnum1Native.ToString(), $"Comparing Roslyn to native using {num1}");
            Assert.Equal(dnum2Roslyn.ToString(), dnum2Native.ToString(), $"Comparing Roslyn to natvie using {num2}");
        }

        [TestMethod]
        public void Convert_HexInt()
        {
            string number = "0x01234567";
            int actualNumber = 0x01234567;

            int value = Convert.ToInt32(number, 16);

            Assert.Equal(value, actualNumber);
            number = "0x89abcdef";
            unchecked
            {
                actualNumber = (int)0x89abcdef;
            }
            Assert.Equal(actualNumber, Convert.ToInt32(number, 16));
            number = "0x0AbF83C";
            actualNumber = 0xAbF83C;

            Assert.Equal(actualNumber, Convert.ToInt32(number, 16));
        }

        [TestMethod]

        public void Convert_BoundaryValues()
        {
            //***
            //* Commented out tests and values are due to problems with Parsing of double/float which appear to have rounding errors.
            //* For example, the parse of a Double.MaxValue as a string should be hex 0x43EFFFFFFFFFFFFF but comes back as 0x43EFFFFFFFFFFFFC, so 3 bits off
            //***

            const string OUT_OF_RANGE = "oor";            // nanoPrintf can only print up to 2^64-2 as a max value for double/floating
            const string OUT_OF_RANGE_NEG = "-oor";       // nanoPrintf can only print down to -2^64+2 as a min value for double/floating

            const string DOUBLE_MAX_VAL  = "1.7976931348623157E+308";  // will get 'oor' when printed
            const string DOUBLE_MAX_HEX  = "0x7FEFFFFFFFFFFFFF";
            const string DOUBLE_MIN_VAL  = "-1.7976931348623157E+308"; // will get '-oor' when printed
            const string DOUBLE_MIN_HEX  = "0xFFEFFFFFFFFFFFFF";
            const string DOUBLE_ZERO_HEX = "0x0000000000000000";
            const string DOUBLE_LARGEST_PRINT = "1.84467440737095E+19";
            const string DOUBLE_LARGEST_PRINT_HEX = "0x43EFFFFFFFFFFFE8";
            const string DOUBLE_LARGESTINVALID_PRINT = "1.8446744073709552E+19";  // will get 'oor' when printed
            const string DOUBLE_LARGESTINVALID_PRINT_HEX = "0x43F0000000000000";
            const string DOUBLE_SMALLEST_PRINT = "-1.32585973029787E+19"; // "-1.844674407370955e19";
            const string DOUBLE_SMALLEST_PRINT_HEX = "0xC3E6FFFFFFFFFFED";
            const string DOUBLE_SMALLESTINVALID_PRINT = "-1.8446744073709552E+19"; // will get '-oor' when printed
            const string DOUBLE_SMALLESTINVALID_PRINT_HEX = "0xC3F0000000000000";

            const string FLOAT_MAX_VAL = "3.40282347E+38";
            const string FLOAT_MAX_HEX = "0x7F7FFFFF";  // will get 'oor' when printed
            const string FLOAT_MIN_VAL = "-3.40282347E+38";
            const string FLOAT_MIN_HEX = "0xFF7FFFFF";  // will get '-oor' when printed
            const string FLOAT_ZERO_HEX = "0x00000000";
            const string FLOAT_LARGEST_PRINT = "1.844674E+19";
            const string FLOAT_LARGEST_PRINT_HEX = "0x5F7FFFFC";
            const string FLOAT_LARGESTINVALID_PRINT = "1.8446744E+19";  // will get 'oor' when printed
            const string FLOAT_LARGESTINVALID_PRINT_HEX = "0x5F800000";
            const string FLOAT_SMALLEST_PRINT = "-1.844674E+19";
            const string FLOAT_SMALLEST_PRINT_HEX = "0xDF7FFFFC";
            const string FLOAT_SMALLESTINVALID_PRINT = "-1.8446744E+19"; // will get '-oor' when printed
            const string FLOAT_SMALLESTINVALID_PRINT_HEX = "0xDF800000";

            // boundary: double max
            string time = DateTime.UtcNow.ToString("hh:mm:ss");
            double doubleMax = double.MaxValue;
            Assert.Equal(doubleMax.ToString(), OUT_OF_RANGE, "nanoPrintf returns oor for double > 2^64-2");
            Assert.Equal(DoubleToHex(doubleMax), DOUBLE_MAX_HEX, "Hex value to double max value does not match");
            Assert.Equal(DoubleToHex(Convert.ToDouble(DOUBLE_MAX_VAL)), DOUBLE_MAX_HEX, "Parsing double max value does not return correct hex value");

            // boundary: double min
            double doubleMin = double.MinValue;
            Assert.Equal(doubleMin.ToString(), OUT_OF_RANGE_NEG, "nanoPrintf returns oor for double < -2^64+2");
            Assert.Equal(DoubleToHex(doubleMin), DOUBLE_MIN_HEX,"Hex value to double min value does not match");
            Assert.Equal(DoubleToHex(Convert.ToDouble(DOUBLE_MIN_VAL)), DOUBLE_MIN_HEX, "Parsing double min value does not return correct hex value");

            // boundary: double zero
            double doubleZero = 0;   // test that zero gets a zero exponent and a value like 1023 the exponent bias used in floating point math
            Assert.Equal(doubleZero.ToString(), "0", "ToString of a double with zero value formats incorrectly");
            Assert.Equal(DoubleToHex(doubleZero), DOUBLE_ZERO_HEX, "Double with zero value returns the wrong hex value");

            // boundary: double largest-in-range
            double doubleInRange = Convert.ToDouble(DOUBLE_LARGEST_PRINT);
            Assert.Equal(DoubleToHex(doubleInRange), DOUBLE_LARGEST_PRINT_HEX, "Parsing double largest in ranges does not return correct hex value");
            Assert.Equal(doubleInRange.ToString(), DOUBLE_LARGEST_PRINT, "Double.ToString did not return the correct value for largest in range value");

            // boundary: double largest-out-of-range
            double doubleOutRange = Convert.ToDouble(DOUBLE_LARGESTINVALID_PRINT);
            Assert.Equal(DoubleToHex(doubleOutRange), DOUBLE_LARGESTINVALID_PRINT_HEX, "Parsing double largest out range does not return correct hex value");
            Assert.Equal(doubleOutRange.ToString(), OUT_OF_RANGE, "Double.ToString did not return 'oor' for first out-of-range value");

            // boundary: double smallest-in-range
            double doubleInRangeNeg = Convert.ToDouble(DOUBLE_SMALLEST_PRINT);
            Assert.Equal(DoubleToHex(doubleInRangeNeg), DOUBLE_SMALLEST_PRINT_HEX, "Parsing double smallest in ranges does not return correct hex value");
            Assert.Equal(doubleInRangeNeg.ToString(), DOUBLE_SMALLEST_PRINT, "Double.ToString did not return the correct value for smallest in range value");

            // boundary: double smallest-out-of-range
            double doubleOutRangeNeg = Convert.ToDouble(DOUBLE_SMALLESTINVALID_PRINT);
            Assert.Equal(DoubleToHex(doubleOutRangeNeg), DOUBLE_SMALLESTINVALID_PRINT_HEX, "Parsing double smallest out range does not return correct hex value");
            Assert.Equal(doubleOutRangeNeg.ToString(), OUT_OF_RANGE_NEG, "Double.ToString did not return 'oor' for smallest out-of-range value");

            // boundary: float max
            float floatMax = float.MaxValue;
            Assert.Equal(floatMax.ToString(), OUT_OF_RANGE, "nanoPrintf return oor for float > 2^64-2");
            Assert.Equal(FloatToHex(floatMax), FLOAT_MAX_HEX, "Hex value to float max values does not match");
            Assert.Equal(FloatToHex((float)Convert.ToDouble(FLOAT_MAX_VAL)), FLOAT_MAX_HEX, "Parsing float max value does not return correct hex value");

            // boundary: float min
            float floatMin = float.MinValue;
            Assert.Equal(floatMin.ToString(), OUT_OF_RANGE_NEG, "nanoPrintf returns oor for float < -2^64+2");
            Assert.Equal(FloatToHex(floatMin), FLOAT_MIN_HEX, "Hex value to double min value does not match");
            Assert.Equal(FloatToHex((float)Convert.ToDouble(FLOAT_MIN_VAL)), FLOAT_MIN_HEX, "Parsing float min value does not return correct hex value");

            //boundary: float zero
            float floatZero = 0;   // test that zero gets a zero exponent and a value like 1023 the exponent bias used in floating point math
            Assert.Equal(floatZero.ToString(), "0", "ToString of a string with zero value formats incorrectly");
            Assert.Equal(FloatToHex(floatZero), FLOAT_ZERO_HEX, "Float with zero value returns the wrong hex value");

            // boundary: float largest-in-range
            float floatInRange = (float)Convert.ToDouble(FLOAT_LARGEST_PRINT);
            Assert.Equal(FloatToHex(floatInRange), FLOAT_LARGEST_PRINT_HEX, "Parsing float largest in ranges does not return correct hex value");
            Assert.Equal(floatInRange.ToString(), FLOAT_LARGEST_PRINT, "Float.ToString did not return the correct value for largest in range value");

            // boundary: float largest-out-of-range
            float floatOutRange = (float)Convert.ToDouble(FLOAT_LARGESTINVALID_PRINT);
            Assert.Equal(FloatToHex(floatOutRange), FLOAT_LARGESTINVALID_PRINT_HEX, "Parsing float largest out range does not return correct hex value");
            Assert.Equal(floatOutRange.ToString(), OUT_OF_RANGE, "Float.ToString did not return 'oor' for first out-of-range value");

            // boundary: float smallest-in-range
            float floatInRangeNeg = (float)Convert.ToDouble(FLOAT_SMALLEST_PRINT);
            Assert.Equal(FloatToHex(floatInRangeNeg), FLOAT_SMALLEST_PRINT_HEX, "Parsing float smallest in ranges does not return correct hex value");
            Assert.Equal(floatInRangeNeg.ToString(), FLOAT_SMALLEST_PRINT, "Float.ToString did not return the correct value for smallest in range value");

            // boundary: float smallest-out-of-range
            float floatOutRangeNeg = (float)Convert.ToDouble(FLOAT_SMALLESTINVALID_PRINT);
            Assert.Equal(FloatToHex(floatOutRangeNeg), FLOAT_SMALLESTINVALID_PRINT_HEX, "Parsing float smallest out range does not return correct hex value");
            Assert.Equal(floatOutRangeNeg.ToString(), OUT_OF_RANGE_NEG, "Float.ToString did not return 'oor' for smallest out-of-range value");

            long lMax = long.MaxValue;
            string numMax = lMax.ToString();
            long lMin = long.MinValue;
            string numMin = lMin.ToString();

            Assert.Equal(lMax, Convert.ToInt64(numMax), "Int64 Max");
            Assert.Equal(lMin, Convert.ToInt64(numMin), "Int64 Min");

            ulong ulMax = ulong.MaxValue;
            numMax = ulMax.ToString();
            ulong ulMin = ulong.MinValue;
            numMin = ulMin.ToString();

            Assert.Equal(ulMax, Convert.ToUInt64(numMax), "UInt64 Max");
            Assert.Equal(ulMin, Convert.ToUInt64(numMin), "UInt64 Min");

            long iMax = int.MaxValue;
            numMax = iMax.ToString();
            long iMin = int.MinValue;
            numMin = iMin.ToString();

            Assert.Equal(iMax, Convert.ToInt32(numMax), "Int32 Max");
            Assert.Equal(iMin, Convert.ToInt32(numMin), "Int32 Min");

            uint uiMax = uint.MaxValue;
            numMax = uiMax.ToString();
            uint uiMin = uint.MinValue;
            numMin = uiMin.ToString();

            Assert.Equal(uiMax, Convert.ToUInt32(numMax));
            Assert.Equal(uiMin, Convert.ToUInt32(numMin));

            short sMax = short.MaxValue;
            numMax = sMax.ToString();
            short sMin = short.MinValue;
            numMin = sMin.ToString();

            Assert.Equal(sMax, Convert.ToInt16(numMax));
            Assert.Equal(sMin, Convert.ToInt16(numMin));

            ushort usMax = ushort.MaxValue;
            numMax = usMax.ToString();
            ushort usMin = ushort.MinValue;
            numMin = usMin.ToString();

            Assert.Equal(usMax, Convert.ToUInt16(numMax));
            Assert.Equal(usMin, Convert.ToUInt16(numMin));

            sbyte sbMax = sbyte.MaxValue;
            numMax = sbMax.ToString();
            sbyte sbMin = sbyte.MinValue;
            numMin = sbMin.ToString();

            Assert.Equal(sbMax, Convert.ToSByte(numMax));
            Assert.Equal(sbMin, Convert.ToSByte(numMin));

            byte bMax = byte.MaxValue;
            numMax = bMax.ToString();
            byte bMin = byte.MinValue;
            numMin = bMin.ToString();

            Assert.Equal(bMax, Convert.ToByte(numMax));
            Assert.Equal(bMin, Convert.ToByte(numMin));
            
        }


        [TestMethod]
        public void Convert_LeadingZeroValues()
        {
            string number = "00000000";

            Assert.Equal((short)0, Convert.ToInt16(number));
            Assert.Equal(0, Convert.ToInt32(number));
            Assert.Equal(0, Convert.ToInt64(number));

            number = "+00000000000";

            Assert.Equal((short)0, Convert.ToInt16(number));
            Assert.Equal(0, Convert.ToInt32(number));
            Assert.Equal(0, Convert.ToInt64(number));

            number = "-00000000000";

            Assert.Equal((short)0, Convert.ToInt16(number));
            Assert.Equal(0, Convert.ToInt32(number));
            Assert.Equal(0, Convert.ToInt64(number));
        }

        [TestMethod]
        public void Convert_LeadingZeros()
        {
            string number = "000003984";
            int actualNumber = 3984;

            Assert.Equal((short)actualNumber, Convert.ToInt16(number));
            Assert.Equal(actualNumber, Convert.ToInt32(number));
            Assert.Equal(actualNumber, Convert.ToInt64(number));
            number = "-00000003489";
            actualNumber = -3489;

            Assert.Equal((short)actualNumber, Convert.ToInt16(number));
            Assert.Equal(actualNumber, Convert.ToInt32(number));
            Assert.Equal(actualNumber, Convert.ToInt64(number));
            number = "+00000003489";
            actualNumber = 3489;

            Assert.Equal((short)actualNumber, Convert.ToInt16(number));
            Assert.Equal(actualNumber, Convert.ToInt32(number));
            Assert.Equal(actualNumber, Convert.ToInt64(number));

            number = "+000000043984.00048850000";
            double numD = 4.39840004885;

            Assert.NotEqual(numD, Convert.ToDouble(number));
            number = "-000000043984.00048850000";
            numD = -4.39840004885;

            Assert.NotEqual(numD, Convert.ToDouble(number));
            number = "000000043984.000488500e-006";
            numD = 4.39840004885e2;

            Assert.NotEqual(numD, Convert.ToDouble(number));
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
            Debug.WriteLine("Time: " + (DateTime.UtcNow - start).ToString());

            Assert.Equal(val, -7446744073709551615L);
        }

        [TestMethod]
        public void Convert_FromBoolean()
        {
            bool iamTrue = true;
            bool iamFalse = false;

            byte convTrueIsOne = Convert.ToByte(iamTrue);
            byte convFalseIsZero = Convert.ToByte(iamFalse);

            Assert.Equals(convTrueIsOne, 1);
            Assert.Equals(convFalseIsZero, 0);
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
            string returnValue = string.Format("0x{0:X8}", BitConverter.ToInt32(BitConverter.GetBytes(f),0));  // CoreLibrary/mscorlib does not implement SingleToInt32Bits
            return returnValue;
        }


        #endregion

    }
}
