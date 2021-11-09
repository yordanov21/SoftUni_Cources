using System;
using System.Linq;

namespace _04GenericSwapMethodInteger
{
     public class Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int input =int.Parse( Console.ReadLine());
                box.Values.Add(input);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int a = indexes[0];
            int b = indexes[1];
            box.Swap(a, b);

            Console.WriteLine(box);
        }
    }
}
