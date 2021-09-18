using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
                     
            Dictionary<string, List<string>> bandsNameList = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandsTimeList = new Dictionary<string, int>();

            while(command!= "start of concert")
            {
                string[] commandArr = command.Split("; ");
                string consertCommand = commandArr[0];
                string bandMember = commandArr[1];

                if (consertCommand == "Add")
                {
                    List<string> members = commandArr[2]
                    .Split(", ")
                    .ToList();
                    if (!bandsNameList.ContainsKey(bandMember))
                    {                     
                        bandsNameList.Add(bandMember, members);
                    }
                    else
                    {
                       foreach(var member in members)
                        {
                            if (!bandsNameList[bandMember].Contains(member))
                            {
                                bandsNameList[bandMember].Add(member);
                            }
                        }
                    }
                                   
                }
                else if (consertCommand == "Play")
                {
                    int time = int.Parse(commandArr[2]);
                    if (!bandsTimeList.ContainsKey(bandMember))
                    {
                        bandsTimeList.Add(bandMember, time);
                    }
                    else
                    {
                        bandsTimeList[bandMember] += time;
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Total time: {bandsTimeList.Values.Sum()}");

            foreach(var band in bandsTimeList.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            string name = Console.ReadLine();
            Console.WriteLine(name);
            foreach (var member in bandsNameList[name])
            {
                Console.WriteLine($"=> {member}");
            }

        }
    }  
}
