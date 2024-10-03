//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Collections;
using static NFUnitTestArithmetic.SampleDisplay;

namespace NFUnitTestArithmetic
{
    [TestClass]
    public class UnitTestFormat
    {
        private static SampleDisplay sampleDisplay;
        public enum NumType
        {
            IntOnly,
            FloatDoubleOnly,
            All
        }

        public enum Signed
        {
            UnsignedOnly,
            Both
        }

        public enum Case
        {
            Upper,
            Lower,
            Both
        }

        [TestMethod]
        public void StringFormat_00()
        {
            // Test a null string in String.Format - should be treated like an empty string.
            string nullArg = null;
            Assert.AreEqual(string.Format("Value is {0}", nullArg), "Value is ", "");
        }

        [TestMethod]
        public void StringFormat_01()
        {
            // catch an exception if the format string is null
            string nullFormat = null;
            Assert.ThrowsException(typeof(NullReferenceException), () => { string.Format(nullFormat, 12345.67); });
        }

        [TestMethod]
        [DataRow("Left align in 10 chars: {0,-10:N2}: and then more", 1234.5641, "Left align in 10 chars: 1,234.56  : and then more")]
        [DataRow("Right align in 10 chars: {0,10:N2}: and then more", 1234.5641, "Right align in 10 chars:   1,234.56: and then more")]
        public void StringFormat_02(string formatString, double value, string outcomeMessage)
        {
            // Test alignment operator which is the "," and a number.  Negative is right aligned, positive left aligned 
            Assert.AreEqual(string.Format(formatString, value), outcomeMessage);
        }

        [TestMethod]
        [DataRow("{0,}", 12345.67, "Should throw with error message: Format error: empty alignment, column 3")]
        [DataRow("{0,a10}", 12345.67, "Should throw with error message: Format error: wrong symbol at alignment, column 3")]
        [DataRow("{0, -a10}", 12345.67, "Should throw with error message: Format error: wrong symbol at alignment, column 4")]
        [DataRow("{a}", 12345.67, "Should throw with error message: Format error: wrong symbol at {}, column 1")]
        [DataRow("{0:}", 12345.67, "Should throw with error message: Format error: empty format after ':', column 3")]
        [DataRow("{0", 12345.67, "Should throw with error message: Format error: no closed brace, column 2")]
        public void StringFormat_03(string formatString, double value, string outcomeMessage)
        {
            OutputHelper.WriteLine("formatString is" + formatString);
            // invalid alignment cases
            Assert.ThrowsException(typeof(ArgumentException), () => { string.Format(formatString, value); }, outcomeMessage);
        }

        [TestMethod]
        // the D format can only be used with integers (no double or floats)
        public void DecimalFormat()
        {
            sampleDisplay = new SampleDisplay();

            TestFormat("  123", "D", "123");
            TestFormat("  129", "D", "129");
            TestFormat(" -129", "D", "-129");
            TestFormat("  128", "D", "128");
            TestFormat(" -128", "D", "-128");
            TestFormat(" -128", "D2", "-128");
            TestFormat(" 1234", "D2", "1234");
            TestFormat("-1234", "D", "-1234");
            TestFormat(" 1234", "D6", "001234");
            TestFormat("-1234", "D6", "-001234");

            sampleDisplay.WriteOutput();

        }


        [TestMethod]
        // the F format can be used with all number types
        public void FixedFormat()
        {
            sampleDisplay = new SampleDisplay();

            // default for CultureInvariant is 2 decimal places

            TestFormat("0", "F", "0.00");
            TestFormat("0", "F4", "0.0000");
            TestFormat("123", "F", "123.00");
            TestFormat("129", "F", "129.00");
            TestFormat("-129", "F", "-129.00");
            TestFormat("128", "F", "128.00");
            TestFormat("128", "F4", "128.0000");
            TestFormat("-128", "F", "-128.00");
            TestFormat("-128", "F2", "-128.00");
            TestFormat("1234", "F2", "1234.00");
            TestFormat("-1234", "F", "-1234.00");
            TestFormat("1234", "F6", "1234.000000");
            TestFormat("-1234", "F6", "-1234.000000");
            TestFormat("123.78", "F3", "123.780");
            TestFormat("123.78", "F1", "123.8");
            TestFormat("1234.8999", "F3", "1234.900");

            sampleDisplay.WriteOutput();

        }

