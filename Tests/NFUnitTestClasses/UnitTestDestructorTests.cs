//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;
using System.Reflection;

namespace NFUnitTestClasses
{
    [TestClass]
    class UnitTestDestructorTests
    {
        // Removing as using something out of mscorlib
        //[TestMethod]
        //public void Destructors3_Test()
        //{
        //    //Ported from Destructors3.cs
        //    Debug.WriteLine(" Section 10.11");
        //    Debug.WriteLine(" Destructors implement the actions required to ");
        //    Debug.WriteLine(" destruct the instances of a class.");
        //    Debug.WriteLine("");
        //    Debug.WriteLine("Note: This test may fail due to lengthy garbage collection, look for Destructor messages in later logs");
        //    Assert.True(DestructorsTestClass3.testMethod());
        //}

        [TestMethod]
        public void Destructors4_Test()
        {
            //Ported from Destructors4.cs
            Debug.WriteLine(" Section 10.11");
            Debug.WriteLine(" Destructors implement the actions required to ");
            Debug.WriteLine(" destruct the instances of a class.");
            Debug.WriteLine("");
            Debug.WriteLine("Note: This test may fail due to lengthy garbage collection, look for Destructor messages in later logs");
            Assert.True(DestructorsTestClass4.testMethod());
        }

        // Removed as using a class out of mscorlib
        //[TestMethod]
        //public void Destructors7_Test()
        //{
        //    //Ported from Destructors7.cs
        //    Debug.WriteLine(" Section 10.12");
        //    Debug.WriteLine(" Destructors are not inherited. Thus, a class");
        //    Debug.WriteLine(" has no other destructors than those that are ");
        //    Debug.WriteLine(" actually declared in the class.");
        //    Debug.WriteLine("");
        //    Debug.WriteLine("Note: This test may fail due to lengthy garbage collection, look for Destructor messages in later logs");
        //    Assert.True(DestructorsTestClass7.testMethod());
        //}

        //class DestructorsTestClass3
        //{

        //    static int intI = 1;

        //    ~DestructorsTestClass3()
        //    {
        //        //Debug.WriteLine("Calling Destructor for Test Class 3");
        //        intI = 2;
        //    }

        //    public static bool testMethod()
        //    {
        //        DestructorsTestClass3 mc = new DestructorsTestClass3();
        //        mc = null;
        //        nanoFramework.Runtime.Native.GC.Run(true);
        //        int sleepTime = 5000;
        //        int slept = 0;
        //        while (intI != 2 && slept < sleepTime)
        //        {
        //            System.Threading.Thread.Sleep(10);
        //            slept += 10;
        //        }
        //        Debug.WriteLine("Thread has slept for");
        //        Debug.WriteLine(slept.ToString());
        //        if (intI == 2)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}


        class DestructorsTestClass4_Base
        {
            public static int intI = 2;
            ~DestructorsTestClass4_Base()
            {
                intI = intI * 2;
                //Debug.WriteLine("Calling Destructor for Test Class 4 Base");
            }
        }

        class DestructorsTestClass4 : DestructorsTestClass4_Base
        {

            ~DestructorsTestClass4()
            {
                intI = intI + 2;
                //Debug.WriteLine("Calling Destructor for Test Class 4");
            }

            public static bool testMethod()
            {
                DestructorsTestClass4 mc = new DestructorsTestClass4();
                mc = null;
                // nanoFramework.Runtime.Native.GC.Run(true);
                int sleepTime = 5000;
                int slept = 0;
                while (intI != 8 && slept < sleepTime)
                {
                    System.Threading.Thread.Sleep(10);
                    slept += 10;
                }
                Debug.WriteLine("Thread has slept for");
                Debug.WriteLine(slept.ToString());
                if (intI == 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class DestructorsTestClass7_Base
        {
            public static int intI = 2;
        }

        class DestructorsTestClass7 : DestructorsTestClass7_Base
        {

            ~DestructorsTestClass7()
            {
                intI = 3;
                //Debug.WriteLine("Calling Destructor for Test Class 7");
            }

            public static bool testMethod()
            {
                DestructorsTestClass7 mc = new DestructorsTestClass7();
                mc = null;
                //nanoFramework.Runtime.Native.GC.Run(true);
                int sleepTime = 5000;
                int slept = 0;
                while (intI != 3 && slept < sleepTime)
                {
                    System.Threading.Thread.Sleep(10);
                    slept += 10;
                }
                Debug.WriteLine("Thread has slept for");
                Debug.WriteLine(slept.ToString());
                if (intI == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
