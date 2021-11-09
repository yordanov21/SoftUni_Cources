namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(100, 100);
            vehicle.Drive(10);

            SportCar sportCar = new SportCar(100, 100);
            sportCar.Drive(10);

            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(100, 100);
            raceMotorcycle.Drive(10);

            Car car = new Car(100, 100);
            car.Drive(10);

            System.Console.WriteLine(vehicle);
            System.Console.WriteLine(sportCar);
            System.Console.WriteLine(raceMotorcycle);
            System.Console.WriteLine(car);
        }
    }
}
