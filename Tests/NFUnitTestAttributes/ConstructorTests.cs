using System;
using nanoFramework.TestFramework;
// ReSharper disable InconsistentNaming

// Enabling nullable here tests the use case where the compiler adds an attribute the isn't implemented in nanoFramework
// This is currently System.Runtime.CompilerServices.NullableContextAttribute
#nullable enable
namespace NFUnitTestAttributes
{
    public class ConstructorTests
    {
        public const int ExpectedIntParameter = 69_420;
        public const string ExpectedStringParameter = "A string parameter";

        private static void AssertArrayConstructorIsCalled(object[] attributes)
        {
            Assert.IsNotNull(attributes);
            Assert.AreEqual(1, attributes.Length);
            Assert.IsInstanceOfType(attributes[0], typeof(SingleParameterConstructorTestAttribute));

            var testAttribute = (SingleParameterConstructorTestAttribute)attributes[0];

            Assert.IsTrue(testAttribute.ConstructorCalled);
            Assert.AreEqual(ExpectedIntParameter, testAttribute.IntProperty);
            Assert.AreEqual(ExpectedStringParameter, testAttribute.StringProperty);
        }

        private static void AssertDefaultConstructorIsCalled(object[] attributes)
        {
            Assert.IsNotNull(attributes);
            Assert.AreEqual(1, attributes.Length);
            Assert.IsInstanceOfType(attributes[0], typeof(DefaultConstructorTestAttribute));

            var testAttribute = (DefaultConstructorTestAttribute)attributes[0];

            Assert.AreEqual(ExpectedIntParameter, testAttribute.IntProperty);
            Assert.AreEqual(ExpectedStringParameter, testAttribute.StringProperty);
        }

        private static void AssertMultiParameterConstructorIsCalled(object[] attributes)
        {
            Assert.IsNotNull(attributes);
            Assert.AreEqual(1, attributes.Length);
            Assert.IsInstanceOfType(attributes[0], typeof(MultiParameterConstructorTestAttribute));

            var testAttribute = (MultiParameterConstructorTestAttribute)attributes[0];

            Assert.IsTrue(testAttribute.ConstructorCalled);
            Assert.AreEqual(ExpectedIntParameter, testAttribute.IntProperty);
            Assert.AreEqual(ExpectedStringParameter, testAttribute.StringProperty);
        }

        private static void AssertSingleParameterConstructorIsCalledWithIntValue(object[] attributes)
        {
            Assert.IsNotNull(attributes);
            Assert.AreEqual(1, attributes.Length);
            Assert.IsInstanceOfType(attributes[0], typeof(SingleParameterConstructorTestAttribute));

            var testAttribute = (SingleParameterConstructorTestAttribute)attributes[0];

            Assert.IsTrue(testAttribute.ConstructorCalled);
            Assert.AreEqual(ExpectedIntParameter, testAttribute.IntProperty);
            Assert.IsNull(testAttribute.StringProperty);
        }

        private static void AssertSingleParameterConstructorIsCalledWithStringValue(object[] attributes)
        {
            Assert.IsNotNull(attributes);
            Assert.AreEqual(1, attributes.Length);
            Assert.IsInstanceOfType(attributes[0], typeof(SingleParameterConstructorTestAttribute));

            var testAttribute = (SingleParameterConstructorTestAttribute)attributes[0];

            Assert.IsTrue(testAttribute.ConstructorCalled);
            Assert.AreEqual(0, testAttribute.IntProperty);
            Assert.AreEqual(ExpectedStringParameter, testAttribute.StringProperty);
        }

        private static void AssertZeroParameterConstructorIsCalled(object[] attributes)
        {
            Assert.IsNotNull(attributes);
            Assert.AreEqual(1, attributes.Length);
            Assert.IsInstanceOfType(attributes[0], typeof(SingleParameterConstructorTestAttribute));

            var testAttribute = (SingleParameterConstructorTestAttribute)attributes[0];

            Assert.IsTrue(testAttribute.ConstructorCalled);
            Assert.AreEqual(0, testAttribute.IntProperty);
            Assert.IsNull(testAttribute.StringProperty);
        }

        [TestClass]
        public class When_Attribute_is_on_a_class: ConstructorTests
        {
            private static object[] GetAttributes(Type testCases)
            {
                return testCases.GetCustomAttributes(true);
            }

