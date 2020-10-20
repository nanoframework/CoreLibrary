//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Runtime.CompilerServices
{
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
    }
}
