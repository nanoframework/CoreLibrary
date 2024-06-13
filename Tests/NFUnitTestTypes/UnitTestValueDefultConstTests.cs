//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestTypes
{
    [TestClass]
    class UnitTestValueDefultConstTests
    {
        [TestMethod]
        public void ValueDefault_Const01_Test()
        {
            // Testing byte == 0
            ValueDefault_ConstTestClass01.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const02_Test()
        {
            // Testing short == 0
            ValueDefault_ConstTestClass02.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const03_Test()
        {
            // Testing int == 0
            ValueDefault_ConstTestClass03.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const04_Test()
        {
            // Testing long == 0L
            ValueDefault_ConstTestClass04.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const05_Test()
        {
            // Testing char == \x0000
            ValueDefault_ConstTestClass05.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const06_Test()
        {
            // Testing float == 0.0f
            ValueDefault_ConstTestClass06.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const07_Test()
        {
            // Testing double == 0.0d
            ValueDefault_ConstTestClass07.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const09_Test()
        {
            // Testing bool == false
            ValueDefault_ConstTestClass09.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const11_Test()
        {
            // Testing enum
            ValueDefault_ConstTestClass11.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const12_Test()
        {
            // Testing struct
            ValueDefault_ConstTestClass12.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const14_Test()
        {
            // Testing sbyte == 0
            ValueDefault_ConstTestClass14.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const15_Test()
        {
            // Testing ushort == 0
            ValueDefault_ConstTestClass15.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const16_Test()
        {
            // Testing uint == 0
            ValueDefault_ConstTestClass16.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const17_Test()
        {
            // Testing ulong == 0
            ValueDefault_ConstTestClass17.testMethod();
        }

        //Compiled Test Cases 
        public class ValueDefault_ConstTestClass01
        {
            public static void testMethod()
            {
                byte b = new byte();
                Assert.AreEqual(b, (byte)0);
            }
        }

        public class ValueDefault_ConstTestClass02
        {
            public static void testMethod()
            {
                short s = new short();
                Assert.AreEqual(s, (short)0);
            }
        }

        public class ValueDefault_ConstTestClass03
        {
            public static void testMethod()
            {
                int i = new int();
                Assert.AreEqual(i, 0);
            }
        }

        public class ValueDefault_ConstTestClass04
        {
            public static void testMethod()
            {
                long l = new long();
                Assert.AreEqual(l, 0L);
            }
        }

        public class ValueDefault_ConstTestClass05
        {
            public static void testMethod()
            {
                char c = new char();
                Assert.AreEqual(c, '\x0000');
            }
        }

        public class ValueDefault_ConstTestClass06
        {
            public static void testMethod()
            {
                float f = new float();
                Assert.AreEqual(f, 0.0f);
            }
        }

        public class ValueDefault_ConstTestClass07
        {
            public static void testMethod()
            {
                double d = new double();
                Assert.AreEqual(d, 0.0d);
            }
        }

        public class ValueDefault_ConstTestClass09
        {
            public static void testMethod()
            {
                bool b = new bool();
                Assert.AreEqual(b, false);
            }
        }

        enum E { a = 1, b = 2 };
        public class ValueDefault_ConstTestClass11
        {
            public static void testMethod()
            {
                E e = new E();
                if (e != ((E)0))
                {
                    throw new Exception("Enums are not equal");
                }
            }
        }

        struct MyStruct
        {
#pragma warning disable CS0649  // variable not initialized
            public int I;
            public Object MyObj;
#pragma warning restore CS0649  
        }

        public class ValueDefault_ConstTestClass12
        {
            public static void testMethod()
            {
                MyStruct TC = new MyStruct();
                if ((TC.I == 0) && (TC.MyObj == null))
                {
                    return;
                }

                throw new Exception("Elements not equal");
            }
        }

        public class ValueDefault_ConstTestClass14
        {
            public static void testMethod()
            {
                sbyte b = new sbyte();
                Assert.AreEqual(b, (sbyte)0);
            }
        }

        public class ValueDefault_ConstTestClass15
        {
            public static void testMethod()
            {
                ushort b = new ushort();
                Assert.AreEqual(b, (ushort)0);
            }
        }

        public class ValueDefault_ConstTestClass16
        {
            public static void testMethod()
            {
                uint b = new uint();
                Assert.AreEqual(b , (uint)0) ;
            }
        }

        public class ValueDefault_ConstTestClass17
        {
            public static void testMethod()
            {
                ulong b = new ulong();
                Assert.AreEqual(b, (ulong)0);
            }
        }

    }
}
