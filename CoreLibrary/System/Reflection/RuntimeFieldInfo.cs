//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Reflection
{
    using System;
    using Runtime.CompilerServices;

    [Serializable]
    internal sealed class RuntimeFieldInfo : FieldInfo
    {
        public override extern String Name
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        public override extern Type DeclaringType
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        public override extern Type FieldType
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public override extern Object GetValue(Object obj);
    }
}


