using System;

namespace _11._Increasing_4_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = a; i <= b; i++)
            {
                for (int j = i+1; j <= b; j++)
                {
                    for (int k = j+1; k <= b; k++)
                    {
                        for (int g = k+1; g <= b; g++)
                        {
                            Console.WriteLine($"{i} {j} {k} {g}");
                            count++;
                        }
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
