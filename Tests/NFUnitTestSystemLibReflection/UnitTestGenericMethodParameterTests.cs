// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    public class MpBox<T>
    {
        public T Value;
    }

    public class MpPlain
    {
    }

    public static class MpMethods
    {
        public static Type TypeOf<T>() { return typeof(T); }
        public static Type TypeOfArray<T>() { return typeof(T[]); }
        public static Type TypeOfJagged<T>() { return typeof(T[][]); }
        public static Type TypeOfBox<T>() { return typeof(MpBox<T>); }
        public static Type TypeOfBoxArray<T>() { return typeof(MpBox<T>[]); }
        public static Type GetTypeOfValue<T>(T value) { return value.GetType(); }
        public static object Default<T>() { return default(T); }
        public static bool IsOf<T>(object o) { return o is T; }
        public static bool IsOfArray<T>(object o) { return o is T[]; }
        public static bool IsBoxOf<T>(object o) { return o is MpBox<T>; }
        public static object CastArray<T>(object o) { return (T[])o; }
        public static object CastBox<T>(object o) { return (MpBox<T>)o; }
        public static Type Outer<T>() { return Inner<T>(); }
        public static Type Inner<T>() { return typeof(T); }
        public static Type Outer3<T>() { return Mid<T>(); }
        public static Type Mid<T>() { return Inner<T>(); }
        public static Type TypeOfInBox<T>() { return new MpBox<T>().GetType(); }
    }

    public class MpHolder<T>
    {
        public Type ClassT() { return typeof(T); }
        public Type MethodT<U>() { return typeof(U); }
        public Type Both<U>() { return typeof(MpBox<U>); }
        public Type ViaMethodOfClassParameter() { return MpMethods.TypeOf<T>(); }
        public Type ViaMethodOfClassParameterBox() { return MpMethods.TypeOfBox<T>(); }
        public Type MethodTWithClassContext<U>() { return MpMethods.TypeOf<U>(); }
        public Type ClassBox() { return typeof(MpBox<T>); }
        public Type ClassArray() { return typeof(T[]); }
        public bool IsBoxOfT(object o) { return o is MpBox<T>; }
        public bool IsBoxOfU<U>(object o) { return o is MpBox<U>; }
        public bool IsArrayOfU<U>(object o) { return o is U[]; }
    }

    // delegates
    public delegate object MpMake();

    public static class MpDelegates
    {
        public static object Arr<T>() { return new T[1]; }
        public static Type Ty<T>() { return typeof(T); }
        public static MpMake FromMethodSpec() { return Arr<int>; }
        public static MpMake FromGenericMethod<T>() { return Arr<T>; }
        public static Func<Type> TypeFromGenericMethod<T>() { return Ty<T>; }
        public static string Order = string.Empty;
        public static Func<object> Lambda<T>() { return () => new T[1]; }
        public static Func<object> Recording<T>(string name) { return () => { Order += name; return new T[1]; }; }
        public static Func<object> Closure<T>(T seed) { return () => new T[] { seed }; }
        public static Func<Type> LambdaType<T>() { return () => typeof(T); }
    }

    public class MpDelegateHolder<T>
    {
        public object Arr() { return new T[1]; }
        public object ArrOf<U>() { return new U[1]; }
        public MpMake FromInstance() { return Arr; }
        public MpMake FromStaticMethodSpec() { return MpDelegates.Arr<T>; }
        public MpMake FromInstanceMethodSpec() { return ArrOf<T>; }
        public MpMake FromInstanceMethodSpecInt() { return ArrOf<int>; }
        public Func<object> Lambda() { return () => new T[1]; }
        public Func<object> LambdaWithMethod<U>() { return () => new U[1]; }
        public Func<object> LambdaBoth<U>() { return () => new MpBox<T>[] { null }; }
    }

    // The generic context of a method type parameter: typeof(T), casts to T[], and delegates created in generic code.
    [TestClass]
    public class UnitTestGenericMethodParameterTests
    {
        // typeof, casts and arrays of a method type parameter, and of a closed generic argument
        [TestMethod] public void TypeOf_Int() { Assert.AreEqual(typeof(int), MpMethods.TypeOf<int>()); }
        [TestMethod] public void TypeOf_String() { Assert.AreEqual(typeof(string), MpMethods.TypeOf<string>()); }
        [TestMethod] public void TypeOf_Class() { Assert.AreEqual(typeof(MpPlain), MpMethods.TypeOf<MpPlain>()); }
        [TestMethod] public void TypeOf_Array() { Assert.AreEqual(typeof(int[]), MpMethods.TypeOfArray<int>()); }
        [TestMethod] public void TypeOf_Jagged() { Assert.AreEqual(typeof(int[][]), MpMethods.TypeOfJagged<int>()); }
        [TestMethod] public void TypeOf_Box() { Assert.AreEqual(typeof(MpBox<int>), MpMethods.TypeOfBox<int>()); }
        [TestMethod] public void TypeOf_BoxDiffers() { Assert.AreNotEqual(typeof(MpBox<string>), MpMethods.TypeOfBox<int>()); }
        [TestMethod] public void TypeOf_BoxArray() { Assert.AreEqual(typeof(MpBox<int>[]), MpMethods.TypeOfBoxArray<int>()); }
        [TestMethod] public void TypeOf_ArgumentIsGenericInstance() { Assert.AreEqual(typeof(MpBox<int>), MpMethods.TypeOf<MpBox<int>>()); }
        [TestMethod] public void TypeOf_ArgumentIsArray() { Assert.AreEqual(typeof(int[]), MpMethods.TypeOf<int[]>()); }
        [TestMethod] public void GetTypeOfValue() { Assert.AreEqual(typeof(int), MpMethods.GetTypeOfValue<int>(3)); }
        [TestMethod] public void GetTypeOfValueRef() { Assert.AreEqual(typeof(string), MpMethods.GetTypeOfValue<string>("a")); }
        [TestMethod] public void DefaultInt() { Assert.AreEqual(0, (int)MpMethods.Default<int>()); }
        [TestMethod] public void DefaultRef() { Assert.IsNull(MpMethods.Default<string>()); }
        [TestMethod] public void IsOf() { Assert.IsTrue(MpMethods.IsOf<int>(3)); Assert.IsFalse(MpMethods.IsOf<string>(3)); }
        [TestMethod] public void IsOfArray() { Assert.IsTrue(MpMethods.IsOfArray<int>(new int[1])); Assert.IsFalse(MpMethods.IsOfArray<string>(new int[1])); }
        [TestMethod] public void Nested() { Assert.AreEqual(typeof(int), MpMethods.Outer<int>()); }
        [TestMethod] public void Nested3() { Assert.AreEqual(typeof(string), MpMethods.Outer3<string>()); }
        [TestMethod] public void TypeOfInBox() { Assert.AreEqual(typeof(MpBox<int>), MpMethods.TypeOfInBox<int>()); }

        // class T and method T together
        [TestMethod] public void ClassT() { Assert.AreEqual(typeof(int), new MpHolder<int>().ClassT()); }
        [TestMethod] public void MethodTInGenericClass() { Assert.AreEqual(typeof(string), new MpHolder<int>().MethodT<string>()); }
        [TestMethod] public void BothInGenericClass() { Assert.AreEqual(typeof(MpBox<string>), new MpHolder<int>().Both<string>()); }
        [TestMethod] public void GenericMethodOfClassParameter() { Assert.AreEqual(typeof(int), new MpHolder<int>().ViaMethodOfClassParameter()); }
        [TestMethod] public void GenericMethodOfClassParameterBox() { Assert.AreEqual(typeof(MpBox<string>), new MpHolder<string>().ViaMethodOfClassParameterBox()); }
        [TestMethod] public void MethodTWithClassContext() { Assert.AreEqual(typeof(string), new MpHolder<int>().MethodTWithClassContext<string>()); }

        [TestMethod] public void ClassT_IsGenericInstance() { Assert.AreEqual(typeof(MpBox<int>), new MpHolder<MpBox<int>>().ClassT()); }
        [TestMethod] public void ClassBox() { Assert.AreEqual(typeof(MpBox<int>), new MpHolder<int>().ClassBox()); }
        [TestMethod] public void ClassArray() { Assert.AreEqual(typeof(int[]), new MpHolder<int>().ClassArray()); }
        [TestMethod] public void ClassIsBoxOfT() { Assert.IsTrue(new MpHolder<int>().IsBoxOfT(new MpBox<int>())); Assert.IsFalse(new MpHolder<int>().IsBoxOfT(new MpBox<string>())); }
        [TestMethod] public void MethodIsBoxOfU() { Assert.IsTrue(new MpHolder<int>().IsBoxOfU<string>(new MpBox<string>())); Assert.IsFalse(new MpHolder<int>().IsBoxOfU<string>(new MpBox<int>())); }
        [TestMethod] public void MethodIsBox() { Assert.IsTrue(MpMethods.IsBoxOf<int>(new MpBox<int>())); Assert.IsFalse(MpMethods.IsBoxOf<int>(new MpBox<string>())); }
        [TestMethod] public void CastArray_Ok() { Assert.IsNotNull(MpMethods.CastArray<int>(new int[1])); }
        [TestMethod] public void CastArray_Wrong() { Assert.ThrowsException(typeof(InvalidCastException), () => { MpMethods.CastArray<string>(new int[1]); }); }
        [TestMethod] public void CastBox_Ok() { Assert.IsNotNull(MpMethods.CastBox<int>(new MpBox<int>())); }
        [TestMethod] public void CastBox_Wrong() { Assert.ThrowsException(typeof(InvalidCastException), () => { MpMethods.CastBox<string>(new MpBox<int>()); }); }
        [TestMethod] public void ClassMethodIsArrayOfU() { Assert.IsTrue(new MpHolder<int>().IsArrayOfU<string>(new string[1])); Assert.IsFalse(new MpHolder<int>().IsArrayOfU<string>(new int[1])); }

        [TestMethod]
        public void EqualityOfDifferentInstantiations()
        {
            MpMake a = MpDelegates.Arr<int>;
            MpMake b = MpDelegates.Arr<string>;
            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void RemoveOfDifferentInstantiation()
        {
            MpMake a = MpDelegates.Arr<int>;
            MpMake b = MpDelegates.Arr<string>;
            MpMake m = (MpMake)Delegate.Combine(a, b);
            MpMake r = (MpMake)Delegate.Remove(m, b);
            Assert.IsTrue(r.Equals(a));
        }

        // delegates of generic methods and of methods of generic classes
        [TestMethod] public void MethodSpecDirect() { Assert.IsTrue(MpDelegates.FromMethodSpec()() is int[]); }
        [TestMethod] public void MethodSpecOfParameter_Int() { Assert.IsTrue(MpDelegates.FromGenericMethod<int>()() is int[]); }
        [TestMethod] public void MethodSpecOfParameter_Two()
        {
            MpMake a = MpDelegates.FromGenericMethod<int>();
            MpMake b = MpDelegates.FromGenericMethod<string>();
            Assert.IsTrue(a() is int[]);
            Assert.IsTrue(b() is string[]);
            Assert.IsFalse(b() is int[]);
        }
        [TestMethod] public void Lambda_NonCapturing() { Assert.IsTrue(MpDelegates.Lambda<int>()() is int[]); }
        [TestMethod] public void Lambda_Capturing()
        {
            Func<object> f = MpDelegates.Closure<string>("x");
            Assert.IsTrue(f() is string[]);
            Assert.AreEqual("x", ((string[])f())[0]);
        }
        [TestMethod] public void Class_InstanceDelegate() { Assert.IsTrue(new MpDelegateHolder<int>().FromInstance()() is int[]); }
        [TestMethod] public void Class_StaticMethodSpecOfClassParameter() { Assert.IsTrue(new MpDelegateHolder<int>().FromStaticMethodSpec()() is int[]); }
        [TestMethod] public void Class_InstanceMethodSpecOfClassParameter() { Assert.IsTrue(new MpDelegateHolder<int>().FromInstanceMethodSpec()() is int[]); }
        [TestMethod] public void Class_InstanceMethodSpecInt() { Assert.IsTrue(new MpDelegateHolder<string>().FromInstanceMethodSpecInt()() is int[]); }
        [TestMethod] public void Class_Lambda() { Assert.IsTrue(new MpDelegateHolder<int>().Lambda()() is int[]); }
        [TestMethod] public void Class_LambdaWithMethodParameter() { Assert.IsTrue(new MpDelegateHolder<int>().LambdaWithMethod<string>()() is string[]); }
        [TestMethod] public void Class_LambdaBoth() { Assert.IsTrue(new MpDelegateHolder<int>().LambdaBoth<string>()() is MpBox<int>[]); }
        [TestMethod]
        public void Multicast()
        {
            MpDelegates.Order = string.Empty;

            Func<object> f = MpDelegates.Recording<int>("f");
            Func<object> g = MpDelegates.Recording<string>("g");
            Func<object> m = (Func<object>)Delegate.Combine(f, g);
            object last = m();

            Assert.AreEqual("fg", MpDelegates.Order);
            Assert.IsTrue(last is string[]);
            Assert.IsFalse(last is int[]);
        }
        [TestMethod]
        public void InvokedAfterFrameGone()
        {
            MpMake a = MpDelegates.FromGenericMethod<int>();
            MpMake b = new MpDelegateHolder<string>().FromStaticMethodSpec();
            GC.Collect();
            Assert.IsTrue(a() is int[]);
            Assert.IsTrue(b() is string[]);
        }
        [TestMethod] public void TypeOfViaDelegate_Direct() { Assert.AreEqual(typeof(int), ((Func<Type>)MpDelegates.Ty<int>)()); }
        [TestMethod] public void TypeOfViaDelegate_Parameter() { Assert.AreEqual(typeof(string), MpDelegates.TypeFromGenericMethod<string>()()); }
        [TestMethod] public void TypeOfViaLambda() { Assert.AreEqual(typeof(int), MpDelegates.LambdaType<int>()()); }
    }
}
