//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Runtime.Events
{
    /// <summary>
    /// Provides an interface to use as the basis of event listeners.
    /// </summary>
    public interface IEventListener
    {
        /// <summary>
        /// Initializes an event listener so that it listens to events from a particular source.
        /// </summary>
        void InitializeForEventSource();

        /// <summary>
        /// Reacts to an event.
        /// </summary>
        /// <param name="ev">Holds the event that occurred.</param>
        /// <returns><code>true</code> if the event was processed, or <code>false</code> if not. </returns>
        bool OnEvent(BaseEvent ev);
    }
}
