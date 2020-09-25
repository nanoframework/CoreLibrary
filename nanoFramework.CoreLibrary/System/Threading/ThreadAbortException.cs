//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Threading
{
    using System;

    /// <summary>
    /// The exception that is thrown when a call is made to the Abort method. This class cannot be inherited.
    /// </summary>
    [Serializable]
    public sealed class ThreadAbortException : SystemException
    {
        private ThreadAbortException() { }
    }
}
