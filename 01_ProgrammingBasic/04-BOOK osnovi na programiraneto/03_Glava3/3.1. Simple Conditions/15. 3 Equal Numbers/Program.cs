﻿using System;

namespace _15._3_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            if (num1 == num2 && num2 == num3 && num3 == num1)           
                Console.WriteLine("yes");          
            else
                Console.WriteLine("no");
        }
    }
}
