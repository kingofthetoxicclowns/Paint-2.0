using GeometryUtils;
using System.Drawing;

namespace EntitiesLib
{
    public class Circle : IFigure
    {
        public bool IsCircle { get; set; } = true;
        public bool IsSelect { get; set; } = false;
        public bool IsClosed { get; set; } = true;
        public Point2 Center { get; set; }
        public double Radius { get; set; }
        public List<Point2> Points { get; set; } = new List<Point2>();//первая точка - центр, вторая находится на границе окружности

        public Color StrokeColor { get; set; } = Color.Black;

        public int StrokeThickness { get; set; } = 1;

        public Color? FillColor { get; set; }

        public void Create(Point2 startPoint2, Point2 endPoint2, Color color)
        {
            Points.Add(startPoint2);
            Points.Add(endPoint2);
            StrokeColor = color;

            Center = startPoint2;
            Radius = Distance(startPoint2, endPoint2);
        }

        public void Create(Point2 startPoint2, Vector2 vector, Color color)
        {
            Points.Add(startPoint2);
            Points.Add(new Point2(startPoint2.X + vector.X, startPoint2.Y + vector.Y));
            StrokeColor = color;

            Center = startPoint2;
            Radius = Distance(Points[0], Points[1]);
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

        public static double Distance(Point2 a, Point2 b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

    }
}