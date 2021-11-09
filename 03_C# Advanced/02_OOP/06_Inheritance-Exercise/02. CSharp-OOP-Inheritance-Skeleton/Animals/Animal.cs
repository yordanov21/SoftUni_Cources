using System;
namespace Animals
{
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Animal: ISoundProducable
    {
        private string name;
        private int age;
        private string gender;
       
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;         
        }

        public string Name 
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0|| string.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }
        public string Gender
        {
            get { return this.gender; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;

            }
        }

        public virtual  string ProduceSound()
        {
           return string.Empty;
        }
   
    
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine($"{this.ProduceSound()}");

            return sb.ToString().TrimEnd();
        }
    }
}
