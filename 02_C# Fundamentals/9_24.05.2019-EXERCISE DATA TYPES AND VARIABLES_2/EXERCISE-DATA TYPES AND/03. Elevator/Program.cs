using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int person = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            //int courses = 0;
            //
            //if (person % capacity == 0)
            //{
            //    courses = person / capacity;
            //}
            //else
            //{
            //    courses = person / capacity + 1;
            //}
            //Console.WriteLine(courses);
            int courses = (int)Math.Ceiling((double)person / capacity);
            Console.WriteLine(courses);
        }
    }
}
