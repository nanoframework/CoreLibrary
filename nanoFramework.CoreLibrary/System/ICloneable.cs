// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    /// <summary>
    /// Defines an interface indicating that an object may be cloned.
    /// </summary>
    public interface ICloneable
    {
        /// <summary>
        /// Make a new object which is a copy of the object instanced.
        /// </summary>
        /// <returns>A new object that represents a clone of the object.</returns>
        Object Clone();
    }
}
