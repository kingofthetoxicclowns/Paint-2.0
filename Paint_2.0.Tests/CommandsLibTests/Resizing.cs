using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLib;
using GeometryUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using CommandsLib;
using ExCSS;
using System.Numerics;

namespace Paint_2._0.Tests.CommandsLibTests
{
    [TestClass]
    public class ResizingTests
    {
        [TestMethod]
        public void ExecuteByTwoPoints_ThrowsExceptionIfFigureIsNull()
        {
            Resizing resizing = new Resizing();

            Assert.ThrowsException<ArgumentNullException>(() => resizing.ExecuteByTwoPoints(new Point2(0, 0), new Point2(1, 1)));
        }

        [TestMethod]
        public void ExecuteByTwoPoints_Line_ResizesCorrectly()
        {
            Line line = new Line();
            line.Points.Add(new Point2(0, 0));
            line.Points.Add(new Point2(4, 4));
            Resizing resizing = new Resizing();
            resizing.Start(line);
            Point2 startPoint = new Point2(1, 1);
            Point2 endPoint = new Point2(6, 6);

            resizing.ExecuteByTwoPoints(startPoint, endPoint);

            Assert.AreEqual(6.5, line.Points[1].X);
            Assert.AreEqual(6.5, line.Points[1].Y);
            Assert.AreEqual(-2.5, line.Points[0].X);
            Assert.AreEqual(-2.5, line.Points[0].Y);
        }

        [TestMethod]
        public void ExecuteByTwoPoints_Circle_ResizesCorrectly()
        {
            Circle circle = new Circle();
            circle.Points.Add(new Point2(0, 0));
            circle.Points.Add(new Point2(5, 5));
            Resizing resizing = new Resizing();
            resizing.Start(circle);
            Point2 startPoint = new Point2(0, 0);
            Point2 endPoint = new Point2(3, 4);

            resizing.ExecuteByTwoPoints(startPoint, endPoint);

            Assert.AreEqual(8, circle.Points[1].X);
            Assert.AreEqual(9, circle.Points[1].Y);
        }

        [TestMethod]
        public void Start_SetsFigureAndIsCommandStart()
        {
            Resizing resizing = new Resizing();
            IFigure figure = new Circle();

            resizing.Start(figure);

            Assert.AreEqual(figure, resizing.Figure);
            Assert.IsTrue(resizing.IsCommandStart);
        }

        [TestMethod]
        public void Stop_ClearsFigureAndColor()
        {
            Resizing resizing = new Resizing();
            IFigure figure = new Line();
            resizing.Start(figure);

            resizing.Stop();

            Assert.IsNull(resizing.Figure);
            Assert.IsFalse(resizing.IsCommandStart);
        }
    }
}
