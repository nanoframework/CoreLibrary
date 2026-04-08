// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestTypes
{
    [TestClass]
    public class ValueArrayTypes
    {
        [TestMethod]
        public void ValueArray01_Test()
        {
            //  Section 4.1
            //  byte is an alias for System.Byte
            ValueArrayTestClass01.testMethod();
        }

        [TestMethod]
        public void ValueArray02_Test()
        {
            //  Section 4.1
            //  char is an alias for System.Char
            ValueArrayTestClass02.testMethod();
        }

        [TestMethod]
        public void ValueArray03_Test()
        {
            //  Section 4.1
            //  short is an alias for System.Int16
            ValueArrayTestClass03.testMethod();
        }

        [TestMethod]
        public void ValueArray04_Test()
        {
            //  Section 4.1
            //  int is an alias for System.Int32
            ValueArrayTestClass04.testMethod();
        }

        [TestMethod]
        public void ValueArray05_Test()
        {
            //  Section 4.1
            //  long is an alias for System.Int64
            ValueArrayTestClass05.testMethod();
        }

        [TestMethod]
        public void ValueArray06_Test()
        {
            //  Section 4.1
            //  float is an alias for System.Single
            ValueArrayTestClass06.testMethod();
        }

        [TestMethod]
        public void ValueArray07_Test()
        {
            //  Section 4.1
            //  double is an alias for System.Double
            ValueArrayTestClass07.testMethod();
        }
        [TestMethod]
        public void ValueArray09_Test()
        {
            //  Section 4.1
            //  bool is an alias for System.Boolean
            ValueArrayTestClass09.testMethod();
        }

        [TestMethod]
        public void ValueArray12_Test()
        {
            //  Section 4.1
            //  Because a simple type aliases a struct type, every simple type has members.
            // This test is expected to fail
            ValueArrayTestClass12.testMethod();
        }

        [TestMethod]
        public void ValueArray13_Test()
        {
            //  Section 4.1
            //  sbyte is an alias for System.SByte
            ValueArrayTestClass13.testMethod();
        }

        [TestMethod]
        public void ValueArray14_Test()
        {
            //  Section 4.1
            //  ushort is an alias for System.UInt16
            ValueArrayTestClass14.testMethod();
        }
        [TestMethod]
        public void ValueArray15_Test()
        {
            //  Section 4.1
            //  uint is an alias for System.UInt32
            ValueArrayTestClass15.testMethod();
        }


        //Compiled Test Cases 
        public class ValueArrayTestClass01
        {
            public static void testMethod()
            {
                byte[] b = { 0 };
                Type compareType = Type.GetType("System.Byte[]");
                Assert.IsInstanceOfType(b, compareType, $"The type {compareType.Name} is not equal to {b.GetType().Name}");
            }
        }
        public class ValueArrayTestClass02
        {
            public static void testMethod()
            {
                char[] c = { 'a' };
                Assert.IsInstanceOfType(c, Type.GetType("System.Char[]"));
            }
        }
        public class ValueArrayTestClass03
        {
            public static void testMethod()
            {
                short[] s = { 0 };
                Assert.IsInstanceOfType(s, Type.GetType("System.Int16[]"));
            }
        }
        public class ValueArrayTestClass04
        {
            public static void testMethod()
            {
                int[] i = { 0 };
                Assert.IsInstanceOfType(i, Type.GetType("System.Int32[]"));
            }
        }
        public class ValueArrayTestClass05
        {
            public static void testMethod()
            {
                long[] l = { 0L };
                Assert.IsInstanceOfType(l, Type.GetType("System.Int64[]"));
            }
        }
        public class ValueArrayTestClass06
        {
            public static void testMethod()
            {
                float[] f = { 0.0f };
                Assert.IsInstanceOfType(f, Type.GetType("System.Single[]"));
            }
        }
        public class ValueArrayTestClass07
        {
            public static void testMethod()
            {
                double[] d = { 0.0d };
                Assert.IsInstanceOfType(d, Type.GetType("System.Double[]"));
            }
        }
        public class ValueArrayTestClass09
        {
            public static void testMethod()
            {
                bool[] b = { true };
                Assert.IsInstanceOfType(b, Type.GetType("System.Boolean[]"));
            }
        }

        public class ValueArrayTestClass12
        {
            public static void testMethod()
            {
                string[] strArray = { "string" };
                Assert.IsInstanceOfType(strArray, Type.GetType("System.String[]"));
            }
        }
        public class ValueArrayTestClass13
        {
            public static void testMethod()
            {
                sbyte[] sb = { 0 };
                Assert.IsInstanceOfType(sb, Type.GetType("System.SByte[]"));
            }
        }
        public class ValueArrayTestClass14
        {
            public static void testMethod()
            {
                ushort[] us = { 0 };
                Assert.IsInstanceOfType(us, Type.GetType("System.UInt16[]"));
            }
        }
        public class ValueArrayTestClass15
        {
            public static void testMethod()
            {
                uint[] ui = { 0 };
                Assert.IsInstanceOfType(ui, Type.GetType("System.UInt32[]"));
            }
        }

    }
}
