using System;
using System.Collections.Generic;
using System.Text;

namespace polymorhpizum
{
    public abstract class Animal
    {
        public void PrintInfo()
        {
            Console.WriteLine($"I am {this.GetType().Name}.");
            Console.WriteLine(GetTypicalSound());
        }
        protected abstract String GetTypicalSound();
    }
}
