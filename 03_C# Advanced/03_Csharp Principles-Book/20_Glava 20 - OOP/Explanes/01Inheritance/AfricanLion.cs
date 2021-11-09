using System;
using System.Collections.Generic;
using System.Text;

namespace _01Inheritance
{
    public class AfricanLion : Lion
    {
        public AfricanLion(bool male, int weight) 
           : base(male, weight)
        {
        }

        public override string ToString()
        {
            return $"(AfricanLion, male: {this.Male}, weight: {this.Weight})"; 
        }
    }
}
