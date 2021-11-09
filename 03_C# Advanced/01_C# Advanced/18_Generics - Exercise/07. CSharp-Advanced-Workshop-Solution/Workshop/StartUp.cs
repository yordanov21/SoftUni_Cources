using System;
using System.Linq;

namespace Workshop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DoubleLinkedList<int> doubleLinked = new DoubleLinkedList<int>();
            doubleLinked.AddFirst(1);
            doubleLinked.AddFirst(2);
            doubleLinked.AddFirst(3);
            doubleLinked.AddFirst(4);
            doubleLinked.AddFirst(5);
            doubleLinked.ForEach(Console.WriteLine);

        }
    }
}
