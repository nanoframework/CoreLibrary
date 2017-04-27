//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{

    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    [Serializable()]
    public class WeakReference
    {

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern WeakReference(Object target);

        public extern virtual bool IsAlive
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        public extern virtual Object Target
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;

            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            set;
        }

    }
}
