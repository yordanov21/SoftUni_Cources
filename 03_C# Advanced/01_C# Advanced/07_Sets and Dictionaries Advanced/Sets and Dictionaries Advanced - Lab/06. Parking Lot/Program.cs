using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var splitedInput = input.Split(", ");
                var direction = splitedInput[0];
                var carNum = splitedInput[1];

                if (direction == "IN")
                {
                    carNumbers.Add(carNum);
                }
                else if (direction == "OUT")
                {
                    carNumbers.Remove(carNum);
                }
            }

            if (carNumbers.Count > 0)
            {
                foreach (var carNum in carNumbers)
                {
                    Console.WriteLine(carNum);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
