using System;

namespace _16._Number_0_100_to_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

           
            if (num >= 0 && num < 20)
            {
                if (num == 0)
                {
                    Console.WriteLine("zero");
                }
                else if (num == 1)
                {
                    Console.WriteLine("one");
                }
                else if (num == 2)
                {
                    Console.WriteLine("two");
                }
                else if (num == 3)
                {
                    Console.WriteLine("three");
                }
                else if (num == 4)
                {
                    Console.WriteLine("four");
                }
                else if (num == 5)
                {
                    Console.WriteLine("five");
                }
                else if (num == 6)
                {
                    Console.WriteLine("six");
                }
                else if (num == 7)
                {
                    Console.WriteLine("seven");
                }
                else if (num == 8)
                {
                    Console.WriteLine("eight");
                }
                else if (num == 9)
                {
                    Console.WriteLine("nine");
                }
                else if (num == 10)
                {
                    Console.WriteLine("ten");
                }
                else if (num == 11)
                {
                    Console.WriteLine("eleven");
                }
                else if (num == 12)
                {
                    Console.WriteLine("twelve");
                }
                else if (num == 13)
                {
                    Console.WriteLine("thirteen");
                }
                else if (num == 14)
                {
                    Console.WriteLine("fourteen");
                }
                else if (num == 15)
                {
                    Console.WriteLine("fifteen");
                }
                else if (num == 16)
                {
                    Console.WriteLine("sixteen");
                }
                else if (num == 17)
                {
                    Console.WriteLine("seventeen");
                }
                else if (num == 18)
                {
                    Console.WriteLine("eighteen");
                }
                else if (num == 19)
                {
                    Console.WriteLine("nineteen");
                }

            }
            else if (num > 19 && num < 100)
            {
                int firstNum = num/10;
                int secondNum = num%10;
                                      
                if (firstNum == 2)
                {
                    Console.Write("twenty");
                }
                else if (firstNum == 3)
                {
                    Console.Write("thirty");
                }
                else if (firstNum == 4)
                {
                    Console.Write("forty");
                }
                else if (firstNum == 5)
                {
                    Console.Write("fifty");
                }
                else if (firstNum == 6)
                {
                    Console.Write("sixty");
                }
                else if (firstNum == 7)
                {
                    Console.Write("seventy");
                }
                else if (firstNum == 8)
                {
                    Console.Write("eighty");
                }
                else if (firstNum == 9)
                {
                    Console.Write("ninety");
                }

                if (secondNum == 1)
                {
                    Console.Write(" one");
                }
                else if (secondNum == 2)
                {
                    Console.Write(" two");
                }
                else if (secondNum == 3)
                {
                    Console.Write(" three");
                }
                else if (secondNum == 4)
                {
                    Console.Write(" four");
                }
                else if (secondNum == 5)
                {
                    Console.Write(" five");
                }
                else if (secondNum == 6)
                {
                    Console.Write(" six");
                }
                else if (secondNum == 7)
                {
                    Console.Write(" seven");
                }
                else if (secondNum == 8)
                {
                    Console.Write(" eight");
                }
                else if (secondNum == 9)
                {
                    Console.Write(" nine");
                }
            }
            else if (num == 100)
            {
                Console.WriteLine("one hundred");
            }
            else
            {
                Console.WriteLine("invalid number");
            }


        }
    }
}
