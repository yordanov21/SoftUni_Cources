﻿using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string strReversed = "";
            string userInput = "";
            int counter = 0;

            for (int i = str.Length - 1; i >= 0; --i)
            {
                strReversed += str[i];
            }

            while ((userInput = Console.ReadLine()) != strReversed)
            {
                if (userInput != strReversed)
                {
                    if (counter == 3)
                    {
                        Console.WriteLine($"User {str} blocked!");
                        return;
                    }
                    Console.WriteLine($"Incorrect password. Try again.");
                    counter++;
                }
            }
            if (userInput == strReversed)
            {
                Console.WriteLine($"User {str} logged in.");
            }
        }
    }
}
