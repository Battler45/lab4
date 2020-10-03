using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace lab4
{
    public sealed class Edge : Primitive
    {
        public Edge(Point begin, Point end)
        {
            Points = new List<Point>
            {
                begin,
                end
            };
        }
        public Edge(ICollection<Point> points)
        {
            if (points.Count == 0 || points.Count > 2) throw new ArgumentException();
            Points = new List<Point>(points);
        }

        public Point Begin => Points.First();
        public Point End => Points.Last();
        public override Point Centroid => new Point((int)Math.Round((Begin.X + End.X) / 2.0), (int) Math.Round((Begin.Y + End.Y) / 2.0));
        public override List<Point> Points { get;  }
    }
}