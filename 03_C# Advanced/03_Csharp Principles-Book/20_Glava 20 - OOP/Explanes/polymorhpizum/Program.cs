using System;

namespace polymorhpizum
{
   public class Program
    {
      public  static void Main(string[] args)
        {
            Animal cat = new Cat();
            cat.PrintInfo();
            Animal dog = new Dog();
            dog.PrintInfo();
        }
    }
}
