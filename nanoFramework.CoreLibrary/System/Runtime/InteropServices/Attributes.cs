//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Runtime.InteropServices
{
    /// <summary>
    /// Controls accessibility of an individual managed type or member, or of all types within an assembly, to COM.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, Inherited = false)]
    public sealed class ComVisibleAttribute : Attribute
    {
        internal bool _val;

        /// <summary>
        /// Initializes a new instance of the ComVisibleAttribute class.
        /// </summary>
        /// <param name="visibility">true to indicate that the type is visible to COM; otherwise, false. The default is true.</param>
        public ComVisibleAttribute(bool visibility)
        {
            _val = visibility;
        }

        /// <summary>
        /// Gets a value that indicates whether the COM type is visible.
        /// </summary>
        /// <value>
        /// true if the type is visible; otherwise, false. The default value is true.
        /// </value>
        public bool Value { get { return _val; } }
    }

    /// <summary>
    /// Supplies an explicit System.Guid when an automatic GUID is undesirable.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct | AttributeTargets.Delegate, Inherited = false)]
    public sealed class GuidAttribute : Attribute
    {
        internal String Val;

        /// <summary>
        /// Initializes a new instance of the GuidAttribute class with the specified GUID.
        /// </summary>
        /// <param name="guid">The Guid to be assigned.</param>
        public GuidAttribute(String guid)
        {
            Val = guid;
        }

        /// <summary>
        /// Gets the Guid of the class.
        /// </summary>
        /// <value>
        /// The Guid of the class.
        /// </value>
        public String Value { get { return Val; } }
    }

    /// <summary>
    /// Indicates that data should be marshaled from callee back to caller.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class OutAttribute : Attribute
    {
    }

    /// <summary>
    /// Lets you control the physical layout of the data fields of a class or structure in memory.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class StructLayoutAttribute : Attribute
    {
        internal LayoutKind Val;

        /// <summary>
        /// Initalizes a new instance of the StructLayoutAttribute class with the specified System.Runtime.InteropServices.LayoutKind enumeration member.
        /// </summary>
        /// <param name="layoutKind">One of the enumeration values that specifes how the class or structure should be arranged.</param>
        public StructLayoutAttribute(LayoutKind layoutKind)
        {
            Val = layoutKind;
        }

        /// <summary>
        /// Initalizes a new instance of the StructLayoutAttribute class with the specified System.Runtime.InteropServices.LayoutKind enumeration member.
        /// </summary>
        /// <param name="layoutKind">A 16-bit integer that represents one of the LayoutKind values that specifes how the class or structure should be arranged.</param>
        public StructLayoutAttribute(short layoutKind)
        {
            Val = (LayoutKind)layoutKind;
        }

        /// <summary>
        /// Gets the LayoutKind value that specifies how the class or structure is arranged.
        /// </summary>
        /// <value>
        /// One of the enumeration values that specifies how the class or structure is arranged.
        /// </value>
        public LayoutKind Value { get { return Val; } }

        /// <summary>
        /// Controls the alignment of data fields of a class or structure in memory.
        /// </summary>
        public int Pack;
        /// <summary>
        /// Indicates the absolute size of the class or structure.
        /// </summary>
        public int Size;
        /// <summary>
        /// Indicates whether string data fields within the class should be marshaled as LPWSTR or LPSTR by default.
        /// </summary>
        public CharSet CharSet;
    }
}


