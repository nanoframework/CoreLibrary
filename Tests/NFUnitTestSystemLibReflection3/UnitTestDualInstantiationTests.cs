// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

namespace DiOther
{
    public class DiA
    {
    }

    public class DiOuter
    {
        public class DiNested
        {
        }
    }
}

namespace DiN1
{
    public interface IDiOut<T>
    {
        string Name();
    }
}

namespace DiN2
{
    public interface IDiOut<T>
    {
        string Name();
    }
}

namespace NFUnitTestSystemLib
{
    // Expected values come from running the same code on .NET 10.
    [TestClass]
    public class UnitTestDualInstantiationTests
    {
        public class DiA
        {
        }

        public class DiB : DiA
        {
        }

        public class DiC
        {
        }

        public class DiBox<T>
        {
        }

        public delegate void DiHandler();

        public interface IDiOut<T>
        {
            string Name();

            T Get();
        }

        public interface IDiProp<T>
        {
            string Name { get; }
        }

        public interface IDiEvent<T>
        {
            event DiHandler E;

            string Fire();
        }

        public interface IDiA<T>
        {
            string M();
        }

        public interface IDiB<T> : IDiA<T>
        {
            string N();
        }

        public interface IDiOutV<out T>
        {
            string Name();
        }

        public interface IDiInV<in T>
        {
            string Name();
        }

        public interface IDiM<T>
        {
            string M<U>();
        }

        public interface IDiM2<T>
        {
            string N<U>(U[] values) where U : class;
        }

        public interface IDiObs<T>
        {
            string OnNext(T value);

            string OnCompleted();

            string OnError(Exception error);
        }

        public class DiExplicit : IDiOut<DiA>, IDiOut<DiC>
        {
            string IDiOut<DiA>.Name()
            {
                return "A";
            }

            string IDiOut<DiC>.Name()
            {
                return "C";
            }

            DiA IDiOut<DiA>.Get()
            {
                return new DiA();
            }

            DiC IDiOut<DiC>.Get()
            {
                return new DiC();
            }
        }

        public class DiImplicit : IDiOut<DiA>, IDiOut<DiC>
        {
            public string Name()
            {
                return "one";
            }

            DiA IDiOut<DiA>.Get()
            {
                return null;
            }

            DiC IDiOut<DiC>.Get()
            {
                return null;
            }
        }

        public class DiMixed : IDiOut<DiA>, IDiOut<DiC>
        {
            string IDiOut<DiA>.Name()
            {
                return "explicit-A";
            }

            public string Name()
            {
                return "public";
            }

            DiA IDiOut<DiA>.Get()
            {
                return null;
            }

            public DiC Get()
            {
                return null;
            }
        }

        public class DiBasePublic : IDiOut<DiA>
        {
            public string Name()
            {
                return "base-A";
            }

            public DiA Get()
            {
                return null;
            }
        }

        public class DiDerivedExplicit : DiBasePublic, IDiOut<DiC>
        {
            string IDiOut<DiC>.Name()
            {
                return "derived-C";
            }

            DiC IDiOut<DiC>.Get()
            {
                return null;
            }
        }

        public class DiBaseExplicit : IDiOut<DiA>
        {
            string IDiOut<DiA>.Name()
            {
                return "base-A";
            }

            DiA IDiOut<DiA>.Get()
            {
                return null;
            }
        }

        public class DiDerivedExplicit2 : DiBaseExplicit, IDiOut<DiC>
        {
            string IDiOut<DiC>.Name()
            {
                return "derived-C";
            }

            DiC IDiOut<DiC>.Get()
            {
                return null;
            }
        }

        public class DiReimplement : DiBaseExplicit, IDiOut<DiA>
        {
            string IDiOut<DiA>.Name()
            {
                return "derived-A";
            }

            DiA IDiOut<DiA>.Get()
            {
                return null;
            }
        }

        public class DiGeneric<T> : IDiOut<T>, IDiOut<DiBox<T>>
        {
            string IDiOut<T>.Name()
            {
                return "T";
            }

            string IDiOut<DiBox<T>>.Name()
            {
                return "BoxT";
            }

            T IDiOut<T>.Get()
            {
                return default(T);
            }

