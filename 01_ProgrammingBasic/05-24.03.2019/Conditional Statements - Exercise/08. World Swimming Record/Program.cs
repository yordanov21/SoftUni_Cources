using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distanse = double.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());

            double secоnds = distanse * time;
            double secоndсSlowly = Math.Floor(distanse / 15.0) * 12.5;
            double AllSeconds = secоnds + secоndсSlowly;
            double difference =Math.Abs( record - AllSeconds);
            if (AllSeconds < record)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {AllSeconds:f2} seconds.");
            }
            else
            {
                
                Console.WriteLine($"No, he failed! He was {difference:f2} seconds slower.");
            }
        }
    }
}
