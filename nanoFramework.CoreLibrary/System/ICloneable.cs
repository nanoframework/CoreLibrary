//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

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
