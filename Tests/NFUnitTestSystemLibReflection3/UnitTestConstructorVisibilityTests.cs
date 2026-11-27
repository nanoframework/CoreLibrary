// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLibReflection3
{
    public class ClassWithPublicConstructor
    {
        public int X = 1;
    }

    public class ClassWithPrivateConstructors
    {
        public int X;

        private ClassWithPrivateConstructors()
        {
            X = 2;
        }

        private ClassWithPrivateConstructors(int x)
        {
            X = x;
        }
    }

    public class ClassWithProtectedConstructor
    {
        protected ClassWithProtectedConstructor()
        {
        }
    }

    public class ClassWithInternalConstructor
    {
        internal ClassWithInternalConstructor()
        {
        }
    }

    public class ClassWithMixedConstructors
    {
        public ClassWithMixedConstructors()
        {
        }

        public ClassWithMixedConstructors(char c)
        {
        }

        protected ClassWithMixedConstructors(string s)
        {
        }

        internal ClassWithMixedConstructors(long l)
        {
        }

        private ClassWithMixedConstructors(int i)
        {
        }
    }

    public abstract class AbstractClassWithPublicConstructor
    {
        public AbstractClassWithPublicConstructor()
        {
        }
    }

    public abstract class AbstractGenericClass<T>
    {
        public AbstractGenericClass()
        {
        }
    }

    public class GenericClassWithPublicConstructor<T>
    {
        public GenericClassWithPublicConstructor()
        {
        }
    }

    public interface IMarkerInterface
    {
    }

    [TestClass]
    public class UnitTestConstructorVisibilityTests
    {
        [TestMethod]
        public void GetConstructor_PublicParameterless_IsFound()
        {
            ConstructorInfo constructor = typeof(ClassWithPublicConstructor).GetConstructor(new Type[0]);

            Assert.IsNotNull(constructor);
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void GetConstructor_NonPublicParameterless_IsNull()
        {
            Assert.IsNull(typeof(ClassWithPrivateConstructors).GetConstructor(new Type[0]));
            Assert.IsNull(typeof(ClassWithProtectedConstructor).GetConstructor(new Type[0]));
            Assert.IsNull(typeof(ClassWithInternalConstructor).GetConstructor(new Type[0]));
        }

        [TestMethod]
        public void GetConstructor_NonPublicWithParameters_IsNull()
        {
            Assert.IsNull(typeof(ClassWithPrivateConstructors).GetConstructor(new Type[] { typeof(int) }));
            Assert.IsNull(typeof(ClassWithMixedConstructors).GetConstructor(new Type[] { typeof(int) }));
            Assert.IsNull(typeof(ClassWithMixedConstructors).GetConstructor(new Type[] { typeof(string) }));
            Assert.IsNull(typeof(ClassWithMixedConstructors).GetConstructor(new Type[] { typeof(long) }));
            Assert.IsNotNull(typeof(ClassWithMixedConstructors).GetConstructor(new Type[] { typeof(char) }));
        }

        [TestMethod]
        public void GetConstructors_ReturnsOnlyPublicOnes()
        {
            Assert.AreEqual(2, typeof(ClassWithMixedConstructors).GetConstructors().Length);
            Assert.AreEqual(0, typeof(ClassWithPrivateConstructors).GetConstructors().Length);
        }

        [TestMethod]
        public void Invoke_PublicConstructor_CreatesTheObject()
        {
            object created = typeof(ClassWithPublicConstructor).GetConstructor(new Type[0]).Invoke(null);

            Assert.IsInstanceOfType(created, typeof(ClassWithPublicConstructor));
            Assert.AreEqual(1, ((ClassWithPublicConstructor)created).X);

            Assert.IsInstanceOfType(typeof(GenericClassWithPublicConstructor<int>).GetConstructor(new Type[0]).Invoke(null), typeof(GenericClassWithPublicConstructor<int>));
        }

        [TestMethod]
        public void Invoke_AbstractClassConstructor_ThrowsMemberAccessException()
        {
            ConstructorInfo constructor = typeof(AbstractClassWithPublicConstructor).GetConstructor(new Type[0]);

            Assert.IsNotNull(constructor);
            Assert.ThrowsException(typeof(MemberAccessException), () => constructor.Invoke(null));

            ConstructorInfo closed = typeof(AbstractGenericClass<int>).GetConstructor(new Type[0]);

            Assert.ThrowsException(typeof(MemberAccessException), () => closed.Invoke(null));
        }

        [TestMethod]
        public void Invoke_OpenGenericConstructor_ThrowsMemberAccessException()
        {
            ConstructorInfo open = typeof(GenericClassWithPublicConstructor<>).GetConstructor(new Type[0]);

            Assert.IsNotNull(open);
            Assert.ThrowsException(typeof(MemberAccessException), () => open.Invoke(null));

            ConstructorInfo openAbstract = typeof(AbstractGenericClass<>).GetConstructor(new Type[0]);

            Assert.ThrowsException(typeof(MemberAccessException), () => openAbstract.Invoke(null));
        }

        [TestMethod]
        public void InterfaceType_HasNoConstructors()
        {
            Assert.IsNull(typeof(IMarkerInterface).GetConstructor(new Type[0]));
            Assert.AreEqual(0, typeof(IMarkerInterface).GetConstructors().Length);
        }

        [TestMethod]
        public void Activator_AbstractOrNonPublic_ThrowsMissingMethodException()
        {
            Assert.ThrowsException(typeof(MissingMethodException), () => Activator.CreateInstance<AbstractClassWithPublicConstructor>());
            Assert.ThrowsException(typeof(MissingMethodException), () => Activator.CreateInstance<ClassWithPrivateConstructors>());
            Assert.ThrowsException(typeof(MissingMethodException), () => Activator.CreateInstance<IMarkerInterface>());
            Assert.IsNotNull(Activator.CreateInstance<ClassWithPublicConstructor>());
        }
    }
}
