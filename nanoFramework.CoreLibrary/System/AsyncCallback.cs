// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    /// <summary>
    /// References a method to be called when a corresponding asynchronous operation completes.
    /// </summary>
    /// <param name="ar">The result of the asynchronous operation.</param>
    [Serializable]
    public delegate void AsyncCallback(IAsyncResult ar);

}
