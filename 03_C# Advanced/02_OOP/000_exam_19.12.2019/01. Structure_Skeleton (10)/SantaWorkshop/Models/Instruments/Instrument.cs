using SantaWorkshop.Models.Instruments.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.power = value;
            }
        }

        public bool IsBroken()
        {
       
            if (this.power > 0)
            {
                return false;
            }
            else
            {             
                return true;
            }

        }

        public void Use()
        {
            this.power -= 10;
          
            if (this.power<0)
            {
                this.power = 0;              
            }
        }
    }
}
