// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Collections
{
    using System;
    /// <summary>
    /// Defines methods to support the comparison of objects for equality.
    /// </summary>
    public interface IEqualityComparer
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        bool Equals(Object x, Object y);

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The Object for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        int GetHashCode(Object obj);
    }
}
