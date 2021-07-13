//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#define while //Lexical_TestClass_pre_009

#define True1 //Lexical_TestClass_pre_012
#define True2
#define False1
#undef False1
#undef False1
#undef False2

//Lexical_TestClass_pre_013
#define foo// Should work fine
#define bar // As should this
#define aaa
#define bbb
#undef	aaa// Should Work
#undef	bbb// Should also work
#if !foo
#error !foo
#endif
#if !bar
#error !bar
#endif
#if aaa
#error aaa
#endif
#if bbb
#error bbb
#endif

#define TESTDEF //Lexical_TestClass_preproc_03

#define TESTDEF3 //Lexical_TestClass_preproc_04
#define TESTDEF2
#undef TESTDEF3


#define FOO //Lexical_TestClass_preproc_05
#if FOO
#define BAR
#endif

#define FOO2 //Lexical_TestClass_preproc_06
#undef FOO2
#undef FOO2

#define FOO3 //Lexical_TestClass_preproc_07
#undef BAR3


#define TEST //Lexical_TestClass_preproc_15-25,32

#define TEST2 //Lexical_TestClass_preproc_17-23,32


#define for //Lexical_TestClass_preproc_39


using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestLexical
{
    [TestClass]
    class UnitTestLexicalTest2
    {
        [TestMethod]
        public void Lexical_pre_009_Test()
        {
            OutputHelper.WriteLine("Section 2.3Preprocessing");
            OutputHelper.WriteLine("Verify #define and #undef");
            Assert.True(Lexical_TestClass_pre_009.testMethod());
        }

        [TestMethod]
        public void Lexical_pre_012_Test()
        {
            OutputHelper.WriteLine("Section 2.3Preprocessing");
            OutputHelper.WriteLine("Verify #if operators and parens");
            Assert.True(Lexical_TestClass_pre_012.testMethod());
        }

        [TestMethod]
        public void Lexical_pre_013_Test()
        {
            OutputHelper.WriteLine("Section 2.3Preprocessing");
            OutputHelper.WriteLine("Verify # commands with comments");
            Assert.True(Lexical_TestClass_pre_013.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_03_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("#define/#undef - verify #define works");
            Assert.True(Lexical_TestClass_preproc_03.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_04_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("#define/#undef - verify #undef works");
            Assert.True(Lexical_TestClass_preproc_04.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_05_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Exact example used in spec definition - 2.3.1");
            Assert.True(Lexical_TestClass_preproc_05.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_06_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Using #undef on a non-existing identifier compiles fine");
            Assert.True(Lexical_TestClass_preproc_06.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_07_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Nested #if's");
            Assert.True(Lexical_TestClass_preproc_07.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_15_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verify the ! operator on #identifiers");
            Assert.True(Lexical_TestClass_preproc_15.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_16_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verify the ! operator on #identifiers with parenthesis");
            Assert.True(Lexical_TestClass_preproc_16.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_17_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verify the double ampersand operator works");
            Assert.True(Lexical_TestClass_preproc_17.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_18_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verify the double ampersand operator works with parentheses");
            Assert.True(Lexical_TestClass_preproc_18.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_19_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verify the || operator works ");
            Assert.True(Lexical_TestClass_preproc_19.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_20_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verify the || operator works with parentheses");
            Assert.True(Lexical_TestClass_preproc_20.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_21_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verify the == operator works with/without parentheses");
            Assert.True(Lexical_TestClass_preproc_21.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_22_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verify the != operator works with/without parentheses");
            Assert.True(Lexical_TestClass_preproc_22.testMethod());
        }
        [TestMethod]
        public void Lexical_preproc_23_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Grouping operators: ! double ampersand || != == true false");
            Assert.True(Lexical_TestClass_preproc_23.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_24_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verifying comments and #preprocessor items");
            Assert.True(Lexical_TestClass_preproc_24.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_25_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verifying comments and #preprocessor items");
            Assert.True(Lexical_TestClass_preproc_25.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_31_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verifying comments and #preprocessor items");
            Assert.True(Lexical_TestClass_preproc_31.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_32_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verify the usage of #elif");
            Assert.True(Lexical_TestClass_preproc_32.testMethod());
        }

        [TestMethod]
        public void Lexical_preproc_39_Test()
        {
            OutputHelper.WriteLine("Section 2.3 Preprocessing");
            OutputHelper.WriteLine("Verify that a # keyword (i.e. for) can be used as a #preprocessor identifier");
            Assert.True(Lexical_TestClass_preproc_39.testMethod());
        }

        //Compiled Test Cases 

        public class Lexical_TestClass_pre_009
        {
            public static int Main_old(string[] args)
            {
                int i = 2;
#if while
		while (--i > 0)
			;
#endif
                return (i > 0 ? 1 : 0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }
        }

        public class Lexical_TestClass_pre_012
        {
            public static int Main_old(string[] args)
            {
                int i = 6;
#if True1 == true
		i--;
#endif
#if False1 == false
                i--;
#endif
#if false
#error #elif True2 == True1
#elif True2 == True1
                i--;
#else
#error #else #elif True2 == True1
#endif
#if (True1 != false) && ((False1) == False2) && (true || false)
		i--;
#else
#error #if (True != false) && ((False1) == False2) && (true || false)
#endif
#if ((true == True1) != (false && true))
		i--;
#else
#error ((true == True1) != (false && true))
#endif
#if !(!(!!(true))) != false
                i--;
#else
#error !(!(!!(true))) != false
#endif
                return (i > 0 ? 1 : 0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }
        }

        public class Lexical_TestClass_pre_013
        {
            public static int Main_old(string[] args)
            {
                int i = 0;
                return (i > 0 ? 1 : 0);
            }
            public static bool testMethod()
            {
                return (Main_old(null) == 0);
            }
        }

        public class Lexical_TestClass_preproc_03
        {
            public static void Main_old(String[] args)
            {
                OutputHelper.WriteLine("Starting!");
#if TESTDEF
                OutputHelper.WriteLine("Good");
#else
                OutputHelper.WriteLine("Bad");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }

        public class Lexical_TestClass_preproc_04
        {
            public static void Main_old(String[] args)
            {
                OutputHelper.WriteLine("Starting!");
#if TESTDEF3
			OutputHelper.WriteLine("TESTDEF3 is defined");
#else
                OutputHelper.WriteLine("TESTDEF3 is not defined");
#endif
#if TESTDEF2
                OutputHelper.WriteLine("TESTDEF2 is defined");
#else
                OutputHelper.WriteLine("TESTDEF2 not defined");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }


#if BAR
        class Lexical_TestClass_preproc_05
        {
            public static void Main_old(String[] args) { }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
#endif



        class Lexical_TestClass_preproc_06
        {
            public static void Main_old(String[] args) { }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }


        class Lexical_TestClass_preproc_07
        {
            public static void Main_old(String[] args)
            {
                OutputHelper.WriteLine("Starting:");
#if FOO3
                OutputHelper.WriteLine("Inside FOO");
#if BAR3
			OutputHelper.WriteLine("Inside BAR");
#else
                OutputHelper.WriteLine("Inside BAR's else");
#endif
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_preproc_15
        {
            public static void Main_old(String[] args)
            {
#if !TEST
                OutputHelper.WriteLine("Problem");
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

        class Lexical_TestClass_preproc_16
        {
            public static void Main_old(String[] args)
            {
#if !(TEST)
                OutputHelper.WriteLine("Problem");
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

        class Lexical_TestClass_preproc_17
        {
            public static void Main_old(String[] args)
            {
#if TEST && TEST2
                OutputHelper.WriteLine("Good");
#endif
#if TEST && TEST3
			OutputHelper.WriteLine("Problem");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_preproc_18
        {
            public static void Main_old(String[] args)
            {
#if (TEST && TEST2)
                OutputHelper.WriteLine("Good");
#endif
#if (TEST && TEST3)
			OutputHelper.WriteLine("Problem");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_preproc_19
        {
            public static void Main_old(String[] args)
            {
#if TEST || TEST2
                OutputHelper.WriteLine("Good");
#endif
#if TEST3 || TEST2
                OutputHelper.WriteLine("Good");
#endif
#if TEST3 || TEST4
			OutputHelper.WriteLine("Problem");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_preproc_20
        {
            public static void Main_old(String[] args)
            {
#if (TEST || TEST2)
                OutputHelper.WriteLine("Good");
#endif
#if (TEST3 || TEST2)
                OutputHelper.WriteLine("Good");
#endif
#if (TEST3 || TEST4)
			OutputHelper.WriteLine("Problem");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_preproc_21
        {
            public static void Main_old(String[] args)
            {
#if TEST == TEST2
                OutputHelper.WriteLine("Good");
#endif
#if (TEST == TEST2)
                OutputHelper.WriteLine("Good");
#endif
#if TEST==TEST2
                OutputHelper.WriteLine("Good");
#endif
#if (TEST == TEST3)
                OutputHelper.WriteLine("Bad");
#endif
#if TEST3 == TEST
                OutputHelper.WriteLine("Bad");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_preproc_22
        {
            public static void Main_old(String[] args)
            {
#if TEST != TEST2
			OutputHelper.WriteLine("Bad");
#endif
#if (TEST != TEST2)
			OutputHelper.WriteLine("Bad");
#endif
#if TEST!=TEST2
			OutputHelper.WriteLine("Bad");
#endif
#if (TEST != TEST3)
                OutputHelper.WriteLine("Good");
#endif
#if TEST3 != TEST
                OutputHelper.WriteLine("Good");
#endif
#if TEST3!=TEST
                OutputHelper.WriteLine("Good");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_preproc_23
        {
            public static void Main_old(String[] args)
            {
#if (TEST && TEST2) || (TEST3 || TEST4)
                OutputHelper.WriteLine("1 - Good");
#endif
#if (TEST3 == TEST4) || (TEST == TEST2)
                OutputHelper.WriteLine("2 - Good");
#endif
#if (TEST != TEST3) && (TEST2 != TEST4)
                OutputHelper.WriteLine("3 - Good");
#endif
#if (! TEST4) && (TEST2 == TEST)
                OutputHelper.WriteLine("4 - Good");
#endif
#if (TEST == true) && (TEST2 != false)
                OutputHelper.WriteLine("5 - Good");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_preproc_24
        {
            public static void Main_old(String[] args)
            {
#if TEST
                OutputHelper.WriteLine("Good");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_preproc_25
        {
            public static void Main_old(String[] args)
            {
#if TEST
                OutputHelper.WriteLine("Good");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_preproc_31
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
        class Lexical_TestClass_preproc_32
        {
            public static void Main_old(String[] args)
            {
#if TEST3
			OutputHelper.WriteLine("Bad");
#elif TEST2 && TEST
                OutputHelper.WriteLine("Good");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }
        class Lexical_TestClass_preproc_39
        {
            public static void Main_old(String[] args)
            {
#if for
                for (int x = 0; x < 3; x++)
                    OutputHelper.WriteLine("Worked");
#else
                OutputHelper.WriteLine("It should not be showing this!");
#endif
            }
            public static bool testMethod()
            {
                Main_old(null);
                return true;
            }
        }

    }
}
