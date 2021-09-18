using System;

namespace _01.Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int Num = int.Parse(Console.ReadLine());

            if (Num <= 2)
            {
                Console.WriteLine("baby");         
            }
            else if(Num>=3 && Num < 14)
            {
                Console.WriteLine("child");
            }
            else if (Num > 13 && Num < 20)
            {
                Console.WriteLine("teenager");
            }
            else if (Num > 19 && Num < 66)
            {
                Console.WriteLine("adult");
            }
            else if(Num >=66)
            {
                Console.WriteLine("elder");
            }
        }
    }
}
