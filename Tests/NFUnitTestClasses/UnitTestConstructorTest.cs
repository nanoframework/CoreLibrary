//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;
using System.Reflection;

namespace NFUnitTestClasses
{
    [TestClass]
    public class UnitTestConstructorTest
    {
        [TestMethod]
        public void Constructors1_Test()
        {
            OutputHelper.WriteLine("Tests if assignments in a constructor function.");
            Assert.True(ConstructorsTestClass1.testMethod());
        }

        [TestMethod]
        public void Constructors2_Test()
        {
            //Ported from Const2.cs
            OutputHelper.WriteLine("Tests if assignments in a constructor function, when constructor is public.");
            Assert.True(ConstructorsTestClass2.testMethod());
        }

        [TestMethod]
        public void Constructors3_Test()
        {
            //Ported from Const3.cs
            OutputHelper.WriteLine("Tests if assignments in a constructor function, when constructor is protected.");
            Assert.True(ConstructorsTestClass3.testMethod());
        }

        [TestMethod]
        public void Constructors5_Test()
        {
            //Ported from Const5.cs
            OutputHelper.WriteLine("Tests if assignments in a constructor function, when constructor is internal.");
            Assert.True(ConstructorsTestClass5.testMethod());
        }

        [TestMethod]
        public void Constructors6_Test()
        {
            //Ported from Const6.cs
            OutputHelper.WriteLine("Tests if assignments in a constructor function, when constructor is private.");
            Assert.True(ConstructorsTestClass6.testMethod());
        }

        [TestMethod]
        public void Constructors8_Test()
        {
            //Ported from Const8.cs
            OutputHelper.WriteLine("Tests if assignments in a constructor function, when constructor has one parameter.");
            Assert.True(ConstructorsTestClass8.testMethod());
        }

        [TestMethod]
        public void Constructors10_Test()
        {
            //Ported from Const10.cs

            OutputHelper.WriteLine("Tests if assignments in a constructor function, when constructor is called with one parameter");
            OutputHelper.WriteLine("and is overloaded with an un-called zero parameter version");
            Assert.True(ConstructorsTestClass10.testMethod());
        }

        [TestMethod]
        public void Constructors11_Test()
        {
            //Ported from Const11.cs
            OutputHelper.WriteLine("Tests if assignments in a constructor function, when constructor has two parameters.");
            Assert.True(ConstructorsTestClass11.testMethod());
        }

        [TestMethod]
        public void Constructors13_Test()
        {
            //Ported from Const13.cs
            OutputHelper.WriteLine("Tests if assignments in a constructor function, when constructor has ten parameters.");
            Assert.True(ConstructorsTestClass13.testMethod());
        }

        [TestMethod]
        public void Constructors16_Test()
        {
            //Ported from Const16.cs
            OutputHelper.WriteLine("Tests if assignments in a constructor function, when test class inherits constructor");

            OutputHelper.WriteLine("and extends it with base");
            Assert.True(ConstructorsTestClass16.testMethod());
        }

        [TestMethod]
        public void Constructors17_Test()
        {
            //Ported from Const17.cs
            OutputHelper.WriteLine("Tests if assignments in a constructor function, when test class inherits 2 constructors");
            OutputHelper.WriteLine("and extends one of them with base");
            Assert.True(ConstructorsTestClass17.testMethod());
        }

        [TestMethod]
        public void Constructors20_Test()
        {
            //Ported from Const20.cs
            OutputHelper.WriteLine("Tests if assignments in a constructor and its base are both functional");
            Assert.True(ConstructorsTestClass20.testMethod());
        }

        [TestMethod]
        public void Constructors21_Test()
        {
            //Ported from Const21.cs
            OutputHelper.WriteLine("Tests if assignments in a constructor and its base, and its base's base are all functional");
            Assert.True(ConstructorsTestClass21.testMethod());
        }

        [TestMethod]
        public void Constructors22_Test()
        {
            //Ported from Const22.cs
            OutputHelper.WriteLine("Tests if assignments in both a class' constructors are functional when a parametered constructor extends");
            OutputHelper.WriteLine("a not-parametered one with 'this'");
            Assert.True(ConstructorsTestClass22.testMethod());
        }

        [TestMethod]
        public void Constructors23_Test()
        {
            //Ported from Const23.cs
            OutputHelper.WriteLine("Tests if assignments in both a class' constructors are functional when a not-parametered constructor extends");
            OutputHelper.WriteLine("a parametered one with 'this'");
            Assert.True(ConstructorsTestClass23.testMethod());
        }

