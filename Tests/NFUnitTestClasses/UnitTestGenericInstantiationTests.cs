// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestClasses
{
    // A method of one instantiation of a generic type using a different instantiation of the same type must bind
    // to the instantiation it names, not to the one it's running in.
    [TestClass]
    class UnitTestGenericInstantiationTests
    {
        [TestMethod]
        public void NonGenericCaller_String_ValueStartsNull()
        {
            InstantiationHolder<string> made = InstantiationFactory.MakeString();

            Assert.IsNull(made.Value);
        }

        [TestMethod]
        public void NonGenericCaller_String_ValueRoundTrips()
        {
            InstantiationHolder<string> made = InstantiationFactory.MakeString();

            made.Value = "x";

            Assert.AreEqual("x", made.Value);
        }

        [TestMethod]
        public void NonGenericCaller_String_ConstructorArray()
        {
            InstantiationHolder<string> made = InstantiationFactory.MakeString();

            Assert.IsTrue(made.CtorArray is string[]);
        }

        [TestMethod]
        public void NonGenericCaller_String_MethodArray()
        {
            InstantiationHolder<string> made = InstantiationFactory.MakeString();

            Assert.IsTrue(made.MethodArray() is string[]);
        }

        [TestMethod]
        public void OtherInstantiation_String_ValueStartsNull()
        {
            InstantiationHolder<string> made = new InstantiationHolder<int>().MakeString();

            Assert.IsNull(made.Value);
        }

        [TestMethod]
        public void OtherInstantiation_String_ValueRoundTrips()
        {
            InstantiationHolder<string> made = new InstantiationHolder<int>().MakeString();

            made.Value = "x";

            Assert.AreEqual("x", made.Value);
        }

        [TestMethod]
        public void OtherInstantiation_String_ConstructorArray()
        {
            InstantiationHolder<string> made = new InstantiationHolder<int>().MakeString();

            Assert.IsTrue(made.CtorArray is string[]);
        }

        [TestMethod]
        public void OtherInstantiation_String_MethodArray()
        {
            InstantiationHolder<string> made = new InstantiationHolder<int>().MakeString();

            Assert.IsTrue(made.MethodArray() is string[]);
        }

        [TestMethod]
        public void OtherInstantiation_Int_ValueStartsZero()
        {
            InstantiationHolder<int> made = new InstantiationHolder<string>().MakeInt();

            Assert.AreEqual(0, made.Value);
        }

        [TestMethod]
        public void OtherInstantiation_Int_ValueRoundTrips()
        {
            InstantiationHolder<int> made = new InstantiationHolder<string>().MakeInt();

            made.Value = 42;

            Assert.AreEqual(42, made.Value);
        }

        [TestMethod]
        public void OtherInstantiation_Int_ConstructorArray()
        {
            InstantiationHolder<int> made = new InstantiationHolder<string>().MakeInt();

            Assert.IsTrue(made.CtorArray is int[]);
        }

        [TestMethod]
        public void OtherInstantiation_StaticMethod()
        {
            Assert.IsTrue(new InstantiationHolder<int>().StringStaticArray() is string[]);
        }

        [TestMethod]
        public void OtherInstantiation_StaticField_IsNotShared()
        {
            InstantiationHolder<int> caller = new InstantiationHolder<int>();

            caller.SetSharedString("x");

            Assert.AreEqual("x", caller.GetSharedString());
            Assert.AreEqual("x", InstantiationHolder<string>.Shared);
            Assert.AreEqual(0, InstantiationHolder<int>.Shared);
        }

        [TestMethod]
        public void OtherInstantiation_StaticConstructor_ViaField()
        {
            Assert.IsTrue(new InstantiationHolder<int>().StringCctorArrayField() is string[]);
            Assert.IsTrue(InstantiationHolder<int>.StaticCtorArray is int[]);
        }

        [TestMethod]
        public void OtherInstantiation_StaticConstructor_ViaMethod()
        {
            Assert.IsTrue(new InstantiationHolder<int>().StringCctorArrayMethod() is string[]);
        }

        [TestMethod]
        public void SameInstantiation_Int_ConstructorArray()
        {
            Assert.IsTrue(new InstantiationHolder<int>().SameInstantiationArray() is int[]);
        }

        [TestMethod]
        public void SameInstantiation_String_ConstructorArray()
        {
            Assert.IsTrue(new InstantiationHolder<string>().SameInstantiationArray() is string[]);
        }

        [TestMethod]
        public void NonGenericType_InsideGenericMethod_CanBeLocked()
        {
            InstantiationPlainType made = new InstantiationHolder<int>().MakePlain();

            lock (made)
            {
                Assert.IsNotNull(made);
            }
        }

        [TestMethod]
        public void NonGenericType_InsideGenericMethod_HasItsOwnType()
        {
            InstantiationPlainType made = new InstantiationHolder<int>().MakePlain();

            Assert.IsTrue(made.GetType() == typeof(InstantiationPlainType));
        }
    }

    class InstantiationPlainType
    {
    }

    class InstantiationHolder<T>
    {
        public static T Shared;
        public static object StaticCtorArray = new T[1];

        public T Value;
        public object CtorArray;

        public InstantiationHolder()
        {
            CtorArray = new T[1];
        }

        public object MethodArray()
        {
            return new T[1];
        }

        public static object GetStaticCtorArray()
        {
            return StaticCtorArray;
        }

        public static object StaticArray()
        {
            return new T[1];
        }

        public InstantiationHolder<string> MakeString()
        {
            return new InstantiationHolder<string>();
        }

        public InstantiationHolder<int> MakeInt()
        {
            return new InstantiationHolder<int>();
        }

        public InstantiationPlainType MakePlain()
        {
            return new InstantiationPlainType();
        }

        public object StringStaticArray()
        {
            return InstantiationHolder<string>.StaticArray();
        }

        public void SetSharedString(string value)
        {
            InstantiationHolder<string>.Shared = value;
        }

        public string GetSharedString()
        {
            return InstantiationHolder<string>.Shared;
        }

        public object StringCctorArrayField()
        {
            return InstantiationHolder<string>.StaticCtorArray;
        }

        public object StringCctorArrayMethod()
        {
            return InstantiationHolder<string>.GetStaticCtorArray();
        }

        public object SameInstantiationArray()
        {
            return new InstantiationHolder<T>().CtorArray;
        }
    }

    static class InstantiationFactory
    {
        public static InstantiationHolder<string> MakeString()
        {
            return new InstantiationHolder<string>();
        }
    }
}
