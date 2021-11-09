using System;
using example3;
namespace example2
{
    class Program
    {
        static void Main(string[] args)
        {

            Dog dog = new Dog();
            dog.DoSth();
            Kid kid = new Kid();
            kid.CallTheDog(dog);
            kid.WagTheDog(dog);

        }
    }
    
}
