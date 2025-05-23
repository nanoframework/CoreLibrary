﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestClasses
{
    [TestClass]
    class UnitTestConstsTests
    {
        [TestMethod]
        public void Const1_Test()
        {
            //Ported from const1.cs
            // Section 10.3
            // A constant-declaration may include a set of attributes,
            // a new modifier, and one of four access modifiers.  The
            // attributes and modifiers apply to all of the members 
            // declared by the constant declaration.
            Assert.IsTrue(ConstTestClass1.test());
        }

        [TestMethod]
        public void Const2_Test()
        {
            //Ported from const2.cs
            // Section 10.3
            // A constant-declaration may include a set of attributes,
            // a new modifier, and one of four access modifiers.  The
            // attributes and modifiers apply to all of the members 
            // declared by the constant declaration.
            Assert.IsTrue(ConstTestClass2.test());
        }

        [TestMethod]
        public void Const3_Test()
        {
            //Ported from const3.cs
            // Section 10.3
            // A constant-declaration may include a set of attributes,
            // a new modifier, and one of four access modifiers.  The
            // attributes and modifiers apply to all of the members 
            // declared by the constant declaration.
            Assert.IsTrue(ConstTestClass3.test());

        }

        [TestMethod]
        public void Const4_Test()
        {
            //Ported from const4.cs
            // Section 10.3
            // A constant-declaration may include a set of attributes,
            // a new modifier, and one of four access modifiers.  The
            // attributes and modifiers apply to all of the members 
            // declared by the constant declaration.
            Assert.IsTrue(ConstTestClass4.test());
        }

        [TestMethod]
        public void Const5_Test()
        {
            //Ported from const5.cs
            // Section 10.3
            // A constant-declaration may include a set of attributes,
            // a new modifier, and one of four access modifiers.  The
            // attributes and modifiers apply to all of the members 
            // declared by the constant declaration.
            Assert.IsTrue(ConstTestClass5.test());
        }

        [TestMethod]
        public void Const6_Test()
        {
            //Ported from const6.cs
            // Section 10.3
            // A constant-declaration may include a set of attributes,
            // a new modifier, and one of four access modifiers.  The
            // attributes and modifiers apply to all of the members 
            // declared by the constant declaration.
            Assert.IsTrue(ConstTestClass6.test());
        }


        [TestMethod]
        public void Const9_Test()
        {
            //Ported from const9.cs
            // Section 10.3
            // A constant-declaration may include a set of attributes,
            // a new modifier, and one of four access modifiers.  The
            // attributes and modifiers apply to all of the members 
            // declared by the constant declaration.
            Assert.IsTrue(ConstTestClass9.test());
        }


        [TestMethod]
        public void Const11_Test()
        {
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            //Ported from const11.cs
            Assert.IsTrue(ConstTestClass11.test());
        }

        [TestMethod]
        public void Const12_Test()
        {
            //Ported from const12.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass12.test());
        }

        [TestMethod]
        public void Const13_Test()
        {
            //Ported from const13.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass13.test());
        }

        [TestMethod]
        public void Const14_Test()
        {
            //Ported from const14.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass14.test());
        }

        [TestMethod]
        public void Const15_Test()
        {
            //Ported from const15.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass15.test());
        }

        [TestMethod]
        public void Const16_Test()
        {
            //Ported from const16.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass16.test());
        }

        [TestMethod]
        public void Const17_Test()
        {
            //Ported from const17.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass17.test());
        }

        [TestMethod]
        public void Const18_Test()
        {
            //Ported from const18.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass18.test());
        }

        [TestMethod]
        public void Const19_Test()
        {
            //Ported from const19.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass19.test());
        }

        [TestMethod]
        public void Const20_Test()
        {
            //Ported from const20.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass20.test());
        }

        [TestMethod]
        public void Const21_Test()
        {
            //Ported from const21.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass21.test());
        }

        [TestMethod]
        public void Const24_Test()
        {
            //Ported from const24.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass24.test());
        }

        [TestMethod]
        public void Const25_Test()
        {
            //Ported from const25.cs
            // Section 10.3
            // A constant itself can participate in a constant-expression.
            // Thus, a constant may be used in any construct that requires
            // a constant-expression.  Examples of such constructs include
            // case labels, goto case statements, enum member declarations,
            // attributes, and other constant declarations.
            Assert.IsTrue(ConstTestClass25.test());
        }

        [TestMethod]
        public void Const26_Test()
        {
            //Ported from const26.cs
            // Section 10.3
            // A constant itself can participate in a constant-expression.
            // Thus, a constant may be used in any construct that requires
            // a constant-expression.  Examples of such constructs include
            // case labels, goto case statements, enum member declarations,
            // attributes, and other constant declarations.
            Assert.IsTrue(ConstTestClass26.test());
        }

        [TestMethod]
        public void Const27_Test()
        {
            //Ported from const27.cs
            // Section 10.3
            // A constant itself can participate in a constant-expression.
            // Thus, a constant may be used in any construct that requires
            // a constant-expression.  Examples of such constructs include
            // case labels, goto case statements, enum member declarations,
            // attributes, and other constant declarations.
            Assert.IsTrue(ConstTestClass27.test());
        }

        [TestMethod]
        public void Const28_Test()
        {
            //Ported from const28.cs
            // Section 10.3
            // A constant itself can participate in a constant-expression.
            // Thus, a constant may be used in any construct that requires
            // a constant-expression.  Examples of such constructs include
            // case labels, goto case statements, enum member declarations,
            // attributes, and other constant declarations.
            Assert.IsTrue(ConstTestClass28.test());
        }

        [TestMethod]
        public void Const30_Test()
        {
            //Ported from const30.cs
            // Section 10.3
            // Constants are permitted to depend on other constants
            // within the same project as long as the dependencies
            // are not of a circular nature.  The compiler automatically
            // arranges to evaluate the constant declarations in the
            // appropriate order.
            Assert.IsTrue(ConstTestClass30.test());
        }

        [TestMethod]
        public void Const32_Test()
        {
            //Ported from const32.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass32.test());
        }

        [TestMethod]
        public void Const33_Test()
        {
            //Ported from const33.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass33.test());
        }

        [TestMethod]
        public void Const34_Test()
        {
            //Ported from const34.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass34.test());
        }

        [TestMethod]
        public void Const35_Test()
        {
            //Ported from const35.cs
            // Section 10.3
            // The type specified in a constant declaration
            // must be byte, char, short, int, long, float,
            // double, double, bool, string, an enum-type,
            // or a reference type.  Each constant-expression
            // must yield a value of the target type or of a 
            // type that can be converted to the target type
            // by implicit conversion.
            Assert.IsTrue(ConstTestClass35.test());
        }

        [TestMethod]
        public void Const42_Test()
        {
            //Ported from const42.cs
            // Section 10.3
            // A constant declarator introduces a new member
            // This test is expected to fail
            Assert.IsFalse(ConstTestClass42.test());
            {
                // This failure indicates a test is now passing that previously failed by design.
                // It previously marked as known failure because of bug # 17246
                // The Test owner needs to verify that the change was intentional and remove the known failure.
            }
        }

        [TestMethod]
        public void Const43_Test()
        {
            //Ported from const43.cs
            // Section 10.3
            // A constant declarator introduces a new member
            // This test is expected to fail
            Assert.IsFalse(ConstTestClass43.test());
            {
                // This failure indicates a test is now passing that previously failed by design.
                // It previously marked as known failure because of bug # 17246
                // The Test owner needs to verify that the change was intentional and remove the known failure.
            }
        }

        [TestMethod]
        public void Const44_Test()
        {
            //Ported from const44.cs
            // Section 10.3
            // The type of a constant must be at least as acccessible as the constant itself.
            Assert.IsTrue(ConstTestClass44.test());
        }


        [TestMethod]
        public void Const56_Test()
        {
            //Ported from const56.cs
            // Section 10.3
            // ...the only possible value for constants of reference-types other than 
            // string is null
            Assert.IsTrue(ConstTestClass56.test());
        }

        [TestMethod]
        public void Const57_Test()
        {
            //Ported from const57.cs
            // Section 10.3
            // A constant declaration that declares multiple constants is equivalent to 
            // multiple declarations of single constants with the same attributes, 
            // modifiers, and type. 
            Assert.IsTrue(ConstTestClass57.test());
        }

        //Const test classes
        class ConstTestClass1
        {
            const int intI = 2;

            public static bool test()
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

        class ConstTestClass2_base
        {
            public const int intI = 1;
        }

        class ConstTestClass2 : ConstTestClass2_base
        {
            new const int intI = 2;

            public static bool test()
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

        class ConstTestClass3
        {
            public const int intI = 2;

            public static bool test()
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

        class ConstTestClass4
        {
            protected const int intI = 2;

            public static bool test()
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

        class ConstTestClass5
        {
            internal const int intI = 2;

            public static bool test()
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

        class ConstTestClass6
        {

            private const int intI = 2;

            public static bool test()
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

        class ConstTestClass7_sub
        {
            protected const int intI = 2;
        }

        class ConstTestClass9_sub
        {
            public const int intI = 2, intJ = 3;
        }

        class ConstTestClass9
        {

            public static bool test()
            {
                if ((ConstTestClass9_sub.intI == 2) && (ConstTestClass9_sub.intJ == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass11
        {

            const byte byteB = 2;

            public static bool test()
            {
                if (byteB == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass12
        {

            const char charC = 'b';

            public static bool test()
            {
                if (charC == 'b')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass13
        {

            const short shortS = 2;

            public static bool test()
            {
                if (shortS == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass14
        {
            //This appears to be a duplicate of Test 1
            const int IntI = 2;

            public static bool test()
            {
                if (IntI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass15
        {

            const long longL = 2L;

            public static bool test()
            {
                if (longL == 2L)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass16
        {

            const float floatF = 2.0F;

            public static bool test()
            {
                if (floatF == 2.0F)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass17
        {

            const double doubleD = 2.0D;

            public static bool test()
            {
                if (doubleD == 2.0D)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass18
        {
            //Is this OK to cast?
            const double doubleD = (double)2.0;

            public static bool test()
            {
                if (doubleD == (double)2.0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass19
        {

            const bool boolB = true;

            public static bool test()
            {
                if (boolB)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass20
        {

            const string stringS = "mytest";

            public static bool test()
            {
                if (stringS.Equals("mytest"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        enum ConstTestClass21Enum { a = 1, b = 2 }

        class ConstTestClass21
        {

            const ConstTestClass21Enum enumE = ConstTestClass21Enum.a;

            public static bool test()
            {
                if (enumE == ConstTestClass21Enum.a)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass24
        {

            const double doubleD = 2.0F;

            public static bool test()
            {
                if (doubleD == 2.0D)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass25
        {

            const int MyInt = 1;

            public static bool test()
            {

                int intI = 1;

                switch (intI)
                {
                    case MyInt:
                        return true;
                    default:
                        return false;
                }
            }
        }

        class ConstTestClass26
        {

            const int MyInt = 1;

            public static bool test()
            {

                int intI = 2;

                switch (intI)
                {
                    case 1:
                        return true;
                    case 2:
                        goto case MyInt;
                    default:
                        return false;
                }
            }
        }

        class ConstTestClass27
        {
            const int MyInt = 2;

            enum MyEnum { a = 1, b = MyInt }

            public static bool test()
            {
                if (MyEnum.b == (MyEnum)2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass28
        {

            const int MyInt = 2;
            const int MyTest = MyInt;

            public static bool test()
            {
                if (MyTest == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass30_sub
        {
            public const int X = ConstTestClass30.Z + 1;
            public const int Y = 10;
        }
        class ConstTestClass30
        {
            public const int Z = ConstTestClass30_sub.Y + 1;
            public static bool test()
            {
                if ((ConstTestClass30_sub.Y == 10) && (ConstTestClass30.Z == 11) && (ConstTestClass30_sub.X == 12))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass32
        {

            const sbyte sbyteS = 2;

            public static bool test()
            {
                if (sbyteS == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass33
        {

            const ushort ushortU = 2;

            public static bool test()
            {
                if (ushortU == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass34
        {

            const uint uintU = 2;

            public static bool test()
            {
                if (uintU == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass35
        {

            const ulong ulongU = 2;

            public static bool test()
            {
                if (ulongU == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstTestClass42
        {
            const int intI = 10;

            public static bool test()
            {
                bool retval = false;
                FieldInfo fi = typeof(ConstTestClass42).GetField("intI", BindingFlags.NonPublic | BindingFlags.Static);
                if (null != fi)
                    retval = true;
                return retval;
            }
        }

        class ConstTestClass43
        {

            const int intI = 10;

            public static bool test()
            {
                bool retval = false;
                FieldInfo fi = typeof(ConstTestClass43).GetField("intI", BindingFlags.NonPublic | BindingFlags.Static);
                if (null != fi)
                    if ((int)fi.GetValue(ConstTestClass43.intI) == 10)
                        retval = true;
                return retval;
            }
        }

        class ConstTestClass44
        {

            enum E { zero, one, two, three };
            const E enumE = E.two;

            public static bool test()
            {
                bool retval = false;

                if (enumE == E.two)
                    retval = true;
                return retval;
            }
        }

        class ConstTestClass55_sub
        {
            int _i;
            public ConstTestClass55_sub(int i) { _i = i; }
            public int GetI() { return _i; }
        }

        class ConstTestClass56_sub
        {
            int _i;
            public ConstTestClass56_sub(int i) { _i = i; }
            public int GetI() { return _i; }
        }

        class ConstTestClass56
        {

            public readonly ConstTestClass56_sub mc = new ConstTestClass56_sub(10);

            public static bool test()
            {
                bool retval = false;
                ConstTestClass56 mmc = new ConstTestClass56();
                if (mmc.mc.GetI() == 10)
                    retval = true;
                return retval;
            }
        }

        class ConstTestClass57_sub_A
        {
            public const double X = 1.0, Y = 2.0, Z = 3.0;
        }

        class ConstTestClass57_sub_B
        {
            public const double X = 1.0;
            public const double Y = 2.0;
            public const double Z = 3.0;
        }

        class ConstTestClass57
        {
            public static bool test()
            {
                bool retval = false;
                ConstTestClass57 mmc = new ConstTestClass57();
                if ((ConstTestClass57_sub_A.X == ConstTestClass57_sub_B.X)
                    && (ConstTestClass57_sub_A.Y == ConstTestClass57_sub_B.Y)
                    && (ConstTestClass57_sub_A.Z == ConstTestClass57_sub_B.Z))
                    retval = true;
                return retval;
            }
        }

    }
}
