// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestAttributes
{
    public enum EnumArgColor
    {
        Red,
        Green,
        Blue
    }

    public enum EnumArgByte : byte
    {
        Low = 1,
        High = 250
    }

    public enum EnumArgSByte : sbyte
    {
        Negative = -5
    }

    public enum EnumArgUShort : ushort
    {
        Wide = 60000
    }

    public enum EnumArgLong : long
    {
        Small = 1,
        Big = 0x123456789A
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class EnumArgAttribute : Attribute
    {
        public EnumArgColor Value { get; }

        public EnumArgAttribute(EnumArgColor value)
        {
            Value = value;
        }
    }

    public class EnumArgNestedAttribute : Attribute
    {
        public EnumArgHolder.NestedEnum Value { get; }

        public EnumArgNestedAttribute(EnumArgHolder.NestedEnum value)
        {
            Value = value;
        }
    }

    public class EnumArgMixedAttribute : Attribute
    {
        public int Number { get; }
        public EnumArgLong Big { get; }
        public string Text { get; }

        public EnumArgMixedAttribute(int number, EnumArgLong big, string text)
        {
            Number = number;
            Big = big;
            Text = text;
        }
    }

    public class EnumArgObjectsAttribute : Attribute
    {
        public object[] Values { get; }

        public EnumArgObjectsAttribute(params object[] values)
        {
            Values = values;
        }
    }

    public class EnumArgDayAttribute : Attribute
    {
        public DayOfWeek Value { get; }

        public EnumArgDayAttribute(DayOfWeek value)
        {
            Value = value;
        }
    }

    [EnumArg(EnumArgColor.Green)]
    [EnumArgNested(EnumArgHolder.NestedEnum.Second)]
    public class EnumArgHolder
    {
        public enum NestedEnum
        {
            First,
            Second
        }

        [EnumArg(EnumArgColor.Blue)]
        public int DecoratedField;

        [EnumArg(EnumArgColor.Red)]
        [EnumArg(EnumArgColor.Blue)]
        public void MultipleAttributes()
        {
        }

        [EnumArgMixed(7, EnumArgLong.Big, "text")]
        public void MixedArguments()
        {
        }

        [EnumArgObjects(EnumArgColor.Blue, EnumArgByte.High, EnumArgLong.Big, EnumArgSByte.Negative, EnumArgUShort.Wide, 42, "text")]
        public void ObjectArguments()
        {
        }

        [EnumArgDay(DayOfWeek.Friday)]
        public void CoreLibraryEnum()
        {
        }

        [EnumArgObjects(DayOfWeek.Saturday)]
        public void CoreLibraryEnumInObjects()
        {
        }
    }

    [TestClass]
    public class EnumAttributeArgumentTests
    {
        private static object FindAttribute(object[] attributes, Type attributeType, int occurrence = 0)
        {
            foreach (object attribute in attributes)
            {
                if (attribute.GetType() == attributeType && occurrence-- == 0)
                {
                    return attribute;
                }
            }

            return null;
        }

        private static object[] MethodAttributes(string name)
        {
            return typeof(EnumArgHolder).GetMethod(name).GetCustomAttributes(false);
        }

        [TestMethod]
        public void TypeAttribute_EnumArgument()
        {
            object[] attributes = typeof(EnumArgHolder).GetCustomAttributes(false);

            EnumArgAttribute attribute = (EnumArgAttribute)FindAttribute(attributes, typeof(EnumArgAttribute));
            Assert.IsNotNull(attribute);
            Assert.AreEqual((int)EnumArgColor.Green, (int)attribute.Value);

            EnumArgNestedAttribute nested = (EnumArgNestedAttribute)FindAttribute(attributes, typeof(EnumArgNestedAttribute));
            Assert.IsNotNull(nested);
            Assert.AreEqual((int)EnumArgHolder.NestedEnum.Second, (int)nested.Value);
        }

        [TestMethod]
        public void FieldAttribute_EnumArgument()
        {
            object[] attributes = typeof(EnumArgHolder).GetField("DecoratedField").GetCustomAttributes(false);

            EnumArgAttribute attribute = (EnumArgAttribute)FindAttribute(attributes, typeof(EnumArgAttribute));
            Assert.IsNotNull(attribute);
            Assert.AreEqual((int)EnumArgColor.Blue, (int)attribute.Value);
        }

        [TestMethod]
        public void MethodAttribute_MultipleEnumArguments()
        {
            object[] attributes = MethodAttributes("MultipleAttributes");

            Assert.AreEqual(2, attributes.Length);

            EnumArgAttribute first = (EnumArgAttribute)FindAttribute(attributes, typeof(EnumArgAttribute), 0);
            EnumArgAttribute second = (EnumArgAttribute)FindAttribute(attributes, typeof(EnumArgAttribute), 1);

            Assert.IsNotNull(first);
            Assert.IsNotNull(second);
            Assert.AreEqual((int)EnumArgColor.Red + (int)EnumArgColor.Blue, (int)first.Value + (int)second.Value);
            Assert.AreNotEqual((int)first.Value, (int)second.Value);
        }

        [TestMethod]
        public void MethodAttribute_MixedArguments()
        {
            object[] attributes = MethodAttributes("MixedArguments");

            EnumArgMixedAttribute attribute = (EnumArgMixedAttribute)FindAttribute(attributes, typeof(EnumArgMixedAttribute));
            Assert.IsNotNull(attribute);
            Assert.AreEqual(7, attribute.Number);
            Assert.IsTrue(attribute.Big == EnumArgLong.Big);
            Assert.AreEqual("text", attribute.Text);
        }

        [TestMethod]
        public void MethodAttribute_EnumsInObjectArray_KeepTheirType()
        {
            object[] attributes = MethodAttributes("ObjectArguments");

            EnumArgObjectsAttribute attribute = (EnumArgObjectsAttribute)FindAttribute(attributes, typeof(EnumArgObjectsAttribute));
            Assert.IsNotNull(attribute);

            object[] values = attribute.Values;
            Assert.AreEqual(7, values.Length);

            Assert.IsTrue(values[0] is EnumArgColor);
            Assert.IsTrue((EnumArgColor)values[0] == EnumArgColor.Blue);

            Assert.IsTrue(values[1] is EnumArgByte);
            Assert.IsTrue((EnumArgByte)values[1] == EnumArgByte.High);

            Assert.IsTrue(values[2] is EnumArgLong);
            Assert.IsTrue((EnumArgLong)values[2] == EnumArgLong.Big);

            Assert.IsTrue(values[3] is EnumArgSByte);
            Assert.IsTrue((EnumArgSByte)values[3] == EnumArgSByte.Negative);

            Assert.IsTrue(values[4] is EnumArgUShort);
            Assert.IsTrue((EnumArgUShort)values[4] == EnumArgUShort.Wide);

            Assert.IsTrue(values[5] is int);
            Assert.AreEqual(42, (int)values[5]);

            Assert.IsTrue(values[6] is string);
            Assert.AreEqual("text", (string)values[6]);
        }

        [TestMethod]
        public void MethodAttribute_EnumFromCoreLibrary()
        {
            DayOfWeek single = ((EnumArgDayAttribute)FindAttribute(MethodAttributes("CoreLibraryEnum"), typeof(EnumArgDayAttribute))).Value;
            Assert.IsTrue(single == DayOfWeek.Friday);

            EnumArgObjectsAttribute boxed = (EnumArgObjectsAttribute)FindAttribute(MethodAttributes("CoreLibraryEnumInObjects"), typeof(EnumArgObjectsAttribute));
            Assert.IsTrue(boxed.Values[0] is DayOfWeek);
            Assert.IsTrue((DayOfWeek)boxed.Values[0] == DayOfWeek.Saturday);
        }

        [TestMethod]
        [DataRow(EnumArgColor.Green)]
        [DataRow(EnumArgColor.Blue)]
        public void DataRow_WithEnumArgument(EnumArgColor color)
        {
            Assert.IsTrue(color == EnumArgColor.Green || color == EnumArgColor.Blue);
        }

        [TestMethod]
        [DataRow(EnumArgByte.High, EnumArgLong.Big)]
        public void DataRow_WithSeveralEnumArguments(EnumArgByte small, EnumArgLong big)
        {
            Assert.IsTrue(small == EnumArgByte.High);
            Assert.IsTrue(big == EnumArgLong.Big);
        }
    }
}
