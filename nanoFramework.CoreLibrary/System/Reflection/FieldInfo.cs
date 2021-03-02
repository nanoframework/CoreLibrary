//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using Runtime.CompilerServices;
    using System;

    /// <summary>
    /// Discovers the attributes of a field and provides access to field metadata.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
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
        [MethodImpl(MethodImplOptions.InternalCall)]
        public virtual extern void SetValue(Object obj, Object value);

        /// <summary>
        /// When overridden in a derived class, returns an array of all custom attributes applied to this member.
        /// </summary>
        /// <param name="inherit"><c>true</c> to search this member's inheritance chain to find the attributes; otherwise, <c>false</c>. This parameter is ignored for properties and events.</param>
        /// <returns>An array that contains all the custom attributes applied to this member, or an array with zero elements if no attributes are defined.</returns>
        /// <remarks>This method ignores the inherit parameter for properties and events.</remarks>
        public override object[] GetCustomAttributes(bool inherit)
        {
            return CustomAttributesHelpers.GetCustomAttributesInternal(GetCustomAttributesNative(inherit));
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern object[] GetCustomAttributesNative(bool inherit);
    }
}

#endif // NANOCLR_REFLECTION
