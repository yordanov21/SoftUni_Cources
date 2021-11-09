namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Room
    {
        public Room()
        {
            this.Patients = new List<Patient>();
        }
        public bool IsFull => this.Patients.Count >= 3;
        public List<Patient> Patients { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var parient in this.Patients.OrderBy(x => x.Name))
            {
                sb.AppendLine(parient.Name);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
