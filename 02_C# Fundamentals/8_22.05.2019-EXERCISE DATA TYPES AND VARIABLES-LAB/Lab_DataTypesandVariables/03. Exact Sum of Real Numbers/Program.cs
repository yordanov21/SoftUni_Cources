using System;

namespace _03._Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            decimal counter = 0;
            for (int i = 1; i <= numbers; i++)
            {
                decimal Num = decimal.Parse(Console.ReadLine());
                counter += Num;
            }
            Console.WriteLine(counter);
        }
    }
}
