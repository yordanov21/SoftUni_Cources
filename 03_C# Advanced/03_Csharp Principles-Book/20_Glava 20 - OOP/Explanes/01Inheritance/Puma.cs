using System;
using System.Collections.Generic;
using System.Text;

namespace _01Inheritance
{
    public class Puma : Felidae
    {
        private int weight;
      
       public Puma(bool male, int weight ) : base(male)
        {
            this.weight = weight;
          
        }
        public int Weight
        {
            get => this.weight;
            set => this.weight = value;
        } 

      
    }
}
