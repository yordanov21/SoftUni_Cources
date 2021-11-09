using System;

namespace _02RandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ramdonNumbers = new Random();
            Console.WriteLine(ramdonNumbers.Next(0,100));
            Console.WriteLine(ramdonNumbers.Next(0,100));
            Console.WriteLine(ramdonNumbers.Next(0,100));
            Console.WriteLine(ramdonNumbers.Next(0,100));
            Console.WriteLine(ramdonNumbers.Next(0,100));
            Console.WriteLine(ramdonNumbers.Next(0,100));
            Console.WriteLine(ramdonNumbers.Next(0,100));
            Console.WriteLine(ramdonNumbers.Next(0,100));
        }
    }
}
