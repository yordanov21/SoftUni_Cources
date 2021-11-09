using System;
using System.Collections.Generic;
using System.Linq;

namespace _05BorderControl
{
    public class Program
    {
        static void Main()
        {
            List<IIndentifiable> all = new List<IIndentifiable>();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                var tokens = command.Split();
                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    all.Add(new Citizen(name, age, id));
                }
                else if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string id = tokens[1];
                    all.Add(new Robot(model, id));
                }           
            }

            var lastDigits = Console.ReadLine();

            all.Where(c => c.Id.EndsWith(lastDigits))
                .Select(c => c.Id)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
