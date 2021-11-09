using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AquariumAdventure
{
    public class Aquarium
    {
        private string name;
        private int capacity;
        private int size;

        private List<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;

            this.fishInPool = new List<Fish>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }


        public void Add(Fish fish)
        {

            if (Capacity > 0)
            {
                Fish CurrentFish = fishInPool.FirstOrDefault(x => x.Name == fish.Name);

                if (CurrentFish == null)
                {
                    fishInPool.Add(fish);
                    Capacity--;
                }
            }
        }

        public bool Remove(string name)
        {
            Fish currentFish = fishInPool.FirstOrDefault(x => x.Name == name);

            if (currentFish != null)
            {
                fishInPool.Remove(currentFish);
                Capacity++;
                return true;
            }

            return false;
        }
        public Fish FindFish(string name)
        {
            return fishInPool.FirstOrDefault(x => x.Name == name);
        }
        public string Report()
        {
            var aquarium = new StringBuilder();

            aquarium.AppendLine($"Aquarium: {Name} ^ Size: {Size}");

            foreach (var currentFish in fishInPool)
            {
                aquarium.AppendLine(currentFish.ToString());
            }

            return aquarium.ToString().Trim(); // Trim - маха всичко празно!
        }
    }
}
