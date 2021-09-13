using System;

namespace _05._Square_Frame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write("+ ");
            for (int top = 1; top < n-1; top++)
            {
                Console.Write("- " );
            }
            Console.Write("+");
            Console.WriteLine();

            for (int i = 1; i < n-1; i++)
            {
                Console.Write("| ");
                for (int j = 1; j < n - 1; j++)
                {
                    Console.Write("- ");
                }
                Console.Write("|");
                Console.WriteLine();
            }

            Console.Write("+ ");
            for (int down = 1; down < n - 1; down++)
            {
                Console.Write("- ");
            }
            Console.Write("+");
        }
    }
}
