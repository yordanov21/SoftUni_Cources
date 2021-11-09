namespace FightingArena
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Weapon
    {

        private int size;
        private int solidity;
        private int sharpness;

        public Weapon(int size, int solidity, int sharpness)
        {
            Size = size;
            Solidity = solidity;
            Sharpness = sharpness;
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public int Solidity
        {
            get { return solidity; }
            set { solidity = value; }
        }

        public int Sharpness
        {
            get { return sharpness; }
            set { sharpness = value; }
        }
    }
}
