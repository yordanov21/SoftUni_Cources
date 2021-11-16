namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _last;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            bool contains = false;
            var checkNode = this._last;

            while (checkNode != null)
            {
                //  this.EnsureNotEmpty();

                var topNodeItem = checkNode.Item;

                int result = Compare(topNodeItem, item); // Comparer<int>.Default will be used
                if (result == 1)
                {
                    contains = true;
                    break;
                }

                var newTop = checkNode.Next;
                checkNode.Next = null;
                checkNode = newTop;
            }

            return contains;
        }

        public T Dequeue()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            var oldHead = _head;
            _head = _head.Next;

            if(_head == null)
            {
                this._last = null;

            }

            if(Count > 0)
            {
                Count--;
            }

            return oldHead.Item;
        }

        public void Enqueue(T item)
        {
            Node<T> newLast = new Node<T>(item);

            if(_last == null)
            {
                _last = newLast;
                _head = newLast;
            }
            else
            {
                _last.Next = newLast;
                _last = newLast;
            }

            this.Count++;
        }

        public T Peek()
        {
            if(_head == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

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
    }
}