        [TestMethod]
        public void Constructors24_Test()
        {
            //Ported from Const24.cs
            OutputHelper.WriteLine("Tests if assignments in all a class' constructors are functional in a chain of extension using 'this'");
            Assert.True(ConstructorsTestClass24.testMethod());
        }

        [TestMethod]
        public void Constructors25_Test()
        {
            //Ported from Const25.cs

            OutputHelper.WriteLine("Tests if assignments in all a class' constructors are functional when a parametered one extends a");
            OutputHelper.WriteLine("not-parametered one, which in turn extends the class' base class constructor");
            Assert.True(ConstructorsTestClass25.testMethod());
        }

        [TestMethod]
        public void Constructors26_Test()
        {
            //Ported from Const26.cs            
            OutputHelper.WriteLine("Tests if assignments in all a class' constructors are functional when a not-parametered one extends a");
            OutputHelper.WriteLine("not-parametered one in its base class, which in turn extends a parametered one in the base class");
            Assert.True(ConstructorsTestClass26.testMethod());
        }

        [TestMethod]
        public void Constructors27_Test()
        {
            //Ported from Const27.cs
            OutputHelper.WriteLine("Tests if assignments in both a class' constructors are functional when a two-parametered constructor extends");
            OutputHelper.WriteLine("a one-parametered one with 'this'");
            Assert.True(ConstructorsTestClass27.testMethod());
        }

        [TestMethod]
        public void Constructors28_Test()
        {
            //Ported from Const28.cs
            OutputHelper.WriteLine("Tests if assignments in both a class' constructors are functional when a two-parametered constructor extends");
            OutputHelper.WriteLine("a one-parametered one with 'this' and calls that constructor with a static arg");
            Assert.True(ConstructorsTestClass28.testMethod());
        }

        [TestMethod]
        public void Constructors31_Test()
        {
            //Ported from Const31.cs
            OutputHelper.WriteLine("Tests if assignments in both a class' constructors are functional when a not-parametered constructor extends");
            OutputHelper.WriteLine("a two-parametered one with 'this'");
            Assert.True(ConstructorsTestClass31.testMethod());
        }

        [TestMethod]
        public void Constructors32_Test()
        {
            //Ported from Const32.cs

            OutputHelper.WriteLine("Tests if assignments in both a class' constructors are functional when a parametered constructor extends");
            OutputHelper.WriteLine("a not-parametered one that is private with 'this'");
            Assert.True(ConstructorsTestClass32.testMethod());
        }

        [TestMethod]
        public void Constructors33_Test()
        {
            //Ported from Const33.cs

            OutputHelper.WriteLine("Tests if assignments in a class' constructor are functional when the constructor is static");
            Assert.True(ConstructorsTestClass33.testMethod());
        }

        [TestMethod]
        public void Constructors34_Test()
        {
            //Ported from Const34.cs
            OutputHelper.WriteLine("Tests if assignments in a class' constructor are functional when one constructor is static");
            OutputHelper.WriteLine("and the other isn't");
            Assert.True(ConstructorsTestClass34.testMethod());
        }

        [TestMethod]
        public void Constructors35_Test()
        {
            //From Bug# 16354/16719
            OutputHelper.WriteLine("Tests if handled exceptions in constructors continues execution");
            Assert.True(ConstructorsTestClass35.testMethod());
        }

        [TestMethod]
        public void Constructors44_Test()
        {
            //Ported from Const44.cs
            OutputHelper.WriteLine("Section 10.9.5");
            OutputHelper.WriteLine("When a class declares only private constructors it ");
            OutputHelper.WriteLine("is not possible for other classes to derive from");
            OutputHelper.WriteLine("the class or create instances of the class (an System.Exception");
            OutputHelper.WriteLine("being classes nested within the class).");
            Assert.True(ConstructorsTestClass44.testMethod());
        }

        [TestMethod]
        public void Constructors45_Test()
        {
            //Ported from Const45.cs
            OutputHelper.WriteLine("Section 10.11.");
            OutputHelper.WriteLine("It is possible to construct circular dependencies that");
            OutputHelper.WriteLine("allow static fields with variable initializers to be");
            OutputHelper.WriteLine("observed in their default value state.");
            Assert.True(ConstructorsTestClass45.testMethod());
        }

        //We initialize static constructors on load rather when enumerated, so order is not guaranteed (unlike desktop)

