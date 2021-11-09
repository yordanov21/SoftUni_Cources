using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._The_Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsGarden = int.Parse(Console.ReadLine());

            char[][] garden = new char[rowsGarden][];

            for (int row = 0; row < rowsGarden; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                garden[row] = currentRow;
            }

            Dictionary<string, int> vegetables = new Dictionary<string, int>();
            vegetables["Carrots"] = 0;
            vegetables["Potatoes"] = 0;
            vegetables["Lettuce"] = 0;
            vegetables["Harmed vegetables"] = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End of Harvest")
                {
                    break;
                }

                var commandArr = command.Split();
                string currendCommand = commandArr[0];

                if (currendCommand == "Harvest")
                {
                    int rowVegetable = int.Parse(commandArr[1]);
                    int colVegetable = int.Parse(commandArr[2]);

                    if (rowVegetable >= 0 && rowVegetable < rowsGarden)
                    {
                        if (colVegetable >= 0 && colVegetable < garden[rowVegetable].Length)
                        {
                            char vegetable = garden[rowVegetable][colVegetable];
                            if (vegetable == 'C')
                            {
                                vegetables["Carrots"]++;
                                garden[rowVegetable][colVegetable] = ' ';
                            }
                            else if (vegetable == 'P')
                            {
                                vegetables["Potatoes"]++;
                                garden[rowVegetable][colVegetable] = ' ';
                            }
                            else if (vegetable == 'L')
                            {
                                vegetables["Lettuce"]++;
                                garden[rowVegetable][colVegetable] = ' ';
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                else if (currendCommand == "Mole")
                {
                    int rowVegetable = int.Parse(commandArr[1]);
                    int colVegetable = int.Parse(commandArr[2]);
                    string direction = commandArr[3].ToLower();
                    if (rowVegetable >= 0 && rowVegetable < rowsGarden)
                    {
                        if (colVegetable >= 0 && colVegetable < garden[rowVegetable].Length)
                        {
                            MoleGetVegetable(garden, vegetables, rowVegetable, colVegetable);

                            if (direction == "up")
                            {
                                while (true)
                                {
                                    rowVegetable -= 2;
                                    if (rowVegetable < 0)
                                    {
                                        break;
                                    }
                                    MoleGetVegetable(garden, vegetables, rowVegetable, colVegetable);
                                }

                            }
                            else if (direction == "down")
                            {
                                while (true)
                                {
                                    rowVegetable += 2;
                                    if (rowVegetable >= rowsGarden)
                                    {
                                        break;
                                    }
                                    MoleGetVegetable(garden, vegetables, rowVegetable, colVegetable);
                                }
                            }
                            else if (direction == "left")
                            {
                                while (true)
                                {
                                    colVegetable -= 2;
                                    if (colVegetable < 0)
                                    {
                                        break;
                                    }
                                    MoleGetVegetable(garden, vegetables, rowVegetable, colVegetable);
                                }
                            }
                            else if (direction == "right")
                            {
                                while (true)
                                {
                                    colVegetable += 2;
                                    if (colVegetable > garden[rowVegetable].Length)
                                    {
                                        break;
                                    }
                                    MoleGetVegetable(garden, vegetables, rowVegetable, colVegetable);
                                }
                            }
                        }
                    }
                    
                }
            }

            foreach (char[] row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            foreach (var item in vegetables)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static void MoleGetVegetable(char[][] garden, Dictionary<string, int> vegetables, int rowVegetable, int colVegetable)
        {
            if (garden[rowVegetable][colVegetable] != ' ')
            {
                vegetables["Harmed vegetables"]++;
                garden[rowVegetable][colVegetable] = ' ';
            }
        }
    }
}

