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
    class UnitTestDeclarationTests
    {
        [TestMethod]
        public void BaseClass1_Test()
        {
            // Tests an int declaration with assignment in a base class
            Assert.IsTrue(BaseClassTestClass1.testMethod());
        }

        [TestMethod]
        public void BaseClass2_Test()
        {

            // Tests a function declaration in a implementing class still
            // works after child is cast as an implemented interface
            Assert.IsTrue(BaseClassTestClass2.testMethod());
        }

        [TestMethod]
        public void BaseClass3_Test()
        {

            // Tests a function declaration in an implementing class still works after child is cast as
            // each of two implemented interfaces
            Assert.IsTrue(BaseClassTestClass3.testMethod());
        }

        [TestMethod]
        public void BaseClass4_Test()
        {
            // Tests a function declaration in a child class still works after child is cast as
            // its parent class and an interface it implements
            Assert.IsTrue(BaseClassTestClass4.testMethod());
        }

        [TestMethod]
        public void BaseClass10_Test()
        {
            // Section 10.1
            // The base classes of a class are the direct base
            // class and its base classes.  In other words, the
            // set of base classes is the transitive closure of the 
            // direct base class relatationship.
            Assert.IsTrue(BaseClassTestClass10.testMethod());
        }

        [TestMethod]
        public void BaseClass13_Test()
        {
            // Section 10.1
            // Note that a class does not depend on the
            // classes that are nested within it. 
            Assert.IsTrue(BaseClassTestClass13.testMethod());
        }

        [TestMethod]
        public void BaseClass25_Test()
        {
            // 10.1.2.1 
            // inheriting from nested types
            Assert.IsTrue(BaseClassTestClass25.testMethod());
        }

        [TestMethod]
        public void BaseClass29_Test()
        {
            // 10.1.2.1 
            // inheriting from nested types

            Assert.IsTrue(BaseClassTestClass29.testMethod());
        }

        [TestMethod]
        public void Modifiers2_Test()
        {
            // Testing  a public int inside an inner class with modifier 'new' 

            Assert.IsTrue(ModifiersTestClass2.testMethod());
        }

        [TestMethod]
        public void Modifiers3_Test()
        {

            // Testing  a public int directly inside a public class
            Assert.IsTrue(ModifiersTestClass3.testMethod());
        }

        [TestMethod]
        public void Modifiers4_Test()
        {

            // Testing  a public int inside an inner class with modifier 'public' 
            Assert.IsTrue(ModifiersTestClass4.testMethod());
        }

        [TestMethod]
        public void Modifiers6_Test()
        {

            // Testing  a public int inside an inner class with modifier 'protected' 
            Assert.IsTrue(ModifiersTestClass6.testMethod());
        }

        [TestMethod]
        public void Modifiers7_Test()
        {

            // Testing  a public int directly inside an internal class
            Assert.IsTrue(ModifiersTestClass7.testMethod());
        }

        [TestMethod]
        public void Modifiers8_Test()
        {
            // Testing  a public int inside an inner class with modifier 'internal' 
            Assert.IsTrue(ModifiersTestClass8.testMethod());
        }

        [TestMethod]
        public void Modifiers10_Test()
        {

            // Testing  a public int inside an inner class with modifier 'private' 
            Assert.IsTrue(ModifiersTestClass10.testMethod());
        }

        [TestMethod]
        public void Modifiers11_Test()
        {

            // Testing  a public int inside an abstract class that is implemented
            Assert.IsTrue(ModifiersTestClass11.testMethod());
        }

        [TestMethod]
        public void Modifiers12_Test()
        {

            // Testing  a public int inside an inner abstract class that is implemented
            Assert.IsTrue(ModifiersTestClass12.testMethod());
        }

        [TestMethod]
        public void Modifiers13_Test()
        {
            // Testing  a public int directly inside a sealed class
            Assert.IsTrue(ModifiersTestClass13.testMethod());
        }

        [TestMethod]
        public void Modifiers14_Test()
        {

            // Testing  a public int inside an inner sealed class
            Assert.IsTrue(ModifiersTestClass14.testMethod());
        }

        [TestMethod]
        public void Modifiers23_Test()
        {
            // An abstract class cannot be instantiated, and it is
            // an error to use the new operator on an abstract class.
            // While it is possible to have variables and values whose
            // compile-time types are abstract, such variables and values
            // will necessarily either be null or contain references
            // to instances of non-abstract classes derived from the 
            // abstract types.
            Assert.IsTrue(ModifiersTestClass23.testMethod());
        }

        [TestMethod]
        public void Modifiers24_Test()
        {
            // An abstract class cannot be instantiated, and it is
            // an error to use the new operator on an abstract class.
            // While it is possible to have variables and values whose
            // compile-time types are abstract, such variables and values
            // will necessarily either be null or contain references
            // to instances of non-abstract classes derived from the 
            // abstract types.
            Assert.IsTrue(ModifiersTestClass24.testMethod());
        }

        [TestMethod]
        public void Modifiers25_Test()
        {
            // Section 10.1
            // An abstract class is permitted (but not required)
            // to contain abstract methods and accessors.
            Assert.IsTrue(ModifiersTestClass25.testMethod());
        }

        [TestMethod]
        public void Modifiers26_Test()
        {
            // Section 10.1
            // An abstract class is permitted (but not required)
            // to contain abstract methods and accessors.
            Assert.IsTrue(ModifiersTestClass26.testMethod());
        }

        [TestMethod]
        public void Modifiers31_Test()
        {

            // Section 10.1
            // When a non-abstract class is derived from
            // an abstract class, the non-abstract class must
            // be include actual implementations of all inherited 
            // abstract methods and accessors.  Such implementations
            // are provided by overriding the abstract methods
            // and accessors.
            Assert.IsTrue(ModifiersTestClass31.testMethod());
        }

        class BaseClassTestClass1_Base
        {
            public int intI = 2;
        }

        class BaseClassTestClass1 : BaseClassTestClass1_Base
        {
            public static bool testMethod()
            {
                BaseClassTestClass1 MC = new BaseClassTestClass1();
                if (MC.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        interface BaseClassTestClass2_Base
        {
            int RetInt();
        }

        class BaseClassTestClass2 : BaseClassTestClass2_Base
        {

            public int RetInt()
            {
                return 2;
            }

            public static bool testMethod()
            {
                BaseClassTestClass2 MC = new BaseClassTestClass2();
                BaseClassTestClass2_Base Test = (BaseClassTestClass2_Base)MC;
                if (Test.RetInt() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        interface BaseClassTestClass3_Base1
        {
            int RetInt();
        }

        interface BaseClassTestClass3_Base2
        {
            int RetInt2();
        }

        class BaseClassTestClass3 : BaseClassTestClass3_Base1, BaseClassTestClass3_Base2
        {

            public int RetInt()
            {
                return 2;
            }

            public int RetInt2()
            {
                return 3;
            }

            public static bool testMethod()
            {
                BaseClassTestClass3 MC = new BaseClassTestClass3();
                BaseClassTestClass3_Base1 Test1 = (BaseClassTestClass3_Base1)MC;
                BaseClassTestClass3_Base2 Test2 = (BaseClassTestClass3_Base2)MC;
                if ((Test1.RetInt() == 2) && (Test2.RetInt2() == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



        class BaseClassTestClass4_Base1
        {
            public int RetInt()
            {
                return 2;
            }
        }

        interface BaseClassTestClass4_Base2
        {
            int RetInt2();
        }

        class BaseClassTestClass4 : BaseClassTestClass4_Base1, BaseClassTestClass4_Base2
        {

            public int RetInt2()
            {
                return 3;
            }

            public static bool testMethod()
            {
                BaseClassTestClass4 MC = new BaseClassTestClass4();
                BaseClassTestClass4_Base1 Test1 = (BaseClassTestClass4_Base1)MC;
                BaseClassTestClass4_Base2 Test2 = (BaseClassTestClass4_Base2)MC;
                if ((Test1.RetInt() == 2) && (Test2.RetInt2() == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        class BaseClassTestClass10_Base1
        {
            public int intI = 2;
        }

        class BaseClassTestClass10_Base2 : BaseClassTestClass10_Base1
        {
            public int intJ = 3;
        }

        class BaseClassTestClass10 : BaseClassTestClass10_Base2
        {
            public static bool testMethod()
            {
                BaseClassTestClass10 MC = new BaseClassTestClass10();
                if ((MC.intI == 2) && (MC.intJ == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class BaseClassTestClass13
        {
            class BaseClassTestClass13_Sub : BaseClassTestClass13
            {
                public int intI = 2;
            }

            public static bool testMethod()
            {
                BaseClassTestClass13_Sub test = new BaseClassTestClass13_Sub();
                if (test.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class BaseClassTestClass25_Base1
        {
            public class BaseClassTestClass25_Sub1 : BaseClassTestClass25_Base1 { }
            public interface BaseClassTestClass25_Interface1 { }
            public class BaseClassTestClass25_Sub2 : BaseClassTestClass25_Sub1, BaseClassTestClass25_Interface1
            { }
        }

        class BaseClassTestClass25 : BaseClassTestClass25_Base1.BaseClassTestClass25_Sub2, BaseClassTestClass25_Base1.BaseClassTestClass25_Interface1
        {
            public static bool testMethod()
            {
                BaseClassTestClass25 m = new BaseClassTestClass25();
                if ((BaseClassTestClass25_Base1.BaseClassTestClass25_Sub2)m == null)
                    return false;

                if ((BaseClassTestClass25_Base1.BaseClassTestClass25_Interface1)m == null)
                    return false;
                return true;
            }
        }

        public class BaseClassTestClass29_SubC : BaseClassTestClass29_SubA.BaseClassTestClass29_SubB { }
        class BaseClassTestClass29_SubG : BaseClassTestClass29_SubC { }
        class BaseClassTestClass29_SubGG : BaseClassTestClass29_SubA.D { }
        class BaseClassTestClass29_SubGGG : BaseClassTestClass29_SubD, BaseClassTestClass29_SubA.BaseClassTestClass29_SubC.II, BaseClassTestClass29_SubA.BaseClassTestClass29_SubB.I { }

        public class BaseClassTestClass29_SubA
        {
            public class BaseClassTestClass29_SubB : BaseClassTestClass29_SubC.I
            {
                public interface I { }
            }
            public class BaseClassTestClass29_SubC
            {
                public interface I { }
                public interface II : I { }
            }

            public class D : BaseClassTestClass29_SubC.II
            {
                public class DD : D, BaseClassTestClass29_SubC.I, BaseClassTestClass29_SubC.II
                {
                    public interface I : BaseClassTestClass29_SubC.II { }
                }
            }
        }

        class BaseClassTestClass29_SubD : BaseClassTestClass29_SubC { }
        class BaseClassTestClass29_SubDD : BaseClassTestClass29_SubA.D { }
        class BaseClassTestClass29_SubDDD : BaseClassTestClass29_SubD, BaseClassTestClass29_SubA.BaseClassTestClass29_SubC.II, BaseClassTestClass29_SubA.BaseClassTestClass29_SubB.I { }

        class BaseClassTestClass29
        {
            public static bool testMethod()
            {
                return true;
            }
        }


        class ModifiersTestClass2_Base1
        {
            public class Inner
            {
                public int IntI = 1;
            }
        }

        class ModifiersTestClass2 : ModifiersTestClass2_Base1
        {

            // new
            new class Inner
            {
                public int IntI = 2;
            }

            public static bool testMethod()
            {
                Inner Test = new Inner();
                if (Test.IntI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class ModifiersTestClass3
        {

            public int IntI = 2;

            public static bool testMethod()
            {
                ModifiersTestClass3 Test = new ModifiersTestClass3();
                if (Test.IntI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ModifiersTestClass4
        {

            //public 
            public class Inner
            {
                public int IntI = 2;
            }

            public static bool testMethod()
            {
                Inner Test = new Inner();
                if (Test.IntI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ModifiersTestClass6
        {
            protected class Inner
            {
                public int IntI = 2;
            }
            public static bool testMethod()
            {
                Inner Test = new Inner();
                if (Test.IntI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal class ModifiersTestClass7
        {

            public int IntI = 2;

            public static bool testMethod()
            {
                ModifiersTestClass7 Test = new ModifiersTestClass7();
                if (Test.IntI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ModifiersTestClass8
        {

            // internal
            internal class Inner
            {
                public int IntI = 2;
            }

            public static bool testMethod()
            {
                Inner Test = new Inner();
                if (Test.IntI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ModifiersTestClass10
        {

            // private
            private class Inner
            {
                public int IntI = 2;
            }

            public static bool testMethod()
            {
                Inner Test = new Inner();
                if (Test.IntI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public abstract class ModifiersTestClass11_Base
        {
            public int IntI = 2;
        }

        public class ModifiersTestClass11 : ModifiersTestClass11_Base
        {
            public static bool testMethod()
            {
                ModifiersTestClass11 Test = new ModifiersTestClass11();
                if (Test.IntI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class ModifiersTestClass12
        {

            // abstract
            abstract class BaseClass
            {
                public int IntI = 2;
            }

            class Inner : BaseClass { }

            public static bool testMethod()
            {
                Inner Test = new Inner();
                if (Test.IntI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        sealed class ModifiersTestClass13
        {

            public int IntI = 2;

            public static bool testMethod()
            {
                ModifiersTestClass13 Test = new ModifiersTestClass13();
                if (Test.IntI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ModifiersTestClass14
        {

            //sealed 
            sealed class Inner
            {
                public int IntI = 2;
            }

            public static bool testMethod()
            {
                Inner Test = new Inner();
                if (Test.IntI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        abstract class ModifiersTestClass23_Sub1 { }

        class ModifiersTestClass23
        {

            ModifiersTestClass23_Sub1 A;

            public static bool testMethod()
            {
                ModifiersTestClass23 test = new ModifiersTestClass23();
                if (test.A == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        abstract class ModifiersTestClass24_Abstract1
        {
            public abstract int retInt();
        }

        class ModifiersTestClass24_Derived1 : ModifiersTestClass24_Abstract1
        {
            override public int retInt()
            {
                return 2;
            }
        }

        class ModifiersTestClass24
        {

            ModifiersTestClass24_Abstract1 A = new ModifiersTestClass24_Derived1();

            public static bool testMethod()
            {

                ModifiersTestClass24 test = new ModifiersTestClass24();

                if (test.A.retInt() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        abstract class ModifiersTestClass25_Abstract1 { }

        class ModifiersTestClass25 : ModifiersTestClass25_Abstract1
        {
            public static bool testMethod()
            {
                return true;
            }
        }

        abstract class ModifiersTestClass26_Abstract1
        {
            public abstract void foo();
            public abstract int intI
            {
                get;
                set;
            }
        }

        class ModifiersTestClass26
        {
            public static bool testMethod()
            {
                return true;
            }
        }

        abstract class ModifiersTestClass31_SubA
        {
            public abstract void F();
        }

        abstract class ModifiersTestClass31_SubB : ModifiersTestClass31_SubA
        {
            public void G() { }
        }

        class ModifiersTestClass31 : ModifiersTestClass31_SubB
        {

            int MyInt = 0;

            public override void F()
            {
                MyInt = 1;
            }

            public static bool testMethod()
            {
                ModifiersTestClass31 test = new ModifiersTestClass31();
                ModifiersTestClass31_SubA abstest = test;
                abstest.F();
                if (test.MyInt == 1)
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
