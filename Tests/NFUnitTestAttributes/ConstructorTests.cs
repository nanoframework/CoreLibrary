using System;
using nanoFramework.TestFramework;

namespace NFUnitTestAttributes
{
    [TestClass]
    public class ConstructorTests
    {
        public const int ExpectedIntParameter = 69_420;
        public const string ExpectedStringParameter = "A string parameter";

        private static void AssertDefaultConstructorIsCalled(object[] attributes)
        {
            Assert.IsNotNull(attributes);
            Assert.AreEqual(1, attributes.Length);
            Assert.IsInstanceOfType(attributes[0], typeof(DefaultConstructorTestAttribute));

            var testAttribute = (DefaultConstructorTestAttribute)attributes[0];

            Assert.AreEqual(ExpectedIntParameter, testAttribute.IntProperty);
            Assert.AreEqual(ExpectedStringParameter, testAttribute.StringProperty);
        }

        private static void AssertSingleParameterConstructorIsCalledWithIntValue(object[] attributes)
        {
            Assert.IsNotNull(attributes);
            Assert.AreEqual(1, attributes.Length);
            Assert.IsInstanceOfType(attributes[0], typeof(ConstructorParameterTestAttribute));

            var testAttribute = (ConstructorParameterTestAttribute)attributes[0];

            Assert.IsTrue(testAttribute.SingleParameterConstructorCalled);
            Assert.AreEqual(ExpectedIntParameter, testAttribute.IntProperty);
            Assert.IsNull(testAttribute.StringProperty);
        }

        private static void AssertSingleParameterConstructorIsCalledWithStringValue(object[] attributes)
        {
            Assert.IsNotNull(attributes);
            Assert.AreEqual(1, attributes.Length);
            Assert.IsInstanceOfType(attributes[0], typeof(ConstructorParameterTestAttribute));

            var testAttribute = (ConstructorParameterTestAttribute)attributes[0];

            Assert.IsTrue(testAttribute.SingleParameterConstructorCalled);
            Assert.AreEqual(0, testAttribute.IntProperty);
            Assert.AreEqual(ExpectedStringParameter, testAttribute.StringProperty);
        }

        private static void AssertZeroParameterConstructorIsCalled(object[] attributes)
        {
            Assert.IsNotNull(attributes);
            Assert.AreEqual(1, attributes.Length);
            Assert.IsInstanceOfType(attributes[0], typeof(ConstructorParameterTestAttribute));

            var testAttribute = (ConstructorParameterTestAttribute)attributes[0];

            Assert.IsTrue(testAttribute.ZeroParameterConstructorCalled);
            Assert.AreEqual(0, testAttribute.IntProperty);
            Assert.IsNull(testAttribute.StringProperty);
        }

        [TestMethod]
        public void When_Attribute_is_on_a_class_default_constructor_is_called()
        {
            var attributes = typeof(DefaultConstructorTestCases).GetCustomAttributes(true);

            AssertDefaultConstructorIsCalled(attributes);
        }

        [TestMethod]
        public void When_Attribute_is_on_a_class_single_parameter_constructor_is_called_with_int_value()
        {
            var attributes = typeof(IntParameterConstructorTestCases).GetCustomAttributes(true);

            AssertSingleParameterConstructorIsCalledWithIntValue(attributes);
        }

        [TestMethod]
        public void When_Attribute_is_on_a_class_single_parameter_constructor_is_called_with_string_value()
        {
            var attributes = typeof(StringParameterConstructorTestCases).GetCustomAttributes(true);
 
            AssertSingleParameterConstructorIsCalledWithStringValue(attributes);
        }

        [TestMethod]
        public void When_Attribute_is_on_a_class_zero_parameter_constructor_is_called()
        {
            var attributes = typeof(ZeroParameterConstructorClass).GetCustomAttributes(true);

            AssertZeroParameterConstructorIsCalled(attributes);
        }

        [TestMethod]
        public void When_Attribute_is_on_a_method_default_constructor_is_called()
        {
            var attributes = typeof(DefaultConstructorTestCases).GetMethod("TestMethod").GetCustomAttributes(true);

            AssertDefaultConstructorIsCalled(attributes);
        }

        [TestMethod]
        public void When_Attribute_is_on_a_method_single_parameter_constructor_is_called_with_int_value()
        {
            var attributes = typeof(IntParameterConstructorTestCases).GetMethod("TestMethod").GetCustomAttributes(true);

            AssertSingleParameterConstructorIsCalledWithIntValue(attributes);
        }

        [TestMethod]
        public void When_Attribute_is_on_a_method_single_parameter_constructor_is_called_with_string_value()
        {
            var attributes = typeof(StringParameterConstructorTestCases).GetMethod("TestMethod").GetCustomAttributes(true);

            AssertSingleParameterConstructorIsCalledWithStringValue(attributes);

        }

        [TestMethod]
        public void When_Attribute_is_on_a_method_zero_parameter_constructor_is_called()
        {
            var attributes = typeof(ZeroParameterConstructorClass).GetMethod("TestMethod").GetCustomAttributes(true);

            AssertZeroParameterConstructorIsCalled(attributes);
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class DefaultConstructorTestAttribute : Attribute
    {
        public int IntProperty { get; set; } = ConstructorTests.ExpectedIntParameter;
        public string StringProperty { get; set; } = ConstructorTests.ExpectedStringParameter;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class ConstructorParameterTestAttribute: Attribute 
    {
        public ConstructorParameterTestAttribute()
        {
            ZeroParameterConstructorCalled = true;
        }

        public ConstructorParameterTestAttribute(int value)
        {
            SingleParameterConstructorCalled = true;
            IntProperty = value;
        }

        public ConstructorParameterTestAttribute(string parameter)
        {
            SingleParameterConstructorCalled = true;
            StringProperty = parameter;
        }

        public bool ZeroParameterConstructorCalled { get; }

        public int IntProperty { get; set; }

        public bool SingleParameterConstructorCalled { get; set; }

        public string StringProperty { get; set; }
    }

    [DefaultConstructorTest]
    public class DefaultConstructorTestCases
    {
        [DefaultConstructorTest]
        public object TestProperty { get; set; }

        [DefaultConstructorTest]
        public void TestMethod()
        {

        }
    }

    [ConstructorParameterTest(ConstructorTests.ExpectedIntParameter)]
    public class IntParameterConstructorTestCases
    {
        [ConstructorParameterTest(ConstructorTests.ExpectedIntParameter)]
        public object TestProperty { get; set; }

        [ConstructorParameterTest(ConstructorTests.ExpectedIntParameter)]
        public void TestMethod()
        {

        }
    }

    [ConstructorParameterTest(ConstructorTests.ExpectedStringParameter)]
    public class StringParameterConstructorTestCases
    {
        [ConstructorParameterTest(ConstructorTests.ExpectedStringParameter)]
        public object TestProperty { get; set; }

        [ConstructorParameterTest(ConstructorTests.ExpectedStringParameter)]
        public void TestMethod()
        {

        }
    }

    [ConstructorParameterTest]
    public class ZeroParameterConstructorClass
    {
        [ConstructorParameterTest]
        public object TestProperty { get; set; }

        [ConstructorParameterTest]
        public void TestMethod()
        {

        }
    }
}
