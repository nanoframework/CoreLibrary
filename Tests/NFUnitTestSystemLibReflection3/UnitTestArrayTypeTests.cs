// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Expected values come from running the same code on .NET 10.
    [TestClass]
    public class UnitTestArrayTypeTests
    {
        public interface IArMark
        {
        }

        public class ArMarked : IArMark
        {
        }

        public class ArBase
        {
        }

        public class ArDerived : ArBase
        {
        }

        public enum ArColor
        {
            A,
        }

        public struct ArStruct
        {
        }

        public class ArBox<T>
        {
            public U Convert<U>(U value)
            {
                return value;
            }

            public static void Plain()
            {
            }
        }

        public class ArHolder
        {
            public static void Generic<T>()
            {
            }

            public void Instance()
            {
            }
        }

        [TestMethod]
        public void MakeArrayType_BuildsTheSingleDimensionalArrayType()
        {
            Assert.IsTrue(typeof(int).MakeArrayType() == typeof(int[]));
            Assert.IsTrue(typeof(int[]).MakeArrayType() == typeof(int[][]));
            Assert.IsTrue(typeof(ArBox<int>).MakeArrayType() == typeof(ArBox<int>[]));
            Assert.IsTrue(typeof(ArBox<>).MakeGenericType(typeof(string)).MakeArrayType() == typeof(ArBox<string>[]));
            Assert.IsTrue(typeof(ArColor).MakeArrayType() == typeof(ArColor[]));
            Assert.IsTrue(typeof(object).MakeArrayType() == typeof(object[]));
            Assert.IsTrue(typeof(IArMark).MakeArrayType() == typeof(IArMark[]));
            Assert.IsTrue(typeof(Action<int>).MakeArrayType() == typeof(Action<int>[]));
            Assert.IsTrue(typeof(Array).MakeArrayType().IsArray);
            Assert.AreEqual("Int32[][][][]", typeof(int).MakeArrayType().MakeArrayType().MakeArrayType().MakeArrayType().Name);
        }

        [TestMethod]
        public void MakeArrayType_ResultBehavesAsAnArrayType()
        {
            Type made = typeof(string).MakeArrayType();

            Assert.IsTrue(made.IsArray);
            Assert.IsTrue(made.GetElementType() == typeof(string));
            Assert.AreEqual("String[]", made.Name);
            Assert.IsTrue(typeof(object[]).IsAssignableFrom(made));
            Assert.AreEqual(2, Array.CreateInstance(typeof(int).MakeArrayType(), 2).Length);
        }

        [TestMethod]
        public void MakeArrayType_OfAGenericParameter_IsAnArrayOfTheParameter()
        {
            Type parameter = typeof(ArBox<>).GetGenericArguments()[0];
            Type made = parameter.MakeArrayType();

            Assert.IsTrue(made.IsArray);
            Assert.IsFalse(made.IsGenericParameter);
            Assert.IsTrue(made.ContainsGenericParameters);
            Assert.IsTrue(made.GetElementType() == parameter);
        }

        [TestMethod]
        public void MakeArrayType_WithoutAnArrayTypeHere_IsNotSupported()
        {
            Assert.ThrowsException(typeof(NotSupportedException), () => typeof(void).MakeArrayType());
            Assert.ThrowsException(typeof(NotSupportedException), () => typeof(ArBox<>).MakeArrayType());
        }

        [TestMethod]
        public void IsSZArray_IsTrueForEveryArray()
        {
            Assert.IsTrue(typeof(int[]).IsSZArray);
            Assert.IsTrue(typeof(int[][]).IsSZArray);
            Assert.IsTrue(typeof(ArBox<int>[]).IsSZArray);
            Assert.IsTrue(typeof(object[]).IsSZArray);
            Assert.IsTrue(typeof(ArColor[]).IsSZArray);
            Assert.IsTrue(typeof(ArStruct[]).IsSZArray);
            Assert.IsTrue(typeof(ArBox<>).GetGenericArguments()[0].MakeArrayType().IsSZArray);
        }

        [TestMethod]
        public void IsSZArray_IsFalseForOtherTypes()
        {
            Assert.IsFalse(typeof(int).IsSZArray);
            Assert.IsFalse(typeof(Array).IsSZArray);
            Assert.IsFalse(typeof(string).IsSZArray);
            Assert.IsFalse(typeof(ArBox<int>).IsSZArray);
            Assert.IsFalse(typeof(ArBox<>).GetGenericArguments()[0].IsSZArray);
        }

        [TestMethod]
        public void GetArrayRank_OfAnArray_IsOne()
        {
            Assert.AreEqual(1, typeof(int[]).GetArrayRank());
            Assert.AreEqual(1, typeof(int[][]).GetArrayRank());
            Assert.AreEqual(1, typeof(ArBox<int>[]).GetArrayRank());
            Assert.AreEqual(1, typeof(ArBox<>).GetGenericArguments()[0].MakeArrayType().GetArrayRank());
        }

        [TestMethod]
        public void GetArrayRank_OfANonArray_ThrowsArgumentException()
        {
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(int).GetArrayRank());
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(Array).GetArrayRank());
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(ArBox<int>).GetArrayRank());
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(ArBox<>).GetGenericArguments()[0].GetArrayRank());
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(object).GetArrayRank());
            Assert.ThrowsException(typeof(ArgumentException), () => typeof(string).GetArrayRank());
        }

        [TestMethod]
        public void IsAssignableTo_FollowsIsAssignableFrom()
        {
            Assert.IsTrue(typeof(ArDerived).IsAssignableTo(typeof(ArBase)));
            Assert.IsFalse(typeof(ArBase).IsAssignableTo(typeof(ArDerived)));
            Assert.IsTrue(typeof(ArMarked).IsAssignableTo(typeof(IArMark)));
            Assert.IsTrue(typeof(int).IsAssignableTo(typeof(object)));
            Assert.IsTrue(typeof(int).IsAssignableTo(typeof(int)));
            Assert.IsFalse(typeof(int).IsAssignableTo(typeof(long)));
            Assert.IsTrue(typeof(string[]).IsAssignableTo(typeof(object[])));
            Assert.IsTrue(typeof(Action<object>).IsAssignableTo(typeof(Action<string>)));
            Assert.IsFalse(typeof(ArBox<int>).IsAssignableTo(typeof(ArBox<>)));
        }

        [TestMethod]
        public void IsAssignableTo_WithNull_IsFalse()
        {
            Assert.IsFalse(typeof(int).IsAssignableTo(null));
        }

        [TestMethod]
        public void IsConstructedGenericMethod_IsTrueOnlyForAnInstantiation()
        {
            MethodInfo definition = typeof(ArBox<int>).GetMethod("Convert");
            MethodInfo generic = typeof(ArHolder).GetMethod("Generic");

            Assert.IsFalse(definition.IsConstructedGenericMethod);
            Assert.IsTrue(definition.MakeGenericMethod(typeof(string)).IsConstructedGenericMethod);
            Assert.IsFalse(typeof(ArHolder).GetMethod("Instance").IsConstructedGenericMethod);
            Assert.IsFalse(generic.IsConstructedGenericMethod);
            Assert.IsTrue(generic.MakeGenericMethod(typeof(int)).IsConstructedGenericMethod);
            Assert.IsFalse(typeof(ArHolder).GetConstructor(new Type[0]).IsConstructedGenericMethod);
            Assert.IsFalse(typeof(ArBox<int>).GetMethod("Plain").IsConstructedGenericMethod);
        }
    }
}