            DiBox<T> IDiOut<DiBox<T>>.Get()
            {
                return null;
            }
        }

        public class DiOfGeneric : DiGeneric<DiA>, IDiOut<DiC>
        {
            string IDiOut<DiC>.Name()
            {
                return "C";
            }

            DiC IDiOut<DiC>.Get()
            {
                return null;
            }
        }

        public class DiOuter<T>
        {
            public class DiInner : IDiOut<T>, IDiOut<DiBox<T>>
            {
                string IDiOut<T>.Name()
                {
                    return "inT";
                }

                string IDiOut<DiBox<T>>.Name()
                {
                    return "inBoxT";
                }

                T IDiOut<T>.Get()
                {
                    return default(T);
                }

                DiBox<T> IDiOut<DiBox<T>>.Get()
                {
                    return null;
                }
            }
        }

        public class DiProperties : IDiProp<DiA>, IDiProp<DiC>
        {
            string IDiProp<DiA>.Name
            {
                get { return "PA"; }
            }

            string IDiProp<DiC>.Name
            {
                get { return "PC"; }
            }
        }

        public class DiEvents : IDiEvent<DiA>, IDiEvent<DiC>
        {
            private DiHandler _a;
            private DiHandler _c;

            event DiHandler IDiEvent<DiA>.E
            {
                add { _a += value; }
                remove { _a -= value; }
            }

            event DiHandler IDiEvent<DiC>.E
            {
                add { _c += value; }
                remove { _c -= value; }
            }

            string IDiEvent<DiA>.Fire()
            {
                return "a" + (_a != null);
            }

            string IDiEvent<DiC>.Fire()
            {
                return "c" + (_c != null);
            }
        }

        public class DiInherited : IDiB<DiA>, IDiB<DiC>
        {
            string IDiA<DiA>.M()
            {
                return "MA";
            }

            string IDiA<DiC>.M()
            {
                return "MC";
            }

            string IDiB<DiA>.N()
            {
                return "NA";
            }

            string IDiB<DiC>.N()
            {
                return "NC";
            }
        }

        public class DiCovariant : IDiOutV<DiA>, IDiOutV<DiB>
        {
            string IDiOutV<DiA>.Name()
            {
                return "coA";
            }

            string IDiOutV<DiB>.Name()
            {
                return "coB";
            }
        }

        public class DiContravariant : IDiInV<DiA>, IDiInV<DiB>
        {
            string IDiInV<DiA>.Name()
            {
                return "inA";
            }

            string IDiInV<DiB>.Name()
            {
                return "inB";
            }
        }

        public class DiOnlyB : IDiOutV<DiB>
        {
            string IDiOutV<DiB>.Name()
            {
                return "onlyB";
            }
        }

        public struct DiStruct : IDiOut<DiA>, IDiOut<DiC>
        {
            string IDiOut<DiA>.Name()
            {
                return "SA";
            }

            string IDiOut<DiC>.Name()
            {
                return "SC";
            }

            DiA IDiOut<DiA>.Get()
            {
                return null;
            }

            DiC IDiOut<DiC>.Get()
            {
                return null;
            }
        }

        public class DiNames :
            IDiOut<DiOther.DiA>,
            IDiOut<DiA>,
            IDiOut<DiOther.DiOuter.DiNested>,
            IDiOut<DiA[]>,
            IDiOut<int>,
            IDiOut<DiBox<DiA>>,
            IDiOut<DiBox<DiC>>
        {
            string IDiOut<DiOther.DiA>.Name()
            {
                return "otherA";
            }

            string IDiOut<DiA>.Name()
            {
                return "A";
            }

            string IDiOut<DiOther.DiOuter.DiNested>.Name()
            {
                return "nested";
            }

            string IDiOut<DiA[]>.Name()
            {
                return "A[]";
            }

            string IDiOut<int>.Name()
            {
                return "int";
            }

            string IDiOut<DiBox<DiA>>.Name()
            {
                return "BoxA";
            }

            string IDiOut<DiBox<DiC>>.Name()
            {
                return "BoxC";
            }

            DiOther.DiA IDiOut<DiOther.DiA>.Get()
            {
                return null;
            }

            DiA IDiOut<DiA>.Get()
            {
                return null;
            }

            DiOther.DiOuter.DiNested IDiOut<DiOther.DiOuter.DiNested>.Get()
            {
                return null;
            }

            DiA[] IDiOut<DiA[]>.Get()
            {
                return null;
            }

            int IDiOut<int>.Get()
            {
                return 0;
            }

            DiBox<DiA> IDiOut<DiBox<DiA>>.Get()
            {
                return null;
            }

            DiBox<DiC> IDiOut<DiBox<DiC>>.Get()
            {
                return null;
            }
        }

