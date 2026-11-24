// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestDelegates
{
    // Expected values come from running the same code on .NET 10.
    [TestClass]
    public class UnitTestDelegateTypeTests
    {
        public delegate void DtVarianceIn<in T>(T value);

        public delegate T DtVarianceOut<out T>();

        public delegate void DtInvariant<T>(T value);

        public delegate void DtObjectSink(object value);

        public delegate int DtIntFunction(int value);

        public class DtOuter<T>
        {
            public delegate void Sink(T value);

            public delegate T Source();

            public static object MakeSink()
            {
                return new Sink(StaticSink);
            }

            public static object MakeSource()
            {
                return new Source(StaticSource);
            }

            public object MakeInstanceSink()
            {
                return new Sink(InstanceSink);
            }

            private static void StaticSink(T value)
            {
            }

            private static T StaticSource()
            {
                return default(T);
            }

            private void InstanceSink(T value)
            {
            }
        }

        public class DtHolder
        {
            public int Hits;

            public void ObjectMethod(object value)
            {
                Hits++;
            }

            public void StringMethod(string value)
            {
                Hits++;
            }

            public static void StaticObject(object value)
            {
            }

            public static void StaticString(string value)
            {
            }

            public static object StaticReturnObject()
            {
                return null;
            }

            public static string StaticReturnString()
            {
                return null;
            }

            public static T Identity<T>(T value)
            {
                return value;
            }

            public static object MakeAction<T>()
            {
                return new Action<T>(x => { });
            }

            public static object MakeFunc<T>()
            {
                return new Func<T>(() => default(T));
            }

            public static object MakeActionOfArray<T>()
            {
                return new Action<T[]>(x => { });
            }

            public static object MakeIdentity<T>()
            {
                return new Func<T, T>(Identity<T>);
            }
        }

        public class DtFields
        {
            public Action<int> IntAction;
            public Action<string> StringAction;
            public Action<object> ObjectAction;

            public static void TakeIntAction(Action<int> action)
            {
            }

            public static void TakeStringAction(Action<string> action)
            {
            }
        }

        #region casts and variance

        [TestMethod]
        public void ActionOfString_IsOnlyActionOfStringAndActionOfObjectIsAssignable()
        {
            object ofString = new Action<string>(DtHolder.StaticString);
            object ofObject = new Action<object>(DtHolder.StaticObject);
            object ofInt = new Action<int>(x => { });

            Assert.IsFalse(ofString is Action<int>);
            Assert.IsTrue(ofString is Action<string>);
            Assert.IsFalse(ofString is Action<object>);
            Assert.IsTrue(ofObject is Action<string>);
            Assert.IsFalse(ofObject is Action<int>);
            Assert.IsFalse(ofInt is Action<object>);
            Assert.IsTrue(ofString is Delegate);
            Assert.IsTrue(ofString is MulticastDelegate);
            Assert.IsFalse(ofString is Action);
        }

        [TestMethod]
        public void CastOfDelegateObject_ThrowsOrSucceedsLikeDotNet()
        {
            object ofString = new Action<string>(DtHolder.StaticString);
            object ofObject = new Action<object>(DtHolder.StaticObject);

            Assert.ThrowsException(typeof(InvalidCastException), () => { Action<int> unused = (Action<int>)ofString; });
            Assert.ThrowsException(typeof(InvalidCastException), () => { Action<object> unused = (Action<object>)ofString; });
            Assert.IsNotNull((Action<string>)ofObject);
        }

        [TestMethod]
        public void FuncVariance_FollowsInAndOut()
        {
            object funcOfString = new Func<string>(DtHolder.StaticReturnString);
            object funcOfObject = new Func<object>(DtHolder.StaticReturnObject);
            object funcOfInt = new Func<int>(() => 1);
            object objectToString = new Func<object, string>(o => null);
            object stringToObject = new Func<string, object>(o => null);

            Assert.IsTrue(funcOfString is Func<object>);
            Assert.IsFalse(funcOfObject is Func<string>);
            Assert.IsFalse(funcOfInt is Func<object>);
            Assert.IsTrue(objectToString is Func<string, object>);
            Assert.IsFalse(stringToObject is Func<object, string>);
            Assert.IsFalse(stringToObject is Func<string, string>);
        }

        [TestMethod]
        public void UserDelegateVariance_FollowsDeclaration()
        {
            object contravariantOfObject = new DtVarianceIn<object>(o => { });
            object contravariantOfString = new DtVarianceIn<string>(o => { });
            object invariantOfObject = new DtInvariant<object>(o => { });
            object covariantOfString = new DtVarianceOut<string>(() => null);

            Assert.IsTrue(contravariantOfObject is DtVarianceIn<string>);
            Assert.IsFalse(contravariantOfString is DtVarianceIn<object>);
            Assert.IsFalse(invariantOfObject is DtInvariant<string>);
            Assert.IsTrue(invariantOfObject is DtInvariant<object>);
            Assert.IsTrue(covariantOfString is DtVarianceOut<object>);
        }

        [TestMethod]
        public void NonGenericDelegates_AreTheirOwnType()
        {
            object plain = new DtObjectSink(DtHolder.StaticObject);
            object handler = new EventHandler((s, e) => { });

            Assert.IsFalse(plain is DtIntFunction);
            Assert.IsTrue(plain is DtObjectSink);
            Assert.IsFalse(plain is Action<object>);
            Assert.IsFalse(handler is Action);
            Assert.IsTrue(handler is EventHandler);
        }

        [TestMethod]
        public void NestedGenericDelegates_AreClosedOverTheOuterArguments()
        {
            Assert.IsFalse(DtOuter<int>.MakeSink() is DtOuter<string>.Sink);
            Assert.IsTrue(DtOuter<int>.MakeSink() is DtOuter<int>.Sink);
            Assert.IsFalse(DtOuter<string>.MakeSource() is DtOuter<object>.Source);
            Assert.IsFalse(new DtOuter<object>().MakeInstanceSink() is DtOuter<string>.Sink);
            Assert.IsTrue(DtOuter<int>.MakeSink().GetType() == typeof(DtOuter<int>.Sink));
        }

        [TestMethod]
        public void DelegatesCreatedInGenericCode_AreClosedOverTheCallersArguments()
        {
            Assert.IsTrue(DtHolder.MakeAction<int>() is Action<int>);
            Assert.IsFalse(DtHolder.MakeAction<int>() is Action<string>);
            Assert.IsFalse(DtHolder.MakeAction<string>() is Action<object>);
            Assert.IsTrue(DtHolder.MakeAction<string>() is Action<string>);
            Assert.IsTrue(DtHolder.MakeFunc<string>() is Func<object>);
            Assert.IsTrue(DtHolder.MakeFunc<string>() is Func<string>);
            Assert.IsTrue(DtHolder.MakeIdentity<int>() is Func<int, int>);
            Assert.IsFalse(DtHolder.MakeIdentity<int>() is Func<string, string>);
            Assert.IsTrue(DtHolder.MakeActionOfArray<int>().GetType() == typeof(Action<int[]>));
        }

        [TestMethod]
        public void InstanceMethodDelegates_KeepTheDelegateTypeNotTheMethodTypes()
        {
            DtHolder holder = new DtHolder();
            object ofObject = new Action<object>(holder.ObjectMethod);
            object ofString = new Action<string>(holder.ObjectMethod);
            Action<string> converted = new Action<object>(holder.ObjectMethod);

            Assert.IsTrue(ofObject is Action<string>);
            Assert.IsTrue(ofObject.GetType() == typeof(Action<object>));
            Assert.IsTrue(ofString.GetType() == typeof(Action<string>));
            Assert.IsFalse(ofString is Action<object>);
            Assert.IsTrue(converted.GetType() == typeof(Action<object>));
            Assert.IsTrue(converted.Method.Name == "ObjectMethod");
            Assert.IsTrue(converted.Target == holder);
        }

        #endregion

        #region GetType, IsInstanceOfType, IsAssignableFrom

        [TestMethod]
        public void GetType_OfGenericDelegate_IsTheClosedType()
        {
            object ofInt = new Action<int>(x => { });
            object ofString = new Action<string>(DtHolder.StaticString);
            object funcs = new Func<object, string>(o => null);
            Type type = ofInt.GetType();

            Assert.IsTrue(type == typeof(Action<int>));
            Assert.IsTrue(type.IsGenericType);
            Assert.IsFalse(type.IsGenericTypeDefinition);
            Assert.IsTrue(ofString.GetType().GetGenericArguments()[0] == typeof(string));
            Assert.IsTrue(funcs.GetType() == typeof(Func<object, string>));
            Assert.IsTrue(ofString.GetType().BaseType == typeof(MulticastDelegate));
        }

        [TestMethod]
        public void GetType_OfNonGenericDelegate_IsTheDelegateType()
        {
            object handler = new EventHandler((s, e) => { });
            object plain = new DtObjectSink(DtHolder.StaticObject);

            Assert.IsTrue(handler.GetType() == typeof(EventHandler));
            Assert.IsFalse(handler.GetType().IsGenericType);
            Assert.IsTrue(plain.GetType() == typeof(DtObjectSink));
        }

        [TestMethod]
        public void IsInstanceOfType_AndIsAssignableFrom_UseTheClosedType()
        {
            object ofString = new Action<string>(DtHolder.StaticString);
            object ofObject = new Action<object>(DtHolder.StaticObject);

            Assert.IsTrue(typeof(Action<string>).IsInstanceOfType(ofObject));
            Assert.IsFalse(typeof(Action<object>).IsInstanceOfType(ofString));
            Assert.IsFalse(typeof(Action<int>).IsInstanceOfType(ofString));
            Assert.IsTrue(typeof(Action<string>).IsAssignableFrom(ofObject.GetType()));
            Assert.IsTrue(typeof(Delegate).IsInstanceOfType(ofString));
            Assert.IsTrue(typeof(object).IsInstanceOfType(ofString));
            Assert.IsTrue(typeof(Action<string>).IsAssignableFrom(typeof(Action<object>)));
            Assert.IsFalse(typeof(Action<object>).IsAssignableFrom(typeof(Action<string>)));
        }

        #endregion

        #region Combine, Remove, Equals

        [TestMethod]
        public void Combine_OfTheSameType_BuildsAListOfThatType()
        {
            Action<string> first = DtHolder.StaticString;
            Delegate list = Delegate.Combine(first, (Action<string>)(x => { }));
            DtHolder holder = new DtHolder();
            Action<string> added = holder.StringMethod;

            added += DtHolder.StaticString;

            Assert.IsTrue(Delegate.Combine(first, first).GetType() == typeof(Action<string>));
            Assert.IsTrue(list.GetType() == typeof(Action<string>));
            Assert.IsTrue(list is Action<string>);
            Assert.IsFalse(list is Action<object>);
            Assert.IsFalse(list is Action<int>);
            Assert.IsTrue(Delegate.Combine(list, list).GetType() == typeof(Action<string>));
            Assert.AreEqual(2, added.GetInvocationList().Length);
            Assert.IsTrue(added.GetInvocationList()[0].GetType() == typeof(Action<string>));
            Assert.IsTrue((added - (Action<string>)DtHolder.StaticString).GetType() == typeof(Action<string>));
        }

        [TestMethod]
        public void Combine_WithANullSide_ReturnsTheOther()
        {
            Action<string> first = DtHolder.StaticString;

            Assert.IsTrue(Delegate.Combine(null, first).GetType() == typeof(Action<string>));
            Assert.IsTrue(Delegate.Combine(first, null).GetType() == typeof(Action<string>));
            Assert.IsNull(Delegate.Remove(null, first));
            Assert.IsTrue(Delegate.Remove(first, null) == (Delegate)first);
            Assert.IsNull(Delegate.Remove(first, first));
        }

        [TestMethod]
        public void Combine_OfDifferentTypes_ThrowsArgumentException()
        {
            Action<string> ofString = DtHolder.StaticString;
            Action<object> ofObject = DtHolder.StaticObject;
            Delegate list = Delegate.Combine(ofString, (Action<string>)(x => { }));
            Delegate handler = new EventHandler((s, e) => { });

            Assert.ThrowsException(typeof(ArgumentException), () => Delegate.Combine(ofString, ofObject));
            Assert.ThrowsException(typeof(ArgumentException), () => Delegate.Combine(ofObject, ofString));
            Assert.ThrowsException(typeof(ArgumentException), () => Delegate.Combine(handler, (Action)(() => { })));
            Assert.ThrowsException(typeof(ArgumentException), () => Delegate.Combine(ofString, (Action<int>)(x => { })));
            Assert.ThrowsException(typeof(ArgumentException), () => Delegate.Combine(list, ofObject));
            Assert.ThrowsException(
                typeof(ArgumentException),
                () =>
                {
                    Action<string> target = ofString;
                    target += new Action<object>(DtHolder.StaticObject);
                });
        }

        [TestMethod]
        public void Remove_OfADifferentType_ThrowsArgumentException()
        {
            Action<string> ofString = DtHolder.StaticString;
            Action<object> ofObject = DtHolder.StaticObject;
            Delegate list = Delegate.Combine(ofString, (Action<string>)(x => { }));
            Delegate handler = new EventHandler((s, e) => { });

            Assert.ThrowsException(typeof(ArgumentException), () => Delegate.Remove(ofString, ofObject));
            Assert.ThrowsException(typeof(ArgumentException), () => Delegate.Remove(list, ofObject));
            Assert.ThrowsException(typeof(ArgumentException), () => Delegate.Remove(handler, (Action)(() => { })));
        }

        [TestMethod]
        public void Equals_RequiresTheSameDelegateType()
        {
            Action<string> ofString = DtHolder.StaticObject;
            Action<object> ofObject = DtHolder.StaticObject;

            Assert.IsFalse(ofString.Equals(ofObject));
            Assert.IsFalse((Delegate)ofString == (Delegate)ofObject);
            Assert.IsTrue(ofString.Equals((Action<string>)DtHolder.StaticObject));
        }

        #endregion

        #region arrays

        [TestMethod]
        public void ArrayOfDelegates_FollowsReferenceCovarianceOfTheClosedType()
        {
            Action<object>[] ofObject = new Action<object>[1];

            Assert.IsTrue((object)ofObject is Action<string>[]);
            Assert.IsFalse((object)new Action<string>[1] is Action<int>[]);
            Assert.IsNotNull((Action<string>[])(object)ofObject);
        }

        [TestMethod]
        public void StoreIntoCovariantArray_ChecksTheClosedType()
        {
            Action<string>[] seenAsString = (Action<string>[])(object)new Action<object>[1];
            object[] ofString = new Action<string>[2];

            Assert.ThrowsException(
                typeof(ArrayTypeMismatchException),
                () => seenAsString[0] = new Action<string>(DtHolder.StaticString));

            seenAsString[0] = new Action<object>(DtHolder.StaticObject);
            seenAsString[0] = null;

            Assert.ThrowsException(typeof(ArrayTypeMismatchException), () => ofString[0] = new Action<int>(x => { }));

            ofString[0] = new Action<object>(DtHolder.StaticObject);
            ofString[1] = new Action<string>(DtHolder.StaticString);
        }

        [TestMethod]
        public void ArrayCopy_ChecksTheClosedTypeOfTheElements()
        {
            Action<string> ofString = DtHolder.StaticString;
            Action<object> ofObject = DtHolder.StaticObject;

            Assert.ThrowsException(
                typeof(ArrayTypeMismatchException),
                () => Array.Copy(new Action<string>[] { ofString }, new Action<int>[1], 1));
            Assert.ThrowsException(
                typeof(InvalidCastException),
                () => Array.Copy(new Action<string>[] { ofString }, new Action<object>[1], 1));
            Assert.ThrowsException(
                typeof(InvalidCastException),
                () => Array.Copy(new object[] { new Action<int>(x => { }) }, new Action<string>[1], 1));

            Array.Copy(new Action<object>[] { ofObject }, new Action<string>[1], 1);
            Array.Copy(new object[] { ofObject }, new Action<string>[1], 1);
        }

        #endregion

        #region reflection

        [TestMethod]
        public void FieldSetValue_ChecksTheClosedType()
        {
            DtFields fields = new DtFields();
            FieldInfo intAction = typeof(DtFields).GetField("IntAction");
            FieldInfo stringAction = typeof(DtFields).GetField("StringAction");
            FieldInfo objectAction = typeof(DtFields).GetField("ObjectAction");
            object ofString = new Action<string>(DtHolder.StaticString);
            object ofObject = new Action<object>(DtHolder.StaticObject);

            Assert.ThrowsException(typeof(ArgumentException), () => intAction.SetValue(fields, ofString));
            Assert.ThrowsException(typeof(ArgumentException), () => objectAction.SetValue(fields, ofString));

            stringAction.SetValue(fields, ofObject);
        }

        [TestMethod]
        public void MethodInvoke_ChecksTheClosedTypeOfDelegateArguments()
        {
            MethodInfo takeInt = typeof(DtFields).GetMethod("TakeIntAction");
            MethodInfo takeString = typeof(DtFields).GetMethod("TakeStringAction");
            object ofString = new Action<string>(DtHolder.StaticString);
            object ofObject = new Action<object>(DtHolder.StaticObject);

            Assert.ThrowsException(typeof(ArgumentException), () => takeInt.Invoke(null, new object[] { ofString }));

            takeInt.Invoke(null, new object[] { new Action<int>(x => { }) });
            takeString.Invoke(null, new object[] { ofObject });
            takeString.Invoke(null, new object[] { Delegate.Combine((Action<object>)DtHolder.StaticObject, (Action<object>)DtHolder.StaticObject) });
        }

        #endregion
    }
}
