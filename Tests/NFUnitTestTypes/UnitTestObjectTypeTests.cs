// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

namespace NFUnitTestTypes
{
    [TestClass]
    class UnitTestObjectTypeTests
    {
        [TestMethod]
        public void TestCtor()
        {
            // Test of Object constructor

            object o = new();
#pragma warning disable S3236 // Caller information arguments should not be provided explicitly
            Assert.IsNotNull(o, "failed to create an Object");
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly
        }

        [TestMethod]
        public void TestEquals_01()
        {
            // Test01 of Object Equals

            object objectX = new();
            object objectY = new();

            // Caller information arguments should not be provided explicitly
            // Identical expressions should not be used on both sides of operators
            // on purpose to test the Equals overload
#pragma warning disable S3236 
#pragma warning disable S1764 
            Assert.IsTrue(objectX.Equals(objectX), "Object should equal itself");
            Assert.IsTrue(!objectX.Equals(null), "object should not equal null");
            Assert.IsTrue(!objectX.Equals(objectY), "Different objects should not equal 1");
            Assert.IsTrue(!objectY.Equals(objectX), "Different objects should not equal 2");

            double doubleX = double.NaN;
            double doubleY = double.NaN;
            Assert.IsTrue(((object)doubleX).Equals(doubleY), "NaNs should always equal each other");
#pragma warning restore S1764 // Identical expressions should not be used on both sides of operators
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly
        }

        [TestMethod]
        public void TestEquals_02()
        {
            // Test02 of Object Equals overload

            object objectX = new();
            object objectY = new();

            // Caller information arguments should not be provided explicitly
            // Identical expressions should not be used on both sides of operators
            // on purpose to test the Equals overload
#pragma warning disable S3236 
#pragma warning disable S1764 
            Assert.IsTrue(Equals(objectX, objectX), "Object should equal itself");
            Assert.IsTrue(!Equals(objectX, null), "object should not equal null");
            Assert.IsTrue(!Equals(null, objectX), "null should not equal object");
            Assert.IsTrue(!Equals(objectX, objectY), "Different objects should not equal 1");
            Assert.IsTrue(!Equals(objectY, objectX), "Different objects should not equal 2");
            Assert.IsTrue(Equals(null, null), "null should equal null");
#pragma warning restore S1764 // Identical expressions should not be used on both sides of operators
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly


            double doubleX = double.NaN;
            double doubleY = double.NaN;
#pragma warning disable S3236 // Caller information arguments should not be provided explicitly
            Assert.IsTrue(Equals(doubleX, doubleY), "NaNs should always equal each other");
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            // Test Object HashCode

            object objectX = new();
#pragma warning disable S3236 // Caller information arguments should not be provided explicitly
            Assert.AreEqual(objectX.GetHashCode(), objectX.GetHashCode(), "Object's hash code should not change");
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly
        }

        [TestMethod]
        public void TestGetType()
        {
            // Test getting Object type

            object objectX = new();

#pragma warning disable S3236 // Caller information arguments should not be provided explicitly
            Assert.IsNotNull(objectX.GetType(), "Should get a type for Object");
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly
#pragma warning disable S3236 // Caller information arguments should not be provided explicitly
            Assert.AreEqual(objectX.GetType().ToString(), "System.Object", "Wrong ToString from Object type");
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly
        }

        [TestMethod]
        public void TestReferenceEquals()
        {
            // Test Object ReferenceEquals

            object objectX = new();
            object objectY = new();

            // Caller information arguments should not be provided explicitly
            // on purpose to test the ReferenceEquals overload
#pragma warning disable S3236 
            Assert.IsTrue(ReferenceEquals(objectX, objectX), "Object should equal itself");
            Assert.IsTrue(!ReferenceEquals(objectX, null), "object should not equal null");
            Assert.IsTrue(!ReferenceEquals(null, objectX), "null should not equal object");
            Assert.IsTrue(!ReferenceEquals(objectX, objectY), "Different objects should not equal 1");
            Assert.IsTrue(!ReferenceEquals(objectY, objectX), "Different objects should not equal 2");
            Assert.IsTrue(ReferenceEquals(null, null), "null should not equal null");
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly
        }

        [TestMethod]
        public void TestToString()
        {
            // Test Object ToString

            object objectX = new();
            object objectY = new();

#pragma warning disable S3236 // Caller information arguments should not be provided explicitly
            Assert.AreEqual(objectX.ToString(), objectY.ToString(), "All Objects should have same string representation");
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly
        }
    }
}
