using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLib;
using GeometryUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Paint_2._0.Tests.EntitiesLibTests
{
    [TestClass]
    public class SquareTests
    {
        [TestMethod]
        public void Create_TwoPoints_CreatesSquare()
        {
            Square square = new Square();
            Point2 startPoint = new Point2(0, 0);
            Point2 endPoint = new Point2(2, 2);
            Color color = Color.Red;

            square.Create(startPoint, endPoint, color);

            Assert.AreEqual(4, square.Points.Count);
            Assert.AreEqual(color, square.StrokeColor);
        }

        [TestMethod]
        public void Create_PointAndVector_CreatesSquare()
        {
            Square square = new Square();
            Point2 startPoint = new Point2(1, 1);
            Vector2 vector = new Vector2(2, 2);
            Color color = Color.Blue;

            square.Create(startPoint, vector, color);

            Assert.AreEqual(4, square.Points.Count);
            Assert.AreEqual(color, square.StrokeColor);
        }

        [TestMethod]
        public void Move_MoveByVector_MovesAllPoints()
        {
            Square square = new Square();
            square.Points.Add(new Point2(0, 0));
            square.Points.Add(new Point2(2, 0));
            square.Points.Add(new Point2(2, 2));
            square.Points.Add(new Point2(0, 2));
            Vector2 vector = new Vector2(1, 1);

            square.Move(vector);

            Assert.AreEqual(new Point2(1, 1), square.Points[0]);
            Assert.AreEqual(new Point2(3, 1), square.Points[1]);
            Assert.AreEqual(new Point2(3, 3), square.Points[2]);
            Assert.AreEqual(new Point2(1, 3), square.Points[3]);
        }

        [TestMethod]
        public void StrokeColorChange_ChangesColor()
        {
            Square square = new Square();
            Color color = Color.Green;

            square.StrokeColorChange(color);

            Assert.AreEqual(color, square.StrokeColor);
        }

        [TestMethod]
        public void Fill_ChangesFillColor()
        {
            Square square = new Square();
            Color color = Color.Yellow;

            square.Fill(color);

            Assert.AreEqual(color, square.FillColor);
        }

        [TestMethod]
        public void StrokeThicknessChange_ChangesThickness()
        {
            Square square = new Square();
            int thickness = 3;

            square.StrokeThicknessChange(thickness);

            Assert.AreEqual(thickness, square.StrokeThickness);
        }
    }
}
