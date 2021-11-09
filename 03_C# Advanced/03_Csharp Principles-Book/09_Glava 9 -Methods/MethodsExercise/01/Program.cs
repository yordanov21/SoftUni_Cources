using System;
using System.Text.RegularExpressions;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            PrintName(name);
        }

        static void PrintName(string name)
        {
            if (CheckName(name))
            {
                Console.WriteLine($"Hello, {name}!");
            }
            else
            {
                Console.WriteLine("Invalid name!");
            }
        }

        static bool CheckName(string name)
        {
           
            if (string.IsNullOrWhiteSpace(name) || Regex.IsMatch(name, @"^\d+$"))
            {
                return false;
            }
            
            return true;
        }
    }
}
