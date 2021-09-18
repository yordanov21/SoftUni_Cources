using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _01.ArrivinginKathm
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"^([A-Za-z0-9!@#$?]+)=(\d+)<<(.+)$";
            string regexPeak = @"[A-Za-z0-9 ]";

            while(input!="Last note")
            {

                Match match = Regex.Match(input, regex);

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    int lenghtCode = int.Parse(match.Groups[2].Value);
                    string code = match.Groups[3].Value;
                    StringBuilder namePeak = new StringBuilder();
                    if (lenghtCode == code.Length)
                    {
                        MatchCollection matchPeak = Regex.Matches(name, regexPeak);
                        foreach(Match item in matchPeak)
                        {                      
                            namePeak.Append(item);
                        }
                        Console.WriteLine($"Coordinates found! {namePeak} -> {code}");

                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }

                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }


                input = Console.ReadLine();
            }
        }
    }
}
