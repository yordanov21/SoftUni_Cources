using System;

namespace _04.Print_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstN = int.Parse(Console.ReadLine());
            int secondN = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = firstN; i <= secondN; i++)
            {
                Console.Write($"{i} ");
                sum += i;
               
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
