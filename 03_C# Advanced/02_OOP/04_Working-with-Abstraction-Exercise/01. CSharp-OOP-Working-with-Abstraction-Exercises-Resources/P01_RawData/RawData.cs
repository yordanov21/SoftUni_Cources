﻿namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RawData
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                GenerateCar(cars, parameters);
            }

            string command = Console.ReadLine();

            CheckCargoType(cars, command);
        }

        private static void CheckCargoType(List<Car> cars, string command)
        {
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile")
                    .Where(x => x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static void GenerateCar(List<Car> cars, string[] parameters)
        {
            Tire[] tires = new Tire[4];

            string model = parameters[0];

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            Engine engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            double tire1Pressure = double.Parse(parameters[5]);
            int tire1age = int.Parse(parameters[6]);
            tires[0] = new Tire(tire1age, tire1Pressure);

            double tire2Pressure = double.Parse(parameters[7]);
            int tire2age = int.Parse(parameters[8]);
            tires[1] = new Tire(tire2age, tire2Pressure);

            double tire3Pressure = double.Parse(parameters[9]);
            int tire3age = int.Parse(parameters[10]);
            tires[2] = new Tire(tire3age, tire3Pressure);

            double tire4Pressure = double.Parse(parameters[11]);
            int tire4age = int.Parse(parameters[12]);
            tires[3] = new Tire(tire4age, tire4Pressure);

            cars.Add(new Car(model, engine, cargo, tires));
        }
    }
}
