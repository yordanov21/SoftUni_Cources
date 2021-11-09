using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {
        }

       public override string ExplaineSelf()
        {
            return base.ExplaineSelf()+ Environment.NewLine+"MEEOW";
        }
    }
}
