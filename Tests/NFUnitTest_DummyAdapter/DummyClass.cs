//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Diagnostics;

namespace NFUnitTestAdapater
{
    public class DummyClass
    {
        public void DummyMethod()
        {
            Debug.WriteLine("This is just to get the TestAdapter. Don not remove this project!");
        }
    }
}
