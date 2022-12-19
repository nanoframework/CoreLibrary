//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestTypes
{
    [TestClass]
    class UnitTestSubTypeTests
    {
        // Class1 and SubClass1 used for testing type def of inherited classes
        class Class1
        {
            public class SubClass1 
            {
                void Method1()
                {
                
                }
            }

            public SubClass1 Sc1ClassRef = new SubClass1();

        }
        [TestMethod]
        // Test sub-class in the string for GetType(string).  a "+" is used for sub-classes within a class.
        public void SubClassGetTypeValid()
        {
            const string subClass1FullName = "NFUnitTestTypes.UnitTestSubTypeTests+Class1+SubClass1";
            Class1 c1 = new Class1();
            string className = c1.Sc1ClassRef.GetType().FullName;
            Assert.AreEqual(className, subClass1FullName, "The object FullName was not correct");
            Type testType = Type.GetType(subClass1FullName);
            Assert.IsNotNull(testType, $"The Type for {subClass1FullName} could not be parsed");
            Assert.AreEqual(testType.Name, "SubClass1");
            Assert.AreEqual(testType.FullName, subClass1FullName);

        }
        [TestMethod]
        // Test sub-class in the string for GetType(string).  a "+" is used for sub-classes within a class.
        public void SubClassGetTypeInvalid()
        {
            Class1 c1 = new Class1();
            Type testType = Type.GetType("UnitTestSubTypeTests+Class1+SubClass1");   // test without the namespace.  This should NOT work
            Assert.IsNull(testType, "The Type for UnitTestSubTypeTests+Class1+SubClass1 should not parse");

        }

    }
}
