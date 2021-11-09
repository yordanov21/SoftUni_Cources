using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02Helen_sAbduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int energyParis = int.Parse(Console.ReadLine());
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[][] fieldSparta = new char[sizeOfMatrix][];

            int rowParis = int.MinValue;
            int colParis = int.MinValue;

            for (int row = 0; row < fieldSparta.Length; row++)
            {
                string currentRow = Console.ReadLine();
                int length = currentRow.Length;
                fieldSparta[row] = new char[length];
                for (int col = 0; col < fieldSparta[row].Length; col++)
                {
                    fieldSparta[row][col] = currentRow[col];

                    if (currentRow[col] == 'P')
                    {
                        rowParis = row;
                        colParis = col;
                    }
                }
            }
               //   така дава грешка 60/100 не пълни коректно матрицата
                // for (int row = 0; row < sizeOfMatrix; row++)
                // {
                //     var input = Console.ReadLine().ToCharArray();
                //     fieldSparta[row] = input;
                //     for (int col = 0; col < sizeOfMatrix; col++)
                //     {
                //         if (fieldSparta[row][col] == 'P')
                //         {
                //             rowParis = row;
                //             colParis = col;
                //         }
                //     }
                // }

                fieldSparta[rowParis][colParis] = '-';
            while (true)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string direction = command[0];
                int rowSpartans = int.Parse(command[1]);
                int colSpartans = int.Parse(command[2]);

                fieldSparta[rowSpartans][colSpartans] = 'S';

                if (direction == "up")
                {
                    if (rowParis > 0)
                    {
                        rowParis--;
                    }
                    energyParis--;
                }
                else if (direction == "down")
                {
                    if (rowParis < sizeOfMatrix - 1)
                    {
                        rowParis++;
                    }
                    energyParis--;
                }
                else if (direction == "left")
                {
                    if (colParis > 0)
                    {
                        colParis--;
                    }
                    energyParis--;
                }
                else if (direction == "right")
                {
                    if (colParis < sizeOfMatrix - 1)
                    {
                        colParis++;
                    }
                    energyParis--;
                }

                if (fieldSparta[rowParis][colParis] == 'H')
                {
                    fieldSparta[rowParis][colParis] = '-';
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energyParis}");
                    break;
                }

                if (energyParis <= 0)
                {
                    fieldSparta[rowParis][colParis] = 'X';
                    Console.WriteLine($"Paris died at {rowParis};{colParis}.");
                    break;
                }

                if (fieldSparta[rowParis][colParis] == 'S')
                {

                    if (energyParis - 2 > 0)
                    {
                        energyParis -= 2;
                        fieldSparta[rowParis][colParis] = '-';
                    }
                    else
                    {
                        fieldSparta[rowParis][colParis] = 'X';
                        Console.WriteLine($"Paris died at {rowParis};{colParis}.");
                        break;
                    }
                }
            }


            foreach (char[] curentrow in fieldSparta)
            {
                Console.WriteLine(curentrow);
            }
        }
    }
}
