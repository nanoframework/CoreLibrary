// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;
using nanoFramework.TestFramework;

<<<<<<<< HEAD:Tests/NFUnitTestAttributes/Runtime/CompilerServices/CallerMemberNameAttributeTests.cs
namespace NFUnitTestAttributes.Runtime.CompilerServices
========
namespace CoreLibrary.UnitTests.Runtime.CompilerServices
>>>>>>>> 5a6a39b (Add unit tests for new nullable attributes):Tests/CoreLibrary.UnitTests/Runtime/CompilerServices/CallerMemberNameAttributeTests.cs
{
    [TestClass]
    public class CallerMemberNameAttributeTests
    {
        [TestMethod]
        public void CallerMemberNameAttributeGetsCallerMemberName()
        {
            const string expect = nameof(CallerMemberNameAttributeGetsCallerMemberName);
            var actual = TestCallerMemberName();

            Assert.AreEqual(expect, actual);
        }

        // ReSharper disable once EntityNameCapturedOnly.Local
#pragma warning disable IDE0060
        private static string TestCallerMemberName([CallerMemberName] string memberName = null) => memberName;
#pragma warning restore IDE0060
    }
}
