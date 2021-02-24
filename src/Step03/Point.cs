using System;

namespace Step03
{
    public struct Point
    //public class Point
    {
        private readonly double _x;
        private readonly double _y;

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public static Point operator +(Point a, Point b)
            => new Point(a._x + b._x, a._y + b._y);

        public override string ToString()
            => $"({_x},{_y})";

        
    }
}