// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestGenericErasedArrayTests
    {
        // T[] where T is an array of a generic instance
        [TestMethod]
        public void FieldType_OfTArray_WithArrayOfGenericInstance()
        {
            FieldInfo field = typeof(P1aHolder<P1aBox<int>[]>).GetField("Field");

            Assert.IsTrue(field.FieldType == typeof(P1aBox<int>[][]));
            Assert.IsFalse(field.FieldType == typeof(P1aBox<string>[][]));
        }

        [TestMethod]
        public void ParameterType_OfTArray_WithArrayOfGenericInstance()
        {
            MethodInfo method = typeof(P1bHolder<P1bBox<int>[]>).GetMethod("Take");
            Type parameter = method.GetParameters()[0].ParameterType;

            Assert.IsTrue(parameter == typeof(P1bBox<int>[][]));
            Assert.IsFalse(parameter == typeof(P1bBox<string>[][]));
        }

        [TestMethod]
        public void NewTArray_WithArrayOfGenericInstance_GetType()
        {
            object value = new P1cHolder<P1cBox<int>[]>().Make(1);

            Assert.IsTrue(value.GetType() == typeof(P1cBox<int>[][]));
        }

        [TestMethod]
        public void NewTArray_WithArrayOfGenericInstance_IsNotOtherInstantiation()
        {
            object value = new P1cHolder<P1cBox<int>[]>().Make(1);

            Assert.IsFalse(value is P1cBox<string>[][]);
            Assert.IsFalse(value is System.Collections.Generic.IEnumerable<P1cBox<string>[]>);
        }

        [TestMethod]
        public void NewTArray_WithArrayOfGenericInstance_IsSameInstantiation()
        {
            object value = new P1cHolder<P1cBox<int>[]>().Make(1);

            Assert.IsTrue(value is P1cBox<int>[][]);
            Assert.IsTrue(value is System.Collections.Generic.IEnumerable<P1cBox<int>[]>);
        }

        [TestMethod]
        public void NewTArray_WithArrayOfGenericInstance_RejectsOtherInstantiationOnStore()
        {
            object[] value = new P1dHolder<P1dBox<int>[]>().Make(1);

            Assert.ThrowsException(typeof(Exception), () => { value[0] = new P1dBox<string>[1]; });
        }

        [TestMethod]
        public void NewTArray_WithArrayOfGenericInstance_AcceptsSameInstantiationOnStore()
        {
            object[] value = new P1dHolder<P1dBox<int>[]>().Make(1);

            value[0] = new P1dBox<int>[1];
            Assert.IsNotNull(value[0]);
        }

        [TestMethod]
        public void NewTArray_WithPrimitiveArray()
        {
            object value = new P1eHolder<int[]>().Make(1);

            Assert.IsTrue(value.GetType() == typeof(int[][]));
            Assert.IsTrue(value is int[][]);
            Assert.IsFalse(value is string[][]);
        }

        [TestMethod]
        public void NewTArray_WithJaggedPrimitiveArray()
        {
            object value = new P1eHolder<string[][]>().Make(1);

            Assert.IsTrue(value.GetType() == typeof(string[][][]));
        }

        [TestMethod]
        public void TypeOfTArray_WithArrayOfGenericInstance()
        {
            Assert.IsTrue(new P1eHolder<P1gBox<int>[]>().TypeOfArray() == typeof(P1gBox<int>[][]));
            Assert.IsTrue(new P1eHolder<int>().TypeOfArray() == typeof(int[]));
        }

        [TestMethod]
        public void TypeOfTJagged()
        {
            Assert.IsTrue(new P1eHolder<int>().TypeOfJagged() == typeof(int[][]));
            Assert.IsTrue(new P1eHolder<P1gBox<int>>().TypeOfJagged() == typeof(P1gBox<int>[][]));
        }

        // new T[][]
        [TestMethod]
        public void NewTJagged_InGenericMethod()
        {
            object value = P2aFactory.Make<P2aBox<int>>();

            Assert.IsTrue(value.GetType() == typeof(P2aBox<int>[][]));
            Assert.IsFalse(value is P2aBox<string>[][]);
            Assert.IsTrue(value is P2aBox<int>[][]);
        }

        [TestMethod]
        public void NewTJagged_InGenericClass()
        {
            object value = new P2bHolder<P2bBox<int>>().Make();

            Assert.IsTrue(value.GetType() == typeof(P2bBox<int>[][]));
            Assert.IsFalse(value is P2bBox<string>[][]);
            Assert.IsFalse(value is System.Collections.Generic.IEnumerable<P2bBox<string>[]>);
        }

        [TestMethod]
        public void NewTJagged_PrimitiveArgument()
        {
            object value = new P2cHolder<int>().Make();

            Assert.IsTrue(value.GetType() == typeof(int[][]));
            Assert.IsTrue(value is int[][]);
            Assert.IsFalse(value is string[][]);
        }

        // new T[1] and closed rows in generic code
        [TestMethod]
        public void NewTArray_GenericClass_ArgumentGenericInstance()
        {
            object value = new P3aHolder<P3aBox<int>>().Make();

            Assert.IsTrue(value.GetType() == typeof(P3aBox<int>[]));
            Assert.IsFalse(value is P3aBox<string>[]);
        }

        [TestMethod]
        public void NewTArray_GenericMethod_ArgumentGenericInstance()
        {
            object value = P3bFactory.Make<P3bBox<int>>();

            Assert.IsTrue(value.GetType() == typeof(P3bBox<int>[]));
            Assert.IsFalse(value is P3bBox<string>[]);
        }

        [TestMethod]
        public void NewTArray_GenericMethodCalledFromGenericClass()
        {
            object value = new P3cHolder<P3cBox<int>>().Make();

            Assert.IsTrue(value.GetType() == typeof(P3cBox<int>[]));
            Assert.IsFalse(value is P3cBox<string>[]);
        }

        [TestMethod]
        public void NewGenericOfTArray_InGenericClass()
        {
            object value = new P3dHolder<int>().Make();

            Assert.IsTrue(value.GetType() == typeof(P3dBox<int>[]));
            Assert.IsFalse(value is P3dBox<string>[]);
        }

        [TestMethod]
        public void NewGenericArray_ClosedRowInGenericClass()
        {
            object value = new P3fHolder<int>().MakeClosed();

            Assert.IsTrue(value.GetType() == typeof(P3fBox<string>[]));
            Assert.IsFalse(value is P3fBox<int>[]);
        }

        // value-type elements of generic arrays
        [TestMethod]
        public void StructElement_GetValue_KeepsTheInstance()
        {
            Array array = new P4aStruct<int>[2];
            object element = array.GetValue(0);

            Assert.IsTrue(element.GetType() == typeof(P4aStruct<int>));
            Assert.IsFalse(element.GetType() == typeof(P4aStruct<string>));
        }

        [TestMethod]
        public void StructElement_Enumerator_KeepsTheInstance()
        {
            System.Collections.Generic.IEnumerable<P4bStruct<int>> source = new P4bStruct<int>[1];
            System.Collections.Generic.IEnumerator<P4bStruct<int>> enumerator = source.GetEnumerator();

            enumerator.MoveNext();

            object current = enumerator.Current;
            Assert.IsTrue(current.GetType() == typeof(P4bStruct<int>));
            Assert.IsTrue(current is P4bMarker<int>);
            Assert.IsFalse(current is P4bMarker<string>);
        }

        [TestMethod]
        public void StructElement_Interface_ComparesTheArguments()
        {
            Array array = new P4cStruct<int>[1];
            object element = array.GetValue(0);

            Assert.IsTrue(element is P4cMarker<int>);
            Assert.IsFalse(element is P4cMarker<string>);
        }

        [TestMethod]
        public void StructElement_Pair_KeepsBothArguments()
        {
            Array array = new P4dPair<int, string>[1];
            object element = array.GetValue(0);

            Assert.IsTrue(element.GetType() == typeof(P4dPair<int, string>));
            Assert.IsFalse(element.GetType() == typeof(P4dPair<string, int>));
        }

        [TestMethod]
        public void StructElement_JaggedInnerElement()
        {
            P4eStruct<int>[][] array = new P4eStruct<int>[1][];
            array[0] = new P4eStruct<int>[1];

            object element = array[0].GetValue(0);
            Assert.IsTrue(element.GetType() == typeof(P4eStruct<int>));
        }

        [TestMethod]
        public void StructElement_DirectCall()
        {
            P4cStruct<int>[] a = new P4cStruct<int>[1];
            Assert.AreEqual("System.Int32", a[0].Describe());
        }

        // SZArrayHelper over arrays of arrays and generic instances
        [TestMethod]
        public void Enumerator_OfPrimitiveAndStringArrays()
        {
            object ofString = ((System.Collections.Generic.IEnumerable<string>)new string[1]).GetEnumerator();
            object ofInt = ((System.Collections.Generic.IEnumerable<int>)new int[1]).GetEnumerator();

            Assert.IsTrue(ofString is System.Collections.Generic.IEnumerator<string>);
            Assert.IsTrue(ofInt is System.Collections.Generic.IEnumerator<int>);
            Assert.IsFalse(ofInt is System.Collections.Generic.IEnumerator<string>);
        }

        [TestMethod]
        public void Enumerator_OfJaggedGenericInstanceArray_Iterates()
        {
            P5dBox<int>[][] source = new P5dBox<int>[2][];
            source[0] = new P5dBox<int>[1];
            source[1] = new P5dBox<int>[2];

            int total = 0;
            foreach (P5dBox<int>[] row in (System.Collections.Generic.IEnumerable<P5dBox<int>[]>)source)
            {
                total += row.Length;
            }

            Assert.AreEqual(3, total);
        }

        [TestMethod]
        public void CopyToAndContains_OverJaggedGenericInstanceArray()
        {
            P5eBox<int>[][] source = new P5eBox<int>[2][];
            P5eBox<int>[][] destination = new P5eBox<int>[2][];
            source[0] = new P5eBox<int>[1];

            ((System.Collections.Generic.ICollection<P5eBox<int>[]>)source).CopyTo(destination, 0);

            Assert.IsTrue(destination[0] == source[0]);
            Assert.IsTrue(((System.Collections.Generic.ICollection<P5eBox<int>[]>)source).Contains(source[0]));
        }

    }

    public class P1aBox<T> { }
    public class P1aHolder<T> { public T[] Field; }
    public class P1bBox<T> { }
    public class P1bHolder<T> { public void Take(T[] items) { } }
    public class P1cBox<T> { }
    public class P1cHolder<T> { public T[] Make(int n) { return new T[n]; } }
    public class P1eHolder<T> { public T[] Make(int n) { return new T[n]; } public Type TypeOfArray() { return typeof(T[]); } public Type TypeOfJagged() { return typeof(T[][]); } }
    public class P1gBox<T> { }
    public class P1dBox<T> { }
    public class P1dHolder<T> { public T[] Make(int n) { return new T[n]; } }

    public class P2aBox<T> { }
    public static class P2aFactory { public static object Make<T>() { return new T[1][]; } }
    public class P2bBox<T> { }
    public class P2bHolder<T> { public object Make() { return new T[1][]; } }
    public class P2cHolder<T> { public object Make() { return new T[1][]; } }

    public class P3aBox<T> { }
    public class P3aHolder<T> { public object Make() { return new T[1]; } }
    public class P3bBox<T> { }
    public static class P3bFactory { public static object Make<T>() { return new T[1]; } }
    public class P3cBox<T> { }
    public static class P3cFactory { public static object Make<T>() { return new T[1]; } }
    public class P3cHolder<T> { public object Make() { return P3cFactory.Make<T>(); } }
    public class P3dBox<T> { }
    public class P3dHolder<T> { public object Make() { return new P3dBox<T>[1]; } }
    public class P3eBox<T> { }
    public class P3fBox<T> { }
    public class P3fHolder<T> { public object MakeClosed() { return new P3fBox<string>[1]; } }

    public struct P4aStruct<T> { public override string ToString() { return typeof(T).ToString(); } }
    public interface P4bMarker<T> { }
    public struct P4bStruct<T> : P4bMarker<T> { public override string ToString() { return typeof(T).ToString(); } }
    public interface P4cMarker<T> { }
    public interface P4cInterface { string Describe(); }
    public struct P4cStruct<T> : P4cInterface, P4cMarker<T> { public string Describe() { return typeof(T).ToString(); } }
    public struct P4dPair<A, B> { public override string ToString() { return typeof(A) + "," + typeof(B); } }
    public struct P4eStruct<T> { public override string ToString() { return typeof(T).ToString(); } }

    public class P5dBox<T> { }
    public class P5eBox<T> { }
}
