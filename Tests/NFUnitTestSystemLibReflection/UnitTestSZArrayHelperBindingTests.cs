// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // T of the SZArrayHelper methods is the element of the array, including arrays of arrays and generic instances.
    [TestClass]
    public class UnitTestSZArrayHelperBindingTests
    {
        [TestMethod]
        public void Enumerator_OfGenericInstanceArray_IsOfTheInstantiation()
        {
            IEnumerable<SzbBox<int>> source = new SzbBox<int>[1];
            object enumerator = source.GetEnumerator();

            Assert.IsTrue(enumerator is IEnumerator<SzbBox<int>>);
            Assert.IsFalse(enumerator is IEnumerator<SzbBox<string>>);
        }

        [TestMethod]
        public void Enumerator_OfJaggedGenericInstanceArray_IsOfTheInstantiation()
        {
            IEnumerable<SzbJaggedBox<int>[]> source = new SzbJaggedBox<int>[1][];
            object enumerator = source.GetEnumerator();

            Assert.IsTrue(enumerator is IEnumerator<SzbJaggedBox<int>[]>);
            Assert.IsFalse(enumerator is IEnumerator<SzbJaggedBox<string>[]>);
        }

        [TestMethod]
        public void Enumerator_OfJaggedPrimitiveArray_IsOfTheElement()
        {
            IEnumerable<int[]> source = new int[1][];
            object enumerator = source.GetEnumerator();

            Assert.IsTrue(enumerator is IEnumerator<int[]>);
            Assert.IsFalse(enumerator is IEnumerator<string[]>);
            Assert.IsFalse(enumerator is IEnumerator<int>);
        }

        [TestMethod]
        public void Enumerator_OfThreeLevelArray_IsOfTheElement()
        {
            IEnumerable<string[][]> source = new string[1][][];
            object enumerator = source.GetEnumerator();

            Assert.IsTrue(enumerator is IEnumerator<string[][]>);
            Assert.IsFalse(enumerator is IEnumerator<string[]>);
        }

        [TestMethod]
        public void Enumerator_OfPrimitiveArray_IsOfTheElement()
        {
            IEnumerable<int> source = new int[] { 1 };
            object enumerator = source.GetEnumerator();

            Assert.IsTrue(enumerator is IEnumerator<int>);
            Assert.IsFalse(enumerator is IEnumerator<long>);
        }

        [TestMethod]
        public void Enumerator_GenericArgument_IsTheElement()
        {
            IEnumerable<int[]> jagged = new int[1][];
            IEnumerable<SzbArgBox<int>> boxes = new SzbArgBox<int>[1];

            Type[] jaggedArguments = jagged.GetEnumerator().GetType().GetGenericArguments();
            Type[] boxArguments = boxes.GetEnumerator().GetType().GetGenericArguments();

            Assert.AreEqual(1, jaggedArguments.Length);
            Assert.AreEqual(typeof(int[]), jaggedArguments[0]);
            Assert.AreEqual(1, boxArguments.Length);
            Assert.AreEqual(typeof(SzbArgBox<int>), boxArguments[0]);
        }

        [TestMethod]
        public void EmptyEnumerator_IsPerInstantiation()
        {
            object first = ((IEnumerable<SzbEmptyBox<int>>)new SzbEmptyBox<int>[0]).GetEnumerator();
            object second = ((IEnumerable<SzbEmptyBox<string>>)new SzbEmptyBox<string>[0]).GetEnumerator();

            Assert.IsFalse(object.ReferenceEquals(first, second));
        }

        [TestMethod]
        public void EmptyEnumerator_OfJaggedArrays_IsPerElement()
        {
            object ints = ((IEnumerable<int[]>)new int[0][]).GetEnumerator();
            object strings = ((IEnumerable<string[]>)new string[0][]).GetEnumerator();

            Assert.IsFalse(object.ReferenceEquals(ints, strings));
            Assert.IsTrue(ints is IEnumerator<int[]>);
            Assert.IsTrue(strings is IEnumerator<string[]>);
        }

        [TestMethod]
        public void Jagged_CollectionMembers_Work()
        {
            int[] inner = new int[] { 4 };
            int[][] array = new int[][] { new int[] { 1 }, inner };
            ICollection<int[]> collection = array;
            int[][] copy = new int[3][];

            Assert.AreEqual(2, collection.Count);
            Assert.IsTrue(collection.Contains(inner));
            Assert.IsFalse(collection.Contains(new int[] { 4 }));

            collection.CopyTo(copy, 1);

            Assert.IsNull(copy[0]);
            Assert.IsTrue(object.ReferenceEquals(inner, copy[2]));
        }

        [TestMethod]
        public void Jagged_Foreach_ReadsTheElements()
        {
            IEnumerable<string[]> source = new string[][] { new string[] { "a" }, new string[] { "b", "c" } };
            int total = 0;

            foreach (string[] item in source)
            {
                total += item.Length;
            }

            Assert.AreEqual(3, total);
        }

        [TestMethod]
        public void JaggedGeneric_CollectionMembers_Work()
        {
            SzbItem<int>[] inner = new SzbItem<int>[] { new SzbItem<int>(5) };
            ICollection<SzbItem<int>[]> collection = new SzbItem<int>[][] { inner };
            int count = 0;

            Assert.IsTrue(collection.Contains(inner));

            foreach (SzbItem<int>[] item in collection)
            {
                Assert.AreEqual(5, item[0].Value);
                count++;
            }

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void GenericStructElements_EnumerateValues()
        {
            IEnumerable<SzbPair<int>> source = new SzbPair<int>[] { new SzbPair<int>(1), new SzbPair<int>(2) };
            int total = 0;

            foreach (SzbPair<int> item in source)
            {
                total += item.Value;
            }

            Assert.AreEqual(3, total);
        }

        [TestMethod]
        public void Clear_OnJaggedAndGenericArrays_IsNotSupportedAndKeepsTheElements()
        {
            int[][] jagged = new int[][] { new int[1] };
            SzbItem<int>[] boxes = new SzbItem<int>[] { new SzbItem<int>(1) };
            string[] strings = new string[] { "a" };

            Assert.ThrowsException(typeof(NotSupportedException), () => ((ICollection<int[]>)jagged).Clear());
            Assert.ThrowsException(typeof(NotSupportedException), () => ((ICollection<SzbItem<int>>)boxes).Clear());
            Assert.ThrowsException(typeof(NotSupportedException), () => ((ICollection<string>)strings).Clear());

            Assert.IsNotNull(jagged[0]);
            Assert.IsNotNull(boxes[0]);
            Assert.AreEqual("a", strings[0]);
        }

        [TestMethod]
        public void NonGenericClear_ClearsTheArray()
        {
            string[] strings = new string[] { "a" };

            ((System.Collections.IList)strings).Clear();

            Assert.IsNull(strings[0]);
        }
    }

    public class SzbBox<T>
    {
    }

    public class SzbJaggedBox<T>
    {
    }

    public class SzbEmptyBox<T>
    {
    }

    public class SzbArgBox<T>
    {
    }

    public class SzbItem<T>
    {
        public SzbItem(T value)
        {
            Value = value;
        }

        public T Value;
    }

    public struct SzbPair<T>
    {
        public SzbPair(T value)
        {
            Value = value;
        }

        public T Value;
    }
}
