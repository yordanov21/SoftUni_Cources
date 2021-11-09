using System;
using System.Collections.Generic;
using System.Text;

namespace _05FootballTeamGenerator
{
    public class Stat
    {
        private string name;
        private int power;

        public Stat(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                name = value;
            }
        }

        public int Power
        {
            get { return power; }
            private set
            {
                if (value <= 0 || value >= 100)
                {
                    throw new Exception($"{this.Name} should be between 0 and 100.");
                }
                power = value;
            }
        }

    }
}
