using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPairs = int.Parse(Console.ReadLine());
            int previousSum = 0;
            int difference = 0;



            for (int i = 1; i <= numPairs; i++)
            {
                if (i == 1)
                {
                    int firstNum = int.Parse(Console.ReadLine());
                    int secondNum = int.Parse(Console.ReadLine());
                    previousSum = firstNum + secondNum;

                }
                else
                {
                    int firstNum2 = int.Parse(Console.ReadLine());
                    int secondNum2 = int.Parse(Console.ReadLine());
                    int currentSum = firstNum2 + secondNum2;

                    if ((Math.Abs(currentSum - previousSum)) > difference)
                    {
                        difference = Math.Abs(currentSum - previousSum);

                    }
                    previousSum = currentSum;
                }
            }

            if (difference > 0)
            {
                Console.WriteLine("No, maxdiff=" + difference);
            }
            else
            {
                Console.WriteLine("Yes, value=" + previousSum);
            }

        }
    }
}
