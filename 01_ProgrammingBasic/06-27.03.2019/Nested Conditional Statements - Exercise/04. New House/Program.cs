using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            double flowers = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double price = 0;
            double discount = 0;


            if (type == "Roses")
            {
                price = flowers * 5;

                if (flowers > 80)
                {
                    discount = price * 0.1;
                    double cost = price - discount;
                    double resеt = budget - cost;

                    if (budget >= cost)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowers} {type} and {resеt:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {Math.Abs(resеt):f2} leva more.");
                    }
                }
                else if (flowers <= 80)
                {

                    double cost = price;
                    double resеt = budget - cost;

                    if (budget >= cost)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowers} {type} and {resеt:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {Math.Abs(resеt):f2} leva more.");
                    }
                }
            }
            else if (type == "Dahlias")
            {
                price = flowers * 3.80;

                if (flowers > 90)
                {
                    discount = price * 0.15;
                    double cost = price - discount;
                    double resеt = budget - cost;

                    if (budget >= cost)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowers} {type} and {resеt:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {Math.Abs(resеt):f2} leva more.");
                    }
                }
                else if (flowers <= 90)
                {

                    double cost = price;
                    double resеt = budget - cost;

                    if (budget >= cost)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowers} {type} and {resеt:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {Math.Abs(resеt):f2} leva more.");
                    }
                }
            }
            else if (type == "Tulips")
            {
                price = flowers * 2.80;

                if (flowers > 80)
                {
                    discount = price * 0.15;
                    double cost = price - discount;
                    double resеt = budget - cost;

                    if (budget >= cost)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowers} {type} and {resеt:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {Math.Abs(resеt):f2} leva more.");
                    }
                }
                else if (flowers <= 80)
                {

                    double cost = price;
                    double resеt = budget - cost;

                    if (budget >= cost)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowers} {type} and {resеt:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {Math.Abs(resеt):f2} leva more.");
                    }
                }
            }
            else if (type == "Narcissus")
            {
                price = flowers * 3;

                if (flowers < 120)
                {
                    discount = price * 0.15;
                    double cost = price + discount;
                    double resеt = budget - cost;

                    if (budget >= cost)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowers} {type} and {resеt:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {Math.Abs(resеt):f2} leva more.");
                    }
                }
                else if (flowers >= 120)
                {

                    double cost = price;
                    double resеt = budget - cost;

                    if (budget >= cost)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowers} {type} and {resеt:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {Math.Abs(resеt):f2} leva more.");
                    }
                }
            }
            else if (type == "Gladiolus")
            {
                price = flowers * 2.5;

                if (flowers < 80)
                {
                    discount = price * 0.20;
                    double cost = price + discount;
                    double resеt = budget - cost;

                    if (budget >= cost)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowers} {type} and {resеt:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {Math.Abs(resеt):f2} leva more.");
                    }
                }
                else if (flowers >= 80)
                {

                    double cost = price;
                    double resеt = budget - cost;

                    if (budget >= cost)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowers} {type} and {resеt:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {Math.Abs(resеt):f2} leva more.");
                    }
                }

            }
        }
    }
}
