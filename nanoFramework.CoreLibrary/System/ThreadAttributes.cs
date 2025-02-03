// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Indicates that the COM threading model for an application is single-threaded apartment (STA).
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    [ExcludeFromStubs]
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
    [ExcludeFromStubs]
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
