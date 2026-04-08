// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

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
            Assert.AreEqual(ushortArrayType.FullName, "System.UInt16[]");

            short[] array2 = new short[10];
            var shortArrayType = array2.GetType();
            Assert.AreEqual(shortArrayType.FullName, "System.Int16[]");

            int[] array3 = new int[10];
            var intArrayType = array3.GetType();
            Assert.AreEqual(intArrayType.FullName, "System.Int32[]");

            uint[] array4 = new uint[10];
            var uintArrayType = array4.GetType();
            Assert.AreEqual(uintArrayType.FullName, "System.UInt32[]");

            ulong[] array5 = new ulong[10];
            var ulongArrayType = array5.GetType();
            Assert.AreEqual(ulongArrayType.FullName, "System.UInt64[]");

            long[] array6 = new long[10];
            var longArrayType = array6.GetType();
            Assert.AreEqual(longArrayType.FullName, "System.Int64[]");

            float[] array7 = new float[10];
            var floatArrayType = array7.GetType();
            Assert.AreEqual(floatArrayType.FullName, "System.Single[]");

            double[] array8 = new double[10];
            var doubleArrayType = array8.GetType();
            Assert.AreEqual(doubleArrayType.FullName, "System.Double[]");
        }

        [TestMethod]
        public void TypeTestsArrays_01()
        {
            Assert.AreEqual(typeof(short[]).FullName, "System.Int16[]");
            Assert.AreEqual(typeof(ushort[]).FullName, "System.UInt16[]");
            Assert.AreEqual(typeof(int[]).FullName, "System.Int32[]");
            Assert.AreEqual(typeof(uint[]).FullName, "System.UInt32[]");
            Assert.AreEqual(typeof(long[]).FullName, "System.Int64[]");
            Assert.AreEqual(typeof(ulong[]).FullName, "System.UInt64[]");
            Assert.AreEqual(typeof(float[]).FullName, "System.Single[]");
            Assert.AreEqual(typeof(double[]).FullName, "System.Double[]");
            Assert.AreEqual(typeof(char[]).FullName, "System.Char[]");
            Assert.AreEqual(typeof(byte[]).FullName, "System.Byte[]");
            Assert.AreEqual(typeof(sbyte[]).FullName, "System.SByte[]");
            Assert.AreEqual(typeof(bool[]).FullName, "System.Boolean[]");
            Assert.AreEqual(typeof(string[]).FullName, "System.String[]");
            Assert.AreEqual(typeof(object[]).FullName, "System.Object[]");
        }

        [TestMethod]
        public void TypeTestsBaseTypes()
        {
            Assert.AreEqual(typeof(short).FullName, "System.Int16");
            Assert.AreEqual(typeof(ushort).FullName, "System.UInt16");
            Assert.AreEqual(typeof(int).FullName, "System.Int32");
            Assert.AreEqual(typeof(uint).FullName, "System.UInt32");
            Assert.AreEqual(typeof(long).FullName, "System.Int64");
            Assert.AreEqual(typeof(ulong).FullName, "System.UInt64");
            Assert.AreEqual(typeof(float).FullName, "System.Single");
            Assert.AreEqual(typeof(double).FullName, "System.Double");
            Assert.AreEqual(typeof(char).FullName, "System.Char");
            Assert.AreEqual(typeof(byte).FullName, "System.Byte");
            Assert.AreEqual(typeof(sbyte).FullName, "System.SByte");
            Assert.AreEqual(typeof(bool).FullName, "System.Boolean");
            Assert.AreEqual(typeof(string).FullName, "System.String");
            Assert.AreEqual(typeof(object).FullName, "System.Object");
        }
    }
}
