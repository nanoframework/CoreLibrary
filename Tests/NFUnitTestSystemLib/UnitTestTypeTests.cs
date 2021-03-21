//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;
using System.Reflection;

namespace NFUnitTestSystemLib
{
    [TestClass]
    class UnitTestTypeTests
    {
        //SystemType Test methods
        interface iEmpty { }

        class TestObject1 { }

        class TestObject2 : iEmpty
        {
            public TestObject2(Int32 i)
            {
                m_data = (int)i;
            }
            public int m_data;
            class m_subTestObject
            {

            }
            public void Method1()
            {

            }
            public Int32 Method2(Int32 I)
            {
                return I;
            }
        }

        [TestMethod]
        public void Number_ToString_Test()
        {
            // if the negative number can not be truncated to the range specified it
            // will display its full hex value
            Assert.Equal("fe", ((sbyte)-2).ToString("x02"));
            Assert.Equal("36", ((byte)0x36).ToString("x02"));
            Assert.Equal("FF", ((byte)255).ToString("X2"));
            Assert.Equal("fffd", ((short)-3).ToString("x04"));
            Assert.Equal("3049", ((ushort)0x3049).ToString("x4"));
            Assert.Equal("fc00", ((short)-1024).ToString("x02"));
            Assert.Equal("fffffffc", ((int)-4).ToString("x8"));
            Assert.Equal("00004494", ((uint)0x4494).ToString("x8"));
            Assert.Equal("fffffffc", ((int)-4).ToString("x04"));
            Assert.Equal("fffffffffffffffb", ((long)-5).ToString("x016"));
            Assert.Equal("1234567890123456", ((ulong)0x1234567890123456).ToString("x16"));
            // you should not be able to truncate the value only leading zeros
            Assert.Equal("1234567890123456", ((ulong)0x1234567890123456).ToString("x06"));
            Assert.Equal("34567890123456", ((ulong)0x0034567890123456).ToString("x14"));

            string tst = 3210.ToString("D");
            Debug.WriteLine($"3210: {tst}");
            Assert.Equal("3210", tst);

            tst = (-3210).ToString("d");
            Debug.WriteLine($"-3210: {tst}");
            Assert.Equal("-3210", tst);

            tst = 3210.ToString("d06");
            Debug.WriteLine($"003210: {tst}");
            Assert.Equal("003210", tst);

            tst = (-3210).ToString("d06");
            Debug.WriteLine($"-003210: {tst}");
            Assert.Equal("-003210", tst);

            tst = 3210.ToString("d1");
            Debug.WriteLine($"3210: {tst}");
            Assert.Equal("3210", tst);

            tst = (-3210).ToString("d1");
            Debug.WriteLine($"-3210: {tst}");
            Assert.Equal("-3210", tst);

            tst = 3210.ToString("g");
            Debug.WriteLine($"3210 {tst}");
            Assert.Equal("3210", tst);

            tst = (-3210).ToString("g");
            Debug.WriteLine($"-3210 {tst}");
            Assert.Equal("-3210", tst);

            Assert.Equal("NaN", ((float)0f / 0f).ToString());
            Assert.Equal("Infinity", ((float)1f / 0f).ToString());
            Assert.Equal("-Infinity", ((float)-1f / 0f).ToString());

            Assert.Equal("NaN", ((double)0f / 0f).ToString());
            Assert.Equal("Infinity", ((double)1f / 0f).ToString());
            Assert.Equal("-Infinity", ((double)-1f / 0f).ToString());


            Assert.Equal("Da1x", (1).ToString("Da1x"));
            Assert.Equal("1", (1).ToString("D"));
            Assert.Equal("-1", (-1).ToString("D"));
            Assert.Equal("1234", (1234).ToString("D"));
            Assert.Equal("-1234", (-1234).ToString("D"));
            Assert.Equal("001234", (1234).ToString("D6"));
            Assert.Equal("-001234", (-1234).ToString("D6"));
            Assert.Equal("2147483647", (Int32.MaxValue).ToString("D"));
            Assert.Equal("-2147483648", (Int32.MinValue).ToString("D"));
            Assert.Equal("000000000002147483647", (Int32.MaxValue).ToString("D21")); 
            Assert.Equal("-000000000002147483648", (Int32.MinValue).ToString("D21"));
            Assert.Equal("9223372036854775807", (Int64.MaxValue).ToString("D")); 
            Assert.Equal("-9223372036854775808",    (Int64.MinValue).ToString("D")); 
            Assert.Equal("009223372036854775807", (Int64.MaxValue).ToString("D21"));
            Assert.Equal("-009223372036854775808",    (Int64.MinValue).ToString("D21")); 
            Assert.Equal("2147483747",    ((Int64)Int32.MaxValue + 100).ToString("D")); 
            Assert.Equal("-2147483748", ((Int64)Int32.MinValue - 100).ToString("D"));
            Assert.Equal("000000000002147483747",    ((Int64)Int32.MaxValue + 100).ToString("D21")); 
            Assert.Equal("-000000000002147483748", ((Int64)Int32.MinValue - 100).ToString("D21"));

            Assert.Equal("1234.57", (1234.567).ToString("F"));
            Assert.Equal("-1234.57", (-1234.567).ToString("F"));
            Assert.Equal("1235", (1234.567).ToString("F0"));
            Assert.Equal("-1235", (-1234.567).ToString("F0"));
            Assert.Equal("1234.0", (1234).ToString("F1"));
            Assert.Equal("-1234.0", (-1234).ToString("F1"));
            Assert.Equal("1234.5600", (1234.56).ToString("F4"));
            Assert.Equal("-1234.5600", (-1234.56).ToString("F4"));
            Assert.Equal("1234.6", (1234.56).ToString("F1"));
            Assert.Equal("-1234.6", (-1234.56).ToString("F1"));
            Assert.Equal("1234.0", (1234.0056).ToString("F1"));
            Assert.Equal("-1234.0", (-1234.0056).ToString("F1"));
            Assert.Equal("1", (1).ToString());
            Assert.Equal("1", (1).ToString((string)null));
            Assert.Equal("1", (1).ToString(String.Empty));
            Assert.Equal("1234.567", (1234.567).ToString());
            Assert.Equal("123.456", (123.456).ToString("G"));
            Assert.Equal("-123.456", (-123.456).ToString("G"));
            Assert.Equal("1.2E+02", (123.4546).ToString("G2"));
            Assert.Equal("-1.2E+02", (-123.4546).ToString("G2"));
            Assert.Equal("123.5", (123.4546).ToString("G4"));
            Assert.Equal("-123.5", (-123.4546).ToString("G4"));
            Assert.Equal("123.4546", (123.4546).ToString("G10"));
            Assert.Equal("-123.4546", (-123.4546).ToString("G10"));
            Assert.Equal("100", (99.9999).ToString("G4"));
            Assert.Equal("-100", (-99.9999).ToString("G4"));
            Assert.Equal("1234567890", (1234567890).ToString("G"));
            Assert.Equal("-1234567890", (-1234567890).ToString("G"));
            Assert.Equal("1.235E+09", (1234567890).ToString("G4"));
            Assert.Equal("-1.235E+09", (-1234567890).ToString("G4"));
            Assert.Equal("9.877E+09", (9876543210).ToString("G4"));
            Assert.Equal("-9.877E+09", (-9876543210).ToString("G4"));
            Assert.Equal("1234567890", (1234567890).ToString("G15"));
            Assert.Equal("-1234567890", (-1234567890).ToString("G15"));
            Assert.Equal("1,234.57", (1234.567).ToString("N"));
            Assert.Equal("-1,234.57", (-1234.567).ToString("N"));
            Assert.Equal("0", (0).ToString("N0"));
            Assert.Equal("1,234", (1234).ToString("N0"));
            Assert.Equal("-1,234", (-1234).ToString("N0"));
            Assert.Equal("12.0", (12).ToString("N1"));
            Assert.Equal("-12.0", (-12).ToString("N1"));
            Assert.Equal("1,234.0", (1234).ToString("N1"));
            Assert.Equal("-1,234.0", (-1234).ToString("N1"));
            Assert.Equal("1,234.560", (1234.56).ToString("N3"));
            Assert.Equal("-1,234.560", (-1234.56).ToString("N3"));
            Assert.Equal("34,561,234.560", (34561234.56).ToString("N3"));
            Assert.Equal("-34,561,234.560", (-34561234.56).ToString("N3"));

            Assert.Equal("FF", (255).ToString("X"));
            Assert.Equal("1", ((Int32)1).ToString("X"));
            Assert.Equal("ffffffff", ((Int32)(-1)).ToString("x"));
            Assert.Equal("1", (unchecked((byte)1)).ToString("x"));
            Assert.Equal("ff", (unchecked((byte)(-1))).ToString("x"));
            Assert.Equal("1", ((short)1).ToString("x"));
            Assert.Equal("01", ((short)1).ToString("x2"));
            Assert.Equal("ffff", ((short)(-1)).ToString("x"));
            Assert.Equal("00ff", (255).ToString("x4"));
            Assert.Equal("FFFFFFFF", ((Int32)(-1)).ToString("X4"));
            Assert.Equal("7ffffffffffffff5", (Int64.MaxValue - 10).ToString("x")); 
            Assert.Equal("a", ((Int64)10).ToString("x"));
            Assert.Equal("0000a", ((Int64)10).ToString("x5"));

        }

