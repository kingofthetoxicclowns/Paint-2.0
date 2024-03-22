using CommandsLib;
using EntitiesLib;
using GeometryUtils;
using Paint_2._0;
using Paint_2._0.IO;
using System.Drawing;

namespace Tests.IO
{
    [TestClass]
    public class IOTest()
    {
        [TestMethod]
        public void MakeFileFilter()
        {
            var expectedFilterString = "svg|*.svg|jpeg|*.jpeg|png|*.png";

            var filterString = Paint_2._0.IO.IO.MakeFileFilter();

            Assert.AreEqual(expectedFilterString, filterString);
        }
        [TestMethod]
        public void CanvasToSVG_Return0()
        {
            FigureContainer container = new();
            var line = new Line(); var circle = new Circle(); var square = new Square();
            circle.Create(new Point2(2, 2), new Point2(3, 2), new Color());
            square.Create(new Point2(2, 2), new Point2(3, 3), new Color());
            line.Create(new Point2(2, 2), new Point2(5, 2), new Color());
            container.Add(square);
            container.Add(line);
            container.Add(circle);
            string filePath = "test.svg";

            int actual = Paint_2._0.IO.IO.CanvasToSVG(container, filePath);

            Assert.IsTrue(File.Exists(filePath));
            Assert.AreEqual(0, actual);
        }
        public class CurvedLine : IFigure
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
                for (int i = 0; i < Points.Count(); i++)
                {
                    Points[i].X += vector.X;
                    Points[i].Y += vector.Y;
                }
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
        [TestMethod]
        public void CanvasToSVG_Return1()
        {
            FigureContainer container = new();
            var line = new Line(); var circle = new Circle(); var square = new Square(); var curvedLine = new CurvedLine();
            circle.Create(new Point2(2, 2), new Point2(3, 2), new Color());
            square.Create(new Point2(2, 2), new Point2(3, 3), new Color());
            line.Create(new Point2(2, 2), new Point2(5, 2), new Color());
            container.Add(square);
            container.Add(line);
            container.Add(circle);
            container.Add(curvedLine);
            string filePath = "test.svg";

            int actual = Paint_2._0.IO.IO.CanvasToSVG(container, filePath);

            Assert.IsTrue(File.Exists(filePath));
            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        public void SVGToBitmapFormat_ToPng()
        {
            string svgPath = "test.svg";
            string outputPath = "test.png";
            int width = 360; int height = 360;

            Paint_2._0.IO.IO.SVGToBitmapFormat(svgPath, outputPath, width,height);
            
            Assert.IsTrue(File.Exists(outputPath));
        }
        [TestMethod]
        public void SVGToBitmapFormat_Tojpeg()
        {
            string svgPath = "test.svg";
            string outputPath = "test.jpeg";
            int width = 360; int height = 360;

            Paint_2._0.IO.IO.SVGToBitmapFormat(svgPath, outputPath, width, height);

            Assert.IsTrue(File.Exists(outputPath));
        }
        [TestMethod]
        public void SVGToBitmapFormat_WithInvalidFormat_ThrowsException()
        {
            string svgPath = "test.svg";
            string outputPath = "test.invalid";
            int width = 100;
            int height = 100;

            Assert.ThrowsException<Exception>(() => Paint_2._0.IO.IO.SVGToBitmapFormat(svgPath, outputPath, width, height));
        }
        [TestMethod]
        public void SVGToCanvas_NotEmptyContainer()
        {
            string svgPath = "test.svg";
            var resultContainer = Paint_2._0.IO.IO.SVGToCanvas(svgPath);
            Assert.AreEqual(3,resultContainer.Figures.Count);
        }
        [TestMethod]
        public void SVGToCanvas_EmptyContainer()
        {
            FigureContainer container = new();
            string svgPath = "123.svg";
            Paint_2._0.IO.IO.CanvasToSVG(container, svgPath);

            var resultContainer = Paint_2._0.IO.IO.SVGToCanvas(svgPath);
            
            Assert.AreEqual(0, resultContainer.Figures.Count);
        }
    }
}
