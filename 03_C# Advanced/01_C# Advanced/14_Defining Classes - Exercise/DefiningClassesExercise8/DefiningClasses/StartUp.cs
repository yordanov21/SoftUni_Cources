using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] inputInfoEngine = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Engine engine = null;
                string model = inputInfoEngine[0];
                int power = int.Parse(inputInfoEngine[1]);
                if (inputInfoEngine.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                else if (inputInfoEngine.Length == 4)
                {
                    int displacement = int.Parse(inputInfoEngine[2]);
                    string efficienty = inputInfoEngine[3];

                    engine = new Engine(model, power, displacement, efficienty);
                }
                else
                {
                    bool isDisplacement = int.TryParse(inputInfoEngine[2], out int displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, inputInfoEngine[2]);
                    }

                }

                engines.Add(engine);
            }

            int M = int.Parse(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                string[] inputInfoCar = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = inputInfoCar[0];
                string engineModel = inputInfoCar[1];

                Engine engine = engines
                    .Where(x => x.Model == engineModel)
                    .FirstOrDefault();

                Car car = null;

                if (inputInfoCar.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (inputInfoCar.Length == 4)
                {
                    int weigth = int.Parse(inputInfoCar[2]);
                    string color = inputInfoCar[3];
                    car = new Car(model, engine, weigth, color);
                }
                else
                {

                    bool isWeigth = int.TryParse(inputInfoCar[2], out int weigth);

                    if (isWeigth)
                    {
                        car = new Car(model, engine, weigth);
                    }
                    else
                    {
                        car = new Car(model, engine, inputInfoCar[2]);
                    }

                }

                cars.Add(car);
                         
            }

            Console.WriteLine(string.Join(Environment.NewLine,cars));
        }
    }
}
