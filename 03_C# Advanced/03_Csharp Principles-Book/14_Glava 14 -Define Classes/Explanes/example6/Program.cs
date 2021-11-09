using System;

namespace example6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(3);
            circle.PrintSurface();

            double radius = 5;
            // Accessing static method from other static method
            double circlePerimeter =Circle.CalculateCirclePerimeter(radius);
            Console.WriteLine("Circle with radius " + radius +
            " has perimeter: " + circlePerimeter);
        }

     
    }

}
