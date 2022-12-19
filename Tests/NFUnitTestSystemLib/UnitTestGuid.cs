//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Collections;
using System.Diagnostics;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestGuid
    {
        [TestMethod]
        public void Guid_Test()
        {
            /// <summary>
            /// 1. Creates a Guid with Guid.NewGuid()  
            /// 2. Verifies the Guid is with Byte Array length 16
            /// 3. Creates same Guid 
            /// 4. Verifies the two Guids are equal with CompareTo
            /// 5. Verifies the two Guids are equal with Equals
            /// 6. Creates another Guid with Guid.NewGuid()
            /// 7. Verifies the new Guid is not equal to the previous Guid with CompareTo
            /// 8. Verifies the new Guid is not equal to the previous Guid with Equal
            /// </summary>
            ///
            Guid theGuid = Guid.NewGuid();

            byte[] bGuid1 = theGuid.ToByteArray();
            Assert.AreEqual(bGuid1.Length, 16);
            Guid theSameGuid = new Guid(bGuid1);
            // must be the same
            Assert.AreEqual(theGuid.CompareTo(theSameGuid), 0);
            Assert.IsTrue(theGuid.Equals(theSameGuid));
            Guid anotherGuid = Guid.NewGuid();

            // must be the different
            Assert.AreNotEqual(theGuid.CompareTo(anotherGuid), 0);
            Assert.IsFalse(theGuid.Equals(anotherGuid));
        }

        /// <summary>
        /// A utility to a generate random byte array of specified length.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static byte[] GetRandomBytes(int length)
        {
            byte[] byteArr = new byte[length];
            Random s_random = new Random();
            s_random.NextBytes(byteArr);
            return byteArr;
        }

        [TestMethod]
        public void ByteArrayConstructor_Test2()
        {
            /// <summary>
            /// 1. Creates a Guid with byte Array of size 16 and random byte values
            /// 2. Verifies exception is not thrown
            /// </summary>
            ///

            Byte[] guid16 = GetRandomBytes(16);
            Guid myGuid1 = new Guid(guid16);
        }

        [TestMethod]
        public void ArgumentException_Test3()
        {
            /// <summary>
            /// 1. Creates a Guid with byte Array of random size b/n 0 to 100 but not 16 
            /// 2. Verifies ArgumentException is thrown
            /// </summary>
            ///

            int size = 16;

            //size could be set to any Random number b/n 0 and 2147483647
            //System.OutOfMemoryException will be thrown
            Random random = new Random();
            while (size == 16)
            {
                size = random.Next(100);
            }
            Byte[] guidNot16 = GetRandomBytes(size);
            Assert.ThrowsException(typeof(ArgumentException), () => { Guid myGuid1 = new Guid(guidNot16); });
        }

        [TestMethod]
        public void ArgumentNullException_Test4()
        {
            /// <summary>
            /// 1. Creates a Guid with byte Array of null  
            /// 2. Verifies ArgumentNullException is thrown
            /// </summary>
            ///

            Byte[] nullByte = null;
            Assert.ThrowsException(typeof(ArgumentNullException), () => { Guid myGuid1 = new Guid(nullByte); });
        }

        public static Guid GetGuid()
        {
            return new Guid(0x4dff36b5, 0x9dde, 0x4f76, 0x9a, 0x2a, 0x96, 0x43, 0x50, 0x47, 0x06, 0x3d);
        }

        // This can't be run as there is no GetTypesImplementingInterface
        //[TestMethod]
        //public void Reflection_Unboxing_Test5()
        //{
        //    /// <summary>
        //    /// 1. Creates a Guid using a method
        //    /// 2. Invokes the method using Reflection
        //    /// 3. Casts the returned obj from the method back to Guid
        //    /// 4. Verifies Exception is not thrown when castin a Guid obj back to Guid
        //    /// </summary>
        //    ///

        //    Guid[] a = new Guid[] { GetGuid(), GetGuid(), GetGuid() };

        //    IList list = (IList)a;

        //    Guid g = (Guid)list[1];

        //    OutputHelper.WriteLine(g.ToString());
        //    Type t = Type.GetType("Microsoft.SPOT.Platform.Tests.ITest");

        //    Type[] apps = System.Reflection.GetTypesImplementingInterface(t);

        //    foreach (Type app in apps)
        //    {
        //        MethodInfo method = app.GetMethod("GetGuid", BindingFlags.Static | BindingFlags.Public);
        //        if (method != null)
        //        {
        //            object o = method.Invoke(null, null);
        //            try
        //            {
        //                Guid guid = (Guid)o;
        //            }
        //            catch (Exception ex)
        //            {
        //                OutputHelper.WriteLine("Caught : " + ex.Message);
        //                testResult = MFTestResults.Fail;
        //            }
        //        }
        //    }
        //    return testResult;
        //}

        [TestMethod]
        public void Int_Short_Constructor_Test6()
        {
            /// <summary>
            /// 1. Creates Guid(int, short, short, byte, byte ...) 
            /// 2. Verifies exception is not thrown 
            /// </summary>
            ///

            Random random = new Random();
            int _int = random.Next(Int32.MaxValue);
            short _short1 = (short)random.Next(32768);
            short _short2 = (short)random.Next(32768);
            Byte[] _bArr = GetRandomBytes(8);
            Guid _guid = new Guid(_int, _short1, _short2, _bArr[0], _bArr[1], _bArr[2], _bArr[3], _bArr[4], _bArr[5], _bArr[6], _bArr[7]);
        }

        [TestMethod]
        public void UInt_Ushort_Constructor_Test7()
        {
            /// <summary>
            /// 1. Creates a Guid(uint, ushort, byte, byte ...)
            /// 2. Verifies exception is not thrown 
            /// </summary>
            ///

            Random random = new Random();
            int randoInt = random.Next(Int32.MaxValue);
            uint _uInt = (uint)(randoInt * 2);
            ushort _uShort1 = (ushort)random.Next(65536);
            ushort _uShort2 = (ushort)random.Next(65536);
            Byte[] _bArr = GetRandomBytes(8);
            Guid _guid = new Guid(_uInt, _uShort1, _uShort1, _bArr[0], _bArr[1], _bArr[2], _bArr[3], _bArr[4], _bArr[5], _bArr[6], _bArr[7]);
        }

        [TestMethod]
        public void Guid_Empty_Test8()
        {
            /// <summary>
            /// 1. Creates an Empty Guid with Guid.Empty
            /// 2. Extracts all the bytes in the Guid
            /// 3. Verifies all bytes have zero (0) value
            /// </summary>
            ///
            Guid guid = Guid.Empty;
            Byte[] _bArr = guid.ToByteArray();
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(_bArr[i], (byte)0);
            }
        }

        [TestMethod]
        public void Guid_CompareTo_Test9()
        {
            /// <summary>
            /// 1. Creates Guids with different values 
            /// 2. Verifies their equality using CompareTo
            /// </summary>
            ///

            Guid guid1 = Guid.Empty;
            OutputHelper.WriteLine("Verifing any instance of Guid, regardless of its value, is greater than null");
            Assert.AreEqual(guid1.CompareTo(null), 1);
            Byte[] _bArr = new Byte[16];
            OutputHelper.WriteLine("Creating a Guid with all bytes zero");
            Guid guid2 = new Guid(_bArr);
            Assert.AreEqual(guid1.CompareTo(guid2), 0);
            Guid guid3 = new Guid(0x4dff36b5, 0x9dde, 0x4f76, 0x9a, 0x2a, 0x96, 0x43, 0x50, 0x47, 0x06, 0x3d);
            if (guid3.CompareTo(guid1) <= 0)
            {
                throw new Exception("Expected : " + guid3.ToString() + " is greater than " + guid1.ToString());
            }
            Guid guid4 = new Guid(0x4dff36b5, 0x9dde, 0x4f76, 0x9a, 0x2a, 0x96, 0x43, 0x50, 0x47, 0x06, 0x3d);
            Assert.AreEqual(guid4.CompareTo(guid3), 0);
            Guid guid5 = new Guid(0x4dff36b5, 0x9dde, 0x4f76, 0x9a, 0x2a, 0x96, 0x43, 0x50, 0x47, 0x06, 0x3e);
            if (guid5.CompareTo(guid4) <= 0)
            {
                throw new Exception("Expected : " + guid5.ToString() + " is greater than " + guid4.ToString());
            }
            if (guid4.CompareTo(guid5) >= 0)
            {
                throw new Exception("Expected : " + guid4.ToString() + " is less than " + guid5.ToString());
            }
        }

        [TestMethod]
        public void Guid_ToString_Test10()
        {
            /// <summary>
            /// 1. Creates 4 Guids and Converts them ToString 
            /// 2. Verifies the Conversion of Guids to string is correct
            /// </summary>
            ///

            String[] strArr1 = new String[] { "00000000-0000-0000-0000-000000000000",
                "00000000-0000-0000-0000-000000000000",
                "4dff36b5-9dde-4f76-9a2a-96435047063d",
                "ffffffff-ffff-ffff-ffff-ffffffffffff"};
            Guid guid1 = Guid.Empty;
            Byte[] _byteArr1 = new Byte[16];
            Guid guid2 = new Guid(_byteArr1);
            Guid guid3 = new Guid(0x4dff36b5, 0x9dde, 0x4f76, 0x9a, 0x2a, 0x96, 0x43, 0x50, 0x47, 0x06, 0x3d);
            Byte[] _byteArr2 = new Byte[16];
            for (int i = 0; i < _byteArr2.Length; i++)
            {
                _byteArr2[i] = Byte.MaxValue;
            }
            Guid guid4 = new Guid(_byteArr2);
            String[] strArr2 = new String[] { guid1.ToString(), guid2.ToString(), guid3.ToString(), guid4.ToString() };
            for (int i = 0; i < strArr1.Length; i++)
            {
                OutputHelper.WriteLine(strArr1[i]);
                Assert.AreEqual(String.Compare(strArr1[i], strArr2[i]), 0);
            }
        }

        [TestMethod]
        public void Guid_Equals_Test11()
        {
            /// <summary>
            /// 1. Creates 3 Arrays of Guids with different constructors same value 
            /// 2. Verifies the Guids are equal
            /// </summary>
            ///

            OutputHelper.WriteLine("Creating 3 Guids with Guid.Empty and hex values");
            Guid guid11 = Guid.Empty;
            Guid guid12 = new Guid(0x4dff36b5, 0x9dde, 0x4f76, 0x9a, 0x2a, 0x96, 0x43, 0x50, 0x47, 0x06, 0x3d);
            Guid guid13 = new Guid(0x7FFFFFFF, 0x7FFF, 0x7FFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF);
            Guid[] gArr1 = new Guid[] { guid11, guid12, guid13 };

            OutputHelper.WriteLine("Creating Guids with 16 bytes constructor");
            Byte[] _bArr1 = new Byte[16];
            Guid guid21 = new Guid(_bArr1);
            Byte[] _bArr2 = new Byte[] { 181, 54, 255, 77, 222, 157, 118, 79, 154, 42, 150, 67, 80, 71, 6, 61 };
            Guid guid22 = new Guid(_bArr2);
            Byte[] _bArr3 = new Byte[] { 255, 255, 255, 127, 255, 127, 255, 127, 255, 255, 255, 255, 255, 255, 255, 255 };
            Guid guid23 = new Guid(_bArr3);
            Guid[] gArr2 = new Guid[] { guid21, guid22, guid23 };

            OutputHelper.WriteLine("Creating 3 Guids with Guid(int, short, short, byte ....) constructor");
            Guid guid31 = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Guid guid32 = new Guid(1308571317, 40414, 20342, 154, 42, 150, 67, 80, 71, 6, 61);
            Guid guid33 = new Guid(int.MaxValue, short.MaxValue, short.MaxValue, byte.MaxValue, byte.MaxValue,
                byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
            Guid[] gArr3 = new Guid[] { guid31, guid32, guid33 };

            for (int i = 0; i < 3; i++)
            {
                if ((!gArr1[i].Equals(gArr2[i])) || (gArr1[i].GetHashCode() != gArr2[i].GetHashCode()))
                {
                    OutputHelper.WriteLine(i + " Expecting : " + gArr1[i].ToString() + " equals " + gArr2[i].ToString() + " comparing 1 and 2");
                    throw new Exception(" Expecting :  hashcode " + gArr1[i].GetHashCode().ToString() + " equals " + gArr2[i].GetHashCode().ToString());
                }
                if ((!gArr1[i].Equals(gArr3[i])) || (gArr1[i].GetHashCode() != gArr3[i].GetHashCode()))
                {
                    OutputHelper.WriteLine(i + " Expecting : " + gArr1[i].ToString() + " equals " + gArr3[i].ToString() + " comparing 1 and 3");
                    throw new Exception(" Expecting :  hashcode " + gArr1[i].GetHashCode().ToString() + " equals " + gArr3[i].GetHashCode().ToString());
                }
                if ((!gArr2[i].Equals(gArr3[i])) || (gArr2[i].GetHashCode() != gArr3[i].GetHashCode()))
                {
                    OutputHelper.WriteLine(i + " Expecting : " + gArr2[i].ToString() + " equals " + gArr3[i].ToString() + " comparing 2 and 3");
                    throw new Exception(" Expecting :  hashcode " + gArr2[i].GetHashCode().ToString() + " equals " + gArr3[i].GetHashCode().ToString());
                }
            }
        }

    }
}
