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
                string[] inputInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                string model = inputInfo[0];

                int engineSpeed = int.Parse(inputInfo[1]);
                int enginePower = int.Parse(inputInfo[2]);

                int cargoWeight = int.Parse(inputInfo[3]);
                string cargoType = inputInfo[4];

                Tire[] tires = new Tire[4];
                int counter = 0;
                for (int tireIndex = 5; tireIndex < inputInfo.Length; tireIndex += 2)
                {
                    double currentTirePressure = double.Parse(inputInfo[tireIndex]);
                    int currentTireAge = int.Parse(inputInfo[tireIndex + 1]);

                    Tire tire = new Tire(currentTirePressure, currentTireAge);
                    tires[counter++] = tire;
                }
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string cargoTypeInput = Console.ReadLine();
            if (cargoTypeInput == "flamable")
            {
                cars
                    .Where(x => x.Cargo.CargoType == cargoTypeInput)
                    .Where(x => x.Engine.EnginePower > 250)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
            else if (cargoTypeInput == "fragile")
            {
                cars
                    .Where(x => x.Cargo.CargoType == cargoTypeInput)
                    .Where(x => x.Tires.Any(p=>p.TirePressure<1))
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}
