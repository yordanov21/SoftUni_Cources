using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.perimetur.area.surcle
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double area = Math.PI * r*r;
            double perimetur = 2 * Math.PI * r;
            Console.WriteLine("{0:f2}",area);
            Console.WriteLine("{0:f2}", perimetur);

        }
    }
}
