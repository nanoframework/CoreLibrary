//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Runtime.Events
{
    /// <summary>
    /// Constitutes the base class for classes that contain event data. 
    /// </summary>
    /// <remarks>
    /// This class contains no event data; it is used by events that do not pass state information to an event handler when an event is raised. 
    /// If the event handler requires state information, the application must derive a class from this class to hold the data.
    /// </remarks>
    public class EventArgs
    {
        /// <summary>
        /// Gets an empty, read-only <see cref="EventArgs"/> object. 
        /// </summary>
        public static readonly EventArgs Empty = new EventArgs();
    }
}
