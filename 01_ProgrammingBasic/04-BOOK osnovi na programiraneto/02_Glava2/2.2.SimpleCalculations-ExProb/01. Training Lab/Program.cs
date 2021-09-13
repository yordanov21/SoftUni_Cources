using System;

namespace _01._Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine())*100;
            double w = double.Parse(Console.ReadLine())*100;
            int rows =(int) l / 120;
            int deskOnRow = (int)(w - 100) / 70;
            int sites = rows * deskOnRow-3;
            Console.WriteLine(sites);
        }
    }
}
