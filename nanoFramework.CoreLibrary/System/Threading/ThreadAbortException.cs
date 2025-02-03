// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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