        //[TestMethod]
        //public void Constructors46_Test()
        //{
        //    //Ported from Const46.cs
        //    OutputHelper.WriteLine("Section 10.11.");
        //    OutputHelper.WriteLine("It is possible to construct circular dependencies that");
        //    OutputHelper.WriteLine("allow static fields with variable initializers to be");
        //    OutputHelper.WriteLine("observed in their default value state.");
        //    Assert.True(ConstructorsTestClass46.testMethod())
        //    {
        //        return MFTestResults.Pass;
        //    }
        //    return MFTestResults.Fail;
        //}

        //[TestMethod]
        //public void Constructors47_Test()
        //{
        //    //Ported from Const47.cs
        //    OutputHelper.WriteLine("Section 10.11.");
        //    OutputHelper.WriteLine("It is possible to construct circular dependencies that");
        //    OutputHelper.WriteLine("allow static fields with variable initializers to be");
        //    OutputHelper.WriteLine("observed in their default value state.");
        //    OutputHelper.WriteLine("This test is expected to fail.");
        //    Assert.True(ConstructorsTestClass47.testMethod())
        //    {
        //        return MFTestResults.Fail;
        //    }
        //    return MFTestResults.Pass;
        //}

        [TestMethod]
        public void Constructors50_Test()
        {
            //Ported from Const50.cs
            OutputHelper.WriteLine("The scope of the parameters given by the formal");
            OutputHelper.WriteLine("parameter list of a constructor includes the");
            OutputHelper.WriteLine("constructor initializer of that declaration.");
            OutputHelper.WriteLine("Thus, a constructor initializer is permitted to");
            OutputHelper.WriteLine("access the parameters of the constructor.");
            Assert.True(ConstructorsTestClass50.testMethod());
        }

        [TestMethod]
        public void Constructors51_Test()
        {
            //Ported from Const51.cs
            OutputHelper.WriteLine("Section 10.9");
            OutputHelper.WriteLine("The scope of the parameters given by the formal");
            OutputHelper.WriteLine("parameter list of a constructor includes the");
            OutputHelper.WriteLine("constructor initializer of that declaration.");
            OutputHelper.WriteLine("Thus, a constructor initializer is permitted to");
            OutputHelper.WriteLine("access the parameters of the constructor.");
            Assert.True(ConstructorsTestClass51.testMethod());
        }

        [TestMethod]
        public void Constructors52_Test()
        {
            OutputHelper.WriteLine("Testing a constructor with a '(params int[] values)' prototype, called with 3 ints");
            //Ported from Const52.cs
            Assert.True(ConstructorsTestClass52.testMethod());
        }

        [TestMethod]
        public void Constructors54_Test()
        {
            //Ported from Const54.cs
            OutputHelper.WriteLine("Testing a constructor with a '(params int[] values)' prototype, called with 3 ints from its derived class");
            Assert.True(ConstructorsTestClass54.testMethod());
        }

        [TestMethod]
        public void Constructors55_Test()
        {
            //Ported from Const55.cs

            OutputHelper.WriteLine("Testing a constructor with a '(params int[] values)' prototype, called with 3 ints");
            OutputHelper.WriteLine(" from its derived class, and both constructors are 'protected internal'");
            Assert.True(ConstructorsTestClass55.testMethod());
        }

        [TestMethod]
        public void Constructors56_Test()
        {
            OutputHelper.WriteLine("Testing a constructor with a '(params int[] values)' prototype, called with 3 ints");
            OutputHelper.WriteLine(" from its derived class implicitly, and both constructors are 'internal'");
            //Ported from Const56.cs
            Assert.True(ConstructorsTestClass56.testMethod());
        }

        [TestMethod]
        public void Constructors57_Test()
        {
            //Ported from Const57.cs
            OutputHelper.WriteLine("Testing a 'private' constructor with a '(params int[] values)' prototype, called with 3 ints");
            Assert.True(ConstructorsTestClass57.testMethod());
        }

        [TestMethod]
        public void Constructors64_Test()
        {
            //Ported from Const64.cs
            OutputHelper.WriteLine("Instance constructors, destructors, and static constructors are not inherited");
            Assert.True(ConstructorsTestClass64.testMethod());
        }

        [TestMethod]
        public void ConstructorName_01()
        {
            var classToTest = typeof(ClassWith3Constructors);

            ConstructorInfo[] constructors = classToTest.GetConstructors();

            Assert.Equal(3, constructors.Length, $"Expecting 3 constructors, got {constructors.Length}.");
            
            foreach (ConstructorInfo constructorInfo in constructors)
            {
                Assert.Equal(constructorInfo.Name, ".ctor", $"Expecting '.ctor' as constructor name, but got: {constructorInfo.Name}");
            }
        }

