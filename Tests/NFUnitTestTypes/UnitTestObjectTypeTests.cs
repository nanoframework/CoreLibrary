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
            OutputHelper.WriteLine("Test of Object constructor");

            object o = new();
            Assert.NotNull(o, "failed to create an Object");
        }

        [TestMethod]
        public void TestEquals_01()
        {
            OutputHelper.WriteLine("Test01 of Object Equals");

            object objectX = new();
            object objectY = new();

            Assert.True(objectX.Equals(objectX), "Object should equal itself");
            Assert.True(!objectX.Equals(null), "object should not equal null");
            Assert.True(!objectX.Equals(objectY), "Different objects should not equal 1");
            Assert.True(!objectY.Equals(objectX), "Different objects should not equal 2");

            double doubleX = double.NaN;
            double doubleY = double.NaN;
            Assert.True(((object)doubleX).Equals(doubleY), "NaNs should always equal each other");
        }

        [TestMethod]
        public void TestEquals_02()
        {
            OutputHelper.WriteLine("Test02 of Object Equals overload");

            object objectX = new();
            object objectY = new();

            Assert.True(Equals(objectX, objectX), "Object should equal itself");
            Assert.True(!Equals(objectX, null), "object should not equal null");
            Assert.True(!Equals(null, objectX), "null should not equal object");
            Assert.True(!Equals(objectX, objectY), "Different objects should not equal 1");
            Assert.True(!Equals(objectY, objectX), "Different objects should not equal 2");
            Assert.True(Equals(null, null), "null should equal null");


            double doubleX = double.NaN;
            double doubleY = double.NaN;
            Assert.True(Equals(doubleX, doubleY), "NaNs should always equal each other");
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            OutputHelper.WriteLine("Test Object HashCode");

            object objectX = new();
            Assert.Equal(objectX.GetHashCode(), objectX.GetHashCode(), "Object's hash code should not change");
        }

        [TestMethod]
        public void TestGetType()
        {
            OutputHelper.WriteLine("Test getting Object type");

            object objectX = new();

            Assert.NotNull(objectX.GetType(), "Should get a type for Object");
            Assert.Equal(objectX.GetType().ToString(), "System.Object", "Wrong ToString from Object type");
        }

        [TestMethod]
        public void TestReferenceEquals()
        {
            OutputHelper.WriteLine("Test Object ReferenceEquals");

            object objectX = new();
            object objectY = new();

            Assert.True(ReferenceEquals(objectX, objectX), "Object should equal itself");
            Assert.True(!ReferenceEquals(objectX, null), "object should not equal null");
            Assert.True(!ReferenceEquals(null, objectX), "null should not equal object");
            Assert.True(!ReferenceEquals(objectX, objectY), "Different objects should not equal 1");
            Assert.True(!ReferenceEquals(objectY, objectX), "Different objects should not equal 2");
            Assert.True(ReferenceEquals(null, null), "null should not equal null");
        }

        [TestMethod]
        public void TestToString()
        {
            OutputHelper.WriteLine("Test Object ToString");

            object objectX = new();
            object objectY = new();

            Assert.Equal(objectX.ToString(), objectY.ToString(), "All Objects should have same string representation");
        }
    }
}
