using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Walking2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int steps = 0;
            while (steps < 10000)
            {
                string comand = Console.ReadLine();
                if (comand=="Going home")
                {
                    steps += int.Parse(Console.ReadLine());
                    if (steps >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                    else
                    {
                        int diff = 10000 - steps;
                        Console.WriteLine($"{diff} more steps to reach goal.");
                        break;
                    }
                }
                else
                {
                    steps += int.Parse(comand);
                    if (steps >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                }
            }
            
        }
    }
}
