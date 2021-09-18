using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = 1; i <= lines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                counter += letter;
            }
            Console.WriteLine($"The sum equals: {counter}");
        }
    }
}
