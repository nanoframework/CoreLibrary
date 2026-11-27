// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestArrayIndexOfTests
    {
        [TestMethod]
        public void Contains_Null_FindsTheNullElement()
        {
            ICollection<string> collection = new string[] { "a", null };

            Assert.IsTrue(collection.Contains(null));
        }

        [TestMethod]
        public void Contains_Null_FindsTheNullElementFirst()
        {
            ICollection<string> collection = new string[] { null, "a" };

            Assert.IsTrue(collection.Contains(null));
        }

        [TestMethod]
        public void Contains_Null_IsFalseWithoutNullElements()
        {
            ICollection<string> collection = new string[] { "a", "b" };

            Assert.IsFalse(collection.Contains(null));
        }

        [TestMethod]
        public void IndexOf_Null_InStringArray()
        {
            Assert.AreEqual(1, Array.IndexOf(new string[] { "a", null }, null));
            Assert.AreEqual(0, Array.IndexOf(new string[2], null));
        }

        [TestMethod]
        public void IndexOf_Null_InObjectArray()
        {
            Assert.AreEqual(1, Array.IndexOf(new object[] { 1, null }, null));
        }

        [TestMethod]
        public void IndexOf_Null_InClassArray()
        {
            Assert.AreEqual(0, Array.IndexOf(new AioKey[1], null));
        }

        [TestMethod]
        public void IndexOf_Null_InPrimitiveArray_IsNotFound()
        {
            Assert.AreEqual(-1, Array.IndexOf(new int[] { 0 }, null));
        }

        [TestMethod]
        public void StringArray_DefaultElement_IsNull()
        {
            string[] array = new string[1];

            Assert.IsTrue(object.ReferenceEquals(array[0], null));
            Assert.IsNull(((IList)array)[0]);
            Assert.IsNull(array.GetValue(0));
        }

        [TestMethod]
        public void IndexOf_ClassWithEqualsOverride_ReturnsTheFirstMatch()
        {
            AioKey target = new AioKey(7);
            AioKey[] array = new AioKey[] { new AioKey(7), target };

            Assert.AreEqual(0, Array.IndexOf(array, target));
        }

        [TestMethod]
        public void Contains_ClassWithEqualsOverride_MatchesAnEqualElement()
        {
            ICollection<AioKey> collection = new AioKey[] { new AioKey(1), new AioKey(7) };

            Assert.IsTrue(collection.Contains(new AioKey(7)));
            Assert.IsFalse(collection.Contains(new AioKey(8)));
        }

        [TestMethod]
        public void IndexOf_ClassWithoutEqualsOverride_ComparesReferences()
        {
            AioPlain target = new AioPlain();
            AioPlain[] array = new AioPlain[] { new AioPlain(), target };

            Assert.AreEqual(1, Array.IndexOf(array, target));
            Assert.AreEqual(-1, Array.IndexOf(array, new AioPlain()));
        }

        [TestMethod]
        public void IndexOf_Strings_CompareByValue()
        {
            string[] array = new string[] { "a", "bc" };
            string value = new string('b', 1) + "c";

            Assert.AreEqual(1, Array.IndexOf(array, value));
        }

        [TestMethod]
        public void IndexOf_Structs_CompareByValue()
        {
            AioPoint[] array = new AioPoint[] { new AioPoint(1, 2), new AioPoint(3, 4) };

            Assert.AreEqual(1, Array.IndexOf(array, new AioPoint(3, 4)));
            Assert.AreEqual(-1, Array.IndexOf(array, new AioPoint(4, 3)));
        }

        [TestMethod]
        public void IndexOf_BoxedValuesInObjectArray_CompareByValue()
        {
            object[] array = new object[] { "x", 5 };

            Assert.AreEqual(1, Array.IndexOf(array, 5));
            Assert.AreEqual(-1, Array.IndexOf(array, 5L));
        }

        [TestMethod]
        public void IndexOf_FloatingPointZeroes_AreEqual()
        {
            Assert.AreEqual(0, Array.IndexOf(new double[] { 0.0 }, -0.0));
            Assert.AreEqual(0, Array.IndexOf(new double[] { -0.0 }, 0.0));
            Assert.AreEqual(0, Array.IndexOf(new float[] { 0.0f }, -0.0f));
        }

        [TestMethod]
        public void IndexOf_NaN_IsFound()
        {
            Assert.AreEqual(1, Array.IndexOf(new double[] { 1.0, double.NaN }, double.NaN));
            Assert.AreEqual(1, Array.IndexOf(new float[] { 1.0f, float.NaN }, float.NaN));
        }

        [TestMethod]
        public void IndexOf_PrimitiveOfAnotherType_IsNotFound()
        {
            Assert.AreEqual(-1, Array.IndexOf(new long[] { 5 }, 5));
            Assert.AreEqual(-1, Array.IndexOf(new int[] { 5 }, 5L));
            Assert.AreEqual(-1, Array.IndexOf(new double[] { 5 }, 5));
        }

        [TestMethod]
        public void IndexOf_Primitives_HonourStartAndCount()
        {
            int[] array = new int[] { 3, 1, 3, 3 };

            Assert.AreEqual(0, Array.IndexOf(array, 3));
            Assert.AreEqual(2, Array.IndexOf(array, 3, 1));
            Assert.AreEqual(-1, Array.IndexOf(array, 3, 1, 1));
        }

        [TestMethod]
        public void IndexOf_References_HonourStartAndCount()
        {
            string[] array = new string[] { "a", "b", "a" };

            Assert.AreEqual(2, Array.IndexOf(array, "a", 1));
            Assert.AreEqual(-1, Array.IndexOf(array, "a", 1, 1));
        }

        [TestMethod]
        public void IndexOf_ThroughIList_UsesEquals()
        {
            IList list = new AioKey[] { new AioKey(2), new AioKey(9) };

            Assert.AreEqual(1, list.IndexOf(new AioKey(9)));
            Assert.IsTrue(list.Contains(new AioKey(2)));
        }

        [TestMethod]
        public void ArrayList_UsesEquals()
        {
            ArrayList list = new ArrayList();
            list.Add(new AioKey(4));
            list.Add(null);

            Assert.AreEqual(0, list.IndexOf(new AioKey(4)));
            Assert.AreEqual(1, list.IndexOf(null));
            Assert.IsTrue(list.Contains(null));

            list.Remove(new AioKey(4));

            Assert.AreEqual(1, list.Count);
        }

        private class AioKey
        {
            private readonly int _id;

            public AioKey(int id)
            {
                _id = id;
            }

            public override bool Equals(object obj)
            {
                return obj is AioKey other && other._id == _id;
            }

            public override int GetHashCode()
            {
                return _id;
            }
        }

        private class AioPlain
        {
        }

        private struct AioPoint
        {
            public int X;
            public int Y;

            public AioPoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
