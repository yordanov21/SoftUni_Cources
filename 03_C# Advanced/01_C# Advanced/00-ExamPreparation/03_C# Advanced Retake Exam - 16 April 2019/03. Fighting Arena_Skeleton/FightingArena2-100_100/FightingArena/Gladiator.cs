using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
     public class Gladiator
    {
        private string name;
        private Stat stat;
        private Weapon weapon;

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
           this.Name = name;
           this.Stat = stat;
           this.Weapon = weapon;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Stat Stat
        {
            get { return stat; }
            set { stat = value; }
        }

        public Weapon Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }

        // return the sum of the stat properties plus the sum of the weapon properties
        public int GetTotalPower()
        {           
            return GetWeaponPower()+GetStatPower();
        }

        // return the sum of the weapon properties.
        public int GetWeaponPower()
        {
            int power = this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;
            return power;     
        }

        // return the sum of the stat properties.
        public int GetStatPower()
        {
            int power = this.Stat.Agility + this.Stat.Flexibility +
                this.Stat.Intelligence + this.Stat.Skills + this.Stat.Strength;
            return power; 
        }

        public override string ToString()
        {
            StringBuilder sbilder = new StringBuilder();

            sbilder.AppendLine($"[{Name}] - [{GetTotalPower()}]");
            sbilder.AppendLine($" Weapon Power: [{GetWeaponPower()}]");
            sbilder.AppendLine($" Stat Power: [{GetStatPower()}]");
            return sbilder.ToString();
        }
    }
}
