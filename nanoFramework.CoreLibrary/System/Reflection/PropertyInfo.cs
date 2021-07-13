//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using System;
    using Runtime.CompilerServices;

    /// <summary>
    /// Discovers the attributes of a property and provides access to property metadata.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [Serializable]
    public abstract class PropertyInfo : MemberInfo
    {
        /// <summary>
        /// Gets the type of this property.
        /// </summary>
        /// <value>
        /// The type of this property.
        /// </value>
        public abstract Type PropertyType
        {
            get;
        }

        /// <summary>
        /// Returns the property value of a specified object with optional index values for indexed properties.
        /// </summary>
        /// <param name="obj">The object whose property value will be returned.</param>
        /// <param name="index">Optional index values for indexed properties. The indexes of indexed properties are zero-based. This value should be null for non-indexed properties.</param>
        /// <returns>The property value of the specified object.</returns>
        [Diagnostics.DebuggerStepThrough]
        [Diagnostics.DebuggerHidden]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public virtual extern Object GetValue(Object obj, Object[] index);

        /// <summary>
        /// Sets the property value of a specified object with optional index values for index properties.
        /// </summary>
        /// <param name="obj">The object whose property value will be set.</param>
        /// <param name="value">The new property value.</param>
        /// <param name="index">Optional index values for indexed properties. This value should be null for non-indexed properties.</param>
        [Diagnostics.DebuggerStepThrough]
        [Diagnostics.DebuggerHidden]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public virtual extern void SetValue(Object obj, Object value, Object[] index);
    }
}

#endif // NANOCLR_REFLECTION
