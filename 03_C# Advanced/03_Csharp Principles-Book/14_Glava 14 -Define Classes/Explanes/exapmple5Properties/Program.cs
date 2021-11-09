using System;

namespace exapmple5Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Point myPoint = new Point(2, 3);
            double myPointXCoordinate = myPoint.X; // Access a property
            double myPointYCoordinate = myPoint.Y; // Access a property
            Console.WriteLine("The X coordinate is: " + myPointXCoordinate);
            Console.WriteLine("The Y coordinate is: " + myPointYCoordinate);

            Rectangle rectangle = new Rectangle(2, 5);
            Console.WriteLine(rectangle.Area);

        }
    }
}
