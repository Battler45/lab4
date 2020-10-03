using System;
using System.Drawing;
using System.Linq;

namespace lab4
{
    public class PointLocationFinder
    {
        public enum PointPosition
        {
            // ReSharper disable once UnusedMember.Global
            Outside,
            // ReSharper disable once UnusedMember.Global
            Inside
        }
        public static PointLocationFinder GetInstance() => new PointLocationFinder();
        public PointPosition GetPointPosition(Polygon polygon, Point point)
        {
            var polygonMaxX = polygon.Points.Max(p => p.X);
            var pointRay = (new Point(point.X, point.Y), new Point(polygonMaxX, point.Y)); // canvas.Width instead polygonMaxX
            var prev = polygon.Points.First();

            var count = 0;
            if (IsIntersect(pointRay, (prev, polygon.Points.Last()))) ++count;
            foreach (var item in polygon.Points.Skip(1))
            {
                if (IsIntersect(pointRay, (prev, item))) ++count;
                prev = item;
            }

            return (PointPosition)(count % 2);
        }

        private static bool IsIntersect((Point, Point) s1, (Point, Point) s2)
        {
            Point a = s1.Item1,
                b = s1.Item2,
                c = s2.Item1,
                d = s2.Item2;

            var m = new Line(a, b);
            var n = new Line(c, d);
            var zn = Det(m.A, m.B, n.A, n.B);

            var leftx = -1 * Det(m.C, m.B, n.C, n.B) / zn;
            var lefty = -1 * Det(m.A, m.C, n.A, n.C) / zn;

            var inter = Between(a.X, b.X, leftx)
                        && Between(a.Y, b.Y, lefty)
                        && Between(c.X, d.X, leftx)
                        && Between(c.Y, d.Y, lefty);

            return inter;
        }

        private static bool Between(double l, double r, double x) => Math.Min(l, r) <= x + 0.1e-5 && x <= Math.Max(l, r) + 0.1e-5;
        private static double Det(double a, double b, double c, double d) => a * d - b * c;
        public enum PointDirection
        {
            Left, Right
        }

        public PointDirection GetPointDirection(Edge polygon, Point point)
        {
            int x0 = polygon.Points[1].X, y0 = polygon.Points[1].Y;
            int xEdge = polygon.Points[0].X - x0, yEdge = polygon.Points[0].Y - y0;
            int xPoint = point.X - x0, yPoint = point.Y - y0;
            return (yPoint * xEdge - xPoint * yEdge) < 0 ? PointDirection.Right : PointDirection.Left;
        }
    }
}