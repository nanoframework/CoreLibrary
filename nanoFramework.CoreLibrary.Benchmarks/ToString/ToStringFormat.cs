// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace nanoFramework.CoreLibrary.Benchmarks.ToString
{
    [IterationCount(5)]
    public class ToStringFormat
    {
        private int _intValue;
        private long _longValue;
        private double _doubleValue;
        private bool _boolValue;
        private byte _byteValue;
        private DateTime _dateTimeValue;
        private string _stringValue;

        [Setup]
        public void Setup()
        {
            _intValue = 12345;
            _longValue = 1234567890123456L;
            _doubleValue = 123.456;
            _boolValue = true;
            _byteValue = 255;
            _dateTimeValue = new DateTime(2024, 1, 15, 10, 30, 45);
            _stringValue = "test";
        }

        [Benchmark]
        public void Int32Format()
        {
            _ = string.Format("Value: {0}", _intValue);
        }

        [Benchmark]
        public void Int64Format()
        {
            _ = string.Format("Value: {0}", _longValue);
        }

        [Benchmark]
        public void DoubleFormat()
        {
            _ = string.Format("Value: {0}", _doubleValue);
        }

        [Benchmark]
        public void BooleanFormat()
        {
            _ = string.Format("Value: {0}", _boolValue);
        }

        [Benchmark]
        public void ByteFormat()
        {
            _ = string.Format("Value: {0}", _byteValue);
        }

        [Benchmark]
        public void DateTimeFormat()
        {
            _ = string.Format("Value: {0}", _dateTimeValue);
        }

        [Benchmark]
        public void MultipleValuesFormat()
        {
            _ = string.Format("Int: {0}, Double: {1}, Bool: {2}", _intValue, _doubleValue, _boolValue);
        }

        [Benchmark]
        public void MixedFormat()
        {
            _ = string.Format("String: {0}, Int: {1}, DateTime: {2}", _stringValue, _intValue, _dateTimeValue);
        }

        [Benchmark]
        public void ComplexFormat()
        {
            _ = string.Format("Values - Byte: {0}, Long: {1}, Double: {2}, Bool: {3}", _byteValue, _longValue, _doubleValue, _boolValue);
        }

        [Benchmark]
        public void ReorderedFormat()
        {
            _ = string.Format("Values: {2}, {1}, {0}", _intValue, _doubleValue, _boolValue);
        }

        [Benchmark]
        public void RepeatedFormat()
        {
            _ = string.Format("Value {0} repeated: {0}, {0}", _intValue);
        }
    }
}