        public class DiTwoNamespaces : DiN1.IDiOut<DiA>, DiN2.IDiOut<DiA>
        {
            string DiN1.IDiOut<DiA>.Name()
            {
                return "n1";
            }

            string DiN2.IDiOut<DiA>.Name()
            {
                return "n2";
            }
        }

        public class DiObserver : IDiObs<DiA>, IDiObs<DiC>
        {
            string IDiObs<DiA>.OnNext(DiA value)
            {
                return "nextA";
            }

            string IDiObs<DiC>.OnNext(DiC value)
            {
                return "nextC";
            }

            string IDiObs<DiA>.OnCompleted()
            {
                return "doneA";
            }

            string IDiObs<DiC>.OnCompleted()
            {
                return "doneC";
            }

            string IDiObs<DiA>.OnError(Exception error)
            {
                return "errA";
            }

            string IDiObs<DiC>.OnError(Exception error)
            {
                return "errC";
            }
        }

        public class DiGenericMethods : IDiM<DiA>, IDiM<DiC>
        {
            string IDiM<DiA>.M<U>()
            {
                return "GA" + typeof(U).Name;
            }

            string IDiM<DiC>.M<U>()
            {
                return "GC" + typeof(U).Name;
            }
        }

        public class DiSingleGenericMethod : IDiM2<DiA>
        {
            string IDiM2<DiA>.N<U>(U[] values)
            {
                return typeof(U).Name + values.Length;
            }
        }

        private static string CallName<I, E>(object o) where I : IDiOut<E>
        {
            return ((I)o).Name();
        }

        private static string CallConstrained<C, E>(C value) where C : IDiOut<E>
        {
            return value.Name();
        }

        private static string NameOf<X>(object o)
        {
            return ((IDiOut<X>)o).Name();
        }

        private static string NameOfBox<X>(object o)
        {
            return ((IDiOut<DiBox<X>>)o).Name();
        }

        [TestMethod]
        public void Explicit_SameSignature_RunsEachImplementation()
        {
            object o = new DiExplicit();

            Assert.AreEqual("A", ((IDiOut<DiA>)o).Name());
            Assert.AreEqual("C", ((IDiOut<DiC>)o).Name());
            Assert.AreEqual(typeof(DiA), ((IDiOut<DiA>)o).Get().GetType());
            Assert.AreEqual(typeof(DiC), ((IDiOut<DiC>)o).Get().GetType());
        }

        [TestMethod]
        public void Explicit_SameSignature_ThroughGenericCodeConstraintsAndReflection()
        {
            object o = new DiExplicit();

            Assert.AreEqual("A", CallName<IDiOut<DiA>, DiA>(o));
            Assert.AreEqual("C", CallName<IDiOut<DiC>, DiC>(o));
            Assert.AreEqual("A", CallConstrained<DiExplicit, DiA>(new DiExplicit()));
            Assert.AreEqual("C", CallConstrained<DiExplicit, DiC>(new DiExplicit()));
            Assert.AreEqual("A", NameOf<DiA>(o));
            Assert.AreEqual("C", NameOf<DiC>(o));
            Assert.AreEqual("A", typeof(IDiOut<DiA>).GetMethod("Name").Invoke(o, null));
            Assert.AreEqual("C", typeof(IDiOut<DiC>).GetMethod("Name").Invoke(o, null));
        }

        [TestMethod]
        public void OnePublicMethod_ServesBothInstantiations()
        {
            object o = new DiImplicit();

            Assert.AreEqual("one", ((IDiOut<DiA>)o).Name());
            Assert.AreEqual("one", ((IDiOut<DiC>)o).Name());
        }

