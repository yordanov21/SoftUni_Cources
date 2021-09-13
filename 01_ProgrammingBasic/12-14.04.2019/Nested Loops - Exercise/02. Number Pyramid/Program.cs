using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            bool bigger = false;

            for (int row = 1; row <= n; row++)
            {
                for (int colums = 1; colums <= row; colums++)
                {
                    if (counter > n)
                    {
                        bigger = true;
                        break;
                    }
                    Console.Write(counter + " ");
                    counter++;
                }
                if (bigger)
                {
                    break;
                }
                Console.WriteLine();
            }

        }
    }
}
