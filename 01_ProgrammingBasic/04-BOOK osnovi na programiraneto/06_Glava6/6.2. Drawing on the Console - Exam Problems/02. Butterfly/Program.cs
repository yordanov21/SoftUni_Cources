using System;

namespace _02._Butterfly
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stars = n - 2;

            for (int i = 1; i <= n - 2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(new string('-', stars) + "\\" + " " + "/" + new string('-', stars));
                }
                else
                {
                    Console.WriteLine(new string ('*',stars)+"\\"+" "+"/"+new string ('*',stars));
                }               
            }

            Console.WriteLine(new string(' ', stars) + " " + "@" + " " + new string(' ', stars));

            for (int i = 1; i <= n - 2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(new string('-', stars) + "/" + " " + "\\" + new string('-', stars));
                }
                else
                {
                    Console.WriteLine(new string('*', stars) + "/" + " " + "\\" + new string('*', stars));
                }
            }
        }
    }
}