        [TestMethod]
        public void ConstructorName_02()
        {
            var classToTest = typeof(ConstructorsTestClass2);

            ConstructorInfo[] constructors = classToTest.GetConstructors();

            Assert.Equal(1, constructors.Length, $"Expecting 1 constructor, got {constructors.Length}.");

            foreach (ConstructorInfo constructorInfo in constructors)
            {
                Assert.Equal(constructorInfo.Name, ".ctor", $"Expecting '.ctor' as constructor name, but got: {constructorInfo.Name}");
            }
        }

        [TestMethod]
        public void ConstructorName_03()
        {
            // constructor without modifier
            var classToTest = typeof(ConstructorsTestClass3);

            ConstructorInfo[] constructors = classToTest.GetConstructors();

            Assert.Equal(0, constructors.Length, $"Didn't expecting any constructor, got {constructors.Length}.");
        }

        [TestMethod]
        public void ConstructorName_04()
        {
            // internal constructor 
            var classToTest = typeof(ConstructorsTestClass5);

            ConstructorInfo[] constructors = classToTest.GetConstructors();

            Assert.Equal(0, constructors.Length, $"Didn't expecting any constructor, got {constructors.Length}.");
        }

        [TestMethod]
        public void ConstructorName_05()
        {
            // private constructor 
            var classToTest = typeof(ConstructorsTestClass6);

            ConstructorInfo[] constructors = classToTest.GetConstructors();

            Assert.Equal(0, constructors.Length, $"Didn't expecting any constructor, got {constructors.Length}.");
        }

        [TestMethod]
        public void ConstructorName_06()
        {
            // static constructor 
            var classToTest = typeof(ConstructorsTestClass36);

            ConstructorInfo[] constructors = classToTest.GetConstructors();

            Assert.Equal(1, constructors.Length, $"Expecting 1 constructor, got {constructors.Length}.");

            foreach (ConstructorInfo constructorInfo in constructors)
            {
                Assert.Equal(constructorInfo.Name, ".ctor", $"Expecting '.ctor' as constructor name, but got: {constructorInfo.Name}");
            }
        }

        [TestMethod]
        public void ConstructorName_07()
        {
            // constructor for base class
            var classToTest = typeof(ConstructorsTestClass44_Base);

            ConstructorInfo[] constructors = classToTest.GetConstructors();

            Assert.Equal(1, constructors.Length, $"Expecting 1 constructor, got {constructors.Length}.");

            foreach (ConstructorInfo constructorInfo in constructors)
            {
                Assert.Equal(constructorInfo.Name, ".ctor", $"Expecting '.ctor' as constructor name, but got: {constructorInfo.Name}");
            }
        }

        [TestMethod]
        public void ConstructorName_08()
        {
            // constructor for derived class
            var classToTest = typeof(ConstructorsTestClass44);

            ConstructorInfo[] constructors = classToTest.GetConstructors();

            Assert.Equal(1, constructors.Length, $"Expecting 1 constructor, got {constructors.Length}.");

            foreach (ConstructorInfo constructorInfo in constructors)
            {
                Assert.Equal(constructorInfo.Name, ".ctor", $"Expecting '.ctor' as constructor name, but got: {constructorInfo.Name}");
            }
        }

        [TestMethod]
        public void ConstructorParametersInfo_01()
        {
            var classToTest = typeof(ClassWith3Constructors);

            ConstructorInfo[] constructors = classToTest.GetConstructors();

            // get ParameterInfo for 1st constructor
            ParameterInfo[] constructorParameters = constructors[0].GetParameters();

            OutputHelper.WriteLine("Checking parameters for 1st constructor of ClassWith3Constructors");
            Assert.Equal(0, constructorParameters.Length, $"Expecting no parameters, got {constructorParameters.Length}.");

            // get ParameterInfo for 2nd constructor
            constructorParameters = constructors[1].GetParameters();

            Assert.Equal(1, constructorParameters.Length, $"Expecting 1 parameter, got {constructorParameters.Length}.");

            OutputHelper.WriteLine("Checking parameters for 2nd constructor of ClassWith3Constructors");
            Assert.Equal(constructorParameters[0].ParameterType.ToString(), $"{typeof(int)}", $"Expecting parameter of type {typeof(int)}, got {constructorParameters[0].ParameterType}.");

            // get ParameterInfo for 3rd constructor
            constructorParameters = constructors[2].GetParameters();

            Assert.Equal(2, constructorParameters.Length, $"Expecting 2 parameters, got {constructorParameters.Length}.");

            OutputHelper.WriteLine("Checking parameters for 3rd constructor of ClassWith3Constructors");
            Assert.Equal(constructorParameters[0].ParameterType.ToString(), $"{typeof(int)}", $"Expecting parameter of type {typeof(int)}, got {constructorParameters[0].ParameterType}.");
            Assert.Equal(constructorParameters[1].ParameterType.ToString(), $"{typeof(string)}", $"Expecting parameter of type {typeof(string)}, got {constructorParameters[0].ParameterType}.");
        }

