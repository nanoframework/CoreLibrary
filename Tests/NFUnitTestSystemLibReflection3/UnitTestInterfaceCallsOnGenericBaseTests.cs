// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using nanoFramework.TestFramework;

namespace Di4Types
{
    public interface IGd<T>
    {
        string G();
        string G2();
        string Gm<U>();
    }

    public interface IGdPlain
    {
        string G();
    }

    public struct GdStruct
    {
        public int X;
    }

    public class Gd0<T> : IGd<T>, IGdPlain
    {
        public string G() { return typeof(T).Name; }
        public string G2() { return "g2"; }
        public string Gm<U>() { return typeof(T).Name + "/" + typeof(U).Name; }
        public virtual string V() { return "v" + typeof(T).Name; }
    }

    public class Gd1<T> : Gd0<T> { }
    public class Gd2<T> : Gd1<T> { }
    public class Gd3<T> : Gd2<T> { }

    public class GdInt : Gd0<int> { }
    public class GdInt2 : Gd1<int> { }

    public class GdSwap<U> : Gd0<IList> { }

    public class GdWrap<T> : Gd0<GdBox<T>> { }

    public class GdBox<T> { }

    public class GdNested3 : Gd0<GdBox<GdBox<GdBox<int>>>> { }

    public class GdNested4 : Gd0<GdBox<GdBox<GdBox<GdBox<int>>>>> { }

    public class GdOverride<T> : Gd0<T>
    {
        public override string V() { return "o" + typeof(T).Name; }
    }

    public class GdStr0<T> : IGd<string>
    {
        public string G() { return typeof(T).Name; }
        public string G2() { return "s2"; }
        public string Gm<U>() { return typeof(T).Name + "/" + typeof(U).Name; }
    }

    public class GdStr1<T> : GdStr0<T> { }

    public class GdReimpl<T> : Gd1<T>, IGd<T>
    {
        public new string G() { return "re" + typeof(T).Name; }
    }
}

namespace NFUnitTestSystemLib
{
    using Di4Types;

    // Expected values come from running the same code on .NET 10.
    [TestClass]
    public class UnitTestInterfaceCallsOnGenericBaseTests
    {
        [TestMethod]
        public void Gd1Int_G()
        {
            Assert.AreEqual("Int32", ((IGd<int>)new Gd1<int>()).G());
        }

        [TestMethod]
        public void Gd1Int_NoT()
        {
            Assert.AreEqual("g2", ((IGd<int>)new Gd1<int>()).G2());
        }

        [TestMethod]
        public void Gd1Int_GenericMethod()
        {
            Assert.AreEqual("Int32/String", ((IGd<int>)new Gd1<int>()).Gm<string>());
        }

        [TestMethod]
        public void Gd1String_NonGenericInterface()
        {
            Assert.AreEqual("String", ((IGdPlain)new Gd1<string>()).G());
        }

        [TestMethod]
        public void TwoLevels()
        {
            Assert.AreEqual("Int32", ((IGd<int>)new Gd2<int>()).G());
        }

        [TestMethod]
        public void ThreeLevels_GenericMethod()
        {
            Assert.AreEqual("Int64/Int32", ((IGd<long>)new Gd3<long>()).Gm<int>());
        }

        [TestMethod]
        public void NonGenericDerived()
        {
            Assert.AreEqual("Int32", ((IGd<int>)new GdInt()).G());
        }

        [TestMethod]
        public void NonGenericDerivedTwoLevels_GenericMethod()
        {
            Assert.AreEqual("Int32/String", ((IGd<int>)new GdInt2()).Gm<string>());
        }

        [TestMethod]
        public void NonGenericDerived_NonGenericInterface()
        {
            Assert.AreEqual("Int32", ((IGdPlain)new GdInt2()).G());
        }

        [TestMethod]
        public void StructArgument()
        {
            Assert.AreEqual("GdStruct", ((IGd<GdStruct>)new Gd2<GdStruct>()).G());
        }

        [TestMethod]
        public void StructArgument_GenericMethod()
        {
            Assert.AreEqual("GdStruct/GdStruct", ((IGd<GdStruct>)new Gd2<GdStruct>()).Gm<GdStruct>());
        }

        [TestMethod]
        public void InterfaceBoundAtClass()
        {
            Assert.AreEqual("Int32", ((IGd<string>)new GdStr1<int>()).G());
        }

        [TestMethod]
        public void InterfaceBoundAtClass_StructGenericMethod()
        {
            Assert.AreEqual("GdStruct/Int64", ((IGd<string>)new GdStr1<GdStruct>()).Gm<long>());
        }

        [TestMethod]
        public void BaseArgumentFixed()
        {
            Assert.AreEqual("IList", ((IGd<IList>)new GdSwap<int>()).G());
        }

        [TestMethod]
        public void BaseArgumentNested()
        {
            Assert.AreEqual("GdBox`1", ((IGd<GdBox<int>>)new GdWrap<int>()).G());
        }

        [TestMethod]
        public void OverrideOfVirtual()
        {
            Assert.AreEqual("Int32", ((IGd<int>)new GdOverride<int>()).G());
        }

        [TestMethod]
        public void Reimplemented()
        {
            Assert.AreEqual("reInt32", ((IGd<int>)new GdReimpl<int>()).G());
        }

        [TestMethod]
        public void ThroughBaseReference()
        {
            Assert.AreEqual("Int32", ((IGd<int>)(Gd0<int>)new Gd2<int>()).G());
        }

        [TestMethod]
        public void VirtualCall()
        {
            Assert.AreEqual("vInt32", new Gd2<int>().V());
        }

        [TestMethod]
        public void NestedArgumentWithinLimit_Works()
        {
            Assert.AreEqual("GdBox`1", ((IGd<GdBox<GdBox<GdBox<int>>>>)new GdNested3()).G());
        }

        [TestMethod]
        public void DelegateOverInheritedMethod()
        {
            Func<string> d = new Gd2<int>().G;

            Assert.AreEqual("Int32", d());
        }

        [TestMethod]
        public void DelegateOverInheritedMethodThroughInterface()
        {
            Func<string> d = ((IGd<long>)new Gd2<long>()).G;

            Assert.AreEqual("Int64", d());
        }

        [TestMethod]
        public void NestedArgumentOverLimit_FailsClosed()
        {
            Assert.ThrowsException(typeof(Exception), () => ((IGd<GdBox<GdBox<GdBox<GdBox<int>>>>>)new GdNested4()).G());
        }
    }
}
