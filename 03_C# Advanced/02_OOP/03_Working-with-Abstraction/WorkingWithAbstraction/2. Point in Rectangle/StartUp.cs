namespace 2PointInRectangle
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] coordinatsRectangle = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int point1X = coordinatsRectangle[0];
            int point1Y = coordinatsRectangle[1];
            int point2X = coordinatsRectangle[2];
            int point2Y = coordinatsRectangle[3];

            var point1 = new Point(point1X, point1Y);
            var point2 = new Point(point2X, point2Y);

            var rectangle = new Rectangle(point1,point2);

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i<=n; i++)
            {
               var coordinates= Console.ReadLine().Split().Select(int.Parse).ToArray();
                int pointX = coordinates[0];
                int pointY = coordinates[1];
                var point = new Point(pointX, pointY);
                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
