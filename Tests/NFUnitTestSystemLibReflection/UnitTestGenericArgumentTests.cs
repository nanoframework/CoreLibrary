// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Each test uses its own types, so no test depends on a closed TypeSpec row that another one names.
    [TestClass]
    public class UnitTestGenericArgumentTests
    {
        private static void AssertSetValueRejected(FieldInfo field, object holder, object value)
        {
            Assert.ThrowsException(typeof(Exception), () => { field.SetValue(holder, value); });
        }

        // castclass

        [TestMethod]
        public void CastClass_SameArgument_IsAccepted()
        {
            object value = new GaA<int>();

            Assert.IsNotNull((GaA<int>)value);
        }

        [TestMethod]
        public void CastClass_DifferentArgument_IsRejected()
        {
            object value = new GaB<int>();

            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (GaB<string>)value; });
        }

        [TestMethod]
        public void CastClass_ReferenceArguments_AreCompared()
        {
            object value = new GaC<GaFoo>();

            Assert.IsNotNull((GaC<GaFoo>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (GaC<GaBar>)value; });
        }

        [TestMethod]
        public void CastClass_NestedArguments_AreCompared()
        {
            object value = new GaD<GaInner<int>>();

            Assert.IsNotNull((GaD<GaInner<int>>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (GaD<GaInner<string>>)value; });
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (GaD<GaOtherInner<int>>)value; });
        }

        [TestMethod]
        public void CastClass_ArrayArgument_IsComparedWithElementArgument()
        {
            object value = new GaE<int[]>();

            Assert.IsNotNull((GaE<int[]>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (GaE<int>)value; });
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (GaE<int[][]>)value; });
        }

        [TestMethod]
        public void CastClass_SecondArgumentAfterNestedArgument_IsCompared()
        {
            object value = new GaPair<GaInner<int>, string>();

            Assert.IsNotNull((GaPair<GaInner<int>, string>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (GaPair<GaInner<int>, long>)value; });
        }

        [TestMethod]
        public void CastClass_GenericImplementer_ToInterfaceArgument_IsCompared()
        {
            object value = new GaImpl<int>();

            Assert.IsNotNull((IGa<int>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (IGa<string>)value; });
        }

        [TestMethod]
        public void CastClass_ClosedImplementer_ToInterfaceArgument_IsCompared()
        {
            object value = new GaIntImpl();

            Assert.IsNotNull((IGa<int>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (IGa<string>)value; });
        }

        [TestMethod]
        public void CastClass_ArrayToGenericInterface_ComparesElementType()
        {
            object value = new int[1];

            Assert.IsNotNull((IEnumerable<int>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (IEnumerable<string>)value; });
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (IEnumerable<uint>)value; });
        }

        [TestMethod]
        public void CastClass_JaggedArrayToGenericInterface_ComparesLevels()
        {
            object value = new int[1][];

            Assert.IsNotNull((IEnumerable<int[]>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (IEnumerable<int>)value; });
        }

        [TestMethod]
        public void CastClass_ReferenceArrayToGenericInterface_IsCovariant()
        {
            object value = new string[1];

            Assert.IsNotNull((IEnumerable<string>)value);
            Assert.IsNotNull((IEnumerable<object>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (IEnumerable<Exception>)value; });
        }

        [TestMethod]
        public void CastClass_ValueTypeArrayToGenericInterface_IsInvariant()
        {
            object value = new int[1];

            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (IEnumerable<object>)value; });
        }

        [TestMethod]
        public void CastClass_InGenericMethod_UsesTheMethodArgument()
        {
            Assert.IsNotNull(GaCasts.CastToGaF<int>(new GaF<int>()));
            Assert.IsNull(GaCasts.CastToGaF<int>(null));

            Assert.ThrowsException(typeof(InvalidCastException), () => { GaCasts.CastToGaF<string>(new GaF<int>()); });
        }

        [TestMethod]
        public void IsInst_DifferentArgument_IsFalse()
        {
            object value = new GaG<int>();

            Assert.IsFalse(value is GaG<string>);
            Assert.IsTrue(value is GaG<int>);
            Assert.IsNull(value as GaG<string>);
            Assert.IsNotNull(value as GaG<int>);
        }

        [TestMethod]
        public void IsInst_ThroughInterface_ComparesArgument()
        {
            object value = new GaIsImpl<int>();

            Assert.IsTrue(value is IGaIs<int>);
            Assert.IsFalse(value is IGaIs<string>);
        }

        [TestMethod]
        public void IsInstanceOfType_ComparesGenericArgument()
        {
            Assert.IsTrue(typeof(GaIsHolder<int>).IsInstanceOfType(new GaIsHolder<int>()));
            Assert.IsFalse(typeof(GaIsHolder<string>).IsInstanceOfType(new GaIsHolder<int>()));
            Assert.IsTrue(typeof(IGaIs<int>).IsInstanceOfType(new GaIsImpl<int>()));
            Assert.IsFalse(typeof(IGaIs<string>).IsInstanceOfType(new GaIsImpl<int>()));
        }

        [TestMethod]
        public void IsInstanceOfType_Array_ComparesElementType()
        {
            Assert.IsTrue(typeof(IEnumerable<int>).IsInstanceOfType(new int[1]));
            Assert.IsFalse(typeof(IEnumerable<string>).IsInstanceOfType(new int[1]));
            Assert.IsFalse(typeof(IEnumerable<object>).IsInstanceOfType(new int[1]));
            Assert.IsTrue(typeof(IEnumerable<object>).IsInstanceOfType(new string[1]));
        }

        [TestMethod]
        public void IsInst_Null_IsFalse()
        {
            object value = null;

            Assert.IsFalse(value is GaG<int>);
            Assert.IsFalse(value is IEnumerable<int>);
        }

        [TestMethod]
        public void IsInst_InGenericMethod_UsesTheMethodArgument()
        {
            Assert.IsTrue(GaCasts.IsGaIsHolder<int>(new GaIsHolder<int>()));
            Assert.IsFalse(GaCasts.IsGaIsHolder<string>(new GaIsHolder<int>()));
        }

        [TestMethod]
        public void IsInst_Array_ComparesElementType()
        {
            object ints = new int[1];

            Assert.IsTrue(ints is IEnumerable<int>);
            Assert.IsTrue(ints is ICollection<int>);
            Assert.IsFalse(ints is IEnumerable<string>);
            Assert.IsFalse(ints is IEnumerable<object>);
            Assert.IsNull(ints as IEnumerable<string>);
            Assert.IsNotNull(ints as IEnumerable<int>);
        }

        [TestMethod]
        public void IsInst_ReferenceArray_IsCovariant()
        {
            object strings = new string[1];

            Assert.IsTrue(strings is IEnumerable<string>);
            Assert.IsTrue(strings is IEnumerable<object>);
            Assert.IsFalse(strings is IEnumerable<Exception>);
        }

        [TestMethod]
        public void IsInst_JaggedArray_ComparesLevels()
        {
            object value = new int[1][];

            Assert.IsTrue(value is IEnumerable<int[]>);
            Assert.IsFalse(value is IEnumerable<int>);
        }

        [TestMethod]
        public void IsInst_ArrayToUnrelatedGenericInterface_IsFalse()
        {
            object value = new int[1];

            Assert.IsFalse(value is IComparer<int>);
        }

        [TestMethod]
        public void IsInst_TypeArray_IsNotACollection()
        {
            object value = typeof(int[]);

            Assert.IsFalse(value is IEnumerable<int>);
        }

        [TestMethod]
        public void ArrayThroughGenericInterface_ClearThrows()
        {
            int[] array = new int[] { 1, 2 };
            ICollection<int> collection = (ICollection<int>)(object)array;

            Assert.ThrowsException(typeof(NotSupportedException), () => { collection.Clear(); });
            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
        }

        // no usable TypeSpec on the instance

        [TestMethod]
        public void CastClass_NonGenericObjectCreatedInGenericMethod_IgnoresTheCreatorContext()
        {
            object value = GaCasts.CreateIntImpl<string>();

            Assert.IsNotNull((IGa<int>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (IGa<string>)value; });
        }

        [TestMethod]
        public void CastClass_GenericObjectCreatedInGenericMethod_KeepsItsOwnArgument()
        {
            object value = GaCasts.CreateGaH<string>();

            Assert.IsNotNull((GaH<int>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (GaH<string>)value; });
        }

        [TestMethod]
        public void CastClass_ObjectBoundToMethodArgument_KeepsTheBoundArgument()
        {
            object value = GaCasts.CreateGaI<string>();

            Assert.IsNotNull((GaI<string>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (GaI<int>)value; });
        }

        // MethodBase.Invoke and ConstructorInfo.Invoke

        [TestMethod]
        public void Invoke_SameArgument_IsAccepted()
        {
            MethodInfo mi = typeof(GaTargets).GetMethod("TakesGaJ");

            Assert.AreEqual(1, (int)mi.Invoke(null, new object[] { new GaJ<int>() }));
            Assert.AreEqual(1, (int)mi.Invoke(null, new object[] { null }));
        }

        [TestMethod]
        public void Invoke_DifferentArgument_IsRejected()
        {
            MethodInfo mi = typeof(GaTargets).GetMethod("TakesGaK");

            Assert.AreEqual(1, (int)mi.Invoke(null, new object[] { new GaK<int>() }));

            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(null, new object[] { new GaK<string>() }); });
        }

        [TestMethod]
        public void Invoke_NestedArgument_IsCompared()
        {
            MethodInfo mi = typeof(GaTargets).GetMethod("TakesGaLOfInner");

            Assert.AreEqual(1, (int)mi.Invoke(null, new object[] { new GaL<GaInner<int>>() }));

            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(null, new object[] { new GaL<GaInner<string>>() }); });
        }

        [TestMethod]
        public void Invoke_ParametersAfterGenericParameter_AreStillChecked()
        {
            MethodInfo mi = typeof(GaTargets).GetMethod("TakesGaMAndString");

            Assert.AreEqual(1, (int)mi.Invoke(null, new object[] { new GaM<int>(), "x" }));

            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(null, new object[] { new GaM<int>(), 5 }); });
            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(null, new object[] { new GaM<string>(), "x" }); });
        }

        [TestMethod]
        public void Invoke_GenericInterfaceParameter_ComparesArrayElementType()
        {
            MethodInfo mi = typeof(GaTargets).GetMethod("TakesIEnumerableOfInt");

            Assert.AreEqual(1, (int)mi.Invoke(null, new object[] { new int[1] }));

            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(null, new object[] { new string[1] }); });
        }

        [TestMethod]
        public void Invoke_GenericInterfaceParameter_ComparesImplementerArgument()
        {
            MethodInfo mi = typeof(GaTargets).GetMethod("TakesIGaOfInt");

            Assert.AreEqual(1, (int)mi.Invoke(null, new object[] { new GaImpl<int>() }));

            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(null, new object[] { new GaImpl<string>() }); });
        }

        [TestMethod]
        public void Invoke_ConstructorParameter_IsCompared()
        {
            ConstructorInfo ci = typeof(GaCtorTarget).GetConstructors()[0];

            Assert.IsNotNull(ci.Invoke(new object[] { new GaN<int>() }));

            Assert.ThrowsException(typeof(InvalidCastException), () => { ci.Invoke(new object[] { new GaN<string>() }); });
        }

        [TestMethod]
        public void Invoke_ParameterStillNamingT_IsNotSupported()
        {
            MethodInfo mi = typeof(GaO<int>).GetMethod("TakesSelf");

            Assert.ThrowsException(typeof(NotSupportedException), () => { mi.Invoke(new GaO<int>(), new object[] { new GaO<int>() }); });
            Assert.ThrowsException(typeof(NotSupportedException), () => { mi.Invoke(new GaO<int>(), new object[] { null }); });
        }

        // FieldInfo.SetValue

        [TestMethod]
        public void SetValue_SameArgument_IsAccepted()
        {
            GaFields holder = new GaFields();
            FieldInfo field = typeof(GaFields).GetField("Single");
            GaP<int> value = new GaP<int>();

            field.SetValue(holder, value);

            Assert.IsTrue((object)holder.Single == value);
        }

        [TestMethod]
        public void SetValue_DifferentArgument_IsRejected()
        {
            GaFields holder = new GaFields();
            FieldInfo field = typeof(GaFields).GetField("Other");

            AssertSetValueRejected(field, holder, new GaQ<string>());
            Assert.IsNull(holder.Other);

            field.SetValue(holder, new GaQ<int>());
            Assert.IsNotNull(holder.Other);
        }

        [TestMethod]
        public void SetValue_GenericInterfaceField_ComparesArrayElementType()
        {
            GaFields holder = new GaFields();
            FieldInfo field = typeof(GaFields).GetField("Items");

            AssertSetValueRejected(field, holder, new string[1]);
            Assert.IsNull(holder.Items);

            field.SetValue(holder, new int[1]);
            Assert.IsNotNull(holder.Items);
        }

        [TestMethod]
        public void SetValue_FieldOverOwnerArgument_ResolvesThroughTheOwner()
        {
            GaOwner<int> holder = new GaOwner<int>();
            FieldInfo field = typeof(GaOwner<int>).GetField("Value");

            AssertSetValueRejected(field, holder, new GaR<string>());
            Assert.IsNull(holder.Value);

            field.SetValue(holder, new GaR<int>());
            Assert.IsNotNull(holder.Value);
        }

        [TestMethod]
        public void SetValue_InheritedFieldOverBaseArgument_IsNotResolvedAgainstTheDerivedOwner()
        {
            GaDerived<string> holder = new GaDerived<string>();
            FieldInfo field = typeof(GaBase<int>).GetField("Value");
            GaT<int> value = new GaT<int>();

            field.SetValue(holder, value);

            Assert.IsTrue((object)holder.Value == value);
        }

        [TestMethod]
        public void SetValue_Null_IsAccepted()
        {
            GaFields holder = new GaFields();
            FieldInfo field = typeof(GaFields).GetField("Single");

            holder.Single = new GaP<int>();
            field.SetValue(holder, null);

            Assert.IsNull(holder.Single);
        }

        // types

        public class GaFoo
        {
        }

        public class GaBar
        {
        }

        public class GaInner<T>
        {
        }

        public class GaOtherInner<T>
        {
        }

        public class GaA<T>
        {
        }

        public class GaB<T>
        {
        }

        public class GaC<T>
        {
        }

        public class GaD<T>
        {
        }

        public class GaE<T>
        {
        }

        public class GaF<T>
        {
        }

        public class GaG<T>
        {
        }

        public class GaH<T>
        {
        }

        public class GaI<T>
        {
        }

        public class GaJ<T>
        {
        }

        public class GaK<T>
        {
        }

        public class GaL<T>
        {
        }

        public class GaM<T>
        {
        }

        public class GaN<T>
        {
        }

        public class GaP<T>
        {
        }

        public class GaQ<T>
        {
        }

        public class GaR<T>
        {
        }

        public class GaT<T>
        {
        }

        public class GaBase<T>
        {
            public GaT<T> Value;
        }

        public class GaDerived<U> : GaBase<int>
        {
        }

        public class GaPair<T1, T2>
        {
        }

        public class GaO<T>
        {
            public int TakesSelf(GaO<T> value) => 1;
        }

        public interface IGa<T>
        {
        }

        public interface IGaIs<T>
        {
        }

        public class GaIsImpl<T> : IGaIs<T>
        {
        }

        public class GaIsHolder<T>
        {
        }

        public class GaImpl<T> : IGa<T>
        {
        }

        public class GaIntImpl : IGa<int>
        {
        }

        public class GaOwner<T>
        {
            public GaR<T> Value;
        }

        public class GaFields
        {
            public GaP<int> Single;
            public GaQ<int> Other;
            public IEnumerable<int> Items;
        }

        public class GaCtorTarget
        {
            public GaCtorTarget(GaN<int> value)
            {
            }
        }

        public static class GaCasts
        {
            public static GaF<T> CastToGaF<T>(object value) => (GaF<T>)value;

            public static bool IsGaIsHolder<T>(object value) => value is GaIsHolder<T>;

            public static object CreateIntImpl<T>() => new GaIntImpl();

            public static object CreateGaH<T>() => new GaH<int>();

            public static object CreateGaI<T>() => new GaI<T>();
        }

        public static class GaTargets
        {
            public static int TakesGaJ(GaJ<int> value) => 1;

            public static int TakesGaK(GaK<int> value) => 1;

            public static int TakesGaLOfInner(GaL<GaInner<int>> value) => 1;

            public static int TakesGaMAndString(GaM<int> value, string text) => 1;

            public static int TakesIEnumerableOfInt(IEnumerable<int> value) => 1;

            public static int TakesIGaOfInt(IGa<int> value) => 1;
        }
    }
}
