// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestTypes
{
    [TestClass]
    class UnitTestValueSimpleTests
    {
        [TestMethod]
        public void ValueSimple01_Test()
        {
            //  Section 4.1
            //  byte is an alias for System.Byte
            ValueSimpleTestClass01.testMethod();
        }
        [TestMethod]
        public void ValueSimple02_Test()
        {
            //  Section 4.1
            //  char is an alias for System.Char
            ValueSimpleTestClass02.testMethod();
        }
        [TestMethod]
        public void ValueSimple03_Test()
        {
            //  Section 4.1
            //  short is an alias for System.Int16
            ValueSimpleTestClass03.testMethod();
        }
        [TestMethod]
        public void ValueSimple04_Test()
        {
            //  Section 4.1
            //  int is an alias for System.Int32
            ValueSimpleTestClass04.testMethod();
        }
        [TestMethod]
        public void ValueSimple05_Test()
        {
            //  Section 4.1
            //  long is an alias for System.Int64
            ValueSimpleTestClass05.testMethod();
        }
        [TestMethod]
        public void ValueSimple06_Test()
        {
            //  Section 4.1
            //  float is an alias for System.Single
            ValueSimpleTestClass06.testMethod();
        }
        [TestMethod]
        public void ValueSimple07_Test()
        {
            //  Section 4.1
            //  double is an alias for System.Double
            ValueSimpleTestClass07.testMethod();
        }
        [TestMethod]
        public void ValueSimple09_Test()
        {
            //  Section 4.1
            //  bool is an alias for System.Boolean
            ValueSimpleTestClass09.testMethod();
        }
        [TestMethod]
        public void ValueSimple11_Test()
        {
            //  Section 4.1
            //  A simple type and the structure type it aliases are completely indistinguishable.
            //  In other words, writing the reserved work byte is exactly the same as writing 
            //  System.Byte, and writing System.Int32 is exactly the same as writing the reserved
            //  word int.
            ValueSimpleTestClass11.testMethod();
        }
        [TestMethod]
        public void ValueSimple12_Test()
        {
            //  Section 4.1
            //  Because a simple type aliases a struct type, every simple type has members.
            ValueSimpleTestClass12.testMethod();
        }
        [TestMethod]
        public void ValueSimple13_Test()
        {
            //  Section 4.1
            //  sbyte is an alias for System.SByte
            ValueSimpleTestClass13.testMethod();
        }
        [TestMethod]
        public void ValueSimple14_Test()
        {
            //  Section 4.1
            //  ushort is an alias for System.UInt16
            ValueSimpleTestClass14.testMethod();
        }
        [TestMethod]
        public void ValueSimple15_Test()
        {
            //  Section 4.1
            //  uint is an alias for System.UInt32
            ValueSimpleTestClass15.testMethod();
        }


        //Compiled Test Cases 
        public class ValueSimpleTestClass01
        {
            public static void testMethod()
            {
                Assert.IsInstanceOfType(Type.GetType("System.Byte"), typeof(byte));
            }
        }
        public class ValueSimpleTestClass02
        {
            public static void testMethod()
            {
                Assert.IsInstanceOfType(Type.GetType("System.Char"), typeof(char));
            }
        }
        public class ValueSimpleTestClass03
        {
            public static void testMethod()
            {
                Assert.IsInstanceOfType(Type.GetType("System.Int16"), typeof(short));
            }
        }
        public class ValueSimpleTestClass04
        {
            public static void testMethod()
            {
                Assert.IsInstanceOfType(Type.GetType("System.Int32"), typeof(int));
            }
        }
        public class ValueSimpleTestClass05
        {
            public static void testMethod()
            {
                Assert.IsInstanceOfType(Type.GetType("System.Int64"), typeof(long));
            }
        }
        public class ValueSimpleTestClass06
        {
            public static void testMethod()
            {
                Assert.IsInstanceOfType(Type.GetType("System.Single"), typeof(float));
            }
        }
        public class ValueSimpleTestClass07
        {
            public static void testMethod()
            {
                Assert.IsInstanceOfType(Type.GetType("System.Double"), typeof(double));
            }
        }
        public class ValueSimpleTestClass09
        {
            public static void testMethod()
            {
                Assert.IsInstanceOfType(Type.GetType("System.Boolean"), typeof(bool));
            }
        }
        public class ValueSimpleTestClass11
        {
            public static void testMethod()
            {
                System.Byte b = 2;
                System.Int32 i = 2;
                Assert.AreEqual(b, (System.Byte)2);
                Assert.AreEqual(i, 2);
            }
        }
        public class ValueSimpleTestClass12
        {
            public static void testMethod()
            {
                int i = int.MaxValue;
                Assert.AreEqual(i, Int32.MaxValue);
                string s = i.ToString();
                Assert.IsTrue(s.Equals(Int32.MaxValue.ToString()));
                i = 123;
                string t = 123.ToString();
                Assert.IsTrue(t.Equals(i.ToString()));
            }
        }
        public class ValueSimpleTestClass13
        {
            public static void testMethod()
            {
                Assert.IsInstanceOfType(Type.GetType("System.SByte"), typeof(sbyte));
            }
        }
        public class ValueSimpleTestClass14
        {
            public static void testMethod()
            {
                Assert.IsInstanceOfType(Type.GetType("System.UInt16"), typeof(ushort));
            }
        }
        public class ValueSimpleTestClass15
        {
            public static void testMethod()
            {
                Assert.IsInstanceOfType(Type.GetType("System.UInt32"), typeof(uint));
            }
        }

    }
}