        // the E format can be used with all number types
        [DataRow("0", "E", "0.000000E+000", true, true, true)]
        [DataRow("0", "E4", "0.0000E+000", true, true, true)]
        [DataRow("12345.6789", "E", "1.234568E+004", true, true, false)]
        [DataRow("12345.678", "E6", "1.234568E+004", true, true, false)]
        [DataRow("12345.6789", "e4", "1.2346e+004", true, true, false)]
        [DataRow("123", "E", "1.230000E+002", true, true, true)]
        [DataRow("-123", "E", "-1.230000E+002", true, true, true)]
        [DataRow("1.2345e-9", "E", "1.234500E-009", true, false, false)]
        [DataRow("1.2345e-9", "E5", "1.23450E-009", true, false, false)]
        [TestMethod]
        public void ExponentialFormat(string valueStr, string formatString, string expectedResult, bool testDouble, bool testSingle, bool testIntegers)
        {
            double value = double.Parse(valueStr);

            if (testDouble)
            {
                CheckValue(double.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.Single, null);
                Assert.IsTrue(double.TryParse(valueStr, out double result), $"TryParse failed for double {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.Double, null);
            }

            if (testSingle)
            {
                CheckValue(float.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.Single, null);
                Assert.IsTrue(float.TryParse(valueStr, out float result), $"TryParse failed for float {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.Single, null);
            }

            if (testIntegers)
            {
                // can't test negative values with UInt64
                if (value > 0)
                {
                    CheckValue(ulong.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.UInt64, null);
                    Assert.IsTrue(ulong.TryParse(valueStr, out ulong result), $"TryParse failed for ulong {valueStr}");
                    CheckValue(result, valueStr, formatString, expectedResult, ColumnType.UInt64, null);
                }

                CheckValue(long.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.Int64, null);
                Assert.IsTrue(long.TryParse(valueStr, out long result1), $"TryParse failed for long {valueStr}");
                CheckValue(result1, valueStr, formatString, expectedResult, ColumnType.Int64, null);
            }

            //;

            sampleDisplay.WriteOutput();
        }

        [TestMethod]
        // the G format can be used with all number types
        [DataRow("0", "G", "0", false, false, true)]
        [DataRow("0", "G4", "0", false, false, true)]
        [DataRow("123", "G", "123", false, false, true)]
        [DataRow("129", "G", "129", false, false, true)]
        [DataRow("-129", "G", "-129", false, false, true)]
        [DataRow("128", "G", "128", false, false, true)]
        [DataRow("128", "G4", "128", false, false, true)]
        [DataRow("-128", "G", "-128", false, false, true)]
        [DataRow("-128", "G2", "-1.3E+02", false, false, true)]
        [DataRow("1234", "G2", "1.2E+03", false, false, false)]
        [DataRow("-1234", "G", "-1234", true, false, true)]
        [DataRow("1234", "G6", "1234", true, false, true)]
        [DataRow("-1234", "G6", "-1234", true, false, true)]
        [DataRow("123.78", "G3", "124", true, true, false)]
        [DataRow("123.7841", "G5", "123.78", true, true, false)]
        [DataRow("123.7851", "G5", "123.79", true, true, false)]
        [DataRow("123.78", "G5", "123.78", true, true, false)]
        [DataRow("123.78", "G4", "123.8", true, true, false)]
        [DataRow("1234.8999", "G5", "1234.9", true, true, false)]
        [DataRow("1234.8999", "G6", "1234.9", true, true, false)]
        [DataRow("1234.8999", "G7", "1234.9", true, true, false)]
        [DataRow("-1234.901", "G7", "-1234.901", true, true, false)]
        [DataRow("1.2345E-09", "G", "1.2345E-09", true, false, false)]
        [DataRow("1.7976931348623157E+275", "G", "1.7976931348623157E+275", true, false, false)]
        [DataRow("-1.7976931348623157E+275", "G", "-1.7976931348623157E+275", true, false, false)]
        public void GeneralFormat(string valueStr, string formatString, string expectedResult, bool testDouble, bool testSingle, bool testIntegers)
        {
            double value = double.Parse(valueStr);


            if (testDouble)
            {
                CheckValue(double.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.Double, null);
                Assert.IsTrue(double.TryParse(valueStr, out double result), $"TryParse failed for double {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.Double, null);
            }

            if (testSingle)
            {
                CheckValue(float.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.Single, null);
                Assert.IsTrue(float.TryParse(valueStr, out float result), $"TryParse failed for float {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.Single, null);
            }

            if (testIntegers)
            {
                // can't test negative values with UInt64
                if (value > 0)
                {
                    CheckValue(ulong.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.UInt64, null);
                    Assert.IsTrue(ulong.TryParse(valueStr, out ulong result), $"TryParse failed for ulong {valueStr}");
                    CheckValue(result, valueStr, formatString, expectedResult, ColumnType.UInt64, null);
                }

                CheckValue(long.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.Int64, null);
                Assert.IsTrue(long.TryParse(valueStr, out long result1), $"TryParse failed for long {valueStr}");
                CheckValue(result1, valueStr, formatString, expectedResult, ColumnType.Int64, null);
            }
        }

        [TestMethod]
        // the N format can be used with all number types
        public void NumberFormat()
        {
            sampleDisplay = new SampleDisplay();

            TestFormat("123", "N", "123.00");     // default for CultureInvariant is 2 decimal places  
            TestFormat("129", "N", "129.00");
            TestFormat("-129", "N", "-129.00");
            TestFormat("128", "N", "128.00");
            TestFormat("128", "N4", "128.0000");
            TestFormat("-128", "N", "-128.00");
            TestFormat("-128", "N2", "-128.00");
            TestFormat("1234", "N2", "1,234.00");
            TestFormat("-1234", "N", "-1,234.00");
            TestFormat("1234", "N6", "1,234.000000");
            TestFormat("-1234", "N6", "-1,234.000000");
            TestFormat("1234.567", "N2", "1,234.57");
            TestFormat("-1234.567", "N2", "-1,234.57");
            TestFormat("123456.78", "N2", "123,456.78");
            TestFormat("1234567.1210", "N2", "1,234,567.12");
            TestFormat("-0.099999999999999978", "N2", "-0.10");
            sampleDisplay.WriteOutput();
        }

        [TestMethod]
        // the X format can only be used with integer number types
        public void HexFormat_00()
        {
            sampleDisplay = new SampleDisplay();

            //TestFormat("0x20E", "X", "020E");
            TestFormat("    0", "X2", "00");
            TestFormat("   +0", "X", "0");
            TestFormat("   -0", "X", "0");
            TestFormat("   12", "X", "C");
            TestFormat("   12", "X2", "0C");
            TestFormat("  127", "X", "7F");
            TestFormat("  129", "X", "81");

            TestFormat(" 1234", "X", "4D2");
            TestFormat(" -127", "X", "81");
            TestFormat(" -128", "X", "80");
            TestFormat(" -128", "X4", "80");
            TestFormat(" -129", "X", "FF7F");
            TestFormat("-1234", "X", "FB2E");
            TestFormat("-1234", "X6", "FB2E");

            sampleDisplay.WriteOutput();
        }

        [TestMethod]
        // the X format can only be used with integer number types
        public void HexFormat_01()
        {
            Assert.AreEqual("0080", int.Parse("  128").ToString("X4"), "Wrong output for 128 X4");
            Assert.AreEqual("0004D2", int.Parse(" 1234").ToString("X6"), "Wrong output for 1234 X6");
        }

        #region Helper functions
        private void TestFormat(string valueStr, string formatString, string expectedResult, Case formatCase = Case.Both)
        {
            double value = double.Parse(valueStr);  // !!! does not return a negative number when parsed if string value does not contain a decimal point
            bool isNegative = false;
            NumType numType = NumType.All;

            if (value < 0)
            //if (valueStr.TrimStart()[0] == '-')
            {
                isNegative = true;
            }

            switch (formatString.ToUpper()[0])
            {
                case 'D':
                case 'X':
                    numType = NumType.IntOnly;
                    break;

                default:
                    if (value - (int)value != 0)  // number with a fractional part
                    {
                        numType = NumType.FloatDoubleOnly;
                    }
                    break;
            }


            switch (formatCase)
            {
                case Case.Upper:
                    TestFormatInner(valueStr, formatString.ToUpper(), expectedResult.ToUpper(), numType, isNegative);
                    break;
                case Case.Lower:
                    TestFormatInner(valueStr, formatString.ToLower(), expectedResult.ToLower(), numType, isNegative);
                    break;
                case Case.Both:
                    TestFormatInner(valueStr, formatString.ToUpper(), expectedResult.ToUpper(), numType, isNegative);
                    TestFormatInner(valueStr, formatString.ToLower(), expectedResult.ToLower(), numType, isNegative);
                    break;
                default:
                    Assert.IsTrue(false, "Invalid format case used");
                    break;
            }
        }

        private void TestFormatInner(string valueStr, string formatString, string expectedResult, NumType numType, bool isNegative)
        {
            RowData rowData = sampleDisplay.AddRow(valueStr, formatString);
            double value = double.Parse(valueStr);
            if (value <= sbyte.MaxValue
                && value >= sbyte.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                )
            {
                CheckValue(sbyte.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.SByte, rowData);

                Assert.IsTrue(sbyte.TryParse(valueStr, out sbyte result), $"TryParse failed for sbyte {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.SByte, rowData);
            }

            if (value <= short.MaxValue
                && value >= short.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                )
            {
                CheckValue(short.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.Int16, rowData);

                Assert.IsTrue(short.TryParse(valueStr, out short result), $"TryParse failed for short {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.Int16, rowData);
            }

            if (value <= int.MaxValue
                && value >= int.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                )
            {
                CheckValue(int.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.Int32, rowData);

                Assert.IsTrue(int.TryParse(valueStr, out int result), $"TryParse failed for int {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.Int32, rowData);
            }

            if (value <= long.MaxValue
                && value >= long.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                )
            {
                CheckValue(long.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.Int64, rowData);

                Assert.IsTrue(long.TryParse(valueStr, out long result), $"TryParse failed for long {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.Int64, rowData);
            }

            if (value <= byte.MaxValue
                && value >= byte.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                && !isNegative)
            {
                CheckValue(byte.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.Byte, rowData);

                Assert.IsTrue(byte.TryParse(valueStr, out byte result), $"TryParse failed for byte {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.Byte, rowData);
            }

            if (value <= ushort.MaxValue
                && value >= ushort.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                && !isNegative)
            {
                CheckValue(ushort.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.UInt16, rowData);

                Assert.IsTrue(ushort.TryParse(valueStr, out ushort result), $"TryParse failed for ushort {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.UInt16, rowData);
            }

            if (value <= uint.MaxValue
                && value >= uint.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                && !isNegative)
            {
                CheckValue(uint.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.UInt32, rowData);

                Assert.IsTrue(uint.TryParse(valueStr, out uint result), $"TryParse failed for uint {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.UInt32, rowData);
            }

            if (value <= ulong.MaxValue
                && value >= ulong.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                && !isNegative)
            {
                CheckValue(ulong.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.UInt64, rowData);

                Assert.IsTrue(ulong.TryParse(valueStr, out ulong result), $"TryParse failed for ulong {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.UInt64, rowData);
            }

            if (value <= float.MaxValue
                && value >= float.MinValue
                && (numType == NumType.FloatDoubleOnly || numType == NumType.All)
                )
            {
                CheckValue(float.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.Single, rowData);

                Assert.IsTrue(float.TryParse(valueStr, out float result), $"TryParse failed for float {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.Single, rowData);
            }

            if (value <= double.MaxValue
                && value >= double.MinValue
                && (numType == NumType.FloatDoubleOnly || numType == NumType.All)
                )
            {
                CheckValue(double.Parse(valueStr), valueStr, formatString, expectedResult, ColumnType.Double, rowData);

                Assert.IsTrue(double.TryParse(valueStr, out double result), $"TryParse failed for double {valueStr}");
                CheckValue(result, valueStr, formatString, expectedResult, ColumnType.Double, rowData);
            }
        }

        private void CheckValue(object value, string valueStr, string formatString, string expectedResult, ColumnType columnType, RowData rowData)
        {
            string result = string.Format($"{{0:{formatString}}}", new object[] { value });
            // for format of X if the number is negative there will be extra F's in the front depending on integer size.  
            // because of this we will only check the ending characters for format X types
            if (formatString.ToUpper()[0] == 'X')
            {
                Assert.EndsWith(expectedResult, result, $"The expected result for '{formatString}' on value {valueStr} for type {value.GetType().Name} should end with '{expectedResult}'");
            }
            else
            {
                Assert.AreEqual(expectedResult, result, $"The expected result for '{formatString}' on value {valueStr} for type {value.GetType().Name} is '{expectedResult}'");
            }

            if (rowData != null)
            {
                rowData.SetResult(result, columnType);
            }
        }

        #endregion


    }

    #region Classes used for formatting the sample display
    public class SampleDisplay
    {
        public class ColumnInfo
        {
            public string ColumnHeader { get; set; }
            public int LargestLength { get; set; }
            public bool DefaultOnly { get; set; }
            public ColumnInfo(string columnHeader)
            {
                ColumnHeader = columnHeader;
                LargestLength = 0;
                DefaultOnly = true;
            }
        }

        private ArrayList m_columns = new ArrayList();
        private ArrayList m_rows = new ArrayList();
        const string NotApplicable = "n/a";

        public SampleDisplay()
        {
            AddColumn("Value", ColumnType.Value);
            AddColumn("Format", ColumnType.FormatString);
            AddColumn("SByte", ColumnType.SByte);
            AddColumn("Int16", ColumnType.Int16);
            AddColumn("Int32", ColumnType.Int32);
            AddColumn("Int64", ColumnType.Int64);
            AddColumn("Byte", ColumnType.Byte);
            AddColumn("UInt16", ColumnType.UInt16);
            AddColumn("UInt32", ColumnType.UInt32);
            AddColumn("UInt64", ColumnType.UInt64);
            AddColumn("Single", ColumnType.Single);
            AddColumn("Double", ColumnType.Double);
        }

        public ColumnInfo GetColumnInfo(ColumnType columnType)
        {
            return (ColumnInfo)m_columns[(int)columnType];
        }
        public enum ColumnType
        {
            Value,
            FormatString,
            SByte,
            Int16,
            Int32,
            Int64,
            Byte,
            UInt16,
            UInt32,
            UInt64,
            Single,
            Double,
            MaxColumns = Double + 1   // so we can have a number to use for iteration loops max
        }
        public void AddColumn(string columnHeader, ColumnType columnType)
        {
            m_columns.Insert((int)columnType, new ColumnInfo(columnHeader));
            GetColumnInfo(columnType).LargestLength = columnHeader.Length;
        }


        public class RowData
        {
            public string[] ColumnData = new string[(int)ColumnType.MaxColumns];
            private ArrayList ColumnInfos { get; set; }
            public RowData(string value, string formatString, ArrayList columnInfos)
            {
                ColumnInfos = columnInfos;
                SetResult(value, ColumnType.Value);
                SetResult(formatString, ColumnType.FormatString);
                for (int i = 2; i < (int)ColumnType.MaxColumns; i++)
                {
                    SetResult(NotApplicable, (ColumnType)i);
                }
            }

            public void SetResult(string result, ColumnType column)
            {
                int i = (int)column;
                ColumnData[i] = result;
                if (((ColumnInfo)ColumnInfos[i]).LargestLength < result.Length)
                {
                    ((ColumnInfo)ColumnInfos[i]).LargestLength = result.Length;
                }
                if (result != NotApplicable)
                {
                    ((ColumnInfo)ColumnInfos[i]).DefaultOnly = false;

                }
            }
        }

        public RowData AddRow(string value, string formatString)
        {
            RowData rd = new RowData(value, formatString, m_columns);
            m_rows.Add(rd);
            return rd;
        }

        public void WriteOutput()
        {
            // first write out the header row using column info
            for (int i = 0; i < (int)ColumnType.MaxColumns; i++)
            {
                if (GetColumnInfo((ColumnType)i).DefaultOnly == false)
                {
                    OutputHelper.Write(GetColumnInfo((ColumnType)i).ColumnHeader.PadLeft(GetColumnInfo((ColumnType)i).LargestLength + 1));  // +1 for an extra space between columns    
                }
            }

            // now write out the row data
            for (int i = 0; i < m_rows.Count; i++)
            {
                RowData rd = (RowData)m_rows[i];
                for (int j = 0; j < (int)ColumnType.MaxColumns; j++)
                {
                    // don't print columns that only have default (n/a) in them
                    if (GetColumnInfo((ColumnType)j).DefaultOnly)
                    {
                        continue;
                    }
                    // Right align the format string column, left align all the others
                    if (j == (int)ColumnType.FormatString)
                    {
                        OutputHelper.Write(" " + rd.ColumnData[j].PadRight(GetColumnInfo((ColumnType)j).LargestLength));  // add " "for an extra space between columns    
                    }
                    else
                    {
                        OutputHelper.Write(rd.ColumnData[j].PadLeft(GetColumnInfo((ColumnType)j).LargestLength + 1));  // +1 for an extra space between columns    
                    }
                }
            }
        }
    }
    #endregion
}
