using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {

            int totalSteps = 0;


            while (totalSteps < 10000)
            {
                string comand = Console.ReadLine();
                if (comand == "Going home")
                {
                    comand = Console.ReadLine();
                    int stepsrest = int.Parse(comand);

                    totalSteps += stepsrest;
                    int stepsDif = 10000 - totalSteps;
                    if (totalSteps >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{stepsDif} more steps to reach goal.");
                        break;
                    }
                }
                int steps = int.Parse(comand);
                totalSteps += steps;

                if (totalSteps >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    break;
                }



            }

        }
    }
}
