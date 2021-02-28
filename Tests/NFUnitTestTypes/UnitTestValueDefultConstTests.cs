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
            Debug.WriteLine("Testing byte == 0");
            ValueDefault_ConstTestClass01.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const02_Test()
        {
            Debug.WriteLine("Testing short == 0");
            ValueDefault_ConstTestClass02.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const03_Test()
        {
            Debug.WriteLine("Testing int == 0");
            ValueDefault_ConstTestClass03.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const04_Test()
        {
            Debug.WriteLine("Testing long == 0L");
            ValueDefault_ConstTestClass04.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const05_Test()
        {
            Debug.WriteLine("Testing char == \x0000");
            ValueDefault_ConstTestClass05.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const06_Test()
        {
            Debug.WriteLine("Testing float == 0.0f");
            ValueDefault_ConstTestClass06.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const07_Test()
        {
            Debug.WriteLine("Testing double == 0.0d");
            ValueDefault_ConstTestClass07.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const09_Test()
        {
            Debug.WriteLine("Testing bool == false");
            ValueDefault_ConstTestClass09.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const11_Test()
        {
            Debug.WriteLine("Testing enum");
            ValueDefault_ConstTestClass11.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const12_Test()
        {
            Debug.WriteLine("Testing struct");
            ValueDefault_ConstTestClass12.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const14_Test()
        {
            Debug.WriteLine("Testing sbyte == 0");
            ValueDefault_ConstTestClass14.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const15_Test()
        {
            Debug.WriteLine("Testing ushort == 0");
            ValueDefault_ConstTestClass15.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const16_Test()
        {
            Debug.WriteLine("Testing uint == 0");
            ValueDefault_ConstTestClass16.testMethod();
        }

        [TestMethod]
        public void ValueDefault_Const17_Test()
        {
            Debug.WriteLine("Testing ulong == 0");
            ValueDefault_ConstTestClass17.testMethod();
        }

        //Compiled Test Cases 
        public class ValueDefault_ConstTestClass01
        {
            public static void testMethod()
            {
                byte b = new byte();
                Assert.Equal(b, (byte)0);
            }
        }

        public class ValueDefault_ConstTestClass02
        {
            public static void testMethod()
            {
                short s = new short();
                Assert.Equal(s, (short)0);
            }
        }

        public class ValueDefault_ConstTestClass03
        {
            public static void testMethod()
            {
                int i = new int();
                Assert.Equal(i, 0);
            }
        }

        public class ValueDefault_ConstTestClass04
        {
            public static void testMethod()
            {
                long l = new long();
                Assert.Equal(l, 0L);
            }
        }

        public class ValueDefault_ConstTestClass05
        {
            public static void testMethod()
            {
                char c = new char();
                Assert.Equal(c, '\x0000');
            }
        }

        public class ValueDefault_ConstTestClass06
        {
            public static void testMethod()
            {
                float f = new float();
                Assert.Equal(f, 0.0f);
            }
        }

        public class ValueDefault_ConstTestClass07
        {
            public static void testMethod()
            {
                double d = new double();
                Assert.Equal(d, 0.0d);
            }
        }

        public class ValueDefault_ConstTestClass09
        {
            public static void testMethod()
            {
                bool b = new bool();
                Assert.Equal(b, false);
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
            public int I;
            public Object MyObj;
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
                Assert.Equal(b, (sbyte)0);
            }
        }

        public class ValueDefault_ConstTestClass15
        {
            public static void testMethod()
            {
                ushort b = new ushort();
                Assert.Equal(b, (ushort)0);
            }
        }

        public class ValueDefault_ConstTestClass16
        {
            public static void testMethod()
            {
                uint b = new uint();
                Assert.Equal(b , (uint)0) ;
            }
        }

        public class ValueDefault_ConstTestClass17
        {
            public static void testMethod()
            {
                ulong b = new ulong();
                Assert.Equal(b, (ulong)0);
            }
        }

    }
}
