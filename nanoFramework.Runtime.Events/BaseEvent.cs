//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Runtime.Events
{
    /// <summary>
    /// This is a base class from which other nanoFramework event classes derive. 
    /// </summary>
    public class BaseEvent
    {
        /// <summary>
        /// Specifies the source of the event.
        /// </summary>
        public ushort Source;

        /// <summary>
        /// A byte characterizing the event message.
        /// </summary>
        public byte Message;
    }
}
