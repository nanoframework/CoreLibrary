// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Expected values come from running the same code on .NET 10. Each test uses its own types.
    [TestClass]
    public class UnitTestGenericMethodReflectionTests
    {
        #region flags

        [TestMethod]
        public void Flags_OfGenericAndNonGenericMethods()
        {
            MethodInfo id = Method(typeof(GenericMethodSamples), "Id");
            MethodInfo plain = Method(typeof(GenericMethodSamples), "NonGeneric");
            MethodInfo idInt = id.MakeGenericMethod(typeof(int));

            Assert.IsTrue(id.IsGenericMethod);
            Assert.IsTrue(id.IsGenericMethodDefinition);
            Assert.IsTrue(id.ContainsGenericParameters);
            Assert.IsFalse(plain.IsGenericMethod);
            Assert.IsFalse(plain.IsGenericMethodDefinition);
            Assert.IsFalse(plain.ContainsGenericParameters);
            Assert.IsTrue(idInt.IsGenericMethod);
            Assert.IsFalse(idInt.IsGenericMethodDefinition);
            Assert.IsFalse(idInt.ContainsGenericParameters);
        }

        [TestMethod]
        public void Flags_OfMembersOfGenericTypes()
        {
            MethodInfo closed = typeof(GenericMethodHolder<int>).GetMethod("Conv");
            MethodInfo open = typeof(GenericMethodHolder<>).GetMethod("Conv");
            ConstructorInfo ctor = typeof(GenericMethodSamples).GetConstructor(new Type[0]);

            Assert.IsTrue(closed.IsGenericMethodDefinition);
            Assert.IsTrue(closed.ContainsGenericParameters);
            Assert.IsTrue(open.IsGenericMethodDefinition);
            Assert.IsTrue(open.ContainsGenericParameters);
            Assert.IsTrue(typeof(GenericMethodHolder<>).GetMethod("Clear").ContainsGenericParameters);
            Assert.IsFalse(typeof(GenericMethodHolder<int>).GetMethod("Clear").ContainsGenericParameters);
            Assert.IsFalse(typeof(GenericMethodHolder<int>).GetMethod("Clear").IsGenericMethod);
            Assert.IsFalse(ctor.IsGenericMethod);
            Assert.IsFalse(ctor.IsGenericMethodDefinition);
            Assert.IsFalse(ctor.ContainsGenericParameters);
            Assert.IsTrue(typeof(GenericMethodHolder<>).GetConstructor(new Type[0]).ContainsGenericParameters);
            Assert.IsFalse(typeof(GenericMethodHolder<int>).GetConstructor(new Type[0]).ContainsGenericParameters);
        }

        #endregion

        #region GetGenericArguments and GetGenericMethodDefinition

        [TestMethod]
        public void GetGenericArguments_AsDotNet()
        {
            MethodInfo id = Method(typeof(GenericMethodSamples), "Id");
            Type[] parameters = id.GetGenericArguments();
            Type[] arguments = id.MakeGenericMethod(typeof(int)).GetGenericArguments();
            Type[] conv = typeof(GenericMethodHolder<int>).GetMethod("Conv").GetGenericArguments();

            Assert.AreEqual(0, Method(typeof(GenericMethodSamples), "NonGeneric").GetGenericArguments().Length);
            Assert.AreEqual(1, parameters.Length);
            Assert.IsTrue(parameters[0].IsGenericParameter);
            Assert.AreEqual("T", parameters[0].Name);
            Assert.AreEqual(1, arguments.Length);
            Assert.IsTrue(arguments[0] == typeof(int));
            Assert.AreEqual(1, conv.Length);
            Assert.AreEqual("U", conv[0].Name);
            Assert.AreEqual(2, Method(typeof(GenericMethodSamples), "Two").MakeGenericMethod(typeof(int), typeof(string)).GetGenericArguments().Length);
            Assert.IsFalse(object.ReferenceEquals(id.GetGenericArguments(), id.GetGenericArguments()));

            arguments[0] = typeof(string);

            Assert.IsTrue(id.MakeGenericMethod(typeof(int)).GetGenericArguments()[0] == typeof(int));
            Assert.ThrowsException(
                typeof(NotSupportedException),
                () => typeof(GenericMethodSamples).GetConstructor(new Type[0]).GetGenericArguments());
        }

        [TestMethod]
        public void GetGenericMethodDefinition_AsDotNet()
        {
            MethodInfo id = Method(typeof(GenericMethodSamples), "Id");
            MethodInfo conv = typeof(GenericMethodHolder<int>).GetMethod("Conv");

            Assert.IsTrue(id.GetGenericMethodDefinition() == id);
            Assert.IsTrue(object.ReferenceEquals(id.GetGenericMethodDefinition(), id));
            Assert.IsTrue(id.MakeGenericMethod(typeof(int)).GetGenericMethodDefinition() == id);
            Assert.IsTrue(conv.MakeGenericMethod(typeof(string)).GetGenericMethodDefinition() == conv);
            Assert.ThrowsException(
                typeof(InvalidOperationException),
                () => Method(typeof(GenericMethodSamples), "NonGeneric").GetGenericMethodDefinition());
        }

        [TestMethod]
        public void DeclaringMethod_IsTheDefinition()
        {
            MethodInfo id = Method(typeof(GenericMethodSamples), "Id");
            MethodInfo closedConv = typeof(GenericMethodHolder<int>).GetMethod("Conv");
            MethodBase declaring = id.GetGenericArguments()[0].DeclaringMethod;

            Assert.IsTrue(declaring == id);
            Assert.IsTrue(((MethodInfo)declaring).IsGenericMethodDefinition);
            Assert.IsTrue(closedConv.GetGenericArguments()[0].DeclaringMethod == typeof(GenericMethodHolder<>).GetMethod("Conv"));
            Assert.IsFalse(closedConv.GetGenericArguments()[0].DeclaringMethod == closedConv);
            Assert.IsTrue(closedConv.GetGenericArguments()[0] == typeof(GenericMethodHolder<>).GetMethod("Conv").GetGenericArguments()[0]);
        }

        #endregion

        #region MakeGenericMethod

        [TestMethod]
        public void MakeGenericMethod_Identity()
        {
            MethodInfo id = Method(typeof(GenericMethodSamples), "Id");
            MethodInfo idInt = id.MakeGenericMethod(typeof(int));
            MethodInfo conv = typeof(GenericMethodHolder<int>).GetMethod("Conv");

            Assert.IsTrue(idInt == id.MakeGenericMethod(typeof(int)));
            Assert.IsTrue(idInt.Equals(id.MakeGenericMethod(typeof(int))));
            Assert.AreEqual(idInt.GetHashCode(), id.MakeGenericMethod(typeof(int)).GetHashCode());
            Assert.IsFalse(idInt == id.MakeGenericMethod(typeof(string)));
            Assert.IsFalse(idInt == id);
            Assert.AreEqual("Id", idInt.Name);
            Assert.IsTrue(idInt.DeclaringType == typeof(GenericMethodSamples));
            Assert.IsFalse(
                conv.MakeGenericMethod(typeof(string)) ==
                typeof(GenericMethodHolder<long>).GetMethod("Conv").MakeGenericMethod(typeof(string)));
            Assert.IsTrue(conv.MakeGenericMethod(typeof(string)).DeclaringType == typeof(GenericMethodHolder<int>));
            Assert.IsTrue(id.MakeGenericMethod(id.GetGenericArguments()) == id);
            Assert.IsTrue(id.MakeGenericMethod(id.GetGenericArguments()).IsGenericMethodDefinition);
            Assert.IsTrue(conv.MakeGenericMethod(conv.GetGenericArguments()) == conv);
            Assert.IsTrue(conv.MakeGenericMethod(typeof(GenericMethodHolder<>).GetMethod("Conv").GetGenericArguments()) == conv);
        }

        [TestMethod]
        public void MakeGenericMethod_Errors()
        {
            MethodInfo id = Method(typeof(GenericMethodSamples), "Id");
            MethodInfo two = Method(typeof(GenericMethodSamples), "Two");

            Assert.ThrowsException(
                typeof(InvalidOperationException),
                () => Method(typeof(GenericMethodSamples), "NonGeneric").MakeGenericMethod(typeof(int)));
            Assert.ThrowsException(
                typeof(InvalidOperationException),
                () => id.MakeGenericMethod(typeof(int)).MakeGenericMethod(typeof(string)));
            Assert.ThrowsException(typeof(ArgumentException), () => two.MakeGenericMethod(typeof(int)));
            Assert.ThrowsException(typeof(ArgumentException), () => two.MakeGenericMethod(new Type[0]));
            Assert.ThrowsException(typeof(ArgumentNullException), () => two.MakeGenericMethod(null));
            Assert.ThrowsException(typeof(ArgumentNullException), () => two.MakeGenericMethod(typeof(int), null));
            Assert.ThrowsException(typeof(ArgumentException), () => id.MakeGenericMethod(typeof(void)));
        }

        [TestMethod]
        public void MakeGenericMethod_Constraints()
        {
            Assert.AreEqual("ConsClass", Method(typeof(GenericMethodSamples), "ConsClass").MakeGenericMethod(typeof(string)).Name);
            Assert.ThrowsException(typeof(ArgumentException), () => Method(typeof(GenericMethodSamples), "ConsClass").MakeGenericMethod(typeof(int)));
            Assert.AreEqual("ConsStruct", Method(typeof(GenericMethodSamples), "ConsStruct").MakeGenericMethod(typeof(int)).Name);
            Assert.ThrowsException(typeof(ArgumentException), () => Method(typeof(GenericMethodSamples), "ConsStruct").MakeGenericMethod(typeof(string)));
            Assert.AreEqual("ConsNew", Method(typeof(GenericMethodSamples), "ConsNew").MakeGenericMethod(typeof(UnmarkedClass)).Name);
            Assert.ThrowsException(typeof(ArgumentException), () => Method(typeof(GenericMethodSamples), "ConsNew").MakeGenericMethod(typeof(NoDefaultConstructor)));
            Assert.AreEqual("ConsMark", Method(typeof(GenericMethodSamples), "ConsMark").MakeGenericMethod(typeof(ReflectedMarkerClass)).Name);
            Assert.ThrowsException(typeof(ArgumentException), () => Method(typeof(GenericMethodSamples), "ConsMark").MakeGenericMethod(typeof(UnmarkedClass)));
            Assert.AreEqual("ConsSelf", Method(typeof(GenericMethodSamples), "ConsSelf").MakeGenericMethod(typeof(SelfReferencingClass)).Name);
            Assert.ThrowsException(typeof(ArgumentException), () => Method(typeof(GenericMethodSamples), "ConsSelf").MakeGenericMethod(typeof(UnmarkedClass)));
            Assert.AreEqual(
                "ConsBase",
                Method(typeof(GenericMethodSamples), "ConsBase").MakeGenericMethod(typeof(ConstraintDerived), typeof(ConstraintBase)).Name);
            Assert.ThrowsException(
                typeof(ArgumentException),
                () => Method(typeof(GenericMethodSamples), "ConsBase").MakeGenericMethod(typeof(UnmarkedClass), typeof(ConstraintBase)));
            Assert.ThrowsException(
                typeof(ArgumentException),
                () => Method(typeof(GenericMethodSamples), "ConsBase").MakeGenericMethod(typeof(ConstraintBase), typeof(ConstraintDerived)));

            MethodInfo owned = typeof(OwnerConstrainedMethods<ConstraintBase>).GetMethod("Take");

            Assert.AreEqual("Take", owned.MakeGenericMethod(typeof(ConstraintDerived)).Name);
            Assert.ThrowsException(typeof(ArgumentException), () => owned.MakeGenericMethod(typeof(UnmarkedClass)));
        }

        [TestMethod]
        public void MakeGenericMethod_OpenArgumentsAndOwners_AreNotSupported()
        {
            MethodInfo id = Method(typeof(GenericMethodSamples), "Id");

            Assert.ThrowsException(typeof(NotSupportedException), () => id.MakeGenericMethod(typeof(GenericMethodHolder<>).GetGenericArguments()[0]));
            Assert.ThrowsException(typeof(NotSupportedException), () => id.MakeGenericMethod(typeof(GenericMethodHolder<>)));
            Assert.ThrowsException(typeof(NotSupportedException), () => typeof(GenericMethodHolder<>).GetMethod("Conv").MakeGenericMethod(typeof(string)));
        }

        #endregion

        #region signature of an instantiation

        [TestMethod]
        public void ReturnTypeAndParameters_OfAnInstantiation()
        {
            MethodInfo id = Method(typeof(GenericMethodSamples), "Id");
            MethodInfo wrap = Method(typeof(GenericMethodSamples), "Wrap");
            MethodInfo conv = typeof(GenericMethodHolder<int>).GetMethod("Conv").MakeGenericMethod(typeof(string));
            ParameterInfo[] convParameters = conv.GetParameters();

            Assert.IsTrue(id.MakeGenericMethod(typeof(int)).ReturnType == typeof(int));
            Assert.IsTrue(id.MakeGenericMethod(typeof(int)).GetParameters()[0].ParameterType == typeof(int));
            Assert.IsTrue(id.ReturnType.IsGenericParameter);
            Assert.IsTrue(id.ReturnType == id.GetGenericArguments()[0]);
            Assert.IsTrue(id.GetParameters()[0].ParameterType.IsGenericParameter);
            Assert.IsTrue(Method(typeof(GenericMethodSamples), "Array").MakeGenericMethod(typeof(int)).ReturnType == typeof(int[]));
            Assert.IsTrue(wrap.MakeGenericMethod(typeof(int)).ReturnType == typeof(GenericMethodHolder<int>));
            Assert.IsTrue(wrap.MakeGenericMethod(typeof(int)).GetParameters()[0].ParameterType == typeof(GenericMethodHolder<int>[]));
            Assert.IsTrue(wrap.ReturnType.IsGenericType);
            Assert.IsTrue(wrap.ReturnType.ContainsGenericParameters);
            Assert.IsTrue(conv.ReturnType == typeof(string));
            Assert.AreEqual(2, convParameters.Length);
            Assert.IsTrue(convParameters[0].ParameterType == typeof(int));
            Assert.IsTrue(convParameters[1].ParameterType == typeof(string));
        }

        #endregion

        #region Invoke

        [TestMethod]
        public void Invoke_AnInstantiation()
        {
            MethodInfo id = Method(typeof(GenericMethodSamples), "Id");

            Assert.AreEqual(5, (int)id.MakeGenericMethod(typeof(int)).Invoke(null, new object[] { 5 }));
            Assert.AreEqual("abc", (string)id.MakeGenericMethod(typeof(string)).Invoke(null, new object[] { "abc" }));
            Assert.AreEqual(5, (int)id.MakeGenericMethod(typeof(object)).Invoke(null, new object[] { 5 }));
            Assert.AreEqual(2, ((int[])id.MakeGenericMethod(typeof(int[])).Invoke(null, new object[] { new int[] { 1, 2 } })).Length);
            Assert.IsTrue(id.MakeGenericMethod(typeof(GenericMethodHolder<int>)).Invoke(null, new object[] { new GenericMethodHolder<int>() }).GetType() == typeof(GenericMethodHolder<int>));
            Assert.AreEqual("Int32", (string)Method(typeof(GenericMethodSamples), "NameOf").MakeGenericMethod(typeof(int)).Invoke(null, null));
            Assert.AreEqual("GenericMethodHolder`1", (string)Method(typeof(GenericMethodSamples), "NameOf").MakeGenericMethod(typeof(GenericMethodHolder<int>)).Invoke(null, null));
            Assert.AreEqual("Int32[]", (string)Method(typeof(GenericMethodSamples), "NameOf").MakeGenericMethod(typeof(int[])).Invoke(null, null));
            Assert.AreEqual(3, ((int[])Method(typeof(GenericMethodSamples), "Array").MakeGenericMethod(typeof(int)).Invoke(null, new object[] { 3 })).Length);
            Assert.IsTrue(Method(typeof(GenericMethodSamples), "Wrap").MakeGenericMethod(typeof(int)).Invoke(null, new object[] { null }).GetType() == typeof(GenericMethodHolder<int>));
            Assert.AreEqual("z", (string)Method(typeof(GenericMethodSamples), "Two").MakeGenericMethod(typeof(int), typeof(string)).Invoke(null, new object[] { 1, "z" }));
            Assert.AreEqual(4, (int)Method(typeof(GenericMethodSamples), "Instance").MakeGenericMethod(typeof(int)).Invoke(new GenericMethodSamples(), new object[] { 4 }));
        }

        [TestMethod]
        public void Invoke_MembersOfGenericTypes()
        {
            MethodInfo conv = typeof(GenericMethodHolder<int>).GetMethod("Conv").MakeGenericMethod(typeof(string));

            Assert.AreEqual("s", (string)conv.Invoke(new GenericMethodHolder<int>(), new object[] { 1, "s" }));
            Assert.AreEqual("Int32/String", (string)typeof(GenericMethodHolder<int>).GetMethod("Names").MakeGenericMethod(typeof(string)).Invoke(null, null));
            Assert.AreEqual("d", (string)typeof(DerivedGenericMethodHolder).GetMethod("Conv").MakeGenericMethod(typeof(string)).Invoke(new DerivedGenericMethodHolder(), new object[] { 1, "d" }));
        }

        [TestMethod]
        public void Invoke_VirtualAndInterfaceGenericMethods()
        {
            MethodInfo face = typeof(IGenericMethodInterface).GetMethod("M");

            Assert.AreEqual(3, (int)face.MakeGenericMethod(typeof(int)).Invoke(new GenericMethodInterfaceImpl(), new object[] { 3 }));
            Assert.AreEqual("s", (string)face.MakeGenericMethod(typeof(string)).Invoke(new GenericMethodInterfaceImpl(), new object[] { "s" }));
            Assert.AreEqual("derInt32", (string)typeof(AbstractGenericMethods).GetMethod("Who").MakeGenericMethod(typeof(int)).Invoke(new ConcreteGenericMethods(), null));
            Assert.AreEqual("derString", (string)typeof(AbstractGenericMethods).GetMethod("Virt").MakeGenericMethod(typeof(string)).Invoke(new ConcreteGenericMethods(), null));
            Assert.ThrowsException(typeof(TargetException), () => face.MakeGenericMethod(typeof(int)).Invoke(new object(), new object[] { 3 }));
        }

        [TestMethod]
        public void Invoke_Mismatches()
        {
            MethodInfo idInt = Method(typeof(GenericMethodSamples), "Id").MakeGenericMethod(typeof(int));

            Assert.ThrowsException(typeof(ArgumentException), () => idInt.Invoke(null, new object[] { "x" }));
            Assert.ThrowsException(typeof(TargetParameterCountException), () => idInt.Invoke(null, new object[0]));
        }

        [TestMethod]
        public void Invoke_OpenMethods_ThrowInvalidOperation()
        {
            Assert.ThrowsException(typeof(InvalidOperationException), () => Method(typeof(GenericMethodSamples), "Id").Invoke(null, new object[] { 5 }));
            Assert.ThrowsException(typeof(InvalidOperationException), () => Method(typeof(GenericMethodSamples), "Id").Invoke(null, new object[] { null }));
            Assert.ThrowsException(typeof(InvalidOperationException), () => Method(typeof(GenericMethodSamples), "None").Invoke(null, null));
            Assert.ThrowsException(typeof(InvalidOperationException), () => Method(typeof(GenericMethodSamples), "None").Invoke(null, new object[] { 1 }));
            Assert.ThrowsException(typeof(InvalidOperationException), () => typeof(GenericMethodHolder<>).GetMethod("Static").Invoke(null, new object[] { 5 }));
            Assert.ThrowsException(typeof(InvalidOperationException), () => typeof(GenericMethodHolder<>).GetField("Shared").GetValue(null));
        }

        #endregion

        #region delegates

        [TestMethod]
        public void DelegateMethod_NonGeneric_GetParameters()
        {
            Action none = GenericMethodSamples.NonGeneric;
            Func<int, string, int> two = GenericMethodSamples.TwoArgs;

            Assert.AreEqual(0, none.Method.GetParameters().Length);
            Assert.AreEqual(2, two.Method.GetParameters().Length);
            Assert.IsTrue(two.Method.GetParameters()[1].ParameterType == typeof(string));
        }

        [TestMethod]
        public void DelegateMethod_OfAGenericMethod_IsTheInstantiation()
        {
            MethodInfo id = Method(typeof(GenericMethodSamples), "Id");
            Func<int, int> ofInt = GenericMethodSamples.Id<int>;
            Func<string, string> ofString = GenericMethodSamples.Id<string>;
            Func<int, string, string> conv = new GenericMethodHolder<int>().Conv<string>;

            Assert.IsTrue(ofInt.Method.IsGenericMethod);
            Assert.IsFalse(ofInt.Method.IsGenericMethodDefinition);
            Assert.IsTrue(ofInt.Method == id.MakeGenericMethod(typeof(int)));
            Assert.IsFalse(ofString.Method == id.MakeGenericMethod(typeof(int)));
            Assert.IsTrue(ofInt.Method.GetGenericArguments()[0] == typeof(int));
            Assert.IsTrue(ofInt.Method.GetParameters()[0].ParameterType == typeof(int));
            Assert.IsTrue(ofInt.Method.ReturnType == typeof(int));
            Assert.IsTrue(conv.Method == typeof(GenericMethodHolder<int>).GetMethod("Conv").MakeGenericMethod(typeof(string)));
            Assert.IsTrue(conv.Method.DeclaringType == typeof(GenericMethodHolder<int>));
        }

        #endregion

        private static MethodInfo Method(Type type, string name)
        {
            return type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        }
    }

    public interface IReflectedMarker { }

    public interface ISelfReferencing<T> { }

    public class UnmarkedClass { }

    public class ConstraintBase { }

    public class ConstraintDerived : ConstraintBase { }

    public class ReflectedMarkerClass : IReflectedMarker { }

    public class SelfReferencingClass : ISelfReferencing<SelfReferencingClass> { }

    public class NoDefaultConstructor
    {
        public NoDefaultConstructor(int x) { }
    }

    public class GenericMethodSamples
    {
        public static void NonGeneric() { }

        public static int TwoArgs(int a, string b) { return a; }

        public static T Id<T>(T t) { return t; }

        public static U Two<T, U>(T t, U u) { return u; }

        public static int None<T>() { return 2; }

        public static string NameOf<T>() { return typeof(T).Name; }

        public static T[] Array<T>(int n) { return new T[n]; }

        public static GenericMethodHolder<T> Wrap<T>(GenericMethodHolder<T>[] boxes) { return new GenericMethodHolder<T>(); }

        public static void ConsClass<T>() where T : class { }

        public static void ConsStruct<T>() where T : struct { }

        public static void ConsNew<T>() where T : new() { }

        public static void ConsMark<T>() where T : IReflectedMarker { }

        public static void ConsSelf<T>() where T : ISelfReferencing<T> { }

        public static void ConsBase<T, U>() where T : U where U : ConstraintBase { }

        public T Instance<T>(T t) { return t; }
    }

    public class GenericMethodHolder<T>
    {
        public static int Shared;

        public U Conv<U>(T t, U u) { return u; }

        public static string Names<U>() { return typeof(T).Name + "/" + typeof(U).Name; }

        public static int Static(int x) { return x; }

        public void Clear() { }
    }

    public class DerivedGenericMethodHolder : GenericMethodHolder<int> { }

    public class OwnerConstrainedMethods<T>
    {
        public void Take<U>() where U : T { }
    }

    public interface IGenericMethodInterface
    {
        U M<U>(U u);
    }

    public class GenericMethodInterfaceImpl : IGenericMethodInterface
    {
        public U M<U>(U u) { return u; }
    }

    public abstract class AbstractGenericMethods
    {
        public abstract string Who<T>();

        public virtual string Virt<T>() { return "base" + typeof(T).Name; }
    }

    public class ConcreteGenericMethods : AbstractGenericMethods
    {
        public override string Who<T>() { return "der" + typeof(T).Name; }

        public override string Virt<T>() { return "der" + typeof(T).Name; }
    }
}
