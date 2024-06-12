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

namespace NFUnitTestTypes
{
    [TestClass]
    class UnitTestValueFloatTests
    {
        [TestMethod]
        public void ValueFloat04_Test()
        {
            // Testing float type is kept after addition with other types
            ValueFloatTestClass04.testMethod();
        }

        [TestMethod]
        public void ValueFloat05_Test()
        {
            // Testing double type is kept after addition with other types
            ValueFloatTestClass05.testMethod();
        }

        [TestMethod]
        public void ValueFloat06_Test()
        {
            // Testing float type is kept after subtraction with other types
            ValueFloatTestClass06.testMethod();
        }

        [TestMethod]
        public void ValueFloat07_Test()
        {
            // Testing double type is kept after subtraction with other types
            ValueFloatTestClass07.testMethod();
        }

        [TestMethod]
        public void ValueFloat08_Test()
        {
            // Testing float type is kept after multiplication with other types
            ValueFloatTestClass08.testMethod();
        }

        [TestMethod]
        public void ValueFloat09_Test()
        {
            // Testing double type is kept after maultiplication with other types
            ValueFloatTestClass09.testMethod();
        }

        [TestMethod]
        public void ValueFloat10_Test()
        {
            // Testing float type is kept after division with other types
            ValueFloatTestClass10.testMethod();
        }

        [TestMethod]
        public void ValueFloat11_Test()
        {
            // Testing double type is kept after division with other types
            ValueFloatTestClass11.testMethod();
        }

        [TestMethod]
        public void ValueFloat12_Test()
        {
            // Testing float type is kept after modulus with other types
            ValueFloatTestClass12.testMethod();
        }

        [TestMethod]
        public void ValueFloat13_Test()
        {
            // Testing double type is kept after modulus with other types
            ValueFloatTestClass13.testMethod();
        }

        [TestMethod]
        public void ValueFloat14_Test()
        {
            // Testing that equality operations return bool type objects
            ValueFloatTestClass14.testMethod();
        }

        [TestMethod]
        public void ValueFloat15_Test()
        {
            // Testing that equality operations return bool type objects
            ValueFloatTestClass15.testMethod();
        }

        [TestMethod]
        public void ValueFloat16_Test()
        {
            // Testing that non-equality operations return bool type objects
            ValueFloatTestClass16.testMethod();
        }

        [TestMethod]
        public void ValueFloat17_Test()
        {
            // Testing that non-equality operations return bool type objects
            ValueFloatTestClass17.testMethod();
        }

        [TestMethod]
        public void ValueFloat18_Test()
        {
            // Testing that greater than operations return bool type objects
            ValueFloatTestClass18.testMethod();
        }

        [TestMethod]
        public void ValueFloat19_Test()
        {
            // Testing that greater than operations return bool type objects
            ValueFloatTestClass19.testMethod();
        }

        [TestMethod]
        public void ValueFloat20_Test()
        {
            // Testing that less than operations return bool type objects
            ValueFloatTestClass20.testMethod();
        }

        [TestMethod]
        public void ValueFloat21_Test()
        {
            // Testing that less than operations return bool type objects
            ValueFloatTestClass21.testMethod();
        }

        [TestMethod]
        public void ValueFloat22_Test()
        {
            // Testing that greater than or equal operations return bool type objects
            ValueFloatTestClass22.testMethod();
        }

        [TestMethod]
        public void ValueFloat23_Test()
        {
            // Testing that greater than or equal operations return bool type objects
            ValueFloatTestClass23.testMethod();
        }

        [TestMethod]
        public void ValueFloat24_Test()
        {
            // Testing that less than or equal operations return bool type objects
            ValueFloatTestClass24.testMethod();
        }

        [TestMethod]
        public void ValueFloat25_Test()
        {
            // Testing that less than or equal operations return bool type objects
            ValueFloatTestClass25.testMethod();
        }

        [TestMethod]
        public void ValueFloat26_Test()
        {
            // Testing that double keeps its type in all operations with float
            ValueFloatTestClass26.testMethod();
        }

        [TestMethod]
        public void ValueFloat27_Test()
        {
            // Testing that comparisons between floats and doubles return bools
            ValueFloatTestClass27.testMethod();
        }

        [TestMethod]
        public void ValueFloat28_Test()
        {
            // Testing that float keeps its type after any operation with a float
            ValueFloatTestClass28.testMethod();
        }

