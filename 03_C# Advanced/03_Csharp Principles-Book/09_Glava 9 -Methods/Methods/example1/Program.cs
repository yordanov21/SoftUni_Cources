using System;

namespace example1
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine(GetRectangleArea(8,8));
            PrintLogo("logo");
            decimal[] prices = { 1, 2, 3, 4 };
            PrintTotalAmountForBooks(prices);
            PrintSing(5);
            PrintSing(5-5);
            PrintSing(5+3);
            PrintSing(5-20);
            PrintMax(5f, 9f);
            PrintMax(5f*5, 9f*2);

            PrintNumber(5);
        }

        static double GetRectangleArea(double width, double height)
        {
            double area = width * height;
            return area;
        }

        static void PrintLogo(string logo)
        {
            Console.WriteLine(logo);
        }

        static void PrintTotalAmountForBooks(decimal[] prices)
        {
            decimal totalAmount = 0;
            foreach  (decimal singleBookPrice in prices)
            {
                totalAmount += singleBookPrice;
            }

            Console.WriteLine("The total amount of all books is: "+ totalAmount);
        }
    
        static void PrintSing(int number)
        {
            if (number > 0)
            {
                Console.WriteLine("Positive");
            }
            else if (number < 0)
            {
                Console.WriteLine("Negative");
            }
            else
            {
                Console.WriteLine("Zero");
            }
        }

        static void PrintMax(float number1, float number2)
        {
            float max = number1;
            if (number2 > max)
            {
                max = number2;
            }

            Console.WriteLine($"Maximal number: {max}");
        }

        static void PrintNumber(float number)
        {
            Console.WriteLine("The float number is {0}", number);
        }
    }
}
