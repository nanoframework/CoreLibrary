// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using nanoFramework.TestFramework;

namespace NFUnitTestTypes
{
    [TestClass]
    public class UnitTestsSpanByte
    {
        [TestMethod]
        public void EmptySpanTests()
        {
            // Empty span
            Span<byte> span = Span<byte>.Empty;
            // Create a destination span larger
            Span<byte> destination = new Span<byte>(new byte[1]);

            span.CopyTo(destination);

            // Now also empty
            destination = Span<byte>.Empty;

            span.CopyTo(destination);
        }

        [TestMethod]
        public void RaisingExceptionsOfAllKindsTests()
        {
            // Should raise an exception on creation
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { Span<byte> span = new Span<byte>(null, 1, 2); }, "ArgumentOutOfRangeException when array is null, start is 1 and length is 2");
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { Span<byte> span = new Span<byte>(new byte[1], 1, 2); }, "ArgumentOutOfRangeException when array is new byte[1], start is 1 and length is 2");
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { Span<byte> span = new Span<byte>(new byte[1], 0, 2); }, "ArgumentOutOfRangeException when array is new byte[1], start is 0 and length is 2");
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () => { Span<byte> span = new Span<byte>(new byte[1], 2, 0); }, "ArgumentOutOfRangeException when array is new byte[1], start is 2 and length is 0");

            // Exception on index access
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                Span<byte> span = new Span<byte>(array);
                _ = span[span.Length];
            });

            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                Span<byte> span = new Span<byte>(array);
                _ = span[-1];
            });

            // Copy to with too small destination
            Assert.ThrowsException(typeof(ArgumentException), () =>
            {
                Span<byte> span = new Span<byte>(array);
                Span<byte> destination = new Span<byte>(new byte[span.Length - 1]);

                span.CopyTo(destination);
            });

            // Slicing arguments
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                Span<byte> span = new Span<byte>(array);
                _ = span.Slice(span.Length + 1);
            });
            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                Span<byte> span = new Span<byte>(array);
                _ = span.Slice(1, span.Length);
            });

            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                Span<byte> span = new Span<byte>(array);
                _ = span.Slice(-1, span.Length);
            });

            Assert.ThrowsException(typeof(ArgumentOutOfRangeException), () =>
            {
                Span<byte> span = new Span<byte>(array);
                _ = span.Slice(1, -1);
            });

        }

        [TestMethod]
        public void ToArrayTest()
        {
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            Span<byte> span = new(array);

            byte[] toArray = span.ToArray();

            CollectionAssert.AreEqual(array, toArray, "Original array and SpanByte.ToArray should be the same");
        }

        [TestMethod]
        public void ConstructorsOfAllKindsTests()
        {
            // Empty span
            Span<byte> span = new Span<byte>();

            Assert.AreEqual(span.Length, 0, "Empty SpanByte should have length of 0");
            Assert.IsTrue(span.IsEmpty, "Empty SpanByte should be IsEmpty");

            // Empty span
            span = new Span<byte>(null, 0, 0);

            Assert.AreEqual(span.Length, 0, "Empty SpanByte should have length of 0");
            Assert.IsTrue(span.IsEmpty, "Empty SpanByte should be IsEmpty");

            // Empty span
            span = Span<byte>.Empty;

            Assert.AreEqual(span.Length, 0, "Empty SpanByte should have length of 0");
            Assert.IsTrue(span.IsEmpty, "Empty SpanByte should be IsEmpty");

            // Span<byte>from normal array
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            span = new Span<byte>(array);

            Assert.AreEqual(span.Length, array.Length, $"SpanByte should have length of the array it takes: {array.Length}");
            Assert.IsFalse(span.IsEmpty, "SpanByte should NOT be IsEmpty");

            // Span<byte>from normal array with different start and length
            span = new Span<byte>(array, 2, 8);

            Assert.AreEqual(span.Length, 8, $"SpanByte should have length of 8");
            Assert.IsFalse(span.IsEmpty, "SpanByte should NOT be IsEmpty");
        }

        [TestMethod]
        public void SliceTests()
        {
            // Span<byte>from normal array
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            Span<byte> span = new Span<byte>(array);

            // Slice 2 elements and check
            Span<byte> sliced = span.Slice(0, 2);

            Assert.AreEqual(sliced.Length, 2, "Sliced span lenght must be 2");
            Assert.AreEqual(sliced[0], (byte)0x00, "Sliced first element must be value 0");
            Assert.AreEqual(sliced[1], (byte)0x01, "Sliced first element must be value 1");

            // Slide 4 elements starting at index 2 and check
            sliced = span.Slice(2, 4);

            Assert.AreEqual(sliced.Length, 4, "Sliced span lenght must be 4");
            Assert.AreEqual(sliced[0], (byte)0x02, "Sliced first element must be value 2");
            Assert.AreEqual(sliced[1], (byte)0x03, "Sliced first element must be value 3");
            Assert.AreEqual(sliced[2], (byte)0x04, "Sliced first element must be value 4");
            Assert.AreEqual(sliced[3], (byte)0x05, "Sliced first element must be value 5");

            // Slide starting 4 at element check
            sliced = span.Slice(4);

            Assert.AreEqual(sliced.Length, 12, "Sliced span lenght must be 12");

            for (int i = 0; i < sliced.Length; i++)
            {
                Assert.AreEqual(sliced[i], span[i + 4], "SpanByte value should be the same as from the original span");
            }

            // Slice of slice
            Span<byte> secondSliced = sliced.Slice(2, 4);

            Assert.AreEqual(secondSliced.Length, 4, "Sliced span lenght must be 12");

            for (int i = 0; i < secondSliced.Length; i++)
            {
                Assert.AreEqual(secondSliced[i], sliced[i + 2], "SpanByte value should be the same as from the original span");
            }

            // Should be an empty one
            Span<byte> empty = span.Slice(span.Length);

            Assert.AreEqual(empty.Length, 0, "slicing all the span should result in an empty span");
            Assert.IsTrue(empty.IsEmpty, "Empty span should be empty");
        }

        [TestMethod]
        public void CopyToTests()
        {
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            Span<byte> span = new Span<byte>(array);

            // First a copy to with the full span
            Span<byte> toCopy = new Span<byte>(new byte[span.Length]);

            span.CopyTo(toCopy);

            CollectionAssert.AreEqual(array, toCopy.ToArray(), "Original array and SpanByte.CopyTo should be the same");

            // Now create a larger span
            toCopy = new Span<byte>(new byte[span.Length + 1]);
            span.CopyTo(toCopy);

            Assert.AreEqual(toCopy.Length, span.Length + 1);

            byte[] tempArray = new byte[span.Length + 1];
            Array.Copy(array, tempArray, array.Length);

            CollectionAssert.AreEqual(tempArray, toCopy.ToArray(), "Original array and SpanByte.CopyTo should be the same with larger destination");

            Assert.AreEqual(toCopy[toCopy.Length - 1], (byte)0, "Last byte should be 0 (byte default)");
        }

        [TestMethod]
        public void GetElementsTests()
        {
            // Span<byte>from normal array
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            Span<byte> span = new Span<byte>(array);
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual(span[i], array[i], "SpanByte value should be the same as from the original array");
            }

            // Partial span
            span = new Span<byte>(array, 2, 8);
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual(span[i], array[i + 2], "SpanByte value should be the same as from the original array");
            }
        }

        [TestMethod]
        public void SetElementsTests()
        {
            // Create a span, and set the data
            Span<byte> span = new Span<byte>(new byte[12]);

            // All should be 0
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual(span[i], (byte)0, "SpanByte value should be 0");

                // Set a value
                span[i] = (byte)i;
            }

            for (int i = 0; i < span.Length; i++)
            {
                // Check the value
                Assert.AreEqual(span[i], (byte)i, "SpanByte value should be the same as setup in the set method");
            }
        }

        [TestMethod]
        public void StackAllocSpanTests()
        {
            // Create a span from stack-allocated memory
            Span<byte> span = stackalloc byte[16];

            Assert.AreEqual(16, span.Length, "Stack-allocated span should have length of 16");
            Assert.IsFalse(span.IsEmpty, "Stack-allocated span should NOT be IsEmpty");

            // Verify all elements are initialized to zero
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual((byte)0, span[i], "Stack-allocated span elements should be initialized to 0");
            }

            // Set values in the stack-allocated span
            for (int i = 0; i < span.Length; i++)
            {
                span[i] = (byte)(i * 2);
            }

            // Verify the values were set correctly
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual((byte)(i * 2), span[i], $"Stack-allocated span element at index {i} should be {i * 2}");
            }
        }

        [TestMethod]
        public void StackAllocSpanWithInitializerTests()
        {
            // Create a span from stack-allocated memory with initializer
            Span<byte> span = stackalloc byte[8] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };

            Assert.AreEqual(8, span.Length, "Stack-allocated span with initializer should have length of 8");
            Assert.IsFalse(span.IsEmpty, "Stack-allocated span should NOT be IsEmpty");

            // Verify the initialized values
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual((byte)(i + 1), span[i], $"Stack-allocated span element at index {i} should be {i + 1}");
            }
        }

        [TestMethod]
        public void StackAllocSpanSliceTests()
        {
            // Create a span from stack-allocated memory
            Span<byte> span = stackalloc byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            // Slice the stack-allocated span
            Span<byte> sliced = span.Slice(4, 8);

            Assert.AreEqual(8, sliced.Length, "Sliced stack-allocated span should have length of 8");

            for (int i = 0; i < sliced.Length; i++)
            {
                Assert.AreEqual((byte)(i + 4), sliced[i], $"Sliced element at index {i} should be {i + 4}");
            }

            // Modify the sliced span and verify it affects the original
            sliced[0] = 0xFF;
            Assert.AreEqual((byte)0xFF, span[4], "Modifying sliced span should affect the original stack-allocated span");
        }

        [TestMethod]
        public void StackAllocSpanCopyToTests()
        {
            // Create a span from stack-allocated memory
            Span<byte> source = stackalloc byte[8] { 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80 };

            // Create a destination span (also stack-allocated)
            Span<byte> destination = stackalloc byte[8];

            // Copy from source to destination
            source.CopyTo(destination);

            // Verify the copy
            for (int i = 0; i < destination.Length; i++)
            {
                Assert.AreEqual(source[i], destination[i], $"Copied element at index {i} should match source");
            }

            // Copy to a heap-allocated array
            byte[] heapArray = new byte[8];
            Span<byte> heapSpan = new Span<byte>(heapArray);
            source.CopyTo(heapSpan);

            CollectionAssert.AreEqual(source.ToArray(), heapArray, "Stack-allocated span should copy correctly to heap-allocated array");
        }

        [TestMethod]
        public void StackAllocSpanToArrayTests()
        {
            // Create a span from stack-allocated memory
            Span<byte> span = stackalloc byte[6] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF };

            // Convert to array
            byte[] array = span.ToArray();

            Assert.AreEqual(6, array.Length, "ToArray should create an array with the same length");

            byte[] expected = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF };
            CollectionAssert.AreEqual(expected, array, "Stack-allocated span ToArray should match expected values");
        }

        [TestMethod]
        public void StackAllocEmptySpanTests()
        {
            // Create an empty stack-allocated span
            Span<byte> span = stackalloc byte[0];

            Assert.AreEqual(0, span.Length, "Empty stack-allocated span should have length of 0");
            Assert.IsTrue(span.IsEmpty, "Empty stack-allocated span should be IsEmpty");
        }
    }
}
