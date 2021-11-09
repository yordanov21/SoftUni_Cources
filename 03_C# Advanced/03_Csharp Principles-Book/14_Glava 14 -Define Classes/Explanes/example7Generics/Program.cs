using System;

namespace example7Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalShelter<Dog> dogsShelter = new AnimalShelter<Dog>(10);
            Dog dog1 = new Dog();
            Dog dog2 = new Dog();
            Dog dog3 = new Dog();
            dogsShelter.Shelter(dog1);
            dogsShelter.Shelter(dog2);
            dogsShelter.Shelter(dog3);
            dogsShelter.Release(1); // Releasing dog2


            AnimalShelter<Cat> catsShelter = new AnimalShelter<Cat>();
            Cat cat1 = new Cat();
            Cat cat2 = new Cat();
            Cat cat3 = new Cat();
            Cat cat4 = new Cat();
            Cat cat5 = new Cat();
            catsShelter.Shelter(cat1);
            catsShelter.Shelter(cat2);
            catsShelter.Shelter(cat3);
            catsShelter.Shelter(cat4);
            catsShelter.Shelter(cat5);
            catsShelter.Release(2);
        }
    }
}
