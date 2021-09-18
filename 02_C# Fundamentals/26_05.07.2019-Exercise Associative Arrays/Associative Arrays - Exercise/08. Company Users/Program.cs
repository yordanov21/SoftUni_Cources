using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] command = input.Split(" -> ");
                string companyName = command[0];
                string employeeName = command[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                }

                if (!companies[companyName].Contains(employeeName))
                {
                    companies[companyName].Add(employeeName);
                }

            }
            foreach (var kvp in companies.OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var empl in kvp.Value)
                {
                    Console.WriteLine($"-- {empl}");
                }
            }
        }
    }
}
