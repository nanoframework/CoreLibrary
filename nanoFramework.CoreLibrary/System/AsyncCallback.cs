//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// References a method to be called when a corresponding asynchronous operation completes.
    /// </summary>
    /// <param name="ar">The result of the asynchronous operation.</param>
    [Serializable]
    public delegate void AsyncCallback(IAsyncResult ar);

}
