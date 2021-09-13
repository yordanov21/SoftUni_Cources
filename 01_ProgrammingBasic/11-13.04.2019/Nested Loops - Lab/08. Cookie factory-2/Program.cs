using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Cookie_factory_2
{
    class Program
    {
        static void Main(string[] args)
        {

            int partidi = int.Parse(Console.ReadLine());

            int part = 0;

            bool flour = false;
            bool eggs = false;
            bool sugar = false;

            while (true)
            {
                string ingridients = Console.ReadLine();

                if (ingridients == "flour")
                    flour = true;
                if (ingridients == "eggs")
                    eggs = true;
                if (ingridients == "sugar")
                    sugar = true;




                if (ingridients == "Bake!")
                {

                    if (flour == false || eggs == false || sugar == false)
                        Console.WriteLine("The batter should contain flour, eggs and sugar!");

                    else if (flour == true && eggs == true && sugar == true)
                    {
                        part++;
                        Console.WriteLine($"Baking batch number {part}...");
                        flour = false;
                        eggs = false;
                        sugar = false;
                    }
                }

                if (part == partidi)
                    break;
            }
        }
    }
}
