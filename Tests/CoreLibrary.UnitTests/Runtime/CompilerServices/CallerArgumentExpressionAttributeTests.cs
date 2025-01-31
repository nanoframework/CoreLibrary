// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;
using nanoFramework.TestFramework;

namespace CoreLibrary.UnitTests.Runtime.CompilerServices
{
    [TestClass]
    public class CallerArgumentExpressionAttributeTests
    {
        public string Field = "Field value";

        public string Property => "Property value";

        [TestMethod]
        public void CallerArgumentExpressionSetsParameterNameFromField()
        {
            var sut = new CallerArgumentExpressionAttributeTests();
            const string expect = "sut.Field";
            var actual = TestCallerArgumentExpression(sut.Field);

            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void CallerArgumentExpressionSetsParameterNameFromMethodParameter()
        {
            const string expect = "methodParameter";
            var actual = TestMethodParameter("Method parameter value");

            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void CallerArgumentExpressionSetsParameterNameFromNull()
        {
            const string expect = "null";
            var actual = TestCallerArgumentExpression(null);

            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void CallerArgumentExpressionSetsParameterNameFromProperty()
        {
            var sut = new CallerArgumentExpressionAttributeTests();
            const string expect = "sut.Property";
            var actual = TestCallerArgumentExpression(sut.Property);

            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void CallerArgumentExpressionSetsParameterNameFromVariable()
        {
            const string variableName = "Variable value";
            const string expect = nameof(variableName);
            var actual = TestCallerArgumentExpression(variableName);

            Assert.AreEqual(expect, actual);
        }

        // ReSharper disable once EntityNameCapturedOnly.Local
#pragma warning disable IDE0060
        private static string TestCallerArgumentExpression(object objectValue, [CallerArgumentExpression(nameof(objectValue))] string parameterName = null) => parameterName;
#pragma warning restore IDE0060

        private static string TestMethodParameter(string methodParameter) => TestCallerArgumentExpression(methodParameter);
    }
}
