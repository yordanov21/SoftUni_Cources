using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int coumtMessages = int.Parse(Console.ReadLine());

            string firstPattern = @"[STARstar]";
            var attackedList = new List<string>();
         

            var destroyedList = new List<string>();

            for (int i = 0; i < coumtMessages; i++)
            {
                string message = Console.ReadLine();

                MatchCollection lettersmatched = Regex.Matches(message, firstPattern);

                int countOfLetters = lettersmatched.Count;

                string newMessage = string.Empty;
                foreach(var letter in message)
                {
                    newMessage += (char)(letter - countOfLetters);
                }

                string planetNamePattern = @"@([A-Za-z]+)";
                Match planetNameMatch = Regex.Match(newMessage, planetNamePattern);
                string planetName = planetNameMatch.Groups[1].Value;
                
                string planetPopulationPattern = @":([0-9]+)";
                Match planetPopulationMatch = Regex.Match(newMessage, planetPopulationPattern);
                string planetPopulation = planetPopulationMatch.Groups[1].Value;

                string attackTipePattern = @"!(A|D)!";
                Match attackTipePatternMatch = Regex.Match(newMessage, attackTipePattern);
                string attackTipe = attackTipePatternMatch.Groups[1].Value;
                
                string soldierCountPattern = @"->([0-9]+)";
                Match soldierCountMatch = Regex.Match(newMessage, soldierCountPattern);
                string soltierCount = soldierCountMatch.Groups[1].Value;
                if (planetPopulationMatch.Success&&planetNameMatch.Success&&attackTipePatternMatch.Success&&soldierCountMatch.Success)
                {
                    if (attackTipe == "A" && soltierCount != string.Empty)
                    {
                        attackedList.Add(planetName);
                    }
                    else if (attackTipe == "D" && soltierCount != string.Empty)
                    {
                        destroyedList.Add(planetName);
                    }
                }
               

            }
            attackedList.Sort();
            destroyedList.Sort();
            Console.WriteLine($"Attacked planets: {attackedList.Count}");
            if (attackedList.Count > 0)
            {
                foreach(var item in attackedList)
                {
                    Console.WriteLine($"-> {item}");
                }
            }

            Console.WriteLine($"Destroyed planets: {destroyedList.Count}");
            if (destroyedList.Count > 0)
            {
                foreach (var item in destroyedList)
                {
                    Console.WriteLine($"-> {item}");
                }
            }
        }
    }
}
