// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Reflection;
using nanoFramework.TestFramework;

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
            Assert.IsInstanceOfType(o.GetType(), typeof(int));

            o = (object)typeof(Type);
            Assert.IsInstanceOfType(o.GetType(), typeof(Type).GetType());

            //o = AppDomain.CurrentDomain.GetAssemblies();
            //fRes &= o.GetType() == typeof(Assembly[]);

            o = new TestClass();
            Assert.IsInstanceOfType(o.GetType(), typeof(TestClass));

            o = new TestStruct();
            Assert.IsInstanceOfType(o.GetType(), typeof(TestStruct));

            o = new MyDelegate(MyDelegateImpl);
            Assert.IsInstanceOfType(o.GetType(), typeof(MyDelegate));

            o = (new MyDelegate(MyDelegateImpl)).Method;

            MethodInfo mi = typeof(UnitTestReflectionTypeTest).GetMethod("MyDelegateImpl", BindingFlags.Static | BindingFlags.NonPublic);
            Assert.IsInstanceOfType(o.GetType(), mi.GetType());
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

            OutputHelper.WriteLine("Testing  Type members for a class type");

            // Test Type members for a class type
            Type t = cls.GetType();
            Assembly asm = t.Assembly;
            list.Add(asm);
            Assert.AreEqual("NFUnitTest", ((Assembly)list[i]).GetName().Name);
            Assert.AreEqual("NFUnitTest", asm.GetName().Name);
            Assert.AreEqual("TestClass", t.Name);
            Assert.AreEqual("NFUnitTestSystemLib.UnitTestReflectionTypeTest+TestClass", t.FullName);
            Assert.IsInstanceOfType(t.BaseType, typeof(object));
            Assert.IsNull(t.GetElementType());

            OutputHelper.WriteLine("Testing methods of class type");

            MethodInfo[] mis = t.GetMethods();
            Assert.AreEqual("Method1", mis[0].Name);
            mis = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual("Method2", mis[0].Name);
            Assert.IsNotNull(t.GetMethod("Method1"));
            Assert.IsNotNull(t.GetMethod("Method2", BindingFlags.Instance | BindingFlags.NonPublic));

            OutputHelper.WriteLine("Testing fields of class type");

            FieldInfo[] fis = t.GetFields();
            Assert.AreEqual("m_Field1", fis[0].Name);
            fis = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual("m_Field2", fis[0].Name);
            Assert.IsNotNull(t.GetField("m_Field1"));
            Assert.IsNotNull(t.GetField("m_Field2", BindingFlags.NonPublic | BindingFlags.Instance));
            Assert.IsNotNull(t.GetConstructor(new Type[] { }));

            OutputHelper.WriteLine("Testing interfaces of class type");

            Type[] ifaces = t.GetInterfaces();
            Assert.AreEqual(2, ifaces.Length);
            Assert.AreEqual("IInterface1", ifaces[0].Name);
            Assert.AreEqual("IInterface2", ifaces[1].Name);
            Assert.IsTrue(t.IsSubclassOf(typeof(object)));
            i++;

            OutputHelper.WriteLine("Testing Type members for a struct valuetype");

            // test Type members for a struct valuetype
            TestStruct str = new TestStruct();
            t = str.GetType();
            asm = t.Assembly;
            list.Add(asm);
            Assert.AreEqual("NFUnitTest", ((Assembly)list[i]).GetName().Name);
            Assert.AreEqual("NFUnitTest", asm.GetName().Name);
            Assert.AreEqual("TestStruct", t.Name);
            Assert.AreEqual("NFUnitTestSystemLib.UnitTestReflectionTypeTest+TestStruct", t.FullName);
            Assert.IsInstanceOfType(t.BaseType, typeof(ValueType));
            Assert.AreEqual(0, t.GetInterfaces().Length);
            Assert.IsNull(t.GetElementType());
            i++;

            OutputHelper.WriteLine("Testing Type members for an Assembly reflection type");

            // test Type members for an Assembly reflection type
            //Assembly asmObj = typeof(TestClass).Assembly;
            //t = asmObj.GetType();
            //asm = t.Assembly;
            //list.Add(asm);
            //Assert.AreEqual("mscorlib", ((Assembly)list[i]).GetName().Name);
            //Assert.AreEqual("mscorlib", asm.GetName().Name);
            //Assert.AreEqual("Assembly", t.Name);
            //Assert.AreEqual("System.Reflection.Assembly", t.FullName);
            //Assert.IsInstanceOfType(t.BaseType, typeof(Object));
            //Assert.AreEqual(0, t.GetInterfaces().Length);
            //Assert.IsNull(t.GetElementType());

            OutputHelper.WriteLine("Testing Type members for a MethodInfo reflection type");

            mis = typeof(TestClass).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            t = mis.GetType();
            Assert.AreEqual("RuntimeMethodInfo[]", t.Name);
            Assert.AreEqual("System.Reflection.RuntimeMethodInfo[]", t.FullName);
            Assert.IsInstanceOfType(t.BaseType, typeof(Array));
            Assert.IsTrue(t.GetInterfaces().Length > 0);
            Assert.AreEqual("RuntimeMethodInfo", t.GetElementType().Name);

            OutputHelper.WriteLine("Testing Type members for a delegate");

            // test Type members for a delegate
            Delegate del = new MyDelegate(MyDelegateImpl);
            t = del.GetType();
            Assert.IsNotNull(t.DeclaringType);
            Assert.AreEqual("MyDelegate", t.Name);
            Assert.IsInstanceOfType(t.BaseType, typeof(MulticastDelegate));

            OutputHelper.WriteLine("Testing Type members for an enum");

            // test Type members for an enum
            TestEnum en = TestEnum.Item1;
            t = en.GetType();
            Assert.IsInstanceOfType(typeof(UnitTestReflectionTypeTest), t.DeclaringType);
            Assert.IsTrue(t.IsEnum);
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
            Assert.AreEqual("IReflect", typeof(Type).GetInterfaces()[0].Name);
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
