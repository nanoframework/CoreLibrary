// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Expected values come from running the same code on .NET 10, except the cases named as deviations: .NET throws
    // MissingMethodException, or wraps a constructor exception in a TargetInvocationException (neither type exists here).
    [TestClass]
    public class UnitTestActivatorTests
    {
        public interface IAcMark
        {
        }

        public class AcPlain
        {
            public int Value = 7;

            public string Text = "s";

            public AcPlain()
            {
                Value = 9;
            }

            public AcPlain(string text)
            {
                Text = text;
            }
        }

        public struct AcStruct
        {
            public int X;
        }

        public struct AcStructWithConstructor
        {
            public int X;

            public AcStructWithConstructor()
            {
                X = 5;
            }
        }

        public struct AcStructWithArgument
        {
            public int X;

            public AcStructWithArgument(int x)
            {
                X = x;
            }
        }

        public enum AcColor
        {
            Red,
            Green,
        }

        public class AcPrivate
        {
            private AcPrivate()
            {
            }
        }

        public class AcProtected
        {
            protected AcProtected()
            {
            }
        }

        public class AcOnlyArgument
        {
            public AcOnlyArgument(int x)
            {
            }
        }

        public class AcThrower
        {
            public AcThrower()
            {
                throw new InvalidOperationException();
            }
        }

        public abstract class AcAbstract
        {
        }

        public static class AcStatic
        {
        }

        public class AcBox<T>
        {
            public T Value;
        }

        public class AcCounter
        {
            public static int Made;

            public AcCounter()
            {
                Made++;
            }
        }

        public class AcStaticConstructor
        {
            public static int Initialized;

            static AcStaticConstructor()
            {
                Initialized = 1;
            }

            public AcStaticConstructor()
            {
            }
        }

        public class AcFactory<T> where T : new()
        {
            public T Make()
            {
                return new T();
            }
        }

        [TestMethod]
        public void CreateInstanceOfT_ReturnsTheTypedInstance()
        {
            AcPlain plain = Activator.CreateInstance<AcPlain>();

            Assert.AreEqual(9, plain.Value);
            Assert.AreEqual("s", plain.Text);
            Assert.IsNotNull(Activator.CreateInstance<object>());
            Assert.AreEqual(0, Activator.CreateInstance<int>());
            Assert.AreEqual(AcColor.Red, Activator.CreateInstance<AcColor>());
            Assert.AreEqual(0, Activator.CreateInstance<AcStruct>().X);
            Assert.AreEqual(0, Activator.CreateInstance<AcStructWithArgument>().X);
            Assert.AreEqual(5, Activator.CreateInstance<AcStructWithConstructor>().X);
            Assert.IsNotNull(Activator.CreateInstance<AcBox<int>>());
            Assert.IsNotNull(Activator.CreateInstance<AcBox<AcBox<string>>>());
            Assert.IsTrue(Activator.CreateInstance<AcBox<int>>().GetType() == typeof(AcBox<int>));
            Assert.IsFalse(Activator.CreateInstance<AcBox<int>>() is AcBox<string>);

            AcCounter.Made = 0;
            Activator.CreateInstance<AcCounter>();
            Activator.CreateInstance<AcCounter>();

            Assert.AreEqual(2, AcCounter.Made);
            Assert.IsNotNull(Activator.CreateInstance<AcStaticConstructor>());
            Assert.AreEqual(1, AcStaticConstructor.Initialized);
        }

        [TestMethod]
        public void CreateInstanceOfT_WithoutAPublicParameterlessConstructor_ThrowsMissingMethodException_Deviation()
        {
            Assert.ThrowsException(typeof(MissingMethodException), () => Activator.CreateInstance<string>());
            Assert.ThrowsException(typeof(MissingMethodException), () => Activator.CreateInstance<AcAbstract>());
            Assert.ThrowsException(typeof(MissingMethodException), () => Activator.CreateInstance<AcOnlyArgument>());
            Assert.ThrowsException(typeof(MissingMethodException), () => Activator.CreateInstance<AcPrivate>());
            Assert.ThrowsException(typeof(MissingMethodException), () => Activator.CreateInstance<AcProtected>());
            Assert.ThrowsException(typeof(MissingMethodException), () => Activator.CreateInstance<IAcMark>());
            Assert.ThrowsException(typeof(MissingMethodException), () => Activator.CreateInstance<int[]>());
            Assert.ThrowsException(typeof(MissingMethodException), () => Activator.CreateInstance<Action>());
        }

        [TestMethod]
        public void CreateInstanceOfT_ConstructorThatThrows_IsNotWrapped_Deviation()
        {
            Assert.ThrowsException(typeof(InvalidOperationException), () => Activator.CreateInstance<AcThrower>());
        }

        [TestMethod]
        public void NewT_CompilesToCreateInstance_AndWorksForAnyConstructibleType()
        {
            Assert.IsNotNull(new AcFactory<AcPlain>().Make());
            Assert.AreEqual(0, new AcFactory<int>().Make());
            Assert.AreEqual(0, new AcFactory<AcStruct>().Make().X);
            Assert.AreEqual(5, new AcFactory<AcStructWithConstructor>().Make().X);
            Assert.IsNotNull(new AcFactory<AcBox<int>>().Make());
            Assert.IsTrue(new AcFactory<AcBox<int>>().Make() is AcBox<int>);
            Assert.AreEqual(9, new AcFactory<AcPlain>().Make().Value);
            Assert.ThrowsException(typeof(InvalidOperationException), () => new AcFactory<AcThrower>().Make());
        }
    }
}
