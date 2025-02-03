// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;
using nanoFramework.TestFramework;

namespace NFUnitTestAttributes.Runtime.CompilerServices
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
