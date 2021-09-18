using System;

namespace _09._Padawan_Equipment2
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceLightsaber = double.Parse(Console.ReadLine());
            double priceRobe = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());

            double saberStudent = Math.Ceiling(students * 1.1);

            double priceAllLightsabers = priceLightsaber *saberStudent;
            double priceAllRobes = priceRobe * students;
            double priceAllBelt = priceBelt * students;
            if (students >= 6)
            {
               int freeBelt = students / 6;
               priceAllBelt = priceAllBelt - freeBelt * priceBelt;
            }
            double allPrice = priceAllLightsabers + priceAllRobes +priceAllBelt;

            if (buget>=allPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {allPrice:f2}lv.");
            }
            else
            {
                double difference = allPrice - buget;
                Console.WriteLine($"Ivan Cho will need {difference:f2}lv more.");
            }
        }
    }
}