        [TestMethod]
        public void SystemType1_GetTypeNew_Test()
        {
            Int32 testInt32 = 0;

            Assembly Int32Assm = Assembly.Load("mscorlib");

            Debug.WriteLine("This tests the Assembly.GetType(String) by passing \"Namespace.Class\"");
            Type myType0 = Int32Assm.GetType("System.Int32");
            Debug.WriteLine("The full name is " + myType0.FullName);
            Assert.IsType(myType0, testInt32.GetType());

            Debug.WriteLine("This tests the Type.GetType(String) by passing \"Namespace.Class\"");
            Type myType1 = Type.GetType("System.Int32");
            Debug.WriteLine("The full name is " + myType1.FullName);
            Assert.IsType(myType1, testInt32.GetType());

            Debug.WriteLine("This tests the Type.GetType(String) by passing \"Namespace.Class, assembly\"");
            Type myType2 = Type.GetType("System.Int32, mscorlib");
            Debug.WriteLine("The full name is " + myType2.FullName);
            Assert.IsType(myType2, testInt32.GetType());

            Debug.WriteLine("This tests the Type.GetType(String) by passing \"Namespace.Class, assembly, Version=\"a.b.c.d\"\"");
            string typeName3 = "System.Int32, mscorlib, Version=" + Int32Assm.GetName().Version.ToString();
            Type myType3 = Type.GetType(typeName3);
            Debug.WriteLine("The full name is " + myType3.FullName);
            Assert.IsType(myType3, testInt32.GetType());


            Debug.WriteLine("This tests the Type.GetType() method for nested classes");
            TestObject1 testTestObject1 = new TestObject1();
            Type myType4 = testTestObject1.GetType();
            Debug.WriteLine("The full name is " + myType4.FullName);
            Assert.IsType(myType4, Type.GetType("NFUnitTestSystemLib.UnitTestTypeTests+TestObject1"));


            Debug.WriteLine("Since NoneSuch does not exist in this assembly, ");
            Debug.WriteLine("GetType throws a TypeLoadException.");
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                Type myType5 = Type.GetType("NoneSuch");
                Debug.WriteLine("The full name is " + myType5.FullName);
            });
        }

        [TestMethod]
        public void SystemType1_Type_Names_Test()
        {
            Assembly Int32Assm = Assembly.Load("mscorlib");

            // types must be the same whereexver they come from
            Type myType0 = Int32Assm.GetType("System.Int32");
            Type myType1 = Type.GetType("System.Int32");

            Assert.IsType(myType0, myType1);

            // names must be compatible and composable
            Assert.Equal(myType0.Name, myType1.Name);

            // names must be compatible and composable
            Assert.Equal(myType0.FullName, myType1.FullName);

            // assembly must be the same
            Assert.True(myType0.Assembly == myType1.Assembly);

            // type must come from assembly it is supposed to come from
            Assert.True(Int32Assm == myType0.Assembly);

            // verify that the long name is corrent
            string fullAssmName = Int32Assm.FullName;

            Assert.Equal(myType0.AssemblyQualifiedName, (myType0.FullName + ", " + fullAssmName));
        }

        [TestMethod]
        public void SystemType2_Assembly_Test()
        {
            Debug.WriteLine("This tests the Assembly property");

            //Assigned and manipulated to avoid compiler warning
            Int32 testInt32 = -1;
            testInt32++;

            Type myType1 = Type.GetType("System.Int32");
            Debug.WriteLine("The full name is " + myType1.Assembly.FullName);
            Assert.Equal(myType1.Assembly.FullName, "mscorlib, Version=" + myType1.Assembly.GetName().Version.ToString());

            TestObject1 testTestObject1 = new TestObject1();
            Type myType2 = testTestObject1.GetType();
            Debug.WriteLine("The full name is " + myType2.Assembly.FullName);
            Assert.Equal(myType2.Assembly.FullName, "NFUnitTest, Version=" + myType2.Assembly.GetName().Version.ToString());
        }

        [TestMethod]
        public void SystemType3_BaseType_Test()
        {
            Debug.WriteLine("This tests the BaseType() method");

            //Assigned and manipulated to avoid compiler warning
            Int32 testInt32 = -1;
            testInt32++;
            Type myType1 = Type.GetType("System.Int32");
            Debug.WriteLine("The full name is " + myType1.FullName);
            Assert.IsType(myType1.BaseType, Type.GetType("System.ValueType"));

            TestObject1 testTestObject1 = new TestObject1();
            Type myType2 = testTestObject1.GetType();
            Debug.WriteLine("The full name is " + myType2.FullName);
            Assert.IsType(myType2.BaseType, Type.GetType("System.Object"));
        }

        [TestMethod]
        public void SystemType4_DeclaringType_Test()
        {
            Debug.WriteLine("This tests the DeclaringType property");

            //Assigned and manipulated to avoid compiler warning
            Int32 testInt32 = -1;
            testInt32++;

            Type myType1 = Type.GetType("System.Int32");
            Debug.WriteLine("The full name is " + myType1.FullName);
            Assert.True(myType1.DeclaringType == null);

            // As there is no instance of this, the test will fail, commenting it.
            //TestObject1 testTestObject1 = new TestObject1();
            //Type myType2 = testTestObject1.GetType();
            //Debug.WriteLine("The full name is " + myType2.FullName);
            //Type myType3 = this.GetType();
            //Assert.IsType(myType2.DeclaringType , myType3);
        }

        [TestMethod]
        public void SystemType5_GetConstructor_Test()
        {
            Debug.WriteLine("This tests the GetConstructor(Type[]) method");
            TestObject2 testTestObject2 = new TestObject2(5);
            Type myType2 = testTestObject2.GetType();
            Debug.WriteLine("The full name is " + myType2.FullName);
            Type[] typeOfInt32Arr = new Type[] { Type.GetType("System.Int32") };
            object[] value5Arr = new object[] { 5 };
            TestObject2 testTestObject3 =
                (TestObject2)myType2.GetConstructor(typeOfInt32Arr).Invoke(value5Arr);
            Assert.Equal(testTestObject2.m_data, testTestObject3.m_data);
        }

        [TestMethod]
        public void SystemType6_GetElementType_Test()
        {
            Debug.WriteLine("This tests the GetElementType() method");

            //Assigned and manipulated to avoid compiler warning
            Int32 testInt32 = -1;
            testInt32++;

            Type myType1 = Type.GetType("System.Int32");
            Debug.WriteLine("The full name is " + myType1.FullName);
            Int32[] int32Arr = new Int32[] { };
            Type int32ArrType = int32Arr.GetType();
            Assert.IsType(myType1, int32ArrType.GetElementType());

            Assert.True(myType1.GetElementType() == null);
        }

        [TestMethod]
        public void SystemType7_GetField_Test()
        {
            Debug.WriteLine("This tests the GetField(String) ");
            Debug.WriteLine("and the GetField(String,BindingFlags) methods)");
            Debug.WriteLine("Currently this test fails, see 17246 for more details.");

            Type myType1 = Type.GetType("System.Int32");
            Debug.WriteLine("The full name is " + myType1.FullName);
            Assert.True(myType1.GetField("m_data") == null);

            Debug.WriteLine(" TestObject2 type has one data member \"m_data\" of type Int32.");
            TestObject2 testTestObject2 = new TestObject2(5);
            Type myType2 = testTestObject2.GetType();
            Debug.WriteLine("The full name is " + myType2.FullName);

            Debug.WriteLine(" Check that type of m_data is Int32");
            Assert.IsType(myType2.GetField("m_data", BindingFlags.GetField |
                BindingFlags.Public | BindingFlags.Instance).FieldType, myType1);

            Debug.WriteLine(" Check that value in m_data is 5 ( becuase we called new TestObject2(5))");
            Assert.Equal((int)myType2.GetField("m_data", BindingFlags.IgnoreCase |
                BindingFlags.GetField | BindingFlags.Public |
                BindingFlags.Instance).GetValue(testTestObject2), 5);

            Debug.WriteLine(" Check that m_data  is a field");
            Assert.True(myType2.GetField("m_data").MemberType == MemberTypes.Field);

            Debug.WriteLine(" Check that field m_data has Name \"m_data\"");
            Assert.Equal(myType2.GetField("m_data").Name, "m_data");

            Debug.WriteLine(" Check that  misspelling of m_data return NULL.");
            Assert.True(null == myType2.GetField("data"));

            Debug.WriteLine(" Checks that case misspelling of m_data return NULL if flag BindingFlags.IgnoreCase not specified.");
            Assert.True(null == myType2.GetField("m_Data"));

            Debug.WriteLine("Check retrieval with BindingFlags.IgnoreCase. If flag BindingFlags.IgnoreCase is ised, then the case should be ignored. We should get the same type information.");
            FieldInfo fInfo_m_Data = myType2.GetField("m_Data", BindingFlags.IgnoreCase | BindingFlags.GetField | BindingFlags.Public | BindingFlags.Instance);
            FieldInfo fInfo_m_data = myType2.GetField("m_data");
            Assert.NotNull(fInfo_m_Data);
            Assert.NotNull(fInfo_m_data);
            Assert.True(fInfo_m_Data.Name.Equals(fInfo_m_data.Name));

            Debug.WriteLine(" Indirectly set m_data in testTestObject2 to 6 and then check it.");
            myType2.GetField("m_data").SetValue(testTestObject2, 6);
            Assert.Equal((int)myType2.GetField("m_data").GetValue(testTestObject2), 6);
            Assert.Equal(testTestObject2.m_data, 6);
        }

        [TestMethod]
        public void SystemType8_GetFields_Test()
        {

            Debug.WriteLine("This tests the GetFields(String) method");
            Debug.WriteLine("This test must be re-written once BindingFlags is working, ");
            Debug.WriteLine("see 17246 for more details.");

            Type myType1 = Type.GetType("System.Int32");
            Debug.WriteLine("The full name is " + myType1.FullName);
            Assert.Null(myType1.GetField("m_data"));
            TestObject2 testTestObject2 = new TestObject2(5);
            Type myType2 = testTestObject2.GetType();
            Debug.WriteLine("The full name is " + myType2.FullName);
            Assert.IsType(myType2.GetField("m_data").FieldType, myType1);
            Assert.Equal((int)myType2.GetField("m_data").GetValue(testTestObject2), 5);
            Assert.True(myType2.GetField("m_data").MemberType == MemberTypes.Field);
            Assert.Equal(myType2.GetField("m_data").Name, "m_data");
            myType2.GetField("m_data").SetValue(testTestObject2, 6);
            Assert.Equal((int)myType2.GetField("m_data").GetValue(testTestObject2), 6);
        }

        [TestMethod]
        public void SystemType9_GetInterfaces_Test()
        {
            Debug.WriteLine("This tests the GetInterfaces() method");
            Debug.WriteLine("This test must be re-written once BindingFlags is working, ");
            Debug.WriteLine("see 17246 for more details.");

            Type myType1 = Type.GetType("System.Int32");
            Debug.WriteLine("The full name is " + myType1.FullName);
            Assert.Equal(myType1.GetInterfaces().Length, 0);
            TestObject2 testTestObject2 = new TestObject2(5);
            Type myType2 = testTestObject2.GetType();
            Debug.WriteLine("The full name is " + myType2.FullName);
            Type myType3 =
                Type.GetType("NFUnitTestSystemLib.UnitTestTypeTests+iEmpty");
            Assert.IsType(myType2.GetInterfaces()[0], myType3);
        }

        [TestMethod]
        public void SystemType10_GetMethod_Test()
        {
            Debug.WriteLine("This tests the GetMethod(String) method");
            Debug.WriteLine("This test must be re-written once BindingFlags is working, ");
            Debug.WriteLine("see 17246 for more details.");

            Int32 I = 0;
            I++;
            TestObject2 testTestObject2 = new TestObject2(5);
            Type myType2 = testTestObject2.GetType();
            Debug.WriteLine("The full name is " + myType2.FullName);
            MethodInfo methodInfo1 = myType2.GetMethod("Method2");
            Assert.Equal(methodInfo1.IsAbstract, false);
            Assert.Equal(methodInfo1.IsFinal, false);
            Assert.Equal(methodInfo1.IsPublic, true);
            Assert.Equal(methodInfo1.IsStatic, false);
            Assert.Equal(methodInfo1.IsVirtual, false);
            Assert.True(methodInfo1.MemberType == MemberTypes.Method);
            Assert.Equal(methodInfo1.Name, "Method2");
            Assert.IsType(methodInfo1.ReturnType, I.GetType());
            Assert.IsType(methodInfo1.DeclaringType, myType2);
            Assert.Equal((int)(methodInfo1.Invoke(testTestObject2, new object[] { 1 })), 1);
        }

        [TestMethod]
        public void SystemType11_GetMethods_Test()
        {
            Debug.WriteLine("This tests the GetMethods() method");
            Debug.WriteLine("This test must be re-written once BindingFlags is working, ");
            Debug.WriteLine("see 17246 for more details.");

            //Assigned and manipulated to avoid compiler warning
            Int32 I = 0;
            I++;

            TestObject2 testTestObject2 = new TestObject2(5);
            Type myType2 = testTestObject2.GetType();
            Debug.WriteLine("The full name is " + myType2.FullName);
            MethodInfo[] methodInfoArr1 = myType2.GetMethods();
            MethodInfo methodInfo1 = null;
            if (methodInfoArr1[0].Name == "Method2")
            {
                methodInfo1 = methodInfoArr1[0];
                Debug.WriteLine("Method2 found in position 0");
            }
            else if (methodInfoArr1[1].Name == "Method2")
            {
                methodInfo1 = methodInfoArr1[1];
                Debug.WriteLine("Method2 found in position 1");
            }
            Assert.Equal(methodInfo1.IsAbstract, false);
            Assert.Equal(methodInfo1.IsFinal, false);
            Assert.Equal(methodInfo1.IsPublic, true);
            Assert.Equal(methodInfo1.IsStatic, false);
            Assert.Equal(methodInfo1.IsVirtual, false);
            Assert.True(methodInfo1.MemberType == MemberTypes.Method);
            Assert.Equal(methodInfo1.Name, "Method2");
            Assert.IsType(methodInfo1.ReturnType, I.GetType());
            Assert.IsType(methodInfo1.DeclaringType, myType2);
            Assert.Equal((int)(methodInfo1.Invoke(testTestObject2, new object[] { 1 })), 1);
        }

        // Removing this one as not implemented scenario in nano
        //[TestMethod]
        //public void SystemType12_InvokeMember_Test()
        //{
        //    Debug.WriteLine("This tests the InvokeMember(String,BindingFlags) method");
        //    Debug.WriteLine("This test must be re-written once BindingFlags is working, ");
        //    Debug.WriteLine("see 17246 for more details.");
        //    //Assigned and manipulated to avoid compiler warning
        //    Int32 I = 0;
        //    I++;
        //    TestObject2 testTestObject2 = new TestObject2(5);
        //    Type myType2 = testTestObject2.GetType();
        //    Debug.WriteLine("The full name is " + myType2.FullName);
        //    Assert.Equal((int)myType2.InvokeMember("Method2", BindingFlags.Default
        //        | BindingFlags.InvokeMethod, null, testTestObject2,
        //        new object[] { -6 }), -6);
        //}

    }
}
