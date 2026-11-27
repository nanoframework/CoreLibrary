// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLibReflection3
{
    public class ListBase
    {
        public virtual string Who() => "A";

        public virtual string Who(int x) => "A" + x;

        public virtual string Slot() => "A";

        public string Plain() => "A";

        private string Hidden() => "A";

        public static string Stat() => "A";

        private static string PrivStat() => "A";
    }

    public class ListMiddle : ListBase
    {
        public override string Who() => "B";

        public new virtual string Slot() => "B";

        public new string Plain() => "B";
    }

    public class ListLeaf : ListMiddle
    {
        public override string Who() => "C";

        public override string Slot() => "C";
    }

    public class GenRoot
    {
        public virtual string Gen<T>() => "R";
    }

    public class GenBase : GenRoot
    {
        public virtual string Gen() => "B";
    }

    public class GenMiddle : GenBase
    {
        public override string Gen<T>() => "M";
    }

    public class GenLeaf : GenMiddle
    {
    }

    [TestClass]
    public class UnitTestMethodListTests
    {
        private static int Count(MethodInfo[] methods, string name, Type declaring)
        {
            int n = 0;

            foreach (MethodInfo m in methods)
            {
                if (m.Name == name && (declaring == null || m.DeclaringType == declaring))
                {
                    n++;
                }
            }

            return n;
        }

        [TestMethod]
        public void OverridesCollapseToTheMostDerivedMethod()
        {
            MethodInfo[] methods = typeof(ListLeaf).GetMethods();

            Assert.AreEqual(1, Count(methods, "Who", typeof(ListLeaf)));
            Assert.AreEqual(0, Count(methods, "Who", typeof(ListMiddle)));
        }

        [TestMethod]
        public void OverloadsAreKept()
        {
            MethodInfo[] methods = typeof(ListLeaf).GetMethods();

            Assert.AreEqual(2, Count(methods, "Who", null));
            Assert.AreEqual(1, Count(methods, "Who", typeof(ListBase)));
        }

        [TestMethod]
        public void NewSlotAndHiddenNonVirtualMethodsAreKept()
        {
            MethodInfo[] methods = typeof(ListLeaf).GetMethods();

            Assert.AreEqual(1, Count(methods, "Slot", typeof(ListLeaf)));
            Assert.AreEqual(1, Count(methods, "Slot", typeof(ListBase)));
            Assert.AreEqual(2, Count(methods, "Plain", null));
        }

        [TestMethod]
        public void DeclaredOnlyAndPrivateBaseMethodsAreUnchanged()
        {
            MethodInfo[] declared = typeof(ListLeaf).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            Assert.AreEqual(2, declared.Length);
            Assert.AreEqual(0, Count(typeof(ListLeaf).GetMethods(), "Hidden", null));
            Assert.AreEqual(0, Count(typeof(ListLeaf).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance), "Hidden", null));
            Assert.AreEqual(1, Count(typeof(ListBase).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance), "Hidden", null));
        }

        [TestMethod]
        public void GenericArityIsPartOfTheOverrideMatch()
        {
            MethodInfo[] methods = typeof(GenLeaf).GetMethods();

            Assert.AreEqual(2, Count(methods, "Gen", null));
            Assert.AreEqual(1, Count(methods, "Gen", typeof(GenBase)));
            Assert.AreEqual(1, Count(methods, "Gen", typeof(GenMiddle)));
            Assert.AreEqual(0, Count(methods, "Gen", typeof(GenRoot)));
        }

        [TestMethod]
        public void StaticBaseMethodsNeedFlattenHierarchy()
        {
            Assert.IsNull(typeof(ListLeaf).GetMethod("Stat", BindingFlags.Static | BindingFlags.Public));
            Assert.IsNotNull(typeof(ListLeaf).GetMethod("Stat", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy));
            Assert.IsNull(typeof(ListLeaf).GetMethod("PrivStat", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy));
            Assert.IsNotNull(typeof(ListBase).GetMethod("PrivStat", BindingFlags.Static | BindingFlags.NonPublic));
        }

        [TestMethod]
        public void GetMethodReturnsTheMostDerivedOverride()
        {
            Assert.AreEqual(typeof(ListLeaf), typeof(ListLeaf).GetMethod("Who", new Type[0]).DeclaringType);
            Assert.AreEqual(typeof(ListLeaf), typeof(ListLeaf).GetMethod("Slot").DeclaringType);
        }

        [TestMethod]
        public void NullArgumentsThrowArgumentNullException()
        {
            Assert.ThrowsException(typeof(ArgumentNullException), () => typeof(ListLeaf).GetConstructor(null));
            Assert.ThrowsException(typeof(ArgumentNullException), () => typeof(ListLeaf).GetMethod(null));
            Assert.ThrowsException(typeof(ArgumentNullException), () => typeof(ListLeaf).GetMethod(null, new Type[0]));
            Assert.ThrowsException(typeof(ArgumentNullException), () => typeof(ListLeaf).GetMethod("Who", (Type[])null));
            Assert.ThrowsException(typeof(ArgumentNullException), () => typeof(ListLeaf).GetMethod(null, BindingFlags.Public | BindingFlags.Instance));
            Assert.ThrowsException(typeof(ArgumentNullException), () => typeof(ListLeaf).GetField(null));
        }
    }
}
