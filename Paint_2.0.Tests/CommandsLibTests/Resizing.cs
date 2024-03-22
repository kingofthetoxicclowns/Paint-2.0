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
    public class ResizingTests
    {
        [TestMethod]
        public void ExecuteByTwoPoints_ThrowsExceptionIfFigureIsNull()
        {
            Resizing resizing = new Resizing();

            Assert.ThrowsException<ArgumentNullException>(() => resizing.ExecuteByTwoPoints(new Point2(0, 0), new Point2(1, 1)));
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