// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestGenericCastBindingTests
    {
        [TestMethod]
        public void ExplicitInterface_SameAssembly_CastsToStringT()
        {
            IBindAdd h = new BindHolderString<string>();

            Assert.AreEqual(1, h.Add("a"));
            Assert.ThrowsException(typeof(InvalidCastException), () => { h.Add(new BindPlain()); });
        }

        [TestMethod]
        public void ExplicitInterface_SameAssembly_CastsToClassWithoutStatics()
        {
            IBindAdd h = new BindHolderClass<BindInner<int>>();

            Assert.AreEqual(1, h.Add(new BindInner<int>()));
            Assert.ThrowsException(typeof(InvalidCastException), () => { h.Add("a"); });
        }

        [TestMethod]
        public void ExplicitInterface_SameAssembly_CastsToClassWithStatics()
        {
            IBindAdd h = new BindHolderStatics<BindInnerStatic<int>>();

            Assert.AreEqual(1, h.Add(new BindInnerStatic<int>()));
        }

        [TestMethod]
        public void ExplicitInterface_SameAssembly_CastsToValueType()
        {
            IBindAdd h = new BindHolderValue<int>();

            Assert.AreEqual(1, h.Add(5));
        }

        [TestMethod]
        public void ExplicitInterface_CorlibInterface_CastsToClassWithoutStatics()
        {
            IComparable h = new BindComparable<BindInner<int>>();

            Assert.AreEqual(1, h.CompareTo(new BindInner<int>()));
        }

        [TestMethod]
        public void ArrayElement_ClassImplementingInterface_ComparesInterfaceArgument()
        {
            object value = new ElemFooImpl<int>[1];

            Assert.IsNotNull((IElemFoo<int>[])value);
            Assert.IsTrue(value is IElemFoo<int>[]);
            Assert.IsNotNull(value as IElemFoo<int>[]);
            Assert.IsTrue(typeof(IElemFoo<int>[]).IsInstanceOfType(value));

            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (IElemFoo<string>[])value; });
            Assert.IsFalse(value is IElemFoo<string>[]);
            Assert.IsNull(value as IElemFoo<string>[]);
            Assert.IsFalse(typeof(IElemFoo<string>[]).IsInstanceOfType(value));
        }

        [TestMethod]
        public void ArrayElement_ChildOfGenericParent_ComparesInterfaceArgument()
        {
            object value = new ElemFooChild<int>[1];

            Assert.IsNotNull((IElemFoo<int>[])value);
            Assert.IsTrue(value is IElemFoo<int>[]);
            Assert.IsTrue(typeof(IElemFoo<int>[]).IsInstanceOfType(value));

            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (IElemFoo<string>[])value; });
            Assert.IsFalse(value is IElemFoo<string>[]);
            Assert.IsNull(value as IElemFoo<string>[]);
            Assert.IsFalse(typeof(IElemFoo<string>[]).IsInstanceOfType(value));
        }

        [TestMethod]
        public void ArrayElement_ReferenceArgument_ComparesInterfaceArgument()
        {
            object value = new ElemFooChild<ElemFooImpl<string>>[1];

            Assert.IsNotNull((IElemFoo<ElemFooImpl<string>>[])value);
            Assert.IsTrue(value is IElemFoo<ElemFooImpl<string>>[]);

            Assert.ThrowsException(
                typeof(InvalidCastException),
                () => { _ = (IElemFoo<ElemFooImpl<int>>[])value; });
            Assert.IsFalse(value is IElemFoo<ElemFooImpl<int>>[]);
            Assert.IsNull(value as IElemFoo<ElemFooImpl<int>>[]);
        }

        [TestMethod]
        public void ArrayElement_NestedArrays_ComparesInterfaceArgument()
        {
            object[] holder = new IElemFoo<int>[1][];

            holder[0] = new ElemFooImpl<int>[1];

            Assert.ThrowsException(typeof(Exception), () => { holder[0] = new ElemFooImpl<string>[1]; });
        }

        [TestMethod]
        public void ArrayCopy_NestedArrays_ComparesInterfaceArgument()
        {
            ElemFooImpl<int>[][] source = new ElemFooImpl<int>[][] { new ElemFooImpl<int>[1] };
            IElemFoo<int>[][] same = new IElemFoo<int>[1][];
            IElemFoo<string>[][] other = new IElemFoo<string>[1][];

            Array.Copy(source, same, 1);

            Assert.IsNotNull(same[0]);
            Assert.ThrowsException(typeof(InvalidCastException), () => Array.Copy(source, other, 1));
        }
    }

    public interface IBindAdd
    {
        int Add(object v);
    }

    public class BindPlain
    {
    }

    public class BindInner<T>
    {
    }

    public class BindInnerStatic<T>
    {
        public static int Count = 1;
    }

    public class BindHolderString<T> : IBindAdd
    {
        private T _x;

        int IBindAdd.Add(object v)
        {
            _x = (T)v;
            return 1;
        }
    }

    public class BindHolderClass<T> : IBindAdd
    {
        private T _x;

        int IBindAdd.Add(object v)
        {
            _x = (T)v;
            return 1;
        }
    }

    public class BindHolderStatics<T> : IBindAdd
    {
        public static int Created = 0;
        private T _x;

        int IBindAdd.Add(object v)
        {
            _x = (T)v;
            return 1;
        }
    }

    public class BindHolderValue<T> : IBindAdd
    {
        private T _x;

        int IBindAdd.Add(object v)
        {
            _x = (T)v;
            return 1;
        }
    }

    public class BindComparable<T> : IComparable
    {
        private T _x;

        int IComparable.CompareTo(object v)
        {
            _x = (T)v;
            return 1;
        }
    }

    public interface IElemFoo<T>
    {
    }

    public class ElemFooImpl<T> : IElemFoo<T>
    {
    }

    public class ElemFooParent<T> : IElemFoo<T>
    {
    }

    public class ElemFooChild<T> : ElemFooParent<T>
    {
    }
}
