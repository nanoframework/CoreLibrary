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

        // T bound to a generic type

        [TestMethod]
        public void NestedArgument_GetType_IsTheClosedType()
        {
            var instance = new GrNestId<GrNestItem<int>>();

            Assert.IsTrue(instance.GetType() == typeof(GrNestId<GrNestItem<int>>));
            Assert.IsTrue(instance.GetType() != typeof(GrNestId<GrNestItem<string>>));
            Assert.IsTrue(instance.GetType().GetGenericArguments()[0] == typeof(GrNestItem<int>));
        }

        [TestMethod]
        public void NestedArgument_FieldType_IsTheClosedArgument()
        {
            Type field = typeof(GrNestField<GrNestItem<string>>).GetField("Item").FieldType;

            Assert.IsTrue(field == typeof(GrNestItem<string>));
            Assert.IsTrue(field != typeof(GrNestItem<int>));
        }

        [TestMethod]
        public void NestedArgument_ParameterType_IsTheClosedArgument()
        {
            ParameterInfo[] parameters = typeof(GrNestParameter<GrNestItem<int>>).GetMethod("set_Value").GetParameters();

            Assert.IsTrue(parameters[0].ParameterType == typeof(GrNestItem<int>));
        }

        [TestMethod]
        public void NestedArgument_SetValue_ChecksTheArgument()
        {
            var holder = new GrNestSet<GrNestItem<int>>();
            FieldInfo field = holder.GetType().GetField("Item");
            var item = new GrNestItem<int>();

            field.SetValue(holder, item);

            Assert.IsTrue(holder.Item == item);
            Assert.ThrowsException(typeof(Exception), () => { field.SetValue(holder, new GrNestItem<string>()); });
        }

        [TestMethod]
        public void NestedArgument_Invoke_ChecksTheArgument()
        {
            var holder = new GrNestInvoke<GrNestItem<int>>();
            MethodInfo setter = holder.GetType().GetMethod("set_Value");
            var item = new GrNestItem<int>();

            setter.Invoke(holder, new object[] { item });

            Assert.IsTrue(holder.Value == item);
            Assert.ThrowsException(typeof(InvalidCastException), () => { setter.Invoke(holder, new object[] { new GrNestItem<string>() }); });
        }

        [TestMethod]
        public void NestedArgument_InvokeGetter_ReturnsTheStoredValue()
        {
            var item = new GrNestItem<int>();
            var holder = new GrNestGet<GrNestItem<int>> { Value = item };

            Assert.IsTrue(typeof(GrNestGet<GrNestItem<int>>).GetMethod("get_Value").Invoke(holder, null) == item);
        }

        [TestMethod]
        public void NestedArgument_StaticField_IsPerInstantiation()
        {
            _ = new GrNestStatic<GrNestItem<int>>();
            _ = new GrNestStatic<GrNestItem<string>>();
            GrNestStatic<GrNestItem<int>>.Count = 3;
            GrNestStatic<GrNestItem<string>>.Count = 4;

            Assert.AreEqual(3, (int)typeof(GrNestStatic<GrNestItem<int>>).GetField("Count").GetValue(null));
            Assert.AreEqual(4, (int)typeof(GrNestStatic<GrNestItem<string>>).GetField("Count").GetValue(null));
        }

        [TestMethod]
        public void NestedArgument_ConstructorInvoke_CreatesTheRequestedInstantiation()
        {
            object created = typeof(GrNestCreate<GrNestItem<int>>).GetConstructor(new Type[] { }).Invoke(null);

            Assert.IsTrue(created is GrNestCreate<GrNestItem<int>>);
            Assert.IsFalse(created is GrNestCreate<GrNestItem<string>>);
        }

        [TestMethod]
        public void GenericReturnOfT_IsTheClosedType()
        {
            Assert.IsTrue(typeof(GrWrapReturn<int>).GetMethod("Wrap").ReturnType == typeof(GrNestItem<int>));
            Assert.IsTrue(typeof(GrWrapReturn<string>).GetMethod("Wrap").ReturnType == typeof(GrNestItem<string>));
        }

        [TestMethod]
        public void GenericFieldOfT_IsTheClosedType()
        {
            Assert.IsTrue(typeof(GrWrapField<int>).GetField("Item").FieldType == typeof(GrNestItem<int>));
        }

        // T bound to an array

        [TestMethod]
        public void ArrayArgument_FieldType_IsTheArray()
        {
            Assert.IsTrue(typeof(GrArrayField<int[]>).GetField("Item").FieldType == typeof(int[]));
            Assert.IsTrue(typeof(GrArrayFieldString<string[]>).GetField("Item").FieldType == typeof(string[]));
        }

        [TestMethod]
        public void ArrayArgument_ReturnType_IsTheArray()
        {
            Assert.IsTrue(typeof(GrArrayReturn<int[]>).GetMethod("get_Value").ReturnType == typeof(int[]));
        }

        [TestMethod]
        public void ArrayArgument_ParameterType_IsTheArray()
        {
            Assert.IsTrue(typeof(GrArrayParameter<int[]>).GetMethod("set_Value").GetParameters()[0].ParameterType == typeof(int[]));
        }

        [TestMethod]
        public void ArrayArgument_SetValue_ChecksTheArray()
        {
            var holder = new GrArraySet<int[]>();
            FieldInfo field = holder.GetType().GetField("Item");
            var values = new int[] { 1, 2 };

            field.SetValue(holder, values);

            Assert.IsTrue(holder.Item == values);
            Assert.ThrowsException(typeof(Exception), () => { field.SetValue(holder, new string[1]); });
            Assert.ThrowsException(typeof(Exception), () => { field.SetValue(holder, "text"); });
        }

        [TestMethod]
        public void ArrayArgument_Invoke_ChecksTheArray()
        {
            var holder = new GrArrayInvoke<int[]>();
            MethodInfo setter = holder.GetType().GetMethod("set_Value");
            var values = new int[] { 5 };

            setter.Invoke(holder, new object[] { values });

            Assert.IsTrue(holder.Value == values);
            Assert.ThrowsException(typeof(InvalidCastException), () => { setter.Invoke(holder, new object[] { new string[1] }); });
            Assert.ThrowsException(typeof(InvalidCastException), () => { setter.Invoke(holder, new object[] { "text" }); });
        }

        [TestMethod]
        public void ArrayArgument_InvokeGetter_ReturnsTheStoredArray()
        {
            var values = new string[] { "a" };
            var holder = new GrArrayGet<string[]> { Value = values };

            Assert.IsTrue(typeof(GrArrayGet<string[]>).GetMethod("get_Value").Invoke(holder, null) == values);
        }

        [TestMethod]
        public void ArrayOfT_FieldAndReturnType_UseTheArgument()
        {
            Assert.IsTrue(typeof(GrArrayOfT<int>).GetField("Items").FieldType == typeof(int[]));
            Assert.IsTrue(typeof(GrArrayOfT<GrNestItem<int>>).GetMethod("get_Values").ReturnType == typeof(GrNestItem<int>[]));
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

    public class GrNestItem<T>
    {
    }

    public class GrNestId<T>
    {
    }

    public class GrNestField<T>
    {
        public T Item;
    }

    public class GrNestParameter<T>
    {
        public T Value { get; set; }
    }

    public class GrNestSet<T>
    {
        public T Item;
    }

    public class GrNestInvoke<T>
    {
        public T Value { get; set; }
    }

    public class GrNestGet<T>
    {
        public T Value { get; set; }
    }

    public class GrNestCreate<T>
    {
    }

    public class GrArrayField<T>
    {
        public T Item;
    }

    public class GrArrayFieldString<T>
    {
        public T Item;
    }

    public class GrArrayReturn<T>
    {
        public T Value { get; set; }
    }

    public class GrArrayParameter<T>
    {
        public T Value { get; set; }
    }

    public class GrArraySet<T>
    {
        public T Item;
    }

    public class GrArrayInvoke<T>
    {
        public T Value { get; set; }
    }

    public class GrArrayGet<T>
    {
        public T Value { get; set; }
    }

    public class GrNestStatic<T>
    {
        public static int Count;
    }

    public class GrWrapReturn<T>
    {
        public GrNestItem<T> Wrap()
        {
            return null;
        }
    }

    public class GrWrapField<T>
    {
        public GrNestItem<T> Item;
    }

    public class GrArrayOfT<T>
    {
        public T[] Items;

        public T[] Values { get; set; }
    }
}
