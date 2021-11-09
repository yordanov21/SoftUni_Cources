using System;

namespace Shapes
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            Circle circle = new Circle(5);
            Rectangle rectangle = new Rectangle(3, 5);

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());

            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());

            Shape shape = new Circle(10);
            Shape shape1 = new Rectangle(10, 10);

            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.Draw());
          
            Console.WriteLine(shape1.CalculateArea());
            Console.WriteLine(shape1.CalculatePerimeter());
            Console.WriteLine(shape1.Draw());

           
        }
    }
}
