// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using NFUnitTestIdentityHelper;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Each test uses its own types, so no test depends on state or on a closed TypeSpec row that another one names.
    [TestClass]
    public class UnitTestGenericTypeIdentityTests
    {
        #region identity

        [TestMethod]
        public void Identity_LiteralAndInstance()
        {
            Type literal = typeof(IdBoxA<int>);
            Type fromInstance = new IdBoxA<int>().GetType();

            Assert.IsTrue(literal == fromInstance);
            Assert.IsTrue(literal.Equals(fromInstance));
            Assert.AreEqual(literal.GetHashCode(), fromInstance.GetHashCode());
            Assert.IsTrue(literal != typeof(IdBoxA<string>));
            Assert.IsFalse(literal.Equals(typeof(IdBoxA<string>)));
        }

        [TestMethod]
        public void Identity_BaseAndLiteral()
        {
            Type baseType = typeof(IdDerivedB<int>).BaseType;

            Assert.IsTrue(baseType == typeof(IdBaseB<int>));
            Assert.IsTrue(baseType.Equals(typeof(IdBaseB<int>)));
            Assert.AreEqual(typeof(IdBaseB<int>).GetHashCode(), baseType.GetHashCode());
            Assert.IsTrue(baseType != typeof(IdDerivedB<string>).BaseType);
        }

        [TestMethod]
        public void Identity_Arrays()
        {
            Type literal = typeof(IdBoxC<int>[]);

            Assert.IsTrue(literal == new IdBoxC<int>[0].GetType());
            Assert.AreEqual(literal.GetHashCode(), new IdBoxC<int>[0].GetType().GetHashCode());
            Assert.IsTrue(literal != typeof(IdBoxC<int>));
            Assert.IsTrue(literal != typeof(IdBoxC<string>[]));
            Assert.IsTrue(literal.GetElementType() == typeof(IdBoxC<int>));
        }

        [TestMethod]
        public void Identity_NonGenericUnchanged()
        {
            Assert.IsTrue(typeof(IdPlainD) == new IdPlainD().GetType());
            Assert.AreEqual(typeof(IdPlainD).GetHashCode(), new IdPlainD().GetType().GetHashCode());
            Assert.IsTrue(typeof(IdPlainD) != typeof(object));
            Assert.IsTrue(typeof(int[]) == new int[0].GetType());
        }

        [TestMethod]
        public void Identity_Lock()
        {
            bool entered = false;

            lock (typeof(IdBoxE<int>))
            {
                lock (new IdBoxE<int>().GetType())
                {
                    entered = true;
                }
            }

            Assert.IsTrue(entered);
        }

        #endregion

        #region rows of another assembly

        [TestMethod]
        public void CrossAssembly_Literal()
        {
            Type local = typeof(IdxBox<int>);
            Type remote = IdxTypes.BoxOfInt();

            Assert.IsTrue(local == remote);
            Assert.IsTrue(local.Equals(remote));
            Assert.IsFalse(local != remote);
            Assert.AreEqual(local.GetHashCode(), remote.GetHashCode());
            Assert.IsTrue(remote != typeof(IdxBox<string>));
            Assert.IsTrue(IdxTypes.NewBoxOfInt().GetType() == local);
            Assert.AreEqual(local.GetHashCode(), IdxTypes.NewBoxOfInt().GetType().GetHashCode());
        }

        [TestMethod]
        public void CrossAssembly_Arrays()
        {
            Assert.IsTrue(typeof(IdxBox<int>[]) == IdxTypes.BoxOfIntArray());
            Assert.AreEqual(typeof(IdxBox<int>[]).GetHashCode(), IdxTypes.BoxOfIntArray().GetHashCode());
            Assert.IsTrue(typeof(IdxBox<string>[]) != IdxTypes.BoxOfIntArray());
            Assert.IsTrue(IdxTypes.BoxOfIntArray() != IdxTypes.BoxOfInt());
        }

        [TestMethod]
        public void CrossAssembly_BaseAndInterface()
        {
            Assert.IsTrue(typeof(IdxDerivedOf<string>).BaseType == typeof(IdxBase<string>));
            Assert.IsTrue(IdxTypes.BaseOfDerivedString() == typeof(IdxBase<string>));
            Assert.IsTrue(typeof(IdxDerivedInt).BaseType == IdxTypes.BaseOfInt());
            Assert.IsTrue(typeof(IdxDerivedInt).BaseType == typeof(IdxBase<int>));
            Assert.IsTrue(typeof(IdxImplString).GetInterfaces()[0] == typeof(IdxFace<string>));
            Assert.IsTrue(typeof(IdxImplString).GetInterfaces()[0] == IdxTypes.FaceOfString());
        }

        [TestMethod]
        public void CrossAssembly_Assignable()
        {
            Assert.IsTrue(typeof(IdxBase<int>).IsAssignableFrom(typeof(IdxDerivedInt)));
            Assert.IsFalse(typeof(IdxBase<string>).IsAssignableFrom(typeof(IdxDerivedInt)));
            Assert.IsTrue(typeof(IdxFace<string>).IsAssignableFrom(typeof(IdxImplString)));
            Assert.IsTrue(IdxTypes.FaceOfString().IsAssignableFrom(typeof(IdxImplString)));
            Assert.IsTrue(IdxTypes.BoxOfInt().IsAssignableFrom(typeof(IdxBox<int>)));
            Assert.IsTrue(typeof(IdxBox<int>[]).IsAssignableFrom(IdxTypes.BoxOfIntArray()));
        }

        #endregion

        #region open BaseType

        [TestMethod]
        public void OpenBase_Constructed()
        {
            Type baseType = typeof(IdOpenDerived<>).BaseType;

            Assert.IsNotNull(baseType);
            Assert.IsTrue(baseType.IsGenericType);
            Assert.IsFalse(baseType.IsGenericTypeDefinition);
            Assert.IsTrue(baseType.GetGenericTypeDefinition() == typeof(IdOpenBase<>));
            Assert.IsTrue(baseType != typeof(IdOpenBase<>));
            Assert.IsTrue(baseType == typeof(IdOpenDerived<>).BaseType);
            Assert.AreEqual(baseType.GetHashCode(), typeof(IdOpenDerived<>).BaseType.GetHashCode());
        }

        [TestMethod]
        public void OpenBase_OwnerIdentity()
        {
            Assert.IsTrue(typeof(IdOpenDerived<>).BaseType != typeof(IdOpenOther<>).BaseType);
            Assert.IsTrue(typeof(IdOpenDerived<>).BaseType != typeof(IdOpenBase<int>));
        }

        [TestMethod]
        public void OpenBase_NotSubclassOfDefinition()
        {
            Assert.IsFalse(typeof(IdOpenDerived<>).IsSubclassOf(typeof(IdOpenBase<>)));
            Assert.IsFalse(typeof(IdOpenBase<>).IsInstanceOfType(new IdOpenBase<int>()));
        }

        [TestMethod]
        public void OpenBase_ClosedBase()
        {
            Assert.IsTrue(typeof(IdOpenClosed<>).BaseType == typeof(IdOpenBase<int>));
            Assert.IsTrue(typeof(IdOpenClosed<>).IsSubclassOf(typeof(IdOpenBase<int>)));
        }

        [TestMethod]
        public void OpenBase_Chain()
        {
            Type current = typeof(IdChainA<>);
            int steps = 0;

            while (current != null)
            {
                current = current.BaseType;
                steps++;
            }

            // IdChainA, IdChainB<IdWrap<T>>, IdChainC<IdWrap<T>>, object
            Assert.AreEqual(4, steps);

            Type b = typeof(IdChainA<>).BaseType;
            Type c = b.BaseType;

            Assert.IsTrue(b.GetGenericTypeDefinition() == typeof(IdChainB<>));
            Assert.IsTrue(c.GetGenericTypeDefinition() == typeof(IdChainC<>));
            Assert.IsTrue(c.BaseType == typeof(object));
        }

        [TestMethod]
        public void OpenBase_ClosedStillWorks()
        {
            Assert.IsTrue(typeof(IdOpenDerived<string>).BaseType == typeof(IdOpenBase<string>));
            Assert.IsTrue(typeof(IdOpenDerived<string>).BaseType != typeof(IdOpenDerived<>).BaseType);
        }

        [TestMethod]
        public void OpenBase_GenericArgumentsUnsupported()
        {
            Assert.IsTrue(Throws(() => typeof(IdOpenDerived<>).BaseType.GetGenericArguments()));
            Assert.IsTrue(Throws(() => typeof(IdOpenBase<>).GetGenericArguments()));
            Assert.AreEqual(0, typeof(IdPlainD).GetGenericArguments().Length);
            Assert.AreEqual(0, typeof(int[]).GetGenericArguments().Length);
            Assert.AreEqual(0, typeof(IdBoxF<int>[]).GetGenericArguments().Length);
            Assert.AreEqual(1, typeof(IdBoxF<int>).GetGenericArguments().Length);
        }

        [TestMethod]
        public void OpenMembers_Unsupported()
        {
            // the Type of a member of a definition would be an open constructed type or a generic parameter
            Assert.IsTrue(Throws(() => typeof(IdOpenMember<>).GetMethod("Make").ReturnType));
            Assert.IsTrue(Throws(() => typeof(IdOpenMember<>).GetMethod("Make").GetParameters()));
            Assert.IsTrue(Throws(() => typeof(IdOpenMember<>).GetField("Item").FieldType));
            Assert.IsTrue(Throws(() => typeof(IdOpenMember<>).GetField("Boxed").FieldType));

            // the same members of a closed type are exact
            Assert.IsTrue(typeof(IdOpenMember<int>).GetMethod("Make").ReturnType == typeof(IdOpenBox<int>));
            Assert.IsTrue(typeof(IdOpenMember<int>).GetField("Item").FieldType == typeof(int));
            Assert.IsTrue(typeof(IdOpenMember<int>).GetMethod("Make").GetParameters()[0].ParameterType == typeof(IdOpenBox<int>));
        }

        [TestMethod]
        public void OpenBase_NameUsesParameter()
        {
            Assert.IsTrue(typeof(IdOpenDerived<>).BaseType.ToString().EndsWith("IdOpenBase`1[T]"));
            Assert.IsTrue(typeof(IdOpenBase<int>).ToString().EndsWith("IdOpenBase`1[System.Int32]"));
        }

        #endregion

        #region interfaces

        [TestMethod]
        public void Interfaces_Closed()
        {
            Type[] interfaces = typeof(IdImplInt).GetInterfaces();

            Assert.AreEqual(1, interfaces.Length);
            Assert.IsTrue(interfaces[0] == typeof(IdIFaceA<int>));
            Assert.IsTrue(interfaces[0] != typeof(IdIFaceA<string>));
            Assert.IsTrue(interfaces[0].GetGenericArguments()[0] == typeof(int));
        }

        [TestMethod]
        public void Interfaces_ThroughOwner()
        {
            Assert.IsTrue(typeof(IdImplOf<string>).GetInterfaces()[0] == typeof(IdIFaceB<string>));
            Assert.IsTrue(typeof(IdImplOf<int>).GetInterfaces()[0] == typeof(IdIFaceB<int>));
            Assert.IsTrue(typeof(IdImplOf<int>).GetInterfaces()[0] != typeof(IdImplOf<string>).GetInterfaces()[0]);
        }

        [TestMethod]
        public void Interfaces_ThroughBase()
        {
            Type[] interfaces = typeof(IdChild).GetInterfaces();

            Assert.AreEqual(1, interfaces.Length);
            Assert.IsTrue(interfaces[0] == typeof(IdIFaceC<int>));
        }

        [TestMethod]
        public void Interfaces_Definition()
        {
            Type[] interfaces = typeof(IdImplDef<>).GetInterfaces();

            Assert.AreEqual(1, interfaces.Length);
            Assert.IsFalse(interfaces[0].IsGenericTypeDefinition);
            Assert.IsTrue(interfaces[0].GetGenericTypeDefinition() == typeof(IdIFaceD<>));
            Assert.IsTrue(interfaces[0] != typeof(IdIFaceD<>));
            Assert.IsTrue(interfaces[0] == typeof(IdImplDef<>).GetInterfaces()[0]);
        }

        [TestMethod]
        public void Interfaces_NotRepeated()
        {
            Assert.AreEqual(1, typeof(IdDupDerived).GetInterfaces().Length);
            Assert.AreEqual(1, typeof(IdDupBase).GetInterfaces().Length);
        }

        [TestMethod]
        public void Interfaces_NonGeneric()
        {
            Type[] interfaces = typeof(IdPlainImpl).GetInterfaces();

            Assert.AreEqual(1, interfaces.Length);
            Assert.IsTrue(interfaces[0] == typeof(IdIPlain));
        }

        [TestMethod]
        public void Interfaces_Arrays()
        {
            Assert.IsTrue(Contains(typeof(int[]).GetInterfaces(), typeof(IEnumerable<int>)));
            Assert.IsTrue(Contains(typeof(int[]).GetInterfaces(), typeof(ICollection<int>)));
            Assert.IsFalse(Contains(typeof(int[]).GetInterfaces(), typeof(IEnumerable<string>)));
            Assert.IsTrue(Contains(typeof(string[]).GetInterfaces(), typeof(IEnumerable<string>)));
            Assert.IsTrue(Contains(typeof(IdBoxG<int>[]).GetInterfaces(), typeof(IEnumerable<IdBoxG<int>>)));
            Assert.IsFalse(Contains(typeof(IdBoxG<int>[]).GetInterfaces(), typeof(IEnumerable<IdBoxG<string>>)));
            Assert.IsTrue(Contains(typeof(int[][]).GetInterfaces(), typeof(IEnumerable<int[]>)));
            Assert.IsTrue(Contains(typeof(int[]).GetInterfaces(), typeof(IEnumerable)));
        }

        #endregion

        #region IsAssignableFrom

        [TestMethod]
        public void Assignable_NullAndSame()
        {
            Assert.IsFalse(typeof(IdPlainD).IsAssignableFrom(null));
            Assert.IsTrue(typeof(IdPlainD).IsAssignableFrom(typeof(IdPlainD)));
            Assert.IsTrue(typeof(IdBoxH<int>).IsAssignableFrom(typeof(IdBoxH<int>)));
            Assert.IsFalse(typeof(IdBoxH<int>).IsAssignableFrom(typeof(IdBoxH<string>)));
        }

        [TestMethod]
        public void Assignable_Object()
        {
            Assert.IsTrue(typeof(object).IsAssignableFrom(typeof(IdPlainD)));
            Assert.IsTrue(typeof(object).IsAssignableFrom(typeof(IdIPlain)));
            Assert.IsTrue(typeof(object).IsAssignableFrom(typeof(int)));
            Assert.IsTrue(typeof(object).IsAssignableFrom(typeof(int[])));
            Assert.IsTrue(typeof(object).IsAssignableFrom(typeof(IdEnumA)));
            Assert.IsTrue(typeof(object).IsAssignableFrom(typeof(IdBoxH<int>)));
            Assert.IsTrue(typeof(object).IsAssignableFrom(typeof(IdOpenBase<>)));
        }

        [TestMethod]
        public void Assignable_ClassesAndInterfaces()
        {
            Assert.IsTrue(typeof(IdPlainBase).IsAssignableFrom(typeof(IdPlainDerived)));
            Assert.IsFalse(typeof(IdPlainDerived).IsAssignableFrom(typeof(IdPlainBase)));
            Assert.IsTrue(typeof(IdIPlain).IsAssignableFrom(typeof(IdPlainImpl)));
            Assert.IsTrue(typeof(IdIPlain).IsAssignableFrom(typeof(IdIPlainChild)));
            Assert.IsFalse(typeof(IdIPlainChild).IsAssignableFrom(typeof(IdIPlain)));
            Assert.IsFalse(typeof(IdPlainImpl).IsAssignableFrom(typeof(IdIPlain)));
            Assert.IsTrue(typeof(IdIPlain).IsAssignableFrom(typeof(IdPlainImplDerived)));
        }

        [TestMethod]
        public void Assignable_ValueTypes()
        {
            Assert.IsTrue(typeof(ValueType).IsAssignableFrom(typeof(IdStructA)));
            Assert.IsTrue(typeof(IdIPlain).IsAssignableFrom(typeof(IdStructA)));
            Assert.IsTrue(typeof(Enum).IsAssignableFrom(typeof(IdEnumA)));
            Assert.IsTrue(typeof(ValueType).IsAssignableFrom(typeof(IdEnumA)));
            Assert.IsFalse(typeof(int).IsAssignableFrom(typeof(IdEnumA)));
            Assert.IsFalse(typeof(IdEnumA).IsAssignableFrom(typeof(int)));
            Assert.IsFalse(typeof(IdStructA).IsAssignableFrom(typeof(object)));
            Assert.IsFalse(typeof(long).IsAssignableFrom(typeof(int)));
        }

        [TestMethod]
        public void Assignable_Nullable()
        {
            Assert.IsTrue(typeof(int?).IsAssignableFrom(typeof(int)));
            Assert.IsFalse(typeof(int?).IsAssignableFrom(typeof(long)));
            Assert.IsFalse(typeof(int).IsAssignableFrom(typeof(int?)));
            Assert.IsTrue(typeof(int?).IsAssignableFrom(typeof(int?)));
        }

        [TestMethod]
        public void Assignable_GenericClasses()
        {
            Assert.IsTrue(typeof(IdGBase<int>).IsAssignableFrom(typeof(IdGDerivedInt)));
            Assert.IsFalse(typeof(IdGBase<string>).IsAssignableFrom(typeof(IdGDerivedInt)));
            Assert.IsTrue(typeof(IdGBase<string>).IsAssignableFrom(typeof(IdGDerivedOf<string>)));
            Assert.IsFalse(typeof(IdGBase<string>).IsAssignableFrom(typeof(IdGDerivedOf<int>)));
            Assert.IsFalse(typeof(IdGDerivedInt).IsAssignableFrom(typeof(IdGBase<int>)));
        }

        [TestMethod]
        public void Assignable_GenericInterfaces()
        {
            Assert.IsTrue(typeof(IdIFaceE<int>).IsAssignableFrom(typeof(IdImplE)));
            Assert.IsFalse(typeof(IdIFaceE<string>).IsAssignableFrom(typeof(IdImplE)));
            Assert.IsTrue(typeof(IdIFaceE<string>).IsAssignableFrom(typeof(IdImplEOf<string>)));
            Assert.IsFalse(typeof(IdIFaceE<int>).IsAssignableFrom(typeof(IdImplEOf<string>)));
        }

        [TestMethod]
        public void Assignable_Definitions()
        {
            Assert.IsTrue(typeof(IdGBase<>).IsAssignableFrom(typeof(IdGBase<>)));
            Assert.IsFalse(typeof(IdGBase<>).IsAssignableFrom(typeof(IdGBase<int>)));
            Assert.IsFalse(typeof(IdGBase<>).IsAssignableFrom(typeof(IdGDerivedInt)));
            Assert.IsFalse(typeof(IdGBase<int>).IsAssignableFrom(typeof(IdGBase<>)));
            Assert.IsFalse(typeof(IdIFaceE<>).IsAssignableFrom(typeof(IdImplE)));
            Assert.IsFalse(typeof(IdOpenBase<>).IsAssignableFrom(typeof(IdOpenDerived<>)));
        }

        [TestMethod]
        public void Assignable_Arrays()
        {
            Assert.IsTrue(typeof(int[]).IsAssignableFrom(typeof(int[])));
            Assert.IsTrue(typeof(object[]).IsAssignableFrom(typeof(string[])));
            Assert.IsFalse(typeof(string[]).IsAssignableFrom(typeof(object[])));
            Assert.IsTrue(typeof(Array).IsAssignableFrom(typeof(int[])));
            Assert.IsTrue(typeof(Array).IsAssignableFrom(typeof(string[][])));
            Assert.IsFalse(typeof(object[]).IsAssignableFrom(typeof(int[])));
            Assert.IsFalse(typeof(int[]).IsAssignableFrom(typeof(long[])));
            Assert.IsFalse(typeof(int[]).IsAssignableFrom(typeof(Array)));
            Assert.IsFalse(typeof(int[]).IsAssignableFrom(typeof(object)));
            Assert.IsFalse(typeof(int[]).IsAssignableFrom(typeof(int)));
        }

        [TestMethod]
        public void Assignable_JaggedArrays()
        {
            Assert.IsTrue(typeof(object[]).IsAssignableFrom(typeof(string[][])));
            Assert.IsTrue(typeof(object[][]).IsAssignableFrom(typeof(string[][])));
            Assert.IsTrue(typeof(Array[]).IsAssignableFrom(typeof(int[][])));
            Assert.IsFalse(typeof(object[][]).IsAssignableFrom(typeof(string[])));
            Assert.IsFalse(typeof(int[][]).IsAssignableFrom(typeof(string[][])));
            Assert.IsFalse(typeof(object[][]).IsAssignableFrom(typeof(object[])));
        }

        [TestMethod]
        public void Assignable_GenericElementArrays()
        {
            Assert.IsTrue(typeof(IdBoxI<int>[]).IsAssignableFrom(typeof(IdBoxI<int>[])));
            Assert.IsFalse(typeof(IdBoxI<int>[]).IsAssignableFrom(typeof(IdBoxI<string>[])));
            Assert.IsTrue(typeof(object[]).IsAssignableFrom(typeof(IdBoxI<int>[])));
            Assert.IsTrue(typeof(IdGBase<int>[]).IsAssignableFrom(typeof(IdGDerivedInt[])));
            Assert.IsFalse(typeof(IdGBase<string>[]).IsAssignableFrom(typeof(IdGDerivedInt[])));
        }

        [TestMethod]
        public void Assignable_ArraysAsInterfaces()
        {
            Assert.IsTrue(typeof(IEnumerable<int>).IsAssignableFrom(typeof(int[])));
            Assert.IsTrue(typeof(ICollection<int>).IsAssignableFrom(typeof(int[])));
            Assert.IsTrue(typeof(IEnumerable).IsAssignableFrom(typeof(int[])));
            Assert.IsFalse(typeof(IEnumerable<string>).IsAssignableFrom(typeof(int[])));
            Assert.IsTrue(typeof(IEnumerable<string>).IsAssignableFrom(typeof(string[])));
            Assert.IsTrue(typeof(IEnumerable<object>).IsAssignableFrom(typeof(string[])));
            Assert.IsFalse(typeof(IEnumerable<object>).IsAssignableFrom(typeof(int[])));
            Assert.IsTrue(typeof(IEnumerable<int[]>).IsAssignableFrom(typeof(int[][])));
            Assert.IsTrue(typeof(IEnumerable<IdBoxJ<int>>).IsAssignableFrom(typeof(IdBoxJ<int>[])));
            Assert.IsFalse(typeof(IEnumerable<IdBoxJ<string>>).IsAssignableFrom(typeof(IdBoxJ<int>[])));
        }

        [TestMethod]
        public void Assignable_VarianceUnsupported()
        {
            Assert.IsTrue(Throws(() => typeof(IEnumerable<object>).IsAssignableFrom(typeof(IdEnumerable))));
            Assert.IsTrue(Throws(() => typeof(IEnumerable<object>).IsAssignableFrom(typeof(IEnumerable<string>))));
            Assert.IsTrue(Throws(() => typeof(Func<object>).IsAssignableFrom(typeof(Func<string>))));

            // the same arguments are exact, and so is an unrelated definition
            Assert.IsTrue(typeof(IEnumerable<string>).IsAssignableFrom(typeof(IdEnumerable)));
            Assert.IsTrue(typeof(Func<string>).IsAssignableFrom(typeof(Func<string>)));
            Assert.IsFalse(typeof(IdIFaceE<int>).IsAssignableFrom(typeof(IdIFaceE<string>)));
        }

        [TestMethod]
        public void Assignable_IntegralArraysUnsupported()
        {
            Assert.IsTrue(Throws(() => typeof(int[]).IsAssignableFrom(typeof(uint[]))));
            Assert.IsTrue(Throws(() => typeof(IdEnumB[]).IsAssignableFrom(typeof(int[]))));
            Assert.IsTrue(Throws(() => typeof(int[][]).IsAssignableFrom(typeof(uint[][]))));
        }

        #endregion

        private static bool Throws(Func<object> action)
        {
            try
            {
                action();
            }
            catch (NotSupportedException)
            {
                return true;
            }

            return false;
        }

        private static bool Throws(Func<bool> action)
        {
            try
            {
                action();
            }
            catch (NotSupportedException)
            {
                return true;
            }

            return false;
        }

        private static bool Contains(Type[] types, Type type)
        {
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i] == type)
                {
                    return true;
                }
            }

            return false;
        }

        #region helper types

        public class IdBoxA<T> { }
        public class IdBoxC<T> { }
        public class IdBoxE<T> { }
        public class IdBoxF<T> { }
        public class IdBoxG<T> { }
        public class IdBoxH<T> { }
        public class IdBoxI<T> { }
        public class IdBoxJ<T> { }

        public class IdBaseB<T> { }
        public class IdDerivedB<T> : IdBaseB<T> { }

        public class IdPlainD { }

        public class IdOpenBase<T> { }
        public class IdOpenDerived<T> : IdOpenBase<T> { }
        public class IdOpenOther<T> : IdOpenBase<T> { }
        public class IdOpenClosed<T> : IdOpenBase<int> { }

        public class IdOpenBox<T> { }

        public class IdOpenMember<T>
        {
            public T Item;
            public IdOpenBox<T> Boxed;

            public IdOpenBox<T> Make(IdOpenBox<T> arg)
            {
                return null;
            }
        }

        public class IdWrap<T> { }
        public class IdChainC<T> { }
        public class IdChainB<U> : IdChainC<U> { }
        public class IdChainA<T> : IdChainB<IdWrap<T>> { }

        public interface IdIFaceA<T> { }
        public class IdImplInt : IdIFaceA<int> { }

        public interface IdIFaceB<T> { }
        public class IdImplOf<T> : IdIFaceB<T> { }

        public interface IdIFaceC<T> { }
        public class IdParent<T> : IdIFaceC<T> { }
        public class IdChild : IdParent<int> { }

        public interface IdIFaceD<T> { }
        public class IdImplDef<T> : IdIFaceD<T> { }

        public interface IdIDup { }
        public class IdDupBase : IdIDup { }
        public class IdDupDerived : IdDupBase, IdIDup { }

        public interface IdIPlain { }
        public interface IdIPlainChild : IdIPlain { }
        public class IdPlainImpl : IdIPlain { }
        public class IdPlainImplDerived : IdPlainImpl { }

        public class IdPlainBase { }
        public class IdPlainDerived : IdPlainBase { }

        public struct IdStructA : IdIPlain { }
        public enum IdEnumA { One }
        public enum IdEnumB { Two }

        public class IdGBase<T> { }
        public class IdGDerivedInt : IdGBase<int> { }
        public class IdGDerivedOf<T> : IdGBase<T> { }

        public interface IdIFaceE<T> { }
        public class IdImplE : IdIFaceE<int> { }
        public class IdImplEOf<T> : IdIFaceE<T> { }

        public class IdEnumerable : IEnumerable<string>
        {
            public IEnumerator<string> GetEnumerator()
            {
                return null;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return null;
            }
        }

        #endregion
    }
}
