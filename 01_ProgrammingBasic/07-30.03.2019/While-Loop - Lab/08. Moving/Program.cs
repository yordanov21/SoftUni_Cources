using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());
            int volumeRoom = width * length * heigth;
            int totalSPaseBox = 0;
            int DiferenseSpace = 0;

            string comand = Console.ReadLine();
            while (comand != "Done")
            {
                int Boxs = int.Parse(comand);
                
                totalSPaseBox += Boxs;
                DiferenseSpace = Math.Abs(volumeRoom - totalSPaseBox);
                if (totalSPaseBox > volumeRoom)
                {
                    Console.WriteLine($"No more free space! You need {DiferenseSpace} Cubic meters more.");
                    break;
                }
                comand = Console.ReadLine();

                if (comand == "Done")
                {
                    Console.WriteLine($"{DiferenseSpace} Cubic meters left.");
                }
                    
                
            }

            
           
        }
    }
}
