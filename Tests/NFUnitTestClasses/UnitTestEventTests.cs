//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestClasses
{
    [TestClass]
    class UnitTestEventTests
    {
        [TestMethod]
        public void Events1_Test()
        {
            Debug.WriteLine("This is testing an obsolete event structure, but should pass.");
            Assert.True(EventsTestClass1.testMethod());
        }


        public delegate void EventsTestClass1_EventHandler1();

        public class EventsTestClass1_Event1
        {

            [Obsolete("This is Obsolete")]
            public event EventsTestClass1_EventHandler1 CMyEvent;

            public void Fire()
            {
                if (CMyEvent != null) CMyEvent();
            }
        }

        public class EventsTestClass1_Sub1
        {


            public static void MyMeth() { }

            public static void Main_old()
            {
                EventsTestClass1_Event1 mc = new EventsTestClass1_Event1();
                mc.CMyEvent += new EventsTestClass1_EventHandler1(MyMeth);
                mc.Fire();
            }
        }

        class EventsTestClass1
        {
            public static bool testMethod()
            {
                try
                {
                    EventsTestClass1_Sub1.Main_old();
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