            [TestMethod]
            public void Default_constructor_is_called()
            {
                AssertDefaultConstructorIsCalled(GetAttributes(typeof(DefaultConstructorTestCases)));
            }

            [TestMethod]
            public void Multi_parameter_constructor_is_called_with_array_value()
            {
                AssertMultiParameterConstructorIsCalled(GetAttributes(typeof(MultiParameterConstructorTestCases)));
            }

            [TestMethod]
            public void Single_parameter_constructor_is_called_with_array_value()
            {
                AssertArrayConstructorIsCalled(GetAttributes(typeof(ArrayParameterConstructorTestCases)));
            }

            [TestMethod]
            public void Single_parameter_constructor_is_called_with_int_value()
            {
                AssertSingleParameterConstructorIsCalledWithIntValue(GetAttributes(typeof(IntParameterConstructorTestCases)));
            }

            [TestMethod]
            public void Single_parameter_constructor_is_called_with_string_value()
            {
                AssertSingleParameterConstructorIsCalledWithStringValue(GetAttributes(typeof(StringParameterConstructorTestCases)));
            }

            [TestMethod]
            public void Zero_parameter_constructor_is_called()
            {
                AssertZeroParameterConstructorIsCalled(GetAttributes(typeof(ZeroParameterConstructorTestCases)));
            }
        }

        [TestClass]
        public class When_Attribute_is_on_a_field : ConstructorTests
        {
            private static object[] GetAttributes(Type testCases)
            {
                return testCases.GetField("TestField")!.GetCustomAttributes(true);
            }

            [TestMethod]
            public void Default_constructor_is_called()
            {
                AssertDefaultConstructorIsCalled(GetAttributes(typeof(DefaultConstructorTestCases)));
            }

            [TestMethod]
            public void Multi_parameter_constructor_is_called_with_array_value()
            {
                AssertMultiParameterConstructorIsCalled(GetAttributes(typeof(MultiParameterConstructorTestCases)));
            }

            [TestMethod]
            public void Single_parameter_constructor_is_called_with_array_value()
            {
                AssertArrayConstructorIsCalled(GetAttributes(typeof(ArrayParameterConstructorTestCases)));
            }

            [TestMethod]
            public void Single_parameter_constructor_is_called_with_int_value()
            {
                AssertSingleParameterConstructorIsCalledWithIntValue(GetAttributes(typeof(IntParameterConstructorTestCases)));
            }

            [TestMethod]
            public void Single_parameter_constructor_is_called_with_string_value()
            {
                AssertSingleParameterConstructorIsCalledWithStringValue(GetAttributes(typeof(StringParameterConstructorTestCases)));
            }

            [TestMethod]
            public void Zero_parameter_constructor_is_called()
            {
                AssertZeroParameterConstructorIsCalled(GetAttributes(typeof(ZeroParameterConstructorTestCases)));
            }
        }

        [TestClass]
        public class When_Attribute_is_on_a_method : ConstructorTests
        {
            private static object[] GetAttributes(Type testCases)
            {
                return testCases.GetMethod("TestMethod")!.GetCustomAttributes(true);
            }

            [TestMethod]
            public void Default_constructor_is_called()
            {
                AssertDefaultConstructorIsCalled(GetAttributes(typeof(DefaultConstructorTestCases)));
            }

            [TestMethod]
            public void Multi_parameter_constructor_is_called_with_array_value()
            {
                AssertMultiParameterConstructorIsCalled(GetAttributes(typeof(MultiParameterConstructorTestCases)));
            }

            [TestMethod]
            public void Single_parameter_constructor_is_called_with_array_value()
            {
                AssertArrayConstructorIsCalled(GetAttributes(typeof(ArrayParameterConstructorTestCases)));
            }

            [TestMethod]
            public void Single_parameter_constructor_is_called_with_int_value()
            {
                AssertSingleParameterConstructorIsCalledWithIntValue(GetAttributes(typeof(IntParameterConstructorTestCases)));
            }

            [TestMethod]
            public void Single_parameter_constructor_is_called_with_string_value()
            {
                AssertSingleParameterConstructorIsCalledWithStringValue(GetAttributes(typeof(StringParameterConstructorTestCases)));
            }

