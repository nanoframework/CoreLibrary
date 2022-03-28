//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;

namespace NFUnitTestTypes
{
    [TestClass]
    public class UnitTestsSpanByte
    {
        [TestMethod]
        public void EmptySpanTests()
        {
            // Empty span
            SpanByte span = SpanByte.Empty;
            // Create a destination span larger
            SpanByte destination = new byte[1];
            span.CopyTo(destination);

            // Now also empty
            destination = SpanByte.Empty;
            span.CopyTo(destination);
        }

        [TestMethod]
        public void RaisingExceptionsOfAllKindsTests()
        {
            // Should raise an exception on creation
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { SpanByte span = new SpanByte(null, 1, 2); }, "ArgumentOutOfRangeException when array is null, start is 1 and length is 2");
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { SpanByte span = new SpanByte(new byte[1], 1, 2); }, "ArgumentOutOfRangeException when array is new byte[1], start is 1 and length is 2");
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { SpanByte span = new SpanByte(new byte[1], 0, 2); }, "ArgumentOutOfRangeException when array is new byte[1], start is 0 and length is 2");
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { SpanByte span = new SpanByte(new byte[1], 2, 0); }, "ArgumentOutOfRangeException when array is new byte[1], start is 2 and length is 0");

            // Exception on index access
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            Assert.Throws(typeof(ArgumentOutOfRangeException), () =>
            {
                SpanByte span = new SpanByte(array);
                var data = span[span.Length];
            });
            Assert.Throws(typeof(IndexOutOfRangeException), () =>
            {
                SpanByte span = new SpanByte(array);
                var data = span[-1];
            });

            // Copy to with too small destination
            Assert.Throws(typeof(ArgumentException), () =>
            {
                SpanByte span = new SpanByte(array);
                SpanByte destination = new byte[span.Length - 1];
                span.CopyTo(destination);
            });

            // Slicing arguments
            Assert.Throws(typeof(ArgumentOutOfRangeException), () =>
            {
                SpanByte span = new SpanByte(array);
                var sliced = span.Slice(span.Length + 1);
            });
            Assert.Throws(typeof(ArgumentOutOfRangeException), () =>
            {
                SpanByte span = new SpanByte(array);
                var sliced = span.Slice(1, span.Length);
            });

            Assert.Throws(typeof(ArgumentOutOfRangeException), () =>
            {
                SpanByte span = new SpanByte(array);
                var sliced = span.Slice(-1, span.Length);
            });

            Assert.Throws(typeof(ArgumentOutOfRangeException), () =>
            {
                SpanByte span = new SpanByte(array);
                var sliced = span.Slice(1, -1);
            });

        }

        [TestMethod]
        public void ToArrayTest()
        {
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            SpanByte span = new SpanByte(array);
            byte[] toArray = span.ToArray();
            Assert.Equal(array, toArray, "Original array and SpanByte.ToArray should be the same");
        }

        [TestMethod]
        public void ConstructorsOfAllKindsTests()
        {
            // Empty span
            SpanByte span = new SpanByte();
            Assert.Equal(span.Length, 0, "Empty SpanByte should have length of 0");
            Assert.True(span.IsEmpty, "Empty SpanByte should be IsEmpty");

            // Empty span
            span = new SpanByte(null, 0, 0);
            Assert.Equal(span.Length, 0, "Empty SpanByte should have length of 0");
            Assert.True(span.IsEmpty, "Empty SpanByte should be IsEmpty");

            // Empty span
            span = SpanByte.Empty;
            Assert.Equal(span.Length, 0, "Empty SpanByte should have length of 0");
            Assert.True(span.IsEmpty, "Empty SpanByte should be IsEmpty");

            // Span from normal array
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            span = new SpanByte(array);
            Assert.Equal(span.Length, array.Length, $"SpanByte should have length of the array it takes: {array.Length}");
            Assert.False(span.IsEmpty, "SpanByte should NOT be IsEmpty");

            // Span from normal array with different start and length
            span = new SpanByte(array, 2, 8);
            Assert.Equal(span.Length, 8, $"SpanByte should have length of 8");
            Assert.False(span.IsEmpty, "SpanByte should NOT be IsEmpty");
        }

        [TestMethod]
        public void SliceTests()
        {
            // Span from normal array
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            SpanByte span = new SpanByte(array);
            // Slice 2 elements and check
            var sliced = span.Slice(0, 2);
            Assert.Equal(sliced.Length, 2, "Sliced span lenght must be 2");
            Assert.Equal(sliced[0], (byte)0x00, "Sliced first element must be value 0");
            Assert.Equal(sliced[1], (byte)0x01, "Sliced first element must be value 1");

            // Slide 4 elements starting at index 2 and check
            sliced = span.Slice(2, 4);
            Assert.Equal(sliced.Length, 4, "Sliced span lenght must be 4");
            Assert.Equal(sliced[0], (byte)0x02, "Sliced first element must be value 2");
            Assert.Equal(sliced[1], (byte)0x03, "Sliced first element must be value 3");
            Assert.Equal(sliced[2], (byte)0x04, "Sliced first element must be value 4");
            Assert.Equal(sliced[3], (byte)0x05, "Sliced first element must be value 5");

            // Slide starting 4 at element check
            sliced = span.Slice(4);
            Assert.Equal(sliced.Length, 12, "Sliced span lenght must be 12");
            for (int i = 0; i < sliced.Length; i++)
            {
                Assert.Equal(sliced[i], span[i + 4], "SpanByte value should be the same as from the original span");
            }

            // Slice of slice
            var secondSliced = sliced.Slice(2, 4);
            Assert.Equal(secondSliced.Length, 4, "Sliced span lenght must be 12");
            for (int i = 0; i < secondSliced.Length; i++)
            {
                Assert.Equal(secondSliced[i], sliced[i + 2], "SpanByte value should be the same as from the original span");
            }

            // Should be an empty one
            var empty = span.Slice(span.Length);
            Assert.Equal(empty.Length, 0, "slicing all the span should result in an empty span");
            Assert.True(empty.IsEmpty, "Empty span should be empty");
        }

        [TestMethod]
        public void CopyToTests()
        {
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            SpanByte span = new SpanByte(array);
            // First a copy to with the full span
            SpanByte toCopy = new byte[span.Length];
            span.CopyTo(toCopy);
            for (int i = 0; i < span.Length; i++)
            {
                Assert.Equal(toCopy[i], span[i], "SpanByte value should be the same as from the original array");
            }

            // Now create a larger span
            toCopy = new byte[span.Length + 1];
            span.CopyTo(toCopy);
            for (int i = 0; i < span.Length; i++)
            {
                Assert.Equal(toCopy[i], span[i], "SpanByte value should be the same as from the original array");
            }

            Assert.Equal(toCopy[span.Length], (byte)0);
        }

        [TestMethod]
        public void GetElementsTests()
        {
            // Span from normal array
            byte[] array = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            SpanByte span = new SpanByte(array);
            for (int i = 0; i < span.Length; i++)
            {
                Assert.Equal(span[i], array[i], "SpanByte value should be the same as from the original array");
            }

            // Partial span
            span = new SpanByte(array, 2, 8);
            for (int i = 0; i < span.Length; i++)
            {
                Assert.Equal(span[i], array[i + 2], "SpanByte value should be the same as from the original array");
            }
        }

        [TestMethod]
        public void SetElementsTests()
        {
            // Create a span, and set the data
            SpanByte span = new byte[12];
            // All should be 0
            for (int i = 0; i < span.Length; i++)
            {
                Assert.Equal(span[i], (byte)0, "SpanByte value should be 0");
                // Set a value
                span[i] = (byte)i;
            }

            for (int i = 0; i < span.Length; i++)
            {
                // Check the value
                Assert.Equal(span[i], (byte)i, "SpanByte value should be the same as setup in the set method");
            }
        }
    }
}
