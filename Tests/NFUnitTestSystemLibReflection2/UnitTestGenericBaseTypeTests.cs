// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Each test uses its own types, so no test depends on state or on a closed TypeSpec row that another one names.
    [TestClass]
    public class UnitTestGenericBaseTypeTests
    {
        [TestMethod]
        public void Base_Closed()
        {
            Type baseType = typeof(BtDerivedInt).BaseType;

            Assert.IsTrue(baseType == typeof(BtBaseInt<int>));
            Assert.IsTrue(baseType != typeof(BtBaseInt<string>));
            Assert.IsTrue(baseType.IsGenericType);
            Assert.IsFalse(baseType.IsGenericTypeDefinition);
            Assert.IsTrue(baseType.GetGenericTypeDefinition() == typeof(BtBaseInt<>));
            Assert.IsTrue(baseType.GetGenericArguments()[0] == typeof(int));
        }

        [TestMethod]
        public void Base_Subst()
        {
            Assert.IsTrue(typeof(BtDerivedOf<string>).BaseType == typeof(BtBaseOf<string>));
            Assert.IsTrue(typeof(BtDerivedOf<int>).BaseType == typeof(BtBaseOf<int>));
            Assert.IsTrue(typeof(BtDerivedOf<int>).BaseType != typeof(BtDerivedOf<string>).BaseType);
        }

        [TestMethod]
        public void Base_Instance()
        {
            Type baseType = new BtDerivedInstance<string>().GetType().BaseType;

            Assert.IsTrue(baseType == typeof(BtBaseInstance<string>));
            Assert.IsTrue(baseType.GetGenericArguments()[0] == typeof(string));
        }

        [TestMethod]
        public void Base_NestedArg()
        {
            Type baseType = typeof(BtDerivedNested).BaseType;
            Type[] arguments = baseType.GetGenericArguments();

            Assert.IsTrue(baseType == typeof(BtBaseNested<BtOther<int>>));
            Assert.IsTrue(baseType != typeof(BtBaseNested<BtOther<string>>));
            Assert.IsTrue(arguments[0] == typeof(BtOther<int>));
        }

        [TestMethod]
        public void Base_Plain()
        {
            Assert.IsTrue(typeof(BtPlainDerived).BaseType == typeof(BtPlainBase));
            Assert.IsTrue(typeof(BtPlainBase).BaseType == typeof(object));
            Assert.IsNull(typeof(object).BaseType);
        }

        [TestMethod]
        public void Base_Kinds()
        {
            Assert.IsTrue(typeof(BtStruct<int>).BaseType == typeof(ValueType));
            Assert.IsTrue(typeof(BtEnum).BaseType == typeof(Enum));
            Assert.IsNull(typeof(IBtInterface<int>).BaseType);
            Assert.IsTrue(typeof(int[]).BaseType == typeof(Array));
            Assert.IsTrue(typeof(BtBaseInt<int>[]).BaseType == typeof(Array));
        }

        [TestMethod]
        public void Base_Chain()
        {
            Type b = typeof(BtChainA<int>).BaseType;
            Type c = b.BaseType;

            Assert.IsTrue(b == typeof(BtChainB<int>));
            Assert.IsTrue(c.GetGenericTypeDefinition() == typeof(BtChainC<>));
            Assert.IsTrue(c.GetGenericArguments()[0].GetGenericTypeDefinition() == typeof(BtList<>));
            Assert.IsTrue(c.GetGenericArguments()[0].GetGenericArguments()[0] == typeof(int));
            Assert.IsTrue(c.BaseType == typeof(object));
        }

        [TestMethod]
        public void Base_Walk()
        {
            int depth = 0;

            for (Type t = typeof(BtChainA<string>); t != null; t = t.BaseType)
            {
                depth++;
            }

            Assert.AreEqual(4, depth);
        }

        [TestMethod]
        public void Base_Subclass()
        {
            Assert.IsTrue(typeof(BtDerivedInt).IsSubclassOf(typeof(BtBaseInt<int>)));
            Assert.IsFalse(typeof(BtDerivedInt).IsSubclassOf(typeof(BtBaseInt<string>)));
            Assert.IsFalse(typeof(BtBaseInt<int>).IsSubclassOf(typeof(BtBaseInt<int>)));
            Assert.IsFalse(typeof(BtDerivedInt).IsSubclassOf(typeof(BtBaseInt<>)));
        }

        [TestMethod]
        public void Base_Equals()
        {
            Type baseType = typeof(BtDerivedEquals).BaseType;

            Assert.IsTrue(baseType.Equals(typeof(BtBaseEquals<int>)));
        }

        [TestMethod]
        public void Base_Members()
        {
            Type baseType = typeof(BtDerivedMembers).BaseType;

            Assert.IsTrue(baseType.GetField("Item").FieldType == typeof(int));
            Assert.IsTrue(baseType.GetMethod("get_Value").ReturnType == typeof(int));
        }

        [TestMethod]
        public void Base_Open()
        {
            bool thrown = false;

            try
            {
                Type unused = typeof(BtDerivedOpen<>).BaseType;
            }
            catch (Exception)
            {
                thrown = true;
            }

            Assert.IsTrue(thrown);
        }

        // nested types of generic types

        [TestMethod]
        public void Decl_Nested()
        {
            Type nested = typeof(BtOuter<int>.Inner);

            Assert.IsTrue(nested.DeclaringType == typeof(BtOuter<int>));
            Assert.IsTrue(nested.DeclaringType != typeof(BtOuter<string>));
            Assert.IsTrue(nested.GetGenericArguments()[0] == typeof(int));
            Assert.AreEqual("Inner", nested.Name);
        }

        [TestMethod]
        public void Decl_NestedGeneric()
        {
            Type nested = typeof(BtOuterTwo<int>.Inner<string>);
            Type[] arguments = nested.GetGenericArguments();

            Assert.AreEqual(2, arguments.Length);
            Assert.IsTrue(arguments[0] == typeof(int));
            Assert.IsTrue(arguments[1] == typeof(string));
            Assert.IsTrue(nested.DeclaringType == typeof(BtOuterTwo<int>));
            Assert.IsTrue(nested.DeclaringType != typeof(BtOuterTwo<string>));
        }

        [TestMethod]
        public void Decl_Deep()
        {
            Type deep = typeof(BtOuterDeep<int>.Middle.Deepest);

            Assert.IsTrue(deep.DeclaringType == typeof(BtOuterDeep<int>.Middle));
            Assert.IsTrue(deep.DeclaringType.DeclaringType == typeof(BtOuterDeep<int>));
        }

        [TestMethod]
        public void Decl_Plain()
        {
            Assert.IsTrue(typeof(BtPlainOuter.Inner).DeclaringType == typeof(BtPlainOuter));
            Assert.IsTrue(typeof(BtPlainOuter).DeclaringType == typeof(UnitTestGenericBaseTypeTests));
        }

        [TestMethod]
        public void Decl_Open()
        {
            Assert.IsTrue(typeof(BtOuter<>.Inner).DeclaringType == typeof(BtOuter<>));
        }

        [TestMethod]
        public void Decl_Member()
        {
            Assert.IsTrue(typeof(BtMemberOwner<int>).GetMethod("Get").DeclaringType == typeof(BtMemberOwner<int>));
            Assert.IsTrue(typeof(BtMemberOwner<int>).GetField("Item").DeclaringType == typeof(BtMemberOwner<int>));
            Assert.IsTrue(typeof(BtMemberOwner<int>).GetMethod("Get").DeclaringType != typeof(BtMemberOwner<string>));
        }

        [TestMethod]
        public void Decl_StructOuter()
        {
            Type nested = typeof(BtStructOuter<int>.Inner);

            Assert.IsTrue(nested.DeclaringType == typeof(BtStructOuter<int>));
            Assert.IsTrue(nested.DeclaringType != typeof(BtStructOuter<string>));
            Assert.IsTrue(nested.DeclaringType.IsValueType);
            Assert.IsFalse(nested.IsValueType);
        }

        // names of closed generics

        [TestMethod]
        public void Name_Closed()
        {
            string intName = typeof(BtList<int>).FullName;

            Assert.IsTrue(intName.EndsWith("`1[System.Int32]"));
            Assert.IsTrue(typeof(BtList<string>).FullName.EndsWith("`1[System.String]"));
            Assert.AreEqual(intName, typeof(BtList<int>).ToString());
            Assert.IsFalse(typeof(BtList<>).FullName.EndsWith("]"));
            Assert.AreEqual("BtList`1", typeof(BtList<int>).Name);
        }

        [TestMethod]
        public void Name_NestedArgument()
        {
            string name = typeof(BtBaseNested<BtOther<int>>).FullName;

            Assert.IsTrue(name.EndsWith("BtOther`1[System.Int32]]"));
            Assert.IsTrue(name.IndexOf("BtBaseNested`1[") > 0);
        }

        [TestMethod]
        public void Name_TwoArguments()
        {
            Assert.IsTrue(typeof(BtOuterTwo<int>.Inner<string>).FullName.EndsWith("[System.Int32,System.String]"));
            Assert.IsTrue(typeof(BtList<int>[]).FullName.EndsWith("`1[System.Int32][]"));
        }

        [TestMethod]
        public void Name_ArrayArgument()
        {
            Assert.IsTrue(typeof(BtBaseNested<BtOther<int>[]>).FullName.EndsWith("BtOther`1[System.Int32][]]"));
        }

        #region types

        public struct BtStructOuter<T>
        {
            public class Inner
            {
            }
        }

        public class BtBaseInt<T>
        {
        }

        public class BtDerivedInt : BtBaseInt<int>
        {
        }

        public class BtBaseOf<T>
        {
        }

        public class BtDerivedOf<T> : BtBaseOf<T>
        {
        }

        public class BtBaseInstance<T>
        {
        }

        public class BtDerivedInstance<T> : BtBaseInstance<T>
        {
        }

        public class BtOther<T>
        {
        }

        public class BtBaseNested<T>
        {
        }

        public class BtDerivedNested : BtBaseNested<BtOther<int>>
        {
        }

        public class BtPlainBase
        {
        }

        public class BtPlainDerived : BtPlainBase
        {
        }

        public struct BtStruct<T>
        {
        }

        public enum BtEnum
        {
            One,
        }

        public interface IBtInterface<T>
        {
        }

        public class BtList<T>
        {
        }

        public class BtChainC<T>
        {
        }

        public class BtChainB<T> : BtChainC<BtList<T>>
        {
        }

        public class BtChainA<T> : BtChainB<T>
        {
        }

        public class BtBaseEquals<T>
        {
        }

        public class BtDerivedEquals : BtBaseEquals<int>
        {
        }

        public class BtBaseMembers<T>
        {
            public T Item;

            public T Value
            {
                get { return Item; }
            }
        }

        public class BtDerivedMembers : BtBaseMembers<int>
        {
        }

        public class BtBaseOpen<T>
        {
        }

        public class BtDerivedOpen<T> : BtBaseOpen<T>
        {
        }

        public class BtOuter<T>
        {
            public class Inner
            {
            }
        }

        public class BtOuterTwo<T>
        {
            public class Inner<U>
            {
            }
        }

        public class BtOuterDeep<T>
        {
            public class Middle
            {
                public class Deepest
                {
                }
            }
        }

        public class BtPlainOuter
        {
            public class Inner
            {
            }
        }

        public class BtMemberOwner<T>
        {
            public T Item;

            public T Get()
            {
                return Item;
            }
        }

        #endregion
    }
}
