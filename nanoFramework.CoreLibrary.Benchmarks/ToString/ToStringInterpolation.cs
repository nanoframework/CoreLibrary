// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace nanoFramework.CoreLibrary.Benchmarks.ToString
{
    [IterationCount(5)]
    public class ToStringInterpolation
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
        public void Int32Interpolation()
        {
            _ = $"Value: {_intValue}";
        }

        [Benchmark]
        public void Int64Interpolation()
        {
            _ = $"Value: {_longValue}";
        }

        [Benchmark]
        public void DoubleInterpolation()
        {
            _ = $"Value: {_doubleValue}";
        }

        [Benchmark]
        public void BooleanInterpolation()
        {
            _ = $"Value: {_boolValue}";
        }

        [Benchmark]
        public void ByteInterpolation()
        {
            _ = $"Value: {_byteValue}";
        }

        [Benchmark]
        public void DateTimeInterpolation()
        {
            _ = $"Value: {_dateTimeValue}";
        }

        [Benchmark]
        public void MultipleValuesInterpolation()
        {
            _ = $"Int: {_intValue}, Double: {_doubleValue}, Bool: {_boolValue}";
        }

        [Benchmark]
        public void MixedInterpolation()
        {
            _ = $"String: {_stringValue}, Int: {_intValue}, DateTime: {_dateTimeValue}";
        }

        [Benchmark]
        public void ComplexInterpolation()
        {
            _ = $"Values - Byte: {_byteValue}, Long: {_longValue}, Double: {_doubleValue}, Bool: {_boolValue}";
        }
    }
}
