//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// Represents the base class for custom attributes.
    /// </summary>
    [Serializable, AttributeUsageAttribute(AttributeTargets.All)] // Base class for all attributes
    public abstract class Attribute
    {
        /// <summary>
        /// Initializes a new instance of the Attribute class.
        /// </summary>
        protected Attribute() { }
    }
}
