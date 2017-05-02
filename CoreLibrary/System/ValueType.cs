//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    [Serializable]
    public abstract class ValueType
    {

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern override bool Equals(Object obj);

    }
}
