// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.CompilerServices;

#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
#nullable enable

namespace System
{
    /// <summary>
    /// Provides a type-safe and memory-safe read-only representation of a contiguous region of arbitrary memory.
    /// </summary>
    /// <typeparam name="T">The type of items in the <see cref="ReadOnlySpan{T}"/>.</typeparam>
    [DebuggerTypeProxy(typeof(SpanDebugView<>))]
    [DebuggerDisplay("{ToString(),raw}")]
    public readonly ref struct ReadOnlySpan<T>
    {
        private readonly T[] _array;
        private readonly int _length;

        /// <summary>
        /// Creates a new <see cref="ReadOnlySpan{T}"/> over the entirety of a specified array.
        /// </summary>
        /// <param name="array">The array from which to create the <see cref="ReadOnlySpan{T}"/>.</param>
        /// <remarks>If the array is <see langword="null"/>, this constructor returns a null <see cref="ReadOnlySpan{T}"/>.</remarks>
        public ReadOnlySpan(T[]? array)
        {
            _array = array ?? Array.Empty<T>();
            _length = _array.Length;
        }

        /// <summary>
        /// Creates a new <see cref="ReadOnlySpan{T}"/> that includes a specified number of elements of an array starting at a specified index.
        /// </summary>
        /// <param name="array">The array from which to create the <see cref="ReadOnlySpan{T}"/>.</param>
        /// <param name="start">The zero-based index of the first element to include.</param>
        /// <param name="length">The number of elements to include.</param>
        /// <returns>This method returns <see langword="default"/> when <paramref name="array"/> is <see langword="null"/>.</returns>
        /// <remarks>Returns default when <paramref name="array"/> is null.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>
        /// <paramref name="array"/> is <see langword="null"/>, but <paramref name="start"/> or <paramref name="length"/> is non-zero.
        /// </para>
        /// <para>
        /// -or-
        /// </para>
        /// <para>
        /// <paramref name="start"/> is outside the bounds of the array.
        /// </para>
        /// <para>
        /// -or-
        /// </para>
        /// <para>
        /// <paramref name="start"/> and <paramref name="length"/> exceeds the number of elements in the array.
        /// </para>
        /// </exception>
        public ReadOnlySpan(T[]? array, int start, int length)
        {
            if (array == null)
            {
                if (start != 0 || length != 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _array = Array.Empty<T>();
                _length = 0;

                return;
            }

            if ((uint)start > (uint)array.Length
                || (uint)length > (uint)(array.Length - start))
            {
                throw new ArgumentOutOfRangeException();
            }

            NativeReadOnlySpanConstructor(array, start, length);
        }

        /// <summary>
        /// Returns the specified element of the <see cref="ReadOnlySpan{T}"/>.
        /// </summary>
        /// <param name="index">The zero-based index.</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when index less than 0 or index greater than or equal to Length
        /// </exception>
        public ref readonly T this[int index]
        {
            get
            {
                if ((uint)index >= (uint)_length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return ref _array[index];
            }
        }

        /// <summary>
        /// The number of items in the read-only span.
        /// </summary>
        public int Length => _length;

        /// <summary>
        /// Returns a value that indicates the current read-only span is empty.
        /// </summary>
        /// <value><see langword="true"/> when the current span is empty; otherwise, <see langword="false"/>.</value>
        public bool IsEmpty => _length == 0;

        /// <summary>
        /// Returns a value that indicates whether two <see cref="ReadOnlySpan{T}"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first read-only span to compare.</param>
        /// <param name="right">The second read-only span to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the two <see cref="ReadOnlySpan{T}"/> instances are not equal; otherwise, <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// Two <see cref="ReadOnlySpan{T}"/> instances are not equal if they have different lengths or if the corresponding elements of <paramref name="left"/> and <paramref name="right"/> point to different memory locations.
        /// </remarks>
        public static bool operator !=(ReadOnlySpan<T> left, ReadOnlySpan<T> right) => !(left == right);

        /// <summary>
        /// Defines an implicit conversion of an array to a <see cref="ReadOnlySpan{T}"/>
        /// </summary>
        public static implicit operator ReadOnlySpan<T>(T[]? array) => new ReadOnlySpan<T>(array);

        /// <summary>
        /// Returns a value that indicates whether two <see cref="ReadOnlySpan{T}"/> instances are equal.
        /// </summary>
        /// <param name="left">The first span to compare.</param>
        /// <param name="right">The second span to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the two <see cref="ReadOnlySpan{T}"/> instances are equal; otherwise, <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// This tests if two <see cref="ReadOnlySpan{T}"/> instances are equal by comparing their lengths and the elements they point to. Two <see cref="ReadOnlySpan{T}"/> instances point to the same starting memory location, and have the same <see cref="Length"/> values. This does not compare the contents of two <see cref="ReadOnlySpan{T}"/> instances.
        /// </remarks>
        public static bool operator ==(ReadOnlySpan<T> left, ReadOnlySpan<T> right)
        {
            if (left.Length != right.Length)
            {
                return false;
            }

            for (int i = 0; i < left.Length; i++)
            {
                if (!Equals(left[i], right[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Copies the contents of this read-only span into a new array.
        /// </summary>
        /// <returns>
        /// An array containing the data in the current span.
        /// </returns>
        /// <remarks>
        /// This method performs a heap allocation and data copy, and therefore, should be avoided if possible. It it sometimes necessary when APIs that support <see cref="ReadOnlySpan{T}"/> are not available, but APIs that work with arrays are.
        /// </remarks>
        public T[] ToArray()
        {
            T[] destination = new T[_length];
            Array.Copy(_array, 0, destination, 0, _length);
            return destination;
        }

        #region native methods

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeReadOnlySpanConstructor(
            T[] array,
            int start,
            int length);

        #endregion
    }
}

#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
