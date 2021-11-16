namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _last;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newHead = new Node<T>(item);
            newHead.Next = _head;

            this._head = newHead;
            ++this.Count;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (this._head is null)
            {
                this._head = newNode;
            } 
            else
            {
                var current = this._head;

                while (current.Next != null)
                {
                    current = current.Next;
                }
                   
                current.Next = newNode;
            }

            ++this.Count;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();

            return this._head.Value;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();

            var current = this._head;
            while (current.Next != null)
            {
                current = current.Next;
            }


            return current.Value;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();

            var oldHead = _head;
            var newHead = this._head.Next;
            this._head.Next = null;
            this._head = newHead;
            this.Count--;

            return oldHead.Value;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();

            // new way for check
            if (this._head.Next is null)
            {
                return this.RemoveFirst();
            }

            var current = this._head;

            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            var lastValue = current.Next.Value;

            current.Next = null;
            --this.Count;

            return lastValue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Lincked List is empty");
            }

        }
    }
}