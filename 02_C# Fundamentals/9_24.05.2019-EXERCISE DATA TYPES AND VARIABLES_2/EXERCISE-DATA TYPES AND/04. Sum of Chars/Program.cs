using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int leterCount = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = 0; i < leterCount; i++)
            {
                char leter = char.Parse(Console.ReadLine());
                counter += leter;
            }
            Console.WriteLine($"The sum equals: {counter}");
        }
    }
}
