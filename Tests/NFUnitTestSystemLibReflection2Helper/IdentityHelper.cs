// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace NFUnitTestIdentityHelper
{
    // The instantiations named here live in the rows of this assembly, not in the ones of the test assembly.
    public class IdxBox<T>
    {
    }

    public class IdxBase<T>
    {
    }

    public class IdxDerivedInt : IdxBase<int>
    {
    }

    public class IdxDerivedOf<T> : IdxBase<T>
    {
    }

    public interface IdxFace<T>
    {
    }

    public class IdxImplString : IdxFace<string>
    {
    }

    public static class IdxTypes
    {
        public static Type BoxOfInt()
        {
            return typeof(IdxBox<int>);
        }

        public static Type BoxOfIntArray()
        {
            return typeof(IdxBox<int>[]);
        }

        public static Type BaseOfInt()
        {
            return typeof(IdxBase<int>);
        }

        public static Type BaseOfDerivedString()
        {
            return typeof(IdxDerivedOf<string>).BaseType;
        }

        public static object NewBoxOfInt()
        {
            return new IdxBox<int>();
        }

        public static Type FaceOfString()
        {
            return typeof(IdxFace<string>);
        }
    }
}
