//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestClasses
{
    [TestClass]
    class UnitTestIndexerTests
    {
        [TestMethod]
        public void Indexers1_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" An indexer-declaration may include set of");
            OutputHelper.WriteLine(" attributes, a new modifier, and a valid combination");
            OutputHelper.WriteLine(" of the four access modifiers.");
            Assert.IsTrue(IndexersTestClass1.testMethod());
        }

        [TestMethod]
        public void Indexers2_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" An indexer-declaration may include set of");
            OutputHelper.WriteLine(" attributes, a new modifier, and a valid combination");
            OutputHelper.WriteLine(" of the four access modifiers.");
            Assert.IsTrue(IndexersTestClass2.testMethod());
        }

        [TestMethod]
        public void Indexers3_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" An indexer-declaration may include set of");
            OutputHelper.WriteLine(" attributes, a new modifier, and a valid combination");
            OutputHelper.WriteLine(" of the four access modifiers.");
            Assert.IsTrue(IndexersTestClass3.testMethod());

        }

        [TestMethod]
        public void Indexers4_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" An indexer-declaration may include set of");
            OutputHelper.WriteLine(" attributes, a new modifier, and a valid combination");
            OutputHelper.WriteLine(" of the four access modifiers.");
            Assert.IsTrue(IndexersTestClass4.testMethod());
        }

        [TestMethod]
        public void Indexers5_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" An indexer-declaration may include set of");
            OutputHelper.WriteLine(" attributes, a new modifier, and a valid combination");
            OutputHelper.WriteLine(" of the four access modifiers.");
            Assert.IsTrue(IndexersTestClass5.testMethod());
        }

        [TestMethod]
        public void Indexers6_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" An indexer-declaration may include set of");
            OutputHelper.WriteLine(" attributes, a new modifier, and a valid combination");
            OutputHelper.WriteLine(" of the four access modifiers.");
            Assert.IsTrue(IndexersTestClass6.testMethod());
        }

        [TestMethod]
        public void Indexers10_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" An indexer-declaration may include set of");
            OutputHelper.WriteLine(" attributes, a new modifier, and a valid combination");
            OutputHelper.WriteLine(" of the four access modifiers.");
            Assert.IsTrue(IndexersTestClass10.testMethod());
        }

        [TestMethod]
        public void Indexers11_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" An indexer-declaration may include set of");
            OutputHelper.WriteLine(" attributes, a new modifier, and a valid combination");
            OutputHelper.WriteLine(" of the four access modifiers.");
            Assert.IsTrue(IndexersTestClass11.testMethod());
        }

        [TestMethod]
        public void Indexers12_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" The type on an indexer declaration specifies");
            OutputHelper.WriteLine(" the element type of the indexer introduced");
            OutputHelper.WriteLine(" by the declaration");
            Assert.IsTrue(IndexersTestClass12.testMethod());
        }

        [TestMethod]
        public void Indexers14_Test()
        {
            OutputHelper.WriteLine(" Unless the indexer is an explicit interface");
            OutputHelper.WriteLine(" member implementation, the type is followed");
            OutputHelper.WriteLine(" by the keyword this.  For an explicit ");
            OutputHelper.WriteLine(" interface member implementation, the type is ");
            OutputHelper.WriteLine(" followed by an interface-type, a . and the ");
            OutputHelper.WriteLine(" keyword this.");
            OutputHelper.WriteLine("This is currently an expected fail, but is resolved in 3.0 see Bug  16341 for details");
            Assert.IsTrue(IndexersTestClass14.testMethod());
        }

        [TestMethod]
        public void Indexers18_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" The formal-index-parameter-list specifies");
            OutputHelper.WriteLine(" the parameters of the indexer.  The formal");
            OutputHelper.WriteLine(" parameter list of an indexer corresponds");
            OutputHelper.WriteLine(" to that of a method, except that at least");
            OutputHelper.WriteLine(" one parameter must be specified, and that the");
            OutputHelper.WriteLine(" ref and out parameter modifiers are not");
            OutputHelper.WriteLine(" permitted.");
            Assert.IsTrue(IndexersTestClass18.testMethod());
        }

        [TestMethod]
        public void Indexers23_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" The type of an indexer declaration and each ");
            OutputHelper.WriteLine(" of the types referenced in the formal-index");
            OutputHelper.WriteLine(" parameter list must be at least as accessible");
            OutputHelper.WriteLine(" as the indexer itself.");
            Assert.IsTrue(IndexersTestClass23.testMethod());
        }

        [TestMethod]
        public void Indexers29_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" The formal parameter list of an indexer defines");
            OutputHelper.WriteLine(" the signature of the indexer.  Specifically, the");
            OutputHelper.WriteLine(" signature of an indexer consists of the number and");
            OutputHelper.WriteLine(" types of its formal parameters.  The element type");
            OutputHelper.WriteLine(" is not a part of an index signature, nor are the");
            OutputHelper.WriteLine(" names of the formal parameters.");
            Assert.IsTrue(IndexersTestClass29.testMethod());
        }

        [TestMethod]
        public void Indexers32_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" The formal parameter list of an indexer defines");
            OutputHelper.WriteLine(" the signature of the indexer.  Specifically, the");
            OutputHelper.WriteLine(" signature of an indexer consists of the number and");
            OutputHelper.WriteLine(" types of its formal parameters.  The element type");
            OutputHelper.WriteLine(" is not a part of an index signature, nor are the");
            OutputHelper.WriteLine(" names of the formal parameters.");
            Assert.IsTrue(IndexersTestClass32.testMethod());
        }

        [TestMethod]
        public void Indexers33_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" The formal parameter list of an indexer defines");
            OutputHelper.WriteLine(" the signature of the indexer.  Specifically, the");
            OutputHelper.WriteLine(" signature of an indexer consists of the number and");
            OutputHelper.WriteLine(" types of its formal parameters.  The element type");
            OutputHelper.WriteLine(" is not a part of an index signature, nor are the");
            OutputHelper.WriteLine(" names of the formal parameters.");
            Assert.IsTrue(IndexersTestClass33.testMethod());
        }

        [TestMethod]
        public void Indexers37_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" With these differences in mind, all rules");
            OutputHelper.WriteLine(" defined in 10.6.2 and 10.6.3 apply to indexer");
            OutputHelper.WriteLine(" accessors as well as property accessors.");
            Assert.IsTrue(IndexersTestClass37.testMethod());
        }

        [TestMethod]
        public void Indexers38_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" With these differences in mind, all rules");
            OutputHelper.WriteLine(" defined in 10.6.2 and 10.6.3 apply to indexer");
            OutputHelper.WriteLine(" accessors as well as property accessors.");
            Assert.IsTrue(IndexersTestClass38.testMethod());
        }
        [TestMethod]
        public void Indexers39_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" With these differences in mind, all rules");
            OutputHelper.WriteLine(" defined in 10.6.2 and 10.6.3 apply to indexer");
            OutputHelper.WriteLine(" accessors as well as property accessors.");
            Assert.IsTrue(IndexersTestClass39.testMethod());
        }

        [TestMethod]
        public void Indexers42_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" With these differences in mind, all rules");
            OutputHelper.WriteLine(" defined in 10.6.2 and 10.6.3 apply to indexer");
            OutputHelper.WriteLine(" accessors as well as property accessors.");
            Assert.IsTrue(IndexersTestClass42.testMethod());
        }

        [TestMethod]
        public void Indexers43_Test()
        {
            OutputHelper.WriteLine(" Section 10.8");
            OutputHelper.WriteLine(" With these differences in mind, all rules");
            OutputHelper.WriteLine(" defined in 10.6.2 and 10.6.3 apply to indexer");
            OutputHelper.WriteLine(" accessors as well as property accessors.");
            Assert.IsTrue(IndexersTestClass43.testMethod());
        }

        [TestMethod]
        public void Indexers46_Test()
        {
            OutputHelper.WriteLine("Testing multiple comma seperated indexers");
            Assert.IsTrue(IndexersTestClass46.testMethod());
        }

        [TestMethod]
        public void Indexers47_Test()
        {
            OutputHelper.WriteLine("Testing multiple comma seperated indexers to a public variable");
            Assert.IsTrue(IndexersTestClass47.testMethod());
        }

        [TestMethod]
        public void Indexers48_Test()
        {
            OutputHelper.WriteLine("Testing multiple comma seperated indexers with a protected internal get and set");
            Assert.IsTrue(IndexersTestClass48.testMethod());
        }

        [TestMethod]
        public void Indexers49_Test()
        {
            OutputHelper.WriteLine("Testing multiple comma seperated indexers with an internal get and set");
            Assert.IsTrue(IndexersTestClass49.testMethod());
        }

        [TestMethod]
        public void Indexers50_Test()
        {
            OutputHelper.WriteLine("Testing multiple comma seperated indexers with a private get and set");
            Assert.IsTrue(IndexersTestClass50.testMethod());
        }

        [TestMethod]
        public void Indexers51_Test()
        {
            OutputHelper.WriteLine("Testing multiple comma seperated indexers with a public virtual get and set");
            Assert.IsTrue(IndexersTestClass51.testMethod());
        }

        [TestMethod]
        public void Indexers52_Test()
        {
            OutputHelper.WriteLine("Testing multiple comma seperated indexers with an overridden public virtual get and set");
            OutputHelper.WriteLine("This test is expected to fail");
            Assert.IsFalse(IndexersTestClass52.testMethod());
        }

        [TestMethod]
        public void Indexers53_Test()
        {
            OutputHelper.WriteLine("Testing multiple comma seperated indexers with an overridden public abstract get and set");
            Assert.IsTrue(IndexersTestClass53.testMethod());
        }

        [TestMethod]
        public void Indexers55_Test()
        {
            OutputHelper.WriteLine("Testing 10 explicitly specified indexers");
            Assert.IsTrue(IndexersTestClass55.testMethod());
        }

        [TestMethod]
        public void Indexers56_Test()
        {
            OutputHelper.WriteLine("Testing a single indexers with an overridden public abstract get");
            Assert.IsTrue(IndexersTestClass56.testMethod());
        }


        public class IndexersTestClass1
        {

            int intJ;

            int this[int intI]
            {
                get
                {
                    return intI + intJ;
                }
                set
                {
                    intJ = intI + 1;
                }
            }


            public static bool testMethod()
            {
                try
                {
                    IndexersTestClass1 test = new IndexersTestClass1();
                    test[1] = 1;
                    if (test[2] == 4)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch { return false; }
            }
        }

        public class IndexersTestClass2
        {

            int intJ;

            public int this[int intI]
            {
                get
                {
                    return intI + intJ;
                }
                set
                {
                    intJ = intI + 1;
                }
            }


            public static bool testMethod()
            {
                IndexersTestClass2 test = new IndexersTestClass2();
                test[1] = 1;
                if (test[2] == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass3
        {

            int intJ;

            protected int this[int intI]
            {
                get
                {
                    return intI + intJ;
                }
                set
                {
                    intJ = intI + 1;
                }
            }


            public static bool testMethod()
            {
                try
                {
                    IndexersTestClass3 test = new IndexersTestClass3();
                    test[1] = 1;
                    if (test[2] == 4)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch { return false; }
            }
        }

        public class IndexersTestClass4
        {

            int intJ;

            internal int this[int intI]
            {
                get
                {
                    return intI + intJ;
                }
                set
                {
                    intJ = intI + 1;
                }
            }


            public static bool testMethod()
            {
                IndexersTestClass4 test = new IndexersTestClass4();
                test[1] = 1;
                if (test[2] == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public class IndexersTestClass5
        {

            int intJ;

            private int this[int intI]
            {
                get
                {
                    return intI + intJ;
                }
                set
                {
                    intJ = intI + 1;
                }
            }


            public static bool testMethod()
            {
                IndexersTestClass5 test = new IndexersTestClass5();
                test[1] = 1;
                if (test[2] == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass6
        {

            int intJ;

            protected internal int this[int intI]
            {
                get
                {
                    return intI + intJ;
                }
                set
                {
                    intJ = intI + 1;
                }
            }


            public static bool testMethod()
            {
                IndexersTestClass6 test = new IndexersTestClass6();
                test[1] = 1;
                if (test[2] == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass7_Sub
        {

            int intJ;

            protected int this[int intI]
            {
                get
                {
                    return intI + intJ;
                }
                set
                {
                    intJ = intI + 1;
                }
            }
        }

        public class IndexersTestClass10_Base
        {

            int intJ;

            protected int this[int intI]
            {
                get
                {
                    return intI + intJ;
                }
                set
                {
                    intJ = intI + 1;
                }
            }
        }


        public class IndexersTestClass10 : IndexersTestClass10_Base
        {
            public static bool testMethod()
            {
                IndexersTestClass10 test = new IndexersTestClass10();
                test[1] = 1;
                if (test[1] == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass11_Base
        {

            protected int intJ;

            protected int this[int intI]
            {
                get
                {
                    return -1;
                }
                set
                {
                    intJ = -1;
                }
            }
        }


        public class IndexersTestClass11 : IndexersTestClass11_Base
        {

            new protected int this[int intI]
            {
                get
                {
                    return intI + intJ;
                }
                set
                {
                    intJ = intI + 1;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass11 test = new IndexersTestClass11();
                test[1] = 1;
                if (test[2] == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass12_Sub
        {
            public int intI = 2;
        }


        public class IndexersTestClass12
        {

            IndexersTestClass12_Sub TC;

            IndexersTestClass12_Sub this[int i]
            {
                get
                {
                    return TC;
                }
                set
                {
                    TC = value;
                    TC.intI = TC.intI + i;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass12 test = new IndexersTestClass12();
                test[1] = new IndexersTestClass12_Sub();
                if (test[2].intI == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public interface IndexersTestClass14_Base
        {
            int this[int i]
            {
                get;
                set;
            }
        }

        public class IndexersTestClass14 : IndexersTestClass14_Base
        {
            int intI;
            int this[int i]
            {
                get
                {
                    return intI;
                }
                set
                {
                    intI = value;
                }
            }

            int IndexersTestClass14_Base.this[int i]
            {
                get
                {
                    return intI + 1;
                }
                set
                {
                    intI = value + 1;
                }
            }
            public static bool testMethod()
            {
                IndexersTestClass14 test1 = new IndexersTestClass14();
                IndexersTestClass14_Base test2 = new IndexersTestClass14();
                test1[1] = 2;
                test2[2] = 2;
                if ((test1[1] == 2) && (test2[2] == 4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass18
        {

            int this[int int1, int int2, int int3,
                 int int4, int int5, int int6,
                 int int7, int int8, int int9,
                 int int10]
            {

                get
                {
                    return int1 + int2 + int3 + int4 + int5 +
                        int6 + int7 + int8 + int9 + int10;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass18 test = new IndexersTestClass18();
                if (test[1, 2, 3, 4, 5, 6, 7, 8, 9, 10] == 55)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass23
        {

            private class TestClass
            {
                public int intI = 1;
            }

            private TestClass this[TestClass t]
            {
                get
                {
                    return t;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass23 test = new IndexersTestClass23();
                TestClass TC = new TestClass();
                if (test[TC] == TC)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass29
        {

            public int this[int intI]
            {
                get
                {
                    return intI;
                }
            }

            public int this[long lngL]
            {
                get
                {
                    return (int)lngL + 1;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass29 test = new IndexersTestClass29();
                int i = 1;
                long j = 2;

                if ((test[i] == 1) && (test[j] == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass32
        {

            public int this[int intI]
            {
                get
                {
                    return intI;
                }
            }

            public int this[int intI, int intJ]
            {
                get
                {
                    return intI + intJ;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass32 test = new IndexersTestClass32();
                int i = 1;
                int j = 2;

                if ((test[i] == 1) && (test[i, j] == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass33_Base
        {
            public int this[int intI]
            {
                get
                {
                    return intI;
                }
            }
        }

        public class IndexersTestClass33 : IndexersTestClass33_Base
        {

            public int this[int intI, int intJ]
            {
                get
                {
                    return intI + intJ;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass33 test = new IndexersTestClass33();
                int i = 1;
                int j = 2;

                if ((test[i] == 1) && (test[i, j] == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass37
        {

            public int TestInt;

            public virtual int this[int intI]
            {
                set
                {
                    TestInt = intI + value;
                }
                get
                {
                    return TestInt + intI;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass37 test = new IndexersTestClass37();
                test[2] = 2;
                if (test[2] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass38_Base
        {


            public int TestInt;

            public virtual int this[int intI]
            {
                set
                {
                    TestInt = -1;
                }
                get
                {
                    return -1;
                }
            }
        }

        public class IndexersTestClass38 : IndexersTestClass38_Base
        {

            public override int this[int intI]
            {
                set
                {
                    TestInt = intI + value;
                }
                get
                {
                    return TestInt + intI;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass38_Base test = new IndexersTestClass38();
                test[2] = 2;
                if (test[2] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public abstract class IndexersTestClass39_Base
        {


            public int TestInt;

            public abstract int this[int intI]
            {
                set;
                get;
            }
        }

        public class IndexersTestClass39 : IndexersTestClass39_Base
        {

            public override int this[int intI]
            {
                set
                {
                    TestInt = intI + value;
                }
                get
                {
                    return TestInt + intI;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass39_Base test = new IndexersTestClass39();
                test[2] = 2;
                if (test[2] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass42_Base
        {

            public int TestInt;

            public virtual int this[int intI]
            {
                set
                {
                    TestInt = intI + value;
                }
                get
                {
                    return -1;
                }
            }
        }
        public class IndexersTestClass42 : IndexersTestClass42_Base
        {

            public override int this[int intI]
            {
                get
                {
                    return TestInt + intI;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass42_Base test = new IndexersTestClass42();
                test[2] = 2;
                if (test[2] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass43_Base
        {

            public int TestInt;

            public virtual int this[int intI]
            {
                set
                {
                    TestInt = -1;
                }
                get
                {
                    return TestInt + intI;
                }
            }
        }
        public class IndexersTestClass43 : IndexersTestClass43_Base
        {

            public override int this[int intI]
            {
                set
                {
                    TestInt = intI + value;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass43_Base test = new IndexersTestClass43();
                test[2] = 2;
                if (test[2] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass46
        {

            int intTest;

            public int this[params int[] values]
            {
                get
                {
                    return intTest;
                }
                set
                {
                    intTest = values[0] + values[1] + values[2];
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass46 mc = new IndexersTestClass46();
                mc[1, 2, 3] = 0;
                if (mc[1, 2, 3] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass47_Base
        {

            public int intTest;

            protected int this[params int[] values]
            {
                get
                {
                    return intTest;
                }
                set
                {
                    intTest = values[0] + values[1] + values[2];
                }
            }
        }

        public class IndexersTestClass47 : IndexersTestClass47_Base
        {

            public static bool testMethod()
            {
                IndexersTestClass47 mc = new IndexersTestClass47();
                mc[1, 2, 3] = 0;
                if (mc[1, 2, 3] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass48_Base
        {

            public int intTest;

            protected internal int this[params int[] values]
            {
                get
                {
                    return intTest;
                }
                set
                {
                    intTest = values[0] + values[1] + values[2];
                }
            }
        }

        public class IndexersTestClass48 : IndexersTestClass48_Base
        {

            public static bool testMethod()
            {
                IndexersTestClass48 mc = new IndexersTestClass48();
                mc[1, 2, 3] = 0;
                if (mc[1, 2, 3] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass49_Sub
        {

            public int intTest;

            internal int this[params int[] values]
            {
                get
                {
                    return intTest;
                }
                set
                {
                    intTest = values[0] + values[1] + values[2];
                }
            }
        }

        public class IndexersTestClass49
        {

            public static bool testMethod()
            {
                IndexersTestClass49_Sub mc = new IndexersTestClass49_Sub();
                mc[1, 2, 3] = 0;
                if (mc[1, 2, 3] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass50
        {

            int intTest;

            private int this[params int[] values]
            {
                get
                {
                    return intTest;
                }
                set
                {
                    intTest = values[0] + values[1] + values[2];
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass50 mc = new IndexersTestClass50();
                mc[1, 2, 3] = 0;
                if (mc[1, 2, 3] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass51_Base
        {

            public int intTest;

            public virtual int this[params int[] values]
            {
                get
                {
                    return intTest + 1;
                }
                set
                {
                    intTest = 0;
                }
            }
        }

        public class IndexersTestClass51 : IndexersTestClass51_Base
        {

            public override int this[params int[] values]
            {
                get
                {
                    return intTest;
                }
                set
                {
                    intTest = values[0] + values[1] + values[2];
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass51_Base mc = new IndexersTestClass51();
                mc[1, 2, 3] = 0;
                if (mc[1, 2, 3] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass52_Base
        {

            public int intTest;

            public virtual int this[params int[] values]
            {
                get
                {
                    return intTest;
                }
                set
                {
                    intTest = values[0] + values[1] + values[2];
                }
            }
        }

        public class IndexersTestClass52 : IndexersTestClass52_Base
        {

            public new int this[params int[] values]
            {
                get
                {
                    return intTest + 1;
                }
                set
                {
                    intTest = 0;
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass52_Base mc = new IndexersTestClass52();
                mc[1, 2, 3] = 0;
                if (mc[1, 2, 3] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public abstract class IndexersTestClass53_Base
        {

            public int intTest;

            public abstract int this[params int[] values]
            {
                get;
                set;
            }
        }

        public class IndexersTestClass53 : IndexersTestClass53_Base
        {

            public override int this[params int[] values]
            {
                get
                {
                    return intTest;
                }
                set
                {
                    intTest = values[0] + values[1] + values[2];
                }
            }

            public static bool testMethod()
            {
                IndexersTestClass53_Base mc = new IndexersTestClass53();
                mc[1, 2, 3] = 0;
                if (mc[1, 2, 3] == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class IndexersTestClass55
        {

            public int this[int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10]
            {
                get
                {
                    return (i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10);
                }
            }

            public static bool testMethod()
            {

                IndexersTestClass55 MC = new IndexersTestClass55();

                if (MC[1, 2, 3, 4, 5, 6, 7, 8, 9, 10] == 55)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public abstract class IndexersTestClass56_Base
        {
            protected int this[int intI]
            {
                get
                {
                    return (intI + 1);
                }
            }
        }

        public class IndexersTestClass56 : IndexersTestClass56_Base
        {

            public int RetInt(int j)
            {
                return base[j];
            }

            public static bool testMethod()
            {

                IndexersTestClass56 MC = new IndexersTestClass56();

                if (MC.RetInt(2) == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
