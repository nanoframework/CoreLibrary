//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using System.Reflection;
    using System.Collections;
    using System.Runtime.CompilerServices;

    [Serializable]
    public abstract class Enum : ValueType
    {

        public override String ToString()
        {
            Type eT = this.GetType();
            FieldInfo fi = eT.GetField("value__");
            object obj = fi.GetValue(this);

            return obj.ToString();
        }

    }
}
