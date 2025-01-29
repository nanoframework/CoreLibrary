using System.Runtime.CompilerServices;
using nanoFramework.TestFramework;

namespace NFUnitTestAttributes
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
