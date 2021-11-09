using System;
using System.Collections.Generic;
using System.Text;

namespace _02Work
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName) 
            : base(firstName, lastName)
        {
        }

        private int pay;

        public int Pay
        {
            get { return pay; }
            set { pay = value; }
        }

    }
}
