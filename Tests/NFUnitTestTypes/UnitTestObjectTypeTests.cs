//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;

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
            Assert.IsNotNull(o, "failed to create an Object");
        }

        [TestMethod]
        public void TestEquals_01()
        {
            // Test01 of Object Equals

            object objectX = new();
            object objectY = new();

            Assert.IsTrue(objectX.Equals(objectX), "Object should equal itself");
            Assert.IsTrue(!objectX.Equals(null), "object should not equal null");
            Assert.IsTrue(!objectX.Equals(objectY), "Different objects should not equal 1");
            Assert.IsTrue(!objectY.Equals(objectX), "Different objects should not equal 2");

            double doubleX = double.NaN;
            double doubleY = double.NaN;
            Assert.IsTrue(((object)doubleX).Equals(doubleY), "NaNs should always equal each other");
        }

        [TestMethod]
        public void TestEquals_02()
        {
            // Test02 of Object Equals overload

            object objectX = new();
            object objectY = new();

            Assert.IsTrue(Equals(objectX, objectX), "Object should equal itself");
            Assert.IsTrue(!Equals(objectX, null), "object should not equal null");
            Assert.IsTrue(!Equals(null, objectX), "null should not equal object");
            Assert.IsTrue(!Equals(objectX, objectY), "Different objects should not equal 1");
            Assert.IsTrue(!Equals(objectY, objectX), "Different objects should not equal 2");
            Assert.IsTrue(Equals(null, null), "null should equal null");


            double doubleX = double.NaN;
            double doubleY = double.NaN;
            Assert.IsTrue(Equals(doubleX, doubleY), "NaNs should always equal each other");
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            // Test Object HashCode

            object objectX = new();
            Assert.AreEqual(objectX.GetHashCode(), objectX.GetHashCode(), "Object's hash code should not change");
        }

        [TestMethod]
        public void TestGetType()
        {
            // Test getting Object type

            object objectX = new();

            Assert.IsNotNull(objectX.GetType(), "Should get a type for Object");
            Assert.AreEqual(objectX.GetType().ToString(), "System.Object", "Wrong ToString from Object type");
        }

        [TestMethod]
        public void TestReferenceEquals()
        {
            // Test Object ReferenceEquals

            object objectX = new();
            object objectY = new();

            Assert.IsTrue(ReferenceEquals(objectX, objectX), "Object should equal itself");
            Assert.IsTrue(!ReferenceEquals(objectX, null), "object should not equal null");
            Assert.IsTrue(!ReferenceEquals(null, objectX), "null should not equal object");
            Assert.IsTrue(!ReferenceEquals(objectX, objectY), "Different objects should not equal 1");
            Assert.IsTrue(!ReferenceEquals(objectY, objectX), "Different objects should not equal 2");
            Assert.IsTrue(ReferenceEquals(null, null), "null should not equal null");
        }

        [TestMethod]
        public void TestToString()
        {
            // Test Object ToString

            object objectX = new();
            object objectY = new();

            Assert.AreEqual(objectX.ToString(), objectY.ToString(), "All Objects should have same string representation");
        }
    }
}
