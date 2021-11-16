namespace DeprecatedClass
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var simulator = new Summator();

            var privateObject = new PrivateObject(simulator);

            var result = privateObject.Invoke("GetSum", 12, 13);

            Console.WriteLine(result);
        }
    }
}