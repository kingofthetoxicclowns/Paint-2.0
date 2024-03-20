using GeometryUtils;
using System.Drawing;

namespace EntitiesLib
{
    public class Line : IFigure
    {
        public bool IsCircle { get; set; } = false;
        public bool IsSelect { get; set; } = false;
        public bool IsClosed { get; set; } = false;
        public List<Point2> Points { get; set; } = new();
        public Color StrokeColor { get; set; } = Color.Black;
        public int StrokeThickness { get; set; } = 1;
        public Color? FillColor { get; set; }

        public void Create(Point2 startPoint2, Point2 endPoint2, Color color)
        {
            Points.Add(startPoint2);
            Points.Add(endPoint2);
        }

        public void Create(Point2 startPoint2, Vector2 vector, Color color)
        {
            Points.Add(startPoint2);
            Points.Add(new Point2(startPoint2.X + vector.X, startPoint2.Y + vector.Y));
            StrokeColor = color;
        }

        public void Move(Vector2 vector)
        {
            Points.ForEach(p
                => p = new Point2(p.X + vector.X, p.Y + vector.Y));
        }

        public void StrokeColorChange(Color color)
        {
            StrokeColor = color;
        }

        public void Fill(Color color)
        {
            FillColor = color;
        }

        public void StrokeThicknessChange(int thickness)
        {
            StrokeThickness = thickness;
        }
    }
}