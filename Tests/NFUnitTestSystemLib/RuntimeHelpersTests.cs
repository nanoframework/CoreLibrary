// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Runtime.CompilerServices;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    class RuntimeHelpersTests
    {
        [TestMethod]
        public static void IsReferenceOrContainsReferences()
        {
            Assert.IsFalse(RuntimeHelpers.IsReferenceOrContainsReferences<int>());
            Assert.IsTrue(RuntimeHelpers.IsReferenceOrContainsReferences<string>());
            Assert.IsFalse(RuntimeHelpers.IsReferenceOrContainsReferences<Guid>());
            Assert.IsFalse(RuntimeHelpers.IsReferenceOrContainsReferences<StructWithoutReferences>());
            Assert.IsTrue(RuntimeHelpers.IsReferenceOrContainsReferences<StructWithReferences>());
            Assert.IsFalse(RuntimeHelpers.IsReferenceOrContainsReferences<RefStructWithoutReferences>());
            Assert.IsTrue(RuntimeHelpers.IsReferenceOrContainsReferences<RefStructWithReferences>());
            Assert.IsTrue(RuntimeHelpers.IsReferenceOrContainsReferences<Span<char>>());
            Assert.IsTrue(RuntimeHelpers.IsReferenceOrContainsReferences<ReadOnlySpan<char>>());
            //Assert.IsTrue(RuntimeHelpers.IsReferenceOrContainsReferences<RefStructWithRef>());
            //Assert.IsTrue(RuntimeHelpers.IsReferenceOrContainsReferences<RefStructWithNestedRef>());
        }

        private struct StructWithoutReferences
        {
            public int a, b, c;
        }

        private struct StructWithReferences
        {
            public int a, b, c;
            public object d;
        }

        private ref struct RefStructWithoutReferences
        {
            public int a;
            public long b;
        }

        private ref struct RefStructWithReferences
        {
            public int a;
            public object b;
        }

        // TODO: add after checking viability of ref fields in ref structs
        //private ref struct RefStructWithRef
        //{
        //    public ref int a;

        //    internal RefStructWithRef(ref int aVal)
        //    {
        //        a = ref aVal;
        //    }
        //}

        //private ref struct RefStructWithNestedRef
        //{
        //    public Span<char> a;
        //}
    }
}
