using EntitiesLib;
using GeometryUtils;

namespace Paint_2._0.Tests.Geometry
{
    [TestClass]
    public class Point2Test
    {
        [TestMethod]
        public void IsEmptyTest_X_and_Y_is_Zero()
        {
            Point2 point = new (0, 0);
            Assert.IsTrue(point.IsEmpty);
        }
        [TestMethod]
        public void IsEmptyTest_Y_is_Zero()
        {
            Point2 point = new(2, 0);
            Assert.IsFalse(point.IsEmpty);
        }
        [TestMethod]
        public void IsEmptyTest_X_is_Zero()
        {
            Point2 point = new(0, 2);
            Assert.IsFalse(point.IsEmpty);
        }
        [TestMethod]
        public void IsEmptyTest_X_and_Y_is_not_Zero()
        {
            Point2 point = new(2, 2);
            Assert.IsFalse(point.IsEmpty);
        }
        [TestMethod]
        public void Operator_Plus_OnePoint_has_NegX()
        {
            Point2 a = new(2, 2);
            Point2 b = new(-2, 2);
            Point2 expected = new (0, 4);
            var result = a + b;
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
        }
        [TestMethod]
        public void Operator_Plus_OnePoint_has_NegY()
        {
            Point2 a = new(2, -2);
            Point2 b = new(2, 2);
            var expected = new Point2(4, 0);
            var result = a + b;
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
        }
        [TestMethod]
        public void Operator_Plus_BothPoint_has_NegY()
        {
            Point2 a = new(2, -2);
            Point2 b = new(2, -2);
            var expected = new Point2(4, -4);
            var result = a + b;
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
        }
        [TestMethod]
        public void Operator_Plus_BothPoint_has_NegX()
        {
            Point2 a = new(-2, 2);
            Point2 b = new(-2, 2);
            var expected = new Point2(-4, 4);
            var result = a + b;
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
        }
        [TestMethod]
        public void Operator_Plus_BothPoint_has_NegX_and_Y()
        {
            Point2 a = new(-2, -2);
            Point2 b = new(-2, -2);
            var expected = new Point2(-4, -4);
            var result = a + b;
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
        }
        [TestMethod]
        public void Operator_PlusPlus_Point_has_NegX_and_Y()
        {
            Point2 a = new(-2, -2);
            var expected = new Point2(-1, -1);
            var result = ++a;
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
        }
        [TestMethod]
        public void Operator_PlusPlus_Point_has_NegX()
        {
            Point2 a = new(-2, 2);
            var expected = new Point2(-1, 3);
            var result = ++a;
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
        }
        [TestMethod]
        public void Operator_PlusPlus_Point_has_NegY()
        {
            Point2 a = new(2, -2);
            var expected = new Point2(3, -1);
            var result = ++a;
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
        }
        [TestMethod]
        public void Operator_PlusPlus_Point_has_PosXY()
        {
            Point2 a = new(2, 2);
            var expected = new Point2(3, 3);
            var result = ++a;
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
        }
    }
}
