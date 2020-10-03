using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lab4
{
    public interface IPrimitiveDrawer
    {
        void Draw(Graphics graphics, Pen drawingPen, List<Point> primitivePoints, PictureBox pictureBox);
        void Draw(Graphics canvasGraphics, Pen drawingPen, Primitive polygon, PictureBox canvas);
        void ClearCanvas(Graphics canvasGraphics, PictureBox canvas);
    }
}