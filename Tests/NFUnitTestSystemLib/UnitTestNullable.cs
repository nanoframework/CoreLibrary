// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestNullable
    {
        [TestMethod]
        public void Ctor_Empty()
        {
            // Nullable and Nullable<T> are mostly verbatim ports so we don't test much here.

            int? n = default(int?);
            Assert.IsFalse(n.HasValue);

            // TODO replace with Assert.ThrowsException<InvalidOperationException> when available
            Assert.ThrowsException(
                typeof(InvalidOperationException),
                () => _ = n.Value);
            Assert.ThrowsException(
                typeof(InvalidOperationException),
                () => _ = (int)n);

            Assert.IsNull(n);
            Assert.AreNotEqual(7, n);
            Assert.AreEqual(0, n.GetHashCode());
            Assert.AreEqual("", n.ToString());
            Assert.AreEqual(default(int), n.GetValueOrDefault());
            Assert.AreEqual(999, n.GetValueOrDefault(999));

            n = new int?(42);
            Assert.IsTrue(n.HasValue);
            Assert.AreEqual(42, n.Value);
            Assert.AreEqual(42, (int)n);
            Assert.IsNotNull(n);
            Assert.AreNotEqual(7, n);
            Assert.AreEqual(42, n);
            Assert.AreEqual(42.GetHashCode(), n.GetHashCode());
            Assert.AreEqual(42.ToString(), n.ToString());
            Assert.AreEqual(42, n.GetValueOrDefault());
            Assert.AreEqual(42, n.GetValueOrDefault(999));

            n = 88;
            Assert.IsTrue(n.HasValue);
            Assert.AreEqual(88, n.Value);
        }

        [TestMethod]
        public static void Boxing()
        {
            int? n = new int?(42);
            Unbox(n);
        }

        private static void Unbox(object o)
        {
            Type t = o.GetType();

            // TOOD: replace with Assert.IsNotType<int?>(t); when available
            Assert.IsNotInstanceOfType(typeof(int?), t);

            Assert.AreEqual(typeof(int), t);
        }

        [TestMethod]
        public static void ExplicitCast_T()
        {
            int? nullable = 5;
            int value = (int)nullable;
            Assert.AreEqual(5, value);

            nullable = null;
            // TODO replace with Assert.Throws<InvalidOperationException>(() => (int)nullable); when available
            Assert.ThrowsException(
                typeof(InvalidOperationException),
                () => _ = (int)nullable);
        }

        [TestMethod]
        public static void GetUnderlyingType()
        {
            Assert.AreEqual(typeof(int), Nullable.GetUnderlyingType(typeof(int?)));
            Assert.AreEqual(null, Nullable.GetUnderlyingType(typeof(int)));
            Assert.AreEqual(null, Nullable.GetUnderlyingType(typeof(G<int>)));
        }

        [TestMethod]
        public static void GetUnderlyingType_NullType_ThrowsArgumentNullException()
        {
            // TODO replace with Assert.Throws<ArgumentNullException>("nullableType", () => Nullable.GetUnderlyingType(null)); when available
            Assert.ThrowsException(
                typeof(ArgumentNullException),
                () => Nullable.GetUnderlyingType(null)
            );
        }

        // TODO: Uncomment when available
        //[TestMethod]
        //public static void GetValueRefOrDefaultRef_WithValue()
        //{
        //    static void Test<T>(T before, T after)
        //        where T : struct
        //    {
        //        T? nullable = before;
        //        ref readonly T reference = ref Nullable.GetValueRefOrDefaultRef(in nullable);

        //        Assert.AreEqual(before, nullable!.Value);

        //        Unsafe.AsRef<T>(in reference) = after;

        //        Assert.Equal(after, nullable.Value);
        //    }

        //    Test((byte)0, (byte)42);
        //    Test(0, 42);
        //    Test(1.3f, 3.14f);
        //    Test(0.555, 8.49);
        //    Test(Guid.NewGuid(), Guid.NewGuid());
        //}

        // TODO: Uncomment when available
        //[TestMethod]
        //public static void GetValueRefOrDefaultRef_WithDefault()
        //{
        //    static void Test<T>()
        //        where T : struct
        //    {
        //        T? nullable = null;
        //        ref readonly T reference = ref Nullable.GetValueRefOrDefaultRef(in nullable);

        //        Assert.Equal(nullable!.GetValueOrDefault(), reference);
        //    }

        //    Test<byte>();
        //    Test<int>();
        //    Test<float>();
        //    Test<double>();
        //    Test<Guid>();
        //}

        // TODO: Uncomment when available
        //[TestMethod]
        //public static void GetValueRefOrDefaultRef_UnsafeWriteToNullMaintainsExpectedBehavior()
        //{
        //    static void Test<T>(T after)
        //       where T : struct
        //    {
        //        T? nullable = null;
        //        ref readonly T reference = ref Nullable.GetValueRefOrDefaultRef(in nullable);

        //        Unsafe.AsRef<T>(in reference) = after;

        //        Assert.Equal(after, nullable.GetValueOrDefault()); // GetValueOrDefault() unconditionally returns the field
        //        Assert.False(nullable.HasValue);
        //        Assert.Equal(0, nullable.GetHashCode()); // GetHashCode() returns 0 if HasValue is false, without reading the field
        //        Assert.Throws<InvalidOperationException>(() => nullable.Value); // Accessing the value should still throw despite the write
        //        Assert.Throws<InvalidOperationException>(() => (T)nullable);
        //    }

        //    Test((byte)42);
        //    Test(42);
        //    Test(3.14f);
        //    Test(8.49);
        //    Test(Guid.NewGuid());
        //}

        [TestMethod]
        public static void Compare_Equals()
        {
            // Case 1: (null, null, 0)
            int? n1 = null;
            int? n2 = null;
            int expected = 0;
            Assert.AreEqual(expected == 0, Nullable.Equals(n1, n2));
            Assert.AreEqual(expected == 0, n1.Equals(n2));
            // TODO Assert.AreEqual(expected, Nullable.Compare(n1, n2));

            // Case 2: (7, null, 1)
            n1 = 7;
            n2 = null;
            expected = 1;
            Assert.AreEqual(expected == 0, Nullable.Equals(n1, n2));
            Assert.AreEqual(expected == 0, n1.Equals(n2));
            // TODO Assert.AreEqual(expected, Nullable.Compare(n1, n2));

            // Case 3: (null, 7, -1)
            n1 = null;
            n2 = 7;
            expected = -1;
            Assert.AreEqual(expected == 0, Nullable.Equals(n1, n2));
            Assert.AreEqual(expected == 0, n1.Equals(n2));
            // TODO Assert.AreEqual(expected, Nullable.Compare(n1, n2));

            // Case 4: (7, 7, 0)
            n1 = 7;
            n2 = 7;
            expected = 0;
            Assert.AreEqual(expected == 0, Nullable.Equals(n1, n2));
            Assert.AreEqual(expected == 0, n1.Equals(n2));
            // TODO Assert.AreEqual(expected, Nullable.Compare(n1, n2));

            // Case 5: (7, 5, 1)
            n1 = 7;
            n2 = 5;
            expected = 1;
            Assert.AreEqual(expected == 0, Nullable.Equals(n1, n2));
            Assert.AreEqual(expected == 0, n1.Equals(n2));
            // TODO Assert.AreEqual(expected, Nullable.Compare(n1, n2));

            // Case 6: (5, 7, -1)
            n1 = 5;
            n2 = 7;
            expected = -1;
            Assert.AreEqual(expected == 0, Nullable.Equals(n1, n2));
            Assert.AreEqual(expected == 0, n1.Equals(n2));
            // TODO Assert.AreEqual(expected, Nullable.Compare(n1, n2));
        }

        //[TestMethod]
        //public static void MutatingMethods_MutationsAffectOriginal()
        //{
        //    MutatingStruct? ms = new MutatingStruct() { Value = 1 };

        //    for (int i = 1; i <= 2; i++)
        //    {
        //        Assert.AreEqual(i.ToString(), ms.Value.ToString());
        //        Assert.AreEqual(i, ms.Value.Value);

        //        Assert.AreEqual(i.ToString(), ms.ToString());
        //        Assert.AreEqual(i + 1, ms.Value.Value);
        //    }

        //    for (int i = 3; i <= 4; i++)
        //    {
        //        Assert.AreEqual(i, ms.Value.GetHashCode());
        //        Assert.AreEqual(i, ms.Value.Value);

        //        Assert.AreEqual(i, ms.GetHashCode());
        //        Assert.AreEqual(i + 1, ms.Value.Value);
        //    }

        //    for (int i = 5; i <= 6; i++)
        //    {
        //        ms.Value.Equals(new object());
        //        Assert.AreEqual(i, ms.Value.Value);

        //        ms.Equals(new object());
        //        Assert.AreEqual(i + 1, ms.Value.Value);
        //    }
        //}

        //private struct MutatingStruct
        //{
        //    public int Value;
        //    public override string ToString() => Value++.ToString();
        //    public override bool Equals(object obj) => Value++.Equals(null);
        //    public override int GetHashCode() => Value++.GetHashCode();
        //}

        public class G<T> { }
    }
}
