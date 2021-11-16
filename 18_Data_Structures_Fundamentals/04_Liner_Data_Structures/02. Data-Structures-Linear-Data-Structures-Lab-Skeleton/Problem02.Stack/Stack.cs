namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;


        public int Count { get; private set; }

        public bool Contains(T item)
        {
            bool contains = false;
            var checkNode = this._top;

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

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._top.Item;
        }

        public T Pop()
        {
            this.EnsureNotEmpty();

            var topNodeItem = this._top.Item;

            var newTop = this._top.Next;

            this._top.Next = null;

            this._top = newTop;
            this.Count--;

            return topNodeItem;
        }

        public void Push(T item)
        {
            var newNode = new Node<T>
            {
                Item = item,
                Next = this._top
            };

            this._top = newNode;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._top;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
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
            => this.GetEnumerator();
    }
}