        //Constructors Test Classes
        class ConstructorsTestClass1
        {

            //no modifier
            ConstructorsTestClass1()
            {
                intI = 2;
            }

            int intI;

            public static bool testMethod()
            {
                ConstructorsTestClass1 test = new ConstructorsTestClass1();
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

        class ConstructorsTestClass2
        {
            //public
            public ConstructorsTestClass2()
            {
                intI = 2;
            }

            int intI;

            public static bool testMethod()
            {
                ConstructorsTestClass2 test = new ConstructorsTestClass2();
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

        class ConstructorsTestClass3
        {

            //protected
            protected ConstructorsTestClass3()
            {
                intI = 2;
            }

            int intI;

            public static bool testMethod()
            {
                ConstructorsTestClass3 test = new ConstructorsTestClass3();
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

        class ConstructorsTestClass5
        {

            //internal
            internal ConstructorsTestClass5()
            {
                intI = 2;
            }

            int intI;

            public static bool testMethod()
            {
                ConstructorsTestClass5 test = new ConstructorsTestClass5();
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

        class ConstructorsTestClass6
        {

            //private
            private ConstructorsTestClass6()
            {
                intI = 2;
            }

            int intI;

            public static bool testMethod()
            {
                ConstructorsTestClass6 test = new ConstructorsTestClass6();
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


        class ConstructorsTestClass8
        {

            //one parameter
            ConstructorsTestClass8(int intX)
            {
                intI = intX;
            }

            int intI;

            public static bool testMethod()
            {
                ConstructorsTestClass8 test = new ConstructorsTestClass8(3);
                if (test.intI == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        class ConstructorsTestClass10
        {

            ConstructorsTestClass10()
            {
                intI = 2;
            }

            ConstructorsTestClass10(int intX)
            {
                intI = intX;
            }

            int intI;

            public static bool testMethod()
            {

                ConstructorsTestClass10 test = new ConstructorsTestClass10(3); //calling constructor with parameter
                if (test.intI == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass11
        {

            //multiple parameters
            ConstructorsTestClass11(int intX, int intY)
            {
                intI = intX + intY;
            }

            int intI;

            public static bool testMethod()
            {
                ConstructorsTestClass11 test = new ConstructorsTestClass11(3, 4);
                if (test.intI == 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        class ConstructorsTestClass13
        {

            //multiple parameters
            ConstructorsTestClass13(int int1, int int2, int int3, int int4, int int5, int int6, int int7, int int8, int int9, int int10)
            {
                intI = int1 + int2 + int3 + int4 + int5 + int6 + int7 + int8 + int9 + int10;
            }

            int intI;

            public static bool testMethod()
            {
                ConstructorsTestClass13 test = new ConstructorsTestClass13(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
                if (test.intI == 55)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }




        class ConstructorsTestClass16_Base
        {

            public int intI = 1;

            protected ConstructorsTestClass16_Base()
            {
                intI = 2;
            }
        }

        class ConstructorsTestClass16 : ConstructorsTestClass16_Base
        {

            //base constructor initializer
            ConstructorsTestClass16() : base()
            {
                intI = intI * 2;
            }

            public static bool testMethod()
            {

                ConstructorsTestClass16 Test = new ConstructorsTestClass16();

                if (Test.intI == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass17_Base
        {

            public int intI = 1;

            protected ConstructorsTestClass17_Base()
            {
                intI = 2;
            }
            protected ConstructorsTestClass17_Base(int intJ)
            {
                intI = intJ;
            }
        }

        class ConstructorsTestClass17 : ConstructorsTestClass17_Base
        {
            //base constructor initializer
            ConstructorsTestClass17() : base(3)
            {
                intI = intI * 2;
            }

            public static bool testMethod()
            {

                ConstructorsTestClass17 Test = new ConstructorsTestClass17();

                if (Test.intI == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass20_Base
        {

            public int intI = 1;

            protected ConstructorsTestClass20_Base(int intJ, int intK)
            {
                intI = intJ + intK;
            }
        }

        class ConstructorsTestClass20 : ConstructorsTestClass20_Base
        {

            //base constructor initializer
            ConstructorsTestClass20()
                : base(3, 4)
            {
                intI = intI * 2;
            }

            public static bool testMethod()
            {

                ConstructorsTestClass20 Test = new ConstructorsTestClass20();

                if (Test.intI == 14)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass21_Base1
        {
            public int intI = 1;

            protected ConstructorsTestClass21_Base1()
            {
                intI = 2;
            }
        }

        class ConstructorsTestClass21_Base2 : ConstructorsTestClass21_Base1
        {

            protected ConstructorsTestClass21_Base2()
                : base()
            {
                intI = intI * 2;
            }

        }

        class ConstructorsTestClass21 : ConstructorsTestClass21_Base2
        {

            //base constructor initializer
            ConstructorsTestClass21()
                : base()
            {
                intI = intI * 2;
            }

            public static bool testMethod()
            {
                ConstructorsTestClass21 test = new ConstructorsTestClass21();
                if (test.intI == 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass22
        {

            int intI = 1;

            ConstructorsTestClass22()
            {
                intI = 2;
            }


            //this constructor initializer
            ConstructorsTestClass22(int intJ)
                : this()
            {
                intI = intI * intJ;
            }

            public static bool testMethod()
            {

                ConstructorsTestClass22 Test = new ConstructorsTestClass22(2);

                if (Test.intI == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        class ConstructorsTestClass23
        {

            int intI = 1;

            ConstructorsTestClass23()
                : this(3)
            {
                intI = intI * 2;
            }

            //this constructor initializer
            ConstructorsTestClass23(int intJ)
            {
                intI = intJ;
            }

            public static bool testMethod()
            {

                ConstructorsTestClass23 Test = new ConstructorsTestClass23();

                if (Test.intI == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        class ConstructorsTestClass24
        {

            int intI = 1;

            ConstructorsTestClass24()
            {
                intI = 2;
            }


            //this constructor initializer
            ConstructorsTestClass24(int intJ)
                : this()
            {
                intI = intI * intJ;
            }

            //this constructor initializer
            ConstructorsTestClass24(int intK, int intL)
                : this(3)
            {
                intI = (intI + intK) * intL;
            }



            public static bool testMethod()
            {

                ConstructorsTestClass24 Test = new ConstructorsTestClass24(3, 4);

                if (Test.intI == 36)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass25_Base
        {

            public int intI = 1;

            protected ConstructorsTestClass25_Base()
            {
                intI = 2;
            }
        }

        class ConstructorsTestClass25 : ConstructorsTestClass25_Base
        {

            //base constructor initializer
            ConstructorsTestClass25()
                : base()
            {
                intI = intI * 2;
            }

            //this constructor initializer
            ConstructorsTestClass25(int intJ)
                : this()
            {
                intI = intI + intJ;
            }

            public static bool testMethod()
            {

                ConstructorsTestClass25 Test = new ConstructorsTestClass25(3);

                if (Test.intI == 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass26_Base
        {

            public int intI = 1;

            //this constructor initializer
            protected ConstructorsTestClass26_Base()
                : this(3)
            {
                intI = intI * 2;
            }

            protected ConstructorsTestClass26_Base(int intJ)
            {
                intI = intJ;
            }

        }

        class ConstructorsTestClass26 : ConstructorsTestClass26_Base
        {

            //base constructor initializer
            ConstructorsTestClass26()
                : base()
            {
                intI = intI * 2;
            }

            public static bool testMethod()
            {

                ConstructorsTestClass26 Test = new ConstructorsTestClass26();

                if (Test.intI == 12)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass27
        {

            int intI = 1;

            ConstructorsTestClass27(int intJ)
            {
                intI = intJ;
            }

            //this constructor initializer
            ConstructorsTestClass27(int intK, int intL)
                : this(intL)
            {
                intI = intI + intK;
            }



            public static bool testMethod()
            {

                ConstructorsTestClass27 Test = new ConstructorsTestClass27(3, 4);

                if (Test.intI == 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass28
        {

            static int int3 = 3;

            int intI = 1;

            ConstructorsTestClass28(int intJ)
            {
                intI = intJ;
            }

            //this constructor initializer
            ConstructorsTestClass28(int intK, int intL)
                : this(ConstructorsTestClass28.int3)
            {
                intI = (intI + intK) * intL;
            }



            public static bool testMethod()
            {

                ConstructorsTestClass28 Test = new ConstructorsTestClass28(3, 4);

                if (Test.intI == 24)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        class ConstructorsTestClass31
        {

            int intI = 1;

            ConstructorsTestClass31()
                : this(3, 4)
            {
                intI = intI * 2;
            }

            //this constructor initializer
            ConstructorsTestClass31(int intK, int intL)
            {
                intI = intK + intL;
            }



            public static bool testMethod()
            {

                ConstructorsTestClass31 Test = new ConstructorsTestClass31();

                if (Test.intI == 14)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        class ConstructorsTestClass32
        {

            int intI = 1;

            private ConstructorsTestClass32()
            {
                intI = 2;
            }


            //this constructor initializer
            ConstructorsTestClass32(int intJ)
                : this()
            {
                intI = intI * intJ;
            }

            public static bool testMethod()
            {

                ConstructorsTestClass32 Test = new ConstructorsTestClass32(2);

                if (Test.intI == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        class ConstructorsTestClass33
        {

            //static constructor
            static ConstructorsTestClass33()
            {
                intI = 2;
            }

            static int intI = 1;

            public static bool testMethod()
            {
                if (intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass34
        {

            //static constructor
            static ConstructorsTestClass34()
            {
                intI = 2;
            }

            ConstructorsTestClass34()
            {
                intI = 3;
            }

            static int intI = 1;

            public static bool testMethod()
            {

                bool RetVal = true;

                if (intI != 2)
                {
                    RetVal = false;
                }

                ConstructorsTestClass34 Test = new ConstructorsTestClass34();

                if (intI != 3)
                {
                    RetVal = false;
                }

                return RetVal;
            }
        }

        class ConstructorsTestClass35
        {

            // static constructor - with Exception
            static ConstructorsTestClass35()
            {
                try { throw new Exception(); }
                catch { }
                intI = 5;
            }

            static int intI = 1;

            public static bool testMethod()
            {
                return (intI == 5);
            }
        }

        class ConstructorsTestClass36
        {

            // static constructor
            static ConstructorsTestClass36()
            {
                intI = 5;
            }

            static int intI = 1;

            public static bool testMethod()
            {
                return (intI == 5);
            }
        }

        class ConstructorsTestClass44_Base
        {

            protected int MyInt = 2;

            private ConstructorsTestClass44_Base() { }
            public ConstructorsTestClass44_Base(int intI)
            {
                MyInt = intI;
            }
        }

        class ConstructorsTestClass44 : ConstructorsTestClass44_Base
        {

            public ConstructorsTestClass44() : base(1) { }

            public static bool testMethod()
            {
                ConstructorsTestClass44 test = new ConstructorsTestClass44();
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

        class ConstructorsTestClass45
        {

            int intI;

            private ConstructorsTestClass45()
            {
                intI = 1;
            }

            public static bool testMethod()
            {
                return InnerClass.testMethod();
            }

            class InnerClass
            {
                public static bool testMethod()
                {
                    ConstructorsTestClass45 test = new ConstructorsTestClass45();
                    if (test.intI == 1)
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

        class ConstructorsTestClass46_sub
        {
            public static int X = ConstructorsTestClass46.Y + 1;
        }

        class ConstructorsTestClass46
        {
            public static int Y = ConstructorsTestClass46_sub.X + 1;
            public static bool testMethod()
            {
                if ((ConstructorsTestClass46_sub.X == 1) && (ConstructorsTestClass46.Y == 2))
                {
                    return true;
                }
                else
                {
                    OutputHelper.WriteLine("Expected X==1, got X=" + ConstructorsTestClass46_sub.X);
                    OutputHelper.WriteLine("Expected Y==2, got Y=" + ConstructorsTestClass46.Y);
                    return false;
                }
            }
        }

        class ConstructorsTestClass47
        {
            public static int X = ConstructorsTestClass47_sub.Y + 1;
            public static bool testMethod()
            {
                if ((ConstructorsTestClass47.X == 2) && (ConstructorsTestClass47_sub.Y == 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass47_sub
        {
            public static int Y = ConstructorsTestClass47.X + 1;
        }

        class ConstructorsTestClass50_Base
        {
            public int intI;
            public ConstructorsTestClass50_Base(int x, int y)
            {
                intI = x * 2 + y * 3;
            }
        }

        class ConstructorsTestClass50 : ConstructorsTestClass50_Base
        {
            public ConstructorsTestClass50(int x, int y) : base(x + y, x - y) { }
            public static bool testMethod()
            {
                ConstructorsTestClass50 test = new ConstructorsTestClass50(5, 3);
                if (test.intI == 22)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        class ConstructorsTestClass51
        {

            int intI;
            public ConstructorsTestClass51(int x, int y, int z)
            {
                intI = x * 2 + y * 3;
            }
            public ConstructorsTestClass51(int x, int y) : this(x + y, x - y, 0) { }

            public static bool testMethod()
            {
                ConstructorsTestClass51 test = new ConstructorsTestClass51(5, 3);
                if (test.intI == 22)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass52
        {

            int intTest;

            public ConstructorsTestClass52(params int[] values)
            {
                intTest = values[0] + values[1] + values[2];
            }

            public static bool testMethod()
            {

                int intI = 1;
                int intJ = 2;
                int intK = 3;

                ConstructorsTestClass52 mc = new ConstructorsTestClass52(intI, intJ, intK);
                if (mc.intTest == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass53
        {

            int intTest;

            public ConstructorsTestClass53(params int[] values)
            {
                intTest = values[0] + values[1] + values[2];
            }

            public static bool testMethod()
            {

                int intI = 1;
                int intJ = 2;
                int intK = 3;

                ConstructorsTestClass53 mc = new ConstructorsTestClass53(intI, intJ, intK);
                if (mc.intTest == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass54_base
        {

            public int intTest;

            protected ConstructorsTestClass54_base(params int[] values)
            {
                intTest = values[0] + values[1] + values[2];
            }
        }

        class ConstructorsTestClass54 : ConstructorsTestClass54_base
        {

            protected ConstructorsTestClass54(params int[] values) : base(values) { }

            public static bool testMethod()
            {

                int intI = 1;
                int intJ = 2;
                int intK = 3;

                ConstructorsTestClass54 mc = new ConstructorsTestClass54(intI, intJ, intK);

                if (mc.intTest == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass55_Base
        {

            public int intTest;

            protected internal ConstructorsTestClass55_Base(params int[] values)
            {
                intTest = values[0] + values[1] + values[2];
            }
        }

        class ConstructorsTestClass55 : ConstructorsTestClass55_Base
        {

            protected internal ConstructorsTestClass55(params int[] values) : base(values) { }

            public static bool testMethod()
            {

                int intI = 1;
                int intJ = 2;
                int intK = 3;

                ConstructorsTestClass55 mc = new ConstructorsTestClass55(intI, intJ, intK);

                if (mc.intTest == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ConstructorsTestClass56_Sub
        {

            public int intTest;

            internal ConstructorsTestClass56_Sub(params int[] values)
            {
                intTest = values[0] + values[1] + values[2];
            }


        }

        class ConstructorsTestClass56
        {

            public static bool testMethod()
            {

                int intI = 1;
                int intJ = 2;
                int intK = 3;

                ConstructorsTestClass56_Sub mc = new ConstructorsTestClass56_Sub(intI, intJ, intK);
                if (mc.intTest == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        class ConstructorsTestClass57
        {

            int intTest;

            private ConstructorsTestClass57(params int[] values)
            {
                intTest = values[0] + values[1] + values[2];
            }

            public static bool testMethod()
            {

                int intI = 1;
                int intJ = 2;
                int intK = 3;

                ConstructorsTestClass57 mc = new ConstructorsTestClass57(intI, intJ, intK);
                if (mc.intTest == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public class ConstructorsTestClass64_Base
        {
            public ConstructorsTestClass64_Base()
            {
            }
            ~ConstructorsTestClass64_Base()
            {
            }
        }

        class ConstructorsTestClass64_Derived : ConstructorsTestClass64_Base
        {
        }

        class ConstructorsTestClass64
        {

            public static bool testMethod()
            {
                ConstructorsTestClass64_Derived d = new ConstructorsTestClass64_Derived();

                MethodInfo mi = d.GetType().GetMethod("Finalize", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                if (null != mi)
                {

                    return false;
                }

                return true;
            }
        }

        public class ClassWith3Constructors
        {
            public int intValue = 0;
            public string stringValue = "";

            public ClassWith3Constructors() { }

            public ClassWith3Constructors(int intValue) { this.intValue = intValue; }

            public ClassWith3Constructors(int intValue, string stringValue)
            {
                this.intValue = intValue;
                this.stringValue = stringValue;
            }
        }
    }
}
