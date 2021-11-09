using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);

            var width = int.Parse(Console.ReadLine());
            var height= int.Parse(Console.ReadLine());
            IDrawable rectangle = new Rectangle(width, height);

            circle.Draw();
            rectangle.Draw();

            var radius2 = int.Parse(Console.ReadLine());
            Circle circle2 = new Circle(radius2);
            circle2.Draw();
            var width2 = int.Parse(Console.ReadLine());
            var height2 = int.Parse(Console.ReadLine());
            Rectangle rectangle2 = new Rectangle(width2, height2);
            rectangle2.Draw();
        }
    }
}
