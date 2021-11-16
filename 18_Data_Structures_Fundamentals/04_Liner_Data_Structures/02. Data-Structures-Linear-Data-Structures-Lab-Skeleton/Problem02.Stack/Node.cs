namespace Problem02.Stack
{
    // recursive data structure
    public class Node<T>
    {
        public Node()
        {
         
        }

        public Node(T item)
        {
            Item = item;
        }
        public T Item { get; internal set; }
        public Node<T> Next { get; internal set; }
    }
}