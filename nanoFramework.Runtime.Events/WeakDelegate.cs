//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace nanoFramework.Runtime.Events
{
    /// <summary>
    /// Provides methods for combining and removing "weak" delegates. 
    /// </summary>
    /// <remarks>When instances of the WeakDelegate class are created, the object references in the delegate list are treated like WeakReference objects. 
    /// This means that these object references are prone to garbage collection even if they are still targets in the list of delegates. 
    /// When such object references are collected as garbage, they are automatically removed from the list of delegates.
    /// </remarks>
    public static class WeakDelegate
    {
        /// <summary>
        /// Concatenates the invocation lists of two multicast (combinable) delegates. 
        /// </summary>
        /// <param name="a">The combinable delegate whose invocation list comes first.</param>
        /// <param name="b">The combinable delegate whose invocation list comes second.</param>
        /// <returns>A new combinable delegate with an invocation list that concatenates the invocation lists of the a and b parameters, in that order. 
        /// If b is a null reference, this method returns a. 
        /// If a is a null reference, this method returns b. 
        /// If both a and b are null references, this method returns null. </returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static public System.Delegate Combine(System.Delegate a, System.Delegate b);

        /// <summary>
        /// Removes the invocation list of a specified delegate from the invocation list of another specified delegate. 
        /// </summary>
        /// <param name="a">The delegate from which the invocation list is to be removed.</param>
        /// <param name="b">The delegate that supplies the invocation list to be removed from the delegate specified in a.</param>
        /// <returns>A new delegate with an invocation list formed by taking the invocation list of the a parameter and removing the invocation list of the b parameter, if b's invocation list is found in a's invocation list.
        /// If b is a null reference, or if b's invocation list is not found in a's invocation list, this method returns a. 
        /// If b's invocation list is equal to a's invocation list, or if b is a null reference, this method returns null.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static public System.Delegate Remove(System.Delegate a, System.Delegate b);
    }
}
