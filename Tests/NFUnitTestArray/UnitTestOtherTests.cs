// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestArray
{
    [TestClass]
    public class UnitTestOtherTests
    {
        [TestMethod]
        public void Othersystemarrays_conversion_01_Test()
        {
            // System.Array Type - Conversions 
            // Verify that an implicit reference conversion from T[D] to System.Array exists
            Assert.IsTrue(Other_TestClass_systemarrays_conversion_01.testMethod());
        }

        [TestMethod]
        public void Othersystemarrays_conversion_02_Test()
        {
            // System.Array Type - Conversions 
            // Verify that an explicit reference conversion from System.Array to T[D] exists
            Assert.IsTrue(Other_TestClass_systemarrays_conversion_02.testMethod());
        }

        [TestMethod]
        public void Othersystemarrays_nullvalue_01_Test()
        {
            // System.Array Type - Null Values
            // Verify that a System.Array array can be set to null
            Assert.IsTrue(Other_TestClass_systemarrays_nullvalue_01.testMethod());
        }

        [TestMethod]
        public void Othercovariance_exception_01_Test()
        {
            Assert.IsTrue(Other_TestClass_covariance_exception_01.testMethod());
        }

        [TestMethod]
        public void Othercovariance_exception_02_Test()
        {
            // Array Covariance
            // Verify an System.Exception is thrown when incompatible types are assigned to array elements
            Assert.IsTrue(Other_TestClass_covariance_exception_02.testMethod());
        }

        [TestMethod]
        public void Othercovariance_explicit_01_Test()
        {
            // Array Covariance
            // Verify covariance from object to any reference-type (class)
            Assert.IsTrue(Other_TestClass_covariance_explicit_01.testMethod());
        }

        [TestMethod]
        public void Othercovariance_explicit_02_Test()
        {
            // Array Covariance
            // Verify covariance from any reference-type (interface) to object
            Assert.IsTrue(Other_TestClass_covariance_explicit_02.testMethod());
        }

        [TestMethod]
        public void Othercovariance_explicit_03_Test()
        {
            // Array Covariance
            // Verify covariance from any class-type S to any class-type T, provided S is base class of T
            Assert.IsTrue(Other_TestClass_covariance_explicit_03.testMethod());
        }

        [TestMethod]
        public void Othercovariance_explicit_04_Test()
        {
            // Array Covariance
            // Verify covariance from any interface-type S to any interface-type T, provided S is not derived from T
            Assert.IsTrue(Other_TestClass_covariance_explicit_04.testMethod());
        }

        [TestMethod]
        public void Othercovariance_implicit_01_Test()
        {
            // Array Covariance
            // Verify covariance from any reference-type (class) to object
            Assert.IsTrue(Other_TestClass_covariance_implicit_01.testMethod());
        }

        [TestMethod]
        public void Othercovariance_implicit_02_Test()
        {
            // Array Covariance
            // Verify covariance from any reference-type (interface) to object
            Assert.IsTrue(Other_TestClass_covariance_implicit_02.testMethod());
        }

        [TestMethod]
        public void Othercovariance_implicit_03_Test()
        {
            // Array Covariance
            // Verify covariance from any class-type S to any class-type T, provided S is derived from T
            Assert.IsTrue(Other_TestClass_covariance_implicit_03.testMethod());
        }

        [TestMethod]
        public void Othercovariance_implicit_04_Test()
        {
            // Array Covariance
            // Verify covariance from any class-type S to any interface-type T, provided S implements T
            Assert.IsTrue(Other_TestClass_covariance_implicit_04.testMethod());
        }

        [TestMethod]
        public void Othercovariance_implicit_05_Test()
        {
            // Array Covariance
            // Verify covariance from any interface-type S to any interface-type T, provided S is derived from T
            Assert.IsTrue(Other_TestClass_covariance_implicit_05.testMethod());
        }

        [TestMethod]
        public void BinarySearch_Test()
        {
            // Array.BinarySearch

            var objects = new MyClass[6];
            for (int i = 0; i < 6; i++)
            {
                objects[i] = new MyClass(i + 1);
            }

            int y = Array.BinarySearch(objects, new MyClass(5), null);
            Assert.AreEqual(y, 4);
        }

        class MyClass : IComparable
        {
            int m_int;

            public MyClass(int i)
            {
                m_int = i;
            }

            public int Value { get { return m_int; } }

            public int CompareTo(object obj)
            {
                var target = obj as MyClass;
                if (target == null)
                {
                    throw new ArgumentException();
                }

                return m_int - target.m_int;
            }
        }

        //Compiled Test Cases 
        class Other_TestClass_systemarrays_conversion_01
        {
            public static int Main_old()
            {
                int result = 32;

                MyClass[] a = new MyClass[] { new MyClass(5), new MyClass(6), new MyClass(7) };


                Array SystemArray;
                int[] StaticArray = new int[] { 10, 20, 30, 40 };
                // There exists an implicit reference conversion for this
                SystemArray = StaticArray;

                if (result == a[2].Value)
                {
                    return 1;
                }
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Other_TestClass_systemarrays_conversion_02
        {
            public static int Main_old()
            {
                Array SystemArray;
                int[] StaticArray = new int[] { 10, 20, 30, 40 };
                int[] StaticArray2 = new int[] { 1, 2, 3, 4 };
                SystemArray = StaticArray;
                StaticArray2 = (int[])SystemArray;
                int result = 0;
                for (int x = 0; x < 4; x++)
                {
                    if (StaticArray[x] != (x + 1) * 10)
                    {
                        result = 1;
                    }
                }
                return result;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Other_TestClass_systemarrays_nullvalue_01
        {
            public static int Main_old()
            {
                Array SystemArray;
                SystemArray = null;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Other_TestClass_covariance_exception_01
        {
            static void Fill(object[] array, int index, int count, object value)
            {
                for (int i = index; i < index + count; i++)
                    array[i] = value;
            }
            public static int Main_old()
            {
                string[] strings = new string[100];
                Fill(strings, 0, 100, "Undefined");
                Fill(strings, 0, 10, null);

                try
                {
                    Fill(strings, 90, 10, 0);
                }
                catch (Exception)
                {
                    return 0;
                }
                return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Queue
        {
            int next;
            int prev;
        }
        class Other_TestClass_covariance_exception_02
        {
            public static int Main_old()
            {
                string[] stringArr = new string[10];
                object[] objectArr = stringArr;
                objectArr[0] = "hello";

                try
                {
                    objectArr[1] = new Queue();
                }
                catch (Exception)
                {
                    return 0;
                }
                return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Other_TestClass_covariance_explicit_01_Imp
        {
            public int x;
        }
        class Other_TestClass_covariance_explicit_01
        {
            public static int Main_old()
            {
                Other_TestClass_covariance_explicit_01_Imp[] mc = new Other_TestClass_covariance_explicit_01_Imp[10];
                for (int x = 0; x < 10; x++)
                {
                    mc[x] = new Other_TestClass_covariance_explicit_01_Imp();
                    mc[x].x = x;
                }
                object[] o = new Other_TestClass_covariance_explicit_01_Imp[10];
                mc = (Other_TestClass_covariance_explicit_01_Imp[])o;

                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        interface Other_TestClass_covariance_explicit_02_Inter
        {
            int testmethod();
        }
        class Other_TestClass_covariance_explicit_02_Imp : Other_TestClass_covariance_explicit_02_Inter
        {
            public int testmethod()
            {
                // Other_TestClass_covariance_explicit_02_Imp::testmethod()
                return 0;
            }
        }
        class Other_TestClass_covariance_explicit_02
        {
            public static int Main_old()
            {
                Other_TestClass_covariance_explicit_02_Inter[] inst = new Other_TestClass_covariance_explicit_02_Inter[10];
                for (int x = 0; x < 10; x++)
                {
                    inst[x] = new Other_TestClass_covariance_explicit_02_Imp();
                }
                object[] o = new Other_TestClass_covariance_explicit_02_Imp[10];
                inst = (Other_TestClass_covariance_explicit_02_Imp[])o;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class ClassS
        {
            public int x;
        }
        class ClassT : ClassS
        {
            public int y;
        }
        class Other_TestClass_covariance_explicit_03
        {
            public static int Main_old()
            {
                ClassS[] cs = new ClassT[10];
                ClassT[] ct = new ClassT[10];
                for (int x = 0; x < 10; x++)
                {
                    cs[x] = new ClassT();
                    ct[x] = new ClassT();
                }
                ct = (ClassT[])cs;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        interface InterfaceS
        {
            int Other_TestClass_covariance_explicit_04MethodS();
        }
        interface InterfaceT : InterfaceS
        {
            int Other_TestClass_covariance_explicit_04MethodT();
        }
        class Other_TestClass_covariance_explicit_04_Imp : InterfaceS, InterfaceT
        {
            public int x;
            public int Other_TestClass_covariance_explicit_04MethodS()
            {
                return 0;
            }
            public int Other_TestClass_covariance_explicit_04MethodT()
            {
                return 0;
            }
        }
        class Other_TestClass_covariance_explicit_04
        {
            public static int Main_old()
            {
                InterfaceS[] ifs = new InterfaceT[10];
                InterfaceT[] ift = new InterfaceT[10];
                Other_TestClass_covariance_explicit_04_Imp mc = new Other_TestClass_covariance_explicit_04_Imp();
                for (int x = 0; x < 10; x++)
                {
                    ifs[x] = new Other_TestClass_covariance_explicit_04_Imp();
                    ift[x] = new Other_TestClass_covariance_explicit_04_Imp();
                }
                ift = (InterfaceT[])ifs;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Other_TestClass_covariance_implicit_01_Imp
        {
            public int x;
        }
        class Other_TestClass_covariance_implicit_01
        {
            public static int Main_old()
            {
                Other_TestClass_covariance_implicit_01_Imp[] mc = new Other_TestClass_covariance_implicit_01_Imp[10];
                for (int x = 0; x < 10; x++)
                {
                    mc[x] = new Other_TestClass_covariance_implicit_01_Imp();
                    OutputHelper.WriteLine(x.ToString());
                    mc[x].x = x;
                }
                object[] o = new object[10];
                o = mc;
                for (int x = 0; x < 10; x++)
                {
                    OutputHelper.WriteLine(((Other_TestClass_covariance_implicit_01_Imp)o[x]).x.ToString());
                }
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        interface Other_TestClass_covariance_implicit_02_Inter
        {
            int testmethod();
        }
        class Other_TestClass_covariance_implicit_02_Imp : Other_TestClass_covariance_implicit_02_Inter
        {
            public int testmethod()
            {
                // Other_TestClass_covariance_implicit_02_Imp::testmethod()
                return 0;
            }
        }
        class Other_TestClass_covariance_implicit_02
        {
            public static int Main_old()
            {
                Other_TestClass_covariance_implicit_02_Inter[] inst = new Other_TestClass_covariance_implicit_02_Inter[10];
                for (int x = 0; x < 10; x++)
                {
                    inst[x] = new Other_TestClass_covariance_implicit_02_Imp();
                }
                object[] o = new object[10];
                o = inst;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Other_TestClass_covariance_implicit_03_T
        {
            public int x;
        }
        class Other_TestClass_covariance_implicit_03_S : Other_TestClass_covariance_implicit_03_T
        {
            public int y;
        }
        class Other_TestClass_covariance_implicit_03
        {
            public static int Main_old()
            {
                Other_TestClass_covariance_implicit_03_S[] cs = new Other_TestClass_covariance_implicit_03_S[10];
                Other_TestClass_covariance_implicit_03_T[] ct = new Other_TestClass_covariance_implicit_03_T[10];
                for (int x = 0; x < 10; x++)
                {
                    cs[x] = new Other_TestClass_covariance_implicit_03_S();
                    ct[x] = new Other_TestClass_covariance_implicit_03_T();
                }
                ct = cs;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        interface Other_TestClass_covariance_implicit_04_IT
        {
            int Other_TestClass_covariance_implicit_04Method();
        }
        class Other_TestClass_covariance_implicit_04_ImpS : Other_TestClass_covariance_implicit_04_IT
        {
            public int x;
            public int Other_TestClass_covariance_implicit_04Method()
            {
                return 0;
            }
        }
        class Other_TestClass_covariance_implicit_04
        {
            public static int Main_old()
            {
                Other_TestClass_covariance_implicit_04_IT[] it = new Other_TestClass_covariance_implicit_04_IT[10];
                Other_TestClass_covariance_implicit_04_ImpS[] cs = new Other_TestClass_covariance_implicit_04_ImpS[10];
                for (int x = 0; x < 10; x++)
                {
                    it[x] = new Other_TestClass_covariance_implicit_04_ImpS();
                    cs[x] = new Other_TestClass_covariance_implicit_04_ImpS();
                }
                it = cs;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        interface Other_TestClass_covariance_implicit_05_IT
        {
            int Other_TestClass_covariance_implicit_05MethodT();
        }
        interface Other_TestClass_covariance_implicit_05_IS : Other_TestClass_covariance_implicit_05_IT
        {
            int Other_TestClass_covariance_implicit_05MethodS();
        }
        class Other_TestClass_covariance_implicit_05_ImpT : Other_TestClass_covariance_implicit_05_IT
        {
            public int x;
            public int Other_TestClass_covariance_implicit_05MethodT()
            {
                return 0;
            }
        }
        class Other_TestClass_covariance_implicit_05_ImpS : Other_TestClass_covariance_implicit_05_IS
        {
            public int x;
            public int Other_TestClass_covariance_implicit_05MethodS()
            {
                return 0;
            }
            public int Other_TestClass_covariance_implicit_05MethodT()
            {
                return 0;
            }
        }
        class Other_TestClass_covariance_implicit_05
        {
            public static int Main_old()
            {
                Other_TestClass_covariance_implicit_05_IS[] ifs = new Other_TestClass_covariance_implicit_05_IS[10];
                Other_TestClass_covariance_implicit_05_IT[] ift = new Other_TestClass_covariance_implicit_05_IT[10];
                Other_TestClass_covariance_implicit_05_ImpS cs = new Other_TestClass_covariance_implicit_05_ImpS();
                Other_TestClass_covariance_implicit_05_ImpT ct = new Other_TestClass_covariance_implicit_05_ImpT();
                for (int x = 0; x < 10; x++)
                {
                    ifs[x] = new Other_TestClass_covariance_implicit_05_ImpS();
                    ift[x] = new Other_TestClass_covariance_implicit_05_ImpT();
                }
                ift = ifs;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

    }
}
