using System;

namespace _02._FromLeft_toTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            
           

            for (int i = 1; i <= lines; i++)
            {
                string input = Console.ReadLine();
                string stringBeforeSpace = input.Substring(0, input.IndexOf(" "));
                string stringAfterSpace = input.Substring(input.IndexOf(" ") + 1);
                long numLeft = long.Parse(stringBeforeSpace);
                long numRight = long.Parse(stringAfterSpace);
                
                long biggestNum = 0;
                if (numLeft > numRight)
                {
                    biggestNum = numLeft;
                }
                else
                {
                    biggestNum = numRight;
                }

                long sumOfDigits = 0;
                while (biggestNum != 0)
                {
                    sumOfDigits += biggestNum % 10;
                    biggestNum /= 10;
                }

                Console.WriteLine(Math.Abs( sumOfDigits));

            }
        }
    }
}
