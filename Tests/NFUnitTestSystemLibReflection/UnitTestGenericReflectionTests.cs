// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Each test uses its own types, so no test depends on state or on a closed TypeSpec row that another one names.
    [TestClass]
    public class UnitTestGenericReflectionTests
    {
        // GetType

        [TestMethod]
        public void GetType_OfGenericInstance_IsTheClosedType()
        {
            var instance = new GrIdentity<int>();

            Assert.IsTrue(typeof(GrIdentity<int>) == instance.GetType());
            Assert.IsTrue(typeof(GrIdentity<string>) != instance.GetType());
        }

        [TestMethod]
        public void GetType_OfGenericInstance_HasItsGenericArguments()
        {
            Type[] arguments = new GrIdentityArguments<string>().GetType().GetGenericArguments();

            Assert.AreEqual(1, arguments.Length);
            Assert.IsTrue(arguments[0] == typeof(string));
        }

        // MethodInfo.ReturnType

        [TestMethod]
        public void ReturnType_OfTOnClosedType_IsTheArgument()
        {
            Assert.IsTrue(typeof(GrReturnInt<int>).GetMethod("get_Value").ReturnType == typeof(int));
            Assert.IsTrue(typeof(GrReturnString<string>).GetMethod("get_Value").ReturnType == typeof(string));
        }

        [TestMethod]
        public void ReturnType_OfTFromAnInstance_IsTheArgument()
        {
            var instance = new GrReturnInstance<int>();

            Assert.IsTrue(instance.GetType().GetMethod("get_Value").ReturnType == typeof(int));
        }

        [TestMethod]
        public void ReturnType_OfTArray_IsTheArgumentArray()
        {
            Assert.IsTrue(typeof(GrReturnArray<int>).GetMethod("get_Values").ReturnType == typeof(int[]));
        }

        [TestMethod]
        public void ReturnType_OfTBoundToGenericType_IsTheClosedType()
        {
            Type returned = typeof(GrReturnNested<GrNestedItem<int>>).GetMethod("get_Value").ReturnType;

            Assert.IsTrue(returned == typeof(GrNestedItem<int>));
            Assert.IsTrue(returned != typeof(GrNestedItem<string>));
        }

        [TestMethod]
        public void ReturnType_OfClosedGenericOnPlainClass_IsTheClosedType()
        {
            Assert.IsTrue(typeof(GrReturnPlain).GetMethod("Get").ReturnType == typeof(GrPlainItem<int>));
        }

        [TestMethod]
        public void ReturnType_OfDifferentInstantiations_Differ()
        {
            Assert.IsTrue(
                typeof(GrReturnTwo<int>).GetMethod("get_Value").ReturnType !=
                typeof(GrReturnTwo<string>).GetMethod("get_Value").ReturnType);
        }

        [TestMethod]
        public void GetParameters_OfTOnClosedType_HaveTheArgument()
        {
            ParameterInfo[] parameters = typeof(GrParameter<string>).GetMethod("set_Value").GetParameters();

            Assert.AreEqual(1, parameters.Length);
            Assert.IsTrue(parameters[0].ParameterType == typeof(string));
        }

        // FieldInfo.FieldType

        [TestMethod]
        public void FieldType_OfTOnClosedType_IsTheArgument()
        {
            Assert.IsTrue(typeof(GrFieldTypeInt<int>).GetField("Item").FieldType == typeof(int));
            Assert.IsTrue(typeof(GrFieldTypeString<string>).GetField("Item").FieldType == typeof(string));
        }

        [TestMethod]
        public void FieldType_OfTFromAnInstance_IsTheArgument()
        {
            var instance = new GrFieldTypeInstance<GrFieldItem>();

            Assert.IsTrue(instance.GetType().GetField("Item").FieldType == typeof(GrFieldItem));
        }

        // FieldInfo.SetValue and GetValue

        [TestMethod]
        public void SetValue_OnTField_WithTheArgument_Works()
        {
            var holder = new GrSetInt<int>();

            typeof(GrSetInt<int>).GetField("Item").SetValue(holder, 42);

            Assert.AreEqual(42, holder.Item);
        }

        [TestMethod]
        public void SetValue_OnTField_WithAString_Works()
        {
            var holder = new GrSetString<string>();

            holder.GetType().GetField("Item").SetValue(holder, "text");

            Assert.AreEqual("text", holder.Item);
        }

        [TestMethod]
        public void SetValue_OnTField_WithAnotherType_IsRejected()
        {
            var holder = new GrSetWrong<int>();
            FieldInfo field = typeof(GrSetWrong<int>).GetField("Item");

            Assert.ThrowsException(typeof(Exception), () => { field.SetValue(holder, "text"); });
        }

        [TestMethod]
        public void SetValue_WithTheFieldOfAnotherInstantiation_IsRejected()
        {
            var holder = new GrSetOther<int>();
            FieldInfo field = typeof(GrSetOther<string>).GetField("Item");

            Assert.ThrowsException(typeof(Exception), () => { field.SetValue(holder, "text"); });
        }

        [TestMethod]
        public void GetValue_OfTField_ReturnsTheStoredValue()
        {
            var holder = new GrGet<int> { Item = 7 };

            Assert.AreEqual(7, (int)typeof(GrGet<int>).GetField("Item").GetValue(holder));
        }

        // static fields

        [TestMethod]
        public void StaticField_ReadThroughReflection_ReturnsTheStoredValue()
        {
            _ = new GrStaticRead<int>();
            GrStaticRead<int>.Count = 5;

            Assert.AreEqual(5, (int)typeof(GrStaticRead<int>).GetField("Count").GetValue(null));
        }

        [TestMethod]
        public void StaticField_ReadThroughReflection_IsPerInstantiation()
        {
            _ = new GrStaticPer<int>();
            _ = new GrStaticPer<string>();
            GrStaticPer<int>.Count = 1;
            GrStaticPer<string>.Count = 2;

            Assert.AreEqual(1, (int)typeof(GrStaticPer<int>).GetField("Count").GetValue(null));
            Assert.AreEqual(2, (int)typeof(GrStaticPer<string>).GetField("Count").GetValue(null));
        }

        [TestMethod]
        public void StaticField_WrittenThroughReflection_IsSeenByTheCode()
        {
            _ = new GrStaticWrite<int>();

            typeof(GrStaticWrite<int>).GetField("Count").SetValue(null, 9);

            Assert.AreEqual(9, GrStaticWrite<int>.Count);
        }

        [TestMethod]
        public void StaticField_ReadBeforeAnyInstance_RunsTheStaticConstructor()
        {
            Assert.AreEqual(7, (int)typeof(GrStaticCctor<int>).GetField("Seeded").GetValue(null));
        }

        [TestMethod]
        public void StaticField_OfGenericDefinition_IsNotSupported()
        {
            FieldInfo field = typeof(GrStaticDefinition<int>).GetField("Count");
            Type definition = typeof(GrStaticDefinition<int>).GetGenericTypeDefinition();

            Assert.IsNotNull(field);
            Assert.ThrowsException(typeof(NotSupportedException), () => { _ = definition.GetField("Count").GetValue(null); });
        }

        // constructors and invoke

        [TestMethod]
        public void ConstructorInvoke_StaticCounterInConstructor_Works()
        {
            ConstructorInfo constructor = typeof(GrCounter<int>).GetConstructor(new Type[] { });

            constructor.Invoke(null);
            constructor.Invoke(null);

            Assert.AreEqual(2, GrCounter<int>.Created);
        }

        [TestMethod]
        public void ConstructorInvoke_CreatesTheRequestedInstantiation()
        {
            object created = typeof(GrCreated<int>).GetConstructor(new Type[] { }).Invoke(null);

            Assert.IsTrue(created is GrCreated<int>);
            Assert.IsFalse(created is GrCreated<string>);
            Assert.IsTrue(created.GetType() == typeof(GrCreated<int>));
        }

        [TestMethod]
        public void Invoke_SetterOfT_WithTheArgument_Works()
        {
            var holder = new GrInvokeString<string>();

            typeof(GrInvokeString<string>).GetMethod("set_Value").Invoke(holder, new object[] { "text" });

            Assert.AreEqual("text", holder.Value);
        }

        [TestMethod]
        public void Invoke_SetterOfT_WithAValueType_Works()
        {
            var holder = new GrInvokeInt<int>();

            typeof(GrInvokeInt<int>).GetMethod("set_Value").Invoke(holder, new object[] { 21 });

            Assert.AreEqual(21, holder.Value);
        }

        [TestMethod]
        public void Invoke_SetterOfT_WithAnotherType_IsRejected()
        {
            var holder = new GrInvokeWrong<string>();
            MethodInfo setter = typeof(GrInvokeWrong<string>).GetMethod("set_Value");

            Assert.ThrowsException(typeof(InvalidCastException), () => { setter.Invoke(holder, new object[] { 1 }); });
        }

        [TestMethod]
        public void Invoke_GetterOfT_ReturnsTheStoredValue()
        {
            var holder = new GrInvokeGet<int> { Value = 33 };

            Assert.AreEqual(33, (int)typeof(GrInvokeGet<int>).GetMethod("get_Value").Invoke(holder, null));
        }

        [TestMethod]
        public void Invoke_MethodOfAnotherInstantiation_IsRejected()
        {
            var holder = new GrInvokeOther<int>();
            MethodInfo setter = typeof(GrInvokeOther<string>).GetMethod("set_Value");

            Assert.ThrowsException(typeof(InvalidCastException), () => { setter.Invoke(holder, new object[] { "text" }); });
        }
    }

    public class GrIdentity<T>
    {
    }

    public class GrIdentityArguments<T>
    {
    }

    public class GrReturnInt<T>
    {
        public T Value { get; set; }
    }

    public class GrReturnString<T>
    {
        public T Value { get; set; }
    }

    public class GrReturnInstance<T>
    {
        public T Value { get; set; }
    }

    public class GrReturnArray<T>
    {
        public T[] Values { get; set; }
    }

    public class GrNestedItem<T>
    {
    }

    public class GrReturnNested<T>
    {
        public T Value { get; set; }
    }

    public class GrPlainItem<T>
    {
    }

    public class GrReturnPlain
    {
        public GrPlainItem<int> Get()
        {
            return null;
        }
    }

    public class GrReturnTwo<T>
    {
        public T Value { get; set; }
    }

    public class GrParameter<T>
    {
        public T Value { get; set; }
    }

    public class GrFieldItem
    {
    }

    public class GrFieldTypeInt<T>
    {
        public T Item;
    }

    public class GrFieldTypeString<T>
    {
        public T Item;
    }

    public class GrFieldTypeInstance<T>
    {
        public T Item;
    }

    public class GrSetInt<T>
    {
        public T Item;
    }

    public class GrSetString<T>
    {
        public T Item;
    }

    public class GrSetWrong<T>
    {
        public T Item;
    }

    public class GrSetOther<T>
    {
        public T Item;
    }

    public class GrGet<T>
    {
        public T Item;
    }

    public class GrStaticRead<T>
    {
        public static int Count;
    }

    public class GrStaticPer<T>
    {
        public static int Count;
    }

    public class GrStaticWrite<T>
    {
        public static int Count;
    }

    public class GrStaticCctor<T>
    {
        public static int Seeded;

        static GrStaticCctor()
        {
            Seeded = 7;
        }
    }

    public class GrStaticDefinition<T>
    {
        public static int Count;
    }

    public class GrCounter<T>
    {
        public static int Created;

        public GrCounter()
        {
            Created++;
        }
    }

    public class GrCreated<T>
    {
    }

    public class GrInvokeString<T>
    {
        public T Value { get; set; }
    }

    public class GrInvokeInt<T>
    {
        public T Value { get; set; }
    }

    public class GrInvokeWrong<T>
    {
        public T Value { get; set; }
    }

    public class GrInvokeGet<T>
    {
        public T Value { get; set; }
    }

    public class GrInvokeOther<T>
    {
        public T Value { get; set; }
    }
}
