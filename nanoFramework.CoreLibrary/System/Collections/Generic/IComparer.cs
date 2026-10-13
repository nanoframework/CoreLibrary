// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

namespace System.Collections.Generic
{
    /// <summary>
    /// Defines a method that a type implements to compare two objects.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare. This type parameter is contravariant. That is, you can use either the type you specified or any type that is less derived.</typeparam>
    public interface IComparer<in T> where T : allows ref struct
    {
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns></returns>
        int Compare(T? x, T? y);
    }
}
