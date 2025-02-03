// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System
{

    /// <summary>
    /// Indicates that a field of a serializable class should not be serialized. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    [ExcludeType]
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
