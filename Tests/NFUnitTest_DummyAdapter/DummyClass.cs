//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Diagnostics;
using System.Threading;

namespace NFUnitTestAdapater
{
    public class DummyClass
    {
        public void DummyMethod()
        {
            //////////////////////////////////////////////////////////////////////
            // This is just to get the TestAdapter. DO NOT remove this project! //
            //////////////////////////////////////////////////////////////////////
            
            // do something here so the method isn't removed on Release build
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
