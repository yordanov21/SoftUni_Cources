namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item, null, null);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                var oldHead = this.head;
                oldHead.Previous = newNode;

                this.head = newNode;
                this.head.Next = oldHead;
            }

            ++this.Count;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item, null, null);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                var oldTail = this.tail;
                oldTail.Next = newNode;

                this.tail = newNode;
                this.tail.Previous = oldTail;
            }
            ++this.Count;
        }

        public T GetFirst()
        {
            checkForEmptyList();

            return this.head.Item;
        }

        public T GetLast()
        {
            checkForEmptyList();

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            checkForEmptyList();


            var oldHeadItem = this.head.Item;
            var newHead = this.head.Next;
            // newHead.Previous = null;
            this.head = newHead;

            --this.Count;
            return oldHeadItem;
        }

        public T RemoveLast()
        {
            checkForEmptyList();

            var oldTailItem = this.tail.Item;
            var newTail = this.tail.Previous;
            // newTail.Next = null;
            tail = newTail;

            --this.Count;
            return oldTailItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                // yield return enumerator
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void checkForEmptyList()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
        }
    }
}