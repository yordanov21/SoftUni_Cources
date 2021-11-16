namespace Problem04.SinglyLinkedList
{
    // recursive data structure
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }
    }
}