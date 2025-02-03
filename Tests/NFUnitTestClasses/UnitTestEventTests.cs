// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestClasses
{
    [TestClass]
    class UnitTestEventTests
    {
        [TestMethod]
        public void Events1_Test()
        {
            // This is testing an obsolete event structure, but should pass.
            Assert.IsTrue(EventsTestClass1.testMethod());
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
