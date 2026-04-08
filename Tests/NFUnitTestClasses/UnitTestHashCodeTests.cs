// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

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
