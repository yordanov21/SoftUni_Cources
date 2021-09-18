using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] racersList = Console.ReadLine()
                .Split(", ")
                .ToArray();

            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < racersList.Length; i++)
            {
                dict[racersList[i]] = 0;
            }

            string regexName = @"([A-Za-z])";
            string regexDistance = @"\d";

            string command = Console.ReadLine();
            while (command != "end of race")
            {

                MatchCollection racerName = Regex.Matches(command, regexName);
                MatchCollection racerDistance = Regex.Matches(command, regexDistance);
                StringBuilder currentName = new StringBuilder();
                int currentDistance = 0;
                foreach (Match letter in racerName)
                {
                    currentName = currentName.Append(letter);
                }
                foreach (Match dist in racerDistance)
                {
                    currentDistance += int.Parse(dist.Groups[0].Value);
                }

                if (dict.ContainsKey(currentName.ToString()))
                {
                    dict[currentName.ToString()] += currentDistance;
                }

                command = Console.ReadLine();
            }

            dict = dict
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            int count = 1;
            foreach (var racer in dict)
            {
                if (count == 1)
                {
                    Console.WriteLine($"1st place: {racer.Key}");
                    count++;
                }
                else if (count == 2)
                {
                    Console.WriteLine($"2nd place: {racer.Key}");
                    count++;
                }
                else if (count == 3)
                {
                    Console.WriteLine($"3rd place: {racer.Key}");
                    count++;
                }
                else
                {
                    break;
                }

            }
        }
    }
}
