// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// Not part of the project on purpose: these tests fail today, see the SZArrayHelper / Array.IndexOf follow-up.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestSZArrayHelperKnownIssues
    {
        [TestMethod]
        public void Contains_Null_FindsTheNullElement()
        {
            System.Collections.Generic.ICollection<string> collection = new string[] { "a", null };

            Assert.IsTrue(collection.Contains(null));
        }

        [TestMethod]
        public void IndexOf_ClassWithEqualsOverride_ReturnsTheFirstMatch()
        {
            KiKey target = new KiKey(7);
            KiKey[] array = new KiKey[] { new KiKey(7), target };

            Assert.AreEqual(0, Array.IndexOf(array, target));
        }

        [TestMethod]
        public void IndexOf_FloatingPointZeroes_AreEqual()
        {
            double[] array = new double[] { 0.0 };

            Assert.AreEqual(0, Array.IndexOf(array, -0.0));
        }

        private class KiKey
        {
            private readonly int _id;

            public KiKey(int id)
            {
                _id = id;
            }

            public override bool Equals(object obj)
            {
                return obj is KiKey other && other._id == _id;
            }

            public override int GetHashCode()
            {
                return _id;
            }
        }
    }
}
