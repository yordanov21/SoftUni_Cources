using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeA = int.Parse(Console.ReadLine());
            int cakeB = int.Parse(Console.ReadLine());

            int CakeArea = cakeA * cakeB;
            int CakePeaces = 0;
            int CakeDiferense = 0;
            string command = Console.ReadLine();

            while (command != "STOP")
            {
                int peaces = int.Parse(command);
                CakePeaces += peaces;
                CakeDiferense = Math.Abs(CakeArea - CakePeaces);
                if (CakePeaces > CakeArea)
                {
                    Console.WriteLine($"No more cake left! You need {CakeDiferense} pieces more.");
                    break;
                }
                command = Console.ReadLine();
                if (command == "STOP")
                {
                    Console.WriteLine($"{CakeDiferense} pieces are left.");
                }
            }

        }
    }
}
