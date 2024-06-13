//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;

[assembly: CLSCompliant(true)]

class NS_TestClass_attribute_01
{
	public void printClassName()
	{
		OutputHelper.WriteLine("Class A");
	}

	static void Main_old() {}

    public static bool testMethod()
    {
        Main_old();
        return true;
    }
}