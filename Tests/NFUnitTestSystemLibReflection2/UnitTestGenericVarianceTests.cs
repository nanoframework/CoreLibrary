// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    public interface IVarOut<out T>
    {
    }

    public interface IVarIn<in T>
    {
    }

    public interface IVarInv<T>
    {
    }

    public interface IVarBoth<in A, out B>
    {
    }

    public interface IVarOutBase<out T> : IVarOut<T>
    {
    }

    public class VarBase
    {
    }

    public class VarDerived : VarBase
    {
    }

    public class VarOther
    {
    }

    public struct VarStruct
    {
    }

    public enum VarEnumI : int
    {
        A,
    }

    public enum VarEnumJ : int
    {
        A,
    }

    public enum VarEnumU : uint
    {
        A,
    }

    public enum VarEnumB : byte
    {
        A,
    }

    public class VarCOut<T> : IVarOut<T>
    {
    }

    public class VarCIn<T> : IVarIn<T>
    {
    }

    public class VarCInv<T> : IVarInv<T>
    {
    }

    public class VarCBoth<A, B> : IVarBoth<A, B>
    {
    }

    public class VarCOutBase<T> : IVarOutBase<T>
    {
    }

    public class VarCDerived : VarCOut<VarDerived>
    {
    }

    public class VarCTwo : IVarOut<VarDerived>, IVarOut<VarOther>
    {
    }

    public class VarCMulti : IVarOut<VarDerived>, IVarIn<VarBase>
    {
    }

    public class VarGBase<T>
    {
    }

    public class VarGDerived<T> : VarGBase<T>
    {
    }

    public class VarCmp : IComparable<VarBase>
    {
        public int CompareTo(VarBase other)
        {
            return 0;
        }
    }

    public class VarTake
    {
        public static int Count;

        public IVarOut<VarBase> Field;

        public void Take(IVarOut<VarBase> value)
        {
            Count++;
        }
    }

    // Variance of generic interfaces and delegates on reference-type arguments, and the array rules of ECMA-335.
    // Every expected value was printed by .NET 10.
    [TestClass]
    public class UnitTestGenericVarianceTests
    {
        [TestMethod]
        public void Variance_Covariant()
        {
            object derived = new VarCOut<VarDerived>();
            object @base = new VarCOut<VarBase>();

            Assert.IsTrue(derived is IVarOut<VarBase>);
            Assert.IsTrue(derived is IVarOut<object>);
            Assert.IsFalse(@base is IVarOut<VarDerived>);
            Assert.IsFalse(derived is IVarOut<VarOther>);
            Assert.IsNotNull((IVarOut<VarBase>)derived);
            Assert.IsNull(@base as IVarOut<VarDerived>);
            Assert.ThrowsException(typeof(InvalidCastException), () => { IVarOut<VarDerived> d = (IVarOut<VarDerived>)@base; });
        }

        [TestMethod]
        public void Variance_Contravariant()
        {
            object @base = new VarCIn<VarBase>();
            object derived = new VarCIn<VarDerived>();

            Assert.IsTrue(@base is IVarIn<VarDerived>);
            Assert.IsFalse(derived is IVarIn<VarBase>);
            Assert.IsNull(derived as IVarIn<VarBase>);
        }

        [TestMethod]
        public void Variance_Invariant()
        {
            object derived = new VarCInv<VarDerived>();

            Assert.IsFalse(derived is IVarInv<VarBase>);
            Assert.IsTrue(derived is IVarInv<VarDerived>);
            Assert.IsFalse(new VarGDerived<VarDerived>() is VarGBase<VarBase>);
        }

        [TestMethod]
        public void Variance_ValueTypeArguments()
        {
            Assert.IsFalse((object)new VarCOut<int>() is IVarOut<object>);
            Assert.IsFalse((object)new VarCOut<VarStruct>() is IVarOut<object>);
            Assert.IsFalse((object)new VarCOut<VarEnumI>() is IVarOut<object>);
            Assert.IsFalse((object)new VarCOut<VarEnumI>() is IVarOut<Enum>);
            Assert.IsFalse((object)new VarCOut<VarEnumI>() is IVarOut<ValueType>);
            Assert.IsTrue((object)new VarCOut<VarEnumI>() is IVarOut<VarEnumI>);
        }

        [TestMethod]
        public void Variance_ArrayArguments()
        {
            Assert.IsTrue((object)new VarCOut<int[]>() is IVarOut<object>);
            Assert.IsTrue((object)new VarCOut<int[]>() is IVarOut<Array>);
            Assert.IsTrue((object)new VarCOut<VarDerived[]>() is IVarOut<VarBase[]>);
            Assert.IsTrue((object)new VarCOut<int[]>() is IVarOut<uint[]>);
            Assert.IsFalse((object)new VarCOut<int[]>() is IVarOut<long[]>);
            Assert.IsTrue((object)new VarCOut<string[]>() is IVarOut<IEnumerable>);
        }

        [TestMethod]
        public void Variance_Nested()
        {
            Assert.IsTrue((object)new VarCOut<VarCOut<VarDerived>>() is IVarOut<IVarOut<VarBase>>);
            Assert.IsFalse((object)new VarCOut<VarCOut<VarDerived>>() is IVarOut<VarCOut<VarBase>>);
            Assert.IsTrue((object)new VarCOut<IVarIn<VarBase>>() is IVarOut<IVarIn<VarDerived>>);
            Assert.IsFalse((object)new VarCOut<IVarIn<VarDerived>>() is IVarOut<IVarIn<VarBase>>);
            Assert.IsTrue((object)new VarCIn<IVarOut<VarBase>>() is IVarIn<IVarOut<VarDerived>>);
            Assert.IsFalse((object)new VarCOut<VarCInv<VarDerived>>() is IVarOut<VarCInv<VarBase>>);
        }

        [TestMethod]
        public void Variance_BaseAndInterfaceChains()
        {
            Assert.IsTrue((object)new VarCOutBase<VarDerived>() is IVarOut<VarBase>);
            Assert.IsTrue((object)new VarCOutBase<VarDerived>() is IVarOutBase<VarBase>);
            Assert.IsTrue((object)new VarCDerived() is IVarOut<VarBase>);
            Assert.IsFalse((object)new VarCDerived() is IVarOut<VarOther>);
            Assert.IsTrue((object)new VarCTwo() is IVarOut<VarBase>);
            Assert.IsTrue((object)new VarCTwo() is IVarOut<object>);
            Assert.IsTrue((object)new VarCMulti() is IVarIn<VarDerived>);
            Assert.IsFalse((object)new VarCMulti() is IVarIn<VarOther>);
        }

        [TestMethod]
        public void Variance_Both()
        {
            Assert.IsTrue((object)new VarCBoth<VarBase, VarDerived>() is IVarBoth<VarDerived, VarBase>);
            Assert.IsFalse((object)new VarCBoth<VarDerived, VarBase>() is IVarBoth<VarBase, VarDerived>);
        }

        [TestMethod]
        public void Variance_Comparable()
        {
            Assert.IsTrue((object)new VarCmp() is IComparable<VarDerived>);
            Assert.IsTrue((object)new VarCmp() is IComparable<VarBase>);
            Assert.IsFalse((object)new VarCmp() is IComparable<VarOther>);
        }

        [TestMethod]
        public void Variance_Enumerable()
        {
            Assert.IsTrue((object)new VarDerived[0] is System.Collections.Generic.IEnumerable<VarBase>);
        }

        [TestMethod]
        public void Variance_Store()
        {
            IVarOut<VarBase>[] items = new IVarOut<VarBase>[2];

            items[0] = new VarCOut<VarDerived>();
            items[1] = new VarCOut<VarBase>();

            Assert.IsNotNull(items[0]);
            Assert.ThrowsException(
                typeof(Exception),
                () =>
                {
                    object[] objects = new IVarOut<VarDerived>[1];
                    objects[0] = new VarCOut<VarBase>();
                });
        }

        [TestMethod]
        public void Variance_ArrayCopy()
        {
            IVarOut<VarDerived>[] source = new IVarOut<VarDerived>[1] { new VarCOut<VarDerived>() };
            IVarOut<VarBase>[] target = new IVarOut<VarBase>[1];

            Array.Copy(source, target, 1);

            Assert.IsNotNull(target[0]);

            IVarOut<VarBase>[] wide = new IVarOut<VarBase>[1] { new VarCOut<VarBase>() };
            IVarOut<VarDerived>[] narrow = new IVarOut<VarDerived>[1];

            Assert.ThrowsException(typeof(InvalidCastException), () => Array.Copy(wide, narrow, 1));
        }

        [TestMethod]
        public void Variance_ArrayCovariantCast()
        {
            object derived = new IVarOut<VarDerived>[1];

            Assert.IsTrue(derived is IVarOut<VarBase>[]);
            Assert.IsTrue(derived is object[]);
            Assert.IsFalse((object)new IVarOut<VarBase>[1] is IVarOut<VarDerived>[]);
            Assert.IsTrue((object)new VarCOut<VarDerived>[1] is IVarOut<VarBase>[]);
        }

        [TestMethod]
        public void Variance_Invoke()
        {
            MethodInfo take = typeof(VarTake).GetMethod("Take");
            VarTake target = new VarTake();
            int before = VarTake.Count;

            take.Invoke(target, new object[] { new VarCOut<VarDerived>() });
            take.Invoke(target, new object[] { new VarCOut<VarBase>() });

            Assert.AreEqual(before + 2, VarTake.Count);
            Assert.ThrowsException(typeof(InvalidCastException), () => take.Invoke(target, new object[] { new VarCOut<VarOther>() }));
            Assert.ThrowsException(typeof(InvalidCastException), () => take.Invoke(target, new object[] { new VarCOut<int>() }));
        }

        [TestMethod]
        public void Variance_SetValue()
        {
            FieldInfo field = typeof(VarTake).GetField("Field");
            VarTake target = new VarTake();

            field.SetValue(target, new VarCOut<VarDerived>());

            Assert.IsNotNull(target.Field);
            Assert.ThrowsException(typeof(Exception), () => field.SetValue(target, new VarCOut<VarOther>()));
        }

        [TestMethod]
        public void Variance_IsInstanceOfType()
        {
            Assert.IsTrue(typeof(IVarOut<VarBase>).IsInstanceOfType(new VarCOut<VarDerived>()));
            Assert.IsFalse(typeof(IVarOut<VarDerived>).IsInstanceOfType(new VarCOut<VarBase>()));
            Assert.IsTrue(typeof(IVarOut<VarBase>[]).IsInstanceOfType(new IVarOut<VarDerived>[0]));
        }

        [TestMethod]
        public void Variance_IsAssignableFrom()
        {
            Assert.IsTrue(typeof(IVarOut<VarBase>).IsAssignableFrom(typeof(IVarOut<VarDerived>)));
            Assert.IsFalse(typeof(IVarOut<VarDerived>).IsAssignableFrom(typeof(IVarOut<VarBase>)));
            Assert.IsTrue(typeof(IVarOut<VarBase>).IsAssignableFrom(typeof(VarCOut<VarDerived>)));
            Assert.IsTrue(typeof(IVarOut<VarBase>).IsAssignableFrom(typeof(VarCDerived)));
            Assert.IsTrue(typeof(IVarIn<VarDerived>).IsAssignableFrom(typeof(IVarIn<VarBase>)));
            Assert.IsFalse(typeof(IVarInv<VarBase>).IsAssignableFrom(typeof(IVarInv<VarDerived>)));
            Assert.IsFalse(typeof(VarGBase<VarBase>).IsAssignableFrom(typeof(VarGDerived<VarDerived>)));
            Assert.IsTrue(typeof(Func<VarDerived, VarBase>).IsAssignableFrom(typeof(Func<VarBase, VarDerived>)));
            Assert.IsFalse(typeof(Func<VarBase, VarDerived>).IsAssignableFrom(typeof(Func<VarDerived, VarBase>)));
            Assert.IsTrue(typeof(Action<VarDerived>).IsAssignableFrom(typeof(Action<VarBase>)));
            Assert.IsFalse(typeof(Action<int>).IsAssignableFrom(typeof(Action<object>)));
            Assert.IsFalse(typeof(Func<object>).IsAssignableFrom(typeof(Func<int>)));
            Assert.IsTrue(typeof(Func<object>).IsAssignableFrom(typeof(Func<string>)));
        }

        [TestMethod]
        public void Array_IntegralSameSize()
        {
            Assert.IsTrue((object)new int[1] is uint[]);
            Assert.IsTrue((object)new uint[1] is int[]);
            Assert.IsTrue((object)new byte[1] is sbyte[]);
            Assert.IsTrue((object)new long[1] is ulong[]);
            Assert.IsTrue((object)new VarEnumI[1] is int[]);
            Assert.IsTrue((object)new VarEnumI[1] is uint[]);
            Assert.IsTrue((object)new VarEnumI[1] is VarEnumJ[]);
            Assert.IsTrue((object)new int[1] is VarEnumI[]);
            Assert.IsTrue((object)new VarEnumU[1] is int[]);
            Assert.IsTrue((object)new VarEnumB[1] is sbyte[]);
            Assert.IsTrue((object)new int[1][] is uint[][]);
        }

        [TestMethod]
        public void Array_IntegralDifferentSize()
        {
            Assert.IsFalse((object)new int[1] is long[]);
            Assert.IsFalse((object)new char[1] is short[]);
            Assert.IsFalse((object)new bool[1] is byte[]);
            Assert.IsFalse((object)new float[1] is int[]);
            Assert.IsFalse((object)new int[1] is object[]);
            Assert.IsFalse((object)new int[1] is ValueType[]);
            Assert.IsFalse((object)new VarEnumI[1] is Enum[]);
            Assert.IsFalse((object)new VarStruct[1] is ValueType[]);
        }

        [TestMethod]
        public void Array_Depth()
        {
            Assert.IsTrue((object)new string[1][] is object[]);
            Assert.IsTrue((object)new string[1][] is object[][]);
            Assert.IsTrue((object)new string[1][][] is object[][]);
            Assert.IsTrue((object)new int[1][] is object[]);
            Assert.IsTrue((object)new int[1][] is Array[]);
            Assert.IsTrue((object)new VarDerived[1][] is VarBase[][]);
        }

        [TestMethod]
        public void Array_CollectionViews()
        {
            object derived = new VarDerived[1];
            object integers = new int[1];

            Assert.IsTrue(derived is System.Collections.Generic.IEnumerable<VarBase>);
            Assert.IsTrue(integers is System.Collections.Generic.IEnumerable<uint>);
            Assert.IsFalse(integers is System.Collections.Generic.IEnumerable<object>);
            Assert.IsFalse(integers is System.Collections.Generic.IEnumerable<long>);
            Assert.IsTrue(integers is System.Collections.Generic.IEnumerable<VarEnumI>);
            Assert.IsTrue((object)new VarDerived[1][] is System.Collections.Generic.IEnumerable<VarBase[]>);
            Assert.IsTrue((object)new VarCOut<VarDerived>[1] is System.Collections.Generic.IEnumerable<IVarOut<VarBase>>);
            Assert.IsFalse((object)new VarDerived[1] is System.Collections.Generic.IEnumerable<IVarOut<VarBase>>);
        }

        [TestMethod]
        public void Array_CopyIntegral()
        {
            int[] source = new int[2] { -1, 5 };
            uint[] target = new uint[2];

            Array.Copy(source, target, 2);

            Assert.AreEqual(4294967295u, target[0]);
            Assert.AreEqual(5u, target[1]);
        }

        [TestMethod]
        public void Array_IsAssignableFrom()
        {
            Assert.IsTrue(typeof(uint[]).IsAssignableFrom(typeof(int[])));
            Assert.IsTrue(typeof(int[]).IsAssignableFrom(typeof(VarEnumI[])));
            Assert.IsTrue(typeof(VarEnumJ[]).IsAssignableFrom(typeof(VarEnumI[])));
            Assert.IsFalse(typeof(long[]).IsAssignableFrom(typeof(int[])));
            Assert.IsFalse(typeof(short[]).IsAssignableFrom(typeof(char[])));
            Assert.IsFalse(typeof(object[]).IsAssignableFrom(typeof(int[])));
            Assert.IsTrue(typeof(VarBase[][]).IsAssignableFrom(typeof(VarDerived[][])));
            Assert.IsTrue(typeof(object[]).IsAssignableFrom(typeof(string[][])));
            Assert.IsTrue(typeof(System.Collections.Generic.IEnumerable<uint>).IsAssignableFrom(typeof(int[])));
            Assert.IsFalse(typeof(System.Collections.Generic.IEnumerable<object>).IsAssignableFrom(typeof(int[])));
            Assert.IsTrue(typeof(IVarOut<VarBase>[]).IsAssignableFrom(typeof(VarCOut<VarDerived>[])));
        }

        [TestMethod]
        public void Unsupported_ObjectsWithoutClosedType()
        {
            // a delegate object carries no closed type: the cast is accepted by erasure
            object action = new Action<string>(VarAction);

            Assert.IsTrue(action is Action<string>);
        }

        private static void VarAction(string value)
        {
        }
    }
}
