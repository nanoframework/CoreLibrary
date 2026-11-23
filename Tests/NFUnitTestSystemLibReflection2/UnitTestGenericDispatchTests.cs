// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    public interface IProducer<out T>
    {
        T Get();

        string Name();
    }

    public interface IConsumer<in T>
    {
        string Put(T value);
    }

    public interface IEcho<T>
    {
        T Echo(T value);
    }

    public interface IMethodHost<T>
    {
        string M<U>(T value, U other);
    }

    public interface IWho
    {
        string Who();
    }

    public class VarSibling : VarBase
    {
    }

    public class VarBaseComparer : IComparable<VarBase>
    {
        public int CompareTo(VarBase other)
        {
            return 7;
        }
    }

    public class DerivedProducer : IProducer<VarDerived>
    {
        public VarDerived Get()
        {
            return new VarDerived();
        }

        public string Name()
        {
            return "DerivedProducer.Name";
        }
    }

    public class DualProducer : IProducer<VarDerived>, IProducer<VarSibling>
    {
        VarDerived IProducer<VarDerived>.Get()
        {
            return new VarDerived();
        }

        VarSibling IProducer<VarSibling>.Get()
        {
            return new VarSibling();
        }

        string IProducer<VarDerived>.Name()
        {
            return "DualProducer.Derived.Name";
        }

        string IProducer<VarSibling>.Name()
        {
            return "DualProducer.Other.Name";
        }
    }

    public class DualConsumer : IConsumer<VarDerived>, IConsumer<VarSibling>
    {
        string IConsumer<VarDerived>.Put(VarDerived value)
        {
            return "DualConsumer.Derived";
        }

        string IConsumer<VarSibling>.Put(VarSibling value)
        {
            return "DualConsumer.Other";
        }
    }

    public class BaseConsumer : IConsumer<VarBase>
    {
        public string Put(VarBase value)
        {
            return "BaseConsumer.Put";
        }
    }

    public class GenericEcho<T> : IEcho<T>
    {
        public T Echo(T value)
        {
            return value;
        }
    }

    public class StringEcho : IEcho<string>
    {
        public string Echo(string value)
        {
            return "str:" + value;
        }
    }

    public class IntMethodHost : IMethodHost<int>
    {
        public string M<U>(int value, U other)
        {
            return "IntMethodHost.M<" + typeof(U).Name + ">";
        }
    }

    public class EchoBase : IEcho<int>
    {
        public virtual int Echo(int value)
        {
            return 1;
        }
    }

    public class EchoOverride : EchoBase
    {
        public override int Echo(int value)
        {
            return 2;
        }
    }

    public class EchoReimplemented : EchoBase, IEcho<int>
    {
        public new int Echo(int value)
        {
            return 3;
        }
    }

    public class ExplicitAndPublicWho : IWho
    {
        public string Who()
        {
            return "public";
        }

        string IWho.Who()
        {
            return "explicit";
        }
    }

    public struct EchoStruct : IEcho<int>
    {
        public int Echo(int value)
        {
            return value + 100;
        }
    }

    public abstract class GenericBase<T>
    {
        public abstract T Get(T value);

        public virtual string Name(T value)
        {
            return "GenericBase";
        }
    }

    public class ClosedGenericDerived : GenericBase<int>
    {
        public override int Get(int value)
        {
            return value + 1;
        }

        public override string Name(int value)
        {
            return "ClosedGenericDerived";
        }
    }

    public class OpenGenericDerived<T> : GenericBase<T>
    {
        public override T Get(T value)
        {
            return value;
        }

        public override string Name(T value)
        {
            return "OpenGenericDerived";
        }
    }

    public class ValueMap<K, V>
    {
        private readonly V[] _values;

        public ValueMap(V[] values)
        {
            _values = values;
        }

        public ValueCollection Values
        {
            get { return new ValueCollection(_values); }
        }

        public class ValueCollection : IEnumerable<V>
        {
            private readonly V[] _values;

            public ValueCollection(V[] values)
            {
                _values = values;
            }

            public IEnumerator<V> GetEnumerator()
            {
                return new ValueEnumerator(_values);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new ValueEnumerator(_values);
            }
        }

        private class ValueEnumerator : IEnumerator<V>
        {
            private readonly V[] _values;
            private int _index = -1;

            public ValueEnumerator(V[] values)
            {
                _values = values;
            }

            public V Current
            {
                get { return _values[_index]; }
            }

            object IEnumerator.Current
            {
                get { return _values[_index]; }
            }

            public bool MoveNext()
            {
                _index++;

                return _index < _values.Length;
            }

            public void Reset()
            {
                _index = -1;
            }

            public void Dispose()
            {
            }
        }
    }

    public interface IOtherName
    {
        string Describe();
    }

    public interface IGenericDescribe<T>
    {
        string Describe();
    }

    public class ExplicitOtherAndPublicGeneric : IGenericDescribe<int>, IOtherName
    {
        public string Describe()
        {
            return "generic";
        }

        string IOtherName.Describe()
        {
            return "other";
        }
    }

    public interface IKind
    {
        string Kind();
    }

    public class VirtualHost
    {
        public virtual string Kind()
        {
            return "base";
        }
    }

    public class ExplicitKindHost : VirtualHost, IKind
    {
        string IKind.Kind()
        {
            return "explicit";
        }
    }

    public interface IFirstFace
    {
    }

    public interface ISecondFace
    {
    }

    public class BothFaces : IFirstFace, ISecondFace
    {
    }

    public class OneFace : IFirstFace
    {
    }

    public static class DispatchHelper
    {
        public static T CallEcho<T>(T target, int value) where T : IEcho<int>
        {
            target.Echo(value);

            return target;
        }

        public static int EchoOf<T>(T target, int value) where T : IEcho<int>
        {
            return target.Echo(value);
        }

        public static int Count<T>(IEnumerable<T> source)
        {
            int count = 0;

            foreach (T item in source)
            {
                count++;
            }

            return count;
        }
    }

    // The implementation of a generic interface (or of a virtual of a closed generic base) is found by comparing the
    // signatures with the arguments of the class. Every expected value was printed by .NET 10.
    [TestClass]
    public class UnitTestGenericDispatchTests
    {
        [TestMethod]
        public void Dispatch_GenericInterface_IgnoresExplicitImplementationOfOtherInterface()
        {
            IGenericDescribe<int> generic = new ExplicitOtherAndPublicGeneric();
            IOtherName other = new ExplicitOtherAndPublicGeneric();

            Assert.AreEqual("generic", generic.Describe());
            Assert.AreEqual("other", other.Describe());
        }

        [TestMethod]
        public void Dispatch_ClassVirtual_IgnoresExplicitImplementationOfInterface()
        {
            VirtualHost host = new ExplicitKindHost();
            IKind kind = (IKind)host;

            Assert.AreEqual("base", host.Kind());
            Assert.AreEqual("explicit", kind.Kind());
        }

        [TestMethod]
        public void Dispatch_ExactComparable()
        {
            IComparable<VarBase> comparer = (IComparable<VarBase>)(object)new VarBaseComparer();

            Assert.AreEqual(7, comparer.CompareTo(new VarBase()));
        }

        [TestMethod]
        public void Dispatch_ContravariantComparable()
        {
            IComparable<VarDerived> comparer = (IComparable<VarDerived>)(object)new VarBaseComparer();

            Assert.AreEqual(7, comparer.CompareTo(new VarDerived()));
        }

        [TestMethod]
        public void Dispatch_CovariantOut()
        {
            IProducer<VarBase> view = (IProducer<VarBase>)(object)new DerivedProducer();

            Assert.AreEqual(typeof(VarDerived), view.Get().GetType());
            Assert.AreEqual("DerivedProducer.Name", view.Name());
        }

        [TestMethod]
        public void Dispatch_TwoInstantiations_OutSelectsEachEntry()
        {
            DualProducer target = new DualProducer();
            IProducer<VarDerived> derived = target;
            IProducer<VarSibling> other = target;

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(typeof(VarDerived), derived.Get().GetType());
                Assert.AreEqual(typeof(VarSibling), other.Get().GetType());
            }
        }

        [TestMethod]
        public void Dispatch_TwoInstantiations_VariantViewUsesFirstEntry()
        {
            IProducer<VarBase> view = new DualProducer();

            Assert.AreEqual(typeof(VarDerived), view.Get().GetType());
        }

        [TestMethod]
        public void Dispatch_TwoInstantiations_InSelectsEachEntry()
        {
            DualConsumer target = new DualConsumer();
            IConsumer<VarDerived> derived = target;
            IConsumer<VarSibling> other = target;

            Assert.AreEqual("DualConsumer.Derived", derived.Put(new VarDerived()));
            Assert.AreEqual("DualConsumer.Other", other.Put(new VarSibling()));
        }

        [TestMethod]
        public void Dispatch_ContravariantIn()
        {
            IConsumer<VarDerived> view = (IConsumer<VarDerived>)(object)new BaseConsumer();

            Assert.AreEqual("BaseConsumer.Put", view.Put(new VarDerived()));
        }

        [TestMethod]
        public void Dispatch_GenericAndClosedImplementations()
        {
            Assert.AreEqual(5, ((IEcho<int>)new GenericEcho<int>()).Echo(5));
            Assert.AreEqual("x", ((IEcho<string>)new GenericEcho<string>()).Echo("x"));
            Assert.AreEqual("str:x", ((IEcho<string>)new StringEcho()).Echo("x"));
        }

        [TestMethod]
        public void Dispatch_GenericMethodOfGenericInterface()
        {
            IMethodHost<int> target = new IntMethodHost();

            Assert.AreEqual("IntMethodHost.M<String>", target.M<string>(1, "a"));
            Assert.AreEqual("IntMethodHost.M<VarBase>", target.M<VarBase>(1, null));
        }

        [TestMethod]
        public void Dispatch_InheritedAndReimplemented()
        {
            Assert.AreEqual(1, ((IEcho<int>)new EchoBase()).Echo(1));
            Assert.AreEqual(2, ((IEcho<int>)new EchoOverride()).Echo(1));
            Assert.AreEqual(3, ((IEcho<int>)new EchoReimplemented()).Echo(1));
        }

        [TestMethod]
        public void Dispatch_ExplicitBeforePublic()
        {
            ExplicitAndPublicWho target = new ExplicitAndPublicWho();

            Assert.AreEqual("explicit", ((IWho)target).Who());
            Assert.AreEqual("public", target.Who());
        }

        [TestMethod]
        public void Dispatch_ConstrainedOnStruct()
        {
            Assert.AreEqual(105, DispatchHelper.EchoOf(new EchoStruct(), 5));
        }

        [TestMethod]
        public void Dispatch_ClassVirtual_OverClosedBase()
        {
            GenericBase<int> target = new ClosedGenericDerived();

            Assert.AreEqual(6, target.Get(5));
            Assert.AreEqual("ClosedGenericDerived", target.Name(5));
        }

        [TestMethod]
        public void Dispatch_ClassVirtual_OverOpenBase()
        {
            GenericBase<string> target = new OpenGenericDerived<string>();

            Assert.AreEqual("x", target.Get("x"));
            Assert.AreEqual("OpenGenericDerived", target.Name("x"));
        }

        [TestMethod]
        public void Dispatch_NestedCollection_RedeclaredParameters()
        {
            ValueMap<string, VarDerived> map = new ValueMap<string, VarDerived>(new VarDerived[] { new VarDerived(), new VarDerived() });

            Assert.AreEqual(2, DispatchHelper.Count<VarDerived>(map.Values));
            Assert.AreEqual(2, DispatchHelper.Count<VarBase>(map.Values));
            Assert.AreEqual(2, DispatchHelper.Count<object>(map.Values));
        }

        [TestMethod]
        public void Dispatch_Ldvirtftn_ThroughInterface()
        {
            Func<VarBase, int> compare = ((IComparable<VarBase>)new VarBaseComparer()).CompareTo;
            Func<VarSibling> get = ((IProducer<VarSibling>)new DualProducer()).Get;

            Assert.AreEqual(7, compare(new VarBase()));
            Assert.AreEqual(typeof(VarSibling), get().GetType());
        }

        [TestMethod]
        public void Dispatch_Reflection_InvokeOfInterfaceMethod()
        {
            MethodInfo mi = typeof(IEcho<int>).GetMethod("Echo");

            Assert.AreEqual(1, (int)mi.Invoke(new EchoBase(), new object[] { 9 }));
            Assert.AreEqual(3, (int)mi.Invoke(new EchoReimplemented(), new object[] { 9 }));
        }
    }

    // The exception that .NET throws for a mismatch, the type of the argument, of the value or of the element.
    [TestClass]
    public class UnitTestMismatchExceptionTests
    {
        public class MismatchTarget
        {
            public int F;
            public string S;
            public VarDerived D;

            public int M(int value)
            {
                return value;
            }

            public string N(string value)
            {
                return value;
            }

            public void O(VarDerived value)
            {
            }

            public static int Twice(int value)
            {
                return value * 2;
            }
        }

        public class MismatchConstructed
        {
            public MismatchConstructed(int value)
            {
            }
        }

        [TestMethod]
        public void Invoke_WrongArgumentType_IsArgumentException()
        {
            MismatchTarget target = new MismatchTarget();
            MethodInfo m = typeof(MismatchTarget).GetMethod("M");
            MethodInfo n = typeof(MismatchTarget).GetMethod("N");
            MethodInfo o = typeof(MismatchTarget).GetMethod("O");

            Assert.ThrowsException(typeof(ArgumentException), () => m.Invoke(target, new object[] { "x" }));
            Assert.ThrowsException(typeof(ArgumentException), () => m.Invoke(target, new object[] { 5L }));
            Assert.ThrowsException(typeof(ArgumentException), () => n.Invoke(target, new object[] { 5 }));
            Assert.ThrowsException(typeof(ArgumentException), () => o.Invoke(target, new object[] { new VarBase() }));
            Assert.ThrowsException(typeof(ArgumentException), () => o.Invoke(target, new object[] { "s" }));
        }

        [TestMethod]
        public void Invoke_WrongArgumentCount_IsTargetParameterCountException()
        {
            MismatchTarget target = new MismatchTarget();
            MethodInfo m = typeof(MismatchTarget).GetMethod("M");
            ConstructorInfo ctor = typeof(MismatchConstructed).GetConstructor(new Type[] { typeof(int) });

            Assert.ThrowsException(typeof(TargetParameterCountException), () => m.Invoke(target, new object[] { 1, 2 }));
            Assert.ThrowsException(typeof(TargetParameterCountException), () => m.Invoke(target, null));
            Assert.ThrowsException(typeof(TargetParameterCountException), () => ctor.Invoke(new object[] { 1, 2 }));
        }

        [TestMethod]
        public void Invoke_WrongTarget_IsTargetException()
        {
            MethodInfo m = typeof(MismatchTarget).GetMethod("M");

            Assert.ThrowsException(typeof(TargetException), () => m.Invoke("notTarget", new object[] { 1 }));
        }

        [TestMethod]
        public void Invoke_ConstructorWrongArgumentType_IsArgumentException()
        {
            ConstructorInfo ctor = typeof(MismatchConstructed).GetConstructor(new Type[] { typeof(int) });

            Assert.ThrowsException(typeof(ArgumentException), () => ctor.Invoke(new object[] { "x" }));
        }

        [TestMethod]
        public void SetValue_WrongValue_IsArgumentException()
        {
            MismatchTarget target = new MismatchTarget();
            FieldInfo f = typeof(MismatchTarget).GetField("F");
            FieldInfo s = typeof(MismatchTarget).GetField("S");
            FieldInfo d = typeof(MismatchTarget).GetField("D");

            Assert.ThrowsException(typeof(ArgumentException), () => f.SetValue(target, "x"));
            Assert.ThrowsException(typeof(ArgumentException), () => f.SetValue(target, 5L));
            Assert.ThrowsException(typeof(ArgumentException), () => s.SetValue(target, 5));
            Assert.ThrowsException(typeof(ArgumentException), () => d.SetValue(target, new VarBase()));
        }

        [TestMethod]
        public void SetValue_AndGetValue_WrongTarget_IsArgumentException()
        {
            FieldInfo f = typeof(MismatchTarget).GetField("F");

            Assert.ThrowsException(typeof(ArgumentException), () => f.SetValue("x", 1));
            Assert.ThrowsException(typeof(ArgumentException), () => f.GetValue("x"));
        }

        [TestMethod]
        public void StoreElement_WrongType_IsArrayTypeMismatchException()
        {
            object[] strings = new string[1];
            VarBase[] derived = new VarDerived[1];

            Assert.ThrowsException(typeof(ArrayTypeMismatchException), () => { strings[0] = 5; });
            Assert.ThrowsException(typeof(ArrayTypeMismatchException), () => { derived[0] = new VarBase(); });
        }

        [TestMethod]
        public void ArrayCopy_NotAssignable_IsArrayTypeMismatchException()
        {
            Assert.ThrowsException(typeof(ArrayTypeMismatchException), () => Array.Copy(new string[1], new int[1], 1));
            Assert.ThrowsException(typeof(ArrayTypeMismatchException), () => Array.Copy(new int[1], new string[1], 1));
            Assert.ThrowsException(typeof(ArrayTypeMismatchException), () => Array.Copy(new long[] { 1 }, new int[1], 1));
            Assert.ThrowsException(typeof(ArrayTypeMismatchException), () => Array.Copy(new VarBase[1], new string[1], 1));
        }

        [TestMethod]
        public void ArrayCopy_BetweenUnrelatedInterfaces_ChecksEachElement()
        {
            BothFaces both = new BothFaces();
            IFirstFace[] source = new IFirstFace[] { both };
            ISecondFace[] target = new ISecondFace[1];

            Array.Copy(source, target, 1);

            Assert.AreSame(both, target[0]);

            source[0] = new OneFace();

            Assert.ThrowsException(typeof(InvalidCastException), () => Array.Copy(source, target, 1));
        }

        [TestMethod]
        public void ArrayCopy_ElementFailure_IsInvalidCastException()
        {
            Assert.ThrowsException(typeof(InvalidCastException), () => Array.Copy(new object[] { 5 }, new string[1], 1));
            Assert.ThrowsException(typeof(InvalidCastException), () => Array.Copy(new object[] { new VarBase() }, new VarDerived[1], 1));
            Assert.ThrowsException(typeof(InvalidCastException), () => Array.Copy(new VarBase[] { new VarBase() }, new VarDerived[1], 1));
            Assert.ThrowsException(typeof(InvalidCastException), () => Array.Copy(new object[] { "x" }, new int[1], 1));
        }
    }
}
