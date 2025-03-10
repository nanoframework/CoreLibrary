// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

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

            byte[] guid16 = GetRandomBytes(16);
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
            byte[] guidNot16 = GetRandomBytes(size);
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

            byte[] nullByte = null;
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
            int _int = random.Next(int.MaxValue);
            short _short1 = (short)random.Next(32768);
            short _short2 = (short)random.Next(32768);
            byte[] _bArr = GetRandomBytes(8);
            _ = new Guid(_int, _short1, _short2, _bArr[0], _bArr[1], _bArr[2], _bArr[3], _bArr[4], _bArr[5], _bArr[6], _bArr[7]);
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
            int randoInt = random.Next(int.MaxValue);
            uint _uInt = (uint)(randoInt * 2);
            ushort _uShort1 = (ushort)random.Next(65536);
            ushort _uShort2 = (ushort)random.Next(65536);
            byte[] _bArr = GetRandomBytes(8);
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
            byte[] _bArr = guid.ToByteArray();
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
            // Verifing any instance of Guid, regardless of its value, is greater than null
            Assert.AreEqual(guid1.CompareTo(null), 1);
            byte[] _bArr = new byte[16];

            // Creating a Guid with all bytes zero
            Guid guid2 = new Guid(_bArr);
            Assert.AreEqual(guid1.CompareTo(guid2), 0);

            Guid guid3 = new Guid(0x4dff36b5, 0x9dde, 0x4f76, 0x9a, 0x2a, 0x96, 0x43, 0x50, 0x47, 0x06, 0x3d);
            Assert.IsTrue(guid3.CompareTo(guid1) > 0, "Expected : " + guid3.ToString() + " is greater than " + guid1.ToString());

            Guid guid4 = new Guid(0x4dff36b5, 0x9dde, 0x4f76, 0x9a, 0x2a, 0x96, 0x43, 0x50, 0x47, 0x06, 0x3d);
            Assert.AreEqual(guid4.CompareTo(guid3), 0);

            Guid guid5 = new Guid(0x4dff36b5, 0x9dde, 0x4f76, 0x9a, 0x2a, 0x96, 0x43, 0x50, 0x47, 0x06, 0x3e);
            Assert.IsTrue(guid5.CompareTo(guid4) > 0, "Expected : " + guid5.ToString() + " is greater than " + guid4.ToString());
            Assert.IsTrue(guid4.CompareTo(guid5) < 0, "Expected : " + guid4.ToString() + " is less than " + guid5.ToString());
        }

        [TestMethod]
        public void Guid_ToString_Test10()
        {
            /// <summary>
            /// 1. Creates 4 Guids and Converts them ToString 
            /// 2. Verifies the Conversion of Guids to string is correct
            /// </summary>
            ///

            string[] strArr1 = new string[]
            {
                "00000000-0000-0000-0000-000000000000",
                "00000000-0000-0000-0000-000000000000",
                "4dff36b5-9dde-4f76-9a2a-96435047063d",
                "ffffffff-ffff-ffff-ffff-ffffffffffff"
            };

            Guid guid1 = Guid.Empty;
            byte[] _byteArr1 = new byte[16];
            Guid guid2 = new Guid(_byteArr1);
            Guid guid3 = new Guid(0x4dff36b5, 0x9dde, 0x4f76, 0x9a, 0x2a, 0x96, 0x43, 0x50, 0x47, 0x06, 0x3d);

            byte[] _byteArr2 = new byte[16];

            for (int i = 0; i < _byteArr2.Length; i++)
            {
                _byteArr2[i] = byte.MaxValue;
            }

            Guid guid4 = new Guid(_byteArr2);

            string[] strArr2 = new string[] { guid1.ToString(), guid2.ToString(), guid3.ToString(), guid4.ToString() };

            for (int i = 0; i < strArr1.Length; i++)
            {
                OutputHelper.WriteLine(strArr1[i]);
                Assert.AreEqual(string.Compare(strArr1[i], strArr2[i]), 0);
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

            // Creating 3 Guids with Guid.Empty and hex values
            Guid guid11 = Guid.Empty;
            Guid guid12 = new Guid(0x4dff36b5, 0x9dde, 0x4f76, 0x9a, 0x2a, 0x96, 0x43, 0x50, 0x47, 0x06, 0x3d);
            Guid guid13 = new Guid(0x7FFFFFFF, 0x7FFF, 0x7FFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF);
            Guid[] gArr1 = new Guid[] { guid11, guid12, guid13 };

            // Creating Guids with 16 bytes constructor
            byte[] _bArr1 = new byte[16];

            Guid guid21 = new Guid(_bArr1);
            byte[] _bArr2 = new byte[] { 181, 54, 255, 77, 222, 157, 118, 79, 154, 42, 150, 67, 80, 71, 6, 61 };

            Guid guid22 = new Guid(_bArr2);
            byte[] _bArr3 = new byte[] { 255, 255, 255, 127, 255, 127, 255, 127, 255, 255, 255, 255, 255, 255, 255, 255 };

            Guid guid23 = new Guid(_bArr3);
            Guid[] gArr2 = new Guid[] { guid21, guid22, guid23 };

            // Creating 3 Guids with Guid(int, short, short, byte ....) constructor
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

        [DataRow("00000000-0000-0000-0000-000000000000")]
        [DataRow("4dff36b5-9dde-4f76-9a2a-96435047063d")]
        [DataRow("ffffffff-ffff-ffff-ffff-ffffffffffff")]
        [DataRow("a8a110d5-fc49-43c5-bf46-802db8f843ff")]
        [DataRow("44332211-6655-8877-9900-aabbccddeeff")]
        [DataRow("11223344-5566-7788-9900-aabbccddeeff")]
        [TestMethod]
        public void Ctor_FromString_Test00(string guidString)
        {
            /// <summary>
            /// 1. Creates a Guid from a string
            /// 2. Verifies the Guid is created correctly
            /// </summary>

            Guid guid = new Guid(guidString);

            Assert.AreEqual(guidString, guid.ToString());
        }
        [DataRow("{00000000-0000-0000-0000-000000000000}")]
        [DataRow("{4dff36b5-9dde-4f76-9a2a-96435047063d}")]
        [DataRow("{ffffffff-ffff-ffff-ffff-ffffffffffff}")]
        [DataRow("{a8a110d5-fc49-43c5-bf46-802db8f843ff}")]
        [DataRow("{44332211-6655-8877-9900-aabbccddeeff}")]
        [DataRow("{11223344-5566-7788-9900-aabbccddeeff}")]
        [TestMethod]
        public void Ctor_FromString_Test01(string guidString)
        {
            /// <summary>
            /// 1. Creates a Guid from a string
            /// 2. Verifies the Guid is created correctly
            /// </summary>

            Guid guid = new Guid(guidString);

            Assert.AreEqual(guidString, $"{{{guid.ToString()}}}");
        }

        [TestMethod]
        public void Ctor_FromString_Test02()
        {
            Guid testGuid = new Guid("a8a110d5-fc49-43c5-bf46-802db8f843ff");
            Guid fullGuid = new Guid(uint.MaxValue, ushort.MaxValue, ushort.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

            Assert.AreEqual(new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), fullGuid);
            Assert.AreEqual((new Guid("a8a110d5-fc49-43c5-bf46-802db8f843ff")).ToString(), testGuid.ToString());
        }

        [TestMethod]
        public void Guid_ByteArray_Test()
        {
            object[][] testData = new object[][]
            {
                new object[] { Guid.Empty, new byte[16] },
                new object[] { new Guid("44332211-6655-8877-9900-aabbccddeeff"), new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0x00, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } },
                new object[] { new Guid("11223344-5566-7788-9900-aabbccddeeff"), new byte[] { 0x44, 0x33, 0x22, 0x11, 0x66, 0x55, 0x88, 0x77, 0x99, 0x00, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } },
                new object[] { new Guid("a8a110d5-fc49-43c5-bf46-802db8f843ff"), new byte[] { 0xd5, 0x10, 0xa1, 0xa8, 0x49, 0xfc, 0xc5, 0x43, 0xbf, 0x46, 0x80, 0x2d, 0xb8, 0xf8, 0x43, 0xff } }
            };

            foreach (object[] item in testData)
            {
                Guid guid = new Guid((byte[])item[1]);

                OutputHelper.WriteLine($"Actual: {guid}");
                OutputHelper.WriteLine($"Expected: {item[0]}");

                Assert.AreEqual(item[0], guid);
            }
        }

        [TestMethod]
        public void Ctor_NullByteArray_ThrowsArgumentNullException()
        {
            Assert.ThrowsException(
                typeof(ArgumentNullException),
                () => new Guid((byte[])null));
        }

        [DataRow(15)]
        [DataRow(17)]
        [TestMethod]
        public void Ctor_InvalidLengthByteArray_ThrowsArgumentException(int length)
        {
            Assert.ThrowsException(
                typeof(ArgumentException),
                () => new Guid(new byte[length]));
        }

        [TestMethod]
        public void Ctor_UInt_UShort_UShort_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte()
        {
            Guid guid = new Guid(0xa8a110d5, 0xfc49, 0x43c5, 0xbf, 0x46, 0x80, 0x2d, 0xb8, 0xf8, 0x43, 0xff);
            Assert.AreEqual(new Guid("a8a110d5-fc49-43c5-bf46-802db8f843ff"), guid);
        }

        [TestMethod]
        public void NewGuid()
        {
            Guid guid1 = Guid.NewGuid();

            Assert.AreNotEqual(Guid.Empty, guid1);
            Assert.IsTrue((guid1.ToByteArray()[7] & 0xF0) == 0x40);

            Guid guid2 = Guid.NewGuid();

            Assert.AreNotEqual(guid1, guid2);
            Assert.IsTrue((guid2.ToByteArray()[7] & 0xF0) == 0x40);
        }

        [TestMethod]
        public void ToByteArray()
        {
            byte[] myGuidAsArray = new Guid("a8a110d5-fc49-43c5-bf46-802db8f843ff").ToByteArray();

            CollectionAssert.AreEqual(new byte[] { 0xd5, 0x10, 0xa1, 0xa8, 0x49, 0xfc, 0xc5, 0x43, 0xbf, 0x46, 0x80, 0x2d, 0xb8, 0xf8, 0x43, 0xff }, myGuidAsArray);
        }
    }
}
