using System;

namespace _04._Point_in_Figure
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool pointInFigure1 = x >= 2 && x <= 12 && y >= -3 && y <= 1;
            bool pointInFigure2 = x >= 4 && x <= 10 && y >= -5 && y <= 3;
            if (pointInFigure1 || pointInFigure2)
            {
                Console.WriteLine("in");
            }
            else
            {
                Console.WriteLine("out");
            }
        }
    }
}