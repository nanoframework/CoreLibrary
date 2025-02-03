// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Threading
{
    //NOTE: If you change the signature here, there is code in COMSynchronization
    //  that invokes this delegate in native.

    /// <summary>
    /// Represents the method that executes on a Thread.
    /// </summary>
    public delegate void ThreadStart();
}
