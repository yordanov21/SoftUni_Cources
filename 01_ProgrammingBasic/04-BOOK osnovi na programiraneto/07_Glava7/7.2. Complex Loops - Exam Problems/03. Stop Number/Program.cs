using System;
using System.Collections.Generic;

namespace _03._Stop_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());

            int S = int.Parse(Console.ReadLine());
            var list = new List<int>();
            for (int i = M; i >=N; i--)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    if (i == S)
                    {
                        break;
                    }
                    list.Add(i);
                }
            }
            
            Console.WriteLine(string.Join(" ",list));
        }
    }
}
