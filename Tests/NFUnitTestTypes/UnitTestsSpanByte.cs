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
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                Span<byte> span = new Span<byte>(array);
                _ = span[span.Length];
            }, "IndexOutOfRangeException when accessing index equal to Length");

            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                Span<byte> span = new Span<byte>(array);
                _ = span[-1];
            }, "IndexOutOfRangeException when accessing negative index");

            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                Span<byte> span = new Span<byte>(array);
                _ = span[span.Length + 1];
            }, "IndexOutOfRangeException when accessing index beyond Length");

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
        public void IndexOutOfRangeExceptionTests()
        {
            // Comprehensive tests for IndexOutOfRangeException
            byte[] array = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Span<byte> span = new Span<byte>(array);

            // Test reading at exact boundary
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetSpanElement(array, 10);
            }, "Should throw IndexOutOfRangeException at index equal to Length");

            // Test reading beyond boundary
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetSpanElement(array, 100);
            }, "Should throw IndexOutOfRangeException at large index");

            // Test negative index
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetSpanElement(array, -1);
            }, "Should throw IndexOutOfRangeException at negative index");

            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetSpanElement(array, -100);
            }, "Should throw IndexOutOfRangeException at large negative index");

            // Test writing at exact boundary
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                SetSpanElement(array, 10, 99);
            }, "Should throw IndexOutOfRangeException when writing at index equal to Length");

            // Test writing beyond boundary
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                SetSpanElement(array, 100, 99);
            }, "Should throw IndexOutOfRangeException when writing at large index");

            // Test writing at negative index
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                SetSpanElement(array, -1, 99);
            }, "Should throw IndexOutOfRangeException when writing at negative index");

            // Valid access should not throw
            byte value = span[0];
            Assert.AreEqual((byte)0, value, "Valid index 0 should return correct value");

            value = span[9];
            Assert.AreEqual((byte)9, value, "Valid index 9 should return correct value");

            span[5] = 99;
            Assert.AreEqual((byte)99, span[5], "Valid write should succeed");
        }

        // Helper methods to avoid capturing ref struct in lambdas
        private static byte GetSpanElement(byte[] array, int index)
        {
            Span<byte> span = new Span<byte>(array);
            return span[index];
        }

        private static void SetSpanElement(byte[] array, int index, byte value)
        {
            Span<byte> span = new Span<byte>(array);
            span[index] = value;
        }

        private static byte GetPartialSpanElement(byte[] array, int start, int length, int index)
        {
            Span<byte> span = new Span<byte>(array, start, length);
            return span[index];
        }

        private static byte GetEmptySpanElement(int index)
        {
            Span<byte> span = Span<byte>.Empty;
            return span[index];
        }

        private static void SetEmptySpanElement(int index, byte value)
        {
            Span<byte> span = Span<byte>.Empty;
            span[index] = value;
        }

        private static byte GetNullSpanElement(int index)
        {
            Span<byte> span = new Span<byte>(null);
            return span[index];
        }

        [TestMethod]
        public void PartialSpanIndexOutOfRangeExceptionTests()
        {
            // Test IndexOutOfRangeException with partial spans
            byte[] array = new byte[20];
            Span<byte> span = new Span<byte>(array, 5, 10);

            // Should have length 10
            Assert.AreEqual(10, span.Length, "Partial span should have length 10");

            // Valid access
            byte value = span[0];
            span[0] = 1;
            value = span[9];
            span[9] = 1;

            // Invalid access
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetPartialSpanElement(array, 5, 10, 10);
            }, "Should throw IndexOutOfRangeException at index equal to partial span Length");

            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetPartialSpanElement(array, 5, 10, -1);
            }, "Should throw IndexOutOfRangeException at negative index in partial span");
        }

        [TestMethod]
        public void EmptySpanIndexOutOfRangeExceptionTests()
        {
            // Test IndexOutOfRangeException with empty spans
            Span<byte> emptySpan = Span<byte>.Empty;

            Assert.AreEqual(0, emptySpan.Length, "Empty span should have length 0");

            // Any index access should throw
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetEmptySpanElement(0);
            }, "Should throw IndexOutOfRangeException on empty span at index 0");

            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetEmptySpanElement(-1);
            }, "Should throw IndexOutOfRangeException on empty span at negative index");

            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                SetEmptySpanElement(0, 1);
            }, "Should throw IndexOutOfRangeException when writing to empty span");
        }

        [TestMethod]
        public void NullableArrayFieldTests()
        {
            // Test that nullable _array field works correctly

            // Span from null array (tests nullable _array field)
            Span<byte> nullSpan = new Span<byte>(null);
            Assert.AreEqual(0, nullSpan.Length, "Span from null should have length 0");
            Assert.IsTrue(nullSpan.IsEmpty, "Span from null should be empty");

            // Span from null with zero start and length
            nullSpan = new Span<byte>(null, 0, 0);
            Assert.AreEqual(0, nullSpan.Length, "Span from null with 0,0 should have length 0");
            Assert.IsTrue(nullSpan.IsEmpty, "Span from null with 0,0 should be empty");

            // Try to access element in empty span (should throw)
            Assert.ThrowsException(typeof(IndexOutOfRangeException), () =>
            {
                _ = GetNullSpanElement(0);
            }, "Should throw IndexOutOfRangeException when accessing null-based span");

            // Copy from null-based span should work
            Span<byte> destination = new Span<byte>(new byte[5]);
            nullSpan.CopyTo(destination); // Should not throw

            // ToArray should work
            byte[] array = nullSpan.ToArray();
            Assert.AreEqual(0, array.Length, "ToArray on null-based span should return empty array");

            // Clear should work (no-op on empty span)
            nullSpan.Clear(); // Should not throw

            // Slice should work
            Span<byte> sliced = nullSpan.Slice(0);
            Assert.AreEqual(0, sliced.Length, "Slicing null-based span should return empty span");
        }

        [TestMethod]
        public void ClearWithNullableArrayTests()
        {
            // Clear on empty span (null array)
            Span<byte> emptySpan = new Span<byte>(null);
            emptySpan.Clear(); // Should not throw
            Assert.IsTrue(emptySpan.IsEmpty, "Empty span should remain empty after Clear");

            // Clear on normal span
            byte[] array = new byte[5] { 1, 2, 3, 4, 5 };
            Span<byte> span = new Span<byte>(array);
            span.Clear();

            // Verify all elements are cleared
            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual((byte)0, span[i], $"Element at index {i} should be 0 after Clear");
                Assert.AreEqual((byte)0, array[i], $"Original array element at index {i} should be 0 after Clear");
            }
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
        public void ToArrayWithNullableArrayTests()
        {
            // Test ToArray with nullable array field

            // Empty span from null
            Span<byte> emptySpan = new Span<byte>(null);
            byte[] emptyArray = emptySpan.ToArray();
            Assert.AreEqual(0, emptyArray.Length, "ToArray on null-based span should return empty array");

            // Partial span
            byte[] array = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Span<byte> partialSpan = new Span<byte>(array, 3, 5);
            byte[] partialArray = partialSpan.ToArray();

            Assert.AreEqual(5, partialArray.Length, "Partial span ToArray should have correct length");
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(array[i + 3], partialArray[i], $"Partial array element {i} should match");
            }
        }

        [TestMethod]
        public void ConstructorsOfAllKindsTests()
        {
            // Empty span
            Span<byte> span = new Span<byte>();

            Assert.AreEqual(span.Length, 0, "Empty SpanByte should have length of 0");
            Assert.IsTrue(span.IsEmpty, "Empty SpanByte should be IsEmpty");

            // Empty span from null with zero start and length (tests nullable _array)
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

            // Span<byte> from array initializer
            span = new byte[] { 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19 };

            Assert.AreEqual(span.Length, 10, $"SpanByte should have length of 10");
            Assert.IsFalse(span.IsEmpty, "Span<byte> should NOT be IsEmpty");

            Assert.AreEqual(span[0], (byte)0x10, "First element must be value 0x10");
            Assert.AreEqual(span[1], (byte)0x11, "Second element must be value 0x11");
            Assert.AreEqual(span[5], (byte)0x15, "Sixth element must be value 0x15");
            Assert.AreEqual(span[9], (byte)0x19, "Last element must be value 0x19");
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
        public void ImplicitConversionToReadOnlySpanTests()
        {
            // Test implicit conversion from Span to ReadOnlySpan
            byte[] array = new byte[8] { 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80 };
            Span<byte> span = new Span<byte>(array);

            // Implicit conversion
            ReadOnlySpan<byte> readOnlySpan = span;

            Assert.AreEqual(span.Length, readOnlySpan.Length, "Converted ReadOnlySpan should have same length");

            for (int i = 0; i < span.Length; i++)
            {
                Assert.AreEqual(span[i], readOnlySpan[i], $"Element at index {i} should match after conversion");
            }

            // Test with empty span
            Span<byte> emptySpan = Span<byte>.Empty;
            ReadOnlySpan<byte> emptyReadOnly = emptySpan;
            Assert.AreEqual(0, emptyReadOnly.Length, "Converted empty ReadOnlySpan should have length 0");
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

        [TestMethod]
        public void EqualityOperatorTests()
        {
            byte[] array1 = new byte[4] { 0x01, 0x02, 0x03, 0x04 };
            byte[] array2 = new byte[4] { 0x01, 0x02, 0x03, 0x04 };

            Span<byte> span1 = new Span<byte>(array1);
            Span<byte> span2 = new Span<byte>(array2);
            Span<byte> span1Again = new Span<byte>(array1);

            // Test equality - should check reference and length, not content
            Assert.IsTrue(span1 == span1Again, "Spans pointing to same array should be equal");
            Assert.IsFalse(span1 == span2, "Spans pointing to different arrays should not be equal");

            // Test inequality
            Assert.IsFalse(span1 != span1Again, "Spans pointing to same array should not be not-equal");
            Assert.IsTrue(span1 != span2, "Spans pointing to different arrays should be not-equal");

            // Test with different lengths on same array
            Span<byte> span1Partial = new Span<byte>(array1, 0, 2);
            Assert.IsFalse(span1 == span1Partial, "Spans with different lengths should not be equal");
            Assert.IsTrue(span1 != span1Partial, "Spans with different lengths should be not-equal");

            // Test empty spans
            Span<byte> empty1 = new Span<byte>();
            Span<byte> empty2 = new Span<byte>();
            Assert.IsTrue(empty1 == empty2, "Empty spans should be equal");
            Assert.IsFalse(empty1 != empty2, "Empty spans should not be not-equal");
        }

        [TestMethod]
        public void EqualityWithPartialSpansTests()
        {
            byte[] array = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Create two spans from the same array with same start and length
            Span<byte> span1 = new Span<byte>(array, 2, 5);
            Span<byte> span2 = new Span<byte>(array, 2, 5);

            // They should be equal (same array, same start, same length)
            Assert.IsTrue(span1 == span2, "Partial spans from same array with same parameters should be equal");
            Assert.IsFalse(span1 != span2, "Partial spans from same array with same parameters should not be not-equal");

            // Create span from same array but different start
            Span<byte> span3 = new Span<byte>(array, 3, 5);
            Assert.IsFalse(span1 == span3, "Partial spans with different start should not be equal");
            Assert.IsTrue(span1 != span3, "Partial spans with different start should be not-equal");

            // Create span from same array but different length
            Span<byte> span4 = new Span<byte>(array, 2, 4);
            Assert.IsFalse(span1 == span4, "Partial spans with different length should not be equal");
            Assert.IsTrue(span1 != span4, "Partial spans with different length should be not-equal");
        }

        [TestMethod]
        public void EqualityWithSlicedSpansTests()
        {
            byte[] array = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Span<byte> originalSpan = new Span<byte>(array);

            // Create two slices from the same original span
            Span<byte> slice1 = originalSpan.Slice(2, 5);
            Span<byte> slice2 = originalSpan.Slice(2, 5);

            // They should be equal (same underlying array, same region)
            Assert.IsTrue(slice1 == slice2, "Slices from same span with same parameters should be equal");

            // Create a slice with different parameters
            Span<byte> slice3 = originalSpan.Slice(3, 5);
            Assert.IsFalse(slice1 == slice3, "Slices with different start should not be equal");

            // Create a slice with different length
            Span<byte> slice4 = originalSpan.Slice(2, 4);
            Assert.IsFalse(slice1 == slice4, "Slices with different length should not be equal");
        }

        [TestMethod]
        public void EqualityWithNullArrayTests()
        {
            // Test equality with null-backed spans
            Span<byte> nullSpan1 = new Span<byte>(null);
            Span<byte> nullSpan2 = new Span<byte>(null);
            Span<byte> nullSpan3 = new Span<byte>(null, 0, 0);

            // All null-backed spans should be equal
            Assert.IsTrue(nullSpan1 == nullSpan2, "Null-backed spans should be equal");
            Assert.IsTrue(nullSpan1 == nullSpan3, "Null-backed spans with explicit 0,0 should be equal");
            Assert.IsFalse(nullSpan1 != nullSpan2, "Null-backed spans should not be not-equal");

            // Compare with Empty
            Span<byte> emptySpan = Span<byte>.Empty;
            Assert.IsTrue(nullSpan1 == emptySpan, "Null-backed span should equal Empty span");
        }

        [TestMethod]
        public void EqualityReferenceVsContentTests()
        {
            // Create two arrays with identical content
            byte[] array1 = new byte[5] { 10, 20, 30, 40, 50 };
            byte[] array2 = new byte[5] { 10, 20, 30, 40, 50 };

            Span<byte> span1 = new Span<byte>(array1);
            Span<byte> span2 = new Span<byte>(array2);

            // Even though content is identical, spans should not be equal
            // because they reference different arrays
            Assert.IsFalse(span1 == span2, "Spans with same content but different arrays should not be equal");
            Assert.IsTrue(span1 != span2, "Spans with same content but different arrays should be not-equal");

            // Now create another span from array1
            Span<byte> span1Copy = new Span<byte>(array1);
            Assert.IsTrue(span1 == span1Copy, "Spans referencing the same array should be equal");
            Assert.IsFalse(span1 != span1Copy, "Spans referencing the same array should not be not-equal");

            // Modify array1 content
            array1[2] = 99;

            // Spans should still be equal because they reference the same array
            Assert.IsTrue(span1 == span1Copy, "Spans referencing same array should remain equal even after content changes");
        }

        [TestMethod]
        public void EqualityWithStackAllocatedSpansTests()
        {
            // Stack-allocated spans are backed by different memory locations
            Span<byte> stackSpan1 = stackalloc byte[5] { 1, 2, 3, 4, 5 };
            Span<byte> stackSpan2 = stackalloc byte[5] { 1, 2, 3, 4, 5 };

            // Stack-allocated spans should not be equal (different memory locations)
            Assert.IsFalse(stackSpan1 == stackSpan2, "Different stack-allocated spans should not be equal");
            Assert.IsTrue(stackSpan1 != stackSpan2, "Different stack-allocated spans should be not-equal");

            // Create a "copy" reference to the same stack span
            Span<byte> stackSpan1Copy = stackSpan1;
            Assert.IsTrue(stackSpan1 == stackSpan1Copy, "Same stack-allocated span should equal itself");
            Assert.IsFalse(stackSpan1 != stackSpan1Copy, "Same stack-allocated span should not be not-equal to itself");
        }

        [TestMethod]
        public void EqualityTransitivityTests()
        {
            byte[] array = new byte[5] { 1, 2, 3, 4, 5 };

            Span<byte> span1 = new Span<byte>(array);
            Span<byte> span2 = new Span<byte>(array);
            Span<byte> span3 = new Span<byte>(array);

            // Test transitivity: if span1 == span2 and span2 == span3, then span1 == span3
            Assert.IsTrue(span1 == span2, "span1 should equal span2");
            Assert.IsTrue(span2 == span3, "span2 should equal span3");
            Assert.IsTrue(span1 == span3, "span1 should equal span3 (transitivity)");
        }

        [TestMethod]
        public void EqualityReflexivityTests()
        {
            byte[] array = new byte[5] { 1, 2, 3, 4, 5 };
            Span<byte> span = new Span<byte>(array);

            // Test reflexivity: span should equal itself
            Assert.IsTrue(span == span, "Span should equal itself (reflexivity)");
            Assert.IsFalse(span != span, "Span should not be not-equal to itself");

            // Test with empty span
            Span<byte> emptySpan = Span<byte>.Empty;
            Assert.IsTrue(emptySpan == emptySpan, "Empty span should equal itself");
        }

        [TestMethod]
        public void EqualitySymmetryTests()
        {
            byte[] array1 = new byte[5] { 1, 2, 3, 4, 5 };
            byte[] array2 = new byte[5] { 1, 2, 3, 4, 5 };

            Span<byte> span1 = new Span<byte>(array1);
            Span<byte> span2 = new Span<byte>(array2);

            // Test symmetry: if span1 == span2, then span2 == span1
            bool forward = span1 == span2;
            bool backward = span2 == span1;
            Assert.AreEqual(forward, backward, "Equality should be symmetric");

            // Test with same array
            Span<byte> span1Copy = new Span<byte>(array1);
            Assert.IsTrue(span1 == span1Copy, "span1 should equal span1Copy");
            Assert.IsTrue(span1Copy == span1, "span1Copy should equal span1 (symmetry)");
        }

        [TestMethod]
        public void EqualityWithDifferentOffsetsTests()
        {
            byte[] array = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Create spans with overlapping but different regions
            Span<byte> span1 = new Span<byte>(array, 2, 5); // [2,3,4,5,6]
            Span<byte> span2 = new Span<byte>(array, 3, 5); // [3,4,5,6,7]

            // Even though they overlap and have the same length, they should not be equal
            Assert.IsFalse(span1 == span2, "Spans with different offsets should not be equal");
            Assert.IsTrue(span1 != span2, "Spans with different offsets should be not-equal");

            // Create span with same offset and length
            Span<byte> span3 = new Span<byte>(array, 2, 5);
            Assert.IsTrue(span1 == span3, "Spans with same array, offset, and length should be equal");
        }

        [TestMethod]
        public void EqualityZeroLengthSpansTests()
        {
            byte[] array1 = new byte[10];
            byte[] array2 = new byte[10];

            // Create zero-length spans from different arrays
            Span<byte> zeroSpan1 = new Span<byte>(array1, 5, 0);
            Span<byte> zeroSpan2 = new Span<byte>(array2, 3, 0);

            // Zero-length spans from different arrays should not be equal
            Assert.IsFalse(zeroSpan1 == zeroSpan2, "Zero-length spans from different arrays should not be equal");

            // Zero-length spans from same array should be equal only if they have the same parameters
            Span<byte> zeroSpan3 = new Span<byte>(array1, 5, 0);
            Assert.IsTrue(zeroSpan1 == zeroSpan3, "Zero-length spans from same array with same offset should be equal");

            // Compare with Empty
            Span<byte> emptySpan = Span<byte>.Empty;
            Assert.IsFalse(zeroSpan1 == emptySpan, "Zero-length span from array should not equal Empty span (different backing)");
        }
    }
}
