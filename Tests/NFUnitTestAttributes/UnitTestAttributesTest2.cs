//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestAttributes
{
    [TestClass]
    class UnitTestAttributesTest2
    {
        [TestMethod]
        public void Attrib_attrib017_7_Test()
        {
            Debug.WriteLine("17.4.5 Testing Conditional with DEBUG defined.");
            Assert.True(Attrib_TestClass_attrib017_7.testMethod());
        }
        [TestMethod]
        public void Attrib_attrib017_9b_Test()
        {
            Debug.WriteLine("17.4.5 - Conditional not valid on delegate creation.");
            Assert.True(Attrib_TestClass_attrib017_9b.testMethod());
        }

        public class Attrib_TestClass_attrib017_7_C1
        {
            [Conditional("DEBUG")]
            public static void M()
            {
                Attrib_TestClass_attrib017_7.retval++;
                Debug.WriteLine("Executed Attrib_TestClass_attrib017_7_C1.M");
            }
        }
        public class Attrib_TestClass_attrib017_7_C2
        {
            public static void Attrib_TestClass_attrib017_7()
            {
                Attrib_TestClass_attrib017_7_C1.M();
            }
        }
        public class Attrib_TestClass_attrib017_7
        {
            public static int retval = 0;
            public static int Main_old()
            {
                Attrib_TestClass_attrib017_7_C2.Attrib_TestClass_attrib017_7();
                if (retval != 0)
                {
                    Debug.WriteLine("PASS");
                    return 0;
                }
                Debug.WriteLine("FAIL");
                return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        class Attrib_TestClass_attrib017_9b_C1
        {
            [Conditional("DEBUG")]
            public virtual void M()
            {
                Debug.WriteLine("Class1.M executed");
            }
        }
        class Attrib_TestClass_attrib017_9b_C2 : Attrib_TestClass_attrib017_9b_C1
        {
            public override void M()
            {
                Debug.WriteLine("Class2.M executed");
                base.M();						// base.M is not called!
            }
        }


        class Attrib_TestClass_attrib017_9b_C3
        {
            public static void Attrib_TestClass_attrib017_9b()
            {
                Attrib_TestClass_attrib017_9b_C2 c = new Attrib_TestClass_attrib017_9b_C2();
                c.M();							// Attrib_TestClass_attrib017_9b_C2.M() is called, but Attrib_TestClass_attrib017_9b_C1.M() is not!
                Attrib_TestClass_attrib017_9b_C1 c1 = new Attrib_TestClass_attrib017_9b_C1();
                c1.M();                         // But this time Attrib_TestClass_attrib017_9b_C1.M() is called.
            }
        }
        public class Attrib_TestClass_attrib017_9b
        {
            public static int Main_old()
            {
                Attrib_TestClass_attrib017_9b_C3.Attrib_TestClass_attrib017_9b();
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

    }
}
