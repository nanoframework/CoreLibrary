//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Collections
{
    /// <summary>
    /// Implements the IList interface using an array whose size is dynamically increased as required.
    /// </summary>
    [Serializable]
#if NANOCLR_REFLECTION
    [DebuggerDisplay("Count = {Count}")]
#endif // NANOCLR_REFLECTION
    public class ArrayList : IList, ICloneable
    {
        private Object[] _items;
        private int _size;

        // Keep in-sync with c_DefaultCapacity in CLR_RT_HeapBlock_ArrayList in NANOCLR_Runtime__HeapBlock.h
        private const int DefaultCapacity = 4;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayList"/> class that is empty and has the default initial capacity.
        /// </summary>
        public ArrayList()
        {
            _items = new Object[DefaultCapacity];
        }

        /// <summary>
        /// Gets or sets the number of elements that the <see cref="ArrayList"/> can contain.
        /// </summary>
        /// <value>
        /// The number of elements that the <see cref="ArrayList"/> can contain.
        /// </value>
        public virtual int Capacity
        {
            get { return _items.Length; }
            set
            {
                SetCapacity(value);
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void SetCapacity(int capacity);

        /// <summary>
        /// Gets the number of elements actually contained in the <see cref="ArrayList"/>.
        /// </summary>
        /// <value>
        /// The number of elements actually contained in the <see cref="ArrayList"/>.
        /// </value>
        public virtual int Count
        {
            get { return _size; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="ArrayList"/> has a fixed size.
        /// </summary>
        /// <value>
        /// true if the <see cref="ArrayList"/> has a fixed size; otherwise, false. The default is false.
        /// </value>
        public virtual bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="ArrayList"/> is read-only.
        /// </summary>
        /// <value>
        /// true if the <see cref="ArrayList"/> is read-only; otherwise, false. The default is false.
        /// </value>
        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="ArrayList"/> is synchronized (thread safe).
        /// </summary>
        /// <value>
        /// true if access to the <see cref="ArrayList"/> is synchronized (thread safe); otherwise, false. The default is false.
        /// </value>
        public virtual bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="ArrayList"/>.
        /// </summary>
        /// <value>
        /// An object that can be used to synchronize access to the <see cref="ArrayList"/>.
        /// </value>
        public virtual Object SyncRoot
        {
            get { return this; }
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns></returns>
        public virtual extern Object this[int index]
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;

            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        /// <summary>
        /// Adds an object to the end of the <see cref="ArrayList"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The <see cref="Object"/> to be added to the end of the <see cref="ArrayList"/>. The value can be <see langword="null"/>.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public virtual extern int Add(Object value);

        /// <summary>
        /// Searches the entire sorted <see cref="ArrayList"/> for an element using the specified comparer and returns the zero-based index of the element.
        /// </summary>
        /// <param name="value">The Object to locate. The value can be  <see langword="null"/> reference (Nothing in Visual Basic). </param>
        /// <param name="comparer">The IComparer implementation to use when comparing elements.
        /// <para>-or-</para>
        /// <para>nullNothingnullptrunit a <see langword="null"/> reference(Nothing in Visual Basic) to use the IComparable implementation of each element.</para></param>
        /// <returns>The zero-based index of value in the sorted <see cref="ArrayList"/>, if value is found; otherwise, a negative number, which is the bitwise complement of the index of the next element that is larger than value or, if there is no larger element, the bitwise complement of Count.</returns>
        public virtual int BinarySearch(Object value, IComparer comparer)
        {
            return Array.BinarySearch(_items, 0, _size, value, comparer);
        }

        /// <summary>
        /// Removes all elements from the <see cref="ArrayList"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public virtual extern void Clear();

        /// <summary>
        /// Creates a shallow copy of the <see cref="ArrayList"/>.
        /// </summary>
        /// <returns>A shallow copy of the <see cref="ArrayList"/>.</returns>
        public virtual Object Clone()
        {
            var arrayList = new ArrayList();

            if (_size > DefaultCapacity)
            {
                // only re-allocate a new array if the size isn't what we need.
                // otherwise, the one allocated in the constructor will be just fine
                arrayList._items = new Object[_size];
            }

            arrayList._size = _size;
            Array.Copy(_items, 0, arrayList._items, 0, _size);
            return arrayList;
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="ArrayList"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The<see cref="Object"/> to locate in the <see cref="ArrayList"/>.The value can be <see langword="null"/>.</returns>
        public virtual bool Contains(Object value)
        {
            return Array.IndexOf(_items, value, 0, _size) >= 0;
        }

        /// <summary>
        /// Copies the entire <see cref="ArrayList"/> to a compatible one-dimensional Array, starting at the beginning of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from <see cref="ArrayList"/>. The Array must have zero-based indexing.</param>
        public virtual void CopyTo(Array array)
        {
            CopyTo(array, 0);
        }

        /// <summary>
        /// Copies the entire <see cref="ArrayList"/> to a compatible one-dimensional Array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from <see cref="ArrayList"/>. The Array must have zero-based indexing. </param>
        /// <param name="index">The zero-based index in array at which copying begins. </param>
        public virtual void CopyTo(Array array, int index)
        {
            Array.Copy(_items, 0, array, index, _size);
        }

        /// <summary>
        /// Returns an enumerator for the entire <see cref="ArrayList"/>.
        /// </summary>
        /// <returns>An IEnumerator for the entire <see cref="ArrayList"/>.</returns>
        public virtual IEnumerator GetEnumerator()
        {
            return new Array.SzArrayEnumerator(_items, 0, _size);
        }

        /// <summary>
        /// Searches for the specified Object and returns the zero-based index of the first occurrence within the entire <see cref="ArrayList"/>.
        /// </summary>
        /// <param name="value">The Object to locate in the <see cref="ArrayList"/>. The value can be <see langword="null"/> reference (Nothing in Visual Basic). </param>
        /// <returns>The zero-based index of the first occurrence of value within the entire <see cref="ArrayList"/>, if found; otherwise, -1.</returns>
        public virtual int IndexOf(Object value)
        {
            return Array.IndexOf(_items, value, 0, _size);
        }

        /// <summary>
        /// Searches for the specified Object and returns the zero-based index of the first occurrence within the range of elements in the <see cref="ArrayList"/> that extends from the specified index to the last element.
        /// </summary>
        /// <param name="value">The Object to locate in the <see cref="ArrayList"/>. The value can be <see langword="null"/> reference (Nothing in Visual Basic). </param>
        /// <param name="startIndex">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <returns>The zero-based index of the first occurrence of value within the range of elements in the <see cref="ArrayList"/> that extends from startIndex to the last element, if found; otherwise, -1.</returns>
        public virtual int IndexOf(Object value, int startIndex)
        {
            return Array.IndexOf(_items, value, startIndex, _size - startIndex);
        }

        /// <summary>
        /// Searches for the specified Object and returns the zero-based index of the first occurrence within the range of elements in the <see cref="ArrayList"/> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="value">The Object to locate in the <see cref="ArrayList"/>. The value can be <see langword="null"/> reference (Nothing in Visual Basic). </param>
        /// <param name="startIndex">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <param name="count">The number of elements in the section to search. </param>
        /// <returns>The zero-based index of the first occurrence of value within the range of elements in the <see cref="ArrayList"/> that starts at startIndex and contains count number of elements, if found; otherwise, -1.</returns>
        public virtual int IndexOf(Object value, int startIndex, int count)
        {
            return Array.IndexOf(_items, value, startIndex, count);
        }

        /// <summary>
        /// Inserts an element into the <see cref="ArrayList"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <para>value</para> should be inserted.</param>
        /// <param name="value">The <see cref="Object"/> to insert. The `value` can be <see langword="null"/>.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public virtual extern void Insert(int index, Object value);

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="ArrayList"/>.
        /// </summary>
        /// <param name="value">The <see cref="Object"/> to remove from the <see cref="ArrayList"/>. The value can be <see langword="null"/>.</param>
        public virtual void Remove(Object value)
        {
            var index = Array.IndexOf(_items, value, 0, _size);
            if (index >= 0)
            {
                RemoveAt(index);
            }
        }

        /// <summary>
        /// Removes the element at the specified index of the <see cref="ArrayList"/>.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public virtual extern void RemoveAt(int index);

#if NANOCLR_REFLECTION

        /// <summary>
        /// Copies the elements of the <see cref="ArrayList"/> to a new <see cref="Object"/> array.
        /// </summary>
        /// <returns>An Object array containing copies of the elements of the <see cref="ArrayList"/>.</returns>
        /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
        public virtual Object[] ToArray()
        {
            return (Object[])ToArray(typeof(object));
        }

        /// <summary>
        /// Copies the elements of the <see cref="ArrayList"/> to a new array of the specified element type.
        /// </summary>
        /// <param name="type">The element Type of the destination array to create and copy elements to.</param>
        /// <returns>An array of the specified element type containing copies of the elements of the <see cref="ArrayList"/>.</returns>
        public virtual Array ToArray(Type type)
        {
            var array = Array.CreateInstance(type, _size);

            Array.Copy(_items, 0, array, 0, _size);

            return array;
        }

#endif // NANOCLR_REFLECTION

    }
}
