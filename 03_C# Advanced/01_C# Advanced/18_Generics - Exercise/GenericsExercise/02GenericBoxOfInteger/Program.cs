using System;

namespace _02GenericBoxOfInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                int input =int.Parse( Console.ReadLine());
                Box<int> box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}
