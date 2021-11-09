using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int RifleBulletsPerBarrel = 50;
        private const int RifleTotalBullets = 500;
        private const int BulletsPerFire = 5;
        public Rifle(string name) 
            : base(name, RifleBulletsPerBarrel, RifleTotalBullets)
        {
        }

        public override int Fire()
        {
             if (this.BulletsPerBarrel < BulletsPerFire)
            {
                this.Reload(RifleBulletsPerBarrel);
            }

            int firedBullets = this.DecreaseBullets(BulletsPerFire);

            return firedBullets;   
        }
    }
}
