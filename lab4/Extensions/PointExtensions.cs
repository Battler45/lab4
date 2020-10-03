using System.Drawing;

namespace lab4
{
    public static class PointExtensions
    {
        public static Point GetOffset(this Point point, int dx, int dy)
        {
            var pointCopy = point;
            pointCopy.Offset(dx, dy);
            return pointCopy;
        }
        public static Point GetOffset(this Point point, Point dPoint)
        {
            return point.GetOffset(dPoint.X, dPoint.Y);
        }
    }
}