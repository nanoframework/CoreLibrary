//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Threading
{
    //NOTE: If you change the signature here, there is code in COMSynchronization
    //  that invokes this delegate in native.

    /// <summary>
    /// Represents the method that executes on a Thread.
    /// </summary>
    public delegate void ThreadStart();
}


