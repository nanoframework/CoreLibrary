// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices
{
    /// <summary>
    /// Controls the layout of an object when exported to unmanaged code.
    /// </summary>
    [ExcludeFromStubs]
    [Serializable]
    public enum LayoutKind
    {
        /// <summary>
        /// The members of the object are laid out sequentially, in the order in which they appear when exported to unmanaged memory. 
        /// The members are laid out according to the packing specified in StructLayoutAttribute.Pack, and can be noncontiguous.
        /// </summary>
        Sequential = 0,
        /// <summary>
        /// The precise position of each member of an object in unmanaged memory is explicitly controlled, subject to the setting of the StructLayoutAttribute.Pack field. 
        /// Each member must use the FieldOffsetAttribute to indicate the position of that field within the type.
        /// </summary>
        Explicit = 2,
        /// <summary>
        /// The runtime automatically chooses an appropriate layout for the members of an object in unmanaged memory. 
        /// Objects defined with this enumeration member cannot be exposed outside of managed code. Attempting to do so generates an exception.
        /// </summary>
        Auto = 3
    }
}
