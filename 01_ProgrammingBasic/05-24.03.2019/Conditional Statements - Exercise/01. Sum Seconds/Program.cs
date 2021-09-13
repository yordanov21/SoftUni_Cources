using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int FirstTime = int.Parse(Console.ReadLine());
            int SecondTime = int.Parse(Console.ReadLine());
            int ThirdTime = int.Parse(Console.ReadLine());

            int TotalTime = FirstTime + SecondTime + ThirdTime;
            int minutes = TotalTime / 60;
            int secounds = TotalTime % 60;
            if (secounds < 10)
            {
                Console.WriteLine($"{minutes}:0{secounds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{secounds}");
            }


        }
    }
}
