using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lab4
{
    public abstract class PrimitiveDrawer : IPrimitiveDrawer
    {
        public virtual void Draw(Graphics graphics, Pen drawingPen, List<Point> primitivePoints, PictureBox pictureBox)
        {
            if (primitivePoints.Count <= 1) return;
            graphics.DrawLines(drawingPen, primitivePoints.ToArray());
            pictureBox.Refresh();
        }
        public void Draw(Graphics canvasGraphics, Pen drawingPen, Primitive polygon, PictureBox canvas)
        {
            canvasGraphics.Clear(Color.Empty);

            canvasGraphics.DrawLines(drawingPen, polygon.Points.ToArray());
            if (polygon is Polygon)
            {
                canvasGraphics.DrawLine(drawingPen, polygon.Points.Last(), polygon.Points.First());
            }

            canvas.Refresh();
        }

        public void ClearCanvas(Graphics canvasGraphics, PictureBox canvas)
        {
            canvasGraphics.Clear(Color.Empty);
            canvas.Refresh();
        }
    }
}