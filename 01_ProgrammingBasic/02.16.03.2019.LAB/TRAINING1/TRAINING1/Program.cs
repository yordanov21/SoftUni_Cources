using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAINING1
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double suma = double.Parse(Console.ReadLine());
            double precent = 100-(number / suma)*100;
            Console.WriteLine(precent);
        }
    }
}
