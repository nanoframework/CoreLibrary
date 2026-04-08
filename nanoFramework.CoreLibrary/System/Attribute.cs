// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    /// <summary>
    /// Represents the base class for custom attributes.
    /// </summary>
    [Serializable, AttributeUsage(AttributeTargets.All)] // Base class for all attributes
    public abstract class Attribute
    {
        /// <summary>
        /// Initializes a new instance of the Attribute class.
        /// </summary>
        protected Attribute() { }
    }
}
