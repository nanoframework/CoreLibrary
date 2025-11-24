// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;

namespace nanoFramework.CoreLibrary.Benchmarks.ToString
{
    [IterationCount(5)]
    public class ToStringConcatenation
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
        public void Int32Concatenation()
        {
            _ = "Value: " + _intValue;
        }

        [Benchmark]
        public void Int64Concatenation()
        {
            _ = "Value: " + _longValue;
        }

        [Benchmark]
        public void DoubleConcatenation()
        {
            _ = "Value: " + _doubleValue;
        }

        [Benchmark]
        public void BooleanConcatenation()
        {
            _ = "Value: " + _boolValue;
        }

        [Benchmark]
        public void ByteConcatenation()
        {
            _ = "Value: " + _byteValue;
        }

        [Benchmark]
        public void DateTimeConcatenation()
        {
            _ = "Value: " + _dateTimeValue;
        }

        [Benchmark]
        public void MultipleValuesConcatenation()
        {
            _ = "Int: " + _intValue + ", Double: " + _doubleValue + ", Bool: " + _boolValue;
        }

        [Benchmark]
        public void MixedConcatenation()
        {
            _ = "String: " + _stringValue + ", Int: " + _intValue + ", DateTime: " + _dateTimeValue;
        }

        [Benchmark]
        public void ComplexConcatenation()
        {
            _ = "Values - Byte: " + _byteValue + ", Long: " + _longValue + ", Double: " + _doubleValue + ", Bool: " + _boolValue;
        }

        [Benchmark]
        public void ExplicitToStringConcatenation()
        {
            _ = "Value: " + _intValue.ToString();
        }

        [Benchmark]
        public void MultipleExplicitToStringConcatenation()
        {
            _ = "Int: " + _intValue.ToString() + ", Double: " + _doubleValue.ToString() + ", Bool: " + _boolValue.ToString();
        }
    }
}
