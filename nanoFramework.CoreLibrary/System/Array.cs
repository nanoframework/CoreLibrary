//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Collections;
using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Provides methods for creating, manipulating, searching, and sorting arrays, thereby serving as the base class for all arrays in the common language runtime.
    /// </summary>
    [Serializable]
#if NANOCLR_REFLECTION
    public abstract class Array : ICloneable, IList
#else
    public abstract class Array : IList
#endif // NANOCLR_REFLECTION
    {

#if NANOCLR_REFLECTION
        /// <summary>
        /// Creates a one-dimensional Array of the specified Type and length, with zero-based indexing.
        /// </summary>
        /// <param name="elementType">The Type of the Array to create.</param>
        /// <param name="length">The size of the Array to create.</param>
        /// <returns>A new one-dimensional Array of the specified Type with the specified length, using zero-based indexing.</returns>
        /// <remarks><para>Unlike most classes, Array provides the CreateInstance method, instead of public constructors, to allow for late bound access.</para>
        /// <para>Reference-type elements are initialized to nullNothingnullptrunit a null reference(Nothing in Visual Basic). Value-type elements are initialized to zero.</para>
        /// <para>This method is an O(n) operation, where n is length.</para>
        /// Available only in mscorlib build with support for System.Reflection.</remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern Array CreateInstance(Type elementType, int length);

#endif // NANOCLR_REFLECTION

        /// <summary>
        /// Copies a range of elements from an Array starting at the first element and pastes them into another Array starting at the first element. The length is specified as a 32-bit integer.
        /// </summary>
        /// <param name="sourceArray">The Array that contains the data to copy.</param>
        /// <param name="destinationArray">The Array that receives the data.</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
        public static void Copy(Array sourceArray, Array destinationArray, int length)
        {
            Copy(sourceArray, 0, destinationArray, 0, length);
        }

        /// <summary>
        /// Copies a range of elements from an Array starting at the specified source index and pastes them to another Array starting at the specified destination index. The length and the indexes are specified as 32-bit integers.
        /// </summary>
        /// <param name="sourceArray">The Array that contains the data to copy.</param>
        /// <param name="sourceIndex">A 32-bit integer that represents the index in the sourceArray at which copying begins.</param>
        /// <param name="destinationArray">The Array that receives the data.</param>
        /// <param name="destinationIndex">A 32-bit integer that represents the index in the destinationArray at which storing begins.</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Copy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length);

        /// <summary>
        /// Sets a range of elements in the Array to zero, to false, or to  null reference (Nothing in Visual Basic), depending on the element type.
        /// </summary>
        /// <param name="array">The Array whose elements need to be cleared.</param>
        /// <param name="index">The starting index of the range of elements to clear.</param>
        /// <param name="length">The number of elements to clear.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Clear(Array array, int index, int length);

        /// <summary>
        /// Gets the value at the specified position in the one-dimensional Array. The index is specified as a 32-bit integer.
        /// </summary>
        /// <param name="index">A 32-bit integer that represents the position of the Array element to get.</param>
        /// <returns>The value at the specified position in the one-dimensional Array.</returns>
        public Object GetValue(int index)
        {
            return ((IList)this)[index];
        }

        /// <summary>
        /// Gets a 32-bit integer that represents the total number of elements in all the dimensions of the Array.
        /// </summary>
        /// <value>
        /// A 32-bit integer that represents the total number of elements in all the dimensions of the Array; zero if there are no elements in the array.
        /// </value>
        public extern int Length
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        int ICollection.Count
        {
            get
            {
                return Length;
            }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the Array.
        /// </summary>
        /// <value>
        /// An object that can be used to synchronize access to the Array.
        /// </value>
        public Object SyncRoot
        {
            get { return this; }
        }

        /// <summary>
        /// Gets a value indicating whether the Array is read-only.
        /// </summary>
        /// <value>
        /// This property is always false for all arrays.
        /// </value>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether the Array has a fixed size.
        /// </summary>
        /// <value>
        /// This property is always true for all arrays.
        /// </value>
        public bool IsFixedSize
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the Array is synchronized (thread safe).
        /// </summary>
        /// <value>
        /// This property is always false for all arrays.
        /// </value>
        public bool IsSynchronized
        {
            get { return false; }
        }

        extern Object IList.this[int index]
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;

            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        internal void SetByIndex(int index, object value)
        {
            ((IList)this)[index] = value;
        }

        int IList.Add(Object value)
        {
            throw new NotSupportedException();
        }

        bool IList.Contains(Object value)
        {
            return IndexOf(this, value) >= 0;
        }

        void IList.Clear()
        {
            Clear(this, 0, Length);
        }

        int IList.IndexOf(Object value)
        {
            return IndexOf(this, value);
        }

        void IList.Insert(int index, Object value)
        {
            throw new NotSupportedException();
        }

        void IList.Remove(Object value)
        {
            throw new NotSupportedException();
        }

        void IList.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

#if NANOCLR_REFLECTION

        /// <summary>
        /// Creates a shallow copy of the <see cref="Array"/>.
        /// </summary>
        /// <returns>A shallow copy of the <see cref="Array"/>.</returns>
        /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
        public Object Clone()
        {
            var length = Length;
            var destArray = CreateInstance(GetType().GetElementType(), length);
            Copy(this, destArray, length);

            return destArray;
        }

#endif  // NANOCLR_REFLECTION

        /// <summary>
        /// Searches an entire one-dimensional sorted Array for a value using the specified IComparer interface.
        /// </summary>
        /// <param name="array">The sorted one-dimensional Array to search.</param>
        /// <param name="value">The object to search for.</param>
        /// <param name="comparer">The IComparer implementation to use when comparing elements.
        /// <para>-or-</para>
        /// <para>nullNothingnullptrunit a null reference(Nothing in Visual Basic) to use the IComparable implementation of each element.</para></param>
        /// <returns>The index of the specified value in the specified array, if value is found. If value is not found and value is less than one or more elements in array, a negative number which is the bitwise complement of the index of the first element that is larger than value. If value is not found and value is greater than any of the elements in array, a negative number which is the bitwise complement of (the index of the last element plus 1).</returns>
        public static int BinarySearch(Array array, Object value, IComparer comparer)
        {
            return BinarySearch(array, 0, array.Length, value, comparer);
        }

        /// <summary>
        /// Searches a range of elements in a one-dimensional sorted Array for a value, using the specified IComparer interface.
        /// </summary>
        /// <param name="array">The sorted one-dimensional Array to search.</param>
        /// <param name="index">The starting index of the range to search.</param>
        /// <param name="length">The length of the range to search.</param>
        /// <param name="value">The object to search for.</param>
        /// <param name="comparer">The IComparer implementation to use when comparing elements.
        /// <para>-or-</para>
        /// <para>nullNothingnullptrunit a null reference(Nothing in Visual Basic) to use the IComparable implementation of each element.</para></param>
        /// <returns>The index of the specified value in the specified array, if value is found. If value is not found and value is less than one or more elements in array, a negative number which is the bitwise complement of the index of the first element that is larger than value. If value is not found and value is greater than any of the elements in array, a negative number which is the bitwise complement of (the index of the last element plus 1).</returns>
        /// <exception cref="System.InvalidOperationException">comparer is  null reference (Nothing in Visual Basic), value does not implement the IComparable interface, and the search encounters an element that does not implement the IComparable interface.</exception>
        public static int BinarySearch(Array array, int index, int length, Object value, IComparer comparer)
        {
            var lo = index;
            var hi = index + length - 1;
            while (lo <= hi)
            {
                var i = (lo + hi) >> 1;

                int c;
                if (comparer == null)
                {
                    try
                    {
                        var elementComparer = array.GetValue(i) as IComparable;
                        c = elementComparer.CompareTo(value);
                    }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException("Failed to compare two elements in the array", e);
                    }
                }
                else
                {
                    c = comparer.Compare(array.GetValue(i), value);
                }

                if (c == 0) return i;
                if (c < 0)
                {
                    lo = i + 1;
                }
                else
                {
                    hi = i - 1;
                }
            }

            return ~lo;
        }

        /// <summary>
        /// Copies all the elements of the current one-dimensional Array to the specified one-dimensional Array starting at the specified destination Array index. The index is specified as a 32-bit integer.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from the current Array.</param>
        /// <param name="index">A 32-bit integer that represents the index in array at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            Copy(this, 0, array, index, Length);
        }

        /// <summary>
        /// Returns an IEnumerator for the Array.
        /// </summary>
        /// <returns>An IEnumerator for the Array.</returns>
        public IEnumerator GetEnumerator()
        {
            return new SzArrayEnumerator(this);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the first occurrence within the entire one-dimensional Array.
        /// </summary>
        /// <param name="array">The one-dimensional Array to search.</param>
        /// <param name="value">The object to locate in array.</param>
        /// <returns>The index of the first occurrence of value within the entire array, if found; otherwise, the lower bound of the array minus 1.</returns>
        public static int IndexOf(Array array, Object value)
        {
            return IndexOf(array, value, 0, array.Length);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the first occurrence within the range of elements in the one-dimensional Array that extends from the specified index to the last element.
        /// </summary>
        /// <param name="array">The one-dimensional Array to search.</param>
        /// <param name="value">The object to locate in array.</param>
        /// <param name="startIndex">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>The index of the first occurrence of value within the range of elements in array that extends from startIndex to the last element, if found; otherwise, the lower bound of the array minus 1.</returns>
        public static int IndexOf(Array array, Object value, int startIndex)
        {
            return IndexOf(array, value, startIndex, array.Length - startIndex);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the first occurrence within the range of elements in the one-dimensional Array that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="array">The one-dimensional Array to search.</param>
        /// <param name="value">The object to locate in array.</param>
        /// <param name="startIndex">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The index of the first occurrence of value within the range of elements in array that starts at startIndex and contains the number of elements specified in count, if found; otherwise, the lower bound of the array minus 1.</returns>
        public static int IndexOf(Array array, Object value, int startIndex, int count)
        {
            // Try calling a quick native method to handle primitive types.
            int retVal;

            if (TrySzIndexOf(array, startIndex, count, value, out retVal))
            {
                return retVal;
            }

            var endIndex = startIndex + count;

            for (var i = startIndex; i < endIndex; i++)
            {
                var obj = array.GetValue(i);

                if (Equals(obj, value)) return i;
            }

            return -1;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool TrySzIndexOf(Array sourceArray, int sourceIndex, int count, Object value, out int retVal);

        // This is the underlying Enumerator for all of our array-based data structures (Array, ArrayList, Stack, and Queue)
        // It supports enumerating over an array, a part of an array, and also will wrap around when the endIndex
        // specified is larger than the size of the array (to support Queue's internal circular array)
        internal class SzArrayEnumerator : IEnumerator
        {
            private Array _array;
            private int _index;
            private int _endIndex;
            private int _startIndex;
            private int _arrayLength;

            internal SzArrayEnumerator(Array array)
            {
                _array = array;
                _arrayLength = _array.Length;
                _endIndex = _arrayLength;
                _startIndex = 0;
                _index = -1;
            }

            // By specifying the startIndex and endIndex, the enumerator will enumerate
            // only a subset of the array. Note that startIndex is inclusive, while
            // endIndex is NOT inclusive.
            // For example, if array is of size 5,
            // new SZArrayEnumerator(array, 0, 3) will enumerate through
            // array[0], array[1], array[2]
            //
            // This also supports an array acting as a circular data structure.
            // For example, if array is of size 5,
            // new SZArrayEnumerator(array, 4, 7) will enumerate through
            // array[4], array[0], array[1]
            internal SzArrayEnumerator(Array array, int startIndex, int endIndex)
            {
                _array = array;
                _arrayLength = _array.Length;
                _endIndex = endIndex;
                _startIndex = startIndex;
                _index = _startIndex - 1;
            }

            public bool MoveNext()
            {
                if (_index < _endIndex)
                {
                    _index++;
                    return _index < _endIndex;
                }

                return false;
            }

            public Object Current
            {
                get
                {
                    return _array.GetValue(_index % _arrayLength);
                }
            }

            public void Reset()
            {
                _index = _startIndex - 1;
            }
        }
    }
}
