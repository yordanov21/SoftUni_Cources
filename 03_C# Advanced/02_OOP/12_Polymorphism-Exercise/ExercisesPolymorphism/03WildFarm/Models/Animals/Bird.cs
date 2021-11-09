﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03WildFarm.Models.Animals
{ 
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight,double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }


        public double WingSize
        {
            get { return wingSize; }
            set { wingSize = value; }
        }

    }
}
