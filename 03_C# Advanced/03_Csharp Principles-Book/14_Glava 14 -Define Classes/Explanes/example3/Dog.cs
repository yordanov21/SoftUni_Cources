using System;
using System.Collections.Generic;
using System.Text;

namespace example3
{
    public class Dog
    {
        private string name;
        private int age;
        private double length;
        private Collar collar;
        // Nо parameters
        public Dog()
        : this("Sharo") // Constructor call
        {
            // More code could be added here
        }
        // One parameter
        public Dog(string name)
        : this(name, 1) // Constructor call
        {
        }
        // Two parameters
        public Dog(string name, int age)
        : this(name, age, 0.3) // Constructor call
        {
        }
        // Three parameters
        public Dog(string name, int age, double length)
        : this(name, age, length, new Collar(5)) // Constructor call
        {
        }
        // Four parameters
        public Dog(string name, int age, double length, Collar collar)
        {
            this.name = name;
            this.age = age;
            this.length = length;
            this.collar = collar;
        }

      public  static int ReturnFive()
        {
            return 5;
        }
    }
}
