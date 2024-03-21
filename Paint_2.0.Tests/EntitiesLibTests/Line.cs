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
    public class LineTests
    {
        [TestMethod]
        //две точки (начальная и конечная) и цвет линии
        public void Create_TwoPoints_AddsPointsToLine()
        {
            Line line = new Line();
            Point2 startPoint = new Point2(0, 0);
            Point2 endPoint = new Point2(5, 5);
            Color color = Color.Red;

            line.Create(startPoint, endPoint, color);

            Assert.AreEqual(2, line.Points.Count);
            Assert.AreEqual(startPoint, line.Points[0]);
            Assert.AreEqual(endPoint, line.Points[1]);
        }

        [TestMethod]
        //точка (начальная), вектор и цвет линии
        public void Create_StartPointAndVector_AddsPointsToLine()
        {
            Line line = new Line();
            Point2 startPoint = new Point2(0, 0);
            Vector2 vector = new Vector2(5, 5);
            Color color = Color.Blue;

            line.Create(startPoint, vector, color);

            Assert.AreEqual(2, line.Points.Count);
            Assert.AreEqual(startPoint, line.Points[0]);
            Assert.AreEqual(new Point2(5, 5), line.Points[1]);
            Assert.AreEqual(color, line.StrokeColor);
        }

        [TestMethod]
        //перемещение всех точек линии на заданный вектор
        public void Move_MoveByVector_MovesAllPoints()
        {
            Line line = new Line();
            line.Points.Add(new Point2(0, 0));
            line.Points.Add(new Point2(5, 5));
            Vector2 vector = new Vector2(3, 3);


            line.Move(vector);

            Assert.AreEqual(new Point2(3, 3), line.Points[0]);
            Assert.AreEqual(new Point2(8, 8), line.Points[1]);
        }

        [TestMethod]
        //изменение цвета линии
        public void StrokeColorChange_ChangesStrokeColor()
        {
            Line line = new Line();
            Color newColor = Color.Green;

            line.StrokeColorChange(newColor);

            Assert.AreEqual(newColor, line.StrokeColor);
        }

        [TestMethod]
        //изменение цвета заливки линии
        public void Fill_ChangesFillColor()
        {
            Line line = new Line();
            Color fillColor = Color.Yellow;

            line.Fill(fillColor);

            Assert.AreEqual(fillColor, line.FillColor);
        }

        [TestMethod]
        //изменение толщины линии
        public void StrokeThicknessChange_ChangesStrokeThickness()
        {
            Line line = new Line(); 
            int thickness = 3;

            line.StrokeThicknessChange(thickness);

            Assert.AreEqual(thickness, line.StrokeThickness);
        }
    }
}
