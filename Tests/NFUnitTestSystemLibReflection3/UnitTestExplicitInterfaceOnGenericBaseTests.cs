// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Expected values are the language rules for 'is' and casts, checked on .NET 10.
    // Scenario of nanoFramework/Home#1947: explicit non-generic interface implementation on a generic base class.
    [TestClass]
    public class UnitTestExplicitInterfaceOnGenericBaseTests
    {
        public interface IValueGetSet
        {
            object GetValue();

            void SetValue(object value);
        }

        public abstract class ValueBase<T> : IValueGetSet
        {
            public abstract T GetValue();

            public abstract void SetValue(T value);

            void IValueGetSet.SetValue(object value)
            {
                if (value is T typedValue)
                {
                    SetValue(typedValue);
                }
                else
                {
                    throw new ArgumentException("Value is not of the expected type", nameof(value));
                }
            }

            object IValueGetSet.GetValue()
            {
                return (T)GetValue();
            }
        }

        public struct Point
        {
            public int X;
            public int Y;
        }

        public class BoolValue : ValueBase<bool>
        {
            private bool _value;

            public override bool GetValue()
            {
                return _value;
            }

            public override void SetValue(bool value)
            {
                _value = value;
            }
        }

        public class IntValue : ValueBase<int>
        {
            private int _value;

            public override int GetValue()
            {
                return _value;
            }

            public override void SetValue(int value)
            {
                _value = value;
            }
        }

        public class StringValue : ValueBase<string>
        {
            private string _value;

            public override string GetValue()
            {
                return _value;
            }

            public override void SetValue(string value)
            {
                _value = value;
            }
        }

        public class PointValue : ValueBase<Point>
        {
            private Point _value;

            public override Point GetValue()
            {
                return _value;
            }

            public override void SetValue(Point value)
            {
                _value = value;
            }
        }

        [TestMethod]
        public void Bool_SetThenGet_ReturnsBoxedValue()
        {
            IValueGetSet value = new BoolValue();

            value.SetValue(true);

            Assert.AreEqual(true, (bool)value.GetValue());
            Assert.AreEqual(true, ((BoolValue)value).GetValue());
        }

        [TestMethod]
        public void Bool_WrongType_ThrowsArgumentException()
        {
            IValueGetSet value = new BoolValue();

            Assert.ThrowsException(typeof(ArgumentException), () => value.SetValue("x"));
            Assert.ThrowsException(typeof(ArgumentException), () => value.SetValue(1));
            Assert.ThrowsException(typeof(ArgumentException), () => value.SetValue(null));
        }

        [TestMethod]
        public void Int_SetThenGet_ReturnsBoxedValue()
        {
            IValueGetSet value = new IntValue();

            value.SetValue(5);

            Assert.AreEqual(5, (int)value.GetValue());
            Assert.AreEqual(5, ((IntValue)value).GetValue());
        }

        [TestMethod]
        public void Int_WrongType_ThrowsArgumentException()
        {
            IValueGetSet value = new IntValue();

            Assert.ThrowsException(typeof(ArgumentException), () => value.SetValue(true));
            Assert.ThrowsException(typeof(ArgumentException), () => value.SetValue("5"));
            Assert.ThrowsException(typeof(ArgumentException), () => value.SetValue(null));
        }

        [TestMethod]
        public void String_SetThenGet_ReturnsValue()
        {
            IValueGetSet value = new StringValue();

            value.SetValue("a");

            Assert.AreEqual("a", (string)value.GetValue());
            Assert.AreEqual("a", ((StringValue)value).GetValue());
        }

        [TestMethod]
        public void String_Null_ThrowsArgumentException()
        {
            IValueGetSet value = new StringValue();

            value.SetValue("a");

            Assert.ThrowsException(typeof(ArgumentException), () => value.SetValue(null));
            Assert.AreEqual("a", (string)value.GetValue());
        }

        [TestMethod]
        public void String_WrongType_ThrowsArgumentException()
        {
            IValueGetSet value = new StringValue();

            Assert.ThrowsException(typeof(ArgumentException), () => value.SetValue(1));
            Assert.ThrowsException(typeof(ArgumentException), () => value.SetValue(true));
        }

        [TestMethod]
        public void Struct_SetThenGet_ReturnsBoxedValue()
        {
            IValueGetSet value = new PointValue();

            Point point = new Point();
            point.X = 3;
            point.Y = 4;

            value.SetValue(point);

            Point result = (Point)value.GetValue();

            Assert.AreEqual(3, result.X);
            Assert.AreEqual(4, result.Y);
        }

        [TestMethod]
        public void Struct_WrongType_ThrowsArgumentException()
        {
            IValueGetSet value = new PointValue();

            Assert.ThrowsException(typeof(ArgumentException), () => value.SetValue(1));
            Assert.ThrowsException(typeof(ArgumentException), () => value.SetValue(null));
        }

        [TestMethod]
        public void ValueSetAgain_ReplacesPreviousValue()
        {
            IValueGetSet value = new IntValue();

            value.SetValue(1);
            value.SetValue(2);

            Assert.AreEqual(2, (int)value.GetValue());
        }
    }
}
