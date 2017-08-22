//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Runtime.Events
{
    /// <summary>
    /// Provides an interface to use as the basis of event processors.
    /// </summary>
    public interface IEventProcessor
    {
        /// <summary>
        /// Processes an event
        /// IEventProcessor should return null if it cannot process an event,
        /// in that case next processor will be given an opportunity.
        /// </summary>
        /// <param name="data1">Holds event-specific data.</param>
        /// <param name="data2">Holds event-specific data.</param>
        /// <param name="time">Contains the time stamp for the event.</param>
        /// <returns>The event that was processed, or null if the event can't be processed.</returns>
        /// <remarks>In the event that the processor cannot process an event, IEventProcessor should return null.
        /// In that case next processor will be given an opportunity.</remarks>
        BaseEvent ProcessEvent(uint data1, uint data2, DateTime time);
    }
}
