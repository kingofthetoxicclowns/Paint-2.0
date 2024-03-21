using EntitiesLib;
using GeometryUtils;

namespace Paint_2._0.Tests.Geometry
{
    [TestClass]
    public class Vector2Test
    {
        [TestMethod]
        public void Lenght()
        {
            Point2 point1 = new(2, 2);
            Point2 point2 = new(5, 6);
            Vector2 vector = new (point1.X - point2.X, point1.Y-point2.Y);
            var actual = vector.Length;
            Assert.AreEqual(5, actual);





        }
    }
}
