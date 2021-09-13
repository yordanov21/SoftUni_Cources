using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int years = int.Parse(Console.ReadLine());
            double laundry = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());

            double SavedMoney = 0;

            for (int i = 1; i <= years; i++)
            {
                if (i % 2 == 0)
                {
                    SavedMoney += i * 5;
                    SavedMoney -= 1;
                }
                else
                {
                    SavedMoney += toyPrice;
                }


            }
            if (SavedMoney >= laundry)
            {
                Console.WriteLine($"Yes! {Math.Abs(SavedMoney - laundry):f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(SavedMoney - laundry):f2}");

            }
        }
    }
}
