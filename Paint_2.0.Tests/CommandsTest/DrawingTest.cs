using GeometryUtils;
using EntitiesLib;
using CommandsLib;

namespace Tests.Commands
{
    [TestClass]
    public class DrawingTest
    {
        [TestMethod]
        public void Drawing_ExecuteByOnePoint()
        {
            IFigure figure = new Circle();
            Point2 point = new (2, 2);
            IFigureCommand command = new Drawing();
            //command.ExecuteByOnePoint(point);
            Assert.ThrowsException<ArgumentNullException>(() => command.ExecuteByOnePoint(point));
        }
        [TestMethod]
        public void Drawing_Stop()
        {
            IFigure figure = new Circle();
            Point2 point = new(2, 2);
            IFigureCommand command = new Drawing();
            command.Stop();
        }

    }
}
