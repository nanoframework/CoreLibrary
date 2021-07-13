//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Runtime.CompilerServices;

    /// <summary>
    /// Represents a multicast delegate; that is, a delegate that can have more than one element in its invocation list.
    /// </summary>
    [Serializable]
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    // GetHashCode() implementation is provided by general native function CLR_RT_HeapBlock::GetHashCode //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
#pragma warning disable S1206 // "Equals(Object)" and "GetHashCode()" should be overridden in pairs
    public abstract class MulticastDelegate : Delegate
#pragma warning restore S1206 // "Equals(Object)" and "GetHashCode()" should be overridden in pairs
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {

        /// <summary>
        /// Determines whether two MulticastDelegate objects are equal.
        /// </summary>
        /// <param name="d1">The left operand.</param>
        /// <param name="d2">The right operand.</param>
        /// <returns>true if d1 and d2 have the same invocation lists; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool operator ==(MulticastDelegate d1, MulticastDelegate d2);

        /// <summary>
        /// Determines whether two MulticastDelegate objects are not equal.
        /// </summary>
        /// <param name="d1">The left operand.</param>
        /// <param name="d2">The right operand.</param>
        /// <returns>rue if d1 and d2 do not have the same invocation lists; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool operator !=(MulticastDelegate d1, MulticastDelegate d2);

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <param name="obj">A 32-bit signed integer hash code.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
