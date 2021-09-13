using System;

namespace _16._Number_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int coll = 0; coll < n; coll++)
                {
                    var num = row + coll + 1;
                    if (num > n)
                    {
                        num = 2 * n - num;
                    }
                    Console.Write(num+" " );
                }
                Console.WriteLine();
            }
        }
    }
}
