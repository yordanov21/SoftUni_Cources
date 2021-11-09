using System;

namespace _05GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                box.Values.Add(input);
            }

            string targetItem = Console.ReadLine();

           int result= box.GreaterValuesThan(targetItem);
            Console.WriteLine(result);
        }
    }
}
