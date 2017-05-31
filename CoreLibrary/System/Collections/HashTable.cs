//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Collections
{
    /// <summary>
    /// HashTable is an Associative Container.
    /// Created in March 2010.
    /// by Eric Harlow.
    /// </summary>
    public class Hashtable : ICloneable, IDictionary
    {
        private Entry[] _buckets;
        private int _numberOfBuckets;
        private int _count;
        private int _loadFactor;
        private int _maxLoadFactor;
        private double _growthFactor;
        private const int HashTableDefaultCapacity = 4;
        private const int HashTableDefaultLoadFactor = 2;

        /// <summary>
        /// Initializes a new, empty instance of the Hashtable class using the default initial capacity and load factor.
        /// </summary>
        public Hashtable()
        {
            InitializeHashTable(HashTableDefaultCapacity, HashTableDefaultLoadFactor);
        }

        /// <summary>
        /// Initializes a new, empty instance of the Hashtable class using the specified initial capacity, 
        /// and the default load factor.
        /// </summary>
        /// <param name="capacity">The initial capacity of the HashTable</param>
        public Hashtable(int capacity)
        {
            InitializeHashTable(capacity, HashTableDefaultLoadFactor);
        }

        /// <summary>
        /// Initializes a new, empty instance of the Hashtable class using the specified initial capacity, 
        /// load factor.
        /// </summary>
        /// <param name="capacity">The initial capacity of the HashTable</param>
        /// <param name="maxLoadFactor">The load factor to cause a rehash</param>
        public Hashtable(int capacity, int maxLoadFactor)
        {
            InitializeHashTable(capacity, maxLoadFactor);
        }

        //initialize attributes
        private void InitializeHashTable(int capacity, int maxLoadFactor)
        {
            _buckets = new Entry[capacity];
            _numberOfBuckets = capacity;
            _maxLoadFactor = maxLoadFactor;
            _growthFactor = 2;
        }

        /// <summary>
        /// MaxLoadFactor Property is the value used to trigger a rehash.
        /// Default value is 2.
        /// A higher number can decrease lookup performance for large collections.
        /// While a value of 1 maintains a constant time complexity at the cost of increased memory requirements.   
        /// </summary>
        public int MaxLoadFactor
        {
            get { return _maxLoadFactor; }
            set { _maxLoadFactor = value; }
        }

        /// <summary>
        /// GrowthFactor Property is a multiplier to increase the HashTable size by during a rehash.
        /// Default value is 2.
        /// </summary>
        public double GrowthFactor
        {
            get { return _growthFactor; }
            set { _growthFactor = value; }
        }

        //adding for internal purposes
        private void Add(ref Entry[] buckets, object key, object value, bool overwrite)
        {
            var whichBucket = Hash(key, _numberOfBuckets);
            var match = EntryForKey(key, buckets[whichBucket]);

            if (match != null && overwrite)
            { //i.e. already exists in table
                match.value = value;
                return;
            }
            if (match != null && !overwrite) throw new ArgumentException("key exists");
            // insert at front
            var newOne = new Entry(key, value, ref buckets[whichBucket]);
            buckets[whichBucket] = newOne;
            _count++;

            _loadFactor = _count / _numberOfBuckets;
        }

        // Hash function.
        private int Hash(object key, int numOfBuckets)
        {
            var hashcode = key.GetHashCode();

            if (hashcode < 0) hashcode = hashcode * -1;     // don't know how to mod with a negative number

            return hashcode % numOfBuckets;
        }

        //looks up value in bucket
        private Entry EntryForKey(object key, Entry head)
        {
            for (var cur = head; cur != null; cur = cur.next)
                if (cur.key.Equals(key)) return cur;
            return null;
        }

        //Rehashes the table to reduce the load factor
        private void Rehash(int newSize)
        {
            var newTable = new Entry[newSize];
            _numberOfBuckets = newSize;
            _count = 0;
            for (var i = 0; i < _buckets.Length; i++)
            {
                if (_buckets[i] != null)
                {
                    for (var cur = _buckets[i]; cur != null; cur = cur.next)
                        Add(ref newTable, cur.key, cur.value, false);
                }
            }
            _buckets = newTable;
        }

        //implementation for KeyCollection and ValueCollection copyTo method
        private void CopyToCollection(Array array, int index, EnumeratorType type)
        {
            if (index < 0 && index > _numberOfBuckets) throw new IndexOutOfRangeException("index");

            var j = 0;
            var len = array.Length;

            for (var i = index; i < _numberOfBuckets; i++)
            {
                for (var cur = _buckets[i]; cur != null && j < len; cur = cur.next)
                {
                    if (type == EnumeratorType.KEY) ((IList)array)[j] = cur.key;
                    else ((IList)array)[j] = cur.value;

                    j++;
                }
            }
        }

        #region ICloneable Members
        /// <summary>
        /// Make a new object which is a copy of the object instanced.
        /// </summary>
        /// <returns>A new object that represents a clone of the object.</returns>
        public object Clone()
        {
            var ht = new Hashtable();
            ht.InitializeHashTable(_numberOfBuckets, _maxLoadFactor);
            ht._count = _count;
            ht._loadFactor = _loadFactor;
            Array.Copy(_buckets, ht._buckets, _numberOfBuckets);
            return ht;
        }

        #endregion ICloneable Members

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
        public IEnumerator GetEnumerator()
        {
            return new HashtableEnumerator(this, EnumeratorType.DE);
        }

        #endregion IEnumerable Members

        #region ICollection Members

        /// <summary>
        /// Gets the number of elements contained in the ICollection.
        /// </summary>
        /// <value>
        /// The number of elements contained in the ICollection.
        /// </value>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the ICollection is synchronized (thread safe).
        /// </summary>
        /// <value>
        /// true if access to the ICollection is synchronized (thread safe); otherwise, false.
        /// </value>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the ICollection.
        /// </summary>
        /// <value>
        /// An object that can be used to synchronize access to the ICollection.
        /// </value>
        public object SyncRoot
        {
            get { return this; }
        }

        /// <summary>
        /// Copies the elements of the ICollection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from ICollection. The Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            if (index < 0 && index > _buckets.Length) throw new IndexOutOfRangeException("index");

            var j = 0;
            var len = array.Length;
            for (var i = index; i < _buckets.Length; i++)
            {
                for (var cur = _buckets[i]; cur != null && j < len; cur = cur.next)
                {
                    ((IList)array)[j] = new DictionaryEntry(cur.key, cur.value);
                    j++;
                }
            }
        }

        #endregion ICollection Members

        #region IDictionary Members

        /// <summary>
        /// Gets a value indicating whether the IDictionary object is read-only.
        /// </summary>
        /// <value>
        /// true if the IDictionary object is read-only; otherwise, false.
        /// </value>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether the IDictionary object has a fixed size.
        /// </summary>
        /// <value>
        /// true if the IDictionary object has a fixed size; otherwise, false.
        /// </value>
        public bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an ICollection object containing the keys of the IDictionary object.
        /// </summary>
        /// <value>
        /// An ICollection object containing the keys of the IDictionary object.
        /// </value>
        public ICollection Keys
        {
            get
            {
                return new KeyCollection(this);
            }
        }

        /// <summary>
        /// Gets an ICollection object containing the values in the IDictionary object.
        /// </summary>
        /// <value>
        /// An ICollection object containing the values in the IDictionary object.
        /// </value>
        public ICollection Values
        {
            get
            {
                return new ValueCollection(this);
            }
        }

        /// <summary>
        /// Gets or sets the element with the specified key.
        /// </summary>
        /// <param name="key">The key of the element to get or set.</param>
        /// <returns>The element with the specified key, or null if the key does not exist.</returns>
        public object this[object key]
        {
            get
            {
                if (key == null) throw new ArgumentNullException("key is null");
                var whichBucket = Hash(key, _numberOfBuckets);
                var match = EntryForKey(key, _buckets[whichBucket]);

                return match != null ? match.value : null;
            }
            set
            {
                if (key == null) throw new ArgumentNullException("key is null");

                Add(ref _buckets, key, value, true);
                if (_loadFactor >= _maxLoadFactor) Rehash((int)(_numberOfBuckets * _growthFactor));
            }
        }

        /// <summary>
        /// Adds an element with the provided key and value to the IDictionary object.
        /// </summary>
        /// <param name="key">The Object to use as the key of the element to add.</param>
        /// <param name="value">The Object to use as the value of the element to add.</param>
        public void Add(object key, object value)
        {
            if (key == null) throw new ArgumentNullException("key is null");

            Add(ref _buckets, key, value, false);
            if (_loadFactor >= _maxLoadFactor) Rehash((int)(_numberOfBuckets * _growthFactor));
        }

        /// <summary>
        /// Removes all elements from the IDictionary object.
        /// </summary>
        public void Clear()
        {
            _buckets = new Entry[HashTableDefaultCapacity];
            _numberOfBuckets = HashTableDefaultCapacity;
            _loadFactor = 0;
            _count = 0;
        }

        /// <summary>
        /// Determines whether the IDictionary object contains an element with the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the IDictionary object.</param>
        /// <returns>true if the IDictionary contains an element with the key; otherwise, false.</returns>
        public bool Contains(object key)
        {
            if (key == null) throw new ArgumentNullException("key is null");
            var whichBucket = Hash(key, _numberOfBuckets);
            var match = EntryForKey(key, _buckets[whichBucket]);

            return match != null;
        }

        /// <summary>
        /// Removes the element with the specified key from the IDictionary object.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        public void Remove(object key)
        {
            if (key == null) throw new ArgumentNullException("key is null");
            var whichBucket = Hash(key, _numberOfBuckets);
            var match = EntryForKey(key, _buckets[whichBucket]);

            //does entry exist?
            if (match == null) return;

            //is entry at front?
            if (_buckets[whichBucket] == match)
            {
                _buckets[whichBucket] = match.next;
                _count--;
                return;
            }

            //handle entry in middle and at the end
            for (var cur = _buckets[whichBucket]; cur != null; cur = cur.next)
            {
                if (cur.next == match)
                {
                    cur.next = match.next;
                    _count--;
                    return;
                }
            }
        }

        #endregion IDictionary Members

        private class Entry
        {
            public readonly Object key;
            public Object value;
            public Entry next;

            public Entry(object key, object value, ref Entry n)
            {
                this.key = key;
                this.value = value;
                next = n;
            }
        }

        private class HashtableEnumerator : IEnumerator
        {
            private readonly Hashtable _ht;
            private Entry _temp;
            private Int32 _index = -1;
            private readonly EnumeratorType _returnType;

            public HashtableEnumerator(Hashtable hashtable, EnumeratorType type)
            {
                _ht = hashtable;
                _returnType = type;
            }

            // Return the current item.
            public Object Current
            {
                get
                {
                    switch (_returnType)
                    {
                        case EnumeratorType.DE:
                        return new DictionaryEntry(_temp.key, _temp.value);

                        case EnumeratorType.KEY:
                        return _temp.key;

                        case EnumeratorType.VALUE:
                        return _temp.value;
                    }
                    return new DictionaryEntry(_temp.key, _temp.value);
                }
            }

            // Advance to the next item.
            public Boolean MoveNext()
            {
startLoop:
//iterate index or list
                if (_temp == null)
                {
                    _index++;
                    if (_index < _ht._numberOfBuckets) _temp = _ht._buckets[_index];
                    else return false;
                }
                else _temp = _temp.next;

                //null check
                if (_temp == null) goto startLoop;

                return true;
            }

            // Reset the index to restart the enumeration.
            public void Reset()
            {
                _index = -1;
            }
        }

        // EnumeratorType - Enum that describes which object the Enumerator's Current property will return.
        private enum EnumeratorType
        {
            // DictionaryEntry object. 
            DE,
            // Key object.
            KEY,
            // Value object.
            VALUE
        }

        private class KeyCollection : ICollection
        {
            private readonly Hashtable _ht;

            public KeyCollection(Hashtable hashtable)
            {
                _ht = hashtable;
            }

            #region ICollection Members

            public int Count
            {
                get
                {
                    return _ht._count;
                }
            }

            public bool IsSynchronized
            {
                get
                {
                    return _ht.IsSynchronized;
                }
            }

            public object SyncRoot
            {
                get
                {
                    return _ht.SyncRoot;
                }
            }

            public void CopyTo(Array array, int index)
            {
                _ht.CopyToCollection(array, index, EnumeratorType.KEY);
            }

            #endregion

            #region IEnumerable Members

            public IEnumerator GetEnumerator()
            {
                return new HashtableEnumerator(_ht, EnumeratorType.KEY);
            }

            #endregion
        }

        private class ValueCollection : ICollection
        {
            private readonly Hashtable _ht;

            public ValueCollection(Hashtable hashtable)
            {
                _ht = hashtable;
            }

            #region ICollection Members

            public int Count
            {
                get
                {
                    return _ht._count;
                }
            }

            public bool IsSynchronized
            {
                get
                {
                    return _ht.IsSynchronized;
                }
            }

            public object SyncRoot
            {
                get
                {
                    return _ht.SyncRoot;
                }
            }

            public void CopyTo(Array array, int index)
            {
                _ht.CopyToCollection(array, index, EnumeratorType.VALUE);
            }

            #endregion

            #region IEnumerable Members

            public IEnumerator GetEnumerator()
            {
                return new HashtableEnumerator(_ht, EnumeratorType.VALUE);
            }

            #endregion
        }
    }
}
