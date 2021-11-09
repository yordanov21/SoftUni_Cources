using System;
using System.Linq;
namespace _03GenericSwapMethodString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
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
