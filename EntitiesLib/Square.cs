using GeometryUtils;
using System.Drawing;

namespace EntitiesLib
{
    public class Square : IFigure
    {
        public bool IsCircle { get; set; } = false;
        public bool IsSelect { get; set; } = false;
        public bool IsClosed { get; set; } = true;
        public List<Point2> Points { get; set; } = new();
        public Color StrokeColor { get; set; } = Color.Black;
        public int StrokeThickness { get; set; } = 1;
        public Color? FillColor { get; set; }

        public void Create(Point2 startPoint2, Point2 endPoint2, Color color)
        {
            Points.Add(startPoint2);
            Points.Add(new Point2(endPoint2.X, startPoint2.Y));
            Points.Add(endPoint2);
            Points.Add(new Point2(startPoint2.X, endPoint2.Y));
            StrokeColor = color;
        }

        public void Create(Point2 startPoint2, Vector2 vector, Color color)
        {
            Points.Add(startPoint2);
            Points.Add(new Point2(startPoint2.X + vector.X, startPoint2.Y));
            Points.Add(new Point2(
                startPoint2.X + vector.X,
                startPoint2.Y + vector.Y));
            Points.Add(new Point2(startPoint2.X, startPoint2.Y + vector.Y));
            StrokeColor = color;
        }

        public void StrokeColorChange(Color color)
        {
            StrokeColor = color;
        }

        public void Fill(Color color)
        {
            FillColor = color;
        }
        public void Move(Vector2 vector)
        {
            for (int i = 0; i < Points.Count(); i++)
            {
                Points[i].X += vector.X;
                Points[i].Y += vector.Y;
            }
        }

        public void StrokeThicknessChange(int thickness)
        {
            StrokeThickness = thickness;
        }
    }
}
