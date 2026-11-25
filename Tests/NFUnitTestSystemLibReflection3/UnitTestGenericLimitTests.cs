// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLibReflection3
{
    public class NestableBox<T>
    {
        public T V;
    }

    public class GenericWith15Arguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
    }

    public class GenericWith16Arguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
    }

    public static class GenericCastHelper
    {
        public static bool Is<T>(object o)
        {
            return o is T;
        }

        public static object Cast<T>(object o)
        {
            return (T)o;
        }
    }

    [TestClass]
    public class UnitTestGenericLimitTests
    {
        [TestMethod]
        public void Cast_WithinTheLimits_ComparesTheArguments()
        {
            object many = new GenericWith15Arguments<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>();
            object box = new NestableBox<NestableBox<NestableBox<NestableBox<int>>>>();

            Assert.IsTrue(many is GenericWith15Arguments<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>);
            Assert.IsFalse(many is GenericWith15Arguments<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string>);
            Assert.ThrowsException(
                typeof(InvalidCastException),
                () => { var other = (GenericWith15Arguments<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string>)many; });

            Assert.IsTrue(box is NestableBox<NestableBox<NestableBox<NestableBox<int>>>>);
            Assert.IsFalse(box is NestableBox<NestableBox<NestableBox<NestableBox<string>>>>);
            Assert.IsTrue(GenericCastHelper.Is<NestableBox<NestableBox<NestableBox<NestableBox<int>>>>>(box));
            Assert.IsFalse(GenericCastHelper.Is<NestableBox<NestableBox<NestableBox<NestableBox<string>>>>>(box));
        }

        [TestMethod]
        public void Cast_ToTypeWithTooManyNodes_IsNotSupported()
        {
            object many = new GenericWith16Arguments<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>();

            Assert.ThrowsException(
                typeof(NotSupportedException),
                () => { bool b = many is GenericWith16Arguments<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string>; });
            Assert.ThrowsException(
                typeof(NotSupportedException),
                () => { var other = (GenericWith16Arguments<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string>)many; });
            Assert.ThrowsException(
                typeof(NotSupportedException),
                () => GenericCastHelper.Is<GenericWith16Arguments<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string>>(many));
            Assert.ThrowsException(
                typeof(NotSupportedException),
                () => GenericCastHelper.Cast<GenericWith16Arguments<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string>>(many));
        }

        [TestMethod]
        public void Cast_ToTypeNestedTooDeep_IsNotSupported()
        {
            object box = new NestableBox<NestableBox<NestableBox<NestableBox<string>>>>();

            Assert.ThrowsException(typeof(NotSupportedException), () => GenericCastHelper.Is<NestableBox<NestableBox<NestableBox<NestableBox<NestableBox<int>>>>>>(box));
            Assert.ThrowsException(typeof(NotSupportedException), () => GenericCastHelper.Cast<NestableBox<NestableBox<NestableBox<NestableBox<NestableBox<int>>>>>>(box));
        }

        [TestMethod]
        public void Cast_ArrayToArrayOfTypeNestedTooDeep_IsNotSupported()
        {
            object boxes = new NestableBox<NestableBox<NestableBox<NestableBox<string>>>>[1];

            Assert.ThrowsException(
                typeof(NotSupportedException),
                () => { bool b = boxes is NestableBox<NestableBox<NestableBox<NestableBox<NestableBox<int>>>>>[]; });
            Assert.ThrowsException(
                typeof(NotSupportedException),
                () => GenericCastHelper.Is<NestableBox<NestableBox<NestableBox<NestableBox<NestableBox<int>>>>>[]>(boxes));
            Assert.ThrowsException(
                typeof(NotSupportedException),
                () => GenericCastHelper.Cast<NestableBox<NestableBox<NestableBox<NestableBox<NestableBox<int>>>>>[]>(boxes));
            Assert.IsFalse(boxes is NestableBox<NestableBox<NestableBox<NestableBox<int>>>>[]);
        }

        [TestMethod]
        public void MakeGenericType_OverTheLimits_IsNotSupported()
        {
            Type[] sixteen = new Type[16];

            for (int i = 0; i < sixteen.Length; i++)
            {
                sixteen[i] = typeof(int);
            }

            Assert.ThrowsException(typeof(NotSupportedException), () => typeof(GenericWith16Arguments<,,,,,,,,,,,,,,,>).MakeGenericType(sixteen));

            Type deep = typeof(int);

            for (int i = 0; i < 4; i++)
            {
                deep = typeof(NestableBox<>).MakeGenericType(deep);
            }

            Type tooDeep = deep;

            Assert.ThrowsException(typeof(NotSupportedException), () => typeof(NestableBox<>).MakeGenericType(tooDeep));
        }
    }
}
