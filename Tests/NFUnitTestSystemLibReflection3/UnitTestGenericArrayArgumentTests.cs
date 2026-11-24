// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Expected values come from running the same code on .NET 10.
    [TestClass]
    public class UnitTestGenericArrayArgumentTests
    {
        public class AaBox<T>
        {
        }

        public class AaPair<T, U>
        {
        }

        public class AaCheck<T>
        {
            public bool Is(object o)
            {
                return o is T;
            }

            public object Cast(object o)
            {
                return (T)o;
            }

            public bool IsArray(object o)
            {
                return o is T[];
            }
        }

        public class AaElement<T>
        {
            public bool IsBoxArray(object o)
            {
                return o is AaBox<T>[];
            }

            public bool IsBoxOfArray(object o)
            {
                return o is AaBox<T[]>;
            }
        }

        private static bool IsOf<T>(object o)
        {
            return o is T;
        }

        private static object CastTo<T>(object o)
        {
            return (T)o;
        }

        private static bool IsArray<T>(object o)
        {
            return o is T[];
        }

        private static bool IsArrayOfArrays<T>(object o)
        {
            return o is T[][];
        }

        [TestMethod]
        public void MethodTypeParameter_BoundToArrayOfGenericInstance_ComparesTheElementInstance()
        {
            object ints = new AaBox<int>[0];
            object strings = new AaBox<string>[0];

            Assert.IsTrue(IsOf<AaBox<int>[]>(ints));
            Assert.IsTrue(IsOf<AaBox<string>[]>(strings));
            Assert.IsFalse(IsOf<AaBox<int>[]>(strings));
            Assert.IsFalse(IsOf<AaBox<string>[]>(ints));
            Assert.IsFalse(IsOf<AaBox<int>[]>(new object[0]));
            Assert.IsFalse(IsOf<AaBox<int>[]>(new AaBox<int>()));
            Assert.IsFalse(IsOf<AaBox<int>[]>(null));
            Assert.IsFalse(IsOf<AaBox<int>[]>(new object[] { strings }));
        }

        [TestMethod]
        public void MethodTypeParameter_BoundToArrayOfArraysOfGenericInstance_ComparesTheElementInstance()
        {
            object ints = new AaBox<int>[0][];
            object strings = new AaBox<string>[0][];

            Assert.IsTrue(IsOf<AaBox<int>[][]>(ints));
            Assert.IsFalse(IsOf<AaBox<int>[][]>(strings));
            Assert.IsFalse(IsOf<AaBox<int>[][]>(new AaBox<int>[0]));
            Assert.IsFalse(IsOf<AaBox<int>[]>(ints));
            Assert.IsTrue(IsOf<int[][]>(new int[0][]));
            Assert.IsFalse(IsOf<int[][]>(new string[0][]));
        }

        [TestMethod]
        public void MethodTypeParameter_BoundToGenericInstanceWithArrayArgument_ComparesTheArgument()
        {
            Assert.IsTrue(IsOf<AaBox<AaBox<int>[]>>(new AaBox<AaBox<int>[]>()));
            Assert.IsFalse(IsOf<AaBox<AaBox<int>[]>>(new AaBox<AaBox<string>[]>()));
            Assert.IsFalse(IsOf<AaPair<int, AaBox<int>[]>>(new AaPair<int, AaBox<string>[]>()));
        }

        [TestMethod]
        public void Cast_ToMethodTypeParameterBoundToArrayOfGenericInstance_ThrowsForAnotherInstance()
        {
            object ints = new AaBox<int>[0];
            object strings = new AaBox<string>[0];

            Assert.IsNotNull(CastTo<AaBox<int>[]>(ints));
            Assert.IsNull(CastTo<AaBox<int>[]>(null));
            Assert.ThrowsException(typeof(InvalidCastException), () => CastTo<AaBox<int>[]>(strings));
            Assert.ThrowsException(typeof(InvalidCastException), () => CastTo<AaBox<int>[][]>(new AaBox<string>[0][]));
        }

        [TestMethod]
        public void ArrayOfMethodTypeParameter_BoundToGenericInstance_ComparesTheElementInstance()
        {
            object ints = new AaBox<int>[0];
            object strings = new AaBox<string>[0];

            Assert.IsTrue(IsArray<AaBox<int>>(ints));
            Assert.IsFalse(IsArray<AaBox<int>>(strings));
            Assert.IsTrue(IsArray<AaBox<int>[]>(new AaBox<int>[0][]));
            Assert.IsFalse(IsArray<AaBox<int>[]>(new AaBox<string>[0][]));
            Assert.IsTrue(IsArrayOfArrays<AaBox<int>>(new AaBox<int>[0][]));
            Assert.IsFalse(IsArrayOfArrays<AaBox<int>>(new AaBox<string>[0][]));
        }

        [TestMethod]
        public void ClassTypeParameter_BoundToArrayOfGenericInstance_ComparesTheElementInstance()
        {
            object ints = new AaBox<int>[0];
            object strings = new AaBox<string>[0];

            Assert.IsTrue(new AaCheck<AaBox<int>[]>().Is(ints));
            Assert.IsFalse(new AaCheck<AaBox<int>[]>().Is(strings));
            Assert.IsNotNull(new AaCheck<AaBox<int>[]>().Cast(ints));
            Assert.ThrowsException(typeof(InvalidCastException), () => new AaCheck<AaBox<int>[]>().Cast(strings));
            Assert.IsFalse(new AaCheck<AaBox<int>[][]>().Is(new AaBox<string>[0][]));
            Assert.IsTrue(new AaCheck<AaBox<int>>().IsArray(ints));
            Assert.IsFalse(new AaCheck<AaBox<int>>().IsArray(strings));
            Assert.IsFalse(new AaCheck<AaPair<int, string>[]>().Is(new AaPair<int, int>[0]));
        }

        [TestMethod]
        public void ClassTypeParameter_InsideAGenericInstanceOfAnArray_ComparesTheElementInstance()
        {
            Assert.IsTrue(new AaElement<int>().IsBoxArray(new AaBox<int>[0]));
            Assert.IsFalse(new AaElement<int>().IsBoxArray(new AaBox<string>[0]));
            Assert.IsTrue(new AaElement<int>().IsBoxOfArray(new AaBox<int[]>()));
            Assert.IsFalse(new AaElement<int>().IsBoxOfArray(new AaBox<string[]>()));
        }

        [TestMethod]
        public void TypeParameter_BoundToAnInterfaceOfAGenericInstance_AcceptsArraysOfItsArrays()
        {
            object ints = new AaBox<int>[0][];
            object strings = new AaBox<string>[0][];
            object ints3 = new AaBox<int>[0][][];
            object strings3 = new AaBox<string>[0][][];

            Assert.IsTrue(IsArray<IEnumerable<AaBox<int>>>(ints));
            Assert.IsFalse(IsArray<IEnumerable<AaBox<int>>>(strings));
            Assert.IsTrue(IsOf<IEnumerable<AaBox<int>>[]>(ints));
            Assert.IsFalse(IsOf<IEnumerable<AaBox<int>>[]>(strings));
            Assert.IsTrue(IsOf<IEnumerable<AaBox<int>>[][]>(ints3));
            Assert.IsFalse(IsOf<IEnumerable<AaBox<int>>[][]>(strings3));
            Assert.IsFalse(IsOf<IEnumerable<AaBox<int>>[]>(new AaBox<int>[0]));
            Assert.IsNotNull(CastTo<IEnumerable<AaBox<int>>[]>(ints));
            Assert.ThrowsException(typeof(InvalidCastException), () => CastTo<IEnumerable<AaBox<int>>[]>(strings));
            Assert.IsTrue(ints is IEnumerable<AaBox<int>>[]);
            Assert.IsFalse(strings is IEnumerable<AaBox<int>>[]);
        }

        [TestMethod]
        public void DirectCasts_ToArraysOfGenericInstances_StayExact()
        {
            object ints = new AaBox<int>[0][];
            object strings = new AaBox<string>[0][];

            Assert.IsTrue(ints is AaBox<int>[][]);
            Assert.IsFalse(strings is AaBox<int>[][]);
            Assert.IsFalse(strings is AaBox<int>[]);
            Assert.ThrowsException(typeof(InvalidCastException), () =>
            {
                object cast = (AaBox<int>[][])strings;
            });
        }
    }
}
