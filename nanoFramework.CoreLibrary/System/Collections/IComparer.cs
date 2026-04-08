// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Collections
{
    using System;

    /// <summary>
    /// Exposes a method that compares two objects.
    /// </summary>
    public interface IComparer
    {
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x and y, as shown in the following table.
        /// <para>Less than zero : x is less than y.</para>
        /// <para>Zero : x equals y.</para>
        /// <para>Greater than zero : x is greater than y.</para>
        /// </returns>
        int Compare(Object x, Object y);
    }
}
