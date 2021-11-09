using System;
using System.Collections.Generic;
using System.Text;

namespace example7Generics
{
    public class AnimalShelter<T>
    {
        private const int DefaultPlacesCount = 20;
        private T[] animalList;
        private int usedPlaces;
        public AnimalShelter() : this(DefaultPlacesCount)
        {
        }
        public AnimalShelter(int placesCount)
        {
            this.animalList = new T[placesCount];
            this.usedPlaces = 0;
        }
        public void Shelter(T newAnimal)
        {
            if (this.usedPlaces >= this.animalList.Length)
            {
                throw new InvalidOperationException("Shelter is full.");
            }
            this.animalList[this.usedPlaces] = newAnimal;
            this.usedPlaces++;
        }
        public T Release(int index)
        {
            if (index < 0 || index >= this.usedPlaces)
            {
                throw new ArgumentOutOfRangeException(
                "Invalid cell index: " + index);
            }
            T releasedAnimal = this.animalList[index];
            for (int i = index; i < this.usedPlaces - 1; i++)
            {
                this.animalList[i] = this.animalList[i + 1];
            }
            this.animalList[this.usedPlaces - 1] = default;
            this.usedPlaces--;
            return releasedAnimal;
        }
    }
}
