//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Runtime.CompilerServices;
    /// <summary>
    /// Represents a weak reference, which references an object while still allowing that object to be reclaimed by garbage collection.
    /// </summary>
    [Serializable]
    public class WeakReference
    {
        /// <summary>
        /// Initializes a new instance of the WeakReference class, referencing the specified object.
        /// </summary>
        /// <param name="target">The object to track or null.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern WeakReference(Object target);

        /// <summary>
        /// Gets an indication whether the object referenced by the current WeakReference object has been garbage collected.
        /// </summary>
        /// <value>true if the object referenced by the current WeakReference object has not been garbage collected and is still accessible; otherwise, false.</value>
        public virtual extern bool IsAlive
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets or sets the object (the target) referenced by the current WeakReference object.
        /// </summary>
        /// <value>null if the object referenced by the current WeakReference object has been garbage collected; otherwise, a reference to the object referenced by the current WeakReference object.</value>
        public virtual extern Object Target
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;

            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

    }
}
