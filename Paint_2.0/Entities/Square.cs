using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Paint_2._0.Entities
{
    public class Square : IFigure
    {
        public List<PointF> Points { get; set; } = new();
        public Color StrokeColor { get; set; } = Color.Black;
        public int StrokeThickness { get; set; } = 1;
        public Color? FillColor { get; set; }

        public void Create(PointF startPointF, PointF endPointF, Color color)
        {
            Points.Add(startPointF);
            Points.Add(new PointF(endPointF.X, startPointF.Y));
            Points.Add(endPointF);
            Points.Add(new PointF(startPointF.X, endPointF.Y));
            StrokeColor = color;
        }

        public void Create(PointF startPointF, Vector2 vector, Color color)
        {
            Points.Add(startPointF);
            Points.Add(new PointF(startPointF.X + vector.X, startPointF.Y));
            Points.Add(new PointF(
                startPointF.X + vector.X,
                startPointF.Y + vector.Y));
            Points.Add(new PointF(startPointF.X, startPointF.Y + vector.Y));
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
            Points.ForEach(p
                => p = new PointF(p.X + vector.X, p.Y + vector.Y));
        }

        public void StrokeThicknessChange(int thickness)
        {
            StrokeThickness = thickness;
        }
    }
}