        [TestMethod]
        public void ValueFloat29_Test()
        {
            // Testing that comparisons between floats return bools
            ValueFloatTestClass29.testMethod();
        }

        [TestMethod]
        public void ValueFloat30_Test()
        {
            // Testing float and double .epsilon values
            ValueFloatTestClass30.testMethod();
        }

        public class ValueFloatTestClass04
        {
            public static void testMethod()
            {
                float f1 = 11.0f;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((f1 + s1).GetType(), f1.GetType());
                Assert.IsType((s1 + f1).GetType(), f1.GetType());
                Assert.IsType((f1 + b1).GetType(), f1.GetType());
                Assert.IsType((b1 + f1).GetType(), f1.GetType());
                Assert.IsType((f1 + i1).GetType(), f1.GetType());
                Assert.IsType((i1 + f1).GetType(), f1.GetType());
                Assert.IsType((f1 + l1).GetType(), f1.GetType());
                Assert.IsType((l1 + f1).GetType(), f1.GetType());
                Assert.IsType((f1 + c1).GetType(), f1.GetType());
                Assert.IsType((c1 + f1).GetType(), f1.GetType());
            }
        }
        public class ValueFloatTestClass05
        {
            public static void testMethod()
            {
                double d1 = 11.0d;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((d1 + s1).GetType(), d1.GetType());
                Assert.IsType((s1 + d1).GetType(), d1.GetType());
                Assert.IsType((d1 + b1).GetType(), d1.GetType());
                Assert.IsType((b1 + d1).GetType(), d1.GetType());
                Assert.IsType((d1 + i1).GetType(), d1.GetType());
                Assert.IsType((i1 + d1).GetType(), d1.GetType());
                Assert.IsType((d1 + l1).GetType(), d1.GetType());
                Assert.IsType((l1 + d1).GetType(), d1.GetType());
                Assert.IsType((d1 + c1).GetType(), d1.GetType());
                Assert.IsType((c1 + d1).GetType(), d1.GetType());
            }
        }
        public class ValueFloatTestClass06
        {
            public static void testMethod()
            {
                float f1 = 11.0f;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((f1 - s1).GetType(), f1.GetType());
                Assert.IsType((s1 - f1).GetType(), f1.GetType());
                Assert.IsType((f1 - b1).GetType(), f1.GetType());
                Assert.IsType((b1 - f1).GetType(), f1.GetType());
                Assert.IsType((f1 - i1).GetType(), f1.GetType());
                Assert.IsType((i1 - f1).GetType(), f1.GetType());
                Assert.IsType((f1 - l1).GetType(), f1.GetType());
                Assert.IsType((l1 - f1).GetType(), f1.GetType());
                Assert.IsType((f1 - c1).GetType(), f1.GetType());
                Assert.IsType((c1 - f1).GetType(), f1.GetType());
            }
        }
        public class ValueFloatTestClass07
        {
            public static void testMethod()
            {
                double d1 = 11.0d;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((d1 - s1).GetType(), d1.GetType());
                Assert.IsType((s1 - d1).GetType(), d1.GetType());
                Assert.IsType((d1 - b1).GetType(), d1.GetType());
                Assert.IsType((b1 - d1).GetType(), d1.GetType());
                Assert.IsType((d1 - i1).GetType(), d1.GetType());
                Assert.IsType((i1 - d1).GetType(), d1.GetType());
                Assert.IsType((d1 - l1).GetType(), d1.GetType());
                Assert.IsType((l1 - d1).GetType(), d1.GetType());
                Assert.IsType((d1 - c1).GetType(), d1.GetType());
                Assert.IsType((c1 - d1).GetType(), d1.GetType());
            }
        }
        public class ValueFloatTestClass08
        {
            public static void testMethod()
            {
                float f1 = 11.0f;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((f1 * s1).GetType(), f1.GetType());
                Assert.IsType((s1 * f1).GetType(), f1.GetType());
                Assert.IsType((f1 * b1).GetType(), f1.GetType());
                Assert.IsType((b1 * f1).GetType(), f1.GetType());
                Assert.IsType((f1 * i1).GetType(), f1.GetType());
                Assert.IsType((i1 * f1).GetType(), f1.GetType());
                Assert.IsType((f1 * l1).GetType(), f1.GetType());
                Assert.IsType((l1 * f1).GetType(), f1.GetType());
                Assert.IsType((f1 * c1).GetType(), f1.GetType());
                Assert.IsType((c1 * f1).GetType(), f1.GetType());
            }
        }
        public class ValueFloatTestClass09
        {
            public static void testMethod()
            {
                double d1 = 11.0d;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((d1 * s1).GetType(), d1.GetType());
                Assert.IsType((s1 * d1).GetType(), d1.GetType());
                Assert.IsType((d1 * b1).GetType(), d1.GetType());
                Assert.IsType((b1 * d1).GetType(), d1.GetType());
                Assert.IsType((d1 * i1).GetType(), d1.GetType());
                Assert.IsType((i1 * d1).GetType(), d1.GetType());
                Assert.IsType((d1 * l1).GetType(), d1.GetType());
                Assert.IsType((l1 * d1).GetType(), d1.GetType());
                Assert.IsType((d1 * c1).GetType(), d1.GetType());
                Assert.IsType((c1 * d1).GetType(), d1.GetType());
            }
        }
        public class ValueFloatTestClass10
        {
            public static void testMethod()
            {
                float f1 = 11.0f;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((f1 / s1).GetType(), f1.GetType());
                Assert.IsType((s1 / f1).GetType(), f1.GetType());
                Assert.IsType((f1 / b1).GetType(), f1.GetType());
                Assert.IsType((b1 / f1).GetType(), f1.GetType());
                Assert.IsType((f1 / i1).GetType(), f1.GetType());
                Assert.IsType((i1 / f1).GetType(), f1.GetType());
                Assert.IsType((f1 / l1).GetType(), f1.GetType());
                Assert.IsType((l1 / f1).GetType(), f1.GetType());
                Assert.IsType((f1 / c1).GetType(), f1.GetType());
                Assert.IsType((c1 / f1).GetType(), f1.GetType());
            }
        }
        public class ValueFloatTestClass11
        {
            public static void testMethod()
            {
                double d1 = 11.0d;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((d1 / s1).GetType(), d1.GetType());
                Assert.IsType((s1 / d1).GetType(), d1.GetType());
                Assert.IsType((d1 / b1).GetType(), d1.GetType());
                Assert.IsType((b1 / d1).GetType(), d1.GetType());
                Assert.IsType((d1 / i1).GetType(), d1.GetType());
                Assert.IsType((i1 / d1).GetType(), d1.GetType());
                Assert.IsType((d1 / l1).GetType(), d1.GetType());
                Assert.IsType((l1 / d1).GetType(), d1.GetType());
                Assert.IsType((d1 / c1).GetType(), d1.GetType());
                Assert.IsType((c1 / d1).GetType(), d1.GetType());
            }
        }
        public class ValueFloatTestClass12
        {
            public static void testMethod()
            {
                float f1 = 11.0f;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((f1 % s1).GetType(), f1.GetType());
                Assert.IsType((s1 % f1).GetType(), f1.GetType());
                Assert.IsType((f1 % b1).GetType(), f1.GetType());
                Assert.IsType((b1 % f1).GetType(), f1.GetType());
                Assert.IsType((f1 % i1).GetType(), f1.GetType());
                Assert.IsType((i1 % f1).GetType(), f1.GetType());
                Assert.IsType((f1 % l1).GetType(), f1.GetType());
                Assert.IsType((l1 % f1).GetType(), f1.GetType());
                Assert.IsType((f1 % c1).GetType(), f1.GetType());
                Assert.IsType((c1 % f1).GetType(), f1.GetType());
            }
        }
        public class ValueFloatTestClass13
        {
            public static void testMethod()
            {
                double d1 = 11.0d;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((d1 % s1).GetType(), d1.GetType());
                Assert.IsType((s1 % d1).GetType(), d1.GetType());
                Assert.IsType((d1 % b1).GetType(), d1.GetType());
                Assert.IsType((b1 % d1).GetType(), d1.GetType());
                Assert.IsType((d1 % i1).GetType(), d1.GetType());
                Assert.IsType((i1 % d1).GetType(), d1.GetType());
                Assert.IsType((d1 % l1).GetType(), d1.GetType());
                Assert.IsType((l1 % d1).GetType(), d1.GetType());
                Assert.IsType((d1 % c1).GetType(), d1.GetType());
                Assert.IsType((c1 % d1).GetType(), d1.GetType());
            }
        }
        public class ValueFloatTestClass14
        {
            public static void testMethod()
            {
                bool b = true;
                float f1 = 11.0f;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((f1 == s1).GetType(), b.GetType());
                Assert.IsType((s1 == f1).GetType(), b.GetType());
                Assert.IsType((f1 == b1).GetType(), b.GetType());
                Assert.IsType((b1 == f1).GetType(), b.GetType());
                Assert.IsType((f1 == i1).GetType(), b.GetType());
                Assert.IsType((i1 == f1).GetType(), b.GetType());
                Assert.IsType((f1 == l1).GetType(), b.GetType());
                Assert.IsType((l1 == f1).GetType(), b.GetType());
                Assert.IsType((f1 == c1).GetType(), b.GetType());
                Assert.IsType((c1 == f1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass15
        {
            public static void testMethod()
            {
                bool b = false;
                double d1 = 11.0d;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((d1 == s1).GetType(), b.GetType());
                Assert.IsType((s1 == d1).GetType(), b.GetType());
                Assert.IsType((d1 == b1).GetType(), b.GetType());
                Assert.IsType((b1 == d1).GetType(), b.GetType());
                Assert.IsType((d1 == i1).GetType(), b.GetType());
                Assert.IsType((i1 == d1).GetType(), b.GetType());
                Assert.IsType((d1 == l1).GetType(), b.GetType());
                Assert.IsType((l1 == d1).GetType(), b.GetType());
                Assert.IsType((d1 == c1).GetType(), b.GetType());
                Assert.IsType((c1 == d1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass16
        {
            public static void testMethod()
            {
                bool b = true;
                float f1 = 11.0f;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((f1 != s1).GetType(), b.GetType());
                Assert.IsType((s1 != f1).GetType(), b.GetType());
                Assert.IsType((f1 != b1).GetType(), b.GetType());
                Assert.IsType((b1 != f1).GetType(), b.GetType());
                Assert.IsType((f1 != i1).GetType(), b.GetType());
                Assert.IsType((i1 != f1).GetType(), b.GetType());
                Assert.IsType((f1 != l1).GetType(), b.GetType());
                Assert.IsType((l1 != f1).GetType(), b.GetType());
                Assert.IsType((f1 != c1).GetType(), b.GetType());
                Assert.IsType((c1 != f1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass17
        {
            public static void testMethod()
            {
                bool b = false;
                double d1 = 11.0d;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((d1 != s1).GetType(), b.GetType());
                Assert.IsType((s1 != d1).GetType(), b.GetType());
                Assert.IsType((d1 != b1).GetType(), b.GetType());
                Assert.IsType((b1 != d1).GetType(), b.GetType());
                Assert.IsType((d1 != i1).GetType(), b.GetType());
                Assert.IsType((i1 != d1).GetType(), b.GetType());
                Assert.IsType((d1 != l1).GetType(), b.GetType());
                Assert.IsType((l1 != d1).GetType(), b.GetType());
                Assert.IsType((d1 != c1).GetType(), b.GetType());
                Assert.IsType((c1 != d1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass18
        {
            public static void testMethod()
            {
                bool b = true;
                float f1 = 11.0f;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((f1 > s1).GetType(), b.GetType());
                Assert.IsType((s1 > f1).GetType(), b.GetType());
                Assert.IsType((f1 > b1).GetType(), b.GetType());
                Assert.IsType((b1 > f1).GetType(), b.GetType());
                Assert.IsType((f1 > i1).GetType(), b.GetType());
                Assert.IsType((i1 > f1).GetType(), b.GetType());
                Assert.IsType((f1 > l1).GetType(), b.GetType());
                Assert.IsType((l1 > f1).GetType(), b.GetType());
                Assert.IsType((f1 > c1).GetType(), b.GetType());
                Assert.IsType((c1 > f1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass19
        {
            public static void testMethod()
            {
                bool b = false;
                double d1 = 11.0d;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((d1 > s1).GetType(), b.GetType());
                Assert.IsType((s1 > d1).GetType(), b.GetType());
                Assert.IsType((d1 > b1).GetType(), b.GetType());
                Assert.IsType((b1 > d1).GetType(), b.GetType());
                Assert.IsType((d1 > i1).GetType(), b.GetType());
                Assert.IsType((i1 > d1).GetType(), b.GetType());
                Assert.IsType((d1 > l1).GetType(), b.GetType());
                Assert.IsType((l1 > d1).GetType(), b.GetType());
                Assert.IsType((d1 > c1).GetType(), b.GetType());
                Assert.IsType((c1 > d1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass20
        {
            public static void testMethod()
            {
                bool b = true;
                float f1 = 11.0f;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((f1 < s1).GetType(), b.GetType());
                Assert.IsType((s1 < f1).GetType(), b.GetType());
                Assert.IsType((f1 < b1).GetType(), b.GetType());
                Assert.IsType((b1 < f1).GetType(), b.GetType());
                Assert.IsType((f1 < i1).GetType(), b.GetType());
                Assert.IsType((i1 < f1).GetType(), b.GetType());
                Assert.IsType((f1 < l1).GetType(), b.GetType());
                Assert.IsType((l1 < f1).GetType(), b.GetType());
                Assert.IsType((f1 < c1).GetType(), b.GetType());
                Assert.IsType((c1 < f1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass21
        {
            public static void testMethod()
            {
                bool b = false;
                double d1 = 11.0d;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((d1 < s1).GetType(), b.GetType());
                Assert.IsType((s1 < d1).GetType(), b.GetType());
                Assert.IsType((d1 < b1).GetType(), b.GetType());
                Assert.IsType((b1 < d1).GetType(), b.GetType());
                Assert.IsType((d1 < i1).GetType(), b.GetType());
                Assert.IsType((i1 < d1).GetType(), b.GetType());
                Assert.IsType((d1 < l1).GetType(), b.GetType());
                Assert.IsType((l1 < d1).GetType(), b.GetType());
                Assert.IsType((d1 < c1).GetType(), b.GetType());
                Assert.IsType((c1 < d1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass22
        {
            public static void testMethod()
            {
                bool b = true;
                float f1 = 11.0f;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((f1 >= s1).GetType(), b.GetType());
                Assert.IsType((s1 >= f1).GetType(), b.GetType());
                Assert.IsType((f1 >= b1).GetType(), b.GetType());
                Assert.IsType((b1 >= f1).GetType(), b.GetType());
                Assert.IsType((f1 >= i1).GetType(), b.GetType());
                Assert.IsType((i1 >= f1).GetType(), b.GetType());
                Assert.IsType((f1 >= l1).GetType(), b.GetType());
                Assert.IsType((l1 >= f1).GetType(), b.GetType());
                Assert.IsType((f1 >= c1).GetType(), b.GetType());
                Assert.IsType((c1 >= f1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass23
        {
            public static void testMethod()
            {
                bool b = false;
                double d1 = 11.0d;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((d1 >= s1).GetType(), b.GetType());
                Assert.IsType((s1 >= d1).GetType(), b.GetType());
                Assert.IsType((d1 >= b1).GetType(), b.GetType());
                Assert.IsType((b1 >= d1).GetType(), b.GetType());
                Assert.IsType((d1 >= i1).GetType(), b.GetType());
                Assert.IsType((i1 >= d1).GetType(), b.GetType());
                Assert.IsType((d1 >= l1).GetType(), b.GetType());
                Assert.IsType((l1 >= d1).GetType(), b.GetType());
                Assert.IsType((d1 >= c1).GetType(), b.GetType());
                Assert.IsType((c1 >= d1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass24
        {
            public static void testMethod()
            {
                bool b = true;
                float f1 = 11.0f;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((f1 <= s1).GetType(), b.GetType());
                Assert.IsType((s1 <= f1).GetType(), b.GetType());
                Assert.IsType((f1 <= b1).GetType(), b.GetType());
                Assert.IsType((b1 <= f1).GetType(), b.GetType());
                Assert.IsType((f1 <= i1).GetType(), b.GetType());
                Assert.IsType((i1 <= f1).GetType(), b.GetType());
                Assert.IsType((f1 <= l1).GetType(), b.GetType());
                Assert.IsType((l1 <= f1).GetType(), b.GetType());
                Assert.IsType((f1 <= c1).GetType(), b.GetType());
                Assert.IsType((c1 <= f1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass25
        {
            public static void testMethod()
            {
                bool b = false;
                double d1 = 11.0d;
                short s1 = 2;
                byte b1 = 3;
                int i1 = 4;
                long l1 = 5L;
                char c1 = (char)6;

                Assert.IsType((d1 <= s1).GetType(), b.GetType());
                Assert.IsType((s1 <= d1).GetType(), b.GetType());
                Assert.IsType((d1 <= b1).GetType(), b.GetType());
                Assert.IsType((b1 <= d1).GetType(), b.GetType());
                Assert.IsType((d1 <= i1).GetType(), b.GetType());
                Assert.IsType((i1 <= d1).GetType(), b.GetType());
                Assert.IsType((d1 <= l1).GetType(), b.GetType());
                Assert.IsType((l1 <= d1).GetType(), b.GetType());
                Assert.IsType((d1 <= c1).GetType(), b.GetType());
                Assert.IsType((c1 <= d1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass26
        {
            public static void testMethod()
            {
                double d1 = 11.0d;
                float f1 = 12.0f;

                Assert.IsType((d1 + f1).GetType(), d1.GetType());
                Assert.IsType((f1 + d1).GetType(), d1.GetType());
                Assert.IsType((d1 + d1).GetType(), d1.GetType());
                Assert.IsType((d1 - f1).GetType(), d1.GetType());
                Assert.IsType((f1 - d1).GetType(), d1.GetType());
                Assert.IsType((d1 - d1).GetType(), d1.GetType());
                Assert.IsType((d1 * f1).GetType(), d1.GetType());
                Assert.IsType((f1 * d1).GetType(), d1.GetType());
                Assert.IsType((d1 * d1).GetType(), d1.GetType());
                Assert.IsType((d1 / f1).GetType(), d1.GetType());
                Assert.IsType((f1 / d1).GetType(), d1.GetType());
                Assert.IsType((d1 / d1).GetType(), d1.GetType());
                Assert.IsType((d1 % f1).GetType(), d1.GetType());
                Assert.IsType((f1 % d1).GetType(), d1.GetType());
                Assert.IsType((d1 % d1).GetType(), d1.GetType());
            }
        }
        public class ValueFloatTestClass27
        {
            public static void testMethod()
            {
                double d1 = 11.0d;
                float f1 = 12.0f;
                bool b = false;
                Assert.IsType((d1 == f1).GetType(), b.GetType());
                Assert.IsType((f1 == d1).GetType(), b.GetType());
                Assert.IsType((d1 == d1).GetType(), b.GetType());
                Assert.IsType((d1 != f1).GetType(), b.GetType());
                Assert.IsType((f1 != d1).GetType(), b.GetType());
                Assert.IsType((d1 != d1).GetType(), b.GetType());
                Assert.IsType((d1 > f1).GetType(), b.GetType());
                Assert.IsType((f1 > d1).GetType(), b.GetType());
                Assert.IsType((d1 > d1).GetType(), b.GetType());
                Assert.IsType((d1 < f1).GetType(), b.GetType());
                Assert.IsType((f1 < d1).GetType(), b.GetType());
                Assert.IsType((d1 < d1).GetType(), b.GetType());
                Assert.IsType((d1 >= f1).GetType(), b.GetType());
                Assert.IsType((f1 >= d1).GetType(), b.GetType());
                Assert.IsType((d1 >= d1).GetType(), b.GetType());
                Assert.IsType((d1 <= f1).GetType(), b.GetType());
                Assert.IsType((f1 <= d1).GetType(), b.GetType());
                Assert.IsType((d1 <= d1).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass28
        {
            public static void testMethod()
            {
                float f1 = 11.0f;
                float f2 = 12.0f;

                Assert.IsType((f1 + f2).GetType(), f1.GetType());
                Assert.IsType((f1 - f2).GetType(), f1.GetType());
                Assert.IsType((f1 * f2).GetType(), f1.GetType());
                Assert.IsType((f1 / f2).GetType(), f1.GetType());
                Assert.IsType((f1 % f2).GetType(), f1.GetType());
            }
        }
        public class ValueFloatTestClass29
        {
            public static void testMethod()
            {
                double f1 = 11.0d;
                float f2 = 12.0f;
                bool b = false;
                Assert.IsType((f1 == f2).GetType(), b.GetType());
                Assert.IsType((f1 != f2).GetType(), b.GetType());
                Assert.IsType((f1 > f2).GetType(), b.GetType());
                Assert.IsType((f1 < f2).GetType(), b.GetType());
                Assert.IsType((f1 >= f2).GetType(), b.GetType());
                Assert.IsType((f1 <= f2).GetType(), b.GetType());
            }
        }
        public class ValueFloatTestClass30
        {
            public static void testMethod()
            {
                float f1 = float.Epsilon;
                double d1 = double.Epsilon;
                Assert.AreEqual((float)(f1 / 2.0f), 0.0f);
                Assert.AreEqual((float)(f1 * 0.5f), 0.0f);
                Assert.AreEqual((double)(d1 / 2.0d), (double)0.0d);
                Assert.AreEqual((double)(d1 * 0.5d), (double)0.0d);
            }
        }

    }
}
