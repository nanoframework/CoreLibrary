// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Di4Types;
using nanoFramework.TestFramework;

namespace ReceiverRecoveryTypes
{
    public interface ILoopingMethod
    {
        string Loop();
    }

    public class LoopingBase<T> : ILoopingMethod
    {
        public string Loop()
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

    public class LoopingBaseThreeDeep : LoopingBase<GdBox<GdBox<GdBox<int>>>> { }

    public class LoopingBaseFourDeep : LoopingBase<GdBox<GdBox<GdBox<GdBox<int>>>>> { }

    public class ToStringBase<T>
    {
        public override string ToString() { return typeof(T).Name; }
    }

    public class ToStringBaseThreeDeep : ToStringBase<GdBox<GdBox<GdBox<int>>>> { }

    public class ToStringBaseFourDeep : ToStringBase<GdBox<GdBox<GdBox<GdBox<int>>>>> { }

    public class GenericCaller<T>
    {
        public string CallLooping(ILoopingMethod target) { return target.Loop(); }

        public string CallToString(object target) { return target.ToString(); }

        public string CallDelegate(IGdPlain target)
        {
            Func<string> d = target.G;
            return d();
        }

        public string CallOwn(IOwnName target) { return target.Name(); }

        public string CallPlain(IGdPlain target) { return target.G(); }
    }

    public interface IOwnName
    {
        string Name();
    }

    public class FourDeepWithOwnMethod : Gd0<GdBox<GdBox<GdBox<GdBox<int>>>>>, IOwnName
    {
        public string Name() { return "own"; }
    }

    [TestClass]
    public class UnitTestReceiverRecoveryFailureTests
    {
        [TestMethod]
        public void OverLimitBase_FromGenericCaller_DoesNotUseCallerArguments()
        {
            Assert.ThrowsException(typeof(NotSupportedException), () => new GenericCaller<string>().CallPlain(new GdNested4()));
        }

        [TestMethod]
        public void OverLimitBase_FromNonGenericCaller_Throws()
        {
            Assert.ThrowsException(typeof(NotSupportedException), () => ((IGdPlain)new GdNested4()).G());
        }

        [TestMethod]
        public void AtLimitBase_FromGenericCaller_StillWorks()
        {
            Assert.AreEqual("GdBox`1", new GenericCaller<string>().CallPlain(new GdNested3()));
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
            Assert.AreEqual("own", new GenericCaller<string>().CallOwn(new FourDeepWithOwnMethod()));
        }

        [TestMethod]
        public void OverLimitBase_MethodNotInlined_FromGenericCaller_Throws()
        {
            Assert.AreEqual("GdBox`1GdBox`1", new GenericCaller<string>().CallLooping(new LoopingBaseThreeDeep()));
            Assert.ThrowsException(typeof(NotSupportedException), () => new GenericCaller<string>().CallLooping(new LoopingBaseFourDeep()));
        }

        [TestMethod]
        public void OverLimitBase_VirtualToString_Throws()
        {
            Assert.AreEqual("GdBox`1", new GenericCaller<string>().CallToString(new ToStringBaseThreeDeep()));
            Assert.ThrowsException(typeof(NotSupportedException), () => new GenericCaller<string>().CallToString(new ToStringBaseFourDeep()));
        }

        [TestMethod]
        public void OverLimitBase_DelegateOverInterfaceMethod_Throws()
        {
            Assert.AreEqual("GdBox`1", new GenericCaller<string>().CallDelegate(new GdNested3()));
            Assert.ThrowsException(typeof(NotSupportedException), () => new GenericCaller<string>().CallDelegate(new GdNested4()));
        }
    }
}
