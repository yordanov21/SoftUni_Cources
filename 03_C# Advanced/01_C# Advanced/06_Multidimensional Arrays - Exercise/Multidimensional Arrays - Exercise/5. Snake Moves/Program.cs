using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];
            string snake = Console.ReadLine();

            char [][]matrix = new char[rows][];
            int countSnakeIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
            }
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                       
                        matrix[row][col] = snake[countSnakeIndex];
                        countSnakeIndex++;
                        if (countSnakeIndex >= snake.Length)
                        {
                            countSnakeIndex = 0;
                        }
                    }
                }
                else
                {
                    for (int col = cols-1; col >= 0; col--)
                    {
                       
                        matrix[row][col] = snake[countSnakeIndex];
                        countSnakeIndex++;
                        if (countSnakeIndex >= snake.Length)
                        {
                            countSnakeIndex = 0;
                        }
                    }
                }
               
            }

            foreach (char [] row in matrix)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
    }
}
