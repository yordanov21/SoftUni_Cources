using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
           Func<string, int, bool> lengthFunc = (name, length) => name.Length == length;
           Func<string, string, bool> startWithFunc = (name, startWithString) => name.StartsWith (startWithString);
           Func<string, string, bool> endWithFunc = (name, endWithString) => name.EndsWith(endWithString);

           List<string> names = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] commandInfo = command.Split();
                string action = commandInfo[0];
                string condition = commandInfo[1];
                string parametur = commandInfo[2];

                if (action == "Double")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(parametur);

                        var tempNames = names.Where(name => lengthFunc(name, length)).ToList();
                        MyAddRange(names, tempNames);
                    }
                    else if (condition == "StartsWith")
                    {
                        var tempNames = names.Where(name=>startWithFunc(name,parametur)).ToList();
                        MyAddRange(names, tempNames);
                    }
                    else if (condition == "EndsWith")
                    {
                        var tempNames = names.Where(name => endWithFunc(name, parametur)).ToList();
                        MyAddRange(names, tempNames);
                    }
                }
                else if(action == "Remove")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(parametur);

                       names= names.Where(name => !lengthFunc(name, length)).ToList();                     
                    }
                    else if (condition == "StartsWith")
                    {
                        names = names.Where(name => !startWithFunc(name, parametur)).ToList();

                    }
                    else if (condition == "EndsWith")
                    {
                        names = names.Where(name => !endWithFunc(name, parametur)).ToList();
                    }
                }

                command = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ",names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        private static void MyAddRange(List<string> names, List<string> tempNames)
        {
            foreach (var currentName in tempNames)
            {
                int index = names.IndexOf(currentName);
                names.Insert(index, currentName);
            }
        }
    }
}
