//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
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
