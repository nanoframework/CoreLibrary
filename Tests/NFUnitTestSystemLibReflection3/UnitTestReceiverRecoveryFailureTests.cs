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

    public class Deep1<T> : Gd0<T> { }
    public class Deep2<T> : Deep1<T> { }
    public class Deep3<T> : Deep2<T> { }
    public class Deep4<T> : Deep3<T> { }
    public class Deep5<T> : Deep4<T> { }
    public class Deep6<T> : Deep5<T> { }
    public class Deep7<T> : Deep6<T> { }
    public class Deep8<T> : Deep7<T> { }
    public class Deep9<T> : Deep8<T> { }
    public class Deep10<T> : Deep9<T> { }
    public class Deep11<T> : Deep10<T> { }
    public class Deep12<T> : Deep11<T> { }
    public class Deep13<T> : Deep12<T> { }
    public class Deep14<T> : Deep13<T> { }
    public class Deep15<T> : Deep14<T> { }
    public class Deep16<T> : Deep15<T> { }
    public class Deep17<T> : Deep16<T> { }
    public class Deep18<T> : Deep17<T> { }
    public class Deep19<T> : Deep18<T> { }
    public class Deep20<T> : Deep19<T> { }
    public class Deep21<T> : Deep20<T> { }
    public class Deep22<T> : Deep21<T> { }
    public class Deep23<T> : Deep22<T> { }
    public class Deep24<T> : Deep23<T> { }
    public class Deep25<T> : Deep24<T> { }
    public class Deep26<T> : Deep25<T> { }
    public class Deep27<T> : Deep26<T> { }
    public class Deep28<T> : Deep27<T> { }
    public class Deep29<T> : Deep28<T> { }
    public class Deep30<T> : Deep29<T> { }
    public class Deep31<T> : Deep30<T> { }
    public class Deep32<T> : Deep31<T> { }
    public class Deep33<T> : Deep32<T> { }

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

        [TestMethod]
        public void DeepHierarchy_MatchAtTheLastSearchStep_Works()
        {
            Assert.AreEqual("Int32", ((IGd<int>)new Deep32<int>()).G());
        }

        [TestMethod]
        public void DeepHierarchy_BeyondTheSearchLimit_Throws()
        {
            Assert.ThrowsException(typeof(NotSupportedException), () => ((IGd<int>)new Deep33<int>()).G());
        }
    }
}
