//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestStruct
{
    [TestClass]
    public class UnitTestStructs
    {
        [TestMethod]
        public void Structs01_Test()
        {
            StructsTestClass_01_Notes.Note();
            Assert.IsTrue(StructsTestClass_01.testMethod());
        }
        [TestMethod]
        public void Structs04_Test()
        {
            StructsTestClass_04_Notes.Note();
            Assert.IsTrue(StructsTestClass_04.testMethod());
        }
        [TestMethod]
        public void Structs11_Test()
        {
            StructsTestClass_11_Notes.Note();
            Assert.IsTrue(StructsTestClass_11.testMethod());
        }
        [TestMethod]
        public void Structs12_Test()
        {
            StructsTestClass_12_Notes.Note();
            Assert.IsTrue(StructsTestClass_12.testMethod());
        }
        [TestMethod]
        public void Structs13_Test()
        {
            // Expected failure, see 16852 for more details

            StructsTestClass_13_Notes.Note();
            Assert.IsTrue(StructsTestClass_13.testMethod());
        }
        [TestMethod]
        public void Structs14_Test()
        {
            StructsTestClass_14_Notes.Note();
            Assert.IsTrue(StructsTestClass_14.testMethod());
        }
        [TestMethod]
        public void Structs15_Test()
        {
            StructsTestClass_15_Notes.Note();
            Assert.IsTrue(StructsTestClass_15.testMethod());
        }
        [TestMethod]
        public void Structs19_Test()
        {
            StructsTestClass_19_Notes.Note();
            Assert.IsTrue(StructsTestClass_19.testMethod());
        }
        [TestMethod]
        public void Structs21_Test()
        {
            StructsTestClass_21_Notes.Note();
            Assert.IsTrue(StructsTestClass_21.testMethod());
        }
        [TestMethod]
        public void Structs23_Test()
        {
            StructsTestClass_23_Notes.Note();
            Assert.IsTrue(StructsTestClass_23.testMethod());
        }
        [TestMethod]
        public void Structs24_Test()
        {
            StructsTestClass_24_Notes.Note();
            Assert.IsTrue(StructsTestClass_24.testMethod());
        }
        [TestMethod]
        public void Structs26_Test()
        {
            StructsTestClass_26_Notes.Note();
            Assert.IsTrue(StructsTestClass_26.testMethod());
        }
        [TestMethod]
        public void Structs28_Test()
        {
            StructsTestClass_28_Notes.Note();
            Assert.IsTrue(StructsTestClass_28.testMethod());
        }
        [TestMethod]
        public void Structs29_Test()
        {
            StructsTestClass_29_Notes.Note();
            Assert.IsTrue(StructsTestClass_29.testMethod());
        }
        [TestMethod]
        public void Structs32_Test()
        {
            StructsTestClass_32_Notes.Note();
            Assert.IsTrue(StructsTestClass_32.testMethod());
        }
        [TestMethod]
        public void Structs33_Test()
        {
            StructsTestClass_33_Notes.Note();
            Assert.IsTrue(StructsTestClass_33.testMethod());
        }
        [TestMethod]
        public void Structs34_Test()
        {
            StructsTestClass_34_Notes.Note();
            Assert.IsTrue(StructsTestClass_34.testMethod());
        }
        [TestMethod]
        public void Structs35_Test()
        {
            StructsTestClass_35_Notes.Note();
            Assert.IsTrue(StructsTestClass_35.testMethod());
        }
        [TestMethod]
        public void Structs36_Test()
        {
            StructsTestClass_36_Notes.Note();
            Assert.IsTrue(StructsTestClass_36.testMethod());
        }
        [TestMethod]
        public void Structs37_Test()
        {
            StructsTestClass_37_Notes.Note();
            Assert.IsTrue(StructsTestClass_37.testMethod());
        }
        [TestMethod]
        public void Structs38_Test()
        {
            StructsTestClass_38_Notes.Note();
            Assert.IsTrue(StructsTestClass_38.testMethod());
        }
        [TestMethod]
        public void Structs40_Test()
        {
            StructsTestClass_40_Notes.Note();
            Assert.IsTrue(StructsTestClass_40.testMethod());
        }
        [TestMethod]
        public void Structs41_Test()
        {
            StructsTestClass_41_Notes.Note();
            Assert.IsTrue(StructsTestClass_41.testMethod());
        }
        [TestMethod]
        public void Structs42_Test()
        {
            StructsTestClass_42_Notes.Note();
            Assert.IsTrue(StructsTestClass_42.testMethod());
        }
        [TestMethod]
        public void Structs43_Test()
        {
            StructsTestClass_43_Notes.Note();
            Assert.IsTrue(StructsTestClass_43.testMethod());
        }
        [TestMethod]
        public void Structs44_Test()
        {
            StructsTestClass_44_Notes.Note();
            Assert.IsTrue(StructsTestClass_44.testMethod());
        }
        [TestMethod]
        public void Structs55_Test()
        {
            StructsTestClass_55_Notes.Note();
            Assert.IsTrue(StructsTestClass_55.testMethod());
        }

        [TestMethod]
        public void ValueTest_StructEquals_01()
        {
            AStruct s1 = new AStruct() { a = 1 };
            AStruct s2 = new AStruct() { a = 2 };

            Assert.IsTrue(s1.Equals(s1), "Comparing struct failed: s1.Equals(s1)");
            Assert.IsFalse(s1.Equals(s2), "Comparing struct failed: s1.Equals(s2)");
            Assert.IsTrue(s1.a.Equals(s1.a), "Comparing struct failed: s1.a.Equals(s1.a)");
            Assert.IsFalse(s1.a.Equals(s2.a), "Comparing struct failed: s1.a.Equals(s2.a)");
            // TODO
            // these are failing: need to fix the comparer at CLR
            //Assert.IsFalse(s1.Equals(null), "Comparing struct failed: s1.Equals(null)");
            //Assert.IsFalse(s1.Equals(null), "Comparing struct failed: s1.Equals(null)");
        }

        //Compiled Test Cases 
        class StructsTestClass_01_Notes
        {
            public static void Note()
            {
                //  Declaring a struct with and without a trailing semicolon. 
            }
        }
        struct StructsTestClass_01_Struct1
        {
            public int i;
        }
        struct StructsTestClass_01_Struct2
        {
            public int i;
        };
        public class StructsTestClass_01
        {
            public static bool testMethod()
            {
                StructsTestClass_01_Struct1 s1;
                StructsTestClass_01_Struct2 s2;
                s1.i = 1;
                s2.i = 1;
                return (0 == (s1.i - s2.i));
            }

        }
        class StructsTestClass_04_Notes
        {
            public static void Note()
            {
                //  Verify all valid protection levels for members and methods
            }
        }
        struct StructsTestClass_04_Struct1
        {
            public int pub;
            private int priv;
            internal int intern;
            public int StructsTestClass_04PubPriv()
            {
                return StructsTestClass_04Priv();
            }
            private int StructsTestClass_04Priv()
            {
                pub = 1;
                priv = 2;
                return (pub + priv);
            }
            internal int StructsTestClass_04Intern()
            {
                intern = 3;
                return (intern);
            }
            public int GetPrivate()
            {
                return (priv);
            }
        }
        public class StructsTestClass_04
        {
            public static bool testMethod()
            {
                StructsTestClass_04_Struct1 s1 = new StructsTestClass_04_Struct1();
                int result;
                result = s1.StructsTestClass_04PubPriv();
                result += s1.StructsTestClass_04Intern();
                result -= s1.intern;
                result -= s1.pub;
                result -= s1.GetPrivate();
                return (result == 0);
            }

        }
        class StructsTestClass_11_Notes
        {
            public static void Note()
            {
                //  Verify struct can implement an interface.
            }
        }
        interface Inter1
        {
            int Return42();
        }
        struct StructsTestClass_11_Struct1 : Inter1
        {
            public int Return42() { return (42); }
        }
        public class StructsTestClass_11
        {
            public static bool testMethod()
            {
                Inter1 i1 = new StructsTestClass_11_Struct1();
                return (0 == (i1.Return42() - 42));
            }

        }
        class StructsTestClass_12_Notes
        {
            public static void Note()
            {
                //  Verify struct can implement multiple interfaces.
            }
        }
        interface StructsTestClass_12_Inter1
        {
            int Return42();
        }
        interface StructsTestClass_12_Inter2
        {
            int Return20();
        }
        interface StructsTestClass_12_Inter3
        {
            int Return22();
        }
        struct StructsTestClass_12_Struct1 : StructsTestClass_12_Inter1, StructsTestClass_12_Inter2, StructsTestClass_12_Inter3
        {
            public int Return42() { return (42); }
            public int Return20() { return (20); }
            public int Return22() { return (22); }
        }
        public class StructsTestClass_12
        {
            public static bool testMethod()
            {
                StructsTestClass_12_Inter1 i1 = new StructsTestClass_12_Struct1();
                return (0 == (i1.Return42() - ((StructsTestClass_12_Inter2)i1).Return20() - ((StructsTestClass_12_Inter3)i1).Return22()));
            }

        }
        class StructsTestClass_13_Notes
        {
            public static void Note()
            {
                //  Verify struct can implement multiple interfaces that contain methods with identical signatures.
            }
        }
        interface StructsTestClass_13_Inter1
        {
            int Return42();
        }
        interface StructsTestClass_13_Inter2
        {
            int Return42();
        }
        interface StructsTestClass_13_Inter3
        {
            int Return0();
        }
        struct StructsTestClass_13_Struct1 : StructsTestClass_13_Inter1, StructsTestClass_13_Inter2, StructsTestClass_13_Inter3
        {
            int StructsTestClass_13_Inter1.Return42() { return (42); }
            int StructsTestClass_13_Inter2.Return42() { return (42); }
            int StructsTestClass_13_Inter3.Return0() { return (0); }
        }
        public class StructsTestClass_13
        {
            public static int Main_old()
            {
                StructsTestClass_13_Inter1 i1 = new StructsTestClass_13_Struct1();
                return (i1.Return42() - ((StructsTestClass_13_Inter2)i1).Return42() - ((StructsTestClass_13_Inter3)i1).Return0());
            }
            public static bool testMethod()
            {
                try
                {
                    return (Main_old() == 0);
                }
                catch
                {
                    return false;
                }
            }
        }
        class StructsTestClass_14_Notes
        {
            public static void Note()
            {
                //  Verify that a struct can contain a class
            }
        }
        class StructsTestClass_14_Class1
        {
        };
        struct StructsTestClass_14_Struct1
        {
            public StructsTestClass_14_Class1 c;
        }
        public class StructsTestClass_14
        {
            public static int Main_old()
            {
                StructsTestClass_14_Struct1 s1 = new StructsTestClass_14_Struct1();
                int result = s1.c == null ? 0 : 1;
                return (result);
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class StructsTestClass_15_Notes
        {
            public static void Note()
            {
                //  Verify that a struct can contain another sruct
            }
        }
        struct StructsTestClass_15_Struct1
        {
            public int i;
        };
        struct StructsTestClass_15_Struct2
        {
            public StructsTestClass_15_Struct1 s;
            public int i;
        }
        public class StructsTestClass_15
        {
            public static int Main_old()
            {
                StructsTestClass_15_Struct2 s2 = new StructsTestClass_15_Struct2();
                return (s2.s.i);
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class StructsTestClass_19_Notes
        {
            public static void Note()
            {
                // Attempt to use an empty StructsTestClass_19_Struct
            }
        }
        struct StructsTestClass_19_Struct1
        {
        }
        public class StructsTestClass_19
        {
            public static int Main_old()
            {
                StructsTestClass_19_Struct1 s = new StructsTestClass_19_Struct1();
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }

        }

        class StructsTestClass_21_Notes
        {
            public static void Note()
            {
                // attempt to return a struct
            }
        }
        public struct StructsTestClass_21_Struct1
        {
            int a;
            public void Set(int val) { a = val; }
            public int Get() { return (a); }
        }
        public class StructsTestClass_21
        {
            public static int Main_old()
            {
                if (callQuick().Get() != 0)
                    return (1);
                return (call().Get() - 42);
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
            public static StructsTestClass_21_Struct1 callQuick()
            {
                return (new StructsTestClass_21_Struct1());
            }
            public static StructsTestClass_21_Struct1 call()
            {
                StructsTestClass_21_Struct1 s = new StructsTestClass_21_Struct1();
                s.Set(42);
                return (s);
            }
        }
        class StructsTestClass_23_Notes
        {
            public static void Note()
            {
                // struct like an object
            }
        }
        struct StructsTestClass_23_Struct1
        {
            public int i;
        }
        public class StructsTestClass_23
        {
            public static int Main_old()
            {
                StructsTestClass_23_Struct1 s = new StructsTestClass_23_Struct1();
                s.i = 42;
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        class StructsTestClass_24_Notes
        {
            public static void Note()
            {
                //   struct values aren't changed when boxed and passed as interfaces.
            }
        }
        public interface Interface1
        {
            void SetInt(int val);
            int GetInt();
        };
        public struct StructsTestClass_24_Struct1 : Interface1
        {
            public int i;
            public void SetInt(int val) { i = val; }
            public int GetInt() { return (i); }
        }
        public class StructsTestClass_24
        {
            public static int Main_old()
            {
                StructsTestClass_24_Struct1 s = new StructsTestClass_24_Struct1();
                s.i = 42;
                Call(s);
                return (s.i == 42 ? 0 : 1);
            }
            public static void Call(Interface1 iface)
            {
                if (iface.GetInt() != 42)
                {
                    throw new System.Exception();
                    throw new System.Exception("expected i == 42");
                }
                iface.SetInt(99);
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        class StructsTestClass_26_Notes
        {
            public static void Note()
            {
                //   StructsTestClass_26_A ttempt to make a parameterized conStructsTestClass_26_Structor for a StructsTestClass_?_Struct.
            }
        }
        struct StructsTestClass_26_Struct1
        {
            public StructsTestClass_26_Struct1(int j) { i = j; }
            public int i;
        }
        public class StructsTestClass_26
        {
            public static int Main_old()
            {
                StructsTestClass_26_Struct1 s = new StructsTestClass_26_Struct1(42);
                return (s.i - 42);
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class StructsTestClass_28_Notes
        {
            public static void Note()
            {
                //  Explicit test of object boxing conversions to and from a StructsTestClass_28_Struct.
            }
        }
        struct StructsTestClass_28_Struct1
        {
            public int i;
        }
        public class StructsTestClass_28
        {
            static public int Main_old()
            {
                StructsTestClass_28_Struct1 s1 = new StructsTestClass_28_Struct1();
                Object converter = s1;
                StructsTestClass_28_Struct1 s2 = (StructsTestClass_28_Struct1)converter;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class StructsTestClass_29_Notes
        {
            public static void Note()
            {
                //  StructsTestClass_29 conStructsTestClass_29_Structor forwarding works for StructsTestClass_?_Structs
            }
        }
        struct Foo
        {
            public Foo(int x) : this(5, 6)
            {
            }
            public Foo(int x, int y)
            {
                m_x = x;
                m_y = y;
            }
            public int m_x;
            public int m_y;
        }
        public class StructsTestClass_29
        {
            static public int Main_old()
            {
                Foo s1 = new Foo(1);
                if (s1.m_x != 5)
                    return (1);
                if (s1.m_y != 6)
                    return (1);
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class StructsTestClass_32_Notes
        {
            public static void Note()
            {
                //  nested struct should work
            }
        }
        public struct StructsTestClass_32_Struct
        {
            public struct Nested
            {
                public int i;
            }
            public Nested n;
        }
        public class StructsTestClass_32
        {
            public static bool testMethod()
            {
                StructsTestClass_32_Struct s = new StructsTestClass_32_Struct();
                StructsTestClass_32_Struct.Nested nn = new StructsTestClass_32_Struct.Nested();
                nn.i = 10;
                s.n = nn;  //value copy	

                if (s.n.i == nn.i)
                    return true;
                else
                    return false;
            }
        }
        class StructsTestClass_33_Notes
        {
            public static void Note()
            {
                //  nested class inside struct should work
            }
        }
        public struct StructsTestClass_33_Struct
        {
            public class Nested
            {
                public int i;
            }
            public Nested n;
        }
        public class StructsTestClass_33
        {
            public static bool testMethod()
            {
                StructsTestClass_33_Struct s = new StructsTestClass_33_Struct();
                StructsTestClass_33_Struct.Nested nn = new StructsTestClass_33_Struct.Nested();
                nn.i = 10;
                s.n = nn;  //value copy

                if (s.n.i == nn.i)
                    return true;
                else
                    return false;
            }
        }
        class StructsTestClass_34_Notes
        {
            public static void Note()
            {
                //  nested struct should work
            }
        }
        public struct StructsTestClass_34_Struct
        {
            public struct Nested
            {
                public struct NestedNested
                {
                    public int i;
                }
                public int i;   //in different scope
            }
            public Nested n;
        }
        public class StructsTestClass_34
        {
            public static bool testMethod()
            {
                StructsTestClass_34_Struct s = new StructsTestClass_34_Struct();
                StructsTestClass_34_Struct.Nested nn = new StructsTestClass_34_Struct.Nested();
                nn.i = 10;
                s.n = nn;  //value copy	

                StructsTestClass_34_Struct.Nested.NestedNested nnn = new StructsTestClass_34_Struct.Nested.NestedNested();

                if (s.n.i != nn.i)
                    return false;
                nnn.i = 20;
                s.n.i = nnn.i;
                if (nn.i == 10 && s.n.i == nnn.i)//check nn.i did not changed
                    return true;
                else
                    return false;
            }
        }
        class StructsTestClass_35_Notes
        {
            public static void Note()
            {
                //  cast struct to inherited interface type
            }
        }
        public interface StructsTestClass_35_Interface
        {
            int foo();
        }
        public struct StructsTestClass_35_A : StructsTestClass_35_Interface
        {
            public int foo()
            {
                return 10;
            }
        }
        public class StructsTestClass_35
        {
            public static bool testMethod()
            {
                StructsTestClass_35_Interface a = new StructsTestClass_35_A();

                if (a.foo() != 10)
                    return false;
                else
                    return true;
            }
        }
        class StructsTestClass_36_Notes
        {
            public static void Note()
            {
                //  cast struct to inherited interface type
            }
        }
        public interface StructsTestClass_36_Interface
        {
            int foo();
        }
        public struct StructsTestClass_36_A : StructsTestClass_36_Interface
        {
            public int foo()
            {
                return 10;
            }
        }
        public class StructsTestClass_36
        {
            public static bool testMethod()
            {
                StructsTestClass_36_Interface a = new StructsTestClass_36_A();

                if (a.foo() != 10)
                    return false;
                else
                    return true;
            }
        }
        class StructsTestClass_37_Notes
        {
            public static void Note()
            {
                //  cast struct to inherited interface type
            }
        }
        public interface StructsTestClass_37_Interface
        {
            int foo();
        }
        public struct StructsTestClass_37_A : StructsTestClass_37_Interface
        {
            public int foo()
            {
                return 10;
            }
        }
        public class StructsTestClass_37
        {
            public static bool testMethod()
            {
                StructsTestClass_37_A a = new StructsTestClass_37_A();
                object o = a;    //boxing
                bool b = o is StructsTestClass_37_Interface;

                if (!b)
                    return false;
                if ((a as StructsTestClass_37_Interface) == null)
                    return false;
                if (a.foo() != 10)
                    return false;
                else
                    return true;
            }
        }
        class StructsTestClass_38_Notes
        {
            public static void Note()
            {
                //  cast struct to inherited interface type through function
            }
        }
        public interface StructsTestClass_38_Interface
        {
            int foo();
        }
        public struct StructsTestClass_38_A : StructsTestClass_38_Interface
        {
            public StructsTestClass_38_Interface GetI()
            {
                this.i = 10;
                return this;
            }
            public int foo()
            {
                return i;
            }
            public int i;
        }
        public class StructsTestClass_38
        {
            public static bool testMethod()
            {
                StructsTestClass_38_A a = new StructsTestClass_38_A();
                object o = a;    //boxing
                bool b = o is StructsTestClass_38_Interface;

                if (!b)
                    return false;
                if ((a as StructsTestClass_38_Interface) == null)
                    return false;
                if (a.GetI().foo() != 10)
                    return false;
                else
                    return true;
            }
        }
        class StructsTestClass_40_Notes
        {
            public static void Note()
            {
                //  property in struct
            }
        }
        public struct StructsTestClass_40_Struct
        {
            public int Foo
            {
                get
                {
                    return 10;
                }
            }
        }
        public class StructsTestClass_40
        {
            public static bool testMethod()
            {
                StructsTestClass_40_Struct a = new StructsTestClass_40_Struct();
                if (a.Foo == 10)
                    return true;
                else
                    return false;
            }
        }
        class StructsTestClass_41_Notes
        {
            public static void Note()
            {
                //  indexer in struct
            }
        }
        public struct StructsTestClass_41_Struct
        {
            public int this[int index]
            {
                get
                {
                    return index;
                }
            }
        }
        public class StructsTestClass_41
        {
            public static bool testMethod()
            {
                StructsTestClass_41_Struct a = new StructsTestClass_41_Struct();
                if (a[10] == 10)
                    return true;
                else
                    return false;
            }
        }
        class StructsTestClass_42_Notes
        {
            public static void Note()
            {
                //  interface indexer in StructsTestClass_42_Struct
            }
        }
        public interface StructsTestClass_42_Interface
        {
            int this[int index] { get; }
        }
        public struct StructsTestClass_42_A : StructsTestClass_42_Interface
        {
            public int this[int index]
            {
                get
                {
                    return index;
                }
            }
        }
        public class StructsTestClass_42
        {
            public static bool testMethod()
            {
                StructsTestClass_42_Interface a = new StructsTestClass_42_A();
                if (a[10] == 10)
                    return true;
                else
                    return false;
            }
        }
        class StructsTestClass_43_Notes
        {
            public static void Note()
            {
                //  delegate in struct
            }
        }
        public struct StructsTestClass_43_Struct
        {
            public delegate int foo();
            public int boo()
            {
                return 10;
            }
        }
        public class StructsTestClass_43
        {
            public static bool testMethod()
            {
                StructsTestClass_43_Struct a = new StructsTestClass_43_Struct();
                StructsTestClass_43_Struct.foo d = new StructsTestClass_43_Struct.foo(a.boo);
                if (d() == 10)
                    return true;
                else
                    return false;
            }
        }
        class StructsTestClass_44_Notes
        {
            public static void Note()
            {
                //  delegate in struct assing interface as a delegate argument
            }
        }
        public interface StructsTestClass_44_Interface
        {
            int boo();
        }
        public struct StructsTestClass_44_A : StructsTestClass_44_Interface
        {
            public delegate int foo();
            public int boo()
            {
                return 10;
            }
        }
        public class StructsTestClass_44
        {
            public static bool testMethod()
            {
                StructsTestClass_44_Interface a = new StructsTestClass_44_A();
                StructsTestClass_44_A.foo d = new StructsTestClass_44_A.foo(a.boo);
                if (d() == 10)
                    return true;
                else
                    return false;
            }
        }
        class StructsTestClass_55_Notes
        {
            public static void Note()
            {
                // The this object cannot be used before all of its fields are assigned to
            }
        }
        public struct StructsTestClass_55
        {
            public int i;
            static void foo() { }
            StructsTestClass_55(int i)
            {
                this.i = i;
                foo();
            }

            public static bool testMethod()
            {
                StructsTestClass_55 s = new StructsTestClass_55(101);
                return (0 == s.i - 101);
            }
        }

        public struct AStruct
        {
            public int a { get; set; }
        }
    }
}
