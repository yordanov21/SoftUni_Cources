using System;

namespace _02._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                int pascalNumber = 1;
                for (int j = 0; j <= i; j++)
                {

                    if (j == 0 || i == 0)
                    {
                        pascalNumber = 1;
                    }
                    else
                    {
                        pascalNumber = pascalNumber * (i - j + 1) / j;
                    }

                    Console.Write(pascalNumber + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
