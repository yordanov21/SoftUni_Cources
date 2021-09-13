using System;

namespace _14.__Numbers_to_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long number = 0;
            for (long i = 0; i < n; i++)
            {
                number = long.Parse(Console.ReadLine());
                if (number < -999)
                {
                    Console.WriteLine("too small");
                }
                else if (number > 999)
                {
                    Console.WriteLine("too large");
                }
                else if ((number > 99 && number <= 999) || (number < -99 && number >= -999))
                {
                    if (number < 0)
                    {
                        Console.Write("minus ");
                        number *= -1;
                    }
                    LetterizeNumbers(number);
                    Console.WriteLine();
                }
            }
        }

        private static void LetterizeNumbers(long number)
        {
            if (number % 10 == 0 && number / 10 % 10 == 0)
            {
                PrintHundreds(number);
            }
            else if (number % 10 != 0 && number / 10 % 10 == 0)
            {
                PrintHundredsAndUnits(number);
            }
            else if (number % 10 == 0 && number / 10 % 10 != 0)
            {
                PrintHundredsAndTenth(number);
            }
            else if (number % 100 > 10 && number % 100 < 20)
            {
                PrintHundredsTenthsUnits1020(number);
            }
            else
            {
                PrintHundredsAndTenthAndUnit(number);
            }
        }

        private static void PrintHundredsAndTenthAndUnit(long number)
        {
            long tenth = number / 10 % 10;
            PrintHundreds(number);
            Console.Write(" and ");
            switch (tenth)
            {
                case 2: Console.Write("twenty"); break;
                case 3: Console.Write("thirty"); break;
                case 4: Console.Write("fourty"); break;
                case 5: Console.Write("fifty"); break;
                case 6: Console.Write("sixty"); break;
                case 7: Console.Write("seventy"); break;
                case 8: Console.Write("eighty"); break;
                case 9: Console.Write("ninety"); break;
            }
            Console.Write(" ");
            PrintUnits(number);
        }

        private static void PrintUnits(long number)
        {
            long units = number % 10;
            switch (units)
            {
                case 1: Console.Write("one"); break;
                case 2: Console.Write("two"); break;
                case 3: Console.Write("three"); break;
                case 4: Console.Write("four"); break;
                case 5: Console.Write("five"); break;
                case 6: Console.Write("six"); break;
                case 7: Console.Write("seven"); break;
                case 8: Console.Write("eight"); break;
                case 9: Console.Write("nine"); break;
            }
        }

        private static void PrintHundredsTenthsUnits1020(long number)
        {
            long tenth1020 = number % 100;
            PrintHundreds(number);
            Console.Write(" and ");
            switch (tenth1020)
            {
                case 11: Console.Write("eleven"); break;
                case 12: Console.Write("twelve"); break;
                case 13: Console.Write("thirteen"); break;
                case 14: Console.Write("fourteen"); break;
                case 15: Console.Write("fifteen"); break;
                case 16: Console.Write("sixteen"); break;
                case 17: Console.Write("seventeen"); break;
                case 18: Console.Write("eighteen"); break;
                case 19: Console.Write("nineteen"); break;
            }
        }

        private static void PrintHundredsAndTenth(long number)
        {
            long tenth = number / 10 % 10;
            PrintHundreds(number);
            Console.Write(" and ");
            switch (tenth)
            {
                case 1: Console.Write("ten"); break;
                case 2: Console.Write("twenty"); break;
                case 3: Console.Write("thirty"); break;
                case 4: Console.Write("fourty"); break;
                case 5: Console.Write("fifty"); break;
                case 6: Console.Write("sixty"); break;
                case 7: Console.Write("seventy"); break;
                case 8: Console.Write("eighty"); break;
                case 9: Console.Write("ninety"); break;
            }
        }

        private static void PrintHundredsAndUnits(long number)
        {
            long units = number % 10;
            PrintHundreds(number);
            Console.Write(" and ");
            PrintUnits(number);
        }

        private static void PrintHundreds(long number)
        {
            long hundreds = number / 100;
            switch (hundreds)
            {
                case 1: Console.Write("one-hundred"); break;
                case 2: Console.Write("two-hundred"); break;
                case 3: Console.Write("three-hundred"); break;
                case 4: Console.Write("four-hundred"); break;
                case 5: Console.Write("five-hundred"); break;
                case 6: Console.Write("six-hundred"); break;
                case 7: Console.Write("seven-hundred"); break;
                case 8: Console.Write("eight-hundred"); break;
                case 9: Console.Write("nine-hundred"); break;
            }
        }
    }
}
