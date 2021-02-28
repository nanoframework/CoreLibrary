using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestTypes
{
    [TestClass]
    class UnitTestValueSimpleTests
    {
        [TestMethod]
        public void ValueSimple01_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" byte is an alias for System.Byte");
            ValueSimpleTestClass01.testMethod();
        }
        [TestMethod]
        public void ValueSimple02_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" char is an alias for System.Char");
            ValueSimpleTestClass02.testMethod();
        }
        [TestMethod]
        public void ValueSimple03_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" short is an alias for System.Int16");
            ValueSimpleTestClass03.testMethod();
        }
        [TestMethod]
        public void ValueSimple04_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" int is an alias for System.Int32");
            ValueSimpleTestClass04.testMethod();
        }
        [TestMethod]
        public void ValueSimple05_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" long is an alias for System.Int64");
            ValueSimpleTestClass05.testMethod();
        }
        [TestMethod]
        public void ValueSimple06_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" float is an alias for System.Single");
            ValueSimpleTestClass06.testMethod();
        }
        [TestMethod]
        public void ValueSimple07_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" double is an alias for System.Double");
            ValueSimpleTestClass07.testMethod();
        }
        [TestMethod]
        public void ValueSimple09_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" bool is an alias for System.Boolean");
            ValueSimpleTestClass09.testMethod();
        }
        [TestMethod]
        public void ValueSimple11_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" A simple type and the structure type it aliases are completely indistinguishable.");
            Debug.WriteLine(" In other words, writing the reserved work byte is exactly the same as writing ");
            Debug.WriteLine(" System.Byte, and writing System.Int32 is exactly the same as writing the reserved");
            Debug.WriteLine(" word int.");
            ValueSimpleTestClass11.testMethod();
        }
        [TestMethod]
        public void ValueSimple12_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" Because a simple type aliases a struct type, every simple type has members.");
            ValueSimpleTestClass12.testMethod();
        }
        [TestMethod]
        public void ValueSimple13_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" sbyte is an alias for System.SByte");
            ValueSimpleTestClass13.testMethod();
        }
        [TestMethod]
        public void ValueSimple14_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" ushort is an alias for System.UInt16");
            ValueSimpleTestClass14.testMethod();
        }
        [TestMethod]
        public void ValueSimple15_Test()
        {
            Debug.WriteLine(" Section 4.1");
            Debug.WriteLine(" uint is an alias for System.UInt32");
            ValueSimpleTestClass15.testMethod();
        }


        //Compiled Test Cases 
        public class ValueSimpleTestClass01
        {
            public static void testMethod()
            {
                byte b = 0;
                Assert.IsType(b.GetType(), Type.GetType("System.Byte"));
            }
        }
        public class ValueSimpleTestClass02
        {
            public static void testMethod()
            {
                char c = 'a';
                Assert.IsType(c.GetType(), Type.GetType("System.Char"));
            }
        }
        public class ValueSimpleTestClass03
        {
            public static void testMethod()
            {
                short s = 0;
                Assert.IsType(s.GetType(), Type.GetType("System.Int16"));
            }
        }
        public class ValueSimpleTestClass04
        {
            public static void testMethod()
            {
                int i = 0;
                Assert.IsType(i.GetType(), Type.GetType("System.Int32"));
            }
        }
        public class ValueSimpleTestClass05
        {
            public static void testMethod()
            {
                long l = 0L;
                Assert.IsType(l.GetType(), Type.GetType("System.Int64"));
            }
        }
        public class ValueSimpleTestClass06
        {
            public static void testMethod()
            {
                float f = 0.0f;
                Assert.IsType(f.GetType(), Type.GetType("System.Single"));
            }
        }
        public class ValueSimpleTestClass07
        {
            public static void testMethod()
            {
                double d = 0.0d;
                Assert.IsType(d.GetType(), Type.GetType("System.Double"));
            }
        }
        public class ValueSimpleTestClass09
        {
            public static void testMethod()
            {
                bool b = true;
                Assert.IsType(b.GetType(), Type.GetType("System.Boolean"));
            }
        }
        public class ValueSimpleTestClass11
        {
            public static void testMethod()
            {
                System.Byte b = 2;
                System.Int32 i = 2;
                Assert.Equal(b, (System.Byte)2);
                Assert.Equal(i, 2);
            }
        }
        public class ValueSimpleTestClass12
        {
            public static void testMethod()
            {
                int i = int.MaxValue;
                Assert.Equal(i, Int32.MaxValue);
                string s = i.ToString();
                Assert.True(s.Equals(Int32.MaxValue.ToString()));
                i = 123;
                string t = 123.ToString();
                Assert.True(t.Equals(i.ToString()));
            }
        }
        public class ValueSimpleTestClass13
        {
            public static void testMethod()
            {
                sbyte b = 0;
                Assert.IsType(b.GetType(), Type.GetType("System.SByte"));
            }
        }
        public class ValueSimpleTestClass14
        {
            public static void testMethod()
            {
                ushort s = 0;
                Assert.IsType(s.GetType(), Type.GetType("System.UInt16"));
            }
        }
        public class ValueSimpleTestClass15
        {
            public static void testMethod()
            {
                uint i = 0;
                Assert.IsType(i.GetType(), Type.GetType("System.UInt32"));
            }
        }

    }
}