            [TestMethod]
            public void Zero_parameter_constructor_is_called()
            {
                AssertZeroParameterConstructorIsCalled(GetAttributes(typeof(ZeroParameterConstructorTestCases)));
            }
        }
    }

    #region Test Attributes
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class DefaultConstructorTestAttribute : Attribute
    {
        public int IntProperty { get; set; } = ConstructorTests.ExpectedIntParameter;
        public string StringProperty { get; set; } = ConstructorTests.ExpectedStringParameter;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class MultiParameterConstructorTestAttribute : Attribute
    {
        public MultiParameterConstructorTestAttribute()
        {
            
        }

        public MultiParameterConstructorTestAttribute(int intValue, string stringValue)
        {
            ConstructorCalled = true;
            IntProperty = intValue;
            StringProperty = stringValue;
        }

        public bool ConstructorCalled { get; }

        public int IntProperty { get; set; }

        public string? StringProperty { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class SingleParameterConstructorTestAttribute: Attribute 
    {
        public SingleParameterConstructorTestAttribute()
        {
            ConstructorCalled = true;
        }

        public SingleParameterConstructorTestAttribute(int value)
        {
            ConstructorCalled = true;
            IntProperty = value;
        }

        public SingleParameterConstructorTestAttribute(string parameter)
        {
            ConstructorCalled = true;
            StringProperty = parameter;
        }

        public SingleParameterConstructorTestAttribute(params object[] parameters)
        {
            ConstructorCalled = true;

            foreach (var parameter in parameters)
            {
                switch (parameter)
                {
                    case int intParameter:
                        IntProperty = intParameter;
                        break;
                    case string stringParameter:
                        StringProperty = stringParameter;
                        break;
                }
            }
        }

        public bool ConstructorCalled { get; }

        public int IntProperty { get; set; }

        public string? StringProperty { get; set; }
    }
    #endregion

    #region Test Cases
    [SingleParameterConstructorTest(ConstructorTests.ExpectedIntParameter, ConstructorTests.ExpectedStringParameter)]
    public class ArrayParameterConstructorTestCases
    {
        [SingleParameterConstructorTest(ConstructorTests.ExpectedIntParameter, ConstructorTests.ExpectedStringParameter)]
        public object? TestField;

        [SingleParameterConstructorTest(ConstructorTests.ExpectedIntParameter, ConstructorTests.ExpectedStringParameter)]
        public void TestMethod(string? value = null)
        {

        }
    }

    [DefaultConstructorTest]
    public class DefaultConstructorTestCases
    {
        [DefaultConstructorTest]
        public object? TestField;

        [DefaultConstructorTest]
        public void TestMethod(string? value = null)
        {

        }
    }

    [SingleParameterConstructorTest(ConstructorTests.ExpectedIntParameter)]
    public class IntParameterConstructorTestCases
    {
        [SingleParameterConstructorTest(ConstructorTests.ExpectedIntParameter)]
        public object? TestField;

        [SingleParameterConstructorTest(ConstructorTests.ExpectedIntParameter)]
        public void TestMethod(string? value = null)
        {

        }
    }

    [MultiParameterConstructorTest(ConstructorTests.ExpectedIntParameter, ConstructorTests.ExpectedStringParameter)]
    public class MultiParameterConstructorTestCases
    {
        [MultiParameterConstructorTest(ConstructorTests.ExpectedIntParameter, ConstructorTests.ExpectedStringParameter)]
        public object? TestField;

        [MultiParameterConstructorTest(ConstructorTests.ExpectedIntParameter, ConstructorTests.ExpectedStringParameter)]
        public void TestMethod(string? value = null)
        {

        }
    }

    [SingleParameterConstructorTest(ConstructorTests.ExpectedStringParameter)]
    public class StringParameterConstructorTestCases
    {
        [SingleParameterConstructorTest(ConstructorTests.ExpectedStringParameter)]
        public object? TestField;

        [SingleParameterConstructorTest(ConstructorTests.ExpectedStringParameter)]
        public void TestMethod(string? value = null)
        {

        }
    }

    [SingleParameterConstructorTest]
    public class ZeroParameterConstructorTestCases
    {
        [SingleParameterConstructorTest]
        public object? TestField;

        [SingleParameterConstructorTest]
        public void TestMethod(string? value = null)
        {

        }
    }
    #endregion
}
