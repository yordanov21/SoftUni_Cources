using System;
using System.Collections.Generic;
using System.Text;

namespace _02Work
{
    class Student : Human
    {
        private int evaluation;

        public Student(string firstName, string lastName, int evaluation) 
            : base(firstName, lastName)
        {
            this.Evaluation = evaluation;
        }

        public int Evaluation
        {
            get { return evaluation; }
            set { evaluation = value; }
        }

    }
}
