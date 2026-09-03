// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NANOCLR_REFLECTION
#nullable enable

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Contains generic, low-level functionality for manipulating pointers.
    /// </summary>
    public static unsafe partial class Unsafe
    {
        /// <summary>
        /// Casts the given object to the specified type, performs no dynamic type checking.
        /// </summary>
        /// <typeparam name="T">The target reference type. The return value will be of this type.</typeparam>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern T? As<T>(object? o) where T : class?;
    }
}

#endif
