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
        public void CastClass_ReferenceArrayToGenericInterface_IsInvariant()
        {
            object value = new string[1];

            Assert.IsNotNull((IEnumerable<string>)value);
            // Diverges from standard .NET, where IEnumerable<out T> is covariant. Only an exact element type matches.
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
        public void IsInst_DifferentArgument_StaysErased()
        {
            object value = new GaG<int>();

            // Diverges from standard .NET, where this is false. isinst compares only the generic type definition.
            Assert.IsTrue(value is GaG<string>);
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
