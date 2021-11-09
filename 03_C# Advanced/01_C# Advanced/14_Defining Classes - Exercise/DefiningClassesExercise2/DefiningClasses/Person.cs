namespace DefiningClasses
{
    public class Person
    { 
        private string name;                //field
        private int age;                    //field

        public Person()
        {
            this.Name = "No name";
            this.Age = 1;

        }
        public Person(int number)
        {
            this.Name = "No name";
            this.Age = number;
        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name                   //property
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age                     //property
        {
            get { return this.age; }
            set { this.age = value; }
        }
    }
}
