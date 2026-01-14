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
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
                _ = span[span.Length];
            }, "IndexOutOfRangeException when accessing index equal to Length");

            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
                _ = span[-1];
            }, "IndexOutOfRangeException when accessing negative index");

            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
                _ = span[span.Length + 1];
            }, "IndexOutOfRangeException when accessing index beyond Length");

            // CopyTo with too small destination
            Assert.ThrowsException(typeof(ArgumentException), () =>
            {
                ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
                Span<byte> destination = new Span<byte>(new byte[span.Length - 1]);

                span.CopyTo(destination);
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
        public void IndexOutOfRangeExceptionTests()
        {
            // Comprehensive tests for IndexOutOfRangeException in the indexer
            byte[] array = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);

            // Test reading at exact boundary
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetReadOnlySpanElement(array, 10);
            }, "Should throw IndexOutOfRangeException at index equal to Length");

            // Test reading beyond boundary
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetReadOnlySpanElement(array, 100);
            }, "Should throw IndexOutOfRangeException at large index");

            // Test negative index
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetReadOnlySpanElement(array, -1);
            }, "Should throw IndexOutOfRangeException at negative index");

            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetReadOnlySpanElement(array, -100);
            }, "Should throw IndexOutOfRangeException at large negative index");

            // Valid access should not throw
            byte value = span[0];
            Assert.AreEqual((byte)0, value, "Valid index 0 should return correct value");

            value = span[9];
            Assert.AreEqual((byte)9, value, "Valid index 9 should return correct value");

            value = span[5];
            Assert.AreEqual((byte)5, value, "Valid index 5 should return correct value");
        }

        // Helper methods to avoid capturing ref struct in lambdas
        private static byte GetReadOnlySpanElement(byte[] array, int index)
        {
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
            return span[index];
        }

        private static byte GetPartialReadOnlySpanElement(byte[] array, int start, int length, int index)
        {
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array, start, length);
            return span[index];
        }

        private static byte GetEmptyReadOnlySpanElement(int index)
        {
            ReadOnlySpan<byte> span = ReadOnlySpan<byte>.Empty;
            return span[index];
        }

        private static byte GetNullReadOnlySpanElement(int index)
        {
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(null);
            return span[index];
        }

        private static byte GetSlicedReadOnlySpanElement(byte[] array, int sliceStart, int sliceLength, int index)
        {
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
            ReadOnlySpan<byte> sliced = span.Slice(sliceStart, sliceLength);
            return sliced[index];
        }

        private static byte GetStackAllocReadOnlySpanElement(int spanLength, int index)
        {
            ReadOnlySpan<byte> span = spanLength == 8
                ? stackalloc byte[8] { 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80 }
         : stackalloc byte[0];
            return span[index];
        }

        [TestMethod]
        public void PartialSpanIndexOutOfRangeExceptionTests()
        {
            // Test IndexOutOfRangeException with partial ReadOnlySpans
            byte[] array = new byte[20];
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array, 5, 10);

            // Should have length 10
            Assert.AreEqual(10, span.Length, "Partial ReadOnlySpan should have length 10");

            // Valid access
            byte value = span[0];
            value = span[9];

            // Invalid access - at boundary
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetPartialReadOnlySpanElement(array, 5, 10, 10);
            }, "Should throw IndexOutOfRangeException at index equal to partial span Length");

            // Invalid access - negative index
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetPartialReadOnlySpanElement(array, 5, 10, -1);
            }, "Should throw IndexOutOfRangeException at negative index in partial span");

            // Invalid access - beyond boundary
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetPartialReadOnlySpanElement(array, 5, 10, 15);
            }, "Should throw IndexOutOfRangeException at index beyond partial span Length");
        }

        [TestMethod]
        public void EmptySpanIndexOutOfRangeExceptionTests()
        {
            // Test IndexOutOfRangeException with empty ReadOnlySpans
            ReadOnlySpan<byte> emptySpan = ReadOnlySpan<byte>.Empty;

            Assert.AreEqual(0, emptySpan.Length, "Empty ReadOnlySpan should have length 0");

            // Any index access should throw
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetEmptyReadOnlySpanElement(0);
            }, "Should throw IndexOutOfRangeException on empty span at index 0");

            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetEmptyReadOnlySpanElement(-1);
            }, "Should throw IndexOutOfRangeException on empty span at negative index");

            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetEmptyReadOnlySpanElement(1);
            }, "Should throw IndexOutOfRangeException on empty span at index 1");
        }

        [TestMethod]
        public void NullArrayIndexOutOfRangeExceptionTests()
        {
            // Test IndexOutOfRangeException with null-based ReadOnlySpan
            ReadOnlySpan<byte> nullSpan = new ReadOnlySpan<byte>(null);

            Assert.AreEqual(0, nullSpan.Length, "ReadOnlySpan from null should have length 0");
            Assert.IsTrue(nullSpan.IsEmpty, "ReadOnlySpan from null should be empty");

            // Any index access should throw
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetNullReadOnlySpanElement(0);
            }, "Should throw IndexOutOfRangeException when accessing null-based span at index 0");

            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetNullReadOnlySpanElement(-1);
            }, "Should throw IndexOutOfRangeException when accessing null-based span at negative index");
        }

        [TestMethod]
        public void SlicedSpanIndexOutOfRangeExceptionTests()
        {
            // Test IndexOutOfRangeException with sliced ReadOnlySpans
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);
            ReadOnlySpan<byte> sliced = span.Slice(4, 8);

            // Should have length 8
            Assert.AreEqual(8, sliced.Length, "Sliced ReadOnlySpan should have length 8");

            // Valid access
            byte value = sliced[0];
            Assert.AreEqual((byte)0x04, value, "First element of slice should be 0x04");

            value = sliced[7];
            Assert.AreEqual((byte)0x0B, value, "Last element of slice should be 0x0B");

            // Invalid access at boundary
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetSlicedReadOnlySpanElement(array, 4, 8, 8);
            }, "Should throw IndexOutOfRangeException at sliced span boundary");

            // Invalid access beyond boundary
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetSlicedReadOnlySpanElement(array, 4, 8, 10);
            }, "Should throw IndexOutOfRangeException beyond sliced span boundary");

            // Invalid negative access
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetSlicedReadOnlySpanElement(array, 4, 8, -1);
            }, "Should throw IndexOutOfRangeException at negative index in sliced span");
        }

        [TestMethod]
        public void StackAllocIndexOutOfRangeExceptionTests()
        {
            // Test IndexOutOfRangeException with stack-allocated ReadOnlySpans
            ReadOnlySpan<byte> span = stackalloc byte[8] { 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80 };

            Assert.AreEqual(8, span.Length, "Stack-allocated ReadOnlySpan should have length 8");

            // Valid access
            byte value = span[0];
            Assert.AreEqual((byte)0x10, value, "First element should be 0x10");

            value = span[7];
            Assert.AreEqual((byte)0x80, value, "Last element should be 0x80");

            // Invalid access at boundary
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetStackAllocReadOnlySpanElement(8, 8);
            }, "Should throw IndexOutOfRangeException at stack-allocated span boundary");

            // Invalid negative access
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetStackAllocReadOnlySpanElement(8, -1);
            }, "Should throw IndexOutOfRangeException at negative index in stack-allocated span");
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

            // ReadOnlySpan from array initializer
            span = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD };

            Assert.AreEqual(span.Length, 4, "ReadOnlySpan from array initializer should have length of 4");
            Assert.IsFalse(span.IsEmpty, "ReadOnlySpan from array initializer should NOT be IsEmpty");
            Assert.AreEqual(span[0], (byte)0xAA, "First element should be 0xAA");
            Assert.AreEqual(span[1], (byte)0xBB, "Second element should be 0xBB");
            Assert.AreEqual(span[2], (byte)0xCC, "Third element should be 0xCC");
            Assert.AreEqual(span[3], (byte)0xDD, "Fourth element should be 0xDD");
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
        public void CopyToTests()
        {
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);

            // Copy to with the exact same size
            Span<byte> destination = new Span<byte>(new byte[span.Length]);
            span.CopyTo(destination);

            CollectionAssert.AreEqual(array, destination.ToArray(), "Original array and ReadOnlySpan.CopyTo should be the same");

            // Copy to a larger span
            destination = new Span<byte>(new byte[span.Length + 4]);
            span.CopyTo(destination);

            Assert.AreEqual(destination.Length, span.Length + 4, "Destination should maintain its original size");

            // Verify that the copied elements match
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual(span[i], destination[i], $"Element at index {i} should match after CopyTo");
            }

            // Verify that extra elements in destination remain zero
            for (int i = span.Length; i < destination.Length; i++)
            {
                Assert.AreEqual((byte)0, destination[i], $"Element at index {i} beyond copied range should remain zero");
            }
        }

        [TestMethod]
        public void CopyToEmptySpanTests()
        {
            // Empty ReadOnlySpan CopyTo empty Span
            ReadOnlySpan<byte> emptySource = ReadOnlySpan<byte>.Empty;
            Span<byte> emptyDestination = Span<byte>.Empty;

            emptySource.CopyTo(emptyDestination);

            Assert.AreEqual(0, emptyDestination.Length, "Empty destination should remain empty");

            // Empty ReadOnlySpan CopyTo larger Span
            Span<byte> largerDestination = new Span<byte>(new byte[5]);
            emptySource.CopyTo(largerDestination);

            Assert.AreEqual(5, largerDestination.Length, "Destination should maintain its size");

            // Verify all elements remain zero
            for (int i = 0; i < largerDestination.Length; i++)
            {
                Assert.AreEqual((byte)0, largerDestination[i], $"Element at index {i} should be zero");
            }
        }

        [TestMethod]
        public void CopyToPartialSpanTests()
        {
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            // Create a partial ReadOnlySpan
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array, 4, 8);

            // Copy to a span of exact size
            Span<byte> destination = new Span<byte>(new byte[8]);
            span.CopyTo(destination);

            // Verify copied elements
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual(span[i], destination[i], $"Element at index {i} should match");
                Assert.AreEqual(array[i + 4], destination[i], $"Element should match original array at offset");
            }
        }

        [TestMethod]
        public void CopyToSlicedSpanTests()
        {
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);

            // Slice the ReadOnlySpan and then copy
            ReadOnlySpan<byte> sliced = span.Slice(2, 6);
            Span<byte> destination = new Span<byte>(new byte[6]);

            sliced.CopyTo(destination);

            // Verify copied elements match the sliced portion
            for (int i = 0; i < sliced.Length; i++)
            {
                Assert.AreEqual(sliced[i], destination[i], $"Element at index {i} should match sliced span");
                Assert.AreEqual(array[i + 2], destination[i], $"Element should match original array at offset 2");
            }
        }

        [TestMethod]
        public void CopyToWithDestinationSliceTests()
        {
            byte[] array = new byte[8] { 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80 };
            ReadOnlySpan<byte> source = new ReadOnlySpan<byte>(array);

            // Create a larger destination and copy to a slice of it
            byte[] destArray = new byte[12];
            Span<byte> destination = new Span<byte>(destArray);
            Span<byte> destSlice = destination.Slice(2, 8);

            source.CopyTo(destSlice);

            // Verify first 2 elements remain zero
            Assert.AreEqual((byte)0, destArray[0], "Element before copied range should be zero");
            Assert.AreEqual((byte)0, destArray[1], "Element before copied range should be zero");

            // Verify copied elements
            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreEqual(source[i], destArray[i + 2], $"Copied element at index {i + 2} should match source");
            }

            // Verify last elements remain zero
            Assert.AreEqual((byte)0, destArray[10], "Element after copied range should be zero");
            Assert.AreEqual((byte)0, destArray[11], "Element after copied range should be zero");
        }

        [TestMethod]
        public void CopyToWithNullableArrayTests()
        {
            // Test that CopyTo works correctly when the internal _array field is nullable
            // Create ReadOnlySpan from null (tests nullable _array field)
            ReadOnlySpan<byte> nullSpan = new ReadOnlySpan<byte>(null);
            Span<byte> destination = new Span<byte>(new byte[5]);

            // CopyTo from empty span should not throw
            nullSpan.CopyTo(destination);

            // Verify destination remains unchanged (all zeros)
            for (int i = 0; i < destination.Length; i++)
            {
                Assert.AreEqual((byte)0, destination[i], $"Element at index {i} should be zero");
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
        public void StackAllocReadOnlySpanCopyToTests()
        {
            // Create a ReadOnlySpan from stack-allocated memory
            ReadOnlySpan<byte> source = stackalloc byte[8] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88 };

            // Create a destination Span
            Span<byte> destination = new Span<byte>(new byte[8]);

            // Copy from stack-allocated ReadOnlySpan to heap-allocated Span
            source.CopyTo(destination);

            // Verify the copy
            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreEqual(source[i], destination[i], $"Element at index {i} should match after CopyTo from stack-allocated span");
            }
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

            // Test equality with same content (content-based equality)
            Assert.IsTrue(span1 == span2, "ReadOnlySpans with same content should be equal");
            Assert.IsFalse(span1 != span2, "ReadOnlySpans with same content should not be not-equal");

            // Test inequality with different content
            Assert.IsTrue(span1 != span3, "ReadOnlySpans with different content should not be equal");
            Assert.IsFalse(span1 == span3, "ReadOnlySpans with different content should not be equal");

            // Test empty spans
            ReadOnlySpan<byte> empty1 = new ReadOnlySpan<byte>();
            ReadOnlySpan<byte> empty2 = new ReadOnlySpan<byte>();

            Assert.IsTrue(empty1 == empty2, "Empty ReadOnlySpans should be equal");
            Assert.IsFalse(empty1 != empty2, "Empty ReadOnlySpans should not be not-equal");
        }

        [TestMethod]
        public void EqualityWithPartialSpansTests()
        {
            byte[] array1 = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            byte[] array2 = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Create two spans from different arrays with same content
            ReadOnlySpan<byte> span1 = new ReadOnlySpan<byte>(array1, 2, 5);
            ReadOnlySpan<byte> span2 = new ReadOnlySpan<byte>(array2, 2, 5);

            // They should be equal (content-based equality)
            Assert.IsTrue(span1 == span2, "Partial spans with same content should be equal");
            Assert.IsFalse(span1 != span2, "Partial spans with same content should not be not-equal");

            // Create span from different array with different content
            byte[] array3 = new byte[10] { 0, 1, 2, 3, 99, 5, 6, 7, 8, 9 };
            ReadOnlySpan<byte> span3 = new ReadOnlySpan<byte>(array3, 2, 5);
            Assert.IsFalse(span1 == span3, "Partial spans with different content should not be equal");
            Assert.IsTrue(span1 != span3, "Partial spans with different content should be not-equal");

            // Create span with different length
            ReadOnlySpan<byte> span4 = new ReadOnlySpan<byte>(array1, 2, 4);
            Assert.IsFalse(span1 == span4, "Partial spans with different length should not be equal");
            Assert.IsTrue(span1 != span4, "Partial spans with different length should be not-equal");
        }

        [TestMethod]
        public void EqualityWithSlicedSpansTests()
        {
            byte[] array1 = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            byte[] array2 = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            ReadOnlySpan<byte> originalSpan1 = new ReadOnlySpan<byte>(array1);
            ReadOnlySpan<byte> originalSpan2 = new ReadOnlySpan<byte>(array2);

            // Create two slices from different arrays with same content
            ReadOnlySpan<byte> slice1 = originalSpan1.Slice(2, 5);
            ReadOnlySpan<byte> slice2 = originalSpan2.Slice(2, 5);

            // They should be equal (content-based equality)
            Assert.IsTrue(slice1 == slice2, "Slices with same content should be equal");
            Assert.IsFalse(slice1 != slice2, "Slices with same content should not be not-equal");

            // Create a slice with different content
            byte[] array3 = new byte[10] { 0, 1, 2, 99, 4, 5, 6, 7, 8, 9 };
            ReadOnlySpan<byte> originalSpan3 = new ReadOnlySpan<byte>(array3);
            ReadOnlySpan<byte> slice3 = originalSpan3.Slice(2, 5);
            Assert.IsFalse(slice1 == slice3, "Slices with different content should not be equal");

            // Create a slice with different length
            ReadOnlySpan<byte> slice4 = originalSpan1.Slice(2, 4);
            Assert.IsFalse(slice1 == slice4, "Slices with different length should not be equal");
        }

        [TestMethod]
        public void EqualityWithNullArrayTests()
        {
            // Test equality with null-backed spans
            ReadOnlySpan<byte> nullSpan1 = new ReadOnlySpan<byte>(null);
            ReadOnlySpan<byte> nullSpan2 = new ReadOnlySpan<byte>(null);
            ReadOnlySpan<byte> nullSpan3 = new ReadOnlySpan<byte>(null, 0, 0);

            // All null-backed spans should be equal (both are empty)
            Assert.IsTrue(nullSpan1 == nullSpan2, "Null-backed spans should be equal");
            Assert.IsTrue(nullSpan1 == nullSpan3, "Null-backed spans with explicit 0,0 should be equal");
            Assert.IsFalse(nullSpan1 != nullSpan2, "Null-backed spans should not be not-equal");

            // Compare with Empty
            ReadOnlySpan<byte> emptySpan = ReadOnlySpan<byte>.Empty;
            Assert.IsTrue(nullSpan1 == emptySpan, "Null-backed span should equal Empty span");
        }

        [TestMethod]
        public void EqualityContentBasedTests()
        {
            // Create two arrays with identical content but different references
            byte[] array1 = new byte[5] { 10, 20, 30, 40, 50 };
            byte[] array2 = new byte[5] { 10, 20, 30, 40, 50 };

            ReadOnlySpan<byte> span1 = new ReadOnlySpan<byte>(array1);
            ReadOnlySpan<byte> span2 = new ReadOnlySpan<byte>(array2);

            // ReadOnlySpans with same content should be equal (content-based equality)
            Assert.IsTrue(span1 == span2, "ReadOnlySpans with same content should be equal");
            Assert.IsFalse(span1 != span2, "ReadOnlySpans with same content should not be not-equal");

            // Now create another span from array1
            ReadOnlySpan<byte> span1Copy = new ReadOnlySpan<byte>(array1);
            Assert.IsTrue(span1 == span1Copy, "ReadOnlySpans from same array should be equal");

            // Modify array1 content
            array1[2] = 99;

            // Spans should no longer be equal because content changed
            Assert.IsFalse(span1 == span2, "ReadOnlySpans should not be equal after content changes");
            Assert.IsTrue(span1 != span2, "ReadOnlySpans should be not-equal after content changes");

            // But span1 and span1Copy still reference the same array so should see same content
            Assert.IsTrue(span1 == span1Copy, "ReadOnlySpans from same array should remain equal");
        }

        [TestMethod]
        public void EqualityWithStackAllocatedSpansTests()
        {
            // Stack-allocated spans with same content should be equal
            ReadOnlySpan<byte> stackSpan1 = stackalloc byte[5] { 1, 2, 3, 4, 5 };
            ReadOnlySpan<byte> stackSpan2 = stackalloc byte[5] { 1, 2, 3, 4, 5 };

            // Stack-allocated spans with identical content should be equal (content-based)
            Assert.IsTrue(stackSpan1 == stackSpan2, "Stack-allocated spans with same content should be equal");
            Assert.IsFalse(stackSpan1 != stackSpan2, "Stack-allocated spans with same content should not be not-equal");

            // Stack-allocated spans with different content should not be equal
            ReadOnlySpan<byte> stackSpan3 = stackalloc byte[5] { 1, 2, 99, 4, 5 };
            Assert.IsFalse(stackSpan1 == stackSpan3, "Stack-allocated spans with different content should not be equal");
            Assert.IsTrue(stackSpan1 != stackSpan3, "Stack-allocated spans with different content should be not-equal");

            // Create a "copy" reference to the same stack span
            ReadOnlySpan<byte> stackSpan1Copy = stackSpan1;
            Assert.IsTrue(stackSpan1 == stackSpan1Copy, "Same stack-allocated span should equal itself");
        }

        [TestMethod]
        public void EqualityTransitivityTests()
        {
            byte[] array1 = new byte[5] { 1, 2, 3, 4, 5 };
            byte[] array2 = new byte[5] { 1, 2, 3, 4, 5 };
            byte[] array3 = new byte[5] { 1, 2, 3, 4, 5 };

            ReadOnlySpan<byte> span1 = new ReadOnlySpan<byte>(array1);
            ReadOnlySpan<byte> span2 = new ReadOnlySpan<byte>(array2);
            ReadOnlySpan<byte> span3 = new ReadOnlySpan<byte>(array3);

            // Test transitivity: if span1 == span2 and span2 == span3, then span1 == span3
            Assert.IsTrue(span1 == span2, "span1 should equal span2");
            Assert.IsTrue(span2 == span3, "span2 should equal span3");
            Assert.IsTrue(span1 == span3, "span1 should equal span3 (transitivity)");
        }

        [TestMethod]
        public void EqualityReflexivityTests()
        {
            byte[] array = new byte[5] { 1, 2, 3, 4, 5 };
            ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(array);

            // Test reflexivity: span should equal itself
            Assert.IsTrue(span == span, "ReadOnlySpan should equal itself (reflexivity)");
            Assert.IsFalse(span != span, "ReadOnlySpan should not be not-equal to itself");

            // Test with empty span
            ReadOnlySpan<byte> emptySpan = ReadOnlySpan<byte>.Empty;
            Assert.IsTrue(emptySpan == emptySpan, "Empty ReadOnlySpan should equal itself");
        }

        [TestMethod]
        public void EqualitySymmetryTests()
        {
            byte[] array1 = new byte[5] { 1, 2, 3, 4, 5 };
            byte[] array2 = new byte[5] { 1, 2, 3, 4, 5 };
            byte[] array3 = new byte[5] { 1, 2, 99, 4, 5 };

            ReadOnlySpan<byte> span1 = new ReadOnlySpan<byte>(array1);
            ReadOnlySpan<byte> span2 = new ReadOnlySpan<byte>(array2);
            ReadOnlySpan<byte> span3 = new ReadOnlySpan<byte>(array3);

            // Test symmetry: if span1 == span2, then span2 == span1
            Assert.IsTrue(span1 == span2, "span1 should equal span2");
            Assert.IsTrue(span2 == span1, "span2 should equal span1 (symmetry)");

            // Test symmetry with inequality
            Assert.IsFalse(span1 == span3, "span1 should not equal span3");
            Assert.IsFalse(span3 == span1, "span3 should not equal span1 (symmetry)");
        }

        [TestMethod]
        public void EqualityWithDifferentOffsetsTests()
        {
            byte[] array = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Create spans with overlapping but different regions
            ReadOnlySpan<byte> span1 = new ReadOnlySpan<byte>(array, 2, 5); // [2,3,4,5,6]
            ReadOnlySpan<byte> span2 = new ReadOnlySpan<byte>(array, 3, 5); // [3,4,5,6,7]

            // They have different content so should not be equal
            Assert.IsFalse(span1 == span2, "ReadOnlySpans with different content should not be equal");
            Assert.IsTrue(span1 != span2, "ReadOnlySpans with different content should be not-equal");

            // Create span with same content from different array
            byte[] array2 = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ReadOnlySpan<byte> span3 = new ReadOnlySpan<byte>(array2, 2, 5);
            Assert.IsTrue(span1 == span3, "ReadOnlySpans with same content should be equal");
        }

        [TestMethod]
        public void EqualityZeroLengthSpansTests()
        {
            byte[] array1 = new byte[10];
            byte[] array2 = new byte[10];

            // Create zero-length spans from different arrays
            ReadOnlySpan<byte> zeroSpan1 = new ReadOnlySpan<byte>(array1, 5, 0);
            ReadOnlySpan<byte> zeroSpan2 = new ReadOnlySpan<byte>(array2, 3, 0);

            // Zero-length spans should be equal (both empty, content-based)
            Assert.IsTrue(zeroSpan1 == zeroSpan2, "Zero-length spans should be equal");
            Assert.IsFalse(zeroSpan1 != zeroSpan2, "Zero-length spans should not be not-equal");

            // Zero-length span from same array with different offset
            ReadOnlySpan<byte> zeroSpan3 = new ReadOnlySpan<byte>(array1, 7, 0);
            Assert.IsTrue(zeroSpan1 == zeroSpan3, "Zero-length spans should be equal regardless of offset");

            // Compare with Empty
            ReadOnlySpan<byte> emptySpan = ReadOnlySpan<byte>.Empty;
            Assert.IsTrue(zeroSpan1 == emptySpan, "Zero-length span should equal Empty span");
        }

        [TestMethod]
        public void EqualityDifferentLengthsTests()
        {
            byte[] array1 = new byte[6] { 1, 2, 3, 4, 5, 6 };
            byte[] array2 = new byte[4] { 1, 2, 3, 4 };

            ReadOnlySpan<byte> span1 = new ReadOnlySpan<byte>(array1);
            ReadOnlySpan<byte> span2 = new ReadOnlySpan<byte>(array2);

            // Spans with different lengths should not be equal
            Assert.IsFalse(span1 == span2, "ReadOnlySpans with different lengths should not be equal");
            Assert.IsTrue(span1 != span2, "ReadOnlySpans with different lengths should be not-equal");

            // Test with partial spans that have same initial content but different lengths
            byte[] array3 = new byte[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ReadOnlySpan<byte> span3 = new ReadOnlySpan<byte>(array3, 0, 4);
            ReadOnlySpan<byte> span4 = new ReadOnlySpan<byte>(array3, 0, 6);

            Assert.IsFalse(span3 == span4, "Partial spans with different lengths should not be equal");
        }

        [TestMethod]
        public void EqualityPartialContentMatchTests()
        {
            // Test equality when only part of the content matches
            byte[] array1 = new byte[5] { 1, 2, 3, 4, 5 };
            byte[] array2 = new byte[5] { 1, 2, 99, 4, 5 };

            ReadOnlySpan<byte> span1 = new ReadOnlySpan<byte>(array1);
            ReadOnlySpan<byte> span2 = new ReadOnlySpan<byte>(array2);

            // Should not be equal (one element differs)
            Assert.IsFalse(span1 == span2, "ReadOnlySpans with partial content match should not be equal");
            Assert.IsTrue(span1 != span2, "ReadOnlySpans with partial content match should be not-equal");

            // Test with matching prefix
            ReadOnlySpan<byte> span1Prefix = span1.Slice(0, 2);
            ReadOnlySpan<byte> span2Prefix = span2.Slice(0, 2);
            Assert.IsTrue(span1Prefix == span2Prefix, "ReadOnlySpans with matching prefix should be equal");

            // Test with matching suffix
            ReadOnlySpan<byte> span1Suffix = span1.Slice(3, 2);
            ReadOnlySpan<byte> span2Suffix = span2.Slice(3, 2);
            Assert.IsTrue(span1Suffix == span2Suffix, "ReadOnlySpans with matching suffix should be equal");
        }
    }
}
