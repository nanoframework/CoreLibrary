//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Runtime.Events
{
    /// <summary>
    /// A multicast (combinable) delegate that defines the event handler for a native event.
    /// </summary>
    /// <param name="data1">First parameter (can be the port).</param>
    /// <param name="data2">First parameter (can be the port).</param>
    /// <param name="time">Time of the event.</param>
    public delegate void NativeEventHandler(uint data1, uint data2, DateTime time);

    /// <summary>
    /// Initializes a new instance of the <see cref="NativeEventDispatcher"/> class.
    /// </summary>
    public class NativeEventDispatcher : IDisposable
    {
        /// <summary>
        /// The event handler for this <see cref="NativeEventDispatcher"/> object (a mulitcast combinable delegate).
        /// </summary>
        protected NativeEventHandler threadSpawn = null;

        /// <summary>
        /// The event handler for this <see cref="NativeEventDispatcher"/> object (a mulitcast combinable delegate).
        /// </summary>
        protected NativeEventHandler callbacks = null;

        /// <summary>
        /// Set to <code>true</code> if this <see cref="NativeEventDispatcher"/> object has been disposed, or <code>false</code> if not.
        /// </summary>
        protected bool disposed = false;

        // this field is required in native so need to be kept here
        #pragma warning disable 169
        private object _NativeEventDispatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeEventDispatcher"/> class.
        /// </summary>
        /// <param name="driverName">The name of a registered driver.</param>
        /// <param name="driverData">Driver data to be used when initializing the driver.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern public NativeEventDispatcher(string driverName, ulong driverData);

        /// <summary>
        /// Enables the interrupt for this <see cref="NativeEventDispatcher "/> object.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern public virtual void EnableInterrupt();

        /// <summary>
        /// Disables the interrupt for this <see cref="NativeEventDispatcher"/> object.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern public virtual void DisableInterrupt();

        /// <summary>
        /// Releases resources used by this <see cref="NativeEventDispatcher"/> object.
        /// </summary>
        /// <param name="disposing"><code>true</code> if in the process of disposing, or <code>false</code> otherwise.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern protected virtual void Dispose(bool disposing);

        //--//

        #pragma warning disable 1591
        ~NativeEventDispatcher()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases resources used by this <see cref="NativeEventDispatcher"/> object.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Dispose()
        {
            if (!disposed)
            {
                Dispose(true);

                GC.SuppressFinalize(this);

                disposed = true;
            }
        }

        /// <summary>
        /// Adds or removes callback methods for native events.
        /// </summary>
        /// <remarks>Applications can subscribe to this event to be notified when an interrupt event occurs.</remarks>
        public event NativeEventHandler OnInterrupt
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                if (disposed)
                {
                    throw new ObjectDisposedException();
                }

                NativeEventHandler callbacksOld = callbacks;
                NativeEventHandler callbacksNew = (NativeEventHandler)Delegate.Combine(callbacksOld, value);

                try
                {
                    callbacks = callbacksNew;

                    if (callbacksNew != null)
                    {
                        if (callbacksOld == null)
                        {
                            EnableInterrupt();
                        }

                        if (callbacksNew.Equals(value) == false)
                        {
                            callbacksNew = new NativeEventHandler(this.MultiCastCase);
                        }
                    }

                    threadSpawn = callbacksNew;
                }
                catch
                {
                    callbacks = callbacksOld;

                    if (callbacksOld == null)
                    {
                        DisableInterrupt();
                    }

                    throw;
                }
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                if (disposed)
                {
                    throw new ObjectDisposedException();
                }

                NativeEventHandler callbacksOld = callbacks;
                NativeEventHandler callbacksNew = (NativeEventHandler)Delegate.Remove(callbacksOld, value);

                try
                {
                    callbacks = callbacksNew;

                    if (callbacksNew == null && callbacksOld != null)
                    {
                        DisableInterrupt();
                    }
                }
                catch
                {
                    callbacks = callbacksOld;

                    throw;
                }
            }
        }

        private void MultiCastCase(uint port, uint state, DateTime time)
        {
            callbacks?.Invoke(port, state, time);
        }
    }
}
