using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double precent = double.Parse(Console.ReadLine());
            double volum = length * width * height;
            double allliters = volum * 0.001;
            double precentsand = precent * 0.01;
            double liters = allliters * (1 - precentsand);
            Console.WriteLine("{0:f3}",liters);


        }
    }
}
