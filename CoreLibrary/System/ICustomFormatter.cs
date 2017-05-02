//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{

    using System;
    public interface ICustomFormatter
    {
        // Interface does not need to be marked with the serializable attribute
        String Format(String format, Object arg, IFormatProvider formatProvider);

    }
}
