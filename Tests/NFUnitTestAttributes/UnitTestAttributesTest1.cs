//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NFUnitTestAttributes
{
    [TestClass]
    public class UnitTestAttributesTest1
    {
        [TestMethod]
        public void Attrib_attrib000_Test()
        {
            // Declare a basic attribute class, example from C# Language reference, 1.1
            Assert.IsTrue(Attrib_TestClass_attrib000.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib000_2_Test()
        {
            // 17.1 - A non-abstract attribute class must have public accessibility.
            Assert.IsTrue(Attrib_TestClass_attrib000_2.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib001_Test()
        {
            // Declare a basic attribute class, example from C# Language reference, 1.1
            Assert.IsTrue(Attrib_TestClass_attrib001.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib002_Test()
        {
            // Declare a basic attribute class, example from C# Language reference, 1.1
            Assert.IsTrue(Attrib_TestClass_attrib002.testMethod());
        }

        // Removing this test as not supported scenario in nano
        //[TestMethod]
        //public void Attrib_attrib017_7a_Test()
        //{
        //    // 17.4.5 test of conditional when DEBUG is undefined
        //    Assert.IsTrue(Attrib_TestClass_attrib017_7a.testMethod());
        //}

        [TestMethod]
        public void Attrib_attrib017_8c_Test()
        {
            // 17.4.5 - Example from CLR

            Assert.IsTrue(Attrib_TestClass_attrib017_8c.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib021_2_Test()
        {
            // CLR 17.4.9 - guid Attribute
            Assert.IsTrue(Attrib_TestClass_attrib021_2.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib021_4_Test()
        {
            // CLR 17.4.9 - guid Attribute
            Assert.IsTrue(Attrib_TestClass_attrib021_4.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib029_8_Test()
        {
            // CLR 17.4.19 - obsolete
            // obsolete can be used on any declaration, but should be able to call
            // obsolete methods
            Assert.IsTrue(Attrib_TestClass_attrib029_8.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib029_9_Test()
        {
            // CLR 17.4.19 - obsolete
            // obsolete can be used on any declaration, but should be able to call
            // obsolete methods
            Assert.IsTrue(Attrib_TestClass_attrib029_9.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib029_a_Test()
        {
            // CLR 17.4.19 - obsolete
            // obsolete can be used on any declaration, but should be able to call
            // obsolete methods
            Assert.IsTrue(Attrib_TestClass_attrib029_a.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib029_b_Test()
        {
            // CLR 17.4.19 - obsolete
            // obsolete can be used on any declaration, but overrides should generate warning
            Assert.IsTrue(Attrib_TestClass_attrib029_b.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib031_4_Test()
        {
            // CLR 17.4.22 - serializable Attribute
            Assert.IsTrue(Attrib_TestClass_attrib031_4.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib032_2_Test()
        {
            // CLR 17.4.23 - structlayout Attribute
            Assert.IsTrue(Attrib_TestClass_attrib032_2.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib033_2_Test()
        {
            // Attribute usage is inherited.
            Assert.IsTrue(Attrib_TestClass_attrib033_2.testMethod());
        }

        /*
         * These tests are excluded because they require parts of System.Reflection that are not supported in the MF
         * 
        [TestMethod]
        public void Attrib_attrib035_12_Test()
        {
            // Make sure that assembly level GuidAttribute appears in assembly
            Assert.IsTrue(Attrib_TestClass_attrib035_12.testMethod())
            {
                return MFTestResults.Pass;
            }
            return MFTestResults.Fail;
        }
        [TestMethod]
        public void Attrib_attrib035_22_Test()
        {
            // Make sure that assembly level GuidAttribute appears in assembly
            Assert.IsTrue(Attrib_TestClass_attrib035_22.testMethod())
            {
                return MFTestResults.Pass;
            }
            return MFTestResults.Fail;
        }
         */

        [TestMethod]
        public void Attrib_attrib036_1_Test()
        {
            // 17.1 - A top-level, non-abstract attribute class must have public or
            // internal accessibility. Nested attribute classes may also be private,
            // protected, or protected internal.
            Assert.IsTrue(Attrib_TestClass_attrib036_1.testMethod());            
        }

        [TestMethod]
        public void Attrib_attrib038_1_Test()
        {
            // Verify params keyword
                Assert.IsTrue(Attrib_TestClass_attrib038_1.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib047_4_Test()
        {
            //  Make sure that ObsoleteAttribute works with following targets
            // [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct |
            // 	AttributeTargets.Enum | AttributeTargets.Constructor |
            // 	AttributeTargets.Method | AttributeTargets.Property |
            // 	AttributeTargets.Field | AttributeTargets.Event |
            // 	AttributeTargets.Interface | AttributeTargets.Delegate)]
            Assert.IsTrue(Attrib_TestClass_attrib047_4.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib047_5_Test()
        {
            //  Make sure that ObsoleteAttribute works with following targets
            // [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct |
            // 	AttributeTargets.Enum | AttributeTargets.Constructor |
            // 	AttributeTargets.Method | AttributeTargets.Property |
            // 	AttributeTargets.Field | AttributeTargets.Event |
            // 	AttributeTargets.Interface | AttributeTargets.Delegate)]
            Assert.IsTrue(Attrib_TestClass_attrib047_5.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib049_4_Test()
        {
            // Bad named attribute argumements should be an error
            Assert.IsTrue(Attrib_TestClass_attrib049_4.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib054_Test()
        {
            // ECMA complaince: support special attribute name binding rules with @ identifier
            // explictly specify attribute location with @
            Assert.IsTrue(Attrib_TestClass_attrib054.testMethod());
        }

        [TestMethod]
        public void Attrib_attrib062_Test()
        {
            // Declare a derived attribute after declaring its base.
            // Attributes can inherit from other attirubtes that have not yet been declared as long as there are no
            // circular dependencies.
            Assert.IsTrue(Attrib_TestClass_attrib062.testMethod());
        }

        //Compiled Test Cases 
        [AttributeUsage(AttributeTargets.Class)]
        public class Attrib_TestClass_attrib000_A : Attribute { }
        public class Attrib_TestClass_attrib000
        {
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        [AttributeUsage(AttributeTargets.Class)]
        abstract class Attrib_TestClass_attrib000_2_C1 : Attribute
        {
            public abstract void mf();
        }
        public class Attrib_TestClass_attrib000_2
        {
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface)]
        public class Attrib_TestClass_attrib001_C : Attribute
        {
            public int Name;
            public Attrib_TestClass_attrib001_C(int sName) { Name = sName; }

            [Attrib_TestClass_attrib001_C(5)]
            class Attrib_TestClass_attrib001_C1 { }
            [Attrib_TestClass_attrib001_C(6)]
            interface Attrib_TestClass_attrib001_I1 { }
            [Attrib_TestClass_attrib001_C(7)]
            struct Attrib_TestClass_attrib001_S1 { }
        }
        public class Attrib_TestClass_attrib001
        {
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        [AttributeUsage(AttributeTargets.Class)]
        public class Attrib_TestClass_attrib002 : Attribute
        {
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }





        public class Attrib_TestClass_attrib017_7a_C1
        {
            [Conditional("DEBUG")]
            public static void M()
            {
                Attrib_TestClass_attrib017_7a.retval++;
                // Executed Attrib_TestClass_attrib017_7a_C1.M
            }
        }
        public class Attrib_TestClass_attrib017_7a_C2
        {
            public static void Test()
            {
                Attrib_TestClass_attrib017_7a_C1.M();
            }
        }
        public class Attrib_TestClass_attrib017_7a
        {
            public static int retval = 0;
            public static int Main_old()
            {
                Attrib_TestClass_attrib017_7a_C2.Test();
                if (retval == 0) OutputHelper.WriteLine("PASS");
                else OutputHelper.WriteLine("FAIL");
                return retval;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Attrib_TestClass_attrib017_8c_C1
        {
            [Conditional("DEBUG")]
            public static void C1()
            {
                // Executed Class1.C1()
            }
        }

        class Attrib_TestClass_attrib017_8c_C2
        {
            public static void C2()
            {
                // Executed Class2.C2()
                Attrib_TestClass_attrib017_8c_C1.C1();				// C1 is called
            }
        }

        class Attrib_TestClass_attrib017_8c_C3
        {
            public static void C4()
            {
                // Executed Attrib_TestClass_attrib017_8c_C3.C4()
                Attrib_TestClass_attrib017_8c_C1.C1();
            }
        }
        public class Attrib_TestClass_attrib017_8c
        {
            public static int Main_old()
            {
                Attrib_TestClass_attrib017_8c_C3.C4();
                Attrib_TestClass_attrib017_8c_C2.C2();
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        [Guid("00020810-0000-0000-C000-000000000046")]
        class Attrib_TestClass_attrib021_2_C1 { }
        public class Attrib_TestClass_attrib021_2
        {
            public static int Main_old()
            {
                Attrib_TestClass_attrib021_2_C1 w = new Attrib_TestClass_attrib021_2_C1();	// Creates an Excel worksheet
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        [GuidAttribute("00020810-0000-0000-C000-000000000046")]
        struct Attrib_TestClass_attrib021_4_C1 { }
        public class Attrib_TestClass_attrib021_4
        {
            public static int Main_old()
            {
                Attrib_TestClass_attrib021_4_C1 w = new Attrib_TestClass_attrib021_4_C1();	// Creates an Excel worksheet
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        public class Attrib_TestClass_attrib029_8_C1
        {
            public Attrib_TestClass_attrib029_8_C1()
            {
                _i = -1;
            }
            private int _i;
            [Obsolete]
            public int i
            {
                get { return _i; }
                set
                {
                    _i = value;
                    Attrib_TestClass_attrib029_8_S1 s1 = new Attrib_TestClass_attrib029_8_S1(-1);
                    s1.j = 3;
                    if (s1.j == 3)
                        Attrib_TestClass_attrib029_8.retval -= 1;
                }
            }
        }
        public struct Attrib_TestClass_attrib029_8_S1
        {
            public Attrib_TestClass_attrib029_8_S1(int i)
            {
                _j = i;
            }
            private int _j;
            [Obsolete("Attrib_TestClass_attrib029_8_S1 is an obsolete struct")]
            public int j
            {
                get { return _j; }
                set { _j = value; }
            }
        }
        public class Attrib_TestClass_attrib029_8
        {
            public static int retval = 7;
            public static int Main_old()
            {
                Attrib_TestClass_attrib029_8_C1 c1 = new Attrib_TestClass_attrib029_8_C1();
                c1.i = 5;
                int anInt = c1.i;
                if (anInt == 5)
                    retval -= 2;
                Attrib_TestClass_attrib029_8_S1 s1 = new Attrib_TestClass_attrib029_8_S1();
                s1.j = 10;
                
                if (10 == s1.j)
                {
                    retval -= 4;
                }
                
                if (0 != retval)
                {
                    OutputHelper.WriteLine("FAIL, retval==" + retval.ToString());
                }

                return retval;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Attrib_TestClass_attrib029_9_C1
        {
            [Obsolete]
            public int C1Method(int value)
            {
                Attrib_TestClass_attrib029_9_S1 s1 = new Attrib_TestClass_attrib029_9_S1(-1);
                if (s1.S1Method(3) == 3)
                    Attrib_TestClass_attrib029_9.retval -= 1;
                return value;
            }
        }
        public struct Attrib_TestClass_attrib029_9_S1
        {
            public Attrib_TestClass_attrib029_9_S1(int i) { }
            [Obsolete("Attrib_TestClass_attrib029_9_S1 is an obsolete struct")]
            public int S1Method(int value)
            {
                return value;
            }
        }
        public class Attrib_TestClass_attrib029_9
        {
            public static int retval = 7;
            public static int Main_old()
            {
                Attrib_TestClass_attrib029_9_C1 c1 = new Attrib_TestClass_attrib029_9_C1();
                int anInt = c1.C1Method(5);
                if (anInt == 5)
                    retval -= 2;
                Attrib_TestClass_attrib029_9_S1 s1 = new Attrib_TestClass_attrib029_9_S1();
                
                if (10 == s1.S1Method(10))
                {
                    retval -= 4;
                }

                if (0 != retval)
                {
                    OutputHelper.WriteLine("FAIL, retval==" + retval.ToString());
                }

                return retval;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Attrib_TestClass_attrib029_a_C1
        {
            public Attrib_TestClass_attrib029_a_C1()
            {
                i = -1;
            }
            [Obsolete]
            public int i;
        }
        public struct Attrib_TestClass_attrib029_a_S1
        {
            public Attrib_TestClass_attrib029_a_S1(int i)
            {
                j = i;
            }
            [Obsolete("Attrib_TestClass_attrib029_a_S1 is an obsolete struct")]
            public int j;
        }
        public class Attrib_TestClass_attrib029_a
        {
            public static int retval = 3;
            public static int Main_old()
            {
                Attrib_TestClass_attrib029_a_C1 c1 = new Attrib_TestClass_attrib029_a_C1();
                c1.i = 5;
                int anInt = c1.i;
                if (anInt == 5)
                    retval -= 1;
                Attrib_TestClass_attrib029_a_S1 s1 = new Attrib_TestClass_attrib029_a_S1();
                s1.j = 10;

                if (10 == s1.j)
                {
                    retval -= 2;
                }

                if (0 != retval) 
                {
                    OutputHelper.WriteLine("FAIL, retval==" + retval.ToString());
                }

                return retval;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Attrib_TestClass_attrib029_b_C1
        {
            [Obsolete]
            public virtual int C1Method(int value)
            {
                Attrib_TestClass_attrib029_b.retval -= 1;
                return value;
            }
        }
        public class Attrib_TestClass_attrib029_b_C2 : Attrib_TestClass_attrib029_b_C1
        {
            public override int C1Method(int value)
            {
                base.C1Method(value);
                return value;
            }
        }
        public class Attrib_TestClass_attrib029_b
        {
            public static int retval = 3;
            public static int Main_old()
            {
                Attrib_TestClass_attrib029_b_C1 c1 = new Attrib_TestClass_attrib029_b_C1();
                int anInt = c1.C1Method(5);

                if (anInt == 5)
                {
                    retval -= 2;
                }

                if (0 == retval)
                {
                    OutputHelper.WriteLine("FAIL, retval==" + retval.ToString());
                }

                return retval;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        [type: Serializable]
        struct Attrib_TestClass_attrib031_4_C1 { public int i; }
        [type: Serializable]
        public class Attrib_TestClass_attrib031_4
        {
            public static int Main_old()
            {
                if (typeof(Attrib_TestClass_attrib031_4_C1).IsSerializable)
                {
                    // PASS
                    return 0;
                }
                // FAIL
                return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        class Attrib_TestClass_attrib032_2_C1
        {
            int i;
            double d;
            char c;
            byte b1, b2, b3;
        }
        public class Attrib_TestClass_attrib032_2
        {
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        [AttributeUsage(AttributeTargets.Method)]
        public class Attrib_TestClass_attrib033_2_A1 : Attribute
        {
            public Attrib_TestClass_attrib033_2_A1(int i) { }
        }
        public class Attrib_TestClass_attrib033_2_A2 : Attrib_TestClass_attrib033_2_A1
        {
            public Attrib_TestClass_attrib033_2_A2(int i) : base(i) { }
        }
        class Attrib_TestClass_attrib033_2
        {
            [Attrib_TestClass_attrib033_2_A2(4)]  // Should be legal.
            public static int Main_old()
            { return 0; }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        /*
        public class Attrib_TestClass_attrib035_12
        {
            public static int Main_old()
            {
                int retval = 3;
                object[] gaa = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false);
                GuidAttribute ga = null;
                if (gaa.Length == 1)
                    retval -= 1;
                try
                {
                    ga = (GuidAttribute)gaa[0];
                    if (ga.Value == Attrib_TestClass_attrib035_12_C5.GuidString)
                        retval -= 2;
                }
                catch { }  //Just keep the program from dying
                if (retval == 0) // PASS
                else OutputHelper.WriteLine("FAIL, retval == {0}", retval);
                return retval;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Attrib_TestClass_attrib035_22
        {
            public static int Main_old()
            {
                Attrib_TestClass_attrib035_22_C5 x = new Attrib_TestClass_attrib035_22_C5();
                int retval = x.MyMethod();
                if (retval == 0) // PASS
                else OutputHelper.WriteLine("FAIL, retval == {0}", retval);
                return retval;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        */
        [AttributeUsage(AttributeTargets.Class)]
        internal class Attrib_TestClass_attrib036_1_A1 : Attribute
        {
            Attrib_TestClass_attrib036_1_A1() { }  //Default ctor necessary because compiler generates public ctor otherwise
            internal Attrib_TestClass_attrib036_1_A1(int i) { }
            [AttributeUsage(AttributeTargets.Class)]
            protected class Attrib2 : Attribute
            {
                Attrib2() { }  //Default ctor necessary because compiler generates public ctor otherwise
                protected Attrib2(int i) { }

                [AttributeUsage(AttributeTargets.Class)]
                internal protected class Attrib3 : Attribute
                {
                    Attrib3() { }  //Default ctor necessary because compiler generates public ctor otherwise
                    protected internal Attrib3(int i) { }
                }
                [AttributeUsage(AttributeTargets.Class)]
                private class Attrib4 : Attribute
                {
                    Attrib4() { }  //Default ctor necessary because compiler generates public ctor otherwise
                    private Attrib4(int i) { }
                }
            }
        }
        public class Attrib_TestClass_attrib036_1
        {
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        public delegate void Attrib_TestClass_attrib038_1_F1(params int[] numbers);
        public class Attrib_TestClass_attrib038_1_C1
        {
            public void Attrib_TestClass_attrib038_1(params int[] numbers)
            {
                // Called with " + numbers.Length.ToString() + " args
            }
        }
        public class Attrib_TestClass_attrib038_1
        {
            public static void Main_old()
            {
                Attrib_TestClass_attrib038_1_C1 cls = new Attrib_TestClass_attrib038_1_C1();
                Attrib_TestClass_attrib038_1_F1 f1 = new Attrib_TestClass_attrib038_1_F1(cls.Attrib_TestClass_attrib038_1);
                f1();
                f1(1);
                f1(1, 2);
                f1(1, 2, 3);
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
        public class Attrib_TestClass_attrib047_4_A1 : Attribute
        {
            [Obsolete("Constructor", false)]
            public Attrib_TestClass_attrib047_4_A1() { }

            [Obsolete("Property", false)]
            public int Prop
            {
                get { return 1; }
                set { }
            }

            [Obsolete("Field", false)]
            public int Field;
        }
        [Attrib_TestClass_attrib047_4_A1]
        [Attrib_TestClass_attrib047_4_A1()]
        [Attrib_TestClass_attrib047_4_A1(Field = 1)]
        [Attrib_TestClass_attrib047_4_A1(Prop = 1)]
        public class Attrib_TestClass_attrib047_4
        {
            [method: Attrib_TestClass_attrib047_4_A1]
            [method: Attrib_TestClass_attrib047_4_A1()]
            [return: Attrib_TestClass_attrib047_4_A1(Field = 1)]
            [return: Attrib_TestClass_attrib047_4_A1(Prop = 1)]
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        [Obsolete("Class", false)]
        public class Attrib_TestClass_attrib047_5_A
        {
            [Obsolete("Constructor", false)]
            public Attrib_TestClass_attrib047_5_A() { }
            [Obsolete("Struct", false)]
            public struct S { }
            [Obsolete("Enum", false)]
            public enum E { }
            [Obsolete("Method", false)]
            public void foo() { }

            [Obsolete("Property", false)]
            public int Prop
            {
                get { return 1; }
                set { }
            }

            [Obsolete("Delegate", false)]
            public delegate void Del();
            [Obsolete("Event", false)]
            public event Del Eve;
            [Obsolete("Field", false)]
            public readonly int Field;
            [Obsolete("Interface", false)]
            public interface I { }
        }
        public class Attrib_TestClass_attrib047_5
        {
            public void foo() { }
            public static int Main_old()
            {
                Attrib_TestClass_attrib047_5 t = new Attrib_TestClass_attrib047_5();
                Attrib_TestClass_attrib047_5_A a = new Attrib_TestClass_attrib047_5_A();
                Attrib_TestClass_attrib047_5_A.S s = new Attrib_TestClass_attrib047_5_A.S();
                a.Eve += new Attrib_TestClass_attrib047_5_A.Del(t.foo);
                a.foo();
                int i = a.Prop;
                a.Prop = i;
                i = a.Field;
                Attrib_TestClass_attrib047_5_A.E e;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Attrib_TestClass_attrib049_4_B : Attribute
        {
            public readonly int Attrib_TestClass_attrib049_4_C5;
        }
        public class Attrib_TestClass_attrib049_4_C : Attrib_TestClass_attrib049_4_B
        {
            new public int Attrib_TestClass_attrib049_4_C5;
        }
        [Attrib_TestClass_attrib049_4_C(Attrib_TestClass_attrib049_4_C5 = 5)]        // should not be an error
        public class Attrib_TestClass_attrib049_4
        {
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        [AttributeUsage(AttributeTargets.All)]
        public class Attrib_TestClass_attrib054_C5 : Attribute
        {
        }
        [AttributeUsage(AttributeTargets.All)]
        public class Attrib_TestClass_attrib054_A1 : Attribute
        {
        }
        [Attrib_TestClass_attrib054_A1]			// Refers to Attrib_TestClass_attrib054_A1
        class Attrib_TestClass_attrib054_C2
        {
        }
        [@Attrib_TestClass_attrib054_C5]						// Refers to Attrib_TestClass_attrib054_C5
        class Attrib_TestClass_attrib054_C3
        {
            [method: @Attrib_TestClass_attrib054_C5]
            [method: Attrib_TestClass_attrib054_A1]
            void foo() { }
            [method: @Attrib_TestClass_attrib054_C5]
            [method: @Attrib_TestClass_attrib054_A1]
            void foo(int i) { }
            [method: @Attrib_TestClass_attrib054_C5]
            [method: Attrib_TestClass_attrib054_A1]
            void foo(int i, int ii) { }
        }
        [@Attrib_TestClass_attrib054_A1]			// Refers to Attrib_TestClass_attrib054_A1
        class Attrib_TestClass_attrib054_C4
        {
        }
        public class Attrib_TestClass_attrib054
        {
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Attrib_TestClass_attrib062_A2 : Attrib_TestClass_attrib062_A1 { }
        public class Attrib_TestClass_attrib062_A1 : Attribute { }
        [Attrib_TestClass_attrib062_A1]
        [Attrib_TestClass_attrib062_A2]
        public class Attrib_TestClass_attrib062
        {
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

    }
}
