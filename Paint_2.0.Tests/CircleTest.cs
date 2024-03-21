using GeometryUtils;
using System.Net;

namespace Paint_2._0.Tests
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void Circle_DistanceTest()
        {
            Point2 a = new Point2(2, 2); 
            Point2 b = new Point2(3, 2); ;
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            var expected = 1;
            Assert.AreEqual(expected, Math.Sqrt(dx * dx + dy * dy));
        }
    }
}