        [TestMethod]
        public void ExplicitForOneInstantiation_DoesNotCaptureTheOther()
        {
            object o = new DiMixed();

            Assert.AreEqual("explicit-A", ((IDiOut<DiA>)o).Name());
            Assert.AreEqual("public", ((IDiOut<DiC>)o).Name());
        }

        [TestMethod]
        public void BaseAndDerived_EachInstantiationRunsItsOwnImplementation()
        {
            object publicBase = new DiDerivedExplicit();

            Assert.AreEqual("base-A", ((IDiOut<DiA>)publicBase).Name());
            Assert.AreEqual("derived-C", ((IDiOut<DiC>)publicBase).Name());

            object explicitBase = new DiDerivedExplicit2();

            Assert.AreEqual("base-A", ((IDiOut<DiA>)explicitBase).Name());
            Assert.AreEqual("derived-C", ((IDiOut<DiC>)explicitBase).Name());

            Assert.AreEqual("derived-A", ((IDiOut<DiA>)(object)new DiReimplement()).Name());
            Assert.AreEqual("base-A", ((IDiOut<DiA>)(object)new DiBaseExplicit()).Name());
        }

        [TestMethod]
        public void GenericClass_InstantiationsOverItsOwnParameter()
        {
            object a = new DiGeneric<DiA>();

            Assert.AreEqual("T", ((IDiOut<DiA>)a).Name());
            Assert.AreEqual("BoxT", ((IDiOut<DiBox<DiA>>)a).Name());

            object i = new DiGeneric<int>();

            Assert.AreEqual("T", ((IDiOut<int>)i).Name());
            Assert.AreEqual("BoxT", ((IDiOut<DiBox<int>>)i).Name());
            Assert.AreEqual("T", NameOf<int>(i));
            Assert.AreEqual("BoxT", NameOfBox<int>(i));
        }

        [TestMethod]
        public void GenericBaseClass_WithAnotherInstantiationInTheDerivedClass()
        {
            object o = new DiOfGeneric();

            Assert.AreEqual("T", ((IDiOut<DiA>)o).Name());
            Assert.AreEqual("BoxT", ((IDiOut<DiBox<DiA>>)o).Name());
            Assert.AreEqual("C", ((IDiOut<DiC>)o).Name());
        }

        [TestMethod]
        public void NestedClass_OfAGenericClass()
        {
            object o = new DiOuter<DiA>.DiInner();

            Assert.AreEqual("inT", ((IDiOut<DiA>)o).Name());
            Assert.AreEqual("inBoxT", ((IDiOut<DiBox<DiA>>)o).Name());
        }

        [TestMethod]
        public void Properties_AreMatchedPerInstantiation()
        {
            object o = new DiProperties();

            Assert.AreEqual("PA", ((IDiProp<DiA>)o).Name);
            Assert.AreEqual("PC", ((IDiProp<DiC>)o).Name);
        }

        [TestMethod]
        public void Events_AreAddedToTheRightInstantiation()
        {
            object o = new DiEvents();

            ((IDiEvent<DiC>)o).E += Handler;

            Assert.AreEqual("aFalse", ((IDiEvent<DiA>)o).Fire());
            Assert.AreEqual("cTrue", ((IDiEvent<DiC>)o).Fire());

            ((IDiEvent<DiC>)o).E -= Handler;

            Assert.AreEqual("cFalse", ((IDiEvent<DiC>)o).Fire());
        }

        private static void Handler()
        {
        }

        [TestMethod]
        public void InheritedInterfaces_AreMatchedPerInstantiation()
        {
            object o = new DiInherited();

            Assert.AreEqual("MA", ((IDiA<DiA>)o).M());
            Assert.AreEqual("MC", ((IDiA<DiC>)o).M());
            Assert.AreEqual("MC", ((IDiB<DiC>)o).M());
            Assert.AreEqual("NA", ((IDiB<DiA>)o).N());
            Assert.AreEqual("NC", ((IDiB<DiC>)o).N());
        }

