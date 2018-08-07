//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
namespace System
{
    using Reflection;
    using Runtime.CompilerServices;
    /// <summary>
    /// Represents a delegate, which is a data structure that refers to a static method or to a class instance and an instance method of that class.
    /// </summary>
    [Serializable]
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    // GetHashCode() implementation is provided by general native function CLR_RT_HeapBlock::GetHashCode //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    public abstract class Delegate
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {

        /// <summary>
        /// Determines whether the specified object and the current delegate are of the same type and share the same targets, methods, and invocation list.
        /// </summary>
        /// <param name="obj">The object to compare with the current delegate. </param>
        /// <returns>true if obj and the current delegate have the same targets, methods, and invocation list; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern bool Equals(Object obj);

        /// <summary>
        /// Concatenates the invocation lists of two delegates.
        /// </summary>
        /// <param name="a">The delegate whose invocation list comes first. </param>
        /// <param name="b">The delegate whose invocation list comes last. </param>
        /// <returns>A new delegate with an invocation list that concatenates the invocation lists of a and b in that order. Returns a if b is  null reference (Nothing in Visual Basic), returns b if a is a null reference, and returns a null reference if both a and b are null references.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern Delegate Combine(Delegate a, Delegate b);

        /// <summary>
        /// Gets the method represented by the delegate.
        /// </summary>
        /// <value>
        /// A MethodInfo describing the method represented by the delegate.
        /// </value>
        public extern MethodInfo Method
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the class instance on which the current delegate invokes the instance method.
        /// </summary>
        /// <value>
        /// The object on which the current delegate invokes the instance method, if the delegate represents an instance method;  null reference (Nothing in Visual Basic) if the delegate represents a static method.
        /// </value>
        public extern Object Target
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Removes the last occurrence of the invocation list of a delegate from the invocation list of another delegate.
        /// </summary>
        /// <param name="source">The delegate from which to remove the invocation list of value.</param>
        /// <param name="value">The delegate that supplies the invocation list to remove from the invocation list of source.</param>
        /// <returns>A new delegate with an invocation list formed by taking the invocation list of source and removing the last occurrence of the invocation list of value, if the invocation list of value is found within the invocation list of source. Returns source if value is  null reference (Nothing in Visual Basic) or if the invocation list of value is not found within the invocation list of source. Returns a null reference if the invocation list of value is equal to the invocation list of source or if source is a null reference.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern Delegate Remove(Delegate source, Delegate value);

        /// <summary>
        /// Determines whether the specified delegates are equal.
        /// </summary>
        /// <param name="d1">The first delegate to compare.</param>
        /// <param name="d2">The second delegate to compare. </param>
        /// <returns>true if d1 is equal to d2; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool operator ==(Delegate d1, Delegate d2);

        /// <summary>
        /// Determines whether the specified delegates are not equal.
        /// </summary>
        /// <param name="d1">The first delegate to compare.</param>
        /// <param name="d2">The second delegate to compare. </param>
        /// <returns>true if d1 is not equal to d2; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool operator !=(Delegate d1, Delegate d2);
    }
}
