using CommandsLib;
using EntitiesLib;
using GeometryUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLib;
using GeometryUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Paint_2._0.Tests.CommandsLibTests
{
    [TestClass]
    public class MovingTests
    {
        [TestMethod]
        //фигура не задана
        public void Start_ThrowsExceptionIfFigureIsNull()
        {
            Moving moving = new Moving();

            Assert.ThrowsException<ArgumentNullException>(() => moving.Start(null));
        }

        [TestMethod]
        //инициализация фигуры
        public void Start_WithFigure_SetsFigureAndIsCommandStart()
        {
            Moving moving = new Moving();
            IFigure figure = new Square();

            moving.Start(figure);

            Assert.AreEqual(figure, moving.Figure);
            Assert.AreEqual(true, moving.IsCommandStart);
        }

        [TestMethod]
        //фигура не задана
        public void ExecuteByTwoPoints_ThrowsExceptionIfFigureIsNotInitialized()
        {
            Moving moving = new Moving();

            Assert.ThrowsException<ArgumentNullException>(() => moving.ExecuteByTwoPoints(new Point2(0, 0), new Point2(1, 1)));
        }

        [TestMethod]
        //перемещение фигуры
        public void ExecuteByTwoPoints_MovePoints()
        {
            Moving moving = new Moving();
            IFigure figure = new Square();
            figure.Points.Add(new Point2(0, 0));
            figure.Points.Add(new Point2(1, 1));
            Point2 startPoint = new Point2(1, 1);
            Point2 point = new Point2(3, 3);
           
            moving.Start(figure);

            moving.ExecuteByTwoPoints(startPoint, point);

            Assert.AreEqual(2, figure.Points[0].X);
            Assert.AreEqual(2, figure.Points[0].Y);
            Assert.AreEqual(3, figure.Points[1].X);
            Assert.AreEqual(3, figure.Points[1].Y);
        }

        [TestMethod]
        //завершение перемещения
        public void Stop_ResetsFigureAndIsCommandStart()
        {
            Moving moving = new Moving();
            IFigure figure = new Square();
            moving.Start(figure);

            moving.Stop();

            Assert.IsNull(moving.Figure);
            Assert.IsFalse(moving.IsCommandStart);
        }
    }
}
