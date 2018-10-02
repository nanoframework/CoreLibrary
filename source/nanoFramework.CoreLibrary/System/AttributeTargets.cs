//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// Specifies the application elements on which it is valid to apply an attribute.
    /// </summary>
    [Flags, Serializable]
    public enum AttributeTargets
    {
        /// <summary>
        /// Attribute can be applied to an assembly.
        /// </summary>
        Assembly = 0x0001,
        /// <summary>
        /// Attribute can be applied to a module.
        /// </summary>
        Module = 0x0002,
        /// <summary>
        /// Attribute can be applied to a class.
        /// </summary>
        Class = 0x0004,
        /// <summary>
        /// Attribute can be applied to a structure; that is, a value type.
        /// </summary>
        Struct = 0x0008,
        /// <summary>
        /// Attribute can be applied to an enumeration.
        /// </summary>
        Enum = 0x0010,
        /// <summary>
        /// Attribute can be applied to a constructor.
        /// </summary>
        Constructor = 0x0020,
        /// <summary>
        /// Attribute can be applied to a method.
        /// </summary>
        Method = 0x0040,
        /// <summary>
        /// Attribute can be applied to a property.
        /// </summary>
        Property = 0x0080,
        /// <summary>
        /// Attribute can be applied to a field.
        /// </summary>
        Field = 0x0100,
        /// <summary>
        /// Attribute can be applied to an event.
        /// </summary>
        Event = 0x0200,
        /// <summary>
        /// Attribute can be applied to an interface.
        /// </summary>
        Interface = 0x0400,
        /// <summary>
        /// Attribute can be applied to a parameter.
        /// </summary>
        Parameter = 0x0800,
        /// <summary>
        /// Attribute can be applied to a delegate.
        /// </summary>
        Delegate = 0x1000,
        /// <summary>
        /// Attribute can be applied to a return value.
        /// </summary>
        ReturnValue = 0x2000,
        /// <summary>
        /// Attribute can be applied to any application element.
        /// </summary>
        All = Assembly | Module | Class | Struct | Enum | Constructor |
                        Method | Property | Field | Event | Interface | Parameter | Delegate | ReturnValue,
    }
}
