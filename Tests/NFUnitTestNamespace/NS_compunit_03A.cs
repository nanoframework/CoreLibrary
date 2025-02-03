// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

class NS_TestClass_compunit_03A
{
    public void printClassName()
    {
        NS_TestClass_compunit_03B cB = new NS_TestClass_compunit_03B();
        cB.showName();
    }

    public void showName()
    {
        OutputHelper.WriteLine("Class A");
    }
}