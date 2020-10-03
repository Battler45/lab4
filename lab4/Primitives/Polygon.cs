using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace lab4
{
    public class Polygon : Primitive
    {
        public Polygon(IEnumerable<Point> polygonPoints) => Points = new List<Point>(polygonPoints);
        public override List<Point> Points { get; }

        public override Point Centroid
        {
            get
            {
                var area = Area;
                var cX = Lines.Sum(line => (line.Begin.X + line.End.X) * (line.Begin.X * line.End.Y - line.End.X * line.Begin.Y) / (area * 6));
                var cY = Lines.Sum(line => (line.Begin.Y + line.End.Y) * (line.Begin.X * line.End.Y - line.End.X * line.Begin.Y) / (area * 6));
                return new Point((int)cX, (int)cY);
            }
        }

        private double? _area;

        public double Area
        {
            get
            {
                var area = Lines.Sum(line => line.Begin.X * line.End.Y - line.End.X * line.Begin.Y) / 2.0;
                return area;
            }
        }
        private IEnumerable<Edge> Lines
        {
            get
            {
                for (var i = 0; i < Points.Count - 1; i++)
                {
                    yield return new Edge(Points[i], Points[i + 1]);
                }
                yield return new Edge(Points.Last(), Points.First());
            }
        }
    }
}