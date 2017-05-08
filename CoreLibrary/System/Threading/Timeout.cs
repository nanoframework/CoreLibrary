//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Threading
{
    using System.Threading;
    using System;
    //
    // A constant used by methods that take a timeout (Object.Wait, Thread.Sleep
    // etc) to indicate that no timeout should occur.
    //
    // this should become an enum.
    //
    // This class has only static members and does not require serialization.
    public static class Timeout
    {
        public const int Infinite = -1;
    }

}


