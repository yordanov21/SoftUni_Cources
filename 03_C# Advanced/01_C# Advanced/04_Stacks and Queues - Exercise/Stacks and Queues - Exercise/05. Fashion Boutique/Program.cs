using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothsInBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());

            int countRack = 0;
            int currentRack = 0;
            while (clothsInBox.Count > 0)
            {
                int currentCloth = clothsInBox.Peek();
                currentRack += currentCloth;
                if (currentRack <= rackCapacity)
                {
                    clothsInBox.Pop();

                }
                else
                {
                    currentRack = 0;
                    countRack++;
                }
            }
            countRack++;
            Console.WriteLine(countRack);
        }
    }
}
