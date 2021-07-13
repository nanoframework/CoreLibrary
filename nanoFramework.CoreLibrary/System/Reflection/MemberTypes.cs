//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using System;

    /// <summary>
    /// Marks each type of member that is defined as a derived class of MemberInfo.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [Serializable]
    public enum MemberTypes
    {
        /// <summary>
        /// Specifies that the member is a constructor
        /// </summary>
        Constructor = 0x01,
        /// <summary>
        /// Specifies that the member is an event
        /// </summary>
        Event = 0x02,
        /// <summary>
        /// Specifies that the member is a field
        /// </summary>
        Field = 0x04,
        /// <summary>
        /// Specifies that the member is a method
        /// </summary>
        Method = 0x08,
        /// <summary>
        /// Specifies that the member is a property
        /// </summary>
        Property = 0x10,
        /// <summary>
        /// Specifies that the member is a type
        /// </summary>
        TypeInfo = 0x20,
        /// <summary>
        /// Specifies that the member is a custom member type
        /// </summary>
        Custom = 0x40,
        /// <summary>
        /// Specifies that the member is a nested type
        /// </summary>
        NestedType = 0x80,
        /// <summary>
        /// Specifies all member types.
        /// </summary>
        All = Constructor | Event | Field | Method | Property | TypeInfo | NestedType,
    }
}

#endif // NANOCLR_REFLECTION
