namespace DefiningClasses
{
    public class Person
    { 
        private string name;                //field
        private int age;                    //field

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
