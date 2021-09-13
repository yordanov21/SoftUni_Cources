using System;

namespace _04._Triangle_of_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 1; row <= n; row++)
            {
                for (int coll = 1; coll < = row; coll++)
                {
                    Console.Write("$ ", StringSplitOptions.RemoveEmptyEntries);
                }
                Console.WriteLine();
            }
        }
    }
}
