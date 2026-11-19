// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestSZArrayHelperTests
    {
        [TestMethod]
        public void Contains_ReferenceElement_UsesEquals()
        {
            string[] array = new string[] { "alpha", "beta" };
            System.Collections.Generic.ICollection<string> collection = array;
            string equalButDistinct = new string(new char[] { 'b', 'e', 't', 'a' });

            Assert.IsTrue(collection.Contains(equalButDistinct));
            Assert.IsFalse(collection.Contains("gamma"));
        }

        [TestMethod]
        public void Contains_StructElement_UsesEquals()
        {
            SzhPoint[] array = new SzhPoint[] { new SzhPoint(1, 2), new SzhPoint(3, 4) };
            System.Collections.Generic.ICollection<SzhPoint> collection = array;

            Assert.IsTrue(collection.Contains(new SzhPoint(3, 4)));
            Assert.IsFalse(collection.Contains(new SzhPoint(4, 3)));
        }

        [TestMethod]
        public void Contains_ClassWithEqualsOverride_UsesEquals()
        {
            SzhKey[] array = new SzhKey[] { new SzhKey(1), new SzhKey(2) };
            System.Collections.Generic.ICollection<SzhKey> collection = array;

            Assert.IsTrue(collection.Contains(new SzhKey(2)));
            Assert.IsFalse(collection.Contains(new SzhKey(3)));
        }

        [TestMethod]
        public void IndexOf_EqualButDistinctEarlierElement_ReturnsTheFirstMatch()
        {
            string first = new string(new char[] { 'x', 'y' });
            string second = new string(new char[] { 'x', 'y' });
            string[] array = new string[] { first, second };

            Assert.AreEqual(0, ((IList)array).IndexOf(second));
            Assert.AreEqual(0, Array.IndexOf(array, second));
        }

        [TestMethod]
        public void IndexOf_NotFound_IsMinusOne()
        {
            Assert.AreEqual(-1, Array.IndexOf(new int[] { 1, 2, 3 }, 4));
            Assert.AreEqual(-1, Array.IndexOf(new string[] { "a" }, "b"));
            Assert.AreEqual(-1, Array.IndexOf(new SzhKey[] { new SzhKey(1) }, new SzhKey(2)));
        }

        [TestMethod]
        public void Collection_Members_BehaveForPrimitiveArrays()
        {
            int[] array = new int[] { 5, 6, 7 };
            System.Collections.Generic.ICollection<int> collection = array;
            int[] copy = new int[4];

            Assert.AreEqual(3, collection.Count);
            Assert.IsTrue(collection.IsReadOnly);
            Assert.IsTrue(collection.Contains(6));
            Assert.IsFalse(collection.Contains(8));

            collection.CopyTo(copy, 1);

            Assert.AreEqual(0, copy[0]);
            Assert.AreEqual(5, copy[1]);
            Assert.AreEqual(7, copy[3]);
        }

        [TestMethod]
        public void Collection_Mutators_AreNotSupported()
        {
            System.Collections.Generic.ICollection<string> collection = new string[] { "a" };

            Assert.ThrowsException(typeof(NotSupportedException), () => collection.Add("b"));
            Assert.ThrowsException(typeof(NotSupportedException), () => collection.Clear());
            Assert.ThrowsException(typeof(NotSupportedException), () => collection.Remove("a"));
        }

        [TestMethod]
        public void Collection_Members_BehaveForGenericElements()
        {
            SzhBox<int>[] array = new SzhBox<int>[] { new SzhBox<int>(), new SzhBox<int>() };
            System.Collections.Generic.ICollection<SzhBox<int>> collection = array;
            SzhBox<int>[] copy = new SzhBox<int>[2];

            Assert.AreEqual(2, collection.Count);
            Assert.IsTrue(collection.Contains(array[1]));
            Assert.IsFalse(collection.Contains(new SzhBox<int>()));

            collection.CopyTo(copy, 0);

            Assert.IsTrue(object.ReferenceEquals(array[0], copy[0]));
        }

        [TestMethod]
        public void Collection_Members_BehaveForArraysOfArrays()
        {
            int[][] array = new int[][] { new int[] { 1 }, new int[] { 2, 3 } };
            System.Collections.Generic.ICollection<int[]> collection = array;

            Assert.AreEqual(2, collection.Count);
            Assert.IsTrue(collection.Contains(array[1]));
            Assert.IsFalse(collection.Contains(new int[] { 1 }));
        }

        [TestMethod]
        public void Enumerator_Members_BehaveForEveryElementKind()
        {
            CheckEnumerator<int>(new int[] { 1, 2 });
            CheckEnumerator<string>(new string[] { "a", "b" });
            CheckEnumerator<SzhPoint>(new SzhPoint[] { new SzhPoint(1, 1), new SzhPoint(2, 2) });
            CheckEnumerator<SzhBox<string>>(new SzhBox<string>[] { new SzhBox<string>(), new SzhBox<string>() });
            CheckEnumerator<int[]>(new int[][] { new int[] { 1 }, new int[] { 2 } });
        }

        [TestMethod]
        public void Enumerator_OverEmptyArray_HasNoElements()
        {
            Assert.IsFalse(((System.Collections.Generic.IEnumerable<int>)new int[0]).GetEnumerator().MoveNext());
            Assert.IsFalse(((System.Collections.Generic.IEnumerable<string>)new string[0]).GetEnumerator().MoveNext());
            Assert.IsFalse(((System.Collections.Generic.IEnumerable<SzhBox<int>>)new SzhBox<int>[0]).GetEnumerator().MoveNext());
        }

        [TestMethod]
        public void Enumerator_CurrentOutOfRange_Throws()
        {
            System.Collections.Generic.IEnumerator<string> enumerator =
                ((System.Collections.Generic.IEnumerable<string>)new string[] { "a" }).GetEnumerator();

            Assert.ThrowsException(typeof(InvalidOperationException), () => { _ = enumerator.Current; });

            Assert.IsTrue(enumerator.MoveNext());
            Assert.IsFalse(enumerator.MoveNext());

            Assert.ThrowsException(typeof(InvalidOperationException), () => { _ = enumerator.Current; });
        }

        [TestMethod]
        public void Enumerator_Covariance_ReadsDerivedElements()
        {
            SzhDerived[] array = new SzhDerived[] { new SzhDerived(), new SzhDerived() };
            int count = 0;

            foreach (SzhBase item in (System.Collections.Generic.IEnumerable<SzhBase>)array)
            {
                Assert.IsNotNull(item);
                count++;
            }

            Assert.AreEqual(2, count);
        }

        private static void CheckEnumerator<T>(T[] array)
        {
            System.Collections.Generic.IEnumerator<T> enumerator =
                ((System.Collections.Generic.IEnumerable<T>)array).GetEnumerator();
            int count = 0;

            while (enumerator.MoveNext())
            {
                Assert.IsTrue(Equals(array[count], enumerator.Current) || array[count] is Array);
                count++;
            }

            Assert.AreEqual(array.Length, count);

            enumerator.Reset();

            Assert.IsTrue(enumerator.MoveNext());

            enumerator.Dispose();
        }

        private struct SzhPoint
        {
            public int X;
            public int Y;

            public SzhPoint(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(object obj)
            {
                return obj is SzhPoint other && other.X == X && other.Y == Y;
            }

            public override int GetHashCode()
            {
                return X ^ Y;
            }
        }

        private class SzhKey
        {
            private readonly int _id;

            public SzhKey(int id)
            {
                _id = id;
            }

            public override bool Equals(object obj)
            {
                return obj is SzhKey other && other._id == _id;
            }

            public override int GetHashCode()
            {
                return _id;
            }
        }

        private class SzhBox<T> { public T Value; }

        private class SzhBase { }

        private class SzhDerived : SzhBase { }
    }
}
