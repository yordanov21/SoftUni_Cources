using System;

namespace _13._Point_in_the_Figure
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());

            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool inSideFigire1 = (x > 0 && x < 3 * h && y > 0 && y < h);
            bool inSideFigire2 = (x > h && x < 2 * h && y >= h && y < 4 * h);


            bool onBorderFig1 = (x == 0 && y >= 0 && y <= h) || (x == 3 * h && y >= 0 && y <= h) ||
                (y == 0 && x >= 0 && x <= 3 * h) || (y == h && x >= 0 && x <= h) || (y == h && x >= 2 * h && x <= 3 * h);
            bool onBorderFig2 = (x == h && y >= h && y <= 4 * h) || (x == 2 * h && y >= h && y <= 4 * h) || (y == 4 * h && x >= h && x <= 2 * h);

            if (inSideFigire1 || inSideFigire2)
            {
                Console.WriteLine("inside");
            }
            else if (onBorderFig1 || onBorderFig2)
            {
                Console.WriteLine("border");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}
