using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixNumber = int.Parse(Console.ReadLine());
            GetMeMatrix(matrixNumber);
        }

        private static void GetMeMatrix(int matrixNumber)
        {

            int[] nxnArray = new int[matrixNumber];

            for (int j = 0; j < matrixNumber; j++)
            {

                for (int i = 0; i < matrixNumber; i++)
                {

                    nxnArray[i] = matrixNumber;
                    Console.Write(nxnArray[i] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
