using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Feed_the_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, int> animalList = new Dictionary<string, int>();
            Dictionary<string, List<string>> animalAreaList = new Dictionary<string, List<string>>();

            while (command != "Last Info")
            {
                string[] commandAnimalArr = command
                    .Split(":");

                string commandAnimal = commandAnimalArr[0];
                string animalName = commandAnimalArr[1];
                int food = int.Parse(commandAnimalArr[2]);
                string area = commandAnimalArr[3];

                if (commandAnimal == "Add")
                {
                    if (!animalList.ContainsKey(animalName))
                    {
                        animalList.Add(animalName, 0);
                    }

                    animalList[animalName] += food;

                    if (!animalAreaList.ContainsKey(area))
                    {
                        animalAreaList.Add(area, new List<string>());
                    }

                    if (!animalAreaList[area].Contains(animalName))
                    {
                        animalAreaList[area].Add(animalName);
                    }

                }
                else if (commandAnimal == "Feed")
                {
                    if (animalList.ContainsKey(animalName))
                    {
                        animalList[animalName] -= food;
                        if (animalList[animalName] <= 0)
                        {

                            animalList.Remove(animalName);
                            animalAreaList[area].Remove(animalName);
                            Console.WriteLine($"{animalName} was successfully fed");
                        }
                    }

                }

                command = Console.ReadLine();
            }
            Console.WriteLine("Animals:");
            animalList = animalList
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            animalAreaList = animalAreaList
               .OrderByDescending(x => x.Value.Count)
               .ToDictionary(x => x.Key, x => x.Value);

            foreach (var animal in animalList)
            {
                Console.WriteLine($"{animal.Key} -> {animal.Value}g");
            }

            if (animalAreaList.Any())
            {
                Console.WriteLine("Areas with hungry animals:");
                foreach (var animal in animalAreaList)
                {
                    if (animal.Value.Count > 0)
                    {
                        Console.WriteLine($"{animal.Key} : {animal.Value.Count}");
                    }

                }
            }

        }
    }
}
