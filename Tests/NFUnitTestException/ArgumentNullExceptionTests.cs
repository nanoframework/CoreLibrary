using System;
using nanoFramework.TestFramework;

#nullable enable
namespace NFUnitTestException
{
    [TestClass]
    public class ArgumentNullExceptionTests
    {
        [TestMethod]
        public void ctor_sets_correct_message_with_parameter()
        {
            const string parameter = nameof(ctor_sets_correct_message_with_parameter);
            const string expected = $"Value cannot be null. (Parameter '{parameter}')";

            var ex1 = new ArgumentNullException(parameter);
            var ex2 = new ArgumentNullException(parameter, (string?)null);

            Assert.AreEqual(expected, ex1.Message);
            Assert.AreEqual(expected, ex2.Message);
        }

        [TestMethod]
        public void ctor_sets_correct_message_without_parameter()
        {
            const string expected = "Value cannot be null.";

            var ex1 = new ArgumentNullException();
            var ex2 = new ArgumentNullException(null);
            var ex3 = new ArgumentNullException(null, (Exception?) null);
            var ex4 = new ArgumentNullException((string?) null, (string?) null);

            Assert.AreEqual(expected, ex1.Message);
            Assert.AreEqual(expected, ex2.Message);
            Assert.AreEqual(expected, ex3.Message);
            Assert.AreEqual(expected, ex4.Message);
        }

        [TestMethod]
        public void ThrowIfNullOrEmpty_throws_ArgumentNullException_if_null()
        {
            Assert.ThrowsException(typeof(ArgumentNullException), () => ArgumentNullException.ThrowIfNull(null));
        }
    }
}
