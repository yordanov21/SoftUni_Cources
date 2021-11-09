using System;
using System.Collections.Generic;
using System.Text;

namespace _01Inheritance
{
    public class Felidae
    {
        private bool male;
        
        public Felidae() : this(true) { }

        public Felidae(bool male)
        {
            this.male = male;
        }

        public bool Male
        {
            get => this.male;
            set => this.male = value;
        }
    }
}
