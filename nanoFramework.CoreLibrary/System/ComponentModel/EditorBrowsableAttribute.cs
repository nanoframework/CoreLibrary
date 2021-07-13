//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
namespace System.ComponentModel
{
    using System;

    /// <summary>
    /// Specifies the browsable state of a property or method from within an editor.
    /// </summary>
    public enum EditorBrowsableState
    {
        /// <summary>
        /// The property or method is always browsable from within an editor.
        /// </summary>
        Always,
        /// <summary>
        /// The property or method is never browsable from within an editor.
        /// </summary>
        Never,
        /// <summary>
        /// The property or method is a feature that only advanced users should see. An editor can either show or hide such properties.
        /// </summary>
        Advanced
    }

    /// <summary>
    /// Specifies that a property or method is viewable in an editor. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    // GetHashCode() implementation is provided by general native function CLR_RT_HeapBlock::GetHashCode //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
#pragma warning disable S1206 // "Equals(Object)" and "GetHashCode()" should be overridden in pairs
    public sealed class EditorBrowsableAttribute : Attribute
#pragma warning restore S1206 // "Equals(Object)" and "GetHashCode()" should be overridden in pairs
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        private readonly EditorBrowsableState _browsableState;

        /// <summary>
        /// Initializes a new instance of the EditorBrowsableAttribute class with State set to the default state.
        /// </summary>
        public EditorBrowsableAttribute() : this(EditorBrowsableState.Always) { }

        /// <summary>
        /// Initializes a new instance of the EditorBrowsableAttribute class with an EditorBrowsableState.
        /// </summary>
        /// <param name="state">The EditorBrowsableState to set State to.</param>
        public EditorBrowsableAttribute(EditorBrowsableState state)
        {
            _browsableState = state;
        }

        /// <summary>
        /// Returns whether the value of the given object is equal to the current EditorBrowsableAttribute.
        /// </summary>
        /// <param name="obj">The object to test the value equality of.</param>
        /// <returns>true if the value of the given object is equal to that of the current; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == this) return true;

            var attribute1 = obj as EditorBrowsableAttribute;
            if (attribute1 != null) return (attribute1._browsableState == _browsableState);

            return false;
        }

        /// <summary>
        /// Gets the browsable state of the property or method.
        /// </summary>
        /// <value>An EditorBrowsableState that is the browsable state of the property or method.</value>
        public EditorBrowsableState State
        {
            get
            {
                return _browsableState;
            }
        }
    }
}
