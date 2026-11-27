// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Expected values come from running the same code on .NET 10. Each test uses its own types.
    [TestClass]
    public class UnitTestMakeGenericTypeTests
    {
        #region identity

        [TestMethod]
        public void MakeGenericType_EqualsTheClosedType()
        {
            Type made = typeof(Box<>).MakeGenericType(typeof(int));

            Assert.IsTrue(made == typeof(Box<int>));
            Assert.IsTrue(made.Equals(typeof(Box<int>)));
            Assert.AreEqual(typeof(Box<int>).GetHashCode(), made.GetHashCode());
            Assert.AreEqual("Box`1", made.Name);
            Assert.IsTrue(typeof(Pair<,>).MakeGenericType(typeof(int), typeof(string)) == typeof(Pair<int, string>));
            Assert.IsFalse(typeof(Pair<,>).MakeGenericType(typeof(string), typeof(int)) == typeof(Pair<int, string>));
        }

        [TestMethod]
        public void MakeGenericType_InstantiationNotInTheMetadata()
        {
            Type made = typeof(Box<>).MakeGenericType(typeof(byte));
            Type again = typeof(Box<>).MakeGenericType(typeof(byte));
            Type[] arguments = made.GetGenericArguments();

            Assert.IsTrue(made.IsGenericType);
            Assert.IsTrue(made.IsConstructedGenericType);
            Assert.IsFalse(made.IsGenericTypeDefinition);
            Assert.IsFalse(made.ContainsGenericParameters);
            Assert.AreEqual("Box`1", made.Name);
            Assert.IsTrue(made.GetGenericTypeDefinition() == typeof(Box<>));
            Assert.AreEqual(1, arguments.Length);
            Assert.IsTrue(arguments[0] == typeof(byte));
            Assert.IsTrue(made == again);
            Assert.AreEqual(made.GetHashCode(), again.GetHashCode());
            Assert.IsFalse(made == typeof(Box<>).MakeGenericType(typeof(sbyte)));
            Assert.IsTrue(made.GetMethod("Get").ReturnType == typeof(byte));
            Assert.IsTrue(made.GetField("Value").FieldType == typeof(byte));

            object created = made.GetConstructor(new Type[0]).Invoke(null);

            Assert.IsTrue(created.GetType() == made);
            made.GetField("Value").SetValue(created, (byte)7);
            Assert.AreEqual(7, (int)(byte)made.GetMethod("Get").Invoke(created, null));
        }

        [TestMethod]
        public void MakeGenericType_ArraysAndNestedInstances()
        {
            Assert.IsTrue(typeof(Box<>).MakeGenericType(typeof(int[])) == typeof(Box<int[]>));
            Assert.IsTrue(typeof(Box<>).MakeGenericType(typeof(int[][])) == typeof(Box<int[][]>));
            Assert.IsTrue(typeof(Box<>).MakeGenericType(typeof(Box<int>)) == typeof(Box<Box<int>>));
            Assert.IsTrue(typeof(Box<>).MakeGenericType(typeof(Box<int>[])) == typeof(Box<Box<int>[]>));
            Assert.IsTrue(
                typeof(Box<>).MakeGenericType(typeof(Box<>).MakeGenericType(typeof(int))) ==
                typeof(Box<Box<int>>));
            Assert.IsTrue(typeof(Box<>).MakeGenericType(new PointStruct().GetType()) == typeof(Box<PointStruct>));
            Assert.IsTrue(typeof(Nullable<>).MakeGenericType(typeof(int)) == typeof(int?));
            Assert.IsTrue(
                typeof(Outer<>.Inner<>).MakeGenericType(typeof(int), typeof(string)) ==
                typeof(Outer<int>.Inner<string>));
        }

        [TestMethod]
        public void MakeGenericType_ArgumentsAreCopied()
        {
            Type[] arguments = new Type[] { typeof(int) };
            Type made = typeof(Box<>).MakeGenericType(arguments);

            arguments[0] = typeof(string);

            Assert.IsTrue(made == typeof(Box<int>));
        }

        [TestMethod]
        public void MakeGenericType_ResultIsUsable()
        {
            Type made = typeof(Pair<,>).MakeGenericType(typeof(int), typeof(string));
            Type[] arguments = made.GetGenericArguments();

            Assert.IsTrue(made.IsGenericType);
            Assert.IsTrue(made.IsConstructedGenericType);
            Assert.IsFalse(made.IsGenericTypeDefinition);
            Assert.IsFalse(made.ContainsGenericParameters);
            Assert.IsTrue(made.GetGenericTypeDefinition() == typeof(Pair<,>));
            Assert.AreEqual(2, arguments.Length);
            Assert.IsTrue(arguments[0] == typeof(int));
            Assert.IsTrue(arguments[1] == typeof(string));
            Assert.IsTrue(typeof(Box<>).MakeGenericType(typeof(int)).GetMethod("Get") != null);
            Assert.IsTrue(typeof(Box<int>).IsAssignableFrom(typeof(Box<>).MakeGenericType(typeof(int))));

            object created = typeof(Box<>).MakeGenericType(typeof(int)).GetConstructor(new Type[0]).Invoke(null);

            Assert.IsTrue(created.GetType() == typeof(Box<int>));
            Assert.IsTrue(Nullable.GetUnderlyingType(typeof(Nullable<>).MakeGenericType(typeof(int))) == typeof(int));
        }

        #endregion

        #region errors

        [TestMethod]
        public void MakeGenericType_ArgumentErrors()
        {
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(Pair<,>).MakeGenericType(typeof(int)));
            Assert.ThrowsException(
                typeof(ArgumentException),
                () => typeof(Pair<,>).MakeGenericType(typeof(int), typeof(int), typeof(int)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(Box<>).MakeGenericType(new Type[0]));
            Assert.ThrowsException(typeof(ArgumentNullException), () => typeof(Box<>).MakeGenericType(null));
            Assert.ThrowsException(
                typeof(ArgumentNullException),
                () => typeof(Box<>).MakeGenericType(new Type[] { null }));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(Box<>).MakeGenericType(typeof(void)));
        }

        [TestMethod]
        public void MakeGenericType_NotADefinition_Throws()
        {
            Assert.ThrowsException(
                typeof(InvalidOperationException),
                () => typeof(Box<int>).MakeGenericType(typeof(int)));
            Assert.ThrowsException(typeof(InvalidOperationException), () => typeof(int).MakeGenericType(typeof(int)));
            Assert.ThrowsException(typeof(InvalidOperationException), () => typeof(int[]).MakeGenericType(typeof(int)));
            Assert.ThrowsException(typeof(InvalidOperationException), () => typeof(object).MakeGenericType(typeof(int)));
            Assert.ThrowsException(
                typeof(InvalidOperationException),
                () => typeof(Box<>).GetGenericArguments()[0].MakeGenericType(typeof(int)));
        }

        #endregion

        #region constraints

        [TestMethod]
        public void MakeGenericType_ClassConstraint()
        {
            Assert.IsTrue(typeof(RequiresClass<>).MakeGenericType(typeof(string)) == typeof(RequiresClass<string>));
            Assert.IsTrue(typeof(RequiresClass<>).MakeGenericType(typeof(IMarker)) == typeof(RequiresClass<IMarker>));
            Assert.IsTrue(typeof(RequiresClass<>).MakeGenericType(typeof(int[])) == typeof(RequiresClass<int[]>));
            Assert.IsTrue(typeof(RequiresClass<>).MakeGenericType(typeof(Enum)) == typeof(RequiresClass<Enum>));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresClass<>).MakeGenericType(typeof(int)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresClass<>).MakeGenericType(typeof(int?)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresClass<>).MakeGenericType(typeof(PointStruct)));
        }

        [TestMethod]
        public void MakeGenericType_StructConstraint()
        {
            Assert.IsTrue(typeof(RequiresStruct<>).MakeGenericType(typeof(int)) == typeof(RequiresStruct<int>));
            Assert.IsTrue(typeof(RequiresStruct<>).MakeGenericType(typeof(PointStruct)) == typeof(RequiresStruct<PointStruct>));
            Assert.IsTrue(typeof(RequiresStruct<>).MakeGenericType(typeof(DayOfWeek)) == typeof(RequiresStruct<DayOfWeek>));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresStruct<>).MakeGenericType(typeof(string)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresStruct<>).MakeGenericType(typeof(int?)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresStruct<>).MakeGenericType(typeof(object)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresStruct<>).MakeGenericType(typeof(ValueType)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresStruct<>).MakeGenericType(typeof(Enum)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresStruct<>).MakeGenericType(typeof(int[])));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(Nullable<>).MakeGenericType(typeof(string)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(Nullable<>).MakeGenericType(typeof(int?)));
        }

        [TestMethod]
        public void MakeGenericType_NewConstraint()
        {
            Assert.IsTrue(typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(PlainClass)) == typeof(RequiresDefaultConstructor<PlainClass>));
            Assert.IsTrue(typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(int)) == typeof(RequiresDefaultConstructor<int>));
            Assert.IsTrue(typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(PointStruct)) == typeof(RequiresDefaultConstructor<PointStruct>));
            Assert.IsTrue(typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(int?)) == typeof(RequiresDefaultConstructor<int?>));
            Assert.IsTrue(typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(object)) == typeof(RequiresDefaultConstructor<object>));
            Assert.IsTrue(typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(DayOfWeek)) == typeof(RequiresDefaultConstructor<DayOfWeek>));
            Assert.IsTrue(typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(Box<int>)) == typeof(RequiresDefaultConstructor<Box<int>>));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(ClassWithoutDefaultConstructor)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(ClassWithPrivateConstructor)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(AbstractClass)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(IMarker)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(string)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(int[])));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(Enum)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresDefaultConstructor<>).MakeGenericType(typeof(ValueType)));
        }

        [TestMethod]
        public void MakeGenericType_InterfaceAndBaseConstraints()
        {
            Assert.IsTrue(typeof(RequiresMarker<>).MakeGenericType(typeof(MarkedClass)) == typeof(RequiresMarker<MarkedClass>));
            Assert.IsTrue(typeof(RequiresMarker<>).MakeGenericType(typeof(MarkedStruct)) == typeof(RequiresMarker<MarkedStruct>));
            Assert.IsTrue(typeof(RequiresMarker<>).MakeGenericType(typeof(IMarker)) == typeof(RequiresMarker<IMarker>));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresMarker<>).MakeGenericType(typeof(PlainClass)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresMarker<>).MakeGenericType(typeof(int)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresMarker<>).MakeGenericType(typeof(int[])));

            Assert.IsTrue(typeof(RequiresBaseClass<>).MakeGenericType(typeof(DerivedClass)) == typeof(RequiresBaseClass<DerivedClass>));
            Assert.IsTrue(typeof(RequiresBaseClass<>).MakeGenericType(typeof(BaseClass)) == typeof(RequiresBaseClass<BaseClass>));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresBaseClass<>).MakeGenericType(typeof(PlainClass)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresBaseClass<>).MakeGenericType(typeof(object)));

            Assert.IsTrue(typeof(RequiresEnum<>).MakeGenericType(typeof(DayOfWeek)) == typeof(RequiresEnum<DayOfWeek>));
            Assert.IsTrue(typeof(RequiresEnum<>).MakeGenericType(typeof(Enum)) == typeof(RequiresEnum<Enum>));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresEnum<>).MakeGenericType(typeof(int)));

            Assert.IsTrue(typeof(RequiresDelegate<>).MakeGenericType(typeof(Action)) == typeof(RequiresDelegate<Action>));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresDelegate<>).MakeGenericType(typeof(object)));
        }

        [TestMethod]
        public void MakeGenericType_ConstraintsNamingTheParameter()
        {
            Assert.IsTrue(typeof(RequiresSelfConstraint<>).MakeGenericType(typeof(SelfConstrained)) == typeof(RequiresSelfConstraint<SelfConstrained>));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresSelfConstraint<>).MakeGenericType(typeof(PlainClass)));

            Assert.IsTrue(typeof(RequiresComparable<>).MakeGenericType(typeof(ComparableClass)) == typeof(RequiresComparable<ComparableClass>));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(RequiresComparable<>).MakeGenericType(typeof(PointStruct)));

            Assert.IsTrue(
                typeof(RequiresChain<,>).MakeGenericType(typeof(DerivedClass), typeof(BaseClass)) ==
                typeof(RequiresChain<DerivedClass, BaseClass>));
            Assert.ThrowsException(
                typeof(ArgumentException),
                () => typeof(RequiresChain<,>).MakeGenericType(typeof(PlainClass), typeof(BaseClass)));
            Assert.ThrowsException(
                typeof(ArgumentException),
                () => typeof(RequiresChain<,>).MakeGenericType(typeof(BaseClass), typeof(DerivedClass)));
        }

        #endregion

        #region open arguments and limits

        [TestMethod]
        public void MakeGenericType_OwnParameters_ReturnTheDefinition()
        {
            Assert.IsTrue(typeof(Box<>).MakeGenericType(typeof(Box<>).GetGenericArguments()) == typeof(Box<>));
            Assert.IsTrue(typeof(Pair<,>).MakeGenericType(typeof(Pair<,>).GetGenericArguments()) == typeof(Pair<,>));
        }

        [TestMethod]
        public void MakeGenericType_OpenArguments_AreNotSupported()
        {
            Type[] pair = typeof(Pair<,>).GetGenericArguments();

            Assert.ThrowsException(typeof(NotSupportedException), () => typeof(Pair<,>).MakeGenericType(pair[1], pair[0]));
            Assert.ThrowsException(typeof(NotSupportedException), () => typeof(Box<>).MakeGenericType(pair[0]));
            Assert.ThrowsException(typeof(NotSupportedException), () => typeof(Box<>).MakeGenericType(typeof(Box<>)));
            Assert.ThrowsException(typeof(NotSupportedException), () => typeof(Pair<,>).MakeGenericType(pair[0], typeof(int)));
        }

        [TestMethod]
        public void MakeGenericType_OverTheLimits_IsNotSupported()
        {
            Type deep = typeof(Box<Box<Box<Box<int>>>>);
            Type pair = typeof(Pair<int, int>);

            Assert.ThrowsException(typeof(NotSupportedException), () => typeof(Box<>).MakeGenericType(deep));
            Assert.ThrowsException(
                typeof(NotSupportedException),
                () => typeof(SixArguments<,,,,,>).MakeGenericType(pair, pair, pair, pair, pair, pair));
        }

        #endregion

        [TestMethod]
        public void MakeGenericType_ByRefLikeArgument_Throws()
        {
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(Box<>).MakeGenericType(typeof(Span<int>)));
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(Box<>).MakeGenericType(typeof(ReadOnlySpan<byte>)));
        }

        #region GenericTypeArguments and parameter kinds

        [TestMethod]
        public void GenericTypeArguments_AsDotNet()
        {
            Type[] two = typeof(Pair<int, string>).GenericTypeArguments;
            Type[] copy = typeof(Box<int>).GenericTypeArguments;

            Assert.AreEqual(1, typeof(Box<int>).GenericTypeArguments.Length);
            Assert.AreEqual(2, two.Length);
            Assert.IsTrue(two[0] == typeof(int));
            Assert.IsTrue(two[1] == typeof(string));
            Assert.AreEqual(0, typeof(Box<>).GenericTypeArguments.Length);
            Assert.AreEqual(0, typeof(int).GenericTypeArguments.Length);
            Assert.AreEqual(0, typeof(int[]).GenericTypeArguments.Length);
            Assert.AreEqual(0, typeof(Box<int>[]).GenericTypeArguments.Length);
            Assert.AreEqual(0, typeof(Box<>).GetGenericArguments()[0].GenericTypeArguments.Length);

            copy[0] = typeof(string);

            Assert.IsTrue(typeof(Box<int>).GenericTypeArguments[0] == typeof(int));
        }

        [TestMethod]
        public void IsGenericTypeAndMethodParameter()
        {
            Type classParameter = typeof(Box<>).GetGenericArguments()[0];
            Type methodParameter = typeof(Box<>).GetMethod("Pick").GetGenericArguments()[0];

            Assert.IsTrue(classParameter.IsGenericTypeParameter);
            Assert.IsFalse(classParameter.IsGenericMethodParameter);
            Assert.IsFalse(methodParameter.IsGenericTypeParameter);
            Assert.IsTrue(methodParameter.IsGenericMethodParameter);
            Assert.IsFalse(typeof(int).IsGenericTypeParameter);
            Assert.IsFalse(typeof(int).IsGenericMethodParameter);
            Assert.IsFalse(typeof(Box<>).IsGenericTypeParameter);
        }

        #endregion
    }

    public interface IMarker { }

    public interface ISelfConstraint<T> { }

    public class PlainClass { }

    public class BaseClass { }

    public class DerivedClass : BaseClass { }

    public class MarkedClass : IMarker { }

    public struct MarkedStruct : IMarker { }

    public struct PointStruct
    {
        public int X;
    }

    public class ClassWithoutDefaultConstructor
    {
        public ClassWithoutDefaultConstructor(int x) { }
    }

    public class ClassWithPrivateConstructor
    {
        private ClassWithPrivateConstructor() { }
    }

    public abstract class AbstractClass { }

    public class SelfConstrained : ISelfConstraint<SelfConstrained> { }

    public class ComparableClass : IComparable<ComparableClass>
    {
        public int CompareTo(ComparableClass other) { return 0; }
    }

    public class Box<T>
    {
        public T Value;

        public T Get() { return Value; }

        public U Pick<U>(U u) { return u; }
    }

    public class Pair<A, B> { }

    public class SixArguments<A, B, C, D, E, F> { }

    public class Outer<T>
    {
        public class Inner<U> { }
    }

    public class RequiresClass<T> where T : class { }

    public class RequiresStruct<T> where T : struct { }

    public class RequiresDefaultConstructor<T> where T : new() { }

    public class RequiresMarker<T> where T : IMarker { }

    public class RequiresBaseClass<T> where T : BaseClass { }

    public class RequiresEnum<T> where T : Enum { }

    public class RequiresDelegate<T> where T : Delegate { }

    public class RequiresSelfConstraint<T> where T : ISelfConstraint<T> { }

    public class RequiresComparable<T> where T : IComparable<T> { }

    public class RequiresChain<T, U> where T : U where U : BaseClass { }
}
