//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;

namespace NFUnitTestSystemLib
{
    [TestClass]
    class UnitTestReflectionTypeTest
    {
        delegate bool MyDelegate(int i);

        [TestMethod]
        public void SystemReflectionType_ObjectGetType_Test0()
        {
            object o = (object)1;
            Assert.IsType(o.GetType(), typeof(int));

            o = (object)typeof(Type);
            Assert.IsType(o.GetType(), typeof(Type).GetType());

            //o = AppDomain.CurrentDomain.GetAssemblies();
            //fRes &= o.GetType() == typeof(Assembly[]);

            o = new TestClass();
            Assert.IsType(o.GetType(), typeof(TestClass));

            o = new TestStruct();
            Assert.IsType(o.GetType(), typeof(TestStruct));

            o = new MyDelegate(MyDelegateImpl);
            Assert.IsType(o.GetType(), typeof(MyDelegate));

            o = (new MyDelegate(MyDelegateImpl)).Method;

            MethodInfo mi = typeof(UnitTestReflectionTypeTest).GetMethod("MyDelegateImpl", BindingFlags.Static | BindingFlags.NonPublic);
            Assert.IsType(o.GetType(), mi.GetType());
        }


        [TestMethod]
        public void SystemReflectionType_RuntimeType_Test1()
        {
            ArrayList list = new ArrayList();
            int i = 0;

            ///
            /// Test the RuntimeType class members
            /// 
            TestClass cls = new TestClass();

            // Test Type members for a class type
            Type t = cls.GetType();
            Assembly asm = t.Assembly;
            list.Add(asm);
            Assert.AreEqual(((Assembly)list[i]).GetName().Name, "NFUnitTest");
            Assert.AreEqual(asm.GetName().Name, "NFUnitTest");
            Assert.AreEqual(t.Name, "TestClass");
            Assert.AreEqual(t.FullName, "NFUnitTestSystemLib.UnitTestReflectionTypeTest+TestClass");
            Assert.IsType(t.BaseType, typeof(object));
            Assert.IsNull(t.GetElementType());

            MethodInfo[] mis = t.GetMethods();
            Assert.AreEqual(mis[0].Name, "Method1");
            mis = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(mis[0].Name, "Method2");
            Assert.IsNotNull(t.GetMethod("Method1"));
            Assert.IsNotNull(t.GetMethod("Method2", BindingFlags.Instance | BindingFlags.NonPublic));

            FieldInfo[] fis = t.GetFields();
            Assert.AreEqual(fis[0].Name, "m_Field1");
            fis = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(fis[0].Name, "m_Field2");
            Assert.IsNotNull(t.GetField("m_Field1"));
            Assert.IsNotNull(t.GetField("m_Field2", BindingFlags.NonPublic | BindingFlags.Instance));
            Assert.IsNotNull(t.GetConstructor(new Type[] { }));

            Type[] ifaces = t.GetInterfaces();
            Assert.AreEqual(ifaces.Length, 2);
            Assert.AreEqual(ifaces[0].Name, "IInterface1");
            Assert.AreEqual(ifaces[1].Name, "IInterface2");
            Assert.IsTrue(t.IsSubclassOf(typeof(object)));
            i++;

            // test Type members for a struct valuetype
            TestStruct str = new TestStruct();
            t = str.GetType();
            asm = t.Assembly;
            list.Add(asm);
            Assert.AreEqual(((Assembly)list[i]).GetName().Name, "NFUnitTest");
            Assert.AreEqual(asm.GetName().Name, "NFUnitTest");
            Assert.AreEqual(t.Name, "TestStruct");
            Assert.AreEqual(t.FullName, "NFUnitTestSystemLib.UnitTestReflectionTypeTest+TestStruct");
            Assert.IsType(t.BaseType, typeof(ValueType));
            Assert.AreEqual(t.GetInterfaces().Length, 0);
            Assert.IsNull(t.GetElementType());
            i++;

            // test Type members for an Assembly reflection type
            //Assembly asmObj = typeof(TestClass).Assembly;
            //t = asmObj.GetType();
            //asm = t.Assembly;
            //list.Add(asm);
            //Assert.AreEqual(((Assembly)list[i]).GetName().Name, "mscorlib");
            //Assert.AreEqual(asm.GetName().Name, "mscorlib");
            //Assert.AreEqual(t.Name, "Assembly");
            //Assert.AreEqual(t.FullName, "System.Reflection.Assembly");
            //Assert.IsType(t.BaseType, typeof(Object));
            //Assert.AreEqual(t.GetInterfaces().Length, 0);
            //Assert.IsNull(t.GetElementType());

            mis = typeof(TestClass).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            t = mis.GetType();
            Assert.AreEqual(t.Name, "RuntimeMethodInfo[]");
            Assert.AreEqual(t.FullName, "System.Reflection.RuntimeMethodInfo[]");
            Assert.IsType(t.BaseType, typeof(Array));
            Assert.IsTrue(t.GetInterfaces().Length > 0);
            Assert.AreEqual(t.GetElementType().Name, "RuntimeMethodInfo");

            // test Type members for a delegate
            Delegate del = new MyDelegate(MyDelegateImpl);
            t = del.GetType();
            Assert.IsNotNull(t.DeclaringType);
            Assert.AreEqual(t.Name, "MyDelegate");
            Assert.IsType(t.BaseType, typeof(MulticastDelegate));

            // test Type members for an enum
            TestEnum en = TestEnum.Item1;
            t = en.GetType();
            Assert.IsType(t.DeclaringType, typeof(UnitTestReflectionTypeTest));
            Assert.IsTrue( t.IsEnum);
            Assert.IsFalse(t.IsAbstract);
            Assert.IsFalse(t.IsClass);
            Assert.IsFalse(t.IsPublic);
            Assert.IsTrue(t.IsValueType);
        }

        [TestMethod]
        public void SystemReflectionType_SystemType_Test2()
        {
            int[] blah = new int[3];

            Assert.IsTrue(typeof(Array).IsInstanceOfType(blah));
            Assert.IsTrue(typeof(TestStruct[]).IsArray);
            Assert.IsFalse(typeof(Array).IsValueType);
            Assert.IsTrue(typeof(TestStruct).IsValueType);
            Assert.IsTrue(typeof(Type).IsSubclassOf(typeof(MemberInfo)));
            Assert.AreEqual(typeof(Type).GetInterfaces()[0].Name , "IReflect");
            Assert.IsTrue(typeof(MyDelegate).IsInstanceOfType(new MyDelegate(MyDelegateImpl)));

            // Get known type from assembly qualified type name Culture and PublicKeyToken are used by debugger to identify types
            // so we must be able to parse them (even if we through out the culture/key).
            // Type t = Type.GetType("System.Int32, mscorlib, version=4.1.0.0, CultureInfo=enu, PublicKeyToken=null");
            // Assert.IsNotNull(t);
        }

        //------------------- Classes/interfaces/structs used by this test class ---------------------------//

        #region INTERNAL_TEST_CLASSES

        enum TestEnum
        {
            Item1,
            Item2,
            Item3
        };

        private static bool MyDelegateImpl(int i)
        {
            return true;
        }

        public struct TestStruct
        {
            public int Field1;
            public bool Field2;
        }

        interface IInterface1
        {
        }
        interface IInterface2
        {
        }

        class TestClass : IInterface1, IInterface2
        {
            public int m_Field1;
            private float m_Field2;

            public int Method1(bool b)
            {
                m_Field1 = 3;
                return m_Field1;
            }

            private bool Method2(int i)
            {
                m_Field2 = (float)i;
                return true;
            }
        }
        #endregion

    }
}
