namespace Example1
{
    using System;

    public class Dog
    {
        private string name;
        public Dog()
        {
        }
        public Dog(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void Bark()
        {
            Console.WriteLine("{0} said: wow-wow!", name?? "[unnamed dog]");
        }

    }
}
