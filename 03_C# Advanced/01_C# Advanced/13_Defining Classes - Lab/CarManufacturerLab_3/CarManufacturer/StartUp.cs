﻿using System;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year =int.Parse( Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, 
                fuelQuantity, fuelConsumption);
         // Console.WriteLine(firstCar.WhoAmI());
         // Console.WriteLine();
         // Console.WriteLine(secondCar.WhoAmI());
         // Console.WriteLine();
         // Console.WriteLine(thirdCar.WhoAmI());

        }
    }
}
