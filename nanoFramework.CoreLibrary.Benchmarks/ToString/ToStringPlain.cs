// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace nanoFramework.CoreLibrary.Benchmarks.ToString
{
    [IterationCount(5)]
    public class ToStringPlain
    {
        private int _intValue;
        private long _longValue;
        private double _doubleValue;
        private bool _boolValue;
        private byte _byteValue;
        private DateTime _dateTimeValue;

        [Setup]
        public void Setup()
        {
            _intValue = 12345;
            _longValue = 1234567890123456L;
            _doubleValue = 123.456;
            _boolValue = true;
            _byteValue = 255;
            _dateTimeValue = new DateTime(2024, 1, 15, 10, 30, 45);
        }

        [Benchmark]
        public void Int32ToString()
        {
            _ = _intValue.ToString();
        }

        [Benchmark]
        public void Int64ToString()
        {
            _ = _longValue.ToString();
        }

        [Benchmark]
        public void DoubleToString()
        {
            _ = _doubleValue.ToString();
        }

        [Benchmark]
        public void BooleanToString()
        {
            _ = _boolValue.ToString();
        }

        [Benchmark]
        public void ByteToString()
        {
            _ = _byteValue.ToString();
        }

        [Benchmark]
        public void DateTimeToString()
        {
            _ = _dateTimeValue.ToString();
        }
    }
}
