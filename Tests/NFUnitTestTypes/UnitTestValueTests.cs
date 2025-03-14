﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

namespace NFUnitTestTypes
{
    [TestClass]
    class UnitTestValueTests
    {
        [TestMethod]
        public void Value7_Test()
        {
            ValueTestClass7.testMethod();
        }

        [TestMethod]
        public void Value8_Test()
        {
            ValueTestClass8.testMethod();
        }

        [TestMethod]
        public void Value9_Test()
        {
            ValueTestClass9.testMethod();
        }

        //Compiled Test Cases 
        public struct ValueTestClass7_Struct
        {
            public int MyInt;
        }

        public class ValueTestClass7
        {
            public static void testMethod()
            {
                ValueTestClass7_Struct MS = new ValueTestClass7_Struct();
                ValueTestClass7_Struct MS2;

                MS.MyInt = 3;
                MS2 = MS;
                MS.MyInt = 4;

                Assert.AreEqual(MS2.MyInt, 3);
            }
        }

        public class ValueTestClass8
        {
            public static void testMethod()
            {
                int MyInt;
                int MyInt2;

                MyInt = 3;
                MyInt2 = MyInt;
                MyInt = 4;
                Assert.AreEqual(MyInt2, 3);
            }
        }

        enum ValueTestClass9_Enum { a = 1, b = 2 }

        public class ValueTestClass9
        {
            public static void testMethod()
            {
                ValueTestClass9_Enum Enum1;
                ValueTestClass9_Enum Enum2;
                Enum1 = ValueTestClass9_Enum.a;
                Enum2 = Enum1;
                Enum1 = ValueTestClass9_Enum.b;
                Assert.AreEqual((int)Enum2, (int)ValueTestClass9_Enum.a);
            }
        }

    }
}
