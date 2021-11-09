namespace _07CreatingAndUsingObjrcts.NewFolder
{
    using System;
    public class Cat
    {
        private string name;
        public Cat()
        {
        }

        public Cat(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public void SayMeow()
        {
            Console.WriteLine($"Cat {this.Name} say: meoooow!");
        }
    }
}
