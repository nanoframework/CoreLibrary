// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestClasses
{
    [TestClass]
    class UnitTestGenericStaticTests
    {
        [TestMethod]
        public void Generic_StaticField_FirstTouch_Read()
        {
            // First interaction with this closed generic type is a static field read
            // (CEE_LDSFLD), not a constructor call.
            Assert.AreEqual(1, GenericWithStaticField<int>.InitCount);
        }

        [TestMethod]
        public void Generic_StaticMethod_FirstTouch_Call()
        {
            // First interaction with this closed generic type is a static method
            // call (CEE_CALL), not a constructor call.
            Assert.IsTrue(GenericWithStaticMethod<long>.IsInitialized());
        }

        [TestMethod]
        public void Generic_StaticField_NonGenericHolder()
        {
            BoxHolder.IntBox.Add(42);

            Assert.AreEqual(1, BoxHolder.IntBox.Count);
            Assert.AreEqual(42, BoxHolder.IntBox.Items[0]);

            BoxHolder.StringBox.Add("hello");

            Assert.AreEqual(1, BoxHolder.StringBox.Count);
            Assert.AreEqual("hello", BoxHolder.StringBox.Items[0]);
        }

        [TestMethod]
        public void Generic_StaticField_GenericHolder()
        {
            GenericBoxHolder<int>.Box.Add(99);

            Assert.AreEqual(1, GenericBoxHolder<int>.Box.Count);
            Assert.AreEqual(99, GenericBoxHolder<int>.Box.Items[0]);
        }

        [TestMethod]
        public void Generic_StaticField_MultipleInstantiations()
        {
            Assert.AreEqual(1, GenericWithStaticField<byte>.InitCount);
            Assert.AreEqual(1, GenericWithStaticField<string>.InitCount);
        }

        [TestMethod]
        public void Generic_SingleParam_ValueType()
        {
            var container = new GenericContainer<int>(42);

            Assert.AreEqual(42, container.GetValue());

            container.SetValue(100);

            Assert.AreEqual(100, container.GetValue());
        }

        [TestMethod]
        public void Generic_SingleParam_ReferenceType()
        {
            var container = new GenericContainer<string>("hello");

            Assert.AreEqual("hello", container.GetValue());
        }

        [TestMethod]
        public void Generic_SingleParam_Convert()
        {
            var container = new GenericContainer<int>(21);

            int doubled = container.Convert(v => v * 2);

            Assert.AreEqual(42, doubled);
        }

        [TestMethod]
        public void Generic_TwoParam_MixedTypes()
        {
            var pair = new GenericPair<int, string>(1, "one");

            Assert.AreEqual(1, pair.First);
            Assert.AreEqual("one", pair.Second);
        }

        [TestMethod]
        public void Generic_TwoParam_SameType()
        {
            var pair = new GenericPair<int, int>(10, 20);

            Assert.AreEqual(10, pair.First);
            Assert.AreEqual(20, pair.Second);
        }

        [TestMethod]
        public void Generic_GenericMethod_Resolution()
        {
            int a = 1;
            int b = 2;
            Swap(ref a, ref b);

            Assert.AreEqual(2, a);
            Assert.AreEqual(1, b);

            string s1 = "A";
            string s2 = "B";
            Swap(ref s1, ref s2);

            Assert.AreEqual("B", s1);
            Assert.AreEqual("A", s2);
        }

        [TestMethod]
        public void Generic_MultipleInstantiations_SameMethod()
        {
            var intContainer = new GenericContainer<int>(1);
            var stringContainer = new GenericContainer<string>("one");
            var pair = new GenericPair<bool, int>(true, 2);

            Assert.AreEqual(1, intContainer.GetValue());
            Assert.AreEqual("one", stringContainer.GetValue());
            Assert.IsTrue(pair.First);
            Assert.AreEqual(2, pair.Second);
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        internal class GenericWithStaticField<T>
        {
            internal static T DefaultValue = default(T);
            internal static int InitCount = 0;

            static GenericWithStaticField()
            {
                InitCount = 1;
            }
        }

        internal class GenericWithStaticMethod<T>
        {
            private static bool _initialized = false;

            static GenericWithStaticMethod()
            {
                _initialized = true;
            }

            internal static bool IsInitialized()
            {
                return _initialized;
            }
        }

        internal class GenericStaticFieldBox<T>
        {
            internal T[] Items;
            internal int Count;

            internal GenericStaticFieldBox()
            {
                Items = new T[4];
                Count = 0;
            }

            internal void Add(T item)
            {
                Items[Count++] = item;
            }
        }

        internal static class BoxHolder
        {
            internal static readonly GenericStaticFieldBox<int> IntBox = new GenericStaticFieldBox<int>();
            internal static readonly GenericStaticFieldBox<string> StringBox = new GenericStaticFieldBox<string>();
        }

        internal static class GenericBoxHolder<T>
        {
            internal static readonly GenericStaticFieldBox<T> Box = new GenericStaticFieldBox<T>();
        }

        internal class GenericContainer<T>
        {
            private T _value;

            internal GenericContainer(T value)
            {
                _value = value;
            }

            internal T GetValue() => _value;

            internal void SetValue(T value) => _value = value;

            internal TResult Convert<TResult>(Func<T, TResult> converter)
            {
                return converter(_value);
            }
        }

        internal class GenericPair<TFirst, TSecond>
        {
            internal TFirst First;
            internal TSecond Second;

            internal GenericPair(TFirst first, TSecond second)
            {
                First = first;
                Second = second;
            }
        }
    }
}
