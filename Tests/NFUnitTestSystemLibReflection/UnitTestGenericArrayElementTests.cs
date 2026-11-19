// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestGenericArrayElementTests
    {
        [TestMethod]
        public void CastToEnumerable_ComparesTheElementArguments()
        {
            object value = new ElemCastBox<int>[2];

            Assert.IsNotNull((System.Collections.Generic.IEnumerable<ElemCastBox<int>>)value);
            Assert.ThrowsException(
                typeof(InvalidCastException),
                () => { _ = (System.Collections.Generic.IEnumerable<ElemCastBox<string>>)value; });
            Assert.IsNotNull((object[])value);
            Assert.IsNotNull((Array)value);
        }

        [TestMethod]
        public void IsInst_EnumerableOfOtherInstantiation_IsFalse()
        {
            object value = new ElemIsInstBox<int>[1];

            Assert.IsTrue(value is System.Collections.Generic.IEnumerable<ElemIsInstBox<int>>);
            Assert.IsFalse(value is System.Collections.Generic.IEnumerable<ElemIsInstBox<string>>);
        }

        [TestMethod]
        public void CastToArray_ComparesTheElementArguments()
        {
            object value = new ElemArrayCastBox<int>[1];

            Assert.IsNotNull((ElemArrayCastBox<int>[])value);
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (ElemArrayCastBox<string>[])value; });
            Assert.IsNull(value as ElemArrayCastBox<string>[]);
            Assert.IsNotNull(value as ElemArrayCastBox<int>[]);
        }

        [TestMethod]
        public void ArrayType_DiffersPerInstantiation()
        {
            Type ofInt = typeof(ElemTypeBox<int>[]);
            Type ofString = typeof(ElemTypeBox<string>[]);

            Assert.IsTrue(ofInt == new ElemTypeBox<int>[0].GetType());
            Assert.IsFalse(ofInt == ofString);
            Assert.IsTrue(ofInt.IsArray);
        }

        [TestMethod]
        public void GetElementType_KeepsTheGenericArguments()
        {
            Type element = typeof(ElemGetBox<int>[]).GetElementType();

            Assert.IsTrue(element == typeof(ElemGetBox<int>));
            Assert.IsFalse(element == typeof(ElemGetBox<string>));
            Assert.IsTrue(element.IsGenericType);
        }

        [TestMethod]
        public void GetElementType_ProvidesMembersWithOwnerContext()
        {
            Type element = typeof(ElemMemberBox<int>[]).GetElementType();
            MethodInfo setter = element.GetMethod("SetValue");
            ElemMemberBox<int> instance = new ElemMemberBox<int>();

            setter.Invoke(instance, new object[] { 5 });

            Assert.AreEqual(5, instance.Value);
            Assert.ThrowsException(typeof(Exception), () => setter.Invoke(instance, new object[] { "x" }));
        }

        [TestMethod]
        public void ArrayCreateInstance_UsesTheGenericElementType()
        {
            Array created = Array.CreateInstance(typeof(ElemCreateBox<int>), 2);

            Assert.IsTrue(created is ElemCreateBox<int>[]);
            Assert.IsFalse(created is ElemCreateBox<string>[]);
            Assert.IsTrue(created.GetType() == typeof(ElemCreateBox<int>[]));
        }

        [TestMethod]
        public void IsInstanceOfType_ComparesTheElementArguments()
        {
            object value = new ElemInstanceBox<int>[1];

            Assert.IsTrue(typeof(ElemInstanceBox<int>[]).IsInstanceOfType(value));
            Assert.IsFalse(typeof(ElemInstanceBox<string>[]).IsInstanceOfType(value));
        }

        [TestMethod]
        public void StoreThroughObjectArray_RejectsAnotherInstantiation()
        {
            object[] array = new ElemStoreBox<int>[1];

            array[0] = new ElemStoreBox<int>();

            Assert.ThrowsException(typeof(Exception), () => { array[0] = new ElemStoreBox<string>(); });
        }

        [TestMethod]
        public void ArrayCopy_JaggedArrays_ComparesTheElementArguments()
        {
            ElemJaggedCopyBox<int>[][] source = new ElemJaggedCopyBox<int>[][] { new ElemJaggedCopyBox<int>[1] };
            ElemJaggedCopyBox<int>[][] same = new ElemJaggedCopyBox<int>[1][];
            ElemJaggedCopyBox<string>[][] other = new ElemJaggedCopyBox<string>[1][];

            Array.Copy(source, same, 1);

            Assert.IsNotNull(same[0]);
            Assert.ThrowsException(typeof(InvalidCastException), () => Array.Copy(source, other, 1));
        }

        [TestMethod]
        public void StoreThroughObjectArray_JaggedArrays_RejectsAnotherInstantiation()
        {
            object[] jagged = new ElemJaggedStoreBox<string>[1][];

            jagged[0] = new ElemJaggedStoreBox<string>[1];

            Assert.ThrowsException(typeof(Exception), () => { jagged[0] = new ElemJaggedStoreBox<int>[1]; });
        }

        [TestMethod]
        public void Covariance_GenericBaseClassOfTheElement_IsAccepted()
        {
            object value = new ElemDerivedBox<int>[1];

            Assert.IsNotNull((ElemBaseBox<int>[])value);
            Assert.IsTrue(value is ElemBaseBox<int>[]);
            Assert.IsTrue(typeof(ElemBaseBox<int>[]).IsInstanceOfType(value));
            Assert.IsFalse(value is ElemBaseBox<string>[]);
            Assert.IsFalse(typeof(ElemBaseBox<string>[]).IsInstanceOfType(value));
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (ElemBaseBox<string>[])value; });
        }

        [TestMethod]
        public void NewArrayInGenericMethod_UsesTheMethodArgument()
        {
            object forInt = ElemMethodHolder.Make<ElemMethodBox<int>>();
            object forString = ElemMethodHolder.Make<ElemMethodBox<string>>();

            Assert.IsTrue(forInt is ElemMethodBox<int>[]);
            Assert.IsFalse(forInt is ElemMethodBox<string>[]);
            Assert.IsTrue(forString is ElemMethodBox<string>[]);
            Assert.IsFalse(forString is ElemMethodBox<int>[]);
        }

        [TestMethod]
        public void ArrayCopy_ComparesTheElementArguments()
        {
            ElemCopyBox<int>[] source = new ElemCopyBox<int>[] { new ElemCopyBox<int>(), new ElemCopyBox<int>() };
            ElemCopyBox<int>[] same = new ElemCopyBox<int>[2];
            ElemCopyBox<string>[] other = new ElemCopyBox<string>[2];
            object[] objects = new object[2];

            Array.Copy(source, same, 2);
            Array.Copy(source, objects, 2);

            Assert.IsNotNull(same[1]);
            Assert.IsNotNull(objects[1]);
            Assert.ThrowsException(typeof(InvalidCastException), () => Array.Copy(source, other, 2));
        }

        [TestMethod]
        public void NewArrayInGenericCode_UsesTheClosedElement()
        {
            object forInt = ElemNewHolder<int>.Make();
            object forString = ElemNewHolder<string>.Make();

            Assert.IsTrue(forInt is ElemNewBox<int>[]);
            Assert.IsFalse(forInt is ElemNewBox<string>[]);
            Assert.IsTrue(forString is ElemNewBox<string>[]);
            Assert.IsFalse(forString is ElemNewBox<int>[]);
        }

        [TestMethod]
        public void StoreInGenericCode_AcceptsTheSameInstantiation()
        {
            ElemStoreHolder<ElemStoreInner<int>> holder = new ElemStoreHolder<ElemStoreInner<int>>();

            holder.Set(new ElemStoreInner<int>());
            holder.Set(new ElemStoreInner<int>());

            Assert.AreEqual(2, holder.Count);
        }

        [TestMethod]
        public void NestedGenericElement_IsInvariant()
        {
            object value = new ElemNestedBox<ElemNestedBox<int>>[1];

            Assert.IsTrue(value is ElemNestedBox<ElemNestedBox<int>>[]);
            Assert.IsFalse(value is ElemNestedBox<ElemNestedBox<string>>[]);
            Assert.IsFalse(value is ElemNestedBox<int>[]);
        }

        [TestMethod]
        public void JaggedArray_KeepsTheInnermostInstantiation()
        {
            object value = new ElemJaggedBox<int>[1][];

            Assert.IsTrue(value is ElemJaggedBox<int>[][]);
            Assert.IsFalse(value is ElemJaggedBox<string>[][]);
            Assert.IsTrue(typeof(ElemJaggedBox<int>[][]).GetElementType() == typeof(ElemJaggedBox<int>[]));
        }

        [TestMethod]
        public void ForEach_OverArrayOfGeneric_Works()
        {
            ElemForEachBox<int>[] array = new ElemForEachBox<int>[]
            {
                new ElemForEachBox<int> { Value = 1 },
                new ElemForEachBox<int> { Value = 2 }
            };
            System.Collections.Generic.IEnumerable<ElemForEachBox<int>> sequence = array;
            int sum = 0;

            foreach (ElemForEachBox<int> item in sequence)
            {
                sum += item.Value;
            }

            Assert.AreEqual(3, sum);
        }

        [TestMethod]
        public void ForEach_OverJaggedArray_BindsTheArrayElement()
        {
            int[][] jagged = new int[][] { new int[] { 1, 2 }, new int[] { 3 } };
            System.Collections.Generic.IEnumerable<int[]> sequence = jagged;
            int sum = 0;

            foreach (int[] item in sequence)
            {
                foreach (int value in item)
                {
                    sum += value;
                }
            }

            Assert.AreEqual(6, sum);
        }

        [TestMethod]
        public void NonGenericArrays_AreUnchanged()
        {
            object value = new int[2];

            Assert.IsTrue(value is int[]);
            Assert.IsTrue(value is System.Collections.Generic.IEnumerable<int>);
            Assert.IsFalse(value is System.Collections.Generic.IEnumerable<string>);
            Assert.IsTrue(typeof(string[]).GetElementType() == typeof(string));
        }

        private class ElemCastBox<T> { public T Value; }

        private class ElemIsInstBox<T> { public T Value; }

        private class ElemArrayCastBox<T> { public T Value; }

        private class ElemTypeBox<T> { public T Value; }

        private class ElemGetBox<T> { public T Value; }

        private class ElemMemberBox<T>
        {
            public T Value;

            public void SetValue(T value)
            {
                Value = value;
            }
        }

        private class ElemCreateBox<T> { public T Value; }

        private class ElemInstanceBox<T> { public T Value; }

        private class ElemStoreBox<T> { public T Value; }

        private class ElemCopyBox<T> { public T Value; }

        private class ElemNewBox<T> { public T Value; }

        private class ElemNewHolder<T>
        {
            public static object Make()
            {
                return new ElemNewBox<T>[1];
            }
        }

        private class ElemStoreInner<T> { public T Value; }

        private class ElemStoreHolder<T>
        {
            private T[] _items = new T[1];

            public int Count;

            public void Set(T value)
            {
                if (Count == _items.Length)
                {
                    T[] bigger = new T[Count * 2];

                    Array.Copy(_items, bigger, Count);
                    _items = bigger;
                }

                _items[Count++] = value;
            }
        }

        private class ElemJaggedCopyBox<T> { public T Value; }

        private class ElemJaggedStoreBox<T> { public T Value; }

        private class ElemBaseBox<T> { public T Value; }

        private class ElemDerivedBox<T> : ElemBaseBox<T> { }

        private class ElemMethodBox<T> { public T Value; }

        private static class ElemMethodHolder
        {
            public static object Make<T>()
            {
                return new T[1];
            }
        }

        private class ElemNestedBox<T> { public T Value; }

        private class ElemJaggedBox<T> { public T Value; }

        private class ElemForEachBox<T> { public T Value; }
    }
}
