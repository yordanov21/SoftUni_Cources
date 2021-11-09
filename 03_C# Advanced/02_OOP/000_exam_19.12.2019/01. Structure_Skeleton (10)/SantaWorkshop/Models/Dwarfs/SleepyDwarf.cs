﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int InitialEnergy = 50;
        public SleepyDwarf(string name) 
            : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
          //TODO  (15 in total)?
            this.Energy -= 15;
            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}
