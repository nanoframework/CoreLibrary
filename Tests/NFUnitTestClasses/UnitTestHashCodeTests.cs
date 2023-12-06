//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System.Diagnostics;

namespace NFUnitTestClasses
{
    [TestClass]
    class UnitTestHashCodeTests
    {
        [TestMethod]
        public void HashCode_Test_01()
        {
            // generate a hash code for a class with fields
            SomeKey key = new(42);

            int hashCode = key.GetHashCode();

            OutputHelper.WriteLine($"Hash code for SomeKey(42) is {hashCode}");
            OutputHelper.WriteLine($"Hash code for SomeKey(42) is {key.GetHashCode()}");

            Assert.AreNotEqual(0, key.GetHashCode(), "Hash code for a class should not be 0");
            Assert.AreEqual($"{key.GetHashCode()}".GetHashCode(), $"{hashCode}".GetHashCode());
        }

        [TestMethod]
        public void HashCode_Test_02()
        {
            // generate a hash code for a class without fields
            SomeOtherKey key = new();

            int hashCode = key.GetHashCode();

            OutputHelper.WriteLine($"Hash code for SomeOtherKey is {hashCode}");
            OutputHelper.WriteLine($"Hash code for SomeOtherKey is {key.GetHashCode()}");

            Assert.AreNotEqual(0, key.GetHashCode(), "Hash code for a class should not be 0");
            Assert.AreEqual($"{key.GetHashCode()}".GetHashCode(), $"{hashCode}".GetHashCode());
        }

        [TestMethod]
        public void HashCode_Test_03()
        {
            // generate a hash code for a class with fields with different types
            SomeOtherFunnyKey key = new();

            int hashCode = key.GetHashCode();

            OutputHelper.WriteLine($"Hash code for SomeOtherFunnyKey is {hashCode}");
            OutputHelper.WriteLine($"Hash code for SomeOtherFunnyKey is {key.GetHashCode()}");

            Assert.AreNotEqual(0, key.GetHashCode(), "Hash code for a class should not be 0");
            Assert.AreEqual($"{key.GetHashCode()}".GetHashCode(), $"{hashCode}".GetHashCode());
        }

        public class SomeKey
        {
            public SomeKey(int value)
            {
                Value = value;
            }
            public int Value { get; }
        }

        public class SomeOtherKey
        {
            public SomeOtherKey()
            {
            }
        }

        public class SomeOtherFunnyKey
        {
            public string Name { get; set; }

            public int GetValue { get; set; }

            public SomeOtherFunnyKey()
            {
            }
        }

    }
}
