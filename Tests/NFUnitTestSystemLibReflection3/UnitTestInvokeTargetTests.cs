// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Expected values come from running the same code on .NET 10.
    [TestClass]
    public class UnitTestInvokeTargetTests
    {
        public class ItInstance
        {
            public int F = 3;

            public string NoThis()
            {
                return "nothis";
            }

            public string UsesThis()
            {
                return "uses" + F;
            }

            public virtual string Virt()
            {
                return "base";
            }

            public int AddOne(int a)
            {
                return a + 1;
            }

            public static string Static()
            {
                return "static";
            }
        }

        public class ItDerived : ItInstance
        {
            public override string Virt()
            {
                return "derived";
            }
        }

        public class ItOther
        {
        }

        public interface ItFoo
        {
            string Foo();
        }

        public class ItFooImpl : ItFoo
        {
            public string Foo()
            {
                return "foo";
            }
        }

        public struct ItStruct
        {
            public int X;

            public string Show()
            {
                return "S" + X;
            }

            public string Const()
            {
                return "c";
            }
        }

        public class ItGeneric<T>
        {
            public string M()
            {
                return "gm";
            }

            public static string StaticM()
            {
                return "gsm";
            }

            public string G<U>()
            {
                return "gg";
            }
        }

        private static void AssertTargetException(MethodInfo method, object target, object[] arguments = null)
        {
            Assert.ThrowsException(typeof(TargetException), () => method.Invoke(target, arguments));
        }

        [TestMethod]
        public void InstanceMethod_NullTarget_ThrowsTargetException()
        {
            Type type = typeof(ItInstance);

            AssertTargetException(type.GetMethod("NoThis"), null);
            AssertTargetException(type.GetMethod("UsesThis"), null);
            AssertTargetException(type.GetMethod("Virt"), null);
            AssertTargetException(type.GetMethod("AddOne"), null, new object[] { 1 });
        }

        [TestMethod]
        public void InstanceMethod_RightTarget_Runs()
        {
            Type type = typeof(ItInstance);
            ItInstance instance = new ItInstance();

            Assert.AreEqual("nothis", (string)type.GetMethod("NoThis").Invoke(instance, null));
            Assert.AreEqual("uses3", (string)type.GetMethod("UsesThis").Invoke(instance, null));
            Assert.AreEqual(2, (int)type.GetMethod("AddOne").Invoke(instance, new object[] { 1 }));
            Assert.AreEqual("derived", (string)type.GetMethod("Virt").Invoke(new ItDerived(), null));
        }

        [TestMethod]
        public void InstanceMethod_WrongTarget_ThrowsTargetException()
        {
            MethodInfo noThis = typeof(ItInstance).GetMethod("NoThis");
            MethodInfo virt = typeof(ItInstance).GetMethod("Virt");

            AssertTargetException(virt, new ItOther());
            AssertTargetException(noThis, new ItOther());
            AssertTargetException(noThis, "x");
            AssertTargetException(noThis, 5);
        }

        [TestMethod]
        public void StaticMethod_IgnoresTarget()
        {
            MethodInfo method = typeof(ItInstance).GetMethod("Static");

            Assert.AreEqual("static", (string)method.Invoke(null, null));
            Assert.AreEqual("static", (string)method.Invoke(new ItOther(), null));
            Assert.AreEqual("static", (string)method.Invoke(new ItInstance(), null));
        }

        [TestMethod]
        public void InterfaceMethod_NullOrWrongTarget_ThrowsTargetException()
        {
            MethodInfo method = typeof(ItFoo).GetMethod("Foo");

            Assert.AreEqual("foo", (string)method.Invoke(new ItFooImpl(), null));
            AssertTargetException(method, new ItOther());
            AssertTargetException(method, null);
        }

        [TestMethod]
        public void StructMethod_NullOrWrongTarget_ThrowsTargetException()
        {
            ItStruct value = new ItStruct();
            value.X = 4;

            MethodInfo show = typeof(ItStruct).GetMethod("Show");
            MethodInfo constant = typeof(ItStruct).GetMethod("Const");

            Assert.AreEqual("S4", (string)show.Invoke(value, null));
            AssertTargetException(show, null);
            AssertTargetException(constant, null);
            AssertTargetException(show, new ItOther());
            AssertTargetException(show, 5);
        }

        [TestMethod]
        public void GenericTypeMethod_NullOrWrongTarget_ThrowsTargetException()
        {
            MethodInfo method = typeof(ItGeneric<int>).GetMethod("M");
            MethodInfo staticMethod = typeof(ItGeneric<int>).GetMethod("StaticM");

            Assert.AreEqual("gm", (string)method.Invoke(new ItGeneric<int>(), null));
            AssertTargetException(method, new ItGeneric<string>());
            AssertTargetException(method, null);
            AssertTargetException(method, new ItOther());
            Assert.AreEqual("gsm", (string)staticMethod.Invoke(null, null));
        }

        [TestMethod]
        public void GenericMethod_NullTarget_ThrowsTargetException()
        {
            MethodInfo open = typeof(ItGeneric<int>).GetMethod("G");
            MethodInfo closed = open.MakeGenericMethod(typeof(string));

            Assert.AreEqual("gg", (string)closed.Invoke(new ItGeneric<int>(), null));
            AssertTargetException(closed, null);
            Assert.ThrowsException(typeof(InvalidOperationException), () => open.Invoke(new ItGeneric<int>(), null));
        }

        [TestMethod]
        public void Constructor_TwoArgumentInvoke_NullTarget_ThrowsTargetException()
        {
            ConstructorInfo constructor = typeof(ItInstance).GetConstructor(new Type[0]);

            Assert.ThrowsException(typeof(TargetException), () => constructor.Invoke(null, null));
            Assert.ThrowsException(typeof(TargetException), () => constructor.Invoke(new ItOther(), null));
        }
    }
}
