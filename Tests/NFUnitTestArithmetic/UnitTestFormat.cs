//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;


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
        public void StringFormat()
        {
            // Test a null string in String.Format - should be treated like an empty string.
            string nullArg = null;
            Assert.Equal(string.Format("Value is {0}", nullArg), "Value is ", "");

            // catch an exception if the format string is null
            string nullFormat = null;
            Assert.Throws(typeof(NullReferenceException), () => { string.Format(nullFormat, 12345.67); });

            // Test alignment operator which is the "," and a number.  Negative is right aligned, positive left aligned 

            Assert.Equal(string.Format("Left align in 10 chars: {0,-10:N2}: and then more", 1234.5641), "Left align in 10 chars: 1,234.56  : and then more");
            Assert.Equal(string.Format("Right align in 10 chars: {0,10:N2}: and then more", 1234.5641), "Right align in 10 chars:   1,234.56: and then more");

            // invalid alignment cases

            Assert.Throws(typeof(ArgumentException), () => { string.Format("{0,}", 12345.67); }, "Should throw with error message: Format error: empty alignment, column 3");
            Assert.Throws(typeof(ArgumentException), () => { string.Format("{0,a10}", 12345.67); }, "Should throw with error message: Format error: wrong symbol at alignment, column 3");
            Assert.Throws(typeof(ArgumentException), () => { string.Format("{0,-a10}", 12345.67); }, "Should throw with error message: Format error: wrong symbol at alignment, column 4");
            Assert.Throws(typeof(ArgumentException), () => { string.Format("{a}", 12345.67); }, "Should throw with error message: Format error: wrong symbol at {}, column 1");
            Assert.Throws(typeof(ArgumentException), () => { string.Format("{0:}", 12345.67); }, "Should throw with error message: Format error: empty format after ':', column 3");
            Assert.Throws(typeof(ArgumentException), () => { string.Format("{0", 12345.67); }, "Should throw with error message: Format error: no closed brace, column 2");

        }



        [TestMethod]
        // the D format can only be used with integers (no double or floats)
        public void DecimalFormat()
        {
            sampleDisplay = new SampleDisplay();
             
            TestFormat("  123", "D",     "123");
            TestFormat("  129", "D",     "129");
            TestFormat(" -129", "D",    "-129");
            TestFormat("  128", "D",     "128");
            TestFormat(" -128", "D",    "-128");
            TestFormat(" -128", "D2",   "-128");
            TestFormat(" 1234", "D2",   "1234");
            TestFormat("-1234", "D",   "-1234");  
            TestFormat(" 1234", "D6", "001234");
            TestFormat("-1234", "D6","-001234");

            sampleDisplay.WriteOutput();

        }

        
        [TestMethod]
        // the F format can be used with all number types
        public void FixedFormat()
        {
            sampleDisplay = new SampleDisplay();

            TestFormat("123", "F", "123.00");    // default for CultureInvariant is 2 decimal places
            TestFormat("129", "F", "129.00");
            TestFormat("-129", "F", "-129.00");
            TestFormat("128", "F", "128.00");
            TestFormat("128", "F4", "128.0000");  // bug - int gets different value than float/double
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

        [TestMethod]
        // the G format can be used with all number types
        public void GeneralFormat()
        {
            sampleDisplay = new SampleDisplay();

            TestFormat("123", "G", "123");
            TestFormat("129", "G", "129");
            TestFormat("-129", "G", "-129");
            TestFormat("128", "G", "128");
            TestFormat("128", "G4", "128");
            TestFormat("-128", "G", "-128");
            TestFormat("-128", "G2", "-1.3E+02");
            TestFormat("1234", "G2", "1.2E+03");
            TestFormat("-1234", "G", "-1234");
            TestFormat("1234", "G6", "1234");
            TestFormat("-1234", "G6", "-1234");
            TestFormat("123.78", "G3", "124");
            TestFormat("123.7841", "G5", "123.78");
            TestFormat("123.7851", "G5", "123.79");
            TestFormat("123.78", "G5", "123.78");
            TestFormat("123.78", "G4", "123.8");
            TestFormat("1234.8999", "G5", "1234.9");
            TestFormat("1234.8999", "G6", "1234.9");
            TestFormat("1234.8999", "G7", "1234.9");
            TestFormat("-1234.901", "G7", "-1234.901");

            sampleDisplay.WriteOutput();

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
            sampleDisplay.WriteOutput();
        }

        [TestMethod]
        // the X format can only be used with integer number types
        public void HexFormat()
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

            TestFormat("  128", "X4", "0080");
            TestFormat(" 1234", "X", "4D2");
            TestFormat(" 1234", "X6", "0004D2");
            TestFormat(" -127", "X", "81");
            TestFormat(" -128", "X", "80");
            TestFormat(" -128", "X4", "80");
            TestFormat(" -129", "X", "FF7F");
            TestFormat("-1234", "X", "FB2E");
            TestFormat("-1234", "X6", "FB2E");

            sampleDisplay.WriteOutput();
        }


        #region Helper functions
        private void TestFormat(string valueStr, string formatString, string expectedResult, Case formatCase=Case.Both)
        {
            double value = Double.Parse(valueStr);  // !!! does not return a negative number when parsed if string value does not contain a decimal point
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
                    Assert.True(false, "Invalid format case used");
                    break;
            }
        }

        private void TestFormatInner(string valueStr, string formatString, string expectedResult, NumType numType, bool isNegative)
        {
            SampleDisplay.RowData rowData = sampleDisplay.AddRow(valueStr, formatString);
            double value = Double.Parse(valueStr);
            if (value <= SByte.MaxValue
                && value >= SByte.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                )
            {
                CheckValue(SByte.Parse(valueStr), valueStr, formatString, expectedResult, SampleDisplay.ColumnType.SByte, rowData);
            }

            if (value <= Int16.MaxValue
                && value >= Int16.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                )
            {
                CheckValue(Int16.Parse(valueStr), valueStr, formatString, expectedResult, SampleDisplay.ColumnType.Int16, rowData);
            }

            if (value <= Int32.MaxValue
                && value >= Int32.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                )
            {
                CheckValue(Int32.Parse(valueStr), valueStr, formatString, expectedResult, SampleDisplay.ColumnType.Int32, rowData);
            }

            if (value <= Int64.MaxValue
                && value >= Int64.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                )
            {
                CheckValue(Int64.Parse(valueStr), valueStr, formatString, expectedResult, SampleDisplay.ColumnType.Int64, rowData);
            }

            if (value <= Byte.MaxValue
                && value >= Byte.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                && isNegative == false)
            {
                CheckValue(Byte.Parse(valueStr), valueStr, formatString, expectedResult, SampleDisplay.ColumnType.Byte, rowData);
            }

            if (value <= UInt16.MaxValue
                && value >= UInt16.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                && isNegative == false)
            {
                CheckValue(UInt16.Parse(valueStr), valueStr, formatString, expectedResult, SampleDisplay.ColumnType.UInt16, rowData);
            }

            if (value <= UInt32.MaxValue
                && value >= UInt32.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                && isNegative == false)
            {
                CheckValue(UInt32.Parse(valueStr), valueStr, formatString, expectedResult, SampleDisplay.ColumnType.UInt32, rowData);
            }

            if (value <= UInt64.MaxValue
                && value >= UInt64.MinValue
                && (numType == NumType.IntOnly || numType == NumType.All)
                && isNegative == false)
            {
                CheckValue(UInt64.Parse(valueStr), valueStr, formatString, expectedResult, SampleDisplay.ColumnType.UInt64, rowData);
            }

            if (value <= Single.MaxValue
                && value >= Single.MinValue
                && (numType == NumType.FloatDoubleOnly || numType == NumType.All)
                )
            {
                CheckValue(Single.Parse(valueStr), valueStr, formatString, expectedResult, SampleDisplay.ColumnType.Single, rowData);
            }

            if (value <= Double.MaxValue
                && value >= Double.MinValue
                && (numType == NumType.FloatDoubleOnly || numType == NumType.All)
                )
            {
                CheckValue(Double.Parse(valueStr), valueStr, formatString, expectedResult, SampleDisplay.ColumnType.Double, rowData);
            }


        }

        private void CheckValue(object value, string valueStr, string formatString, string expectedResult, SampleDisplay.ColumnType columnType, SampleDisplay.RowData rowData)
        {
            string result = String.Format($"{{0:{formatString}}}", new object[] { value });
            // for format of X if the number is negative there will be extra F's in the front depending on integer size.  
            // because of this we will only check the ending characters for format X types
            if (formatString.ToUpper()[0] == 'X')
            {
                Assert.EndsWith(expectedResult, result, $"The expected result for '{formatString}' on value {valueStr} for type {value.GetType().Name} should end with '{expectedResult}'");
            }
            else
            {
                Assert.Equal(result, expectedResult, $"The expected result for '{formatString}' on value {valueStr} for type {value.GetType().Name} is '{expectedResult}'");
            }
            rowData.SetResult(result, columnType);
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
            AddColumn("Value", SampleDisplay.ColumnType.Value);
            AddColumn("Format", SampleDisplay.ColumnType.FormatString);
            AddColumn("SByte", SampleDisplay.ColumnType.SByte);
            AddColumn("Int16", SampleDisplay.ColumnType.Int16);
            AddColumn("Int32", SampleDisplay.ColumnType.Int32);
            AddColumn("Int64", SampleDisplay.ColumnType.Int64);
            AddColumn("Byte", SampleDisplay.ColumnType.Byte);
            AddColumn("UInt16", SampleDisplay.ColumnType.UInt16);
            AddColumn("UInt32", SampleDisplay.ColumnType.UInt32);
            AddColumn("UInt64", SampleDisplay.ColumnType.UInt64);
            AddColumn("Single", SampleDisplay.ColumnType.Single);
            AddColumn("Double", SampleDisplay.ColumnType.Double);
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
                    Debug.Write(GetColumnInfo((ColumnType)i).ColumnHeader.PadLeft(GetColumnInfo((ColumnType)i).LargestLength + 1));  // +1 for an extra space between columns    
                }
            }
            Debug.WriteLine("");  // complete the line

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
                        Debug.Write(" " + rd.ColumnData[j].PadRight(GetColumnInfo((ColumnType)j).LargestLength));  // add " "for an extra space between columns    
                    }
                    else
                    {
                        Debug.Write(rd.ColumnData[j].PadLeft(GetColumnInfo((ColumnType)j).LargestLength + 1));  // +1 for an extra space between columns    
                    }
                }
                Debug.WriteLine("");  // complete the line
            }

        }

    }
        #endregion
}
