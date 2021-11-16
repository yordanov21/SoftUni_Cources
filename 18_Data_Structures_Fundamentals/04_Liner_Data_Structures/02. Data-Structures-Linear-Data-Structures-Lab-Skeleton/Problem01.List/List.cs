namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY)
        {

        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this._items = new T[capacity];
        }

        // indexer 
        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this._items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.GrowIfNecessary();
            this._items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                int result = Compare(this._items[i], item); // Comparer<int>.Default will be used
                if (result == 1)
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                int result = Compare(this._items[i], item); // Comparer<int>.Default will be used
                if (result == 1)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.GrowIfNecessary();

            for (var i = this.Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            bool findItem = false;
            for (int i = 0; i < this.Count - 1; i++)
            {
                if (findItem == false)
                {
                    int result = Compare(this._items[i], item); // Comparer<int>.Default will be used
                    if (result == 1)
                    {
                        findItem = true;
                        this._items[i] = this._items[i + 1];
                    }
                }
                else
                {
                    this._items[i] = this._items[i + 1];
                }
            }

            if (findItem)
            {
                this._items[this.Count - 1] = default;
                this.Count--;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            for (int i = index; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[this.Count - 1] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        private void GrowIfNecessary()
        {
            if (this.Count == this._items.Length)
            {
                this._items = this.Grow();
            }
        }

        private T[] Grow()
        {
            var newArray = new T[this.Count * 2];
            Array.Copy(this._items, newArray, this._items.Length);

            return newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private static int Compare<T>(T v1, T v2, IComparer<T> comparer = null)
        {
            if (null == comparer)              // If we don't have tailored comparer
                comparer = Comparer<T>.Default;  // Try default one

            // If we don't know how to compare - throw exception
            if (null == comparer)
                throw new ArgumentNullException("comparer",
                  $"Type {typeof(T).Name} doesn't have default comparer; comparer must not be null.");

            // Taken from the question: 
            // if (v1.CompareTo(v2) < 0)
            //          return -1;
            //      return 1;
            // You, probably, may want just  
            // return comparer.Compare(v1, v2);
            return comparer.Compare(v1, v2) < 0 ? -1 : 1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}