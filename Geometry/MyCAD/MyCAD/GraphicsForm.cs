using System.Drawing;
using System.Collections.Generic;
namespace MyCAD
{
    public partial class GraphicsForm : Form
    {
        public GraphicsForm()
        {
            InitializeComponent();
        }
        private List<Entities.Point> points = new List<Entities.Point>();
        private Vector3 currentPosition;
        private int DrawIndex = -1;
        private bool active_drawing = false;

        private void drawing_MouseMove(object sender, MouseEventArgs e)
        {
            currentPosition = PointToCartesian(e.Location);
            label1.Text = string.Format("{0}, {1}", e.Location.X, e.Location.Y);
            label2.Text = string.Format("{0,0:F3}, {1,0:F3}", currentPosition.X, currentPosition.Y);
        }
        // Get screen dpi
        private float DPI
        {
            get
            {
                using (var g = CreateGraphics())
                    return g.DpiX;
            }
        }
        private Vector3 PointToCartesian(Point point)
        {
            return new Vector3(Pixel_to_Mn(point.X), Pixel_to_Mn(drawing.Height - point.Y));
        }

        private float Pixel_to_Mn(float pixel)
        {
            return pixel * 25.4f / DPI;
        }

        private void drawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (active_drawing)
                {
                    switch (DrawIndex)
                    {
                        case 0: // point
                            points.Add(new Entities.Point(currentPosition));
                            break;

                    }
                    drawing.Refresh();
                    UpdateDrawing();
                }
            }
        }

        private void UpdateDrawing()
        {
            // Создаем новый объект PaintEventArgs
            PaintEventArgs e = new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle);

            // Вызываем событие Paint напрямую
            drawing_Paint(this, e);
        }

        private void drawing_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParameters(Pixel_to_Mn(drawing.Height));
            if (points.Count > 0)
            {
                foreach (Entities.Point p in points)
                {
                    e.Graphics.DrawPoint(new Pen(Color.Red, 1), p);////////был 0 в видосе 1 в комментах
                }
            }
        }

        private void pointBtn_Click(object sender, EventArgs e)
        {
            DrawIndex = 0;
            active_drawing = true;
            drawing.Cursor = Cursors.Cross;
        }

        private void drawing_Click(object sender, EventArgs e)
        {

        }
    }
}
