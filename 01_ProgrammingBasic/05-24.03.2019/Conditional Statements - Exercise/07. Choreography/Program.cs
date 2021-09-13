using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            double steps = int.Parse(Console.ReadLine());
            double dancers = int.Parse(Console.ReadLine());
            double days = int.Parse(Console.ReadLine());

            double StepsOfDay = ((steps / days) / steps)*100;
            double precentStepsOfDay = Math.Ceiling(StepsOfDay);
            double precentStepsOfDancer = precentStepsOfDay / dancers;

            if (precentStepsOfDay <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {precentStepsOfDancer:f2}%.");
            }
            else
            {
                Console.WriteLine($"No, they will not succeed in that goal! Required {precentStepsOfDancer:f2}% steps to be learned per day.");
            }

        }
    }
}
