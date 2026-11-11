// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestGenericInvokeTests
    {
        [TestMethod]
        public void ClosedOwner_ReferenceT_RightWrongAndNull()
        {
            MethodInfo mi = typeof(RefParameterTarget<string>).GetMethod("Take");
            RefParameterTarget<string> target = new RefParameterTarget<string>();

            Assert.AreEqual(1, (int)mi.Invoke(target, new object[] { "x" }));
            Assert.AreEqual(1, (int)mi.Invoke(target, new object[] { null }));

            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(target, new object[] { 5 }); });
            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(target, new object[] { new RefParameterTarget<string>() }); });
        }

        [TestMethod]
        public void ClosedOwner_ValueT_IsUnboxed()
        {
            MethodInfo mi = typeof(ValueParameterTarget<int>).GetMethod("Echo");
            ValueParameterTarget<int> target = new ValueParameterTarget<int>();

            Assert.AreEqual(7, (int)mi.Invoke(target, new object[] { 7 }));

            Assert.ThrowsException(typeof(Exception), () => { mi.Invoke(target, new object[] { "x" }); });
            Assert.ThrowsException(typeof(Exception), () => { mi.Invoke(target, new object[] { 7L }); });
        }

        [TestMethod]
        public void ClosedOwner_StructT_IsUnboxed()
        {
            MethodInfo mi = typeof(StructParameterTarget<SamplePoint>).GetMethod("Echo");
            SamplePoint point = new SamplePoint { X = 3 };

            SamplePoint result = (SamplePoint)mi.Invoke(new StructParameterTarget<SamplePoint>(), new object[] { point });

            Assert.AreEqual(3, result.X);
            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(new StructParameterTarget<SamplePoint>(), new object[] { 3 }); });
        }

        [TestMethod]
        public void ClosedOwner_ArrayOfT_ChecksElementType()
        {
            MethodInfo mi = typeof(ArrayParameterTarget<int>).GetMethod("Take");
            ArrayParameterTarget<int> target = new ArrayParameterTarget<int>();

            Assert.AreEqual(1, (int)mi.Invoke(target, new object[] { new int[1] }));
            Assert.AreEqual(1, (int)mi.Invoke(target, new object[] { null }));

            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(target, new object[] { new string[1] }); });
            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(target, new object[] { 5 }); });
        }

        [TestMethod]
        public void ClosedOwner_GenericOfT_ChecksArguments()
        {
            MethodInfo mi = typeof(GenericParameterTarget<int>).GetMethod("Take");
            GenericParameterTarget<int> target = new GenericParameterTarget<int>();

            Assert.AreEqual(1, (int)mi.Invoke(target, new object[] { new Box<int>() }));
            Assert.AreEqual(1, (int)mi.Invoke(target, new object[] { null }));

            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(target, new object[] { new Box<string>() }); });
            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(target, new object[] { "x" }); });
        }

        [TestMethod]
        public void ClosedOwner_NestedGenericOfT_ChecksArguments()
        {
            MethodInfo mi = typeof(NestedGenericParameterTarget<int>).GetMethod("Take");
            NestedGenericParameterTarget<int> target = new NestedGenericParameterTarget<int>();

            Assert.AreEqual(1, (int)mi.Invoke(target, new object[] { new Box<Box<int>>() }));

            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(target, new object[] { new Box<Box<string>>() }); });
            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(target, new object[] { new Box<int>() }); });
        }

        [TestMethod]
        public void ClosedOwner_StaticMethod_ResolvesT()
        {
            MethodInfo mi = typeof(StaticMethodTarget<int>).GetMethod("Echo");

            Assert.AreEqual(5, (int)mi.Invoke(null, new object[] { 5 }));
            Assert.ThrowsException(typeof(Exception), () => { mi.Invoke(null, new object[] { "x" }); });
        }

        [TestMethod]
        public void ClosedOwner_Constructor_ResolvesT()
        {
            ConstructorInfo ci = typeof(ConstructorTarget<string>).GetConstructors()[0];

            ConstructorTarget<string> created = (ConstructorTarget<string>)ci.Invoke(new object[] { "x" });

            Assert.AreEqual("x", created.Value);
            Assert.IsFalse((object)created is ConstructorTarget<int>);
            Assert.ThrowsException(typeof(InvalidCastException), () => { ci.Invoke(new object[] { 5 }); });
        }

        [TestMethod]
        public void ClosedOwner_ValueConstructor_ResolvesT()
        {
            ConstructorInfo ci = typeof(ValueConstructorTarget<int>).GetConstructors()[0];

            ValueConstructorTarget<int> created = (ValueConstructorTarget<int>)ci.Invoke(new object[] { 9 });

            Assert.AreEqual(9, created.Value);
            Assert.ThrowsException(typeof(Exception), () => { ci.Invoke(new object[] { "x" }); });
        }

        [TestMethod]
        public void MethodTypeParameter_StaysNotSupported()
        {
            MethodInfo mi = typeof(MethodTypeParameterTarget).GetMethod("Take");

            Assert.ThrowsException(typeof(NotSupportedException), () => { mi.Invoke(null, new object[] { 5 }); });
            Assert.ThrowsException(typeof(NotSupportedException), () => { mi.Invoke(null, new object[] { null }); });
        }

        [TestMethod]
        public void OpenDefinition_StaysNotSupported()
        {
            MethodInfo mi = typeof(OpenDefinitionTarget<>).GetMethod("Take");

            Assert.ThrowsException(typeof(NotSupportedException), () => { mi.Invoke(null, new object[] { 5 }); });
        }

        [TestMethod]
        public void InheritedFromClosedBase_Method_ResolvesT()
        {
            MethodInfo take = typeof(MethodsDerived).GetMethod("Take");
            MethodInfo echo = typeof(MethodsDerived).GetMethod("Echo");
            MethodsDerived target = new MethodsDerived();

            Assert.AreEqual(1, (int)take.Invoke(target, new object[] { 5 }));
            Assert.AreEqual(5, (int)echo.Invoke(target, new object[] { 5 }));
            Assert.IsTrue(echo.ReturnType == typeof(int));
            Assert.IsTrue(take.GetParameters()[0].ParameterType == typeof(int));

            Assert.ThrowsException(typeof(Exception), () => { take.Invoke(target, new object[] { "x" }); });
        }

        [TestMethod]
        public void InheritedFromClosedBase_ReferenceT_AcceptsNull()
        {
            MethodInfo take = typeof(NullDerived).GetMethod("Take");
            NullDerived target = new NullDerived();

            Assert.AreEqual(1, (int)take.Invoke(target, new object[] { "x" }));
            Assert.AreEqual(1, (int)take.Invoke(target, new object[] { null }));

            Assert.ThrowsException(typeof(InvalidCastException), () => { take.Invoke(target, new object[] { 5 }); });
        }

        [TestMethod]
        public void InheritedFromClosedBase_Field_ResolvesT()
        {
            FieldInfo field = typeof(FieldDerived).GetField("Value");
            FieldDerived target = new FieldDerived();

            Assert.IsTrue(field.FieldType == typeof(int));

            field.SetValue(target, 4);
            Assert.AreEqual(4, target.Value);

            Assert.ThrowsException(typeof(Exception), () => { field.SetValue(target, "x"); });
        }

        [TestMethod]
        public void InheritedFromClosedBase_ArrayAndGenericOfT()
        {
            ShapesDerived target = new ShapesDerived();
            MethodInfo array = typeof(ShapesDerived).GetMethod("TakeArray");
            MethodInfo box = typeof(ShapesDerived).GetMethod("TakeBox");

            Assert.AreEqual(1, (int)array.Invoke(target, new object[] { new int[1] }));
            Assert.ThrowsException(typeof(InvalidCastException), () => { array.Invoke(target, new object[] { new string[1] }); });

            Assert.AreEqual(1, (int)box.Invoke(target, new object[] { new Box<int>() }));
            Assert.ThrowsException(typeof(InvalidCastException), () => { box.Invoke(target, new object[] { new Box<string>() }); });
        }

        [TestMethod]
        public void InheritedFromGenericBase_OpenChild_ResolvesT()
        {
            MethodInfo take = typeof(OpenChild<string>).GetMethod("Take");
            OpenChild<string> target = new OpenChild<string>();

            Assert.AreEqual(1, (int)take.Invoke(target, new object[] { "x" }));
            Assert.ThrowsException(typeof(InvalidCastException), () => { take.Invoke(target, new object[] { 5 }); });
        }

        [TestMethod]
        public void InheritedFromGenericBase_TwoLevels_ResolvesT()
        {
            MethodInfo echo = typeof(DeepChild<int>).GetMethod("Echo");
            DeepChild<int> target = new DeepChild<int>();

            Assert.AreEqual(8, (int)echo.Invoke(target, new object[] { 8 }));
            Assert.ThrowsException(typeof(Exception), () => { echo.Invoke(target, new object[] { "x" }); });
        }

        public class RefParameterTarget<T>
        {
            public int Take(T value) => 1;
        }

        public class ValueParameterTarget<T>
        {
            public T Echo(T value) => value;
        }

        public struct SamplePoint
        {
            public int X;
        }

        public class StructParameterTarget<T>
        {
            public T Echo(T value) => value;
        }

        public class ArrayParameterTarget<T>
        {
            public int Take(T[] value) => 1;
        }

        public class Box<T>
        {
        }

        public class GenericParameterTarget<T>
        {
            public int Take(Box<T> value) => 1;
        }

        public class NestedGenericParameterTarget<T>
        {
            public int Take(Box<Box<T>> value) => 1;
        }

        public class StaticMethodTarget<T>
        {
            public static T Echo(T value) => value;
        }

        public class ConstructorTarget<T>
        {
            public T Value;

            public ConstructorTarget(T value)
            {
                Value = value;
            }
        }

        public class ValueConstructorTarget<T>
        {
            public T Value;

            public ValueConstructorTarget(T value)
            {
                Value = value;
            }
        }

        public class MethodTypeParameterTarget
        {
            public static int Take<T>(T value) => 1;
        }

        public class OpenDefinitionTarget<T>
        {
            public static int Take(T value) => 1;
        }

        public class MethodsBase<T>
        {
            public int Take(T value) => 1;

            public T Echo(T value) => value;
        }

        public class MethodsDerived : MethodsBase<int>
        {
        }

        public class NullBase<T>
        {
            public int Take(T value) => 1;
        }

        public class NullDerived : NullBase<string>
        {
        }

        public class FieldBase<T>
        {
            public T Value;
        }

        public class FieldDerived : FieldBase<int>
        {
        }

        public class ShapesBase<T>
        {
            public int TakeArray(T[] value) => 1;

            public int TakeBox(Box<T> value) => 1;
        }

        public class ShapesDerived : ShapesBase<int>
        {
        }

        public class OpenBase<T>
        {
            public int Take(T value) => 1;
        }

        public class OpenChild<U> : OpenBase<U>
        {
        }

        public class DeepBase<T>
        {
            public T Echo(T value) => value;
        }

        public class DeepMiddle<U> : DeepBase<U>
        {
        }

        public class DeepChild<V> : DeepMiddle<V>
        {
        }
    }
}
