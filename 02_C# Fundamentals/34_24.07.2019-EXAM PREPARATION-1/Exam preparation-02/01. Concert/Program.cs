using System;
using System.Linq;
using System.Collections.Generic;


namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> bandMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandTime = new Dictionary<string, int>();
            int totalTime = 0;

            string input = Console.ReadLine();

            while (input != "start of concert")
            {
                string[] commandArr = input.Split("; ");

                string command = commandArr[0];
                string bandName = commandArr[1];

                if (command == "Add")
                {
                    string[] members = commandArr[2].Split(", ");

                    if (!bandMembers.ContainsKey(bandName))
                    {
                        bandMembers[bandName] = new List<string>();
                        for (int i = 0; i < members.Length; i++)
                        {
                            string member = members[i];
                            bandMembers[bandName].Add(member);
                        }

                    }
                    else
                    {
                        for (int i = 0; i < members.Length; i++)
                        {
                            string member = members[i];
                            if (!bandMembers[bandName].Contains(member))
                            {
                                bandMembers[bandName].Add(member);
                            }

                        }
                    }

                }
                else if (command == "Play")
                {
                    int time = int.Parse(commandArr[2]);
                    if (!bandTime.ContainsKey(bandName))
                    {
                        bandTime[bandName] = 0;
                    }
                    bandTime[bandName] += time;
                    totalTime += time;
                }

                input = Console.ReadLine();
            }
            bandTime = bandTime
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Total time: {totalTime}");
            foreach (var time in bandTime)
            {
                if (time.Value > 0)
                {
                    Console.WriteLine($"{time.Key} -> {time.Value}");
                }

            }
            string band = Console.ReadLine();

            if (bandMembers[band].Count > 0)
            {
                Console.WriteLine(band);
                for (int i = 0; i < bandMembers[band].Count; i++)
                {
                    Console.WriteLine($"=> {bandMembers[band][i]}");
                }
            }
            
            
        }
    }
}
