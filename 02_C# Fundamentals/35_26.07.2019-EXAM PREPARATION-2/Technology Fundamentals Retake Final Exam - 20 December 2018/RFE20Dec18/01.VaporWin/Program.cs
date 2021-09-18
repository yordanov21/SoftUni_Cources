using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.VaporWin
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] gamesInput = input.Split(", ");

            string regexPrice = @"([A-Za-z0-9 ]+)-(\d+\.*\d+)";
            string regexDLC = @"([A-Za-z0-9 ]+):([A-Za-z0-9 ]+)";

            Dictionary<string, double> gameListPrice = new Dictionary<string, double>();
            Dictionary<string, string> gameListDLC = new Dictionary<string, string>();

            for (int i = 0; i < gamesInput.Length; i++)
            {
                string currentGame = gamesInput[i];
                Match matchGame = Regex.Match(currentGame, regexPrice);
                Match matchDLC = Regex.Match(currentGame, regexDLC);

                if (matchGame.Success)
                {
                    string gameName = matchGame.Groups[1].Value;
                    double priceGame = double.Parse(matchGame.Groups[2].Value);
                    if (!gameListPrice.ContainsKey(gameName))
                    {
                        gameListPrice[gameName] = priceGame;
                    }
                }
                else if (matchDLC.Success)
                {
                    string gameName = matchDLC.Groups[1].Value;
                    string DLCGame = matchDLC.Groups[2].Value;
                    if (gameListPrice.ContainsKey(gameName))
                    {
                        gameListDLC.Add(gameName, DLCGame);

                        gameListPrice[gameName] *= 1.2;
                    }
                }
            }
            Dictionary<string, double> gamesReducedPrise = new Dictionary<string, double>();
            foreach (var game in gameListPrice)
           {
               if (!gameListDLC.ContainsKey(game.Key))
               {
                    gamesReducedPrise[game.Key] =game.Value*0.8;
               }
               else
               {
                    gamesReducedPrise[game.Key] = game.Value *0.5;
               }
           }

            gamesReducedPrise = gamesReducedPrise
                .OrderBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var game in gamesReducedPrise)
            {
                if (gameListDLC.ContainsKey(game.Key))
                {
                    string DLC = gameListDLC[game.Key];
                    Console.WriteLine($"{game.Key} - {DLC} - {game.Value:f2}");

                }
            }
            gamesReducedPrise = gamesReducedPrise
               .OrderByDescending(x => x.Value)
               .ToDictionary(x => x.Key, x => x.Value);

            foreach (var game in gamesReducedPrise)
            {
                if (!gameListDLC.ContainsKey(game.Key))
                {
                   
                    Console.WriteLine($"{game.Key} - {game.Value:f2}");

                }
            }
        }
    }
}
