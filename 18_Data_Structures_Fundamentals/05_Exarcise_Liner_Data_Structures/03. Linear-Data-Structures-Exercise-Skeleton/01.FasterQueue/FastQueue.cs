namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var node = this._head;

            while (node != null)
            {
                if(node.Item.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            checkForEmptyQueue();

            // sanity check
            if(this.Count == 1)
            {
                this._tail.Next = null;
            }

            var oldHead = this._head.Item;
            this._head = this._head.Next;
            --this.Count;

            return oldHead;
        }

        public void Enqueue(T item) // constant 
        {
            var newNode = new Node<T>(item, null);

            // first added element
            if(this.Count == 0)
            {
                this._head = newNode;
                this._tail = newNode;

                ++this.Count;
                return;
            }

            // added element to the end of the queue
            this._tail.Next = newNode;
            this._tail = this._tail.Next; // move reference of _tail to the last element of the queue
            ++this.Count;
        }

        public T Peek()
        {
            checkForEmptyQueue();

            return this._head.Item;
        }

        // this enumerator should return all element one by one
        // this happend with when we passed from all element and return every element 
        // with yeild return !!!
        public IEnumerator<T> GetEnumerator()
        {
            var node = this._head;
            while(node != null)
            {
                // yield return enumerator
                yield return node.Item;
                node = node.Next;
            }
        }

        // IEnumerable позволява на колекцията да се интерира т.е да се foreach-не
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void checkForEmptyQueue()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
        }
    }
}