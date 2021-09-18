using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace _02.PracticeSessions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> roadsList = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commandArr = input
                    .Split("->");
                string command = commandArr[0];

                if (command == "Add")
                {
                    string road = commandArr[1];
                    string racer = commandArr[2];

                    if (!roadsList.ContainsKey(road))
                    {
                        roadsList.Add(road, new List<string>());
                    }
                    roadsList[road].Add(racer);

                }
                else if (command == "Move")
                {
                    string currentRoad = commandArr[1];
                    string racer = commandArr[2];
                    string nextRoad = commandArr[3];

                    if (roadsList.ContainsKey(currentRoad) && roadsList.ContainsKey(nextRoad))
                    {
                        if (roadsList[currentRoad].Contains(racer))
                        {
                            roadsList[currentRoad].Remove(racer);
                            roadsList[nextRoad].Add(racer);
                        }

                    }

                }
                else if (command == "Close")
                {
                    string currentRoad = commandArr[1];
                    if (roadsList.ContainsKey(currentRoad))
                    {
                        roadsList.Remove(currentRoad);
                    }
                }

                input = Console.ReadLine();
            }

            roadsList = roadsList
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine("Practice sessions:");
            foreach(var road in roadsList)
            {
                Console.WriteLine(road.Key);
                foreach (var raser in road.Value)
                {
                    Console.WriteLine($"++{raser}");
                }
            }
        }
    }
}
