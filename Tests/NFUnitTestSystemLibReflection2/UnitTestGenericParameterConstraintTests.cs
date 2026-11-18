// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    // Expected values come from running the same code on .NET. Each test uses its own types.
    [TestClass]
    public class UnitTestGenericParameterConstraintTests
    {
        #region attributes and constraints

        [TestMethod]
        public void Attributes_OfSpecialConstraints()
        {
            Assert.AreEqual(
                (int)(GenericParameterAttributes.NotNullableValueTypeConstraint | GenericParameterAttributes.DefaultConstructorConstraint),
                (int)Arg(typeof(GcStruct<>)).GenericParameterAttributes);
            Assert.AreEqual((int)GenericParameterAttributes.ReferenceTypeConstraint, (int)Arg(typeof(GcClass<>)).GenericParameterAttributes);
            Assert.AreEqual((int)GenericParameterAttributes.DefaultConstructorConstraint, (int)Arg(typeof(GcNew<>)).GenericParameterAttributes);
            Assert.AreEqual((int)GenericParameterAttributes.None, (int)Arg(typeof(GcBase<>)).GenericParameterAttributes);
            Assert.AreEqual((int)GenericParameterAttributes.None, (int)Arg(typeof(GcPlain<>)).GenericParameterAttributes);
            Assert.AreEqual((int)GenericParameterAttributes.None, (int)Arg(typeof(GcFace<>)).GenericParameterAttributes);
        }

        [TestMethod]
        public void Attributes_OfMethodParameter()
        {
            Type v = typeof(GcMethods<>).GetMethod("M3").GetParameters()[0].ParameterType;

            Assert.IsTrue(v.IsGenericParameter);
            Assert.IsTrue(v.DeclaringMethod != null);
            Assert.AreEqual(
                (int)(GenericParameterAttributes.NotNullableValueTypeConstraint | GenericParameterAttributes.DefaultConstructorConstraint),
                (int)v.GenericParameterAttributes);
        }

        [TestMethod]
        public void Attributes_OfOtherTypes_Throw()
        {
            Assert.IsTrue(ThrowsInvalidOperation(() => (object)typeof(int).GenericParameterAttributes));
            Assert.IsTrue(ThrowsInvalidOperation(() => (object)typeof(GcStruct<>).GenericParameterAttributes));
            Assert.IsTrue(ThrowsInvalidOperation(() => (object)typeof(int).GetGenericParameterConstraints()));
            Assert.IsTrue(ThrowsInvalidOperation(() => (object)typeof(GcStruct<int>).GetGenericParameterConstraints()));
        }

        [TestMethod]
        public void Constraints_AreListedInMetadataOrder()
        {
            Type[] none = Arg(typeof(GcClass<>)).GetGenericParameterConstraints();
            Type[] valueType = Arg(typeof(GcStruct<>)).GetGenericParameterConstraints();
            Type[] structFoo = Arg(typeof(GcStructFoo<>)).GetGenericParameterConstraints();
            Type[] multi = Arg(typeof(GcMulti<>)).GetGenericParameterConstraints();

            Assert.AreEqual(0, none.Length);
            Assert.AreEqual(0, Arg(typeof(GcPlain<>)).GetGenericParameterConstraints().Length);
            Assert.AreEqual(1, valueType.Length);
            Assert.IsTrue(valueType[0] == typeof(ValueType));
            Assert.AreEqual(2, structFoo.Length);
            Assert.IsTrue(structFoo[0] == typeof(IGcFoo));
            Assert.IsTrue(structFoo[1] == typeof(ValueType));
            Assert.AreEqual(3, multi.Length);
            Assert.IsTrue(multi[0] == typeof(GcB2));
            Assert.IsTrue(multi[1] == typeof(IGcBar));
            Assert.IsTrue(multi[2] == typeof(IGcOther));
        }

        [TestMethod]
        public void Constraints_OfParameterConstraint()
        {
            Type[] chain = typeof(GcChain<,>).GetGenericArguments();
            Type[] constraints = chain[0].GetGenericParameterConstraints();

            Assert.AreEqual(1, constraints.Length);
            Assert.IsTrue(constraints[0] == chain[1]);
            Assert.IsTrue(constraints[0].IsGenericParameter);
            Assert.IsTrue(chain[1].GetGenericParameterConstraints()[0] == typeof(GcB2));
        }

        [TestMethod]
        public void Constraints_OfOpenGenericTypes()
        {
            Type self = Arg(typeof(GcSelf<>));
            Type[] args = typeof(GcBaseOf<,>).GetGenericArguments();
            Type selfConstraint = self.GetGenericParameterConstraints()[0];
            Type baseConstraint = args[0].GetGenericParameterConstraints()[0];

            Assert.IsTrue(selfConstraint.IsGenericType);
            Assert.IsFalse(selfConstraint.IsGenericTypeDefinition);
            Assert.IsTrue(selfConstraint.ContainsGenericParameters);
            Assert.IsTrue(selfConstraint.GetGenericArguments()[0] == self);
            Assert.IsTrue(baseConstraint.GetGenericArguments()[0] == args[1]);
            Assert.IsTrue(baseConstraint.GetGenericArguments()[0] != args[0]);
        }

        [TestMethod]
        public void Constraints_OfClosedGenericType()
        {
            Type constraint = Arg(typeof(GcClosed<>)).GetGenericParameterConstraints()[0];

            Assert.IsTrue(constraint == typeof(IGcOf<string>));
            Assert.IsFalse(constraint.ContainsGenericParameters);
        }

        [TestMethod]
        public void Constraints_OfMethodParameters()
        {
            Type[] args = typeof(GcMethods<>).GetGenericArguments();
            Type face = typeof(GcMethods<>).GetMethod("M").GetParameters()[0].ParameterType;
            Type baseOf = typeof(GcMethods<>).GetMethod("M2").GetParameters()[0].ParameterType;

            Assert.AreEqual(1, face.GetGenericParameterConstraints().Length);
            Assert.IsTrue(face.GetGenericParameterConstraints()[0] == typeof(IGcFoo));
            Assert.IsTrue(baseOf.GetGenericParameterConstraints()[0].GetGenericArguments()[0] == args[0]);
            Assert.IsTrue(baseOf.BaseType.GetGenericArguments()[0] == args[0]);
        }

        [TestMethod]
        public void Constraints_OfMethodParametersInGenericInstances()
        {
            Type self = typeof(GcMethods<>).GetMethod("M4").GetParameters()[0].ParameterType;
            System.Reflection.ParameterInfo[] m5 = typeof(GcMethods<>).GetMethod("M5").GetParameters();
            Type constraint = self.GetGenericParameterConstraints()[0];

            Assert.IsTrue(constraint.IsGenericType);
            Assert.IsFalse(constraint.IsGenericTypeDefinition);
            Assert.IsTrue(constraint.ContainsGenericParameters);
            Assert.IsTrue(constraint.GetGenericArguments()[0] == self);
            Assert.IsTrue(constraint.GetGenericArguments()[0].DeclaringMethod != null);
            Assert.IsTrue(constraint.ToString().IndexOf("[V]") > 0);
            Assert.IsTrue(constraint.IsAssignableFrom(self));
            Assert.AreEqual(1, self.GetInterfaces().Length);
            Assert.IsTrue(self.GetInterfaces()[0] == constraint);
            Assert.IsTrue(m5[0].ParameterType.BaseType.GetGenericArguments()[0] == m5[1].ParameterType);
        }

        #endregion

        #region base type and interfaces

        [TestMethod]
        public void BaseType_OfConstrainedParameters()
        {
            Assert.IsTrue(Arg(typeof(GcStruct<>)).BaseType == typeof(ValueType));
            Assert.IsTrue(Arg(typeof(GcStructFoo<>)).BaseType == typeof(ValueType));
            Assert.IsTrue(Arg(typeof(GcClass<>)).BaseType == typeof(object));
            Assert.IsTrue(Arg(typeof(GcNew<>)).BaseType == typeof(object));
            Assert.IsTrue(Arg(typeof(GcClassFoo<>)).BaseType == typeof(object));
            Assert.IsTrue(Arg(typeof(GcBase<>)).BaseType == typeof(GcB2));
            Assert.IsTrue(Arg(typeof(GcFace<>)).BaseType == typeof(object));
            Assert.IsTrue(Arg(typeof(GcMulti<>)).BaseType == typeof(GcB2));
        }

        [TestMethod]
        public void BaseType_ThroughParameterConstraint_IsObject()
        {
            Assert.IsTrue(typeof(GcChain<,>).GetGenericArguments()[0].BaseType == typeof(object));
            Assert.IsTrue(typeof(GcChain<,>).GetGenericArguments()[1].BaseType == typeof(GcB2));
        }

        [TestMethod]
        public void BaseType_OfOpenGenericClassConstraint()
        {
            Type self = Arg(typeof(GcBaseSelf<>));
            Type[] args = typeof(GcBaseOf<,>).GetGenericArguments();
            Type selfBase = self.BaseType;
            Type otherBase = args[0].BaseType;

            Assert.IsTrue(selfBase.IsGenericType);
            Assert.IsFalse(selfBase.IsGenericTypeDefinition);
            Assert.IsTrue(selfBase.ContainsGenericParameters);
            Assert.IsTrue(selfBase.GetGenericArguments()[0] == self);
            Assert.IsTrue(otherBase.GetGenericArguments()[0] == args[1]);
            Assert.IsTrue(selfBase == self.GetGenericParameterConstraints()[0]);
        }

        [TestMethod]
        public void Interfaces_OfConstrainedParameters()
        {
            Assert.AreEqual(0, Arg(typeof(GcStruct<>)).GetInterfaces().Length);
            Assert.AreEqual(0, Arg(typeof(GcClass<>)).GetInterfaces().Length);
            Assert.AreEqual(0, Arg(typeof(GcNew<>)).GetInterfaces().Length);

            Type[] structFoo = Arg(typeof(GcStructFoo<>)).GetInterfaces();
            Type[] classFoo = Arg(typeof(GcClassFoo<>)).GetInterfaces();
            Type[] fromBase = Arg(typeof(GcBase<>)).GetInterfaces();
            Type[] fromFace = Arg(typeof(GcFace<>)).GetInterfaces();
            Type[] multi = Arg(typeof(GcMulti<>)).GetInterfaces();

            Assert.AreEqual(1, structFoo.Length);
            Assert.IsTrue(structFoo[0] == typeof(IGcFoo));
            Assert.AreEqual(1, classFoo.Length);
            Assert.AreEqual(1, fromBase.Length);
            Assert.IsTrue(fromBase[0] == typeof(IGcFoo));
            Assert.AreEqual(2, fromFace.Length);
            Assert.IsTrue(Contains(fromFace, typeof(IGcBar)));
            Assert.IsTrue(Contains(fromFace, typeof(IGcFoo)));
            Assert.AreEqual(3, multi.Length);
            Assert.IsTrue(Contains(multi, typeof(IGcFoo)));
            Assert.IsTrue(Contains(multi, typeof(IGcBar)));
            Assert.IsTrue(Contains(multi, typeof(IGcOther)));
        }

        [TestMethod]
        public void Interfaces_ThroughParameterConstraints()
        {
            Type[] chain = typeof(GcChain<,>).GetGenericArguments();
            Type[] chain3 = typeof(GcChain3<,,>).GetGenericArguments();
            Type[] one = chain[0].GetInterfaces();
            Type[] three = chain3[0].GetInterfaces();

            Assert.AreEqual(1, one.Length);
            Assert.IsTrue(one[0] == typeof(IGcFoo));
            Assert.AreEqual(2, three.Length);
            Assert.IsTrue(Contains(three, typeof(IGcBar)));
            Assert.IsTrue(Contains(three, typeof(IGcFoo)));
            Assert.AreEqual(2, chain3[1].GetInterfaces().Length);
        }

        [TestMethod]
        public void Interfaces_OfOpenGenericConstraints()
        {
            Type self = Arg(typeof(GcSelf<>));
            Type selfBase = Arg(typeof(GcBaseSelf<>));
            Type[] ofSelf = self.GetInterfaces();
            Type[] ofBase = selfBase.GetInterfaces();

            Assert.AreEqual(1, ofSelf.Length);
            Assert.IsTrue(ofSelf[0].GetGenericArguments()[0] == self);
            Assert.AreEqual(1, ofBase.Length);
            Assert.IsTrue(ofBase[0] == typeof(IGcFoo));
        }

        #endregion

        #region flags

        [TestMethod]
        public void Flags_OfStruct()
        {
            Type t = Arg(typeof(GcStruct<>));

            Assert.IsTrue(t.IsValueType);
            Assert.IsFalse(t.IsClass);
            Assert.IsFalse(t.IsEnum);
            Assert.IsFalse(t.IsInterface);
            Assert.IsFalse(t.IsAbstract);
            Assert.IsTrue(t.IsPublic);
            Assert.IsTrue(Arg(typeof(GcStructFoo<>)).IsValueType);
        }

        [TestMethod]
        public void Flags_OfClassLikeParameters()
        {
            Type[] all =
            {
                Arg(typeof(GcClass<>)),
                Arg(typeof(GcNew<>)),
                Arg(typeof(GcBase<>)),
                Arg(typeof(GcFace<>)),
                Arg(typeof(GcClassFoo<>)),
                Arg(typeof(GcMulti<>)),
                typeof(GcChain<,>).GetGenericArguments()[0],
            };

            for (int i = 0; i < all.Length; i++)
            {
                Assert.IsTrue(all[i].IsClass);
                Assert.IsFalse(all[i].IsValueType);
                Assert.IsFalse(all[i].IsEnum);
                Assert.IsFalse(all[i].IsInterface);
                Assert.IsFalse(all[i].IsAbstract);
                Assert.IsTrue(all[i].IsPublic);
            }
        }

        #endregion

        #region assignability

        [TestMethod]
        public void IsAssignableFrom_FromConstrainedParameter()
        {
            Type s = Arg(typeof(GcStruct<>));
            Type sf = Arg(typeof(GcStructFoo<>));
            Type c = Arg(typeof(GcClass<>));
            Type b = Arg(typeof(GcBase<>));
            Type f = Arg(typeof(GcFace<>));
            Type m = Arg(typeof(GcMulti<>));

            Assert.IsTrue(typeof(object).IsAssignableFrom(s));
            Assert.IsTrue(typeof(ValueType).IsAssignableFrom(s));
            Assert.IsFalse(typeof(ValueType).IsAssignableFrom(c));
            Assert.IsFalse(typeof(IGcFoo).IsAssignableFrom(s));
            Assert.IsTrue(typeof(IGcFoo).IsAssignableFrom(sf));
            Assert.IsFalse(typeof(IGcBar).IsAssignableFrom(sf));
            Assert.IsTrue(typeof(GcB2).IsAssignableFrom(b));
            Assert.IsTrue(typeof(IGcFoo).IsAssignableFrom(b));
            Assert.IsFalse(typeof(IGcBar).IsAssignableFrom(b));
            Assert.IsTrue(typeof(IGcBar).IsAssignableFrom(f));
            Assert.IsTrue(typeof(IGcFoo).IsAssignableFrom(f));
            Assert.IsFalse(typeof(GcB2).IsAssignableFrom(f));
            Assert.IsTrue(typeof(GcB2).IsAssignableFrom(m));
            Assert.IsTrue(typeof(IGcOther).IsAssignableFrom(m));
            Assert.IsFalse(typeof(GcB3<int>).IsAssignableFrom(m));
        }

        [TestMethod]
        public void IsAssignableFrom_ToConstrainedParameter()
        {
            Type b = Arg(typeof(GcBase<>));
            Type s = Arg(typeof(GcStruct<>));

            Assert.IsTrue(b.IsAssignableFrom(b));
            Assert.IsFalse(b.IsAssignableFrom(typeof(GcB2)));
            Assert.IsFalse(b.IsAssignableFrom(typeof(GcPlain<int>)));
            Assert.IsFalse(s.IsAssignableFrom(typeof(int)));
            Assert.IsFalse(s.IsAssignableFrom(typeof(ValueType)));
            Assert.IsFalse(s.IsAssignableFrom(b));
            Assert.IsFalse(b.IsAssignableFrom(s));
        }

        [TestMethod]
        public void IsAssignableFrom_ThroughParameterConstraints()
        {
            Type[] chain = typeof(GcChain<,>).GetGenericArguments();
            Type[] chain3 = typeof(GcChain3<,,>).GetGenericArguments();

            Assert.IsTrue(chain[1].IsAssignableFrom(chain[0]));
            Assert.IsFalse(chain[0].IsAssignableFrom(chain[1]));
            Assert.IsTrue(typeof(GcB2).IsAssignableFrom(chain[0]));
            Assert.IsTrue(typeof(IGcFoo).IsAssignableFrom(chain[0]));
            Assert.IsFalse(typeof(IGcBar).IsAssignableFrom(chain[0]));
            Assert.IsTrue(chain3[2].IsAssignableFrom(chain3[0]));
            Assert.IsTrue(chain3[1].IsAssignableFrom(chain3[0]));
            Assert.IsFalse(chain3[0].IsAssignableFrom(chain3[2]));
            Assert.IsTrue(typeof(IGcBar).IsAssignableFrom(chain3[0]));
            Assert.IsTrue(typeof(IGcFoo).IsAssignableFrom(chain3[0]));
        }

        [TestMethod]
        public void IsAssignableFrom_OpenGenericConstraint()
        {
            Type self = Arg(typeof(GcSelf<>));

            Assert.IsTrue(self.GetInterfaces()[0].IsAssignableFrom(self));
            Assert.IsTrue(self.GetGenericParameterConstraints()[0].IsAssignableFrom(self));
        }

        #endregion

        #region identity

        [TestMethod]
        public void Constraint_IsTheSameTypeAsReadFromOtherPaths()
        {
            Type self = Arg(typeof(GcBaseSelf<>));

            Assert.IsTrue(self.BaseType == self.GetGenericParameterConstraints()[0]);
            Assert.IsTrue(self.BaseType.GetGenericArguments()[0] == typeof(GcBaseSelf<>).GetGenericArguments()[0]);
            Assert.IsTrue(self.BaseType != typeof(GcB4<>));
            Assert.AreEqual(self.BaseType.GetHashCode(), self.GetGenericParameterConstraints()[0].GetHashCode());
        }

        #endregion

        #region not supported

        [TestMethod]
        public void EnumConstraint_IsNotSupported()
        {
            Type e = Arg(typeof(GcEnum<>));

            Assert.IsTrue(ThrowsNotSupported(() => e.BaseType));
            Assert.IsTrue(ThrowsNotSupported(() => (object)e.IsValueType));
            Assert.IsTrue(ThrowsNotSupported(() => (object)e.IsEnum));
            Assert.IsTrue(ThrowsNotSupported(() => e.GetInterfaces()));
            Assert.IsTrue(ThrowsNotSupported(() => (object)typeof(ValueType).IsAssignableFrom(e)));
            Assert.AreEqual(1, e.GetGenericParameterConstraints().Length);
            Assert.IsTrue(e.GetGenericParameterConstraints()[0] == typeof(Enum));
        }

        [TestMethod]
        public void VariantInterface_NeedsVariance_IsNotSupported()
        {
            Type t = Arg(typeof(GcVariant<>));

            Assert.IsTrue(typeof(IGcOut<string>).IsAssignableFrom(t));
            Assert.IsTrue(ThrowsNotSupported(() => (object)typeof(IGcOut<int>).IsAssignableFrom(t)));
            Assert.IsTrue(ThrowsNotSupported(() => (object)typeof(IGcOut<object>).IsAssignableFrom(t)));
        }

        [TestMethod]
        public void ArraysOfConstrainedParameters_AreNotSupported()
        {
            Type items = typeof(GcArrays<>).GetField("Items").FieldType;

            Assert.IsTrue(ThrowsNotSupported(() => (object)typeof(GcB2[]).IsAssignableFrom(items)));
            Assert.IsTrue(typeof(object).IsAssignableFrom(items));
        }

        #endregion

        private static Type Arg(Type definition)
        {
            return definition.GetGenericArguments()[0];
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

        private static bool ThrowsNotSupported(Func<object> action)
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

        private static bool ThrowsInvalidOperation(Func<object> action)
        {
            try
            {
                action();
            }
            catch (InvalidOperationException)
            {
                return true;
            }

            return false;
        }

        public interface IGcFoo { }

        public interface IGcBar : IGcFoo { }

        public interface IGcOther { }

        public interface IGcOf<T> { }

        public interface IGcOut<out T> { }

        public class GcB2 : IGcFoo { }

        public class GcB3<T> { }

        public class GcB4<T> : GcB3<T>, IGcFoo { }

        public class GcPlain<T> { }

        public class GcStruct<T> where T : struct { }

        public class GcClass<T> where T : class { }

        public class GcNew<T> where T : new() { }

        public class GcEnum<T> where T : Enum { }

        public class GcStructFoo<T> where T : struct, IGcFoo { }

        public class GcClassFoo<T> where T : class, IGcFoo { }

        public class GcBase<T> where T : GcB2 { }

        public class GcFace<T> where T : IGcBar { }

        public class GcMulti<T> where T : GcB2, IGcBar, IGcOther { }

        public class GcChain<T, U> where T : U where U : GcB2 { }

        public class GcChain3<T, U, V> where T : U where U : V where V : IGcBar { }

        public class GcSelf<T> where T : IGcOf<T> { }

        public class GcBaseOf<T, U> where T : GcB3<U> { }

        public class GcBaseSelf<T> where T : GcB4<T> { }

        public class GcClosed<T> where T : IGcOf<string> { }

        public class GcVariant<T> where T : IGcOut<string> { }

        public class GcArrays<T> where T : GcB2
        {
            public T[] Items;
        }

        public class GcMethods<T>
        {
            public void M<V>(V value) where V : IGcFoo { }

            public void M2<V>(V value) where V : GcB3<T> { }

            public void M3<V>(V value) where V : struct { }

            public void M4<V>(V value) where V : IGcOf<V> { }

            public void M5<V, W>(W value, V other) where W : GcB3<V> { }
        }
    }
}
