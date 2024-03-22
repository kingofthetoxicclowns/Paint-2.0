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

namespace Paint_2._0.Tests.CommandsLibTests
{
    [TestClass]
    public class FillingTests
    {
        [TestMethod]
        //не инициализированная фигура
        public void Start_ThrowsExceptionIfFigureIsNull()
        {
            Filling filling = new Filling();

            Assert.ThrowsException<ArgumentNullException>(() => filling.Start(null));
        }

        [TestMethod]
        //фигура равна установленной фигуре
        public void Start_WithValidFigure_SetsFigureAndIsCommandStartToTrue()
        {
            Filling filling = new Filling();
            Square square = new Square();
            Point2 startPoint = new Point2(0, 0);
            Point2 endPoint = new Point2(1, 1);

            filling.Start(square, Color.Blue);

            Assert.AreEqual(square, filling.Figure);
        }

        [TestMethod]
        //при вызове метода ExecuteByColor() с нулевой фигурой выбрасывается исключение 
        public void ExecuteByColor_ThrowsExceptionIfFigureIsNull()
        {
            Filling filling = new Filling();

            Assert.ThrowsException<ArgumentNullException>(() => filling.ExecuteByColor(Color.Red));
        }

        [TestMethod]
        //метод ExecuteByColor() корректно устанавливает цвет заливки выбранной фигуры и флаг IsCommandStart
        public void ExecuteByColor_SetsFillColorAndIsCommandStart()
        {
            Filling filling = new Filling();
            IFigure figure = new Circle();
            filling.Start(figure);

            filling.ExecuteByColor(Color.Blue);

            Assert.AreEqual(Color.Blue, figure.FillColor);
            Assert.IsTrue(filling.IsCommandStart);
        }

        [TestMethod]
        //метод Stop() очищает установленную фигуру и сбрасывает флаг IsCommandStart в false
        public void Stop_ClearsFigureAndIsCommandStart()
        {
            Filling filling = new Filling();
            IFigure figure = new Line();
            filling.Start(figure);

            filling.Stop();

            Assert.IsNull(filling.Figure);
            Assert.IsFalse(filling.IsCommandStart);
        }
    }
}
