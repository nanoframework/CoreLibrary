//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;

namespace NFUnitTestTypes
{
    [TestClass]
    class UnitTestTypes
    {
        [TestMethod]
        public void TypeTestsArrays_00()
        {
            ushort[] array = new ushort[10];
            var ushortArrayType = array.GetType();
            Assert.AreEqual(ushortArrayType.Name, "System.UInt16[]");

            short[] array2 = new short[10];
            var shortArrayType = array2.GetType();
            Assert.AreEqual(shortArrayType.Name, "System.Int16[]");

            int[] array3 = new int[10];
            var intArrayType = array3.GetType();
            Assert.AreEqual(intArrayType.Name, "System.Int32[]");

            uint[] array4 = new uint[10];
            var uintArrayType = array4.GetType();
            Assert.AreEqual(uintArrayType.Name, "System.UInt32[]");

            ulong[] array5 = new ulong[10];
            var ulongArrayType = array5.GetType();
            Assert.AreEqual(ulongArrayType.Name, "System.UInt64[]");

            long[] array6 = new long[10];
            var longArrayType = array6.GetType();
            Assert.AreEqual(longArrayType.Name, "System.Int64[]");

            float[] array7 = new float[10];
            var floatArrayType = array7.GetType();
            Assert.AreEqual(floatArrayType.Name, "System.Single[]");

            double[] array8 = new double[10];
            var doubleArrayType = array8.GetType();
            Assert.AreEqual(doubleArrayType.Name, "System.Double[]");
        }

        [DataRow(typeof(short[]), "System.Int16[]")]
        [DataRow(typeof(ushort[]), "System.UInt16[]")]
        [DataRow(typeof(int[]), "System.Int32[]")]
        [DataRow(typeof(uint[]), "System.UInt32[]")]
        [DataRow(typeof(long[]), "System.Int64[]")]
        [DataRow(typeof(ulong[]), "System.UInt64[]")]
        [DataRow(typeof(float[]), "System.Single[]")]
        [DataRow(typeof(double[]), "System.Double[]")]
        [DataRow(typeof(char[]), "System.Char[]")]
        [DataRow(typeof(byte[]), "System.Byte[]")]
        [DataRow(typeof(sbyte[]), "System.SByte[]")]
        [DataRow(typeof(bool[]), "System.Boolean[]")]
        [DataRow(typeof(string[]), "System.String[]")]
        [DataRow(typeof(object[]), "System.Object[]")]
        [DataRow(typeof(short), "System.Int16")]
        [TestMethod]
        public void TypeTestsArrays_01(Type type, string typeName)
        {
            Assert.AreEqual(type.Name, typeName);
        }

        [DataRow(typeof(short), "System.Int16")]
        [DataRow(typeof(ushort), "System.UInt16")]
        [DataRow(typeof(int), "System.Int32")]
        [DataRow(typeof(uint), "System.UInt32")]
        [DataRow(typeof(long), "System.Int64")]
        [DataRow(typeof(ulong), "System.UInt64")]
        [DataRow(typeof(float), "System.Single")]
        [DataRow(typeof(double), "System.Double")]
        [DataRow(typeof(char), "System.Char")]
        [DataRow(typeof(byte), "System.Byte")]
        [DataRow(typeof(sbyte), "System.SByte")]
        [DataRow(typeof(bool), "System.Boolean")]
        [DataRow(typeof(string), "System.String")]
        [DataRow(typeof(object), "System.Object")]
        [TestMethod]
        public void TypeTestsBaseTypes(Type type, string typeName)
        {
            Assert.AreEqual(type.Name, typeName);
        }
    }
}
