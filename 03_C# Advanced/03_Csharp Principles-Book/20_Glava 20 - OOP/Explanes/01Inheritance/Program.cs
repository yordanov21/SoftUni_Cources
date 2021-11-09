using System;

namespace _01Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            AfricanLion africanLion = new AfricanLion(true, 80);
            object obj = africanLion;

            try
            {
                AfricanLion castedLion = (AfricanLion)obj;
            }
            catch
            {
                Console.WriteLine("obj cannot be downcasted to AfricanLion");
            }

            Console.WriteLine(new object());
            Console.WriteLine(new Felidae(true));
            Console.WriteLine(new Lion(true, 80));
            Console.WriteLine(africanLion);

           
        }
    }
}
