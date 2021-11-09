using System;

namespace example3
{
    class Program
    {
        static void Main(string[] args)
        {
            Collar collar = new Collar(5);
            Console.WriteLine("Collar's size is: " + collar.Size);

            Dog dog = new Dog();
            
            Dog.ReturnFive();
               
        }
    }
}
