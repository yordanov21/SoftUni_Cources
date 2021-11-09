namespace _07CreatingAndUsingObjrcts.NewFolder
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 11; i++)
            {
                Cat cat = new Cat();
                cat.Name=$"Tommy{i}";
              cat.SayMeow();
            }
        }
    }
}
