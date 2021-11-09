using System;

namespace example1
{
    class Program
    {
        static void Main(string[] args)
        {
            int squarePerimeter = 17;
            double squareSide = squarePerimeter / 4.0;
            double squareArea = squareSide * squareSide;
            Console.WriteLine(squareSide); //4.25
            Console.WriteLine(squareArea); //18.0625

            int a = 5;
            int b = 4;
            Console.WriteLine(a+b);      //9
            Console.WriteLine(a+b++);    //9
            Console.WriteLine(a+b);      //10
            Console.WriteLine(a+(++b));  //11
            Console.WriteLine(a+b);      //11
            Console.WriteLine(14/a);     //2
            Console.WriteLine(14%a);     //4

            int one = 1;
            int zero = 0;
           Console.WriteLine(one/zero); //DivideByZeroException: Attempted to divide by zero

            double dMinusOne = -1.0;
            double dZero = 0.0;
            Console.WriteLine(dMinusOne/dZero); //-Infinity (-?)
            Console.WriteLine(one/dZero); //Infinity (?)
        }
    }
}
