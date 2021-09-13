using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {

            int sumPrime = 0;
            int sumNon = 0;
            while (true)
            {
                string input = Console.ReadLine();
                bool isPrime = true;
                if (input == "stop")
                {
                    break;
                }
                int number = int.Parse(input);
                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                else if (number == 1)
                {
                    isPrime = false;
                }
                else
                {
                    for (int i = number; i >= 2; i--)
                    {
                        if (number % i == 0 && i != number)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }

                if (isPrime)
                {
                    sumPrime += number;
                }
                else
                {
                    sumNon += number;
                }

            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNon}");
        }
    }
}
