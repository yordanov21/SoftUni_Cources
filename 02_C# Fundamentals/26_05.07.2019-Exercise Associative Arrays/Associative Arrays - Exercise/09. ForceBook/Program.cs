using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> side = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] inputLine = input.Split(" | ");

                    string forseSide = inputLine[0];
                    string forseUser = inputLine[1];

                    if (!side.ContainsKey(forseSide))
                    {
                        side.Add(forseSide, new List<string>());
                    }

                    bool memberExists = false;

                    foreach (var kvp in side)
                    {
                        if (kvp.Value.Contains(forseUser))
                        {
                            memberExists = true;
                            break;
                        }
                    }

                    if (!side[forseSide].Contains(forseUser) && !memberExists)
                    {
                        side[forseSide].Add(forseUser);
                    }
                }
                else
                {
                    string[] inputLine = input.Split(" -> ");
                    string forseSide = inputLine[1];
                    string forseUser = inputLine[0];

                    bool memberExists = false;
                    string curentSide = string.Empty;

                    foreach (var kvp in side)
                    {
                        if (kvp.Value.Contains(forseUser))
                        {
                            memberExists = true;
                            curentSide = kvp.Key;
                            break;
                        }
                    }

                    if (memberExists)
                    {
                        side[curentSide].Remove(forseUser);
                    }

                    if (!side.ContainsKey(forseSide))
                    {
                        side.Add(forseSide, new List<string>());
                    }

                    if (!side[forseSide].Contains(forseUser))
                    {
                        side[forseSide].Add(forseUser);
                    }
                    Console.WriteLine($"{ forseUser} joins the { forseSide} side!");
                }

                input = Console.ReadLine();

            }
            side = side
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in side)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                List<string> sideMembers = kvp.Value;
                sideMembers.Sort();

                foreach (var member in sideMembers)
                {
                    Console.WriteLine($"! {member}");
                }
            }
        }
    }
}
