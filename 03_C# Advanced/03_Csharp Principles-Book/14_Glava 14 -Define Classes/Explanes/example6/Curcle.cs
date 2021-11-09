using System;
using System.Collections.Generic;
using System.Text;

namespace example6
{
    public class Circle
    {
        public static double PI = 3.141592653589793;
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public static double CalculateSurface(double radius)
        {
            return (PI * radius * radius);
        }
        public void PrintSurface()
        {
            double surface = CalculateSurface(radius);
            Console.WriteLine("Circle's surface is: " + surface);
        }

        // The method applies the formula: P = 2 * PI * r
        public static double CalculateCirclePerimeter(double r)
        {
            // Accessing the static variable PI from static method
            return (2 * PI * r);
        }
    }
}
