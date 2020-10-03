using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        private Graphics _canvasGraphics;
        private readonly Pen _drawingPen = Pens.Red;
        private Primitive _primitive;
        private List<Point> _primitivePoints;
        private IPrimitiveDrawer _primitiveDrawer;


        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;

            _canvas.Image = new Bitmap(_canvas.Width, _canvas.Height);
            _canvasGraphics = Graphics.FromImage(_canvas.Image);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (_primitivePoints != null)
            {
                _primitivePoints.Add(e.Location);
                _primitiveDrawer.Draw(_canvasGraphics, _drawingPen, _primitivePoints, _canvas);
            }

            var pointLocationFinder = PointLocationFinder.GetInstance();
            var pointPositionMessage = _primitive switch
            {
                Polygon polygon when (button9.Focused || button10.Focused)
                    => pointLocationFinder.GetPointPosition(polygon, e.Location).ToString(),
                Edge edge when button11.Focused
                    => pointLocationFinder.GetPointDirection(edge, e.Location).ToString(),
                _ => null
            };
            if (!string.IsNullOrWhiteSpace(pointPositionMessage))
                MessageBox.Show(pointPositionMessage);
        }

        private void primitiveDrawingButton_Click(object sender, EventArgs e)
        {
            var drawingButton = (Button)sender;
            var (drawingButtonText, newPrimitive, newPrimitiveDrawer) = GetPrimitiveContext(drawingButton, _primitivePoints);
            if (_primitivePoints != null)
            {
                drawingButton.Text = drawingButtonText;
                _primitive = newPrimitive;
                _primitivePoints = null;
                _primitiveDrawer.Draw(_canvasGraphics, _drawingPen, _primitive, _canvas);
                return;
            }

            _primitiveDrawer = newPrimitiveDrawer;
            _primitiveDrawer.ClearCanvas(_canvasGraphics, _canvas);
            drawingButton.Text = "Рисование";
            _primitive = null;
            _primitivePoints = new List<Point>();

            ///this is peace of shit code
            (string, Primitive, IPrimitiveDrawer) GetPrimitiveContext(Button drawingButton, List<Point> primitivePoints)
            {
                string drawingButtonText = null;
                Primitive newPrimitive = null;
                IPrimitiveDrawer newPrimitiveDrawer = null;
                if (drawingButton == polygonDrawingButton)
                {
                    if (primitivePoints != null)
                    {
                        drawingButtonText = "Многоугольник";
                        newPrimitive = new Polygon(primitivePoints);
                    }
                    else
                    {
                        newPrimitiveDrawer = new PolygonDrawer();
                    }
                }
                else if (drawingButton == edgeDrawingButton)
                {
                    if (primitivePoints != null)
                    {
                        drawingButtonText = "Ребро";
                        newPrimitive = new Edge(primitivePoints);
                    }
                    else
                    {
                        newPrimitiveDrawer = new EdgeDrawer();
                    }
                }
                else
                {
                    throw new ArgumentException();
                }

                return (drawingButtonText, newPrimitive, newPrimitiveDrawer);
            }
            ///this is peace of shit code
            (string, Primitive, IPrimitiveDrawer) GetPrimitiveContext2(Button drawingButton, List<Point> primitivePoints)
            {
                if (drawingButton != edgeDrawingButton && drawingButton != polygonDrawingButton) throw new ArgumentException();
                var (drawingButtonText, newPrimitive, newPrimitiveDrawer) = primitivePoints != null
                    ? drawingButton == polygonDrawingButton
                        ? ("Многоугольник", new Polygon(primitivePoints), (IPrimitiveDrawer)null)
                        : ("Ребро", (Primitive)new Edge(primitivePoints), (IPrimitiveDrawer)null)
                    : drawingButton == polygonDrawingButton
                        ? ((string)null, (Primitive)null, (IPrimitiveDrawer)new PolygonDrawer())
                        : ((string)null, (Primitive)null, new EdgeDrawer());
                return (drawingButtonText, newPrimitive, newPrimitiveDrawer);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            _canvas.Image = new Bitmap(_canvas.Width, _canvas.Height);
            _canvasGraphics = Graphics.FromImage(_canvas.Image);
        }
        private void offsetButton_Click(object sender, EventArgs e)
        {
            if (_primitive == null) return;
            if (!int.TryParse(offsetXTextBox.Text, out var dX) || !int.TryParse(offsetYTextBox.Text, out var dY)) return;
            _primitive.Offset(dX, dY);
            _primitiveDrawer.Draw(_canvasGraphics, _drawingPen, _primitive, _canvas);
        }
        private void primitiveRotationButton_Click(object sender, EventArgs e)
        {
            if (_primitive == null) return;
            if (!double.TryParse(rotationAngleInDegreesTextBox.Text, out var angle)) return;
            angle = angle * Math.PI / 180;
            _primitive = Transformer.GetInstance().Transform(_primitive, Transformer.GetRotationMatrix(_primitive.Centroid, angle));
            _primitiveDrawer.Draw(_canvasGraphics, _drawingPen, _primitive, _canvas);
        }
        private void scalingButton_Click(object sender, EventArgs e)
        {
            if (_primitive == null) return;
            if (!double.TryParse(scaleTextBox.Text, out var scalePercentage)) return;
            scalePercentage /= 100;
            _primitive = Transformer.GetInstance().Transform(_primitive, Transformer.GetScaleMatrix(_primitive.Centroid, (float)scalePercentage));
            _primitiveDrawer.Draw(_canvasGraphics, _drawingPen, _primitive, _canvas);
        }

        private void rotationAroundPointButton_Click(object sender, EventArgs e)
        {
            if (_primitive == null) return;
            if (!double.TryParse(rotationAroundPointAngleDegrees.Text, out var angle)) return;
            var originStr = rotationAroundPointOrigin.Text.Split(',', ' ');
            if (originStr.Length != 2) return;
            if (!int.TryParse(originStr[0], out var originX)) return;
            if (!int.TryParse(originStr[0], out var originY)) return;
            var origin = new Point(originX, originY);
            angle = angle * Math.PI / 180;
            _primitive = Transformer.GetInstance().Transform(_primitive, Transformer.GetRotationMatrix(origin, angle));
            _primitiveDrawer.Draw(_canvasGraphics, _drawingPen, _primitive, _canvas);
        }
    }
}
