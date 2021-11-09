namespace Animals
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
   
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Beast!")
                {
                    break;
                }

                var arguments = Console.ReadLine().Split(); //remove empty entries

                try
                {              
                    string name = arguments[0];
                    int age = int.Parse(arguments[1]);
                    string gender = arguments[2];

                    Animal animal = null;
                    if (input == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (input == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (input == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (input == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (input == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    if (animal!=null)
                    {
                        animals.Add(animal);
                    }

                }
                catch (ArgumentException argException)
                {
                    Console.WriteLine(argException.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
