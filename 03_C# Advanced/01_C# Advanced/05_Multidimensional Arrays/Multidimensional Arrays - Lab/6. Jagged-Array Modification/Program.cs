using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] arr = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var rowArr = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                arr[i] = rowArr;
            }

            while (true)
            {
                var comand = Console.ReadLine();
                if (comand == "END")
                {
                    break;
                }

                var comandArr = comand.Split();

                if (comandArr[0] == "Add")
                {
                    int value = int.Parse(comandArr[3]);
                    int row = int.Parse(comandArr[1]);
                    int col = int.Parse(comandArr[2]);
                    if (row < 0 || row > arr.Length-1 || col < 0 || col > arr[row].Length-1)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }
                    else
                    {
                        arr[row][col] += value;
                    }

                }

                if (comandArr[0] == "Subtract")
                {
                    int value = int.Parse(comandArr[3]);
                    int row = int.Parse(comandArr[1]);
                    int col = int.Parse(comandArr[2]);
                    if (row < 0 || row > arr.Length-1 || col < 0 || col > arr[row].Length-1)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }
                    else
                    {
                        arr[row][col] -= value;
                    }

                }
            }

            foreach (int []row in arr)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
