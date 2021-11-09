using System;
using System.Collections.Generic;
using System.Text;

namespace examples
{
    class Cat
    {
        private string name;
        private string color;
        private int age;

        public Cat()
        {
        }

        public Cat(string name, string color)
        {
            this.Name = name;
            this.Color = color;
        }

        public Cat(string name, string color, int age)
        {
            this.Name = name;
            this.Color = color;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public void SayMeow()
        {
            Console.WriteLine($"Cat {name} said: Meooow!");
        }
    }
}
