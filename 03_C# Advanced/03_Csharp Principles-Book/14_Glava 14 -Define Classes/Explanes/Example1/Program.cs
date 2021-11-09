namespace Example1
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            //First Example
            Dog dog1 = new Dog();
            dog1.Bark();

            dog1.Name = "Roshko";
            dog1.Bark();
            
           
            //Second Example

            string firstDogName = null;
            Console.WriteLine("Write first dog name: ");
            firstDogName = Console.ReadLine();

            Dog firstDog = new Dog(firstDogName);
            Dog secondDog = new Dog();

            Console.WriteLine("Write second dog name:");
            string secondDogName = Console.ReadLine();
            secondDog.Name = secondDogName;

            Dog thirdDog = new Dog();
            Dog[] dogs = new Dog[] { firstDog, secondDog, thirdDog };

            foreach (Dog dog in dogs)
            {
                dog.Bark();
            }
        }
    }
}
