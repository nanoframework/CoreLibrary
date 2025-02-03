// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

[module: CLSCompliant(true)]

class NS_TestClass_attribute_02
{
    public void printClassName()
    {
        OutputHelper.WriteLine("Class A");
    }

    static void Main_old() { }

    public static bool testMethod()
    {
        Main_old();
        return true;
    }
}