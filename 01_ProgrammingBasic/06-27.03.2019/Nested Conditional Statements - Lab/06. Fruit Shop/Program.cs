﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "banana")
                {
                    price = quantity * 2.50;
                    
                }
                else if (fruit == "apple")
                {
                    price = quantity * 1.20;
                    
                }
                else if (fruit == "orange")
                {
                    price = quantity * 0.85;
                    
                }
                else if (fruit == "grapefruit")
                {
                    price = quantity * 1.45;
                    
                }
                else if (fruit == "kiwi")
                {
                    price = quantity * 2.70;
                    
                }
                else if (fruit == "pineapple")
                {
                    price = quantity * 5.50;
                    
                }
                else if (fruit == "grapes")
                {
                    price = quantity * 3.85;
                    
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                if (fruit == "banana")
                {
                    price = quantity * 2.70;
                    
                }
                else if (fruit == "apple")
                {
                    price = quantity * 1.25;
                    
                }
                else if (fruit == "orange")
                {
                    price = quantity * 0.90;
                    
                }
                else if (fruit == "grapefruit")
                {
                    price = quantity * 1.60;
                   
                }
                else if (fruit == "kiwi")
                {
                    price = quantity * 3.00;
                 
                }
                else if (fruit == "pineapple")
                {
                    price = quantity * 5.60;
                    
                }
                else if (fruit == "grapes")
                {
                    price = quantity * 4.20;
                   
                }
            }

            if (price > 0)
            {
                Console.WriteLine($"{price:f2}");
            }  
             else
            {
                Console.WriteLine("error");
            }


        }
    }
}
