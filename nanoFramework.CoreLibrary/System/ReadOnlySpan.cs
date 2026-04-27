// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
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
        private readonly T[]? _array;
        private readonly int _length;

        /// <summary>
        /// Creates a new <see cref="ReadOnlySpan{T}"/> over the entirety of a specified array.
        /// </summary>
        /// <param name="array">The array from which to create the <see cref="ReadOnlySpan{T}"/>.</param>
        /// <remarks>If the array is <see langword="null"/>, this constructor returns a null <see cref="ReadOnlySpan{T}"/>.</remarks>
        public ReadOnlySpan(T[]? array)
        {
            if (array == null)
            {
                this = default;
                return;
            }

            NativeReadOnlySpanConstructor(
                array,
                0,
                array.Length);
        }

        /// <summary>
        /// Creates a new <see cref="ReadOnlySpan{T}"/> object from a specified number of T elements starting at a specified memory address.
        /// </summary>
        /// <param name="pointer">A pointer to the starting address of a specified number of T elements in memory.</param>
        /// <param name="length">The number of T elements to be included in the <see cref="ReadOnlySpan{T}"/>.</param>
        /// <remarks>This constructor should be used with care, since it creates arbitrarily typed Ts from a <see langword="void"/>*-typed block of memory, and neither <paramref name="pointer"/> nor <paramref name="length"/> are validated by the constructor.</remarks>
        /// <exception cref="ArgumentException">T is a reference type or contains pointers and therefore cannot be stored in unmanaged memory.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> is negative.</exception>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern unsafe ReadOnlySpan(
            void* pointer,
            int length);

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
        public ReadOnlySpan(
            T[]? array,
            int start,
            int length)
        {
            if (array == null)
            {
                if (start != 0 || length != 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _array = default;

                return;
            }

            if ((uint)start > (uint)array.Length
                || (uint)length > (uint)(array.Length - start))
            {
                throw new ArgumentOutOfRangeException();
            }

            NativeReadOnlySpanConstructor(
                array,
                start,
                length);
        }

        /// <summary>
        /// Returns the specified element of the <see cref="ReadOnlySpan{T}"/>.
        /// </summary>
        /// <param name="index">The zero-based index.</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="index"/> less than zero or greater than or equal to <see cref="Length"/>.
        /// </exception>
        public ref readonly T this[int index]
        {
            get
            {
                if ((uint)index >= (uint)_length)
                {
                    throw new IndexOutOfRangeException();
                }

                return ref _array![index];
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
        /// Returns an empty <see cref="ReadOnlySpan{T}"/> object.
        /// </summary>
        public static ReadOnlySpan<T> Empty => default;

        /// <summary>Gets an enumerator for this <see cref="Span{T}"/>.</summary>
        /// <returns>An enumerator for this span.</returns>
        public Enumerator GetEnumerator() => new Enumerator(this);

        /// <summary>
        /// Provides an enumerator for the elements of a <see cref="ReadOnlySpan{T}"/>.
        /// </summary>
        public ref struct Enumerator : IEnumerator<T>
        {
            /// <summary>The span being enumerated.</summary>
            private readonly ReadOnlySpan<T> _span;
            /// <summary>The next index to yield.</summary>
            private int _index;

            /// <summary>Initialize the enumerator.</summary>
            /// <param name="span">The span to enumerate.</param>
            internal Enumerator(ReadOnlySpan<T> span)
            {
                _span = span;
                _index = -1;
            }

            /// <summary>Advances the enumerator to the next item of the <see cref="ReadOnlySpan{T}"/>.</summary>
            /// <returns>
            /// <see langword="true"/> if the enumerator successfully advanced to the next item; <see langword="false"/> if the end of the span has been passed.
            /// </returns>
            public bool MoveNext()
            {
                int index = _index + 1;

                if (index < _span.Length)
                {
                    _index = index;
                    return true;
                }

                return false;
            }

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            public ref readonly T Current
            {
                get
                {
                    return ref _span[_index];
                }
            }

            /// <inheritdoc />
            T IEnumerator<T>.Current => Current;

            /// <inheritdoc />
            object Collections.IEnumerator.Current => Current!;

            /// <inheritdoc />
            void Collections.IEnumerator.Reset() => _index = -1;

            /// <inheritdoc />
            void IDisposable.Dispose() { }
        }

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
            return left._length == right._length && left._array == right._array;
        }

        /// <summary>
        /// Copies the contents of this <see cref="ReadOnlySpan{T}"/> into a destination <see cref="Span{T}"/>.
        /// </summary>
        /// <param name="destination">The span to copy items into.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="destination"/> is shorter than the source <see cref="ReadOnlySpan{T}"/>.
        /// </exception>
        /// <remarks>
        /// If the source and <paramref name="destination"/> overlap, the entirety of source is handled as if it was copied to a temporary location before it is copied to <paramref name="destination"/>.
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void CopyTo(Span<T> destination);

        /// <summary>
        /// Forms a slice out of the current span that begins at a specified index.
        /// </summary>
        /// <param name="start">The zero-based index at which to begin the slice.</param>
        /// <returns>A span that consists of all elements of the current span from <paramref name="start"/> to the end of the span.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="start"/> is greater than the number of items in the read-only span.
        /// </exception>
        public ReadOnlySpan<T> Slice(int start)
        {
            if ((uint)start > (uint)_length)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new ReadOnlySpan<T>(_array, start, _length - start);
        }

        /// <summary>
        /// Forms a slice out of the current read-only span starting at a specified index for a specified length.
        /// </summary>
        /// <param name="start">The zero-based index at which to begin the slice.</param>
        /// <param name="length">The desired length for the slice.</param>
        /// <returns>A span that consists of <paramref name="length"/> elements from the current span starting at <paramref name="start"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="start"/> is less than zero or greater than <see cref="Length"/>.
        /// </exception>
        public ReadOnlySpan<T> Slice(int start, int length)
        {
            if ((uint)start > (uint)_length
                || (uint)length > (uint)(_length - start))
            {
                throw new ArgumentOutOfRangeException();
            }

            return new ReadOnlySpan<T>(_array, start, length);
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
