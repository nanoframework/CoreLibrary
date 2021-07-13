//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.IO
{
    /// <summary>
    /// Specifies the position in a stream to use for seeking.
    /// </summary>
    /// <remarks>These constants match Win32's FILE_BEGIN, FILE_CURRENT, and FILE_END</remarks>
    [Serializable]
    public enum SeekOrigin
    {
        /// <summary>
        /// Specifies the beginning of a stream.
        /// </summary>
        Begin = 0,
        /// <summary>
        /// Specifies the current position within a stream.
        /// </summary>
        Current = 1,
        /// <summary>
        /// Specifies the end of a stream.
        /// </summary>
        End = 2,
    }
}
