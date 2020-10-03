using System;
using System.Drawing;

namespace lab4
{
    internal struct Line
    {
        private const double Eps = 0.1e-5;
        //ay + bx + c = 0
        //y = -(bx + c) / a
        //x = -(ay+c) / b
        public double A, B, C;
        public Line(Point p, Point q)
        {
            A = p.Y - q.Y;	///y
            B = q.X - p.X;		///x
            C = -1 * A * p.X - B * p.Y;  ///c

            var z = Math.Sqrt(A * A + B * B);
            if (!(Math.Abs(z) > Eps)) return;
            A /= z; B /= z; C /= z;
        }
    };
}