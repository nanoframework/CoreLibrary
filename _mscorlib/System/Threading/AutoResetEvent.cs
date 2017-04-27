//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Threading
{

    using System;
    using System.Runtime.CompilerServices;
    public sealed class AutoResetEvent : WaitHandle
    {

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public AutoResetEvent(bool initialState);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public bool Reset();
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern public bool Set();
    }
}


