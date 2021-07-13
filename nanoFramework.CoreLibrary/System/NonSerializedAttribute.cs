//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{

    /// <summary>
    /// Indicates that a field of a serializable class should not be serialized. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class NonSerializedAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the NonSerializedAttribute class.
        /// </summary>
        public NonSerializedAttribute()
        {
        }
    }
}
