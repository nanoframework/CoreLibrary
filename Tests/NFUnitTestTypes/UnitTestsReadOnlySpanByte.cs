// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestTypes
{
    [TestClass]
    public class UnitTestsReadOnlySpanByte
    {
        [TestMethod]
        public void EmptySpanTests()
        {
            // Empty span using default constructor
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>();

            Assert.AreEqual(0, span.Length, "Empty ReadOnlySpan should have length of 0");
            Assert.IsTrue(span.IsEmpty, "Empty ReadOnlySpan should be IsEmpty");

            // Empty span from null array
            span = new ReadOnlySpan<byte>(null);

            Assert.AreEqual(0, span.Length, "ReadOnlySpan from null should have length of 0");
            Assert.IsTrue(span.IsEmpty, "ReadOnlySpan from null should be IsEmpty");

            // Empty span using Empty property
            span = ReadOnlySpan<byte>.Empty;

            Assert.AreEqual(0, span.Length, "Empty ReadOnlySpan should have length of 0");
            Assert.IsTrue(span.IsEmpty, "Empty ReadOnlySpan should be IsEmpty");
        }

        [TestMethod]
        public void RaisingExceptionsOfAllKindsTests()
        {
            // Should raise an exception on creation
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(null, 1, 2); }, "ArgumentOutOfRangeException when array is null, start is 1 and length is 2");
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(new byte[1], 1, 2); }, "ArgumentOutOfRangeException when array is new byte[1], start is 1 and length is 2");
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(new byte[1], 0, 2); }, "ArgumentOutOfRangeException when array is new byte[1], start is 0 and length is 2");
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(new byte[1], 2, 0); }, "ArgumentOutOfRangeException when array is new byte[1], start is 2 and length is 0");

            // Exception on index access
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
                _ = span[span.Length];
            });

            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
                _ = span[-1];
            });

            // Slicing arguments
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
                _ = span.Slice(span.Length + 1);
            });

            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
                _ = span.Slice(1, span.Length);
            });

            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
                _ = span.Slice(-1, span.Length);
            });

            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
                _ = span.Slice(1, -1);
            });
        }

        [TestMethod]
        public void ToArrayTest()
        {
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);

            byte[] toArray = span.ToArray();

            CollectionAssert.AreEqual(array, toArray, "Original array and ReadOnlySpan.ToArray should be the same");
        }

        [TestMethod]
        public void ConstructorsOfAllKindsTests()
        {
            // Empty span using default constructor
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>();

            Assert.AreEqual(span.Length, 0, "Empty ReadOnlySpan should have length of 0");
            Assert.IsTrue(span.IsEmpty, "Empty ReadOnlySpan should be IsEmpty");

            // Empty span from null with zero start and length
            span = new ReadOnlySpan<byte>(null, 0, 0);

            Assert.AreEqual(span.Length, 0, "Empty ReadOnlySpan should have length of 0");
            Assert.IsTrue(span.IsEmpty, "Empty ReadOnlySpan should be IsEmpty");

            // Empty span using Empty property
            span = ReadOnlySpan<byte>.Empty;

            Assert.AreEqual(span.Length, 0, "Empty ReadOnlySpan should have length of 0");
            Assert.IsTrue(span.IsEmpty, "Empty ReadOnlySpan should be IsEmpty");

            // ReadOnlySpan from normal array
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            span = new ReadOnlySpan<byte>(array);

            Assert.AreEqual(span.Length, array.Length, $"ReadOnlySpan should have length of the array it takes: {array.Length}");
            Assert.IsFalse(span.IsEmpty, "ReadOnlySpan should NOT be IsEmpty");

            // ReadOnlySpan from normal array with different start and length
            span = new ReadOnlySpan<byte>(array, 2, 8);

            Assert.AreEqual(span.Length, 8, $"ReadOnlySpan should have length of 8");
            Assert.IsFalse(span.IsEmpty, "ReadOnlySpan should NOT be IsEmpty");
        }

        [TestMethod]
        public void SliceTests()
        {
            // ReadOnlySpan from normal array
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);

            // Slice 2 elements and check
            ReadOnlySpan<byte> sliced = span.Slice(0, 2);

            Assert.AreEqual(sliced.Length, 2, "Sliced span length must be 2");
            Assert.AreEqual(sliced[0], (byte)0x00, "Sliced first element must be value 0");
            Assert.AreEqual(sliced[1], (byte)0x01, "Sliced second element must be value 1");

            // Slice 4 elements starting at index 2 and check
            sliced = span.Slice(2, 4);

            Assert.AreEqual(sliced.Length, 4, "Sliced span length must be 4");
            Assert.AreEqual(sliced[0], (byte)0x02, "Sliced first element must be value 2");
            Assert.AreEqual(sliced[1], (byte)0x03, "Sliced second element must be value 3");
            Assert.AreEqual(sliced[2], (byte)0x04, "Sliced third element must be value 4");
            Assert.AreEqual(sliced[3], (byte)0x05, "Sliced fourth element must be value 5");

            // Slice starting at element 4 and check
            sliced = span.Slice(4);

            Assert.AreEqual(sliced.Length, 12, "Sliced span length must be 12");

            for (int i = 0; i < sliced.Length; i++)
            {
                Assert.AreEqual(sliced[i], span[i + 4], "ReadOnlySpan value should be the same as from the original span");
            }

            // Slice of slice
            ReadOnlySpan<byte> secondSliced = sliced.Slice(2, 4);

            Assert.AreEqual(secondSliced.Length, 4, "Sliced span length must be 4");

            for (int i = 0; i < secondSliced.Length; i++)
            {
                Assert.AreEqual(secondSliced[i], sliced[i + 2], "ReadOnlySpan value should be the same as from the original span");
            }

            // Should be an empty one
            ReadOnlySpan<byte> empty = span.Slice(span.Length);

            Assert.AreEqual(empty.Length, 0, "Slicing all the span should result in an empty span");
            Assert.IsTrue(empty.IsEmpty, "Empty span should be empty");
        }

        [TestMethod]
        public void GetElementsTests()
        {
            // ReadOnlySpan from normal array
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual(span[i], array[i], "ReadOnlySpan value should be the same as from the original array");
            }

            // Partial span
            span = new ReadOnlySpan<byte>(array, 2, 8);
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual(span[i], array[i + 2], "ReadOnlySpan value should be the same as from the original array");
            }
        }

        [TestMethod]
        public void StackAllocReadOnlySpanTests()
        {
            // Create a ReadOnlySpan from stack-allocated memory
            ReadOnlySpan<byte> span = stackalloc byte[16];

            Assert.AreEqual(16, span.Length, "Stack-allocated ReadOnlySpan should have length of 16");
            Assert.IsFalse(span.IsEmpty, "Stack-allocated ReadOnlySpan should NOT be IsEmpty");

            // Verify all elements are initialized to zero
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual((byte)0, span[i], "Stack-allocated ReadOnlySpan elements should be initialized to 0");
            }
        }

        [TestMethod]
        public void StackAllocReadOnlySpanWithInitializerTests()
        {
            // Create a ReadOnlySpan from stack-allocated memory with initializer
            ReadOnlySpan<byte> span = stackalloc byte[8] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };

            Assert.AreEqual(8, span.Length, "Stack-allocated ReadOnlySpan with initializer should have length of 8");
            Assert.IsFalse(span.IsEmpty, "Stack-allocated ReadOnlySpan should NOT be IsEmpty");

            // Verify the initialized values
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual((byte)(i + 1), span[i], $"Stack-allocated ReadOnlySpan element at index {i} should be {i + 1}");
            }
        }

        [TestMethod]
        public void StackAllocReadOnlySpanSliceTests()
        {
            // Create a ReadOnlySpan from stack-allocated memory
            ReadOnlySpan<byte> span = stackalloc byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            // Slice the stack-allocated span
            ReadOnlySpan<byte> sliced = span.Slice(4, 8);

            Assert.AreEqual(8, sliced.Length, "Sliced stack-allocated ReadOnlySpan should have length of 8");

            for (int i = 0; i < sliced.Length; i++)
            {
                Assert.AreEqual((byte)(i + 4), sliced[i], $"Sliced element at index {i} should be {i + 4}");
            }
        }

        [TestMethod]
        public void StackAllocReadOnlySpanToArrayTests()
        {
            // Create a ReadOnlySpan from stack-allocated memory
            ReadOnlySpan<byte> span = stackalloc byte[6] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF };

            // Convert to array
            byte[] array = span.ToArray();

            Assert.AreEqual(6, array.Length, "ToArray should create an array with the same length");

            byte[] expected = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF };
            CollectionAssert.AreEqual(expected, array, "Stack-allocated ReadOnlySpan ToArray should match expected values");
        }

        [TestMethod]
        public void StackAllocEmptyReadOnlySpanTests()
        {
            // Create an empty stack-allocated ReadOnlySpan
            ReadOnlySpan<byte> span = stackalloc byte[0];

            Assert.AreEqual(0, span.Length, "Empty stack-allocated ReadOnlySpan should have length of 0");
            Assert.IsTrue(span.IsEmpty, "Empty stack-allocated ReadOnlySpan should be IsEmpty");
        }

        [TestMethod]
        public void ImplicitConversionFromArrayTests()
        {
            // Test implicit conversion from array to ReadOnlySpan
            byte[] array = new byte[8] { 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80 };

            ReadOnlySpan<byte> span = array; // Implicit conversion

            Assert.AreEqual(array.Length, span.Length, "Implicitly converted ReadOnlySpan should have same length as array");

            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(array[i], span[i], $"Element at index {i} should match");
            }
        }

        [TestMethod]
        public void EqualityOperatorTests()
        {
            byte[] array1 = new byte[4] { 0x01, 0x02, 0x03, 0x04 };
            byte[] array2 = new byte[4] { 0x01, 0x02, 0x03, 0x04 };
            byte[] array3 = new byte[4] { 0x01, 0x02, 0x03, 0x05 };

            ReadOnlySpan<byte> span1 = new ReadOnlySpan<byte>(array1);
            ReadOnlySpan<byte> span2 = new ReadOnlySpan<byte>(array2);
            ReadOnlySpan<byte> span3 = new ReadOnlySpan<byte>(array3);

            // Test equality with same content
            Assert.IsTrue(span1 == span2, "ReadOnlySpans with same content should be equal");

            // Test inequality with different content
            Assert.IsTrue(span1 != span3, "ReadOnlySpans with different content should not be equal");
            Assert.IsFalse(span1 == span3, "ReadOnlySpans with different content should not be equal");

            // Test empty spans
            ReadOnlySpan<byte> empty1 = new ReadOnlySpan<byte>();
            ReadOnlySpan<byte> empty2 = new ReadOnlySpan<byte>();

            Assert.IsTrue(empty1 == empty2, "Empty ReadOnlySpans should be equal");
        }

        [TestMethod]
        public void ReadOnlyBehaviorTests()
        {
            // Verify that ReadOnlySpan protects the underlying data from modification through the span
            byte[] array = new byte[4] { 0x01, 0x02, 0x03, 0x04 };
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);

            // We can read values
            Assert.AreEqual((byte)0x01, span[0], "Should be able to read from ReadOnlySpan");

            // The following would not compile (which is the desired behavior):
            // span[0] = 0xFF; // Error: Cannot assign to a readonly ref return

            // But we can still modify the underlying array directly
            array[0] = 0xFF;
            Assert.AreEqual((byte)0xFF, span[0], "Modifying underlying array should be visible through ReadOnlySpan");
        }

        [TestMethod]
        public void PartialSpanTests()
        {
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            // Create ReadOnlySpan that covers middle portion of array
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array, 4, 8);

            Assert.AreEqual(8, span.Length, "Partial ReadOnlySpan should have correct length");
            Assert.AreEqual((byte)0x04, span[0], "First element should be from start index");
            Assert.AreEqual((byte)0x0B, span[7], "Last element should be at start + length - 1");

            // Verify all elements in the partial span
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual(array[i + 4], span[i], $"Element at index {i} should match array element at {i + 4}");
            }
        }
    }
}
