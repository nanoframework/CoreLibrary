// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    /// <summary>
    /// The exception that is thrown when a feature does not run on a particular platform.
    /// </summary>
    [Serializable]
    public class PlatformNotSupportedException : NotSupportedException
    {
        /// <summary>
        /// Initializes a new instance of the ArgumentNullException class.
        /// </summary>
        public PlatformNotSupportedException()
        { }
    }
}
