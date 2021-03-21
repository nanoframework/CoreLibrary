//
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
            Assert.Equal(value_sb, (sbyte)actualNumber);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { Byte value_b = Convert.ToByte(number); });
            Int16 value_s16 = Convert.ToInt16(number);
            Assert.Equal(value_s16, (short)actualNumber);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { UInt16 value_u16 = Convert.ToUInt16(number); });
            Int32 value_s32 = Convert.ToInt32(number);
            Assert.Equal(value_s32, (int)actualNumber);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { UInt32 value_u32 = Convert.ToUInt32(number); });
            Int64 value_s64 = Convert.ToInt32(number);
            Assert.Equal(value_s64, (long)actualNumber);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { UInt64 value_u64 = Convert.ToUInt64(number); });
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
            double actualNumber = -3600030383448481.123456;

            double value_dd = Convert.ToDouble(number);

            Assert.Equal(value_dd, actualNumber);
            number = "+0.00000000484874758559e-3";
            actualNumber = 4.84874758559e-12;
            Assert.Equal(actualNumber, Convert.ToDouble(number));
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
            double valMax = double.MaxValue;
            string numMax = valMax.ToString();
            double valMin = double.MinValue;
            string numMin = valMin.ToString();

            Assert.Equal(valMax, Convert.ToDouble(numMax));
            Assert.Equal(valMin, Convert.ToDouble(numMin));

            valMax = float.MaxValue;
            numMax = valMax.ToString();
            valMin = float.MinValue;
            numMin = valMin.ToString();

            Assert.Equal(valMax, Convert.ToDouble(numMax));
            Assert.Equal(valMin, Convert.ToDouble(numMin));

            long lMax = long.MaxValue;
            numMax = lMax.ToString();
            long lMin = long.MinValue;
            numMin = lMin.ToString();

            Assert.Equal(lMax, Convert.ToInt64(numMax));
            Assert.Equal(lMin, Convert.ToInt64(numMin));

            ulong ulMax = ulong.MaxValue;
            numMax = ulMax.ToString();
            ulong ulMin = ulong.MinValue;
            numMin = ulMin.ToString();

            Assert.Equal(ulMax, Convert.ToUInt64(numMax));
            Assert.Equal(ulMin, Convert.ToUInt64(numMin));


            long iMax = int.MaxValue;
            numMax = iMax.ToString();
            long iMin = int.MinValue;
            numMin = iMin.ToString();

            Assert.Equal(iMax, Convert.ToInt32(numMax));
            Assert.Equal(iMin, Convert.ToInt32(numMin));

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

    }
}
