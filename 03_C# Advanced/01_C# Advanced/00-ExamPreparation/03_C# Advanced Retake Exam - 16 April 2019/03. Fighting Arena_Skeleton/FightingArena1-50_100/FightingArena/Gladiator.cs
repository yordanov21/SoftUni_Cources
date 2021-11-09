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
            Name = name;
            Stat = stat;
            Weapon = weapon;
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
        public int GetTotalPower()
        {
            return 0;//todo       
        }
        public int GetWeaponPower()
        {
            return 0;//todo       
        }
        public int GetStatPower()
        {
            return 0;//todo       
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
