using EntitiesLib;
using GeometryUtils;
using System.Drawing;

namespace Paint_2._0.Tests.FigureContainerTest
{
    [TestClass]
    public class FigureContainerTest
    {
        [TestMethod]
        public void Add_OneFigure()
        {
            FigureContainer container = new ();
            var figure = new Circle();
            container.Add(figure);
            Assert.AreEqual(1, container.Figures.Count);
            Assert.AreEqual(figure, container.Figures[0]);
        }
        [TestMethod]
        public void Add_AnyFigures()
        {
            FigureContainer container = new();
            IFigure figure1 = new Circle();
            IFigure figure2 = new Line();
            var figures = new List<IFigure>
            {
                figure1,
                figure2
            };

            container.Add(figures[0]);
            container.Add(figures[1]);

            Assert.AreEqual(2, container.Figures.Count);
            Assert.AreEqual(figures[0], container.Figures[0]);
            Assert.AreEqual(figures[1], container.Figures[1]);
        }
        [TestMethod]
        public void Select_OneCircle()
        {
            FigureContainer container = new();
            Point2 center = new (2, 2);
            Point2 point_on_circle = new (3, 2);
            Point2 point = new (2, 3);
            var circle = new Circle();
            circle.Create(center, point_on_circle, new Color());
            container.Add(circle);
            
            var result = container.Select(point);

            Assert.IsNotNull(result); 
            Assert.IsTrue(result.IsSelect);
            Assert.IsInstanceOfType(result, typeof(Circle));
            Assert.AreEqual(new Point2(2,2), ((Circle)result).Center);
            Assert.AreEqual(1, ((Circle)result).Radius);
        }
        [TestMethod]
        public void Select_OneSquare()
        {
            FigureContainer container = new();
            Point2 left_point = new(2, 2);
            Point2 right_point = new(3, 3);
            Point2 point = new(2, 3);
            var square = new Square();
            square.Create(left_point, right_point, new Color());
            container.Add(square);

            var result = container.Select(point);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSelect);
            Assert.IsInstanceOfType(result, typeof(Square));
        }
        [TestMethod]
        public void Select_OneLine()
        {
            FigureContainer container = new();
            Point2 a = new(2, 2);
            Point2 b = new(4, 2);
            Point2 point = new(3, 2);
            var line = new Line();
            line.Create(a, b, new Color());
            container.Add(line);

            var result = container.Select(point);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSelect);
            Assert.IsInstanceOfType(result, typeof(Line));
        }
        [TestMethod]
        public void Select_Line_but_Container_has_other_Figures()
        {
            FigureContainer container = new();
            Point point = new(4, 2);
            var line = new Line();var circle = new Circle();var square = new Square();
            circle.Create(new Point2(2, 2), new Point2(3, 2), new Color());
            square.Create(new Point2(2, 2), new Point2(3, 3), new Color());
            line.Create(new Point2(2, 2), new Point2(5, 2), new Color());
            container.Add(square);
            container.Add(line);
            container.Add(circle);

            var result = container.Select(point);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSelect);
            Assert.IsInstanceOfType(result, typeof(Line));
            Assert.AreEqual(3, container.Figures.Count);
        }
        [TestMethod]
        public void Select_Circle_but_Container_has_other_Figures()
        {
            FigureContainer container = new();
            Point point = new(1, 2);
            var line = new Line(); var circle = new Circle(); var square = new Square();
            circle.Create(new Point2(2, 2), new Point2(3, 2), new Color());
            square.Create(new Point2(2, 2), new Point2(3, 3), new Color());
            line.Create(new Point2(2, 2), new Point2(5, 2), new Color());
            container.Add(square);
            container.Add(line);
            container.Add(circle);

            var result = container.Select(point);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSelect);
            Assert.IsInstanceOfType(result, typeof(Circle));
            Assert.AreEqual(3, container.Figures.Count);
        }
        [TestMethod]
        public void Select_Square_but_Container_has_other_Figures()
        {
            FigureContainer container = new();
            Point2 point = new(2.8f, 3);
            var line = new Line(); var circle = new Circle(); var square = new Square();
            circle.Create(new Point2(2, 2), new Point2(3, 2), new Color());
            square.Create(new Point2(2, 2), new Point2(3, 3), new Color());
            line.Create(new Point2(2, 2), new Point2(5, 2), new Color());
            container.Add(square);
            container.Add(line);
            container.Add(circle);

            var result = container.Select(point);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSelect);
            Assert.IsInstanceOfType(result, typeof(Square));
            Assert.AreEqual(3, container.Figures.Count);
        }
        [TestMethod]
        public void Select_Point_does_not_belong_toFigures()
        {
            FigureContainer container = new();
            Point2 point = new(10, 10);
            var line = new Line(); var circle = new Circle(); var square = new Square();
            circle.Create(new Point2(2, 2), new Point2(3, 2), new Color());
            square.Create(new Point2(2, 2), new Point2(3, 3), new Color());
            line.Create(new Point2(2, 2), new Point2(5, 2), new Color());
            container.Add(square);
            container.Add(line);
            container.Add(circle);

            var result = container.Select(point);

            Assert.IsNull(result);
            Assert.IsFalse(container.Figures[0].IsSelect);
            Assert.IsNotInstanceOfType(result, typeof(Square));
            Assert.AreEqual(3, container.Figures.Count);
        }
    }
}
