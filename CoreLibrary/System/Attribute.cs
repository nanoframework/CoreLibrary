//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{

    using System;
    using System.Reflection;
    using System.Collections;

    [Serializable, AttributeUsageAttribute(AttributeTargets.All, Inherited = true, AllowMultiple = false)] // Base class for all attributes
    public abstract class Attribute
    {
        protected Attribute() { }
    }
}
