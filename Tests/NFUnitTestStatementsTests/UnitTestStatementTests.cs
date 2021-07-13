using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestStatementsTests
{
    [TestClass]
    public class UnitTestStatementTests
    {
        [TestMethod]
        public void Statements_Label_001_Test()
        {
            OutputHelper.WriteLine("Label_001.sc");
            OutputHelper.WriteLine("Make sure labels can be declared");
            Assert.True(Statements_TestClass_Label_001.testMethod());
        }

        [TestMethod]
        public void Statements_Label_002_Test()
        {
            OutputHelper.WriteLine("Label_002.sc");
            OutputHelper.WriteLine("Make sure labels can be referenced. Assumes 'goto'");
            Assert.True(Statements_TestClass_Label_002.testMethod());
        }

        [TestMethod]
        public void Statements_Label_004_Test()
        {
            OutputHelper.WriteLine("Label_004.sc");
            OutputHelper.WriteLine("Make sure labels can be associated with an empty statement");
            Assert.True(Statements_TestClass_Label_004.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_001_Test()
        {
            OutputHelper.WriteLine("Decl_001.sc");
            OutputHelper.WriteLine("Declare a local variable of an intrinsic type");
            Assert.True(Statements_TestClass_Decl_001.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_002_Test()
        {
            OutputHelper.WriteLine("Decl_002.sc");
            OutputHelper.WriteLine("Declare a local variable of an intrinsic type and initialize it");
            Assert.True(Statements_TestClass_Decl_002.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_003_Test()
        {
            OutputHelper.WriteLine("Decl_003.sc");
            OutputHelper.WriteLine("Declare a local variable of an intrinsic type and initialize it");
            OutputHelper.WriteLine("with an expression.");
            Assert.True(Statements_TestClass_Decl_003.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_004_Test()
        {
            OutputHelper.WriteLine("Decl_004.sc");
            OutputHelper.WriteLine("Declare a local variable of an external object type");
            Assert.True(Statements_TestClass_Decl_004.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_007_Test()
        {
            OutputHelper.WriteLine("Decl_007.sc");
            OutputHelper.WriteLine("Declare a series of local variables of an intrinsic type with commas");
            Assert.True(Statements_TestClass_Decl_007.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_009_Test()
        {
            OutputHelper.WriteLine("Decl_009.sc");
            OutputHelper.WriteLine("Declare a series of local variables of an intrinsic type with commas and");
            OutputHelper.WriteLine("initial assignments.");
            Assert.True(Statements_TestClass_Decl_009.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_010_Test()
        {
            OutputHelper.WriteLine("Decl_010.sc");
            OutputHelper.WriteLine("Declare a local variable of an intrinsic type as an array");
            Assert.True(Statements_TestClass_Decl_010.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_012_Test()
        {
            OutputHelper.WriteLine("Decl_012.sc");
            OutputHelper.WriteLine("Declare a local variable of an intrinsic type as an array, allocate and reference it.");
            Assert.True(Statements_TestClass_Decl_012.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_014_Test()
        {
            OutputHelper.WriteLine("Decl_014.sc");
            OutputHelper.WriteLine("Declare a local variable of an intrinsic type as an initialized array");
            Assert.True(Statements_TestClass_Decl_014.testMethod());
        }

        [TestMethod]
        public void Statements_Decl_016_Test()
        {
            OutputHelper.WriteLine("Decl_016.sc");
            OutputHelper.WriteLine("Correctly declare a local variable of a type that has no default constructor");
            OutputHelper.WriteLine("as an array.");
            Assert.True(Statements_TestClass_Decl_016.testMethod());
        }

        [TestMethod]
        public void Statements_Block_001_Test()
        {
            OutputHelper.WriteLine("Block_001.sc");
            OutputHelper.WriteLine("Statements_TestClass_? Several types of statement blocks.  Statement blocks");
            OutputHelper.WriteLine("are so fundamental, that most can be tested in one pass.");
            OutputHelper.WriteLine("Note that by the nature of this code, many warnings");
            OutputHelper.WriteLine("could/should be generated about items that are never reached.");
            Assert.True(Statements_TestClass_Block_001.testMethod());
        }

        [TestMethod]
        public void Statements_Empty_001_Test()
        {
            OutputHelper.WriteLine("Empty_001.sc");
            OutputHelper.WriteLine("Statements_TestClass_? Several scenarios for empty statement.  Emtpy statements");
            OutputHelper.WriteLine("are so fundamental, that most can be tested in one pass.");
            OutputHelper.WriteLine("Note that by the nature of this code, many warnings");
            OutputHelper.WriteLine("could/should be generated about items that are never reached.");
            Assert.True(Statements_TestClass_Empty_001.testMethod());
        }

        [TestMethod]
        public void Statements_Expr_002_Test()
        {
            OutputHelper.WriteLine("Expr_002.sc");
            OutputHelper.WriteLine("Use an expression with side effects.");
            Assert.True(Statements_TestClass_Expr_002.testMethod());
        }

        [TestMethod]
        public void Statements_Expr_003_Test()
        {
            OutputHelper.WriteLine("Expr_003.sc");
            OutputHelper.WriteLine("Use an expression with side effects and multiple l-values.");
            Assert.True(Statements_TestClass_Expr_003.testMethod());
        }

        [TestMethod]
        public void Statements_Expr_004_Test()
        {
            OutputHelper.WriteLine("Expr_004.sc");
            OutputHelper.WriteLine("Run a quick test of common operator/assignment combos");
            Assert.True(Statements_TestClass_Expr_004.testMethod());
        }

        [TestMethod]
        public void Statements_Expr_006_Test()
        {
            OutputHelper.WriteLine("   complex assignment");
            Assert.True(Statements_TestClass_Expr_006.testMethod());
        }

        [TestMethod]
        public void Statements_if_001_Test()
        {
            OutputHelper.WriteLine("if_001.sc");
            OutputHelper.WriteLine("Simple boolean if with a single statement");
            Assert.True(Statements_TestClass_if_001.testMethod());
        }

        [TestMethod]
        public void Statements_if_003_Test()
        {
            OutputHelper.WriteLine("if_003.sc");
            OutputHelper.WriteLine("Simple boolean if with a block statement");
            Assert.True(Statements_TestClass_if_003.testMethod());
        }

        [TestMethod]
        public void Statements_if_005_Test()
        {
            OutputHelper.WriteLine("if_005.sc");
            OutputHelper.WriteLine("Simple boolean if with a single statement and else");
            Assert.True(Statements_TestClass_if_005.testMethod());
        }

        [TestMethod]
        public void Statements_if_007_Test()
        {
            OutputHelper.WriteLine("if_007.sc");
            OutputHelper.WriteLine("Simple boolean if with a block statement");
            Assert.True(Statements_TestClass_if_007.testMethod());
        }

        [TestMethod]
        public void Statements_if_009_Test()
        {
            OutputHelper.WriteLine("if_009.sc");
            OutputHelper.WriteLine("Nest ifs with elses without blocks. Statements_TestClass_? that the 'else' ambiguity from");
            OutputHelper.WriteLine("C/C++ is handled the same way (else bound to closest if)");
            Assert.True(Statements_TestClass_if_009.testMethod());
        }

        [TestMethod]
        public void Statements_switch_001_Test()
        {
            OutputHelper.WriteLine("switch_001.sc");
            OutputHelper.WriteLine("Empty switch");
            Assert.True(Statements_TestClass_switch_001.testMethod());
        }

        [TestMethod]
        public void Statements_switch_002_Test()
        {
            OutputHelper.WriteLine("switch_002.sc");
            OutputHelper.WriteLine("Default only switch");
            Assert.True(Statements_TestClass_switch_002.testMethod());
        }

        [TestMethod]
        public void Statements_switch_003_Test()
        {
            OutputHelper.WriteLine("switch_003.sc");
            OutputHelper.WriteLine("Switch with single case without break - no default");
            Assert.True(Statements_TestClass_switch_003.testMethod());
        }

        [TestMethod]
        public void Statements_switch_004_Test()
        {
            OutputHelper.WriteLine("switch_004.sc");
            OutputHelper.WriteLine("Switch with one case, using break");
            Assert.True(Statements_TestClass_switch_004.testMethod());
        }

        [TestMethod]
        public void Statements_switch_005_Test()
        {
            OutputHelper.WriteLine("switch_005.sc");
            OutputHelper.WriteLine("Switch with two cases, using break");
            Assert.True(Statements_TestClass_switch_005.testMethod());
        }

        [TestMethod]
        public void Statements_switch_006_Test()
        {
            OutputHelper.WriteLine("switch_006.sc");
            OutputHelper.WriteLine("Switch with one case and a default");
            Assert.True(Statements_TestClass_switch_006.testMethod());
        }

        [TestMethod]
        public void Statements_switch_007_Test()
        {
            OutputHelper.WriteLine("switch_007.sc");
            OutputHelper.WriteLine("Switch with two cases and a default");
            Assert.True(Statements_TestClass_switch_007.testMethod());
        }

        [TestMethod]
        public void Statements_switch_010_Test()
        {
            OutputHelper.WriteLine("switch_010.sc");
            OutputHelper.WriteLine("Switch with a const variable in a case");
            Assert.True(Statements_TestClass_switch_010.testMethod());
        }

        [TestMethod]
        public void Statements_switch_012_Test()
        {
            OutputHelper.WriteLine("switch_012.sc");
            OutputHelper.WriteLine("Multiple case labels");
            Assert.True(Statements_TestClass_switch_012.testMethod());
        }

        [TestMethod]
        public void Statements_switch_013_Test()
        {
            OutputHelper.WriteLine("switch_013.sc");
            OutputHelper.WriteLine("test goto all over");
            OutputHelper.WriteLine("Expected Output");
            Assert.True(Statements_TestClass_switch_013.testMethod());
        }

        [TestMethod]
        public void Statements_switch_015_Test()
        {
            OutputHelper.WriteLine("switch_015.sc");
            OutputHelper.WriteLine("Run a switch over a specific type: byte");
            Assert.True(Statements_TestClass_switch_015.testMethod());
        }

        [TestMethod]
        public void Statements_switch_016_Test()
        {
            OutputHelper.WriteLine("switch_016.sc");
            OutputHelper.WriteLine("Run a switch over a specific type: char");
            Assert.True(Statements_TestClass_switch_016.testMethod());
        }

        [TestMethod]
        public void Statements_switch_017_Test()
        {
            OutputHelper.WriteLine("switch_017.sc");
            OutputHelper.WriteLine("Run a switch over a specific type: short");
            Assert.True(Statements_TestClass_switch_017.testMethod());
        }

        [TestMethod]
        public void Statements_switch_018_Test()
        {
            OutputHelper.WriteLine("switch_018.sc");
            OutputHelper.WriteLine("Run a switch over a specific type: int");
            Assert.True(Statements_TestClass_switch_018.testMethod());
        }

        [TestMethod]
        public void Statements_switch_019_Test()
        {
            OutputHelper.WriteLine("switch_019.sc");
            OutputHelper.WriteLine("Run a switch over a specific type: long");
            Assert.True(Statements_TestClass_switch_019.testMethod());
        }

        [TestMethod]
        public void Statements_switch_023_Test()
        {
            OutputHelper.WriteLine("switch_023.sc");
            OutputHelper.WriteLine("Run a switch over a specific type: enum");
            Assert.True(Statements_TestClass_switch_023.testMethod());
        }

        [TestMethod]
        public void Statements_switch_030_Test()
        {
            OutputHelper.WriteLine("   switch on int variable, float case");
            Assert.True(Statements_TestClass_switch_030.testMethod());
        }

        [TestMethod]
        public void Statements_switch_031_Test()
        {
            OutputHelper.WriteLine("   switch with holes in range");
            Assert.True(Statements_TestClass_switch_031.testMethod());
        }

        [TestMethod]
        public void Statements_switch_032_Test()
        {
            OutputHelper.WriteLine("   switch: default case at top");
            Assert.True(Statements_TestClass_switch_032.testMethod());
        }

        [TestMethod]
        public void Statements_switch_033_Test()
        {
            OutputHelper.WriteLine("   switch: default case in middle");
            Assert.True(Statements_TestClass_switch_033.testMethod());
        }

        [TestMethod]
        public void Statements_switch_034_Test()
        {
            OutputHelper.WriteLine("   switch: default case in middle");
            Assert.True(Statements_TestClass_switch_034.testMethod());
        }

        [TestMethod]
        public void Statements_switch_035_Test()
        {
            OutputHelper.WriteLine("Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of ");
            OutputHelper.WriteLine("the switch expression to one of the following possible governing types: sbyte, byte, short,");
            OutputHelper.WriteLine("ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if ");
            OutputHelper.WriteLine("more than one such implicit conversion exists, a compile-time error occurs.");
            Assert.True(Statements_TestClass_switch_035.testMethod());
        }

        [TestMethod]
        public void Statements_switch_036_Test()
        {
            OutputHelper.WriteLine("Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of ");
            OutputHelper.WriteLine("the switch expression to one of the following possible governing types: sbyte, byte, short,");
            OutputHelper.WriteLine("ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if ");
            OutputHelper.WriteLine("more than one such implicit conversion exists, a compile-time error occurs.");
            Assert.True(Statements_TestClass_switch_036.testMethod());
        }

        [TestMethod]
        public void Statements_switch_037_Test()
        {
            OutputHelper.WriteLine("Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of ");
            OutputHelper.WriteLine("the switch expression to one of the following possible governing types: sbyte, byte, short,");
            OutputHelper.WriteLine("ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if ");
            OutputHelper.WriteLine("more than one such implicit conversion exists, a compile-time error occurs.");
            Assert.True(Statements_TestClass_switch_037.testMethod());
        }

        [TestMethod]
        public void Statements_switch_038_Test()
        {
            OutputHelper.WriteLine("Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of ");
            OutputHelper.WriteLine("the switch expression to one of the following possible governing types: sbyte, byte, short,");
            OutputHelper.WriteLine("ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if ");
            OutputHelper.WriteLine("more than one such implicit conversion exists, a compile-time error occurs.");
            Assert.True(Statements_TestClass_switch_038.testMethod());
        }

        [TestMethod]
        public void Statements_switch_039_Test()
        {
            OutputHelper.WriteLine("Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of ");
            OutputHelper.WriteLine("the switch expression to one of the following possible governing types: sbyte, byte, short,");
            OutputHelper.WriteLine("ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if ");
            OutputHelper.WriteLine("more than one such implicit conversion exists, a compile-time error occurs.");
            Assert.True(Statements_TestClass_switch_039.testMethod());
        }

        [TestMethod]
        public void Statements_switch_040_Test()
        {
            OutputHelper.WriteLine("Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of ");
            OutputHelper.WriteLine("the switch expression to one of the following possible governing types: sbyte, byte, short,");
            OutputHelper.WriteLine("ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if ");
            OutputHelper.WriteLine("more than one such implicit conversion exists, a compile-time error occurs.");
            Assert.True(Statements_TestClass_switch_040.testMethod());
        }

        [TestMethod]
        public void Statements_switch_041_Test()
        {
            OutputHelper.WriteLine("Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of ");
            OutputHelper.WriteLine("the switch expression to one of the following possible governing types: sbyte, byte, short,");
            OutputHelper.WriteLine("ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if ");
            OutputHelper.WriteLine("more than one such implicit conversion exists, a compile-time error occurs.");
            Assert.True(Statements_TestClass_switch_041.testMethod());
        }

        [TestMethod]
        public void Statements_switch_042_Test()
        {
            OutputHelper.WriteLine("Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of ");
            OutputHelper.WriteLine("the switch expression to one of the following possible governing types: sbyte, byte, short,");
            OutputHelper.WriteLine("ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if ");
            OutputHelper.WriteLine("more than one such implicit conversion exists, a compile-time error occurs.");
            Assert.True(Statements_TestClass_switch_042.testMethod());
        }

        [TestMethod]
        public void Statements_switch_044_Test()
        {
            OutputHelper.WriteLine("Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of ");
            OutputHelper.WriteLine("the switch expression to one of the following possible governing types: sbyte, byte, short,");
            OutputHelper.WriteLine("ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if ");
            OutputHelper.WriteLine("more than one such implicit conversion exists, a compile-time error occurs.");
            Assert.True(Statements_TestClass_switch_044.testMethod());
        }

        [TestMethod]
        public void Statements_switch_047_Test()
        {
            OutputHelper.WriteLine("Otherwise, exactly one user-defined implicit conversion (�6.4) must exist from the type of ");
            OutputHelper.WriteLine("the switch expression to one of the following possible governing types: sbyte, byte, short,");
            OutputHelper.WriteLine("ushort, int, uint, long, ulong, char, string. If no such implicit conversion exists, or if ");
            OutputHelper.WriteLine("more than one such implicit conversion exists, a compile-time error occurs.");
            OutputHelper.WriteLine("Ensure error is emmited on when more than one implicit conversion to an acceptable governing type is defined");
            Assert.True(Statements_TestClass_switch_047.testMethod());
        }

        [TestMethod]
        public void Statements_switch_049_Test()
        {
            OutputHelper.WriteLine("warning CS1522: Empty switch block");
            Assert.True(Statements_TestClass_switch_049.testMethod());
        }

        [TestMethod]
        public void Statements_switch_string_001_Test()
        {
            OutputHelper.WriteLine("   switch on string: null");
            Assert.True(Statements_TestClass_switch_string_001.testMethod());
        }

        [TestMethod]
        public void Statements_dowhile_001_Test()
        {
            OutputHelper.WriteLine("dowhile_001.sc");
            OutputHelper.WriteLine("do/while with a single statement");
            Assert.True(Statements_TestClass_dowhile_001.testMethod());
        }

        [TestMethod]
        public void Statements_dowhile_002_Test()
        {
            OutputHelper.WriteLine("dowhile_002.sc");
            OutputHelper.WriteLine("do/while with a compound statement");
            Assert.True(Statements_TestClass_dowhile_002.testMethod());
        }

        [TestMethod]
        public void Statements_dowhile_003_Test()
        {
            OutputHelper.WriteLine("dowhile_003.sc");
            OutputHelper.WriteLine("verify known false condition executes only once with single statement");
            Assert.True(Statements_TestClass_dowhile_003.testMethod());
        }

        [TestMethod]
        public void Statements_dowhile_004_Test()
        {
            OutputHelper.WriteLine("dowhile_004.sc");
            OutputHelper.WriteLine("verify known true condition executes with single statement");
            Assert.True(Statements_TestClass_dowhile_004.testMethod());
        }

        [TestMethod]
        public void Statements_dowhile_005_Test()
        {
            OutputHelper.WriteLine("dowhile_005.sc");
            OutputHelper.WriteLine("verify known false condition executes once with compound statements");
            Assert.True(Statements_TestClass_dowhile_005.testMethod());
        }

        [TestMethod]
        public void Statements_dowhile_006_Test()
        {
            OutputHelper.WriteLine("dowhile_006.sc");
            OutputHelper.WriteLine("verify known true condition executes with compound statements");
            Assert.True(Statements_TestClass_dowhile_006.testMethod());
        }

        [TestMethod]
        public void Statements_for_001_Test()
        {
            OutputHelper.WriteLine("for_001.sc");
            OutputHelper.WriteLine("empty for loop");
            Assert.True(Statements_TestClass_for_001.testMethod());
        }

        [TestMethod]
        public void Statements_for_003_Test()
        {
            OutputHelper.WriteLine("for_003.sc");
            OutputHelper.WriteLine("empty initializer in for loop");
            Assert.True(Statements_TestClass_for_003.testMethod());
        }

        [TestMethod]
        public void Statements_for_004_Test()
        {
            OutputHelper.WriteLine("for_004.sc");
            OutputHelper.WriteLine("empty iterator in for loop");
            Assert.True(Statements_TestClass_for_004.testMethod());
        }

        [TestMethod]
        public void Statements_for_006_Test()
        {
            OutputHelper.WriteLine("for_006.sc");
            OutputHelper.WriteLine("Full normal for loop");
            Assert.True(Statements_TestClass_for_006.testMethod());
        }

        [TestMethod]
        public void Statements_for_007_Test()
        {
            OutputHelper.WriteLine("for_007.sc");
            OutputHelper.WriteLine("Full normal for loop with a compound statement");
            Assert.True(Statements_TestClass_for_007.testMethod());
        }

        [TestMethod]
        public void Statements_for_008_Test()
        {
            OutputHelper.WriteLine("for_008.sc");
            OutputHelper.WriteLine("Multiple declarations in initializer");
            Assert.True(Statements_TestClass_for_008.testMethod());
        }

        [TestMethod]
        public void Statements_for_009_Test()
        {
            OutputHelper.WriteLine("for_009.sc");
            OutputHelper.WriteLine("Statements_TestClass_? statement expression lists in for initializer");
            Assert.True(Statements_TestClass_for_009.testMethod());
        }

        [TestMethod]
        public void Statements_for_010_Test()
        {
            OutputHelper.WriteLine("for_010.sc");
            OutputHelper.WriteLine("Statements_TestClass_? statement expression lists in for iterator");
            Assert.True(Statements_TestClass_for_010.testMethod());
        }

        [TestMethod]
        public void Statements_for_011_Test()
        {
            OutputHelper.WriteLine("for_011.sc");
            OutputHelper.WriteLine("Statements_TestClass_? statement expression lists in for initializer and iterator");
            Assert.True(Statements_TestClass_for_011.testMethod());
        }

        [TestMethod]
        public void Statements_for_013_Test()
        {
            OutputHelper.WriteLine("for_013.sc");
            OutputHelper.WriteLine("Verify conditional evaluates before iterator");
            Assert.True(Statements_TestClass_for_013.testMethod());
        }

        [TestMethod]
        public void Statements_for_014_Test()
        {
            OutputHelper.WriteLine("for_014.sc");
            OutputHelper.WriteLine("Verify method calls work ok in all for loop areas");
            Assert.True(Statements_TestClass_for_014.testMethod());
        }

        [TestMethod]
        public void Statements_char_in_string_s01_Test()
        {
            OutputHelper.WriteLine("Optimization to foreach (char c in String) by treating String as a char array");
            Assert.True(Statements_TestClass_char_in_string_s01.testMethod());
        }

        [TestMethod]
        public void Statements_char_in_string_ex01_Test()
        {
            OutputHelper.WriteLine("Optimization to foreach (char c in String) by treating String as a char array");
            Assert.True(Statements_TestClass_char_in_string_ex01.testMethod());
        }

        [TestMethod]
        public void Statements_while_001_Test()
        {
            OutputHelper.WriteLine("while_001.sc");
            OutputHelper.WriteLine("while with a single statement");
            Assert.True(Statements_TestClass_while_001.testMethod());
        }

        [TestMethod]
        public void Statements_while_002_Test()
        {
            OutputHelper.WriteLine("while_002.sc");
            OutputHelper.WriteLine("while with a compound statement");
            Assert.True(Statements_TestClass_while_002.testMethod());
        }

        [TestMethod]
        public void Statements_while_003_Test()
        {
            OutputHelper.WriteLine("while_003.sc");
            OutputHelper.WriteLine("verify known false condition doesn't execute with single statement");
            Assert.True(Statements_TestClass_while_003.testMethod());
        }

        [TestMethod]
        public void Statements_while_004_Test()
        {
            OutputHelper.WriteLine("while_004.sc");
            OutputHelper.WriteLine("verify known true condition executes with single statement");
            Assert.True(Statements_TestClass_while_004.testMethod());
        }

        [TestMethod]
        public void Statements_while_005_Test()
        {
            OutputHelper.WriteLine("while_005.sc");
            OutputHelper.WriteLine("verify known false condition doesn't execute with compound statements");
            Assert.True(Statements_TestClass_while_005.testMethod());
        }

        [TestMethod]
        public void Statements_while_006_Test()
        {
            OutputHelper.WriteLine("while_006.sc");
            OutputHelper.WriteLine("verify known true condition executes with compound statements");
            Assert.True(Statements_TestClass_while_006.testMethod());
        }

        [TestMethod]
        public void Statements_break_001_Test()
        {
            OutputHelper.WriteLine("break_001.sc");
            OutputHelper.WriteLine("Make sure break works in all basic single statement loops");
            Assert.True(Statements_TestClass_break_001.testMethod());
        }

        [TestMethod]
        public void Statements_break_002_Test()
        {
            OutputHelper.WriteLine("break_002.sc");
            OutputHelper.WriteLine("Make sure break works in all basic compound statement loops");
            Assert.True(Statements_TestClass_break_002.testMethod());
        }

        [TestMethod]
        public void Statements_break_003_Test()
        {
            OutputHelper.WriteLine("break_003.sc");
            OutputHelper.WriteLine("Make sure break optional on end of switch");
            Assert.True(Statements_TestClass_break_003.testMethod());
        }

        [TestMethod]
        public void Statements_break_006_Test()
        {
            OutputHelper.WriteLine("break_006.sc");
            OutputHelper.WriteLine("break in an if successfully breaks loop");
            Assert.True(Statements_TestClass_break_006.testMethod());
        }

        [TestMethod]
        public void Statements_break_007_Test()
        {
            OutputHelper.WriteLine("break_007.sc");
            OutputHelper.WriteLine("break in a blocked if successfully breaks loop");
            Assert.True(Statements_TestClass_break_007.testMethod());
        }

        [TestMethod]
        public void Statements_break_010_Test()
        {
            OutputHelper.WriteLine("break_010.sc");
            OutputHelper.WriteLine("Make sure break correctly when nested");
            Assert.True(Statements_TestClass_break_010.testMethod());
        }

        [TestMethod]
        public void Statements_continue_001_Test()
        {
            OutputHelper.WriteLine("continue_001.sc");
            OutputHelper.WriteLine("Make sure continue works in all basic single statement loops");
            Assert.True(Statements_TestClass_continue_001.testMethod());
        }

        [TestMethod]
        public void Statements_continue_002_Test()
        {
            OutputHelper.WriteLine("continue_002.sc");
            OutputHelper.WriteLine("Make sure continue works in all basic compound statement loops");
            OutputHelper.WriteLine("Expected Output");
            Assert.True(Statements_TestClass_continue_002.testMethod());
        }

        [TestMethod]
        public void Statements_continue_006_Test()
        {
            OutputHelper.WriteLine("continue_006.sc");
            OutputHelper.WriteLine("continue in an if successfully continues loop");
            Assert.True(Statements_TestClass_continue_006.testMethod());
        }

        [TestMethod]
        public void Statements_continue_007_Test()
        {
            OutputHelper.WriteLine("continue_007.sc");
            OutputHelper.WriteLine("continue in a block if successfully continues loop");
            Assert.True(Statements_TestClass_continue_007.testMethod());
        }

        [TestMethod]
        public void Statements_continue_010_Test()
        {
            OutputHelper.WriteLine("continue_010.sc");
            OutputHelper.WriteLine("Make sure continue works correctly when nested");
            Assert.True(Statements_TestClass_continue_010.testMethod());
        }

        [TestMethod]
        public void Statements_goto_001_Test()
        {
            OutputHelper.WriteLine("goto_001.sc");
            OutputHelper.WriteLine("simple goto to adjust flow control");
            Assert.True(Statements_TestClass_goto_001.testMethod());
        }

        [TestMethod]
        public void Statements_goto_008_Test()
        {
            OutputHelper.WriteLine("goto_008.sc");
            OutputHelper.WriteLine("goto currect case");
            Assert.True(Statements_TestClass_goto_008.testMethod());
        }

        [TestMethod]
        public void Statements_goto_009_Test()
        {
            OutputHelper.WriteLine("goto_009.sc");
            OutputHelper.WriteLine("goto a different case");
            OutputHelper.WriteLine("Expected Output");
            Assert.True(Statements_TestClass_goto_009.testMethod());
        }

        [TestMethod]
        public void Statements_goto_010_Test()
        {
            OutputHelper.WriteLine("goto_010.sc");
            OutputHelper.WriteLine("goto default correctly");
            Assert.True(Statements_TestClass_goto_010.testMethod());
        }

        [TestMethod]
        public void Statements_goto_014_Test()
        {
            OutputHelper.WriteLine("goto_014.sc");
            OutputHelper.WriteLine("simple gotos to test jumping to parent process.");
            Assert.True(Statements_TestClass_goto_014.testMethod());
        }

        [TestMethod]
        public void Statements_goto_017_Test()
        {
            OutputHelper.WriteLine("   some gotos");
            Assert.True(Statements_TestClass_goto_017.testMethod());
        }

        [TestMethod]
        public void Statements_goto_018_Test()
        {
            OutputHelper.WriteLine("   try/catch/finally with goto");
            Assert.True(Statements_TestClass_goto_018.testMethod());
        }

        [TestMethod]
        public void Statements_return_001_Test()
        {
            OutputHelper.WriteLine("return_001.sc");
            OutputHelper.WriteLine("simple void return on a void method");
            Assert.True(Statements_TestClass_return_001.testMethod());
        }

        [TestMethod]
        public void Statements_return_004_Test()
        {
            OutputHelper.WriteLine("return_004.sc");
            OutputHelper.WriteLine("simple return a normal type, assigning, and ignoring return value");
            Assert.True(Statements_TestClass_return_004.testMethod());
        }

        [TestMethod]
        public void Statements_return_006_Test()
        {
            OutputHelper.WriteLine("return_006.sc");
            OutputHelper.WriteLine("simple return a type mismatch that has an implicit conversion");
            Assert.True(Statements_TestClass_return_006.testMethod());
        }

        [TestMethod]
        public void Statements_return_008_Test()
        {
            OutputHelper.WriteLine("return_008.sc");
            OutputHelper.WriteLine("simple return a type mismatch that has an explicit convertion conversion,");
            OutputHelper.WriteLine("applying the cast");
            Assert.True(Statements_TestClass_return_008.testMethod());
        }

        [TestMethod]
        public void Statements_return_009_Test()
        {
            OutputHelper.WriteLine("return_009.sc");
            OutputHelper.WriteLine("return of a struct");
            Assert.True(Statements_TestClass_return_009.testMethod());
        }

        [TestMethod]
        public void Statements_return_010_Test()
        {
            OutputHelper.WriteLine("return_010.sc");
            OutputHelper.WriteLine("return of a class");
            Assert.True(Statements_TestClass_return_010.testMethod());
        }

        [TestMethod]
        public void Statements_return_013_Test()
        {
            OutputHelper.WriteLine("return_013.sc");
            OutputHelper.WriteLine("simple falloff on a void method");
            Assert.True(Statements_TestClass_return_013.testMethod());
        }

        [TestMethod]
        public void Statements_return_014_Test()
        {
            OutputHelper.WriteLine("return_014.sc");
            OutputHelper.WriteLine("verify that a 'throw' is adequate for flow control analysis of return type");
            Assert.True(Statements_TestClass_return_014.testMethod());
        }

        [TestMethod]
        public void Statements_throw_001_Test()
        {
            OutputHelper.WriteLine("throw_001.sc");
            OutputHelper.WriteLine("simple throw");
            Assert.True(Statements_TestClass_throw_001.testMethod());
        }

        [TestMethod]
        public void Statements_throw_005_Test()
        {
            OutputHelper.WriteLine("throw_005.sc");
            OutputHelper.WriteLine("simple throw with output");
            Assert.True(Statements_TestClass_throw_005.testMethod());
        }

        [TestMethod]
        public void Statements_trycatch_001_Test()
        {
            OutputHelper.WriteLine("trycatch_001.sc");
            OutputHelper.WriteLine("simple throw");
            Assert.True(Statements_TestClass_trycatch_001.testMethod());
        }

        [TestMethod]
        public void Statements_trycatch_006_Test()
        {
            OutputHelper.WriteLine("trycatch_006.sc");
            OutputHelper.WriteLine("simple system generated System.Exception");
            Assert.True(Statements_TestClass_trycatch_006.testMethod());
        }

        [TestMethod]
        public void Statements_trycatch_007_Test()
        {
            OutputHelper.WriteLine("trycatch_007.sc");
            OutputHelper.WriteLine("simple re-throw");
            Assert.True(Statements_TestClass_trycatch_007.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_001_Test()
        {
            OutputHelper.WriteLine("tryfinally_001.sc");
            OutputHelper.WriteLine("simple finally");
            Assert.True(Statements_TestClass_tryfinally_001.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_002_Test()
        {
            OutputHelper.WriteLine("tryfinally_002.sc");
            OutputHelper.WriteLine("simple finally inside try/catch");
            Assert.True(Statements_TestClass_tryfinally_002.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_003_Test()
        {
            OutputHelper.WriteLine("tryfinally_003.sc");
            OutputHelper.WriteLine("simple finally outside try/catch");
            Assert.True(Statements_TestClass_tryfinally_003.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_004_Test()
        {
            OutputHelper.WriteLine("tryfinally_004.sc");
            OutputHelper.WriteLine("simple finally passed 'over' by a goto");
            Assert.True(Statements_TestClass_tryfinally_004.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_006_Test()
        {
            OutputHelper.WriteLine("tryfinally_006.sc");
            OutputHelper.WriteLine("simple finally exited by throw");
            Assert.True(Statements_TestClass_tryfinally_006.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_007_Test()
        {
            OutputHelper.WriteLine("tryfinally_007.sc");
            OutputHelper.WriteLine("simple finally exited by throw in a called method");
            Assert.True(Statements_TestClass_tryfinally_007.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_008_Test()
        {
            OutputHelper.WriteLine("tryfinally_008.sc");
            OutputHelper.WriteLine("simple finally exited by return");
            Assert.True(Statements_TestClass_tryfinally_008.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_009_Test()
        {
            OutputHelper.WriteLine("tryfinally_009.sc");
            OutputHelper.WriteLine("simple finally exited by continue");
            Assert.True(Statements_TestClass_tryfinally_009.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_010_Test()
        {
            OutputHelper.WriteLine("tryfinally_010.sc");
            OutputHelper.WriteLine("simple finally exited by break");
            Assert.True(Statements_TestClass_tryfinally_010.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_011_Test()
        {
            OutputHelper.WriteLine("tryfinally_011.sc");
            OutputHelper.WriteLine("simple finally exited by break (where break is outside try)");
            Assert.True(Statements_TestClass_tryfinally_011.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_012_Test()
        {
            OutputHelper.WriteLine("tryfinally_012.sc");
            OutputHelper.WriteLine("simple finally exited by system System.Exception");
            Assert.True(Statements_TestClass_tryfinally_012.testMethod());
        }

        [TestMethod]
        public void Statements_tryfinally_013_Test()
        {
            Assert.True(Statements_TestClass_tryfinally_013.testMethod());
        }

        [TestMethod]
        public void Statements_Using_001_Test()
        {
            OutputHelper.WriteLine("using_001.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("Cast a class to IDisposable explicitly, use that in the using statement. (1.a)");
            Assert.True(Statements_TestClass_Using_001.testMethod());
        }

        [TestMethod]
        public void Statements_Using_002_Test()
        {
            OutputHelper.WriteLine("using_002.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("Use a class directly in using (1.b)");
            Assert.True(Statements_TestClass_Using_002.testMethod());
        }

        [TestMethod]
        public void Statements_Using_003_Test()
        {
            OutputHelper.WriteLine("using_003.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("Creation of class as part of using statement (1.c)");
            Assert.True(Statements_TestClass_Using_003.testMethod());
        }

        [TestMethod]
        public void Statements_Using_005_Test()
        {
            OutputHelper.WriteLine("using_005.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("A class that explicitly implements IDisposable. (1.e)");
            Assert.True(Statements_TestClass_Using_005.testMethod());
        }

        [TestMethod]
        public void Statements_Using_009_Test()
        {
            OutputHelper.WriteLine("using_009.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("Statements_TestClass_? the behavior if the used variable is nulled-out in the using block (4)");
            Assert.True(Statements_TestClass_Using_009.testMethod());
        }

        [TestMethod]
        public void Statements_Using_010_Test()
        {
            OutputHelper.WriteLine("using_010.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("Dispose() called during normal exit (5.a)");
            Assert.True(Statements_TestClass_Using_010.testMethod());
        }

        [TestMethod]
        public void Statements_Using_011_Test()
        {
            OutputHelper.WriteLine("using_011.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("Dispose() called after throw (5.b)");
            OutputHelper.WriteLine("Expected Output");
            Assert.True(Statements_TestClass_Using_011.testMethod());
        }

        [TestMethod]
        public void Statements_Using_012_Test()
        {
            OutputHelper.WriteLine("using_012.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("Dispose() called for two objects during normal exit. (5.c)");
            Assert.True(Statements_TestClass_Using_012.testMethod());
        }

        [TestMethod]
        public void Statements_Using_013_Test()
        {
            OutputHelper.WriteLine("using_013.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("Dispose() called for first objects with System.Exception thrown before second block. (5.d)");
            Assert.True(Statements_TestClass_Using_013.testMethod());
        }

        [TestMethod]
        public void Statements_Using_014_Test()
        {
            OutputHelper.WriteLine("using_014.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("Dispose() called for first objects with System.Exception thrown after second block. (5.e)");
            Assert.True(Statements_TestClass_Using_014.testMethod());
        }

        [TestMethod]
        public void Statements_Using_015_Test()
        {
            OutputHelper.WriteLine("using_015.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("Dispose() called for both objects when System.Exception thrown inside second block. (5.f)");
            Assert.True(Statements_TestClass_Using_015.testMethod());
        }

        [TestMethod]
        public void Statements_Using_017_Test()
        {
            OutputHelper.WriteLine("using_017.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("Dispose() called for both objects when System.Exception thrown in compound case (5.h)");
            Assert.True(Statements_TestClass_Using_017.testMethod());
        }

        [TestMethod]
        public void Statements_Using_018_Test()
        {
            OutputHelper.WriteLine("using_018.cs");
            OutputHelper.WriteLine("Statements_TestClass_? the using statement.");
            OutputHelper.WriteLine("Dispose() called for both objects in compound using. (5.g)");
            Assert.True(Statements_TestClass_Using_018.testMethod());
        }

        [TestMethod]
        public void Statements_lock001_Test()
        {
            OutputHelper.WriteLine("The expression of a lock statement must denote a value of a reference-type");
            Assert.True(Statements_TestClass_lock001.testMethod());
        }

        [TestMethod]
        public void Statements_lock003_Test()
        {
            OutputHelper.WriteLine("The System.Type object of a class can conveniently be used as the mutual-exclusion lock for static methods of the class");
            Assert.True(Statements_TestClass_lock003.testMethod());
        }

        [TestMethod]
        public void Statements_lock004_Test()
        {
            OutputHelper.WriteLine("possible mistaken null statement when semi-column appears directly after lock()");
            Assert.True(Statements_TestClass_lock004.testMethod());
        }

        [TestMethod]
        public void Statements_lock005_Test()
        {
            OutputHelper.WriteLine("this as the lock expression in a reference type");
            Assert.True(Statements_TestClass_lock005.testMethod());
        }

        [TestMethod]
        public void Statements_lock007_Test()
        {
            OutputHelper.WriteLine("nested lock statements");
            Assert.True(Statements_TestClass_lock007.testMethod());
        }

        [TestMethod]
        public void Statements_enum_002_Test()
        {
            OutputHelper.WriteLine("   enum: comparing constant casted to an enum type to a variable");
            Assert.True(Statements_TestClass_enum_002.testMethod());
        }

        public class Res1 : IDisposable
        {
            public void Dispose()
            {
                OutputHelper.WriteLine("Res1.Dispose()");
            }
            public void Func()
            {
                OutputHelper.WriteLine("Res1.Func()");
            }
            public void Throw()
            {
                throw (new System.Exception("Res1"));
            }
        }

        public class Res2 : IDisposable
        {
            public void Dispose()
            {
                OutputHelper.WriteLine("Res2.Dispose()");
            }
            public void Func()
            {
                OutputHelper.WriteLine("Res2.Func()");
            }
            public void Throw()
            {
                throw (new System.Exception("Res2"));
            }
        }

        // IDispose implemented explicitly
        public class ResExplicit : IDisposable
        {
            void IDisposable.Dispose()
            {
                OutputHelper.WriteLine("ResExplicit.Dispose()");
            }
            public void Func()
            {
                OutputHelper.WriteLine("ResExplicit.Func()");
            }
            public void Throw()
            {
                throw (new System.Exception("ResExplicit"));
            }
        }

        // A class that doesn't implement IDisposable.
        public class NonRes1
        {
            public void GarbageDisposal()
            {
                OutputHelper.WriteLine("NonRes1.GarbageDisposal()");
            }
            public void Func()
            {
                OutputHelper.WriteLine("NonRes1.Func()");
            }
            public void Throw()
            {
                throw (new System.Exception("NonRes1"));
            }
        }

        // Doesn't implement IDisposable, but has a Dispose() function...
        public class NonRes2
        {
            public void Dispose()
            {
                OutputHelper.WriteLine("NonRes2.Dispose()");
            }
            public void Func()
            {
                OutputHelper.WriteLine("NonRes2.Func()");
            }
            public void Throw()
            {
                throw (new System.Exception("NonRes2"));
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
                System.Exception r;
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
                        OutputHelper.WriteLine("new Foo() didn't take");
                        return (1);
                    }
                    if (f[i].GetInt() != i)
                    {
                        OutputHelper.WriteLine("Array didn't get updated");
                        return (1);
                    }
                    if (f[i] != foo)
                    {
                        OutputHelper.WriteLine("Array element and foo are different");
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
                OutputHelper.WriteLine("Adding 5");
                i += 5;  // i == 5
                if (i != 5) return (1);
                OutputHelper.WriteLine("Subtracting 3");
                i -= 3;  // i == 2
                if (i != 2) return (1);
                OutputHelper.WriteLine("Multiplying by 4");
                i *= 4;  // i == 8
                if (i != 8) return (1);
                OutputHelper.WriteLine("Dividing by 2");
                i /= 2;  // i == 4
                if (i != 4) return (1);
                OutputHelper.WriteLine("Left Shifting 3");
                i <<= 3; // i == 32
                if (i != 32) return (1);
                OutputHelper.WriteLine("Right Shifting 2");
                i >>= 2; // i == 8
                if (i != 8) return (1);
                OutputHelper.WriteLine("ANDing against logical not");
                i &= ~i; // i = 0
                if (i != 0) return (1);
                OutputHelper.WriteLine("ORing by 0xBeaf");
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
                        OutputHelper.WriteLine("case 0: ");
                        OutputHelper.WriteLine(ret.ToString());
                        goto case 9999;
                    case 2:
                        ret--; // 4
                        OutputHelper.WriteLine("case 2: ");
                        OutputHelper.WriteLine(ret.ToString());
                        goto case 255;
                    case 6:			// start here
                        ret--; // 5
                        OutputHelper.WriteLine("case 5: ");
                        OutputHelper.WriteLine(ret.ToString());
                        goto case 2;
                    case 9999:
                        ret--; // 1
                        OutputHelper.WriteLine("case 9999: ");
                        OutputHelper.WriteLine(ret.ToString());
                        goto default;
                    case 0xff:
                        ret--; // 3
                        OutputHelper.WriteLine("case 0xff: ");
                        OutputHelper.WriteLine(ret.ToString());
                        goto case 0;
                    default:
                        ret--;
                        OutputHelper.WriteLine("Default: ");
                        OutputHelper.WriteLine(ret.ToString());
                        if (ret > 0)
                        {
                            goto case -1;
                        }
                        break;
                    case -1:
                        ret = 999;
                        OutputHelper.WriteLine("case -1: ");
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
                if (ret > 0)
                    OutputHelper.WriteLine("byte failed");
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
                if (ret > 0)
                    OutputHelper.WriteLine("char failed");
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
                if (ret > 0)
                    OutputHelper.WriteLine("short failed");
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
                if (ret > 0)
                    OutputHelper.WriteLine("int failed");
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
                if (ret > 0)
                    OutputHelper.WriteLine("long failed");
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
                if (ret > 0)
                    OutputHelper.WriteLine("enum	failed");
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
                        OutputHelper.WriteLine("a");
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
                        OutputHelper.WriteLine("null");
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
                    OutputHelper.WriteLine("Failure: i + 1 != j");
                    return (1);
                }
                if (j + 1 != k)
                {
                    OutputHelper.WriteLine("Failure: j + 1 != k");
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
                    OutputHelper.WriteLine("Failure: i + 1 != j");
                    return (1);
                }
                if (j + 1 != k)
                {
                    OutputHelper.WriteLine("Failure: j + 1 != k");
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
                    OutputHelper.WriteLine("Failure: i + 1 != j");
                    return (1);
                }
                if (j + 1 != k)
                {
                    OutputHelper.WriteLine("Failure: j + 1 != k");
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
                        OutputHelper.WriteLine("Fail");
                    }
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
                    OutputHelper.WriteLine("Hello World");
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
                    OutputHelper.WriteLine("Hello World");
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
                OutputHelper.WriteLine("Doing while");
                while (--i != 0)
                    continue;
                if (i != 0)
                    return (1);
                OutputHelper.WriteLine("Doing do/while");
                i = 5;
                do
                    continue;
                while (--i != 0);
                if (i != 0)
                    return (1);
                OutputHelper.WriteLine("Doing for");
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
                throw new System.Exception();
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
                                throw new System.Exception();
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
                    throw new System.Exception();
                }
                catch (System.Exception e)
                {
                    return (0);
                }
                return (1);
            }
            private int Method()
            {
                try
                {
                    throw new System.Exception();
                }
                catch (System.Exception e)
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
                    System.Exception e = new System.Exception();
                    throw (e);
                }
                catch (System.Exception e)
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
                    throw new System.Exception();
                }
                catch (System.Exception e)
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
                catch (System.Exception e)
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
                    catch (System.Exception e)
                    {
                        OutputHelper.WriteLine("Rethrow");
                        throw;
                    }
                }
                catch (System.Exception e)
                {
                    OutputHelper.WriteLine("Recatch");
                    return (0);
                }
                return (1);
            }
            private void Thrower()
            {
                throw new System.Exception();
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
                        throw new System.Exception();
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
                        throw new System.Exception();
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
                    throw new System.Exception();
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
                throw new System.Exception();
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
                    OutputHelper.WriteLine("System.Exception caught");
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
                    OutputHelper.WriteLine("System.Exception caught");
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
                    OutputHelper.WriteLine("System.Exception caught");
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
                    OutputHelper.WriteLine("System.Exception caught");
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
                    OutputHelper.WriteLine("System.Exception caught");
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
