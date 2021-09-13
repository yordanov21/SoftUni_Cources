using System;

namespace _06._Point_on_Rectangle_Border
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());

            bool onLeftSide = x == x1 && y >= y1 && y <= y2;
            bool onRightSide = x == x2 && y >= y1 && y <= y2;
            bool onUpSide = y == y1 && x >= x1 && x <= x2;
            bool onDownSide = y == y2 && x >= x1 && x <= x2;

            if (onLeftSide || onRightSide || onUpSide || onDownSide)
            {
                Console.WriteLine("Border");
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}
