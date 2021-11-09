using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
     public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;
       // private  ICollection<IInstrument> instruments;

        protected Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.Instruments= new List<IInstrument>();
        }

        public string Name 
        {
            get => this.name;
          protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }

        public int Energy 
        {
            get => this.energy;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.energy = value;
            }
        }

        public ICollection<IInstrument> Instruments { get; }
           

        public void AddInstrument(IInstrument instrument)
        {
            Instruments.Add(instrument);
        }

        public abstract void Work();
       
    }
}
