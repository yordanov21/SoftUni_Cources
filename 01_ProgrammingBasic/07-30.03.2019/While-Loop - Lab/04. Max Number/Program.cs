using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int count = 0;
            int max = int.MinValue;
            while (number > count)
            {
                int num = int.Parse(Console.ReadLine());
                count++;
                if (num > max)
                {
                    max = num;
                }

            }
            Console.WriteLine(max);
        }
    }
}
