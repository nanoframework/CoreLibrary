//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Reflection
{
    using System;
    using Runtime.CompilerServices;

    /// <summary>
    /// Discovers the attributes of a field and provides access to field metadata.
    /// </summary>
    [Serializable]
    public abstract class FieldInfo : MemberInfo
    {

        /// <summary>
        /// Gets a MemberTypes value indicating that this member is a field.
        /// </summary>
        /// <value>
        /// A MemberTypes value indicating that this member is a field.
        /// </value>
        public override MemberTypes MemberType
        {
            get
            {
                return MemberTypes.Field;
            }
        }

        /// <summary>
        /// Gets the type of this field object.
        /// </summary>
        /// <value>
        /// The type of this field object.
        /// </value>
        public abstract Type FieldType
        {
            get;
        }

        /// <summary>
        /// When overridden in a derived class, returns the value of a field supported by a given object.
        /// </summary>
        /// <param name="obj">The object whose field value will be returned.</param>
        /// <returns>An object containing the value of the field reflected by this instance.</returns>
        [Diagnostics.DebuggerStepThrough]
        [Diagnostics.DebuggerHidden]
        public abstract object GetValue(object obj);

        /// <summary>
        /// Sets the value of the field supported by the given object.
        /// </summary>
        /// <param name="obj">The object whose field value will be set.</param>
        /// <param name="value">The value to assign to the field.</param>
        [Diagnostics.DebuggerStepThrough]
        [Diagnostics.DebuggerHidden]
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public virtual extern void SetValue(Object obj, Object value);
    }
}


