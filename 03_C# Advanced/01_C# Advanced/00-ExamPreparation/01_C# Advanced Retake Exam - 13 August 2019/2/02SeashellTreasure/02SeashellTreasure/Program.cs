using System;
using System.Linq;
using System.Collections.Generic;

namespace _02SeashellTreasure
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            char[][] beachArray = new char[num][];
            for (int i = 0; i < beachArray.Length; i++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                beachArray[i] = currentRow;
            }

            List<char> collectedSeashealts = new List<char>();
            int stealSeasheltsCount = 0;

            var commandLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (commandLine[0] != "Sunset")
            {

                string command = commandLine[0];
                if (command == "Collect")
                {
                    int row = int.Parse(commandLine[1]);
                    int col = int.Parse(commandLine[2]);
                    if (row >= 0 && row < beachArray.Length)
                    {
                        var rowArr = beachArray[row];
                        if (col >= 0 && col < rowArr.Length)
                        {
                            char symbol = beachArray[row][col];
                            if (symbol != '-')
                            {
                                collectedSeashealts.Add(symbol);
                                beachArray[row][col] = '-';
                            }
                        }
                    }
                }
                else if (command == "Steal")
                {
                    int row = int.Parse(commandLine[1]);
                    int col = int.Parse(commandLine[2]);
                    string direction = commandLine[3];
                    if (row >= 0 && row < beachArray.Length)
                    {
                        var rowArr = beachArray[row];
                        if (col >= 0 && col < rowArr.Length)
                        {
                            char symbol = beachArray[row][col];
                            if (symbol != '-')
                            {
                                stealSeasheltsCount++;
                                beachArray[row][col] = '-';
                                if (direction == "up")
                                {
                                    row--;
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        CheckStealMoves(beachArray, ref stealSeasheltsCount, row, col, ref rowArr, ref symbol);
                                        row--;
                                    }

                                }
                                else if (direction == "down")
                                {
                                    row++;
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        CheckStealMoves(beachArray, ref stealSeasheltsCount, row, col, ref rowArr, ref symbol);
                                        row++;
                                    }
                                }
                                else if (direction == "left")
                                {
                                    col--;
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        CheckStealMoves(beachArray, ref stealSeasheltsCount, row, col, ref rowArr, ref symbol);
                                        col--;
                                    }
                                }
                                else if (direction == "right")
                                {
                                    col++;
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        CheckStealMoves(beachArray, ref stealSeasheltsCount, row, col, ref rowArr, ref symbol);
                                        col++;
                                    }
                                }
                            }
                        }
                    }
                }

                commandLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (char[] currRow in beachArray)
            {
                Console.WriteLine(string.Join(" ", currRow) + " ");
            }

            if (collectedSeashealts.Count > 0)
            {
                Console.WriteLine($"Collected seashells: {collectedSeashealts.Count} -> {string.Join(", ", collectedSeashealts)}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {collectedSeashealts.Count}");

            }

            Console.WriteLine($"Stolen seashells: {stealSeasheltsCount}");
        }

        private static void CheckStealMoves(char[][] beachArray, ref int stealSeasheltsCount, int row, int col, ref char[] rowArr, ref char symbol)
        {
            if (row >= 0 && row < beachArray.Length)
            {
                rowArr = beachArray[row];
                if (col >= 0 && col < rowArr.Length)
                {
                    symbol = beachArray[row][col];
                    if (symbol != '-')
                    {
                        stealSeasheltsCount++;
                        beachArray[row][col] = '-';
                    }
                }
            }
        }

    }
}
