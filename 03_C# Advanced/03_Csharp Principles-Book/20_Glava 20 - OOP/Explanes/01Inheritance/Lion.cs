using System;
using System.Collections.Generic;
using System.Text;

namespace _01Inheritance
{
    public class Lion : Felidae, Reproducible<Lion>
    {
        private int weight;

        public Lion(bool male, int weight)
            : base(male)
        {          
            this.weight = weight;
        }

        public int Weight
        {
            get => this.weight;
            set => this.weight = value;
        }

        public Lion[] Reprodice(Lion mate)
        {
            return new Lion[] { new Lion(true, 12), new Lion(false, 10) };
        }
    }
}
