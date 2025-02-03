// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    class UnitTestInitLocalTests
    {
        public interface IEmptyInterface
        {
        }

        class TestObj : IEmptyInterface
        {
            public int Field1;
            public void Method1(int i)
            {
            }
            public TestObj()
            {
                Field1 = 3;
            }

            public TestObj(int field)
            {
                Field1 = field;
            }

            private bool Method2(float f)
            {
                return true;
            }
        }

        [TestMethod]
        public void SystemType1_GetType_Test()
        {
            // Checking reflection types to assure that they are boxed when used as local variables
            // and when they are assigned to non-valuetype containers (which used to crash)

            ArrayList list = new ArrayList();
            int i = 0;
            // First lets check all reflection types (Type, AppDomain, Assembly, FieldInfo, MethodInfo, 
            // ConstructorInfo)
            // NOTE: We add the reflection items to the ArrayList to assure that they can be properly 
            // assigned to a object container (this used to lead to a access violation)
            Type type = typeof(int);
            list.Add(type);
            string name = ((Type)list[i]).Name;
            Assert.AreEqual(name, "Int32");
            i++;

            // No ApDomain in nano
            //AppDomain domain = AppDomain.CurrentDomain;
            //list.Add(domain);
            //name = ((AppDomain)list[i]).FriendlyName;
            //fRes &= name.ToLower() == "default";
            //i++;

            //Assembly asm = domain.GetAssemblies()[0];
            //list.Add(asm);
            //name = ((Assembly)list[i]).GetName().Name;
            //fRes &= name.ToLower() == "mscorlib";
            //i++;

            type = Type.GetType("NFUnitTestSystemLib.UnitTestInitLocalTests+TestObj");
            list.Add(type);
            name = ((Type)list[i]).Name;
            Assert.AreEqual(name, "TestObj");
            i++;

            Type iface = type.GetInterfaces()[0];
            list.Add(iface);
            name = ((Type)list[i]).Name;
            Assert.AreEqual(name, "IEmptyInterface");
            Assert.AreEqual(iface.Name, "IEmptyInterface");
            i++;

            FieldInfo fi = type.GetField("Field1");
            list.Add(fi);
            name = ((FieldInfo)list[i]).Name;
            Assert.AreEqual(name, "Field1");
            Assert.AreEqual(fi.Name, "Field1");
            i++;

            MethodInfo mi = type.GetMethod("Method1");
            list.Add(mi);
            name = ((MethodInfo)list[i]).Name;
            Assert.AreEqual(name, "Method1");
            Assert.AreEqual(mi.Name, "Method1");
            i++;

            ConstructorInfo ci = type.GetConstructor(new Type[] { });
            list.Add(ci);
            name = ((ConstructorInfo)list[i]).Name;
            Assert.AreEqual(name, ".ctor");
            Assert.AreEqual(ci.Name, ".ctor");
            i++;

            // 
            // Now test arrays of reflection types
            // 
            Type[] types = new Type[] { typeof(int), typeof(bool), Type.GetType("NFUnitTestSystemLib.UnitTestInitLocalTests+TestObj") };
            list.Add(types[2]);
            name = ((Type)list[i]).Name;
            Assert.AreEqual(name, "TestObj");
            Assert.AreEqual(types[2].Name, "TestObj");
            i++;

            //AppDomain[] domains = new AppDomain[] { AppDomain.CurrentDomain, AppDomain.CreateDomain("blah") };
            //list.Add(domains[1]);
            //name = ((AppDomain)list[i]).FriendlyName;
            //fRes &= name == "blah";
            //fRes &= domains[1].FriendlyName == "blah";
            //AppDomain.Unload(domains[1]);
            //i++;

            //Assembly[] asms = new Assembly[] { typeof(UnitTestInitLocalTests).Assembly, domains[0].GetAssemblies()[0] };
            //list.Add(asms[0]);
            //name = ((Assembly)list[i]).GetName().Name;
            //fRes &= name == "Microsoft.SPOT.Platform.Tests.Systemlib2";
            //fRes &= asms[0].GetName().Name == "Microsoft.SPOT.Platform.Tests.Systemlib2";
            //i++;

            FieldInfo[] fis = new FieldInfo[] { types[2].GetField("Field1"), type.GetFields()[0] };
            list.Add(fis[0]);
            name = ((FieldInfo)list[i]).Name;
            Assert.AreEqual(name, "Field1");
            Assert.AreEqual(fis[0].Name, "Field1");
            i++;

            MethodInfo[] mis = new MethodInfo[] { type.GetMethods()[2], types[2].GetMethod("Method2", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public) };
            list.Add(mis[1]);
            name = ((MethodInfo)list[i]).Name;
            Assert.AreEqual(name, "Method2");
            Assert.AreEqual(mis[1].Name, "Method2");
            i++;

            ConstructorInfo[] cis = new ConstructorInfo[] { types[2].GetConstructor(new Type[] { }), typeof(TestObj).GetConstructor(new Type[] { typeof(int) }) };
            list.Add(cis[0]);
            name = ((ConstructorInfo)list[i]).Name;
            Assert.AreEqual(name, ".ctor");
            Assert.AreEqual(cis[0].Name, ".ctor");
            i++;

            Array ar = Array.CreateInstance(typeof(Type), 3);
            ((IList)ar)[0] = typeof(Type);
            ((IList)ar)[1] = Type.GetType("System.Collections.ArrayList");

            list.Add(ar.GetValue(1));
            name = ((Type)list[i]).Name;
            Assert.AreEqual(name, "ArrayList");
            Assert.AreEqual(((Type)((IList)ar)[0]).Name, "Type");
            Assert.AreEqual(((Type)ar.GetValue(1)).Name, "ArrayList");
            i++;

            list.Clear();
        }

        [TestMethod]
        public void SystemType1_StructValueTypeReturn_Test()
        {
            Guid g = ReturnGuid();
        }

        [TestMethod]
        public void SystemType1_StructArrayInit_Test()
        {
            Guid[] data = new Guid[] { new Guid() };
            foreach (Guid g2 in data)
            {
                // test to make sure boxing (to call struct method)
                // still works properly
                Assert.IsTrue(Guid.Empty.Equals(g2));
            }

            data = new Guid[] { ReturnGuid(), Guid.NewGuid(), new Guid(344, 45, 24, 24, 4, 42, 42, 4, 44, 22, 4) };
            foreach (Guid g2 in data)
            {
                Assert.IsFalse(Guid.Empty.Equals(g2));
            }
        }

        [TestMethod]
        public void SystemType1_ArrayListToArrayForStruct_Test()
        {
            // make sure boxing of struct value type (Guid) is handled properly
            // this test was a result of a bug found by a customer.
            Guid ret = new Guid();
            ArrayList guidList = new ArrayList();
            guidList.Add(Guid.NewGuid());
            guidList.Add(Guid.NewGuid());
            Guid[] guidArray = (Guid[])guidList.ToArray(typeof(Guid));

            foreach (Guid g in guidArray)
            {
                ret = g;
            }
        }

        //--- internal test methods ---//

        Guid ReturnGuid()
        {
            return Guid.NewGuid();
        }

    }
}
