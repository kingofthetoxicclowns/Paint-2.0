using GeometryUtils;

namespace Paint_2._0.Tests.Geometry
{
    [TestClass]
    public class GeometryUtilityTest
    {
        /// <summary>
        /// ¬озвращает угол между двум€ векторами ab и bc
        /// </summary>
        /// <param name="a">“очка вектора ab</param>
        /// <param name="b">“очка пересечени€ векторов ab и bc</param>
        /// <param name="c">“очка вектора bc</param>
        /// <returns>”гол между векторами</returns>
        [TestMethod]
        public void GeometryUtility_GetAngle_90()
        {
            Point2 a = new(2, 2);
            Point2 b = new(2, 1);
            Point2 c = new(1, 1);

            float totalAngle = GeometryUtility.GetAngle(a, b, c);
            float expected = float.Pi / 2;

            Assert.AreEqual(expected, totalAngle);
        }

        [TestMethod]
        public void GeometryUtility_GetAngle_AcuteAngle() //острый угол
        {
            Point2 a = new(1, 5);
            Point2 b = new(4, 1);
            Point2 c = new(1, 1);

            float totalAngle = GeometryUtility.GetAngle(a, b, c);
            float expected = (float)Math.Acos(0.6);

            Assert.AreEqual(expected, totalAngle);
        }

        [TestMethod]
        public void GeometryUtility_GetAngle_ObtuseAngle() //тупой угол
        {
            Point2 a = new(0, 4);
            Point2 b = new(3, 0);
            Point2 c = new(8, 0);

            float totalAngle = GeometryUtility.GetAngle(a, b, c);
            float expected = -(float)Math.Acos(-0.6);

            Assert.AreEqual(expected, totalAngle);
        }

        [TestMethod]
        public void GeometryUtility_GetAngle_180()
        {
            Point2 a = new(1, 1);
            Point2 b = new(2, 2);
            Point2 c = new(3, 3);

            float totalAngle = GeometryUtility.GetAngle(a, b, c);
            float expected = (float)Math.PI;

            Assert.AreEqual(expected, totalAngle);
        }
        /// <summary>
        /// ѕровер€ет, находитс€ ли точка внутри области, ограниченной набором вершин.
        /// ƒл€ проверки используетс€ следующий принцип: сумма всех углов между точкой и двум€ смежными 
        /// вершинами полигона будет равна -2Pi или 2Pi, если точка внутри полигона и 
        /// близка к 0, если точка лежит за пределами полигона.
        /// </summary>
        /// <param name="point">“очка</param>
        /// <param name="polygon">¬ершины полигона</param>
        /// <returns>true, если точка внутри полигона</returns>
        [TestMethod]
        public void GeometryUtility_IsPointInsidePolygon_PointInsideSquare()
        {
            Point2 point = new Point2(2, 2);
            List<Point2> polygon =
            [
                new Point2(1, 1), new (3, 3)
            ];
            var tmp = GeometryUtility.IsPointInsidePolygon(point, polygon);

            Assert.IsTrue(tmp);

        }

        [TestMethod]
        public void GeometryUtility_IsPointInsidePolygon_PointOnSquare()
        {
            Point2 point = new(3, 3);
            List<Point2> polygon =
            [
                new Point2(1, 1), new Point2(3, 3)
            ];
            var tmp = GeometryUtility.IsPointInsidePolygon(point, polygon);

            Assert.IsTrue(tmp);

        }
        [TestMethod]
        public void GeometryUtility_IsPointInsidePolygon_Outside()
        {
            Point2 point = new(20, 20);
            List<Point2> polygon =
            [
                new Point2(1, 1), new Point2(3, 3)
            ];
            var tmp = GeometryUtility.IsPointInsidePolygon(point, polygon);

            Assert.IsFalse(tmp);

        }
        /// <summary>
        /// Ќаходит точку пересечени€ пр€мых ab и cd.
        /// —троитс€ уравнение пр€мой дл€ общего случа€, и когда векторы коллинеарны, но не равны.
        /// </summary>
        /// <param name="a">точка внутри полигона</param>
        /// <param name="b">предыдущее местоположение</param>
        /// <param name="c">перва€ точка сегманта</param>
        /// <param name="d">втора€ точка сегмента</param>
        /// <returns>“очка пересечени€ пр€мых ab и cd</returns>
        [TestMethod]
        public void StraightLinesIntersection_Lines_with_different_slopes()
        {
            // Test 1: Lines with different slopes
            var a = new Point2(1, 0);
            var b = new Point2(-1, 2);
            var c = new Point2(-2, 0);
            var d = new Point2(2, 4);
            Point2 expectedResult = new (-0.5f, 1.5f);
            Point2 actualResult = GeometryUtility.StraightLinesIntersection(a, b, c, d);
            Assert.AreEqual(expectedResult.X, actualResult.X);
            Assert.AreEqual(expectedResult.Y, actualResult.Y);
        }
        [TestMethod]
        public void StraightLinesIntersection_Lines_with_same_slopes()
        {
            // Test 2: Lines with same slope
            var a = new Point2(1, 0);
            var b = new Point2(-1, 2);
            var c = new Point2(2, 0);
            var d = new Point2(0, 2);
            var expectedResult = new Point2(4.333333f, 3.333333f);
            var actualResult = GeometryUtility.StraightLinesIntersection(a, b, c, d);
            Assert.AreEqual(expectedResult.X, actualResult.X);
            Assert.AreEqual(expectedResult.Y, actualResult.Y);
        }
        [TestMethod]
        public void StraightLinesIntersection_Vertical_and_horizontal_lines()
        {
            // Test 3: Vertical and horizontal lines
            var a = new Point2(1, 1);
            var b = new Point2(1, 4);
            var c = new Point2(4, 5);
            var d = new Point2(7, 5);
            var expectedResult = new Point2(4, 5);
            var actualResult = GeometryUtility.StraightLinesIntersection(a, b, c, d);
            Assert.AreEqual(expectedResult.X, actualResult.X);
            Assert.AreEqual(expectedResult.Y, actualResult.Y);
        }

    }
}