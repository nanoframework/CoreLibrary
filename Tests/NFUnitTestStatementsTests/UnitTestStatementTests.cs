// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestStatementsTests
{
    [TestClass]
    public class UnitTestStatementTests
    {
        [TestMethod]
        public void Statements_Label_001_Test()
        {
            // Label_001.sc
            // Make sure labels can be declared
            Assert.IsTrue(Statements_TestClass_Label_001.testMethod());
        }

        [TestMethod]
        public void Statements_Label_002_Test()
        {
            // Label_002.sc
            // Make sure labels can be referenced. Assumes 'goto'
            Assert.IsTrue(Statements_TestClass_Label_002.testMethod());
        }

        [TestMethod]
        public void Statements_Label_004_Test()
        {
            // Label_004.sc
            // Make sure labels can be associated with an empty statement
            Assert.IsTrue(Statements_TestClass_Label_004.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_001_Test()
        {
            // Decl_001.sc
            // Declare a local variable of an intrinsic type
            Assert.IsTrue(Statements_TestClass_Decl_001.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_002_Test()
        {
            // Decl_002.sc
            // Declare a local variable of an intrinsic type and initialize it
            Assert.IsTrue(Statements_TestClass_Decl_002.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_003_Test()
        {
            // Decl_003.sc
            // Declare a local variable of an intrinsic type and initialize it
            // with an expression.
            Assert.IsTrue(Statements_TestClass_Decl_003.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_004_Test()
        {
            // Decl_004.sc
            // Declare a local variable of an external object type
            Assert.IsTrue(Statements_TestClass_Decl_004.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_007_Test()
        {
            // Decl_007.sc
            // Declare a series of local variables of an intrinsic type with commas
            Assert.IsTrue(Statements_TestClass_Decl_007.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_009_Test()
        {
            // Decl_009.sc
            // Declare a series of local variables of an intrinsic type with commas and
            // initial assignments.
            Assert.IsTrue(Statements_TestClass_Decl_009.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_010_Test()
        {
            // Decl_010.sc
            // Declare a local variable of an intrinsic type as an array
            Assert.IsTrue(Statements_TestClass_Decl_010.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_012_Test()
        {
            // Decl_012.sc
            // Declare a local variable of an intrinsic type as an array, allocate and reference it.
            Assert.IsTrue(Statements_TestClass_Decl_012.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_014_Test()
        {
            // Decl_014.sc
            // Declare a local variable of an intrinsic type as an initialized array
            Assert.IsTrue(Statements_TestClass_Decl_014.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_016_Test()
        {
            // Decl_016.sc
            // Correctly declare a local variable of a type that has no default constructor
            // as an array.
            Assert.IsTrue(Statements_TestClass_Decl_016.testMethod());
        }

        [TestMethod]
        public void Statements_Block_001_Test()
        {
            // Block_001.sc
            // Statements_TestClass_? Several types of statement blocks.  Statement blocks
            // are so fundamental, that most can be tested in one pass.
            // Note that by the nature of this code, many warnings
            // could/should be generated about items that are never reached.
            Assert.IsTrue(Statements_TestClass_Block_001.testMethod());
        }

        [TestMethod]
        public void Statements_Empty_001_Test()
        {
            // Empty_001.sc
            // Statements_TestClass_? Several scenarios for empty statement.  Emtpy statements
            // are so fundamental, that most can be tested in one pass.
            // Note that by the nature of this code, many warnings
            // could/should be generated about items that are never reached.
            Assert.IsTrue(Statements_TestClass_Empty_001.testMethod());
        }

        [TestMethod]
        public void Statements_Expr_002_Test()
        {
            // Expr_002.sc
            // Use an expression with side effects.
            Assert.IsTrue(Statements_TestClass_Expr_002.testMethod());
        }

        [TestMethod]
        public void Statements_Expr_003_Test()
        {
            // Expr_003.sc
            // Use an expression with side effects and multiple l-values.
            Assert.IsTrue(Statements_TestClass_Expr_003.testMethod());
        }

        [TestMethod]
        public void Statements_Expr_004_Test()
        {
            // Expr_004.sc
            // Run a quick test of common operator/assignment combos
            Assert.IsTrue(Statements_TestClass_Expr_004.testMethod());
        }

        [TestMethod]
        public void Statements_Expr_006_Test()
        {
            //    complex assignment
            Assert.IsTrue(Statements_TestClass_Expr_006.testMethod());
        }

        [TestMethod]
        public void Statements_if_001_Test()
        {
            // if_001.sc
            // Simple boolean if with a single statement
            Assert.IsTrue(Statements_TestClass_if_001.testMethod());
        }

        [TestMethod]
        public void Statements_if_003_Test()
        {
            // if_003.sc
            // Simple boolean if with a block statement
            Assert.IsTrue(Statements_TestClass_if_003.testMethod());
        }

        [TestMethod]
        public void Statements_if_005_Test()
        {
            // if_005.sc
            // Simple boolean if with a single statement and else
            Assert.IsTrue(Statements_TestClass_if_005.testMethod());
        }

        [TestMethod]
        public void Statements_if_007_Test()
        {
            // if_007.sc
            // Simple boolean if with a block statement
            Assert.IsTrue(Statements_TestClass_if_007.testMethod());
        }

        [TestMethod]
        public void Statements_if_009_Test()
        {
            // if_009.sc
            // Nest ifs with elses without blocks. Statements_TestClass_? that the 'else' ambiguity from
            // C/C++ is handled the same way (else bound to closest if)
            Assert.IsTrue(Statements_TestClass_if_009.testMethod());
        }

        [TestMethod]
        public void Statements_switch_001_Test()
        {
            // switch_001.sc
            // Empty switch
            Assert.IsTrue(Statements_TestClass_switch_001.testMethod());
        }

        [TestMethod]
        public void Statements_switch_002_Test()
        {
            // switch_002.sc
            // Default only switch
            Assert.IsTrue(Statements_TestClass_switch_002.testMethod());
        }

        [TestMethod]
        public void Statements_switch_003_Test()
        {
            // switch_003.sc
            // Switch with single case without break - no default
            Assert.IsTrue(Statements_TestClass_switch_003.testMethod());
        }

        [TestMethod]
        public void Statements_switch_004_Test()
        {
            // switch_004.sc
            // Switch with one case, using break
            Assert.IsTrue(Statements_TestClass_switch_004.testMethod());
        }

        [TestMethod]
        public void Statements_switch_005_Test()
        {
            // switch_005.sc
            // Switch with two cases, using break
            Assert.IsTrue(Statements_TestClass_switch_005.testMethod());
        }

        [TestMethod]
        public void Statements_switch_006_Test()
        {
            // switch_006.sc
            // Switch with one case and a default
            Assert.IsTrue(Statements_TestClass_switch_006.testMethod());
        }

        [TestMethod]
        public void Statements_switch_007_Test()
        {
            // switch_007.sc
            // Switch with two cases and a default
            Assert.IsTrue(Statements_TestClass_switch_007.testMethod());
        }

        [TestMethod]
        public void Statements_switch_010_Test()
        {
            // switch_010.sc
            // Switch with a const variable in a case
            Assert.IsTrue(Statements_TestClass_switch_010.testMethod());
        }

        [TestMethod]
        public void Statements_switch_012_Test()
        {
            // switch_012.sc
            // Multiple case labels
            Assert.IsTrue(Statements_TestClass_switch_012.testMethod());
        }

        [TestMethod]
        public void Statements_switch_013_Test()
        {
            // switch_013.sc
            // test goto all over
            // Expected Output
            Assert.IsTrue(Statements_TestClass_switch_013.testMethod());
        }

        [TestMethod]
        public void Statements_switch_015_Test()
        {
            // switch_015.sc
            // Run a switch over a specific type: byte
            Assert.IsTrue(Statements_TestClass_switch_015.testMethod());
        }

        [TestMethod]
        public void Statements_switch_016_Test()
        {
            // switch_016.sc
            // Run a switch over a specific type: char
            Assert.IsTrue(Statements_TestClass_switch_016.testMethod());
        }

        [TestMethod]
        public void Statements_switch_017_Test()
        {
            // switch_017.sc
            // Run a switch over a specific type: short
            Assert.IsTrue(Statements_TestClass_switch_017.testMethod());
        }

        [TestMethod]
        public void Statements_switch_018_Test()
        {
            // switch_018.sc
            // Run a switch over a specific type: int
            Assert.IsTrue(Statements_TestClass_switch_018.testMethod());
        }

        [TestMethod]
        public void Statements_switch_019_Test()
        {
            // switch_019.sc
            // Run a switch over a specific type: long
            Assert.IsTrue(Statements_TestClass_switch_019.testMethod());
        }

        [TestMethod]
        public void Statements_switch_023_Test()
        {
            // switch_023.sc
            // Run a switch over a specific type: enum
            Assert.IsTrue(Statements_TestClass_switch_023.testMethod());
        }

        [TestMethod]
        public void Statements_switch_030_Test()
        {
            //    switch on int variable, float case
            Assert.IsTrue(Statements_TestClass_switch_030.testMethod());
        }

        [TestMethod]
        public void Statements_switch_031_Test()
        {
            //    switch with holes in range
            Assert.IsTrue(Statements_TestClass_switch_031.testMethod());
        }

        [TestMethod]
        public void Statements_switch_032_Test()
        {
            //    switch: default case at top
            Assert.IsTrue(Statements_TestClass_switch_032.testMethod());
        }

        [TestMethod]
        public void Statements_switch_033_Test()
        {
            //    switch: default case in middle
            Assert.IsTrue(Statements_TestClass_switch_033.testMethod());
        }

        [TestMethod]
        public void Statements_switch_034_Test()
        {
            //    switch: default case in middle
            Assert.IsTrue(Statements_TestClass_switch_034.testMethod());
        }

        [TestMethod]
        public void Statements_switch_035_Test()
        {
            // Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of 
            // the switch expression to one of the following possible governing types: sbyte, byte, short,
            // ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if 
            // more than one such implicit conversion exists, a compile-time error occurs.
            Assert.IsTrue(Statements_TestClass_switch_035.testMethod());
        }

        [TestMethod]
        public void Statements_switch_036_Test()
        {
            // Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of 
            // the switch expression to one of the following possible governing types: sbyte, byte, short,
            // ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if 
            // more than one such implicit conversion exists, a compile-time error occurs.
            Assert.IsTrue(Statements_TestClass_switch_036.testMethod());
        }

        [TestMethod]
        public void Statements_switch_037_Test()
        {
            // Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of 
            // the switch expression to one of the following possible governing types: sbyte, byte, short,
            // ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if 
            // more than one such implicit conversion exists, a compile-time error occurs.
            Assert.IsTrue(Statements_TestClass_switch_037.testMethod());
        }

        [TestMethod]
        public void Statements_switch_038_Test()
        {
            // Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of 
            // the switch expression to one of the following possible governing types: sbyte, byte, short,
            // ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if 
            // more than one such implicit conversion exists, a compile-time error occurs.
            Assert.IsTrue(Statements_TestClass_switch_038.testMethod());
        }

        [TestMethod]
        public void Statements_switch_039_Test()
        {
            // Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of 
            // the switch expression to one of the following possible governing types: sbyte, byte, short,
            // ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if 
            // more than one such implicit conversion exists, a compile-time error occurs.
            Assert.IsTrue(Statements_TestClass_switch_039.testMethod());
        }

        [TestMethod]
        public void Statements_switch_040_Test()
        {
            // Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of 
            // the switch expression to one of the following possible governing types: sbyte, byte, short,
            // ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if 
            // more than one such implicit conversion exists, a compile-time error occurs.
            Assert.IsTrue(Statements_TestClass_switch_040.testMethod());
        }

        [TestMethod]
        public void Statements_switch_041_Test()
        {
            // Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of 
            // the switch expression to one of the following possible governing types: sbyte, byte, short,
            // ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if 
            // more than one such implicit conversion exists, a compile-time error occurs.
            Assert.IsTrue(Statements_TestClass_switch_041.testMethod());
        }

        [TestMethod]
        public void Statements_switch_042_Test()
        {
            // Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of 
            // the switch expression to one of the following possible governing types: sbyte, byte, short,
            // ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if 
            // more than one such implicit conversion exists, a compile-time error occurs.
            Assert.IsTrue(Statements_TestClass_switch_042.testMethod());
        }

        [TestMethod]
        public void Statements_switch_044_Test()
        {
            // Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of 
            // the switch expression to one of the following possible governing types: sbyte, byte, short,
            // ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if 
            // more than one such implicit conversion exists, a compile-time error occurs.
            Assert.IsTrue(Statements_TestClass_switch_044.testMethod());
        }

        [TestMethod]
        public void Statements_switch_047_Test()
        {
            // Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of 
            // the switch expression to one of the following possible governing types: sbyte, byte, short,
            // ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if 
            // more than one such implicit conversion exists, a compile-time error occurs.
            // Ensure error is emmited on when more than one implicit conversion to an acceptable governing type is defined
            Assert.IsTrue(Statements_TestClass_switch_047.testMethod());
        }

        [TestMethod]
        public void Statements_switch_049_Test()
        {
            // warning CS1522: Empty switch block
            Assert.IsTrue(Statements_TestClass_switch_049.testMethod());
        }

        [TestMethod]
        public void Statements_switch_string_001_Test()
        {
            //    switch on string: null
            Assert.IsTrue(Statements_TestClass_switch_string_001.testMethod());
        }

        [TestMethod]
        public void Statements_dowhile_001_Test()
        {
            // dowhile_001.sc
            // do/while with a single statement
            Assert.IsTrue(Statements_TestClass_dowhile_001.testMethod());
        }

        [TestMethod]
        public void Statements_dowhile_002_Test()
        {
            // dowhile_002.sc
            // do/while with a compound statement
            Assert.IsTrue(Statements_TestClass_dowhile_002.testMethod());
        }

        [TestMethod]
        public void Statements_dowhile_003_Test()
        {
            // dowhile_003.sc
            // verify known false condition executes only once with single statement
            Assert.IsTrue(Statements_TestClass_dowhile_003.testMethod());
        }

        [TestMethod]
        public void Statements_dowhile_004_Test()
        {
            // dowhile_004.sc
            // verify known true condition executes with single statement
            Assert.IsTrue(Statements_TestClass_dowhile_004.testMethod());
        }

        [TestMethod]
        public void Statements_dowhile_005_Test()
        {
            // dowhile_005.sc
            // verify known false condition executes once with compound statements
            Assert.IsTrue(Statements_TestClass_dowhile_005.testMethod());
        }

        [TestMethod]
        public void Statements_dowhile_006_Test()
        {
            // dowhile_006.sc
            // verify known true condition executes with compound statements
            Assert.IsTrue(Statements_TestClass_dowhile_006.testMethod());
        }

        [TestMethod]
        public void Statements_for_001_Test()
        {
            // for_001.sc
            // empty for loop
            Assert.IsTrue(Statements_TestClass_for_001.testMethod());
        }

        [TestMethod]
        public void Statements_for_003_Test()
        {
            // for_003.sc
            // empty initializer in for loop
            Assert.IsTrue(Statements_TestClass_for_003.testMethod());
        }

        [TestMethod]
        public void Statements_for_004_Test()
        {
            // for_004.sc
            // empty iterator in for loop
            Assert.IsTrue(Statements_TestClass_for_004.testMethod());
        }

        [TestMethod]
        public void Statements_for_006_Test()
        {
            // for_006.sc
            // Full normal for loop
            Assert.IsTrue(Statements_TestClass_for_006.testMethod());
        }

        [TestMethod]
        public void Statements_for_007_Test()
        {
            // for_007.sc
            // Full normal for loop with a compound statement
            Assert.IsTrue(Statements_TestClass_for_007.testMethod());
        }

        [TestMethod]
        public void Statements_for_008_Test()
        {
            // for_008.sc
            // Multiple declarations in initializer
            Assert.IsTrue(Statements_TestClass_for_008.testMethod());
        }

        [TestMethod]
        public void Statements_for_009_Test()
        {
            // for_009.sc
            // Statements_TestClass_? statement expression lists in for initializer
            Assert.IsTrue(Statements_TestClass_for_009.testMethod());
        }

        [TestMethod]
        public void Statements_for_010_Test()
        {
            // for_010.sc
            // Statements_TestClass_? statement expression lists in for iterator
            Assert.IsTrue(Statements_TestClass_for_010.testMethod());
        }

        [TestMethod]
        public void Statements_for_011_Test()
        {
            // for_011.sc
            // Statements_TestClass_? statement expression lists in for initializer and iterator
            Assert.IsTrue(Statements_TestClass_for_011.testMethod());
        }

        [TestMethod]
        public void Statements_for_013_Test()
        {
            // for_013.sc
            // Verify conditional evaluates before iterator
            Assert.IsTrue(Statements_TestClass_for_013.testMethod());
        }

        [TestMethod]
        public void Statements_for_014_Test()
        {
            // for_014.sc
            // Verify method calls work ok in all for loop areas
            Assert.IsTrue(Statements_TestClass_for_014.testMethod());
        }

        [TestMethod]
        public void Statements_char_in_string_s01_Test()
        {
            // Optimization to foreach (char c in String) by treating String as a char array
            Assert.IsTrue(Statements_TestClass_char_in_string_s01.testMethod());
        }

        [TestMethod]
        public void Statements_char_in_string_ex01_Test()
        {
            // Optimization to foreach (char c in String) by treating String as a char array
            Assert.IsTrue(Statements_TestClass_char_in_string_ex01.testMethod());
        }

        [TestMethod]
        public void Statements_while_001_Test()
        {
            // while_001.sc
            // while with a single statement
            Assert.IsTrue(Statements_TestClass_while_001.testMethod());
        }

        [TestMethod]
        public void Statements_while_002_Test()
        {
            // while_002.sc
            // while with a compound statement
            Assert.IsTrue(Statements_TestClass_while_002.testMethod());
        }

        [TestMethod]
        public void Statements_while_003_Test()
        {
            // while_003.sc
            // verify known false condition doesn't execute with single statement
            Assert.IsTrue(Statements_TestClass_while_003.testMethod());
        }

        [TestMethod]
        public void Statements_while_004_Test()
        {
            // while_004.sc
            // verify known true condition executes with single statement
            Assert.IsTrue(Statements_TestClass_while_004.testMethod());
        }

        [TestMethod]
        public void Statements_while_005_Test()
        {
            // while_005.sc
            // verify known false condition doesn't execute with compound statements
            Assert.IsTrue(Statements_TestClass_while_005.testMethod());
        }

        [TestMethod]
        public void Statements_while_006_Test()
        {
            // while_006.sc
            // verify known true condition executes with compound statements
            Assert.IsTrue(Statements_TestClass_while_006.testMethod());
        }

        [TestMethod]
        public void Statements_break_001_Test()
        {
            // break_001.sc
            // Make sure break works in all basic single statement loops
            Assert.IsTrue(Statements_TestClass_break_001.testMethod());
        }

        [TestMethod]
        public void Statements_break_002_Test()
        {
            // break_002.sc
            // Make sure break works in all basic compound statement loops
            Assert.IsTrue(Statements_TestClass_break_002.testMethod());
        }

        [TestMethod]
        public void Statements_break_003_Test()
        {
            // break_003.sc
            // Make sure break optional on end of switch
            Assert.IsTrue(Statements_TestClass_break_003.testMethod());
        }

        [TestMethod]
        public void Statements_break_006_Test()
        {
            // break_006.sc
            // break in an if successfully breaks loop
            Assert.IsTrue(Statements_TestClass_break_006.testMethod());
        }

        [TestMethod]
        public void Statements_break_007_Test()
        {
            // break_007.sc
            // break in a blocked if successfully breaks loop
            Assert.IsTrue(Statements_TestClass_break_007.testMethod());
        }

        [TestMethod]
        public void Statements_break_010_Test()
        {
            // break_010.sc
            // Make sure break correctly when nested
            Assert.IsTrue(Statements_TestClass_break_010.testMethod());
        }

        [TestMethod]
        public void Statements_continue_001_Test()
        {
            // continue_001.sc
            // Make sure continue works in all basic single statement loops
            Assert.IsTrue(Statements_TestClass_continue_001.testMethod());
        }

        [TestMethod]
        public void Statements_continue_002_Test()
        {
            // continue_002.sc
            // Make sure continue works in all basic compound statement loops
            // Expected Output
            Assert.IsTrue(Statements_TestClass_continue_002.testMethod());
        }

        [TestMethod]
        public void Statements_continue_006_Test()
        {
            // continue_006.sc
            // continue in an if successfully continues loop
            Assert.IsTrue(Statements_TestClass_continue_006.testMethod());
        }

        [TestMethod]
        public void Statements_continue_007_Test()
        {
            // continue_007.sc
            // continue in a block if successfully continues loop
            Assert.IsTrue(Statements_TestClass_continue_007.testMethod());
        }

        [TestMethod]
        public void Statements_continue_010_Test()
        {
            // continue_010.sc
            // Make sure continue works correctly when nested
            Assert.IsTrue(Statements_TestClass_continue_010.testMethod());
        }

        [TestMethod]
        public void Statements_goto_001_Test()
        {
            // goto_001.sc
            // simple goto to adjust flow control
            Assert.IsTrue(Statements_TestClass_goto_001.testMethod());
        }

        [TestMethod]
        public void Statements_goto_008_Test()
        {
            // goto_008.sc
            // goto currect case
            Assert.IsTrue(Statements_TestClass_goto_008.testMethod());
        }

        [TestMethod]
        public void Statements_goto_009_Test()
        {
            // goto_009.sc
            // goto a different case
            // Expected Output
            Assert.IsTrue(Statements_TestClass_goto_009.testMethod());
        }

        [TestMethod]
        public void Statements_goto_010_Test()
        {
            // goto_010.sc
            // goto default correctly
            Assert.IsTrue(Statements_TestClass_goto_010.testMethod());
        }

        [TestMethod]
        public void Statements_goto_014_Test()
        {
            // goto_014.sc
            // simple gotos to test jumping to parent process.
            Assert.IsTrue(Statements_TestClass_goto_014.testMethod());
        }

        [TestMethod]
        public void Statements_goto_017_Test()
        {
            //    some gotos
            Assert.IsTrue(Statements_TestClass_goto_017.testMethod());
        }

        [TestMethod]
        public void Statements_goto_018_Test()
        {
            //    try/catch/finally with goto
            Assert.IsTrue(Statements_TestClass_goto_018.testMethod());
        }

        [TestMethod]
        public void Statements_return_001_Test()
        {
            // return_001.sc
            // simple void return on a void method
            Assert.IsTrue(Statements_TestClass_return_001.testMethod());
        }

        [TestMethod]
        public void Statements_return_004_Test()
        {
            // return_004.sc
            // simple return a normal type, assigning, and ignoring return value
            Assert.IsTrue(Statements_TestClass_return_004.testMethod());
        }

        [TestMethod]
        public void Statements_return_006_Test()
        {
            // return_006.sc
            // simple return a type mismatch that has an implicit conversion
            Assert.IsTrue(Statements_TestClass_return_006.testMethod());
        }

        [TestMethod]
        public void Statements_return_008_Test()
        {
            // return_008.sc
            // simple return a type mismatch that has an explicit convertion conversion,
            // applying the cast
            Assert.IsTrue(Statements_TestClass_return_008.testMethod());
        }

        [TestMethod]
        public void Statements_return_009_Test()
        {
            // return_009.sc
            // return of a struct
            Assert.IsTrue(Statements_TestClass_return_009.testMethod());
        }

        [TestMethod]
        public void Statements_return_010_Test()
        {
            // return_010.sc
            // return of a class
            Assert.IsTrue(Statements_TestClass_return_010.testMethod());
        }

        [TestMethod]
        public void Statements_return_013_Test()
        {
            // return_013.sc
            // simple falloff on a void method
            Assert.IsTrue(Statements_TestClass_return_013.testMethod());
        }

        [TestMethod]
        public void Statements_return_014_Test()
        {
            // return_014.sc
            // verify that a 'throw' is adequate for flow control analysis of return type
            Assert.IsTrue(Statements_TestClass_return_014.testMethod());
        }

        [TestMethod]
        public void Statements_throw_001_Test()
        {
            // throw_001.sc
            // simple throw
            Assert.IsTrue(Statements_TestClass_throw_001.testMethod());
        }

        [TestMethod]
        public void Statements_throw_005_Test()
        {
            // throw_005.sc
            // simple throw with output
            Assert.IsTrue(Statements_TestClass_throw_005.testMethod());
        }

        [TestMethod]
        public void Statements_trycatch_001_Test()
        {
            // trycatch_001.sc
            // simple throw
            Assert.IsTrue(Statements_TestClass_trycatch_001.testMethod());
        }

        [TestMethod]
        public void Statements_trycatch_006_Test()
        {
            // trycatch_006.sc
            // simple system generated System.Exception
            Assert.IsTrue(Statements_TestClass_trycatch_006.testMethod());
        }

        [TestMethod]
        public void Statements_trycatch_007_Test()
        {
            // trycatch_007.sc
            // simple re-throw
            Assert.IsTrue(Statements_TestClass_trycatch_007.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_001_Test()
        {
            // tryfinally_001.sc
            // simple finally
            Assert.IsTrue(Statements_TestClass_tryfinally_001.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_002_Test()
        {
            // tryfinally_002.sc
            // simple finally inside try/catch
            Assert.IsTrue(Statements_TestClass_tryfinally_002.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_003_Test()
        {
            // tryfinally_003.sc
            // simple finally outside try/catch
            Assert.IsTrue(Statements_TestClass_tryfinally_003.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_004_Test()
        {
            // tryfinally_004.sc
            // simple finally passed 'over' by a goto
            Assert.IsTrue(Statements_TestClass_tryfinally_004.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_006_Test()
        {
            // tryfinally_006.sc
            // simple finally exited by throw
            Assert.IsTrue(Statements_TestClass_tryfinally_006.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_007_Test()
        {
            // tryfinally_007.sc
            // simple finally exited by throw in a called method
            Assert.IsTrue(Statements_TestClass_tryfinally_007.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_008_Test()
        {
            // tryfinally_008.sc
            // simple finally exited by return
            Assert.IsTrue(Statements_TestClass_tryfinally_008.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_009_Test()
        {
            // tryfinally_009.sc
            // simple finally exited by continue
            Assert.IsTrue(Statements_TestClass_tryfinally_009.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_010_Test()
        {
            // tryfinally_010.sc
            // simple finally exited by break
            Assert.IsTrue(Statements_TestClass_tryfinally_010.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_011_Test()
        {
            // tryfinally_011.sc
            // simple finally exited by break (where break is outside try)
            Assert.IsTrue(Statements_TestClass_tryfinally_011.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_012_Test()
        {
            // tryfinally_012.sc
            // simple finally exited by system System.Exception
            Assert.IsTrue(Statements_TestClass_tryfinally_012.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_013_Test()
        {
            Assert.IsTrue(Statements_TestClass_tryfinally_013.testMethod());
        }

        [TestMethod]
        public void Statements_Using_001_Test()
        {
            // using_001.cs
            // Statements_TestClass_? the using statement.
            // Cast a class to IDisposable explicitly, use that in the using statement. (1.a)
            Assert.IsTrue(Statements_TestClass_Using_001.testMethod());
        }

        [TestMethod]
        public void Statements_Using_002_Test()
        {
            // using_002.cs
            // Statements_TestClass_? the using statement.
            // Use a class directly in using (1.b)
            Assert.IsTrue(Statements_TestClass_Using_002.testMethod());
        }

        [TestMethod]
        public void Statements_Using_003_Test()
        {
            // using_003.cs
            // Statements_TestClass_? the using statement.
            // Creation of class as part of using statement (1.c)
            Assert.IsTrue(Statements_TestClass_Using_003.testMethod());
        }

        [TestMethod]
        public void Statements_Using_005_Test()
        {
            // using_005.cs
            // Statements_TestClass_? the using statement.
            // A class that explicitly implements IDisposable. (1.e)
            Assert.IsTrue(Statements_TestClass_Using_005.testMethod());
        }

        [TestMethod]
        public void Statements_Using_009_Test()
        {
            // using_009.cs
            // Statements_TestClass_? the using statement.
            // Statements_TestClass_? the behavior if the used variable is nulled-out in the using block (4)
            Assert.IsTrue(Statements_TestClass_Using_009.testMethod());
        }

        [TestMethod]
        public void Statements_Using_010_Test()
        {
            // using_010.cs
            // Statements_TestClass_? the using statement.
            // Dispose() called during normal exit (5.a)
            Assert.IsTrue(Statements_TestClass_Using_010.testMethod());
        }

        [TestMethod]
        public void Statements_Using_011_Test()
        {
            // using_011.cs
            // Statements_TestClass_? the using statement.
            // Dispose() called after throw (5.b)
            // Expected Output
            Assert.IsTrue(Statements_TestClass_Using_011.testMethod());
        }

        [TestMethod]
        public void Statements_Using_012_Test()
        {
            // using_012.cs
            // Statements_TestClass_? the using statement.
            // Dispose() called for two objects during normal exit. (5.c)
            Assert.IsTrue(Statements_TestClass_Using_012.testMethod());
        }

        [TestMethod]
        public void Statements_Using_013_Test()
        {
            // using_013.cs
            // Statements_TestClass_? the using statement.
            // Dispose() called for first objects with System.Exception thrown before second block. (5.d)
            Assert.IsTrue(Statements_TestClass_Using_013.testMethod());
        }

        [TestMethod]
        public void Statements_Using_014_Test()
        {
            // using_014.cs
            // Statements_TestClass_? the using statement.
            // Dispose() called for first objects with System.Exception thrown after second block. (5.e)
            Assert.IsTrue(Statements_TestClass_Using_014.testMethod());
        }

        [TestMethod]
        public void Statements_Using_015_Test()
        {
            // using_015.cs
            // Statements_TestClass_? the using statement.
            // Dispose() called for both objects when System.Exception thrown inside second block. (5.f)
            Assert.IsTrue(Statements_TestClass_Using_015.testMethod());
        }

        [TestMethod]
        public void Statements_Using_017_Test()
        {
            // using_017.cs
            // Statements_TestClass_? the using statement.
            // Dispose() called for both objects when System.Exception thrown in compound case (5.h)
            Assert.IsTrue(Statements_TestClass_Using_017.testMethod());
        }

        [TestMethod]
        public void Statements_Using_018_Test()
        {
            // using_018.cs
            // Statements_TestClass_? the using statement.
            // Dispose() called for both objects in compound using. (5.g)
            Assert.IsTrue(Statements_TestClass_Using_018.testMethod());
        }

        [TestMethod]
        public void Statements_lock001_Test()
        {
            // The expression of a lock statement must denote a value of a reference-type
            Assert.IsTrue(Statements_TestClass_lock001.testMethod());
        }

        [TestMethod]
        public void Statements_lock003_Test()
        {
            // The System.Type object of a class can conveniently be used as the mutual-exclusion lock for static methods of the class
            Assert.IsTrue(Statements_TestClass_lock003.testMethod());
        }

        [TestMethod]
        public void Statements_lock004_Test()
        {
            // possible mistaken null statement when semi-column appears directly after lock()
            Assert.IsTrue(Statements_TestClass_lock004.testMethod());
        }

        [TestMethod]
        public void Statements_lock005_Test()
        {
            // this as the lock expression in a reference type
            Assert.IsTrue(Statements_TestClass_lock005.testMethod());
        }

        [TestMethod]
        public void Statements_lock007_Test()
        {
            // nested lock statements
            Assert.IsTrue(Statements_TestClass_lock007.testMethod());
        }

        [TestMethod]
        public void Statements_enum_002_Test()
        {
            //    enum: comparing constant casted to an enum type to a variable
            Assert.IsTrue(Statements_TestClass_enum_002.testMethod());
        }

        public class Res1 : IDisposable
        {
            public void Dispose()
            {
                // Res1.Dispose()
            }
            public void Func()
            {
                // Res1.Func()
            }
            public void Throw()
            {
                throw (new Exception("Res1"));
            }
        }

        public class Res2 : IDisposable
        {
            public void Dispose()
            {
                // Res2.Dispose()
            }
            public void Func()
            {
                // Res2.Func()
            }
            public void Throw()
            {
                throw (new Exception("Res2"));
            }
        }

        // IDispose implemented explicitly
        public class ResExplicit : IDisposable
        {
            void IDisposable.Dispose()
            {
                // ResExplicit.Dispose()
            }
            public void Func()
            {
                // ResExplicit.Func()
            }
            public void Throw()
            {
                throw (new Exception("ResExplicit"));
            }
        }

        // A class that doesn't implement IDisposable.
        public class NonRes1
        {
            public void GarbageDisposal()
            {
                // NonRes1.GarbageDisposal()
            }
            public void Func()
            {
                // NonRes1.Func()
            }
            public void Throw()
            {
                throw (new Exception("NonRes1"));
            }
        }

        // Doesn't implement IDisposable, but has a Dispose() function...
        public class NonRes2
        {
            public void Dispose()
            {
                // NonRes2.Dispose()
            }
            public void Func()
            {
                // NonRes2.Func()
            }
            public void Throw()
            {
                throw (new Exception("NonRes2"));
            }
        }

        //Compiled Test Cases 
        public class Statements_TestClass_Label_001
        {
            public static int Main_old(string[] args)
            {
            Label:
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Label_002
        {
            public static int Main_old(string[] args)
            {
                goto Label;
                return (1);
            Label:
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Label_004
        {
            public static int Main_old(string[] args)
            {
                Method();
                return (0);
            }
            public static void Method()
            {
                goto Label;
            Label:;
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Decl_001
        {
            public static int Main_old(string[] args)
            {
                int i;
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Decl_002
        {
            public static int Main_old(string[] args)
            {
                int i = 99;
                if (i != 99)
                    return (1);
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Decl_003
        {
            public static int Main_old(string[] args)
            {
                int i = 99;
                int j = i + 1;
                if (i != 99)
                    return (1);
                if (j != 100)
                    return (1);
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Decl_004
        {
            public static int Main_old(string[] args)
            {
                Exception r;
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Decl_007
        {
            public static int Main_old(string[] args)
            {
                int i, j, k;
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Decl_009
        {
            public static int Main_old(string[] args)
            {
                int i = 1, j = i + 1, k = i + j + 3;
                if ((i != 1) || (j != 2) || (k != 6))
                    return (1);
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Decl_010
        {
            public static int Main_old(string[] args)
            {
                int[] i;
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Decl_012
        {
            public static int Main_old(string[] args)
            {
                int[] i = new int[30];
                int j = i[23];
                if (j != 0)
                {
                    return (1);
                }
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Decl_014
        {
            public static int Main_old(string[] args)
            {
                int[] i = new int[] { 0, 1, 2, 3, 4 };
                int j = i[2];
                if (j != 2)
                {
                    return (1);
                }
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Foo
        {
            public Foo(int i)
            {
                m_i = i;
            }

            public int GetInt() { return (m_i); }
            int m_i;
        }
        public class Statements_TestClass_Decl_016
        {
            public static int Main_old(string[] args)
            {
                Foo[] f = new Foo[30]; // 30 null'd foos
                Foo foo = f[23];
                for (int i = 0; i < f.Length; i++)
                {
                    foo = f[i];
                    if (foo != null)
                        return (1);
                    f[i] = foo = new Foo(i);
                    if (foo.GetInt() != i)
                    {
                        // new Foo() didn't take
                        return (1);
                    }
                    if (f[i].GetInt() != i)
                    {
                        // Array didn't get updated
                        return (1);
                    }
                    if (f[i] != foo)
                    {
                        // Array element and foo are different
                        return (i);
                    }
                }
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Block_001
        {
            public static int Main_old(string[] args)
            {
                int status = 0;
                // arbitrary nesting
                {
                    int i;
                    i = 0;
                    i++;
                }
                // empty nesting
                {
                    {
                        {
                            {
                                {
                                    {
                                        {
                                            {
                                                {
                                                    {
                                                        {
                                                            {
                                                                {
                                                                    {
                                                                        {
                                                                            {
                                                                                {
                                                                                    {
                                                                                        {
                                                                                            {
                                                                                                {
                                                                                                    {
                                                                                                        {
                                                                                                            {
                                                                                                                {
                                                                                                                    {
                                                                                                                        {
                                                                                                                            {
                                                                                                                                {
                                                                                                                                    {
                                                                                                                                        {
                                                                                                                                            {
                                                                                                                                                {
                                                                                                                                                    {
                                                                                                                                                        {
                                                                                                                                                            {
                                                                                                                                                                {
                                                                                                                                                                    {
                                                                                                                                                                        {
                                                                                                                                                                            {
                                                                                                                                                                                {
                                                                                                                                                                                    {
                                                                                                                                                                                        {
                                                                                                                                                                                            {
                                                                                                                                                                                                {
                                                                                                                                                                                                    {
                                                                                                                                                                                                        {
                                                                                                                                                                                                            {
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                        int i;
                                                                                                                                                                                                                                                                                                        i = 0;
                                                                                                                                                                                                                                                                                                        i++;
                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                }
                                                                                                                                                                                                                            }
                                                                                                                                                                                                                        }
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                }
                                                                                                                                                                                                            }
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                }
                                                                                                                                                                                            }
                                                                                                                                                                                        }
                                                                                                                                                                                    }
                                                                                                                                                                                }
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                    }
                                                                                                                                                                }
                                                                                                                                                            }
                                                                                                                                                        }
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // empty hanging clause
                if (true)
                {
                }
                else
                {
                    status = 1;
                }
                while (false)
                {
                }
                do
                {
                } while (false);

                switch (status)
                {
                }
                for (; false;)
                {
                }
            Label: { }
                return (status);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Empty_001
        {
            public static int Main_old(string[] args)
            {
                int status = 0;
                // empty series
                ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ;
                int i;
                i = 0;
                i++;
                ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ;
                // empty hanging clause
                if (true)
                    ;
                else
                {
                    status = 1;
                }
                while (false)
                    ;
                do; while (false);

                switch (status)
                {
                    default: break;
                }
                for (; false;)
                    ;
                Label:;
                return (status);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Expr_002
        {
            public static int Main_old(string[] args)
            {
                bool b = false;
                b = true || false || b;
                if (!b)
                    return (1);
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Expr_003
        {
            public static int Main_old(string[] args)
            {
                bool b = false;
                bool b1;
                bool b2;
                b = b1 = b2 = true || false || b;
                if (!b || !b1 || !b2)
                    return (1);
                return (false ? 1 : 0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Expr_004
        {
            public static int Main_old(string[] args)
            {
                int i = 0;
                // Adding 5
                i += 5;  // i == 5
                if (i != 5) return (1);
                // Subtracting 3
                i -= 3;  // i == 2
                if (i != 2) return (1);
                // Multiplying by 4
                i *= 4;  // i == 8
                if (i != 8) return (1);
                // Dividing by 2
                i /= 2;  // i == 4
                if (i != 4) return (1);
                // Left Shifting 3
                i <<= 3; // i == 32
                if (i != 32) return (1);
                // Right Shifting 2
                i >>= 2; // i == 8
                if (i != 8) return (1);
                // ANDing against logical not
                i &= ~i; // i = 0
                if (i != 0) return (1);
                // ORing by 0xBeaf
                i |= 48815; // i = 0xBeaf
                if (i != 0xBeaf) return (1);
                return (true ? 0 : 1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_Expr_006
        {
            public static int Main_old(string[] args)
            {
                int b, c, d, e;
                e = 1;
                int a = b = c = d = e++ + 1;
                b = a = d + e * 2;
                if ((a == 6) && (a == b) && (c == 2) && (c == d) && (d == e))
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_if_001
        {
            public static int Main_old(string[] args)
            {
                if (true)
                    return (0);
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_if_003
        {
            public static int Main_old(string[] args)
            {
                if (true)
                {
                    int i = 0;
                    return (i);
                }
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_if_005
        {
            public static int Main_old(string[] args)
            {
                int ret = 0;
                if (true)
                    ret = ret;
                else
                    ret = 1;
                if (false)
                    ret = 1;
                else
                    ret = ret;
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_if_007
        {
            public static int Main_old(string[] args)
            {
                int ret = 0;
                if (true)
                {
                    int i = ret;
                    ret = i;
                }
                else
                {
                    int i = 1;
                    ret = i;
                }
                if (false)
                {
                    int i = 1;
                    ret = i;
                }
                else
                {
                    int i = ret;
                    ret = i;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_if_009
        {
            public static int Main_old(string[] args)
            {
                int ret = 1; // default to fail
                if (true)
                    if (false)
                        return (1);
                    else // if this else if associated with the 1st if, it won't execute.
                        ret = 0;
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_001
        {
            public static int Main_old(string[] args)
            {
                switch (true)
                {
                }
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_002
        {
            public static int Main_old(string[] args)
            {
                int ret = 1;
                switch (true)
                {
                    default:
                        ret = 0;
                        break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_003
        {
            public static int Main_old(string[] args)
            {
                int ret = 1;
                switch (true)
                {
                    case true:
                        ret = 0;
                        break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_004
        {
            public static int Main_old(string[] args)
            {
                int ret = 1;
                switch (true)
                {
                    case true:
                        ret = 0;
                        break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_005
        {
            public static int Main_old(string[] args)
            {
                int ret = 1;
                switch (true)
                {
                    case true:
                        ret = 0;
                        break;
                    case false:
                        ret = 1;
                        break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_006
        {
            public static int Main_old(string[] args)
            {
                int ret = 1;
                switch (false)
                {
                    default:
                        ret = 0;
                        break;
                    case true:
                        ret = 1;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_007
        {
            public static int Main_old(string[] args)
            {
                int ret = 1;
                switch (23)
                {
                    default:
                        ret = 0;
                        break;
                    case 1:
                        ret = 1;
                        break;
                    case -2:
                        ret = 1;
                        break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_010
        {
            public static int Main_old(string[] args)
            {
                int ret = 1;
                int value = 23;
                switch (value)
                {
                    case kValue:
                        ret = 0;
                        break;
                    default:
                        ret = 1;
                        break;
                }
                return (ret);
            }
            const int kValue = 23;
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_012
        {
            public static int Main_old(string[] args)
            {
                int ret = 3;
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 1:
                        case 0:
                        case 2:
                            ret--;
                            break;
                        default:
                            return (1);
                    }
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_013
        {
            public static int Main_old(string[] args)
            {
                int ret = 6;
                switch (ret)
                {
                    case 0:
                        ret--; // 2
                        // case 0: 
                        OutputHelper.WriteLine(ret.ToString());
                        goto case 9999;
                    case 2:
                        ret--; // 4
                        // case 2: 
                        OutputHelper.WriteLine(ret.ToString());
                        goto case 255;
                    case 6:			// start here
                        ret--; // 5
                        // case 5: 
                        OutputHelper.WriteLine(ret.ToString());
                        goto case 2;
                    case 9999:
                        ret--; // 1
                        // case 9999: 
                        OutputHelper.WriteLine(ret.ToString());
                        goto default;
                    case 0xff:
                        ret--; // 3
                        // case 0xff: 
                        OutputHelper.WriteLine(ret.ToString());
                        goto case 0;
                    default:
                        ret--;
                        // Default: 
                        OutputHelper.WriteLine(ret.ToString());
                        if (ret > 0)
                        {
                            goto case -1;
                        }
                        break;
                    case -1:
                        ret = 999;
                        // case -1: 
                        OutputHelper.WriteLine(ret.ToString());
                        break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_015
        {
            public static int Main_old(string[] args)
            {
                int ret = 0;
                ret = DoByte();
                return (ret);
            }
            private static int DoByte()
            {
                int ret = 2;
                byte b = 2;
                switch (b)
                {
                    case 1:
                    case 2:
                        ret--;
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
                switch (b)
                {
                    case 1:
                    case 3:
                        break;
                    default:
                        ret--;
                        break;
                }
                return (ret);
            }


            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_016
        {
            public static int Main_old(string[] args)
            {
                int ret = 0;
                ret = DoChar();
                return (ret);
            }
            private static int DoChar()
            {
                int ret = 2;
                char c = '2';
                switch (c)
                {
                    case '1':
                    case '2':
                        ret--;
                        break;
                    case '3':
                        break;
                    default:
                        break;
                }
                switch (c)
                {
                    case '1':
                    case '3':
                        break;
                    default:
                        ret--;
                        break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_017
        {
            public static int Main_old(string[] args)
            {
                int ret = 0;
                ret = DoShort();
                return (ret);
            }
            private static int DoShort()
            {
                int ret = 2;
                short s = 0x7fff;
                switch (s)
                {
                    case 1:
                    case 32767:
                        ret--;
                        break;
                    case -1:
                        break;
                    default:
                        break;
                }
                switch (s)
                {
                    case 1:
                    case -1:
                        break;
                    default:
                        ret--;
                        break;
                }
                return (ret);
            }


            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_018
        {
            public static int Main_old(string[] args)
            {
                int ret = 0;
                ret = DoInt();
                return (ret);
            }
            private static int DoInt()
            {
                int ret = 2;
                int i = 0x7fffffff;
                switch (i)
                {
                    case 1:
                    case 2147483647:
                        ret--;
                        break;
                    case -1:
                        break;
                    default:
                        break;
                }
                switch (i)
                {
                    case 1:
                    case -1:
                        break;
                    default:
                        ret--;
                        break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_019
        {
            public static int Main_old(string[] args)
            {
                int ret = 0;
                ret = DoLong();
                return (ret);
            }
            private static int DoLong()
            {
                int ret = 2;
                long l = 0x7fffffffffffffffL;
                switch (l)
                {
                    case 1L:
                    case 9223372036854775807L:
                        ret--;
                        break;
                    case -1L:
                        break;
                    default:
                        break;
                }
                switch (l)
                {
                    case 1L:
                    case -1L:
                        break;
                    default:
                        ret--;
                        break;
                }
                return (ret);
            }

            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_023
        {
            enum eTypes
            {
                kFirst,
                kSecond,
                kThird,
            };
            public static int Main_old(string[] args)
            {
                int ret = 0;
                ret = DoEnum();
                return (ret);
            }

            private static int DoEnum()
            {
                int ret = 2;
                eTypes e = eTypes.kSecond;
                switch (e)
                {
                    case eTypes.kThird:
                    case eTypes.kSecond:
                        ret--;
                        break;
                    case (eTypes)(-1):
                        break;
                    default:
                        break;
                }
                switch (e)
                {
                    case (eTypes)100:
                    case (eTypes)(-1):
                        break;
                    default:
                        ret--;
                        break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_030
        {
            public static int Main_old(string[] args)
            {
                int i = 5;
                switch (i)
                {
                    case (int)5.0f:
                        return 0;
                    default:
                        return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_031
        {
            public static int Main_old(string[] args)
            {
                int i = 5;
                switch (i)
                {
                    case 1:
                    case 2:
                    case 3:
                        return 1;
                    case 1001:
                    case 1002:
                    case 1003:
                        return 2;
                }
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_032
        {
            public static int Main_old(string[] args)
            {
                string s = "hello";
                switch (s)
                {
                    default:
                        return 1;
                    case null:
                        return 1;
                    case "hello":
                        return 0;
                }
                return 1;
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_033
        {
            public static int Main_old(string[] args)
            {
                string s = "hello";
                switch (s)
                {
                    case null:
                        return 1;
                    default:
                        return 1;
                    case "hello":
                        return 0;
                }
                return 1;
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_switch_034
        {
            public static implicit operator int(Statements_TestClass_switch_034 val)
            {
                return 1;
            }
            public static implicit operator float(Statements_TestClass_switch_034 val)
            {
                return 2.1f;
            }
            public static int Main_old(string[] args)
            {
                Statements_TestClass_switch_034 t = new Statements_TestClass_switch_034();
                switch (t)
                {
                    case 1:
                        // a
                        return 0;
                    default:
                        return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        class Statements_TestClass_switch_035
        {
            public sbyte x;

            public Statements_TestClass_switch_035(sbyte i)
            {
                x = i;
            }
            public static implicit operator sbyte(Statements_TestClass_switch_035 C)
            {
                return C.x;
            }

            public static int Main_old()
            {
                Statements_TestClass_switch_035 C = new Statements_TestClass_switch_035(12);
                switch (C)
                {
                    case 12: return 0;
                    default: return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_switch_036
        {
            public byte x;

            public Statements_TestClass_switch_036(byte i)
            {
                x = i;
            }
            public static implicit operator byte(Statements_TestClass_switch_036 C)
            {
                return C.x;
            }

            public static int Main_old()
            {
                Statements_TestClass_switch_036 C = new Statements_TestClass_switch_036(12);
                switch (C)
                {
                    case 12: return 0;
                    default: return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_switch_037
        {
            public short x;

            public Statements_TestClass_switch_037(short i)
            {
                x = i;
            }
            public static implicit operator short(Statements_TestClass_switch_037 C)
            {
                return C.x;
            }

            public static int Main_old()
            {
                Statements_TestClass_switch_037 C = new Statements_TestClass_switch_037(12);
                switch (C)
                {
                    case 12: return 0;
                    default: return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_switch_038
        {
            public ushort x;

            public Statements_TestClass_switch_038(ushort i)
            {
                x = i;
            }
            public static implicit operator ushort(Statements_TestClass_switch_038 C)
            {
                return C.x;
            }

            public static int Main_old()
            {
                Statements_TestClass_switch_038 C = new Statements_TestClass_switch_038(12);
                switch (C)
                {
                    case 12: return 0;
                    default: return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_switch_039
        {
            public int x;

            public Statements_TestClass_switch_039(int i)
            {
                x = i;
            }
            public static implicit operator int(Statements_TestClass_switch_039 C)
            {
                return C.x;
            }

            public static int Main_old()
            {
                Statements_TestClass_switch_039 C = new Statements_TestClass_switch_039(12);
                switch (C)
                {
                    case 12: return 0;
                    default: return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_switch_040
        {
            public uint x;

            public Statements_TestClass_switch_040(uint i)
            {
                x = i;
            }
            public static implicit operator uint(Statements_TestClass_switch_040 C)
            {
                return C.x;
            }

            public static int Main_old()
            {
                Statements_TestClass_switch_040 C = new Statements_TestClass_switch_040(12);
                switch (C)
                {
                    case 12: return 0;
                    default: return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_switch_041
        {
            public long x;

            public Statements_TestClass_switch_041(long i)
            {
                x = i;
            }
            public static implicit operator long(Statements_TestClass_switch_041 C)
            {
                return C.x;
            }

            public static int Main_old()
            {
                Statements_TestClass_switch_041 C = new Statements_TestClass_switch_041(12);
                switch (C)
                {
                    case 12: return 0;
                    default: return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_switch_042
        {
            public ulong x;

            public Statements_TestClass_switch_042(ulong i)
            {
                x = i;
            }
            public static implicit operator ulong(Statements_TestClass_switch_042 C)
            {
                return C.x;
            }

            public static int Main_old()
            {
                Statements_TestClass_switch_042 C = new Statements_TestClass_switch_042(12);
                switch (C)
                {
                    case 12: return 0;
                    default: return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_switch_044
        {
            public static implicit operator string(Statements_TestClass_switch_044 C)
            {
                return "true";
            }

            public static int Main_old()
            {
                Statements_TestClass_switch_044 C = new Statements_TestClass_switch_044();
                switch (C)
                {
                    case "true": return 0;
                    default: return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class X { }
        class Statements_TestClass_switch_047
        {

            public static implicit operator int(Statements_TestClass_switch_047 C)
            {
                return 1;
            }

            public static implicit operator X(Statements_TestClass_switch_047 C)
            {
                return new X();
            }

            public static int Main_old()
            {
                Statements_TestClass_switch_047 C = new Statements_TestClass_switch_047();
                switch (C)
                {
                    case 1: return 0;
                    default: return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_switch_049
        {
            public static int Main_old()
            {
                int i = 6;
                switch (i) { }   // CS1522
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Statements_TestClass_switch_string_001
        {
            public static int Main_old(string[] args)
            {
                string s = null;
                switch (s)
                {
                    case null:
                        // null
                        return 0;
                    default:
                        return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_dowhile_001
        {
            public static int Main_old(string[] args)
            {
                int i = 0;
                int j = 10;
                // post decrement test as well
                do
                    i++;
                while (--j > 0);
                if (i == 10)
                    return (0);
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_dowhile_002
        {
            public static int Main_old(string[] args)
            {
                int i = 0;
                int j = 10;
                // post decrement test as well
                do
                {
                    j--;
                    i++;
                } while (j > 0);
                if (i == 10)
                    return (0);
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_dowhile_003
        {
            public static int Main_old(string[] args)
            {
                bool bFalse = false;
                int ret = 1;
                do
                    ret--;
                while (bFalse);
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_dowhile_004
        {
            public static int Main_old(string[] args)
            {
                bool bTrue = true;
                do
                    return (0);
                while (bTrue);
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_dowhile_005
        {
            public static int Main_old(string[] args)
            {
                bool bFalse = false;
                int ret = 1;
                do
                {
                    OutputHelper.WriteLine("Hello World");
                    ret--;
                } while (bFalse);
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_dowhile_006
        {
            public static int Main_old(string[] args)
            {
                bool bTrue = true;
                do
                {
                    OutputHelper.WriteLine("Hello World");
                    return (0);
                } while (bTrue);
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_for_001
        {
            public static int Main_old(string[] args)
            {
                for (; ; )
                    return (0);
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_for_003
        {
            public static int Main_old(string[] args)
            {
                int i = 0;
                int ret = 10;
                for (; i < 10; i++)
                    ret--;
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_for_004
        {
            public static int Main_old(string[] args)
            {
                for (int i = 0; i < 10;)
                    i++;
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_for_006
        {
            public static int Main_old(string[] args)
            {
                int ret = 10;
                for (int i = 0; i < 10; i++)
                    ret--;
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_for_007
        {
            public static int Main_old(string[] args)
            {
                int ret1 = 10;
                int ret2 = -10;
                for (int i = 0; i < 10; i++)
                {
                    ret1--;
                    ret2++;
                }
                return (ret1 | ret2); // bit or
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_for_008
        {
            public static int Main_old(string[] args)
            {
                int ret1 = 10;
                int ret2 = 0;
                for (int i = 0, j = -10; i < 10; i++)
                {
                    ret1--;
                    j++;
                    ret2 = j;
                }
                return (ret1 | ret2); // bit or
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_for_009
        {
            public static int Main_old(string[] args)
            {
                int ret = 10;
                int i, j, k;
                for (i = 0, j = i + 1, k = j + 1; i < 10; i++)
                {
                    ret--;
                    k++;
                    j++;
                }
                if (i + 1 != j)
                {
                    // Failure: i + 1 != j
                    return (1);
                }
                if (j + 1 != k)
                {
                    // Failure: j + 1 != k
                    return (1);
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_for_010
        {
            public static int Main_old(string[] args)
            {
                int ret = 10;
                int i, j = 1, k = 2;
                for (i = 0; i < 10; i++, j++, k++)
                {
                    ret--;
                }
                if (i + 1 != j)
                {
                    // Failure: i + 1 != j
                    return (1);
                }
                if (j + 1 != k)
                {
                    // Failure: j + 1 != k
                    return (1);
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_for_011
        {
            public static int Main_old(string[] args)
            {
                int ret = 10;
                int i, j, k = 2;
                for (i = 0, j = i + 1; i < 10; i++, k++)
                {
                    ret--;
                    j++;
                }
                if (i + 1 != j)
                {
                    // Failure: i + 1 != j
                    return (1);
                }
                if (j + 1 != k)
                {
                    // Failure: j + 1 != k
                    return (1);
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_for_013
        {
            public static int Main_old(string[] args)
            {
                int ret = 0;
                for (; false; ret++)
                    ;
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_for_014
        {
            public static int Main_old(string[] args)
            {
                int ret = 10;
                for (Initializer(); Conditional(); Iterator())
                    ret = Body(ret);
                return (ret);
            }
            public static int Initializer()
            {
                m_i = 0;
                return (0);
            }
            public static bool Conditional()
            {
                return (m_i < 10);
            }
            public static void Iterator()
            {
                m_i++;
            }
            public static int Body(int ret)
            {
                return (--ret);
            }
            private static int m_i;
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_char_in_string_s01
        {
            public static int Main_old()
            {
                String Str = new String('\0', 1024);
                int i = 0;
                foreach (char C in Str)
                {
                    i++;
                    if (C != '\0')
                        return 1;

                }

                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Statements_TestClass_char_in_string_ex01
        {
            public static int Main_old()
            {
                String Str = null;
                try
                {
                    foreach (char C in Str)
                    {
                        return 1;
                        // Fail
                    }
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


        public class Statements_TestClass_while_001
        {
            public static int Main_old(string[] args)
            {
                int i = 0;
                int j = 10;
                // post decrement test as well
                while (j-- > 0)
                    i++;
                if (i == 10)
                    return (0);
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_while_002
        {
            public static int Main_old(string[] args)
            {
                int i = 0;
                int j = 10;
                // post decrement test as well
                while (j > 0)
                {
                    j--;
                    i++;
                }
                if (i == 10)
                    return (0);
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_while_003
        {
            public static int Main_old(string[] args)
            {
                bool bFalse = false;
                while (bFalse)
                    return (1);
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_while_004
        {
            public static int Main_old(string[] args)
            {
                bool bTrue = true;
                while (bTrue)
                    return (0);
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_while_005
        {
            public static int Main_old(string[] args)
            {
                bool bFalse = false;
                while (bFalse)
                {
                    // Hello World
                    return (1);
                }
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_while_006
        {
            public static int Main_old(string[] args)
            {
                bool bTrue = true;
                while (bTrue)
                {
                    // Hello World
                    return (0);
                }
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_break_001
        {
            public static int Main_old(string[] args)
            {
                while (true)
                    break;
                do
                    break;
                while (true);
                for (; true;)
                    break;
                int[] iArr = new int[20];
                foreach (int i in iArr)
                    break;
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_break_002
        {
            public static int Main_old(string[] args)
            {
                int ret = 0;
                while (true)
                {
                    break;
                    ret++;
                }
                do
                {
                    break;
                    ret++;
                } while (true);
                for (; true;)
                {
                    break;
                    ret++;
                }
                int[] iArr = new int[20];
                foreach (int i in iArr)
                {
                    break;
                    ret++;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_break_003
        {
            public static int Main_old(string[] args)
            {
                int ret = 1;
                switch (ret)
                {
                    case 1:
                        ret = 0;
                        break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_break_006
        {
            public static int Main_old(string[] args)
            {
                int ret = 0;
                while (true)
                {
                    if (ret == 0)
                        break;
                    ret = 1;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_break_007
        {
            public static int Main_old(string[] args)
            {
                int ret = 0;
                while (true)
                {
                    if (ret == 0)
                    {
                        break;
                        ret = 1;
                    }
                    ret = 1;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_break_010
        {
            public static int Main_old(string[] args)
            {
                int ret = 3;
                while (true)
                {
                    do
                    {
                        for (ret--; true; ret--)
                        {
                            break;
                        }
                        ret--;
                        break;
                    } while (true);
                    ret--;
                    break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_continue_001
        {
            public static int Main_old(string[] args)
            {
                int i = 5;
                int ret = 0;
                // Doing while
                while (--i != 0)
                    continue;
                if (i != 0)
                    return (1);
                // Doing do/while
                i = 5;
                do
                    continue;
                while (--i != 0);
                if (i != 0)
                    return (1);
                // Doing for
                for (i = 5; i != 0; i--)
                    continue;
                int[] iArr = new int[20];
                foreach (int i2 in iArr)
                    continue;
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_continue_002
        {
            public static int Main_old(string[] args)
            {
                int i = 1;
                int ret = 6;
                OutputHelper.WriteLine(ret.ToString());
                while (i-- > 0)
                {
                    ret--;
                    continue;
                    ret--;
                }
                OutputHelper.WriteLine(ret.ToString());
                i = 1;
                do
                {
                    ret--;
                    continue;
                    ret--;
                } while (--i > 0);
                OutputHelper.WriteLine(ret.ToString());
                for (i = 1; i > 0; i--)
                {
                    ret--;
                    continue;
                    ret--;
                }
                int[] iArr = new int[3];
                i = 0;
                OutputHelper.WriteLine(ret.ToString());
                foreach (int i2 in iArr)
                {
                    ret--;
                    continue;
                    ret--;
                }
                OutputHelper.WriteLine(ret.ToString());
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_continue_006
        {
            public static int Main_old(string[] args)
            {
                int ret = 10;
                while (ret > 0)
                {
                    if (--ret >= 0)
                        continue;
                    return (1);
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_continue_007
        {
            public static int Main_old(string[] args)
            {
                int ret = 1;
                while (ret != 0)
                {
                    if (ret == 1)
                    {
                        ret = 0;
                        continue;
                        ret = 1;
                    }
                    ret = 1;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_continue_010
        {
            public static int Main_old(string[] args)
            {
                int ret = 125;
                int iWhile = 5, iDo = 5, iFor = 6;
                while (iWhile-- > 0)
                {
                    if (iDo != 5)
                        return (1);
                    do
                    {
                        if (iFor != 6)
                            return (1);
                        for (iFor--; iFor > 0; iFor--)
                        {
                            ret--;
                            continue;
                            return (1);
                        }
                        iFor = 6;
                        iDo--;
                        continue;
                        return (1);
                    } while (iDo > 0);
                    iDo = 5;
                    continue;
                    return (1);
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_goto_001
        {
            public static int Main_old(string[] args)
            {
                goto Label2; // jump ahead
                return (1);
            Label1:
                goto Label3; // end it
                return (1);
            Label2:
                goto Label1; // jump backwards
                return (1);
            Label3:
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_goto_008
        {
            public static int Main_old(string[] args)
            {
                int s = 23;
                int ret = 5;
                switch (s)
                {
                    case 21:
                        break;
                    case 23:
                        if (--ret > 0)
                            goto case 23;
                        break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_goto_009
        {
            public static int Main_old(string[] args)
            {
                int ret = 6;
                switch (32)
                {
                    case 1:
                        if (--ret > 0)
                        {
                            OutputHelper.WriteLine("Case 1:" + ret.ToString());
                            goto case 32;
                        }
                        break;
                    case 32:
                        if (--ret > 0)
                        {
                            OutputHelper.WriteLine("Case 32:" + ret.ToString());
                            goto case 1;
                        }
                        break;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_goto_010
        {
            public static int Main_old(string[] args)
            {
                int s = 23;
                int ret = 5;
                switch (s)
                {
                    case 21:
                        break;
                    default:
                        if (--ret > 0)
                            goto default;
                        break;
                    case 23:
                        goto default;
                }
                return (ret);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_goto_014
        {
            public static int Main_old(string[] args)
            {
                bool bLoopOnce = true;
                int i = 0;
            Top:
                for (i = 0; i < 10; i++)
                {
                    if (i > 5)
                        return (1);
                    if (i == 5)
                        goto LeaveFor;
                }
            LeaveFor:
                i = 0;
                do
                {
                    if (++i > 5)
                        return (1);
                    if (i == 5)
                    {
                        goto LeaveDo;
                    }
                } while (i < 10);
            LeaveDo:
                i = 0;
                while (i < 10)
                {
                    if (++i > 5)
                        return (1);
                    if (i == 5)
                        goto LeaveWhile;
                }
            LeaveWhile:
                if (bLoopOnce)
                {
                    bLoopOnce = !bLoopOnce;

                    while (true)
                    {
                        do
                        {
                            for (; ; )
                            {
                                goto Top;
                            }
                        } while (true);
                    }
                }
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_goto_017
        {
            public static int Main_old(string[] args)
            {
                string target = "label1";
            label1:
            label2:
                if (target == "label1")
                {
                    target = "label2";
                    goto label1;
                }
                else if (target == "label2")
                {
                    target = "exit";
                    goto label2;
                }
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_goto_018
        {
            public static int Main_old(string[] args)
            {
                string target = "label1";
            label1:
                try
                {
                    if (target == "label1")
                    {
                        target = "exit";
                        goto label1;
                    }
                }
                catch
                {
                }
                finally
                {
                }
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_return_001
        {
            public static int Main_old(string[] args)
            {
                Statements_TestClass_return_001.sMethod();
                Statements_TestClass_return_001 t = new Statements_TestClass_return_001();
                t.Method();
                return (0);
            }
            private static void sMethod()
            {
                return;
            }
            private void Method()
            {
                return;
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_return_004
        {
            public static int Main_old(string[] args)
            {
                int i;
                i = Statements_TestClass_return_004.sMethod();
                Statements_TestClass_return_004.sMethod();
                Statements_TestClass_return_004 t = new Statements_TestClass_return_004();
                i = t.Method();
                t.Method();
                return (i == 0 ? 0 : 1);
            }
            private static int sMethod()
            {
                return (1);
            }
            private int Method()
            {
                return (0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_return_006
        {
            public static int Main_old(string[] args)
            {
                int i;
                i = Statements_TestClass_return_006.sMethod();
                if (i != 0)
                    return (1);
                Statements_TestClass_return_006 t = new Statements_TestClass_return_006();
                i = t.Method();
                return (i == 0 ? 0 : 1);
            }
            private static int sMethod()
            {
                short s = 0;
                return (s);
            }
            private int Method()
            {
                short s = 0;
                return (s);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_return_008
        {
            public static int Main_old(string[] args)
            {
                short s;
                s = Statements_TestClass_return_008.sMethod();
                if (s != 0)
                    return (1);
                Statements_TestClass_return_008 t = new Statements_TestClass_return_008();
                s = t.Method();
                return (s == 0 ? 0 : 1);
            }
            private static short sMethod()
            {
                int i = 0;
                return ((short)i);
            }
            private short Method()
            {
                int i = 0;
                return ((short)i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        struct S
        {
            public int i;
            public string s;
        }
        public class Statements_TestClass_return_009
        {
            public static int Main_old(string[] args)
            {
                S s;
                s = Statements_TestClass_return_009.sMethod();
                if (s.i.ToString().CompareTo(s.s) != 0)
                {
                    return (1);
                }
                Statements_TestClass_return_009.sMethod();
                Statements_TestClass_return_009 t = new Statements_TestClass_return_009();
                s = t.Method();
                t.Method();
                if (s.i.ToString().CompareTo(s.s) != 0)
                {
                    return (1);
                }
                return (s.i == 0 ? 0 : 1);
            }
            private static S sMethod()
            {
                S s;
                s.i = 1;
                s.s = s.i.ToString();
                return (s);
            }
            private S Method()
            {
                S s;
                s.i = 0;
                s.s = s.i.ToString();
                return (s);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        class C
        {
            public int i;
            public string s;
        }
        public class Statements_TestClass_return_010
        {
            public static int Main_old(string[] args)
            {
                C c;
                c = Statements_TestClass_return_010.sMethod();
                if (c.i.ToString().CompareTo(c.s) != 0)
                {
                    return (1);
                }
                Statements_TestClass_return_010.sMethod();
                Statements_TestClass_return_010 t = new Statements_TestClass_return_010();
                c = t.Method();
                t.Method();
                if (c.i.ToString().CompareTo(c.s) != 0)
                {
                    return (1);
                }
                return (c.i == 0 ? 0 : 1);
            }
            private static C sMethod()
            {
                C c = new C();
                c.i = 1;
                c.s = c.i.ToString();
                return (c);
            }
            private C Method()
            {
                C c = new C();
                c.i = 0;
                c.s = c.i.ToString();
                return (c);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_return_013
        {
            public static int Main_old(string[] args)
            {
                Statements_TestClass_return_013.sMethod();
                Statements_TestClass_return_013 t = new Statements_TestClass_return_013();
                t.Method();
                return (0);
            }
            private static void sMethod()
            {
            }
            private void Method()
            {
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_return_014
        {
            public static int Main_old(string[] args)
            {
                int i;
                i = Statements_TestClass_return_014.sMethod(1);
                Statements_TestClass_return_014.sMethod(2);
                Statements_TestClass_return_014 t = new Statements_TestClass_return_014();
                i = t.Method(3);
                t.Method(4);
                return (i == 0 ? 0 : 1);
            }
            private static int sMethod(int i)
            {
                if (i > 0)
                    return (1);
                throw new Exception();
            }
            private int Method(int i)
            {
                if (i == 0)
                {
                    return (0);
                }
                else
                {
                    if (i > 0)
                    {
                        switch (i)
                        {
                            case 1:
                                return (0);
                            case 3:
                                while (i > 0)
                                {
                                    return (0);
                                }
                                for (; i < 0;)
                                {
                                    return (1);
                                }
                                throw new Exception();
                            default:
                                return (0);
                        }
                    }
                    else
                    {
                        return (0);
                    }
                }
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_throw_001
        {
            public static int Main_old(string[] args)
            {
                int i;
                i = Statements_TestClass_throw_001.sMethod();
                if (i > 0)
                    return (1);
                Statements_TestClass_throw_001.sMethod();
                Statements_TestClass_throw_001 t = new Statements_TestClass_throw_001();
                i = t.Method();
                t.Method();
                return (i == 0 ? 0 : 1);
            }
            private static int sMethod()
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception e)
                {
                    return (0);
                }
                return (1);
            }
            private int Method()
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception e)
                {
                    return (0);
                }
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_throw_005
        {
            public static int Main_old(string[] args)
            {
                int i;
                i = Statements_TestClass_throw_005.sMethod();
                return (i == 0 ? 0 : 1);
            }
            private static int sMethod()
            {
                int i = 1;
                try
                {
                    Exception e = new Exception();
                    throw (e);
                }
                catch (Exception e)
                {
                    OutputHelper.WriteLine(e.ToString());
                    return (0);
                }
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_trycatch_001
        {
            public static int Main_old(string[] args)
            {
                int i;
                Statements_TestClass_trycatch_001 t = new Statements_TestClass_trycatch_001();
                i = t.Method();
                return (i == 0 ? 0 : 1);
            }
            private int Method()
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception e)
                {
                    return (0);
                }
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_trycatch_006
        {
            public static int Main_old(string[] args)
            {
                int i;
                Statements_TestClass_trycatch_006 t = new Statements_TestClass_trycatch_006();
                i = t.Method(0);
                return (i == 0 ? 0 : 1);
            }
            private int Method(int i)
            {
                try
                {
                    int x = 1 / i;
                    OutputHelper.WriteLine(x.ToString()); // prevent it being optimized away
                }
                catch (Exception e)
                {
                    return (0);
                }
                return (1);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_trycatch_007
        {
            public static int Main_old(string[] args)
            {
                int i;
                Statements_TestClass_trycatch_007 t = new Statements_TestClass_trycatch_007();
                i = t.Method();
                int tt = i == 0 ? 0 : 1;
                OutputHelper.WriteLine("Value is" + tt);
                return (i == 0 ? 0 : 1);
            }
            private int Method()
            {
                try
                {
                    try
                    {
                        Thrower();
                        //throw new System.Exception();
                    }
                    catch (Exception e)
                    {
                        // Rethrow
                        throw;
                    }
                }
                catch (Exception e)
                {
                    // Recatch
                    return (0);
                }
                return (1);
            }
            private void Thrower()
            {
                throw new Exception();
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_tryfinally_001
        {
            public static int Main_old(string[] args)
            {
                int i;
                Statements_TestClass_tryfinally_001 t = new Statements_TestClass_tryfinally_001();
                i = t.Method(2);
                return (i == 0 ? 0 : 1);
            }
            private int Method(int i)
            {
                try
                {
                    i--;
                }
                finally
                {
                    i--;
                }

                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_tryfinally_002
        {
            public static int Main_old(string[] args)
            {
                int i;
                Statements_TestClass_tryfinally_002 t = new Statements_TestClass_tryfinally_002();
                i = t.Method(1);
                return (i == 0 ? 0 : 1);
            }
            private int Method(int i)
            {
                try
                {
                    try
                    {
                        throw new Exception();
                    }
                    finally
                    {
                        i--;
                    }
                }
                catch
                {

                }
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_tryfinally_003
        {
            public static int Main_old(string[] args)
            {
                int i;
                Statements_TestClass_tryfinally_003 t = new Statements_TestClass_tryfinally_003();
                i = t.Method(1);
                return (i == 0 ? 0 : 1);
            }
            private int Method(int i)
            {
                try
                {
                    try
                    {
                        throw new Exception();
                    }
                    catch
                    {
                    }
                }
                finally
                {
                    i--;
                }
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_tryfinally_004
        {
            public static int Main_old(string[] args)
            {
                int i;
                Statements_TestClass_tryfinally_004 t = new Statements_TestClass_tryfinally_004();
                i = t.Method(1);
                return (i == 0 ? 0 : 1);
            }
            private int Method(int i)
            {
                try
                {
                    goto TheEnd;
                }
                finally
                {
                    i--;
                }
            TheEnd:
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_tryfinally_006
        {
            public static int Main_old(string[] args)
            {
                int i = 0;
                Statements_TestClass_tryfinally_006 t = new Statements_TestClass_tryfinally_006();
                try
                {
                    i = t.Method(1);
                }
                catch { }
                return (i == 0 ? 0 : 1);
            }
            private int Method(int i)
            {
                try
                {
                    throw new Exception();
                }
                finally
                {
                    i--;
                }
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_tryfinally_007
        {
            public static int Main_old(string[] args)
            {
                int i = 0;
                Statements_TestClass_tryfinally_007 t = new Statements_TestClass_tryfinally_007();
                try
                {
                    i = t.Method(1);
                }
                catch { }
                return (i == 0 ? 0 : 1);
            }
            private int Method(int i)
            {
                try
                {
                    DeepMethod(i);
                }
                finally
                {
                    i--;
                }
                return (i);
            }
            private int DeepMethod(int i)
            {
                throw new Exception();
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_tryfinally_008
        {
            public static int Main_old(string[] args)
            {
                int i = 1;
                Statements_TestClass_tryfinally_008 t = new Statements_TestClass_tryfinally_008();
                try
                {
                    i = t.Method(0);
                }
                catch { }
                return (i == 0 ? 0 : 1);
            }
            private int Method(int i)
            {
                try
                {
                    return (i);
                }
                finally
                {
                    i++;
                }
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_tryfinally_009
        {
            public static int Main_old(string[] args)
            {
                int i = 1;
                Statements_TestClass_tryfinally_009 t = new Statements_TestClass_tryfinally_009();
                try
                {
                    i = t.Method(1);
                }
                catch { }
                return (i == 0 ? 0 : 1);
            }
            private int Method(int i)
            {
                bool b = true;
                while (b)
                {
                    try
                    {
                        b = false;
                        continue;
                    }
                    finally
                    {
                        i--;
                    }
                }
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_tryfinally_010
        {
            public static int Main_old(string[] args)
            {
                int i = 1;
                Statements_TestClass_tryfinally_010 t = new Statements_TestClass_tryfinally_010();
                try
                {
                    i = t.Method(1);
                }
                catch { }
                return (i == 0 ? 0 : 1);
            }
            private int Method(int i)
            {
                while (true)
                {
                    try
                    {
                        break;
                    }
                    finally
                    {
                        i--;
                    }
                }
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_tryfinally_011
        {
            public static int Main_old(string[] args)
            {
                int i = 1;
                Statements_TestClass_tryfinally_011 t = new Statements_TestClass_tryfinally_011();
                try
                {
                    i = t.Method(0);
                }
                catch { }
                return (i == 0 ? 0 : 1);
            }
            private int Method(int i)
            {
                while (true)
                {
                    break;
                    try
                    {
                        break;
                    }
                    finally
                    {
                        i++;
                    }
                }
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public class Statements_TestClass_tryfinally_012
        {
            public static int Main_old(string[] args)
            {
                int i = 0;
                bool bCatch = false;
                Statements_TestClass_tryfinally_012 t = new Statements_TestClass_tryfinally_012();
                try
                {
                    i = t.Method(1);
                }
                catch { bCatch = true; }
                if (!bCatch)
                    i = 1;
                return (i == 0 ? 0 : 1);
            }
            private int Method(int i)
            {
                try
                {
                    OutputHelper.WriteLine((10 / (i - 1)).ToString());
                }
                finally
                {
                    i--;
                }
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        class Statements_TestClass_tryfinally_013
        {
            static void Main_old(string[] args)
            {
            before_try:
                try
                {
                }
                catch (Exception)
                {
                    goto before_try;
                }
                finally
                {

                before_inner_try:
                    try
                    {
                    }
                    catch (Exception)
                    {
                        goto before_inner_try;
                    }
                    finally
                    {
                    }
                }
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_001
        {
            public static void Main_old()
            {
                Res1 res1 = new Res1();
                IDisposable id = (IDisposable)res1;
                using (id)
                {
                    res1.Func();
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_002
        {
            public static void Main_old()
            {
                Res1 res1 = new Res1();
                using (res1)
                {
                    res1.Func();
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_003
        {
            public static void Main_old()
            {
                using (Res1 res1 = new Res1())
                {
                    res1.Func();
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_005
        {
            public static void Main_old()
            {
                using (ResExplicit resExplicit = new ResExplicit())
                {
                    resExplicit.Func();
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_009
        {
            public static void Main_old()
            {
                Res1 res1 = new Res1();
                using (res1)
                {
                    res1.Func();
                    res1 = null;
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_010
        {
            public static void Main_old()
            {
                using (Res1 res1 = new Res1())
                {
                    res1.Func();
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_011
        {
            public static void Main_old()
            {
                try
                {
                    using (Res1 res1 = new Res1())
                    {
                        res1.Throw();
                    }
                }
                catch
                {
                    // System.Exception caught
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_012
        {
            public static void Main_old()
            {
                using (Res1 res1 = new Res1())
                {
                    res1.Func();
                    using (Res2 res2 = new Res2())
                    {
                        res2.Func();
                    }
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_013
        {
            public static void Main_old()
            {
                try
                {
                    using (Res1 res1 = new Res1())
                    {
                        res1.Func();
                        res1.Throw();
                        using (Res2 res2 = new Res2())
                        {
                            res2.Func();
                        }
                    }
                }
                catch
                {
                    // System.Exception caught
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_014
        {
            public static void Main_old()
            {
                try
                {
                    using (Res1 res1 = new Res1())
                    {
                        res1.Func();
                        using (Res2 res2 = new Res2())
                        {
                            res2.Func();
                        }
                        res1.Throw();
                    }
                }
                catch
                {
                    // System.Exception caught
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_015
        {
            public static void Main_old()
            {
                try
                {
                    using (Res1 res1 = new Res1())
                    {
                        res1.Func();
                        using (Res2 res2 = new Res2())
                        {
                            res2.Func();
                            res1.Throw();
                        }
                    }
                }
                catch
                {
                    // System.Exception caught
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_017
        {
            public static void Main_old()
            {
                try
                {
                    using (Res1 res1 = new Res1(),
                        res1a = new Res1())
                    {
                        res1.Func();
                        res1.Func();
                        res1.Throw();
                    }
                }
                catch
                {
                    // System.Exception caught
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        // two normal classes...
        public class Statements_TestClass_Using_018
        {
            public static void Main_old()
            {
                using (Res1 res1 = new Res1(),
                    res1a = new Res1())
                {
                    res1.Func();
                    res1a.Func();
                }
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Statements_TestClass_lock001
        {
            public static int Main_old()
            {
                Statements_TestClass_lock001 C = new Statements_TestClass_lock001();
                lock (C)
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_lock003
        {
            public static int Main_old()
            {
                lock (typeof(Statements_TestClass_lock003))
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_lock004
        {
            public static int Main_old()
            {
                lock (typeof(Statements_TestClass_lock004)) ;
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_lock005
        {

            public void TryMe()
            {
                lock (this) { }
            }
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Statements_TestClass_lock007
        {
            public static int Main_old()
            {
                lock (typeof(Statements_TestClass_lock007))
                {
                    Statements_TestClass_lock007 C = new Statements_TestClass_lock007();
                    lock (C)
                    {
                        return 0;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Statements_TestClass_enum_002
        {
            private const int CONST = 2;
            public static int Main_old(string[] args)
            {
                int i = 2;
                if (i < (int)(MyEnum)CONST)
                    return 1;
                if (i == (int)(MyEnum)0)
                    return 1;
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }

        }
        public enum MyEnum
        {
            aaa,
            bbb,
            ccc
        }

    }
}
