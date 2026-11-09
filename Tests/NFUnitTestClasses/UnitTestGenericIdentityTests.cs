// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestClasses
{
    // Each test uses its own holder type, because static storage and .cctor runs last for the whole test run, and
    // naming an instantiation elsewhere would add the closed TypeSpec row that the generic method tests must not have.
    [TestClass]
    class UnitTestGenericIdentityTests
    {
        [TestMethod]
        public void Closed_ValueArg_VersusReferenceArg_AreSeparate()
        {
            IdentityCounterA<int>.Count = 1;

            Assert.AreEqual(0, IdentityCounterA<string>.Count);
        }

        [TestMethod]
        public void Closed_ClassArgs_AreSeparate()
        {
            IdentityCounterB<IdentityFoo>.Count = 1;

            Assert.AreEqual(0, IdentityCounterB<IdentityBar>.Count);
        }

        [TestMethod]
        public void Closed_NestedArgs_SameGeneric_AreSeparate()
        {
            IdentityCounterC<IdentityInner<int>>.Count = 1;

            Assert.AreEqual(0, IdentityCounterC<IdentityInner<string>>.Count);
        }

        [TestMethod]
        public void Closed_NestedArgs_DifferentGeneric_AreSeparate()
        {
            IdentityCounterD<IdentityInner<long>>.Count = 1;

            Assert.AreEqual(0, IdentityCounterD<IdentityOtherInner<long>>.Count);
        }

        [TestMethod]
        public void Closed_ArrayArg_VersusElementArg_AreSeparate()
        {
            IdentityCounterE<short[]>.Count = 1;

            Assert.AreEqual(0, IdentityCounterE<short>.Count);
        }

        [TestMethod]
        public void Closed_ArrayArg_VersusJaggedArrayArg_AreSeparate()
        {
            IdentityCounterF<byte[]>.Count = 1;

            Assert.AreEqual(0, IdentityCounterF<byte[][]>.Count);
        }

        [TestMethod]
        public void Closed_SecondArg_AfterNestedArg_AreSeparate()
        {
            IdentityPairCounterA<IdentityInner<int>, string>.Count = 1;

            Assert.AreEqual(0, IdentityPairCounterA<IdentityInner<int>, long>.Count);
        }

        [TestMethod]
        public void Closed_NestedSecondArgs_AreSeparate()
        {
            IdentityPairCounterB<int, IdentityInner<int>>.Count = 1;

            Assert.AreEqual(0, IdentityPairCounterB<int, IdentityInner<string>>.Count);
        }

        [TestMethod]
        public void GenericMethod_ValueArgs_RunCctorForEach()
        {
            IdentityMethods.TouchValueHolder<short>();
            IdentityMethods.TouchValueHolder<long>();

            Assert.AreEqual(2, IdentityCctorRuns.Value);
        }

        [TestMethod]
        public void GenericMethod_ClassArgs_RunCctorForEach()
        {
            IdentityMethods.TouchClassHolder<IdentityFoo>();
            object second = IdentityMethods.TouchClassHolder<IdentityBar>();

            Assert.AreEqual(2, IdentityCctorRuns.Class);
            Assert.IsTrue(second is IdentityBar[]);
        }

        [TestMethod]
        public void GenericMethod_ArrayVersusElementArg_RunCctorForEach()
        {
            IdentityMethods.TouchArrayHolder<int>();
            IdentityMethods.TouchArrayHolder<int[]>();

            Assert.AreEqual(2, IdentityCctorRuns.Array);
        }

        [TestMethod]
        public void GenericMethod_ValueArg_SharesStorageWithClosedRow()
        {
            IdentityCounterG<int>.Count = 9;

            Assert.AreEqual(9, IdentityMethods.ReadCounterG<int>());
        }

        [TestMethod]
        public void GenericMethod_ClassArg_SharesStorageWithClosedRow()
        {
            IdentityCounterH<IdentityFoo>.Count = 9;

            Assert.AreEqual(9, IdentityMethods.ReadCounterH<IdentityFoo>());
        }

        [TestMethod]
        public void GenericMethod_NestedArg_NewArray()
        {
            Assert.IsTrue(IdentityMethods.NewNestedArgArray<IdentityInner<int>>() is IdentityInner<int>[]);
        }

        [TestMethod]
        public void Nesting_AtLimit_Closed_AreSeparate()
        {
            IdentityCounterI<IdentityInner<IdentityInner<IdentityInner<int>>>>.Count = 1;

            Assert.AreEqual(1, IdentityCounterI<IdentityInner<IdentityInner<IdentityInner<int>>>>.Count);
            Assert.AreEqual(0, IdentityCounterI<IdentityInner<IdentityInner<IdentityInner<string>>>>.Count);
        }

        [TestMethod]
        public void Nesting_AtLimit_ThroughGenericMethod_RunCctorForEach()
        {
            IdentityMethods.TouchDeepHolder<IdentityInner<IdentityInner<IdentityInner<int>>>>();
            IdentityMethods.TouchDeepHolder<IdentityInner<IdentityInner<IdentityInner<string>>>>();

            Assert.AreEqual(2, IdentityCctorRuns.Deep);
        }

        [TestMethod]
        public void Nesting_AtLimit_ThroughTypeArg_CanAccessStaticField()
        {
            Assert.IsNotNull(new IdentityWrapping<IdentityInner<IdentityInner<int>>>().Touch());
        }

        [TestMethod]
        public void Nesting_OverLimit_Closed_StaticFieldAccessThrows()
        {
            Assert.ThrowsException(
                typeof(Exception),
                () => IdentityCounterJ<IdentityInner<IdentityInner<IdentityInner<IdentityInner<int>>>>>.Count = 1);
            Assert.ThrowsException(
                typeof(Exception),
                () =>
                {
                    int count = IdentityCounterJ<IdentityInner<IdentityInner<IdentityInner<IdentityInner<string>>>>>.Count;
                });
        }

        [TestMethod]
        public void Nesting_OverLimit_ThroughGenericMethod_StaticFieldAccessThrows()
        {
            Assert.ThrowsException(
                typeof(Exception),
                () => IdentityMethods.TouchOverLimitHolder<IdentityInner<IdentityInner<IdentityInner<IdentityInner<int>>>>>());
            Assert.AreEqual(0, IdentityCctorRuns.OverLimit);
        }

        [TestMethod]
        public void Nesting_OverLimit_CanCreateInstance()
        {
            Assert.IsNotNull(new IdentityBare<IdentityBare<IdentityBare<IdentityBare<IdentityBare<int>>>>>());
        }

        [TestMethod]
        public void TypeArg_SecondPosition_NewArray()
        {
            Assert.IsTrue(new IdentityPair<int, string>().NewSecondArray() is string[]);
        }

        [TestMethod]
        public void TypeArg_SecondPosition_AfterNestedArg_NewArray()
        {
            Assert.IsTrue(new IdentityPair<IdentityInner<int>, string>().NewSecondArray() is string[]);
        }

        [TestMethod]
        public void TypeArg_SecondPosition_AfterNestedArg_TypeOf()
        {
            Assert.IsTrue(new IdentityPair<IdentityInner<int>, string>().SecondType() == typeof(string));
        }

        [TestMethod]
        public void MethodArg_SecondPosition_NewArray()
        {
            Assert.IsTrue(IdentityMethods.NewSecondArray<int, string>() is string[]);
        }

        [TestMethod]
        public void MethodArg_SecondPosition_AfterNestedArg_NewArray()
        {
            Assert.IsTrue(IdentityMethods.NewSecondArray<IdentityInner<int>, string>() is string[]);
        }
    }

    class IdentityFoo
    {
    }

    class IdentityBar
    {
    }

    class IdentityInner<T>
    {
        public T Value;
    }

    class IdentityOtherInner<T>
    {
        public T Value;
    }

    class IdentityBare<T>
    {
    }

    class IdentityCounterA<T>
    {
        public static int Count;
    }

    class IdentityCounterB<T>
    {
        public static int Count;
    }

    class IdentityCounterC<T>
    {
        public static int Count;
    }

    class IdentityCounterD<T>
    {
        public static int Count;
    }

    class IdentityCounterE<T>
    {
        public static int Count;
    }

    class IdentityCounterF<T>
    {
        public static int Count;
    }

    class IdentityCounterG<T>
    {
        public static int Count;
    }

    class IdentityCounterH<T>
    {
        public static int Count;
    }

    class IdentityPairCounterA<T1, T2>
    {
        public static int Count;
    }

    class IdentityPairCounterB<T1, T2>
    {
        public static int Count;
    }

    static class IdentityCctorRuns
    {
        public static int Value;
        public static int Class;
        public static int Array;
        public static int Deep;
        public static int OverLimit;
    }

    class IdentityCounterI<T>
    {
        public static int Count;
    }

    class IdentityCounterJ<T>
    {
        public static int Count;
    }

    class IdentityDeepHolder<T>
    {
        public static object Items = Make();

        private static object Make()
        {
            IdentityCctorRuns.Deep++;

            return new T[1];
        }

        public object Get()
        {
            return Items;
        }
    }

    class IdentityWrappedHolder<T>
    {
        public static object Items = new object();

        public object Get()
        {
            return Items;
        }
    }

    class IdentityWrapping<T>
    {
        public object Touch()
        {
            return new IdentityWrappedHolder<IdentityInner<T>>().Get();
        }
    }

    class IdentityOverLimitHolder<T>
    {
        public static object Items = Make();

        private static object Make()
        {
            IdentityCctorRuns.OverLimit++;

            return new T[1];
        }

        public object Get()
        {
            return Items;
        }
    }

    class IdentityValueHolder<T>
    {
        public static object Items = Make();

        private static object Make()
        {
            IdentityCctorRuns.Value++;

            return new T[1];
        }

        public object Get()
        {
            return Items;
        }
    }

    class IdentityClassHolder<T>
    {
        public static object Items = Make();

        private static object Make()
        {
            IdentityCctorRuns.Class++;

            return new T[1];
        }

        public object Get()
        {
            return Items;
        }
    }

    class IdentityArrayHolder<T>
    {
        public static object Items = Make();

        private static object Make()
        {
            IdentityCctorRuns.Array++;

            return new T[1];
        }

        public object Get()
        {
            return Items;
        }
    }

    class IdentityNestedArgHolder<T>
    {
        public static object Items = new T[1];

        public object Get()
        {
            return Items;
        }
    }

    class IdentityPair<T1, T2>
    {
        public object NewSecondArray()
        {
            return new T2[1];
        }

        public Type SecondType()
        {
            return typeof(T2);
        }
    }

    static class IdentityMethods
    {
        public static object TouchValueHolder<U>()
        {
            return new IdentityValueHolder<U>().Get();
        }

        public static object TouchClassHolder<U>()
        {
            return new IdentityClassHolder<U>().Get();
        }

        public static object TouchArrayHolder<U>()
        {
            return new IdentityArrayHolder<U>().Get();
        }

        public static object TouchDeepHolder<U>()
        {
            return new IdentityDeepHolder<U>().Get();
        }

        public static object TouchOverLimitHolder<U>()
        {
            return new IdentityOverLimitHolder<U>().Get();
        }

        public static object NewNestedArgArray<U>()
        {
            return new IdentityNestedArgHolder<U>().Get();
        }

        public static int ReadCounterG<U>()
        {
            return IdentityCounterG<U>.Count;
        }

        public static int ReadCounterH<U>()
        {
            return IdentityCounterH<U>.Count;
        }

        public static object NewSecondArray<T1, T2>()
        {
            return new T2[1];
        }
    }
}
