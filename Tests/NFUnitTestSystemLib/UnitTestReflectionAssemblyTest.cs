﻿//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;
using System.Reflection;

namespace NFUnitTestSystemLib
{
    [TestClass]
    class UnitTestReflectionAssemblyTest
    {
        [TestMethod]
        public void AssemblyName_Test1()
        {

            Assembly assm = Assembly.GetExecutingAssembly();

            // we will check that the Name and FullName from the AssemblyName class do go along
            string name = assm.GetName().Name;
            Debug.WriteLine("Assembly name from AssemblyName type is: \"" + name + "\"");
            string fullNameFromAssemblyName = assm.GetName().FullName;
            Debug.WriteLine("Assembly FullNme from AssemblyName type is: \"" + fullNameFromAssemblyName + "\"");

            string nameParsedFromFullName = fullNameFromAssemblyName.Substring(0, fullNameFromAssemblyName.IndexOf(','));
            Assert.Equal(nameParsedFromFullName, name);

            // we will check that the FullName from Assembly and FullName from the AssemblyName class do match
            string fullName = assm.FullName;
            Debug.WriteLine("Assembly FullName from Assembly type: \"" + fullName + "\"");

            Assert.Equal(fullName, (name + ", Version=" + assm.GetName().Version.ToString()));
        }

        [TestMethod]
        public void AssemblyVersion_Test2()
        {
            // get the version
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            Assert.NotNull(ver);
        }

        [TestMethod]
        public void AssemblyVersion_Test3()
        {
            Type myType3 = Type.GetType("System.Int32");

            // get the version
            Assembly assm = Assembly.Load("mscorlib");
            Assert.NotNull(assm);

            string v = assm.GetName().Version.ToString();

            Assembly assm1 = Assembly.Load("mscorlib, Version=" + v);
            Assert.NotNull(assm1);

            Assert.Throws(typeof(ArgumentException), () => { Assembly assm2 = Assembly.Load("mscorlib, <THIS SHOULD NOT BE HERE>,Version=" + v); });

            // Test for extra parameters after assembly version.  The assembly version parser needs to handle this
            // because the VS debugger will identify in CultureInfo and PublicKeyToken when debugging.
            assm = Assembly.Load("mscorlib, Version=" + v + ", CultureInfo=en, PublicKeyToken=null");
            Assert.NotNull(assm);
        }

        [TestMethod]
        public void Assembly_GetAssemblies_Satellite_Test4()
        {
            Assembly asm = typeof(int).Assembly;

            // Make sure satellite assembly can be retrieved
            Assembly res = asm.GetSatelliteAssembly(new System.Globalization.CultureInfo("en"));
            Assert.NotNull(res);

            // Make sure we can get a known type from the target assembly
            Type t = asm.GetType("System.Int32");
            Assert.True(t.IsValueType);

            // make sure all types from the assembly have proper
            // assembly property
            Type[] ts = asm.GetTypes();
            for (int i = 0; i < ts.Length; i++)
            {
                Assert.Equal(ts[i].Assembly.FullName, asm.FullName);
            }
        }

    }
}
