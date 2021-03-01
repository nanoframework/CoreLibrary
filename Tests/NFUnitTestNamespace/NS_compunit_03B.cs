//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
using System.Diagnostics;

class NS_TestClass_compunit_03B
{
    public void printClassName()
    {
        NS_TestClass_compunit_03 cC = new NS_TestClass_compunit_03();
        cC.showName();
    }

    public void showName()
    {
        Debug.WriteLine("Class B");
    }
}
