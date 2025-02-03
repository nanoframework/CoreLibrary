// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestConversions
{
    [TestClass]
    class UnitTestExprefTests
    {
        [TestMethod]
        public void Expref_obj_ref_Test()
        {
            //  Converting from 'object' to a reference object. 
            Assert.IsTrue(ExprefTestClass_obj_ref.testMethod());
        }

        [TestMethod]
        public void Expref_obj_ref_exc_Test()
        {

            //  Converting from 'object' to a reference object. 
            Assert.IsTrue(ExprefTestClass_obj_ref_exc.testMethod());
        }

        [TestMethod]
        public void Expref_class_class_Test()
        {

            //  Tests that you can convert from a base class to a derived class
            Assert.IsTrue(ExprefTestClass_class_class.testMethod());
        }

        [TestMethod]
        public void Expref_class_class_exc_Test()
        {

            //  Tests that you can convert from a base class to a derived class
            Assert.IsTrue(ExprefTestClass_class_class_exc.testMethod());
        }

        [TestMethod]
        public void Expref_inter_struct_exc_Test()
        {

            //  Tests that you can convert from an interface to a struct that implements it.
            Assert.IsTrue(ExprefTestClass_inter_struct_exc.testMethod());
        }

        [TestMethod]
        public void Expref_class_inter_Test()
        {
            //  Tests converting from a class to an interface that the class does not implement (but a derived class might).
            Assert.IsTrue(ExprefTestClass_class_inter.testMethod());
        }

        [TestMethod]
        public void Expref_class_inter_exc_Test()
        {
            //  Tests converting from a class to an interface that the class does not implement (but a derived class might).
            Assert.IsTrue(ExprefTestClass_class_inter_exc.testMethod());
        }

        [TestMethod]
        public void Expref_inter_class_Test()
        {
            //  Tests converting from an interface to a class
            // From any interface-type S to any class-type T, provided T is not sealed, or provided T implements S.
            // If T implements S:
            Assert.IsTrue(ExprefTestClass_inter_class.testMethod());
        }

        [TestMethod]
        public void Expref_inter_class2_Test()
        {
            //  Tests converting from an interface to a class
            Assert.IsTrue(ExprefTestClass_inter_class2.testMethod());
        }

        [TestMethod]
        public void Expref_inter_class2_exc1_Test()
        {
            //  Tests converting from an interface to a class
            Assert.IsTrue(ExprefTestClass_inter_class2_exc1.testMethod());
        }

        [TestMethod]
        public void Expref_inter_class2_exc2_Test()
        {

            //  Tests converting from an interface to a class
            Assert.IsTrue(ExprefTestClass_inter_class2_exc2.testMethod());
        }

        [TestMethod]
        public void Expref_inter_class_exc_Test()
        {

            //  Tests converting from an interface to a class
            Assert.IsTrue(ExprefTestClass_inter_class_exc.testMethod());
        }

        [TestMethod]
        public void Expref_inter_class_sealed_Test()
        {
            //  Tests converting from an interface to a class
            Assert.IsTrue(ExprefTestClass_inter_class_sealed.testMethod());
        }

        [TestMethod]
        public void Expref_inter_class_sealed_exc_Test()
        {
            //  Tests converting from an interface to a class
            Assert.IsTrue(ExprefTestClass_inter_class_sealed_exc.testMethod());
        }

        [TestMethod]
        public void Expref_inter_inter_Test()
        {
            //  Tests converting from an interface to an interface
            Assert.IsTrue(ExprefTestClass_inter_inter.testMethod());
        }

        [TestMethod]
        public void Expref_inter_inter_exc_Test()
        {
            //  Tests converting from an interface to an interface
            Assert.IsTrue(ExprefTestClass_inter_inter_exc.testMethod());
        }

        [TestMethod]
        public void Impenum_zero_Test()
        {
            // Tests whether 0 can be converted to various enum types...
            Assert.IsTrue(ImpenumTestClass_zero.testMethod());
        }

        [TestMethod]
        public void Impref_ref_obj_Test()
        {
            //  Converting from a reference object to 'object'
            Assert.IsTrue(ImprefTestClass_ref_obj.testMethod());
        }

        [TestMethod]
        public void Impref_class_class_Test()
        {
            //  Tests that you can convert from a class to a base class. 
            Assert.IsTrue(ImprefTestClass_class_class.testMethod());
        }

        [TestMethod]
        public void Impref_class_inter_Test()
        {
            //  Tests that you can convert from a class to an interface that it implements. 
            Assert.IsTrue(ImprefTestClass_class_inter.testMethod());
        }

        [TestMethod]
        public void Impref_struct_inter_Test()
        {
            //  Tests that you can convert from a struct to an interface that it implements. 
            Assert.IsTrue(ImprefTestClass_struct_inter.testMethod());
        }

        [TestMethod]
        public void Impref_array_array_Test()
        {
            //  Tests that you can convert from an array of one class to an array of another class...
            Assert.IsTrue(ImprefTestClass_array_array.testMethod());
        }

        [TestMethod]
        public void Impref_array_cloneable_Test()
        {
            //  Tests that you can convert from an array to System.ICloneable;
            Assert.IsTrue(ImprefTestClass_array_cloneable.testMethod());
        }

        [TestMethod]
        public void Impref_null_ref_Test()
        {
            //  Tests that you can convert from null to several reference types
            Assert.IsTrue(ImprefTestClass_null_ref.testMethod());
        }

        [TestMethod]
        public void Impref_delegate_to_SystemDotDelegate_Test()
        {
            //  Tests that you can convert from a delegate type to System.Delegate
            Assert.IsTrue(ImprefTestClass_delegate_to_SystemDotDelegate.testMethod());
        }


        //Compiled Test Cases 
        public class ImprefTestClass_ref_obj_Sub
        {
            int func() { return (1); }
        }
        public class ImprefTestClass_ref_obj
        {
            public static bool testMethod()
            {
                ImprefTestClass_ref_obj_Sub test = new ImprefTestClass_ref_obj_Sub();
                object obj;
                obj = test;
                return true;
            }
        }

        class ImprefTestClass_class_class_Der1
        {
            void i() { }
        }

        class ImprefTestClass_class_class_Der2 : ImprefTestClass_class_class_Der1
        {
            void j() { }
        }
        public class ImprefTestClass_class_class
        {
            public static bool testMethod()
            {
                ImprefTestClass_class_class_Der2 derivedClass = new ImprefTestClass_class_class_Der2();

                ImprefTestClass_class_class_Der1 ImprefTestClass_class_class_Base;
                ImprefTestClass_class_class_Base = derivedClass;
                return true;
            }
        }

        interface ImprefTestClass_class_inter_Interface1
        {
            void i();
        }
        interface ImprefTestClass_class_inter_Interface2
        {
            void j();
        }

        class ImprefTestClass_class_inter_Sub : ImprefTestClass_class_inter_Interface1, ImprefTestClass_class_inter_Interface2
        {
            public void i() { }
            public void j() { }
        }
        public class ImprefTestClass_class_inter
        {
            public static bool testMethod()
            {
                ImprefTestClass_class_inter_Sub ImprefTestClass_class_inter_Sub = new ImprefTestClass_class_inter_Sub();
                ImprefTestClass_class_inter_Interface2 inter2;
                ImprefTestClass_class_inter_Interface1 inter1;
                inter1 = ImprefTestClass_class_inter_Sub;
                inter2 = ImprefTestClass_class_inter_Sub;
                return true;
            }

        }

        interface ImprefTestClass_struct_inter_Interface1
        {
            void i();
        }
        interface ImprefTestClass_struct_inter_Interface2
        {
            void j();
        }

        struct ImprefTestClass_struct_inter_Sub : ImprefTestClass_struct_inter_Interface1, ImprefTestClass_struct_inter_Interface2
        {
            public void i() { }
            public void j() { }
        }
        public class ImprefTestClass_struct_inter
        {
            public static bool testMethod()
            {
                ImprefTestClass_struct_inter_Sub ImprefTestClass_struct_inter_Sub = new ImprefTestClass_struct_inter_Sub();
                ImprefTestClass_struct_inter_Interface2 inter2;
                ImprefTestClass_struct_inter_Interface1 inter1;
                inter2 = ImprefTestClass_struct_inter_Sub;
                inter1 = ImprefTestClass_struct_inter_Sub;
                return true;
            }
        }

        class ImprefTestClass_array_array_Base1
        {
            public void i() { }
        }

        class ImprefTestClass_array_array_Base2 : ImprefTestClass_array_array_Base1
        {
            public void j() { }
        }
        public class ImprefTestClass_array_array
        {
            public static bool testMethod()
            {
                ImprefTestClass_array_array_Base2[] arrDer = new ImprefTestClass_array_array_Base2[1];
                ImprefTestClass_array_array_Base2 element = new ImprefTestClass_array_array_Base2();
                arrDer[0] = element;
                ImprefTestClass_array_array_Base1[] arrBase = new ImprefTestClass_array_array_Base1[1];
                arrBase = arrDer;
                element.j();
                arrBase[0].i();
                return true;
            }
        }

        class ImprefTestClass_array_cloneable_Derived
        {
            public void i() { }
        }

        public class ImprefTestClass_array_cloneable
        {
            public static bool testMethod()
            {
                ImprefTestClass_array_cloneable_Derived[] arrBase = new ImprefTestClass_array_cloneable_Derived[1];
                ICloneable clone;
                clone = arrBase;
                return true;
            }
        }

        class ImprefTestClass_null_ref_Derived
        {
            public void i() { }
        }
        public class ImprefTestClass_null_ref
        {
            public static bool testMethod()
            {
                ImprefTestClass_null_ref_Derived classDer1;
                String string1;
                classDer1 = null;
                string1 = null;
                return true;
            }
        }

        delegate void ImprefTestClass_delegate_to_SystemDotDelegate_Delegate();
        class ImprefTestClass_delegate_to_SystemDotDelegate
        {
            public static void DoNothing() { }
            public static bool testMethod()
            {
                ImprefTestClass_delegate_to_SystemDotDelegate_Delegate src = new ImprefTestClass_delegate_to_SystemDotDelegate_Delegate(ImprefTestClass_delegate_to_SystemDotDelegate.DoNothing);
                System.Delegate dst = src;
                src();
                return true;
            }
        }


        enum ImpenumTestClass_zero_Test1 : int
        {
            a,
            b,
            c
        }
        enum ImpenumTestClass_zero_Test2 : short
        {
            a,
            b,
            c
        }
        enum ImpenumTestClass_zero_Test3 : long
        {
            a,
            b,
            c
        }
        public class ImpenumTestClass_zero
        {
            public static bool testMethod()
            {
                ImpenumTestClass_zero_Test1 t1 = 0;
                ImpenumTestClass_zero_Test2 t2 = 0;
                ImpenumTestClass_zero_Test3 t3 = 0;
                return true;
            }
        }


        //Compiled Test Cases 
        public class ExprefTestClass_obj_ref_Sub1
        {
            public void func() {/*Old Print*/}
        }
        public class ExprefTestClass_obj_ref_Sub2
        {
            public void func() {/*Old Print*/}
        }
        public class ExprefTestClass_obj_ref
        {
            public static bool testMethod()
            {
                ExprefTestClass_obj_ref_Sub1 test = new ExprefTestClass_obj_ref_Sub1();
                object obj;
                obj = test;     // implicit setup
                test = (ExprefTestClass_obj_ref_Sub1)obj;
                test.func();
                return true;
            }
        }

        public class ExprefTestClass_obj_ref_exc_Sub1
        {
            int func() { return (1); }
        }
        public class ExprefTestClass_obj_ref_exc_Sub2
        {
            int func() { return (1); }
        }
        public class ExprefTestClass_obj_ref_exc
        {
            public static bool testMethod()
            {
                ExprefTestClass_obj_ref_exc_Sub1 test = new ExprefTestClass_obj_ref_exc_Sub1();
                ExprefTestClass_obj_ref_exc_Sub2 test2;
                object obj;
                obj = test;     // implicit setup
                try
                {
                    test2 = (ExprefTestClass_obj_ref_exc_Sub2)obj;  // obj is *not* a test2
                }
                catch (System.Exception e)
                {
                    //Old Print		
                }
                return true;
            }
        }

        class ExprefTestClass_class_class_Base1
        {
            void i() { }
        }

        class ExprefTestClass_class_class_Base2 : ExprefTestClass_class_class_Base1
        {
            void j() { }
        }
        public class ExprefTestClass_class_class
        {
            public static bool testMethod()
            {
                ExprefTestClass_class_class_Base2 derivedClass = new ExprefTestClass_class_class_Base2();

                ExprefTestClass_class_class_Base1 myBase;
                myBase = derivedClass;      // implicit conversion
                derivedClass = (ExprefTestClass_class_class_Base2)myBase;       // test conversion
                return true;
            }
        }

        class ExprefTestClass_class_class_exc_Base
        {
            void i() { }
        }

        class ExprefTestClass_class_class_exc_Der1 : ExprefTestClass_class_class_exc_Base
        {
            void j() { }
        }
        class ExprefTestClass_class_class_exc_Der2 : ExprefTestClass_class_class_exc_Base
        {
            void k() { }
        }
        public class ExprefTestClass_class_class_exc
        {
            public static bool testMethod()
            {
                ExprefTestClass_class_class_exc_Der1 derivedClass = new ExprefTestClass_class_class_exc_Der1();

                ExprefTestClass_class_class_exc_Base myBase;
                ExprefTestClass_class_class_exc_Der2 derivedClass3;
                myBase = derivedClass;      // implicit conversion
                try
                {
                    derivedClass3 = (ExprefTestClass_class_class_exc_Der2)myBase;       // test conversion
                }
                catch (System.Exception e)
                {
                    //Old Print		
                }
                return true;
            }
        }

        interface ExprefTestClass_inter_struct_exc_Interface1
        {
            void i();
        }
        public interface ExprefTestClass_inter_struct_exc_Interface2
        {
            void j();
        }

        struct ExprefTestClass_inter_struct_exc_struct1 : ExprefTestClass_inter_struct_exc_Interface1
        {
            public void i()
            {//Old Print
            }
        }
        struct TheStruct2 : ExprefTestClass_inter_struct_exc_Interface1
        {
            public void i()
            {//Old Print
            }
        }

        public class ExprefTestClass_inter_struct_exc
        {
            public static bool testMethod()
            {
                //Old Print
                ExprefTestClass_inter_struct_exc_struct1 theStruct1 = new ExprefTestClass_inter_struct_exc_struct1();
                //Old Print
                return true;
                theStruct1.i();
                ExprefTestClass_inter_struct_exc_Interface1 ExprefTestClass_inter_struct_exc_Interface1;
                ExprefTestClass_inter_struct_exc_Interface1 = theStruct1;
                theStruct1 = (ExprefTestClass_inter_struct_exc_struct1)ExprefTestClass_inter_struct_exc_Interface1;
                theStruct1.i();
                TheStruct2 theStruct2;
                theStruct2 = (TheStruct2)ExprefTestClass_inter_struct_exc_Interface1;
                theStruct2.i();
                //ExprefTestClass_inter_struct_exc.TestRoutine(ExprefTestClass_inter_struct_exc_Interface1);
                // NOTE: Currently detects this during compile time; try passing ExprefTestClass_inter_struct_exc_Interface1 to a method
                // to see if that will defeat the compile-time flow analysis. 
            }
        }
        interface ExprefTestClass_class_inter_I1
        {
            void i();
        }
        interface ExprefTestClass_class_inter_I2
        {
            void j();
        }

        class ExprefTestClass_class_inter_C1 : ExprefTestClass_class_inter_I1
        {
            public void i()
            {//Old Print
            }
        }
        class ExprefTestClass_class_inter_C2 : ExprefTestClass_class_inter_C1, ExprefTestClass_class_inter_I2
        {
            public void j()
            {//Old Print
            }
        }
        public class ExprefTestClass_class_inter
        {
            public static bool testMethod()
            {
                ExprefTestClass_class_inter_C1 thebase = new ExprefTestClass_class_inter_C2();
                try
                {
                    ExprefTestClass_class_inter_I2 i2 = (ExprefTestClass_class_inter_I2)thebase;
                    i2.j();
                }
                catch (System.Exception e)
                {
                    //Old Print
                }
                return true;
            }
        }
        interface ExprefTestClass_class_inter_exc_I1
        {
            void i();
        }
        interface ExprefTestClass_class_inter_exc_I2
        {
            void j();
        }

        class ExprefTestClass_class_inter_exc_C1 : ExprefTestClass_class_inter_exc_I1
        {
            public void i()
            {//Old Print
            }
        }
        class ExprefTestClass_class_inter_exc_C2 : ExprefTestClass_class_inter_exc_C1
        {
        }
        public class ExprefTestClass_class_inter_exc
        {
            public static bool testMethod()
            {
                ExprefTestClass_class_inter_exc_C1 thebase = new ExprefTestClass_class_inter_exc_C2();
                try
                {
                    ExprefTestClass_class_inter_exc_I2 i2 = (ExprefTestClass_class_inter_exc_I2)thebase;
                    i2.j();
                }
                catch (System.Exception e)
                {
                    //Old Print
                }
                return true;
            }
        }
        interface ExprefTestClass_inter_class_I1
        {
            void i();
        }
        class ExprefTestClass_inter_class_C1 : ExprefTestClass_inter_class_I1
        {
            public void i() {/*Old Print*/}
        }
        class ExprefTestClass_inter_class_C2 : ExprefTestClass_inter_class_I1
        {
            public void i() {/*Old Print*/}
        }
        public class ExprefTestClass_inter_class
        {
            public static bool testMethod()
            {
                ExprefTestClass_inter_class_I1 inter = new ExprefTestClass_inter_class_C1();
                try
                {
                    ExprefTestClass_inter_class_C1 c1 = (ExprefTestClass_inter_class_C1)inter;
                    c1.i();
                }
                catch (System.Exception)
                {
                    //Old Print
                }
                return true;
            }
        }
        interface ExprefTestClass_inter_class2_I1
        {
            void i();
        }
        interface ExprefTestClass_inter_class2_I2
        {
            void j();
        }
        class ExprefTestClass_inter_class2_C1 : ExprefTestClass_inter_class2_I1
        {
            public void i()
            {//Old Print
            }
        }
        class ExprefTestClass_inter_class2_C2 : ExprefTestClass_inter_class2_I1
        {
            public void i()
            {//Old Print
            }
        }
        class ExprefTestClass_inter_class2_C3 : ExprefTestClass_inter_class2_C1, ExprefTestClass_inter_class2_I2
        {
            public void j()
            {//Old Print
            }
        }
        public class ExprefTestClass_inter_class2
        {
            public static bool testMethod()
            {
                ExprefTestClass_inter_class2_I2 inter = new ExprefTestClass_inter_class2_C3();
                try
                {
                    ExprefTestClass_inter_class2_C1 c1 = (ExprefTestClass_inter_class2_C1)inter;
                    c1.i();
                }
                catch (System.Exception e)
                {
                    //Old Print
                }
                return true;
            }
        }
        interface ExprefTestClass_inter_class2_exc1_I1
        {
            void i();
        }
        interface ExprefTestClass_inter_class2_exc1_I2
        {
            void j();
        }
        class ExprefTestClass_inter_class2_exc1_C1 : ExprefTestClass_inter_class2_exc1_I1
        {
            public void i()
            {//Old Print
            }
        }
        class ExprefTestClass_inter_class2_exc1_C2 : ExprefTestClass_inter_class2_exc1_I2
        {
            public void j()
            {//Old Print
            }
        }
        public class ExprefTestClass_inter_class2_exc1
        {
            public static bool testMethod()
            {
                ExprefTestClass_inter_class2_exc1_I2 inter = new ExprefTestClass_inter_class2_exc1_C2();
                try
                {
                    ExprefTestClass_inter_class2_exc1_C1 c1 = (ExprefTestClass_inter_class2_exc1_C1)inter;
                    c1.i();
                }
                catch (System.Exception e)
                {
                    //Old Print
                }
                return true;
            }
        }
        interface ExprefTestClass_inter_class2_exc2_I1
        {
            void i();
        }
        interface ExprefTestClass_inter_class2_exc2_I2
        {
            void j();
        }
        class ExprefTestClass_inter_class2_exc2_C1 : ExprefTestClass_inter_class2_exc2_I1
        {
            public void i()
            {//Old Print
            }
        }
        class ExprefTestClass_inter_class2_exc2_C2 : ExprefTestClass_inter_class2_exc2_I2
        {
            public void j()
            {//Old Print
            }
        }
        class ExprefTestClass_inter_class2_exc2_C3 : ExprefTestClass_inter_class2_exc2_C1
        {
        }
        public class ExprefTestClass_inter_class2_exc2
        {
            public static bool testMethod()
            {
                ExprefTestClass_inter_class2_exc2_I2 inter = new ExprefTestClass_inter_class2_exc2_C2();
                try
                {
                    ExprefTestClass_inter_class2_exc2_C1 c1 = (ExprefTestClass_inter_class2_exc2_C1)inter;
                    c1.i();
                }
                catch (System.Exception e)
                {
                    //Old Print
                }
                return true;
            }
        }
        interface ExprefTestClass_inter_class_exc_I1
        {
            void i();
        }
        class ExprefTestClass_inter_class_exc_C1 : ExprefTestClass_inter_class_exc_I1
        {
            public void i()
            {//Old Print
            }
        }
        class ExprefTestClass_inter_class_exc_C2 : ExprefTestClass_inter_class_exc_I1
        {
            public void i()
            {//Old Print
            }
        }
        public class ExprefTestClass_inter_class_exc
        {
            public static bool testMethod()
            {
                ExprefTestClass_inter_class_exc_I1 inter = new ExprefTestClass_inter_class_exc_C1();
                try
                {
                    ExprefTestClass_inter_class_exc_C2 c2 = (ExprefTestClass_inter_class_exc_C2)inter;
                }
                catch (System.Exception e)
                {
                    //Old Print
                }
                return true;
            }
        }
        interface ExprefTestClass_inter_class_sealed_I1
        {
            void i();
        }
        sealed class ExprefTestClass_inter_class_sealed_C1 : ExprefTestClass_inter_class_sealed_I1
        {
            public void i() {/*Old Print*/}
        }
        class ExprefTestClass_inter_class_sealed_C2 : ExprefTestClass_inter_class_sealed_I1
        {
            public void i() {/*Old Print*/}
        }
        public class ExprefTestClass_inter_class_sealed
        {
            public static bool testMethod()
            {
                ExprefTestClass_inter_class_sealed_I1 inter = new ExprefTestClass_inter_class_sealed_C1();
                try
                {
                    ExprefTestClass_inter_class_sealed_C1 c1 = (ExprefTestClass_inter_class_sealed_C1)inter;
                    c1.i();
                }
                catch (System.Exception e)
                {
                    //Old Print
                }
                return true;
            }
        }
        interface ExprefTestClass_inter_class_sealed_exc_I1
        {
            void i();
        }
        sealed class ExprefTestClass_inter_class_sealed_exc_C1 : ExprefTestClass_inter_class_sealed_exc_I1
        {
            public void i() {/*Old Print*/}
        }
        class ExprefTestClass_inter_class_sealed_exc_C2 : ExprefTestClass_inter_class_sealed_exc_I1
        {
            public void i() {/*Old Print*/}
        }
        public class ExprefTestClass_inter_class_sealed_exc
        {
            public static bool testMethod()
            {
                ExprefTestClass_inter_class_sealed_exc_I1 inter = new ExprefTestClass_inter_class_sealed_exc_C1();
                try
                {
                    ExprefTestClass_inter_class_sealed_exc_C2 c2 = (ExprefTestClass_inter_class_sealed_exc_C2)inter;
                }
                catch (System.Exception e)
                {
                    //Old Print
                }
                return true;
            }
        }
        interface ExprefTestClass_inter_inter_I1
        {
            void i();
        }
        interface ExprefTestClass_inter_inter_I2
        {
            void j();
        }

        class ExprefTestClass_inter_inter_C1 : ExprefTestClass_inter_inter_I1
        {
            public void i() {/*Old Print*/}
        }
        class ExprefTestClass_inter_inter_C2 : ExprefTestClass_inter_inter_C1, ExprefTestClass_inter_inter_I2
        {
            public void j() {/*Old Print*/}
        }
        public class ExprefTestClass_inter_inter
        {
            public static bool testMethod()
            {
                ExprefTestClass_inter_inter_I2 i2 = (ExprefTestClass_inter_inter_I2)new ExprefTestClass_inter_inter_C2();
                try
                {
                    ExprefTestClass_inter_inter_I1 i1 = (ExprefTestClass_inter_inter_I1)i2;
                    i1.i();
                }
                catch (System.Exception e)
                {
                    //Old Print
                }
                return true;

            }
        }
        interface ExprefTestClass_inter_inter_exc_I1
        {
            void i();
        }
        interface ExprefTestClass_inter_inter_exc_I2
        {
            void j();
        }
        interface ExprefTestClass_inter_inter_exc_I3
        {
            void k();
        }

        class ExprefTestClass_inter_inter_exc_C1 : ExprefTestClass_inter_inter_exc_I1
        {
            public void i() {/*Old Print*/}
        }
        class ExprefTestClass_inter_inter_exc_C2 : ExprefTestClass_inter_inter_exc_C1, ExprefTestClass_inter_inter_exc_I2
        {
            public void j() {/*Old Print*/}
        }
        public class ExprefTestClass_inter_inter_exc
        {
            public static bool testMethod()
            {
                ExprefTestClass_inter_inter_exc_I2 i2 = (ExprefTestClass_inter_inter_exc_I2)new ExprefTestClass_inter_inter_exc_C2();
                try
                {
                    ExprefTestClass_inter_inter_exc_I3 i3 = (ExprefTestClass_inter_inter_exc_I3)i2;
                }
                catch (System.Exception e)
                {
                    //Old Print
                }
                return true;
            }
        }

    }
}
