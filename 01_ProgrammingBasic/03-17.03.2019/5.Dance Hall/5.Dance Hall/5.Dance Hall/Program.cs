using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double LeightHall = double.Parse(Console.ReadLine());
            double WidhtHall = double.Parse(Console.ReadLine());
            double Awardrobe = double.Parse(Console.ReadLine());
            double areaHall = LeightHall * 100 * WidhtHall * 100;
            double areaWardrobe = Awardrobe *100* Awardrobe * 100;
            double bench = areaHall * 0.1;
            double areaDancer =40+7000;
            double dancers = (areaHall - areaWardrobe - bench) / areaDancer;
            Console.WriteLine(Math.Floor(dancers));

        }
    }
}
