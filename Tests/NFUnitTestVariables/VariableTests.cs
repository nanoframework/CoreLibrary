//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestVariables
{
    [TestClass]
    class VariableTests
    {
        [Setup]
        public void InitializeVariables()
        {
            Debug.WriteLine("Adding set up for the tests");
        }

        [Cleanup]
        public void CleanUpVariables()
        {
            Debug.WriteLine("Cleaning up after the tests");
        }

        //Variables Test methods
        //The following tests were ported from folder current\test\cases\client\CLR\Conformance\10_classes\Variables
        //S5_range_byte_0.cs,S5_range_byte_1.cs,S5_range_char_0.cs,S5_range_char_1.cs,S5_range_double_0.cs,S5_range_double_1.cs,S5_range_float_0.cs,S5_range_float_1.cs,S5_range_int_0.cs,S5_range_int_1.cs,S5_range_int_3.cs,S5_range_long_0.cs,S5_range_long_1.cs,S5_range_long_3.cs,S5_range_short_0.cs,S5_range_short_1.cs

        //Test Case Calls 
        [TestMethod]
        public void Variables_S5_range_byte_0_Test()
        {
            Debug.WriteLine("S5_range_byte_0.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("byte");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		255Y");
            Variables_TestClass_S5_range_byte_0.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_byte_1_Test()
        {
            Debug.WriteLine("S5_range_byte_1.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("byte");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		0Y");
            Variables_TestClass_S5_range_byte_1.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_char_0_Test()
        {
            Debug.WriteLine("S5_range_char_0.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("char");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		65535");
            Variables_TestClass_S5_range_char_0.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_char_1_Test()
        {
            Debug.WriteLine("S5_range_char_1.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("char");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		0");
            Variables_TestClass_S5_range_char_1.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_double_0_Test()
        {
            Debug.WriteLine("S5_range_double_0.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("double");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		1.7e308d");
            Variables_TestClass_S5_range_double_0.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_double_1_Test()
        {
            Debug.WriteLine("S5_range_double_1.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("double");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		-1.7e308d");
            Variables_TestClass_S5_range_double_1.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_float_0_Test()
        {
            Debug.WriteLine("S5_range_float_0.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("float");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		3.4e38F");
            Variables_TestClass_S5_range_float_0.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_float_1_Test()
        {
            Debug.WriteLine("S5_range_float_1.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("float");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		-3.4e38F");
            Variables_TestClass_S5_range_float_1.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_int_0_Test()
        {
            Debug.WriteLine("S5_range_int_0.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("int");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		2147483647");
            Variables_TestClass_S5_range_int_0.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_int_1_Test()
        {
            Debug.WriteLine("S5_range_int_1.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("int");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		-2147483647");
            Variables_TestClass_S5_range_int_1.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_int_3_Test()
        {
            Debug.WriteLine("S5_range_int_3.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("int");
            Debug.WriteLine("	CompilesOK:	0");
            Debug.WriteLine("	Value:		-2147483648");
            Variables_TestClass_S5_range_int_3.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_long_0_Test()
        {
            Debug.WriteLine("S5_range_long_0.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("long");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		9223372036854775807L");
            Variables_TestClass_S5_range_long_0.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_long_1_Test()
        {
            Debug.WriteLine("S5_range_long_1.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("long");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		-9223372036854775807L");
            Variables_TestClass_S5_range_long_1.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_long_3_Test()
        {
            Debug.WriteLine("S5_range_long_3.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("long");
            Debug.WriteLine("	CompilesOK:	0");
            Debug.WriteLine("	Value:		-9223372036854775808L");
            Variables_TestClass_S5_range_long_3.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_short_0_Test()
        {
            Debug.WriteLine("S5_range_short_0.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("short");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		32767S");
            Variables_TestClass_S5_range_short_0.testMethod();
        }
        [TestMethod]
        public void Variables_S5_range_short_1_Test()
        {
            Debug.WriteLine("S5_range_short_1.sc");
            Debug.WriteLine("This is a variable range test:");
            Debug.WriteLine("short");
            Debug.WriteLine("	CompilesOK:	1");
            Debug.WriteLine("	Value:		-32767S");
            Variables_TestClass_S5_range_short_1.testMethod();
        }

        public class Variables_TestClass_S5_range_byte_0
        {
            public static void Main_old()
            {
                byte var;
                byte var2;
                var = 255;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_byte_1
        {
            public static void Main_old()
            {
                byte var;
                byte var2;
                var = 0;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_char_0
        {
            public static void Main_old()
            {
                char var;
                char var2;
                var = (char)65535;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_char_1
        {
            public static void Main_old()
            {
                char var;
                char var2;
                var = (char)0;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_double_0
        {
            public static void Main_old()
            {
                double var;
                double var2;
                var = 1.7e308d;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_double_1
        {
            public static void Main_old()
            {
                double var;
                double var2;
                var = -1.7e308d;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_float_0
        {
            public static void Main_old()
            {
                float var;
                float var2;
                var = 3.4e38F;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_float_1
        {
            public static void Main_old()
            {
                float var;
                float var2;
                var = -3.4e38F;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_int_0
        {
            public static void Main_old()
            {
                int var;
                int var2;
                var = 2147483647;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_int_1
        {
            public static void Main_old()
            {
                int var;
                int var2;
                var = -2147483647;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_int_3
        {
            public static void Main_old()
            {
                int var;
                int var2;
                var = -2147483648;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_long_0
        {
            public static void Main_old()
            {
                long var;
                long var2;
                var = 9223372036854775807L;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_long_1
        {
            public static void Main_old()
            {
                long var;
                long var2;
                var = -9223372036854775807L;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_long_3
        {
            public static void Main_old()
            {
                long var;
                long var2;
                var = -9223372036854775808L;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_short_0
        {
            public static void Main_old()
            {
                short var;
                short var2;
                var = 32767;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public class Variables_TestClass_S5_range_short_1
        {
            public static void Main_old()
            {
                short var;
                short var2;
                var = -32767;
                var2 = var;
                return;
            }
            public static bool testMethod()
            {
                try
                {
                    Main_old();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

    }
}
