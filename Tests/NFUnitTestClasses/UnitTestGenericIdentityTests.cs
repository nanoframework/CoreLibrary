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

        [TestMethod]
        public void BareT_NestedClassArg_NewObject()
        {
            IdentityStampA<IdentityStampA<int>> outer = new IdentityStampA<IdentityStampA<int>>();
            outer.Value = new IdentityStampA<int>();
            outer.Value.Value = 5;

            Assert.AreEqual(5, outer.Get().Get());
        }

        [TestMethod]
        public void BareT_DeepNestedClassArg_NewObject()
        {
            IdentityStampB<IdentityStampB<IdentityStampB<string>>> outer =
                new IdentityStampB<IdentityStampB<IdentityStampB<string>>>();

            Assert.IsNull(outer.Value);

            outer.Value = new IdentityStampB<IdentityStampB<string>>();

            Assert.IsNotNull(outer.Get());
        }

        [TestMethod]
        public void BareT_ArrayArg_NewObject()
        {
            IdentityStampC<int[]> holder = new IdentityStampC<int[]>();

            Assert.IsNull(holder.Value);

            holder.Value = new int[2];

            Assert.AreEqual(2, holder.Get().Length);
        }

        [TestMethod]
        public void BareT_NestedValueArg_NewObject()
        {
            IdentityStampD<IdentityStampStruct<int>> holder = new IdentityStampD<IdentityStampStruct<int>>();
            IdentityStampStruct<int> value = holder.Get();
            value.Value = 7;
            holder.Value = value;

            Assert.AreEqual(7, holder.Get().Value);
        }

        [TestMethod]
        public void StaticT_Closed_NestedArg()
        {
            IdentityStaticTA<IdentityStampE<int>>.Value = new IdentityStampE<int>();
            IdentityStaticTA<IdentityStampE<int>>.Value.Value = 3;

            Assert.AreEqual(3, IdentityStaticTA<IdentityStampE<int>>.Value.Value);
        }

        [TestMethod]
        public void StaticT_OpenOwner_NestedMethodArg_AreSeparate()
        {
            object first = IdentityMethods.StoreStaticTB<int>();
            object second = IdentityMethods.StoreStaticTB<string>();

            Assert.AreSame(first, IdentityMethods.ReadStaticTB<int>());
            Assert.AreSame(second, IdentityMethods.ReadStaticTB<string>());
        }

        [TestMethod]
        public void StaticT_OpenOwner_NestedMethodArg_SharesStorageWithClosedRow()
        {
            IdentityStampG<long> value = new IdentityStampG<long>();
            value.Value = 11;
            IdentityStaticTC<IdentityStampG<long>>.Value = value;

            Assert.AreEqual(11L, IdentityMethods.ReadStaticTC<long>());
        }

        [TestMethod]
        public void StaticT_OpenOwner_BareMethodArg_AreSeparate()
        {
            IdentityMethods.StoreStaticTD<int>(4);
            IdentityMethods.StoreStaticTD<long>(8);

            Assert.AreEqual(4, IdentityMethods.ReadStaticTD<int>());
            Assert.AreEqual(8L, IdentityMethods.ReadStaticTD<long>());
        }

        [TestMethod]
        public void StaticT_OpenOwner_NestedTypeArg_AreSeparate()
        {
            IdentityStaticTOuter<int> first = new IdentityStaticTOuter<int>();
            IdentityStaticTOuter<string> second = new IdentityStaticTOuter<string>();

            object firstStored = first.Store();
            object secondStored = second.Store();

            Assert.AreSame(firstStored, first.Read());
            Assert.AreSame(secondStored, second.Read());
        }

        [TestMethod]
        public void StaticT_OpenOwner_NestedTypeArg_CctorInitializesStorage()
        {
            Assert.IsNotNull(new IdentityStaticTOuter<short>().ReadMarker());
        }

        [TestMethod]
        public void RuntimeClosed_NestedTypeArg_RunCctorOnce()
        {
            new IdentityRuntimeOuterA<int>().Touch();
            new IdentityRuntimeOuterA<int>().Touch();
            new IdentityRuntimeOuterA<string>().Touch();

            Assert.AreEqual(2, IdentityCctorRuns.RuntimeNested);
        }

        [TestMethod]
        public void RuntimeClosed_BareTypeArg_RunCctorOnce()
        {
            new IdentityRuntimeOuterA<int>().TouchBare();
            new IdentityRuntimeOuterA<int>().TouchBare();
            new IdentityRuntimeOuterA<string>().TouchBare();

            Assert.AreEqual(2, IdentityCctorRuns.RuntimeBare);
        }

        [TestMethod]
        public void RuntimeClosed_OwnMethods_SeparateState()
        {
            IdentityRuntimeOuterB<int> first = new IdentityRuntimeOuterB<int>();
            IdentityRuntimeOuterB<string> second = new IdentityRuntimeOuterB<string>();
            object firstValue = new object();
            object secondValue = new object();

            first.Store(firstValue);
            second.Store(secondValue);

            Assert.AreSame(firstValue, first.Read());
            Assert.AreSame(secondValue, second.Read());
            Assert.AreSame(firstValue, first.ReadNested());
            Assert.AreSame(secondValue, second.ReadNested());
        }

        [TestMethod]
        public void RuntimeClosed_BareTField_IsTyped()
        {
            object value = new IdentityRuntimeOuterC<int>().ReadDefault();

            Assert.IsNotNull(value);
            Assert.IsTrue(value is int);
            Assert.AreEqual(0, (int)value);
        }

        [TestMethod]
        public void RuntimeClosed_BareTField_StoresValue()
        {
            Assert.AreEqual(9L, new IdentityRuntimeOuterC<long>().RoundTrip(9L));
        }

        [TestMethod]
        public void RuntimeClosed_SwappedPair_BindsOwnArguments()
        {
            IdentityRuntimePair<int, string> pair = new IdentityRuntimePair<int, string>();

            Assert.IsTrue(pair.SwappedFirst() is string[]);
            Assert.IsTrue(pair.SwappedSecond() is int[]);
        }

        [TestMethod]
        public void RuntimeClosed_ArrayTypeArg_SeparateState()
        {
            IdentityRuntimeArrayOuter<int> first = new IdentityRuntimeArrayOuter<int>();
            IdentityRuntimeArrayOuter<string> second = new IdentityRuntimeArrayOuter<string>();
            object firstValue = new object();
            object secondValue = new object();

            first.Store(firstValue);
            second.Store(secondValue);

            Assert.AreSame(firstValue, first.Read());
            Assert.AreSame(secondValue, second.Read());
        }

        [TestMethod]
        public void RuntimeClosed_ArrayTypeArg_SharesStorageWithClosedRow()
        {
            object value = new object();
            IdentityRuntimeArrayRowState<long[]>.Value = value;

            Assert.AreSame(value, new IdentityRuntimeArrayOuter<long>().ReadRow());
        }

        [TestMethod]
        public void RuntimeClosed_ValueTypeArg_StampsItsOwnFields()
        {
            object boxed = new IdentityRuntimeValueOuter<int>().ReadBoxed();

            Assert.IsTrue(((IIdentityRuntimeInner)boxed).Inner() is int);
        }

        [TestMethod]
        public void RuntimeClosed_WithClosedRow_IsSameType()
        {
            Assert.IsTrue(new IdentityRuntimeOuterD<int>().Make() is IdentityRuntimeBox<int>);
        }

        [TestMethod]
        public void RuntimeClosed_AtLimit_CanCreateAndRunCctor()
        {
            Assert.IsNotNull(new IdentityRuntimeDeep<int>().Touch());
            Assert.AreEqual(1, IdentityCctorRuns.RuntimeDeep);
        }

        [TestMethod]
        public void RuntimeClosed_OverLimit_CreateThrows()
        {
            Assert.ThrowsException(
                typeof(Exception),
                () => new IdentityRuntimeOverLimit<IdentityInner<int>>().Touch());
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
        public static int RuntimeNested;
        public static int RuntimeBare;
        public static int RuntimeDeep;
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

    class IdentityStampA<T>
    {
        public T Value;

        public T Get()
        {
            T value = Value;

            return value;
        }
    }

    class IdentityStampB<T>
    {
        public T Value;

        public T Get()
        {
            return Value;
        }
    }

    class IdentityStampC<T>
    {
        public T Value;

        public T Get()
        {
            return Value;
        }
    }

    class IdentityStampD<T>
    {
        public T Value;

        public T Get()
        {
            return Value;
        }
    }

    struct IdentityStampStruct<T>
    {
        public T Value;
    }

    class IdentityStampE<T>
    {
        public T Value;
    }

    class IdentityStampF<T>
    {
        public T Value;
    }

    class IdentityStampG<T>
    {
        public T Value;
    }

    class IdentityStampH<T>
    {
        public T Value;
    }

    class IdentityStaticTA<T>
    {
        public static T Value;
    }

    class IdentityStaticTB<T>
    {
        public static T Value;
    }

    class IdentityStaticTC<T>
    {
        public static T Value;
    }

    class IdentityStaticTD<T>
    {
        public static T Value;
    }

    class IdentityStaticTE<T>
    {
        public static T Value;
        public static object Marker = new object();
    }

    class IdentityStaticTOuter<T>
    {
        public object Store()
        {
            IdentityStampH<T> stamp = new IdentityStampH<T>();
            IdentityStaticTE<IdentityStampH<T>>.Value = stamp;

            return stamp;
        }

        public object Read()
        {
            return IdentityStaticTE<IdentityStampH<T>>.Value;
        }

        public object ReadMarker()
        {
            return IdentityStaticTE<IdentityStampH<T>>.Marker;
        }
    }

    class IdentityRuntimeNestedHolder<T>
    {
        public static object Items = Make();

        private static object Make()
        {
            IdentityCctorRuns.RuntimeNested++;

            return new object();
        }

        public object Get()
        {
            return Items;
        }
    }

    class IdentityRuntimeBareHolder<T>
    {
        public static object Items = Make();

        private static object Make()
        {
            IdentityCctorRuns.RuntimeBare++;

            return new object();
        }

        public object Get()
        {
            return Items;
        }
    }

    class IdentityRuntimeOuterA<T>
    {
        public object Touch()
        {
            return new IdentityRuntimeNestedHolder<IdentityInner<T>>().Get();
        }

        public object TouchBare()
        {
            return new IdentityRuntimeBareHolder<T>().Get();
        }
    }

    class IdentityRuntimeState<T>
    {
        public static object Value;

        public void Store(object value)
        {
            Value = value;
        }

        public object Read()
        {
            return Value;
        }
    }

    class IdentityRuntimeNestedState<T>
    {
        public static object Value;

        public void Store(object value)
        {
            Value = value;
        }

        public object Read()
        {
            return Value;
        }
    }

    class IdentityRuntimeOuterB<T>
    {
        public void Store(object value)
        {
            new IdentityRuntimeState<T>().Store(value);
            new IdentityRuntimeNestedState<IdentityInner<T>>().Store(value);
        }

        public object Read()
        {
            return new IdentityRuntimeState<T>().Read();
        }

        public object ReadNested()
        {
            return new IdentityRuntimeNestedState<IdentityInner<T>>().Read();
        }
    }

    class IdentityRuntimeField<T>
    {
        public T Value;

        public object Boxed()
        {
            return Value;
        }

        public T Get()
        {
            return Value;
        }
    }

    class IdentityRuntimeOuterC<T>
    {
        public object ReadDefault()
        {
            return new IdentityRuntimeField<T>().Boxed();
        }

        public T RoundTrip(T value)
        {
            IdentityRuntimeField<T> field = new IdentityRuntimeField<T>();
            field.Value = value;

            return field.Get();
        }
    }

    class IdentityRuntimePair<T1, T2>
    {
        public object NewFirstArray()
        {
            return new T1[1];
        }

        public object NewSecondArray()
        {
            return new T2[1];
        }

        public object SwappedFirst()
        {
            return new IdentityRuntimePair<T2, T1>().NewFirstArray();
        }

        public object SwappedSecond()
        {
            return new IdentityRuntimePair<T2, T1>().NewSecondArray();
        }
    }

    class IdentityRuntimeArrayState<T>
    {
        public static object Value;

        public void Store(object value)
        {
            Value = value;
        }

        public object Read()
        {
            return Value;
        }
    }

    class IdentityRuntimeArrayRowState<T>
    {
        public static object Value;

        public object Read()
        {
            return Value;
        }
    }

    class IdentityRuntimeArrayOuter<T>
    {
        public void Store(object value)
        {
            new IdentityRuntimeArrayState<T[]>().Store(value);
        }

        public object Read()
        {
            return new IdentityRuntimeArrayState<T[]>().Read();
        }

        public object ReadRow()
        {
            return new IdentityRuntimeArrayRowState<T[]>().Read();
        }
    }

    interface IIdentityRuntimeInner
    {
        object Inner();
    }

    struct IdentityRuntimeStruct<T> : IIdentityRuntimeInner
    {
        public T Value;

        public object Inner()
        {
            return Value;
        }
    }

    class IdentityRuntimeValueHolder<T>
    {
        public T Value;

        public object Boxed()
        {
            return Value;
        }
    }

    class IdentityRuntimeValueOuter<T>
    {
        public object ReadBoxed()
        {
            return new IdentityRuntimeValueHolder<IdentityRuntimeStruct<T>>().Boxed();
        }
    }

    class IdentityRuntimeBox<T>
    {
    }

    class IdentityRuntimeOuterD<T>
    {
        public object Make()
        {
            return new IdentityRuntimeBox<T>();
        }
    }

    class IdentityRuntimeDeepHolder<T>
    {
        public static object Items = Make();

        private static object Make()
        {
            IdentityCctorRuns.RuntimeDeep++;

            return new object();
        }

        public object Get()
        {
            return Items;
        }
    }

    class IdentityRuntimeDeep<T>
    {
        public object Touch()
        {
            return new IdentityRuntimeDeepHolder<IdentityInner<IdentityInner<IdentityInner<T>>>>().Get();
        }
    }

    class IdentityRuntimeOverLimitHolder<T>
    {
        public object Get()
        {
            return this;
        }
    }

    class IdentityRuntimeOverLimit<T>
    {
        public object Touch()
        {
            return new IdentityRuntimeOverLimitHolder<IdentityInner<IdentityInner<IdentityInner<T>>>>().Get();
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

        public static object StoreStaticTB<U>()
        {
            IdentityStampF<U> stamp = new IdentityStampF<U>();
            IdentityStaticTB<IdentityStampF<U>>.Value = stamp;

            return stamp;
        }

        public static object ReadStaticTB<U>()
        {
            return IdentityStaticTB<IdentityStampF<U>>.Value;
        }

        public static U ReadStaticTC<U>()
        {
            return IdentityStaticTC<IdentityStampG<U>>.Value.Value;
        }

        public static void StoreStaticTD<U>(U value)
        {
            IdentityStaticTD<U>.Value = value;
        }

        public static U ReadStaticTD<U>()
        {
            return IdentityStaticTD<U>.Value;
        }
    }
}