        [TestMethod]
        public void Variance_ExactEntryFirst_ThenTheFirstCompatibleOne()
        {
            object co = new DiCovariant();

            Assert.AreEqual("coA", ((IDiOutV<DiA>)co).Name());
            Assert.AreEqual("coB", ((IDiOutV<DiB>)co).Name());
            Assert.AreEqual("coA", ((IDiOutV<object>)co).Name());

            object contra = new DiContravariant();

            Assert.AreEqual("inA", ((IDiInV<DiA>)contra).Name());
            Assert.AreEqual("inB", ((IDiInV<DiB>)contra).Name());

            Assert.AreEqual("onlyB", ((IDiOutV<DiA>)(object)new DiOnlyB()).Name());
        }

        [TestMethod]
        public void Struct_BoxedAndConstrained()
        {
            DiStruct value = new DiStruct();
            object boxed = value;

            Assert.AreEqual("SA", ((IDiOut<DiA>)boxed).Name());
            Assert.AreEqual("SC", ((IDiOut<DiC>)boxed).Name());
            Assert.AreEqual("SC", CallConstrained<DiStruct, DiC>(value));
        }

        [TestMethod]
        public void ManyInstantiations_DifferingInNamespaceNestingArraysAndArguments()
        {
            object o = new DiNames();

            Assert.AreEqual("otherA", ((IDiOut<DiOther.DiA>)o).Name());
            Assert.AreEqual("A", ((IDiOut<DiA>)o).Name());
            Assert.AreEqual("nested", ((IDiOut<DiOther.DiOuter.DiNested>)o).Name());
            Assert.AreEqual("A[]", ((IDiOut<DiA[]>)o).Name());
            Assert.AreEqual("int", ((IDiOut<int>)o).Name());
            Assert.AreEqual("BoxA", ((IDiOut<DiBox<DiA>>)o).Name());
            Assert.AreEqual("BoxC", ((IDiOut<DiBox<DiC>>)o).Name());
        }

        [TestMethod]
        public void InterfacesWithTheSameNameInTwoNamespaces()
        {
            object o = new DiTwoNamespaces();

            Assert.AreEqual("n1", ((DiN1.IDiOut<DiA>)o).Name());
            Assert.AreEqual("n2", ((DiN2.IDiOut<DiA>)o).Name());
        }

        [TestMethod]
        public void ObserverLikeInterface_MembersWithoutTheTypeParameterInTheSignature()
        {
            object o = new DiObserver();

            Assert.AreEqual("nextA", ((IDiObs<DiA>)o).OnNext(null));
            Assert.AreEqual("nextC", ((IDiObs<DiC>)o).OnNext(null));
            Assert.AreEqual("doneA", ((IDiObs<DiA>)o).OnCompleted());
            Assert.AreEqual("doneC", ((IDiObs<DiC>)o).OnCompleted());
            Assert.AreEqual("errA", ((IDiObs<DiA>)o).OnError(null));
            Assert.AreEqual("errC", ((IDiObs<DiC>)o).OnError(null));
        }

        [TestMethod]
        public void ExplicitGenericMethods_AreMatchedPerInstantiation()
        {
            object o = new DiGenericMethods();

            Assert.AreEqual("GAInt32", ((IDiM<DiA>)o).M<int>());
            Assert.AreEqual("GCInt32", ((IDiM<DiC>)o).M<int>());

            Func<string> viaDelegate = ((IDiM<DiC>)o).M<long>;

            Assert.AreEqual("GCInt64", viaDelegate());
        }

        [TestMethod]
        public void ExplicitGenericMethods_ThroughReflection()
        {
            object o = new DiGenericMethods();

            Assert.AreEqual("GCString", typeof(IDiM<DiC>).GetMethod("M").MakeGenericMethod(typeof(string)).Invoke(o, null));
            Assert.AreEqual("GAInt64", typeof(IDiM<DiA>).GetMethod("M").MakeGenericMethod(typeof(long)).Invoke(o, null));
        }

        [TestMethod]
        public void ExplicitGenericMethod_KeepsItsConstraints()
        {
            object o = new DiSingleGenericMethod();

            Assert.AreEqual("String2", ((IDiM2<DiA>)o).N<string>(new string[2]));

            Assert.ThrowsException(typeof(ArgumentException), () => typeof(IDiM2<DiA>).GetMethod("N").MakeGenericMethod(typeof(int)));
        }
    }
}
