namespace _01ClassBoxData
{
    using System;

    public class Program
    {
        public static void Main()
        {
            //You are given a geometric figure box with parameters length, width and height.
            //Model a class Box that that can be instantiated by the same three parameters.
            //Expose to the outside world only methods for its surface area,lateral surface area and its volume
            //(formulas: http://www.mathwords.com/r/rectangular_parallelepiped.htm).
            //A box’s side should not be zero or a negative number.
            //Аdd data validation for each parameter given to the constructor.
            //Make a private setter that performs data validation internally.

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double heght = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, heght);
                Console.WriteLine(box.SurfaceArea());
                Console.WriteLine(box.LateralSurfaceArea());
                Console.WriteLine(box.Volume());
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
           
        }
    }
}
