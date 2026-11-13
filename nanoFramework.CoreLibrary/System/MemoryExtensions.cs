// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{

#nullable enable

    /// <summary>
    /// Provides extension methods for the memory-related and span-related types, such as <see cref="Span{T}"/>, and <see cref="ReadOnlySpan{T}"/>.
    /// </summary>
    public static class MemoryExtensions
    {
        /// <summary>
        /// Copies the contents of the array into the span.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="source">The array to copy items from.</param>
        /// <param name="destination">The span to copy items into.</param>
        /// <exception cref="ArgumentException">The destination span is shorter than the source array.</exception>
        public static void CopyTo<T>(
            this T[]? source,
            Span<T> destination) => new ReadOnlySpan<T>(source).CopyTo(destination);
    }
}
