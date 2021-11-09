using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var line = input.Split(" ");
                string continent = line[0];
                string country = line[1];
                string city = line[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent][country] = new List<string>();
                }

                continents[continent][country].Add(city);
            }

            foreach (var continent in continents)
            {
                string curentContinent = continent.Key;
                Console.WriteLine(curentContinent + ":");
                foreach (var country in continent.Value)
                {
                    string curcurentCountry = country.Key;
                    var currentCities = country.Value;
                    Console.WriteLine($"  {curcurentCountry} -> {String.Join(", ", currentCities)}");
                }
            }
        }
    }
}
