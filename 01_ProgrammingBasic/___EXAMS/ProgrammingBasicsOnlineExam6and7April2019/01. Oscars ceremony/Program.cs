using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Oscars_ceremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());
            double oscars = rent * 0.70;
            double ketaring = oscars * 0.85;
            double sound = 0.50 * ketaring;
            double allcost = rent + oscars + ketaring + sound;
            Console.WriteLine($"{allcost:f2}");
        }
    }
}
