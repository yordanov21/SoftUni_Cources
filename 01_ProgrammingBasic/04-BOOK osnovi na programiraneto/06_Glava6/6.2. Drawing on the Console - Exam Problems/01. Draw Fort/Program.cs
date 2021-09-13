using System;

namespace _01._Draw_Fort
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.Write("/");
            for (int i = 0; i < n/2; i++)
            {
                Console.Write("^");
            }
            Console.Write("\\");
            var colSize = n / 2;
            var midSize = 2 * n - 2 * colSize - 4;
            Console.Write(new string ('_',midSize));
            Console.Write("/");
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write("^");
            }
            Console.Write("\\");
            Console.WriteLine();

            for (int i = 1; i < n-2; i++)
            {
                Console.WriteLine("|"+new string(' ',n*2-2)+"|");
            }

            Console.WriteLine("|" + new string(' ', colSize+1) + new string('_', midSize)+ new string(' ', colSize+1) +"|");
           

            Console.Write("\\");
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write("_");
            }
            Console.Write("/");
           
            Console.Write(new string(' ', midSize));
            Console.Write("\\");
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write("_");
            }
            Console.Write("/");
         
        }
    }
}
