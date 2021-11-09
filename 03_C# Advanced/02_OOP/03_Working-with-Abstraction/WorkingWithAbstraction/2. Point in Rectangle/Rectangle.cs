namespace 2PointInRectangle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rectangle
    {

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeftCoordinates = topLeft;
            this.BottomRightCoordinates = bottomRight;
        }

        public Point TopLeftCoordinates { get; set; }

        public Point BottomRightCoordinates { get; set; }

        public bool Contains(Point point)
        {
            bool isXtop = point.X >= TopLeftCoordinates.X;
            bool isXbottom = point.X <= BottomRightCoordinates.X;
            bool isYtop = point.Y >= TopLeftCoordinates.Y;
            bool isYbottom = point.Y <= BottomRightCoordinates.Y;

            return isXtop && isXbottom && isYtop && isYbottom;
        }
    }
}
