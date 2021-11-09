using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;


        public Pilot(string name)
        {
            Name = name;
            this.Machines = new List<IMachine>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                this.name = value;
            }
        }

        public IList<IMachine> Machines { get;  set; }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.Machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {this.Machines.Count} machines");
            //And for each machine:
            foreach (var mashine in Machines)
            {
                sb.AppendLine(mashine.ToString());
                //sb.AppendLine($"- {mashine.Name}");
                //sb.AppendLine($" *Type: {mashine.GetType().Name}");
                //sb.AppendLine($" *Health: {mashine.HealthPoints:f2}");
                //sb.AppendLine($" *Attack: {mashine.AttackPoints:f2}");
                //sb.AppendLine($" *Defense: {mashine.DefensePoints:f2}");
                //sb.AppendLine($" *Targets: {mashine.Targets}");//targets my be in different lay
            }
   
            return sb.ToString().TrimEnd();
        }
    }
}
