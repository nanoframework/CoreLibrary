// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

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
            //  Section 4.1
            //  For the +, - and ~ unary operators, of the operand is of type long, the
            //  operation is performed using 64-bit precision, and the type of the result
            //  is long.  Otherwise, the operand is converted to int, and operation is
            //  performed using 32-bit precision, and the type of the result is int.
            ValueIntegralTestClass01.testMethod();
        }
        [TestMethod]
        public void ValueIntegral05_Test()
        {
            //  Section 4.1
            //  For the +, - and ~ unary operators, of the operand is of type long, the
            //  operation is performed using 64-bit precision, and the type of the result
            //  is long.  Otherwise, the operand is converted to int, and operation is
            //  performed using 32-bit precision, and the type of the result is int.
            ValueIntegralTestClass05.testMethod();
        }
        [TestMethod]
        public void ValueIntegral09_Test()
        {
            //  Section 4.1
            //  For the +, - and ~ unary operators, of the operand is of type long, the
            //  operation is performed using 64-bit precision, and the type of the result
            //  is long.  Otherwise, the operand is converted to int, and operation is
            //  performed using 32-bit precision, and the type of the result is int.
            ValueIntegralTestClass09.testMethod();
        }
        [TestMethod]
        public void ValueIntegral13_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass13.testMethod();
        }
        [TestMethod]
        public void ValueIntegral14_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass14.testMethod();
        }
        [TestMethod]
        public void ValueIntegral15_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass15.testMethod();
        }
        [TestMethod]
        public void ValueIntegral16_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass16.testMethod();
        }
        [TestMethod]
        public void ValueIntegral17_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass17.testMethod();
        }
        [TestMethod]
        public void ValueIntegral18_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass18.testMethod();
        }
        [TestMethod]
        public void ValueIntegral19_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass19.testMethod();
        }
        [TestMethod]
        public void ValueIntegral20_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass20.testMethod();
        }
        [TestMethod]
        public void ValueIntegral21_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass21.testMethod();
        }
        [TestMethod]
        public void ValueIntegral22_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass22.testMethod();
        }
        [TestMethod]
        public void ValueIntegral23_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass23.testMethod();
        }
        [TestMethod]
        public void ValueIntegral24_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass24.testMethod();
        }
        [TestMethod]
        public void ValueIntegral25_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass25.testMethod();
        }
        [TestMethod]
        public void ValueIntegral26_Test()
        {
            //  For the binary operators other than shift, if at least one
            //  operand is of type long, then both operands are converted to long, the operation
            //  is performed using 64-bit precision, and the type of the result is long or bool. 
            //  Otherwise, both operands are converted to int, the operation is performed using 
            //  32-bit precision, and the type of the result is int or bool.
            ValueIntegralTestClass26.testMethod();
        }
        [TestMethod]
        public void ValueIntegral27_Test()
        {
            //  Section 4.1
            //  For the shift operators, if the left-hand operand is of type long,
            //  the operation is performed using 64-bit precision, and the type of the result
            //  is long.  Otherwise, the left hand-operand is converted to int, the operation is 
            //  performed using 32-bit precision, and the type of the result is int.
            ValueIntegralTestClass27.testMethod();
        }
        [TestMethod]
        public void ValueIntegral28_Test()
        {
            //  Section 4.1
            //  For the shift operators, if the left-hand operand is of type long,
            //  the operation is performed using 64-bit precision, and the type of the result
            //  is long.  Otherwise, the left hand-operand is converted to int, the operation is 
            //  performed using 32-bit precision, and the type of the result is int.
            ValueIntegralTestClass28.testMethod();
        }
        [TestMethod]
        public void ValueIntegral38_Test()
        {
            //  Section 4.1
            //  Constants of the char type must be written as character-literals.
            //  Character constants can only be written as integer-literals
            //  in combination with a cast. For example, (char)10 is the same as
            //  '\x000A'.
            ValueIntegralTestClass38.testMethod();
        }
        [TestMethod]
        public void ValueIntegral39_Test()
        {
            //  Section 4.1
            //  For the unary + and ~ operators, the operand is converted
            //  to type T, where T is the first of int, uint, long, and
            //  ulong that can fully represent all possible values of the
            //  operand. The operation is then performed using the precision 
            //  of type T, and the type of the result is T.
            ValueIntegralTestClass39.testMethod();
        }
        [TestMethod]
        public void ValueIntegral42_Test()
        {
            //  Section 4.1
            //  For the unary + and ~ operators, the operand is converted
            //  to type T, where T is the first of int, uint, long, and
            //  ulong that can fully represent all possible values of the
            //  operand. The operation is then performed using the precision 
            //  of type T, and the type of the result is T.
            ValueIntegralTestClass42.testMethod();
        }
        [TestMethod]
        public void ValueIntegral45_Test()
        {
            //  Section 4.1
            //  For the unary - operator, the operand is converted
            //  to type T, where T is the first of int and long that 
            //  can fully represent all possible values of the 
            //  operand.  The operation is then performed using the
            //  precision of type T, and the type of the result is T.
            //  The unary - operator cannot be applied to operands of
            //  type ulong.
            ValueIntegralTestClass45.testMethod();
        }
        [TestMethod]
        public void ValueIntegral49_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass49.testMethod();
        }
        [TestMethod]
        public void ValueIntegral50_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass50.testMethod();
        }
        [TestMethod]
        public void ValueIntegral51_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass51.testMethod();
        }
        [TestMethod]
        public void ValueIntegral52_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass52.testMethod();
        }
        [TestMethod]
        public void ValueIntegral53_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass53.testMethod();
        }
        [TestMethod]
        public void ValueIntegral54_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass54.testMethod();
        }
        [TestMethod]
        public void ValueIntegral55_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass55.testMethod();
        }
        [TestMethod]
        public void ValueIntegral56_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass56.testMethod();
        }
        [TestMethod]
        public void ValueIntegral57_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass57.testMethod();
        }
        [TestMethod]
        public void ValueIntegral58_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass58.testMethod();
        }
        [TestMethod]
        public void ValueIntegral59_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass59.testMethod();
        }
        [TestMethod]
        public void ValueIntegral60_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass60.testMethod();
        }
        [TestMethod]
        public void ValueIntegral61_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass61.testMethod();
        }
        [TestMethod]
        public void ValueIntegral62_Test()
        {
            //  Section 4.1
            //  For the binary operators except shift, the operands
            //  are converted to type T, where T is the first of int, uint, long, and ulong
            //  that can fully represent all possible values of each operand. The operation
            //  is then performed using the precision of type T, and the type of the result
            //  is T (or bool for relational operators).
            ValueIntegralTestClass62.testMethod();
        }
        [TestMethod]
        public void ValueIntegral63_Test()
        {
            //  Section 4.1
            //  For the binary shift operators, the left operand
            //  is converted to type T, where T is the first of int,
            //  uint, long, and ulong that can fully represent all possible
            //  values of the operand. The operation is then performed
            //  using the precision of type T, and the type of the result
            //  T.
            ValueIntegralTestClass63.testMethod();
        }
        [TestMethod]
        public void ValueIntegral64_Test()
        {
            //  Section 4.1
            //  For the binary shift operators, the left operand
            //  is converted to type T, where T is the first of int,
            //  uint, long, and ulong that can fully represent all possible
            //  values of the operand. The operation is then performed
            //  using the precision of type T, and the type of the result
            //  T.
            ValueIntegralTestClass64.testMethod();
        }
        [TestMethod]
        public void ValueIntegral70_Test()
        {
            //  Section 4.1
            //  Constants of the char type must be written as character-literals.
            //  Character constants can only be written as integer-literals
            //  in compination with a cast.  For example, (char)10 is the same 
            //  as '\x000a'.
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

                Assert.AreEqual(s2, (short)-2);
                Assert.AreEqual(b2, -3);
                Assert.AreEqual(i2, -4);
                Assert.AreEqual(l2, -5L);
                Assert.AreEqual(c2, -6);
                Assert.AreEqual(i2, -4);
                Assert.AreEqual(l2, -5L);
                Assert.AreEqual(c2, -6);
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

                Assert.AreEqual(s2, (short)2);
                Assert.AreEqual(b2, 3);
                Assert.AreEqual(i2, 4);
                Assert.AreEqual(l2, 5L);
                Assert.AreEqual(c2, 6);
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

                Assert.AreEqual(s2, (short)-3);
                Assert.AreEqual(b2, -4);
                Assert.AreEqual(i2, -5);
                Assert.AreEqual(l2, -6L);
                Assert.AreEqual(c2, -7);
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
                Assert.IsInstanceOfType((s1 + s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 + b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 + i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 + l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s1 + c1).GetType(), i1.GetType());
                //byte
                Assert.IsInstanceOfType((b1 + b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 + i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 + l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b1 + c1).GetType(), i1.GetType());
                //int
                Assert.IsInstanceOfType((i1 + i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 + l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i1 + c1).GetType(), i1.GetType());
                //long
                Assert.IsInstanceOfType((l1 + l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((l1 + c1).GetType(), l1.GetType());
                //char
                Assert.IsInstanceOfType((c1 + c1).GetType(), i1.GetType());
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
                Assert.IsInstanceOfType((s1 - s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 - b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 - i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 - l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s1 - c1).GetType(), i1.GetType());
                //byte
                Assert.IsInstanceOfType((b1 - b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 - i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 - l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b1 - c1).GetType(), i1.GetType());
                //int
                Assert.IsInstanceOfType((i1 - i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 - l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i1 - c1).GetType(), i1.GetType());
                //long
                Assert.IsInstanceOfType((l1 - l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((l1 - c1).GetType(), l1.GetType());
                //char
                Assert.IsInstanceOfType((c1 - c1).GetType(), i1.GetType());
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
                Assert.IsInstanceOfType((s1 * s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 * b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 * i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 * l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s1 * c1).GetType(), i1.GetType());
                //byte                                            
                Assert.IsInstanceOfType((b1 * b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 * i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 * l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b1 * c1).GetType(), i1.GetType());
                //int                                             
                Assert.IsInstanceOfType((i1 * i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 * l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i1 * c1).GetType(), i1.GetType());
                //long
                Assert.IsInstanceOfType((l1 * l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((l1 * c1).GetType(), l1.GetType());
                //char
                Assert.IsInstanceOfType((c1 * c1).GetType(), i1.GetType());
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
                Assert.IsInstanceOfType((s1 / s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 / b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 / i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 / l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s1 / c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 / b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 / i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 / l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b1 / c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 / i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 / l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i1 / c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((l1 / l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((l1 / c1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((c1 / c1).GetType(), i1.GetType());
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
                Assert.IsInstanceOfType((s1 % s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 % b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 % i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 % l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s1 % c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 % b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 % i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 % l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b1 % c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 % i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 % l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i1 % c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((l1 % l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((l1 % c1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((c1 % c1).GetType(), i1.GetType());
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
                Assert.IsInstanceOfType((s1 & s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 & b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 & i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 & l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s1 & c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 & b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 & i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 & l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b1 & c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 & i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 & l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i1 & c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((l1 & l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((l1 & c1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((c1 & c1).GetType(), i1.GetType());
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
                Assert.IsInstanceOfType((s1 ^ s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 ^ b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 ^ i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 ^ l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s1 ^ c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 ^ b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 ^ i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 ^ l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b1 ^ c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 ^ i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 ^ l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i1 ^ c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((l1 ^ l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((l1 ^ c1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((c1 ^ c1).GetType(), i1.GetType());
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
                Assert.IsInstanceOfType((s1 | s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 | b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 | i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s1 | l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s1 | c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 | b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 | i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 | l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b1 | c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 | i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 | l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i1 | c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((l1 | l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((l1 | c1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((c1 | c1).GetType(), i1.GetType());
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
                Assert.IsInstanceOfType((s1 == s1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 == b1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 == i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 == l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 == c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 == b1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 == i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 == l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 == c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 == i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 == l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 == c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((l1 == l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((l1 == c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((c1 == c1).GetType(), TestBool.GetType());
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
                Assert.IsInstanceOfType((s1 != s1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 != b1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 != i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 != l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 != c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 != b1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 != i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 != l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 != c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 != i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 != l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 != c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((l1 != l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((l1 != c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((c1 != c1).GetType(), TestBool.GetType());
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
                Assert.IsInstanceOfType((s1 > s1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 > b1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 > i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 > l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 > c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 > b1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 > i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 > l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 > c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 > i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 > l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 > c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((l1 > l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((l1 > c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((c1 > c1).GetType(), TestBool.GetType());
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
                Assert.IsInstanceOfType((s1 < s1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 < b1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 < i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 < l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 < c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 < b1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 < i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 < l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 < c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 < i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 < l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 < c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((l1 < l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((l1 < c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((c1 < c1).GetType(), TestBool.GetType());
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
                Assert.IsInstanceOfType((s1 >= s1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 >= b1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 >= i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 >= l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 >= c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 >= b1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 >= i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 >= l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 >= c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 >= i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 >= l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 >= c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((l1 >= l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((l1 >= c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((c1 >= c1).GetType(), TestBool.GetType());
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
                Assert.IsInstanceOfType((s1 <= s1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 <= b1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 <= i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 <= l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((s1 <= c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 <= b1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 <= i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 <= l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((b1 <= c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 <= i1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 <= l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((i1 <= c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((l1 <= l1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((l1 <= c1).GetType(), TestBool.GetType());
                Assert.IsInstanceOfType((c1 <= c1).GetType(), TestBool.GetType());
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
                Assert.IsInstanceOfType((s1 << 1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 << 1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 << 1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((l1 << 1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((c1 << 1).GetType(), i1.GetType());
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
                Assert.IsInstanceOfType((s1 >> 1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b1 >> 1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((i1 >> 1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((l1 >> 1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((c1 >> 1).GetType(), i1.GetType());
            }
        }
        public class ValueIntegralTestClass38
        {
            public static void testMethod()
            {
                char c = '\x000A';
                Assert.AreEqual(c, (char)10);
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

                Assert.AreEqual(s2, (ushort)2);
                Assert.AreEqual(b2, 3);
                Assert.AreEqual(i2, 4);
                Assert.AreEqual(l2, 5ul);
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

                    Assert.AreEqual(s2, -3);
                    Assert.AreEqual(b2, -4);
                    Assert.AreEqual(i2, 4294967291u);
                    Assert.AreEqual(l2, 18446744073709551610ul);
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

                Assert.AreEqual(s2, -2);
                Assert.AreEqual(b2, -3);
                Assert.AreEqual(i2, -4);
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
                Assert.IsInstanceOfType((s2 + s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 + b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 + i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 + l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s2 + c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 + s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 + b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 + i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((s2 + l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((b2 + s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 + b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 + i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 + l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b2 + c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 + s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 + b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 + i2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 + s1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 + b1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 + i1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 + l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 + c1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 + s2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 + b2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 + i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 + l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 + b1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 + c1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 + s2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 + i2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 + l2).GetType(), l2.GetType());
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
                Assert.IsInstanceOfType((s2 - s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 - i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 - l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s2 - c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 - s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 - b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 - i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((s2 - l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((b2 - s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 - b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 - i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 - l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b2 - c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 - s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 - b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 - i2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 - s1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 - b1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 - i1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 - l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 - c1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 - s2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 - b2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 - i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 - l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 - b1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 - c1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 - s2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 - i2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 - l2).GetType(), l2.GetType());
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
                Assert.IsInstanceOfType((s2 * s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 * b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 * i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 * l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s2 * c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 * s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 * b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 * i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((s2 * l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((b2 * s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 * b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 * i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 * l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b2 * c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 * s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 * b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 * i2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 * s1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 * b1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 * i1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 * l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 * c1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 * s2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 * b2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 * i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 * l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 * b1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 * c1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 * s2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 * i2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 * l2).GetType(), l2.GetType());
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
                Assert.IsInstanceOfType((s2 / s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 / b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 / i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 / l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s2 / c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 / s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 / b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 / i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((s2 / l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((b2 / s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 / b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 / i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 / l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b2 / c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 / s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 / b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 / i2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 / s1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 / b1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 / i1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 / l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 / c1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 / s2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 / b2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 / i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 / l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 / b1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 / c1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 / s2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 / i2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 / l2).GetType(), l2.GetType());
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
                Assert.IsInstanceOfType((s2 % s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 % b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 % i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 % l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s2 % c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 % s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 % b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 % i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((s2 % l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((b2 % s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 % b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 % i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 % l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b2 % c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 % s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 % b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 % i2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 % s1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 % b1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 % i1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 % l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 % c1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 % s2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 % b2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 % i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 % l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 % b1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 % c1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 % s2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 % i2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 % l2).GetType(), l2.GetType());
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
                Assert.IsInstanceOfType((s2 & s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 & b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 & i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 & l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s2 & c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 & s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 & b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 & i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((s2 & l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((b2 & s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 & b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 & i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 & l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b2 & c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 & s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 & b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 & i2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 & s1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 & b1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 & i1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 & l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 & c1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 & s2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 & b2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 & i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 & l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 & b1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 & c1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 & s2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 & i2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 & l2).GetType(), l2.GetType());
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
                Assert.IsInstanceOfType((s2 ^ s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 ^ b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 ^ i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 ^ l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s2 ^ c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 ^ s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 ^ b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 ^ i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((s2 ^ l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((b2 ^ s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 ^ b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 ^ i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 ^ l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b2 ^ c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 ^ s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 ^ b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 ^ i2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 ^ s1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 ^ b1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 ^ i1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 ^ l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 ^ c1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 ^ s2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 ^ b2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 ^ i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 ^ l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 ^ b1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 ^ c1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 ^ s2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 ^ i2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 ^ l2).GetType(), l2.GetType());
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
                Assert.IsInstanceOfType((s2 | s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 | b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 | i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 | l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((s2 | c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 | s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 | b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((s2 | i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((s2 | l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((b2 | s1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 | b1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 | i1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 | l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((b2 | c1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 | s2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 | b2).GetType(), i1.GetType());
                Assert.IsInstanceOfType((b2 | i2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 | s1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 | b1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 | i1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 | l1).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 | c1).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 | s2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 | b2).GetType(), l1.GetType());
                Assert.IsInstanceOfType((i2 | i2).GetType(), i2.GetType());
                Assert.IsInstanceOfType((i2 | l2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 | b1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 | c1).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 | s2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 | i2).GetType(), l2.GetType());
                Assert.IsInstanceOfType((l2 | l2).GetType(), l2.GetType());
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
                Assert.IsInstanceOfType((s2 == s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 == b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 == i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 == l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 == c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 == s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 == b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 == i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 == l2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 == s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 == b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 == i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 == l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 == c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 == s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 == b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 == i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 == s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 == b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 == i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 == l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 == c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 == s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 == b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 == i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 == l2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 == b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 == c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 == s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 == i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 == l2).GetType(), b.GetType());
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
                Assert.IsInstanceOfType((s2 != s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 != b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 != i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 != l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 != c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 != s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 != b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 != i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 != l2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 != s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 != b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 != i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 != l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 != c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 != s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 != b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 != i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 != s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 != b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 != i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 != l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 != c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 != s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 != b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 != i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 != l2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 != b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 != c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 != s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 != i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 != l2).GetType(), b.GetType());
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
                Assert.IsInstanceOfType((s2 > s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 > b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 > i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 > l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 > c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 > s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 > b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 > i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 > l2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 > s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 > b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 > i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 > l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 > c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 > s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 > b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 > i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 > s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 > b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 > i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 > l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 > c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 > s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 > b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 > i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 > l2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 > b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 > c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 > s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 > i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 > l2).GetType(), b.GetType());
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
                Assert.IsInstanceOfType((s2 < s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 < b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 < i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 < l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 < c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 < s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 < b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 < i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 < l2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 < s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 < b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 < i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 < l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 < c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 < s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 < b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 < i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 < s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 < b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 < i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 < l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 < c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 < s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 < b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 < i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 < l2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 < b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 < c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 < s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 < i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 < l2).GetType(), b.GetType());
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
                Assert.IsInstanceOfType((s2 >= s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 >= b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 >= i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 >= l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 >= c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 >= s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 >= b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 >= i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 >= l2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 >= s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 >= b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 >= i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 >= l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 >= c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 >= s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 >= b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 >= i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 >= s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 >= b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 >= i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 >= l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 >= c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 >= s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 >= b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 >= i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 >= l2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 >= b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 >= c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 >= s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 >= i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 >= l2).GetType(), b.GetType());
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
                Assert.IsInstanceOfType((s2 <= s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 <= b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 <= i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 <= l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 <= c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 <= s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 <= b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 <= i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((s2 <= l2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 <= s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 <= b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 <= i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 <= l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 <= c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 <= s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 <= b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((b2 <= i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 <= s1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 <= b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 <= i1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 <= l1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 <= c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 <= s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 <= b2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 <= i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((i2 <= l2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 <= b1).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 <= c1).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 <= s2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 <= i2).GetType(), b.GetType());
                Assert.IsInstanceOfType((l2 <= l2).GetType(), b.GetType());
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

                Assert.IsInstanceOfType((s1 << 1).GetType(), i.GetType());
                Assert.IsInstanceOfType((b1 << 1).GetType(), i.GetType());
                Assert.IsInstanceOfType((i1 << 1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((l1 << 1).GetType(), l1.GetType());
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

                Assert.IsInstanceOfType((s1 >> 1).GetType(), i.GetType());
                Assert.IsInstanceOfType((b1 >> 1).GetType(), i.GetType());
                Assert.IsInstanceOfType((i1 >> 1).GetType(), i1.GetType());
                Assert.IsInstanceOfType((l1 >> 1).GetType(), l1.GetType());
            }
        }
        public class ValueIntegralTestClass70
        {
            public static void testMethod()
            {
                char c = (char)10;
                Assert.AreEqual(c, '\x000a');
            }
        }

    }
}
