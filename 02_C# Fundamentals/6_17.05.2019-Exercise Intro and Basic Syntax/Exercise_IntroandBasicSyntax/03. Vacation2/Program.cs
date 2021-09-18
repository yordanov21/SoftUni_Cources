using System;

namespace _03._Vacation2
{
    class Program
    {
        static void Main(string[] args)
        {
            double group = double.Parse(Console.ReadLine());
            string tipe = Console.ReadLine();
            string day = Console.ReadLine();
            double totalPrice = 0.0;

            switch (tipe)
            {
                case "Students":
                    if (day == "Friday")
                    {
                        if (group >= 30)
                        {
                            totalPrice = group * 8.45 - 0.15 * group * 8.45;
                            Console.WriteLine($"Total price: {totalPrice:f2}");                         
                        }
                        else
                        {
                            totalPrice = group * 8.45;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                    }
                    else if(day == "Saturday")
                    {
                        if (group >= 30)
                        {
                            totalPrice = group * 9.80 - 0.15 * group * 9.80;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                        else
                        {
                            totalPrice = group * 9.80;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                    }
                    else if (day == "Sunday")
                    {
                        if (group >= 30)
                        {
                            totalPrice = group * 10.46 - 0.15 * group * 10.46;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                        else
                        {
                            totalPrice = group * 10.46;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                    }
                    break;

                case "Business":
                    if (day == "Friday")
                    {
                        if (group >= 100)
                        {
                            totalPrice = (group - 10) * 10.90; 
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                        else
                        {
                            totalPrice = group * 10.90;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                    }
                    else if (day == "Saturday")
                    {
                        if (group >= 100)
                        {
                            totalPrice = (group - 10) * 15.60;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                        else
                        {
                            totalPrice = group * 15.60;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                    }
                    else if (day == "Sunday")
                    {
                        if (group >= 100)
                        {
                            totalPrice = (group - 10) * 16;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                        else
                        {
                            totalPrice = group * 16;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                    }
                    break;

                case "Regular":
                    if (day == "Friday")
                    {
                        if (group >= 10 && group<=20)
                        {
                            totalPrice = group *15*0.95;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                        else
                        {
                            totalPrice = group * 15;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                    }
                    else if (day == "Saturday")
                    {
                        if (group >= 10 && group <= 20)
                        {
                            totalPrice = group * 20 * 0.95;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                        else
                        {
                            totalPrice = group * 20;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                    }
                    else if (day == "Sunday")
                    {
                        if (group >= 10 && group <= 20)
                        {
                            totalPrice = group * 22.50* 0.95;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                        else
                        {
                            totalPrice = group * 22.50;
                            Console.WriteLine($"Total price: {totalPrice:f2}");
                        }
                    }
                    break;
            }
        }
    }
}
