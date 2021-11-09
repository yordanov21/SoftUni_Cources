using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int x = GetMax(a, b);
            Console.WriteLine(GetMax(x,c));
        }

        static int GetMax(int a, int b)
        {
            int max = a;
            if (b > a)
            {
                max = b;
            }

            return max;
        }
    }
}
