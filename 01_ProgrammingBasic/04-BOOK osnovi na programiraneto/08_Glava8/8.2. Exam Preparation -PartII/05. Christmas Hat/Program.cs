using System;

namespace _05._Christmas_Hat
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 1;

            Console.WriteLine(new string('.', n * 2 - 1) + @"/|\" + new string('.', n * 2 - 1));
            Console.WriteLine(new string('.', n * 2 - 1) + @"\|/" + new string('.', n * 2 - 1));
            Console.WriteLine(new string('.', n * 2 - 1) + @"***" + new string('.', n * 2 - 1));

            for (int i = 1; i < n * 2; i++)
            {

                Console.WriteLine(new string('.', n * 2 - 1 - count) + '*' + new string('-', count) + '*' + new string('-', count) + '*' + new string('.', n * 2 - 1 - count));
                count++;
            }

            Console.WriteLine(new string('*', n * 4 +1));
            for (int i = 0; i < n*4+1; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
            Console.WriteLine(new string('*', n * 4+1 ));
        }
    }
}
