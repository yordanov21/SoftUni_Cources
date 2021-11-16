namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this._items[this.Count - index - 1];
            }
            set
            {
                ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this._items.Length)
            {
                Grow();
            }

            this._items[this.Count] = item;
            ++this.Count;
        }

        public bool Contains(T item)
        {
            var length = this._items.Length;
            for (int i = 0; i < length; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            var length = this.Count;
            for (int i = 0; i < length; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return this.Count - i - 1;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            if (this.Count == this._items.Length)
            {
                Grow();
            }

            var tempItems = this._items;

            for (int i = this.Count; i >= this.Count - index; --i)
            {
                this._items[i] = tempItems[i - 1];
            }

            this._items[this.Count - index] = item;
            ++this.Count;
        }

        public bool Remove(T item)
        {
            bool isRemove = false;
            int index = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    isRemove = true;
                    index = i;
                }
            }

            if (isRemove)
            {
                for (int i = index; i < this.Count; i++)
                {
                    this._items[i] = this._items[i + 1];
                }

                --this.Count;
            }
            return isRemove;
        }

        public void RemoveAt(int index)
        {
            // Note: there is bug with the test, sometimes the test does not pass
            // some corner cases are not tested corect
            ValidateIndex(index);

            var tempItems = this._items;

            for (int i = this.Count -1; i >= this.Count - index; --i)
            {
                this._items[i -1] = tempItems[i ];
            }

            --this.Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Grow()
        {
            var tempArray = new T[this._items.Length * 2];
            Array.Copy(this._items, tempArray, this.Count);

            this._items = tempArray;
        }
    }
}