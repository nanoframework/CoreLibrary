//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// Indicates that the COM threading model for an application is single-threaded apartment (STA).
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class STAThreadAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the STAThreadAttribute class.
        /// </summary>
        public STAThreadAttribute()
        {
        }
    }

    /// <summary>
    /// Indicates that the COM threading model for an application is multithreaded apartment (MTA).
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class MTAThreadAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the MTAThreadAttribute class.
        /// </summary>
        public MTAThreadAttribute()
        {
        }
    }
}
