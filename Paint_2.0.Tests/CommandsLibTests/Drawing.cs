using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryUtils;
using System.Drawing;
using EntitiesLib;
using CommandsLib;

namespace Paint_2._0.Tests.CommandsLibTests
{
    [TestClass]
    public class DrawingTests
    {
        [TestMethod]
        public void Start_ThrowsExceptionIfFigureIsNull()
        {
            Drawing drawing = new Drawing();

            Assert.ThrowsException<ArgumentNullException>(() => drawing.Start(null, Color.Red));
        }

        [TestMethod]
        public void Start_ThrowsExceptionIfColorIsNull()
        {
            Drawing drawing = new Drawing();
            IFigure figure = new Square();

            Assert.ThrowsException<ArgumentNullException>(() => drawing.Start(figure, null));
        }

        [TestMethod]
        public void Start_WithValidFigureAndColor_SetsFigureColorAndStartpoint()
        {
            Drawing drawing = new Drawing();
            Square square = new Square();
            Color color = Color.Red;

            drawing.Start(square, color);

            Assert.AreEqual(square, drawing.Figure);
            Assert.AreEqual(color, drawing.Color);
            Assert.IsNotNull(drawing.Startpoint);
        }

        [TestMethod]
        public void ExecuteByOnePoint_ThrowsExceptionIfParametersNotInitialized()
        {
            Drawing drawing = new Drawing();

            Assert.ThrowsException<ArgumentNullException>(() => drawing.ExecuteByOnePoint(new Point2(1, 1)));
        }

        [TestMethod]
        public void ExecuteByOnePoint_CreatesFigureIfStartpointIsSet()
        {
            Drawing drawing = new Drawing();
            IFigure figure = new Line();
            drawing.Start(figure, Color.Red);
            Point2 startPoint = new Point2(0, 0);

            IFigure result = drawing.ExecuteByOnePoint(new Point2(1, 1));

            Assert.AreEqual(figure, result);
        }

        [TestMethod]
        public void Stop_ClearsFigureAndColorAndStartpoint()
        {
            Drawing drawing = new Drawing();
            Square square = new Square();
            Color color = Color.Green;
            drawing.Start(square, color);

            drawing.Stop();

            Assert.IsNull(drawing.Figure);
            Assert.IsNull(drawing.Color);
            Assert.IsNull(drawing.Startpoint);
            Assert.IsFalse(drawing.IsCommandStart);
        }
    }
}