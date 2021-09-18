using System;
using System.Text.RegularExpressions;
using System.Text;

namespace _03._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string inputtt = Console.ReadLine();
                string regex = @"(?<start>[#$%*&])(?<name>[A-Za-z]+)\1=(?<geohashcodeLentgh>\d+)!!(?<geohashcode>.*)$";

                Match match = Regex.Match(inputtt, regex);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    int codeLenght = int.Parse(match.Groups["geohashcodeLentgh"].Value);
                    string code = match.Groups["geohashcode"].Value;

                    if (codeLenght == code.Length)
                    {

                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < code.Length; i++)
                        {
                            char symbol = (char)(code[i] + codeLenght);
                            sb.Append(symbol);
                        }
                        Console.WriteLine($"Coordinates found! {name} -> {sb.ToString()}");
                        break;
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
            }
        }
    }
}
