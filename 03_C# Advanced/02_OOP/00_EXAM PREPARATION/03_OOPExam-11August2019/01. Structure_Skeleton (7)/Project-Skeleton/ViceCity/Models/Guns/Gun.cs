﻿using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
                }

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => this.bulletsPerBarrel;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }

                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => this.totalBullets;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }

                this.totalBullets = value;
            }
        }

        public bool CanFire
           => this.bulletsPerBarrel > 0 || this.totalBullets > 0;

        public abstract int Fire();

        protected void Reload(int barrelCapacity)
        {
            if (this.TotalBullets >= barrelCapacity)
            {
                this.BulletsPerBarrel = barrelCapacity;
                this.TotalBullets -= barrelCapacity;
            }

        }

        protected int DecreaseBullets(int bullets)
        {
            int firedBullets = 0;
            if (this.BulletsPerBarrel - bullets >= 0)
            {
                this.BulletsPerBarrel -= bullets;
                firedBullets = bullets;
            }

            return firedBullets;
        }

    }
}
