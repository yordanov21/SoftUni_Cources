using System;
using System.Collections.Generic;
using System.Linq;

namespace _06BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIndentifiable> all = new List<IIndentifiable>();
            List<IBirtday> allBirtdays = new List<IBirtday>();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                var tokens = command.Split();
                if (tokens[0]=="Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string bDate = tokens[4];
                    allBirtdays.Add(new Citizen(name, age, id,bDate));
                }
                else if (tokens[0] == "Pet")
                {
                    string name = tokens[1];
                    string bDate = tokens[2];
                    allBirtdays.Add(new Pet(name, bDate));
                }
            }

            var year = Console.ReadLine();

            allBirtdays.Where(c => c.Date.EndsWith(year))
                .Select(c => c.Date)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
    
}
