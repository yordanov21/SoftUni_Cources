using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Name_Wars
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = Console.ReadLine();
            int maxSum = int.MinValue;
            string max = string.Empty;
            int SUM = 0;

            while (name != "STOP")
            {
                for (int i = 0; i < name.Length; i++)
                {
                    int x = name[i];
                    SUM += x;
                    if (SUM >= maxSum)
                    {
                        maxSum = SUM;
                        max = name;
                    }
                }

                name = Console.ReadLine();
                SUM = 0;
            }
            Console.WriteLine($"Winner is {max} - {maxSum}!");
        }
    }
}
