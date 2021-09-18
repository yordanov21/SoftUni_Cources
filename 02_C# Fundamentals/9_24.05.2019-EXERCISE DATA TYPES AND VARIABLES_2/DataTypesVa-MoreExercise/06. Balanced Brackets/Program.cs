using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = 1; i <= lines; i++)
            {
                string num = Console.ReadLine();
              
                if (num == "("|| num==")")
                {
                    counter++;
                }

            }
            if (counter % 2 == 0)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
