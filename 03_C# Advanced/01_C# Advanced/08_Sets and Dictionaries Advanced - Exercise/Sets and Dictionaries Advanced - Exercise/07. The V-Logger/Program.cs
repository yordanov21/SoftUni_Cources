using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, HashSet<string>>> vloggerList
                = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }

                var comands = input.Split();
                string vlorgerName = comands[0];
                string currendComand = comands[1];

                if (currendComand == "joined")
                {
                    if (!vloggerList.ContainsKey(vlorgerName))
                    {
                        vloggerList.Add(vlorgerName, new Dictionary<string, HashSet<string>>());// за сортиран HashSet може да използваме SortedSet!
                        vloggerList[vlorgerName].Add("followed", new HashSet<string>());
                        vloggerList[vlorgerName].Add("following", new HashSet<string>());
                    }
                }
                else if (currendComand == "followed")
                {
                    string follower = comands[2];
                    string following = comands[0];
                    if (follower == following)
                    {
                        continue;
                    }
                    if (!vloggerList.ContainsKey(follower) || !vloggerList.ContainsKey(following))
                    {
                        continue;
                    }

                    vloggerList[follower]["followed"].Add(following);
                    vloggerList[following]["following"].Add(follower);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggerList.Count} vloggers in its logs.");

            var sortedVloggerList = vloggerList
                .OrderByDescending(x => x.Value["followed"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(x => x.Key, y => y.Value);

            int count = 1;

            foreach (var (vloger, colectionOfPeople) in sortedVloggerList)
            {
                Console.WriteLine($"{count}. {vloger} : {colectionOfPeople["followed"].Count} followers, {colectionOfPeople["following"].Count} following");
            
                if (count == 1)
                {
                    foreach (var person in colectionOfPeople["followed"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {person}");
                    }
                }
                
                count++;
            }
        }
    }
}
