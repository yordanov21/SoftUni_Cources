using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int number = Math.Abs(num);
            int sumEvens = 0;
            int sumOdds = 0;
            
            while (true)
            {
                int resultNum = number % 10;
                number = number / 10;
                if (resultNum % 2 == 0)
                {
                    sumEvens += resultNum;
                }
                else if(resultNum % 2 != 0)
                {
                    sumOdds += resultNum;
                }   
                if (number == 0)
                {
                    break;
                }
            }
            Console.WriteLine(sumOdds*sumEvens);
            
        }
    }
}
