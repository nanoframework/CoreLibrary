//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Runtime.CompilerServices;

    /// <summary>
    /// Provides the base class for value types.
    /// </summary>
    [Serializable]
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    // GetHashCode() implementation is provided by general native function CLR_RT_HeapBlock::GetHashCode //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
#pragma warning disable S1206 // "Equals(Object)" and "GetHashCode()" should be overridden in pairs
    public abstract class ValueType
#pragma warning restore S1206 // "Equals(Object)" and "GetHashCode()" should be overridden in pairs
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>true if obj and this instance are the same type and represent the same value; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern bool Equals(Object obj);
    }
}
