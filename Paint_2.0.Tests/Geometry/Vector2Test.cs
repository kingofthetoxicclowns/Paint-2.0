using EntitiesLib;
using GeometryUtils;

namespace Paint_2._0.Tests.Geometry
{
    [TestClass]
    public class Vector2Test
    {
        [TestMethod]
        public void Lenght_PositiveXY()
        {
            Vector2 vector = new (3, 4);
            var actual = vector.Length;
            Assert.AreEqual(5, actual);
        }
        [TestMethod]
        public void Lenght_NegativeX()
        {
            Vector2 vector = new(-3, 4);
            var actual = vector.Length;
            Assert.AreEqual(5, actual);
        }
        [TestMethod]
        public void Lenght_NegativeY()
        {
            Vector2 vector = new(3, -4);
            var actual = vector.Length;
            Assert.AreEqual(5, actual);
        }
        [TestMethod]
        public void Lenght_NegativeXY()
        {
            Vector2 vector = new(-3, -4);
            var actual = vector.Length;
            Assert.AreEqual(5, actual);
        }
        [TestMethod]
        public void Lengh_One()
        {
            Vector2 vector = new(0, 0);
            var actual = vector.Length;
            Assert.AreEqual(0, actual);
        }
        [TestMethod]
        public void Lengh_Zero()
        {
            Vector2 vector = new(0, 0);
            var actual = vector.Length;
            Assert.AreEqual(0, actual);
        }
        [TestMethod]
        public void Normalize_X_is_One()
        {
            Vector2 vector = new(1, 0);
            vector.Normalize();
            Vector2 expected = new (1, 0);
            Assert.AreEqual(expected.X, vector.X);
            Assert.AreEqual(expected.Y, vector.Y);
        }

        [TestMethod]
        public void Normalize_PositiveXY()
        {
            Vector2 vector = new(3, 4);
            vector.Normalize();
            var length = (float)Math.Sqrt(3 * 3 + 4 * 4);
            Vector2 expected = new(3/length, 4 / length);
            Assert.AreEqual(expected.X, vector.X);
            Assert.AreEqual(expected.Y, vector.Y);
        }
        [TestMethod]
        public void Normalize_Zero()
        {
            Vector2 vector = new(0, 0);
            vector.Normalize();
            Vector2 expected = new(0, 0);
            Assert.AreEqual(expected.X, vector.X);
            Assert.AreEqual(expected.Y, vector.Y);
        }
    }
}
