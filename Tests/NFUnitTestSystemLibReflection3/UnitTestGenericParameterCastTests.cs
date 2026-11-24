// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Expected values are the language rules for 'is' and casts, checked on .NET 10.
    [TestClass]
    public class UnitTestGenericParameterCastTests
    {
        public class CastBox<T>
        {
            public T Value;
        }

        public class CastHolder<T>
        {
            public bool Is(object value)
            {
                return value is T;
            }

            public T As(object value)
            {
                return (T)value;
            }

            public static bool StaticIs(object value)
            {
                return value is T;
            }
        }

        private static bool IsOf<T>(object value)
        {
            return value is T;
        }

        private static T CastTo<T>(object value)
        {
            return (T)value;
        }

        [TestMethod]
        public void MethodTypeParameter_OfAGenericInstance_IsChecked()
        {
            Assert.IsTrue(IsOf<CastBox<int>>(new CastBox<int>()));
            Assert.IsFalse(IsOf<CastBox<string>>(new CastBox<int>()));
            Assert.IsFalse(IsOf<CastBox<int>>(null));
            Assert.IsTrue(IsOf<object>(new CastBox<int>()));
            Assert.IsFalse(IsOf<CastBox<int>>("text"));
        }

        [TestMethod]
        public void MethodTypeParameter_OfAGenericInstance_CastIsChecked()
        {
            CastBox<int> box = new CastBox<int>();

            Assert.IsTrue(CastTo<CastBox<int>>(box) == box);
            Assert.IsNull(CastTo<CastBox<int>>(null));
            Assert.IsTrue(CastTo<object>(box) == box);
            Assert.ThrowsException(typeof(InvalidCastException), () => CastTo<CastBox<string>>(box));
            Assert.ThrowsException(typeof(InvalidCastException), () => CastTo<CastBox<int>>("text"));
        }

        [TestMethod]
        public void MethodTypeParameter_OfAnArray_IsChecked()
        {
            int[] numbers = new int[1];

            Assert.IsTrue(IsOf<int[]>(numbers));
            Assert.IsFalse(IsOf<string[]>(numbers));
            Assert.IsFalse(IsOf<int[]>(new string[1]));
            Assert.IsTrue(IsOf<CastBox<int>[]>(new CastBox<int>[1]));
            Assert.IsTrue(CastTo<int[]>(numbers) == numbers);
            Assert.ThrowsException(typeof(InvalidCastException), () => CastTo<string[]>(numbers));
        }

        [TestMethod]
        public void MethodTypeParameter_OfAGenericDelegate_IsChecked()
        {
            Action<int> action = x => { };

            Assert.IsTrue(IsOf<Action<int>>(action));
            Assert.IsFalse(IsOf<Action<string>>(action));
            Assert.IsTrue(CastTo<Action<int>>(action) == action);
            Assert.ThrowsException(typeof(InvalidCastException), () => CastTo<Action<string>>(action));
        }

        [TestMethod]
        public void MethodTypeParameter_OfAPlainType_StillWorks()
        {
            Assert.IsTrue(IsOf<string>("text"));
            Assert.IsFalse(IsOf<string>(5));
            Assert.AreEqual(5, CastTo<int>(5));
            Assert.AreEqual("text", CastTo<string>("text"));
            Assert.ThrowsException(typeof(InvalidCastException), () => CastTo<int>("text"));
        }

        [TestMethod]
        public void ClassTypeParameter_OfAGenericInstanceOrArray_IsChecked()
        {
            Assert.IsTrue(new CastHolder<CastBox<int>>().Is(new CastBox<int>()));
            Assert.IsFalse(new CastHolder<CastBox<int>>().Is(new CastBox<string>()));
            Assert.IsTrue(CastHolder<CastBox<int>>.StaticIs(new CastBox<int>()));
            Assert.IsTrue(new CastHolder<int[]>().Is(new int[1]));
            Assert.IsFalse(new CastHolder<int[]>().Is(new string[1]));
            Assert.IsNotNull(new CastHolder<CastBox<int>>().As(new CastBox<int>()));
            Assert.ThrowsException(typeof(InvalidCastException), () => new CastHolder<int[]>().As(new string[1]));
        }
    }
}
