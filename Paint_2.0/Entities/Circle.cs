using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Paint_2._0.Entities
{
    public class Circle : IFigure
    {
        public bool IsCircle { get; set; } = true;
        public PointF Center { get; set; }

        public double Radius { get; set; }
        public List<PointF> Points { get; set; } //первая точка - центр, вторая находится на границе окружности

        public Color StrokeColor { get; set; } = Color.Black;

        public int StrokeThickness { get; set; } = 1;

        public Color? FillColor { get; set; }

        public void Create(PointF startPointF, PointF endPointF, Color color)
        {
            Points.Add(startPointF);
            Points.Add(endPointF);
            StrokeColor = color;

            Center = startPointF;
            Radius = Distance(startPointF, endPointF);
        }

        public void Create(PointF startPointF, Vector2 vector, Color color)
        {
            Points.Add(startPointF);
            Points.Add(new PointF(startPointF.X + vector.X, startPointF.Y + vector.Y));
            StrokeColor = color;

            Center = startPointF;
            Radius = Distance(Points[0], Points[1]);
        }

        public void Move(Vector2 vector)
        {
            Points.ForEach(p
                => p = new PointF(p.X + vector.X, p.Y + vector.Y));
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

        public static double Distance(PointF a, PointF b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

    }
}