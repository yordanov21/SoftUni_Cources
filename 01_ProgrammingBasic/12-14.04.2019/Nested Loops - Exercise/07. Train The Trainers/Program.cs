using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumvalue = 0;
            double value = 0;
            double Allsumvalue = 0;
            int counter = 0;
            int numJurie = int.Parse(Console.ReadLine());
            string NamePrezentacione = string.Empty;
            while (true)
            {

                NamePrezentacione = Console.ReadLine();
                if (NamePrezentacione == "Finish")
                {
                    Console.WriteLine($"Student's final assessment is {Allsumvalue / counter:f2}.");
                    break;
                }
                for (int i = 1; i <= numJurie; i++)
                {
                    value = double.Parse(Console.ReadLine());
                    sumvalue += value;
                    Allsumvalue += value;
                    counter++;
                }
                Console.WriteLine($"{NamePrezentacione} - {sumvalue / numJurie:f2}.");
                sumvalue = 0;

            }

        }
    }
}
