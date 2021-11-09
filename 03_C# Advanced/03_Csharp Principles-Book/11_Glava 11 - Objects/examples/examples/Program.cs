using System;

namespace examples
{
    class Program
    {
        static void Main(string[] args)
        {
            // test for Cat
            Cat firsrCat = new Cat();
            firsrCat.Name = "Tom";
            firsrCat.SayMeow();

            Cat secondCat = new Cat("Pepy", "orange");
            secondCat.SayMeow();
            Console.WriteLine($"Cat {secondCat.Name} is {secondCat.Color} of age {secondCat.Age}");

            Cat thirdCat = new Cat();
            thirdCat.Name = "Rumencho";
            thirdCat.SayMeow();

            Cat fourCat = new Cat();
            fourCat.SayMeow();
            Console.WriteLine($"Cat :{fourCat.Name}: is :{fourCat.Color}: of age :{fourCat.Age}:");


            //test for Sequence
            Console.WriteLine($"Sequence[1..4]: {Sequence.NextValue()} {Sequence.NextValue()} {Sequence.NextValue()} {Sequence.NextValue()}");
            Console.WriteLine($"Sequence[1..4]: {Sequence.NextValue()} {Sequence.NextValue()} {Sequence.NextValue()} {Sequence.NextValue()}");
        }
    }
}
