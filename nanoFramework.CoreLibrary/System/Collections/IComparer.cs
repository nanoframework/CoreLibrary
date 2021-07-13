//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

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
