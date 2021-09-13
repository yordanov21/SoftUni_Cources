using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int count = 0;
            int min = int.MaxValue;
            while (number > count)
            {
                int num = int.Parse(Console.ReadLine());
                count++;
                if (num < min)
                {
                    min = num;
                }

            }
            Console.WriteLine(min);
        }
    }
}
