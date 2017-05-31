//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Text
{
    /// <summary>
    /// A Micro Framework port of the Full Framework StringBuilder. Contributed by Julius Friedman.
    /// Represents a mutable string of characters. This class cannot be inherited.
    /// </summary>
    public sealed class StringBuilder
    {
        #region Fields

        int _maxCapacity;
        char[] _chunkChars;
        int _chunkLength;
        StringBuilder _chunkPrevious;
        int _chunkOffset;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the maximum capacity of this instance.
        /// </summary>
        /// <value>The maximum number of characters this instance can hold.</value>
        public int MaxCapacity
        {
            get
            {
                return _maxCapacity;
            }
        }

        /// <summary>
        /// Gets or sets the character at the specified character position in this instance.
        /// </summary>
        /// <param name="index">The position of the character.</param>
        /// <returns>The Unicode character at position index.</returns>
        public char this[int index]
        {
            get
            {
                var chunkPrevious = this;
                while (true)
                {
                    var num = index - chunkPrevious._chunkOffset;
                    if (num >= 0)
                    {
                        if (num >= chunkPrevious._chunkLength)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        return chunkPrevious._chunkChars[num];
                    }
                    chunkPrevious = chunkPrevious._chunkPrevious;
                    if (chunkPrevious == null)
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
            }
            set
            {
                var chunkPrevious = this;
Label_0002:
                var num = index - chunkPrevious._chunkOffset;
                if (num >= 0)
                {
                    if (num >= chunkPrevious._chunkLength)
                    {
                        throw new ArgumentOutOfRangeException("index");
                    }
                    chunkPrevious._chunkChars[num] = value;
                }
                else
                {
                    chunkPrevious = chunkPrevious._chunkPrevious;
                    if (chunkPrevious == null)
                    {
                        throw new ArgumentOutOfRangeException("index");
                    }
                    goto Label_0002;
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of characters that can be contained in the memory allocated by the current instance.
        /// </summary>
        /// <value>
        /// The maximum number of characters that can be contained in the memory allocated by the current instance. Its value can range from Length to MaxCapacity.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int Capacity
        {
            get
            {
                return _chunkChars.Length + _chunkOffset;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("value");
                if (value > MaxCapacity) throw new ArgumentOutOfRangeException("value");
                if (value < Length) throw new ArgumentOutOfRangeException("value");
                if (Capacity != value)
                {
                    var num = value - _chunkOffset;
                    var destinationArray = new char[num];
                    Array.Copy(_chunkChars, destinationArray, _chunkLength);
                    _chunkChars = destinationArray;
                }
            }
        }

        /// <summary>
        /// Gets or sets the length of the current StringBuilder object.
        /// </summary>
        /// <value>The length of this instance.</value>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int Length
        {
            get
            {
                return _chunkOffset + _chunkLength;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("value");
                if (value > MaxCapacity) throw new ArgumentOutOfRangeException("value");
                var capacity = Capacity;
                if (value == 0 && _chunkPrevious == null)
                {
                    _chunkLength = 0;
                    _chunkOffset = 0;
                }
                else
                {
                    var repeatCount = value - Length;
                    if (repeatCount > 0)
                    {
                        Append('\0', repeatCount);
                    }
                    else
                    {
                        var builder = FindChunkForIndex(value);
                        if (builder != this)
                        {
                            var num3 = capacity - builder._chunkOffset;
                            var destinationArray = new char[num3];
                            Array.Copy(builder._chunkChars, destinationArray, builder._chunkLength);
                            _chunkChars = destinationArray;
                            _chunkPrevious = builder._chunkPrevious;
                            _chunkOffset = builder._chunkOffset;
                        }
                        _chunkLength = value - builder._chunkOffset;
                    }
                }

            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the StringBuilder class from the specified substring and capacity. 
        /// </summary>
        /// <param name="value">The string that contains the substring used to initialize the value of this instance. If value is null, the new StringBuilder will contain the empty string (that is, it contains Empty).</param>
        /// <param name="startIndex">The position within value where the substring begins.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <param name="capacity">The suggested starting size of the StringBuilder.</param>
        public unsafe StringBuilder(string value, int startIndex, int length, int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException("capacity");
            if (length < 0) throw new ArgumentOutOfRangeException("length");
            if (startIndex < 0) throw new ArgumentOutOfRangeException("startIndex");
            if (value == null) value = string.Empty;
            if (startIndex > value.Length - length) throw new ArgumentOutOfRangeException("length");
            _maxCapacity = 0x7fffffff;
            if (capacity == 0) capacity = 0x10;
            if (capacity < length) capacity = length;
            //Allocate the chunk of capactity
            _chunkChars = new char[capacity];
            //Set the length of the chunk
            _chunkLength = length;
            //Copy the value to the chunkChars
            value.ToCharArray().CopyTo(_chunkChars, 0);
        }

        private StringBuilder(int size, int maxCapacity, StringBuilder previousBlock)
        {
            _chunkChars = new char[size];
            _maxCapacity = maxCapacity;
            _chunkPrevious = previousBlock;
            if (previousBlock != null)
            {
                _chunkOffset = previousBlock._chunkOffset + previousBlock._chunkLength;
            }
        }

        /// <summary>
        /// Initializes a new instance of the StringBuilder class using the specified string and capacity.
        /// </summary>
        /// <param name="value">The string used to initialize the value of the instance. If value is null, the new StringBuilder will contain the empty string (that is, it contains Empty).</param>
        /// <param name="capacity">The suggested starting size of the StringBuilder.</param>
        public StringBuilder(string value, int capacity)
            : this(value, 0, value != null ? value.Length : 0, capacity) { }

        /// <summary>
        /// Initializes a new instance of the StringBuilder class that starts with a specified capacity and can grow to a specified maximum. 
        /// </summary>
        /// <param name="capacity">The suggested starting size of the StringBuilder.</param>
        /// <param name="maxCapacity">The maximum number of characters the current string can contain.</param>
        public StringBuilder(int capacity, int maxCapacity)
        {
            if (capacity > maxCapacity) throw new ArgumentOutOfRangeException("capacity");
            if (maxCapacity < 1) throw new ArgumentOutOfRangeException("maxCapacity");
            if (capacity < 0) throw new ArgumentOutOfRangeException("capacity");
            if (capacity == 0) capacity = Math.Min(0x10, maxCapacity);
            _maxCapacity = maxCapacity;
            _chunkChars = new char[capacity];
        }

        private StringBuilder(StringBuilder from)
        {
            _chunkLength = from._chunkLength;
            _chunkOffset = from._chunkOffset;
            _chunkChars = from._chunkChars;
            _chunkPrevious = from._chunkPrevious;
            _maxCapacity = from._maxCapacity;
        }

        /// <summary>
        /// Initializes a new instance of the StringBuilder class using the specified capacity. 
        /// </summary>
        /// <param name="capacity">The suggested starting size of this instance.</param>
        public StringBuilder(int capacity)
            : this(string.Empty, capacity) { }

        /// <summary>
        /// Initializes a new instance of the StringBuilder class using the specified string. 
        /// </summary>
        /// <param name="value">The string used to initialize the value of the instance. If value is null, the new StringBuilder will contain the empty string (that is, it contains Empty).</param>
        public StringBuilder(string value)
            : this(value, 0x10) { }

        /// <summary>
        /// Initializes a new instance of the StringBuilder class. 
        /// </summary>
        public StringBuilder()
            : this(0x10) { }

        #endregion

        #region Methods

        /// <summary>
        /// Removes all characters from the current StringBuilder instance. 
        /// </summary>
        /// <returns>An object whose Length is 0 (zero).</returns>
        public StringBuilder Clear()
        {
            Length = 0;
            return this;
        }

        /// <summary>
        /// Appends the string representation of a specified Boolean value to this instance. 
        /// </summary>
        /// <param name="value">The Boolean value to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(bool value)
        {
            return Append(value.ToString());
        }

        /// <summary>
        /// Appends the string representation of a specified 8-bit unsigned integer to this instance. 
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(byte value)
        {
            return Append(value.ToString());
        }

        /// <summary>
        /// Appends the string representation of a specified Unicode character to this instance. 
        /// </summary>
        /// <param name="value">The UTF-16-encoded code unit to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(char value)
        {
            if (_chunkLength < _chunkChars.Length) _chunkChars[_chunkLength++] = value;
            else Append(value, 1);

            return this;
        }

        /// <summary>
        /// Appends the string representation of a specified double-precision floating-point number to this instance. 
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(double value)
        {
            return Append(value.ToString());
        }

        /// <summary>
        /// Appends the string representation of a specified 16-bit signed integer to this instance. 
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(short value)
        {
            return Append(value.ToString());
        }

        /// <summary>
        /// Appends the string representation of the Unicode characters in a specified array to this instance. 
        /// </summary>
        /// <param name="value">The array of characters to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(char[] value)
        {
            if (value != null && value.Length > 0)
            {
                Append(value, value.Length);
            }
            return this;
        }

        /// <summary>
        /// Appends the string representation of a specified 32-bit signed integer to this instance. 
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(int value)
        {
            return Append(value.ToString());
        }

        /// <summary>
        /// Appends the string representation of a specified 64-bit unsigned integer to this instance. 
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(long value)
        {
            return Append(value.ToString());
        }

        /// <summary>
        /// Appends the string representation of a specified object to this instance. 
        /// </summary>
        /// <param name="value">The object to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(object value)
        {
            return value == null ? this : Append(value);
        }

        /// <summary>
        /// Appends a copy of the specified string to this instance.
        /// </summary>
        /// <param name="value">The string to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(string value)
        {
            if (value != null && value != string.Empty)
            {
                var chunkChars = _chunkChars;
                var chunkLength = _chunkLength;
                var length = value.Length;
                var num3 = chunkLength + length;
                if (num3 < chunkChars.Length)
                {
                    if (length <= 2)
                    {
                        if (length > 0) chunkChars[chunkLength] = value[0];
                        if (length > 1) chunkChars[chunkLength + 1] = value[1];
                    }
                    else
                    {
                        var tmp = value.ToCharArray();
                        Array.Copy(tmp, 0, chunkChars, chunkLength, length);
                    }
                    _chunkLength = num3;
                }
                else
                {
                    AppendHelper(ref value);
                }
            }
            return this;
        }

        /// <summary>
        /// Appends the string representation of a specified 8-bit signed integer to this instance. 
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(sbyte value)
        {
            return Append(value.ToString());
        }

        /// <summary>
        /// Appends the string representation of a specified double-precision floating-point number to this instance. 
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(float value)
        {
            return Append(value.ToString());
        }

        /// <summary>
        /// Appends the string representation of a specified 16-bit unsigned integer to this instance. 
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(ushort value)
        {
            return Append(value.ToString());
        }

        /// <summary>
        /// Appends the string representation of a specified 32-bit unsigned integer to this instance. 
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(uint value)
        {
            return Append(value.ToString());
        }

        /// <summary>
        /// Appends the string representation of a specified 64-bit unsigned integer to this instance. 
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(ulong value)
        {
            return Append(value.ToString());
        }

        /// <summary>
        /// Appends a copy of a specified substring to this instance. 
        /// </summary>
        /// <param name="value">The string that contains the substring to append.</param>
        /// <param name="startIndex">The starting position of the substring within value.</param>
        /// <param name="count">The number of characters in value to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(string value, int startIndex, int count)
        {
            if (startIndex < 0) throw new ArgumentOutOfRangeException("startIndex");
            if (count < 0) throw new ArgumentOutOfRangeException("count");
            if (value == null)
            {
                if (startIndex != 0 || count != 0) throw new ArgumentNullException("value");
                return this;
            }
            if (count != 0)
            {
                if (startIndex > value.Length - count) throw new ArgumentOutOfRangeException("startIndex");
                Append(value.Substring(startIndex, count));
            }
            return this;
        }

        /// <summary>
        /// Appends the string representation of a specified subarray of Unicode characters to this instance
        /// </summary>
        /// <param name="value">A character array. </param>
        /// <param name="startIndex">The starting position in value. </param>
        /// <param name="charCount">The number of characters to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(char[] value, int startIndex, int charCount)
        {
            if (startIndex < 0) throw new ArgumentOutOfRangeException("startIndex");
            if (charCount < 0) throw new ArgumentOutOfRangeException("count");
            if (value == null)
            {
                if (startIndex != 0 || charCount != 0) throw new ArgumentNullException("value");
                return this;
            }
            if (charCount > value.Length - startIndex) throw new ArgumentOutOfRangeException("count");
            if (charCount != 0)
            {
                for (var i = startIndex; i < startIndex + charCount; ++i)
                {
                    Append(value[i], 1);
                }
            }
            return this;
        }

        /// <summary>
        /// Appends a specified number of copies of the string representation of a Unicode character to this instance. 
        /// </summary>
        /// <param name="value">The character to append.</param>
        /// <param name="repeatCount">The number of times to append value.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(char value, int repeatCount)
        {
            if (repeatCount < 0) throw new ArgumentOutOfRangeException("repeatCount");
            if (repeatCount != 0)
            {
                var chunkLength = _chunkLength;
                while (repeatCount > 0)
                {
                    if (chunkLength < _chunkChars.Length)
                    {
                        _chunkChars[chunkLength++] = value;
                        repeatCount--;
                    }
                    else
                    {
                        _chunkLength = chunkLength;
                        ExpandByABlock(repeatCount);
                        chunkLength = 0;
                    }
                }
                _chunkLength = chunkLength;
            }
            return this;
        }

        /// <summary>
        /// Removes the specified range of characters from this instance. 
        /// </summary>
        /// <param name="startIndex">The zero-based position in this instance where removal begins.</param>
        /// <param name="length">The number of characters to remove.</param>
        /// <returns>A reference to this instance after the excise operation has completed.</returns>
        public StringBuilder Remove(int startIndex, int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length");
            if (startIndex < 0) throw new ArgumentOutOfRangeException("startIndex");
            if (length > Length - startIndex) throw new ArgumentOutOfRangeException("index");
            if (Length == length && startIndex == 0)
            {
                Length = 0;
                return this;
            }
            if (length > 0)
            {
                StringBuilder builder;
                int num;
                Remove(startIndex, length, out builder, out num);
            }
            return this;
        }

        /// <summary>
        /// Converts the value of this instance to a String. (Overrides Object.ToString().)
        /// </summary>
        /// <returns>A string whose value is the same as this instance.</returns>
        public override string ToString()
        {
            var result = new char[Length];
            var chunkPrevious = this;
            do
            {
                if (chunkPrevious._chunkLength > 0)
                {
                    var chunkChars = chunkPrevious._chunkChars;
                    var chunkOffset = chunkPrevious._chunkOffset;
                    var chunkLength = chunkPrevious._chunkLength;
                    Array.Copy(chunkChars, 0, result, chunkOffset, chunkLength);
                }
                chunkPrevious = chunkPrevious._chunkPrevious;
            }
            while (chunkPrevious != null);
            return new string(result);
        }

        /// <summary>
        /// Converts the value of a substring of this instance to a String. 
        /// </summary>
        /// <param name="startIndex">The starting position of the substring in this instance.</param>
        /// <param name="length">The length of the substring.</param>
        /// <returns>A string whose value is the same as the specified substring of this instance.</returns>
        public string ToString(int startIndex, int length)
        {
            var num = Length;
            if (startIndex < 0) throw new ArgumentOutOfRangeException("startIndex");
            if (startIndex > num) throw new ArgumentOutOfRangeException("startIndex");
            if (length < 0) throw new ArgumentOutOfRangeException("length");
            if (startIndex > num - length) throw new ArgumentOutOfRangeException("length");

            var chunkPrevious = this;
            var num2 = startIndex + length;
            var result = new char[Length];
            var num3 = length;
            while (num3 > 0)
            {
                var chunkLength = num2 - chunkPrevious._chunkOffset;
                if (chunkLength >= 0)
                {
                    if (chunkLength > chunkPrevious._chunkLength)
                    {
                        chunkLength = chunkPrevious._chunkLength;
                    }
                    var num5 = num3;
                    var charCount = num5;
                    var index = chunkLength - num5;
                    if (index < 0)
                    {
                        charCount += index;
                        index = 0;
                    }
                    num3 -= charCount;
                    if (charCount > 0)
                    {
                        var chunkChars = chunkPrevious._chunkChars;
                        if (charCount + num3 > length || charCount + index > chunkChars.Length)
                        {
                            throw new ArgumentOutOfRangeException("chunkCount");
                        }
                        Array.Copy(chunkChars, index, result, 0, charCount);
                    }
                }
                chunkPrevious = chunkPrevious._chunkPrevious;
            }
            return new string(result);
        }

        /// <summary>
        /// Inserts one or more copies of a specified string into this instance at the specified character position. 
        /// </summary>
        /// <param name="index">The position in this instance where insertion begins.</param>
        /// <param name="value">The string to insert.</param>
        /// <param name="count">The number of times to insert value.</param>
        /// <returns>A reference to this instance after insertion has completed.</returns>
        public StringBuilder Insert(int index, string value, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException("count");

            var length = Length;
            if (index > length) throw new ArgumentOutOfRangeException("index");
            if (value != null && value.Length != 0 && count != 0)
            {
                StringBuilder builder;
                int num3;
                long num2 = value.Length * count;
                if (num2 > MaxCapacity - Length) throw new OutOfMemoryException();
                MakeRoom(index, (int)num2, out builder, out num3, false);
                var chars = value.ToCharArray();
                var charLength = chars.Length;
                while (count > 0)
                {
                    var cindex = 0;
                    ReplaceInPlaceAtChunk(ref builder, ref num3, chars, ref cindex, charLength);
                    --count;
                }
            }
            return this;
        }

        /// <summary>
        /// Inserts the string representation of a specified subarray of Unicode characters into this instance at the specified character position. 
        /// </summary>
        /// <param name="index">The position in this instance where insertion begins.</param>
        /// <param name="value">A character array.</param>
        /// <param name="startIndex">The starting index within value.</param>
        /// <param name="charCount">The number of characters to insert.</param>
        /// <returns>A reference to this instance after the insert operation has completed.</returns>
        public StringBuilder Insert(int index, char[] value, int startIndex, int charCount)
        {
            var length = Length;
            if (index > length) throw new ArgumentOutOfRangeException("index");
            if (value == null)
            {
                if (startIndex != 0 || charCount != 0) throw new ArgumentNullException("index");
                return this;
            }
            if (startIndex < 0) throw new ArgumentOutOfRangeException("startIndex");
            if (charCount < 0) throw new ArgumentOutOfRangeException("count");
            if (startIndex > value.Length - charCount) throw new ArgumentOutOfRangeException("startIndex");
            if (charCount > 0) Insert(index, new string(value, startIndex, charCount), 1);

            return this;
        }

        /// <summary>
        /// Replaces, within a substring of this instance, all occurrences of a specified character with another specified character. 
        /// </summary>
        /// <param name="oldChar">The character to replace. </param>
        /// <param name="newChar">The character that replaces oldChar. </param>
        /// <param name="startIndex">The position in this instance where the substring begins. </param>
        /// <param name="count">The length of the substring. </param>
        /// <returns>A reference to this instance with oldChar replaced by newChar in the range from startIndex to startIndex + count -1.</returns>
        public StringBuilder Replace(char oldChar, char newChar, int startIndex, int count)
        {
            var length = Length;
            if (startIndex > length) throw new ArgumentOutOfRangeException("startIndex");
            if (count < 0 || startIndex > length - count) throw new ArgumentOutOfRangeException("count");

            var num2 = startIndex + count;
            var chunkPrevious = this;
Label_0048:
            var num3 = num2 - chunkPrevious._chunkOffset;
            var num4 = startIndex - chunkPrevious._chunkOffset;
            if (num3 >= 0)
            {
                var index = Math.Max(num4, 0);
                var num6 = Math.Min(chunkPrevious._chunkLength, num3);
                while (index < num6)
                {
                    if (chunkPrevious._chunkChars[index] == oldChar)
                    {
                        chunkPrevious._chunkChars[index] = newChar;
                    }
                    index++;
                }
            }
            if (num4 < 0)
            {
                chunkPrevious = chunkPrevious._chunkPrevious;
                goto Label_0048;
            }
            return this;
        }

        /// <summary>
        /// Replaces all occurrences of a specified character in this instance with another specified character. 
        /// </summary>
        /// <param name="oldChar">The character to replace.</param>
        /// <param name="newChar">The character that replaces oldChar.</param>
        /// <returns>A reference to this instance with oldChar replaced by newChar.</returns>
        public StringBuilder Replace(char oldChar, char newChar)
        {
            return Replace(oldChar, newChar, 0, Length);
        }

        /// <summary>
        /// Replaces, within a substring of this instance, all occurrences of a specified string with another specified string. 
        /// </summary>
        /// <param name="oldValue">The string to replace.</param>
        /// <param name="newValue">The string that replaces oldValue, or null.</param>
        /// <param name="startIndex">The position in this instance where the substring begins.</param>
        /// <param name="count">The length of the substring.</param>
        /// <returns>A reference to this instance with all instances of oldValue replaced by newValue in the range from startIndex to startIndex + count - 1.</returns>
        public StringBuilder Replace(string oldValue, string newValue, int startIndex, int count)
        {
            var length = Length;
            if (startIndex > length) throw new ArgumentOutOfRangeException("startIndex");
            if (count < 0 || startIndex > length - count) throw new ArgumentOutOfRangeException("count");
            if (oldValue == null) throw new ArgumentNullException("oldValue");
            if (oldValue.Length == 0) throw new ArgumentException("oldValue");
            if (newValue == null) newValue = string.Empty;

            var newLength = newValue.Length;
            var oldLength = oldValue.Length;
            int[] sourceArray = null;
            var replacementsCount = 0;
            var chunk = FindChunkForIndex(startIndex);
            var indexInChunk = startIndex - chunk._chunkOffset;
            //While there is a replacement remaining
            while (count > 0)
            {
                //If the old value if found in the chunk at the index
                if (StartsWith(chunk, indexInChunk, count, oldValue))
                {
                    //If we need to allocate for a match then do so
                    if (sourceArray == null)
                    {
                        sourceArray = new int[5];
                    }
                    else if (replacementsCount >= sourceArray.Length)
                    {
                        //We have more matches than allocated for resize the buffer
                        var destinationArray = new int[sourceArray.Length * 3 / 2 + 4];
                        Array.Copy(sourceArray, destinationArray, sourceArray.Length);
                        sourceArray = destinationArray;
                    }
                    //Save the index in the next avilable replacement slot
                    sourceArray[replacementsCount] = indexInChunk;
                    ++replacementsCount;
                    //Move the index pointer
                    indexInChunk += oldLength;
                    //Decrement the count
                    count -= oldLength;
                }
                else
                {

                    //A match at the index was not found
                    //Move the pointer
                    ++indexInChunk;
                    //Decrement the count
                    --count;
                }
                //If we are past the chunk boundry or the no replacements remaining
                if (indexInChunk >= chunk._chunkLength || count == 0)
                {
                    //Determine the index
                    var index = indexInChunk + chunk._chunkOffset;
                    //Replace the remaining characters
                    ReplaceAllInChunk(sourceArray, replacementsCount, chunk, oldLength, newValue);
                    //Move the index
                    index += (newLength - oldLength) * replacementsCount;
                    //Resert the replacements count
                    replacementsCount = 0;
                    //Find the next chunk and continue
                    chunk = FindChunkForIndex(index);
                    //Move the index reletive to inside the chunk
                    indexInChunk = index - chunk._chunkOffset;
                }
            }
            return this;
        }

        /// <summary>
        /// Replaces all occurrences of a specified string in this instance with another specified string. 
        /// </summary>
        /// <param name="oldValue">The string to replace.</param>
        /// <param name="newValue">The string that replaces oldValue, or null.</param>
        /// <returns>A reference to this instance with all instances of oldValue replaced by newValue.</returns>
        public StringBuilder Replace(string oldValue, string newValue)
        {
            return Replace(oldValue, newValue, 0, Length);
        }

        /// <summary>
        /// Appends a copy of the specified string followed by the default line terminator to the end of the current StringBuilder object.
        /// </summary>
        /// <param name="str">A reference to this instance after the append operation has completed.</param>
        public StringBuilder AppendLine(string str)
        {
            Append(str);
            return AppendLine();
        }

        /// <summary>
        /// Appends the default line terminator to the end of the current StringBuilder object.
        /// </summary>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder AppendLine()
        {
            return Append("\r\n");
        }

        #endregion

        #region Internals

        internal int EnsureCapacity(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException("capacity");
            if (Capacity < capacity) Capacity = capacity;

            return Capacity;
        }

        internal bool StartsWith(StringBuilder chunk, int indexInChunk, int count, string value)
        {
            for (int i = 0, e = value.Length; i < e; ++i)
            {
                if (count == 0) return false;
                if (indexInChunk >= chunk._chunkLength)
                {
                    chunk = Next(chunk);
                    if (chunk == null) return false;
                    indexInChunk = 0;
                }
                if (value[i] != chunk._chunkChars[indexInChunk]) return false;
                ++indexInChunk;
                --count;
            }
            return true;
        }

        internal void ReplaceAllInChunk(int[] replacements, int replacementsCount, StringBuilder sourceChunk, int removeCount, string value)
        {
            //If there is a replacement to occur
            if (replacementsCount > 0)
            {
                //Determine the cmount of characters to remove
                var count = (value.Length - removeCount) * replacementsCount;
                //Scope the working chunk
                var chunk = sourceChunk;
                //Determine the index of the first replacement
                var indexInChunk = replacements[0];
                //If there is a character being added make room
                if (count > 0) MakeRoom(chunk._chunkOffset + indexInChunk, count, out chunk, out indexInChunk, true);
                //Start at the first replacement
                var index = 0;
                var replacementIndex = 0;
                var chars = value.ToCharArray();
ReplaceValue:
//Replace the value                 
                ReplaceInPlaceAtChunk(ref chunk, ref indexInChunk, chars, ref replacementIndex, value.Length);
                if (replacementIndex == value.Length) replacementIndex = 0;

                //Determine the next replacement 
                var valueIndex = replacements[index] + removeCount;
                //Move the pointer of the working replacement
                ++index;
                //If we are not past the replacement boundry
                if (index < replacementsCount)
                {
                    //Determine the next replacement
                    var nextIndex = replacements[index];
                    //If there is a character remaining to be replaced
                    if (count != 0)
                    {
                        //Replace it
                        ReplaceInPlaceAtChunk(ref chunk, ref indexInChunk, sourceChunk._chunkChars, ref valueIndex, nextIndex - valueIndex);
                    }//Move the pointer
                    else indexInChunk += nextIndex - valueIndex;
                    goto ReplaceValue;//Finish replacing
                }
                //We are are done and there is charcters to be removed they are at the end
                if (count < 0)
                {
                    //Remove them by negating the count to make it positive the chars removed are from (chunk.m_ChunkOffset + indexInChunk) to -count
                    Remove(chunk._chunkOffset + indexInChunk, -count, out chunk, out indexInChunk);
                }
            }
        }

        internal StringBuilder Next(StringBuilder chunk)
        {
            return chunk == this ? null : FindChunkForIndex(chunk._chunkOffset + chunk._chunkLength);
        }

        private void ReplaceInPlaceAtChunk(ref StringBuilder chunk, ref int indexInChunk, char[] value, ref int valueIndex, int count)
        {
            if (count == 0) return;

            while (true)
            {
                //int num = chunk.m_ChunkLength - indexInChunk;
                var length = Math.Min(chunk._chunkLength - indexInChunk, count);
                //ThreadSafeCopy(value, ref valueIndex, chunk.m_ChunkChars, ref indexInChunk, num2);
                Array.Copy(value, valueIndex, chunk._chunkChars, indexInChunk, length);
                indexInChunk += length;
                if (indexInChunk >= chunk._chunkLength)
                {
                    chunk = Next(chunk);
                    indexInChunk = 0;
                }
                count -= length;
                valueIndex += length;
                if (count == 0) return;
            }
        }

        internal void MakeRoom(int index, int count, out StringBuilder chunk, out int indexInChunk, bool doneMoveFollowingChars)
        {
            if (count + Length > _maxCapacity) throw new ArgumentOutOfRangeException("requiredLength");
            chunk = this;
            while (chunk._chunkOffset > index)
            {
                chunk._chunkOffset += count;
                chunk = chunk._chunkPrevious;
            }
            indexInChunk = index - chunk._chunkOffset;
            if (!doneMoveFollowingChars && chunk._chunkLength <= 0x20 && chunk._chunkChars.Length - chunk._chunkLength >= count)
            {
                var chunkLength = chunk._chunkLength;
                while (chunkLength > indexInChunk)
                {
                    chunkLength--;
                    chunk._chunkChars[chunkLength + count] = chunk._chunkChars[chunkLength];
                }
                chunk._chunkLength += count;
            }
            else
            {
                var builder = new StringBuilder(Math.Max(count, 0x10), chunk._maxCapacity, chunk._chunkPrevious);
                builder._chunkLength = count;
                var length = Math.Min(count, indexInChunk);
                if (length > 0)
                {
                    Array.Copy(chunk._chunkChars, 0, builder._chunkChars, 0, length);
                    var nextLength = indexInChunk - length;
                    if (nextLength >= 0)
                    {
                        Array.Copy(chunk._chunkChars, length, chunk._chunkChars, 0, nextLength);
                        indexInChunk = nextLength;
                    }
                }
                chunk._chunkPrevious = builder;
                chunk._chunkOffset += count;
                if (length < count)
                {
                    chunk = builder;
                    indexInChunk = length;
                }
            }
        }

        internal StringBuilder FindChunkForIndex(int index)
        {
            var chunkPrevious = this;
            while (chunkPrevious._chunkOffset > index) chunkPrevious = chunkPrevious._chunkPrevious;
            return chunkPrevious;
        }

        internal void AppendHelper(ref string value)
        {
            if (value == null || value == string.Empty) return;
            Append(value.ToCharArray(), value.Length);
        }

        internal void ExpandByABlock(int minBlockCharCount)
        {
            if (minBlockCharCount + Length > _maxCapacity) throw new ArgumentOutOfRangeException("requiredLength");
            var num = Math.Max(minBlockCharCount, Math.Min(Length, 0x1f40));
            _chunkPrevious = new StringBuilder(this);
            _chunkOffset += _chunkLength;
            _chunkLength = 0;
            //If Allocated does not match required storage
            if (_chunkOffset + num < num)
            {
                _chunkChars = null;
                throw new OutOfMemoryException();
            }
            _chunkChars = new char[num];
        }

        internal void Remove(int startIndex, int count, out StringBuilder chunk, out int indexInChunk)
        {
            var num = startIndex + count;
            chunk = this;
            StringBuilder builder = null;
            var sourceIndex = 0;
            while (true)
            {
                if (num - chunk._chunkOffset >= 0)
                {
                    if (builder == null)
                    {
                        builder = chunk;
                        sourceIndex = num - builder._chunkOffset;
                    }
                    if (startIndex - chunk._chunkOffset >= 0)
                    {
                        indexInChunk = startIndex - chunk._chunkOffset;
                        var destinationIndex = indexInChunk;
                        var num4 = builder._chunkLength - sourceIndex;
                        if (builder != chunk)
                        {
                            destinationIndex = 0;
                            chunk._chunkLength = indexInChunk;
                            builder._chunkPrevious = chunk;
                            builder._chunkOffset = chunk._chunkOffset + chunk._chunkLength;
                            if (indexInChunk == 0)
                            {
                                builder._chunkPrevious = chunk._chunkPrevious;
                                chunk = builder;
                            }
                        }
                        builder._chunkLength -= sourceIndex - destinationIndex;
                        if (destinationIndex != sourceIndex)
                        {
                            //ThreadSafeCopy(builder.m_ChunkChars, ref sourceIndex, builder.m_ChunkChars, ref destinationIndex, num4);
                            Array.Copy(builder._chunkChars, sourceIndex, builder._chunkChars, destinationIndex, num4);
                        }
                        return;
                    }
                }
                else chunk._chunkOffset -= count;
                chunk = chunk._chunkPrevious;
            }
        }

        internal void Append(char[] value, int valueCount)
        {
            var num = valueCount + _chunkLength;
            if (num <= _chunkChars.Length)
            {
                //ThreadSafeCopy(value, this.m_ChunkChars, this.m_ChunkLength, valueCount);
                Array.Copy(value, 0, _chunkChars, _chunkLength, valueCount);
                _chunkLength = num;
            }
            else
            {
                var count = _chunkChars.Length - _chunkLength;
                if (count > 0)
                {
                    //ThreadSafeCopy(value, this.m_ChunkChars, this.m_ChunkLength, count);
                    Array.Copy(value, 0, _chunkChars, _chunkLength, count);
                    _chunkLength = _chunkChars.Length;
                }
                var minBlockCharCount = valueCount - count;
                ExpandByABlock(minBlockCharCount);
                //ThreadSafeCopy(value + count, this.m_ChunkChars, 0, minBlockCharCount);
                Array.Copy(value, count, _chunkChars, 0, minBlockCharCount);
                _chunkLength = minBlockCharCount;
            }
        }

        #endregion        
    }
}
