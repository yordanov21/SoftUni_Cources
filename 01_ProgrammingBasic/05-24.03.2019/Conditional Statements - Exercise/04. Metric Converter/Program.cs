using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string input1 =Console.ReadLine();
            string output2 = Console.ReadLine();

            if (input1 == "mm")
            {
                num /= 1000;
            }
            else if(input1=="cm")
            {
                num /= 100;
            }
            if (output2 == "mm")
            {
                num *= 1000;
            }
            else if (output2 == "cm")
            {
                num *= 100;
                
            }
            Console.WriteLine($"{num:f3}");
        }
    }
}
