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
    class UnitTestPropertiesTests
    {
        [TestMethod]
        public void Properties003_Test()
        {
            // Section 10.6
            // A property declaration may include set of
            // attributes, a new modifier, a valid combination
            // nof the four access modifiers, and a static modifier.
            Assert.IsTrue(PropertiesTestClass003.testMethod());
        }
        [TestMethod]
        public void Properties004_Test()
        {
            // Section 10.6
            // A property declaration may include set of
            // attributes, a new modifier, a valid combination
            // nof the four access modifiers, and a static modifier.
            Assert.IsTrue(PropertiesTestClass004.testMethod());
        }
        [TestMethod]
        public void Properties005_Test()
        {
            // Section 10.6
            // A property declaration may include set of
            // attributes, a new modifier, a valid combination
            // nof the four access modifiers, and a static modifier.
            Assert.IsTrue(PropertiesTestClass005.testMethod());
        }
        [TestMethod]
        public void Properties006_Test()
        {
            // Section 10.6
            // A property declaration may include set of
            // attributes, a new modifier, a valid combination
            // nof the four access modifiers, and a static modifier.
            Assert.IsTrue(PropertiesTestClass006.testMethod());
        }
        [TestMethod]
        public void Properties007_Test()
        {
            // Section 10.6
            // A property declaration may include set of
            // attributes, a new modifier, a valid combination
            // nof the four access modifiers, and a static modifier.
            Assert.IsTrue(PropertiesTestClass007.testMethod());
        }
        [TestMethod]
        public void Properties008_Test()
        {
            // Section 10.6
            // A property declaration may include set of
            // attributes, a new modifier, a valid combination
            // nof the four access modifiers, and a static modifier.
            Assert.IsTrue(PropertiesTestClass008.testMethod());
        }
        [TestMethod]
        public void Properties009_Test()
        {
            // Section 10.6
            // A property declaration may include set of
            // attributes, a new modifier, a valid combination
            // nof the four access modifiers, and a static modifier.
            Assert.IsTrue(PropertiesTestClass009.testMethod());
        }
        [TestMethod]
        public void Properties010_Test()
        {
            // Section 10.6
            // A property declaration may include set of
            // attributes, a new modifier, a valid combination
            // nof the four access modifiers, and a static modifier.
            Assert.IsTrue(PropertiesTestClass010.testMethod());
        }
        [TestMethod]
        public void Properties011_Test()
        {
            // Section 10.6 
            // The type of a property declaration specifies
            // the type of the property introduced by the
            // declaration, and the member-name specifies
            // the name of the property.  Unless the property
            // is an explicit interface member implementation,
            // the member name is simply an identifier.  For an
            // explicit interface member implementation, the
            // member name consists of an interface-type followed
            // by a . and an identifier.
            // This is currently an expected fail, but is resolved in 3.0 see Bug  16341 for details
            Assert.IsTrue(PropertiesTestClass011.testMethod());
        }
        [TestMethod]
        public void Properties024_Test()
        {
            // Section 10.6 
            // An instance property is associated with
            // a given instance of a class, and this instance
            // can be accessed as this in the accessors of
            // the property.
            Assert.IsTrue(PropertiesTestClass024.testMethod());
        }
        [TestMethod]
        public void Properties025_Test()
        {
            // Section 10.6 
            // An instance property is associated with
            // a given instance of a class, and this instance
            // can be accessed as this in the accessors of
            // the property.
            Assert.IsTrue(PropertiesTestClass025.testMethod());
        }
        [TestMethod]
        public void Properties026_Test()
        {
            // Section 10.6 
            // When a property is referenced in a member-access
            // of the form E.M, if M is a static property, E must
            // denote a type, and if M is an instance property,
            // E must denote an instance.
            Assert.IsTrue(PropertiesTestClass026.testMethod());
        }
        [TestMethod]
        public void Properties027_Test()
        {
            // Section 10.6 
            // When a property is referenced in a member-access
            // of the form E.M, if M is a static property, E must
            // denote a type, and if M is an instance property,
            // E must denote an instance.
            Assert.IsTrue(PropertiesTestClass027.testMethod());
        }
        [TestMethod]
        public void Properties033_Test()
        {
            // Section 10.6 
            // The accessor declarations consist of a 
            // get-accessor-declaration, a set-accessor
            // declaration, or both.
            Assert.IsTrue(PropertiesTestClass033.testMethod());
        }
        [TestMethod]
        public void Properties034_Test()
        {
            // Section 10.6 
            // The accessor declarations consist of a 
            // get-accessor-declaration, a set-accessor
            // declaration, or both.
            Assert.IsTrue(PropertiesTestClass034.testMethod());
        }
        [TestMethod]
        public void Properties035_Test()
        {
            // Section 10.6 
            // The accessor declarations consist of a 
            // get-accessor-declaration, a set-accessor
            // declaration, or both.
            Assert.IsTrue(PropertiesTestClass035.testMethod());
        }
        [TestMethod]
        public void Properties036_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass036.testMethod());
        }
        [TestMethod]
        public void Properties037_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass037.testMethod());
        }
        [TestMethod]
        public void Properties038_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass038.testMethod());
        }
        [TestMethod]
        public void Properties043_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass043.testMethod());
        }
        [TestMethod]
        public void Properties046_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass046.testMethod());
        }
        [TestMethod]
        public void Properties048_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass048.testMethod());
        }
        [TestMethod]
        public void Properties050_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass050.testMethod());
        }
        [TestMethod]
        public void Properties053_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass053.testMethod());
        }
        [TestMethod]
        public void Properties054_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass054.testMethod());
        }
        [TestMethod]
        public void Properties056_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass056.testMethod());
        }
        [TestMethod]
        public void Properties058_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass058.testMethod());
        }
        [TestMethod]
        public void Properties059_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass059.testMethod());
        }
        [TestMethod]
        public void Properties060_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass060.testMethod());
        }
        [TestMethod]
        public void Properties062_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass062.testMethod());
        }
        [TestMethod]
        public void Properties068_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass068.testMethod());
        }
        [TestMethod]
        public void Properties071_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass071.testMethod());
        }
        [TestMethod]
        public void Properties072_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass072.testMethod());
        }
        [TestMethod]
        public void Properties073_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass073.testMethod());
        }
        [TestMethod]
        public void Properties074_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass074.testMethod());
        }
        [TestMethod]
        public void Properties075_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass075.testMethod());
        }
        [TestMethod]
        public void Properties078_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass078.testMethod());
        }
        [TestMethod]
        public void Properties089_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass089.testMethod());
        }
        [TestMethod]
        public void Properties090_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass090.testMethod());
        }
        [TestMethod]
        public void Properties097_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass097.testMethod());
        }
        [TestMethod]
        public void Properties109_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass109.testMethod());
        }
        [TestMethod]
        public void Properties110_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass110.testMethod());
        }
        [TestMethod]
        public void Properties121_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass121.testMethod());
        }
        [TestMethod]
        public void Properties122_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass122.testMethod());
        }
        [TestMethod]
        public void Properties123_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            // This test is an expected fail
            Assert.IsFalse(PropertiesTestClass123.testMethod());
        }
        [TestMethod]
        public void Properties124_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            // This test is an expected fail
            Assert.IsFalse(PropertiesTestClass124.testMethod());
        }
        [TestMethod]
        public void Properties125_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass125.testMethod());
        }
        [TestMethod]
        public void Properties126_Test()
        {
            // Section 10.6 
            // Each accessor declaration consists of an
            // optional accessor-modifier, followed by the
            // keyword get or set, followed by an accessor
            Assert.IsTrue(PropertiesTestClass126.testMethod());
        }

        //Compiled Test Cases 
        class PropertiesTestClass003
        {
            int intI = 0;
            int MyProp
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
            public static bool testMethod()
            {
                PropertiesTestClass003 test = new PropertiesTestClass003();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass004_Base
        {
            public int MyProp
            {
                get
                {
                    return 1;
                }
            }
        }
        class PropertiesTestClass004 : PropertiesTestClass004_Base
        {
            int intI = 0;
            new int MyProp
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
            public static bool testMethod()
            {
                PropertiesTestClass004 test = new PropertiesTestClass004();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass005
        {
            int intI = 0;
            public int MyProp
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
            public static bool testMethod()
            {
                PropertiesTestClass005 test = new PropertiesTestClass005();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass006
        {
            int intI = 0;
            protected int MyProp
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
            public static bool testMethod()
            {
                PropertiesTestClass006 test = new PropertiesTestClass006();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass007
        {
            int intI = 0;
            internal int MyProp
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
            public static bool testMethod()
            {
                PropertiesTestClass007 test = new PropertiesTestClass007();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass008
        {
            int intI = 0;
            private int MyProp
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
            public static bool testMethod()
            {
                PropertiesTestClass008 test = new PropertiesTestClass008();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass009
        {
            int intI = 0;
            protected internal int MyProp
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
            public static bool testMethod()
            {
                PropertiesTestClass009 test = new PropertiesTestClass009();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass010
        {
            static int intI = 0;
            static int MyProp
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
            public static bool testMethod()
            {
                PropertiesTestClass010.MyProp = 2;
                if (PropertiesTestClass010.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        interface PropertiesTestClass011_Interface
        {
            int MyProp
            {
                get;
                set;
            }
        }
        class PropertiesTestClass011 : PropertiesTestClass011_Interface
        {
            static int intI = 0;
            int PropertiesTestClass011_Interface.MyProp
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
            public static bool testMethod()
            {
                try
                {
                    PropertiesTestClass011 MC = new PropertiesTestClass011();
                    ((PropertiesTestClass011_Interface)MC).MyProp = 2;
                    if (((PropertiesTestClass011_Interface)MC).MyProp == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass024
        {
            public int intI = 2;
            public int MyProp
            {
                get
                {
                    return this.intI;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass024 test = new PropertiesTestClass024();
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass025
        {
            public int intI = 1;
            public int MyProp
            {
                set
                {
                    this.intI = value;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass025 test = new PropertiesTestClass025();
                test.MyProp = 2;
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
        public class PropertiesTestClass026
        {
            public int intI = 1;
            public int MyProp
            {
                set
                {
                    this.intI = value;
                }
                get
                {
                    return intI;
                }
            }
            public int GetProp()
            {
                return MyProp;
            }
            public void SetProp(int intJ)
            {
                MyProp = intJ;
            }
            public static bool testMethod()
            {
                PropertiesTestClass026 test = new PropertiesTestClass026();
                test.SetProp(3);
                if (test.GetProp() == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass027
        {
            public static int intI = 1;
            public static int MyProp
            {
                set
                {
                    intI = value;
                }
                get
                {
                    return intI;
                }
            }
            public static int GetProp()
            {
                return MyProp;
            }
            public static void SetProp(int intJ)
            {
                MyProp = intJ;
            }
            public static bool testMethod()
            {
                PropertiesTestClass027.SetProp(3);
                if (PropertiesTestClass027.GetProp() == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass033
        {
            public int MyProp
            {
                get
                {
                    return 2;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass033 test = new PropertiesTestClass033();
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass034
        {
            public int intI = 0;
            public int MyProp
            {
                set
                {
                    intI = value;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass034 test = new PropertiesTestClass034();
                test.MyProp = 2;
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
        public class PropertiesTestClass035
        {
            public int intI = 0;
            public int MyProp
            {
                set
                {
                    intI = value;
                }
                get
                {
                    return intI;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass035 test = new PropertiesTestClass035();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass036
        {
            int intI = 0;
            public virtual int MyProp
            {
                set
                {
                    intI = value;
                }
                get
                {
                    return intI;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass036 test = new PropertiesTestClass036();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass037_Base
        {
            public virtual int MyProp
            {
                set
                {
                }
                get
                {
                    return -1;
                }
            }
        }
        public class PropertiesTestClass037 : PropertiesTestClass037_Base
        {
            int intI = 0;
            public override int MyProp
            {
                set
                {
                    intI = value;
                }
                get
                {
                    return intI;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass037_Base test = new PropertiesTestClass037();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public abstract class PropertiesTestClass038_Base
        {
            public abstract int MyProp
            {
                set;
                get;
            }
        }
        public class PropertiesTestClass038 : PropertiesTestClass038_Base
        {
            int intI = 0;
            public override int MyProp
            {
                set
                {
                    intI = value;
                }
                get
                {
                    return intI;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass038_Base test = new PropertiesTestClass038();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass043
        {
            public int TestInt = 1;
            public int MyProp
            {
                get
                {
                    TestInt = 2;
                    return -1;
                }
                set
                {
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass043 test = new PropertiesTestClass043();
                test.MyProp = 2;
                if (test.TestInt == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass046
        {
            public int MyProp
            {
                get
                {
                    short s = 3;
                    return s;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass046 test = new PropertiesTestClass046();
                if (test.MyProp == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass048_Sub
        {
            public int intI = 2;
            public static implicit operator int(PropertiesTestClass048_Sub t)
            {
                return t.intI;
            }

        }
        public class PropertiesTestClass048
        {
            public int MyProp
            {
                get
                {
                    PropertiesTestClass048_Sub test = new PropertiesTestClass048_Sub();
                    return test;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass048 MC = new PropertiesTestClass048();
                if (MC.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass050_Sub
        {
            public int intI = 2;
            public static implicit operator int(PropertiesTestClass050_Sub t)
            {
                return t.intI;
            }

        }
        public class PropertiesTestClass050
        {
            public bool b = true;
            public int MyProp
            {
                get
                {
                    if (b == true)
                    {
                        PropertiesTestClass050_Sub test = new PropertiesTestClass050_Sub();
                        return test;
                    }
                    else
                    {
                        return 3;
                    }
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass050 MC = new PropertiesTestClass050();
                PropertiesTestClass050 MC2 = new PropertiesTestClass050();
                MC.b = true;
                MC2.b = false;
                if ((MC.MyProp == 2) && (MC2.MyProp == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass053
        {
            public int MyProp
            {
                get
                {
                    throw new System.Exception();
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass053 test = new PropertiesTestClass053();
                try
                {
                    int intJ = test.MyProp;
                }
                catch (System.Exception e)
                {
                    return true;
                }
                return false;
            }
        }
        public class PropertiesTestClass054
        {
            public bool b = true;
            public int MyProp
            {
                get
                {
                    if (b == true)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new System.Exception();
                    }
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass054 MC = new PropertiesTestClass054();
                PropertiesTestClass054 MC2 = new PropertiesTestClass054();
                MC.b = true;
                MC2.b = false;

                if (MC.MyProp != 1)
                {
                    return false;
                }

                try
                {
                    int intJ = MC2.MyProp;
                }
                catch (System.Exception e)
                {
                    return true;
                }
                return false;
            }
        }
        public class PropertiesTestClass056
        {
            public int intI = 2;
            public int MyProp
            {
                set { }
                get
                {
                    intI = 3;
                    return 1;
                }

            }
            public static bool testMethod()
            {
                PropertiesTestClass056 test = new PropertiesTestClass056();
                test.MyProp = 4;
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
        public class PropertiesTestClass058
        {
            public int intI = 2;
            public int MyProp
            {
                set
                {
                    return;
                    intI = 3;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass058 test = new PropertiesTestClass058();
                test.MyProp = 4;
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
        public class PropertiesTestClass059
        {
            public int intI = 2;
            public int MyProp
            {
                set
                {
                    intI = value;
                    return;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass059 test = new PropertiesTestClass059();
                test.MyProp = 4;
                if (test.intI == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass060
        {
            bool b = true;
            public int intI = 2;
            public int MyProp
            {
                set
                {
                    if (b == true)
                    {
                        intI = value;
                        return;
                    }
                    else
                    {
                        intI = value + 1;
                        return;
                    }
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass060 test = new PropertiesTestClass060();
                PropertiesTestClass060 test2 = new PropertiesTestClass060();
                test.b = true;
                test2.b = false;
                test.MyProp = 4;
                test2.MyProp = 4;
                if ((test.intI == 4) && (test2.intI == 5))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass062
        {
            int value;
            public int MyProp
            {
                set
                {
                    this.value = 2;
                    value = 3;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass062 test = new PropertiesTestClass062();
                test.MyProp = 1;
                if (test.value == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass068_Base
        {
            public int intTest;
            public int MyProp
            {
                get
                {
                    return intTest;
                }
                set
                {
                    intTest = value;
                }
            }
        }
        public class PropertiesTestClass068 : PropertiesTestClass068_Base
        {
            new public int MyProp
            {
                get
                {
                    return intTest + 1;
                }
                set
                {
                    intTest = value + 1;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass068 test = new PropertiesTestClass068();
                test.MyProp = 2;
                if (test.MyProp == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass071_Base
        {

            public int MyProp
            {
                get
                {
                    return 1;
                }
            }
        }
        public class PropertiesTestClass071 : PropertiesTestClass071_Base
        {
            new public int MyProp
            {
                set { }
            }
            public static bool testMethod()
            {
                PropertiesTestClass071 test = new PropertiesTestClass071();
                int intJ = ((PropertiesTestClass071_Base)test).MyProp;
                if (intJ == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass072_Base
        {

            public int intI;
            public int MyProp
            {
                set { intI = value; }
            }
        }
        public class PropertiesTestClass072 : PropertiesTestClass072_Base
        {
            new public int MyProp
            {
                get { return 1; }
            }
            public static bool testMethod()
            {
                PropertiesTestClass072 test = new PropertiesTestClass072();
                ((PropertiesTestClass072_Base)test).MyProp = 2;
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
        public class PropertiesTestClass073_Base
        {

            public int MyProp
            {
                get
                {
                    return 1;
                }
            }
        }
        public class PropertiesTestClass073 : PropertiesTestClass073_Base
        {
            new public int MyProp
            {
                get { return 2; }
            }
            public static bool testMethod()
            {
                PropertiesTestClass073 test = new PropertiesTestClass073();
                int intJ = ((PropertiesTestClass073_Base)test).MyProp;
                if (intJ == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass074_Base
        {

            public int intI;
            public int MyProp
            {
                set { intI = value; }
            }
        }
        public class PropertiesTestClass074 : PropertiesTestClass074_Base
        {
            new public int MyProp
            {
                set { intI = value + 1; }
            }
            public static bool testMethod()
            {
                PropertiesTestClass074 test = new PropertiesTestClass074();
                ((PropertiesTestClass074_Base)test).MyProp = 2;
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
        public class PropertiesTestClass075
        {
            int intI = 0;
            public virtual int MyProp
            {
                get { return intI; }
                set { intI = value; }
            }
            public static bool testMethod()
            {
                PropertiesTestClass075 test = new PropertiesTestClass075();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public abstract class PropertiesTestClass078_Sub
        {
            public int intI = 0;
            public abstract int MyProp
            {
                get;
                set;
            }
        }
        public class PropertiesTestClass078 : PropertiesTestClass078_Sub
        {
            public override int MyProp
            {
                get { return intI; }
                set { intI = value; }
            }
            public static bool testMethod()
            {
                PropertiesTestClass078_Sub test = new PropertiesTestClass078();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass089_Base
        {
            public int intI;
            public virtual int MyProp
            {
                set { intI = value; }
                get { return intI; }
            }
        }
        public class PropertiesTestClass089 : PropertiesTestClass089_Base
        {
            public override int MyProp
            {
                get { return intI + 1; }
            }
            public static bool testMethod()
            {
                PropertiesTestClass089_Base test = new PropertiesTestClass089();
                test.MyProp = 2;
                if (test.MyProp == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class PropertiesTestClass090_Base
        {
            public int intI;
            public virtual int MyProp
            {
                set { intI = value; }
                get { return intI; }
            }
        }
        public class PropertiesTestClass090 : PropertiesTestClass090_Base
        {
            public override int MyProp
            {
                set { intI = value - 1; }
            }
            public static bool testMethod()
            {
                PropertiesTestClass090_Base test = new PropertiesTestClass090();
                test.MyProp = 2;
                if (test.MyProp == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass097
        {
            int intI = 0;
            int MyProp
            {
                set
                {
                    intI = value;
                }
                get
                {
                    return intI;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass097 test = new PropertiesTestClass097();
                test.MyProp = 2;
                if (test.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass109_Base
        {
            public virtual int foo
            {
                get
                {
                    return 1;
                }
            }
        }
        class PropertiesTestClass109_Derived : PropertiesTestClass109_Base
        {
            private int get_foo()
            {
                return 1;
            }
        }
        class PropertiesTestClass109 : PropertiesTestClass109_Derived
        {
            public override int foo
            {
                get
                {
                    return 2;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass109_Base MB = new PropertiesTestClass109();
                if (MB.foo == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass110_Base
        {
            public int intI;
            public virtual int foo
            {
                set
                {
                    intI = 1;
                }
            }
        }
        class PropertiesTestClass110_Derived : PropertiesTestClass110_Base
        {
            private void set_foo(int value)
            {
                intI = 2;
            }
        }
        class PropertiesTestClass110 : PropertiesTestClass110_Derived
        {
            public override int foo
            {
                set
                {
                    intI = 3;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass110_Base MB = new PropertiesTestClass110();
                MB.foo = 3;
                if (MB.intI == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass121_Base
        {
            public virtual int MyProp
            {
                get
                {
                    return 1;
                }
            }
        }
        class PropertiesTestClass121 : PropertiesTestClass121_Base
        {
            public override int MyProp
            {
                get
                {
                    return 2;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass121_Base MC = new PropertiesTestClass121();
                if (MC.MyProp == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass122_Base
        {
            public int myInt;
            public virtual int MyProp
            {
                set
                {
                    myInt = 1;
                }
            }
        }
        class PropertiesTestClass122 : PropertiesTestClass122_Base
        {
            public override int MyProp
            {
                set
                {
                    myInt = 2;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass122_Base MC = new PropertiesTestClass122();
                MC.MyProp = 0;
                if (MC.myInt == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass123_Base
        {
            public virtual int MyProp
            {
                get
                {
                    return 1;
                }
            }
        }
        class PropertiesTestClass123 : PropertiesTestClass123_Base
        {
            public new int MyProp
            {
                get
                {
                    return 2;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass123_Base MC = new PropertiesTestClass123();
                if (MC.MyProp == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass124_Base
        {
            public int myInt;
            public virtual int MyProp
            {
                set
                {
                    myInt = 1;
                }
            }
        }
        class PropertiesTestClass124 : PropertiesTestClass124_Base
        {
            public new int MyProp
            {
                set
                {
                    myInt = 2;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass124_Base MC = new PropertiesTestClass124();
                MC.MyProp = 0;
                if (MC.myInt == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass125_Base
        {
            public int intI = 0;
            public virtual int MyProp
            {
                get
                {
                    return -1;
                }
                set
                {
                    intI = -1;
                }

            }
        }
        class PropertiesTestClass125 : PropertiesTestClass125_Base
        {
            public override int MyProp
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
            public static bool testMethod()
            {
                PropertiesTestClass125_Base MC = new PropertiesTestClass125();
                MC.MyProp = 4;
                if (MC.MyProp == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class PropertiesTestClass126_Base
        {
            public int intI = 0;
            public virtual int MyProp
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
        }
        class PropertiesTestClass126 : PropertiesTestClass126_Base
        {
            public new int MyProp
            {
                get
                {
                    return -1;
                }
                set
                {
                    intI = -1;
                }
            }
            public static bool testMethod()
            {
                PropertiesTestClass126_Base MC = new PropertiesTestClass126();
                MC.MyProp = 4;
                if (MC.MyProp == -1)
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
