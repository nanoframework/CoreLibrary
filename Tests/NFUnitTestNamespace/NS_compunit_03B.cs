// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

class NS_TestClass_compunit_03B
{
    public void printClassName()
    {
        NS_TestClass_compunit_03 cC = new NS_TestClass_compunit_03();
        cC.showName();
    }

    public void showName()
    {
        OutputHelper.WriteLine("Class B");
    }
}
