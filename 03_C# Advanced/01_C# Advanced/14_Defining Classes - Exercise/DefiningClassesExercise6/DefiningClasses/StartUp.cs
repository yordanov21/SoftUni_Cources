using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var inputInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                string model = inputInfo[0];
                double fuelAmount = double.Parse(inputInfo[1]);
                double fuelConsumptionFor1Km = double.Parse(inputInfo[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionFor1Km, 0);

                cars.Add(car);
            }

            while (true)
            {
                string inputInfo2 = Console.ReadLine();
                if (inputInfo2 == "End")
                {
                    break;
                }

                string[] splitedInput  = inputInfo2
                    .Split()
                    .ToArray();

                string model = splitedInput[1];
                double amountOfKm =double.Parse(splitedInput[2]);

                cars.Where(c => c.Model == model).ToList().ForEach(c => c.CheckCarDistance(amountOfKm));
            }

            foreach (var car in cars)
            {
                string model = car.Model;
                double fuelAmount = car.FuelAmount;
                double distanceTraveled = car.TravelledDistance;
                Console.WriteLine($"{model} {fuelAmount:f2} {distanceTraveled}");
            }
        }
    }
}
