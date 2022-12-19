﻿//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestArray
{
    [TestClass]
    class UnitTestSimpleTests
    {
        [TestMethod]
        public void Simple_decl_decl_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of type int");

            Assert.IsTrue(Simple_TestClass_decl_decl_01.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of type byte");
            Assert.IsTrue(Simple_TestClass_decl_decl_02.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of type short");

            Assert.IsTrue(Simple_TestClass_decl_decl_03.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of type long");

            Assert.IsTrue(Simple_TestClass_decl_decl_04.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_05_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of type char");

            Assert.IsTrue(Simple_TestClass_decl_decl_05.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_06_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of type double");

            Assert.IsTrue(Simple_TestClass_decl_decl_06.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_07_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of type float");

            Assert.IsTrue(Simple_TestClass_decl_decl_07.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_08_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of type double");

            Assert.IsTrue(Simple_TestClass_decl_decl_08.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_09_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of type bool");

            Assert.IsTrue(Simple_TestClass_decl_decl_09.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_10_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of a user-defined struct");

            Assert.IsTrue(Simple_TestClass_decl_decl_10.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_11_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of a user-defined class");

            Assert.IsTrue(Simple_TestClass_decl_decl_11.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_12_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of a user-defined interface");

            Assert.IsTrue(Simple_TestClass_decl_decl_12.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_13_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of type object");

            Assert.IsTrue(Simple_TestClass_decl_decl_13.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_14_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of delegates");

            Assert.IsTrue(Simple_TestClass_decl_decl_14.testMethod());
        }
        [TestMethod]
        public void Simple_decl_decl_15_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Declare a simple array of type System.Array");

            Assert.IsTrue(Simple_TestClass_decl_decl_15.testMethod());
        }
        [TestMethod]
        public void Simple_decl_bounds_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" An array created as array[0] compiles successfully");

            Assert.IsTrue(Simple_TestClass_decl_bounds_01.testMethod());
        }
        [TestMethod]
        public void Simple_decl_bounds_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" An array created as array[maxint] compiles successfully");
            OutputHelper.WriteLine("This test is expected to generate");
            OutputHelper.WriteLine("Out Of Memory System.Exception");
            Assert.IsFalse(Simple_TestClass_decl_bounds_02.testMethod());
            OutputHelper.WriteLine(" This failure indicates a test is now passing that previously failed by design.");
            OutputHelper.WriteLine(" It previously marked as known failure because of bug # 16823");
            OutputHelper.WriteLine(" The Test owner needs to verify that the change was intentional and remove the known failure.");
        }
        [TestMethod]
        public void Simple_decl_bounds_03_Test()
        {
            OutputHelper.WriteLine(" decl_bounds_03 ");
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" An array created as array[maxint+1] compiles successfully");
            Assert.IsFalse(Simple_TestClass_decl_bounds_03.testMethod());
            OutputHelper.WriteLine(" This failure indicates a test is now passing that previously failed by design.");
            OutputHelper.WriteLine(" It previously marked as known failure because of bug # 16823");
            OutputHelper.WriteLine(" The Test owner needs to verify that the change was intentional and remove the known failure.");
        }
        [TestMethod]
        public void Simple_decl_index_01_Test()
        {
            OutputHelper.WriteLine(" decl_index_01 ");
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" A char variable as an array index should work");

            Assert.IsTrue(Simple_TestClass_decl_index_01.testMethod());
        }
        [TestMethod]
        public void Simple_decl_index_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" A byte variable as an array index should work");
            Assert.IsTrue(Simple_TestClass_decl_index_02.testMethod());
        }
        [TestMethod]
        public void Simple_decl_index_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" A short variable as an array index should work");
            Assert.IsTrue(Simple_TestClass_decl_index_03.testMethod());
        }
        [TestMethod]
        public void Simple_decl_index_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" A short literal as an array index should work");

            Assert.IsTrue(Simple_TestClass_decl_index_04.testMethod());
        }
        [TestMethod]
        public void Simple_decl_index_05_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" A byte literal as an array index should work");
            Assert.IsTrue(Simple_TestClass_decl_index_05.testMethod());
        }
        [TestMethod]
        public void Simple_decl_index_06_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" A char literal as an array index should work");
            Assert.IsTrue(Simple_TestClass_decl_index_06.testMethod());
        }
        [TestMethod]
        public void Simple_decl_index_07_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" A uint variable as an array index should work");
            Assert.IsTrue(Simple_TestClass_decl_index_07.testMethod());
        }
        [TestMethod]
        public void Simple_decl_index_08_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" A long variable as an array index should work");
            Assert.IsTrue(Simple_TestClass_decl_index_08.testMethod());
        }
        [TestMethod]
        public void Simple_decl_index_09_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" A ulong variable as an array index should work");
            Assert.IsTrue(Simple_TestClass_decl_index_09.testMethod());
        }
        [TestMethod]
        public void Simple_decl_index_10_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" A uint literal as an array index should work");
            Assert.IsTrue(Simple_TestClass_decl_index_10.testMethod());
        }
        [TestMethod]
        public void Simple_decl_index_11_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" A long literal as an array index should work");
            Assert.IsTrue(Simple_TestClass_decl_index_11.testMethod());
        }
        [TestMethod]
        public void Simple_decl_index_12_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" A ulong literal as an array index should work");
            Assert.IsTrue(Simple_TestClass_decl_index_12.testMethod());
        }
        [TestMethod]
        public void Simple_decl_syntax_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Declarations");
            OutputHelper.WriteLine(" Spaces after type and between brackets and comments do not affect arrays");
            Assert.IsTrue(Simple_TestClass_decl_syntax_03.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_a_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type int using new (longhand)");
            Assert.IsTrue(Simple_TestClass_init_init_a_01.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_a_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type short using new (longhand)");
            Assert.IsTrue(Simple_TestClass_init_init_a_02.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_a_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type byte using new (longhand)");
            Assert.IsTrue(Simple_TestClass_init_init_a_03.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_a_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type long using new (longhand)");
            Assert.IsTrue(Simple_TestClass_init_init_a_04.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_a_05_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type double using new (longhand)");
            Assert.IsTrue(Simple_TestClass_init_init_a_05.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_a_06_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type float using new (longhand)");

            Assert.IsTrue(Simple_TestClass_init_init_a_06.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_a_08_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type String using new (longhand)");
            Assert.IsTrue(Simple_TestClass_init_init_a_08.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_a_09_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type char using new (longhand)");
            Assert.IsTrue(Simple_TestClass_init_init_a_09.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_a_10_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type bool using new (longhand)");
            Assert.IsTrue(Simple_TestClass_init_init_a_10.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_b_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type int using new (shorthand)");
            Assert.IsTrue(Simple_TestClass_init_init_b_01.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_b_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type short using new (shorthand)");
            Assert.IsTrue(Simple_TestClass_init_init_b_02.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_b_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type byte using new (shorthand)");
            Assert.IsTrue(Simple_TestClass_init_init_b_03.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_b_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type long using new (shorthand)");
            Assert.IsTrue(Simple_TestClass_init_init_b_04.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_b_05_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type double using new (shorthand)");
            Assert.IsTrue(Simple_TestClass_init_init_b_05.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_b_06_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type float using new (shorthand)");
            Assert.IsTrue(Simple_TestClass_init_init_b_06.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_b_08_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type String using new (shorthand)");
            Assert.IsTrue(Simple_TestClass_init_init_b_08.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_b_09_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type char using new (shorthand)");
            Assert.IsTrue(Simple_TestClass_init_init_b_09.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_b_10_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type bool using new (shorthand)");

            Assert.IsTrue(Simple_TestClass_init_init_b_10.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_c_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type int using new (# init values sets array size)");
            Assert.IsTrue(Simple_TestClass_init_init_c_01.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_c_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type short using new (# init values sets array size)");
            Assert.IsTrue(Simple_TestClass_init_init_c_02.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_c_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type byte using new (# init values sets array size)");
            Assert.IsTrue(Simple_TestClass_init_init_c_03.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_c_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type long using new (# init values sets array size)");
            Assert.IsTrue(Simple_TestClass_init_init_c_04.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_c_05_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type double using new (# init values sets array size)");
            Assert.IsTrue(Simple_TestClass_init_init_c_05.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_c_06_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type float using new (# init values sets array size)");
            Assert.IsTrue(Simple_TestClass_init_init_c_06.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_c_08_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type String using new (# init values sets array size)");
            Assert.IsTrue(Simple_TestClass_init_init_c_08.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_c_09_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type char using new (# init values sets array size)");
            Assert.IsTrue(Simple_TestClass_init_init_c_09.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_c_10_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type bool using new (# init values sets array size)");
            Assert.IsTrue(Simple_TestClass_init_init_c_10.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_d_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type int using new (longhand) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_d_01.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_d_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type short using new (longhand) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_d_02.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_d_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type byte using new (longhand) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_d_03.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_d_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type long using new (longhand) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_d_04.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_d_05_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type double using new (longhand) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_d_05.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_d_06_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type float using new (longhand) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_d_06.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_d_08_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type String using new (longhand) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_d_08.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_d_09_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type char using new (longhand) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_d_09.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_d_10_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type bool using new (longhand) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_d_10.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_e_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type int using new (# init values sets array size) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_e_01.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_e_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type short using new (# init values sets array size) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_e_02.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_e_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type byte using new (# init values sets array size) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_e_03.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_e_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type long using new (# init values sets array size) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_e_04.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_e_05_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type double using new (# init values sets array size) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_e_05.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_e_06_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type float using new (# init values sets array size) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_e_06.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_e_08_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type String using new (# init values sets array size) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_e_08.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_e_09_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type char using new (# init values sets array size) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_e_09.testMethod());
        }
        [TestMethod]
        public void Simple_init_init_e_10_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type bool using new (# init values sets array size) separate from decl statement");
            Assert.IsTrue(Simple_TestClass_init_init_e_10.testMethod());
        }
        [TestMethod]
        public void Simple_init_syntax_09_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Syntax - Whitespace and comments in braces should not affect anything");
            Assert.IsTrue(Simple_TestClass_init_syntax_09.testMethod());
        }
        [TestMethod]
        public void Simple_init_syntax_11_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Syntax - zero elements in initializer should create zero length array");
            Assert.IsTrue(Simple_TestClass_init_syntax_11.testMethod());
        }
        [TestMethod]
        public void Simple_init_syntax_12_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Syntax - zero elements in initializer should be allowed for 0-length array");
            Assert.IsTrue(Simple_TestClass_init_syntax_12.testMethod());
        }
        [TestMethod]
        public void Simple_init_decl_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Declaration - if initializer is used, a provided index can be a const");
            Assert.IsTrue(Simple_TestClass_init_decl_02.testMethod());
        }
        [TestMethod]
        public void Simple_init_decl_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Declaration - if initializer is used, a provided index can be a const short");
            Assert.IsTrue(Simple_TestClass_init_decl_03.testMethod());
        }
        [TestMethod]
        public void Simple_init_decl_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Declaration - if initializer is used, a provided index can be a const byte");
            Assert.IsTrue(Simple_TestClass_init_decl_04.testMethod());
        }
        [TestMethod]
        public void Simple_init_decl_05_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Declaration - if initializer is used, a provided index can be a const long casted to an int");
            Assert.IsTrue(Simple_TestClass_init_decl_05.testMethod());
        }
        [TestMethod]
        public void Simple_init_shorthand_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Initialization of arrays of type int using new (shorthand)");
            OutputHelper.WriteLine(" This is to verify bug #52958 doesn't regress");
            Assert.IsTrue(Simple_TestClass_init_shorthand_01.testMethod());
        }
        [TestMethod]
        public void Simple_init_constinit_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Ensure all constant init optimization code paths are covered: all constants (VS7:124565 for more info)");
            Assert.IsTrue(Simple_TestClass_init_constinit_01.testMethod());
        }
        [TestMethod]
        public void Simple_init_constinit_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Ensure all constant init optimization code paths are covered: all variables (VS7:124565 for more info)");

            Assert.IsTrue(Simple_TestClass_init_constinit_02.testMethod());
        }
        [TestMethod]
        public void Simple_init_constinit_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Initialization");
            OutputHelper.WriteLine(" Ensure all constant init optimization code paths are covered: half variables and half constants (VS7:124565 for more info)");
            Assert.IsTrue(Simple_TestClass_init_constinit_03.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_length_01_Test()
        {
            OutputHelper.WriteLine(" acc_iter_length_01 ");
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Declare simple arrays of various lengths and verify that array.Length is correct");
            Assert.IsTrue(Simple_TestClass_acc_iter_length_01.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_bounds_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's 0th element should work fine");
            Assert.IsTrue(Simple_TestClass_acc_iter_bounds_01.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_bounds_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's maxlength element should work fine");
            Assert.IsTrue(Simple_TestClass_acc_iter_bounds_02.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_bounds_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's -1 element should throw an System.Exception");
            Assert.IsTrue(Simple_TestClass_acc_iter_bounds_03.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_bounds_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's maxlength+1 element should throw an System.Exception");
            Assert.IsTrue(Simple_TestClass_acc_iter_bounds_04.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_idxtype_a_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's index with a variable of type int should work");
            Assert.IsTrue(Simple_TestClass_acc_iter_idxtype_a_01.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_idxtype_a_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's index with a variable of type short should work");
            Assert.IsTrue(Simple_TestClass_acc_iter_idxtype_a_02.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_idxtype_a_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's index with a variable of type byte should work");

            Assert.IsTrue(Simple_TestClass_acc_iter_idxtype_a_03.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_idxtype_a_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's index with a variable of type char should work");
            Assert.IsTrue(Simple_TestClass_acc_iter_idxtype_a_04.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_idxtype_a_06_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's index with a variable of type long should work");
            Assert.IsTrue(Simple_TestClass_acc_iter_idxtype_a_06.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_idxtype_b_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's index with an int literal should work");

            Assert.IsTrue(Simple_TestClass_acc_iter_idxtype_b_01.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_idxtype_b_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's index with a short literal should work");
            Assert.IsTrue(Simple_TestClass_acc_iter_idxtype_b_02.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_idxtype_b_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's index with a byte literal should work");
            Assert.IsTrue(Simple_TestClass_acc_iter_idxtype_b_03.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_idxtype_b_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's index with a char literal should work");
            Assert.IsTrue(Simple_TestClass_acc_iter_idxtype_b_04.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_idxtype_b_06_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Accessing an array's index with a variable of type long should work");
            Assert.IsTrue(Simple_TestClass_acc_iter_idxtype_b_06.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_iter_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Declare simple array of int, init it through iteration, verify values are correct");
            Assert.IsTrue(Simple_TestClass_acc_iter_iter_01.testMethod());
        }
        [TestMethod]
        public void Simple_acc_iter_iter_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Access and Iteration");
            OutputHelper.WriteLine(" Declare simple array of char, init it through individual element assignments, verify correctness");
            Assert.IsTrue(Simple_TestClass_acc_iter_iter_02.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_a_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning int type literals into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_a_01.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_a_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning byte type literals into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_a_02.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_a_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning short type literals into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_a_03.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_a_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning long type literals into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_a_04.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_a_05_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning char type literals into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_a_05.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_a_06_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning double type literals into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_a_06.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_a_07_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning float type literals into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_a_07.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_a_08_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning double type literals into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_a_08.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_a_09_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning bool type literals into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_a_09.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_b_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning int type variables into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_b_01.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_b_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning byte type variables into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_b_02.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_b_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning short type variables into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_b_03.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_b_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning long type variables into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_b_04.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_b_05_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning char type variables into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_b_05.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_b_06_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning double type variables into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_b_06.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_b_07_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning float type variables into array elements should work");

            Assert.IsTrue(Simple_TestClass_assign_smpass_b_07.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_b_08_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning double type variables into array elements should work");

            Assert.IsTrue(Simple_TestClass_assign_smpass_b_08.testMethod());
        }
        [TestMethod]
        public void Simple_assign_smpass_b_09_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning bool type variables into array elements should work");
            Assert.IsTrue(Simple_TestClass_assign_smpass_b_09.testMethod());
        }
        [TestMethod]
        public void Simple_assign_badass_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning null to an array variable should work");
            Assert.IsTrue(Simple_TestClass_assign_badass_01.testMethod());
        }
        [TestMethod]
        public void Simple_assign_badass_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning a smaller array to a bigger array should work");
            Assert.IsTrue(Simple_TestClass_assign_badass_03.testMethod());
        }
        [TestMethod]
        public void Simple_assign_badass_04_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning a bigger array to a smaller array should work");
            Assert.IsTrue(Simple_TestClass_assign_badass_04.testMethod());
        }
        [TestMethod]
        public void Simple_assign_element_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning one element to another element of the same array should work");
            Assert.IsTrue(Simple_TestClass_assign_element_01.testMethod());
        }
        [TestMethod]
        public void Simple_assign_element_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments");
            OutputHelper.WriteLine(" Assigning one element to another element of a different array should work");
            Assert.IsTrue(Simple_TestClass_assign_element_02.testMethod());
        }
        [TestMethod]
        public void Simple_assign_argpass_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments - Passing elements to methods");
            OutputHelper.WriteLine(" Passing an element to a function should work");
            Assert.IsTrue(Simple_TestClass_assign_argpass_01.testMethod());
        }
        [TestMethod]
        public void Simple_assign_argpass_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments - Passing elements to methods");
            OutputHelper.WriteLine(" Passing an element to a function as a ref parameter should work");
            Assert.IsTrue(Simple_TestClass_assign_argpass_02.testMethod());
        }
        [TestMethod]
        public void Simple_assign_argpass_03_Test()
        {
            OutputHelper.WriteLine(" Arrays - Assignments - Passing elements to methods");
            OutputHelper.WriteLine(" Passing an element to a function as an out parameter should work");
            Assert.IsTrue(Simple_TestClass_assign_argpass_03.testMethod());
        }
        [TestMethod]
        public void Simple_object_sysarr_01_Test()
        {
            OutputHelper.WriteLine(" Arrays - As Object and System.Array");
            OutputHelper.WriteLine(" Testing the System.Array methods and Properties: System.Array.Clear()");
            Assert.IsTrue(Simple_TestClass_object_sysarr_01.testMethod());
        }
        [TestMethod]
        public void Simple_object_sysarr_02_Test()
        {
            OutputHelper.WriteLine(" Arrays - As Object and System.Array");
            OutputHelper.WriteLine(" Testing the System.Array methods and Properties: Length property");
            Assert.IsTrue(Simple_TestClass_object_sysarr_02.testMethod());
        }

        //Compiled Test Cases 
        class Simple_TestClass_decl_decl_01
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_decl_02
        {
            public static int Main_old()
            {
                byte[] arr = new byte[10];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_decl_03
        {
            public static int Main_old()
            {
                short[] arr = new short[10];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_decl_04
        {
            public static int Main_old()
            {
                long[] arr = new long[10];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_decl_05
        {
            public static int Main_old()
            {
                char[] arr = new char[10];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_decl_06
        {
            public static int Main_old()
            {
                double[] arr = new double[10];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_decl_07
        {
            public static int Main_old()
            {
                float[] arr = new float[10];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_decl_08
        {
            public static int Main_old()
            {
                double[] arr = new double[10];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_decl_09
        {
            public static int Main_old()
            {
                bool[] arr = new bool[10];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        struct myStruct
        {
            public int x;
        }
        class Simple_TestClass_decl_decl_10
        {
            public static int Main_old()
            {
                myStruct[] arr = new myStruct[10];

                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class myClass
        {
            public int x = 0;
            void meth() { }
        }
        class Simple_TestClass_decl_decl_11
        {
            public static int Main_old()
            {
                myClass[] arr = new myClass[10];

                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        interface myInterface { }
        class Simple_TestClass_decl_decl_12
        {
            public static int Main_old()
            {
                myInterface[] arr = new myInterface[10];

                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_decl_13
        {
            public static int Main_old()
            {
                object[] arr = new object[10];

                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        delegate void myDelegate(String myString);
        class Simple_TestClass_decl_decl_14
        {
            public static int Main_old()
            {
                myDelegate[] myDel = new myDelegate[10];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_decl_15
        {
            public static int Main_old()
            {
                Array[] arr = new Array[10];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_bounds_01
        {
            public static int Main_old()
            {
                int[] arr = new int[0];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_bounds_02
        {
            public static int Main_old()
            {
                try
                {//bug 16823
                    //int[] arr = new int[2147483647];
                }
                catch (System.Exception)
                {
                    OutputHelper.WriteLine("Out Of Memory System.Exception");
                }
                return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_bounds_03
        {
            public static int Main_old()
            {
                try
                {//bug 16823
                    //int[] arr = new int[2147483648];
                }
                catch (System.Exception)
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
        class Simple_TestClass_decl_index_01
        {
            public static int Main_old()
            {
                char x = 'a';
                int[] arr1 = new int[x];

                char y = 'b';
                int[] arr2 = new int[y];

                if (arr1.Length == (arr2.Length - 1))
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_index_02
        {
            public static int Main_old()
            {
                byte x = 5;
                int[] arr1 = new int[x];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_index_03
        {
            public static int Main_old()
            {
                short x = 5;
                int[] arr1 = new int[x];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_index_04
        {
            public static int Main_old()
            {
                int[] arr1 = new int[(short)5];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_index_05
        {
            public static int Main_old()
            {
                int[] arr1 = new int[(byte)5];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_index_06
        {
            public static int Main_old()
            {
                int[] arr1 = new int['a'];
                int[] arr2 = new int['b'];

                OutputHelper.WriteLine(arr1.Length.ToString());
                OutputHelper.WriteLine(arr2.Length.ToString());
                if (arr1.Length == (arr2.Length - 1))
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_index_07
        {
            public static int Main_old()
            {
                uint x = 5;
                int[] arr1 = new int[x];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_index_08
        {
            public static int Main_old()
            {
                long x = 5;
                int[] arr1 = new int[x];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_index_09
        {
            public static int Main_old()
            {
                ulong x = 5;
                int[] arr1 = new int[x];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_index_10
        {
            public static int Main_old()
            {
                int[] arr1 = new int[5U];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_index_11
        {
            public static int Main_old()
            {
                int[] arr1 = new int[5L];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_index_12
        {
            public static int Main_old()
            {
                int[] arr1 = new int[5UL];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_decl_syntax_03
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                int[ /* test comment */ ] arr2 = new int[5];
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_a_01
        {
            public static int Main_old()
            {
                int[] arr = new int[5] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_a_02
        {
            public static int Main_old()
            {
                short[] arr = new short[5] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_a_03
        {
            public static int Main_old()
            {
                byte[] arr = new byte[5] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_a_04
        {
            public static int Main_old()
            {
                long[] arr = new long[5] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_a_05
        {
            public static int Main_old()
            {
                double[] arr = new double[5] { 1.0, 2.0, 3.0, 4.0, 5.0 };
                int x = 0;
                if (arr[0] != 1.0)
                    x = 1;
                if (arr[1] != 2.0)
                    x = 1;
                if (arr[2] != 3.0)
                    x = 1;
                if (arr[3] != 4.0)
                    x = 1;
                if (arr[4] != 5.0)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_a_06
        {
            public static int Main_old()
            {
                float[] arr = new float[5] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f };
                int x = 0;
                if (arr[0] != 1.0)
                    x = 1;
                if (arr[1] != 2.0)
                    x = 1;
                if (arr[2] != 3.0)
                    x = 1;
                if (arr[3] != 4.0)
                    x = 1;
                if (arr[4] != 5.0)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_a_08
        {
            public static int Main_old()
            {
                String[] arr = new String[5] { "one", "two", "three", "four", "five" };
                int x = 0;
                if (!arr[0].Equals("one"))
                    x = 1;
                if (!arr[1].Equals("two"))
                    x = 1;
                if (!arr[2].Equals("three"))
                    x = 1;
                if (!arr[3].Equals("four"))
                    x = 1;
                if (!arr[4].Equals("five"))
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_a_09
        {
            public static int Main_old()
            {
                char[] arr = new char[5] { '1', '2', '3', '4', '5' };
                int x = 0;
                if (arr[0] != '1')
                    x = 1;
                if (arr[1] != '2')
                    x = 1;
                if (arr[2] != '3')
                    x = 1;
                if (arr[3] != '4')
                    x = 1;
                if (arr[4] != '5')
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_a_10
        {
            public static int Main_old()
            {
                bool[] arr = new bool[5] { true, false, true, false, true };
                int x = 0;
                if (!arr[0])
                    x = 1;
                if (arr[1])
                    x = 1;
                if (!arr[2])
                    x = 1;
                if (arr[3])
                    x = 1;
                if (!arr[4])
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_b_01
        {
            public static int Main_old()
            {
                int[] arr = { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_b_02
        {
            public static int Main_old()
            {
                short[] arr = { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_b_03
        {
            public static int Main_old()
            {
                byte[] arr = { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_b_04
        {
            public static int Main_old()
            {
                long[] arr = { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_b_05
        {
            public static int Main_old()
            {
                double[] arr = { 1.0, 2.0, 3.0, 4.0, 5.0 };
                int x = 0;
                if (arr[0] != 1.0)
                    x = 1;
                if (arr[1] != 2.0)
                    x = 1;
                if (arr[2] != 3.0)
                    x = 1;
                if (arr[3] != 4.0)
                    x = 1;
                if (arr[4] != 5.0)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_b_06
        {
            public static int Main_old()
            {
                float[] arr = { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f };
                int x = 0;
                if (arr[0] != 1.0)
                    x = 1;
                if (arr[1] != 2.0)
                    x = 1;
                if (arr[2] != 3.0)
                    x = 1;
                if (arr[3] != 4.0)
                    x = 1;
                if (arr[4] != 5.0)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_b_08
        {
            public static int Main_old()
            {
                String[] arr = { "one", "two", "three", "four", "five" };
                int x = 0;
                if (!arr[0].Equals("one"))
                    x = 1;
                if (!arr[1].Equals("two"))
                    x = 1;
                if (!arr[2].Equals("three"))
                    x = 1;
                if (!arr[3].Equals("four"))
                    x = 1;
                if (!arr[4].Equals("five"))
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_b_09
        {
            public static int Main_old()
            {
                char[] arr = { '1', '2', '3', '4', '5' };
                int x = 0;
                if (arr[0] != '1')
                    x = 1;
                if (arr[1] != '2')
                    x = 1;
                if (arr[2] != '3')
                    x = 1;
                if (arr[3] != '4')
                    x = 1;
                if (arr[4] != '5')
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_b_10
        {
            public static int Main_old()
            {
                bool[] arr = { true, false, true, false, true };
                int x = 0;
                if (!arr[0])
                    x = 1;
                if (arr[1])
                    x = 1;
                if (!arr[2])
                    x = 1;
                if (arr[3])
                    x = 1;
                if (!arr[4])
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_c_01
        {
            public static int Main_old()
            {
                int[] arr = new int[] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_c_02
        {
            public static int Main_old()
            {
                short[] arr = new short[] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_c_03
        {
            public static int Main_old()
            {
                byte[] arr = new byte[] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_c_04
        {
            public static int Main_old()
            {
                long[] arr = new long[] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_c_05
        {
            public static int Main_old()
            {
                double[] arr = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 };
                int x = 0;
                if (arr[0] != 1.0)
                    x = 1;
                if (arr[1] != 2.0)
                    x = 1;
                if (arr[2] != 3.0)
                    x = 1;
                if (arr[3] != 4.0)
                    x = 1;
                if (arr[4] != 5.0)
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_c_06
        {
            public static int Main_old()
            {
                float[] arr = new float[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f };
                int x = 0;
                if (arr[0] != 1.0)
                    x = 1;
                if (arr[1] != 2.0)
                    x = 1;
                if (arr[2] != 3.0)
                    x = 1;
                if (arr[3] != 4.0)
                    x = 1;
                if (arr[4] != 5.0)
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_c_08
        {
            public static int Main_old()
            {
                String[] arr = new String[] { "one", "two", "three", "four", "five" };
                int x = 0;
                if (!arr[0].Equals("one"))
                    x = 1;
                if (!arr[1].Equals("two"))
                    x = 1;
                if (!arr[2].Equals("three"))
                    x = 1;
                if (!arr[3].Equals("four"))
                    x = 1;
                if (!arr[4].Equals("five"))
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_c_09
        {
            public static int Main_old()
            {
                char[] arr = new char[] { '1', '2', '3', '4', '5' };
                int x = 0;
                if (arr[0] != '1')
                    x = 1;
                if (arr[1] != '2')
                    x = 1;
                if (arr[2] != '3')
                    x = 1;
                if (arr[3] != '4')
                    x = 1;
                if (arr[4] != '5')
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_c_10
        {
            public static int Main_old()
            {
                bool[] arr = new bool[] { true, false, true, false, true };
                int x = 0;
                if (!arr[0])
                    x = 1;
                if (arr[1])
                    x = 1;
                if (!arr[2])
                    x = 1;
                if (arr[3])
                    x = 1;
                if (!arr[4])
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_d_01
        {
            public static int Main_old()
            {
                int[] arr;
                arr = new int[5] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_d_02
        {
            public static int Main_old()
            {
                short[] arr;
                arr = new short[5] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_d_03
        {
            public static int Main_old()
            {
                byte[] arr;
                arr = new byte[5] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_d_04
        {
            public static int Main_old()
            {
                long[] arr;
                arr = new long[5] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_d_05
        {
            public static int Main_old()
            {
                double[] arr;
                arr = new double[5] { 1.0, 2.0, 3.0, 4.0, 5.0 };
                int x = 0;
                if (arr[0] != 1.0)
                    x = 1;
                if (arr[1] != 2.0)
                    x = 1;
                if (arr[2] != 3.0)
                    x = 1;
                if (arr[3] != 4.0)
                    x = 1;
                if (arr[4] != 5.0)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_d_06
        {
            public static int Main_old()
            {
                float[] arr;
                arr = new float[5] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f };
                int x = 0;
                if (arr[0] != 1.0)
                    x = 1;
                if (arr[1] != 2.0)
                    x = 1;
                if (arr[2] != 3.0)
                    x = 1;
                if (arr[3] != 4.0)
                    x = 1;
                if (arr[4] != 5.0)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_d_08
        {
            public static int Main_old()
            {
                String[] arr;
                arr = new String[5] { "one", "two", "three", "four", "five" };
                int x = 0;
                if (!arr[0].Equals("one"))
                    x = 1;
                if (!arr[1].Equals("two"))
                    x = 1;
                if (!arr[2].Equals("three"))
                    x = 1;
                if (!arr[3].Equals("four"))
                    x = 1;
                if (!arr[4].Equals("five"))
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_d_09
        {
            public static int Main_old()
            {
                char[] arr;
                arr = new char[5] { '1', '2', '3', '4', '5' };
                int x = 0;
                if (arr[0] != '1')
                    x = 1;
                if (arr[1] != '2')
                    x = 1;
                if (arr[2] != '3')
                    x = 1;
                if (arr[3] != '4')
                    x = 1;
                if (arr[4] != '5')
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_d_10
        {
            public static int Main_old()
            {
                bool[] arr;
                arr = new bool[5] { true, false, true, false, true };
                int x = 0;
                if (!arr[0])
                    x = 1;
                if (arr[1])
                    x = 1;
                if (!arr[2])
                    x = 1;
                if (arr[3])
                    x = 1;
                if (!arr[4])
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_e_01
        {
            public static int Main_old()
            {
                int[] arr;
                arr = new int[] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_e_02
        {
            public static int Main_old()
            {
                short[] arr;
                arr = new short[] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_e_03
        {
            public static int Main_old()
            {
                byte[] arr;
                arr = new byte[] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_e_04
        {
            public static int Main_old()
            {
                long[] arr;
                arr = new long[] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_e_05
        {
            public static int Main_old()
            {
                double[] arr;
                arr = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 };
                int x = 0;
                if (arr[0] != 1.0)
                    x = 1;
                if (arr[1] != 2.0)
                    x = 1;
                if (arr[2] != 3.0)
                    x = 1;
                if (arr[3] != 4.0)
                    x = 1;
                if (arr[4] != 5.0)
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_e_06
        {
            public static int Main_old()
            {
                float[] arr;
                arr = new float[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f };
                int x = 0;
                if (arr[0] != 1.0)
                    x = 1;
                if (arr[1] != 2.0)
                    x = 1;
                if (arr[2] != 3.0)
                    x = 1;
                if (arr[3] != 4.0)
                    x = 1;
                if (arr[4] != 5.0)
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_e_08
        {
            public static int Main_old()
            {
                String[] arr;
                arr = new String[] { "one", "two", "three", "four", "five" };
                int x = 0;
                if (!arr[0].Equals("one"))
                    x = 1;
                if (!arr[1].Equals("two"))
                    x = 1;
                if (!arr[2].Equals("three"))
                    x = 1;
                if (!arr[3].Equals("four"))
                    x = 1;
                if (!arr[4].Equals("five"))
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_e_09
        {
            public static int Main_old()
            {
                char[] arr;
                arr = new char[] { '1', '2', '3', '4', '5' };
                int x = 0;
                if (arr[0] != '1')
                    x = 1;
                if (arr[1] != '2')
                    x = 1;
                if (arr[2] != '3')
                    x = 1;
                if (arr[3] != '4')
                    x = 1;
                if (arr[4] != '5')
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_init_e_10
        {
            public static int Main_old()
            {
                bool[] arr;
                arr = new bool[] { true, false, true, false, true };
                int x = 0;
                if (!arr[0])
                    x = 1;
                if (arr[1])
                    x = 1;
                if (!arr[2])
                    x = 1;
                if (arr[3])
                    x = 1;
                if (!arr[4])
                    x = 1;
                if (arr.Length != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_syntax_09
        {
            public static int Main_old()
            {
                int[] arr = new int[5] { 1, 2, 3, 4, 5 };
                int[] arr2 = new int[5] { 1, /* test comment */ 2, 3, 4, 5 };
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_syntax_11
        {
            public static int Main_old()
            {
                int[] arr = new int[] { };
                if (arr.Length == 0)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_syntax_12
        {
            public static int Main_old()
            {
                int[] arr = new int[0] { };
                if (arr.Length == 0)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_decl_02
        {
            const int myLength = 5;
            public static int Main_old()
            {
                int[] arr = new int[myLength] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_decl_03
        {
            const short myLength = 5;
            public static int Main_old()
            {
                int[] arr = new int[myLength] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_decl_04
        {
            const byte myLength = 5;
            public static int Main_old()
            {
                int[] arr = new int[myLength] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_decl_05
        {
            const long myLength = 5;
            public static int Main_old()
            {
                int[] arr = new int[(int)myLength] { 1, 2, 3, 4, 5 };
                int x = 0;
                if (arr[0] != 1)
                    x = 1;
                if (arr[1] != 2)
                    x = 1;
                if (arr[2] != 3)
                    x = 1;
                if (arr[3] != 4)
                    x = 1;
                if (arr[4] != 5)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_shorthand_01
        {
            static int[] a = { 1, 2, 3, 4 };
            public static int Main_old()
            {
                for (int i = 0; i < 4; i++)
                {
                    int[] b = { 1, 2, 3, 4 };
                    OutputHelper.WriteLine(a[i].ToString());
                    OutputHelper.WriteLine(b[i].ToString());
                }
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_constinit_01
        {
            int[] TestArray1 = new int[] { 1, 2, 3, 4 };
            static int Main_old()
            {
                int[] TestArray2 = new int[] { 1, 2, 3, 4 };

                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_constinit_02
        {
            int a = 1;
            int b = 2;
            int c = 3;
            int d = 4;
            void MyMethod()
            {
                int[] TestArray = new int[] { a, b, c, d };

            }
            static int Main_old()
            {
                Simple_TestClass_init_constinit_02 a = new Simple_TestClass_init_constinit_02();
                a.MyMethod();

                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_init_constinit_03
        {
            int a = 1;
            int b = 2;
            void MyMethod()
            {
                int[] TestArray = new int[] { 1, a, 2, b };

            }
            static int Main_old()
            {
                Simple_TestClass_init_constinit_03 a = new Simple_TestClass_init_constinit_03();
                a.MyMethod();

                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_length_01
        {
            public static int Main_old()
            {
                int[] arr1 = new int[10];
                double[] arr2 = new double[15];
                float[] arr3;
                arr3 = new float[1];
                char[] arr4;
                arr4 = new char[0];
                int x = 0;
                if (arr1.Length != 10)
                    x = 1;
                if (arr2.Length != 15)
                    x = 1;
                if (arr3.Length != 1)
                    x = 1;
                if (arr4.Length != 0)
                    x = 1;
                return x;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_bounds_01
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                arr[0] = 5;
                if (arr[0] == 5)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_bounds_02
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                arr[9] = 5;
                if (arr[9] == 5)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_bounds_03
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                try
                {
                    arr[-1] = 5;
                }
                catch (System.Exception)
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
        class Simple_TestClass_acc_iter_bounds_04
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                try
                {
                    arr[10] = 5;
                }
                catch (System.Exception)
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
        class Simple_TestClass_acc_iter_idxtype_a_01
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                arr[5] = 100;
                int idx = 5;
                if (arr[idx] == 100)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_idxtype_a_02
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                arr[5] = 100;
                short idx = 5;
                if (arr[idx] == 100)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_idxtype_a_03
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                arr[5] = 100;
                byte idx = 5;
                if (arr[idx] == 100)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_idxtype_a_04
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                arr[5] = 100;
                char idx = (char)5;
                if (arr[idx] == 100)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_idxtype_a_06
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                arr[5] = 100;
                long idx = 5L;
                if (arr[idx] == 100)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_idxtype_b_01
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                arr[5] = 100;
                if (arr[5] == 100)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_idxtype_b_02
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                arr[5] = 100;
                if (arr[(short)5] == 100)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_idxtype_b_03
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                arr[5] = 100;
                if (arr[(byte)5] == 100)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_idxtype_b_04
        {
            public static int Main_old()
            {
                int[] arr = new int[35];
                arr[32] = 100;
                if (arr[' '] == 100)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_idxtype_b_06
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                arr[5] = 100;
                if (arr[5L] == 100)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_iter_01
        {
            public static int Main_old()
            {
                int[] arr = new int[10];
                for (int x = 0; x < arr.Length; x++)
                {
                    arr[x] = x;
                }
                int result = 0;
                for (int y = 0; y < arr.Length; y++)
                {
                    if (arr[y] != y)
                        result = 1;
                }
                return result;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_acc_iter_iter_02
        {
            public static int Main_old()
            {
                char[] arr = new char[10];
                arr[0] = 'L';
                arr[1] = 'a';
                arr[2] = 'n';
                arr[3] = 'g';
                arr[4] = 'u';
                arr[5] = 'a';
                arr[6] = 'g';
                arr[7] = 'e';

                int result = 0;
                if (arr[0] != 'L') result = 1;
                if (arr[1] != 'a') result = 1;
                if (arr[2] != 'n') result = 1;
                if (arr[3] != 'g') result = 1;
                if (arr[4] != 'u') result = 1;
                if (arr[5] != 'a') result = 1;
                if (arr[6] != 'g') result = 1;
                if (arr[7] != 'e') result = 1;
                return result;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_a_01
        {
            public static int Main_old()
            {
                int[] arr = new int[5];
                arr[3] = 5;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_a_02
        {
            public static int Main_old()
            {
                byte[] arr = new byte[5];
                arr[3] = (byte)5;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_a_03
        {
            public static int Main_old()
            {
                short[] arr = new short[5];
                arr[3] = (short)5;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_a_04
        {
            public static int Main_old()
            {
                long[] arr = new long[5];
                arr[3] = (long)5;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_a_05
        {
            public static int Main_old()
            {
                char[] arr = new char[5];
                arr[3] = 'c';
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_a_06
        {
            public static int Main_old()
            {
                double[] arr = new double[5];
                arr[3] = 5.42;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_a_07
        {
            public static int Main_old()
            {
                float[] arr = new float[5];
                arr[3] = (float)1.00;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_a_08
        {
            public static int Main_old()
            {
                double[] arr = new double[5];
                arr[3] = (double)1.00;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_a_09
        {
            public static int Main_old()
            {
                bool[] arr = new bool[5];
                arr[3] = true;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_b_01
        {
            public static int Main_old()
            {
                int[] arr = new int[5];
                int x = 5;
                arr[3] = x;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_b_02
        {
            public static int Main_old()
            {
                byte[] arr = new byte[5];
                byte x = 5;

                arr[3] = x;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_b_03
        {
            public static int Main_old()
            {
                short[] arr = new short[5];
                short x = 5;
                arr[3] = x;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_b_04
        {
            public static int Main_old()
            {
                long[] arr = new long[5];
                long x = 5;
                arr[3] = x;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_b_05
        {
            public static int Main_old()
            {
                char[] arr = new char[5];
                char x = 'c';
                arr[3] = x;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_b_06
        {
            public static int Main_old()
            {
                double[] arr = new double[5];
                double x = 5.42;
                arr[3] = x;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_b_07
        {
            public static int Main_old()
            {
                float[] arr = new float[5];
                float x = (float)1.00;
                arr[3] = x;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_b_08
        {
            public static int Main_old()
            {
                double[] arr = new double[5];
                double x = (double)1.00;
                arr[3] = x;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_smpass_b_09
        {
            public static int Main_old()
            {
                bool[] arr = new bool[5];
                bool x = true;
                arr[3] = x;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_badass_01
        {
            public static int Main_old()
            {
                int[] arr = new int[5] { 1, 2, 3, 4, 5 };
                if (arr[2] != 3)
                    return 1;
                arr = null;
                try
                {
                    if (arr[2] == 3)
                        return 1;
                }
                catch (System.Exception)
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
        class Simple_TestClass_assign_badass_03
        {
            public static int Main_old()
            {
                int[] arr1 = new int[5] { 1, 2, 3, 4, 5 };
                int[] arr2 = new int[3] { 6, 7, 8 };
                int result = 0;
                // Verify lengths are different
                if (arr1.Length == arr2.Length)
                    result = 1;
                // assign the small array to the larger array
                //   This is actually just making arr1 point to arr2, NOT copying
                arr1 = arr2;

                // verify the values are correct
                if (arr1[0] != 6) result = 1;
                if (arr1[1] != 7) result = 1;
                if (arr1[2] != 8) result = 1;

                if (arr1.Length != arr2.Length)
                    result = 1;
                return result;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_badass_04
        {
            public static int Main_old()
            {
                int[] arr1 = new int[3] { 6, 7, 8 };
                int[] arr2 = new int[5] { 1, 2, 3, 4, 5 };
                int result = 0;
                // Verify lengths are different
                if (arr1.Length == arr2.Length)
                    result = 1;
                // assign the larger array to the smaller array
                //   This is actually just making arr1 point to arr2, NOT copying
                arr1 = arr2;

                // verify the values are correct
                if (arr1[0] != 1) result = 1;
                if (arr1[1] != 2) result = 1;
                if (arr1[2] != 3) result = 1;

                if (arr1.Length != arr2.Length)
                    result = 1;
                return result;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_element_01
        {
            public static int Main_old()
            {
                int[] arr = new int[5] { 1, 2, 3, 4, 5 };
                arr[2] = arr[4];
                if (arr[2] == 5)
                    return 0;

                return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_element_02
        {
            public static int Main_old()
            {
                int[] arr1 = new int[5] { 1, 2, 3, 4, 5 };
                int[] arr2 = new int[5] { 6, 7, 8, 9, 10 };
                arr1[2] = arr2[4];
                if (arr1[2] == 10)
                    return 0;

                return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_argpass_01
        {
            public static int ElementTaker(int val)
            {
                return val;
            }

            public static int Main_old()
            {
                int[] arr = new int[5] { 1, 2, 3, 4, 5 };
                OutputHelper.WriteLine(ElementTaker(arr[2]).ToString());
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_argpass_02
        {
            public static int ElementTaker(ref int val)
            {
                val += 5;
                return val;
            }

            public static int Main_old()
            {
                int[] arr = new int[5] { 1, 2, 3, 4, 5 };
                var ret = ElementTaker(ref arr[2]).ToString();
                OutputHelper.WriteLine(ret);
                if (arr[2] != 8)
                    return 1;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_assign_argpass_03
        {
            public static int ElementTaker(out int val)
            {
                val = 5;
                return val;
            }

            public static int Main_old()
            {
                int[] arr = new int[5] { 1, 2, 3, 4, 5 };
                var ret = ElementTaker(out arr[2]).ToString();
                OutputHelper.WriteLine(ret);
                if (arr[2] != 5)
                    return 1;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_object_sysarr_01
        {
            public static int Main_old()
            {
                int[] arr = new int[5] { 1, 2, 3, 4, 5 };
                int result = 0;

                for (int x = 0; x < arr.Length; x++)
                    if (arr[x] != x + 1) result = 1;

                Array.Clear(arr, 0, 5);
                for (int x = 0; x < arr.Length; x++)
                    if (arr[x] != 0) result = 1;

                return result;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Simple_TestClass_object_sysarr_02
        {
            public static int Main_old()
            {
                int result = 0;
                int[] arr1 = new int[5] { 1, 2, 3, 4, 5 };
                if (arr1.Length != 5) result = 1;

                int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
                if (arr2.Length != 5) result = 1;

                int[] arr3 = new int[] { };
                if (arr3.Length != 0) result = 1;
                int[] arr4 = new int[0];
                if (arr4.Length != 0) result = 1;
                return result;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

    }
}
