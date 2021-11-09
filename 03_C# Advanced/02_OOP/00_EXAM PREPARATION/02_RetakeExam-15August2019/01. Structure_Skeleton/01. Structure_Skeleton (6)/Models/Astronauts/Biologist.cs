﻿using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut, IAstronaut
    {
        private const double BiologistOxigen= 70;
        public Biologist(string name) 
            : base(name, BiologistOxigen)
        {
        }

        public override void Breath()
        {
            this.Oxygen -= 5;
            if (this.Oxygen < 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
