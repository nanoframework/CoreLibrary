// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.CompilerServices;

#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
#nullable enable

namespace System
{
    /// <summary>
    /// Span represents a contiguous region of arbitrary memory. Unlike arrays, it can point to either managed
    /// or native memory, or to memory allocated on the stack. It is type-safe and memory-safe.
    /// </summary>
    /// <typeparam name="T">The type of items in the <see cref="Span{T}"/>.</typeparam>
    [DebuggerTypeProxy(typeof(SpanDebugView<>))]
    [DebuggerDisplay("{ToString(),raw}")]
    public readonly ref struct Span<T>
    {
        private readonly T[] _array;
        private readonly int _start;
        private readonly int _length;

        /// <summary>
        /// <summary>
        /// Creates a new <see cref="Span{T}"/> object over the entirety of a specified array.
        /// </summary>
        /// </summary>
        /// <param name="array">The array from which to create the <see cref="Span{T}"/> object.</param>
        /// <remarks>If array is <see langword="null"/>, this constructor returns a <see langword="null"/> <see cref="Span{T}"/>.</remarks>
        /// <exception cref="ArrayTypeMismatchException"><see typeparamref="T"/> is a reference type, and <paramref name="array"/> is not an array of type <see typeparamref ="T"/>.</exception>
        public Span(T[]? array)
        {
            if (array == null)
            {
                this = default;
                return;
            }

            if (!typeof(T).IsValueType && array.GetType() != typeof(T[]))
            {
                throw new ArrayTypeMismatchException();
            }

            _array = array ?? [];
            _start = 0;
            _length = _array.Length;
        }

        /// <summary>
        /// Creates a new <see cref="Span{T}"/> object that includes a specified number of elements of an array starting at a specified index.
        /// </summary>
        /// <param name="array">The source array.</param>
        /// <param name="start">The zero-based index of the first element to include in the new <see cref="Span{T}"/>.</param>
        /// <param name="length">The number of elements to include in the new <see cref="Span{T}"/>.</param>
        /// <remarks>This method returns <see langword="default"/> when <paramref name="array"/> is <see langword="null"/>.</remarks>
        /// <exception cref="ArrayTypeMismatchException"><see typeparamref="T"/> is a reference type, and <paramref name="array"/> is not an array of type <see typeparamref="T"/>.</exception>
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
        public Span(
            T[]? array,
            int start,
            int length)
        {
            if (array == null)
            {
                if (start != 0
                    || length != 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this = default;
                return;
            }

            if (!typeof(T).IsValueType
                && array.GetType() != typeof(T[]))
            {
                throw new ArrayTypeMismatchException();
            }

            if ((uint)start > (uint)array.Length
                || (uint)length > (uint)(array.Length - start))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array == null)
            {
                if (start != 0 || length != 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _array = Array.Empty<T>();
                _start = 0;
                _length = 0;

                return;
            }

            if ((uint)start > (uint)array.Length
                || (uint)length > (uint)(array.Length - start))
            {
                throw new ArgumentOutOfRangeException();
            }

            _array = array;
            _start = start;
            _length = length;
        }

        /// <summary>
        /// Returns a reference to specified element of the span.
        /// </summary>
        /// <param name="index">The zero-based index.</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when <paramref name="index"/> less than 0 or <paramref name="index"/> greater than or equal to <see cref="Length"/>.
        /// </exception>
        public ref T this[int index]
        {
            get
            {
                if ((uint)index >= (uint)_length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return ref _array[_start + index];
            }
        }

        /// <summary>
        /// Returns the length of the current span.
        /// </summary>
        public int Length => _length;

        /// <summary>
        /// Returns a value that indicates whether the current <see cref="Span{T}"/> is empty.
        /// </summary>
        /// <value><see langword="true"/> if this span is empty; otherwise, <see langword="false"/>.</value>
        public bool IsEmpty => _length == 0;

        /// <summary>
        /// Returns a value that indicates whether two <see cref="Span{T}"/> objects are not equal.
        /// </summary>
        /// <param name="left">The first span to compare.</param>
        /// <param name="right">The second span to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the two <see cref="Span{T}"/> objects are not equal; otherwise, <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// Two <see cref="Span{T}"/> objects are are not equal if they have different lengths or if the corresponding elements of <paramref name="left"/> and <paramref name="right"/> do not point to the same memory.
        /// </remarks>
        public static bool operator !=(Span<T> left, Span<T> right) => !(left == right);

        /// <summary>
        /// Returns an empty <see cref="Span{T}"/> object.
        /// </summary>
        public static Span<T> Empty => default;

        /// <summary>Gets an enumerator for this <see cref="Span{T}"/>.</summary>
        /// <returns>An enumerator for this span.</returns>
        public Enumerator GetEnumerator() => new Enumerator(this);

        /// <summary>
        /// Provides an enumerator for the elements of a <see cref="Span{T}"/>.
        /// </summary>
        public ref struct Enumerator
        {
            /// <summary>The span being enumerated.</summary>
            private readonly Span<T> _span;
            /// <summary>The next index to yield.</summary>
            private int _index;

            /// <summary>Initialize the enumerator.</summary>
            /// <param name="span">The span to enumerate.</param>
            internal Enumerator(Span<T> span)
            {
                _span = span;
                _index = -1;
            }

            /// <summary>Advances the enumerator to the next item of the <see cref="Span{T}"/>.</summary>
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

            /// <summary>Gets a reference to the item at the current position of the enumerator.</summary>
            public ref T Current => ref _span[_index];
        }

        /// <summary>
        /// Clears the contents of this <see cref="Span{T}"/> object.
        /// </summary>
        /// <remarks>
        /// The <see cref="Clear"/> method sets the items in the <see cref="Span{T}"/> object to their default values. It does not remove items from the <see cref="Span{T}"/>.
        /// </remarks>
        public void Clear()
        {
            Array.Clear(
                _array,
                _start,
                _length);
        }

        /// <summary>
        /// Copies the contents of this <see cref="Span{T}"/> into a destination <see cref="Span{T}"/>.
        /// </summary>
        /// <param name="destination">The destination <see cref="Span{T}"/> object.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="destination"/> is shorter than the source <see cref="Span{T}"/>.
        /// </exception>
        /// <remarks>
        /// This method copies all of source to <paramref name="destination"/> even if source and <paramref name="destination"/> overlap.
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void CopyTo(Span<T> destination);

        /// <summary>
        /// Returns a value that indicates whether two <see cref="Span{T}"/> objects are equal.
        /// </summary>
        /// <param name="left">The first span to compare.</param>
        /// <param name="right">The second span to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the two <see cref="Span{T}"/> objects are equal; otherwise, <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// Two <see cref="Span{T}"/> objects are equal if they have the same length and if the corresponding elements of <paramref name="left"/> and <paramref name="right"/> point to the same memory.
        /// Note that the test for equality does *not* attempt to determine if the contents are equal.
        /// </remarks>
        public static bool operator ==(Span<T> left, Span<T> right) =>
           left._length == right._length && left._array == right._array && left._start == right._start;

        /// <summary>
        /// Defines an implicit conversion of a <see cref="Span{T}"/> to a <see cref="ReadOnlySpan{T}"/>
        /// </summary>
        /// <param name="span">The object to convert to a <see cref="ReadOnlySpan{T}"/>.</param>
        /// <returns>
        /// A read-only span that corresponds to the current instance.
        /// </returns>
        public static implicit operator ReadOnlySpan<T>(Span<T> span) =>
             new ReadOnlySpan<T>(span._array, span._start, span._length);

        /// <summary>
        /// Forms a slice out of the current span that begins at a specified index.
        /// </summary>
        /// <param name="start">The zero-based index at which to begin the slice.</param>
        /// <returns>A span that consists of all elements of the current span from <paramref name="start"/> to the end of the span.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="start"/> is less than zero or greater than <see cref="Length"/>.
        /// </exception>
        public Span<T> Slice(int start)
        {
            if ((uint)start > (uint)_length)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new Span<T>(_array, _start + start, _length - start);
        }

        /// <summary>
        /// Forms a slice out of the current span starting at a specified index for a specified length.
        /// </summary>
        /// <param name="start">The zero-based index at which to begin the slice.</param>
        /// <param name="length">The desired length for the slice.</param>
        /// <returns>A span that consists of <paramref name="length"/> elements from the current span starting at <paramref name="start"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="start"/> or <paramref name="start"/> + <paramref name="length"/> is less than zero or greater than <see cref="Length"/>.
        /// </exception>
        public Span<T> Slice(int start, int length)
        {
            if ((uint)start > (uint)_length
                || (uint)length > (uint)(_length - start))
            {
                throw new ArgumentOutOfRangeException();
            }

            return new Span<T>(_array, _start + start, length);
        }

        /// <summary>
        /// Copies the contents of this span into a new array.
        /// </summary>
        /// <returns>
        /// An array containing the data in the current span.
        /// </returns>
        /// <remarks>
        /// This method performs a heap allocation and therefore should be avoided if possible. Heap allocations are expected in APIs that work with arrays. Using such APIs is unavoidable if an alternative API overload that takes a <see cref="Span{T}"/> does not exist.
        /// </remarks>
        public T[] ToArray()
        {
            T[] destination = new T[_length];
            Array.Copy(_array, _start, destination, 0, _length);
            return destination;
        }
    }
}

#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
