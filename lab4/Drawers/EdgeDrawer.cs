using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lab4
{
    public class EdgeDrawer : PrimitiveDrawer
    {
        public override void Draw(Graphics graphics, Pen drawingPen, List<Point> primitivePoints, PictureBox pictureBox1)
        {
            if (primitivePoints.Count >= 3) return;
            base.Draw(graphics, drawingPen, primitivePoints, pictureBox1);
        }
    }
}