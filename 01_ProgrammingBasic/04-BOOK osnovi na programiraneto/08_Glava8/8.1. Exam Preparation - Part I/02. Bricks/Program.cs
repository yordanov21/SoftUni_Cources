using System;

namespace _02._Bricks
{
    class Program
    {
        static void Main(string[] args)
        {
            double bricks = double.Parse(Console.ReadLine());
            double workers = double.Parse(Console.ReadLine());
            double cartCapasity = double.Parse(Console.ReadLine());
            
            double oneCourseCapasity = workers * cartCapasity;
            
            double volume = oneCourseCapasity;
            double courses = Math.Ceiling(bricks/oneCourseCapasity);

          
            Console.WriteLine(courses);
        }
    }
}
