// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    public class UnitTestMemoryExtensions
    {
        [TestMethod]
        public void CopyTo_WithValidArray_ShouldCopyAllElements()
        {
            // Arrange
            byte[] source = new byte[] { 1, 2, 3, 4, 5 };
            Span<byte> destination = new Span<byte>(new byte[5]);

            // Act
            source.CopyTo(destination);

            // Assert
            for (byte i = 0; i < source.Length; i++)
            {
                Assert.AreEqual(source[i], destination[i], $"Element at index {i} should match");
            }
        }

        [TestMethod]
        public void CopyTo_WithLargerDestination_ShouldCopyAllElements()
        {
            // Arrange
            int[] source = new int[] { 10, 20, 30 };
            Span<int> destination = new Span<int>(new int[5]);

            // Act
            source.CopyTo(destination);

            // Assert
            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreEqual(source[i], destination[i], $"Element at index {i} should match");
            }

            // Verify remaining elements are default
            for (int i = source.Length; i < destination.Length; i++)
            {
                Assert.AreEqual(0, destination[i], $"Element at index {i} should be default value");
            }
        }

        [TestMethod]
        public void CopyTo_WithSmallerDestination_ShouldThrowArgumentException()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException(typeof(ArgumentException), () =>
            {
                int[] source = new int[] { 1, 2, 3, 4, 5 };
                Span<int> destination = new Span<int>(new int[3]);

                source.CopyTo(destination);
            });
        }

        [TestMethod]
        public void CopyTo_WithNullArray_ShouldCopyAsEmpty()
        {
            // Arrange
            int[] source = null;
            Span<int> destination = new Span<int>(new int[5]);

            // Act
            source.CopyTo(destination);

            // Assert - all elements should remain at default value (0)
            for (int i = 0; i < destination.Length; i++)
            {
                Assert.AreEqual(0, destination[i], $"Element at index {i} should be default value");
            }
        }

        [TestMethod]
        public void CopyTo_WithEmptyArray_ShouldNotModifyDestination()
        {
            // Arrange
            int[] source = new int[0];
            int[] destArray = new int[5] { 1, 2, 3, 4, 5 };
            Span<int> destination = new Span<int>(destArray);

            // Act
            source.CopyTo(destination);

            // Assert - destination should remain unchanged
            for (int i = 0; i < destArray.Length; i++)
            {
                Assert.AreEqual(i + 1, destination[i], $"Element at index {i} should remain unchanged");
            }
        }

        [TestMethod]
        public void CopyTo_WithByteArray_ShouldCopyCorrectly()
        {
            // Arrange
            byte[] source = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            Span<byte> destination = new Span<byte>(new byte[4]);

            // Act
            source.CopyTo(destination);

            // Assert
            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreEqual(source[i], destination[i], $"Byte at index {i} should match");
            }
        }

        [TestMethod]
        public void CopyTo_WithStringArray_ShouldCopyReferences()
        {
            // Arrange
            string[] source = new string[] { "hello", "world", "test" };
            Span<string> destination = new Span<string>(new string[3]);

            // Act
            source.CopyTo(destination);

            // Assert
            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreSame(source[i], destination[i], $"String reference at index {i} should be the same");
            }
        }

        [TestMethod]
        public void CopyTo_WithValueTypeArray_ShouldCopyValues()
        {
            // Arrange
            double[] source = new double[] { 1.5, 2.5, 3.5 };
            Span<double> destination = new Span<double>(new double[3]);

            // Act
            source.CopyTo(destination);

            // Assert
            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreEqual(source[i], destination[i], $"Double at index {i} should match");
            }
        }

        [TestMethod]
        public void CopyTo_WithCustomStruct_ShouldCopyStructValues()
        {
            // Arrange
            TestStruct[] source = new TestStruct[]
            {
                new TestStruct { Value = 10, Name = "First" },
                new TestStruct { Value = 20, Name = "Second" },
                new TestStruct { Value = 30, Name = "Third" }
            };
            Span<TestStruct> destination = new Span<TestStruct>(new TestStruct[3]);

            // Act
            source.CopyTo(destination);

            // Assert
            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreEqual(source[i].Value, destination[i].Value, $"Struct Value at index {i} should match");
                Assert.AreEqual(source[i].Name, destination[i].Name, $"Struct Name at index {i} should match");
            }
        }

        [TestMethod]
        public void CopyTo_MultipleConsecutiveCalls_ShouldWorkCorrectly()
        {
            // Arrange
            int[] source1 = new int[] { 1, 2, 3 };
            int[] source2 = new int[] { 4, 5, 6 };
            Span<int> destination = new Span<int>(new int[6]);

            // Act
            source1.CopyTo(destination);
            source2.CopyTo(destination.Slice(3));

            // Assert
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], destination[i], $"Element at index {i} should match");
            }
        }

        [TestMethod]
        public void CopyTo_WithSingleElementArray_ShouldCopy()
        {
            // Arrange
            int[] source = new int[] { 42 };
            Span<int> destination = new Span<int>(new int[1]);

            // Act
            source.CopyTo(destination);

            // Assert
            Assert.AreEqual(42, destination[0], "Single element should be copied");
        }

        [TestMethod]
        public void CopyTo_WithLargeArray_ShouldCopyAllElements()
        {
            // Arrange
            int size = 1000;
            int[] source = new int[size];
            for (int i = 0; i < size; i++)
            {
                source[i] = i;
            }

            Span<int> destination = new Span<int>(new int[size]);

            // Act
            source.CopyTo(destination);

            // Assert
            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(source[i], destination[i], $"Element at index {i} should match");
            }
        }

        // Helper struct for testing
        private struct TestStruct
        {
            public int Value { get; set; }
            public string Name { get; set; }
        }
    }
}
