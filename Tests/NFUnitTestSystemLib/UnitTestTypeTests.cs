// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using nanoFramework.TestFramework;

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
            public TestObject2(int i)
            {
                m_data = i;
            }
            public int m_data;
            class m_subTestObject
            {

            }
            public void Method1()
            {

            }
            public int Method2(int I)
            {
                return I;
            }
        }

        [TestMethod]
        public void Number_ToString_Test()
        {
            // if the negative number can not be truncated to the range specified it
            // will display its full hex value
            Assert.AreEqual("fe", ((sbyte)-2).ToString("x02"));
            Assert.AreEqual("36", ((byte)0x36).ToString("x02"));
            Assert.AreEqual("FF", ((byte)255).ToString("X2"));
            Assert.AreEqual("fffd", ((short)-3).ToString("x04"));
            Assert.AreEqual("3049", ((ushort)0x3049).ToString("x4"));
            Assert.AreEqual("fc00", ((short)-1024).ToString("x02"));
            Assert.AreEqual("fffffffc", (-4).ToString("x8"));
            Assert.AreEqual("00004494", ((uint)0x4494).ToString("x8"));
            Assert.AreEqual("fffffffc", (-4).ToString("x04"));
            Assert.AreEqual("fffffffffffffffb", ((long)-5).ToString("x016"));
            Assert.AreEqual("1234567890123456", ((ulong)0x1234567890123456).ToString("x16"));
            // you should not be able to truncate the value only leading zeros
            Assert.AreEqual("1234567890123456", ((ulong)0x1234567890123456).ToString("x06"));
            Assert.AreEqual("34567890123456", ((ulong)0x0034567890123456).ToString("x14"));

            string tst = 3210.ToString("D");
            OutputHelper.WriteLine($"3210: {tst}");
            Assert.AreEqual("3210", tst);

            tst = (-3210).ToString("d");
            OutputHelper.WriteLine($"-3210: {tst}");
            Assert.AreEqual("-3210", tst);

            tst = 3210.ToString("d06");
            OutputHelper.WriteLine($"003210: {tst}");
            Assert.AreEqual("003210", tst);

            tst = (-3210).ToString("d06");
            OutputHelper.WriteLine($"-003210: {tst}");
            Assert.AreEqual("-003210", tst);

            tst = 3210.ToString("d1");
            OutputHelper.WriteLine($"3210: {tst}");
            Assert.AreEqual("3210", tst);

            tst = (-3210).ToString("d1");
            OutputHelper.WriteLine($"-3210: {tst}");
            Assert.AreEqual("-3210", tst);

            tst = 3210.ToString("g");
            OutputHelper.WriteLine($"3210 {tst}");
            Assert.AreEqual("3210", tst);

            tst = (-3210).ToString("g");
            OutputHelper.WriteLine($"-3210 {tst}");
            Assert.AreEqual("-3210", tst);

            Assert.AreEqual("NaN", float.NaN.ToString());
            Assert.AreEqual("Infinity", float.PositiveInfinity.ToString());
            Assert.AreEqual("-Infinity", float.NegativeInfinity.ToString(), "float negative infinity test");

            Assert.AreEqual("NaN", double.NaN.ToString());
            Assert.AreEqual("Infinity", double.PositiveInfinity.ToString());
            Assert.AreEqual("-Infinity", double.NegativeInfinity.ToString(), "double negative infinity");

            Assert.AreEqual("Da1x", (1).ToString("Da1x"));
            Assert.AreEqual("1", (1).ToString("D"));
            Assert.AreEqual("-1", (-1).ToString("D"));
            Assert.AreEqual("1234", (1234).ToString("D"));
            Assert.AreEqual("-1234", (-1234).ToString("D"));
            Assert.AreEqual("001234", (1234).ToString("D6"));
            Assert.AreEqual("-001234", (-1234).ToString("D6"));
            Assert.AreEqual("2147483647", (int.MaxValue).ToString("D"));
            Assert.AreEqual("-2147483648", (int.MinValue).ToString("D"));
            Assert.AreEqual("000000000002147483647", (int.MaxValue).ToString("D21"));
            Assert.AreEqual("-000000000002147483648", (int.MinValue).ToString("D21"));
            Assert.AreEqual("9223372036854775807", (long.MaxValue).ToString("D"));
            Assert.AreEqual("-9223372036854775808", (long.MinValue).ToString("D"));
            Assert.AreEqual("009223372036854775807", (long.MaxValue).ToString("D21"));
            Assert.AreEqual("-009223372036854775808", (long.MinValue).ToString("D21"));
            Assert.AreEqual("2147483747", ((long)int.MaxValue + 100).ToString("D"));
            Assert.AreEqual("-2147483748", ((long)int.MinValue - 100).ToString("D"));
            Assert.AreEqual("000000000002147483747", ((long)int.MaxValue + 100).ToString("D21"));
            Assert.AreEqual("-000000000002147483748", ((long)int.MinValue - 100).ToString("D21"));

            Assert.AreEqual("1234.57", (1234.567).ToString("F"));
            Assert.AreEqual("-1234.57", (-1234.567).ToString("F"));
            Assert.AreEqual("1235", (1234.567).ToString("F0"));
            Assert.AreEqual("-1235", (-1234.567).ToString("F0"));
            Assert.AreEqual("1234.0", (1234).ToString("F1"));
            Assert.AreEqual("-1234.0", (-1234).ToString("F1"));
            Assert.AreEqual("1234.5600", (1234.56).ToString("F4"));
            Assert.AreEqual("-1234.5600", (-1234.56).ToString("F4"));
            Assert.AreEqual("1234.6", (1234.56).ToString("F1"));
            Assert.AreEqual("-1234.6", (-1234.56).ToString("F1"));
            Assert.AreEqual("1234.0", (1234.0056).ToString("F1"));
            Assert.AreEqual("-1234.0", (-1234.0056).ToString("F1"));
            Assert.AreEqual("1", (1).ToString());
            Assert.AreEqual("1", (1).ToString(null));
            Assert.AreEqual("1", (1).ToString(string.Empty));
            Assert.AreEqual("1234.567", (1234.567).ToString());
            Assert.AreEqual("123.456", (123.456).ToString("G"), "123.456 (G)");
            Assert.AreEqual("-123.456", (-123.456).ToString("G"));
            Assert.AreEqual("1.2E+02", (123.4546).ToString("G2"), "1.2E+02 (G2)");
            Assert.AreEqual("-1.2E+02", (-123.4546).ToString("G2"));
            Assert.AreEqual("123.5", (123.4546).ToString("G4"));
            Assert.AreEqual("-123.5", (-123.4546).ToString("G4"));
            Assert.AreEqual("123.4546", (123.4546).ToString("G10"));
            Assert.AreEqual("-123.4546", (-123.4546).ToString("G10"));
            Assert.AreEqual("100", (99.9999).ToString("G4"));
            Assert.AreEqual("-100", (-99.9999).ToString("G4"));
            Assert.AreEqual("1234567890", (1234567890).ToString("G"));
            Assert.AreEqual("-1234567890", (-1234567890).ToString("G"));
            Assert.AreEqual("1.235E+09", (1234567890).ToString("G4"));
            Assert.AreEqual("-1.235E+09", (-1234567890).ToString("G4"));
            Assert.AreEqual("9.877E+09", (9876543210).ToString("G4"));
            Assert.AreEqual("-9.877E+09", (-9876543210).ToString("G4"));
            Assert.AreEqual("1234567890", (1234567890).ToString("G15"));
            Assert.AreEqual("-1234567890", (-1234567890).ToString("G15"));
            Assert.AreEqual("1,234.57", (1234.567).ToString("N"));
            Assert.AreEqual("-1,234.57", (-1234.567).ToString("N"));
            Assert.AreEqual("0", (0).ToString("N0"));
            Assert.AreEqual("1,234", (1234).ToString("N0"));
            Assert.AreEqual("-1,234", (-1234).ToString("N0"));
            Assert.AreEqual("12.0", (12).ToString("N1"));
            Assert.AreEqual("-12.0", (-12).ToString("N1"));
            Assert.AreEqual("1,234.0", (1234).ToString("N1"));
            Assert.AreEqual("-1,234.0", (-1234).ToString("N1"));
            Assert.AreEqual("1,234.560", (1234.56).ToString("N3"));
            Assert.AreEqual("-1,234.560", (-1234.56).ToString("N3"));
            Assert.AreEqual("34,561,234.560", (34561234.56).ToString("N3"));
            Assert.AreEqual("-34,561,234.560", (-34561234.56).ToString("N3"));

            Assert.AreEqual("FF", (255).ToString("X"));
            Assert.AreEqual("1", 1.ToString("X"));
            Assert.AreEqual("ffffffff", (-1).ToString("x"));
            Assert.AreEqual("1", (unchecked((byte)1)).ToString("x"));
            Assert.AreEqual("ff", (unchecked((byte)(-1))).ToString("x"));
            Assert.AreEqual("1", ((short)1).ToString("x"));
            Assert.AreEqual("01", ((short)1).ToString("x2"));
            Assert.AreEqual("ffff", ((short)(-1)).ToString("x"));
            Assert.AreEqual("00ff", (255).ToString("x4"));
            Assert.AreEqual("FFFFFFFF", (-1).ToString("X4"));
            Assert.AreEqual("7ffffffffffffff5", (long.MaxValue - 10).ToString("x"));
            Assert.AreEqual("a", ((long)10).ToString("x"));
            Assert.AreEqual("0000a", ((long)10).ToString("x5"));

        }

        [TestMethod]
        public void SystemType1_GetTypeNew_Test()
        {
            int testInt32 = 0;

            Assembly Int32Assm = Assembly.Load("mscorlib");

            // This tests the Assembly.GetType(String) by passing \"Namespace.Class\"
            Type myType0 = Int32Assm.GetType("System.Int32");
            OutputHelper.WriteLine("The full name is " + myType0.FullName);
            Assert.IsInstanceOfType(myType0, testInt32.GetType());

            // This tests the Type.GetType(String) by passing \"Namespace.Class\"
            Type myType1 = Type.GetType("System.Int32");
            OutputHelper.WriteLine("The full name is " + myType1.FullName);
            Assert.IsInstanceOfType(myType1, testInt32.GetType());

            // This tests the Type.GetType(String) by passing \"Namespace.Class, assembly\"
            Type myType2 = Type.GetType("System.Int32, mscorlib");
            OutputHelper.WriteLine("The full name is " + myType2.FullName);
            Assert.IsInstanceOfType(myType2, testInt32.GetType());

            // This tests the Type.GetType(String) by passing \"Namespace.Class, assembly, Version=\"a.b.c.d\"\"
            string typeName3 = "System.Int32, mscorlib, Version=" + Int32Assm.GetName().Version.ToString();
            Type myType3 = Type.GetType(typeName3);
            OutputHelper.WriteLine("The full name is " + myType3.FullName);
            Assert.IsInstanceOfType(myType3, testInt32.GetType());


            // This tests the Type.GetType() method for nested classes
            TestObject1 testTestObject1 = new TestObject1();
            Type myType4 = testTestObject1.GetType();
            OutputHelper.WriteLine("The full name is " + myType4.FullName);
            Assert.IsInstanceOfType(myType4, Type.GetType("NFUnitTestSystemLib.UnitTestTypeTests+TestObject1"));


            // Since NoneSuch does not exist in this assembly, 
            // GetType throws a TypeLoadException.
            Assert.ThrowsException(typeof(NullReferenceException), () =>
            {
                Type myType5 = Type.GetType("NoneSuch");
                OutputHelper.WriteLine("The full name is " + myType5.FullName);
            });
        }

        [TestMethod]
        public void SystemType1_Type_Names_Test()
        {
            Assembly Int32Assm = Assembly.Load("mscorlib");

            // types must be the same whereexver they come from
            Type myType0 = Int32Assm.GetType("System.Int32");
            Type myType1 = Type.GetType("System.Int32");

            Assert.IsInstanceOfType(myType0, myType1);

            // names must be compatible and composable
            Assert.AreEqual(myType0.Name, myType1.Name);

            // names must be compatible and composable
            Assert.AreEqual(myType0.FullName, myType1.FullName);

            // assembly must be the same
            Assert.IsTrue(myType0.Assembly == myType1.Assembly);

            // type must come from assembly it is supposed to come from
            Assert.IsTrue(Int32Assm == myType0.Assembly);

            // verify that the long name is corrent
            string fullAssmName = Int32Assm.FullName;

            Assert.AreEqual(myType0.AssemblyQualifiedName, (myType0.FullName + ", " + fullAssmName));
        }

        [TestMethod]
        public void SystemType2_Assembly_Test()
        {
            // This tests the Assembly property

            //Assigned and manipulated to avoid compiler warning
            int testInt32 = -1;
            testInt32++;

            Type myType1 = Type.GetType("System.Int32");
            OutputHelper.WriteLine("The full name is " + myType1.Assembly.FullName);
            Assert.AreEqual(myType1.Assembly.FullName, "mscorlib, Version=" + myType1.Assembly.GetName().Version.ToString());

            TestObject1 testTestObject1 = new TestObject1();
            Type myType2 = testTestObject1.GetType();
            OutputHelper.WriteLine("The full name is " + myType2.Assembly.FullName);
            Assert.AreEqual(myType2.Assembly.FullName, "NFUnitTest, Version=" + myType2.Assembly.GetName().Version.ToString());
        }

        [TestMethod]
        public void SystemType3_BaseType_Test()
        {
            // This tests the BaseType() method

            //Assigned and manipulated to avoid compiler warning
            int testInt32 = -1;
            testInt32++;
            Type myType1 = Type.GetType("System.Int32");
            OutputHelper.WriteLine("The full name is " + myType1.FullName);
            Assert.IsInstanceOfType(myType1.BaseType, Type.GetType("System.ValueType"));

            TestObject1 testTestObject1 = new TestObject1();
            Type myType2 = testTestObject1.GetType();
            OutputHelper.WriteLine("The full name is " + myType2.FullName);
            Assert.IsInstanceOfType(myType2.BaseType, Type.GetType("System.Object"));
        }

        [TestMethod]
        public void SystemType4_DeclaringType_Test()
        {
            // This tests the DeclaringType property

            //Assigned and manipulated to avoid compiler warning
            int testInt32 = -1;
            testInt32++;

            Type myType1 = Type.GetType("System.Int32");
            OutputHelper.WriteLine("The full name is " + myType1.FullName);
            Assert.IsTrue(myType1.DeclaringType == null);

            // As there is no instance of this, the test will fail, commenting it.
            //TestObject1 testTestObject1 = new TestObject1();
            //Type myType2 = testTestObject1.GetType();
            //OutputHelper.WriteLine("The full name is " + myType2.FullName);
            //Type myType3 = this.GetType();
            //Assert.IsInstanceOfType(myType2.DeclaringType , myType3);
        }

        [TestMethod]
        public void SystemType5_GetConstructor_Test()
        {
            // This tests the GetConstructor(Type[]) method
            TestObject2 testTestObject2 = new TestObject2(5);
            Type myType2 = testTestObject2.GetType();
            OutputHelper.WriteLine("The full name is " + myType2.FullName);
            Type[] typeOfInt32Arr = new Type[] { Type.GetType("System.Int32") };
            object[] value5Arr = new object[] { 5 };
            TestObject2 testTestObject3 =
                (TestObject2)myType2.GetConstructor(typeOfInt32Arr).Invoke(value5Arr);
            Assert.AreEqual(testTestObject2.m_data, testTestObject3.m_data);
        }

        [TestMethod]
        public void SystemType6_GetElementType_Test()
        {
            // This tests the GetElementType() method

            //Assigned and manipulated to avoid compiler warning
            int testInt32 = -1;
            testInt32++;

            Type myType1 = Type.GetType("System.Int32");
            OutputHelper.WriteLine("The full name is " + myType1.FullName);
            int[] int32Arr = new int[] { };
            Type int32ArrType = int32Arr.GetType();
            Assert.IsInstanceOfType(myType1, int32ArrType.GetElementType());

            Assert.IsTrue(myType1.GetElementType() == null);
        }

        [TestMethod]
        public void SystemType7_GetField_Test()
        {
            // This tests the GetField(String) 
            // and the GetField(String,BindingFlags) methods)
            // Currently this test fails, see 17246 for more details.

            Type myType1 = Type.GetType("System.Int32");
            OutputHelper.WriteLine("The full name is " + myType1.FullName);
            Assert.IsTrue(myType1.GetField("m_data") == null);

            //  TestObject2 type has one data member \"m_data\" of type Int32.
            TestObject2 testTestObject2 = new TestObject2(5);
            Type myType2 = testTestObject2.GetType();
            OutputHelper.WriteLine("The full name is " + myType2.FullName);

            //  Check that type of m_data is Int32
            Assert.IsInstanceOfType(myType2.GetField("m_data", BindingFlags.GetField |
                BindingFlags.Public | BindingFlags.Instance).FieldType, myType1);

            //  Check that value in m_data is 5 ( becuase we called new TestObject2(5))
            Assert.AreEqual((int)myType2.GetField("m_data", BindingFlags.IgnoreCase |
                BindingFlags.GetField | BindingFlags.Public |
                BindingFlags.Instance).GetValue(testTestObject2), 5);

            //  Check that m_data  is a field
            Assert.IsTrue(myType2.GetField("m_data").MemberType == MemberTypes.Field);

            //  Check that field m_data has Name \"m_data\"
            Assert.AreEqual(myType2.GetField("m_data").Name, "m_data");

            //  Check that  misspelling of m_data return NULL.
            Assert.IsTrue(null == myType2.GetField("data"));

            //  Checks that case misspelling of m_data return NULL if flag BindingFlags.IgnoreCase not specified.
            Assert.IsTrue(null == myType2.GetField("m_Data"));

            // Check retrieval with BindingFlags.IgnoreCase. If flag BindingFlags.IgnoreCase is ised, then the case should be ignored. We should get the same type information.
            FieldInfo fInfo_m_Data = myType2.GetField("m_Data", BindingFlags.IgnoreCase | BindingFlags.GetField | BindingFlags.Public | BindingFlags.Instance);
            FieldInfo fInfo_m_data = myType2.GetField("m_data");
            Assert.IsNotNull(fInfo_m_Data);
            Assert.IsNotNull(fInfo_m_data);
            Assert.IsTrue(fInfo_m_Data.Name.Equals(fInfo_m_data.Name));

            //  Indirectly set m_data in testTestObject2 to 6 and then check it.
            myType2.GetField("m_data").SetValue(testTestObject2, 6);
            Assert.AreEqual((int)myType2.GetField("m_data").GetValue(testTestObject2), 6);
            Assert.AreEqual(testTestObject2.m_data, 6);
        }

        [TestMethod]
        public void SystemType8_GetFields_Test()
        {

            // This tests the GetFields(String) method
            // This test must be re-written once BindingFlags is working, 
            // see 17246 for more details.

            Type myType1 = Type.GetType("System.Int32");
            OutputHelper.WriteLine("The full name is " + myType1.FullName);
            Assert.IsNull(myType1.GetField("m_data"));
            TestObject2 testTestObject2 = new TestObject2(5);
            Type myType2 = testTestObject2.GetType();
            OutputHelper.WriteLine("The full name is " + myType2.FullName);
            Assert.IsInstanceOfType(myType2.GetField("m_data").FieldType, myType1);
            Assert.AreEqual((int)myType2.GetField("m_data").GetValue(testTestObject2), 5);
            Assert.IsTrue(myType2.GetField("m_data").MemberType == MemberTypes.Field);
            Assert.AreEqual(myType2.GetField("m_data").Name, "m_data");
            myType2.GetField("m_data").SetValue(testTestObject2, 6);
            Assert.AreEqual((int)myType2.GetField("m_data").GetValue(testTestObject2), 6);
        }

        [TestMethod]
        public void SystemType9_GetInterfaces_Test()
        {
            // This tests the GetInterfaces() method
            // This test must be re-written once BindingFlags is working, 
            // see 17246 for more details.

            Type myType1 = Type.GetType("System.Int32");
            OutputHelper.WriteLine("The full name is " + myType1.FullName);
            Assert.AreEqual(myType1.GetInterfaces().Length, 0);
            TestObject2 testTestObject2 = new TestObject2(5);
            Type myType2 = testTestObject2.GetType();
            OutputHelper.WriteLine("The full name is " + myType2.FullName);
            Type myType3 =
                Type.GetType("NFUnitTestSystemLib.UnitTestTypeTests+iEmpty");
            Assert.IsInstanceOfType(myType2.GetInterfaces()[0], myType3);
        }

        [TestMethod]
        public void SystemType10_GetMethod_Test()
        {
            // This tests the GetMethod(String) method
            // This test must be re-written once BindingFlags is working, 
            // see 17246 for more details.

            int I = 0;
            I++;
            TestObject2 testTestObject2 = new TestObject2(5);
            Type myType2 = testTestObject2.GetType();
            OutputHelper.WriteLine("The full name is " + myType2.FullName);
            MethodInfo methodInfo1 = myType2.GetMethod("Method2");
            Assert.AreEqual(methodInfo1.IsAbstract, false);
            Assert.AreEqual(methodInfo1.IsFinal, false);
            Assert.AreEqual(methodInfo1.IsPublic, true);
            Assert.AreEqual(methodInfo1.IsStatic, false);
            Assert.AreEqual(methodInfo1.IsVirtual, false);
            Assert.IsTrue(methodInfo1.MemberType == MemberTypes.Method);
            Assert.AreEqual(methodInfo1.Name, "Method2");
            Assert.IsInstanceOfType(methodInfo1.ReturnType, I.GetType());
            Assert.IsInstanceOfType(methodInfo1.DeclaringType, myType2);
            Assert.AreEqual((int)(methodInfo1.Invoke(testTestObject2, new object[] { 1 })), 1);
        }

        [TestMethod]
        public void SystemType11_GetMethods_Test()
        {
            // This tests the GetMethods() method
            // This test must be re-written once BindingFlags is working, 
            // see 17246 for more details.

            //Assigned and manipulated to avoid compiler warning
            int I = 0;
            I++;

            TestObject2 testTestObject2 = new TestObject2(5);
            Type myType2 = testTestObject2.GetType();
            OutputHelper.WriteLine("The full name is " + myType2.FullName);
            MethodInfo[] methodInfoArr1 = myType2.GetMethods();
            MethodInfo methodInfo1 = null;
            if (methodInfoArr1[0].Name == "Method2")
            {
                methodInfo1 = methodInfoArr1[0];
                // Method2 found in position 0
            }
            else if (methodInfoArr1[1].Name == "Method2")
            {
                methodInfo1 = methodInfoArr1[1];
                // Method2 found in position 1
            }
            Assert.AreEqual(methodInfo1.IsAbstract, false);
            Assert.AreEqual(methodInfo1.IsFinal, false);
            Assert.AreEqual(methodInfo1.IsPublic, true);
            Assert.AreEqual(methodInfo1.IsStatic, false);
            Assert.AreEqual(methodInfo1.IsVirtual, false);
            Assert.IsTrue(methodInfo1.MemberType == MemberTypes.Method);
            Assert.AreEqual(methodInfo1.Name, "Method2");
            Assert.IsInstanceOfType(methodInfo1.ReturnType, I.GetType());
            Assert.IsInstanceOfType(methodInfo1.DeclaringType, myType2);
            Assert.AreEqual((int)(methodInfo1.Invoke(testTestObject2, new object[] { 1 })), 1);
        }

        // Removing this one as not implemented scenario in nano
        //[TestMethod]
        //public void SystemType12_InvokeMember_Test()
        //{
        //    // This tests the InvokeMember(String,BindingFlags) method
        //    // This test must be re-written once BindingFlags is working, 
        //    // see 17246 for more details.
        //    //Assigned and manipulated to avoid compiler warning
        //    Int32 I = 0;
        //    I++;
        //    TestObject2 testTestObject2 = new TestObject2(5);
        //    Type myType2 = testTestObject2.GetType();
        //    OutputHelper.WriteLine("The full name is " + myType2.FullName);
        //    Assert.AreEqual((int)myType2.InvokeMember("Method2", BindingFlags.Default
        //        | BindingFlags.InvokeMethod, null, testTestObject2,
        //        new object[] { -6 }), -6);
        //}

    }
}
