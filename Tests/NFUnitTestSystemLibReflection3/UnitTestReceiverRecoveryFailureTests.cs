// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Di4Types;
using nanoFramework.TestFramework;

namespace Di28Types
{
    public interface IRcBig
    {
        string Big();
    }

    public class RcBigBase<T> : IRcBig
    {
        public string Big()
        {
            string r = "";

            for (int i = 0; i < 2; i++)
            {
                try
                {
                    r += typeof(T).Name;
                }
                catch
                {
                    r = "x";
                }
            }

            return r;
        }
    }

    public class RcBigNested3 : RcBigBase<GdBox<GdBox<GdBox<int>>>> { }

    public class RcBigNested4 : RcBigBase<GdBox<GdBox<GdBox<GdBox<int>>>>> { }

    public class RcToStringBase<T>
    {
        public override string ToString() { return typeof(T).Name; }
    }

    public class RcToStringNested3 : RcToStringBase<GdBox<GdBox<GdBox<int>>>> { }

    public class RcToStringNested4 : RcToStringBase<GdBox<GdBox<GdBox<GdBox<int>>>>> { }

    public class RcCaller<T>
    {
        public string CallBig(IRcBig target) { return target.Big(); }

        public string CallToString(object target) { return target.ToString(); }

        public string CallDelegate(IGdPlain target)
        {
            Func<string> d = target.G;
            return d();
        }

        public string CallOwn(IRcOwn target) { return target.Name(); }

        public string CallPlain(IGdPlain target) { return target.G(); }

        public string CallGeneric(IGd<GdBox<GdBox<GdBox<int>>>> target) { return target.G(); }
    }

    public interface IRcOwn
    {
        string Name();
    }

    public class RcNested4Own : Gd0<GdBox<GdBox<GdBox<GdBox<int>>>>>, IRcOwn
    {
        public string Name() { return "own"; }
    }

    [TestClass]
    public class UnitTestReceiverRecoveryFailureTests
    {
        [TestMethod]
        public void OverLimitBase_FromGenericCaller_DoesNotUseCallerArguments()
        {
            Assert.ThrowsException(typeof(NotSupportedException), () => new RcCaller<string>().CallPlain(new GdNested4()));
        }

        [TestMethod]
        public void OverLimitBase_FromNonGenericCaller_Throws()
        {
            Assert.ThrowsException(typeof(NotSupportedException), () => ((IGdPlain)new GdNested4()).G());
        }

        [TestMethod]
        public void AtLimitBase_FromGenericCaller_StillWorks()
        {
            Assert.AreEqual("GdBox`1", new RcCaller<string>().CallPlain(new GdNested3()));
        }

        [TestMethod]
        public void OverLimitBase_DelegateOverInheritedMethod_Throws()
        {
            Assert.ThrowsException(typeof(NotSupportedException), () =>
            {
                Func<string> d = new GdNested4().G;
                d();
            });
        }

        [TestMethod]
        public void OverLimitBase_MethodWithoutGenericDeclaringType_StillWorks()
        {
            Assert.AreEqual("own", new RcCaller<string>().CallOwn(new RcNested4Own()));
        }

        [TestMethod]
        public void OverLimitBase_MethodNotInlined_FromGenericCaller_Throws()
        {
            Assert.AreEqual("GdBox`1GdBox`1", new RcCaller<string>().CallBig(new RcBigNested3()));
            Assert.ThrowsException(typeof(NotSupportedException), () => new RcCaller<string>().CallBig(new RcBigNested4()));
        }

        [TestMethod]
        public void OverLimitBase_VirtualToString_Throws()
        {
            Assert.AreEqual("GdBox`1", new RcCaller<string>().CallToString(new RcToStringNested3()));
            Assert.ThrowsException(typeof(NotSupportedException), () => new RcCaller<string>().CallToString(new RcToStringNested4()));
        }

        [TestMethod]
        public void OverLimitBase_DelegateOverInterfaceMethod_Throws()
        {
            Assert.AreEqual("GdBox`1", new RcCaller<string>().CallDelegate(new GdNested3()));
            Assert.ThrowsException(typeof(NotSupportedException), () => new RcCaller<string>().CallDelegate(new GdNested4()));
        }
    }
}
