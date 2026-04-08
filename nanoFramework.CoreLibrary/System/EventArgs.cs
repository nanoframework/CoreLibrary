// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    /// <summary>
    /// Represents the base class for classes that contain event data, and provides a value to use for events that do not include event data.
    /// </summary>
    public class EventArgs
    {
        /// <summary>
        /// Provides a value to use with events that do not have event data.
        /// </summary>
        public static readonly EventArgs Empty = new EventArgs();

        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgs"/> class.
        /// </summary>
        public EventArgs()
        {
        }
    }
}
