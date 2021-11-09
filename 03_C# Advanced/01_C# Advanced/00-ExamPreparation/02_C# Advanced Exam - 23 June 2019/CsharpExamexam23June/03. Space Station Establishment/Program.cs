using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Space_Station_Establishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            char[,] galaxySize = new char[num, num];

            for (int row = 0; row < num; row++)
            {
                string curentRow = Console.ReadLine();
                for (int col = 0; col < num; col++)
                {
                    galaxySize[row, col] = curentRow[col];
                }
            }

            int starShipPositionRow = 0;
            int starShipPositionCol = 0;

            for (int row = 0; row < num; row++)
            {
                for (int col = 0; col < num; col++)
                {
                    if (galaxySize[row, col] == 'S')
                    {
                        starShipPositionRow = row;
                        starShipPositionCol = col;
                    }
                }
            }
            bool starsShipInGalaxyChecker = true;
            int starPower = 0;
            while (true)
            {
                if (starPower >= 50)
                {
                    galaxySize[starShipPositionRow, starShipPositionCol] = 'S';
                    break;
                }
                string command = Console.ReadLine();

                if (command == "up")
                {
                    StarShipPositionMove(galaxySize, starShipPositionRow, starShipPositionCol);
                    starShipPositionRow--;
                    if (starShipPositionRow < 0)
                    {
                        starsShipInGalaxyChecker = false;
                        break;
                    }

                    starPower = ColectStarPower(galaxySize, starShipPositionRow, starShipPositionCol, starPower);

                    StarShipBlackHoleMove(num, galaxySize, ref starShipPositionRow, ref starShipPositionCol);
                }
                else if (command == "down")
                {
                    StarShipPositionMove(galaxySize, starShipPositionRow, starShipPositionCol);
                    starShipPositionRow++;
                    if (starShipPositionRow > num - 1)
                    {
                        starsShipInGalaxyChecker = false;
                        break;
                    }

                    starPower = ColectStarPower(galaxySize, starShipPositionRow, starShipPositionCol, starPower);

                    StarShipBlackHoleMove(num, galaxySize, ref starShipPositionRow, ref starShipPositionCol);

                }
                else if (command == "left")
                {
                    StarShipPositionMove(galaxySize, starShipPositionRow, starShipPositionCol);
                    starShipPositionCol--;
                    if (starShipPositionCol < 0)
                    {
                        starsShipInGalaxyChecker = false;
                        break;
                    }

                    starPower = ColectStarPower(galaxySize, starShipPositionRow, starShipPositionCol, starPower);

                    StarShipBlackHoleMove(num, galaxySize, ref starShipPositionRow, ref starShipPositionCol);

                }
                else if (command == "right")
                {
                    StarShipPositionMove(galaxySize, starShipPositionRow, starShipPositionCol);
                    starShipPositionCol++;
                    if (starShipPositionCol > num-1)
                    {
                        starsShipInGalaxyChecker = false;
                        break;
                    }

                    starPower = ColectStarPower(galaxySize, starShipPositionRow, starShipPositionCol, starPower);

                    StarShipBlackHoleMove(num, galaxySize, ref starShipPositionRow, ref starShipPositionCol);

                }


            }

            if (starPower >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }
            if (starsShipInGalaxyChecker == false)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }

            Console.WriteLine($"Star power collected: {starPower}");

            for (int row = 0; row < num; row++)
            {
                for (int col = 0; col < num; col++)
                {
                    Console.Write(galaxySize[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void StarShipBlackHoleMove(int num, char[,] galaxySize, ref int starShipPositionRow, ref int starShipPositionCol)
        {
            if (galaxySize[starShipPositionRow, starShipPositionCol] == 'O')
            {
                StarShipPositionMove(galaxySize, starShipPositionRow, starShipPositionCol);
                for (int row = 0; row < num; row++)
                {
                    for (int col = 0; col < num; col++)
                    {
                        if (galaxySize[row, col] == 'O')
                        {
                            starShipPositionRow = row;
                            starShipPositionCol = col;
                            galaxySize[starShipPositionRow, starShipPositionCol] = 'S';
                            continue;
                        }
                    }
                }

            }
        }

        private static int ColectStarPower(char[,] galaxySize, int starShipPositionRow, int starShipPositionCol, int starPower)
        {

            char symbol = galaxySize[starShipPositionRow, starShipPositionCol];
            if (Char.IsDigit(symbol))
            {
                int symbolAsDigit = Convert.ToInt32(new string(symbol, 1));
                starPower += symbolAsDigit;
            }         
            return starPower;
        }

        private static void StarShipPositionMove(char[,] galaxySize, int starShipPositionRow, int starShipPositionCol)
        {
            galaxySize[starShipPositionRow, starShipPositionCol] = '-';
        }
    }
}
