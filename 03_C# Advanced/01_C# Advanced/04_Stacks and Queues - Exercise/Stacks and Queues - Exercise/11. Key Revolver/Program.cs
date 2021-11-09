using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int intelligance = int.Parse(Console.ReadLine());
            int countTotalBullet = 0;
            int countBullet = 0;
            Stack<int> bulletStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);

            while (bulletStack.Count > 0 && locksQueue.Count > 0)
            {
                var currentLock = locksQueue.Peek();
                var currentBullet = bulletStack.Pop();
                countBullet++;
                countTotalBullet++;
                if (currentBullet <= currentLock)
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (countBullet == sizeOfGunBarrel&&bulletStack.Count>0)
                {
                    Console.WriteLine("Reloading!");
                    countBullet = 0;
                    continue;

                }
            }
            if (locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                int moneyEarned = intelligance - countTotalBullet * priceOfBullet;
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
