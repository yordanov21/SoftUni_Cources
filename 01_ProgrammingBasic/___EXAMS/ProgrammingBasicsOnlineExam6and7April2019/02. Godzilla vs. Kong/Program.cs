using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Godzilla_vs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            int statics = int.Parse(Console.ReadLine());
            double dress = double.Parse(Console.ReadLine());

            double decor = 0.10 * bujet;
            if (statics > 150)
            {
                dress = 0.9 * dress;
            }
            double Alldress = statics * dress;
            if ((Alldress + decor) > bujet)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Alldress+decor-bujet:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {bujet- (Alldress + decor):f2} leva left.");
            }
        }
    }
}
