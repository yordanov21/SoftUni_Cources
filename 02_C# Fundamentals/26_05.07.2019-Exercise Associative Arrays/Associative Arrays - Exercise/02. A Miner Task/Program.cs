using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var resourses = new Dictionary<string, int>();
            while (true)
            {
                string resourseCommnad = Console.ReadLine();
                if (resourseCommnad == "stop")
                {
                    break;
                }
                int quantity = int.Parse(Console.ReadLine());
                if (!resourses.ContainsKey(resourseCommnad))
                {
                    resourses.Add(resourseCommnad, quantity);
                }
                else
                {
                    resourses[resourseCommnad] += quantity;
                }
            }

            foreach (var item in resourses)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
