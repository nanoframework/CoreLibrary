// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    class UnitTestReflectionMemberTest
    {
        [TestMethod]
        public void SystemReflectionMemberTests_Properties_Test0()
        {
            TestClass tst = new TestClass();

            ///
            /// Test the PropertyInfo class members
            /// 
            MethodInfo mi = typeof(TestClass).GetMethod("BaseInternalProtectedMethod", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Assert.IsFalse(mi.IsAbstract);
            Assert.IsFalse(mi.IsFinal);
            Assert.IsFalse(mi.IsPublic);
            Assert.IsFalse(mi.IsStatic);
            Assert.IsFalse(mi.IsVirtual);
            Assert.IsType(mi.ReturnType, typeof(object));
            Assert.IsTrue(mi.Invoke(tst, new object[] { 3 }) == null);
            Assert.IsType(mi.DeclaringType, typeof(AbsTestClass));

            mi = typeof(AbsTestClass).GetMethod("AbstractPublicMethod", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Assert.IsTrue(mi.IsAbstract);
            Assert.IsFalse(mi.IsFinal);
            Assert.IsTrue(mi.IsPublic);
            Assert.IsFalse(mi.IsStatic);
            Assert.IsTrue(mi.IsVirtual);
            Assert.IsType(mi.ReturnType, typeof(float));
            Assert.IsTrue((float)mi.Invoke(tst, new object[] { 3 }) == 38.4f);
            Assert.IsType(mi.DeclaringType, typeof(AbsTestClass));

            mi = typeof(TestClass).GetMethod("VirtualInternalMethod", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Assert.IsFalse(mi.IsAbstract);
            Assert.IsFalse(mi.IsFinal);
            Assert.IsFalse(mi.IsPublic);
            Assert.IsFalse(mi.IsStatic);
            Assert.IsTrue(mi.IsVirtual);
            Assert.IsType(mi.ReturnType, typeof(int));
            Assert.IsTrue((int)mi.Invoke(tst, new object[] { true }) == 34);
            Assert.IsType(mi.DeclaringType, typeof(TestClass));

            mi = typeof(TestClass).GetMethod("SealedPublicMethod", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Assert.IsFalse(mi.IsAbstract);
            Assert.IsTrue(mi.IsFinal);
            Assert.IsTrue(mi.IsPublic);
            Assert.IsFalse(mi.IsStatic);
            Assert.IsTrue(mi.IsVirtual);
            Assert.IsType(mi.ReturnType, typeof(bool));
            Assert.IsTrue((bool)mi.Invoke(tst, new object[] { }));
            Assert.IsType(mi.DeclaringType, typeof(TestClass));

            mi = typeof(TestClass).GetMethod("StaticPrivateAbsMethod", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            Assert.IsFalse(mi.IsAbstract);
            Assert.IsFalse(mi.IsFinal);
            Assert.IsFalse(mi.IsPublic);
            Assert.IsTrue(mi.IsStatic);
            Assert.IsFalse(mi.IsVirtual);
            Assert.IsType(mi.ReturnType, typeof(void));
            TestClass.s_WasStaticMethodCalled = false;
            mi.Invoke(tst, new object[] { });
            Assert.IsTrue(TestClass.s_WasStaticMethodCalled);
            Assert.IsType(mi.DeclaringType, typeof(AbsTestClass));

            mi = typeof(TestClass).GetMethod("PublicMethod", BindingFlags.Instance | BindingFlags.Public);
            Assert.IsFalse(mi.IsAbstract);
            Assert.IsTrue(mi.IsFinal);
            Assert.IsTrue(mi.IsPublic);
            Assert.IsFalse(mi.IsStatic);
            Assert.IsTrue(mi.IsVirtual);
            Assert.IsType(mi.ReturnType, typeof(void));
            mi.Invoke(tst, new object[] { });
            Assert.IsType(mi.DeclaringType, typeof(TestClass));

            mi = typeof(TestClass).GetMethod("InternalMethod", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsFalse(mi.IsAbstract);
            Assert.IsFalse(mi.IsFinal);
            Assert.IsFalse(mi.IsPublic);
            Assert.IsFalse(mi.IsStatic);
            Assert.IsFalse(mi.IsVirtual);
            Assert.IsType(mi.ReturnType, typeof(int));
            Assert.IsTrue(1 == (int)mi.Invoke(tst, new object[] { 90.3f }));
            Assert.IsType(mi.DeclaringType, typeof(TestClass));

            mi = typeof(TestClass).GetMethod("PrivateMethod", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsFalse(mi.IsAbstract);
            Assert.IsFalse(mi.IsFinal);
            Assert.IsFalse(mi.IsPublic);
            Assert.IsFalse(mi.IsStatic);
            Assert.IsFalse(mi.IsVirtual);
            Assert.IsType(mi.ReturnType, typeof(float));
            Assert.IsTrue(3.3f == (float)mi.Invoke(tst, new object[] { 92 }));
            Assert.IsType(mi.DeclaringType, typeof(TestClass));
        }

        [TestMethod]
        public void SystemReflectionMemberTests_DelegateMethod_Test1()
        {
            ///
            /// Test the MethodInfo returned from the Delegate.Method property
            /// 

            Delegate del = new MyDelegate(MyDelegateImpl);
            MethodInfo mi = del.Method;

            Assert.IsFalse(mi.IsPublic);
            Assert.IsTrue(mi.IsStatic);
            Assert.IsFalse(mi.IsVirtual);
            Assert.IsFalse(mi.IsAbstract);
            Assert.IsFalse(mi.IsFinal);
            Assert.AreEqual(mi.Name, "MyDelegateImpl");
            Assert.IsType(mi.ReturnType, typeof(bool));
            Assert.IsTrue((bool)mi.Invoke(null, new object[] { 1, 3.3f }));
            Assert.IsType(mi.DeclaringType, typeof(UnitTestReflectionMemberTest));
        }

        [TestMethod]
        public void SystemReflectionMemberTests_ConstructorInfo_Test2()
        {
            ///
            /// Test the ConstructorInfo class members
            /// 
            Type t = typeof(TestClass);

            ConstructorInfo ci = t.GetConstructor(new Type[] { });
            Assert.IsTrue(ci.IsPublic);
            Assert.IsFalse(ci.IsStatic);
            Assert.IsTrue(ci.Invoke(new object[] { }) is TestClass);

            ci = typeof(AbsTestClass).GetConstructor(new Type[] { typeof(float) });
            Assert.IsFalse(ci.IsPublic);
            Assert.IsFalse(ci.IsStatic);
            Assert.IsType(ci.DeclaringType, typeof(AbsTestClass));
            AbsTestClass tst = ci.Invoke(new object[] { 1.2f }) as AbsTestClass;
            Assert.IsNotNull(tst);

            ci = t.GetConstructor(new Type[] { typeof(int) });
            Assert.IsFalse(ci.IsStatic);
            Assert.IsFalse(ci.IsPublic);
            Assert.IsTrue(ci.Invoke(new object[] { 3 }) is TestClass);

            ci = t.GetConstructor(new Type[] { typeof(bool) });
            Assert.IsFalse(ci.IsStatic);
            Assert.IsFalse(ci.IsPublic);
            Assert.IsTrue(ci.Invoke(new object[] { true }) is TestClass);
        }

        [TestMethod]
        public void SystemReflectionMemberTests_FieldInfo_Test3()
        {
            ///
            /// Test the FieldInfo class members
            /// 

            Type t = typeof(TestClass);
            FieldInfo fi = t.GetField("AbsPrivateField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsType(fi.FieldType, typeof(int));
            Assert.IsType(fi.DeclaringType, typeof(AbsTestClass));

            fi = t.GetField("PublicField");
            Assert.IsType(fi.FieldType, typeof(int));
            Assert.IsType(fi.DeclaringType, typeof(TestClass));

            fi = t.GetField("IntProtectedField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsType(fi.FieldType, typeof(float));
            Assert.IsType(fi.DeclaringType, t);

            fi = t.GetField("BoolPrivateField", BindingFlags.Static | BindingFlags.NonPublic);
            Assert.IsType(fi.FieldType, typeof(bool));
            Assert.IsType(fi.DeclaringType, t);

        }

        //--------------------Classes/Interfaces/Delegates used by this test class----------------------//

        #region INTERNAL_TEST_CLASSES
        private static bool MyDelegateImpl(int i, float f)
        {
            return true;
        }

        public delegate bool MyDelegate(int i, float f);

        abstract class AbsTestClass
        {
            int AbsPrivateField;

            public static bool s_WasStaticMethodCalled;

            static AbsTestClass()
            {
                s_WasStaticMethodCalled = false;
            }
            protected AbsTestClass(float f)
            {
                AbsPrivateField = (int)f;
            }

            internal protected object BaseInternalProtectedMethod(int i)
            {
                return null;
            }

            public abstract float AbstractPublicMethod(int i);

            internal virtual int VirtualInternalMethod(bool b)
            {
                return 0;
            }

            public virtual bool SealedPublicMethod()
            {
                return false;
            }

            private static void StaticPrivateAbsMethod()
            {
                s_WasStaticMethodCalled = true;
            }
        }

        interface IBaseInterface
        {
            void PublicMethod();
        }

        private class TestClass : AbsTestClass, IBaseInterface
        {
            public int PublicField;
            internal protected float IntProtectedField;
            private static bool BoolPrivateField;

            public TestClass() : base(3.4f)
            {
                PublicField = 0;
            }

            internal TestClass(int i) : base(45.6f)
            {
                IntProtectedField = i;
            }

            private TestClass(bool b) : base(2.2f)
            {
                BoolPrivateField = b;
            }

            public void PublicMethod()
            {
            }
            public sealed override bool SealedPublicMethod()
            {
                return true;
            }

            internal int InternalMethod(float f)
            {
                return 1;
            }
            protected bool ProtectedMethod(bool b)
            {
                return true;
            }
            private float PrivateMethod(int i)
            {
                return 3.3f;
            }
            public override float AbstractPublicMethod(int i)
            {
                return 38.4f;
            }

            internal override int VirtualInternalMethod(bool b)
            {
                return 34;
            }
        }
        #endregion

    }
}
