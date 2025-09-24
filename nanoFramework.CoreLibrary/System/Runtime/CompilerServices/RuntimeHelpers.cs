// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.CompilerServices
{
#pragma warning disable S4200 // Native methods should be wrapped

    /// <summary>
    /// Provides a set of static methods and properties that provide support for compilers. This class cannot be inherited.
    /// </summary>
    [Serializable]
    public static class RuntimeHelpers
    {
        /// <summary>
        /// Provides a fast way to initialize an array from data that is stored in a module.
        /// </summary>
        /// <param name="array">The array to be initialized.</param>
        /// <param name="fldHandle">A field handle that specifies the location of the data used to initialize the array.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void InitializeArray(Array array, RuntimeFieldHandle fldHandle);

        /// <summary>
        /// Boxes a value type.
        /// </summary>
        /// <param name="obj">The value type to be boxed.</param>
        /// <returns>A boxed copy of obj if it is a value class; otherwise, obj itself.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern Object GetObjectValue(Object obj);

        /// <summary>
        /// Runs a specified class constructor method.
        /// </summary>
        /// <param name="type">A type handle that specifies the class constructor method to run.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void RunClassConstructor(RuntimeTypeHandle type);

        /// <summary>
        /// Gets the offset, in bytes, to the data in the given string.
        /// </summary>
        /// <value>
        /// The byte offset, from the start of the String object to the first character in the string.
        /// </value>
        public static extern int OffsetToStringData
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

#if NANOCLR_REFLECTION

        /// <summary>
        /// Returns a value that indicates whether the specified type is a reference type or a value type that contains references or by-refs.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns><see langword="true"/> if the given type is a reference type or a value type that contains references or by-refs; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsReferenceOrContainsReferences<T>() where T : allows ref struct;

#endif

    }

#pragma warning restore S4200 // Native methods should be wrapped
}
