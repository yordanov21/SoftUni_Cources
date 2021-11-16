namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        private List<IWeapon> weapons;

        public Inventory()
        {
            this.weapons = new List<IWeapon>();
        }
        public int Capacity => this.weapons.Count;

        // O(1) amortized
        public void Add(IWeapon weapon)
        {
            weapons.Add(weapon);
           // weapsDictionary.Add(weapon.Id, weapon);
        }

        public void Clear()
        {
            weapons.Clear();
        }

        // O(n)
        public bool Contains(IWeapon weapon)
        {
            return weapons.Contains(weapon);
        }

        // O(n)
        public void EmptyArsenal(Category category)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                if(weapons[i].Category == category)
                {
                    weapons[i].Ammunition = 0;
                }
            }
        }

        // O(n)
        public bool Fire(IWeapon weapon, int ammunition)
        {
            if (!weapons.Contains(weapon))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

           
            int ammoAfterFire = weapon.Ammunition - ammunition;

            if (ammoAfterFire < 0)
            {
                return false;
            }

            weapon.Ammunition -= ammunition;

            return true;

            // second way
            // var idx = weapons.IndexOf(weapon);
            //if (weapons[idx].Ammunition >= ammunition)
            //{
            //    weapons[idx].Ammunition -= ammunition;
            //    return true;
            //}

            //return false;
        }

        // O(n)
        public IWeapon GetById(int id)
        {
            //if(!weapsDictionary.ContainsKey(id))
            //{
            //    return null;
            //}

            //return weapsDictionary[id];


            for (int i = 0; i < this.Capacity; i++)
            {
                var current = this.weapons[i];

                if (this.weapons[i].Id == id)
                {
                    return current;
                }
            }

            return null;
        }

        public IEnumerator GetEnumerator()
        {
            return weapons.GetEnumerator();
        }

        // O(n)
        public int Refill(IWeapon weapon, int ammunition)
        {
            if (!weapons.Contains(weapon))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            var idx = weapons.IndexOf(weapon);

            if ((weapons[idx].Ammunition + ammunition)<= weapons[idx].MaxCapacity)
            {
                weapons[idx].Ammunition += ammunition;
                return weapons[idx].Ammunition;
            }

            return weapons[idx].Ammunition = weapons[idx].MaxCapacity;
        }

        public IWeapon RemoveById(int id)
        {
            //if(!weapsDictionary.ContainsKey(id))
            //{
            //    throw new InvalidOperationException("Weapon does not exist in inventory!");
            //}

            //var result = weapons[id];
            //weapsDictionary.Remove(id);
            //weapons.RemoveAt(id);

            //return result;

            IWeapon searched = null;

            for (int i = 0; i < this.Capacity; i++)
            {
                if (this.weapons[i].Id == id)
                {
                    searched = this.weapons[i];
                    this.weapons.RemoveAt(i);
                    break;
                }
            }

            if (searched == null)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            return searched;
        }

        public int RemoveHeavy()
        {
            return this.weapons.RemoveAll(w => w.Category == Category.Heavy);   
        }

        public List<IWeapon> RetrieveAll()
        {
            if(weapons.Count == 0)
            {
                return null;
            }
      
            return new List<IWeapon>(weapons);
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            List<IWeapon> inBounds = new List<IWeapon>();

            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].Category >= lower && weapons[i].Category <= upper)
                {
                    inBounds.Add(weapons[i]);
                }
            }

            return inBounds;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            int firstEntityIndex = weapons.IndexOf(firstWeapon);
            int secondEntityIndex = weapons.IndexOf(secondWeapon);
            CheckValidIndex(firstEntityIndex, "Weapon does not exist in inventory!");
            CheckValidIndex(secondEntityIndex, "Weapon does not exist in inventory!");

            // swap the entities if the weapons are in the same category
            if (firstWeapon.Category == secondWeapon.Category)
            {
                weapons[firstEntityIndex] = secondWeapon;
                weapons[secondEntityIndex] = firstWeapon;
            }
           
        }

        private void CheckValidIndex(int index, string message)
        {
            if (index < 0)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
