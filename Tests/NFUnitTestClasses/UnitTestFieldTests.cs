// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestClasses
{
    [TestClass]
    class UnitTestFieldTests
    {
        [TestMethod]
        public void Fields1_testMethod()
        {
            //  Section 10.4
            //  A field-declaration may include set of attributes,
            //  a new modifier, one of four access modifiers, a
            //  static modifier, and a readonly modifier.  The 
            //  attributes and modifiers apply to all of the 
            //  members declared by the field-declaration.
            Assert.IsTrue(FieldsTestClass1.testMethod());
        }

        [TestMethod]
        public void Fields2_testMethod()
        {
            //  Section 10.4
            //  A field-declaration may include set of attributes,
            //  a new modifier, one of four access modifiers, a
            //  static modifier, and a readonly modifier.  The 
            //  attributes and modifiers apply to all of the 
            //  members declared by the field-declaration.
            Assert.IsTrue(FieldsTestClass2.testMethod());
        }

        [TestMethod]
        public void Fields3_testMethod()
        {
            //  Section 10.4
            //  A field-declaration may include set of attributes,
            //  a new modifier, one of four access modifiers, a
            //  static modifier, and a readonly modifier.  The 
            //  attributes and modifiers apply to all of the 
            //  members declared by the field-declaration.
            Assert.IsTrue(FieldsTestClass3.testMethod());
        }

        [TestMethod]
        public void Fields4_testMethod()
        {
            //  Section 10.4
            //  A field-declaration may include set of attributes,
            //  a new modifier, one of four access modifiers, a
            //  static modifier, and a readonly modifier.  The 
            //  attributes and modifiers apply to all of the 
            //  members declared by the field-declaration.
            Assert.IsTrue(FieldsTestClass4.testMethod());
        }

        [TestMethod]
        public void Fields5_testMethod()
        {
            //  Section 10.4
            //  A field-declaration may include set of attributes,
            //  a new modifier, one of four access modifiers, a
            //  static modifier, and a readonly modifier.  The 
            //  attributes and modifiers apply to all of the 
            //  members declared by the field-declaration.
            Assert.IsTrue(FieldsTestClass5.testMethod());
        }

        [TestMethod]
        public void Fields6_testMethod()
        {
            //  Section 10.4
            //  A field-declaration may include set of attributes,
            //  a new modifier, one of four access modifiers, a
            //  static modifier, and a readonly modifier.  The 
            //  attributes and modifiers apply to all of the 
            //  members declared by the field-declaration.
            Assert.IsTrue(FieldsTestClass6.testMethod());
        }

        [TestMethod]
        public void Fields7_testMethod()
        {
            //  Section 10.4
            //  A field-declaration may include set of attributes,
            //  a new modifier, one of four access modifiers, a
            //  static modifier, and a readonly modifier.  The 
            //  attributes and modifiers apply to all of the 
            //  members declared by the field-declaration.
            Assert.IsTrue(FieldsTestClass7.testMethod());
        }

        [TestMethod]
        public void Fields8_testMethod()
        {
            //  Section 10.4
            //  A field-declaration may include set of attributes,
            //  a new modifier, one of four access modifiers, a
            //  static modifier, and a readonly modifier.  The 
            //  attributes and modifiers apply to all of the 
            //  members declared by the field-declaration.
            Assert.IsTrue(FieldsTestClass8.testMethod());
        }

        [TestMethod]
        public void Fields13_testMethod()
        {
            //  Section 10.4
            //  A field-declaration may include set of attributes,
            //  a new modifier, one of four access modifiers, a
            //  static modifier, and a readonly modifier.  The 
            //  attributes and modifiers apply to all of the 
            //  members declared by the field-declaration.
            // 
            //  A field declaration that declares multiple fields
            //  is equivalent to multiple declarations of single 
            //  fields with the same attributes, modifiers, and type.
            Assert.IsTrue(FieldsTestClass13.testMethod());
        }

        [TestMethod]
        public void Fields14_testMethod()
        {
            //  Section 10.4
            //  A static field identifies exactly on storage location.
            //  No matter how many instances of a class are created,
            //  there is only ever one copy of a static field.
            Assert.IsTrue(FieldsTestClass14.testMethod());
        }

        [TestMethod]
        public void Fields15_testMethod()
        {
            //  Section 10.4
            //  A static field comes into existence when the 
            //  type in which it is declared is loaded, and 
            //  ceases to exist when the type in which it 
            //  is declared in unloaded.
            Assert.IsTrue(FieldsTestClass15.testMethod());
        }

        [TestMethod]
        public void Fields16_testMethod()
        {
            //  Section 10.4
            //  Every instance of a class contains a separate copy
            //  of all instance fields of the class.  An instance 
            //  field comes into existence when a new instance of 
            //  its class is created, and ceases to exist when there 
            //  are no references to that instance and the destructor
            //  of the instance has executed.
            Assert.IsTrue(FieldsTestClass16.testMethod());
        }

        [TestMethod]
        public void Fields17_testMethod()
        {
            //  Section 10.4
            //  Every instance of a class contains a separate copy
            //  of all instance fields of the class.  An instance 
            //  field comes into existence when a new instance of 
            //  its class is created, and ceases to exist when there 
            //  are no references to that instance and the destructor
            //  of the instance has executed.
            Assert.IsTrue(FieldsTestClass17.testMethod());
        }

        [TestMethod]
        public void Fields18_testMethod()
        {
            //  Section 10.4
            //  When a field is referenced in a member-access of
            //  the form E.M, if M is a static field, E must denote
            //  a type, and if M is an instance field, E must 
            //  denote an instance.
            Assert.IsTrue(FieldsTestClass18.testMethod());
        }

        [TestMethod]
        public void Fields20_testMethod()
        {
            //  Section 10.4
            //  When a field is referenced in a member-access of
            //  the form E.M, if M is a static field, E must denote
            //  a type, and if M is an instance field, E must 
            //  denote an instance.
            Assert.IsTrue(FieldsTestClass20.testMethod());
        }

        [TestMethod]
        public void Fields22_testMethod()
        {
            //  Section 10.4
            //  When a field-declaration includes a readonly
            //  modifier, assignments to the fields introduced
            //  by the declaration can only occur as part of
            //  the declaration or in a constructor in the
            //  same class.
            Assert.IsTrue(FieldsTestClass22.testMethod());
        }

        [TestMethod]
        public void Fields23_testMethod()
        {
            //  Section 10.4
            //  When a field-declaration includes a readonly
            //  modifier, assignments to the fields introduced
            //  by the declaration can only occur as part of
            //  the declaration or in a constructor in the
            //  same class.
            Assert.IsTrue(FieldsTestClass23.testMethod());
        }

        [TestMethod]
        public void Fields24_testMethod()
        {
            //  Section 10.4
            //  When a field-declaration includes a readonly
            //  modifier, assignments to the fields introduced
            //  by the declaration can only occur as part of
            //  the declaration or in a constructor in the
            //  same class.
            Assert.IsTrue(FieldsTestClass24.testMethod());
        }

        [TestMethod]
        public void Fields41_testMethod()
        {
            //  Section 10.4
            //  A static readonly field is useful when a symbolic
            //  name for a constant value is desired, but when the 
            //  type of the value is not permitted in a const declaration
            //  or when the value cannot be computed at compile-time
            //  by a constant expression.
            Assert.IsTrue(FieldsTestClass41.testMethod());
        }

        [TestMethod]
        public void Fields42_testMethod()
        {
            //  Section 10.4
            //  Field declarations may include variable-initializers.
            //  For static fields, varaible initializers correspond to
            //  assignment statements that are executed when the class
            //  is loaded. For instance fields, variable initializers
            //  correspond to assignment statements that are executed
            //  when an instance of the class is created.
            // This test has been rewritten to avoid use of the Math.Abs function which the MF does not support
            Assert.IsTrue(FieldsTestClass42.testMethod());
        }

        [TestMethod]
        public void Fields43_testMethod()
        {
            //  Section 10.4
            //  The static field variable initializers of a class
            //  correspond to a sequence of assignments that are 
            //  executed immediately upon entry to the static
            //  constructor of a class.  The variable initializers
            //  are executed in the textual order they appear
            //  in the class declaration.
            Assert.IsTrue(FieldsTestClass43.testMethod());
        }

        [TestMethod]
        public void Fields44_testMethod()
        {
            //  Section 10.4
            //  The static field variable initializers of a class
            //  correspond to a sequence of assignments that are 
            //  executed immediately upon entry to the static
            //  constructor of a class.  The variable initializers
            //  are executed in the textual order they appear
            //  in the class declaration.
            Assert.IsTrue(FieldsTestClass44.testMethod());
        }

        [TestMethod]
        public void Fields45_testMethod()
        {
            //  Section 10.4
            //  The static field variable initializers of a class
            //  correspond to a sequence of assignments that are 
            //  executed immediately upon entry to the static
            //  constructor of a class.  The variable initializers
            //  are executed in the textual order they appear
            //  in the class declaration.
            Assert.IsTrue(FieldsTestClass45.testMethod());
        }

        [TestMethod]
        public void Fields46_testMethod()
        {
            //  Section 10.4
            //  The instance field variable initializers of a class
            //  correspond to a sequence of assignments that are 
            //  executed immediately upon entry to one of the instance
            //  constructors of the class.
            Assert.IsTrue(FieldsTestClass46.testMethod());
        }

        [TestMethod]
        public void Fields49_testMethod()
        {
            //  A variable initializer for an instance field
            //  cannot reference the instance being created.
            //  Thus, it is an error to reference this in a 
            //  variable initializer, as it is an error for
            //  a variable initialzer to reference any instance
            //  member through a simple-name.
            Assert.IsTrue(FieldsTestClass49.testMethod());
        }

        [TestMethod]
        public void Fields51_testMethod()
        {
            //  Section 10.4
            //  Specifically, assignments to a readonly field
            //  are permitted only in the following context.
            //  ...
            //  For an instance field, in the instance constructors
            //  of the class that contains the field declaration, or
            //  for a static field, in the static constructor of the
            //  class the contains the field declaration. These are also
            //  contexts in which it is valid to pass a readonly field
            //  as an out or ref parameter.
            Assert.IsTrue(FieldsTestClass51.testMethod());
        }

        [TestMethod]
        public void Fields52_testMethod()
        {
            //  Section 10.4
            //  Specifically, assignments to a readonly field
            //  are permitted only in the following context.
            //  ...
            //  For an instance field, in the instance constructors
            //  of the class that contains the field declaration, or
            //  for a static field, in the static constructor of the
            //  class the contains the field declaration. These are also
            //  contexts in which it is valid to pass a readonly field
            //  as an out or ref parameter.
            Assert.IsTrue(FieldsTestClass52.testMethod());
        }

        [TestMethod]
        public void Fields53_testMethod()
        {
            // Testing bools assigned with (x == y)
            Assert.IsTrue(FieldsTestClass53.testMethod());
        }

        [TestMethod]
        public void Fields54_testMethod()
        {
            // Testing bools assigned with function calls
            Assert.IsTrue(FieldsTestClass54.testMethod());
        }

        [TestMethod]
        public void Fields55_testMethod()
        {
            // Testing bools assigned with conditionals
            Assert.IsTrue(FieldsTestClass55.testMethod());
        }

        [TestMethod]
        public void Fields56_testMethod()
        {
            // Testing ints assigned with function calls
            Assert.IsTrue(FieldsTestClass56.testMethod());
        }

        [TestMethod]
        public void Fields57_testMethod()
        {
            // Testing strings assigned with \"x\" + \"y\"
            Assert.IsTrue(FieldsTestClass57.testMethod());
        }

        [TestMethod]
        public void Fields58_testMethod()
        {
            // Testing strings assigned with function calls
            Assert.IsTrue(FieldsTestClass58.testMethod());
        }

        class FieldsTestClass1
        {

            int intI = 2;

            public static bool testMethod()
            {

                FieldsTestClass1 test = new FieldsTestClass1();
                if (test.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass2_Base
        {
            public int intI = 1;
        }

        class FieldsTestClass2 : FieldsTestClass2_Base
        {

            new int intI = 2;

            public static bool testMethod()
            {

                FieldsTestClass2 test = new FieldsTestClass2();
                if (test.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass3
        {

            public int intI = 2;

            public static bool testMethod()
            {

                FieldsTestClass3 test = new FieldsTestClass3();
                if (test.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass4
        {

            protected int intI = 2;

            public static bool testMethod()
            {

                FieldsTestClass4 test = new FieldsTestClass4();
                if (test.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass5
        {

            internal int intI = 2;

            public static bool testMethod()
            {

                FieldsTestClass5 test = new FieldsTestClass5();
                if (test.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass6
        {

            private int intI = 2;

            public static bool testMethod()
            {

                FieldsTestClass6 test = new FieldsTestClass6();
                if (test.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass7
        {

            static int intI = 2;

            public static bool testMethod()
            {

                if (intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass8
        {

            readonly int intI = 2;

            public static bool testMethod()
            {

                FieldsTestClass8 test = new FieldsTestClass8();
                if (test.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass13_Base
        {
            public int intI = 2, intJ = 3;
        }

        class FieldsTestClass13
        {

            public static bool testMethod()
            {

                FieldsTestClass13_Base test = new FieldsTestClass13_Base();
                if ((test.intI == 2) && (test.intJ == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass14
        {

            static int intI = 1;

            public void ChangeInt(int intJ)
            {
                intI = intJ;
            }


            public static bool testMethod()
            {

                FieldsTestClass14 c1 = new FieldsTestClass14();
                c1.ChangeInt(2);
                FieldsTestClass14 c2 = new FieldsTestClass14();
                c1.ChangeInt(3);
                FieldsTestClass14 c3 = new FieldsTestClass14();
                c1.ChangeInt(4);

                if (intI == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass15_Base
        {
            public static int intI = 1;
        }

        class FieldsTestClass15
        {

            public static bool testMethod()
            {

                if (FieldsTestClass15_Base.intI == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass16
        {


            int intI = 1;

            public void ChangeInt(int intJ)
            {
                intI = intJ;
            }

            public static bool testMethod()
            {

                FieldsTestClass16 c1 = new FieldsTestClass16();
                c1.ChangeInt(2);
                FieldsTestClass16 c2 = new FieldsTestClass16();
                c2.ChangeInt(3);
                FieldsTestClass16 c3 = new FieldsTestClass16();
                c3.ChangeInt(4);

                if ((c1.intI == 2) && (c2.intI == 3) && (c3.intI == 4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass17_Base
        {
            public int intI = 1;
        }

        class FieldsTestClass17
        {

            FieldsTestClass17_Base tc;

            public static bool testMethod()
            {
                try
                {
                    bool RetVal = false;

                    FieldsTestClass17 test = new FieldsTestClass17();

                    try
                    {
                        int intJ = test.tc.intI; //MyTest hasn't been instantiated
                    }
                    catch (Exception e)
                    {
                        RetVal = true;
                    }
                    return RetVal;
                }
                catch { return false; }
            }
        }

        class FieldsTestClass18
        {

            static int intI = 2;

            public static bool testMethod()
            {
                if (FieldsTestClass18.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass20
        {

            int intI = 2;

            public static bool testMethod()
            {
                FieldsTestClass20 test = new FieldsTestClass20();
                if (test.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        enum FieldsTestClass22_Enum { a = 1, b = 2 }

        struct FieldsTestClass22_Struct
        {
            public FieldsTestClass22_Struct(int intI)
            {
                Test = intI;
            }
            public int Test;
        }

        struct FieldsTestClass22_Sub
        {
            public FieldsTestClass22_Sub(int intI)
            {
                Test = intI;
            }
            public int Test;
        }

        class FieldsTestClass22
        {

            readonly int intI = 2;
            readonly string strS = "MyString";
            readonly FieldsTestClass22_Enum enuE = FieldsTestClass22_Enum.a;
            readonly FieldsTestClass22_Struct sctS = new FieldsTestClass22_Struct(3);
            readonly FieldsTestClass22_Sub clsC = new FieldsTestClass22_Sub(4);

            public static bool testMethod()
            {

                FieldsTestClass22 MC = new FieldsTestClass22();

                if ((MC.intI == 2) && (MC.strS.Equals("MyString")) && (MC.enuE == FieldsTestClass22_Enum.a) && (MC.sctS.Test == 3) && (MC.clsC.Test == 4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        enum FieldsTestClass23_Enum { a = 1, b = 2 }

        struct FieldsTestClass23_Struct
        {
            public FieldsTestClass23_Struct(int intI)
            {
                Test = intI;
            }
            public int Test;
        }

        struct FieldsTestClass23_Sub
        {
            public FieldsTestClass23_Sub(int intI)
            {
                Test = intI;
            }
            public int Test;
        }

        class FieldsTestClass23
        {

            public FieldsTestClass23()
            {
                intI = 2;
                strS = "MyString";
                enuE = FieldsTestClass23_Enum.a;
                sctS = new FieldsTestClass23_Struct(3);
                clsC = new FieldsTestClass23_Sub(4);
            }

            readonly int intI;
            readonly string strS;
            readonly FieldsTestClass23_Enum enuE;
            readonly FieldsTestClass23_Struct sctS;
            readonly FieldsTestClass23_Sub clsC;

            public static bool testMethod()
            {

                FieldsTestClass23 MC = new FieldsTestClass23();

                if ((MC.intI == 2) && (MC.strS.Equals("MyString")) && (MC.enuE == FieldsTestClass23_Enum.a) && (MC.sctS.Test == 3) && (MC.clsC.Test == 4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        enum FieldsTestClass24_Enum { a = 1, b = 2 }

        struct FieldsTestClass24_Struct
        {
            public FieldsTestClass24_Struct(int intI)
            {
                Test = intI;
            }
            public int Test;
        }

        struct FieldsTestClass24_Sub
        {
            public FieldsTestClass24_Sub(int intI)
            {
                Test = intI;
            }
            public int Test;
        }

        class FieldsTestClass24
        {

            public FieldsTestClass24()
            {
                intI = 2;
                strS = "MyString";
                enuE = FieldsTestClass24_Enum.a;
                sctS = new FieldsTestClass24_Struct(3);
                clsC = new FieldsTestClass24_Sub(4);
            }

            readonly int intI = 3;
            readonly string strS = "FooBar";
            readonly FieldsTestClass24_Enum enuE = FieldsTestClass24_Enum.b;
            readonly FieldsTestClass24_Struct sctS = new FieldsTestClass24_Struct(2);
            readonly FieldsTestClass24_Sub clsC = new FieldsTestClass24_Sub(5);

            public static bool testMethod()
            {

                FieldsTestClass24 MC = new FieldsTestClass24();

                if ((MC.intI == 2) && (MC.strS.Equals("MyString")) && (MC.enuE == FieldsTestClass24_Enum.a) && (MC.sctS.Test == 3) && (MC.clsC.Test == 4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public class FieldsTestClass41
        {

            public static readonly FieldsTestClass41 Black = new FieldsTestClass41(0, 0, 0);
            public static readonly FieldsTestClass41 White = new FieldsTestClass41(255, 255, 255);
            public static readonly FieldsTestClass41 Red = new FieldsTestClass41(255, 0, 0);
            public static readonly FieldsTestClass41 Green = new FieldsTestClass41(0, 255, 0);
            public static readonly FieldsTestClass41 Blue = new FieldsTestClass41(0, 0, 255);

            private byte red, green, blue;

            public FieldsTestClass41(byte r, byte g, byte b)
            {
                red = r;
                green = g;
                blue = b;
            }

            public void getRGB(out byte r1, out byte g1, out byte b1)
            {
                r1 = red;
                g1 = green;
                b1 = blue;
            }

            public static bool testMethod()
            {
                FieldsTestClass41 wht = FieldsTestClass41.White;
                byte r2, g2, b2;
                wht.getRGB(out r2, out g2, out b2);
                if ((r2 == 255) && (g2 == 255) && (b2 == 255))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class FieldsTestClass42
        {
            static int x = (int)0.99939082701909573000624344004393;
            int i = 100;
            string s = "Hello";

            public static bool testMethod()
            {
                try
                {
                    FieldsTestClass42 t = new FieldsTestClass42();
                    if ((x == (int)0.99939082701909573000624344004393) && (t.i == 100) && (t.s.Equals("Hello")))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
        public class FieldsTestClass43
        {

            static int intI;
            static int intJ = 2;

            //intJ should be initialized before we enter the static constructor
            static FieldsTestClass43()
            {
                intI = intJ;
            }

            public static bool testMethod()
            {
                if (intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class FieldsTestClass44
        {

            static int intI = 2;
            //intI is initialized before intJ
            static int intJ = intI + 3;

            public static bool testMethod()
            {
                if (intJ == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public class FieldsTestClass45
        {

            //intI is initialized after intJ
            static int intJ = intI + 3;
            static int intI = 2;

            public static bool testMethod()
            {
                if (intJ == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public class FieldsTestClass46
        {

            int intI = 2;
            int intJ;
            int intK;

            public FieldsTestClass46()
            {
                //int I should already be initialized
                intJ = intI;
            }

            public FieldsTestClass46(int DummyInt)
            {
                //int I should already be initialized
                intK = intI;
            }

            public static bool testMethod()
            {
                FieldsTestClass46 test1 = new FieldsTestClass46();
                FieldsTestClass46 test2 = new FieldsTestClass46(0);
                if ((test1.intJ == 2) && (test2.intK == 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public class FieldsTestClass49
        {

            public static int intI = 2;
            public int intK = intI;

            public static bool testMethod()
            {
                FieldsTestClass49 test = new FieldsTestClass49();
                if (test.intK == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass51
        {

            FieldsTestClass51()
            {
                MyMeth1(ref intI);
                MyMeth2(out intJ);
            }

            public static void MyMeth1(ref int i)
            {
                i = 2;
            }

            public static void MyMeth2(out int j)
            {
                j = 3;
            }


            public readonly int intI;
            public readonly int intJ;


            public static bool testMethod()
            {
                FieldsTestClass51 mc = new FieldsTestClass51();
                if ((mc.intI == 2) && (mc.intJ == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass52
        {

            static FieldsTestClass52()
            {
                MyMeth1(ref intI);
                MyMeth2(out intJ);
            }

            public static void MyMeth1(ref int i)
            {
                i = 2;
            }

            public static void MyMeth2(out int j)
            {
                j = 3;
            }


            public static readonly int intI;
            public static readonly int intJ;


            public static bool testMethod()
            {
                if ((FieldsTestClass52.intI == 2) && (FieldsTestClass52.intJ == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass53
        {

            public static bool b1 = (3 == 3);
            public static bool b2 = (3 == 4);
            public bool b3 = (3 == 3);
            public bool b4 = (3 == 4);

            public static bool testMethod()
            {

                FieldsTestClass53 mc = new FieldsTestClass53();

                if ((b1 == true) && (b2 == false) && (mc.b3 == true) && (mc.b4 == false))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass54
        {

            public static bool b1 = RetTrue();
            public static bool b2 = RetFalse();
            public bool b3 = RetTrue();
            public bool b4 = RetFalse();

            public static bool RetTrue()
            {
                return true;
            }
            public static bool RetFalse()
            {
                return false;
            }

            public static bool testMethod()
            {

                FieldsTestClass54 mc = new FieldsTestClass54();

                if ((b1 == true) && (b2 == false) && (mc.b3 == true) && (mc.b4 == false))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass55
        {

            public static int i1 = (3 & 6);
            public static int i2 = (3 | 6);
            public int i3 = (3 & 6);
            public int i4 = (3 | 6);

            public static bool testMethod()
            {

                FieldsTestClass55 mc = new FieldsTestClass55();

                if ((i1 == 2) && (i2 == 7) && (mc.i3 == 2) && (mc.i4 == 7))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass56
        {

            public static int i1 = Ret2();
            public static int i2 = Ret7();
            public int i3 = Ret2();
            public int i4 = Ret7();

            public static int Ret2()
            {
                return 2;
            }

            public static int Ret7()
            {
                return 7;
            }

            public static bool testMethod()
            {

                FieldsTestClass56 mc = new FieldsTestClass56();

                if ((i1 == 2) && (i2 == 7) && (mc.i3 == 2) && (mc.i4 == 7))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass57
        {

            public static string s1 = "foo" + "bar";
            public static string s2 = "bar" + "foo";
            public string s3 = "foo" + "bar";
            public string s4 = "bar" + "foo";

            public static bool testMethod()
            {

                FieldsTestClass57 mc = new FieldsTestClass57();

                if ((s1 == "foobar") && (s2 == "barfoo") && (mc.s3 == "foobar") && (mc.s4 == "barfoo"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FieldsTestClass58
        {

            public static string s1 = Ret1();
            public static string s2 = Ret2();
            public string s3 = Ret1();
            public string s4 = Ret2();

            public static string Ret1()
            {
                return "foobar";
            }

            public static string Ret2()
            {
                return "barfoo";
            }

            public static bool testMethod()
            {
                try
                {
                    FieldsTestClass58 mc = new FieldsTestClass58();

                    if ((s1 == "foobar") && (s2 == "barfoo") && (mc.s3 == "foobar") && (mc.s4 == "barfoo"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch { return false; }
            }
        }

    }
}

