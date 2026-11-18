// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Expected values come from running the same code on .NET. Each test uses its own types.
    [TestClass]
    public class UnitTestGenericParameterTypeTests
    {
        #region arguments

        [TestMethod]
        public void Arguments_OfDefinition()
        {
            Type[] one = typeof(GpBox<>).GetGenericArguments();
            Type[] two = typeof(GpPair<,>).GetGenericArguments();

            Assert.AreEqual(1, one.Length);
            Assert.AreEqual("T", one[0].Name);
            Assert.IsTrue(one[0].IsGenericParameter);
            Assert.AreEqual(2, two.Length);
            Assert.AreEqual("K", two[0].Name);
            Assert.AreEqual("V", two[1].Name);
            Assert.AreEqual(0, two[0].GenericParameterPosition);
            Assert.AreEqual(1, two[1].GenericParameterPosition);
            Assert.IsTrue(two[0] != two[1]);
        }

        [TestMethod]
        public void Arguments_OfNestedDefinition()
        {
            Type[] inner = typeof(GpOuter<>.Inner<>).GetGenericArguments();
            Type outerT = typeof(GpOuter<>).GetGenericArguments()[0];

            Assert.AreEqual(2, inner.Length);
            Assert.AreEqual("T", inner[0].Name);
            Assert.AreEqual("U", inner[1].Name);
            Assert.IsTrue(inner[0].DeclaringType == typeof(GpOuter<>.Inner<>));
            Assert.IsTrue(inner[0] != outerT);
            Assert.IsTrue(outerT.DeclaringType == typeof(GpOuter<>));
        }

        [TestMethod]
        public void Arguments_OfOtherTypes()
        {
            Assert.AreEqual(0, typeof(GpPlain).GetGenericArguments().Length);
            Assert.AreEqual(0, typeof(int[]).GetGenericArguments().Length);
            Assert.AreEqual(1, typeof(GpBox<int>).GetGenericArguments().Length);
            Assert.IsTrue(typeof(GpBox<int>).GetGenericArguments()[0] == typeof(int));
            Assert.AreEqual(0, typeof(GpBox<>).GetGenericArguments()[0].GetGenericArguments().Length);
        }

        [TestMethod]
        public void Arguments_OfOpenConstructed()
        {
            Type baseType = typeof(GpDerived<>).BaseType;
            Type[] arguments = baseType.GetGenericArguments();

            Assert.AreEqual(1, arguments.Length);
            Assert.IsTrue(arguments[0].IsGenericParameter);
            Assert.IsTrue(arguments[0] == typeof(GpDerived<>).GetGenericArguments()[0]);
            Assert.IsTrue(arguments[0] != typeof(GpBox<>).GetGenericArguments()[0]);
            Assert.IsTrue(arguments[0] != typeof(GpOtherDerived<>).BaseType.GetGenericArguments()[0]);
        }

        [TestMethod]
        public void Arguments_OfOpenNested()
        {
            Type baseType = typeof(GpDerivedList<>).BaseType;
            Type inner = baseType.GetGenericArguments()[0];

            Assert.IsTrue(inner.IsConstructedGenericType);
            Assert.IsTrue(inner.ContainsGenericParameters);
            Assert.IsTrue(inner.GetGenericTypeDefinition() == typeof(GpOther<>));
            Assert.IsTrue(inner.GetGenericArguments()[0] == typeof(GpDerivedList<>).GetGenericArguments()[0]);
        }

        #endregion

        #region parameter type

        [TestMethod]
        public void Parameter_Properties()
        {
            Type t = typeof(GpBox<>).GetGenericArguments()[0];

            Assert.AreEqual("T", t.Name);
            Assert.IsNull(t.FullName);
            Assert.AreEqual("T", t.ToString());
            Assert.IsTrue(t.IsGenericParameter);
            Assert.AreEqual(0, t.GenericParameterPosition);
            Assert.IsTrue(t.DeclaringType == typeof(GpBox<>));
            Assert.IsNull(t.DeclaringMethod);
            Assert.IsFalse(t.IsGenericType);
            Assert.IsFalse(t.IsGenericTypeDefinition);
            Assert.IsFalse(t.IsConstructedGenericType);
            Assert.IsTrue(t.ContainsGenericParameters);
            Assert.IsFalse(t.IsArray);
            Assert.IsNull(t.GetElementType());
            Assert.AreEqual(0, t.GetGenericArguments().Length);
            Assert.IsNotNull(t.Assembly);
            Assert.IsNull(t.AssemblyQualifiedName);
        }

        [TestMethod]
        public void Parameter_UnconstrainedShape()
        {
            Type t = typeof(GpBox<>).GetGenericArguments()[0];

            Assert.IsTrue(t.IsClass);
            Assert.IsFalse(t.IsValueType);
            Assert.IsFalse(t.IsInterface);
            Assert.IsFalse(t.IsAbstract);
            Assert.IsFalse(t.IsEnum);
            Assert.IsTrue(t.IsPublic);
            Assert.IsFalse(t.IsNotPublic);
            Assert.IsTrue(t.BaseType == typeof(object));
            Assert.AreEqual(0, t.GetInterfaces().Length);
        }

        [TestMethod]
        public void Parameter_InvalidOperations()
        {
            Type t = typeof(GpBox<>).GetGenericArguments()[0];

            Assert.IsTrue(ThrowsInvalidOperation(() => t.GetGenericTypeDefinition()));
            Assert.IsTrue(ThrowsInvalidOperation(() => typeof(int).GenericParameterPosition));
            Assert.IsTrue(ThrowsInvalidOperation(() => typeof(int).DeclaringMethod));
            Assert.IsTrue(ThrowsInvalidOperation(() => typeof(GpBox<>).GenericParameterPosition));
            Assert.IsTrue(ThrowsInvalidOperation(() => typeof(GpBox<int>[]).DeclaringMethod));
        }

        [TestMethod]
        public void Parameter_NotAnInstanceType()
        {
            Type t = typeof(GpBox<>).GetGenericArguments()[0];

            Assert.IsFalse(t.IsInstanceOfType("x"));
            Assert.IsFalse(t.IsInstanceOfType(1));
            Assert.IsFalse(t.IsInstanceOfType(null));
        }

        [TestMethod]
        public void Parameter_Unsupported()
        {
            Type t = typeof(GpBox<>).GetGenericArguments()[0];

            Assert.IsTrue(ThrowsNotSupported(() => t.GetMethods()));
            Assert.IsTrue(ThrowsNotSupported(() => t.GetFields()));
            Assert.IsTrue(ThrowsNotSupported(() => t.GetConstructors()));
        }

        #endregion

        #region constraints are not supported yet

        [TestMethod]
        public void Constrained_NameAndPosition()
        {
            Type t = typeof(GpClassConstraint<>).GetGenericArguments()[0];

            Assert.IsTrue(t.IsGenericParameter);
            Assert.AreEqual("T", t.Name);
            Assert.AreEqual(0, t.GenericParameterPosition);
            Assert.IsTrue(t.DeclaringType == typeof(GpClassConstraint<>));
            Assert.IsTrue(t.ContainsGenericParameters);
            Assert.IsTrue(t.IsAssignableFrom(t));
        }

        [TestMethod]
        public void Constrained_ShapeUnsupported()
        {
            Type t = typeof(GpClassConstraint<>).GetGenericArguments()[0];
            Type s = typeof(GpStructConstraint<>).GetGenericArguments()[0];
            Type b = typeof(GpBaseConstraint<>).GetGenericArguments()[0];

            Assert.IsTrue(ThrowsNotSupported(() => t.BaseType));
            Assert.IsTrue(ThrowsNotSupported(() => t.GetInterfaces()));
            Assert.IsTrue(ThrowsNotSupported(() => t.IsClass));
            Assert.IsTrue(ThrowsNotSupported(() => s.IsValueType));
            Assert.IsTrue(ThrowsNotSupported(() => b.BaseType));
            Assert.IsTrue(ThrowsNotSupported(() => typeof(object).IsAssignableFrom(b)));
            Assert.IsTrue(ThrowsNotSupported(() => b.IsAssignableFrom(typeof(GpPlain))));
        }

        #endregion

        #region identity

        [TestMethod]
        public void Identity_SameParameterAnyPath()
        {
            Type definition = typeof(GpBox<>).GetGenericArguments()[0];
            Type field = typeof(GpBox<>).GetField("Item").FieldType;
            Type returned = typeof(GpBox<>).GetMethod("Get").ReturnType;

            Assert.IsTrue(definition == field);
            Assert.IsTrue(definition == returned);
            Assert.IsTrue(definition.Equals(field));
            Assert.IsTrue(object.Equals(definition, returned));
            Assert.AreEqual(definition.GetHashCode(), field.GetHashCode());
            Assert.AreEqual(definition.GetHashCode(), returned.GetHashCode());
        }

        [TestMethod]
        public void Identity_DifferentOwnersDiffer()
        {
            Type a = typeof(GpBox<>).GetGenericArguments()[0];
            Type b = typeof(GpOther<>).GetGenericArguments()[0];

            Assert.IsTrue(a != b);
            Assert.IsFalse(a.Equals(b));
            Assert.IsTrue(a != typeof(int));
            Assert.IsFalse(a.Equals(null));
        }

        #endregion

        #region contains generic parameters

        [TestMethod]
        public void Contains_Matrix()
        {
            Assert.IsTrue(typeof(GpBox<>).ContainsGenericParameters);
            Assert.IsTrue(typeof(GpBox<>).GetGenericArguments()[0].ContainsGenericParameters);
            Assert.IsTrue(typeof(GpDerived<>).BaseType.ContainsGenericParameters);
            Assert.IsFalse(typeof(GpBox<int>).ContainsGenericParameters);
            Assert.IsFalse(typeof(GpBox<int>[]).ContainsGenericParameters);
            Assert.IsFalse(typeof(GpBox<GpOther<int>>).ContainsGenericParameters);
            Assert.IsFalse(typeof(int).ContainsGenericParameters);
            Assert.IsFalse(typeof(int[]).ContainsGenericParameters);
            Assert.IsFalse(typeof(GpPlain).ContainsGenericParameters);
            Assert.IsFalse(typeof(GpDerived<string>).BaseType.ContainsGenericParameters);
            Assert.IsTrue(typeof(GpOuter<>.Inner<>).ContainsGenericParameters);
        }

        [TestMethod]
        public void Constructed_Matrix()
        {
            Assert.IsTrue(typeof(GpBox<int>).IsConstructedGenericType);
            Assert.IsTrue(typeof(GpDerived<>).BaseType.IsConstructedGenericType);
            Assert.IsFalse(typeof(GpBox<>).IsConstructedGenericType);
            Assert.IsFalse(typeof(GpBox<>).GetGenericArguments()[0].IsConstructedGenericType);
            Assert.IsFalse(typeof(int).IsConstructedGenericType);
            Assert.IsFalse(typeof(GpBox<int>[]).IsConstructedGenericType);
        }

        #endregion

        #region members of a definition

        [TestMethod]
        public void Members_FieldAndReturn()
        {
            Type t = typeof(GpBox<>).GetGenericArguments()[0];

            Assert.IsTrue(typeof(GpBox<>).GetField("Item").FieldType == t);
            Assert.IsTrue(typeof(GpBox<>).GetMethod("Get").ReturnType == t);
            Assert.IsTrue(typeof(GpBox<>).GetMethod("Put").GetParameters()[0].ParameterType == t);
            Assert.IsTrue(typeof(GpPair<,>).GetField("Second").FieldType == typeof(GpPair<,>).GetGenericArguments()[1]);
        }

        [TestMethod]
        public void Members_ArrayOfParameter()
        {
            Type t = typeof(GpBox<>).GetGenericArguments()[0];
            Type items = typeof(GpBox<>).GetField("Items").FieldType;

            Assert.IsTrue(items.IsArray);
            Assert.IsFalse(items.IsGenericParameter);
            Assert.IsTrue(items.GetElementType() == t);
            Assert.IsTrue(items.ContainsGenericParameters);
            Assert.AreEqual("T[]", items.Name);
            Assert.IsNull(items.FullName);
            Assert.IsTrue(items != t);
            Assert.IsTrue(items == typeof(GpBox<>).GetMethod("GetAll").ReturnType);
        }

        [TestMethod]
        public void Members_OpenConstructed()
        {
            Type t = typeof(GpBox<>).GetGenericArguments()[0];
            Type boxed = typeof(GpBox<>).GetField("Boxed").FieldType;

            Assert.IsTrue(boxed.IsConstructedGenericType);
            Assert.IsFalse(boxed.IsGenericTypeDefinition);
            Assert.IsTrue(boxed.ContainsGenericParameters);
            Assert.IsTrue(boxed.GetGenericTypeDefinition() == typeof(GpOther<>));
            Assert.IsTrue(boxed.GetGenericArguments()[0] == t);
            Assert.IsNull(boxed.FullName);
            Assert.IsTrue(boxed != typeof(GpOther<int>));
            Assert.IsTrue(boxed != typeof(GpOther<>));
            Assert.IsTrue(boxed == typeof(GpBox<>).GetMethod("GetBoxed").ReturnType);
        }

        [TestMethod]
        public void Members_MethodParameter()
        {
            Type t = typeof(GpBox<>).GetGenericArguments()[0];
            System.Reflection.MethodInfo map = typeof(GpBox<>).GetMethod("Map");
            Type u = map.ReturnType;
            System.Reflection.ParameterInfo[] parameters = map.GetParameters();

            Assert.IsTrue(u.IsGenericParameter);
            Assert.AreEqual("U", u.Name);
            Assert.AreEqual(0, u.GenericParameterPosition);
            Assert.IsTrue(u.DeclaringType == typeof(GpBox<>));
            Assert.IsNotNull(u.DeclaringMethod);
            Assert.AreEqual("Map", u.DeclaringMethod.Name);
            Assert.IsTrue(u != t);
            Assert.IsTrue(parameters[0].ParameterType == u);
            Assert.IsTrue(parameters[1].ParameterType == t);
        }

        [TestMethod]
        public void Members_GenericMethodOfPlainType()
        {
            System.Reflection.MethodInfo identity = typeof(GpMethods).GetMethod("Identity");
            Type u = identity.ReturnType;

            Assert.IsTrue(u.IsGenericParameter);
            Assert.AreEqual("U", u.Name);
            Assert.IsTrue(u.DeclaringType == typeof(GpMethods));
            Assert.AreEqual("Identity", u.DeclaringMethod.Name);
            Assert.IsTrue(identity.GetParameters()[0].ParameterType == u);
            Assert.IsTrue(typeof(GpMethods).GetMethod("TakesArray").GetParameters()[0].ParameterType.IsArray);
            Assert.IsTrue(typeof(GpMethods).GetMethod("TakesArray").GetParameters()[0].ParameterType.GetElementType().IsGenericParameter);
            System.Reflection.MethodInfo takesOther = typeof(GpMethods).GetMethod("TakesOther");

            Assert.IsNotNull(takesOther);
            Assert.IsTrue(ThrowsNotSupported(() => takesOther.GetParameters()));
        }

        [TestMethod]
        public void Members_ClosedTypeIsUnchanged()
        {
            Assert.IsTrue(typeof(GpBox<int>).GetField("Item").FieldType == typeof(int));
            Assert.IsTrue(typeof(GpBox<int>).GetField("Boxed").FieldType == typeof(GpOther<int>));
            Assert.IsTrue(typeof(GpBox<int>).GetField("Items").FieldType == typeof(int[]));
            Assert.IsTrue(typeof(GpBox<int>).GetMethod("Get").ReturnType == typeof(int));
            Assert.IsTrue(typeof(GpBox<int>).GetMethod("Map").ReturnType.IsGenericParameter);
        }

        [TestMethod]
        public void Members_InheritedThroughDefinition()
        {
            Type derivedT = typeof(GpDerived<>).GetGenericArguments()[0];
            Type boxT = typeof(GpBox<>).GetGenericArguments()[0];
            Type boxed = typeof(GpDerived<>).GetField("Boxed").FieldType;

            Assert.IsTrue(typeof(GpDerived<>).GetField("Item").FieldType == derivedT);
            Assert.IsTrue(typeof(GpDerived<>).GetField("Item").FieldType != boxT);
            Assert.IsTrue(typeof(GpDerived<>).GetMethod("Get").ReturnType == derivedT);
            Assert.IsTrue(boxed.GetGenericArguments()[0] == derivedT);
            Assert.IsTrue(typeof(GpDerived<>).GetField("Items").FieldType.GetElementType() == derivedT);
        }

        [TestMethod]
        public void Members_InheritedThroughClosedType()
        {
            Assert.IsTrue(typeof(GpDerived<string>).GetField("Item").FieldType == typeof(string));
            Assert.IsTrue(typeof(GpDerived<string>).GetField("Boxed").FieldType == typeof(GpOther<string>));
        }

        #endregion

        #region interfaces and assignability

        [TestMethod]
        public void Interfaces_OfOpenDefinition()
        {
            Type[] interfaces = typeof(GpWithInterface<>).GetInterfaces();
            Type t = typeof(GpWithInterface<>).GetGenericArguments()[0];

            Assert.AreEqual(1, interfaces.Length);
            Assert.IsTrue(interfaces[0].ContainsGenericParameters);
            Assert.IsTrue(interfaces[0].GetGenericArguments()[0] == t);
        }

        [TestMethod]
        public void Assignable_Unconstrained()
        {
            Type t = typeof(GpBox<>).GetGenericArguments()[0];
            Type other = typeof(GpOther<>).GetGenericArguments()[0];

            Assert.IsTrue(t.IsAssignableFrom(t));
            Assert.IsTrue(typeof(object).IsAssignableFrom(t));
            Assert.IsFalse(t.IsAssignableFrom(typeof(object)));
            Assert.IsFalse(t.IsAssignableFrom(typeof(string)));
            Assert.IsFalse(typeof(string).IsAssignableFrom(t));
            Assert.IsFalse(typeof(ValueType).IsAssignableFrom(t));
            Assert.IsFalse(t.IsAssignableFrom(other));
            Assert.IsFalse(t.IsAssignableFrom(null));
        }

        [TestMethod]
        public void Assignable_ArraysOfParametersAreUnsupported()
        {
            Type items = typeof(GpBox<>).GetField("Items").FieldType;

            Assert.IsTrue(items.IsAssignableFrom(items));
            Assert.IsTrue(ThrowsNotSupported(() => typeof(object[]).IsAssignableFrom(items)));
        }

        #endregion

        #region unchanged behaviour

        [TestMethod]
        public void TypeOfParameterInsideClosedType_IsTheArgument()
        {
            Assert.IsTrue(new GpBox<int>().TypeOfT() == typeof(int));
            Assert.IsTrue(new GpBox<string>().TypeOfT() == typeof(string));
            Assert.IsFalse(new GpBox<int>().TypeOfT().IsGenericParameter);
        }

        #endregion

        private static bool ThrowsNotSupported(Func<object> action)
        {
            try
            {
                action();
            }
            catch (NotSupportedException)
            {
                return true;
            }

            return false;
        }

        private static bool ThrowsNotSupported(Func<bool> action)
        {
            try
            {
                action();
            }
            catch (NotSupportedException)
            {
                return true;
            }

            return false;
        }

        private static bool ThrowsInvalidOperation(Func<object> action)
        {
            try
            {
                action();
            }
            catch (InvalidOperationException)
            {
                return true;
            }

            return false;
        }

        private static bool ThrowsInvalidOperation(Func<int> action)
        {
            try
            {
                action();
            }
            catch (InvalidOperationException)
            {
                return true;
            }

            return false;
        }

        public class GpPlain { }

        public class GpOther<T> { }

        public class GpPair<K, V>
        {
            public K First;
            public V Second;
        }

        public class GpBox<T>
        {
            public T Item;
            public T[] Items;
            public GpOther<T> Boxed;

            public T Get()
            {
                return Item;
            }

            public void Put(T value) { }

            public T[] GetAll()
            {
                return Items;
            }

            public GpOther<T> GetBoxed()
            {
                return Boxed;
            }

            public U Map<U>(U value, T other)
            {
                return value;
            }

            public Type TypeOfT()
            {
                return typeof(T);
            }
        }

        public class GpOuter<T>
        {
            public class Inner<U> { }
        }

        public class GpDerived<T> : GpBox<T> { }

        public class GpOtherDerived<T> : GpBox<T> { }

        public class GpDerivedList<T> : GpBox<GpOther<T>> { }

        public interface IGpFace<T> { }

        public class GpWithInterface<T> : IGpFace<T> { }

        public class GpClassConstraint<T> where T : class { }

        public class GpStructConstraint<T> where T : struct { }

        public class GpBaseConstraint<T> where T : GpPlain { }

        public class GpMethods
        {
            public U Identity<U>(U value)
            {
                return value;
            }

            public void TakesArray<U>(U[] values) { }

            public void TakesOther<U>(GpOther<U> value) { }
        }
    }
}
