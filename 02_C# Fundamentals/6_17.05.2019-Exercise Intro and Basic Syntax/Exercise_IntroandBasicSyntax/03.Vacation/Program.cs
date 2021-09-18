using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());
            string tipe=Console.ReadLine();
            string day = Console.ReadLine();
            double totalPrice = 0.0;
            if (tipe == "Students")
            {
                if (day == "Friday")
                {
                    if (group >= 30)
                    {
                        totalPrice = 8.45 * group - 0.15 * 8.45 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else
                    {
                        totalPrice = 8.45 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }
                else if (day == "Saturday")
                {
                    if (group >= 30)
                    {
                        totalPrice = 9.80 * group - 0.15 * 9.80 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else
                    {
                        totalPrice = 9.80 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }
                if (day == "Sunday")
                {
                    if (group >= 30)
                    {
                        totalPrice = 10.46 * group - 0.15 * 10.46 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else
                    {
                        totalPrice = 10.46 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }

            }
            else if (tipe == "Business")
            {
                if (day == "Friday")
                {
                    if (group >= 100)
                    {
                        totalPrice = 10.90 * (group - 10);
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else
                    {
                        totalPrice = 10.90 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }
                else if (day == "Saturday")
                {
                    if (group >= 100)
                    {
                        totalPrice = 15.60 * (group - 10);
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else
                    {
                        totalPrice =15.60 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }
                if (day == "Sunday")
                {
                    if (group >= 100)
                    {
                        totalPrice = 16.00 * (group -10);
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else
                    {
                        totalPrice =16.00 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }

            }
            else if (tipe == "Regular")
            {
                if (day == "Friday")
                {
                    if (group >= 10 && group<=20)
                    {
                        totalPrice = 15.00 * group - 0.05 * 15.00 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else
                    {
                        totalPrice = 15.00 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }
                else if (day == "Saturday")
                {
                    if (group >= 10 && group <= 20)
                    {
                        totalPrice = 20.00 * group - 0.05 * 20.00 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else
                    {
                        totalPrice = 20.00 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }
                if (day == "Sunday")
                {
                    if (group >= 10 && group <= 20)
                    {
                        totalPrice = 22.50 * group - 0.05 * 22.50 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else
                    {
                        totalPrice = 22.50 * group;
                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }

            }
        }
    }
}
