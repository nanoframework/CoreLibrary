//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;

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

                Assert.Equal(MS2.MyInt, 3);
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
                Assert.Equal(MyInt2, 3);
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
                Assert.Equal((int)Enum2, (int)ValueTestClass9_Enum.a);
            }
        }

    }
}
