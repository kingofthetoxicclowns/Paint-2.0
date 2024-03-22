using GeometryUtils;
using EntitiesLib;
using System.Drawing;

namespace Paint_2._0.Tests.EntitiesLibTest
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void Circle_DistanceTest()
        {
            Point2 a = new(2, 2);
            Point2 b = new(3, 2);
            var expected = 1;
            Assert.AreEqual(expected, Circle.Distance(a, b));
        }

    }
}