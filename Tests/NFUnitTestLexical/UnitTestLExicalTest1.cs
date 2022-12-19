//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#define \u0066endf2

#define \u0066oobar2

#define middle\u0066oobar

#define end\u0066

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestLexical
{
    [TestClass]
    public class UnitTestLExicalTest1
    {
        [TestMethod]
        public void Lexical_comments_01_Test()
        {
            OutputHelper.WriteLine("Section 2.4.4 Test");
            OutputHelper.WriteLine("Verifies valid/invalid comment");
            Assert.IsTrue(Lexical_TestClass_comments_01.testMethod());
        }

        [TestMethod]
        public void Lexical_comments_02_Test()
        {
            OutputHelper.WriteLine("Section 2.4.4 Test");
            OutputHelper.WriteLine("Verifies valid/invalid comment");
            Assert.IsTrue(Lexical_TestClass_comments_02.testMethod());
        }

        [TestMethod]
        public void Lexical_comments_03_Test()
        {
            OutputHelper.WriteLine("Section 2.4.4 Test");
            OutputHelper.WriteLine("Verifies valid/invalid comment");
            Assert.IsTrue(Lexical_TestClass_comments_03.testMethod());
        }

        [TestMethod]
        public void Lexical_comments_04_Test()
        {
            OutputHelper.WriteLine("Section 2.4.4 Test");
            OutputHelper.WriteLine("Verifies valid/invalid comment");
            Assert.IsTrue(Lexical_TestClass_comments_04.testMethod());
        }

        [TestMethod]
        public void Lexical_comments_05_Test()
        {
            OutputHelper.WriteLine("Section 2.4.4 Test");
            OutputHelper.WriteLine("Verifies valid/invalid comment");
            Assert.IsTrue(Lexical_TestClass_comments_05.testMethod());
        }

        [TestMethod]
        public void Lexical_comments_06_Test()
        {
            OutputHelper.WriteLine("Section 2.4.4 Test");
            OutputHelper.WriteLine("Verifies valid/invalid comment");
            Assert.IsTrue(Lexical_TestClass_comments_06.testMethod());
        }

        [TestMethod]
        public void Lexical_comments_07_Test()
        {
            OutputHelper.WriteLine("Section 2.4.4 Test");
            OutputHelper.WriteLine("Verifies valid/invalid comment");
            Assert.IsTrue(Lexical_TestClass_comments_07.testMethod());
        }

        [TestMethod]
        public void Lexical_comments_10_Test()
        {
            OutputHelper.WriteLine("Section 2.4.4 Test");
            OutputHelper.WriteLine("Verifies valid/invalid comment");
            Assert.IsTrue(Lexical_TestClass_comments_10.testMethod());
        }

        [TestMethod]
        public void Lexical_bool_01_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify true works on bools");
            Assert.IsTrue(Lexical_TestClass_bool_01.testMethod());
        }

        [TestMethod]
        public void Lexical_bool_02_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify false works on bools");
            Assert.IsTrue(Lexical_TestClass_bool_02.testMethod());
        }

        [TestMethod]
        public void Lexical_int_01_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify 0 as int literal");
            Assert.IsTrue(Lexical_TestClass_int_01.testMethod());
        }

        [TestMethod]
        public void Lexical_int_02_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify positive int literals");
            Assert.IsTrue(Lexical_TestClass_int_02.testMethod());
        }

        [TestMethod]
        public void Lexical_int_03_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify negative int literals");
            Assert.IsTrue(Lexical_TestClass_int_03.testMethod());
        }

        [TestMethod]
        public void Lexical_int_04_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify negative hex literals");
            Assert.IsTrue(Lexical_TestClass_int_04.testMethod());
        }

        [TestMethod]
        public void Lexical_int_05_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify positive hex literals");
            Assert.IsTrue(Lexical_TestClass_int_05.testMethod());
        }

        [TestMethod]
        public void Lexical_int_06_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify 0 as hex int literal");
            Assert.IsTrue(Lexical_TestClass_int_06.testMethod());
        }

        [TestMethod]
        public void Lexical_intsuffix_01_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("L/l suffix on longs");
            Assert.IsTrue(Lexical_TestClass_intsuffix_01.testMethod());
        }

        [TestMethod]
        public void Lexical_intsuffix_02_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("LU, Ul,uL,ul,LU,Lu,lU,lu suffix on ulongs");
            Assert.IsTrue(Lexical_TestClass_intsuffix_02.testMethod());
        }

        [TestMethod]
        public void Lexical_intsuffix_03_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("LU, Ul,uL,ul,LU,Lu,lU,lu suffix on ulongs");
            Assert.IsTrue(Lexical_TestClass_intsuffix_03.testMethod());
        }

        [TestMethod]
        public void Lexical_intsuffix_04_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("Verify UL,Ul,uL,ul,LU,Lu,lU,lu suffix are of type ulong");
            Assert.IsTrue(Lexical_TestClass_intsuffix_04.testMethod());
        }

        [TestMethod]
        public void Lexical_intsuffix_06_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("Verify L, l suffixes are of type uint");
            Assert.IsTrue(Lexical_TestClass_intsuffix_06.testMethod());
        }

        [TestMethod]
        public void Lexical_intsuffix_07_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("Using the lowercase 'l' suffix should generate a level 4 warning (VS7:86407)");
            Assert.IsTrue(Lexical_TestClass_intsuffix_07.testMethod());
        }

        [TestMethod]
        public void Lexical_suff_typepick_03_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("Verify that literals with l, L suffixes are typed according to spec");
            Assert.IsTrue(Lexical_TestClass_suff_typepick_03.testMethod());
        }

        [TestMethod]
        public void Lexical_real_01_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify (+/-) double double literals");
            Assert.IsTrue(Lexical_TestClass_real_01.testMethod());
        }

        [TestMethod]
        public void Lexical_real_02_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            Assert.IsTrue(Lexical_TestClass_real_02.testMethod());
        }

        [TestMethod]
        public void Lexical_real_03_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify (-/+) non-double double literals");
            Assert.IsTrue(Lexical_TestClass_real_03.testMethod());
        }

        [TestMethod]
        public void Lexical_real_04_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify E and e (-/+) as double literals");
            Assert.IsTrue(Lexical_TestClass_real_04.testMethod());
        }

        [TestMethod]
        public void Lexical_real_05_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify E and e (-/+) as double literals");
            Assert.IsTrue(Lexical_TestClass_real_05.testMethod());
        }

        [TestMethod]
        public void Lexical_real_06_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify E and e (-/+) as double literals");
            Assert.IsTrue(Lexical_TestClass_real_06.testMethod());
        }

        [TestMethod]
        public void Lexical_char_01_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify keyboard symbols as chars");
            Assert.IsTrue(Lexical_TestClass_char_01.testMethod());
        }

        [TestMethod]
        public void Lexical_char_02_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify all escape sequences in section 2.4.9.4");
            Assert.IsTrue(Lexical_TestClass_char_02.testMethod());
        }

        [TestMethod]
        public void Lexical_char_03_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("Hex encoded Unicode characters");
            Assert.IsTrue(Lexical_TestClass_char_03.testMethod());
        }

        [TestMethod]
        public void Lexical_realsuffix_01_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("D/d suffix on double literals");
            OutputHelper.WriteLine("Real suffixes");
            Assert.IsTrue(Lexical_TestClass_realsuffix_01.testMethod());
        }

        [TestMethod]
        public void Lexical_realsuffix_02_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("F/f suffix on float literals");
            OutputHelper.WriteLine("Real suffixes");
            Assert.IsTrue(Lexical_TestClass_realsuffix_02.testMethod());
        }

        [TestMethod]
        public void Lexical_string_01_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify escape sequences in string literals");
            Assert.IsTrue(Lexical_TestClass_string_01.testMethod());
        }

        [TestMethod]
        public void Lexical_string_02_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify hex escape sequences in string literals");
            Assert.IsTrue(Lexical_TestClass_string_02.testMethod());
        }

        [TestMethod]
        public void Lexical_string_03_Test()
        {
            OutputHelper.WriteLine("Section 2.4.9 Test");
            OutputHelper.WriteLine("verify null strings work");
            Assert.IsTrue(Lexical_TestClass_string_03.testMethod());
        }

        [TestMethod]
        public void Lexical_pre_001_Test()
        {
            OutputHelper.WriteLine("Section 2.3Preprocessing");
            OutputHelper.WriteLine("simple pre processor");
            Assert.IsTrue(Lexical_TestClass_pre_001.testMethod());
        }

        [TestMethod]
        public void Lexical_pre_004_Test()
        {
            OutputHelper.WriteLine("Section 2.3Preprocessing");
            OutputHelper.WriteLine("Verify that class name namespace isn't searched");
            Assert.IsTrue(Lexical_TestClass_pre_004.testMethod());
        }

        [TestMethod]
        public void Lexical_pre_005_Test()
        {
            OutputHelper.WriteLine("Section 2.3Preprocessing");
            OutputHelper.WriteLine("Verify that invalid syntax doesn't mess up compiler in non-ifdef sections");
            Assert.IsTrue(Lexical_TestClass_pre_005.testMethod());
        }

        [TestMethod]
        public void Lexical_pre_008_Test()
        {
            OutputHelper.WriteLine("Section 2.3Preprocessing");
            OutputHelper.WriteLine("Verify #elif and #else");
            Assert.IsTrue(Lexical_TestClass_pre_008.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_09_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("#warning verification");
            Assert.IsTrue(Lexical_TestClass_preproc_09.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_30_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verifying comments and #preprocessor items");
            OutputHelper.WriteLine("This define should not be included	#define TEST ");
            Assert.IsTrue(Lexical_TestClass_preproc_30.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_38_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verify the code that is skipped because of an #if is not checked by compiler at all");
            Assert.IsTrue(Lexical_TestClass_preproc_38.testMethod());
        }

        [TestMethod]
        public void Lexical_line_02_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("#line: Valid integer-literal passed to #line should work correctly with a real warning");
            Assert.IsTrue(Lexical_TestClass_line_02.testMethod());
        }

        [TestMethod]
        public void Lexical_line_03_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("#line: Valid integer-literal passed to #line should work correctly with a #warning directive");
            Assert.IsTrue(Lexical_TestClass_line_03.testMethod());
        }

        [TestMethod]
        public void Lexical_line_06_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("#line: Valid integer-literal/string-literal passed to #line should work correctly with a real warning");
            Assert.IsTrue(Lexical_TestClass_line_06.testMethod());
        }

        [TestMethod]
        public void Lexical_line_07_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("#line: Valid integer-literal/string-literal passed to #line should work correctly with a #warning directive");
            Assert.IsTrue(Lexical_TestClass_line_07.testMethod());
        }

        [TestMethod]
        public void Lexical_line_26_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("#line: Should work cleanly inside an #if-#endif block that evaluates to false");
            Assert.IsTrue(Lexical_TestClass_line_26.testMethod());
        }

        [TestMethod]
        public void Lexical_line_35_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("#line: #line default in a false #if block should compile cleanly");
            Assert.IsTrue(Lexical_TestClass_line_35.testMethod());
        }

        [TestMethod]
        public void Lexical_region_01_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Make sure #region works without banner text");
            Assert.IsTrue(Lexical_TestClass_region_01.testMethod());
        }

        [TestMethod]
        public void Lexical_region_02_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Make sure #region works with banner text");
            Assert.IsTrue(Lexical_TestClass_region_02.testMethod());
        }

        [TestMethod]
        public void Lexical_region_05_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Nesting a #region inside another should work ");
            Assert.IsTrue(Lexical_TestClass_region_05.testMethod());
        }

        [TestMethod]
        public void Lexical_region_06_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Nesting five #region blocks should compile successfully ");
            Assert.IsTrue(Lexical_TestClass_region_06.testMethod());
        }

        [TestMethod]
        public void Lexical_region_07_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Nesting two #region blocks within a single #region block should compile successfully ");
            Assert.IsTrue(Lexical_TestClass_region_07.testMethod());
        }

        [TestMethod]
        public void Lexical_region_10_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Make sure #region works with banner text enclosed in double-quotes");
            Assert.IsTrue(Lexical_TestClass_region_10.testMethod());
        }

        [TestMethod]
        public void Lexical_region_11_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("A single-line comment following a #region should compile successfully");
            Assert.IsTrue(Lexical_TestClass_region_11.testMethod());
        }

        [TestMethod]
        public void Lexical_region_12_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("A single-line comment following an #endregion should compile successfully");
            Assert.IsTrue(Lexical_TestClass_region_12.testMethod());
        }

        [TestMethod]
        public void Lexical_region_15_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Any text following the #endregion directive should be ignored");
            Assert.IsTrue(Lexical_TestClass_region_15.testMethod());
        }

        [TestMethod]
        public void Lexical_lineterm_01_Test()
        {
            OutputHelper.WriteLine("Section 2.4 Lexical Analysis");
            OutputHelper.WriteLine("Test different ways to end a line with semi-colon");
            Assert.IsTrue(Lexical_TestClass_lineterm_01.testMethod());
        }

        [TestMethod]
        public void Lexical_atkeyword_03_Test()
        {
            OutputHelper.WriteLine("Section 2.4 Lexical Analysis - Keywords");
            OutputHelper.WriteLine("The identifiers @test and test should refer to the same variable");
            Assert.IsTrue(Lexical_TestClass_atkeyword_03.testMethod());
        }

        [TestMethod]
        public void Lexical_atkeyword_04_Test()
        {
            OutputHelper.WriteLine("Section 2.4 Lexical Analysis - Keywords");
            OutputHelper.WriteLine("Verify that 'if' can be an identifier using unicode escape sequences as well as an @keyword");
            Assert.IsTrue(Lexical_TestClass_atkeyword_04.testMethod());
        }

        [TestMethod]
        public void Lexical_atkeyword_05_Test()
        {
            OutputHelper.WriteLine("Section 2.4 Lexical Analysis - Keywords");
            OutputHelper.WriteLine("Verify that prefixing an identifer that is prefixed by a double underscore does not generate warning");
            Assert.IsTrue(Lexical_TestClass_atkeyword_05.testMethod());
        }

        [TestMethod]
        public void Lexical_ident_01_Test()
        {
            OutputHelper.WriteLine("Section 2.4.7 Identifiers");
            OutputHelper.WriteLine("identifier-start-character can be alphabetic");
            Assert.IsTrue(Lexical_TestClass_ident_01.testMethod());
        }

        [TestMethod]
        public void Lexical_ident_02_Test()
        {
            OutputHelper.WriteLine("Section 2.4.7 Identifiers");
            OutputHelper.WriteLine("identifier-start-character can be an underscore");
            Assert.IsTrue(Lexical_TestClass_ident_02.testMethod());
        }

        [TestMethod]
        public void Lexical_ident_03_Test()
        {
            OutputHelper.WriteLine("Section 2.4.7 Identifiers");
            OutputHelper.WriteLine("identifier-part-character can be a number");
            Assert.IsTrue(Lexical_TestClass_ident_03.testMethod());
        }

        [TestMethod]
        public void Lexical_ident_04_Test()
        {
            OutputHelper.WriteLine("Section 2.4.7 Identifiers");
            OutputHelper.WriteLine("identifier-part-character can be a number (in the middle)");
            Assert.IsTrue(Lexical_TestClass_ident_04.testMethod());
        }

        [TestMethod]
        public void Lexical_ident_05_Test()
        {
            OutputHelper.WriteLine("Section 2.4.2 Identifiers");
            OutputHelper.WriteLine("Identifiers that start with double underscores (__) should not generate a warning/error though it used to");
            Assert.IsTrue(Lexical_TestClass_ident_05.testMethod());
        }

        [TestMethod]
        public void Lexical_ident_06_Test()
        {
            OutputHelper.WriteLine("Section 2.4.2 Identifiers");
            OutputHelper.WriteLine("Identifiers that have embedded double underscores (__) should generate a warning/error though it used to");
            Assert.IsTrue(Lexical_TestClass_ident_06.testMethod());
        }

        [TestMethod]
        public void Lexical_ident_07_Test()
        {
            OutputHelper.WriteLine("Section 2.4.2 Identifiers");
            OutputHelper.WriteLine("Identifiers that end with double underscores (__) should generate a warning/error though it used to");
            Assert.IsTrue(Lexical_TestClass_ident_07.testMethod());
        }
        [TestMethod]
        public void Lexical_nullunicode_01_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("A \\u0000 within comments should not stop compiler from reading to EOF");
            Assert.IsTrue(Lexical_TestClass_nullunicode_01.testMethod());
        }

        [TestMethod]
        public void Lexical_nullunicode_03_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("A \\u0000 in a string should be equal to \x0000 and \0");
            Assert.IsTrue(Lexical_TestClass_nullunicode_03.testMethod());
        }

        [TestMethod]
        public void Lexical_nullunicode_04_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("A \\u0000 is ignored if within preprocessor-excluded code");
            Assert.IsTrue(Lexical_TestClass_nullunicode_04.testMethod());
        }

        [TestMethod]
        public void Lexical_unicode_02_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("A simple program that is saved as utf-8 with Notepad compiles and runs correctly.");
            Assert.IsTrue(Lexical_TestClass_unicode_02.testMethod());
        }

        [TestMethod]
        public void Lexical_unicode_04_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Displaying a unicode character with OutputHelper.WriteLine(().ToString())");
            Assert.IsTrue(Lexical_TestClass_unicode_04.testMethod());
        }

        [TestMethod]
        public void Lexical_unicode_05_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Displaying a unicode character with OutputHelper.WriteLine(().ToString())");
            OutputHelper.WriteLine("Since the correct language is not installed on my machine, should get a 'QQQ' as output");
            Assert.IsTrue(Lexical_TestClass_unicode_05.testMethod());
        }

        [TestMethod]
        public void Lexical_unicode_06_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Identifier whose name is defined with \\uXXXX works correctly (Bug 111180)");
            Assert.IsTrue(Lexical_TestClass_unicode_06.testMethod());
        }

        [TestMethod]
        public void Lexical_unicode_07_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Identifier whose name starts with \\uXXXX works correctly");
            Assert.IsTrue(Lexical_TestClass_unicode_07.testMethod());
        }

        [TestMethod]
        public void Lexical_unicode_08_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Identifier whose name has a \\uXXXX in the middle of it works correctly");
            Assert.IsTrue(Lexical_TestClass_unicode_08.testMethod());
        }

        [TestMethod]
        public void Lexical_unicode_09_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Identifier whose name ends with a \\uXXXX works correctly ");
            Assert.IsTrue(Lexical_TestClass_unicode_09.testMethod());
        }

        [TestMethod]
        public void Lexical_unicode_10_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Unicode escape sequence to start preprocessor identifier");
            OutputHelper.WriteLine("Bug #33538 - Fixed");
            Assert.IsTrue(Lexical_TestClass_unicode_10.testMethod());
        }

        [TestMethod]
        public void Lexical_unicode_11_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Unicode escape sequence to start preprocessor identifier");
            OutputHelper.WriteLine("Bug #33538 - Fixed");
            Assert.IsTrue(Lexical_TestClass_unicode_11.testMethod());
        }

        [TestMethod]
        public void Lexical_unicode_12_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Unicode escape sequence to start preprocessor identifier");
            OutputHelper.WriteLine("Bug #33538 - Fixed");
            Assert.IsTrue(Lexical_TestClass_unicode_12.testMethod());
        }

        [TestMethod]
        public void Lexical_unicode_13_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Unicode escape sequence in middle of a #define (#de\\u0066ine)");
            OutputHelper.WriteLine("Bug #33538 - Fixed");
            Assert.IsTrue(Lexical_TestClass_unicode_13.testMethod());
        }

        [TestMethod]
        public void Lexical_unicode_17_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("The literal \\u0000 should not be interpreted as a unicode escape sequence");
            Assert.IsTrue(Lexical_TestClass_unicode_17.testMethod());
        }

        [TestMethod]
        public void Lexical_uni8digit_01_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Identifier whose name is defined with \\uXXXXXXXX works correctly");
            Assert.IsTrue(Lexical_TestClass_uni8digit_01.testMethod());
        }

        [TestMethod]
        public void Lexical_uni8digit_02_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Using OutputHelper.WriteLine with \\uXXXXXXXX works correctly");
            Assert.IsTrue(Lexical_TestClass_uni8digit_02.testMethod());
        }

        [TestMethod]
        public void Lexical_uni8digit_03_Test()
        {
            OutputHelper.WriteLine("Section 2.5 Lexical Analysis");
            OutputHelper.WriteLine("Verify valid boundaries of values for \\uXXXXXXXX work correctly");
            Assert.IsTrue(Lexical_TestClass_uni8digit_03.testMethod());
        }

        [TestMethod]
        public void Lexical_atstrings_01_Test()
        {
            OutputHelper.WriteLine("Back-Quoted String Test");
            OutputHelper.WriteLine("Newlines should be valid within @-quoted string literals");
            Assert.IsTrue(Lexical_TestClass_atstrings_01.testMethod());
        }

        [TestMethod]
        public void Lexical_atstrings_02_Test()
        {
            OutputHelper.WriteLine("Back-Quoted String Test");
            OutputHelper.WriteLine("Unicode escape sequences are not processed within @-quoted string literals");
            Assert.IsTrue(Lexical_TestClass_atstrings_02.testMethod());
        }

        [TestMethod]
        public void Lexical_atstrings_03_Test()
        {
            OutputHelper.WriteLine("Back-Quoted String Test");
            OutputHelper.WriteLine("Slash escape sequences are not processed within @-quoted string literals");
            Assert.IsTrue(Lexical_TestClass_atstrings_03.testMethod());
        }

        [TestMethod]
        public void Lexical_atstrings_04_Test()
        {
            OutputHelper.WriteLine("Back-Quoted String Test");
            OutputHelper.WriteLine("Passing @-quoted strings to OutputHelper.WriteLine(().ToString()) should work");
            Assert.IsTrue(Lexical_TestClass_atstrings_04.testMethod());
        }

        [TestMethod]
        public void Lexical_mscombo_01_Test()
        {
            OutputHelper.WriteLine("XML Doc Test (Just lexical tests, no output validation)");
            OutputHelper.WriteLine("Combination of multi and single line xml doc comments");
            Assert.IsTrue(Lexical_TestClass_mscombo_01.testMethod());
        }

        [TestMethod]
        public void Lexical_mscombo_05_Test()
        {
            OutputHelper.WriteLine("XML Doc Test (Just lexical tests, no output validation)");
            OutputHelper.WriteLine("Combination of multi and single line xml doc comments");
            Assert.IsTrue(Lexical_TestClass_mscombo_05.testMethod());
        }

        //Compiled Test Cases 
        public class Lexical_TestClass_comments_01
        {
            /* This is a comment */
            public static void Main_old(String[] args) { }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_comments_02
        {
            // This is a comment
            public static void Main_old(String[] args) { }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_comments_03
        {
            // This is a comment //
            public static void Main_old(String[] args) { }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_comments_04
        {
            /* This is a comment 
	           This is a comment
	        */
            public static void Main_old(String[] args) { }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_comments_05
        {
            /* This is a comment 
	           This is a comment */
            public static void Main_old(String[] args) { }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_comments_06
        {
            /* This is a comment 
	        // This is a comment
	           This is a comment */
            public static void Main_old(String[] args) { }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_comments_07
        {
            /* This is a comment 
	        // This is a comment */
            public static void Main_old(String[] args) { }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_comments_10
        {
            // /* This is a comment 
            public static void Main_old(String[] args) { }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_bool_01
        {
            public static void Main_old(String[] args)
            {
                bool test1;
                bool test2;
                test1 = true;
                test2 = test1;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_bool_02
        {
            public static void Main_old(String[] args)
            {
                bool test1;
                bool test2;
                test1 = false;
                test2 = test1;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_int_01
        {
            public static void Main_old(String[] args)
            {
                int test1;
                int test2;
                test1 = 0;
                test2 = test1;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_int_02
        {
            public static void Main_old(String[] args)
            {
                int test1;
                int test2;
                test1 = 10;
                test2 = test1;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_int_03
        {
            public static void Main_old(String[] args)
            {
                int test1;
                int test2;
                test1 = -10;
                test2 = test1;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_int_04
        {
            public static void Main_old(String[] args)
            {
                int test1;
                int test2;
                test1 = -0xF;
                test2 = test1;
                OutputHelper.WriteLine((test2).ToString());
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_int_05
        {
            public static void Main_old(String[] args)
            {
                int test1;
                int test2;
                test1 = 0xF;
                test2 = test1;
                OutputHelper.WriteLine((test2).ToString());
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_int_06
        {
            public static void Main_old(String[] args)
            {
                int test1;
                int test2;
                test1 = 0x0;
                test2 = test1;
                OutputHelper.WriteLine((test2).ToString());
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_intsuffix_01
        {
            public static void Main_old(String[] args)
            {
                long test1;
                long test2;
                test1 = 10L;
                test2 = test1;
                test1 = 10L;
                test2 = test1;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_intsuffix_02
        {
            public static void Main_old(String[] args)
            {
                ulong test1;
                ulong test2;
                test1 = 10LU;
                test2 = test1;
                test1 = 10Ul;
                test2 = test1;
                test1 = 10uL;
                test2 = test1;
                test1 = 10ul;
                test2 = test1;
                test1 = 10LU;
                test2 = test1;
                test1 = 10Lu;
                test2 = test1;
                test1 = 10LU;
                test2 = test1;
                test1 = 10Lu;
                test2 = test1;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_intsuffix_03
        {
            public static void Main_old(String[] args)
            {
                uint test1;
                uint test2;
                test1 = 10u;
                test2 = test1;
                test1 = 10U;
                test2 = test1;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_intsuffix_04
        {
            public static int Main_old()
            {
                int result = 0;
                if (10UL is ulong) result += 0; else result += 1;
                if (10Ul is ulong) result += 0; else result += 1;
                if (10uL is ulong) result += 0; else result += 1;
                if (10ul is ulong) result += 0; else result += 1;
                if (10LU is ulong) result += 0; else result += 1;
                if (10Lu is ulong) result += 0; else result += 1;
                if (10LU is ulong) result += 0; else result += 1;
                if (10Lu is ulong) result += 0; else result += 1;

                OutputHelper.WriteLine((result).ToString());
                return result;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Lexical_TestClass_intsuffix_06
        {
            public static int Main_old(String[] args)
            {
                int result = 0;
                if (10L is long) result += 0; else result += 1;
                if (10L is long) result += 0; else result += 1;
                return result;
            }
            public static bool testMethod()
            {
                if (Main_old(null) != 0)
                    return false;
                else
                    return true;
            }
        }
        public class Lexical_TestClass_intsuffix_07
        {
            public static void Main_old()
            {
                long test1;
                long test2;
                test1 = 10L;
                test2 = test1;
                test1 = 10L;
                test2 = test1;
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_suff_typepick_03
        {
            public static int Main_old(String[] args)
            {
                int result = 0;
                // these should all be considered of type long (lowercase suffix)
                if (-9223372036854775808L is long) result += 0; else result += 1;
                if (9223372036854775807L is long) result += 0; else result += 1;
                // these should all be considered of type long (uppercase suffix)
                if (-9223372036854775808L is long) result += 0; else result += 1;
                if (9223372036854775807L is long) result += 0; else result += 1;
                // these should all be considered of type ulong (lowercase suffix)
                if (9223372036854775808L is ulong) result += 0; else result += 1;
                if (18446744073709551615L is ulong) result += 0; else result += 1;
                // these should all be considered of type ulong (uppercase suffix)
                if (9223372036854775808L is ulong) result += 0; else result += 1;
                if (18446744073709551615L is ulong) result += 0; else result += 1;
                return result;
            }
            public static bool testMethod()
            {
                if (Main_old(null) != 0)
                    return false;
                else
                    return true;
            }
        }
        public class Lexical_TestClass_real_01
        {
            public static void Main_old(String[] args)
            {
                double test1, test2;
                test1 = 9.99;
                test2 = -9.99;
                test1 = test2;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_real_02
        {
            public static void Main_old(String[] args)
            {
                double test1, test2;
                test1 = .99;
                test2 = -.99;
                test1 = test2;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_real_03
        {
            public static void Main_old(String[] args)
            {
                double test1, test2;
                test1 = 99;
                test2 = -99;
                test1 = test2;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_real_04
        {
            public static void Main_old(String[] args)
            {
                double test1, test2, test3;
                test1 = 9.99e5;
                test2 = -9.99E-5;
                test3 = -9.99E+5;
                test1 = test2;
                test2 = test3;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_real_05
        {
            public static void Main_old(String[] args)
            {
                double test1, test2, test3;
                test1 = .99e5;
                test2 = -.99E-5;
                test3 = -.99E+5;
                test1 = test2;
                test2 = test3;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_real_06
        {
            public static void Main_old(String[] args)
            {
                double test1, test2, test3;
                test1 = 99e5;
                test2 = -99E-5;
                test3 = -99E+5;
                test1 = test2;
                test2 = test3;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_char_01
        {
            public static void Main_old(String[] args)
            {
                char test, getter;

                test = 'a';
                test = 'A';
                test = '1';
                test = '0';
                test = '9';
                test = '!';
                test = '@';
                test = '#';
                test = '$';
                test = '%';
                test = '^';
                test = '&';
                test = '*';
                test = '(';
                test = ')';
                test = '-';
                test = '=';
                test = '_';
                test = '+';
                test = '`';
                test = '~';
                test = '{';
                test = '}';
                test = '[';
                test = ']';
                test = '|';
                test = '"';
                test = ':';
                test = ';';
                test = ',';
                test = '.';
                test = '/';
                test = '<';
                test = '>';
                getter = test;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_char_02
        {
            public static void Main_old(String[] args)
            {
                char test, getter;

                test = '\'';
                test = '\"';
                test = '\\';
                test = '\0';
                test = '\a';
                test = '\b';
                test = '\f';
                test = '\n';
                test = '\r';
                test = '\t';
                test = '\v';
                getter = test;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_char_03
        {
            public static void Main_old(String[] args)
            {
                char test, getter;

                test = '\x0027';
                test = '\x0022';
                test = '\x005C';
                test = '\x0000';
                test = '\x0007';
                test = '\x0008';
                test = '\x000C';
                test = '\x000A';
                test = '\x000D';
                test = '\x0009';
                test = '\x000B';

                getter = test;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_realsuffix_01
        {
            public static void Main_old(String[] args)
            {
                double test1;
                double test2;
                test1 = -9.99D;
                test2 = 9.99d;
                test1 = .99D;
                test2 = -.99d;
                test1 = 9D;
                test2 = -9d;
                test1 = 9.99E5D;
                test2 = -9.99e-5d;
                test1 = .99e+5D;
                test2 = -9E-5d;
                test2 = test1;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_realsuffix_02
        {
            public static void Main_old(String[] args)
            {
                float test1;
                float test2;
                test1 = -9.99F;
                test2 = 9.99f;
                test1 = .99F;
                test2 = -.99f;
                test1 = 9F;
                test2 = -9f;
                test1 = 9.99E5F;
                test2 = -9.99e-5f;
                test1 = .99e+5F;
                test2 = -9E-5f;
                test2 = test1;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_string_01
        {
            public static void Main_old(String[] args)
            {
                String test1;
                test1 = "asdfjkl;\nasdfjkl;";
                OutputHelper.WriteLine((test1).ToString());
                test1 = "\"testing\'";
                OutputHelper.WriteLine((test1).ToString());
                test1 = "escape seq at end\\";
                OutputHelper.WriteLine((test1).ToString());
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_string_02
        {
            public static void Main_old(String[] args)
            {
                String test1;
                test1 = "asdfjkl;\x000Aasdfjkl;";
                OutputHelper.WriteLine((test1).ToString());
                test1 = "\x0022testing\x0027";
                OutputHelper.WriteLine((test1).ToString());
                test1 = "escape seq at end\x005C";
                OutputHelper.WriteLine((test1).ToString());
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_string_03
        {
            public static void Main_old(String[] args)
            {
                String test1, test2;
                test1 = null;
                test2 = test1;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }


        public class Lexical_TestClass_pre_001
        {
            public static int Main_old(string[] args)
            {
                int i = 2;
#if true
                i = 0;
#endif
#if false
	i = 1;
#endif
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }
        }
        public class Lexical_TestClass_pre_004
        {
            public static int Main_old(string[] args)
            {
                int i = 0;
#if Lexical_TestClass_pre_004 
	i = 1;
#endif
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }
        }
        public class Lexical_TestClass_pre_005
        {
            public static int Main_old(string[] args)
            {
                int i = 0;
#if false
	skdjf ksdklfj mcxnvsdh 9-u23kjd f0120 skdc.zxcnv
	sdjfu239nzjnv,mciw -32poduf.zxcnv djfs9a]du
#if true
	this shouldn't even be looked at.  Except for counting up the #if/#endif pairs
#else
	This should be skipped too!
#endif
#if false
	this shouldn't even be looked at.  Except for counting up the #if/#endif pairs
#else
	This should be skipped too!
#endif
	This should also be ignored
#endif
                return (i);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }
        }

        /*
                public class Lexical_TestClass_pre_006
                {
                    public static int Main_old(string[] args)
                    {
                        int i = 0;
        #warning Klaatu barada nikto
        #if false
        #if true
        #error This wasn't supposed to trigger
        #else
        #error This wasn't supposed to trigger either
        #endif
        #endif
                        return (i);
                    }
                    public static bool testMethod()
                    {
                        return (Main_old(null) == 0);
                    }
                }
        */
        public class Lexical_TestClass_pre_008
        {
            public static int Main_old(string[] args)
            {
                int i = 2;
#if false
#error false is true?
#elif true
                i--;
#else
#error Else shouldn't trigger here
#endif
#if false
#error false is still true?
#elif foobar
#error foobar wasn't supposed to be defined
#else
                i--;
#endif
                return (i > 0 ? 1 : 0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }
        }
        class Lexical_TestClass_preproc_09
        {
            public static void Main_old(String[] args)
            {
#warning This is a WARNING!
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }




        class Lexical_TestClass_preproc_30
        {
            public static void Main_old(String[] args)
            {
#if TEST
			OutputHelper.WriteLine("Bad");
#else
                OutputHelper.WriteLine("Good");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_preproc_38
        {
            public static void Main_old(String[] args)
            {
#if foo
			this code should be completely skipped
#else
                OutputHelper.WriteLine("Else triggered");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_line_02
        {
            public static void Main_old()
            {
#line 13
                int a = 3;
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_line_03
        {
            public static void Main_old()
            {
#line 13
#warning This is a warning
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_line_06
        {
            public static void Main_old()
            {
#line 13 "myfile.cs"
                int a = 3;
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }


        public class Lexical_TestClass_line_07
        {
            public static void Main_old()
            {
#line 13 "myfile.cs"
#warning This is a warning
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_line_26
        {
            public static void Main_old()
            {
#if false
#line 13
        short s = 123456;       
#endif
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_line_35
        {
            public static void Main_old()
            {
#if false
#line default
        short s1 = 123456;   
#endif
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }



        public class Lexical_TestClass_region_01
        {
            public static void Main_old()
            {
                #region
                OutputHelper.WriteLine("This works!");
                #endregion
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_region_02
        {
            public static void Main_old()
            {
                #region This is the banner text
                OutputHelper.WriteLine("This works!");
                #endregion
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_region_05
        {
            public static void Main_old()
            {
                #region
                OutputHelper.WriteLine("1");
                #region
                OutputHelper.WriteLine("2");
                #endregion
                OutputHelper.WriteLine("3");
                #endregion
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_region_06
        {
            public static void Main_old()
            {
                #region
                OutputHelper.WriteLine("1");
                #region
                OutputHelper.WriteLine("2");
                #region
                OutputHelper.WriteLine("3");
                #region
                OutputHelper.WriteLine("4");
                #region
                OutputHelper.WriteLine("5");
                #endregion
                OutputHelper.WriteLine("6");
                #endregion
                OutputHelper.WriteLine("7");
                #endregion
                OutputHelper.WriteLine("8");
                #endregion
                OutputHelper.WriteLine("9");
                #endregion
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_region_07
        {
            public static void Main_old()
            {
                #region
                OutputHelper.WriteLine("1");
                #region
                OutputHelper.WriteLine("2");
                #endregion
                OutputHelper.WriteLine("3");
                #region
                OutputHelper.WriteLine("4");
                #endregion
                OutputHelper.WriteLine("5");
                #endregion
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_region_10
        {
            public static void Main_old()
            {
                #region "This is the banner text"
                OutputHelper.WriteLine("This works!");
                #endregion
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_region_11
        {
            public static void Main_old()
            {
                #region // This is a single-line comment
                OutputHelper.WriteLine("This works!");
                #endregion
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_region_12
        {
            public static void Main_old()
            {
                #region
                OutputHelper.WriteLine("This works!");
                #endregion // This is a single-line comment
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }




        public class Lexical_TestClass_region_15
        {
            public static void Main_old()
            {
                #region
                OutputHelper.WriteLine("This works!");
                #endregion This text should be ignored
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_lineterm_01
        {
            public static void Main_old(String[] args)
            {
                OutputHelper.WriteLine("1");			// normal
                OutputHelper.WriteLine("2");		// space between
                OutputHelper.WriteLine("3")
                ;								// ; on the next line
                OutputHelper.WriteLine("4")
                                      // comment in between
                                      ;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_atkeyword_03
        {
            public static void Main_old(String[] args)
            {
                int @test;
                test = 5;
                OutputHelper.WriteLine((@test).ToString());
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_atkeyword_04
        {
            static int Main_old()
            {
                string \u0069f;
                @if = "Hello, world";
                OutputHelper.WriteLine((i\u0066).ToString());

                if (@if == "Hello, world")
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Lexical_TestClass_atkeyword_05
        {
            static void Main_old()
            {
                int @__test;
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        public class Lexical_TestClass_ident_01
        {
            public static void Main_old(String[] args)
            {
                int alpha = 4;
                int Alpha = 5;
                Alpha = alpha;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        public class Lexical_TestClass_ident_02
        {
            public static void Main_old(String[] args)
            {
                int _alpha = 4;
                int _Alpha = 5;
                _Alpha = _alpha;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }





        public class Lexical_TestClass_ident_03
        {
            public static void Main_old(String[] args)
            {
                int alpha4 = 4;
                int Alpha3 = 5;
                Alpha3 = alpha4;
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_ident_04
        {
            static void Main_old()
            {
                int alpha4a = 4;
                int Alpha3a = 5;
                Alpha3a = alpha4a;
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_ident_05
        {
            static void Main_old()
            {
                int __alpha4 = 4;
                int __Alpha3 = 5;
                __Alpha3 = __alpha4;
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_ident_06
        {
            static void Main_old()
            {
                int x__alpha4 = 4;
                int x__Alpha3 = 5;
                x__Alpha3 = x__alpha4;
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_ident_07
        {
            static void Main_old()
            {
                int alpha4__ = 4;
                int Alpha3__ = 5;
                Alpha3__ = alpha4__;
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_nullunicode_01
        {
            public static void Main_old()
            {
                // This should not stop the compiler from moving on \u0000

                OutputHelper.WriteLine("Worked");
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_nullunicode_03
        {
            public static int Main_old()
            {
                string first = "This string\0 should show";
                string second = "This string\u0000 should show";
                string third = "This string\x0000 should show";
                if ((first == second) && (second == third))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Lexical_TestClass_nullunicode_04
        {
            public static int Main_old()
            {
#if NOTDEFINED

			\u0000  // This should be ignored	

#endif
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        // <StdHeader/>
        class Lexical_TestClass_unicode_02
        {
            public static void Main_old()
            {
                OutputHelper.WriteLine("Worked!");
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }




        class Lexical_TestClass_unicode_04
        {
            public static void Main_old()
            {
                OutputHelper.WriteLine("\u0057");
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_unicode_05
        {
            public static void Main_old()
            {
                OutputHelper.WriteLine("\u0701");
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_unicode_06
        {
            public static void Main_old()
            {
                int \u0057ash;
                Wash = 3;
                OutputHelper.WriteLine((Wash).ToString());
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_unicode_07
        {
            public static void Main_old()
            {
                int \u0391Lpha;  // \u0391 is the capital greek letter Alpha
                \u0391Lpha = 3;
                OutputHelper.WriteLine((\u0391Lpha).ToString());
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_unicode_08
        {
            public static void Main_old()
            {
                int start\u0391Lpha;  // \u0391 is the capital greek letter Alpha
                start\u0391Lpha = 3;
                OutputHelper.WriteLine((start\u0391Lpha).ToString());
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }


        class Lexical_TestClass_unicode_09
        {
            public static void Main_old()
            {
                int lpha\u0391;  // \u0391 is the capital greek letter Alpha
                lpha\u0391 = 3;
                OutputHelper.WriteLine((lpha\u0391).ToString());
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }


        class Lexical_TestClass_unicode_17
        {
            public static void Main_old()
            {
                string s = "\\u0000";
                OutputHelper.WriteLine((s).ToString());
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }


        class Lexical_TestClass_uni8digit_01
        {
            public static void Main_old()
            {
                int \U00000057ash;
                Wash = 3;
                OutputHelper.WriteLine((Wash).ToString());
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_uni8digit_02
        {
            static void Main_old()
            {
                OutputHelper.WriteLine("\U00000057ash");
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_uni8digit_03
        {
            static void Main_old()
            {
                string a = "\U00000000";
                string b = "\U0010FFFF";
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_atstrings_01
        {
            public const string hello = @"hel
lo";
            public static void Main_old()
            {
                OutputHelper.WriteLine((hello).ToString());
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_atstrings_02
        {
            public static string a = @"hello, world!";
            public static string b = @"\u0068ello, world!";
            public static void Main_old()
            {
                OutputHelper.WriteLine((a).ToString());
                OutputHelper.WriteLine((b).ToString());
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_atstrings_03
        {
            public static string a = @"Hello,\nworld";
            public static string b = @"Hello,\tworld";
            public static void Main_old()
            {
                OutputHelper.WriteLine((a).ToString());
                OutputHelper.WriteLine((b).ToString());
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_atstrings_04
        {
            public static void Main_old()
            {
                OutputHelper.WriteLine(@"Hello, world!");
                OutputHelper.WriteLine(@"Testing");
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_mscombo_01
        {

            /// This is the summary

            public int Field = 0;
            static void Main_old() { }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_mscombo_05
        {

            /// This is the summary 

            public int Field = 0;
            static void Main_old() { }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }


        class Lexical_TestClass_unicode_10
        {
            public static void Main_old()
            {
#if foobar2
                OutputHelper.WriteLine("Worked!");
#endif
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_unicode_11
        {
            public static void Main_old()
            {
#if middlefoobar
                OutputHelper.WriteLine("Worked!");
#endif
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_unicode_12
        {
            public static void Main_old()
            {
#if endf
                OutputHelper.WriteLine("Worked!");
#endif
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }
        class Lexical_TestClass_unicode_13
        {
            public static void Main_old()
            {
#if endf2
                OutputHelper.WriteLine("Worked!");
#endif
            }
            public static bool testMethod()
            {
                Main_old();
                return true;
            }
        }

    }
}
