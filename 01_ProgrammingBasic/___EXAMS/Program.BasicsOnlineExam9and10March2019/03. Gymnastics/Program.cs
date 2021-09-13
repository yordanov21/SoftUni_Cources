using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string appliance = Console.ReadLine();
            
            if (country == "Russia")
            {
                switch (appliance)
                {
                    case "ribbon":
                        double value1 = 9.100 + 9.400;
                        double rest1 = ((20 - value1)/20)*100;
                        Console.WriteLine($"The team of {country} get {value1:f3} on {appliance}.");
                        Console.WriteLine($"{rest1:f2}%");
                        break;
                    case "hoop":
                        double value2 = 9.300 + 9.800;
                        double rest2 = ((20 - value2) / 20) * 100;
                        Console.WriteLine($"The team of {country} get {value2:f3} on {appliance}.");
                        Console.WriteLine($"{rest2:f2}%");
                        break;
                    case "rope":
                        double value3 = 9.600 + 9.000;
                        double rest3 = ((20 - value3) / 20) * 100;
                        Console.WriteLine($"The team of {country} get {value3:f3} on {appliance}.");
                        Console.WriteLine($"{rest3:f2}%");
                        break;
                }                           
            }
            else if (country == "Bulgaria")
            {
                switch (appliance)
                {
                    case "ribbon":
                        double value1 = 9.600 + 9.400;
                        double rest1 = ((20 - value1) / 20) * 100;
                        Console.WriteLine($"The team of {country} get {value1:f3} on {appliance}.");
                        Console.WriteLine($"{rest1:f2}%");
                        break;
                    case "hoop":
                        double value2 = 9.550 + 9.750;
                        double rest2 = ((20 - value2) / 20) * 100;
                        Console.WriteLine($"The team of {country} get {value2:f3} on {appliance}.");
                        Console.WriteLine($"{rest2:f2}%");
                        break;
                    case "rope":
                        double value3 = 9.500 + 9.400;
                        double rest3 = ((20 - value3) / 20) * 100;
                        Console.WriteLine($"The team of {country} get {value3:f3} on {appliance}.");
                        Console.WriteLine($"{rest3:f2}%");
                        break;
                }
            }
            else if (country == "Italy")
            {
                switch (appliance)
                {
                    case "ribbon":
                        double value1 = 9.200 + 9.500;
                        double rest1 = ((20 - value1) / 20) * 100;
                        Console.WriteLine($"The team of {country} get {value1:f3} on {appliance}.");
                        Console.WriteLine($"{rest1:f2}%");
                        break;
                    case "hoop":
                        double value2 = 9.450 + 9.350;
                        double rest2 = ((20 - value2) / 20) * 100;
                        Console.WriteLine($"The team of {country} get {value2:f3} on {appliance}.");
                        Console.WriteLine($"{rest2:f2}%");
                        break;
                    case "rope":
                        double value3 = 9.700 + 9.150;
                        double rest3 = ((20 - value3) / 20) * 100;
                        Console.WriteLine($"The team of {country} get {value3:f3} on {appliance}.");
                        Console.WriteLine($"{rest3:f2}%");
                        break;
                }
            }
           


        }
    }
}
