﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int InitialEnergy = 100;

        public HappyDwarf(string name)
            : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            this.Energy -= 10;
                if (this.Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}
