using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace lab4
{
    public abstract class Primitive
    {
        public abstract Point Centroid { get; }
        public abstract List<Point> Points { get; } 
        public void SetCentroid(Point newCentroid)
        {
            #if DEBUG
            if (this is Polygon polygon)
            {
                Console.Write($@"old area: {polygon.Area}");
            }
            #endif

            var currentCentroid = Centroid;
            while (newCentroid != currentCentroid)
            {
                var dCentroid = new Point(newCentroid.X - currentCentroid.X, newCentroid.Y - currentCentroid.Y);
                Offset(dCentroid);
                currentCentroid = Centroid;
            }

            #if DEBUG
            if (this is Polygon polygon1)
            {
                Console.WriteLine($@" new area : {polygon1.Area}");
            }
            Console.WriteLine($@"{nameof(newCentroid)}: {newCentroid}, new {nameof(Centroid)}: {Centroid}");
            #endif
        }

        public void Offset(int dx, int dy)
        {
            for (var i = 0; i < Points.Count; i++)
            {
                Points[i] = Points[i].GetOffset(dx, dy);
            }
        }

        public void Offset(Point dPoint) => Offset(dPoint.X, dPoint.Y);
        public Polygon GetOffset(int dx, int dy)
        {
            var polygonOffset = new Polygon(new List<Point>(Points));
            polygonOffset.Offset(dx, dy);
            return polygonOffset;
        }
    }
}