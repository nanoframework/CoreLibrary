//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{

    using System;
    [Serializable()]
    public class InvalidOperationException : SystemException
    {
        public InvalidOperationException()
            : base()
        {
        }

        public InvalidOperationException(String message)
            : base(message)
        {
        }

        public InvalidOperationException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
