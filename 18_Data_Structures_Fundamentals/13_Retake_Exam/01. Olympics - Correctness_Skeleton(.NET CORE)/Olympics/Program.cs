using System;
using System.Data.Common;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var olympics = new Olympics();
      //  olympics.AddCompetitor(1, "Ani");
      //  olympics.AddCompetitor(2, "Ivan");
      //  olympics.AddCompetitor(3, "Galin");
      //  olympics.AddCompetitor(4, "Kali");

      //  //Act
      ////  int expectedCount = 4;
      //  int actualCount = olympics.CompetitorsCount();
      //  Console.WriteLine(actualCount);


        olympics.AddCompetition(1, "SoftUniada", 500);
        olympics.AddCompetition(2, "Java", 600);

        olympics.AddCompetitor(5, "Ani");
        olympics.Compete(5, 1);
        olympics.Compete(5, 2);

        olympics.AddCompetitor(1, "Ivan");
        olympics.Compete(1, 1);

        olympics.AddCompetitor(2, "Stamat");
        olympics.Compete(2, 1);
        olympics.Compete(2, 2);

        int expectedCount = 2;
        int actualCount2 = olympics.FindCompetitorsInRange(500, 1100).Count();
        Console.WriteLine(actualCount2);
    }
}
