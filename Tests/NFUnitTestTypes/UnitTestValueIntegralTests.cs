//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

// disable a number of warnings that we are intentionally going to test
#pragma warning disable CS1718 // Comparison made to same variable
#pragma warning disable CS0675 // Bitwise-or operator used on a sign-extended operand

namespace NFUnitTestTypes
{
    [TestClass]
    class UnitTestValueIntegralTests
    {
        [TestMethod]
        public void ValueIntegral01_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the +, - and ~ unary operators, of the operand is of type long, the");
            OutputHelper.WriteLine(" operation is performed using 64-bit precision, and the type of the result");
            OutputHelper.WriteLine(" is long.  Otherwise, the operand is converted to int, and operation is");
            OutputHelper.WriteLine(" performed using 32-bit precision, and the type of the result is int.");
            ValueIntegralTestClass01.testMethod();
        }
        [TestMethod]
        public void ValueIntegral05_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the +, - and ~ unary operators, of the operand is of type long, the");
            OutputHelper.WriteLine(" operation is performed using 64-bit precision, and the type of the result");
            OutputHelper.WriteLine(" is long.  Otherwise, the operand is converted to int, and operation is");
            OutputHelper.WriteLine(" performed using 32-bit precision, and the type of the result is int.");
            ValueIntegralTestClass05.testMethod();
        }
        [TestMethod]
        public void ValueIntegral09_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the +, - and ~ unary operators, of the operand is of type long, the");
            OutputHelper.WriteLine(" operation is performed using 64-bit precision, and the type of the result");
            OutputHelper.WriteLine(" is long.  Otherwise, the operand is converted to int, and operation is");
            OutputHelper.WriteLine(" performed using 32-bit precision, and the type of the result is int.");
            ValueIntegralTestClass09.testMethod();
        }
        [TestMethod]
        public void ValueIntegral13_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass13.testMethod();
        }
        [TestMethod]
        public void ValueIntegral14_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass14.testMethod();
        }
        [TestMethod]
        public void ValueIntegral15_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass15.testMethod();
        }
        [TestMethod]
        public void ValueIntegral16_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass16.testMethod();
        }
        [TestMethod]
        public void ValueIntegral17_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass17.testMethod();
        }
        [TestMethod]
        public void ValueIntegral18_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass18.testMethod();
        }
        [TestMethod]
        public void ValueIntegral19_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass19.testMethod();
        }
        [TestMethod]
        public void ValueIntegral20_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass20.testMethod();
        }
        [TestMethod]
        public void ValueIntegral21_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass21.testMethod();
        }
        [TestMethod]
        public void ValueIntegral22_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass22.testMethod();
        }
        [TestMethod]
        public void ValueIntegral23_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass23.testMethod();
        }
        [TestMethod]
        public void ValueIntegral24_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass24.testMethod();
        }
        [TestMethod]
        public void ValueIntegral25_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass25.testMethod();
        }
        [TestMethod]
        public void ValueIntegral26_Test()
        {
            OutputHelper.WriteLine(" For the binary operators other than shift, if at least one");
            OutputHelper.WriteLine(" operand is of type long, then both operands are converted to long, the operation");
            OutputHelper.WriteLine(" is performed using 64-bit precision, and the type of the result is long or bool. ");
            OutputHelper.WriteLine(" Otherwise, both operands are converted to int, the operation is performed using ");
            OutputHelper.WriteLine(" 32-bit precision, and the type of the result is int or bool.");
            ValueIntegralTestClass26.testMethod();
        }
        [TestMethod]
        public void ValueIntegral27_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the shift operators, if the left-hand operand is of type long,");
            OutputHelper.WriteLine(" the operation is performed using 64-bit precision, and the type of the result");
            OutputHelper.WriteLine(" is long.  Otherwise, the left hand-operand is converted to int, the operation is ");
            OutputHelper.WriteLine(" performed using 32-bit precision, and the type of the result is int.");
            ValueIntegralTestClass27.testMethod();
        }
        [TestMethod]
        public void ValueIntegral28_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the shift operators, if the left-hand operand is of type long,");
            OutputHelper.WriteLine(" the operation is performed using 64-bit precision, and the type of the result");
            OutputHelper.WriteLine(" is long.  Otherwise, the left hand-operand is converted to int, the operation is ");
            OutputHelper.WriteLine(" performed using 32-bit precision, and the type of the result is int.");
            ValueIntegralTestClass28.testMethod();
        }
        [TestMethod]
        public void ValueIntegral38_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" Constants of the char type must be written as character-literals.");
            OutputHelper.WriteLine(" Character constants can only be written as integer-literals");
            OutputHelper.WriteLine(" in combination with a cast. For example, (char)10 is the same as");
            OutputHelper.WriteLine(" '\x000A'.");
            ValueIntegralTestClass38.testMethod();
        }
        [TestMethod]
        public void ValueIntegral39_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the unary + and ~ operators, the operand is converted");
            OutputHelper.WriteLine(" to type T, where T is the first of int, uint, long, and");
            OutputHelper.WriteLine(" ulong that can fully represent all possible values of the");
            OutputHelper.WriteLine(" operand. The operation is then performed using the precision ");
            OutputHelper.WriteLine(" of type T, and the type of the result is T.");
            ValueIntegralTestClass39.testMethod();
        }
        [TestMethod]
        public void ValueIntegral42_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the unary + and ~ operators, the operand is converted");
            OutputHelper.WriteLine(" to type T, where T is the first of int, uint, long, and");
            OutputHelper.WriteLine(" ulong that can fully represent all possible values of the");
            OutputHelper.WriteLine(" operand. The operation is then performed using the precision ");
            OutputHelper.WriteLine(" of type T, and the type of the result is T.");
            ValueIntegralTestClass42.testMethod();
        }
        [TestMethod]
        public void ValueIntegral45_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the unary - operator, the operand is converted");
            OutputHelper.WriteLine(" to type T, where T is the first of int and long that ");
            OutputHelper.WriteLine(" can fully represent all possible values of the ");
            OutputHelper.WriteLine(" operand.  The operation is then performed using the");
            OutputHelper.WriteLine(" precision of type T, and the type of the result is T.");
            OutputHelper.WriteLine(" The unary - operator cannot be applied to operands of");
            OutputHelper.WriteLine(" type ulong.");
            ValueIntegralTestClass45.testMethod();
        }
        [TestMethod]
        public void ValueIntegral49_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass49.testMethod();
        }
        [TestMethod]
        public void ValueIntegral50_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass50.testMethod();
        }
        [TestMethod]
        public void ValueIntegral51_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass51.testMethod();
        }
        [TestMethod]
        public void ValueIntegral52_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass52.testMethod();
        }
        [TestMethod]
        public void ValueIntegral53_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass53.testMethod();
        }
        [TestMethod]
        public void ValueIntegral54_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass54.testMethod();
        }
        [TestMethod]
        public void ValueIntegral55_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass55.testMethod();
        }
        [TestMethod]
        public void ValueIntegral56_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass56.testMethod();
        }
        [TestMethod]
        public void ValueIntegral57_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass57.testMethod();
        }
        [TestMethod]
        public void ValueIntegral58_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass58.testMethod();
        }
        [TestMethod]
        public void ValueIntegral59_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass59.testMethod();
        }
        [TestMethod]
        public void ValueIntegral60_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass60.testMethod();
        }
        [TestMethod]
        public void ValueIntegral61_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass61.testMethod();
        }
        [TestMethod]
        public void ValueIntegral62_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary operators except shift, the operands");
            OutputHelper.WriteLine(" are converted to type T, where T is the first of int, uint, long, and ulong");
            OutputHelper.WriteLine(" that can fully represent all possible values of each operand. The operation");
            OutputHelper.WriteLine(" is then performed using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" is T (or bool for relational operators).");
            ValueIntegralTestClass62.testMethod();
        }
        [TestMethod]
        public void ValueIntegral63_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary shift operators, the left operand");
            OutputHelper.WriteLine(" is converted to type T, where T is the first of int,");
            OutputHelper.WriteLine(" uint, long, and ulong that can fully represent all possible");
            OutputHelper.WriteLine(" values of the operand. The operation is then performed");
            OutputHelper.WriteLine(" using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" T.");
            ValueIntegralTestClass63.testMethod();
        }
        [TestMethod]
        public void ValueIntegral64_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" For the binary shift operators, the left operand");
            OutputHelper.WriteLine(" is converted to type T, where T is the first of int,");
            OutputHelper.WriteLine(" uint, long, and ulong that can fully represent all possible");
            OutputHelper.WriteLine(" values of the operand. The operation is then performed");
            OutputHelper.WriteLine(" using the precision of type T, and the type of the result");
            OutputHelper.WriteLine(" T.");
            ValueIntegralTestClass64.testMethod();
        }
        [TestMethod]
        public void ValueIntegral70_Test()
        {
            OutputHelper.WriteLine(" Section 4.1");
            OutputHelper.WriteLine(" Constants of the char type must be written as character-literals.");
            OutputHelper.WriteLine(" Character constants can only be written as integer-literals");
            OutputHelper.WriteLine(" in compination with a cast.  For example, (char)10 is the same ");
            OutputHelper.WriteLine(" as '\x000a'.");
            ValueIntegralTestClass70.testMethod();
        }


        //Compiled Test Cases 
        public class ValueIntegralTestClass01
        {
            public static void testMethod()
            {
                short s1 = 2;
                short s2 = (short)-s1;
                byte b1 = 3;
                int b2 = -b1;
                int i1 = 4;
                int i2 = -i1;
                long l1 = 5L;
                long l2 = -l1;
                char c1 = (char)6;
                int c2 = -c1;

                Assert.Equal(s2, (short)-2);
                Assert.Equal(b2, -3);
                Assert.Equal(i2, -4);
                Assert.Equal(l2, -5L);
                Assert.Equal(c2, -6);
                Assert.Equal(i2, -4);
                Assert.Equal(l2, -5L);
                Assert.Equal(c2, -6);
            }
        }
        public class ValueIntegralTestClass05
        {
            public static void testMethod()
            {
                short s1 = 2;
                short s2 = (short)+s1;
                byte b1 = 3;
                int b2 = +b1;
                int i1 = 4;
                int i2 = +i1;
                long l1 = 5;
                long l2 = +l1;
                char c1 = (char)6;
                int c2 = +c1;

                Assert.Equal(s2, (short)2);
                Assert.Equal(b2, 3);
                Assert.Equal(i2, 4);
                Assert.Equal(l2, 5L);
                Assert.Equal(c2, 6);
            }
        }
        public class ValueIntegralTestClass09
        {
            public static void testMethod()
            {
                short s1 = 2;
                short s2 = (short)~s1;
                byte b1 = 3;
                int b2 = ~b1;
                int i1 = 4;
                int i2 = ~i1;
                long l1 = 5L;
                long l2 = ~l1;
                char c1 = (char)6;
                int c2 = ~c1;

                Assert.Equal(s2, (short)-3);
                Assert.Equal(b2, -4);
                Assert.Equal(i2, -5);
                Assert.Equal(l2, -6L);
                Assert.Equal(c2, -7);
            }
        }
        public class ValueIntegralTestClass13
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 + s1).GetType(), i1.GetType());
                Assert.IsType((s1 + b1).GetType(), i1.GetType());
                Assert.IsType((s1 + i1).GetType(), i1.GetType());
                Assert.IsType((s1 + l1).GetType(), l1.GetType());
                Assert.IsType((s1 + c1).GetType(), i1.GetType());
                //byte
                Assert.IsType((b1 + b1).GetType(), i1.GetType());
                Assert.IsType((b1 + i1).GetType(), i1.GetType());
                Assert.IsType((b1 + l1).GetType(), l1.GetType());
                Assert.IsType((b1 + c1).GetType(), i1.GetType());
                //int
                Assert.IsType((i1 + i1).GetType(), i1.GetType());
                Assert.IsType((i1 + l1).GetType(), l1.GetType());
                Assert.IsType((i1 + c1).GetType(), i1.GetType());
                //long
                Assert.IsType((l1 + l1).GetType(), l1.GetType());
                Assert.IsType((l1 + c1).GetType(), l1.GetType());
                //char
                Assert.IsType((c1 + c1).GetType(), i1.GetType());
            }
        }
        public class ValueIntegralTestClass14
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 - s1).GetType(), i1.GetType());
                Assert.IsType((s1 - b1).GetType(), i1.GetType());
                Assert.IsType((s1 - i1).GetType(), i1.GetType());
                Assert.IsType((s1 - l1).GetType(), l1.GetType());
                Assert.IsType((s1 - c1).GetType(), i1.GetType());
                //byte
                Assert.IsType((b1 - b1).GetType(), i1.GetType());
                Assert.IsType((b1 - i1).GetType(), i1.GetType());
                Assert.IsType((b1 - l1).GetType(), l1.GetType());
                Assert.IsType((b1 - c1).GetType(), i1.GetType());
                //int
                Assert.IsType((i1 - i1).GetType(), i1.GetType());
                Assert.IsType((i1 - l1).GetType(), l1.GetType());
                Assert.IsType((i1 - c1).GetType(), i1.GetType());
                //long
                Assert.IsType((l1 - l1).GetType(), l1.GetType());
                Assert.IsType((l1 - c1).GetType(), l1.GetType());
                //char
                Assert.IsType((c1 - c1).GetType(), i1.GetType());
            }
        }
        public class ValueIntegralTestClass15
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 * s1).GetType(), i1.GetType());
                Assert.IsType((s1 * b1).GetType(), i1.GetType());
                Assert.IsType((s1 * i1).GetType(), i1.GetType());
                Assert.IsType((s1 * l1).GetType(), l1.GetType());
                Assert.IsType((s1 * c1).GetType(), i1.GetType());
                //byte                                            
                Assert.IsType((b1 * b1).GetType(), i1.GetType());
                Assert.IsType((b1 * i1).GetType(), i1.GetType());
                Assert.IsType((b1 * l1).GetType(), l1.GetType());
                Assert.IsType((b1 * c1).GetType(), i1.GetType());
                //int                                             
                Assert.IsType((i1 * i1).GetType(), i1.GetType());
                Assert.IsType((i1 * l1).GetType(), l1.GetType());
                Assert.IsType((i1 * c1).GetType(), i1.GetType());
                //long
                Assert.IsType((l1 * l1).GetType(), l1.GetType());
                Assert.IsType((l1 * c1).GetType(), l1.GetType());
                //char
                Assert.IsType((c1 * c1).GetType(), i1.GetType());
            }
        }
        public class ValueIntegralTestClass16
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                Assert.IsType((s1 / s1).GetType(), i1.GetType());
                Assert.IsType((s1 / b1).GetType(), i1.GetType());
                Assert.IsType((s1 / i1).GetType(), i1.GetType());
                Assert.IsType((s1 / l1).GetType(), l1.GetType());
                Assert.IsType((s1 / c1).GetType(), i1.GetType());
                Assert.IsType((b1 / b1).GetType(), i1.GetType());
                Assert.IsType((b1 / i1).GetType(), i1.GetType());
                Assert.IsType((b1 / l1).GetType(), l1.GetType());
                Assert.IsType((b1 / c1).GetType(), i1.GetType());
                Assert.IsType((i1 / i1).GetType(), i1.GetType());
                Assert.IsType((i1 / l1).GetType(), l1.GetType());
                Assert.IsType((i1 / c1).GetType(), i1.GetType());
                Assert.IsType((l1 / l1).GetType(), l1.GetType());
                Assert.IsType((l1 / c1).GetType(), l1.GetType());
                Assert.IsType((c1 / c1).GetType(), i1.GetType());
            }
        }
        public class ValueIntegralTestClass17
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 % s1).GetType(), i1.GetType());
                Assert.IsType((s1 % b1).GetType(), i1.GetType());
                Assert.IsType((s1 % i1).GetType(), i1.GetType());
                Assert.IsType((s1 % l1).GetType(), l1.GetType());
                Assert.IsType((s1 % c1).GetType(), i1.GetType());
                Assert.IsType((b1 % b1).GetType(), i1.GetType());
                Assert.IsType((b1 % i1).GetType(), i1.GetType());
                Assert.IsType((b1 % l1).GetType(), l1.GetType());
                Assert.IsType((b1 % c1).GetType(), i1.GetType());
                Assert.IsType((i1 % i1).GetType(), i1.GetType());
                Assert.IsType((i1 % l1).GetType(), l1.GetType());
                Assert.IsType((i1 % c1).GetType(), i1.GetType());
                Assert.IsType((l1 % l1).GetType(), l1.GetType());
                Assert.IsType((l1 % c1).GetType(), l1.GetType());
                Assert.IsType((c1 % c1).GetType(), i1.GetType());
            }
        }
        public class ValueIntegralTestClass18
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 & s1).GetType(), i1.GetType());
                Assert.IsType((s1 & b1).GetType(), i1.GetType());
                Assert.IsType((s1 & i1).GetType(), i1.GetType());
                Assert.IsType((s1 & l1).GetType(), l1.GetType());
                Assert.IsType((s1 & c1).GetType(), i1.GetType());
                Assert.IsType((b1 & b1).GetType(), i1.GetType());
                Assert.IsType((b1 & i1).GetType(), i1.GetType());
                Assert.IsType((b1 & l1).GetType(), l1.GetType());
                Assert.IsType((b1 & c1).GetType(), i1.GetType());
                Assert.IsType((i1 & i1).GetType(), i1.GetType());
                Assert.IsType((i1 & l1).GetType(), l1.GetType());
                Assert.IsType((i1 & c1).GetType(), i1.GetType());
                Assert.IsType((l1 & l1).GetType(), l1.GetType());
                Assert.IsType((l1 & c1).GetType(), l1.GetType());
                Assert.IsType((c1 & c1).GetType(), i1.GetType());
            }
        }
        public class ValueIntegralTestClass19
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 ^ s1).GetType(), i1.GetType());
                Assert.IsType((s1 ^ b1).GetType(), i1.GetType());
                Assert.IsType((s1 ^ i1).GetType(), i1.GetType());
                Assert.IsType((s1 ^ l1).GetType(), l1.GetType());
                Assert.IsType((s1 ^ c1).GetType(), i1.GetType());
                Assert.IsType((b1 ^ b1).GetType(), i1.GetType());
                Assert.IsType((b1 ^ i1).GetType(), i1.GetType());
                Assert.IsType((b1 ^ l1).GetType(), l1.GetType());
                Assert.IsType((b1 ^ c1).GetType(), i1.GetType());
                Assert.IsType((i1 ^ i1).GetType(), i1.GetType());
                Assert.IsType((i1 ^ l1).GetType(), l1.GetType());
                Assert.IsType((i1 ^ c1).GetType(), i1.GetType());
                Assert.IsType((l1 ^ l1).GetType(), l1.GetType());
                Assert.IsType((l1 ^ c1).GetType(), l1.GetType());
                Assert.IsType((c1 ^ c1).GetType(), i1.GetType());
            }
        }
        public class ValueIntegralTestClass20
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 | s1).GetType(), i1.GetType());
                Assert.IsType((s1 | b1).GetType(), i1.GetType());
                Assert.IsType((s1 | i1).GetType(), i1.GetType());
                Assert.IsType((s1 | l1).GetType(), l1.GetType());
                Assert.IsType((s1 | c1).GetType(), i1.GetType());
                Assert.IsType((b1 | b1).GetType(), i1.GetType());
                Assert.IsType((b1 | i1).GetType(), i1.GetType());
                Assert.IsType((b1 | l1).GetType(), l1.GetType());
                Assert.IsType((b1 | c1).GetType(), i1.GetType());
                Assert.IsType((i1 | i1).GetType(), i1.GetType());
                Assert.IsType((i1 | l1).GetType(), l1.GetType());
                Assert.IsType((i1 | c1).GetType(), i1.GetType());
                Assert.IsType((l1 | l1).GetType(), l1.GetType());
                Assert.IsType((l1 | c1).GetType(), l1.GetType());
                Assert.IsType((c1 | c1).GetType(), i1.GetType());
            }
        }
        public class ValueIntegralTestClass21
        {
            public static void testMethod()
            {
                bool TestBool = false;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 == s1).GetType(), TestBool.GetType());
                Assert.IsType((s1 == b1).GetType(), TestBool.GetType());
                Assert.IsType((s1 == i1).GetType(), TestBool.GetType());
                Assert.IsType((s1 == l1).GetType(), TestBool.GetType());
                Assert.IsType((s1 == c1).GetType(), TestBool.GetType());
                Assert.IsType((b1 == b1).GetType(), TestBool.GetType());
                Assert.IsType((b1 == i1).GetType(), TestBool.GetType());
                Assert.IsType((b1 == l1).GetType(), TestBool.GetType());
                Assert.IsType((b1 == c1).GetType(), TestBool.GetType());
                Assert.IsType((i1 == i1).GetType(), TestBool.GetType());
                Assert.IsType((i1 == l1).GetType(), TestBool.GetType());
                Assert.IsType((i1 == c1).GetType(), TestBool.GetType());
                Assert.IsType((l1 == l1).GetType(), TestBool.GetType());
                Assert.IsType((l1 == c1).GetType(), TestBool.GetType());
                Assert.IsType((c1 == c1).GetType(), TestBool.GetType());
            }
        }
        public class ValueIntegralTestClass22
        {
            public static void testMethod()
            {
                bool TestBool = false;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 != s1).GetType(), TestBool.GetType());
                Assert.IsType((s1 != b1).GetType(), TestBool.GetType());
                Assert.IsType((s1 != i1).GetType(), TestBool.GetType());
                Assert.IsType((s1 != l1).GetType(), TestBool.GetType());
                Assert.IsType((s1 != c1).GetType(), TestBool.GetType());
                Assert.IsType((b1 != b1).GetType(), TestBool.GetType());
                Assert.IsType((b1 != i1).GetType(), TestBool.GetType());
                Assert.IsType((b1 != l1).GetType(), TestBool.GetType());
                Assert.IsType((b1 != c1).GetType(), TestBool.GetType());
                Assert.IsType((i1 != i1).GetType(), TestBool.GetType());
                Assert.IsType((i1 != l1).GetType(), TestBool.GetType());
                Assert.IsType((i1 != c1).GetType(), TestBool.GetType());
                Assert.IsType((l1 != l1).GetType(), TestBool.GetType());
                Assert.IsType((l1 != c1).GetType(), TestBool.GetType());
                Assert.IsType((c1 != c1).GetType(), TestBool.GetType());
            }
        }
        public class ValueIntegralTestClass23
        {
            public static void testMethod()
            {
                bool TestBool = false;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 > s1).GetType(), TestBool.GetType());
                Assert.IsType((s1 > b1).GetType(), TestBool.GetType());
                Assert.IsType((s1 > i1).GetType(), TestBool.GetType());
                Assert.IsType((s1 > l1).GetType(), TestBool.GetType());
                Assert.IsType((s1 > c1).GetType(), TestBool.GetType());
                Assert.IsType((b1 > b1).GetType(), TestBool.GetType());
                Assert.IsType((b1 > i1).GetType(), TestBool.GetType());
                Assert.IsType((b1 > l1).GetType(), TestBool.GetType());
                Assert.IsType((b1 > c1).GetType(), TestBool.GetType());
                Assert.IsType((i1 > i1).GetType(), TestBool.GetType());
                Assert.IsType((i1 > l1).GetType(), TestBool.GetType());
                Assert.IsType((i1 > c1).GetType(), TestBool.GetType());
                Assert.IsType((l1 > l1).GetType(), TestBool.GetType());
                Assert.IsType((l1 > c1).GetType(), TestBool.GetType());
                Assert.IsType((c1 > c1).GetType(), TestBool.GetType());
            }
        }
        public class ValueIntegralTestClass24
        {
            public static void testMethod()
            {
                bool TestBool = false;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 < s1).GetType(), TestBool.GetType());
                Assert.IsType((s1 < b1).GetType(), TestBool.GetType());
                Assert.IsType((s1 < i1).GetType(), TestBool.GetType());
                Assert.IsType((s1 < l1).GetType(), TestBool.GetType());
                Assert.IsType((s1 < c1).GetType(), TestBool.GetType());
                Assert.IsType((b1 < b1).GetType(), TestBool.GetType());
                Assert.IsType((b1 < i1).GetType(), TestBool.GetType());
                Assert.IsType((b1 < l1).GetType(), TestBool.GetType());
                Assert.IsType((b1 < c1).GetType(), TestBool.GetType());
                Assert.IsType((i1 < i1).GetType(), TestBool.GetType());
                Assert.IsType((i1 < l1).GetType(), TestBool.GetType());
                Assert.IsType((i1 < c1).GetType(), TestBool.GetType());
                Assert.IsType((l1 < l1).GetType(), TestBool.GetType());
                Assert.IsType((l1 < c1).GetType(), TestBool.GetType());
                Assert.IsType((c1 < c1).GetType(), TestBool.GetType());
            }
        }
        public class ValueIntegralTestClass25
        {
            public static void testMethod()
            {
                bool TestBool = false;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 >= s1).GetType(), TestBool.GetType());
                Assert.IsType((s1 >= b1).GetType(), TestBool.GetType());
                Assert.IsType((s1 >= i1).GetType(), TestBool.GetType());
                Assert.IsType((s1 >= l1).GetType(), TestBool.GetType());
                Assert.IsType((s1 >= c1).GetType(), TestBool.GetType());
                Assert.IsType((b1 >= b1).GetType(), TestBool.GetType());
                Assert.IsType((b1 >= i1).GetType(), TestBool.GetType());
                Assert.IsType((b1 >= l1).GetType(), TestBool.GetType());
                Assert.IsType((b1 >= c1).GetType(), TestBool.GetType());
                Assert.IsType((i1 >= i1).GetType(), TestBool.GetType());
                Assert.IsType((i1 >= l1).GetType(), TestBool.GetType());
                Assert.IsType((i1 >= c1).GetType(), TestBool.GetType());
                Assert.IsType((l1 >= l1).GetType(), TestBool.GetType());
                Assert.IsType((l1 >= c1).GetType(), TestBool.GetType());
                Assert.IsType((c1 >= c1).GetType(), TestBool.GetType());
            }
        }
        public class ValueIntegralTestClass26
        {
            public static void testMethod()
            {
                bool TestBool = false;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                //short
                Assert.IsType((s1 <= s1).GetType(), TestBool.GetType());
                Assert.IsType((s1 <= b1).GetType(), TestBool.GetType());
                Assert.IsType((s1 <= i1).GetType(), TestBool.GetType());
                Assert.IsType((s1 <= l1).GetType(), TestBool.GetType());
                Assert.IsType((s1 <= c1).GetType(), TestBool.GetType());
                Assert.IsType((b1 <= b1).GetType(), TestBool.GetType());
                Assert.IsType((b1 <= i1).GetType(), TestBool.GetType());
                Assert.IsType((b1 <= l1).GetType(), TestBool.GetType());
                Assert.IsType((b1 <= c1).GetType(), TestBool.GetType());
                Assert.IsType((i1 <= i1).GetType(), TestBool.GetType());
                Assert.IsType((i1 <= l1).GetType(), TestBool.GetType());
                Assert.IsType((i1 <= c1).GetType(), TestBool.GetType());
                Assert.IsType((l1 <= l1).GetType(), TestBool.GetType());
                Assert.IsType((l1 <= c1).GetType(), TestBool.GetType());
                Assert.IsType((c1 <= c1).GetType(), TestBool.GetType());
            }
        }
        public class ValueIntegralTestClass27
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                Assert.IsType((s1 << 1).GetType(), i1.GetType());
                Assert.IsType((b1 << 1).GetType(), i1.GetType());
                Assert.IsType((i1 << 1).GetType(), i1.GetType());
                Assert.IsType((l1 << 1).GetType(), l1.GetType());
                Assert.IsType((c1 << 1).GetType(), i1.GetType());
            }
        }
        public class ValueIntegralTestClass28
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                Assert.IsType((s1 >> 1).GetType(), i1.GetType());
                Assert.IsType((b1 >> 1).GetType(), i1.GetType());
                Assert.IsType((i1 >> 1).GetType(), i1.GetType());
                Assert.IsType((l1 >> 1).GetType(), l1.GetType());
                Assert.IsType((c1 >> 1).GetType(), i1.GetType());
            }
        }
        public class ValueIntegralTestClass38
        {
            public static void testMethod()
            {
                char c = '\x000A';
                Assert.Equal(c, (char)10);
            }
        }
        public class ValueIntegralTestClass39
        {
            public static void testMethod()
            {
                ushort s1 = 2;
                ushort s2 = (ushort)+s1;
                sbyte b1 = 3;
                int b2 = +b1;
                uint i1 = 4;
                uint i2 = +i1;
                ulong l1 = 5ul;
                ulong l2 = +l1;

                Assert.Equal(s2, (ushort)2);
                Assert.Equal(b2, 3);
                Assert.Equal(i2, 4);
                Assert.Equal(l2, 5ul);
            }
        }
        public class ValueIntegralTestClass42
        {
            public static void testMethod()
            {
                checked
                {
                    ushort s1 = 2;
                    int s2 = ~s1;
                    sbyte b1 = 3;
                    int b2 = ~b1;
                    uint i1 = 4;
                    uint i2 = ~i1;
                    ulong l1 = 5ul;
                    ulong l2 = ~l1;

                    Assert.Equal(s2, -3);
                    Assert.Equal(b2, -4);
                    Assert.Equal(i2, 4294967291u);
                    Assert.Equal(l2, 18446744073709551610ul);
                }
            }
        }
        public class ValueIntegralTestClass45
        {
            public static void testMethod()
            {
                ushort s1 = 2;
                int s2 = -s1;
                sbyte b1 = 3;
                int b2 = -b1;
                uint i1 = 4;
                long i2 = -i1;

                Assert.Equal(s2, -2);
                Assert.Equal(b2, -3);
                Assert.Equal(i2, -4);
            }
        }
        public class ValueIntegralTestClass49
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                //ushort
                Assert.IsType((s2 + s1).GetType(), i1.GetType());
                Assert.IsType((s2 + b1).GetType(), i1.GetType());
                Assert.IsType((s2 + i1).GetType(), i1.GetType());
                Assert.IsType((s2 + l1).GetType(), l1.GetType());
                Assert.IsType((s2 + c1).GetType(), i1.GetType());
                Assert.IsType((s2 + s2).GetType(), i1.GetType());
                Assert.IsType((s2 + b2).GetType(), i1.GetType());
                Assert.IsType((s2 + i2).GetType(), i2.GetType());
                Assert.IsType((s2 + l2).GetType(), l2.GetType());
                Assert.IsType((b2 + s1).GetType(), i1.GetType());
                Assert.IsType((b2 + b1).GetType(), i1.GetType());
                Assert.IsType((b2 + i1).GetType(), i1.GetType());
                Assert.IsType((b2 + l1).GetType(), l1.GetType());
                Assert.IsType((b2 + c1).GetType(), i1.GetType());
                Assert.IsType((b2 + s2).GetType(), i1.GetType());
                Assert.IsType((b2 + b2).GetType(), i1.GetType());
                Assert.IsType((b2 + i2).GetType(), l1.GetType());
                Assert.IsType((i2 + s1).GetType(), l1.GetType());
                Assert.IsType((i2 + b1).GetType(), i2.GetType());
                Assert.IsType((i2 + i1).GetType(), l1.GetType());
                Assert.IsType((i2 + l1).GetType(), l1.GetType());
                Assert.IsType((i2 + c1).GetType(), i2.GetType());
                Assert.IsType((i2 + s2).GetType(), i2.GetType());
                Assert.IsType((i2 + b2).GetType(), l1.GetType());
                Assert.IsType((i2 + i2).GetType(), i2.GetType());
                Assert.IsType((i2 + l2).GetType(), l2.GetType());
                Assert.IsType((l2 + b1).GetType(), l2.GetType());
                Assert.IsType((l2 + c1).GetType(), l2.GetType());
                Assert.IsType((l2 + s2).GetType(), l2.GetType());
                Assert.IsType((l2 + i2).GetType(), l2.GetType());
                Assert.IsType((l2 + l2).GetType(), l2.GetType());
            }
        }
        public class ValueIntegralTestClass50
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                //ushort
                Assert.IsType((s2 - s1).GetType(), i1.GetType());
                Assert.IsType((s2 - i1).GetType(), i1.GetType());
                Assert.IsType((s2 - l1).GetType(), l1.GetType());
                Assert.IsType((s2 - c1).GetType(), i1.GetType());
                Assert.IsType((s2 - s2).GetType(), i1.GetType());
                Assert.IsType((s2 - b2).GetType(), i1.GetType());
                Assert.IsType((s2 - i2).GetType(), i2.GetType());
                Assert.IsType((s2 - l2).GetType(), l2.GetType());
                Assert.IsType((b2 - s1).GetType(), i1.GetType());
                Assert.IsType((b2 - b1).GetType(), i1.GetType());
                Assert.IsType((b2 - i1).GetType(), i1.GetType());
                Assert.IsType((b2 - l1).GetType(), l1.GetType());
                Assert.IsType((b2 - c1).GetType(), i1.GetType());
                Assert.IsType((b2 - s2).GetType(), i1.GetType());
                Assert.IsType((b2 - b2).GetType(), i1.GetType());
                Assert.IsType((b2 - i2).GetType(), l1.GetType());
                Assert.IsType((i2 - s1).GetType(), l1.GetType());
                Assert.IsType((i2 - b1).GetType(), i2.GetType());
                Assert.IsType((i2 - i1).GetType(), l1.GetType());
                Assert.IsType((i2 - l1).GetType(), l1.GetType());
                Assert.IsType((i2 - c1).GetType(), i2.GetType());
                Assert.IsType((i2 - s2).GetType(), i2.GetType());
                Assert.IsType((i2 - b2).GetType(), l1.GetType());
                Assert.IsType((i2 - i2).GetType(), i2.GetType());
                Assert.IsType((i2 - l2).GetType(), l2.GetType());
                Assert.IsType((l2 - b1).GetType(), l2.GetType());
                Assert.IsType((l2 - c1).GetType(), l2.GetType());
                Assert.IsType((l2 - s2).GetType(), l2.GetType());
                Assert.IsType((l2 - i2).GetType(), l2.GetType());
                Assert.IsType((l2 - l2).GetType(), l2.GetType());
            }
        }
        public class ValueIntegralTestClass51
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                //ushort
                Assert.IsType((s2 * s1).GetType(), i1.GetType());
                Assert.IsType((s2 * b1).GetType(), i1.GetType());
                Assert.IsType((s2 * i1).GetType(), i1.GetType());
                Assert.IsType((s2 * l1).GetType(), l1.GetType());
                Assert.IsType((s2 * c1).GetType(), i1.GetType());
                Assert.IsType((s2 * s2).GetType(), i1.GetType());
                Assert.IsType((s2 * b2).GetType(), i1.GetType());
                Assert.IsType((s2 * i2).GetType(), i2.GetType());
                Assert.IsType((s2 * l2).GetType(), l2.GetType());
                Assert.IsType((b2 * s1).GetType(), i1.GetType());
                Assert.IsType((b2 * b1).GetType(), i1.GetType());
                Assert.IsType((b2 * i1).GetType(), i1.GetType());
                Assert.IsType((b2 * l1).GetType(), l1.GetType());
                Assert.IsType((b2 * c1).GetType(), i1.GetType());
                Assert.IsType((b2 * s2).GetType(), i1.GetType());
                Assert.IsType((b2 * b2).GetType(), i1.GetType());
                Assert.IsType((b2 * i2).GetType(), l1.GetType());
                Assert.IsType((i2 * s1).GetType(), l1.GetType());
                Assert.IsType((i2 * b1).GetType(), i2.GetType());
                Assert.IsType((i2 * i1).GetType(), l1.GetType());
                Assert.IsType((i2 * l1).GetType(), l1.GetType());
                Assert.IsType((i2 * c1).GetType(), i2.GetType());
                Assert.IsType((i2 * s2).GetType(), i2.GetType());
                Assert.IsType((i2 * b2).GetType(), l1.GetType());
                Assert.IsType((i2 * i2).GetType(), i2.GetType());
                Assert.IsType((i2 * l2).GetType(), l2.GetType());
                Assert.IsType((l2 * b1).GetType(), l2.GetType());
                Assert.IsType((l2 * c1).GetType(), l2.GetType());
                Assert.IsType((l2 * s2).GetType(), l2.GetType());
                Assert.IsType((l2 * i2).GetType(), l2.GetType());
                Assert.IsType((l2 * l2).GetType(), l2.GetType());
            }
        }
        public class ValueIntegralTestClass52
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                //ushort
                Assert.IsType((s2 / s1).GetType(), i1.GetType());
                Assert.IsType((s2 / b1).GetType(), i1.GetType());
                Assert.IsType((s2 / i1).GetType(), i1.GetType());
                Assert.IsType((s2 / l1).GetType(), l1.GetType());
                Assert.IsType((s2 / c1).GetType(), i1.GetType());
                Assert.IsType((s2 / s2).GetType(), i1.GetType());
                Assert.IsType((s2 / b2).GetType(), i1.GetType());
                Assert.IsType((s2 / i2).GetType(), i2.GetType());
                Assert.IsType((s2 / l2).GetType(), l2.GetType());
                Assert.IsType((b2 / s1).GetType(), i1.GetType());
                Assert.IsType((b2 / b1).GetType(), i1.GetType());
                Assert.IsType((b2 / i1).GetType(), i1.GetType());
                Assert.IsType((b2 / l1).GetType(), l1.GetType());
                Assert.IsType((b2 / c1).GetType(), i1.GetType());
                Assert.IsType((b2 / s2).GetType(), i1.GetType());
                Assert.IsType((b2 / b2).GetType(), i1.GetType());
                Assert.IsType((b2 / i2).GetType(), l1.GetType());
                Assert.IsType((i2 / s1).GetType(), l1.GetType());
                Assert.IsType((i2 / b1).GetType(), i2.GetType());
                Assert.IsType((i2 / i1).GetType(), l1.GetType());
                Assert.IsType((i2 / l1).GetType(), l1.GetType());
                Assert.IsType((i2 / c1).GetType(), i2.GetType());
                Assert.IsType((i2 / s2).GetType(), i2.GetType());
                Assert.IsType((i2 / b2).GetType(), l1.GetType());
                Assert.IsType((i2 / i2).GetType(), i2.GetType());
                Assert.IsType((i2 / l2).GetType(), l2.GetType());
                Assert.IsType((l2 / b1).GetType(), l2.GetType());
                Assert.IsType((l2 / c1).GetType(), l2.GetType());
                Assert.IsType((l2 / s2).GetType(), l2.GetType());
                Assert.IsType((l2 / i2).GetType(), l2.GetType());
                Assert.IsType((l2 / l2).GetType(), l2.GetType());
            }
        }
        public class ValueIntegralTestClass53
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                //ushort
                Assert.IsType((s2 % s1).GetType(), i1.GetType());
                Assert.IsType((s2 % b1).GetType(), i1.GetType());
                Assert.IsType((s2 % i1).GetType(), i1.GetType());
                Assert.IsType((s2 % l1).GetType(), l1.GetType());
                Assert.IsType((s2 % c1).GetType(), i1.GetType());
                Assert.IsType((s2 % s2).GetType(), i1.GetType());
                Assert.IsType((s2 % b2).GetType(), i1.GetType());
                Assert.IsType((s2 % i2).GetType(), i2.GetType());
                Assert.IsType((s2 % l2).GetType(), l2.GetType());
                Assert.IsType((b2 % s1).GetType(), i1.GetType());
                Assert.IsType((b2 % b1).GetType(), i1.GetType());
                Assert.IsType((b2 % i1).GetType(), i1.GetType());
                Assert.IsType((b2 % l1).GetType(), l1.GetType());
                Assert.IsType((b2 % c1).GetType(), i1.GetType());
                Assert.IsType((b2 % s2).GetType(), i1.GetType());
                Assert.IsType((b2 % b2).GetType(), i1.GetType());
                Assert.IsType((b2 % i2).GetType(), l1.GetType());
                Assert.IsType((i2 % s1).GetType(), l1.GetType());
                Assert.IsType((i2 % b1).GetType(), i2.GetType());
                Assert.IsType((i2 % i1).GetType(), l1.GetType());
                Assert.IsType((i2 % l1).GetType(), l1.GetType());
                Assert.IsType((i2 % c1).GetType(), i2.GetType());
                Assert.IsType((i2 % s2).GetType(), i2.GetType());
                Assert.IsType((i2 % b2).GetType(), l1.GetType());
                Assert.IsType((i2 % i2).GetType(), i2.GetType());
                Assert.IsType((i2 % l2).GetType(), l2.GetType());
                Assert.IsType((l2 % b1).GetType(), l2.GetType());
                Assert.IsType((l2 % c1).GetType(), l2.GetType());
                Assert.IsType((l2 % s2).GetType(), l2.GetType());
                Assert.IsType((l2 % i2).GetType(), l2.GetType());
                Assert.IsType((l2 % l2).GetType(), l2.GetType());
            }
        }
        public class ValueIntegralTestClass54
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                //ushort
                Assert.IsType((s2 & s1).GetType(), i1.GetType());
                Assert.IsType((s2 & b1).GetType(), i1.GetType());
                Assert.IsType((s2 & i1).GetType(), i1.GetType());
                Assert.IsType((s2 & l1).GetType(), l1.GetType());
                Assert.IsType((s2 & c1).GetType(), i1.GetType());
                Assert.IsType((s2 & s2).GetType(), i1.GetType());
                Assert.IsType((s2 & b2).GetType(), i1.GetType());
                Assert.IsType((s2 & i2).GetType(), i2.GetType());
                Assert.IsType((s2 & l2).GetType(), l2.GetType());
                Assert.IsType((b2 & s1).GetType(), i1.GetType());
                Assert.IsType((b2 & b1).GetType(), i1.GetType());
                Assert.IsType((b2 & i1).GetType(), i1.GetType());
                Assert.IsType((b2 & l1).GetType(), l1.GetType());
                Assert.IsType((b2 & c1).GetType(), i1.GetType());
                Assert.IsType((b2 & s2).GetType(), i1.GetType());
                Assert.IsType((b2 & b2).GetType(), i1.GetType());
                Assert.IsType((b2 & i2).GetType(), l1.GetType());
                Assert.IsType((i2 & s1).GetType(), l1.GetType());
                Assert.IsType((i2 & b1).GetType(), i2.GetType());
                Assert.IsType((i2 & i1).GetType(), l1.GetType());
                Assert.IsType((i2 & l1).GetType(), l1.GetType());
                Assert.IsType((i2 & c1).GetType(), i2.GetType());
                Assert.IsType((i2 & s2).GetType(), i2.GetType());
                Assert.IsType((i2 & b2).GetType(), l1.GetType());
                Assert.IsType((i2 & i2).GetType(), i2.GetType());
                Assert.IsType((i2 & l2).GetType(), l2.GetType());
                Assert.IsType((l2 & b1).GetType(), l2.GetType());
                Assert.IsType((l2 & c1).GetType(), l2.GetType());
                Assert.IsType((l2 & s2).GetType(), l2.GetType());
                Assert.IsType((l2 & i2).GetType(), l2.GetType());
                Assert.IsType((l2 & l2).GetType(), l2.GetType());
            }
        }
        public class ValueIntegralTestClass55
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                //ushort
                Assert.IsType((s2 ^ s1).GetType(), i1.GetType());
                Assert.IsType((s2 ^ b1).GetType(), i1.GetType());
                Assert.IsType((s2 ^ i1).GetType(), i1.GetType());
                Assert.IsType((s2 ^ l1).GetType(), l1.GetType());
                Assert.IsType((s2 ^ c1).GetType(), i1.GetType());
                Assert.IsType((s2 ^ s2).GetType(), i1.GetType());
                Assert.IsType((s2 ^ b2).GetType(), i1.GetType());
                Assert.IsType((s2 ^ i2).GetType(), i2.GetType());
                Assert.IsType((s2 ^ l2).GetType(), l2.GetType());
                Assert.IsType((b2 ^ s1).GetType(), i1.GetType());
                Assert.IsType((b2 ^ b1).GetType(), i1.GetType());
                Assert.IsType((b2 ^ i1).GetType(), i1.GetType());
                Assert.IsType((b2 ^ l1).GetType(), l1.GetType());
                Assert.IsType((b2 ^ c1).GetType(), i1.GetType());
                Assert.IsType((b2 ^ s2).GetType(), i1.GetType());
                Assert.IsType((b2 ^ b2).GetType(), i1.GetType());
                Assert.IsType((b2 ^ i2).GetType(), l1.GetType());
                Assert.IsType((i2 ^ s1).GetType(), l1.GetType());
                Assert.IsType((i2 ^ b1).GetType(), i2.GetType());
                Assert.IsType((i2 ^ i1).GetType(), l1.GetType());
                Assert.IsType((i2 ^ l1).GetType(), l1.GetType());
                Assert.IsType((i2 ^ c1).GetType(), i2.GetType());
                Assert.IsType((i2 ^ s2).GetType(), i2.GetType());
                Assert.IsType((i2 ^ b2).GetType(), l1.GetType());
                Assert.IsType((i2 ^ i2).GetType(), i2.GetType());
                Assert.IsType((i2 ^ l2).GetType(), l2.GetType());
                Assert.IsType((l2 ^ b1).GetType(), l2.GetType());
                Assert.IsType((l2 ^ c1).GetType(), l2.GetType());
                Assert.IsType((l2 ^ s2).GetType(), l2.GetType());
                Assert.IsType((l2 ^ i2).GetType(), l2.GetType());
                Assert.IsType((l2 ^ l2).GetType(), l2.GetType());
            }
        }
        public class ValueIntegralTestClass56
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                //ushort
                Assert.IsType((s2 | s1).GetType(), i1.GetType());
                Assert.IsType((s2 | b1).GetType(), i1.GetType());
                Assert.IsType((s2 | i1).GetType(), i1.GetType());
                Assert.IsType((s2 | l1).GetType(), l1.GetType());
                Assert.IsType((s2 | c1).GetType(), i1.GetType());
                Assert.IsType((s2 | s2).GetType(), i1.GetType());
                Assert.IsType((s2 | b2).GetType(), i1.GetType());
                Assert.IsType((s2 | i2).GetType(), i2.GetType());
                Assert.IsType((s2 | l2).GetType(), l2.GetType());
                Assert.IsType((b2 | s1).GetType(), i1.GetType());
                Assert.IsType((b2 | b1).GetType(), i1.GetType());
                Assert.IsType((b2 | i1).GetType(), i1.GetType());
                Assert.IsType((b2 | l1).GetType(), l1.GetType());
                Assert.IsType((b2 | c1).GetType(), i1.GetType());
                Assert.IsType((b2 | s2).GetType(), i1.GetType());
                Assert.IsType((b2 | b2).GetType(), i1.GetType());
                Assert.IsType((b2 | i2).GetType(), l1.GetType());
                Assert.IsType((i2 | s1).GetType(), l1.GetType());
                Assert.IsType((i2 | b1).GetType(), i2.GetType());
                Assert.IsType((i2 | i1).GetType(), l1.GetType());
                Assert.IsType((i2 | l1).GetType(), l1.GetType());
                Assert.IsType((i2 | c1).GetType(), i2.GetType());
                Assert.IsType((i2 | s2).GetType(), i2.GetType());
                Assert.IsType((i2 | b2).GetType(), l1.GetType());
                Assert.IsType((i2 | i2).GetType(), i2.GetType());
                Assert.IsType((i2 | l2).GetType(), l2.GetType());
                Assert.IsType((l2 | b1).GetType(), l2.GetType());
                Assert.IsType((l2 | c1).GetType(), l2.GetType());
                Assert.IsType((l2 | s2).GetType(), l2.GetType());
                Assert.IsType((l2 | i2).GetType(), l2.GetType());
                Assert.IsType((l2 | l2).GetType(), l2.GetType());
            }
        }
        public class ValueIntegralTestClass57
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                bool b = true;
                //ushort
                Assert.IsType((s2 == s1).GetType(), b.GetType());
                Assert.IsType((s2 == b1).GetType(), b.GetType());
                Assert.IsType((s2 == i1).GetType(), b.GetType());
                Assert.IsType((s2 == l1).GetType(), b.GetType());
                Assert.IsType((s2 == c1).GetType(), b.GetType());
                Assert.IsType((s2 == s2).GetType(), b.GetType());
                Assert.IsType((s2 == b2).GetType(), b.GetType());
                Assert.IsType((s2 == i2).GetType(), b.GetType());
                Assert.IsType((s2 == l2).GetType(), b.GetType());
                Assert.IsType((b2 == s1).GetType(), b.GetType());
                Assert.IsType((b2 == b1).GetType(), b.GetType());
                Assert.IsType((b2 == i1).GetType(), b.GetType());
                Assert.IsType((b2 == l1).GetType(), b.GetType());
                Assert.IsType((b2 == c1).GetType(), b.GetType());
                Assert.IsType((b2 == s2).GetType(), b.GetType());
                Assert.IsType((b2 == b2).GetType(), b.GetType());
                Assert.IsType((b2 == i2).GetType(), b.GetType());
                Assert.IsType((i2 == s1).GetType(), b.GetType());
                Assert.IsType((i2 == b1).GetType(), b.GetType());
                Assert.IsType((i2 == i1).GetType(), b.GetType());
                Assert.IsType((i2 == l1).GetType(), b.GetType());
                Assert.IsType((i2 == c1).GetType(), b.GetType());
                Assert.IsType((i2 == s2).GetType(), b.GetType());
                Assert.IsType((i2 == b2).GetType(), b.GetType());
                Assert.IsType((i2 == i2).GetType(), b.GetType());
                Assert.IsType((i2 == l2).GetType(), b.GetType());
                Assert.IsType((l2 == b1).GetType(), b.GetType());
                Assert.IsType((l2 == c1).GetType(), b.GetType());
                Assert.IsType((l2 == s2).GetType(), b.GetType());
                Assert.IsType((l2 == i2).GetType(), b.GetType());
                Assert.IsType((l2 == l2).GetType(), b.GetType());
            }
        }
        public class ValueIntegralTestClass58
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                bool b = true;
                //ushort
                Assert.IsType((s2 != s1).GetType(), b.GetType());
                Assert.IsType((s2 != b1).GetType(), b.GetType());
                Assert.IsType((s2 != i1).GetType(), b.GetType());
                Assert.IsType((s2 != l1).GetType(), b.GetType());
                Assert.IsType((s2 != c1).GetType(), b.GetType());
                Assert.IsType((s2 != s2).GetType(), b.GetType());
                Assert.IsType((s2 != b2).GetType(), b.GetType());
                Assert.IsType((s2 != i2).GetType(), b.GetType());
                Assert.IsType((s2 != l2).GetType(), b.GetType());
                Assert.IsType((b2 != s1).GetType(), b.GetType());
                Assert.IsType((b2 != b1).GetType(), b.GetType());
                Assert.IsType((b2 != i1).GetType(), b.GetType());
                Assert.IsType((b2 != l1).GetType(), b.GetType());
                Assert.IsType((b2 != c1).GetType(), b.GetType());
                Assert.IsType((b2 != s2).GetType(), b.GetType());
                Assert.IsType((b2 != b2).GetType(), b.GetType());
                Assert.IsType((b2 != i2).GetType(), b.GetType());
                Assert.IsType((i2 != s1).GetType(), b.GetType());
                Assert.IsType((i2 != b1).GetType(), b.GetType());
                Assert.IsType((i2 != i1).GetType(), b.GetType());
                Assert.IsType((i2 != l1).GetType(), b.GetType());
                Assert.IsType((i2 != c1).GetType(), b.GetType());
                Assert.IsType((i2 != s2).GetType(), b.GetType());
                Assert.IsType((i2 != b2).GetType(), b.GetType());
                Assert.IsType((i2 != i2).GetType(), b.GetType());
                Assert.IsType((i2 != l2).GetType(), b.GetType());
                Assert.IsType((l2 != b1).GetType(), b.GetType());
                Assert.IsType((l2 != c1).GetType(), b.GetType());
                Assert.IsType((l2 != s2).GetType(), b.GetType());
                Assert.IsType((l2 != i2).GetType(), b.GetType());
                Assert.IsType((l2 != l2).GetType(), b.GetType());
            }
        }
        public class ValueIntegralTestClass59
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                bool b = true;
                //ushort
                Assert.IsType((s2 > s1).GetType(), b.GetType());
                Assert.IsType((s2 > b1).GetType(), b.GetType());
                Assert.IsType((s2 > i1).GetType(), b.GetType());
                Assert.IsType((s2 > l1).GetType(), b.GetType());
                Assert.IsType((s2 > c1).GetType(), b.GetType());
                Assert.IsType((s2 > s2).GetType(), b.GetType());
                Assert.IsType((s2 > b2).GetType(), b.GetType());
                Assert.IsType((s2 > i2).GetType(), b.GetType());
                Assert.IsType((s2 > l2).GetType(), b.GetType());
                Assert.IsType((b2 > s1).GetType(), b.GetType());
                Assert.IsType((b2 > b1).GetType(), b.GetType());
                Assert.IsType((b2 > i1).GetType(), b.GetType());
                Assert.IsType((b2 > l1).GetType(), b.GetType());
                Assert.IsType((b2 > c1).GetType(), b.GetType());
                Assert.IsType((b2 > s2).GetType(), b.GetType());
                Assert.IsType((b2 > b2).GetType(), b.GetType());
                Assert.IsType((b2 > i2).GetType(), b.GetType());
                Assert.IsType((i2 > s1).GetType(), b.GetType());
                Assert.IsType((i2 > b1).GetType(), b.GetType());
                Assert.IsType((i2 > i1).GetType(), b.GetType());
                Assert.IsType((i2 > l1).GetType(), b.GetType());
                Assert.IsType((i2 > c1).GetType(), b.GetType());
                Assert.IsType((i2 > s2).GetType(), b.GetType());
                Assert.IsType((i2 > b2).GetType(), b.GetType());
                Assert.IsType((i2 > i2).GetType(), b.GetType());
                Assert.IsType((i2 > l2).GetType(), b.GetType());
                Assert.IsType((l2 > b1).GetType(), b.GetType());
                Assert.IsType((l2 > c1).GetType(), b.GetType());
                Assert.IsType((l2 > s2).GetType(), b.GetType());
                Assert.IsType((l2 > i2).GetType(), b.GetType());
                Assert.IsType((l2 > l2).GetType(), b.GetType());
            }
        }
        public class ValueIntegralTestClass60
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                bool b = true;
                //ushort
                Assert.IsType((s2 < s1).GetType(), b.GetType());
                Assert.IsType((s2 < b1).GetType(), b.GetType());
                Assert.IsType((s2 < i1).GetType(), b.GetType());
                Assert.IsType((s2 < l1).GetType(), b.GetType());
                Assert.IsType((s2 < c1).GetType(), b.GetType());
                Assert.IsType((s2 < s2).GetType(), b.GetType());
                Assert.IsType((s2 < b2).GetType(), b.GetType());
                Assert.IsType((s2 < i2).GetType(), b.GetType());
                Assert.IsType((s2 < l2).GetType(), b.GetType());
                Assert.IsType((b2 < s1).GetType(), b.GetType());
                Assert.IsType((b2 < b1).GetType(), b.GetType());
                Assert.IsType((b2 < i1).GetType(), b.GetType());
                Assert.IsType((b2 < l1).GetType(), b.GetType());
                Assert.IsType((b2 < c1).GetType(), b.GetType());
                Assert.IsType((b2 < s2).GetType(), b.GetType());
                Assert.IsType((b2 < b2).GetType(), b.GetType());
                Assert.IsType((b2 < i2).GetType(), b.GetType());
                Assert.IsType((i2 < s1).GetType(), b.GetType());
                Assert.IsType((i2 < b1).GetType(), b.GetType());
                Assert.IsType((i2 < i1).GetType(), b.GetType());
                Assert.IsType((i2 < l1).GetType(), b.GetType());
                Assert.IsType((i2 < c1).GetType(), b.GetType());
                Assert.IsType((i2 < s2).GetType(), b.GetType());
                Assert.IsType((i2 < b2).GetType(), b.GetType());
                Assert.IsType((i2 < i2).GetType(), b.GetType());
                Assert.IsType((i2 < l2).GetType(), b.GetType());
                Assert.IsType((l2 < b1).GetType(), b.GetType());
                Assert.IsType((l2 < c1).GetType(), b.GetType());
                Assert.IsType((l2 < s2).GetType(), b.GetType());
                Assert.IsType((l2 < i2).GetType(), b.GetType());
                Assert.IsType((l2 < l2).GetType(), b.GetType());
            }
        }
        public class ValueIntegralTestClass61
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                bool b = true;
                //ushort
                Assert.IsType((s2 >= s1).GetType(), b.GetType());
                Assert.IsType((s2 >= b1).GetType(), b.GetType());
                Assert.IsType((s2 >= i1).GetType(), b.GetType());
                Assert.IsType((s2 >= l1).GetType(), b.GetType());
                Assert.IsType((s2 >= c1).GetType(), b.GetType());
                Assert.IsType((s2 >= s2).GetType(), b.GetType());
                Assert.IsType((s2 >= b2).GetType(), b.GetType());
                Assert.IsType((s2 >= i2).GetType(), b.GetType());
                Assert.IsType((s2 >= l2).GetType(), b.GetType());
                Assert.IsType((b2 >= s1).GetType(), b.GetType());
                Assert.IsType((b2 >= b1).GetType(), b.GetType());
                Assert.IsType((b2 >= i1).GetType(), b.GetType());
                Assert.IsType((b2 >= l1).GetType(), b.GetType());
                Assert.IsType((b2 >= c1).GetType(), b.GetType());
                Assert.IsType((b2 >= s2).GetType(), b.GetType());
                Assert.IsType((b2 >= b2).GetType(), b.GetType());
                Assert.IsType((b2 >= i2).GetType(), b.GetType());
                Assert.IsType((i2 >= s1).GetType(), b.GetType());
                Assert.IsType((i2 >= b1).GetType(), b.GetType());
                Assert.IsType((i2 >= i1).GetType(), b.GetType());
                Assert.IsType((i2 >= l1).GetType(), b.GetType());
                Assert.IsType((i2 >= c1).GetType(), b.GetType());
                Assert.IsType((i2 >= s2).GetType(), b.GetType());
                Assert.IsType((i2 >= b2).GetType(), b.GetType());
                Assert.IsType((i2 >= i2).GetType(), b.GetType());
                Assert.IsType((i2 >= l2).GetType(), b.GetType());
                Assert.IsType((l2 >= b1).GetType(), b.GetType());
                Assert.IsType((l2 >= c1).GetType(), b.GetType());
                Assert.IsType((l2 >= s2).GetType(), b.GetType());
                Assert.IsType((l2 >= i2).GetType(), b.GetType());
                Assert.IsType((l2 >= l2).GetType(), b.GetType());
            }
        }
        public class ValueIntegralTestClass62
        {
            public static void testMethod()
            {
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;
                ushort s2 = 7;
                sbyte b2 = 8;
                uint i2 = 9;
                ulong l2 = 10;
                bool b = true;
                //ushort
                Assert.IsType((s2 <= s1).GetType(), b.GetType());
                Assert.IsType((s2 <= b1).GetType(), b.GetType());
                Assert.IsType((s2 <= i1).GetType(), b.GetType());
                Assert.IsType((s2 <= l1).GetType(), b.GetType());
                Assert.IsType((s2 <= c1).GetType(), b.GetType());
                Assert.IsType((s2 <= s2).GetType(), b.GetType());
                Assert.IsType((s2 <= b2).GetType(), b.GetType());
                Assert.IsType((s2 <= i2).GetType(), b.GetType());
                Assert.IsType((s2 <= l2).GetType(), b.GetType());
                Assert.IsType((b2 <= s1).GetType(), b.GetType());
                Assert.IsType((b2 <= b1).GetType(), b.GetType());
                Assert.IsType((b2 <= i1).GetType(), b.GetType());
                Assert.IsType((b2 <= l1).GetType(), b.GetType());
                Assert.IsType((b2 <= c1).GetType(), b.GetType());
                Assert.IsType((b2 <= s2).GetType(), b.GetType());
                Assert.IsType((b2 <= b2).GetType(), b.GetType());
                Assert.IsType((b2 <= i2).GetType(), b.GetType());
                Assert.IsType((i2 <= s1).GetType(), b.GetType());
                Assert.IsType((i2 <= b1).GetType(), b.GetType());
                Assert.IsType((i2 <= i1).GetType(), b.GetType());
                Assert.IsType((i2 <= l1).GetType(), b.GetType());
                Assert.IsType((i2 <= c1).GetType(), b.GetType());
                Assert.IsType((i2 <= s2).GetType(), b.GetType());
                Assert.IsType((i2 <= b2).GetType(), b.GetType());
                Assert.IsType((i2 <= i2).GetType(), b.GetType());
                Assert.IsType((i2 <= l2).GetType(), b.GetType());
                Assert.IsType((l2 <= b1).GetType(), b.GetType());
                Assert.IsType((l2 <= c1).GetType(), b.GetType());
                Assert.IsType((l2 <= s2).GetType(), b.GetType());
                Assert.IsType((l2 <= i2).GetType(), b.GetType());
                Assert.IsType((l2 <= l2).GetType(), b.GetType());
            }
        }
        public class ValueIntegralTestClass63
        {
            public static void testMethod()
            {
                ushort s1 = 2;
                sbyte b1 = 3;
                uint i1 = 4;
                ulong l1 = 5L;
                int i = 1;

                Assert.IsType((s1 << 1).GetType(), i.GetType());
                Assert.IsType((b1 << 1).GetType(), i.GetType());
                Assert.IsType((i1 << 1).GetType(), i1.GetType());
                Assert.IsType((l1 << 1).GetType(), l1.GetType());
            }
        }
        public class ValueIntegralTestClass64
        {
            public static void testMethod()
            {
                ushort s1 = 2;
                sbyte b1 = 3;
                uint i1 = 4;
                ulong l1 = 5L;
                int i = 1;

                Assert.IsType((s1 >> 1).GetType(), i.GetType());
                Assert.IsType((b1 >> 1).GetType(), i.GetType());
                Assert.IsType((i1 >> 1).GetType(), i1.GetType());
                Assert.IsType((l1 >> 1).GetType(), l1.GetType());
            }
        }
        public class ValueIntegralTestClass70
        {
            public static void testMethod()
            {
                char c = (char)10;
                Assert.Equal(c, '\x000a');
            }
        }

    }
}
