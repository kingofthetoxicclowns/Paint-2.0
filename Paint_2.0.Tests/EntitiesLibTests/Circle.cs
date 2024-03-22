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
    public class CircleTests
    {
        [TestMethod]
        public void TestCreateWithTwoPoints()
        {
            Circle circle = new Circle();
            Point2 startPoint = new Point2(0, 0);
            Point2 endPoint = new Point2(3, 4);
            Color color = Color.Red;
            circle.Create(startPoint, endPoint, color);

            Assert.AreEqual(startPoint, circle.Points[0]);
            Assert.AreEqual(endPoint, circle.Points[1]);
            Assert.AreEqual(startPoint, circle.Center);
            Assert.AreEqual(5, circle.Radius);
            Assert.AreEqual(color, circle.StrokeColor);
        }

        [TestMethod]
        public void TestCreateWithStartPointAndVector()
        {
            Circle circle = new Circle();
            Point2 startPoint = new Point2(0, 0);
            Vector2 vector = new Vector2(3, 4);
            Color color = Color.Blue;
            circle.Create(startPoint, vector, color);

            Assert.AreEqual(startPoint, circle.Points[0]);
            Assert.AreEqual(new Point2(3, 4), circle.Points[1]);
            Assert.AreEqual(startPoint, circle.Center);
            Assert.AreEqual(5, circle.Radius);
            Assert.AreEqual(color, circle.StrokeColor);
        }

        [TestMethod]
        public void TestMove()
        {
            Circle circle = new Circle();
            circle.Points.Add(new Point2(0, 0));
            circle.Points.Add(new Point2(3, 4));
            Vector2 vector = new Vector2(2, 3);
            circle.Move(vector);

            Assert.AreEqual(new Point2(2, 3), circle.Points[0]);
            Assert.AreEqual(new Point2(5, 7), circle.Points[1]);
        }

        [TestMethod]
        public void TestStrokeColorChange()
        {
            Circle circle = new Circle();
            Color newColor = Color.Green;
            circle.StrokeColorChange(newColor);

            Assert.AreEqual(newColor, circle.StrokeColor);
        }

        [TestMethod]
        public void TestFill()
        {
            Circle circle = new Circle();
            Color fillColor = Color.Yellow;
            circle.Fill(fillColor);

            Assert.AreEqual(fillColor, circle.FillColor);
        }

        [TestMethod]
        public void TestStrokeThicknessChange()
        {
            Circle circle = new Circle();
            int newThickness = 3;
            circle.StrokeThicknessChange(newThickness);

            Assert.AreEqual(newThickness, circle.StrokeThickness);
        }

        [TestMethod]
        public void TestDistance()
        {
            Point2 a = new Point2(0, 0);
            Point2 b = new Point2(3, 4);
            double expectedDistance = 5;

            double actualDistance = Circle.Distance(a, b);

            Assert.AreEqual(expectedDistance, actualDistance);
        }
    }
}
