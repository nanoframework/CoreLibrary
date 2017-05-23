//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Runtime.CompilerServices;

    /// <summary>
    /// Supports all classes in the .NET Framework class hierarchy and provides low-level services to derived classes. This is the ultimate base class of all classes in the .NET Framework; it is the root of the type hierarchy.
    /// </summary>
    [Serializable]
    public class Object
    {
        /// <summary>
        /// Initializes a new instance of the Object class.
        /// </summary>
        [Diagnostics.DebuggerHidden]
        public Object()
        {
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public virtual String ToString()
        {
            return GetType().FullName;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">he object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public virtual extern bool Equals(Object obj);

        /// <summary>
        /// Determines whether the specified object instances are considered equal.
        /// </summary>
        /// <param name="objA">The first object to compare.</param>
        /// <param name="objB">The second object to compare.</param>
        /// <returns>true if the objects are considered equal; otherwise, false. If both objA and objB are null, the method returns true.</returns>
        public static bool Equals(Object objA, Object objB)
        {
            if (objA == objB)
            {
                return true;
            }

            if (objA == null || objB == null)
            {
                return false;
            }

            return objA.Equals(objB);
        }

        /// <summary>
        /// Determines whether the specified Object instances are the same instance.
        /// </summary>
        /// <param name="objA">The first object to compare.</param>
        /// <param name="objB">The second object to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null; otherwise, false.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern bool ReferenceEquals(Object objA, Object objB);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public virtual extern int GetHashCode();

        /// <summary>
        /// Gets the Type of the current instance.
        /// </summary>
        /// <returns>The exact runtime type of the current instance.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern Type GetType();

        /// <summary>
        /// Creates a shallow copy of the current Object.
        /// </summary>
        /// <returns>A shallow copy of the current Object.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        protected extern Object MemberwiseClone();

    }
}
