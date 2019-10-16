//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Collections
{
    /// <summary>
    /// An array implementation of a stack. Push can be O(n). Pop is O(1).
    /// </summary>
    [Serializable]
#if NANOCLR_REFLECTION
    [DebuggerDisplay("Count = {Count}")]
#endif // NANOCLR_REFLECTION
    public class Stack : ICollection, ICloneable
    {
        private Object[] _array;   // Storage for stack elements
        private int _size;         // Number of items in the stack.

        // Keep in-sync with c_DefaultCapacity in CLR_RT_HeapBlock_Stack in NANOCLR_Runtime__HeapBlock.h
        private const int DefaultCapacity = 4;

        /// <summary>
        /// Initializes a new instance of the Stack class that is empty and has the default initial capacity.
        /// </summary>
        public Stack()
        {
            _array = new Object[DefaultCapacity];
            _size = 0;
        }

        /// <summary>
        /// Size of the stack
        /// </summary>
        public virtual int Count
        {
            get { return _size; }
        }

        /// <summary>
        /// Returns whether the current stack is synchornized. Always return false.
        /// </summary>
        public virtual bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the Stack.
        /// </summary>
        public virtual Object SyncRoot
        {
            get { return this; }
        }

        /// <summary>
        /// Removes all Objects from the Stack.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        public virtual extern void Clear();
#pragma warning restore S4200 // Native methods should be wrapped

        /// <summary>
        /// Creates a shallow copy of the Stack.
        /// </summary>
        /// <returns>A shallow copy of the Stack.</returns>
        public virtual Object Clone()
        {
            var stack = new Stack();
            var capacity = DefaultCapacity;

            if (_size > DefaultCapacity)
            {
                // only re-allocate a new array if the size isn't what we need.
                // otherwise, the one allocated in the constructor will be just fine
                stack._array = new Object[_size];
                capacity = _size;
            }

            stack._size = _size;
            Array.Copy(_array, _array.Length - _size, stack._array, capacity - _size, _size);
            return stack;
        }

        /// <summary>
        /// Determines whether an element is in the Stack.
        /// </summary>
        /// <param name="obj">The Object to locate in the Stack.</param>
        /// <returns>true, if obj is found in the Stack; otherwise, false</returns>
        public virtual bool Contains(Object obj)
        {
            return Array.IndexOf(_array, obj, _array.Length - _size, _size) >= 0;
        }

        /// <summary>
        /// Copies the Stack to an existing one-dimensional Array, starting at the specified array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from Stack.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public virtual void CopyTo(Array array, int index)
        {
            Array.Copy(_array, _array.Length - _size, array, index, _size);
        }

        /// <summary>
        /// Returns an IEnumerator for this Stack.
        /// </summary>
        /// <returns>An IEnumerator for the Stack.</returns>
        public virtual IEnumerator GetEnumerator()
        {
            var capacity = _array.Length;
            return new Array.SzArrayEnumerator(_array, capacity - _size, capacity);
        }

        /// <summary>
        /// Returns the object at the top of the Stack without removing it.
        /// </summary>
        /// <returns>The Object at the top of the Stack.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        public virtual extern Object Peek();
#pragma warning restore S4200 // Native methods should be wrapped

        /// <summary>
        /// Removes and returns the object at the top of the Stack.
        /// </summary>
        /// <returns>The Object removed from the top of the Stack.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        public virtual extern Object Pop();
#pragma warning restore S4200 // Native methods should be wrapped

        /// <summary>
        /// Inserts an object at the top of the Stack.
        /// </summary>
        /// <param name="obj">The Object to push onto the Stack.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        public virtual extern void Push(Object obj);
#pragma warning restore S4200 // Native methods should be wrapped

        /// <summary>
        /// Copies the Stack to a new array, in the same order Pop would return the items.
        /// </summary>
        /// <returns>A new array containing copies of the elements of the Stack.</returns>
        public virtual Object[] ToArray()
        {
            var objArray = new Object[_size];

            Array.Copy(_array, _array.Length - _size, objArray, 0, _size);

            return objArray;
        }
    }
}
