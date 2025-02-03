// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

#nullable enable
namespace NFUnitTestException
{
    [TestClass]
    public class ArgumentExceptionTests
    {
        [TestMethod]
        public void ctor_sets_correct_message_with_parameter()
        {
            const string parameter = nameof(ctor_sets_correct_message_with_parameter);
            const string expected = $"Value does not fall within the expected range. (Parameter '{parameter}')";

            var ex1 = new ArgumentException(null, parameter);
            var ex2 = new ArgumentException(null, parameter, (Exception?)null);

            Assert.AreEqual(expected, ex1.Message);
            Assert.AreEqual(expected, ex2.Message);
        }

        [TestMethod]
        public void ctor_sets_correct_message_without_parameter()
        {
            const string expected = "Value does not fall within the expected range.";

            var ex1 = new ArgumentException();
            var ex2 = new ArgumentException(null);
            var ex3 = new ArgumentException(null, (Exception?)null);
            var ex4 = new ArgumentException(null, (string?)null);
            var ex5 = new ArgumentException(null, (string?)null, (Exception?)null);

            Assert.AreEqual(expected, ex1.Message);
            Assert.AreEqual(expected, ex2.Message);
            Assert.AreEqual(expected, ex3.Message);
            Assert.AreEqual(expected, ex4.Message);
            Assert.AreEqual(expected, ex5.Message);
        }

        [TestMethod]
        public void ThrowIfNullOrEmpty_throws_ArgumentException_if_empty_string()
        {
            Assert.ThrowsException(typeof(ArgumentException), () => ArgumentException.ThrowIfNullOrEmpty(string.Empty));
        }

        [TestMethod]
        public void ThrowIfNullOrEmpty_throws_ArgumentNullException_if_null()
        {
            Assert.ThrowsException(typeof(ArgumentNullException), () => ArgumentException.ThrowIfNullOrEmpty(null));
        }
    }
}
