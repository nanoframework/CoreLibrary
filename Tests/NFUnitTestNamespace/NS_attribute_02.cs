//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Diagnostics;

[module: CLSCompliant(true)]

class NS_TestClass_attribute_02
{
    public void printClassName()
    {
        Debug.WriteLine("Class A");
    }

    static void Main_old() { }

    public static bool testMethod()
    {
        Main_old();
        return true;
    }
}