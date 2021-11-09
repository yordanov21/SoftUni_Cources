using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Make_a_Salad
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> vegetables = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            List<int> readySalads = new List<int>();

            int currentCalories = 0;
            int vegyCalories = 0;

            while (vegetables.Count > 0 && calories.Count > 0)
            {
                string currentVegy = vegetables.Dequeue().ToLower(); //може и без ToLower()

                if (currentVegy == "tomato")
                {
                    vegyCalories = 80;
                }
                else if (currentVegy == "carrot")
                {

                    vegyCalories = 136;
                }
                else if (currentVegy == "lettuce")
                {

                    vegyCalories = 109;
                }
                else if (currentVegy == "potato")
                {

                    vegyCalories = 215;
                }

                currentCalories += vegyCalories;
                int currentSaladCalories = calories.Peek();
                if (currentSaladCalories <= currentCalories)
                {
                    readySalads.Add(currentSaladCalories);
                    currentCalories -= currentSaladCalories;
                    calories.Pop();
                }
            }

            if (readySalads.Any())
            {
                Console.WriteLine(string.Join(" ", readySalads));
            }

            if (vegetables.Any())
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
            if (calories.Any())
            {
                Console.WriteLine(string.Join(" ", calories));
            }
        }
    }
}
