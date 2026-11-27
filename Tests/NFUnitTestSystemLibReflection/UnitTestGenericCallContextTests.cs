// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // The generic context of the callee when the call is made from generic code, or on a boxed generic struct.
    [TestClass]
    public class UnitTestGenericCallContextTests
    {
        // generic method passing its own type parameter to another generic method
        [TestMethod]
        public void GenericMethod_PassingItsParameterOn_BindsTheArgument()
        {
            object value = CallContextFactory.MakeArrayViaOneLevel<int>();

            Assert.IsTrue(value is int[]);
            Assert.IsFalse(value is string[]);
        }

        [TestMethod]
        public void GenericMethod_PassingItsParameterOnThreeLevels_BindsTheArgument()
        {
            object value = CallContextFactory.MakeArrayViaThreeLevels<string>();

            Assert.IsTrue(value is string[]);
            Assert.IsFalse(value is int[]);
        }

        [TestMethod]
        public void GenericMethod_CalledWithDifferentArguments_BindsEachCall()
        {
            object first = CallContextFactory.MakeArrayViaOneLevel<int>();
            object second = CallContextFactory.MakeArrayViaOneLevel<string>();
            object third = CallContextFactory.MakeArrayViaOneLevel<int>();

            Assert.IsTrue(first is int[]);
            Assert.IsTrue(second is string[]);
            Assert.IsTrue(third is int[]);
            Assert.IsFalse(second is int[]);
        }

        [TestMethod]
        public void GenericMethod_PassingItsParameterInsideAGenericInstance_BindsTheArgument()
        {
            object value = CallContextFactory.MakeBoxArrayViaOneLevel<int>();

            Assert.IsTrue(value is CallContextBox<int>[]);
            Assert.IsFalse(value is CallContextBox<string>[]);
        }

        // generic method of a generic class passing a parameter of the class
        [TestMethod]
        public void GenericClassMethod_PassingTheClassParameter_BindsTheArgument()
        {
            object value = new CallContextHolder<int>().MakeArrayOfClassParameter();

            Assert.IsTrue(value is int[]);
            Assert.IsFalse(value is string[]);
        }

        [TestMethod]
        public void GenericClassGenericMethod_PassingTheClassParameter_BindsTheArgument()
        {
            object value = new CallContextHolder<int>().MakeArrayOfClassParameterFromGenericMethod<string>();

            Assert.IsTrue(value is int[]);
            Assert.IsFalse(value is string[]);
        }

        // virtual and interface calls from a generic frame run with the context of the receiver, not of the caller
        [TestMethod]
        public void CallFromGenericClass_VirtualMethodOfOtherGenericClass_UsesTheReceiverArgument()
        {
            string name = new CallContextCaller<string>().CallVirtual(new CallContextDerived<int>());

            Assert.AreEqual("System.Int32", name);
        }

        [TestMethod]
        public void CallFromGenericClass_InterfaceMethodOfOtherGenericClass_UsesTheReceiverArgument()
        {
            string name = new CallContextCaller<string>().CallInterface(new CallContextImplementation<int>());

            Assert.AreEqual("System.Int32", name);
        }

        [TestMethod]
        public void CallFromGenericClass_ObjectToStringOfGenericClass_UsesTheReceiverArgument()
        {
            string name = new CallContextCaller<string>().CallToString(new CallContextDerived<int>());

            Assert.AreEqual("System.Int32", name);
        }

        [TestMethod]
        public void CallFromGenericClass_InterfaceMethodOfOtherInstantiation_UsesTheReceiverArgument()
        {
            string name = new CallContextImplementation<string>().CallOther(new CallContextImplementation<int>());

            Assert.AreEqual("System.Int32", name);
        }

        [TestMethod]
        public void CallFromGenericClass_InterfaceMethodOfBoxedStruct_UsesTheReceiverArgument()
        {
            string name = new CallContextCaller<string>().CallInterface(new CallContextStruct<int>());

            Assert.AreEqual("System.Int32", name);
        }

        [TestMethod]
        public void CallFromGenericClass_ObjectToStringOfBoxedStruct_UsesTheReceiverArgument()
        {
            string name = new CallContextCaller<string>().CallToString(new CallContextStruct<int>());

            Assert.AreEqual("System.Int32", name);
        }

        [TestMethod]
        public void CallFromGenericMethod_VirtualMethodOfGenericClass_UsesTheReceiverArgument()
        {
            string name = CallContextFactory.CallVirtual<string>(new CallContextDerived<int>());

            Assert.AreEqual("System.Int32", name);
        }

        [TestMethod]
        public void CallFromGenericMethod_InterfaceMethodOfGenericClass_UsesTheReceiverArgument()
        {
            string name = CallContextFactory.CallInterface<string>(new CallContextImplementation<int>());

            Assert.AreEqual("System.Int32", name);
        }

        [TestMethod]
        public void GenericVirtualMethod_CalledThroughBase_BindsTheArgument()
        {
            CallContextArrayMaker maker = new CallContextArrayMakerOverride();

            object value = maker.Make<int>();

            Assert.IsTrue(value is int[]);
            Assert.IsFalse(value is string[]);
        }

        // boxed struct of a generic instance
        [TestMethod]
        public void BoxedGenericStruct_VirtualCall_UsesT()
        {
            object boxed = new CallContextStruct<int>();

            Assert.AreEqual("System.Int32", boxed.ToString());
        }

        [TestMethod]
        public void BoxedGenericStruct_InterfaceCall_UsesT()
        {
            CallContextDescribe boxed = new CallContextStruct<int>();

            Assert.AreEqual("System.Int32", boxed.Describe());
        }

        [TestMethod]
        public void BoxedGenericStruct_ConstrainedCall_UsesT()
        {
            Assert.AreEqual("System.Int32", CallContextFactory.DescribeConstrained(new CallContextStruct<int>()));

            CallContextDescribe boxed = new CallContextStruct<int>();

            Assert.AreEqual("System.Int32", CallContextFactory.DescribeConstrained(boxed));
        }

        [TestMethod]
        public void BoxedGenericStruct_OverrideNotUsingT_IsCalled()
        {
            object boxed = new CallContextPlainStruct<int>();

            Assert.AreEqual("plain", boxed.ToString());
        }

        [TestMethod]
        public void BoxedGenericStruct_OtherInstantiations_UseTheirOwnArgument()
        {
            object first = new CallContextStruct<int>();
            object second = new CallContextStruct<string>();

            Assert.AreEqual("System.Int32", first.ToString());
            Assert.AreEqual("System.String", second.ToString());
        }
    }

    public interface CallContextDescribe
    {
        string Describe();
    }

    public abstract class CallContextArrayMaker
    {
        public abstract object Make<T>();
    }

    public class CallContextArrayMakerOverride : CallContextArrayMaker
    {
        public override object Make<T>() { return new T[1]; }
    }

    public class CallContextBox<T> { }

    public static class CallContextFactory
    {
        public static object MakeArray<T>() { return new T[1]; }
        public static object MakeArrayViaOneLevel<T>() { return MakeArray<T>(); }
        public static object MakeArrayViaTwoLevels<T>() { return MakeArrayViaOneLevel<T>(); }
        public static object MakeArrayViaThreeLevels<T>() { return MakeArrayViaTwoLevels<T>(); }
        public static object MakeBoxArrayViaOneLevel<T>() { return MakeArray<CallContextBox<T>>(); }

        public static string CallVirtual<U>(CallContextBase receiver) { return receiver.Name(); }
        public static string CallInterface<U>(CallContextDescribe receiver) { return receiver.Describe(); }
        public static string DescribeConstrained<S>(S value) where S : CallContextDescribe { return value.Describe(); }
    }

    public class CallContextHolder<T>
    {
        public object MakeArrayOfClassParameter() { return CallContextFactory.MakeArray<T>(); }
        public object MakeArrayOfClassParameterFromGenericMethod<U>() { return CallContextFactory.MakeArray<T>(); }
    }

    public abstract class CallContextBase
    {
        public abstract string Name();
    }

    public class CallContextDerived<T> : CallContextBase
    {
        public override string Name() { return typeof(T).ToString(); }
        public override string ToString() { return typeof(T).ToString(); }
    }

    public class CallContextImplementation<T> : CallContextDescribe
    {
        public string Describe() { return typeof(T).ToString(); }
        public string CallOther(CallContextDescribe other) { return other.Describe(); }
    }

    public class CallContextCaller<U>
    {
        public string CallVirtual(CallContextBase receiver) { return receiver.Name(); }
        public string CallInterface(CallContextDescribe receiver) { return receiver.Describe(); }
        public string CallToString(object receiver) { return receiver.ToString(); }
    }

    public struct CallContextStruct<T> : CallContextDescribe
    {
        public override string ToString() { return typeof(T).ToString(); }
        public string Describe() { return typeof(T).ToString(); }
    }

    public struct CallContextPlainStruct<T>
    {
        public override string ToString() { return "plain"; }
    }
}
