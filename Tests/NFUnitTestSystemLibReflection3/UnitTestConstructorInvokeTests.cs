// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Expected values come from running the same code on .NET 10.
    [TestClass]
    public class UnitTestConstructorInvokeTests
    {
        public struct CiParameterless
        {
            public int X;

            public CiParameterless()
            {
                X = 5;
            }
        }

        public struct CiWithArgument
        {
            public int X;

            public CiWithArgument(int x)
            {
                X = x;
            }
        }

        public struct CiResetting
        {
            public int X;

            public int Y;

            public CiResetting(int x)
                : this()
            {
                X = x;
            }
        }

        public struct CiNoConstructor
        {
            public int X;
        }

        public struct CiGeneric<T>
        {
            public T Value;

            public CiGeneric()
            {
            }

            public CiGeneric(T value)
            {
                Value = value;
            }
        }

        public class CiClass
        {
            public int X;

            public CiClass()
            {
                X = 9;
            }

            public CiClass(int x)
            {
                X = x;
            }
        }

        public class CiOther
        {
        }

        private static ConstructorInfo Constructor(Type type, params Type[] arguments)
        {
            return type.GetConstructor(arguments);
        }

        [TestMethod]
        public void Invoke_StructWithParameterlessConstructor_ReturnsABoxedStruct()
        {
            object o = Constructor(typeof(CiParameterless)).Invoke(null);

            Assert.IsTrue(o.GetType() == typeof(CiParameterless));
            Assert.IsTrue(o is CiParameterless);
            Assert.IsTrue(o is ValueType);
            Assert.AreEqual(5, ((CiParameterless)o).X);
            Assert.IsTrue(o.Equals(new CiParameterless()));
            Assert.AreEqual(5, ((CiParameterless)new object[] { o }[0]).X);
            Assert.AreEqual(5, ((CiParameterless)Constructor(typeof(CiParameterless)).Invoke(new object[0])).X);
            Assert.IsFalse(ReferenceEquals(o, Constructor(typeof(CiParameterless)).Invoke(null)));
        }

        [TestMethod]
        public void Invoke_StructWithParameterlessConstructor_UnboxedCopyIsIndependent()
        {
            object o = Constructor(typeof(CiParameterless)).Invoke(null);
            CiParameterless copy = (CiParameterless)o;

            copy.X = 7;

            Assert.AreEqual(5, ((CiParameterless)o).X);
        }

        [TestMethod]
        public void Invoke_StructWithArgument_ReturnsABoxedStruct()
        {
            ConstructorInfo constructor = Constructor(typeof(CiWithArgument), typeof(int));
            object o = constructor.Invoke(new object[] { 7 });

            Assert.IsTrue(o is CiWithArgument);
            Assert.AreEqual(7, ((CiWithArgument)o).X);
            Assert.ThrowsException(typeof(TargetParameterCountException), () => constructor.Invoke(null));
            Assert.ThrowsException(typeof(ArgumentException), () => constructor.Invoke(new object[] { "x" }));
        }

        [TestMethod]
        public void GetConstructor_StructWithoutDeclaredConstructor_IsNull()
        {
            Assert.IsNull(Constructor(typeof(CiNoConstructor)));
        }

        [TestMethod]
        public void Invoke_GenericStruct_ReturnsAClosedBoxedStruct()
        {
            object o = Constructor(typeof(CiGeneric<int>), typeof(int)).Invoke(new object[] { 4 });

            Assert.IsTrue(o.GetType() == typeof(CiGeneric<int>));
            Assert.IsTrue(o is CiGeneric<int>);
            Assert.IsFalse(o is CiGeneric<string>);
            Assert.AreEqual(4, ((CiGeneric<int>)o).Value);

            object s = Constructor(typeof(CiGeneric<string>)).Invoke(null);

            Assert.IsNull(((CiGeneric<string>)s).Value);
        }

        [TestMethod]
        public void Invoke_ConstructorsOfBuiltInValueTypesAndString_Work()
        {
            object dateTime = Constructor(typeof(DateTime), typeof(long)).Invoke(new object[] { 630000000000000000L });
            object timeSpan = Constructor(typeof(TimeSpan), typeof(long)).Invoke(new object[] { 77L });
            object guid = Constructor(typeof(Guid), typeof(byte[])).Invoke(new object[] { new byte[16] });
            object text = Constructor(typeof(string), typeof(char[])).Invoke(new object[] { new char[] { 'a', 'b' } });

            Assert.AreEqual(630000000000000000L, ((DateTime)dateTime).Ticks);
            Assert.IsTrue(dateTime.GetType() == typeof(DateTime));
            Assert.AreEqual(77L, ((TimeSpan)timeSpan).Ticks);
            Assert.IsTrue(guid is Guid);
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", ((Guid)guid).ToString());
            Assert.AreEqual("ab", (string)text);
        }

        [TestMethod]
        public void Invoke_ClassConstructors_Work()
        {
            Assert.AreEqual(9, ((CiClass)Constructor(typeof(CiClass)).Invoke(null)).X);
            Assert.AreEqual(4, ((CiClass)Constructor(typeof(CiClass), typeof(int)).Invoke(new object[] { 4 })).X);
            Assert.AreEqual("m", ((Exception)Constructor(typeof(Exception), typeof(string)).Invoke(new object[] { "m" })).Message);
        }

        [TestMethod]
        public void Invoke_ConstructorWithATarget_RunsOnTheTarget()
        {
            ConstructorInfo constructor = Constructor(typeof(CiClass), typeof(int));
            CiClass target = new CiClass();

            Assert.IsNull(constructor.Invoke(target, new object[] { 2 }));
            Assert.AreEqual(2, target.X);
        }

        [TestMethod]
        public void Invoke_ConstructorOnABoxedStruct_ReinitializesTheBoxInPlace()
        {
            CiParameterless parameterless = new CiParameterless();
            parameterless.X = 1;

            object boxedParameterless = parameterless;
            object boxedWithArgument = new CiWithArgument(1);
            object boxedGeneric = new CiGeneric<int>(1);
            object boxedDateTime = new DateTime(630000000000000000L + 10000000L);
            CiResetting resetting = new CiResetting(0);
            resetting.X = 8;
            resetting.Y = 5;

            object boxedResetting = resetting;

            Assert.IsNull(Constructor(typeof(CiParameterless)).Invoke(boxedParameterless, null));
            Assert.IsNull(Constructor(typeof(CiWithArgument), typeof(int)).Invoke(boxedWithArgument, new object[] { 7 }));
            Assert.IsNull(Constructor(typeof(CiGeneric<int>), typeof(int)).Invoke(boxedGeneric, new object[] { 9 }));
            Assert.IsNull(Constructor(typeof(DateTime), typeof(long)).Invoke(boxedDateTime, new object[] { 630000000000000000L }));
            Assert.IsNull(Constructor(typeof(CiResetting), typeof(int)).Invoke(boxedResetting, new object[] { 3 }));

            Assert.AreEqual(5, ((CiParameterless)boxedParameterless).X);
            Assert.AreEqual(7, ((CiWithArgument)boxedWithArgument).X);
            Assert.AreEqual(9, ((CiGeneric<int>)boxedGeneric).Value);
            Assert.AreEqual(630000000000000000L, ((DateTime)boxedDateTime).Ticks);
            Assert.AreEqual(3, ((CiResetting)boxedResetting).X);
            Assert.AreEqual(0, ((CiResetting)boxedResetting).Y);
        }

        [TestMethod]
        public void Invoke_ConstructorOnABoxedStruct_ThrowsForAnotherType()
        {
            object boxed = new CiParameterless();

            Assert.ThrowsException(typeof(TargetException), () => Constructor(typeof(CiWithArgument), typeof(int)).Invoke(boxed, new object[] { 1 }));
            Assert.ThrowsException(typeof(TargetParameterCountException), () => Constructor(typeof(CiWithArgument), typeof(int)).Invoke(new CiWithArgument(1), new object[0]));
        }

        [TestMethod]
        public void Invoke_ConstructorWithoutAnOrAWrongTarget_ThrowsTargetException()
        {
            ConstructorInfo constructor = Constructor(typeof(CiClass), typeof(int));

            Assert.ThrowsException(typeof(TargetException), () => constructor.Invoke(null, new object[] { 2 }));
            Assert.ThrowsException(typeof(TargetException), () => constructor.Invoke(new CiOther(), new object[] { 2 }));
        }
    }
}
