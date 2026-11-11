// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestGenericBaseCastTests
    {
        [TestMethod]
        public void CastClass_DerivedFromClosedBase_ComparesBaseArguments()
        {
            object value = new CastDerived();

            Assert.IsNotNull((CastBase<int>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (CastBase<string>)value; });
        }

        [TestMethod]
        public void IsInst_DerivedFromClosedBase_ComparesBaseArguments()
        {
            object value = new IsInstDerived();

            Assert.IsTrue(value is IsInstBase<int>);
            Assert.IsFalse(value is IsInstBase<string>);
            Assert.IsNull(value as IsInstBase<string>);
        }

        [TestMethod]
        public void CastClass_GenericChildOfGenericBase_ComparesBaseArguments()
        {
            object value = new Child<int>();

            Assert.IsNotNull((ChildBase<int>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (ChildBase<string>)value; });
        }

        [TestMethod]
        public void CastClass_TwoLevels_ComparesBaseArguments()
        {
            object value = new Deep();

            Assert.IsNotNull((DeepBase<int>)value);
            Assert.IsNotNull((DeepMiddle<int>)value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (DeepBase<string>)value; });
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (DeepMiddle<string>)value; });
        }

        [TestMethod]
        public void CastClass_DerivedFromClosedBase_NullAndSameType()
        {
            NullDerived value = new NullDerived();
            object nothing = null;

            Assert.IsNull((NullBase<string>)nothing);
            Assert.IsNotNull((NullBase<int>)(object)value);
            Assert.IsNotNull((NullDerived)(object)value);
        }

        [TestMethod]
        public void CastClass_PlainDerivedClass_IsUnchanged()
        {
            object value = new PlainDerived();

            Assert.IsNotNull((PlainBase)value);
            Assert.IsNotNull((PlainDerived)value);
            Assert.IsTrue(value is PlainBase);
        }

        [TestMethod]
        public void Invoke_ArgumentDerivedFromClosedBase_IsChecked()
        {
            MethodInfo mi = typeof(InvokeTarget).GetMethod("Take");

            Assert.AreEqual(1, (int)mi.Invoke(null, new object[] { new InvokeIntDerived() }));
            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(null, new object[] { new InvokeStringDerived() }); });
        }

        [TestMethod]
        public void SetValue_ArgumentDerivedFromClosedBase_IsChecked()
        {
            FieldHolder holder = new FieldHolder();
            FieldInfo field = typeof(FieldHolder).GetField("Item");

            field.SetValue(holder, new FieldIntDerived());
            Assert.IsNotNull(holder.Item);

            holder.Item = null;

            Assert.ThrowsException(typeof(Exception), () => { field.SetValue(holder, new FieldStringDerived()); });
            Assert.IsNull(holder.Item);
        }

        public class CastBase<T>
        {
        }

        public class CastDerived : CastBase<int>
        {
        }

        public class IsInstBase<T>
        {
        }

        public class IsInstDerived : IsInstBase<int>
        {
        }

        public class ChildBase<T>
        {
        }

        public class Child<U> : ChildBase<U>
        {
        }

        public class DeepBase<T>
        {
        }

        public class DeepMiddle<U> : DeepBase<U>
        {
        }

        public class Deep : DeepMiddle<int>
        {
        }

        public class NullBase<T>
        {
        }

        public class NullDerived : NullBase<int>
        {
        }

        public class PlainBase
        {
        }

        public class PlainDerived : PlainBase
        {
        }

        public class InvokeBase<T>
        {
        }

        public class InvokeIntDerived : InvokeBase<int>
        {
        }

        public class InvokeStringDerived : InvokeBase<string>
        {
        }

        public static class InvokeTarget
        {
            public static int Take(InvokeBase<int> value) => 1;
        }

        public class FieldBase<T>
        {
        }

        public class FieldIntDerived : FieldBase<int>
        {
        }

        public class FieldStringDerived : FieldBase<string>
        {
        }

        public class FieldHolder
        {
            public FieldBase<int> Item;
        }
    }
}
