namespace FightingArena
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    

    public class Stat
    {
        private int strength;
        private int flexibility;
        private int agility;
        private int skills;
        private int intelligence;

        public Stat(int strength, int flexibility, int agility, int skills, int intelligence)
        {
            Strength = strength;
            Flexibility = flexibility;
            Agility = agility;
            Skills = skills;
            Intelligence = intelligence;
        }

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public int Flexibility 
        {
            get { return flexibility; }
            set { flexibility = value; }
        }

        public int Agility
        {
            get { return agility; }
            set { agility = value; }
        }

        public int Skills
        {
            get { return skills; }
            set { skills = value; }
        }

        public int Intelligence
        {
            get { return intelligence; }
            set { intelligence = value; }
        }
    }
}
