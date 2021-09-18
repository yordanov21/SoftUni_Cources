using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _01_AnimalSanct
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int totalWeight = 0;
            string regex = @"n:(.[^;]+);t:(.[^;]+);c--([A-Za-z ]+)$";
            string digitRegex = @"\d";
            string nameRegex = @"[A-Za-z]";


            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, regex);

                if (match.Success)
                {
                    string nameAnimal = match.Groups[1].Value;
                    string kindAnimal = match.Groups[2].Value;
                    string country = match.Groups[3].Value;

                    MatchCollection digitmatch = Regex.Matches(input, digitRegex);

                    foreach (Match digit in digitmatch)
                    {
                        int curenetDigit = int.Parse(digit.Value);
                        totalWeight += curenetDigit;
                    }

                    string name = string.Empty;
                    MatchCollection nameMatch = Regex.Matches(nameAnimal, nameRegex);

                    foreach (Match letter in nameMatch)
                    {
                        name += letter;
                    }

                    string kind = string.Empty;
                    MatchCollection kindMatch = Regex.Matches(kindAnimal, nameRegex);

                    foreach (Match letter in kindMatch)
                    {
                        kind += letter;
                    }

                    Console.WriteLine($"{name} is a {kind} from {country}");
                }

            }
            Console.WriteLine($"Total weight of animals: {totalWeight}KG");
        }
    }
}
