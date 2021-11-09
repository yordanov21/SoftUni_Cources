using System;

namespace example7
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateSquareSurface(20.5);
            Console.WriteLine(CalculateSquareSurface(20.5));
            var result=CalculateSquareSurfaceTwo(5);

            var personInfo = (name: "Steeve", age: 27, "Bulgaria");
            Console.WriteLine(personInfo);

            var division = Divide(10, 4);
            Console.WriteLine(division.result);
            Console.WriteLine(division.reminder);

            int age = 17;

            double GetAgeAfter(int years)
            {
              return  age+years;
            }

            
            Console.WriteLine(GetAgeAfter(3));
        }

        static double CalculateSquareSurface(double sideLenght)
        {
            double surface = sideLenght * sideLenght;
            return surface;
        }
        static float CalculateSquareSurfaceTwo(int sideLenght)
        {
            int surface = sideLenght * sideLenght;
            return surface;
        
        }

        static (int result, int reminder) Divide(int x, int y)
        {
            int result = x / y;
            int reminder = x % y;

            return (result, result);
        }
    }
}
