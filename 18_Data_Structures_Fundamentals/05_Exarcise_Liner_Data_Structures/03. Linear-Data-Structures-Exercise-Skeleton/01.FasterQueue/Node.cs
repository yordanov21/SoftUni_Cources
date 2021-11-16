﻿namespace Problem01.FasterQueue
{
    public class Node<T>
    {
        public Node(T item, Node<T> next)
        {
            this.Item = item;
            this.Next = next;
        }
        public Node()
        {

        }

        public T Item { get; set; }

        public Node<T> Next { get; set; }
    }
}