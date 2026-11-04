// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestReflectionInvokeTests
    {
        private static MethodInfo Target(string name)
        {
            return typeof(InvokeTargets).GetMethod(name);
        }

        private static void AssertInvokeRejected(string method, object arg)
        {
            MethodInfo mi = Target(method);

            Assert.ThrowsException(typeof(InvalidCastException), () => { mi.Invoke(null, new object[] { arg }); });
        }

        private static void AssertInvokeAccepted(string method, object arg)
        {
            Assert.AreEqual(1, (int)Target(method).Invoke(null, new object[] { arg }));
        }

        [TestMethod]
        public void Invoke_ReferenceParameter_RejectsIncompatibleArguments()
        {
            AssertInvokeRejected("TakesFoo", "not a Foo");
            AssertInvokeRejected("TakesFoo", new int[1]);
            AssertInvokeRejected("TakesFoo", new object());
            AssertInvokeRejected("TakesString", new Foo());
        }

        [TestMethod]
        public void Invoke_ArrayParameter_RejectsIncompatibleArguments()
        {
            AssertInvokeRejected("TakesFooArray", new int[1]);
            AssertInvokeRejected("TakesFooArray", new string[1]);
            AssertInvokeRejected("TakesFooArray", new Foo());
            AssertInvokeRejected("TakesFooArray", new Foo[1][]);
            AssertInvokeRejected("TakesIntJagged", new int[1]);
            AssertInvokeRejected("TakesObjectArray", new int[1]);
        }

        [TestMethod]
        public void Invoke_ArrayParameter_RejectsTypeObjectRepresentingArray()
        {
            AssertInvokeRejected("TakesFooArray", typeof(Foo[]));
        }

        [TestMethod]
        public void Invoke_ReferenceParameters_AcceptCompatibleArguments()
        {
            AssertInvokeAccepted("TakesFoo", new Foo());
            AssertInvokeAccepted("TakesFoo", new FooChild());
            AssertInvokeAccepted("TakesIBase", new OnlyDerived());
            AssertInvokeAccepted("TakesObject", 5);
            AssertInvokeAccepted("TakesObject", new int[1]);
            AssertInvokeAccepted("TakesType", typeof(Foo));
            AssertInvokeAccepted("TakesType", typeof(Foo[]));
        }

        [TestMethod]
        public void Invoke_ArrayParameters_AcceptCompatibleArguments()
        {
            AssertInvokeAccepted("TakesFooArray", new Foo[1]);
            AssertInvokeAccepted("TakesFooArray", new FooChild[1]);
            AssertInvokeAccepted("TakesIBaseArray", new OnlyDerived[1]);
            AssertInvokeAccepted("TakesObjectArray", new string[1]);
            AssertInvokeAccepted("TakesObjectArray", new string[1][]);
            AssertInvokeAccepted("TakesArray", new int[1]);
            AssertInvokeAccepted("TakesIList", new int[1]);
            AssertInvokeAccepted("TakesICollection", new int[1]);
            AssertInvokeAccepted("TakesIEnumerable", new int[1]);
        }

        [TestMethod]
        public void Invoke_NullReferenceArguments_AreAccepted()
        {
            AssertInvokeAccepted("TakesFoo", null);
            AssertInvokeAccepted("TakesFooArray", null);
            AssertInvokeAccepted("TakesString", null);
        }

        [TestMethod]
        public void Invoke_EnumParameter_AcceptsBoxedEnumAndUnderlyingType()
        {
            AssertInvokeAccepted("TakesEnum", SampleEnum.One);
            AssertInvokeAccepted("TakesEnum", 1);
        }

        [TestMethod]
        public void Invoke_EnumArrays_AreInterchangeableWithUnderlyingType()
        {
            AssertInvokeAccepted("TakesEnumArray", new SampleEnum[1]);
            AssertInvokeAccepted("TakesEnumArray", new int[1]);
            AssertInvokeAccepted("TakesIntArray", new SampleEnum[1]);
            AssertInvokeAccepted("TakesEnumJagged", new int[1][]);
            AssertInvokeAccepted("TakesIntJagged", new SampleEnum[1][]);

            AssertInvokeRejected("TakesEnumArray", new string[1]);
            AssertInvokeRejected("TakesEnumArray", new long[1]);
        }

        [TestMethod]
        public void Invoke_RefParameters_AreAccepted()
        {
            AssertInvokeAccepted("TakesRefFoo", new Foo());
            AssertInvokeAccepted("TakesRefInt", 1);

            AssertInvokeRejected("TakesRefFoo", "not a Foo");
        }

        [TestMethod]
        public void Invoke_Receiver_IsChecked()
        {
            MethodInfo instance = typeof(Foo).GetMethod("Instance");
            MethodInfo onInterface = typeof(IBase).GetMethod("OnBase");

            Assert.ThrowsException(typeof(InvalidCastException), () => { instance.Invoke("not a Foo", new object[0]); });
            Assert.ThrowsException(typeof(InvalidCastException), () => { instance.Invoke(new int[1], new object[0]); });
            Assert.ThrowsException(typeof(InvalidCastException), () => { onInterface.Invoke(new Foo(), new object[0]); });

            Assert.AreEqual(1, (int)instance.Invoke(new Foo(), new object[0]));
            Assert.AreEqual(1, (int)instance.Invoke(new FooChild(), new object[0]));
            Assert.AreEqual(1, (int)onInterface.Invoke(new OnlyDerived(), new object[0]));
        }

        [TestMethod]
        public void ConstructorInvoke_ValidatesArguments()
        {
            ConstructorInfo withFoo = typeof(CtorTarget).GetConstructor(new Type[] { typeof(Foo) });
            ConstructorInfo withArray = typeof(CtorTarget).GetConstructor(new Type[] { typeof(Foo[]) });

            Assert.ThrowsException(typeof(InvalidCastException), () => { withFoo.Invoke(new object[] { "not a Foo" }); });
            Assert.ThrowsException(typeof(InvalidCastException), () => { withArray.Invoke(new object[] { new int[1] }); });

            Assert.IsNotNull(withFoo.Invoke(new object[] { new Foo() }));
            Assert.IsNotNull(withFoo.Invoke(new object[] { null }));
            Assert.IsNotNull(withArray.Invoke(new object[] { new FooChild[1] }));
        }

        [TestMethod]
        public void FieldSetValue_ArrayField_ChecksElementType()
        {
            FieldHolder holder = new FieldHolder();
            FieldInfo field = typeof(FieldHolder).GetField("Foos");

            AssertSetValueRejected(field, holder, new int[1]);
            AssertSetValueRejected(field, holder, new string[1]);
            Assert.IsNull(holder.Foos);

            FooChild[] compatible = new FooChild[1];
            field.SetValue(holder, compatible);
            Assert.IsTrue((object)holder.Foos == compatible);

            field.SetValue(holder, null);
            Assert.IsNull(holder.Foos);
        }

        [TestMethod]
        public void FieldSetValue_NonArrayField_StillChecksType()
        {
            FieldHolder holder = new FieldHolder();
            FieldInfo field = typeof(FieldHolder).GetField("Single");

            AssertSetValueRejected(field, holder, "not a Foo");
            AssertSetValueRejected(field, holder, new Foo[1]);

            field.SetValue(holder, new FooChild());
            Assert.IsNotNull(holder.Single);
        }

        private static void AssertSetValueRejected(FieldInfo field, object holder, object value)
        {
            bool rejected = false;

            try
            {
                field.SetValue(holder, value);
            }
            catch (Exception)
            {
                rejected = true;
            }

            Assert.IsTrue(rejected);
        }

        [TestMethod]
        public void IsInst_Arrays_MatchBaseTypesAndInterfaces()
        {
            object array = new int[1];

            Assert.IsTrue(array is object);
            Assert.IsTrue(array is Array);
            Assert.IsTrue(array is IList);
            Assert.IsTrue(array is ICollection);
            Assert.IsTrue(array is IEnumerable);

            Assert.IsFalse(array is string);
            Assert.IsFalse(array is Foo);
            Assert.IsFalse(array is object[]);
            Assert.IsFalse(array is int[][]);
            Assert.IsFalse(array is long[]);
        }

        [TestMethod]
        public void CastClass_Arrays_MatchIsInst()
        {
            object array = new int[1];

            Assert.IsNotNull((Array)array);
            Assert.IsNotNull((IList)array);
            Assert.IsNotNull((ICollection)array);
            Assert.IsNotNull((IEnumerable)array);

            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (string)array; });
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (Foo)array; });
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (object[])array; });
            Assert.ThrowsException(typeof(InvalidCastException), () => { _ = (int[][])array; });
        }

        [TestMethod]
        public void Arrays_ReferenceElementCovariance()
        {
            object children = new FooChild[1];
            object strings = new string[1];
            object jagged = new string[1][];
            object interfaces = new IBase[1];

            Assert.IsTrue(children is Foo[]);
            Assert.IsTrue(children is IBase[]);
            Assert.IsTrue(children is object[]);
            Assert.IsTrue(strings is object[]);
            Assert.IsTrue(jagged is object[]);
            Assert.IsTrue(jagged is IList[]);
            Assert.IsTrue(interfaces is object[]);

            Assert.IsFalse(strings is Foo[]);
            Assert.IsFalse(new Foo[1] is FooChild[]);
        }

        [TestMethod]
        public void Arrays_EnumAndUnderlyingType_ShareStorage()
        {
            object ints = new int[1];
            object enums = new SampleEnum[1];

            Assert.IsTrue(ints is SampleEnum[]);
            Assert.IsTrue(enums is int[]);
            Assert.IsFalse(enums is long[]);
            Assert.IsFalse(enums is object[]);
        }

        [TestMethod]
        public void Arrays_StructElements_AreInvariant()
        {
            object first = new SampleStruct[1];

            Assert.IsTrue(first is SampleStruct[]);
            Assert.IsFalse(first is OtherStruct[]);
            Assert.IsFalse(first is object[]);
        }

        [TestMethod]
        public void Interfaces_DeclaredThroughDerivedInterface_AreFound()
        {
            // OnlyDerived only declares IDerived. The compiler emits IBase on it as well, which IsInstanceOf relies on.
            object value = new OnlyDerived();

            Assert.IsTrue(value is IDerived);
            Assert.IsTrue(value is IBase);
            Assert.IsNotNull((IBase)value);

            object derivedFromIt = new OnlyDerivedChild();

            Assert.IsTrue(derivedFromIt is IBase);
        }

        [TestMethod]
        public void InterfaceInheritedByInterface_ArrayCovariance()
        {
            object derived = new IDerived[1];

            Assert.IsTrue(derived is IBase[]);
        }

        [TestMethod]
        public void ArrayCopy_JaggedDestination_ChecksEveryElement()
        {
            object[] source = new object[]
            {
                new string[] { "a" },
                new string[] { "b" },
                new string[] { "c" }
            };
            string[][] destination = new string[3][];

            Array.Copy(source, destination, 3);

            Assert.AreEqual("a", destination[0][0]);
            Assert.AreEqual("b", destination[1][0]);
            Assert.AreEqual("c", destination[2][0]);

            source[2] = new int[1];

            Assert.ThrowsException(typeof(InvalidCastException), () => { Array.Copy(source, destination, 3); });
        }

        public interface IBase
        {
            int OnBase();
        }

        public interface IDerived : IBase
        {
        }

        public class Foo
        {
            public int Instance()
            {
                return 1;
            }
        }

        public class FooChild : Foo, IBase
        {
            public int OnBase()
            {
                return 1;
            }
        }

        public class OnlyDerived : IDerived
        {
            public int OnBase()
            {
                return 1;
            }
        }

        public class OnlyDerivedChild : OnlyDerived
        {
        }

        public enum SampleEnum
        {
            Zero,
            One
        }

        public struct SampleStruct
        {
            public int Value;
        }

        public struct OtherStruct
        {
            public int Value;
        }

        public class FieldHolder
        {
            public Foo[] Foos;
            public Foo Single;
        }

        public class CtorTarget
        {
            public CtorTarget(Foo value)
            {
            }

            public CtorTarget(Foo[] values)
            {
            }
        }

        public static class InvokeTargets
        {
            public static int TakesFoo(Foo value) => 1;

            public static int TakesString(string value) => 1;

            public static int TakesIBase(IBase value) => 1;

            public static int TakesObject(object value) => 1;

            public static int TakesType(Type value) => 1;

            public static int TakesFooArray(Foo[] value) => 1;

            public static int TakesIBaseArray(IBase[] value) => 1;

            public static int TakesObjectArray(object[] value) => 1;

            public static int TakesIntArray(int[] value) => 1;

            public static int TakesIntJagged(int[][] value) => 1;

            public static int TakesArray(Array value) => 1;

            public static int TakesIList(IList value) => 1;

            public static int TakesICollection(ICollection value) => 1;

            public static int TakesIEnumerable(IEnumerable value) => 1;

            public static int TakesEnum(SampleEnum value) => 1;

            public static int TakesEnumArray(SampleEnum[] value) => 1;

            public static int TakesEnumJagged(SampleEnum[][] value) => 1;

            public static int TakesRefFoo(ref Foo value) => 1;

            public static int TakesRefInt(ref int value) => 1;
        }
    }
}
